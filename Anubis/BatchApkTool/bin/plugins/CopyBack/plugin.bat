:: CopyBack v1.0.1
:: Автор: bursoft
:: Плагин заменяет *.apk и *.jar файлы в папке _system на одноименные файлы из папок _OUT_APK и _OUT_JAR.
if "%bat_version%"=="" goto:eof
cls
echo.
cecho {!colG!}!bat_title!{# #}{\n}
echo !bat_page!
echo !bat_line!
echo.
echo !str_plugin_name!.
echo.
set count2=0
set count3=0
set count4=0
set count5=0
set progressbar=0
FOR /f "delims=" %%F IN ('sfk list -hidden -quiet -quot -dir _system -file .apk .jar 2^>nul') DO (set /A count2+=1)
FOR /f "delims=" %%a IN ('sfk list -hidden -quiet -quot -dir _system -file .apk .jar 2^>nul') DO (
	if !count3!==0 (cecho {!colG!}[#)
	if "%%~xa"==".apk" (
		if exist "_OUT_APK\%%~nxa" (
			COPY "_OUT_APK\%%~nxa" "%%~a" >nul
			set /A count4+=1
		) else (
			set /A count5+=1
		)
	) else (
		if exist "_OUT_JAR\%%~nxa" (
			COPY "_OUT_JAR\%%~nxa" "%%~a" >nul
			set /A count4+=1
		) else (
			set /A count5+=1
		)
	)
	set /A count3+=1
	set /A percent=!count3!*100/!count2!
	set /A diff=!percent!-!progressbar!
	if not diff==0 (
		set hash_sign=
		FOR /L %%a IN (1,1,!diff!) DO set hash_sign=!hash_sign!#
		cecho {!colG!}!hash_sign!
		set progressbar=!percent!
	)
	if !percent!==100 (cecho #]{!colB!}{\n})
)
echo [*] !str_plugin_copied!: !count4! !str_plugin_files!, !str_plugin_skipped!: !count5! !str_plugin_files!.
echo.
pause
