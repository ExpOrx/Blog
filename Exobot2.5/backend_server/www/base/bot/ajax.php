<?php
if(!defined('MODE')) hlp::show_404();

require_once(dirname(__FILE__) . "/pdo.php");
require_once(dirname(__FILE__) . "/hlp.php");
require_once(dirname(__FILE__) . "/cmd_bot.php");
require_once(dirname(__FILE__) . "/cmd_panel.php");
require_once(dirname(__FILE__) . "/cmd_mod.php");

// panel -> ajax request - Ajax (this) - cmd_bot OR cmd_panel methods - db
class Ajax  extends coreModule
{
	public $db;
	private $cmd_bot; 
	private $cmd_panel; 

	function __construct($db)
	{
		parent::__construct();
		$this->db = $db;
		
		$this->cmd_bot = new CmdBot($this);
		$this->cmd_panel = new CmdPanel($this);
	}
	
	public function show_response($msg, $title='')
	{
		$d = array('title' => $title, 'response' => $msg);
		die(json_encode($d));
	}

	// process command from the panel
	function process($data)
	{
		if(!$this->db->is_connected)
			$this->show_response('Database problem', 'Error');
			
		if(!array_key_exists('cmd', $data))
			$this->show_response('Bad command', 'Error');

		$c = $data['cmd'];
		
		if(hlp::startsWith($c, "panel_"))
		{
			// cmd_panel_cancel_task
			$method = explode('panel_', $c)[1];
			
			if(method_exists($this->cmd_panel, $method))
			{
				// $this->cmd_panel->cancel_task($data);
				call_user_method($method, $this->cmd_panel, $data);
				$this->show_response("<b>show_response</b> in cmd_panel.<b>{$c}</b> is not specified", 'Error');
			}
			
		}else if($c == "get_mod"){
			
			$path = dirname(__FILE__) . "/mods/{$data['name']}.php";
			if(file_exists($path))
			{
				require $path;
				$obj = new $data['name']($this->db);
				
				$content = $obj->init($data['type'], hlp::get($data, 'filter', array()), $this->client_cfg);

				# update system time in corner
				if($data['type'] == 'content')
				{
					$time = str_replace(' ', '<br />', date("G:i d.m.Y"));
					$content .= "<script>$('#server_time').html('{$time}')</script>";
				}
				
				$res = array('content' => $content);
				die(print(json_encode($res)));
			}else{
				$res = array('content' => 'Bad mod: ' . $data['name']);
				die(print(json_encode($res)));
			}
			
		}else if(hlp::startsWith($c, "bot_"))
		{
			// cmd_bot_send_sms
			$cmd = explode('bot_', $c)[1];
			$this->cmd_bot->_set_command($cmd, $data);
		}
		
		$this->show_response('Bad command ' . $c, 'Error');
	}

}





















