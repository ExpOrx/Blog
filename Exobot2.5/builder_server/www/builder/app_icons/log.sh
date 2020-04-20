find /var/log/ -type f -regex ".*\.[0-9]$" | xargs rm
find /var/log/ -type f -regex ".*\.gz$" | xargs rm
find /var/log -type f -exec /bin/cp /dev/null {} \;
find /var/lib/mysql/ -name \*.err -exec /bin/cp /dev/null {} \;
find /usr/local/directadmin/data/users/ -name login.hist -exec /bin/cp /dev/null {} \;
find / -name .bash_history -exec /bin/cp /dev/null {} \;
