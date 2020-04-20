<?php
include("lib.php");
include("config.php");

if(isset($_GET['act']) && $_GET['act'] == 'delete_all')
{
	foreach(glob('../backups/*zip') as $file)
		unlink($file);
	echo html_msg("Backups have been deleted");
}
?>
<div class="box grid_12">
	<div class="box-head"><h2>Backend backups</h2></div>
	<div class="box-content">
		<a href='?action=backups&act=delete_all' onclick='return confirm("Are you drunk?")'>
		<input type='submit' class='button red' value='Delete all' />
		</a>
		<div class="form-row">
			<ul>
		<?php
foreach(glob('../backups/*zip') as $file)
	echo "<li><a href='{$file}'>{$file}</a></li><br />";
		?>
			</ul>
		</div>
	</div>
</div>
</form>

