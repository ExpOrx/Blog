<?php
include("lib.php");
include("config.php");

$injects_root = "../../base/bot/injects";

$link = mysql_connect('localhost', $_DB['user'], $_DB['password']);
mysql_query('use general', $link);

$create_group_sql = '';
$conflicted = array();

if($_POST)
{
	if(trim($_POST['group']))
		$group = trim($_POST['group']);
	else{
		$group_name = trim($_POST['group_new']);
		
		if(strstr($group_name, "|"))
		{
			list($group_name, $descr) = explode("|", $group_name, 2);
		}else
			$descr = "";
			
		$sql = "insert into groups values(null, '{$group_name}', '{$descr}');";
		$res = mysql_query($sql) or die(mysql_error());
		$create_group_sql = $sql;
		$res = mysql_query("select id from groups where title='{$group_name}'") or die(mysql_error());
		$group = mysql_fetch_assoc($res)['id'];
	}
	
	if(!$group)
		die("group name can not be empty");
	
	$data = trim($_POST['data']);
	if(!$data)
		die("data can not be empty");
		
	$sqls = array();
	$apps = array();
	foreach(explode("\n", $data) as $row)
	{
		if(!trim($row))
			continue;
			
		$row = trim($row);
		if(!strstr($row, ";"))
			$apps[$row] = array();
		else
		{
			list($pkg, $show_on) = explode(";", $row, 2);
			$show_on_pkgs = explode(",", $show_on);
			$apps[trim($pkg)] = $show_on_pkgs;
		}
	}
	
	$res = mysql_query("SELECT app from injects") or die(mysql_error());

	$existing_apps = array();
	while($data = mysql_fetch_assoc($res))
	{
		$existing_apps[] = $data['app'];
	}

	foreach($apps as $folder=>$pkgs)
	{
		if(in_array($folder, $existing_apps))
		{
			print("<div class='form-row'>folder ALREADY EXISTS: {$folder}");
			$conflicted[] = $folder;
			continue;
		}
		
		foreach($pkgs as $pkg)
		{
			if(in_array($pkg, $existing_apps))
			{
				print("<div class='form-row'>pkg ALREADY EXISTS: {$pkg}");
				$conflicted[] = $pkg;
				continue;
			}
		}
		
		
		if($pkgs)
		{
			$x = implode(", ", $pkgs);
			//~ print("<div class='form-row'>GOOD: {$folder} + {$x}");
			//~ $pkgs[] = $folder;
		}else{
			//~ print("<div class='form-row'>GOOD: {$folder}");
			//~ $pkgs = array($folder);
		}
			
		$cmd = "cp -rp {$injects_root}/blank {$injects_root}/{$folder}";
		print("<div class='form-row'># {$cmd}</div>");
		exec($cmd);
		
		//~ if(!$pkgs)
			//~ $sqls[] = "insert into injects values(null, {$group}, '{$folder}', '{$folder}');";
			
		$pkgs2 = $pkgs;
		$pkgs2[] = $folder;
		$pkgs2 = array_unique($pkgs2);
		
		foreach($pkgs2 as $p)
			$sqls[] = "insert into injects values(null, {$group}, '{$p}', '{$folder}', 0);";
	} // end foreach loaded apps
	
	$sqls_string = implode("\n", $sqls) . "\n" . $create_group_sql;
	$t = <<<PHP
<div class="box grid_12">
<div class="box-head"><h2>SQL to execute</h2></div>
<div class="box-content"><textarea style='width: 100%; height: 200px'>{$sqls_string}</textarea></div>
PHP;
	print($t);
	
	foreach($sqls as $sql)
		$res = mysql_query($sql) or die(mysql_error());
	
	if($conflicted)
	{
		$conflicted = implode("\n", $conflicted);
		$t = <<<PHP
	<div class="box grid_12">
	<div class="box-head"><h2>Conflicted names</h2></div>
	<div class="box-content"><textarea style='width: 100%; height: 200px'>{$conflicted}</textarea></div>
PHP;
		print($t);
	}
}

?>
<form method='post'>
<div class="box grid_12">
	<div class="box-head"><h2>Add new injects</h2></div>
	<div class="box-content">
		<div class="form-row">It will check if injects are present in db and create non-conflict ones from blank/ template.</div>
		<div class="form-row"><select name="group"><option value=''>--choose group--</option>
		<?php

$res = mysql_query("SELECT id, title, notes from groups") or die(mysql_error());

while($d = mysql_fetch_assoc($res))
{
	echo "<option value='{$d['id']}'>#{$d['id']} {$d['title']} {$d['notes']}</option>\n";
}
	
		?>
		</select> or enter the new one (lower case): <input type='text' name='group_new' /> (name|description)</div>
		<div class="form-row"><textarea name="data" style='width: 100%; height: 200px' placeholder='folder;package1,package2 or only folder'></textarea></div>
		<div class="form-row" style="text-align: center"><input class="button green" type='submit' value="Add" /></div>
	</div>
</div>
</form>
