#!/bin/bash

echo Build $1 in $2
cd $2
./make_cert.sh


./gradlew aR  > build.log && echo `tail build.log -n 3` && mv app/build/outputs/apk/app-release.apk $1.apk 

mv $1.apk apks/


