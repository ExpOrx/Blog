function add_server()
{
	var html = $('#notes').val()
	
	var ip = prompt('Ip?')
	var password = prompt('password?')
	
	var server = 'ssh -p22 -o "StrictHostKeyChecking no" root@' + ip + '\n' + password + '\n'
	
	$('#notes').val(server + '\n' + html)
}

function plus(what)
{
	var current = document.getElementById('paid_until').value // d/m/Y
	if(current.trim() == '')
	{
		var d_now = new Date();
		current = ('0'+(d_now.getDate())).slice(-2) +'/'+ ('0'+(d_now.getMonth()+1)).slice(-2) +'/'+ d_now.getFullYear()
	}
	
    var elems = current.split('/');

	var d = new Date(elems[2], elems[1] - 1, elems[0]) // year month day

	if(what == 'week')
		d.setDate(d.getDate() + 7)
	else
		d.setMonth(d.getMonth() + 1) // +1 month
		
	var new_date = ('0'+(d.getDate())).slice(-2) +'/'+ ('0'+(d.getMonth()+1)).slice(-2) +'/'+ d.getFullYear()
	document.getElementById('paid_until').value = new_date
	
	$('#status').val('active')
}
