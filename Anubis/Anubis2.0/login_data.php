<?php
//Запуск сессий;
session_start();
include_once "crypt.php";
if (isset($_POST['login']) && isset($_POST['password']))
{
// получаем данные из формы с авторизацией
$login = $_POST['login'];
$password = $_POST['password'];
//проверка пароля и логина
	if (($login=='1')&&($password=='1'))
	{
		echo ("Авторизация успешная!");
		$date = date('Y-m-d H:i');
		$session_crypt = "$$datelogin";
		$_SESSION['Name']=encrypt($session_crypt,"qwertyuasd");
		// идем на страницу для авторизованного пользователя
		header("Location: /index.php");
	}
	else
	{
		echo "Логин и пароль введен неверно!";
	}
}
?>