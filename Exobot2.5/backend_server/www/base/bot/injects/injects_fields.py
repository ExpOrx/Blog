import os; os.sys.path.insert(0, "/var/www/frd/engine");from as_hlp import *

injs = hlp.ls2('.', folders=True)
for inj in injs:
	p = inj + '/index.html'
	if not hlp.exists(p):
		p = inj + '/index.php'
		
	if not hlp.exists(p):
		continue
		
	if hlp.exists(inj + '/fields.list'):
		print('ALREADY DONE')
		continue

	print(p)

	d = hlp.f_read(p)
	fld = hlp.parse_all(r'fields\[([\S]+)\]', d)
	if fld is False:
		print(p + ' HAS NO FIELDS')
		continue
	
	hlp.execute('mkdir ' + inj)
	hlp.f_write(inj + '/fields.list', '\n'.join(fld))
	
