<?php
require_once "cmd_mod.php";

class docs extends modBase
{
	protected $module_name = 'docs';

	function get_content()
	{
		$content = "<div class='row'>
			<div class='col-md-12' style='font-size: 32pt; text-align: center'>
				<span class='fui-document marginRight10'></span>
				Documentation</div>
		</div>
		<div>&nbsp;</div>
		<div><center><h4>Under construction</h4></center></div>";
		
		return $this->wrap_content("", $content);
	}
}
