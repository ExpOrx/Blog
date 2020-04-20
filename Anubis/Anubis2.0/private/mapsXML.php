<?php

include 'config.php';

$dom = new DOMDocument('1.0');
$node = $dom->createElement("markers");
$parnode = $dom->appendChild($node);
// Opens a connection to a mySQL server


$connection = new PDO('mysql:host='.SERVER.';dbname='.DB, USER, PASSWORD);
$connection->exec('SET NAMES utf8');       
$query = ("SELECT * FROM markers");

header("Content-type: text/xml");
foreach($connection->query($query) as $row)
	{
	  // Add to XML document node
	  $node = $dom->createElement("marker");
	  $newnode = $parnode->appendChild($node);
	  $newnode->setAttribute("name",$row['name']);
	  $newnode->setAttribute("lat", $row['lat']);
	  $newnode->setAttribute("lng", $row['lng']);
	  $newnode->setAttribute("type", $row['type']);
	  $newnode->setAttribute("provayder", $row['provayder']);
	  $newnode->setAttribute("time", $row['time']);
	}
echo $dom->saveXML();
?>
