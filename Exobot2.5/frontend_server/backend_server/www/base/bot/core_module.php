<?php
if(!defined('MODE')) hlp::show_404();
require_once(dirname(__FILE__) . "/pdo.php");
 
class coreModule
{
	public $client_cfg = null;
	public $db = null;
	
	function __construct()
	{
		$this->db = new Db();
		$this->db->connect();

		$this->client_cfg = array();
		$this->client_cfg['db_name'] = DB_NAME;
		$this->client_cfg['db_user'] = DB_USER;
		$this->client_cfg['db_main'] = DB_MAIN;
		$this->client_cfg['uid'] = UID;
		$this->client_cfg['guest_url'] = GUEST_URL;
		$this->client_cfg['name'] = CLIENT;

		$sql = "select name, value from {$this->client_cfg['db_name']}.config";
		$data = $this->db->exec($sql, null, true);
		
		foreach($data as $elem)
			if(hlp::endsWith($elem['name'], '_list'))
				$this->client_cfg[$elem['name']] = hlp::list2array($elem['value'], "\n");
			else
				$this->client_cfg[$elem['name']] = $elem['value'];
	}
	
}
