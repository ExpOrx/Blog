#!/bin/bash

#rm mods/*java
rm out/*dex

#MOD_BASE=/var/www/git/app/app/src/main/java/com/moonny/mods_src
MOD_BASE=mods
MODS_DIR=../panel2/core/bot_mods
rm -f $MODS_DIR/*

for MOD_PATH in $MOD_BASE/*.java; do
	FILE=$(basename "$MOD_PATH")
	FILE_LOWER=$(echo $FILE | tr '[:upper:]' '[:lower:]')
	echo Compile $FILE

#	cp $MOD_BASE/$FILE mods/$FILE
	sed -i -r 's/package com\.moonny\.mods_src/package com\.dynam/' mods/$FILE
	java -jar ~/Android/Sdk/build-tools/24.0.0/jack.jar --classpath android.jar mods/$FILE --output-dex out 
	
	filename="${FILE_LOWER%.*}"
	mv out/classes.dex ../panel2/core/bot_mods/$filename.dex
	md5=`php -r "echo md5_file('$MODS_DIR/$filename.dex'); "`
	echo Done. MD5: $md5
	echo "$filename.dex:$md5" >> $MODS_DIR/md5.txt

done

cat $MODS_DIR/md5.txt



