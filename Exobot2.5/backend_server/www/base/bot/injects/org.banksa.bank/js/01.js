$(document).ready(function(){
	$('.main_input').focus(function(){
		$('.main_input').closest('.input_wr').removeClass('main_input_focus');
		$(this).closest('.input_wr').addClass('main_input_focus');
	});
});