#!/bin/bash

apt-get update
apt-get -y upgrade
apt-get -y install zip unzip vim mc htop mysql-server python3 sudo phpmyadmin mlocate openjdk-7-jdk git
a2enmod rewrite
a2enmod ssl

# add log dir
mkdir /var/data/ ; mkdir /var/data/logs/ ; chown www-data:root -R /var/data/logs ; chmod 775 /var/data/logs/

cd /var/data/ ; mkdir www ; chown www-data:www-data www/
