<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link href="styles/login.css" rel="stylesheet">
 <link rel="shortcut icon" href="/images/icon1.png" type="image/png">
<title>Вход в систему</title>
</head>
<body bgcolor="1D1F24">
<form class="form-3" action="login_data.php" method="post">
    <p class="clearfix">
        <label for="login">Логин</label>
        <input type="text" name="login" id="login" placeholder="Логин">
    </p>
    <p class="clearfix">
        <label for="password">Пароль</label>
        <input type="password" name="password" id="password" placeholder="Пароль"> 
    </p>
    <p class="clearfix">
        <input type="submit" name="submit" value="Войти">
    </p>       
</form>
</body>
</html>