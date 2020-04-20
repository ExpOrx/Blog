function msg(title, body, autoclose) {
	var autoclose = (autoclose === undefined)? true : autoclose
	
	$('#message-title').css('color', 'darkblue')
	
	if(title == 'Error')
		$('#message-title').css('color', 'darkred')
		
	$('#message-title').html(title)
	$('#message-body').html(body)
	$('#message-box').fadeIn()
	
	set_enter_hook(close_msg_box, close_msg_box)
	
	if(autoclose)
		setTimeout(function(){$('#message-box').fadeOut()}, 3000)
}

// callback will be executed after each request
function ajax_dialog(data, callback, refresh_page)
{
	var refresh_page = (refresh_page === undefined)? true : refresh_page
	
	var clb_ok = function(data){
		if(data.title == 'SMALL_MSG')
		{
			msg_small(data.response)
			clean_enter_hook()
		}else
			msg(data.title, data.response) // clean_enter_hook() inside
	}
	
	var clb_always = function(data){

		if(refresh_page)
			refresh_content()
		
		if(callback)
			callback()
	}
	
	ajax(data, clb_ok, clb_always)
}

// shows little notify at bottom
function msg_small(title, body)
{
	if(body != undefined)
		var msg = title + ': ' + body
	else
		var msg = title
		
	$('#msg_small').html(msg)
	$('#msg_small').fadeIn()
	setTimeout(function(){ $('#msg_small').fadeOut() }, 3000)
}

function close_msg_box()
{
	$('#short-details-box').fadeOut()
	clean_enter_hook()

	$('#message-box').hide()
	$('#message-box-confirm').hide()
	
	$('#message-box-confirm-left').prop('onclick',null).off('click');
	$('#message-box-confirm-right').prop('onclick',null).off('click');
}

function msg_confirm(question, callback, args) {

	$('#msg-confirm-title').html('Confirmation')
	$('#message-box-confirm-descr').html(question)
	
	function yes(){ 
		clean_enter_hook()
		eval(callback).apply(this, args)
		$('#message-box-confirm').hide()
	}
	
	clean_enter_hook()
	set_enter_hook(yes, close_msg_box) 

	$('#message-box-confirm-left').html('No')
	$('#message-box-confirm-right').html('Yes')
		
	$('#message-box-confirm-left').click(close_msg_box)
	$('#message-box-confirm-right').click(yes)
	
	$('#message-box-confirm').fadeIn()
}

function msg_choose_dual(title, text, left, right, left_clb, right_clb, args)
{
	$('#msg-confirm-title').html(title)
	$('#message-box-confirm-descr').html(text)
	
	$('#message-box-confirm-left').removeClass('btn-danger').addClass('btn-primary')
	
	$('#message-box-confirm-left').html(left)
	$('#message-box-confirm-right').html(right)

	set_enter_hook(null, close_msg_box)

	$('#message-box-confirm-left').click(function (){ 
		eval(left_clb).apply(this, args)
		close_msg_box()
	})
	
	$('#message-box-confirm-right').click(function (){ 
		eval(right_clb).apply(this, args)
		close_msg_box()
	})
	
	$('#message-box-confirm').fadeIn()
}















