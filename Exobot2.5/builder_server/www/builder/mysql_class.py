import os, time

os.sys.path.insert(0, '..')
os.sys.path.insert(0, 'engine')
os.sys.path.insert(0, 'pymysql')

import pymysql, itertools
from urllib.parse import quote, unquote
from threading import RLock, Condition
from helper_class import *
import datetime


class mysqlClass():

	def __init__(self):

		# Соединение pymysql дохнет, если его долго не использовать!
		# приходится пинговать

		# спим 5 мин, пингуя
		#~ for i in range(10):
			#~ self.hlp.slp(30, log=self.log)
			#~ self.mysql.conn.ping()

		self.debug = False
		self.conn = None
		self.tables = []
		self.changes = 0 # кол-во требуемых коммитов для _commit()
		self.complex_commits = False # делать коммиты пачками
		self.table_cols = {} # строки для вставки в таблицы, типа 'null, "%s", 0'
		self.iterators = {} # для getnext
		self.lock = RLock()
		self.db_path = '' # путь к загруженной базе данных
		self.last_error = ''

		self.__user = ''
		self.__passwd = ''
		self.__db = ''
		self.__host = ''

	def log(self, text, ctype='~', tid=0):
		text = '{}'.format(text)
		self.parent.log(text, ctype, tid)

	def init(self, debug=False, parent=None, user=False, passwd=False, db=False, host='127.0.0.1'):
		self.last_error = ''
		self.parent = parent

		self.__user = user
		self.__passwd = passwd
		self.__db = db
		self.__host = host

		if debug:
			self.debug = True

		socketpath = "/var/run/mysqld/mysqld.sock"
		if not hlp.exists(socketpath):
			socketpath = '/var/lib/mysql/mysql.sock'

		try:
			self.conn = pymysql.connect(user=user, passwd=passwd, db=db, charset='utf8', host=host)
		except pymysql.err.OperationalError as ex:
			self.last_error = str(ex)
			if not hlp.exists(socketpath):
				print('socket {} not found'.format(socketpath))
				return False

			try:
				self.conn = pymysql.connect(user=user, passwd=passwd, db=db, charset='utf8', unix_socket=socketpath)
			except Exception as ex2:
				ex2 = str(ex2)
				if '2003' in ex2:
					ex2 += ' Add "max_connections = 1000" to [mysqld] section in /etc/my.cnf, restart daemon'

				print('Connect exception', ex2)
				self.last_error = str(ex2)
				return False

		self.cursor = self.conn.cursor()
		return True

	def human_date(self, datetime_obj, format_d="%d.%m.%y %H:%M:%S"):
		'''
		значения столбцов типа timestamp mysql возвращает как объект datetime.datetime()
		метод форматирует его в нужный формат даты и возвращает строку

		@param datetime datetime_obj - объект, который выдала mysql
		@return str форматированная дата/False
		'''

		if isinstance(datetime_obj, datetime.datetime):
			return datetime_obj.strftime(format_d)
		else:
			return False

	def dbg(self, sql):

		if not self.debug:
			return

		hlp._print(sql + '\n')
		#~ print(sql)
		#~ print('<br />')

		if os.path.exists('tmp/SQLITE_DEBUG'):
			hlp.f_add('tmp/SQLITE_DEBUG', sql)

	def vacuum(self):
		self.cursor.execute('VACUUM')
		self.conn.commit()

	def _commit(self):

		if not self.complex_commits:
			self.conn.commit()
			#~ print('COMMIT')
			return

		self.changes += 1

		if self.changes > 10:
			self.changes = 0
			self.conn.commit()

	def execute(self, sql):
		''' возвращает список всех таблиц с данными '''
		self.last_error = ''
		self.dbg('mysql: exec: %s' % sql)

		commit = True
		if 'NO_COMMIT' in sql: # нельзя в многопотоке
			commit = False
			sql = sql.replace('NO_COMMIT', '')

		tables = []
		with self.lock:
			try:
				#cursor = self.conn.cursor()
				res = self.cursor.execute(sql) # res - кол-во результатов

				tables = []
				for row in self.cursor:
					tables.append(row)

				#cursor.close()
			except Exception as ex:

				if 'BrokenPipeError' in str(ex):
					self.log('пробуем переподключиться к базе', '*')
					res = self.init(self.debug, self.parent, self.__user, self.__passwd, self.__db, self.__host)
					if res is False:
						self.log('mysql: exec: BrokenPipeError не смог переподключиться к БД', '!')
						return False
					else:
						if hlp.recursion_limit():
							self.log('переподключились, повторяем запрос', '+')
							return self.execute(sql)
						else:
							self.log('переподключились, но лимит рекурсии, не повторяем запрос', '-')
							return

				self.dbg('mysql: exec: Exception: %s' % str(ex))
				self.last_error = str(ex)
				return False

			if not sql.lower().startswith('select') and commit:
				self._commit()

		return tables

	def get(self, table):
		''' достает данные из первой строки таблицы, возвращает строку '''

		sql = 'select data from `%s`' % table

		self.dbg('mysql: get: %s' % sql)
		
		with self.lock:
			#cursor = self.conn.cursor()
			try:
				data = self.cursor.execute(sql).fetchall()
				return unquote(data[0][0])
			except Exception as ex:
				print('EXCEPTION {}'.format(ex))
				return ''
			#cursor.close()

		

	def getlist(self, table, unique=True, valid=False, where2='', limit=None, what='data'):
		''' достает все строки из таблицы, возвращает список '''
		self.last_error = ''
		if valid:
			sql = 'select %s from `%s` where invalid = 0' % (what, table)
			if where2:
				sql += ' and %s' % where2
		else:
			sql = 'select %s from `%s`' % (what, table)
			if where2:
				sql += ' where %s' % where2

		if limit:
			sql += ' limit %d' % int(limit)

		self.dbg('mysql: getlist: %s' % sql)
		
		rows = []
		with self.lock:

			try:
				cursor = self.conn.cursor()

				if what == 'data, type':
					rows = [[unquote(row[0]), row[1]] for row in cursor.execute(sql).fetchall() if row[0]]
				else:
					rows = [unquote(row[0]) for row in cursor.execute(sql).fetchall() if row[0]]
				cursor.close()

				if unique and len(rows) > 1:
					rows = list(set(rows))

			except Exception as ex:
				self.dbg('mysql: getlist: Exception %s' % (ex))
				self.last_error = str(ex)
				return []

		self.dbg('mysql: getlist: got %d rows from %s' % (len(rows), table))

		return rows

	def sz(self, table):
		return self.size(table)

	def size(self, table):
		''' возвращает количество строк в таблице table '''

		sql = 'select COUNT(data) from %s where data != "" and data != " "' % table

		self.dbg('mysql: size: %s' % sql)

		with self.lock:
			#cursor = self.conn.cursor()
			try:
				data = self.cursor.execute(sql).fetchall()
				return int(data[0][0])
			except Exception as ex:
				print('EXCEPTION2 {}'.format(ex))
				return 0
			#cursor.close()

		

	def rm(self, table, rows):
		''' удаляет строку row из таблицы table '''

		if isinstance(rows, str):
			rows = rows.strip().split('\n')

		for row in rows:
			sql = 'delete from `%s` where data="%s"' % (table, quote(row.strip()))

			self.dbg('mysql: rm: %s' % sql)

			with self.lock:
				#cursor = self.conn.cursor()
				self.cursor.execute(sql)
				#cursor.close()

				self._commit()

	def upd(self, table, data, action):
		''' обновляет строку с data в таблице table. action - стандартные обновления

			sql.upd('accounts', 'vasya', 'invalid')
			sql.upd('accounts', 'vasya', 'empty_cl = 1')

			с like (все " должны быть экранированы, а % продублированы - %%):
			sql.upd('accounts', 'vasya2', 'like vasya') --> ищем в таблице строку, которая содержит "vasya", пишем в эту строку "vasya2"
		'''

		known_flags = ['invalid', 'valid', 'unknown_service', 'empty_cl', 'not_confirmed']

		# TODO убрать
		if action in known_flags:
			upd = action + ' = 1'
		else:
			upd = action

		if action.startswith('like '):
			prep_data = quote(action[5:]).replace('%', '%%').replace('"', '\"')
			sql = 'update `{0}` set data="{1}" where data like("%{2}%")'.format(table, quote(data), prep_data)
		else:
			sql = 'update `%s` set %s where data = "%s"' % (table, upd, quote(data))

		self.dbg('mysql: update: %s' % sql)

		with self.lock:
			#cursor = self.conn.cursor()
			self.cursor.execute(sql)
			#cursor.close()
			self._commit()

	def unique(self, table, column=None):
		''' удаляет дубли из таблицы '''

		self.last_error = ''
		cvars = (table, table)
		sql = 'DELETE FROM `%s` WHERE auto_id NOT IN (SELECT MAX(auto_id) FROM `%s` GROUP BY data)' % cvars

		if column:
			cvars = (table, table, column)
			sql = 'DELETE FROM `%s` WHERE ROWID NOT IN (SELECT MIN(ROWID) FROM `%s` GROUP BY %s)' % cvars

		self.dbg('mysql: unique: %s' % sql)

		with self.lock:
			#cursor = self.conn.cursor()
			try:
				self.cursor.execute(sql)
				self._commit()
			except Exception as ex:
				self.last_error = str(ex)
				# очистка дублей для таблиц, где нет auto_id
				data = self.getlist(table)
				self.clear(table)
				self.add(table, data)

	def clear(self, table):
		''' очищает таблицу table '''

		sql = 'delete from `%s`' % table

		self.dbg('mysql: clear: %s' % sql)

		with self.lock:
			#cursor = self.conn.cursor()
			self.cursor.execute(sql)
			#cursor.close()
			self._commit()

	def mark_invalid(self, table, rows):
		''' отмечает строку как invalid '''

		if isinstance(rows, str):
			rows = rows.strip().split('\n')

		for row in rows:
			sql = 'update `%s` set invalid = 1 where data = "%s"' % (table, row.strip())

			self.dbg('mysql: mark_invalid: %s' % sql)

			with self.lock:
				#cursor = self.conn.cursor()
				self.cursor.execute(sql)
				#cursor.close()
				self._commit()

	def add(self, table, rows, cols=None, split=True, on_duplicate=''):
		''' добавляет строку row в конец таблицы table '''
		self.last_error = ''
		#self.parent.log(', '.join(rows))
		if not rows:
			self.dbg('mysql: add: 0 ROWS')

		if not cols:
			cols = self.table_cols[table]

		if isinstance(rows, int):
			rows = str(rows)

		if isinstance(rows, str):
			if split:
				rows = rows.strip().split('\n')
			else:
				rows = [rows]

		if len(rows) == 1:

			# если база залочена будет ждать 10 сек и пытаться снова каждую секунду
			for i in range(10):
				i
				with self.lock:

					sql = 'insert into `%s` values(%s) %s' % (table, cols, on_duplicate)

					try:
						self.cursor.execute(sql % quote(rows[0]))
					except Exception as ex:
						self.last_error = str(ex)
						time.sleep(1)
						continue

				self._commit()
				break

			return

		sql = 'insert into `%s` values(%s) %s' % (table, cols.replace("'%s'", '?').replace('"%s"', '?'), on_duplicate)
		self.dbg('mysql: add: %s' % sql)

		def generator(rows):
			for row in rows:
				yield (quote(row[0]))

		# если база залочена будет ждать 10 сек и пытаться снова каждую секунду
		for i in range(10):

			with self.lock:

				try:
					self.cursor.executemany(sql, generator(rows))
				except Exception as ex:
					self.last_error = str(ex)
					time.sleep(1)
					continue

			self._commit()
			break

	def save(self, table, rows, cols=None, split=True):
		''' сохраняет список lines построчно в таблицу table '''

		self.clear(table)
		self.add(table, rows, cols=cols, split=split)

	def getrand(self, table, what='data', where=None):
		''' достает рандом строку из таблицы table. возвращает set с полями '''

		self.last_error = ''
		if where:
			where_t = 'where ' + where
		else:
			where_t = ''

		sql = 'select %s from `%s` %s order by RANDOM() limit 1' % (what, table, where_t)

		self.dbg('mysql: getrand: %s' % sql)

		rows = []
		try:
			with self.lock:
				rows = self.cursor.execute(sql).fetchall()[0]
		except Exception as ex:
			self.dbg('mysql: getrand: exception: %s' % ex)
			self.last_error = str(ex)
			return ''

		rows = [self._unquote_b(col) for col in rows]

		if len(rows) == 1:
			return rows[0]

		return rows

	def _unquote_b(self, text):
		return unquote(text) if isinstance(text, str) else text

	def getnext(self, table):

		row = []
		if table in self.iterators:
			row = next(self.iterators[table])
		else:
			with self.lock:
				#cursor = self.conn.cursor()
				res = self.cursor.execute("SELECT * FROM `%s`" % table).fetchall()
				#cursor.close()

				self.iterators[table] = itertools.cycle(res)
				row = next(self.iterators[table])

		row = [self._unquote_b(col) for col in row]

		if len(row) == 1:
			return row[0]

		return row
