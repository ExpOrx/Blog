:: UnicodeEscape2UTF8 v1.0.3
:: Автор: bursoft
:: Плагин конвертирует файлы *.smali в папках smali*, переводя Unicode-последовательности типа "\u043f\u0440\u0438\u0432\u0435\u0442\u0029" в человекопонятные "привет)"
if "%bat_version%"=="" goto:eof
cls
echo.
cecho {!colG!}!bat_title!{# #}{\n}
echo !bat_page!
echo !bat_line!
echo.
echo !str_plugin_name!.
echo.
set error_count=0
FOR /D %%F IN ("_INPUT_APK\!apk_base!") DO (
	if not "%%~nxF"=="_RES_REPLACE" (
		echo [*] !str_converting! %%~nxF...
		FOR /D %%S IN ("_INPUT_APK\%%~nxF\smali*") DO (
			call :native2ascii2 "_INPUT_APK\%%~nxF" "%%~nxS"
		)
	)
)
echo.
if !error_count! GTR 0 (cecho {!colR!}%str_doneerrors%{# #}{\n}) else (cecho {!colG!}!str_done!{# #}{\n})
pause
goto:eof
:native2ascii2
for /f "skip=1 delims=" %%a in ('findstr /s /i /m /D:"%~1\%~2" "\u" * 2^>nul') do (
	cecho     - "%~2\%%~a"
::	native2ascii -reverse -encoding UTF-8 "%~1\%~2\%%~a" "%~1\%~2\%%~a.utf-8"
	java -jar "!plugdir!UnicodeEscape2UTF8.jar" "%~1\%~2\%%~a" >"%~1\%~2\%%~a.utf-8" 2>>nul
	if errorlevel 1 (
		set /A error_count+=1
		cecho {!colR!} !str_converting_error!^^!{# #}{\n}
	) else (
		copy "%~1\%~2\%%~a.utf-8" "%~1\%~2\%%~a" >nul
		echo.
	)
	del /f /q "%~1\%~2\%%~a.utf-8" 2>nul
)