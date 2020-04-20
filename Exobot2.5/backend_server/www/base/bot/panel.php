<?php
if(!defined('MODE')) hlp::show_404();
require_once "ajax.php";

class Panel extends coreModule
{
	
	function __construct()
	{
		parent::__construct();
	}
	
	// response with json
	public function process_ajax($data)
	{
		$app = new Ajax($this->db);
		return $app->process($data);
	}

	// response with html
	public function process_request($data)
	{
		$app = new modBase($this->db);
		
		// hack for file downloads (it works with iframe, not ajax)
		if(hlp::get($data, 'X-Requested-With', '') == 'xmlhttprequest')
			return $this->process_ajax($data);
		
		$user_ip = hlp::get_client_ip();
		if(empty($_COOKIE['login']) || empty($_COOKIE['sessid']) || !$app->check_user_ssid($_COOKIE['login'], $_COOKIE['sessid'], $user_ip))
		{
			$app->clear_cookies();
			return $app->draw_tpl('login');
		}
		
		return $app->show_main_page();
	}

	// response with html
	public function show_guest_stats()
	{
		require_once "mods/statistics.php";
		$stat = new statistics($this->db);
		$html = $stat->get_content(true);
		$main_html = file_get_contents(dirname(__FILE__) . "/tpls/main.html");
		preg_match_all("/(%[^%]+%)/", $main_html, $results);
		
		if($results)
		foreach($results as $macros)
			$main_html = str_replace($macros, "", $main_html);
		
		// insert content
		$main_html = preg_replace("(<div id=\"content\".*>)", "\1{$html}", $main_html);
		
		// remove scripts
		$main_html = preg_replace("(<script.*></script>\s*)", "", $main_html);
		
		// get params from db, no input parameters
		return $main_html;
	}
}














