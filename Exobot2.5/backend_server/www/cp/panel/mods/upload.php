<?php
include("lib.php");

if(!file_exists('up.data.php'))
	file_put_contents('up.data.php', '');
	
#if(!in_array($_SERVER['REMOTE_ADDR'], array('24.89.190.91', '::1'))) die;

function process_post()
{
	if(isset($_GET['delete_all']))
	{
		$files = file('up.data.php');
		foreach($files as $f)
		{
			unlink(trim($f));
			echo html_msg('File ' . trim($f) . ' deleted');
		}
		
		file_put_contents('up.data.php', '');
	}
	
	if(isset($_GET['delete']))
	{
		$files = file('up.data.php');
		
		$files2 = array();
		foreach($files as $f)
			if(trim($f) == $_GET['delete'])
			{
				unlink($_GET['delete']);
				echo html_msg('File ' . $_GET['delete'] . ' deleted');
			}else
				if(trim($f))
					$files2[] = $f;
				
		file_put_contents('up.data.php', implode("", $files2));
	}	

	if(isset($_FILES["fileToUpload"]))
	{
		$target_dir = dirname(__FILE__) . "/../upload/";

		$target_file = $target_dir . basename($_FILES["fileToUpload"]["name"]);
		$name = basename($_FILES["fileToUpload"]["name"]);
		
		if (move_uploaded_file($_FILES["fileToUpload"]["tmp_name"], $target_file)) {
			echo html_msg("File ". basename( $_FILES["fileToUpload"]["name"]). " has been uploaded to {$name}");
		
			$files = file('up.data.php');
			$files[] = "upload/".$name;
			$files = array_unique($files, SORT_STRING);
			
			file_put_contents('up.data.php', implode("\n", array_reverse($files)));
			
		} else {
			echo html_msg("Sorry, there was an error uploading your file", "error");
		}
	}
}

?>
<div class="box grid_12">
	<div class="box-head"><h2>Upload file</h2></div>
	<div class="box-content">
	
	<form id='upload_form' action="?action=upload" method="post" enctype="multipart/form-data">
		<input onchange='upload_form.submit()' type="file" name="fileToUpload" id="fileToUpload" style='' />
	</form>
	
<p>&nbsp;</p>
<?php
	process_post();
	
$files = file('up.data.php');
	
$list = '<h2>Uploaded files</h2><br /><ul style="list-style-type: none">';
foreach($files as $file)
{
	$file = trim($file);
	
	if($file != '')
	{
		$date = date("d.m.y G:i:s", filectime($file));
		$list .= "<li><a href='{$file}'>{$file}</a> 
		<a href='index.php?action=upload&delete={$file}'><button type='button' class='button red'>Delete</button></a>
		<small style='color: grey'>{$date}</small></li>";
	}
}

$list .= '</ul>';

if(sizeof($files))
	$list .= "
	<br />
	<br />
	<div style='clear: both'>
	<a href='index.php?action=upload&delete_all=1'><button type='button' class='button red'>Delete all</button></a>
	</div>";
?>
<p><?php echo $list; ?></p>
</div>
</div>

</body>
</html>
