# headers - http://www.w3.org/Protocols/rfc2616/rfc2616-sec14.html
import time, os, re, itertools, zlib, sys, traceback, urllib, urllib.request, http.cookiejar, gzip, ssl
from base64 import b64encode
from decimal import *

from http.client import HTTPConnection
from urllib.request import urlopen, URLError, HTTPError, HTTPRedirectHandler, HTTPSHandler
from urllib.parse import urlencode

os.sys.path.insert(0, 'engine')
import SocksHandler as SocksHandler
from socks import PROXY_TYPE_SOCKS4, PROXY_TYPE_SOCKS5, PROXY_TYPE_HTTP, Socks5Error
from helper_class import *

#~ Request.get_host() убрали в 3.4 вместо этого Request.host
#~ Request.get_type() убрали в 3.4 вместо этого Request.type

class RelativeRedirectHandler(urllib.request.HTTPRedirectHandler):

	def __init__(self, http='', url=''):
		if http and url:
			self.http = http
			self.http.redir_list = [url]

	def http_error_302(self, req, fp, code, msg, headers):

		if hasattr(self, 'http'):

			#~ cur_host = req.get_host() deprecated in 3.4
			cur_host = req.host
			cur_proxy = self.http.get_proxy()

			# если хост совпадает с прокси - не меняем редиректы
			if cur_host == cur_proxy:
				return urllib.request.HTTPRedirectHandler.http_error_302(self, req, fp, code, msg, headers)
		
		newurl = False
		
		if "location" in headers or "Location" in headers:			
			# headers["Location"] -- test.php, http://sfdsfdsf/, /root.php
			
			if not headers["Location"].startswith('http'):
				
				if headers["Location"].startswith('/'): # ако слање jе апсолутно
					newurl = "{}://{}{}".format(req.type, req.host, headers["Location"])
					#~ hlp.textarea(newurl)
				else:
					urlstrip = req.get_full_url().rsplit('/', 1)[0]
					newurl = "{}/{}".format(urlstrip, headers["Location"])
					#~ hlp.textarea(newurl)
					
				headers.replace_header('location', newurl)
				headers.replace_header('Location', newurl)
				
		elif "uri" in headers:
			headers.replace_header('uri', urllib.request.urljoin("{0}://{1}/".format(req.type, req.host), headers["uri"]))
			newurl = headers['uri']
		else:
			return
		
		if hasattr(self, 'http'):
			if newurl is not False:
				self.http.redir_list.append(newurl)

			for key, value in headers.items():
				if key == 'Set-Cookie':
					value = value.strip()
					cookie_name = hlp.parse(r'^([^=]+)', value, system=True)
					if not cookie_name:
						continue

					cookie_value = hlp.parse(cookie_name + r'=([^;]+)', value, system=True)
					if not cookie_value:
						cookie_value = ''

					cookie_domain = hlp.parse(r'domain=([-0-9a-zA-Z._]+)', value, system=True)
					if not cookie_domain:
						cookie_domain = ''

					self.http.add_cookie(cookie_name, cookie_value, cookie_domain)

		return urllib.request.HTTPRedirectHandler.http_error_302(self, req, fp, code, msg, headers)

	http_error_301 = http_error_303 = http_error_307 = http_error_302

import http
class HTTPSClientAuthHandler(HTTPSHandler):

	def __init__(self, key, cert):
		HTTPSHandler.__init__(self)
		self.key = key
		self.cert = cert

	def https_open(self, req):
		return self.do_open(self.getConnection, req)

	def getConnection(self, host, timeout=30):
		return http.client.HTTPSConnection(host, key_file=self.key, cert_file=self.cert)

class httpClass():

	HTTP = 0
	SOCKS5 = 1
	HTTPS = 2
	AUTO = 3

	def __init__(self, parent=False, debug=False, tid=None, default_charset='utf-8', log=False, no_proxy=False):
		''' инициализация urllib '''

		# перенес всё в конструктор для надежного обнуления и худобы таксисток да хромого разносчика

		self.debug_mode = False
		self.proxy_enabled = False
		
		if parent.cnf.getbool('proxy'):
			self.proxy_enabled = True

		''' request data '''
		self.url = ''
		self.post_data = b''
		self.cookie_jar = ''
		self.headers = {}
		self.last_headers = {} # хидеры ответа
		self.timeout = None

		if parent and parent.cnf.chk('proxy_repeat_req_tries'):
			self.change_proxy_limit = parent.cnf.getnum('proxy_repeat_req_tries')
		else:
			self.change_proxy_limit = 5

		self.redir_list = []
		self.redirs_time = 0
		self.redirs_time = 0
		self.show_post_debug = False # показывать post-данные при postfile() запросе
		self.no_proxy = no_proxy

		self.headers_default = {
			'User-Agent': 'Mozilla/5.0 (Windows; U; Windows NT 5.1; en; rv:1.9.1.3) Gecko/20190824 Firefox/3.5.3',
			'Accept': 'text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8',
			'Accept-Language': 'en-us,en;q=0.5',
			'Accept-Charset': 'utf-8;q=0.7,*;q=0.7',
			'Connection': 'keep-alive',
		#'Content-Length': 200,
		#'Content-type': 'multipart/form-data',
		}
		self.referer = None
		self.response = '' # ответ сервера
		#~ disableGzip = True

		''' cert '''
		self.cert_file = ''
		self.cert_key = ''

		''' proxy '''
		self.__proxy = ''
		self.proxy_port = ''
		self.proxy_type = 1 # 0-http, 1-socks5, 2-https, 3-auto (только для чека)

		''' cut '''
		self.cutMarker1 = ''
		self.cutMarker2 = ''

		''' last '''
		self.last_url = '' # последний урл куда перешел софт по всем редиректам
		self.last_error = '' # последняя http-ошибка, типа '404 not found'
		self.last_error_filename = '' # последний сохраненный файл дебага, типа debug/rgtrerytrer.html
		self.last_headers = {} # все полученные в ответ от запроса хидеры
		self.redirect_location = '' # в случае если есть хидер Redirect-Location - автоперехода не будет, но можно получить урл через это св-во
		self.allowed_redirects = ['_i_loc_rdr=on'] # признаки редиректов, по которым можно перейти
		self.redirs_num = 0

		self.task = None # инфа для сохранения в дебаг, например акк потока

		# Опера исключена потому что говносайты типа майкрософтовского бинга или Яхуй пишут что это неподдерживаемый браузер
		#
		''''Opera/12.80 (Windows NT 5.1; U; en) Presto/2.10.289 Version/12.02',
	'Opera/9.80 (Windows NT 6.1; U; es-ES) Presto/2.9.181 Version/12.00',
	'Opera/9.80 (Windows NT 5.1; U; zh-sg) Presto/2.9.181 Version/12.00',
	'Opera/12.0(Windows NT 5.2;U;en)Presto/22.9.168 Version/12.00',
	'Opera/12.0(Windows NT 5.1;U;en)Presto/22.9.168 Version/12.00',
	'Mozilla/5.0 (Windows NT 5.1) Gecko/20100101 Firefox/14.0 Opera/12.0',
	'Opera/9.80 (Windows NT 6.1; WOW64; U; pt) Presto/2.10.229 Version/11.62',
	'Opera/9.80 (Windows NT 6.0; U; pl) Presto/2.10.229 Version/11.62',
	'Opera/9.80 (Macintosh; Intel Mac OS X 10.6.8; U; fr) Presto/2.9.168 Version/11.52',
	'Opera/9.80 (Macintosh; Intel Mac OS X 10.6.8; U; de) Presto/2.9.168 Version/11.52',
		'''

		if 'engine' in os.getcwd() or hlp.exists('useragents.txt'):
			ua = 'useragents.txt'
		else:
			ua = hlp.join('engine', 'useragents.txt')

		if not hlp.exists(ua):
			rows = []
			for i in range(10):
				i
				rows.append(self.ua_generator())
		else:
			rows = hlp.f_read(ua, to_list=True)
			rows = [r for r in hlp.f_read(ua, to_list=True) if not r.startswith('#')]

		if parent and not hasattr(parent, 'http_uas'):
			self.uas = parent.http_uas = rows

		elif parent and hasattr(parent, 'http_uas'):
			self.uas = parent.http_uas
		else:
			self.uas = rows

		self.muas = ['MOT-AF/0.0.22 UP/4.0.5n', 'MobileExplorer/3.00 (Mozilla/1.22; compatible; MMEF300; Microsoft; Windows; GenericLarge)', 'EricssonR320/R1A', 'Alcatel-BF5/1.0 UP.Browser/5.0.3.1', 'Nokia6210/1.0 (03.01)', 'SAMSUNG-SGH-Q100/1.0 UP/4.1.19k', 'WinWAP 3.0 PRO']

		self.session_ua = None
		self.break_on_proxyerror = False # не пытаться подобрать новую прокси, если запрос с прокси не удался

		# basic authorisation
		self.basic_auth = False # basic-авторизация на страницу. авторизация для прокси при этом идёт лесом =\
		self.basic_auth_user = ''
		self.basic_auth_passw = ''

		self.with_ajax = False # отправлять ajax-заголовки

		self.cookies_disabled = False # разовое отключение кукис методом with_no_cookies()
		self.headers_last = {} # системное

		# отсюда начинался init 06/07/13

		if parent is False:
			parent = hlp.parent_doll()

		self.default_charset = default_charset
		self.tid = tid
		self.cookie_jar = http.cookiejar.CookieJar()

		if log:
			self.log_orig = log
		else:
			self.log_orig = parent.log

		self.parent = parent

		if debug:
			self.debug_mode = True

		if self.parent.cnf.getbool('debug'):
			HTTPConnection.debuglevel = 2

		self.headers = self.headers_default.copy()

		new_ua = hlp.rand(self.uas)
		if new_ua == 'AUTO_UA':
			new_ua = self.ua_generator()
			#~ self.log('создали юзерагент <b>{}</b>'.format(new_ua))

		self.session_ua = new_ua

		self.mime_types = {
'js': 'text/javascript', 'gif': 'image/gif', 'jpeg': 'image/jpeg', 'jpe': 'image/jpg', 'jpg': 'image/jpeg', 'bmp': 'image/x-ms-bmp', 'css': 'text/css', 'htm': 'text/html', 'html': 'text/html', 'shtml': 'text/html', 'txt': 'text/plain', 'xml': 'text/xml', 'xht': 'application/xhtml+xml', 'xhtm': 'application/xhtml+xml', 'xhtml': 'application/xhtml+xml', 'rss': 'application/rss+xml', 'atom': 'application/atom+xml', 'xslt': 'application/xslt+xml', 'rdf': 'application/rdf+xml', 'wml': 'application/wml+xml', 'svg': 'image/svg+xml', 'svgz': 'image/svg+xml', 'ico': 'image/x-icon', 'png': 'image/png', 'wav': 'audio/wav', 'wav': 'audio/x-wav', 'avi': 'video/x-msvideo', 'mpeg': 'video/mpeg', 'mpg': 'video/mpeg', 'mpe': 'video/mpeg', 'm2v': 'video/mpeg', 'm1v': 'video/mpeg', 'mpa': 'video/mpeg', 'mp4': 'video/mp4', 'mpg4': 'video/mp4', 'ogg': 'application/ogg', 'mp3': 'audio/mp3', 'ttf': 'application/x-font-ttf', 'ttc': 'application/x-font-ttf', 'z': 'application/x-compress', 'gz': 'application/x-gzip', 'gzip': 'application/x-gzip', 'tgz': 'application/x-gzip', 'bz2': 'application/bzip2', 'tbz': 'application/bzip2', 'tbz2': 'application/bzip2', 'lzma': 'application/x-lzma', 'tlz': 'application/x-lzma', 'tlzma': 'application/x-lzma', 'xz': 'application/x-xz', 'txz': 'application/x-xz', 'tar': 'application/x-tar', 'tgz': 'application/x-tar', 'gz': 'application/x-tar', 'tbz': 'application/x-tar', 'tbz2': 'application/x-tar', 'bz2': 'application/x-tar', 'tlz': 'application/x-tar', 'tlzma': 'application/x-tar', 'lzma': 'application/x-tar', 'txz': 'application/x-tar', 'xz': 'application/x-tar', 'rpm': 'application/x-rpm', 'pdf': 'application/pdf', 'tif': 'image/tiff', 'tiff': 'image/tiff', 'exe': 'application/x-msdownload', 'dll': 'application/x-msdownload', 'bat': 'application/x-msdownload', 'pif': 'application/x-msdownload', 'com': 'application/x-msdownload', 'scr': 'application/x-msdownload', 'msi': 'application/x-msdownload', 'url': 'application/internet-shortcut', 'zip': 'application/x-zip-compressed', 'rar': 'application/x-rar-compressed', 'doc': 'application/msword', 'dot': 'application/msword', 'wiz': 'application/msword', 'wzs': 'application/msword', 'docx': 'application/msword', 'rtf': 'application/rtf', 'rtx': 'text/richtext', 'xls': 'application/vnd.ms-excel', 'xl': 'application/vnd.ms-excel', 'xla': 'application/vnd.ms-excel', 'xlb': 'application/vnd.ms-excel', 'xlc': 'application/vnd.ms-excel', 'xld': 'application/vnd.ms-excel', 'xlk': 'application/vnd.ms-excel', 'xll': 'application/vnd.ms-excel', 'xlm': 'application/vnd.ms-excel', 'xlt': 'application/vnd.ms-excel', 'xlv': 'application/vnd.ms-excel', 'xlw': 'application/vnd.ms-excel', 'csv': 'application/vnd.ms-excel', 'xlsx': 'application/vnd.ms-excel', 'xltx': 'application/vnd.ms-excel', 'pot': 'application/vnd.ms-powerpoint', 'ppa': 'application/vnd.ms-powerpoint', 'pps': 'application/vnd.ms-powerpoint', 'ppt': 'application/vnd.ms-powerpoint', 'pwz': 'application/vnd.ms-powerpoint', 'pptx': 'application/vnd.ms-powerpoint', 'ppsx': 'application/vnd.ms-powerpoint', 'potx': 'application/vnd.ms-powerpoint', 'sldx': 'application/vnd.ms-powerpoint', 'wma': 'audio/x-ms-wma', 'wmv': 'video/x-ms-wmv', 'wmx': 'video/x-ms-wmv', '3gp': 'video/3gpp', 'flac': 'audio/flac', 'php': 'application/x-php', 'py': 'application/x-python', 'pyc': 'application/x-python', 'pyw': 'application/x-python'}

	def ua_generator(self):
		# генерит юзерагенты хрома
		os  = hlp.rand(['Windows NT 5.0', 'Windows NT 5.1', 'Windows NT 5.2', 'Windows NT 6.0', 'Windows NT 6.1', 'Windows NT 6.2', 'Windows NT 6.3',])

		webkit = hlp.rand(500, 599)
		ver_webkit = hlp.rand(1, 36)
		version = '{}.0.{}.{}'.format(hlp.rand(23, 35), hlp.rand(690, 1667), hlp.rand(0, 100))
		token = '; x64' if hlp.rand(0, 1) else ''
		token += '; WOW64' if hlp.rand(0, 1) else ''

		ua = 'Mozilla/5.0 ({}{}) AppleWebKit/{}.{} (KHTML, like Gecko) Chrome/{} Safari/{}.{}'.format(os, token, webkit, ver_webkit, version, webkit, ver_webkit)

		# v2 
		#~ win_ver = random.randint(1, 2)
		#~ rv = random.randint(6, 9)
		#~ wow = 'WOW64; ' if (random.randint(0, 1)) else ''
		#~ geck = '0{}0{}'.format(random.randint(1, 9), random.randint(1, 9))
		#~ ff = random.randint(5, 9)
		#~ ua = 'Mozilla/5.0 (Windows NT 6.{}; {}rv:3{}.0) Gecko/2010{} Firefox/3{}.0'.format(win_ver, wow, rv, geck, ff)
		
		return ua

	def log(self, t, ctype='&nbsp;&nbsp;', tid=None, hide=False):
		self.log_orig(t, ctype, tid=self.tid)

	# callbacks
	def callback_get_before(self):
		pass

	def callback_get_after(self, page=''):
		pass

	def callback_post_before(self):
		pass

	def callback_post_after(self, page=''):
		pass

	def callback_postfile_before(self):
		pass

	def callback_postfile_after(self, page=''):
		pass

	def callback_getfile_before(self):
		pass

	def callback_getfile_after(self, page=''):
		pass


	def set_post_callback(self, func, targets=None):
		'''
		функция func будет вызываться после работы функций, перечисленных
		в targets (по дефолту - self.__post_callback_for = ['get', 'getfile', 'post', 'postfile'])

		Коллбек вызывается с параметрами url, data - ссылка на страницу и её содержимое

		@param callback func - функция в либе
		@param list str targets - функции
		@return None
		'''

		self.__post_callback = func

		if targets:
			self.__post_callback_for = targets

	def load_certificate(self, cert, key=''):

		if key == '':
			key = cert

		self.cert_file = cert
		self.cert_key = key

	def load_cookies(self, string, domain=''):
		'''
		loading cookies from string in format "cook1=val1; cook2=val2"
		@param
		@return
		'''
		for c in string.strip().split(';'):
			if c.strip() == '' or c.strip() == ';':
				continue

			try:
				k, v = c.strip().split('=', 1)
			except Exception as ex:
				self.log('кривая строка кукис <b>{0}</b>; {0}'.format(c, ex))
				continue

			self.add_cookie(k.strip(), v.strip(), domain=domain)
		return self

	def with_no_cookies(self):
		# выполнить запрос без кукис
		self.cookies_disabled = True
		return self

	def clear_cookies(self):
		self.cookie_jar = http.cookiejar.CookieJar()
		return self

	def _get_redirs(self):
		''' показывает все редиректы по которым прошел урллиб '''

		self.redirs_num = len(self.redir_list)-2
		self.redirs_time = self.redir_list[-1][:6]

		redirs = 'redirs total: <b>{0}, {1}</b> sec<br />'.format(self.redirs_num, self.redirs_time)
		redirs_text = 'redirs total: {0}, {1} sec\n'.format(self.redirs_num, self.redirs_time)

		self.redir_list.pop()
		redirs += '- ' + '<br />- '.join(self.redir_list)
		redirs_text += '- ' + '\n- '.join(self.redir_list)

		self.log(redirs, '%')

		return redirs_text

	def set_ua(self, ua):
		self.session_ua = ua
		return self

	def add_cookie(self, name, value, domain=''):

		c = http.cookiejar.Cookie(version=0, name=str(name), value=str(value), port=None, port_specified=False, domain=domain, domain_specified=False, domain_initial_dot=False, path='/', path_specified=True, secure=False, expires=None, discard=True, comment=None, comment_url=None, rest={'HttpOnly': None}, rfc2109=False)

		self.cookie_jar.set_cookie(c)
		return self

	def delete_cookie(self, name):
		try:
			self.cookie_jar.clear('', '/', name)
		except KeyError:
			return False

	def get_cookie_dict(self):
		'''
		возвращает все куки в виде словаря
		@param
		@return dict куки
		'''

		res = {}
		for cookie in self.cookie_jar:
			res[cookie.name] = cookie.value

		return res

	def get_cookies(self):
		'''
		возвращает все куки в виде строки
		@param
		@return str куки или значение
		'''
		return self.get_cookie()

	# Использование для получения ВСЕХ кук сразу - DEPRECATED
	# юзайте get_cookieS()
	def get_cookie(self, name=''):
		'''
		возвращает все куки (или значение одной с именем name) в виде строки
		@param
		@return str куки или значение
		'''

		if not name:
			res = ''
			for cookie in self.cookie_jar:
				res += '{0}={1}; '.format(cookie.name, cookie.value)

			return res

		for cookie in self.cookie_jar:
			if cookie.name == name:
				return cookie.value

		return False

	def ref(self, url):
		if not url.strip():
			self.log('http ref is empty'.format(self.tid), '!')
			return self

		self.referer = url
		return self

	def add_headers(self, newDict):
		''' update headers with newDict - {'new header': 'new value'} '''
		self.headers.update(newDict)
		return self

	def ajax(self):
		self.with_ajax = True
		#self.headers['X-Prototype-Version'] = '1.6.0.3'
		return self

	# DEPRECATED. Use hlp.quote_url()
	def _quote_url(self, url):
		# кириллица в урле -> %20
		cyr_parts = hlp.parse_all(r'([а-яА-ЯёЁ]+)', url, system=True)
		if not cyr_parts:
			return url

		for cyr_part in cyr_parts:
			url = url.replace(cyr_part, hlp.quote(cyr_part))

		return url

	def get(self, url, fname='', readlimit=None):
		''' fname - имя для файла дебага '''

		if isinstance(fname, dict):
			return ''

		self.post_data = b''
		self.url = url

		self.callback_get_before()
		self._exec(fname=fname, readlimit=readlimit)
		res = self.callback_get_after(self.response)
		if res == 'repeat_request':
			self.log('повторяем запрос на <b>{}</b>'.format(url))
			return self.get(url, fname, readlimit)

		if not isinstance(self.response, str):
			return str(self.response)
			
		return self.response

	def options(self, url, fname='', readlimit=None):

		self.post_data = b''
		self.url = url
		self._exec(fname=fname, readlimit=readlimit, request_method='OPTIONS')
		return self.response

	def getsize(self, url):

		self.url = url
		return self._exec(decode=True, is_post_with_file=False, saveDebug=True, readlimit=None, getsize=True)

	def getfile(self, url, filename='', readlimit=None, returnFileBody=False, postdata=False):
		'''
		скачивает файл get или post-методом
		@param url - ссылка на файл
		@param filename - имя для сохранения. Оставьте пустым чтобы сохранять тем именем, которое файл имеет на сервере
		@param readlimit - читать первые N байт файла
		@param returnFileBody - не сохранять в файл, а вернуть скачанное содержимое в виде ответа data = self.http.getfile()
		@param postdata - POST-данные, строка или словарь, если требуется post-запрос на скачивание
		@return true/false
		'''

		self.post_data = b''

		# данные для POST-запроса
		if postdata:
			if isinstance(postdata, dict):
				postdata = urlencode(postdata)

			self.post_data = postdata

		self.url = url
		self.callback_getfile_before()
		self._exec(decode=False, saveDebug=False, readlimit=readlimit)
		res = self.callback_getfile_after(self.response)
		if res == 'repeat_request':
			self.log('повторяем запрос на <b>{}</b>'.format(url))
			return self.getfile(url, filename, readlimit, returnFileBody, postdata)

		#~ if not len(self.response):
			#~ self.last_error = 'getfile: пустой ответ сервера: '.format(url)
			#~ self.log(self.last_error, '!', tid=self.tid)
			#~ return False

		if returnFileBody:
			return self.response
		
		try:
			if isinstance(self.response, str):
				data = self.response.encode('utf-8', 'ignore')
			else:
				data = self.response
				
			with open(filename, 'wb') as fp:
				fp.write(data)
				os.chmod(filename, 0o777)

		except Exception as ex:

			self.last_error = 'не могу сохранить файл {0}: {1}'.format(filename, ex)
			self.log(self.last_error, '!', tid=self.tid)
			return False

		return True

	def put(self, url, data):

		if not data:
			data = '1=1'

		if isinstance(data, dict):
			data = urlencode(data)

		self.post_data = data
		self.url = url

		self._exec(request_method='PUT')
		return self.response


	def post(self, url, data, fname='', readlimit=None, is_json=False, data_encoding=None):
		''' fname - имя для файла дебага '''
		self.post_data = b''

		if is_json or isinstance(data, str) and data.startswith('{') and data.endswith('}'):
			self.log('добавляем заголовок json-поста')
			self.add_headers({'Content-Type': 'application/json; charset=UTF-8'})

		if not data:
			data = '1=1'

		if isinstance(data, dict):

			# macroses
			#~ for key, val in data.items():
				#~ if isinstance(val, str) and val.startswith('AS_'):
					#~ data[key] = hlp.password(src=val)

			data = urlencode(data, encoding=data_encoding)

		self.post_data = data

		self.url = url
		self.callback_post_before()
		self._exec(fname=fname, readlimit=readlimit)
		res = self.callback_post_after(self.response)
		if res == 'repeat_request':
			self.log('повторяем запрос на <b>{}</b>'.format(url))
			return self.post(url, data, fname, readlimit, is_json, data_encoding)

		if not isinstance(self.response, str):
			return str(self.response)
			
		return self.response

	def get_file_type(self, ext):
		''' get mime-filetype from ext '''

		if ext in self.mime_types:
			return self.mime_types[ext]
		else:
			return 'application/octet-stream'

	def postfile(self, url, data):

		# файлы должны иметь filename="", а текстовые поля нет
		# однако, например в ВК есть форма где заливаются 3 фотки
		# и если мы укажем одну фотку, то другие два поля (photo2, photo3) - все равно должны иметь "filename="""
		# потому что предназначены для приема файлов, иначе там будет Bad request
		# а WSO-шелл наоборот слишком придирчив - если текстовое поле приходит с лишним filename="" -- он не работает
		# поэтому пустые поля для файлов должны все равно быть равны '@'

		# пример:
		# data = {'text_field': '', 'file_field': '@file/path', 'empty_file_field': '@'}


		# кастомные имена для файлов
		# пример:
		# data = {
		# 'f': ['@/var/www/file.php', 'new_ftp_name.php']
		# }
		# - файл будет прочитан из /var/www/file.php, но залит с именем new_ftp_name.php
		cdata = data.copy()
		data = {}
		custom_names = {}

		for key, val in cdata.items():
			if isinstance(val, list):
				data[key] = val[0]
				custom_names[key] = val[1]
			else:
				data[key] = val


		self.post_data = b''
		form_fields = []
		files = []
		boundary = '-----------------------------{}'.format(hlp.password(28))

		for name, value in data.items():
			# if file
			value = str(value)

			if value == '@': # пустое поле для файла

				files.append((name, '', 'application/octet-stream', b''))

			elif value.startswith('@'): # поле с файлом

				value = value[1:]
				body = ''
				with open(value, 'rb') as imageHnd:
					body = imageHnd.read()

				ext = hlp.parse('\.([a-z0-9]+)', value.lower())
				if ext is False:
					type_ = 'text/plain'
				else:
					type_ = self.get_file_type(ext)

				files.append((name, value, type_, body))

			else: # текстовое поле
				form_fields.append((name, value))

		#create post-data
		parts = []
		part_boundary = '--' + boundary

		# Add the form fields # filename="" UPD: убрал ; для заливки в ЛП
		parts.extend(		
		[part_boundary, 'Content-Disposition: form-data; name="{}"'.format(name), '', value,]
			for name, value in form_fields )

		# Add the files to upload
		parts2 = [
			[ bytes(part_boundary,'utf8'),
			  bytes('Content-Disposition: form-data; name="%s"; filename="%s"' % \
				 (field_name, os.path.basename(filename) if field_name not in custom_names else custom_names[field_name]),'utf8'),
			  bytes('Content-Type: %s' % content_type, 'utf8'),
			  b'',
			  body,
			]
			for field_name, filename, content_type, body in files
			]

		# Flatten the list and add closing boundary marker,
		# then return CR+LF separated data
		flattened = list(itertools.chain(*parts))
		flattened = [bytes(row, 'utf8') for row in flattened]
		flattened.extend(list(itertools.chain(*parts2)))
		flattened.append(b'--' + bytes(boundary, 'utf8') + b'--')
		flattened.append(b'')
		self.post_data = b'\r\n'.join(flattened)

		self.content_type = 'multipart/form-data; boundary=%s' % boundary

		self.url = url
		self.callback_postfile_before()
		self._exec(is_post_with_file=True)
		res = self.callback_postfile_after(self.response)
		if res == 'repeat_request':
			self.log('повторяем запрос на <b>{}</b>'.format(url))
			return self.postfile(url, data)

		if not isinstance(self.response, str):
			return str(self.response)
			
		return self.response

	def get_proxy(self):

		if self.__proxy.strip() == '':
			return ''

		return '{0}:{1}'.format(self.__proxy, self.proxy_port)

	def _force_socks_check(self):
		# True - работать, False - нет

		if not hlp.exists('res'):
			return True
					
		if self.no_proxy:
			return True
			
		if not hlp.exists('res/FORCE_SOCKS'):
			return True
			
		if self.__proxy.strip():
			return True
			
		self_ips = hlp.f_readlist('res/FORCE_SOCKS')
		for ip in self_ips:
			if '://{}'.format(ip) in self.url:
				return True
		
		err = '{} попытка запроса на {} без сокса'.format(hlp.human_date(), self.url)
		self.log(err, '!')
		hlp.f_add('tmp/EXCEPTION', err, create=True)
				
		return False
						
	def clear_proxy(self):
		''' удаляет прокси '''
		self.__proxy = self.proxy_port = ''
		return self

	def set_proxy(self, proxy, proxyType=1, proxyPort=''):
		# 0|http 1|socks5 2|https 3|auto

		if ':' not in proxy and proxyPort == '':
			self.log(('http set_proxy: неправильный формат прокси: ', proxy), '!', tid=self.tid)
			return self

		if proxyPort != '':
			self.__proxy, self.proxy_port = proxy, proxyPort
		else:
			self.__proxy, self.proxy_port = proxy.strip().rsplit(':', 1)

		self.proxy_port = int(self.proxy_port)
		self.proxy_type = int(proxyType)
		
		self.proxy_enabled = True
		
		return self

	def cut(self, mark1, mark2=''):
		''' set cut rules '''
		self.cutMarker1 = mark1
		self.cutMarker2 = mark2
		return self

	def base_auth_reset(self):
		# удаляет бейсик-авторизацию
		self.basic_auth = False
		self.basic_auth_user = ''
		self.basic_auth_passw = ''
		return self

	def base_auth(self, login, passw):
		# ставит бейсик-авторизацию перманентно. такая авторизация затирает авторизацию на прокси
		self.basic_auth = True
		self.basic_auth_user = login
		self.basic_auth_passw = passw
		return self

	def _exec(self, decode=True, is_post_with_file=False, saveDebug=True, fname='', readlimit=None, getsize=False, changeproxy=0, request_method=None, repeat_with_the_same_proxy=True):
		''' make request '''

		self.headers_last = {}
		self.headers['User-Agent'] = self.session_ua

		sent_cookies = self.get_cookie()

		if not changeproxy:
			changeproxy = 1
		else:
			changeproxy += 1

		if changeproxy > self.change_proxy_limit:
			self.log('change proxy limit exceed'.format(self.tid))
			self.http_error = 'change proxy limit exceed'
			return False

		# cleanup
		self.response = ''
		self.last_error = ''

		self.url = self._quote_url(self.url)

		if self.url.startswith('www.'):
			url = 'http://' + self.url
		else:
			url = self.url

		request = urllib.request.Request(url)

		if request_method:
			request.get_method = lambda : request_method

		#~ if decode and readlimit == None and not self.disableGzip:
			#~ request.add_header('Accept-Encoding', 'gzip, x-gzip, deflate') # for GZIP
			#~ self.headers['Accept-Encoding'] = 'gzip, x-gzip, deflate'

		# реф по дефолту None
		# если он есть - ставим его в хидеры и обнуляем, чтобы он ставился только 1 раз
		# если его нет, но указан last_url (на который переходили последний раз) - ставим как реф его
		if self.referer:
			request.add_header('Referer', self.referer)
			self.headers['Referer'] = self.referer
			if not self.with_ajax:
				self.referer = self.url

		elif self.last_url:
			#self.log('ставим деф.реф ' + self.last_url, tid=self.tid)
			request.add_header('Referer', self.last_url)
			self.headers['Referer'] = self.last_url
		else:
			if not self.with_ajax:
				self.referer = url

		# разовое отключение кукис
		cookies_was_disabled = False # флаг чтобы в дебаг-файл не записались отключенные куки
		if self.cookies_disabled:
			hnds = []
			self.cookies_disabled = False
			cookies_was_disabled = True
		else:
			hnds = [urllib.request.HTTPCookieProcessor(self.cookie_jar)]

		if self.cert_file:
			hnds.append(HTTPSClientAuthHandler(self.cert_key, self.cert_file))

		hnds.append(RelativeRedirectHandler(self, url))

		for header, content in self.headers.items():
			if header == 'X-Requested-With':
				continue
			request.add_header(header, content)


		if self.with_ajax:
			request.add_header('X-Requested-With', 'XMLHttpRequest')
			self.headers['X-Requested-With'] = 'XMLHttpRequest'
			request.add_header('Accept', '*/*;q=0.5, text/javascript, application/javascript, application/ecmascript, application/x-ecmascript')
			self.with_ajax = False

		self.headers_last = self.headers.copy() # для вывода в дебаге
		self.headers = self.headers_default.copy() # обнуляем рабочие хидеры

		method = 'get'

		if is_post_with_file:
			method = 'multipart/form-data'
			request.add_header('Content-type', self.content_type)
			self.headers_last['Content-type'] = self.content_type

			request.add_header('Content-length', len(self.post_data))
			self.headers_last['Content-length'] = len(self.post_data)

			#~ request.add_data(self.post_data)
			request.data = self.post_data

		else:
			method = 'application/x-www-form-urlencoded'
			if self.post_data:
				if isinstance(self.post_data, str):
					try:
						request.data = bytes(self.post_data, 'utf8')
					except Exception as ex:
						hlp.textarea(self.post_data)
						debug_data = '{}\n{}'.format(ex, self.post_data)
						hlp.traceback_save('POST_DATA', debug_data)

				if 'Content-type' not in self.headers_last:# для ебучих од, где тут должно быть что-то другое иначе не работает. Если сделал add_headers({'Content-type': 'application/json; charset=utf-8''}) то ставится он, а не application/x-www-form-urlencoded
					self.headers_last['Content-type'] = 'application/x-www-form-urlencoded'

				self.headers_last['Content-length'] = len(self.post_data)

		if self._force_socks_check() is False:
			return 
			
		# добавляем прокси и авторизацию
		if self.proxy_enabled and self.__proxy.strip():

			usr = passw = None
			if self.parent.cnf.getbool('proxy_auth') and self.parent.cnf.get('proxy_auth_data').strip():
				usr, passw = self.parent.cnf.get('proxy_auth_data').split(':')

			if self.proxy_type == 0:
				# http
				full_proxy = '{0}:{1}'.format(self.__proxy, self.proxy_port)

				if url.startswith('https'):
					proxy_map = {'https': full_proxy}
				else:
					proxy_map = {'http': full_proxy}

				hnd = urllib.request.ProxyHandler(proxy_map)
				hnds.append(hnd)

				if self.parent.cnf.getbool('proxy_auth'):
					auth_handler = urllib.request.HTTPBasicAuthHandler()
					auth_handler.add_password('realm', 'host', usr, passw)
					hnds.append(auth_handler)

					auth_data = bytes("{0}:{1}".format(usr, passw), 'utf-8')
					auth_data64 = b64encode(auth_data).decode("ascii")

					auth_value = 'Basic {0}'.format(auth_data64)

					request.add_header('Authorization', auth_value)
					self.headers_last['Authorization'] = auth_value

					request.add_header('Proxy-Authorization', 'Basic {0}'.format(auth_data64))
					self.headers_last['Proxy-Authorization'] = auth_value



			elif self.proxy_type == 1:
				# socks5
				hnd = SocksHandler.SocksHandler(PROXY_TYPE_SOCKS5, self.__proxy,
												self.proxy_port, username=usr, password=passw)
				hnds.append(hnd)

			elif self.proxy_type == 2:
				# https
				hnd = SocksHandler.SocksHandler(PROXY_TYPE_HTTP, self.__proxy,
												self.proxy_port, username=usr, password=passw)
				hnds.append(hnd)

			else:
				self.log('неподдерживаемый тип прокси <b>{0}</b>'.format(self.proxy_type), '!')

		if self.basic_auth:# and self.parent.cnf.getbool('proxy_auth'):

			# бейсик-авторизация, перетирающая бейсик-авторизацию прокси
			# ситуация когда авторизация требуется и на прокси и на ресурсе - это уже чересчур, пускай на прокси привязку меняют, блеать
			auth_data = bytes("{0}:{1}".format(self.basic_auth_user, self.basic_auth_passw), 'utf-8')
			auth_data64 = b64encode(auth_data).decode("ascii")

			auth_value = 'Basic {0}'.format(auth_data64)

			self.headers_last['Authorization'] = auth_value
			request.add_header('Authorization', auth_value)

			request.add_header('Proxy-Authorization', auth_value)
			self.headers_last['Proxy-Authorization'] = auth_value

		# добавляем кастомный редиректХендлер
		#~ hnds.append(RelativeRedirectHandler(self, url))
		opener = urllib.request.build_opener(*hnds)
		urllib.request.install_opener(opener)

		self.sz = self.success_request = False

		if self.timeout:
			timeout = self.timeout
		else:
			timeout = self.parent.cnf.getint('http_timeout')

		repeat_request = response = reason = ''
		self.last_url = self.url
		reason = page = ''
		t_start = Decimal(time.time())
		headers = None
		#~ self.log('timeout: {0}'.format(timeout))

		# require python 3.4.3 and higher
		#ssl._create_default_https_context = ssl._create_unverified_context
		
		try:
			response = urllib.request.urlopen(request, timeout=timeout)

			if getsize:
				self.sz = response.info().get('Content-Length', False)
				if self.sz is not False:
					self.sz = int(self.sz)

			headers = response.getheaders()

		except HTTPError as e:
			response = e
			headers = []
			for key in e.headers:
				headers.append([key, e.headers[key]])

			reason = str(e)

		except http.client.BadStatusLine as e:
			reason = 'BadStatusLine'
			repeat_request = True

		except URLError as e:
			reason = str(e)
			repeat_request = True

		except Socks5Error as e:
			reason = 'socks5Error'
			repeat_request = True

		except Exception as e:
			reason = str(e)

			tb = sys.exc_info()[2]
			if tb:
				tb = ''.join(traceback.format_tb(tb))
				tb = tb.replace('\n', '<br />').replace(' ', '&nbsp;')

				# укорачиваем пути
				fnames = hlp.parse_all(r'File (".*?)"', tb, system=True)
				if fnames:
					for fname in fnames:
						try:
							short = fname.split('/')[-1]
						except:
							short = fname

						tb = tb.replace(fname, short)

				tb = tb.replace('", line ', ':')

				# формируем для лога
				tb = '''<b style='text-decoration: underline' onclick='$("#tb_{0}").toggle()'>Exception #{0} {2}</b><br /><textarea style='display: none; width: 400px; height: 200px' id='tb_{0}'>{1}</textarea>'''.format(hlp.password(20), tb, reason)

			else:
				tb = 'Exception not catched'

			self.log(tb, '!', tid=self.tid)
			repeat_request = True
		finally:
			t_finish = Decimal(time.time()) - t_start

		if getsize:
			return self.sz

		if response:
			try:
				page = response.read(readlimit)
				self.last_url = response.geturl()
			except Exception as ex:
				self.log('Problem reading: ' + str(ex), '!', tid=self.tid)
				self.last_error = 'Problem reading: ' + str(ex)
				repeat_request = True

		if reason and reason.strip():
			reason = reason.replace('<', '&lt;').replace('>', '&gt;')
			self.last_error = reason
			proxy = '{} '.format(self.get_proxy())
			self.log('{0}не могу скачать страницу <b>{1}</b>: {2}'.format(proxy, url, reason), '!', tid=self.tid)


		########### тут он пытается повторить запрос с другой прокси
		########### чего в ряде случаев делать нельзя, когда сессия привязана к ИП
		########### отключается эта хуйня опцией break_on_proxyerror, no_switch_proxy()

		# пока code есть только здесь
		if 'HTTP Error 404' in reason:
			code = 404
		elif '500: Internal Server Error' in reason:
			code = 500
		elif 'urlopen error timed out' in reason:
			code = 'timeout'
		elif 'HTTP Error 501: Not Implemented' in reason:
			code = 501
		elif 'Error 503: Service Temporarily Unavailable' in reason:
			code = 503
		elif 'Error 502: Bad Gateway' in reason: #  сервер, выступая в роли шлюза или прокси-сервера, получил недействительное ответное сообщение от вышестоящего сервера
			code = 502
			self.log('502, пробуем с другой прокси', '*')
			repeat_request = True
		elif 'Error 301: Moved' in reason:
			code = 301
		elif "'Network unreachable'" in reason:
			code = 'network_unreachable'
		elif '400: Bad Request' in reason:
			code = 400
		elif '403: Forbidden' in reason:
			code = 403
		elif 'Error 301' in reason and 'would lead to an infinite loop' in reason:
			code = 'loop'
		elif reason == 'BadStatusLine':
			code = 'BadStatusLine'
		else:
			code = 200

		# 'network_unreachable' - меняем прокси при ней
		# 501 - таки надо повторять запрос
		if repeat_request and self.proxy_enabled and code not in [400, 301, 404, 'loop', 500, 503, 403]:

			# если "не пробовать с другой прокси"
			if self.break_on_proxyerror:
				# отключаем её и не пробуем
				self.break_on_proxyerror = False
				self.last_error = 'proxy_error'
				return False

			if repeat_with_the_same_proxy:
				self.log('повторяем запрос с той же прокси (или без неё)', tid=self.tid)
				return self._exec(decode=decode, is_post_with_file=is_post_with_file, saveDebug=saveDebug, fname=fname, readlimit=readlimit, getsize=getsize, changeproxy=changeproxy, repeat_with_the_same_proxy=False)
			
			self.log('повторяем запрос{}'.format(' с другой прокси' if self.no_proxy is False else ''), tid=self.tid)

			if self.no_proxy is False and self.parent.proxy.change(self) == 'no proxies':
				fail_info = "{} {}".format(hlp.human_date(), url)
				hlp.f_add(self.parent.root + "/tmp/DEBUG_PROXY_FAIL", fail_info, create=True)
				return False

			return self._exec(decode=decode, is_post_with_file=is_post_with_file, saveDebug=saveDebug, fname=fname, readlimit=readlimit, getsize=getsize, changeproxy=changeproxy, repeat_with_the_same_proxy=repeat_with_the_same_proxy)

		if repeat_request or not response or not headers:
			return False

		self.success_request = True

		# show debug about redirects and time
		self.redir_list.append(str(t_finish))

		if self.debug_mode and self.parent.cnf.getbool('httpdebug'):
			redirs = self._get_redirs()
		else:
			redirs = False

		encoding = self._get_encoding(headers)

		# prepare headers
		gzipFlag = False
		self.last_headers = {} # хидеры ответа
		self.redirect_location = ''

		for header in headers:

			head1 = hlp.unquote(header[1])
			self.last_headers[header[0]] = head1

			if header[0] == 'Redirect-Location':
				self.log('есть Redirect-Location: {0}'.format(head1))
				server = '/'.join(url.split('/', 3)[:3])

				if head1.startswith('/') and server.endswith('/'):
					server = server[:-1]

				self.redirect_location = server + head1
				self.log('http.redirect_location: {0}'.format(self.redirect_location), '*')

			# Refresh: 0;url=http://yandex.ru/m/?subscribe-email=dulov_kliment@mail.ru&m=OOpIo
			if header[0] == 'Refresh':
				self.log('есть Refresh: {}'.format(head1))
				if 'url=' in head1.lower():
					self.redirect_location = head1.lower().split('url=')[1]
					self.log('http.redirect_location: {0}'.format(self.redirect_location), '*')

			#headers_str += header[0] + ': ' + head1 + '\n'
			if header[0].lower() == 'content-encoding' and 'gzip' in header[1].lower():
				gzipFlag = True


		if gzipFlag:
			try:
				page = zlib.decompress(page, 16 + zlib.MAX_WBITS)
			except Exception as text:
				self.log(('ошибка распаковки gzip: ', str(text)), '!')
				page = b''

		if decode:
			try:
				self.response = page.decode(encoding, 'ignore')
			except Exception as text:
				self.log('Ошибка декодирования: {0}\n  кодировка: {1}\n  исключение: {2}'.format(url, encoding, text), '!')
				self.response = ''

			self.response = self.response.replace('&amp;', '&')
		else:
			self.response = page

		if decode:
			### <meta http-equiv='refresh' content='0; url=http://fuck.off' />
			patt = r'\s*=\s*["|\']*Refresh["|\']*\s*content\s*=\s*["|\']*[0-9]+\s*;\s*url\s*=\s*["|\']*(.*?)["|\']*["|\']+'

			http_refresh = hlp.parse(patt, self.response, ignore_case=True)
			if http_refresh:
				if http_refresh.startswith('?'):
					http_refresh = '{}{}'.format(self.last_url, http_refresh)
				elif not http_refresh.startswith('http'):

					domain = hlp.url2domain(self.last_url)
					scheme = self.last_url.split(domain)[0]
					if not http_refresh.startswith('/'):
						http_refresh = '/' + http_refresh

					http_refresh = '{}{}{}'.format(scheme, domain, http_refresh)
					#~ self.log('собрали чудище Франкенштейна: <b>{}</b>'.format(http_refresh))
					# попробуем по нему перейти (в мир иной)

				self.redirect_location = http_refresh
				self.log('html-refresh http.redirect_location: {0}'.format(self.redirect_location))

		# если в хидерах или <meta> есть редирект и он в allow-листе - идем по нему
		if hlp.txt(self.allowed_redirects, self.redirect_location):
			self.url = self.redirect_location
			self.redirect_location = ''

			self.log('идем по редиректу {}'.format(self.url))
			if self.url.startswith('//'):
				self.log('добавяем к нему протокол')
				self.url = 'http:' + self.url

			return self._exec(decode=decode, is_post_with_file=is_post_with_file, saveDebug=saveDebug, fname=fname, readlimit=readlimit, getsize=getsize, changeproxy=changeproxy, repeat_with_the_same_proxy=repeat_with_the_same_proxy)

		if self.cutMarker1 != '':
			self._cut_response()

		if self.debug_mode and saveDebug:
			# save response to file
			headers_sent = ''
			for name, value in self.headers_last.items():
				headers_sent += '%s: %s\n' % (name, value)

			self.headers_last = {}

			ptype = {
				0: 'http',
				1: 'socks5',
				2: 'https',
				3: 'auto',
			}

			dbg = '<!--<url>' + url + '</url>\n'
			dbg += '<method>' + method + '</method>\n\n'

			if redirs:
				dbg += '<redirs>\n'
				dbg += redirs + '\n</redirs>\n\n'

			if self.last_url:
				dbg += '<last_url>\n'
				dbg += self.last_url + '\n</last_url>\n\n'

			dbg += '<proxy ip="{}" port="{}" type="{}" />\n\n'.format(self.__proxy, self.proxy_port, ptype[self.proxy_type])

			dbg += '<sent_headers>\n'
			dbg += headers_sent + '</sent_headers>\n\n'

			dbg += '<sent_cookies>\n'

			if cookies_was_disabled:
				dbg += 'DISABLED</sent_cookies>\n\n'
				sent_cookies_x = ''
			else:
				dbg += sent_cookies + '</sent_cookies>\n\n'
				sent_cookies_x = sent_cookies

			dbg += '<post_data>\n'
			if method == 'application/x-www-form-urlencoded':
				post_data = str(self.post_data).replace('&', '\n')
				dbg += post_data
			else:
				if self.show_post_debug:
					post_data = 'post data size: %s\n' % len(str(self.post_data))
					post_data += 'post data: {0}'.format(self.post_data.decode('utf-8', 'ignore'))
					dbg += post_data
				else:
					post_data = 'OUTPUT IS HIDDEN (binary data can broke debug file)'
					dbg += post_data

			dbg += '</post_data>\n\n'
			dbg += '<got_headers>\n'

			last_headers_text = ''

			for key, val in self.last_headers.items():
				last_headers_text += '{0}: {1}\n'.format(key, val)

			dbg += last_headers_text + '</got_headers>\n\n'

			dbg += '<got_response>-->\n'

			# html debug
			d_method = 'POST' if self.post_data else 'GET'
			dbg_html = self.make_debug_html(url, d_method, method, self.__proxy, self.proxy_port, ptype[self.proxy_type], headers_sent, sent_cookies_x, post_data, last_headers_text)

			dbg = dbg_html + dbg

			# добавляем <base>
			url_parts = url.split('/')
			domain = '{}//{}'.format(url_parts[0], url_parts[2])
			dbg += '<base href="{}" />'.format(domain)

			# удаляем редиректы, чтобы не перекидывало из превьюхи
			resp = self.response

			resp = self.cut_js_redirects(resp)

			dbg += resp
			dbg += '</got_response>'

			if hasattr(self.parent, 'active_project'):
				project_active = '{}-'.format(self.parent.active_project)
			else:
				project_active = ''

			if fname.strip():
				filename = 'debug/{}{}_{}'.format(project_active, fname, hlp.password(15))
			else:
				filename = 'debug/{}{}'.format(project_active, hlp.password(15))

			if self.post_data:
				filename += '_post'

			#~ filename += '.html.gz'
			filename += '.html'

			if self.last_error_filename and hlp.exists(self.last_error_filename):
				prev = hlp.f_read(self.last_error_filename)
				prev = prev.replace('FR_NEXT_DEBUG', filename)
				prev = prev.replace('id="fr_next_link" style="display: none"', 'id="fr_next_link" ')
				hlp.f_write(self.last_error_filename, prev)

			self.last_error_filename = filename

			try:
			#~ dbg_result = bytes(dbg, 'utf-8')
			#~ dbg_result = gzip.compress(dbg_result, 9)
#~
			#~ f = gzip.open(filename, 'wb')
			#~ f.write(dbg_result)
			#~ f.close()
				#~ dbg = bytes(dbg, 'utf-8')
				#~ dbg = bytes('хуета', 'utf-8')
				#~ s = StringIO()
				#~ g = gzip.GzipFile(fileobj=s, mode='wb')
				#~ g.write(dbg)
				#~ g.close()

				#~ f = gzip.open(filename, 'wb')
				#~ f.write(dbg)
				#~ f.close()
				with open(filename, 'wb') as fp:
					fp.write(bytes(dbg, 'utf-8'))

				self.log('ответ сервера сохранен в <a href="{0}" target="_blank" onmouseout="hide_iframe()" onmouseover="show_preview(this.href)">{0}</a>'.format(filename), tid=self.tid)
			except Exception as ex:
				self.log('ошибка сохранения дебага: {}'.format(ex), '!')

	def cut_js_redirects(self, resp):

		replaces = {
			'body{display:none;}': '', # hotmail
			'desktop/js/_internet.js': 'desktop/js/_internet[dfdfdsf].js', #internet.yandex.ru
			'top.location': 'top[dfdfdsf]location',
			'self.location': 'self[dfdfdsf]location',
			'document.location': 'document[dfdfdsf]location',
			'window.location': 'window[dfdfdsf]location',
			'ontent-type="refresh': 'ontent-type="[dfdfdsf]refresh',
			'ontent-type=\'refresh': 'ontent-type=\'[dfdfdsf]refresh',
			'HTTP-EQUIV=Refresh': 'HTTP-EQUIV=[dfdfdsf]Refresh',
			'HTTP-EQUIV=\'Refresh': 'HTTP-EQUIV=\'[dfdfdsf]Refresh',
			'HTTP-EQUIV="Refresh': 'HTTP-EQUIV="[dfdfdsf]Refresh',
			'visibility: hidden !important': '', # for yahoo classic mail
			'#mailWrapper {display:none;': '', # yahui
			'badoocdn.com/v2/-/-/js/base-lite': 'badoocdn.com/v2/-/-/js/[dfdfdsf]base-lite', # badoo
			'location.href': 'location[dfdfdsf]href',
		}

		for old, new in replaces.items():
			re1 = re.compile(old, re.IGNORECASE)
			resp = re1.sub(new, resp)

		return resp

	def no_switch_proxy(self):
		'''ставим на 1 запрос - не пробовать менять прокси, если он зафейлился
		надо для сайтов, где сессия привязана к ип
		после такого запроса переменная снова возвращается в дефолтное состояние False
		'''
		self.break_on_proxyerror = True
		return self

	def _cut_response(self):

		data = self.response
		start = self.cutMarker1
		finish = self.cutMarker2
		self.cutMarker1 = self.cutMarker2 = ''

		if start not in data or finish.strip() and finish not in data:
			return 'fail'

		# cut1
		data = data[data.find(start):]

		# cut2
		if finish.strip() and data.find(finish) != -1:
			data = data[:data.find(finish)]

		self.response = data

	def _get_encoding(self, headers):
		'''
			ищет кодировку в tuple хидеров
			также используется as_proxy.chk
		'''

		for header in headers:
			name = header[0].lower()
			val = header[1].lower()

			if 'Content-Type'.lower() in name and 'charset='.lower() in val:
				found = val.split('charset=')
				if len(found) > 1:
					encoding = found[1].lower()

					if encoding == 'utf-7':
						encoding = 'utf-8'

					if encoding == 'charset_utf8':
						encoding = 'utf-8'

					return encoding

		return self.default_charset

	def make_debug_html(self, url, method, method_descr, proxy, pport, ptype, headers_sent, cookies, post_data, headers_got):

		date = hlp.human_date()

		cookies_list = [c.strip() for c in cookies.split(';') if c.strip()]
		cookies_num = len(cookies_list)
		cookies = ';\n'.join(cookies_list)

		ajax = 'AJAX' if 'XMLHttpRequest' in headers_sent else ''

		if proxy:
			proxy_line = "<b>{ptype}</b> <input type='text' onclick='this.select()' value='{proxy}:{pport}' />".format(**locals())
		else:
			proxy_line = '<b>-None-</b>'

		if self.task is not None:
			task = '''	<tr>
		<td><b>thread task</b></td>
		<td>{}</td>
	</tr>'''.format(self.task)
		else:
			task = ''

		redirs_html = ''
		for red in self.redir_list:
			if not red.strip():
				continue

			redirs_html += '<option>{}</option>'.format(red)

		html = '''<div id='fr_debug_info' style='position: fixed; z-index:999999999999; border: 1px solid black; top: 0; right: 0; background-color: #fff; padding: 5px; font-family: Verdana; font-size: 9pt; box-shadow: 0 0 10px rgba(0,0,0,0.5);'>
	<script type='text/javascript'>
	function fr_toggle()
	{{
		var cur = document.getElementById('fr_debug_data').style.display;
		if(cur === 'block')
		{{
			document.getElementById('fr_debug_data').style.display = 'none';
			document.getElementById('fr_debug_info').style.width = '';
			document.getElementById('fr_debug_info').style.height = '';
		}}else{{
			document.getElementById('fr_debug_data').style.display = 'block';
			document.getElementById('fr_debug_info').style.width = '95%';
			document.getElementById('fr_debug_info').style.height = '450px';
		}}
	}}

	function fr_go(file)
	{{
		if(file === 'FR_NE'+'XT_DEBUG')
		{{
			alert('this is last debug in chain')
			return
		}}
		var parts = document.location.href.split('debug/')
		var loc = parts[0] + file
		document.location.href = loc

	}}
	</script>
	<style type='text/css'>
	.fr_button {{
		width: 50px;
		height: 30px;
		border: 1px solid black;
		background-color: #eee;
	}}
	#fr_debug_info, #fr_debug_info TD, #fr_debug_info TH {{ color: black; }}
	</style>
	<span style='float:right'><button class="fr_button" id="fr_prev_link" onclick="fr_go('{self.last_error_filename}')">&laquo;</button>
	<span style='font-size: 12pt; font-style: italic; text-decoration: underline' onclick="fr_toggle()">debug file</span>
	<button class="fr_button" id="fr_next_link" style="display: none" onclick="fr_go('FR_NEXT_DEBUG')">&raquo;</button></span>

	<span  id='fr_debug_data' style='display: none'>
	<br />
	<table border='0' style='width: 90%;'>
	<tr>
		<td>&nbsp;</td>
		<td><b>{method} {ajax}</b> {method_descr}, <b>{self.redirs_num}</b> redirects in {self.redirs_time} sec. @ {date}</td>
	</tr>
	<tr>
		<td style='width: 200px'><b>URL</b></td>
		<td><input type='text' style='width: 80%' onclick='this.select()' value="{url}" /></td>
	</tr>
	<tr>
		<td><b>Useragent</b></td>
		<td><input type='text' style='width: 80%' onclick='this.select()' value="{self.session_ua}" /></td>
	</tr>
	<tr>
		<td><b>Redirects</b></td>
		<td>
			<select style='width: 80%'>
				{redirs_html}
			</select>
		</td>
	</tr>
	<tr>
		<td><b>http.last_url</b></td>
		<td><input type='text' style='width: 80%' onclick='this.select()' value="{self.last_url}" /></td>
	</tr>
	<tr>
		<td><b>http.redirect_location</b></td>
		<td><input type='text' style='width: 80%' onclick='this.select()' value="{self.redirect_location}" /></td>
	</tr>
	<tr>
		<td><b>proxy</b></td>
		<td>{proxy_line}</td>
	</tr>
	{task}
</table>
<p><br /></p>
<table border='0' style='width: 100%; margin: 0 auto'>
	<tr>
		<th style='text-align: center'>sent headers</th>
		<th style='text-align: center'>got headers</th>
		<th style='text-align: center'>sent cookies ({cookies_num})</th>
		<th style='text-align: center'>post data</th>
	</tr>
	<tr>
		<td style='text-align: center'><textarea style='width: 100%; height: 200px'>{headers_sent}</textarea></td>
		<td style='text-align: center'><textarea style='width: 100%; height: 200px'>{headers_got}</textarea></td>
		<td style='text-align: center'><textarea style='width: 100%; height: 200px'>{cookies}</textarea></td>
		<td style='text-align: center'><textarea style='width: 100%; height: 200px'>{post_data}</textarea></td>
	</tr>
</table></span>
</div>'''.format(**locals())

		return html


