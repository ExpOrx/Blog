<?php

		 //передаем данные для выпонения команд!!!-----
		if(isset($_POST["bth_add_sort"]))
		{
			$s1 = $_POST['sort_kat'];
			$s2 = $_POST['sortCountry'];
			$s3 = $_POST['color'];
			$s4 = $_POST['versions'];
			$s5 = $_POST['bank'];
			
		// Открыть текстовый файл
		$f = fopen("sort.txt", "w");
		fwrite($f, "$s1|$s2|$s3|$s4|$s5"); 
		fclose($f);

		echo "$s1|$s2|$s3|$s4|$s5";
		header("Location: /index.php");

		}
?>