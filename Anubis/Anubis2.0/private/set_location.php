<?php
$request = htmlspecialchars($_REQUEST["p"], ENT_QUOTES);
include 'crypt.php';
include 'config.php';
$request = decrypt($request,cryptKey);

//echo encrypt("sssssss","qSeADfgzxR");
//echo decrypt("SSf SSf SSf SSf SSf SSf SSf","qSeADfgzxR");

$massivReq = explode(":", $request);
$IMEI = $massivReq[0]; 
$lat = $massivReq[1]; 
$lon = $massivReq[2]; 
$netgps =$massivReq[3];  

$connection = new PDO('mysql:host='.SERVER.';dbname='.DB, USER, PASSWORD);
$connection->exec('SET NAMES utf8');
$sql = "SELECT * FROM markers WHERE name='$IMEI'";
$data_time = date('Y-m-d H:i');


$booIMEI = false;

foreach($connection->query($sql) as $row)
{
	if($row['name']==$IMEI)
	{
		$booIMEI=true;	
		break;
	}
}
if($booIMEI == false)
{
	
$a1 = array("Q","W","E","R","T","Y","U","I","O","P","A","S","D","F","G","H","J","K"
,"L","Z","X","C","V","B","N","M","q","w","e","r","t","y","u","i","o","p","a","s","d"
,"f","g","h","j","k","l","z","x","c","v","b","n","m");
$typeR  = $a1[rand(0, 51)];

	$add_data = $connection->exec("insert into markers (name, lat, lng, type, provayder, time) 
	value ('$IMEI','$lat','$lon', '$typeR','$netgps','$data_time')");
	
	//echo "$IMEI|$lat|$lon|$netgps|$data_time|";
	echo "";
}
else
{
	$sql3 = "UPDATE markers SET name = '$IMEI', lat='$lat', lng='$lon', provayder='$netgps', time = '$data_time' WHERE name = '$IMEI';";
	$connection->query($sql3);

	echo "";
}
?>