#!/bin/bash

echo "CRONTAB: 0	0	*	*	*	/var/data/backend_backup.sh > /dev/null 2>&1"
cd /var/data
curdate=$(date +%d.%m.%y)
echo Start backup to www/cp/backup.zip
#rm www/cp/back.zip
rm -rf tmp/*
mysqldump -uroot -pPASSWORD --all-databases | gzip > tmp/db_dump.sql.gz
# copy all to tmp
cp -rp apache_ip_block www/ tmp/
# rm garbage
rm -f tmp/www/cp/backups/*
rm -f tmp/www/cp/apks_tmp/*
rm -rf tmp/www/cp/pma/
rm -f tmp/www/apks/*
# zip
zip --symlinks -r9 www/cp/backups/back$curdate.zip tmp/*
# clear tmp
rm -rf tmp/*
echo "Done"
ls -lh www/cp/backups/back$curdate.zip
