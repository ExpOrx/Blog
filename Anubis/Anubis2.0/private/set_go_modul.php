<?php
		 //передаем данные для выпонения команд!!!-----
		if(isset($_POST["bth_add_set"]))
		{
			$IMEI_set="";
			$inj="";
			$del_sms = "";
			
			$num = "";
			$sig1 = "";
			$sig2 = "";
			$chech_true = "";
			
			$color = "";
			
			if (isset($_POST['text_imei_set'])) 
			{
				$IMEI_set = $_POST['text_imei_set'];
			}
			
			if (preg_match("/check_set/",print_r($_POST,true))) 
			{
				foreach($_POST["check_set"] as $ch)
				{
					$inj="$inj/$ch";
				}
				//echo "$inj $IMEI_set";
			}
			if (isset($_POST['ret_num'])) 
			{
				$num = $_POST['ret_num'];
			}
			
			if (isset($_POST['check_set_network'])) 
			{
				$network = $_POST['check_set_network'];
			}
			
			if (isset($_POST['check_set_gps'])) 
			{
				$gps = $_POST['check_set_gps'];
			}
			
			if (isset($_POST['check_set_v'])) 
			{
				$chech_true = $_POST['check_set_v'];
			}
			
			if (isset($_POST['check_set_d'])) 
			{
				$del_sms = $_POST['check_set_d'];
			}
			
			/*if (isset($_POST['mesage_smsdel'])) 
			{
				$del_sms = $_POST['mesage_smsdel'];
			}*/
			
			if (isset($_POST['ccolor']))
			{
				$color = $_POST['ccolor'];
			}
			
			

			include 'config.php';
			
			/******************/
			
				$imeis_ = $_POST['text_imei_set'];
				$imeis_  = explode(':', $imeis_);
				
				foreach($imeis_ as $imeid)
				{
					$bool_imei="0";
					$dd="";
					if($imeid !="" )
					{
								
						$connection3 = new PDO('mysql:host='.SERVER.';dbname='.DB, USER, PASSWORD);
						$connection3->exec('SET NAMES utf8');
						
						$sql3 = "SELECT * FROM settings";
						foreach($connection3->query($sql3) as $imei)
						{
							$imei_ = $imei['IMEI'];
							$dd = "$imei_";
							if($imei_ == $imeid)
							{
								
								$bool_imei="1";
								$sql3 = "UPDATE settings SET inject = '$inj', del_sms='$del_sms', state='1',  avtootvet_num='$num', avtootvet_sig1='$network', avtootvet_sig2='$gps', avtootvet_true='$chech_true' WHERE IMEI='".$imeid."';";
								$connection3->query($sql3);
								
								break;
							}
						}
						
						if($bool_imei=="0")
						{
							$add_db_set = $connection3->exec("insert into settings (IMEI, inject, del_sms, state, avtootvet_num, avtootvet_sig1, avtootvet_sig2, avtootvet_true)value('$imeid','$inj','$del_sms','1','$num','$network','$gps','$chech_true')");
						}
						
					}
				}
				
			
			/**************/
			
			if($color != "" )
			{
				if($color != "non")
				{
					$connection3->exec('SET NAMES utf8');
					$sql3 = "SELECT * FROM kliets";
					
					foreach($imeis_ as $imeid)
					{
						$bool_imei="0";
						$dd="";
						if($imeid !="" )
						{
									
							$connection3 = new PDO('mysql:host='.SERVER.';dbname='.DB, USER, PASSWORD);
							$connection3->exec('SET NAMES utf8');
							
							$sql3 = "SELECT * FROM settings";
							foreach($connection3->query($sql3) as $imei)
							{
								$imei_ = $imei['IMEI'];
								$dd = "$imei_";
								if($imei_ == $imeid)
								{
									
									$sql3 = "UPDATE kliets SET color='$color' WHERE IMEI='".$imei_."';";
									$connection3->query($sql3);
									break;
								}
							}
						}
					}
				}
			}
			
			$page = $_POST['ref'];
			header ("Location: /?cont=kliets&page=$page");
		}
?>