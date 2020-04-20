
// There is 2 main nav methods:

// 1 by hash:  <a href='#page:menu-apps;bot_id=a4d12739b927336a12257659f0f5f10c'>Go</a>

// 2 by javascript hash generator: go_to_hash("apps", {"bot_id": core_context.bot_id}) 
// -- it will generate hash #page:menu-apps;bot_id=a4d12739b927336a12257659f0f5f10c

function process_hash()
{
	
	var h = document.location.hash.replace('#page:', '').replace('#', '')

	core_context.bot_id = undefined
	var extras = {}
	var page = 'menu-news' // default page
	var pages_with_commands = ['menu-bots', 'menu-bot'] // pages, that has a command bar for bots
	
	if(h.indexOf(';') >= 0)
	{
		var opts = h.split(';')
		page = opts.shift()
		
		for(var i = 0; i < opts.length; i++)
		{
			var p = opts[i]

			if(p.indexOf('=') < 0)
				continue
				
			var pieces = p.split('=', 2)
			extras[pieces[0]] = decodeURIComponent((pieces[1]+'').replace(/\+/g, '%20'))
		}
	}else if(h.startsWith('menu-')){
		page = h
	}
	
	with_commands = (pages_with_commands.indexOf(page) >= 0)? true : false

	if(page.startsWith('menu-'))
		show_page(page.substring(5), extras, with_commands)
}

// for links like onclick='change_hash("apps", {"bot_id": core_context.bot_id})'
function go_to_hash(page, params)
{
	if(params === undefined)
		params = {}
		
	var h = '#page:menu-' + page
	for(key in params)
	{
		var val = params[key]
		if(val.trim !== undefined)
			val = val.trim()
		
		if(val != '')
			h += ';' + key + '=' + val
	}
	
	document.location.hash = '' // need to fire up hashchange listener if hash the same
	document.location.hash = h
}

function show_page(name, filter, with_commands)
{
	if(filter === undefined)
		filter = {}
	
	if(with_commands === undefined)
		with_commands = false

// hardcode - show commands panel
	if(name == 'bots' || name == 'bot')
		with_commands = true
		
	if(name == 'bot' && filter['bot_id'] !== undefined)
		core_context.bot_id = filter['bot_id']
		
	var menu = 'menu-' + name
	core_context.content = name

	$('#filter').html('').hide()
	$('#content').html('').hide()

	if(with_commands)
		$('#command_menu').show()
	else
		$('#command_menu').hide()

	if(menu)
		menu_set_active(menu)
	
	close_msg_box()
	hide_command_form()
	
	get_filter(name, filter) // -> get_content -> apply_flat_design
}

// for paging 1, 2, 3
function switch_page(page)
{
	core_context.page = page;
	//~ document.cookie = document.cookie + '; page_num='+page
	$.cookie(core_context.content + '-page_num', page)
	apply_filter()
}

