#!/bin/bash

rm mods/*java
rm out/*dex

MOD_BASE=../app/app/src/main/java/com/moonny/mods_src
MODS_DIR=bot_mods
#rm -f $MODS_DIR/*

FILE=$1.java
FILE_LOWER=$(echo $FILE | tr '[:upper:]' '[:lower:]')
echo ================== $FILE ==============

cp $MOD_BASE/$FILE mods/$FILE
sed -i -r 's/package com\.moonny\.mods_src/package com\.dynam/' mods/$FILE

#java -jar ~/Android/Sdk/build-tools/24.0.0/jack.jar --classpath android.jar:android-support-v4.jar:android-support-v7-appcompat.jar mods/$FILE --output-dex out 
java -jar jack.jar --classpath android.jar:android-support-v4.jar:android-support-v7-appcompat.jar mods/$FILE --output-dex out 

filename="${FILE_LOWER%.*}"
mv out/classes.dex bot_mods/$filename.dex
md5=`php -r "echo md5_file('$MODS_DIR/$filename.dex'); "`
echo Done. MD5: $md5
echo "$filename.dex:$md5" >> $MODS_DIR/md5.txt

#cat $MODS_DIR/md5.txt



