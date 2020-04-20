if "%bat_version%"=="" goto:eof
cls
echo.
cecho {!colG!}!bat_title!{# #}{\n}
echo !bat_page!
echo !bat_line!
echo.
if "!apktool:~8,1!"=="1" (
	cecho {!colR!}This plugin works only with apktool 2.x{# #}{\n}
	pause
	goto:eof
)
set exclude=127.apk
for /f %%a in ('copy /Z "%~dpf0" nul') do set "ASCII_CR=%%a"
set count2=0
set count3=0
FOR /f "delims=" %%a IN ('sfk list -quiet -quot -dir _system -file .apk 2^>nul') DO (set /A count2+=1)
if "!count2!"=="0" (
	cecho {!colR!}[*] !str_framework_empty!{# #}{\n}
	pause
	goto:eof
)
FOR /f "delims=" %%a IN ('sfk list -quiet -quot -dir _system\framework -file .apk +then list -quiet -quot -dir _system ^^!_system\framework -file .apk 2^>nul') DO (
	set /A count3+=1
	title !title_text! [!count3!/!count2!]
	set "str=[*] %%~a#"
	set len=0
	for %%P in (4096 2048 1024 512 256 128 64 32 16 8 4 2 1) do (
		if "!str:~%%P,1!" NEQ "" (
			set /a "len+=%%P"
			set "str=!str:~%%P!"
		)
	)
	if !len! LEQ 104 (
		<nul set /p "=[*] %%~a!ASCII_CR!"
	)
	FOR /f "tokens=1* delims=:" %%b IN ('java -jar "%bindir%!apktool!" if -p "%bindir%framework" "%%~a" 2^>nul ^| find /I "Framework installed to"') DO (
		if !exclude!==!exclude:%%~nxc=! (
			echo [*] %%~a (%%~nxc^)
			COPY "%%~a" "_framework" >nul
		)
	)
	if !len! LEQ 104 (
		set space=
		FOR /L %%P IN (1,1,!len!) DO set "space=!space! "
		<nul set /p "=_!space!!ASCII_CR!"
	)
)
echo.
pause
