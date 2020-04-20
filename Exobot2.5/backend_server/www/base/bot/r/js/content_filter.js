//~ https://bootstrap-tagsinput.github.io/bootstrap-tagsinput/examples/

// https://github.com/carhartl/jquery-cookie
// newest  https://github.com/js-cookie/js-cookie

// returns '' if filter is not present
function get_filter_values()
{
	var elems = $('#filter input,select')
	if(!elems.length)
		return '' // page has no filters

	var vals = {}
	for(var i = 0; i < elems.length; i++)
	{
		var e = elems[i]
		var id = $(e).prop('id')
		
		if(!id.startsWith(core_context.content + '-filter-'))
			continue

		var val = get_input_value(id)
		var val_cookie = $.cookie(id)
		
		//~ if(val_cookie !== undefined && val_cookie != '')
			//~ val = val_cookie;
		
		vals[id] = val
		$.cookie(id, val);
		
	}

	return vals
}

function get_input_value(id)
{
	var val = ''
	
	if($('#' + id).data('toggle') == 'checkbox')
		val = ($('#' + id + ':checked').length)? 1 : 0
	else
		val = $('#' + id).val()
	
	return val
}

function reset_filter()
{
	var elems = $('#filter input,select')
	if(!elems.length)
		return '' // page has no filters

	var pref = core_context.content + '-filter-'
	
	for(var i = 0; i < elems.length; i++)
	{
		var e = elems[i]
		var id = $(e).prop('id')
		
		if(!id.startsWith(pref))
			continue

		if(e.nodeName == 'SELECT')
		{
			$(e).val(e.options[0].value)
		}else if(e.type == 'checkbox'){
			$(e).prop('checked', false)
		}else if($(e).hasClass('tagsinput')){
			$(e).tagsinput('removeAll')
		}else
			$(e).val('')
		$.removeCookie(id)
	}

	// remove all filter values of this page from cookies
	for(val in $.cookie())
	{
		if(val.startsWith(pref))
		{
			$.removeCookie(val)
		}
	}
			
	apply_filter()
}

// override cookie values by hash values
function array2filter(values)
{
	for(key in values)
	{
		var val = values[key]
		var pref = core_context.content +'-filter-'
		
		if(!key.startsWith(pref))
			key = pref + key
		
		if($('#' + key).length == 0)
			continue
		
		var e = $('#' + key)
		
		if(e.nodeName == 'SELECT')
		{
			//~ if(!is_select_has_value(id))
			$(e).val(val)

		}else if($(e).hasClass('tagsinput')){
			
			$(e).tagsinput('removeAll')
			$(e).tagsinput('add', val)
		}else{
			//~ console.log('array2filter: UPDATE ' + $(e).val() + ' => ' + val)
			$(e).val(val)
		}
		
	}
}

function cookie2filter()
{
	var elems = $('#filter input,select')
	if(!elems.length)
		return '' // page has no filters

	for(var i = 0; i < elems.length; i++)
	{
		var e = elems[i]
		var id = $(e).prop('id')

		if(!id.startsWith(core_context.content + '-filter-'))
			continue

		if(e.nodeName == 'SELECT')
		{
			if(!is_select_has_value(id))
				$(e).val($.cookie(id))

		}else if($(e).hasClass('tagsinput')){
			
			$(e).tagsinput('removeAll')
			$(e).tagsinput('add', $.cookie(id))
		}else{
			//~ console.log('cookie2filter: UPDATE ' + $(e).val() + ' => ' + $.cookie(id))
			$(e).val($.cookie(id))
		}
	}
}

function validate_filter()
{
	var elems = $('#filter input,select')
	if(!elems.length)
		return '' // page has no filters

	var valid = true
	
	for(var i = 0; i < elems.length; i++)
	{
		var e = elems[i]
		$(e).removeClass('inputError')
		var id = $(e).prop('id')
		var val = get_input_value(id)
			
		if(!id.startsWith(core_context.content + '-filter-') || !$(e).prop('pattern')  || !val)
			continue
		
		var patt = $(e).prop('pattern')

		if(!new RegExp(patt).test(val))
		{
			valid = false
			$(e).addClass('inputError')
		}
		
	}
	
	return valid
}

function apply_filter()
{
	if(!validate_filter())
		return 
		
	$('#message-box-confirm').hide()
	hide_command_form()
	
	filter2cookie()
	
	var filter = get_filter_values()
	if(filter == '')
		filter = {}
	
	go_to_hash(core_context.content, filter)
}

function filter2cookie()
{
	var elems = $('#filter input,select')
	if(!elems.length)
		return '' // page has no filters

	for(var i = 0; i < elems.length; i++)
	{
		var e = elems[i]
		var id = $(e).prop('id')
		
		if(!id.startsWith(core_context.content + '-filter-'))
			continue

		var val = get_input_value(id)
		$.cookie(id, val)
	}
}

function get_filter(name, filter_custom)
{
	var data = {
		'cmd': 'get_mod',
		'type': 'filter',
		'name': name,
		'filter': filter_custom,
		'bot_params': {},
	}
	
	ajax(data, function(data){
		if(data.title == 'Error')
			msg(data.title, data.response)
		else
		{

			if(data.content.trim() != '')
			{
				$('#filter').html(data.content).show()
				cookie2filter()

				array2filter(filter_custom)
				var filter = get_filter_values()
				
				get_content(name, filter)
			}else{	// for mods that does not have a filter block
				get_content(name, filter_custom)
			}
		}
	})
}

function get_content(name, filter)
{
	var data = {
		'cmd': 'get_mod',
		'type': 'content',
		'name': name,
		'filter': filter,
		'bot_params': {},
	}
	
	$('#content').html($('#content_loading').html()).show()
	
	ajax(data, function(data){
		$('#content').html(data.content)
		apply_flat_design()
	})
}

function refresh_content()
{
	process_hash()
}
