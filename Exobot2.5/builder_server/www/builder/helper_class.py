import os, glob, re, string, random, sys, time, subprocess, traceback, base64, json, cgi, socket, inspect
import urllib, hashlib, shutil
from urllib.parse import quote, unquote, quote_plus, unquote_plus, urlencode
from stat import *
import html.entities
from io import StringIO
from contextlib import contextmanager

class hlp:

	PATTERN_EMAIL = r'([-0-9a-zA-Z_&.%+]+@[0-9a-zA-Z\-]+\.?[\.a-zA-Z0-9]{2,20}(?:com|net|link|org|biz|info|name|pro|asia|aero|cat|coop|eco|jobs|mobi|museum|post|tel|travel|xxx|edu|gov|pl|int|mil|рф|укр|xn--[\\w-]*|[a-z]{2}))' # имейл
	
	PATTERN_PROXY = r'([0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}:[0-9]{2,6})' # прокси
	PATTERN_PROXY_2 = r'([0-9\-a-z\-\.]+:[0-9]{2,5})' # прокси
	PATTERN_PROXY_TYPE = r'([0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}:[0-9]{2,6}\|[0-2]{1})' # прокси с типом
	PATTERN_PROXY_2_TYPE = r'([0-9\-a-z\-\.]+:[0-9]{2,5}\|[0-2]{1})' # прокси с типом 1.1.1.1:80|0, 1.1.1.1:5555|1

	PATTERN_IP = r'([0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3})'

	LETTERS_CYR = 'абвгдеёжзийклмнопрстуфхцчшьщъыэюя'
	LETTERS_LAT = string.ascii_lowercase # abcdefg...

	sep = os.sep # разделитель. На никсах /, на винде \\
	linesep = os.linesep # перевод строки. На никсах \n, на винде \r\n

	def __init__(self, parent):
		self.parent = parent

	print_orig = print

	@contextmanager
	def redirected(out):
		sys.stdout = out
		try:
			yield
		finally:
			sys.stdout = sys.__stdout__

	# you can access 'end' argument of print only with hlp.print_orig()
	def print(*args):
		out = StringIO()

		result = ''
		with hlp.redirected(out):
			try:
				hlp.print_orig(*args)
			except:
				pass
			result = out.getvalue().encode('utf-8')

		try:
			sys.stdout.buffer.write(result)
		except:
			sys.stdout.write(str(result))
		try:
			sys.stdout.flush()
		except:
			pass

	def cd(path):
		os.chdir(path)

	def mkdir(name, **kwa):
		return os.makedirs(name, **kwa)

	def html_hex2utf8(text):
		# convert &#x42b;&#x430;&#x43e;&#x443;&#x430; -> ЫАУАЭО
		res = ''
		for letter in text.split(';'):

			if not letter.strip():
				continue

			if letter.startswith('&#x'):
				c = letter.replace('&#x', '0x')
				c = int(c, 16)
				c = chr(c)
				res += c
			else:
				res += letter

		return res

	def get_address_ip(address):

		dom = hlp.url2domain(address)

		try:
			ip = socket.gethostbyname(dom)
		except Exception as ex:
			print('get_address_ip error: {}'.format(ex))
			return False

		return ip

	def is_domain(name):
		# проверяет, является ли строка доменом
		# @param str name
		# @return bool

		if not name.count('.'):
			return False 
			
		# http://www.mkyong.com/regular-expressions/domain-name-regular-expression-example/ + fix
		res = hlp.find('^((?!-)[A-Za-z0-9-\\.]{1,63}(?<!-)\\.+[A-Za-z]{2,6})$', name)
		if res is False:
			return False
		else:
			return True

	def is_launcher():
		# проверяет, запущен скрипт в лаунчере или нет

		if ' Qt/' in os.environ.get('HTTP_USER_AGENT', ''):
			return True
		else:
			return False

	def strip_hard(text):
		# удаляет также неразрывныя пробѣлы, такiя какъ " " (сравни с " ")
		return str(text).replace('\ufeff', '').replace('\xa0', '').replace('&nbsp;', '').strip()

	def parent_doll(silent=False):
		from threading import Event

		class Cnf:
			def getbool(self, t):
				if t == 'proxy':
					return False

				if t == 'debug' or t == 'redirsdebug' or t == 'httpdebug':
					return False

				return True

			def get(self, name):
				return ''

			def getint(self, t):
				return 100

			def chk(self, name):
				return False

		class Proxy:
			def change(self, http):
				pass

		class Parent:

			cmd_path = ''
			cnf = Cnf()
			data = {}
			file = False
			silent = False
			
			tid = 999
			proxy = Proxy()
			threadsStopped = Event()
			def __init__(self, silent=False):
				silent = silent
				
			def log(self, t, type_='~', tid=0, ctype='', hide=False):
				if not silent:
					print('{} {}<br />'.format(type_, t))

		class httpClass:
			pass

		class asThreads:
			pass

		class asSqlite_deferred:
			pass

		parent = Parent(silent)

		os.sys.path.insert(0, '../../')
		from helper_class import hlp

		parent.hlp = hlp(parent)

		def cnt(name='', mode='inc', value=0):
			pass

		parent.hlp.cnt = cnt
		parent.http = httpClass()
		parent.threads = asThreads()
		parent.sqlite_def = asSqlite_deferred()
		parent.active_project = ''
		parent.active_module = ''
		parent.config = ''
		parent.db_path = ''

		return parent

	def info(text):
		return '<p class="grey">{0}</p>'.format(text)

	def err(text):
		return '<p class="red">{0}</p>'.format(text)

	def ok(text):
		return '<p class="blue">{0}</p>'.format(text)

	def is_file(path):
		return bool(os.path.isfile(path))

	def is_dir(path):
		return bool(os.path.isdir(path))

	def is_windows():
		return bool(os.name != 'posix')

	def is_bsd(): # freebsd
		return bool('bsd' in sys.platform)

	def pid():
		return os.getpid()

	def debug_form():
		# распечатывает все поля
		form = cgi.FieldStorage()
		print('<textarea autocomplete="off" style="position: fixed; top: 10px; right: 10px; width: 300px; height: 100px">')
		for elem in form:
			print('{0}: {1}\n'.format(elem, form.getvalue(elem, 'UNSET')))
		print('</textarea>')

	def is_valid_email(email):

		res = hlp.parse(hlp.PATTERN_EMAIL, email)
		if res is False:
			return False
		else:
			return True

	def extract_emails(data):

		emails = hlp.parse_all(hlp.PATTERN_EMAIL, data)
		if emails is False:
			return []

		return list(set(emails))

	def exists(path):
		return bool(os.path.exists(path))

	def email(encode=False):
		if encode:
			return '{0}%40{1}.com'.format(hlp.password(10), hlp.password(10))
		else:
			return '{0}@{1}.com'.format(hlp.password(10), hlp.password(10))

	# return_only_names DEPRECATED attribute
	def ls_image(dirname='.', return_only_names=False, names=False):

		if return_only_names:
			names = True

		files = hlp.ls2(dirname, names=names)
		result = []
		for f in files:
			if '.' not in f:
				continue

			ext = f.rsplit('.', 1)[-1].lower()
			if ext not in ['jpg', 'jpeg', 'png', 'gif']:
				continue

			if names:
				sz = hlp.size('{}/{}'.format(dirname, f))
			else:
				sz = hlp.size(f)

			if sz  == 0:
				continue

			result.append(f)

		return result

	def recursion_limit(limit=2):
		# позволяет функции вызвать себя не больше N раз (включая первый запуск)
		# if self.http.last_error != '' and hlp.recursion_limit(3):
		#       return function()
		# -- рекурсия остановится на 3х вызовах

		stack = inspect.stack()
		func_name = stack[1][3]

		depth = 0
		for elem in stack:
			if elem[3] == func_name:
				depth += 1
			else:
				break

		if depth >= limit:
			return False
		else:
			return True

	def ls2(path, folders=False, files=False, names=False, recursive=False):
		# переосмысление ls с запоминаемыми аргументами
		# path - путь
		# folders - вернуть только директории
		# files - вернуть только файлы
		# names - вернуть имена, а не пути
		# recursive - рекурсивно

		if not recursive:
			return hlp.ls(dirname=path, only_folders=folders, only_files=files, return_only_names=names)

		# отключаем фильтры файлов/дир для рекурсивного поиска
		folders_src = folders
		files_src = files
		
		if recursive:
			files = False
			folders = False
			
		elems = hlp.ls(dirname=path, only_folders=folders, only_files=files, return_only_names=False)

		result = []
		for elem in elems:

			if hlp.is_dir(elem):
				result.append(elem)
				result += hlp.ls2(elem, folders=folders, files=files, names=False, recursive=recursive)
			else:
				result.append(elem)

		# чистим от директорий/файлов при рекурсивном
		if recursive:
			if folders_src:
				result = [elem for elem in result if hlp.is_dir(elem)]
			elif files_src:
				result = [elem for elem in result if not hlp.is_dir(elem)]

		if names:
			result = [r.rsplit(hlp.sep, 1)[1] for r in result]
			result = list(set(result))

		return result

	def ls(dirname='.', only_folders=False, no_pycache=True, no_init=True, exclude=[], return_only_names=False, exclude_extension=False, only_files=False, remove_ext=False, normal_slashes=False):
		'''
		листинг директории
		@str dirname - путь, который сканировать
		@bool only_folders - вернуть только директории
		@bool no_pycache - исключить __pycache__
		@bool no_init - исключить __init__.py
		@list exclude - исключить из результатов элементы
		@bool return_only_names - вернуть только имена
		@bool exclude_extension - исключить файлы с расширением '.расширением'
		@bool only_files - вернуть только файлы
		@bool remove_ext - обрезать расширения
		@bool normal_slashes - "/" слеши в пути, иначе будут os.sep
		@return true/false
		'''
		if '*' not in dirname:
			if dirname.endswith('/'):
				dirname += '*'
			else:
				dirname += '/*'

		if not normal_slashes:
			dirname = dirname.replace('/', os.sep)

		dirname = dirname.replace('[', '[[]')

		data = glob.glob(dirname)

		if only_folders:
			data = [d for d in data if os.path.isdir(d)]

		if only_files:
			data = [d for d in data if not os.path.isdir(d)]

		if no_pycache:
			data = [d for d in data if not d.endswith('__pycache__')]

		if no_init:
			data = [d for d in data if not d.endswith('__init__.py')]

		if exclude:
			result = []

			for d in data:
				for e in exclude:
					if not d.endswith(e):
						result.append(d)

			data = result

		if return_only_names:
			data = [v.split(os.sep)[-1] for v in data]

		if exclude_extension:
			data = [v for v in data if not v.endswith(exclude_extension)]

		if remove_ext:
			data = [v.rsplit('.', 1)[0] for v in data]

		return data

	def get_softid():

		softid = ''
		j = 0

		for letter in hlp.password(40).upper():
			softid += letter
			j += 1
			if j > 5:
				softid += '.'
				j = 0

		return softid

	def delete_file(path):
		os.unlink(path)

	def get_client_ip():
		return os.getenv('REMOTE_ADDR')

	#DEPRECATED! use get_client_ip()
	def client_ip():
		return os.getenv('REMOTE_ADDR')

	def b64_decode(text):
		return base64.decodestring(bytes(text, 'utf-8')).decode('utf-8', 'ignore')

	def b64_encode(text):
		return base64.encodestring(bytes(text, 'utf-8')).decode('utf-8', 'ignore').replace('\n', '')
		
	def quote_url(text, encoding=None):

		pieces = hlp.parse_all(r'([а-яА-ЯёЁ]+)', text)
		if not pieces:
			return text

		for piece in pieces:
			text = text.replace(piece, hlp.quote(piece))

		text = text.replace(' ', '%20')
		return text

	def quote(text, encoding=None):
		return quote(text, encoding=None)

	def unquote(text):
		return unquote(text)

	def time(full=False):
		return time.time() if full else int(time.time())

	def _print(*text):
		try:
			hlp.print(*text)
		except:
			try:
				sys.stdout.buffer.write(text.encode('utf8'))
				sys.stdout.flush()
			except:
				print('hlp._print output exception')

	def js_debug(text):
		print('<script>console.log("{}")</script>'.format(text.replace('"', "'")))

	def print_raw(shit, delim='<br />', prelim=''):
		if isinstance(shit, str):
			print(prelim + '"' + shit + '"' + delim)

		elif isinstance(shit, int) or isinstance(shit, float):
			print(prelim + '"' + str(shit) + '"' + delim)

		elif isinstance(shit, list):
			print('[')

			for elem in shit:
				hlp.print_raw(elem, ', ')

			print('], ')

		elif isinstance(shit, dict):
			print('&nbsp;&nbsp;&nbsp;{')
			for key, elem in shit.items():
				hlp.print_raw(key, ': ')
				hlp.print_raw(elem, ',')
			print('},')

	def quote_plus(text):
		return quote_plus(text)

	def unquote_plus(text):
		return unquote_plus(text)

	def tb_format(e, show=False, html=False):
		'''
		создает распечатку эксепшена с трейсбеком
		@param Exception e - эксепшен (Exception as e)
		@return str распечатка
		'''

		e = str(e)
		tb = sys.exc_info()[2]
		if tb:
			tb = ''.join(traceback.format_tb(tb))
			fnames = hlp.parse_all(r'File (".*?)"', tb)
			if fnames:
				for fname in fnames:
					try:
						short = fname.split(os.sep)[-1]
					except:
						short = fname

					tb = tb.replace(fname, short)

			tb = tb.replace('", line ', ':')

		else:
			tb = 'Not detected'
			print('EXC_INFO', sys.exc_info())

		text = 'Description: {}\nTraceback:\n{}'.format(e, tb)

		if show:
			html = True

		if html:
			text = text.replace(' ', '&nbsp;').replace('\n', '<br />')
			text = '<span style="color: blue; font-size: 10pt">{}</span>'.format(text)

		if show:
			print(text)

		return text

	def traceback_save(name, e, mode='a'):

		text = hlp.tb_format(e)
		text = '\n=============================================\nTime: {}\n{}\n'.format(hlp.human_date(), text)

		with open('tmp/EXCEPTION_' + name, mode + 'b') as fp:
			fp.write(text.encode('utf-8'))

		return text

	def set_cookie(cookies, value=False, method='http', init=True):
		'''
		ставит http-куки
			@dict cookies - словарь с куками
		или
			str cookies - имя
			str value - значение

		Пример скрипта, ставящего куки

		c = {
			'cookie1': 'value1',
			'cookie1': 'value1',
			'cookie1': 'value1',
		}
		cookie_set(c)

		@str method - http / js
			ставить куки http-хидерами (до любого вывода)
			или яваскриптом

		@bool init - инициализировать скрипт
			js-метод: подключив jquery и interface.js
			http-метод: послав заголовок "Content-type: text/html"

		В entire везде используется с init=True, поэтому по умолчанию он True

		@return None
		'''

		if value is not False:
			cookies = {cookies: value}

		# заточен под entire, требует jquery и setcookie из interface.js
		if method == 'js':
			if init:
				print('''<script src='res/jq.js'></script>
			<script src="res/interface.js?rnd=1405766967"></script>''')

			print('''
			<script>
				$(document).ready(function(){

			''')

			for name, value in cookies.items():
				print('''setcookie('{}', '{}')'''.format(name, value))

			print('''
			 });
			</script>''')
			return

		elif method == 'http':

			import http.cookies, sys

			if init:
				sys.stdout.buffer.write(b'Content-type: text/html;charset=utf-8\n')

			for name, value in cookies.items():
				c = http.cookies.SimpleCookie()
				c[name] = value
				ctext = c.output() + '\n'

				sys.stdout.buffer.write(ctext.encode('utf8'))

			if init:
				sys.stdout.buffer.write(b'\n\n')
			sys.stdout.flush()

	def log(text, type_=''):

		ctypes = {'!':'red', '+':'#0DA7F8', '*':'#FFBE70', '$':'#FFFAC5', '><':'#FFC0C0', '-':'#CBFFCD', '~':'#EFEFEF', '%': '#000', '': 'grey'}

		print('''<p threadid="" class="logline  onmouseblink"><span style="padding: 2px; background-color: {}">HLP</span> {}</p>'''.format(ctypes[type_], text))

	def get_cookie(name):
		'''
		получить значение куки name
		@str name - имя куки

		Пример в голом скрипте:

		sys.stdout.buffer.write(b'Content-type: text/html;charset=utf-8\n\n')
		val = get_cookie('pass')

		@return str значение/false
		'''

		import http.cookies

		try:
			cookie = http.cookies.SimpleCookie(os.environ["HTTP_COOKIE"])
			val = hlp.unquote(cookie[name].value)
		except: #  http.cookies.CookieError as KeyError
			return False

		return val

	def ip2long(ip):
		from socket import inet_aton
		from struct import unpack

		try:
			ip2 = unpack("!L", inet_aton(ip))[0]
			return ip2
		except Exception as ex:
			print('hlp.ip2long: {}'.format(ex))
			return False

	def url2domain(url):

		if '://' in url:
			url = url.split('://', 1)[-1]

		return url.split('/', 1)[0]

	def urldecode(text):
		return unquote(text)

	def urlencode(text):
		return urlencode(text)

	# DEPRECATED, use hlp.json
	def pack(obj):
		return json.dumps(obj)

	# DEPRECATED, use hlp.json
	def unpack(string):
		return json.loads(string)

	def valid_timestamp(ts):
		'''
		проверка timestamp на валидность 136xxxxx
		'''

		try:
			ts_str = str(ts)
		except:
			return False

		if len(ts_str) != 10:
			return False

		return True

	def textarea(text, show=True, wide=False):

		text = str(text)
		text = text.replace('<textarea', '&lt;textarea')
		text = text.replace('/textarea>', '/textarea&gt;')

		cols = 120 if wide else 60
		rows = 20 if wide else 10

		html = '<textarea autocomplete="off" cols="{1}" rows="{2}">{0}</textarea>'.format(text, cols, rows)
		if show:
			print(html)

		return html

	def json(obj, default=False, silent=True, exception_file=None):
		'''
		конвертит строку в json, а все остальное в json-овскую строку
		@mixed obj - строка или объект
		@return mixed строка или объект
		'''
		if isinstance(obj, str):
			try:
				data = json.loads(obj)
			except Exception as ex:

				if exception_file:
					hlp.f_add(exception_file, 'Exception: {}<br />{}\n\n'.format(ex, obj))

				if not silent:
					print('JSON load error "{}": <textarea cols="60" rows="10">{}</textarea>'.format(ex, obj))

				return default

			return data
		else:
			return json.dumps(obj)

	def password(len=7, withDigits=True, onlyDigits=False, src='eng|ENG|num'):
		'''
		генератор всякой хуйни
		@int len - длина генерируемой хуйни
		@bool withDigits - DEPRECATED
		@bool onlyDigits - DEPRECATED
		@str src - задачи для генерации хуйни


		@return str
		'''

		# макросы
		if src == 'AS_TIME':
			return hlp.time()

		if src.startswith('AS_RAND_'):
			min_, max_ = src.split('_')[2:]
			return hlp.rand(int(min_), int(max_))

		if src == 'AS_MONTH':
			return hlp.rand(1, 12)

		if src == 'AS_DAY':
			return hlp.rand(1, 28)

		# / макросы

		d = {}
		d['cyr'] = 'абвгдеёжзийклмнопрстуфхцчшьщъыэюя' # комбо для мортал комбата блеать!
		d['CYR'] = 'АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЬЩЪЫЭЮЯ' # а ещё мне нравится писать на клаве слово приоритет не глядя
		d['eng'] = string.ascii_lowercase
		d['ENG'] = string.ascii_uppercase
		d['num'] = string.digits

		if onlyDigits:
			src = 'num'

		data = ''
		for t in src.split('|'):
			data += d[t]

		result = ''
		for i in range(len):
			i
			result += random.choice(data)

		return result

	# get_form deprecated, use form instead
	def cgi_init(get_form=False, form=False):
		sys.stdout.buffer.write(b'Content-type: text/html;charset=utf-8\n\n')
		os.dup2(1, 2)

		if get_form or form:
			return cgi.FieldStorage()

	def get_cli_args():

		sys.argv.pop(0)
		res = {}
		for elem in sys.argv:
			try:
				k, v = elem.split('=')
			except:
				k = elem
				v = ''

			res[k] = v

		return res

	def bukvomixer(msg, mix_cyr_lat=False, insert_letters=0, letters=':ENG::RUS:', shuffle=0, log=None):
		'''
		рандомизация текста в блоках <mix></mix>
		@str msg - сообщение
		@bool mix_cyr_lat - менять кириллицу на латиницу рандом
		@int insert_letters - вставлять рандом буквы в процентах
		@bool shuffle - мешать буквы внутри слова, коэффицент перемешивания от 1 до 10
		@<base.log> - функция вывода в лог

		# пример запуска:
		# hlp.bukvomixer(content, mix_cyr_lat=True, insert_letters=30, letters='fqtj', shuffle=3, log=self.log)
		# контент, который попадает под буквомиксер оборачивать в <mix></mix>

		@return str msg
		'''

		if not log:
			log = print

		# [123-0-100]
		randoms = hlp.parse_all(r'(\[123\-[0-9]+\-[0-9]+\])', msg)
		if randoms:
			randoms = list(set(randoms))

			for r in randoms:
				try:
					s1, s2 = r[1:-1].split('-')[1:]
					l = hlp.rand(int(s1), int(s2))
					new = hlp.password(l, src='num')
				except Exception as ex:
					log('буквомиксер: ошибка парсинга макроса <b>{0}</b>: {1}'.format(r, ex), '!')
					continue

				log('буквомиксер: меняем <b>{0}</b> на <b>{1}</b>'.format(r, new))
				msg = msg.replace(r, new)

		# [ABC-0-100]
		randoms = hlp.parse_all(r'(\[ABC\-[0-9]+\-[0-9]+\])', msg)
		if randoms:
			randoms = list(set(randoms))

			for r in randoms:
				try:
					s1, s2 = r[1:-1].split('-')[1:]
					l = hlp.rand(int(s1), int(s2))
					new = hlp.password(l, src='eng')
				except Exception as ex:
					log('буквомиксер: ошибка парсинга макроса <b>{0}</b>: {1}'.format(r, ex), '!')
					continue

				log('буквомиксер: меняем <b>{0}</b> на <b>{1}</b>'.format(r, new))
				msg = msg.replace(r, new)

		# рандом классов
		for i in range(99):

			m = '[MACROS{}]'.format(i)
			if m in msg:
				r = hlp.password(src='eng')
				msg = msg.replace(m, r)
				log('буквомиксер: заменили <b>{0}</b> на <b>{1}</b>'.format(m, r))

		if '<mix>' not in msg or '</mix>' not in msg:
			#~ log('буквомиксер: в сообщении нет &lt;mix&gt;')
			return msg

		# r'(\[\[\[[\S\s]+\]\]\])'
		blocks = hlp.parse_all(r'(<mix>[\S\s]+?</mix>)', msg)
		if not blocks:
			#~ log('буквомиксер: в сообщении нет &lt;mix&gt;')
			return msg

		log('буквомиксер: нашел <b>{0}</b> блоков &lt;mix&gt;'.format(len(blocks)))

		for i, block in enumerate(blocks):
			log('буквомиксер: блок #{}'.format(i))
			block_orig = block

			block = block[5:-6] # убираем <mix></mix>

			# перемешивание букв внутри слов
			if shuffle:
				log('буквомиксер: перемешиваем буквы внутри слов')
				block = hlp.mix_words(block, shuffle)

			# замена кириллических на латинские
			if mix_cyr_lat:
				log('буквомиксер: меняем буквы на русские/латинские')
				block = hlp.change_letters(block)

			# вставка рандомных букв
			if insert_letters:

				total_let = len(block)
				one_perc = total_let / 100
				need_insert = round(one_perc * insert_letters)
				log('буквомиксер: вставляем {} символов ({}% от {})'.format(need_insert, insert_letters, total_let))

				for i in range(need_insert):

					letters = letters.replace(':RUS:', hlp.LETTERS_CYR)
					letters = letters.replace(':ENG:', hlp.LETTERS_LAT)

					let = letters[hlp.rand(0, len(letters)-1)]
					ind = hlp.rand(0, total_let-1)
					block = block[:ind] + let + block[ind:]

			msg = msg.replace(block_orig, block)

		return msg

	def mix_words(msg, coefficient):
		'''
		перемешивает буквы внутри слов
		@param
		@return
		'''

		words = hlp.parse_all(r'[а-яА-Яa-zA-Z]+', msg)
		words = [w for w in words if len(w) > 5]

		for word in words:

			result = word[0]
			body = list(word[1:-1])
			body2 = ''

			for i in range(0, len(body), 2):
				if hlp.rand(0, 10) < coefficient:
					try:
						body2 += body[i+1]
					except:
						pass
					body2 += body[i]
				else:
					body2 += body[i]
					if len(body) > i+1:
						body2 += body[i+1]

			result += body2 + word[-1]

			msg = msg.replace(word, result)

		return msg

	def redir(url, sleep=0, silent=True, exit=True):

		if not silent:
			print("redirect to %(url)s after %(sleep)s seconds.." % locals())

		print("<meta http-equiv='refresh' content='%(sleep)s; url=%(url)s'>" % locals())
		if exit:
			sys.exit(0)

	def cut(data, marker1, marker2=''):

		if not data.count(marker1) or (marker2 != '' and not data.count(marker2)):
			return data

		data = data.split(marker1)[1]

		if marker2 != '':
			data = data.split(marker2)[0]

		return data

	def unzip(local_name):
		# распаковывает файл в tmp/ и удаляет архив

		resp = hlp.execute('unzip -o ' + local_name)
		names = hlp.parse_all(r'inflating\: (.*?)\n', resp)
		if names is False:
			print('Unzip error')
			return False

		name = names[-1].strip()

		#print('unzip name: ' + name)
		while True:
			if os.path.exists(name):
				#print('delete zip')
				os.unlink(local_name)
				return name

			#print('wait while unpacking..')
			hlp.slp_simple(1)

	def unlink(filename):
		os.unlink(filename)

	def unicode_decode(text):
		# \u041c -> 'a'

		if isinstance(text, str):
			text = bytes(text, 'utf-8')

		text = text.decode('unicode_escape')
		return text

	def slp_simple(delay):
		time.sleep(delay)

	def slp(self, delay, log=False):
		'''
		self.hlp.slp(5)
		self.hlp.slp('spamer_delay')
		self.hlp.slp(self.cnf.get('spamer_delay')) '''

		option_value = ''
		delay_s = 0

		# если int 5
		if isinstance(delay, int):
			delay_s = delay
			option_value = ''

		# если строка 'xxxx_delay'
		elif isinstance(delay, str) and 'delay' in delay:
			option_value = self.parent.cnf.get(delay)
			if not option_value:
				log('опция <b>{}</b> не найдена в конфиге'.format(delay), '!')
				return

		# если строка '1'
		elif isinstance(delay, (str, float)):
			option_value = delay

		# '1', '0.5', '1-5', '0.1-0.9'
		if option_value:
			if isinstance(option_value, str):
				if '-' in option_value:
					delay_s = hlp.rand(option_value)
				elif '.' in option_value:
					delay_s = float(option_value)
				else:
					delay_s = int(option_value)
			else:
				delay_s = int(option_value)

		if 's' in sys.argv:

			if log:
				if hasattr(log, '__call__'):
					log('спим {0} сек.'.format(delay_s))
				else:
					log.log('спим {0} сек.'.format(delay_s))
			else:
				self.parent.log('спим {0} сек.'.format(delay_s))

			time.sleep(delay_s)
			return

		# int/float delay_s
		total = delay_s
		while delay_s > 60:

			delay_s -= 60

			if log:
				if hasattr(log, '__call__'):
					log('осталось спать {0} из {1}'.format(hlp.human_time(delay_s), hlp.human_time(total)))
				else:
					log.log('осталось спать {0} из {1}'.format(hlp.human_time(delay_s, hlp.human_time(total))))
			else:
				self.parent.log('осталось спать {0} из {1}'.format(hlp.human_time(delay_s), hlp.human_time(total)))

			time.sleep(50)
			print('<!-- -->')
			time.sleep(10)

		if log:
			if hasattr(log, '__call__'):
				log('спим {0}'.format(hlp.human_time(delay_s)))
			else:
				log.log('спим {0}'.format(hlp.human_time(delay_s)))
		else:
			self.parent.log('спим {0}'.format(hlp.human_time(delay_s)))

		time.sleep(delay_s)

	def md5(text):

		if isinstance(text, str):
			text = text.encode('utf-8', 'ignore')

		return hashlib.md5(text).hexdigest()

	def md5_file(f, block_size=2**20):

		md5 = hashlib.md5()

		with open(f, 'rb') as fp:

			while True:
				data = fp.read(block_size)
				if not data:
					break
				md5.update(data)

		return md5.hexdigest()

	def dx(text, tid=0):
		'''print lists'''

		import sys

		result = ''
		for elem in text:
			result += ', ' + str(elem)

		msg = '<p threadid="%s" class="logline">#%s [size: %s] %s</p>\n' % \
			  (tid, tid, len(text), result)

		sys.stdout.buffer.write(msg.encode('utf8'))
		sys.stdout.flush()

	def strip_tags(data, to=''):
		patt = re.compile(r'<.*?>')
		return patt.sub(to, data)

	def reg_escape(text):
		# готовит строку для включения в регулярку
		return re.escape(text)

	def parse(pattern, data, ignore_case=False, group=False, system=False):
		''' возвращает первое совпадение pattern в data
		макросы *SPACE* -  '[\S\s]*?' , *VALUE* - '([^"]+)'
		group - вернуть все результаты (для регулярок, которые имеют несколько групп ([^]+) )

		system - системные регулярки, которые не надо дебажить
		'''

		if isinstance(pattern, list):
			for patt in pattern:
				res = hlp.parse(patt, data, ignore_case=ignore_case, group=group, system=system)

				if res is not False:
					return res

			return False

		patt_src = pattern
		pattern = hlp._pattern_hlp(pattern)

		if ignore_case:
			m = re.search(pattern, data, re.I)
		else:
			m = re.search(pattern, data)

		if not m:

			if hasattr(hlp, 'regex_debug') and not system:
				x_debug = 'tmp/regex_{}.html'.format(hlp.password(20))
				hlp.f_write(x_debug, pattern + '<FR_SPLIT>' + data)
				print('<p threadid="" class="logline onmouseblink regex_debug"><a href="reged.py?data={0}" target="_blank">регулярка <i>{1}</i></a></p>'.format(x_debug, hlp.cgi_escape(patt_src)))

			return False

		if group:
			return list(m.groups())
		else:
			return m.group(1)

	def stop(path):
		''' пишет в engine_cmd файл - stop
		hlp.stop(self.cmd_path)
		'''

		with open(path, 'wb') as f:
			f.write(b'stop')

		print('<script>stop_script()</script>')

		try:
			sys.exit(0)
		except:
			pass

	def get_modify_time(filename):
		'''
		возвращает время последней модификации файла в виде timestamp или False
		@str filename - путь к файлу
		@return int/false
		'''

		if not hlp.exists(filename):
			return False

		return os.stat(filename)[ST_MTIME]
		
	def get_perms(filename):
		'''
		возвращает права на файл в виде int 777 или False
		@str filename - путь к файлу
		@return int/false
		'''

		if not hlp.exists(filename):
			return False

		perms = int(oct(os.stat(filename)[ST_MODE])[-3:])

		if perms == 666 and hlp.is_windows():
			return 777
		else:
			return perms

	def set_perms(path, perms):
		'''
		ставит права на файл в формате 777
		@str path - путь до файла
		@str/int perms - новые права в формате 777
		@return true/false
		'''

		cmd = 'chmod -R {0} {1}'.format(perms, path)
		return hlp.execute(cmd, returnFull=True)

	def translit(text, cyr_to_lat=True):
		'''
		транслитерирует текст
		@str text - исходные текст
		@return str text - транслит
		'''

		if cyr_to_lat:
			chars = {'а':'a','б':'b','в':'v','г':'g','д':'d','е':'e','ё':'jo','ж':'zh','з':'z','и':'i','й':'j','к':'k','л':'l','м':'m','н':'n','о':'o','п':'p','р':'r','с':'s','т':'t','у':'u','ф':'f','х':'h','ч':'ch','ц':'c','ш':'sh','щ':'csh','э':'e','ю':'ju','я':'ja','ы':'y','ъ':'','ь':''}
		else:
			chars = {'p': 'п', 'r': 'р', 's': 'с', 't': 'т', 'u': 'у', 'v': 'в', 'y': 'ы', 'z': 'з', 'sh': 'ш', 'a': 'а', 'b': 'б', 'c': 'ц', 'd': 'д', 'e': 'е', 'f': 'ф', 'g': 'г', 'h': 'х', 'i': 'и', 'j': 'й', 'k': 'к', 'jo': 'ё', 'm': 'м', 'n': 'н', 'o': 'о', 'csh': 'щ', 'ju': 'ю', 'l': 'л', 'zh': 'ж', 'ja': 'я', 'ch': 'ч'}

		newtext = ''

		for letter in text.lower():
			newtext += chars.get(letter, letter)

		return newtext

	def f_touch(name, perms=False):
		'''
		создает пустой файл с правами 777
		@param
		@return true/false
		'''

		with open(name, 'w', 0o777) as fp:
			fp.write('')

		if perms is not False:
			hlp.execute('chmod {1} {0}'.format(name, perms))
	
	def f_write_cgi(field, path="./"):
	
		# form = hlp.cgi_init(True)
		# name = hlp.f_write_cgi(form['fileToUpload'], "path/to/save/")
		# print(name + " uploaded success")
		
		# don't forget: enctype='multipart/form-data'
		
		if not path.endswith('/'):
			path += '/'
			
		name = path + os.path.basename(field.filename)
		
		out = open(name, 'wb')
		out.write(field.file.read())
		out.close()
		return name

	def f_writelist(name, data, mode='w', charset='utf-8'):
		return hlp.f_write(name, '\n'.join(data), mode, charset)

	def f_readlist(name, decode=True , charset='utf-8', save_empty_rows=False):
		return hlp.f_read(name, decode, True,charset, save_empty_rows)

	def f_read(name, decode=True, to_list=False, charset='utf-8', save_empty_rows=False):

		name = name.replace('/', os.sep)

		data = ''
		with open(name, 'rb') as fp:
			data = fp.read()

		if decode:
			data = data.decode(charset, 'ignore')

		if to_list:
			if save_empty_rows:
				data = [v for v in data.split('\n')]
			else:
				data = [v.strip() for v in data.split('\n') if v.strip()]
		else:
			if not save_empty_rows:
				data = data.strip()

		return data

	def f_add(name, data, newline=True, create=False):

		if create and not hlp.exists(name):
			hlp.f_touch(name)

		data = str(data)
		name = name.replace('/', os.sep)

		if newline:
			data += '\n'
		hlp.f_write(name, data, 'a')

	def f_delete(path):
		try:
			os.unlink(path.encode())        
		except FileNotFoundError:
			pass
		
	def f_write(name, data, mode='w', charset='utf-8'):
		name = name.replace('/', os.sep)

		if not isinstance(data, (bytes, bytearray)):
			data = str(data).encode(charset, 'ignore')

		with open(name, mode + 'b') as fp:
			fp.write(data)

	def f_clear(name):

		name = name.replace('/', os.sep)

		hlp.f_write(name, '', 'w')

	def f_copy(name, dest):

		shutil.copy(name, dest)

	def _pattern_hlp(pattern):
		'''
		макросы *SPACE* -  '[\S\s]*?' , *VALUE* - '([^"]+)'
		'''
		# пустые места, переводы строк
		pattern = pattern.replace('*SPACE*', '[\S\s]*?')

		# выдирать значение до "
		pattern = pattern.replace('*VALUE*', '([^"]*)')

		# выдирать значение до '
		pattern = pattern.replace('*VALUE2*', "([^']+)")

		return pattern

	def parse_all(pattern, page, ignore_case=False, collect=False, system=False):
		'''
		возвращает все совпадения pattern в page
		если регулярка кривая или по ней ничего не найдено - False
		'''

		# поддержка списка регулярок

		if isinstance(pattern, list):

			if collect: # собрать результаты со всех регулярок

				result = []

				for patt in pattern:
					res = hlp.parse_all(patt, page, ignore_case=ignore_case, collect=collect, system=system)

					# если что-то нашли
					if res is not False:
						result += res

				return list(set(result))

			else: # вернуть результаты первой успешной регулярки

				for patt in pattern:
					res = hlp.parse_all(patt, page, ignore_case=ignore_case, collect=collect, system=system)

					# если что-то нашли
					if res is not False:
						return res

				return False

		# BODY

		patt_src = pattern
		pattern = hlp._pattern_hlp(pattern)
		try:
			if ignore_case:
				data = re.findall(pattern, page, re.I)
			else:
				data = re.findall(pattern, page)
		except Exception as ex:
			print('error parse with pattern: %s: %s' % (pattern, ex))
			return False

		if isinstance(data, list) and len(data):
			return data
		else:

			if hasattr(hlp, 'regex_debug') and not system:
				x_debug = 'tmp/regex_all_{}.html'.format(hlp.password(20))
				hlp.f_write(x_debug, patt_src + '<FR_SPLIT>' + page)
				print('<p threadid="" class="logline onmouseblink regex_debug"><a href="reged.py?data={0}" target="_blank">регулярка <i>{1}</i> ничего не нашла (все совпадения)</a></p>'.format(x_debug, hlp.cgi_escape(patt_src)))

			return False

	def parse_vars(data, page, log=None):
		'''
		заменяет списки регулярок в значениях словаря data на результаты их выполнения в page
		@dict data
		@str page

		Пример data: {'login': [r'name="([^"]+)', r'регулярка2', ...]}
		@return data
		'''
		for key, val in dict(data).items():

			if not isinstance(val, list):
				continue

			res = False
			for regex in val:
				res = hlp.parse(regex, page)
				if res is not False:
					break

			data[key] = res
			if log and res is False:
				log('не смог выпарсить значение <b>{}</b>, <b>{}</b> регулярки'.format(key, len(val)))

		return data

	def parse_custom(pattern, data):
		'''
		парсит по регулярке с несколькими значениями,
		типа 'test(.*) test2(.*?)'
		возвращает список результатов или False

		res = hlp.parse_custom(r'data\-miniprofile="([^"]+)" title="([^"]+)" class="', '')
		Удачно: ['1111', '2222']
		Неудачно: False

		@str pattern - паттерн
		@str data - строка для поиска
		@return list результаты/False
		'''

		res = re.findall(pattern, data)
		if not res:
			return False

		return list(res[0])

	def next(arr):
		''' возвращает элементы списка arr по очереди '''
		el = arr.pop(0)
		arr.append(el)
		return el

	def txt(phrases, body):
		'''
			ищет фразы списка phrases в body
			ищет элементы списка phrases в списке body
			@list * phrases
			@list */str body
			return bool
		'''

		if isinstance(phrases, str):
			phrases = [phrases]

		for phrase in phrases:
			if phrase in body:
				return True

		return False

	def rand(one, two=0):
		'''
		1 one - массив. возвращает рандом элемент из него
		2 one - цифра, two не указан или 0 - возвращает рандом число от 0 до one
		3 one и two - цифры, второй больше первого - возвращает рандом число от one до two
		4 one - строка типа "1-5", выбирается рандом элемент
		5 one - строка "5", возвращает 5 int
		'''

		# {'key': 111, 'test': 222}
		if isinstance(one, dict):
			if not len(one.items()):
				return False
			arr = list(one.items())
			return random.choice(arr)

		# [1,2,3]
		elif isinstance(one, list):
			if not len(one):
				return ''
			return random.choice(one)

		# 5
		elif isinstance(one, int):
			if two > 0:
				return random.randint(one, two)
			else:
				return random.randint(0, one)

		# "1-8" "1.1-2.5"
		elif isinstance(one, str) and '-' in one and len(one) > 2:
			t1, t2 = one.split('-')
			try:
				res = random.randint(int(t1), int(t2))
			except:
				res = random.uniform(float(t1), float(t2))

			return res

		# "6"
		if isinstance(one, str) and '-' not in one:
			return int(one)
		else:
			raise Exception('incorrect hlp.rand parameters: "{0}", "{1}"'.format(one, two))

	def lnk(path, name, style=''):
		return "<a href='%s' style='%s'>%s</a>" % (path, style, name)

	def mix(l):
		# перемешивает содержимое списка
		random.shuffle(l)
		return l

	def cnt(self, name, mode='inc', value=0):
		'''
			+/inc - увеличить на 1 (по умолчанию)
			-/dec - уменьшить на 1
			+= - прибавить
			=/set - установить
			get - получить
		'''

		if mode == 'get':
			if name not in self.parent.counters_map:
				return False

			index = self.parent.counters_map[name]
			return self.parent.counters[index]['value']

		self.parent.queue_cnt.put({'name': name, 'mode': mode, 'value': value})

		'''
		index = self.parent.counters_map[name]

		if mode == 'inc':
			with self.lock:
				self.parent.counters[index]['value'] += 1
		elif mode == 'dec':
			with self.lock:
				self.parent.counters[index]['value'] -= 1
		elif mode == '+=':
			with self.lock:
				self.parent.counters[index]['value'] += value
		elif mode == 'set':
			with self.lock:
				self.parent.counters[index]['value'] = value
		'''

	def change_letters(text):

		replaces = {'й': 'и', 'Й': 'И', 'у': 'y', 'К': 'K',  'е': 'e', 'Е': 'E', 'Н': 'H', 'х': 'x', 'Х': 'X', 'В': 'B', 'а': 'a', 'А': 'A', 'р': 'p', 'Р': 'P',  'о': 'o', 'О': 'O', 'с': 'c', 'С': 'C', 'М': 'M',  'Т': 'T'}

		text_new = ''
		for letter in text:
			if hlp.rand(0, 1):
				if letter == ' ':
					letter = '  '
				else:
					letter = replaces.get(letter, letter)

			text_new += letter

		return text_new

	def randomize(text, change_letters=False):
		# http://utf8-chartable.de/ - мега рандомизация
		''' {1|2|{a|b|c}} '''
		# обработка {||}, замена букв на латинские аналоги
		return hlp.rndmize(text, change_letters)

	def rndmize(text, change_letters=False):
		''' {1|2|{a|b|c}} '''
		# обработка {||}, замена букв на латинские аналоги

		elems = hlp.parse_all('{[^{}]+}', text, system=True)

		if elems is False:

			if change_letters:
				text = hlp.change_letters(text)

			return text

		changed = 0
		for elem in elems:
			if '|' not in elem:
				continue

			parts = elem.replace('{', '').replace('}', '').split('|')

			part = random.choice(parts)
			text = text.replace(elem, part)
			changed += 1

		if changed:
			return hlp.rndmize(text)
		else:
			return text

	def match(patt, body):
		if isinstance(patt, list):
			return any([hlp.match(p, body) for p in patt])
		else:
			return bool(re.findall(patt, body))

	# DEPRECATED use hlp.match
	def find(patt, body):
		return bool(re.findall(patt, body))

	def size_dir(dir_, human=False):

		files = hlp.ls(dir_)

		sz = 0
		for f in files:
			sz += os.path.getsize(f)

		if human:
			return hlp.human_size(sz)
		else:
			return sz

	def size(filename, human=False):
		''' return size of a file in bytes '''

		if not os.path.exists(filename):
			print('hlp.size error: file not found!')

		sz = os.path.getsize(filename)

		if human:
			return hlp.human_size(sz)
		else:
			return sz

	def timestamp_from_time(row, format_d='%d.%m.%y_%H:%M:%S'):
		# делает timestamp из "22.05.2014"

		obj = time.strptime(row.strip(), format_d)
		return int(time.mktime(obj))

	def human_time(sec, return_str=True, lang='сек,мин,ч,дней'):
		''' показать 213412 секунд как 15 ч. 12 м. 04 с. 
		English: lang='sec,min,h,days'
		'''

		res = ''
		m, s = divmod(sec, 60)
		h, m = divmod(m, 60)
		d, h = divmod(h, 24)

		s_str, m_str, h_str, d_str = lang.split(',')
		
		res = '{} {}.'.format(s, s_str)

		if m or h or d:
			res = '{} {}. '.format(m, m_str) + res

			if h or d:
				res = '{} {}. '.format(h, h_str) + res

				if d:
					res = '{} {} '.format(d, d_str) + res

		if return_str:
			return res
		else:
			return (d, h, m, s)
		# 0 дней 0 ч. 00 мин. 10 сек
		#~ return "" % (d, h, m, s)

	def human_size(num):
		for x in ['байт','кб','мб','гб','тб']:
			if num < 1024.0:
				return "%3.1f %s" % (num, x)
			num /= 1024.0

	def image_info(image):
		''' требует ImageMagick для работы '''

		image_name = image
		if not image.startswith('/') and not image.startswith('C:'):
			image = os.getcwd() + '/' + image

		out = hlp.execute('identify "{0}"'.format(image))

		if '#using-pathnames' in out:
			out = out.split('#using-pathnames')[1].strip()

		out = 'PATH ' + out.split(image_name)[1].strip()
		data = out.split(' ')

		info = {
			'full_path': image,
			'type': data[1],
			'width': data[2].split('x')[0],
			'height': data[2].split('x')[1],
			'size': data[6],
		}

		return info

	# @compact - добавляет в дефолтный формат перевод строки чтобы выводить время и дату в 2 строки
	def human_date(timestamp=False, format_d="%d.%m.%y %H:%M:%S", compact=False, locale_name='ru_RU.UTF-8'):
		
		#format_d = 'dict' -- return dictionary: {'day': 1, 'month': 28 ...}
		# 
		# http://docs.python.org/library/datetime.html#strftime-and-strptime-behavior
		import locale, time

		if timestamp is False:
			timestamp = time.time()

		try:
			timestamp = float(timestamp)
		except:
			print('hlp.human_date: invalid timestamp')
			return False

		if format_d == 'dict':
			compact = False
			
		if compact:
			format_d = format_d.replace('%y', '%y<br />')

		if not hlp.is_windows():
			try:
				locale.setlocale(locale.LC_TIME, locale_name)
			except:
				pass

		if timestamp is False:
			timestamp = time.time()

		from datetime import datetime
		d = datetime.fromtimestamp(timestamp)

		if format_d == 'dict':
			res = {
				'day': d.strftime('%d'),
				'month': d.strftime('%m'),
				'year': d.strftime('%y'),
				'hour': d.strftime('%H'),
				'minute': d.strftime('%M'),
				'second': d.strftime('%S'),
			}
			return res
		else:
			return d.strftime(format_d)

	def exec_background(cmd):

		if hlp.is_windows():
			cmd = 'START /B CMD /C CALL {0} >NUL 2>&1'.format(cmd)

		if hlp.exists('tmp'):
			out = 'tmp/background_errors'
		else:
			out = 'background_errors'
			
		subprocess.call(cmd.encode(), shell=True, stdout=None, stdin=None, stderr=open(out, 'wb'))

	def execute(command, silent=True, returnFull=False, cygwin_log=True, env={}, charset='utf-8'):

		#~ charset = 'utf-8'

		if hlp.is_windows():# and not command.startswith('tasklist'):

			#~ charset = '866' # костыль для хромого карлика виндовс

			cygwin_app = True
			not_cygwin_apps = ['tasklist', 'wget', 'phantomjs']
			for cyg in not_cygwin_apps:
				if command.startswith(cyg):
					cygwin_app = False

			if cygwin_app:
				# CYGWIN
				cywgin_log_path = 'cygwin.log'

				if hlp.exists('C:\\cygwin\\bin'):
					command = 'C:\\cygwin\\bin\\' + command
					#~ print('используем {}'.format(command))
				else:
					command = 'plugins\\cygwin\\bin\\' + command

				if os.getcwd().endswith('engine'):
					command = '..\\' + command
					cywgin_log_path = '..\\' + cywgin_log_path

				# check exe file
				exefile = command.split(' ', 1)[0]

				if not hlp.exists(exefile) and not hlp.exists(exefile + '.exe'):
					print('hlp.execute ERROR: {0} not found! cwd: {1}'.format(exefile, os.getcwd()))
					return False

				if 'chmod' in exefile:
					return ''

				#~ hlp.textarea(command)
				hlp.f_add(cywgin_log_path, command)

		environ = os.environ
		if env:
			environ.update(env)

		if silent:

			proc = subprocess.Popen(command.encode(), shell=True, stdout=subprocess.PIPE, stdin=None, stderr=subprocess.PIPE, env=environ)
			processes = proc.stdout.read()
			processes += proc.stderr.read()

			proc.stdout.close()
			proc.stderr.close()

			return processes.decode(charset, 'ignore')
		else:
			proc = subprocess.Popen(command.encode(), shell=True,
				stdout=subprocess.PIPE, stdin=None, stderr=subprocess.PIPE, env=environ)

		processes = b''
		while True:
			processes += proc.stdout.read(1024)
			processes += proc.stderr.read(1024)

			if proc.poll() is not None:
				break

		proc.stdout.close()
		proc.stderr.close()

		ps = processes.decode(charset, 'ignore').split('\n')

		ps = [row.strip() for row in ps if row.strip()]

		if returnFull:
			return '\n'.join(ps)

		if not ps:
			return []
		if len(ps) > 1:
			return ps
		else:
			return ps[0]

	def join(*args):
		args = [str(v) for v in args]
		return os.path.join(*args)

	def sub(what, to, body, count=0, ignore_case=False, multiline=True):
		'''
		меняет одно на другое, допуская регулярки
		@param what - регулярка "что менять"
		@param to - на что менять
		@param body - в чем меняем
		@example меняем : в прокси на | -- acc = hlp.sub(r'([0-9]+\.[0-9]+\.[0-9]+\.[0-9]+):([0-9]+)', r'\1|\2', 'text:111.111.111.1:255:text')
		@return результаты / False
		'''

		flags = 0
		if ignore_case:
			flags |= re.IGNORECASE

		if multiline:
			flags |= re.MULTILINE

		res = re.sub(what, to, body, count=count, flags=flags)
		return res

	def pwd(show=False):
		'''
		возвращает путь к текущему руту скрипта
		@bool show - вывести путь принтом
		@return str путь (без слеша в конце)
		'''

		path = os.getcwd()

		if show:
			print('PWD: ' + path)

		return path

	def check_imagemagick():
		'''
		проверяет наличие imagemagick
		@return true/false
		'''

		if hlp.is_windows():

			if not hlp.exists('plugins/cygwin/bin/convert.exe'):
				return False

			if not hlp.exists('plugins/cygwin/bin/identify.exe'):
				return False

		else:
			output = hlp.execute('convert -version')
			if 'ImageMagick' not in output:
				return False

			output = hlp.execute('identify -version')
			if 'ImageMagick' not in output:
				return False

		return True

	def cgi_escape(string):
		# переводит '<' в '&lt;'
		return cgi.escape(string)

	def cgi_unescape(string):
		"""back replace html-safe sequences to special characters
			>>> unescape('&lt; &amp; &gt;')
			'< & >'
			>>> unescape('&#39;')
			"'"
			>>> unescape('&#x27;')
			"'"

		full list of sequences: htmlentitydefs.entitydefs
		"""

		def _char_unescape(m, defs=html.entities.entitydefs):
			try:
				return defs[m.group(1)]
			except KeyError:
				return m.group(0)

		_char = re.compile(r'&(\w+?);')
		_dec  = re.compile(r'&#(\d{2,4});')
		_hex  = re.compile(r'&#x(\d{2,4});')

		result = _hex.sub(lambda x: chr(int(x.group(1), 16)),\
			_dec.sub(lambda x: chr(int(x.group(1))),\
				_char.sub(_char_unescape, string)))
		if string.__class__ != str:
			return result.encode('utf-8')
		else:
			return result

	def is_local_ip(address):
		'''
		возвращает True, если адрес из локальной сети
		'''

		if 'localhost' in address.lower():
			return True

		if re.search(r'(10\.\d+\.\d+\.\d+)$', address) != None:
			return True

		if re.search(r'(192\.168\.\d+\.\d+)$', address) != None:
			return True

		if re.search(r'(127\.\d+\.\d+\.\d+)$', address) != None:
			return True

		if re.search(r'(172\.(16|17|18|19|20|21|22|23|24|25|26|27|28|29|30|31)\.\d+\.\d+)$', address) != None:
			return True

		return False

	def check_pid(pid, check_text=''):
		'''
		проверяет, запущен ли процесс по его PID
		@param int/str pid - PID процесса
		@return bool
		'''

		if not hlp.is_windows() and not hlp.is_bsd():
			if hlp.exists('/proc/{}'.format(pid)):
				name = hlp.f_read('/proc/{}/cmdline'.format(pid))
				if check_text and check_text not in name:
					return False

				return True

			return False

		if hlp.is_windows():
			try:
				from helper_class import hlp_win
				if hlp_win.is_running(pid):
					return True
				else:
					return False
			except:
				cmd = 'tasklist /fi "PID eq {0}"'.format(pid)

			res = hlp.execute(cmd, silent=True, returnFull=True, cygwin_log=False)
		else:
			cmd = 'ps {0}'.format(pid)
			res = hlp.execute(cmd, silent=True, returnFull=True)

			if check_text and check_text not in res:
				return False

		if str(pid) in res and 'id too large' not in res:
			return True
		else:
			return False

	def word_end(num, male=True):
		# выдает концовку для слова "тест, тестОВ"
		# num - число
		# male - мужской род слова
		#~ 1 акк
		#~ 2 3 4 акка
		#~ 5 6 7 8 9 10 ов
		#~ 1 курица
		#~ 2 3 4 курицы
		#~ 5-10 куриц

		last_letter = str(num)[-1]
		if male:
			if last_letter == '1' and num < 10:
				return ''
			elif last_letter in ['2', '3', '4']:
				return 'а'
			else:
				return 'ов'
		else:
			if last_letter == '1' and num < 10:
				return 'а'
			elif last_letter in ['2', '3', '4']:
				return 'ы'
			else:
				return ''

	def check_inet():
		import socket
		try:
			socket.gethostbyname('google.com')
		except:
			return False
		return True

def makeStart(project='', module='', config=''):

	#~ import pdb; pdb.set_trace()

	import xmlrpc.client
	port = 0
	if not hlp.exists('tmp/fr_access.txt'):
		hlp.execute('./frd start', silent=False)
		hlp.slp_simple(1)

	with open('tmp/fr_access.txt', 'r') as f:
		port = f.read()

	try:
		proxy = xmlrpc.client.ServerProxy("http://localhost:{}/".format(port))
		hlp.slp_simple(1)
	except Exception as e:
		#~ print(e)
		hlp.execute('./frd start')
		hlp.slp_simple(1)
		with open('tmp/fr_access.txt', 'r') as f:
			port = f.read()
		proxy = xmlrpc.client.ServerProxy("http://localhost:{}/".format(port))
		hlp.slp_simple(1)

	try:
		proxy.start(project, module, config)
	except xmlrpc.client.Fault as e:
		#~ print(str(e))
		return
	except ConnectionRefusedError as e:
		hlp.execute('./frd start')
		hlp.slp_simple(1)
		return makeStart(project, module, config)
	except Exception as e:
		#~ print(str(e))
		return makeStart(project, module, config)


print = hlp.print
