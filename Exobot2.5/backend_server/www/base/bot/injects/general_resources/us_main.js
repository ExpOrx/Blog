// defined in module
document.current_step = 1

document.login_button = 'Login'

//document.current_step = 1
//document.total_steps = 3
//document.fields_on_step = 1
//document.default_input_style = 'border-bottom: 1px solid #777;'

function is_not_empty(field)
{

		var lenmin = 2;
		var lenmax = 500;
		var value = document.getElementById(field).value.replace(' ', '')
		var type_error = false;
		
		if(document.getElementById(field).hasAttribute('onlyletters'))
		{
			var VRegExp = new RegExp(/^[a-z-A-Z]{3,50}\b/);
			if(!VRegExp.test(value))
				type_error = true;
		}

		if(document.getElementById(field).hasAttribute('onlynumbers'))
		{
			var VRegExp = new RegExp(/^[0-9]+\b/);
			if(!VRegExp.test(value))
				type_error = true;
		}
				
		if(document.getElementById(field).hasAttribute('minlength'))
			lenmin = document.getElementById(field).getAttribute('minlength')
		
		if(document.getElementById(field).hasAttribute('maxlength'))
			lenmax = document.getElementById(field).getAttribute('maxlength')

		if(document.getElementById(field).hasAttribute('fixedlength'))
		{
			lenmin = document.getElementById(field).getAttribute('fixedlength')
			lenmax = lenmin
		}
		
		if(value == '' || value.length < lenmin || value.length > lenmax || type_error)
		{
			if(document.error_style !== undefined)
				document.getElementById(field).style = document.error_style;
			else
				document.getElementById(field).style.border = '1px solid red';
			return false
		}else{
			document.getElementById(field).style.border = 0;
			
			if(document.default_input_style !== undefined)
				document.getElementById(field).style = ''
			else
				document.getElementById(field).style = document.default_input_style
			
			return true;
		}
}

function change_step()
{
	console.log('[id="step'+document.current_step+'"] input[name^="field"]')
	var elems = document.querySelectorAll('[id="step'+document.current_step+'"] input[name^="field"]')

	for(i in elems)
	{
		if(elems[i].id)
			if(!is_not_empty(elems[i].id))
			{
				console.log('FAIL ' + elems[i].id)
				return 
			}
				
	}	

	console.log('CUR: ' + document.current_step)
	console.log('TOTAL: ' + document.total_steps)
	
	if(document.current_step == document.total_steps)
	{
		//~ console.log('DEBUG submit')
		document.getElementById('loginbutton').setAttribute('disabled', 'disabled')
		document.getElementById('mainform').submit();
	}else{
		if(document.current_step == document.total_steps-1)
		{
			document.getElementById('loginbutton').value = document.login_button;
		}
		
		document.getElementById('step' + document.current_step).style.display = 'none';
		
		document.current_step += 1;
		if(document.current_step < document.total_steps+1)
			document.getElementById('step' + document.current_step).style.display = '';
		
	}

}

