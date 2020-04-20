function log_in()
{
	$('#login_response').html('&nbsp;')
	$('#field1').removeClass('inputError')
	$('#field2').removeClass('inputError')
	
	var data = {
		'cmd': 'panel_login',
		'login': $('#field1').val().trim(),
		'pass': $('#field2').val().trim(),
	}
	
	var fail = false
	if(!data['login'])
	{
		$('#field1').addClass('inputError')
		fail = true
	}

	if(data['login'].indexOf(':') == -1 && !data['pass'])
	{
		$('#field2').addClass('inputError')
		fail = true
	}
	
	if(fail)
		return;
		
	$('#login_button').hide()
	$('#loader').show()
	
	$.post('', data, function(data, textStatus) {

	}, "json").done(function(data){ 
		// title, response
		$('#login_response').html(data.response)
		
		if(data.title == 'Error')
		{
			$('#field1').addClass('inputError')
			$('#field2').addClass('inputError')
			
			$('#login_button').show()
			$('#loader').hide()

		}else{
			
			$('#loader').hide()
			
			setTimeout(function(){
				location.reload()
			}, 500);
		}
		
	}).fail(function(data) {
		
	}).always(function(data){

	})
}

window.onload = function ()
{
	$('#field1').focus()
	$('#field2').prop("type", "password")
}

$(document).on("keydown", function(e){
		
	if(e.keyCode == 27)
	{
		$('#field1').val('')
		$('#field2').val('')
		$('#login_response').html('&nbsp;')
		$('#field1').removeClass('inputError')
		$('#field2').removeClass('inputError')
		$('#field1').focus()

	}else if(e.keyCode == 13){

		log_in()
	}
});
