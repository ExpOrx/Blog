
BACKEND = 'x.x.x.x'
FRONTEND = 'x.x.x.x'

PATH = '/var/data/www/app/' # path to release.sh
PATH_BUILDER = '/var/data/www/builder/' # path to start.py
UPLOAD_TO = 'https://{}:8888/builder.php'.format(BACKEND) # upload apks to
BUILDER_BASIC_AUTH = 'builder:123123'

db = {
	'user': 'root',
	'password': '123123',
	'db_name': 'builder',
}