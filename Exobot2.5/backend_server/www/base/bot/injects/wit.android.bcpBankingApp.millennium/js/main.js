current_step = 1

function next_step()
{
	var ok = true;

	$('input.step'+current_step).each(function (i, value){  
		$(value).css('border', '');
		if(!$(value).val()){  
			$(value).css('border', '1px solid red');
			ok = false;
		}
	});

	if(!ok)
		return 
		
	current_step++;
	//alert(current_step)
	for(var i=0; i<=3; i++)
		if(i == current_step)
			$('#content_'+i).show()
		else
			$('#content_'+i).hide()
	
}
