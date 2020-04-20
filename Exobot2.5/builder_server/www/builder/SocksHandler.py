import urllib.request, os, http.client
os.sys.path.insert(0, 'engine')

import socks as socks
from socks import PROXY_TYPE_SOCKS4, PROXY_TYPE_SOCKS5, PROXY_TYPE_HTTP

class SocksConnection(http.client.HTTPConnection):
	def __init__(self, proxytype, proxyaddr, proxyport = None, rdns = True, username = None, password = None, *args, **kwargs):
		self.proxyargs = (proxytype, proxyaddr, proxyport, rdns, username, password)
		http.client.HTTPConnection.__init__(self, *args, **kwargs)

	def connect(self):
		self.sock = socks.socksocket()
		self.sock.setproxy(*self.proxyargs)
		if isinstance(self.timeout, int):
			self.sock.settimeout(self.timeout)
		self.sock.connect((self.host, self.port))

class SocksConnectionHTTPS(http.client.HTTPSConnection):
	def __init__(self, proxytype, proxyaddr, proxyport = None, rdns = True, username = None, password = None, *args, **kwargs):
		self.proxyargs = (proxytype, proxyaddr, proxyport, rdns, username, password)
		http.client.HTTPSConnection.__init__(self, *args, **kwargs)

	def connect(self):
		self.sock = socks.socksocket()
		self.sock.setproxy(*self.proxyargs)
		if isinstance(self.timeout, int):
			self.sock.settimeout(self.timeout)
		self.sock.connect((self.host, self.port))
		self.sock = http.client.ssl.wrap_socket(self.sock, self.key_file, self.cert_file)

class SocksHandler(urllib.request.HTTPHandler, urllib.request.HTTPSHandler, urllib.request.HTTPRedirectHandler):
	def __init__(self, *args, **kwargs):
		self.args = args
		self.kw = kwargs
		urllib.request.HTTPHandler.__init__(self)
		urllib.request.HTTPSHandler.__init__(self)

	def http_open(self, req):
		#~ def build(host, port=None, strict=None, timeout=0):
		def build(host, port=None, timeout=0):
			#~ conn = SocksConnection(*self.args, host=host, port=port, strict=strict, timeout=timeout, **self.kw)
			conn = SocksConnection(*self.args, host=host, port=port, timeout=timeout, **self.kw)
			return conn
		return self.do_open(build, req)

	def https_open(self, req):
		#~ def build(host, port=None, strict=None, timeout=0):
		def build(host, port=None, timeout=0):
			#~ conn = SocksConnectionHTTPS(*self.args, host=host, port=port, strict=strict, timeout=timeout, **self.kw)
			conn = SocksConnectionHTTPS(*self.args, host=host, port=port, timeout=timeout, **self.kw)
			return conn
		return self.do_open(build, req)

if __name__ == "__main__":
	pass
	#import http.cookiejar
	#opener1 = urllib.request.build_opener(SocksHandler(PROXY_TYPE_SOCKS5, '76.22.161.245', 2010), urllib.request.HTTPCookieProcessor(http.cookiejar.CookieJar()))
	#opener2 = urllib.request.build_opener(SocksHandler(PROXY_TYPE_SOCKS5, 'localhost', 8282, username='user', password='pass'))
	#opener3 = urllib.request.build_opener(SocksHandler(PROXY_TYPE_SOCKS4, 'localhost', 8181))
	#print(opener1.open('http://www.whatismyip.com/automation/n09230945.asp').read())
	#print(opener2.open('http://www.whatismyip.com/automation/n09230945.asp').read())
	#print(opener3.open('http://www.whatismyip.com/automation/n09230945.asp').read())