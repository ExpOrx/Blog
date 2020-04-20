
var core_context = {}
// page, content 'bots', handler setBotInfoHandlers, botid

if('onhashchange' in window ) {

	window.addEventListener('hashchange', getHashValue, false);
	
	function getHashValue() {
		process_hash()
	}
}

window.onload = function ()
{
	process_hash()
	
	String.prototype.repeat = function (num) {
	  return new Array(Math.round(num) + 1).join(this);
	}

	$(document).ready(function() {
		 apply_flat_design()      
	})
} 

function apply_flat_design()
{
	$('[data-toggle="checkbox"]').radiocheck()
	$('[data-toggle="radio"]').radiocheck()
	$('[data-toggle="tooltip"]').tooltip({placement : 'top'})
	$('[data-toggle="tooltip-down"]').tooltip({placement : 'bottom'})
	
	if ($('[data-toggle="select"]').length) {
	  $('[data-toggle="select"]').select()
	}
	
	//~ $('[data-toggle=tooltip]').tooltip('show')
	
	$('input[id*=-filter-]').on('focus', function(){ 
		console.log('FOCUS') 
		console.log($(this).prop('id')) 

	})
	
	$('input[id*=-filter-]').on('focus', function(){ 

		set_enter_hook(function(){
			core_context.filter_key_enter_hook_is_set = true
			apply_filter()
			})
	})
	
	$('input[id*=-filter-]').on('blur', function(){ 
		//~ console.log($(this).prop('id')) 
		if(core_context.filter_key_enter_hook_is_set !== undefined)
		{
			clean_enter_hook()
		}
	})
	
	$('[data-toggle="switch"]').bootstrapSwitch();
}

function set_enter_hook(clb_enter, clb_escape)
{

	$(document).on("keydown", function(e){
		console.log('Caught ' + e.keyCode)
		if(e.keyCode == 27 && clb_escape)
		{
			clb_escape()
		}else if(e.keyCode == 13 && clb_enter){

			if(document.activeElement.nodeName != 'TEXTAREA')
				clb_enter()
		}
	})
}

function clean_enter_hook()
{
	$(document).off("keydown");
	
	$('#message-box-confirm-left').prop('onclick',null).off('click');
	$('#message-box-confirm-right').prop('onclick',null).off('click');
}

function get_selected_elems()
{
	var elems = $('input[id*="-table-chk-"]:checked')
	var ids = []
	for(var i=0; i<elems.length; i++) 
		ids.push(elems[i].id.split('-').pop())
	
	return ids
}

function select_all(sel)
{
	var first = $('input[id*="-table-chk-"]')[0].checked
	$(sel).each(function(index, elem){ elem.checked = !first })
}

function ajax(data, callback_ok, callback_always)
{
	show_loader(true)
	
	$.post('', data, function(data, textStatus) {
		//data contains the JSON object
		//textStatus contains the status: success, error, etc
		//~ console.log('JSON DEBUG: ')
		//~ console.log(data)
		//~ console.log(textStatus)
	}, "json").done(function(data){ 

		if(callback_ok)
			callback_ok(data)
		
	}).fail(function(data, t2, t3) {
		core_context.last_ajax_error_text = data.responseText
		if(core_context.last_ajax_error_text !== undefined)
			msg('Error', '<span ondblclick="show_ajax_error_details()">Request failed</span>')

	}).always(function(data){
		
		show_loader(false)
		if(callback_always)
			callback_always(data)
	})
}

// Send custom command to bot or panel
// name: panel_cancel_task - see method 'cancel_task' in cmd_panel.php
function ajax_command(name, extra, refresh_page)
{
	var extra = (extra === undefined)? {} : extra
	var refresh_page = (refresh_page === undefined)? false : refresh_page
	
	var data = {
		'cmd': name,
		'bot_params': {},
	}

	$.extend(data, extra);
	ajax_dialog(data, null, refresh_page)
}

function show_ajax_error_details()
{
	if(core_context.last_ajax_error_text !== undefined)
	{
		alert(core_context.last_ajax_error_text)
		console.log('Last ajax error:')
		console.log(core_context.last_ajax_error_text)
	}
}

// item: 'news'
function menu_set_active(item)
{
	var links = $('#top_menu li > a')
	
	for(var i = 0; i < links.length; i++)
	{
		var a = links[i]
		if($(a).prop('id') == item)
			$(a).parent().addClass('active')
		else
			$(a).parent().removeClass('active')
	}
}

function is_select_has_value(id)
{
	var opts = $('#' + id + ' > OPTION')
	
	for(var i = 0; i < opts.length; i++) 
	{
		if($(opts[i]).prop('selected') === true)
			return true
	}
	
	return false
}

function enlarge_input(elem)
{
	var elem = $(elem)
	elem.css('height', core_context.input_original_width)
}

function ensmall_input(elem)
{
	var elem = $(elem)
	core_context.input_original_height = elem.css('height')
	elem.css('height', '200px')
}

function show_save_button(elem)
{
	var elem = $(elem)
	
	var button_id = 'button-' + elem.prop('id')
	$('#' + button_id).show()
}

function download_file(data)
{
	$.fileDownload("", {
		httpMethod: "POST",
		data: data
	}).fail(function(data, t2, t3) {
		//core_context.last_ajax_error_text = data.responseText
		console.log(data)
		msg('Error', '<span>File request failed</span>')
	})
}

// type - cards, banks
function export_txt_csv(table)
{
	function to_text(table){ 
		
		download_file({
			cmd: "panel_export_table", // banks/cards/contacts/...
			table: table,
			type: 'text',
			'X-Requested-With': 'xmlhttprequest',
		});
		hide_command_form()
	}
	
	function to_csv(table){ 
		
		download_file({
			cmd: "panel_export_table", // banks/cards/contacts/...
			table: table,
			type: 'csv',
			'X-Requested-With': 'xmlhttprequest',
		});
		hide_command_form()
	}
	
	msg_choose_dual('Export', 'Choose export format', 'Text', 'Excel', to_text, to_csv, [table])
}

function show_bot_details(elem, bot_id)
{
	window.last_bot_detail_link_elem = elem
	ajax({cmd: 'panel_get_bot_details', bot_id: bot_id}, show_details_div)
}

function show_details_div(data)
{
	if ($('#short-details-box').is(':visible'))
		return 
		
	var elem = window.last_bot_detail_link_elem
	var pos = $(elem).offset();
	var h = $(elem).height();
	var w = $(elem).width();

	if(h == 0 || w == 0)
		return
		
	$('#short-details-box').css({ left: pos.left + w + 10, top: pos.top + h - 100 });
	$('#short-details-box').css('position', 'absolute')
	$('#short-details-box').css('width', 400)
	
	$('#short-details-title').html(data.title)
	$('#short-details-body').html(data.response)
	$('#short-details-box').fadeIn()
}

function hide_bot_details()
{
	$('#short-details-box').hide()
}




