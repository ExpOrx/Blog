<?php
require_once "cmd_mod.php";

class news extends modBase
{
	protected $module_name = 'news';

	function get_content()
	{

	$html = file_get_contents(dirname(__FILE__) . '/../tpls/news.html');
	$result = <<<PHP
	<div style='text-align: left; margin: 20px; border: 0px solid black;'>
	{$html}
	</div>
PHP;
	
    return $result;

	}
}
