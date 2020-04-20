<?php
include("lib.php");
include("config.php");

$link = mysql_connect('localhost', $_DB['user'], $_DB['password']);
mysql_query('use general', $link);

if ($_POST){
	if (!isset($_REQUEST['folder']) || ! isset($_REQUEST['id'])){
		die;
	}

	$id = (int) $_REQUEST['id'];
	$folder = mysql_real_escape_string($_REQUEST['folder'], $link);

	$sql = "SELECT `group_id`, `app` FROM `injects` WHERE `id` = $id";

	$res = mysql_query($sql, $link);
	$row = mysql_fetch_row($res);
	if (!$row){
		die();
	}


	$sql = "INSERT INTO `inject_coordinates` VALUES ({$id}, {$row[0]}, '{$row[1]}', '{$folder}') ON duplicate key update folder = '{$folder}'";
	if (!trim($folder)){
		$sql = "DELETE FROM `inject_coordinates` WHERE `id` = {$id}"; 		
	}

	$res = mysql_query($sql);
	echo "<div class='box grid_12'><div class='box-head'><h2>Result</h2></div><div class='box-content'><textarea style='width: 100%'>";
	if ($res){
		echo $sql;
	}
	else {
		echo mysql_error($link);
	}

	echo "</textarea></div></div>";
}

?>
<div class="container" style='margin-top: 10px'>
	<div class='row'>
		<div class='col-md-2'>&nbsp;</div>
<?php

$groups_sql = "SELECT id, title FROM groups";

$groups_arr = array();
$res = mysql_query($groups_sql, $link);
while ($row = mysql_fetch_assoc($res)){
	$groups_arr[$row['id']] = $row['title'];
}

$sql = "SELECT * FROM `injects` LEFT JOIN `inject_coordinates` on `inject_coordinates`.`id` = `injects`.id order by `injects`.`group_id`";

$res = mysql_query($sql);


?>

<div class="box grid_12">
	<div class="box-head"><h2>All injects</h2></div>
	<div class='box-content'>
	<table>
	<tr><th style='padding: 10px'>id</th><th style='padding: 10px'>group</th><th style='padding: 10px'>app</th><th style='padding: 10px'>coordinates folder</th><th style='padding: 10px'>actions</th></tr>
<?php
while ($row = @mysql_fetch_row($res)){
	echo "<tr><form method='POST'><td>{$row[0]}</td><td>{$groups_arr[$row[1]]}</td><td>{$row[2]}</td><td><input type='hidden' name='id' value='{$row[0]}'><input type='text' name='folder' value='{$row[7]}'></td><td><button class='button blue save-button' type='submit'>save</button></td></form></tr>";
}
?>
</table>
	</div>
</div>

</div>
</div>
