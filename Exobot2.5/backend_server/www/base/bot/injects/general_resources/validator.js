
// validate all inputs
// + data-reg and maxlength support
// <input type="text" name="fields[user]" data-reg="/^\w+$/" maxlength="16" />
function formvalidator()
{ 
	var ok = true;

	$('input').each(function (i, value){  

		if($(value).is(':checkbox') || !$(value).is(':visible') || $(value).prop('type') == 'submit')
			return;

		$(value).css('border', '');

		var reg__ = $(value).data().reg;
		if(reg__ !== undefined && !eval(reg__).test( $(value).val()))
		{
			$(value).css('border', '1px solid red');
			ok = false;
			
		}
		
		
		if($(value).val().length < 3){
			$(value).css('border', '1px solid red');
			ok = false;
			
		}
		
		if($(value).prop('maxlength') !== undefined && $(value).prop('maxlength') != -1 && $(value).val().length > $(value).prop('maxlength'))
		{
			$(value).css('border', '1px solid red');
			ok = false;
			
		}
	});
	
	if(window.form_sent) 
		return false; 
		
	if(ok) 
		window.form_sent = true; 
		
	return ok; 
}
