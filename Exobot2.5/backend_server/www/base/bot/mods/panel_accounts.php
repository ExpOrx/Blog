<?php
require_once "cmd_mod.php";

class panel_accounts extends modBase
{
	protected $module_name = 'panel_accounts';

	function get_content()
	{
	
		if(hlp::get($this->client_cfg, 'light_mode', false))
		{
			$content = "<div class='row'>
				<div class='col-md-12' style='font-size: 32pt; text-align: center'>
					<span class='fui-user marginRight10'></span>
					Panel accounts</div>
			</div>
			<div>&nbsp;</div>
			<div><center><h4>Disabled in Light version</h4></center></div>";
			
			return $this->wrap_content("", $content);
		}
		
		if($this->client_cfg['last_login'] != 'admin')
			die;
			
		$buttons = array(
			//~ array('Add account', 'Add new account', 'go_to_hash("add_account")', 'info'),
		);
		
		$sql = "select id, login, status from users";
		$rows = $this->db->exec($sql, null, true);
		
		if(!$rows)
			return $this->wrap_content("Total: 0", $content, 0, $buttons);
		
		$headers = array('ID', 'Login', 'Is admin?', 'Status', 'Actions');
		$total = sizeof($rows);
		$users = array();
		foreach($rows as $row)
		{
			$actions = '';
			if($row['login'] != 'admin')
				$actions = "<button type='button' class='btn btn-danger' onclick='show_ajax_form(\"panel_delete_account\", [{$row['id']}])'>Delete</button>&nbsp;";
			
			switch($row['status'])
			{
				case 'active':
					$status = "<span style='color: blue; font-style: italic'>active</span>";
					if($row['login'] != 'admin')
						$actions .= "<button type='button' class='btn btn-warning' onclick='show_ajax_form(\"panel_disable_account\", [{$row['id']}])'>Disable</button>";
					break;
				case 'disabled':
					$status = "<span style='color: darkred; font-style: italic'>disabled</span>";
					if($row['login'] != 'admin')
						$actions .= "<button type='button' class='btn btn-info' onclick='show_ajax_form(\"panel_enable_account\", [{$row['id']}])'>Enable</button>";
					break;
				default:
					$status = $row['status'];
			}
			
			$user = array(
				$row['id'],
				$row['login'],
				($row['login'] == 'admin')? "<span style='color: blue; font-style: italic'>Yes</span>" : "No",
				$status,
				$actions,
			);
			
			$users[] = $user;
		}
		
		$content = "
		<div class='row'>
			<div class='col-md-12' style='font-size: 32pt; text-align: center'>
				<span class='fui-user marginRight10'></span>
				Panel accounts</div>
		</div>
		<div>&nbsp;</div>
		<div>Current account: {$this->client_cfg['last_login']}</div>
		";
		
		$content .= $this->get_table($users, $headers, 'textcenter');
		
		$content .= <<<PHP
		<div class='row'>
			<div class='col-md-6'>&nbsp;</div>
			<div class='col-md-2'>
				<input type='text' id="new_login" class='form-control' placeholder='Login' />
			</div>
			<div class='col-md-2'>
				<input type='text' id="new_password" class='form-control' placeholder='Password' />
			</div>
			<div class='col-md-2'>
				<button type='button' class='btn btn-primary' onclick='add_account()'>Add new account</button>
			</div>
			
		</div>
PHP;

		return $this->wrap_content("Total: {$total}", $content, 0, $buttons);
	}
}
