<?php
# put on backend server, specify path to this script in builder/config.py

# $_FILES['update_zip'] -- upload zip with apks
# $_REQUEST['get_backup'] -- get latest backup

class BuilderAPI
{
	
	function upload_apks()
	{
		if(!file_exists('apks_tmp'))
			mkdir('apks_tmp');

		foreach(glob("apks_tmp/*.apk") as $file)
			unlink($file);
			
		function uploadError($code)
		{
			switch($code)
			{
				case $code == UPLOAD_ERR_OK:
					return "There is no error, the file uploaded with success.";
					break;
				case $code == UPLOAD_ERR_INI_SIZE:
					return "The uploaded file exceeds the upload_max_filesize directive in php.ini.";
					break;
				case $code == UPLOAD_ERR_FORM_SIZE:
					return "The uploaded file exceeds the MAX_FILE_SIZE directive that was specified in the HTML form.";
					break;
				case $code == UPLOAD_ERR_PARTIAL:
					return "The uploaded file was only partially uploaded.";
					break;
				case $code == UPLOAD_ERR_NO_FILE:
					return "No file was uploaded.";
					break;
				case $code == UPLOAD_ERR_NO_TMP_DIR:
					return "Missing a temporary folder. Introduced in PHP 5.0.3.";
					break;
				case $code == UPLOAD_ERR_CANT_WRITE:
					return "Failed to write file to disk. Introduced in PHP 5.1.0.";
					break;
				case $code == UPLOAD_ERR_EXTENSION:
					return "A PHP extension stopped the file upload";
					break;
					
			}
		}

		function reArrayFiles(&$file_post) {

			$file_ary = array();
			$file_count = count($file_post['name']);
			$file_keys = array_keys($file_post);

			for ($i=0; $i<$file_count; $i++) {
				foreach ($file_keys as $key) {
					$file_ary[$i][$key] = $file_post[$key][$i];
				}
			}

			return $file_ary;
		}

		echo "Unpack {$_FILES['update_zip']['tmp_name']}<br />";
		$zip = new ZipArchive;
		$res = $zip->open($_FILES['update_zip']['tmp_name']);
		if ($res === true){
			$zip->extractTo('apks_tmp');
			$zip->close();
		}
		else {
			die ("Can't unpack file, check php max upload size settings");
		}

		// $cmd = "unzip {$_FILES['update_zip']['tmp_name']} -d apks_tmp/";
		// exec($cmd, $b);
		//~ if($b)
			//~ print_r($b);

		$n_failed = $n_success = 0;
		foreach(glob("apks_tmp/*.apk") as $file)
		{
			# postm_Postmaster_360-Security_09.10.16360.apk
			
			$apk = str_replace("apks_tmp/", "", $file);
			$parts = explode("_", $apk);
			// $parts = explode("_", $apk, 2);
			$folder = $parts[0];
			$api = substr($parts[3], 8, strlen($parts[3]));
			
			$mask = "{$parts[0]}_{$parts[1]}_{$parts[2]}_*{$api}";

			# remove old
			foreach(glob("../apks/{$mask}") as $old)
			{
				echo "$old\n";
				if (is_file($old)){
					echo "Delete {$old}\n";
					unlink($old);
				}
			}
			
			// $cmd = "mv {$file} ../{$folder}/video/apks/";
			// $filename = basename($file);
			if (copy($file, "../apks/{$apk}")){
				echo "moved file {$file}<br />";
				$n_success++;
			}
			else {
				echo "Can't copy file {$file}<br />";
				$n_failed++;
			}
		}
		
		echo "<script>alert('{$n_success} apks uploaded success; {$n_failed} failed')</script>";
		
	} // end upload_apks()
	
	function get_backup()
	{
		$d = date("d.m.y", time());
		$name = "backups/back{$d}.zip";
		if(!file_exists($name))
			die("file_not_found");
		else
			die(file_get_contents($name));
	}
	
}// end class

$b = new BuilderAPI();

if(isset($_FILES['update_zip']))
	$b->upload_apks();
else if(isset($_REQUEST['get_backup']))
	$b->get_backup();
#else
#	print("<form method='post' enctype='multipart/form-data'><input type='file' name='update.zip' /><input type='submit' /></form>");
die;





















