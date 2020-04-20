#!/bin/bash
echo make new app cert, answer all stupid questions
cd app
rm keystore.jks
#keytool -genkey -v -keystore keystore.jks -alias keystore -keyalg RSA -keysize 2048 -validity 10000
#expect ../make_cert.exp
keytool -genkey -noprompt -v -keystore keystore.jks -alias keystore -keyalg RSA -keysize 2048 -validity 10000 -alias keystore -keystore keystore.jks -storepass 123123 -keypass 123123 -dname "CN=Unknown, OU=Unknown, O=Unknown, L=Unknown, S=Unknown, C=Unknown"
echo Done
