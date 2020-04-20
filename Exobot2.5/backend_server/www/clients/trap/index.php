<?php

if(!empty($_SERVER["HTTP_CLIENT_IP"])) {
	$ip = $_SERVER["HTTP_CLIENT_IP"];
} elseif(!empty($_SERVER["HTTP_X_FORWARDED_FOR"])) {
	$ip = $_SERVER["HTTP_X_FORWARDED_FOR"];
} elseif(isset($_SERVER["REMOTE_ADDR"])) {
	$ip = $_SERVER["REMOTE_ADDR"];
} else {
	$ip = "unknown";
}

$ua = $_SERVER['HTTP_USER_AGENT'];
$d = date("d.m.Y G:i:s", time());
$data = "Time: {$d}; URI: " . $_SERVER['REQUEST_URI'] . "; IP: {$ip}; UserAgent: {$ua}\n";

@file_put_contents('../../cp/panel/vps_fucked', $data, FILE_APPEND);

if(isset($_SERVER['REQUEST_URI']))
	$uri = $_SERVER['REQUEST_URI'];
else
	$uri = '/';

$err = <<<PHP
<!DOCTYPE HTML PUBLIC "-//IETF//DTD HTML 2.0//EN">
<html><head>
<title>404 Not Found</title>
</head><body>
<h1>Not Found</h1>
<p>The requested URL {$uri} was not found on this server.</p>
</body></html>
PHP;
header("HTTP/1.0 404 Not Found");
die($err);

