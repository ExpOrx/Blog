<?php 

define('BASE_PATH', dirname(dirname(__FILE__)));
define('APP_FOLDER','simpleadmin');


require_once BASE_PATH.'/lib/MysqliDb.php';
$servername = "localhost";
$username = "debian-sys-maint";
$password = "eYo9GWevgm2xEPEA";
$dbname = "sdfsdfsdfsd";

$transport_key = "LJH4bjl5hj9fdf6d";

$db =new MysqliDb($servername,$username,$password,$dbname);
