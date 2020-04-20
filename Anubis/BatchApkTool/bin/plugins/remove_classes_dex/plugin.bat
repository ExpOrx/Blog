:: remove_classes_dex v1.4
:: Автор: Andycar (на основе ReplaceRes от bursoft)
:: Плагин предназначен для удаления classes.dex из APK. Для одексированных прошивок (предполагается, что соответствующие .odex файлы у нас уже есть)
:: Ниже указаны некоторые переменные, которые используются при работе плагина:
:: Текущий каталог - папка текущего проекта
:: !plugdir! - каталог плагина\
:: !bindir! - каталог bin\
:: !apk_name! - выбранный APK-файл
:: !sign_after! - состояние опции "Подписать результирующий APK" (ON\OFF)
:: Эти и другие переменные можно найти в BATCHAPKTOOL.bat и в файлах локализации (!bindir!language\*.lng и !plugdir!language\*.lng).
if "%bat_version%"=="" goto:eof
set count2=0
set count3=0
set error_count=0
set delete_classes=ON
set only_if_odex=ON
set sign_files=OFF
set zipalign_files=ON
set inifile="!plugdir!plugin.ini"
set logfile="remove_classes_dex_log.txt"
if exist %inifile% for /f "usebackq tokens=1* delims==" %%a in (%inifile%) do set %%a=%%b
:begin
cls
echo.
cecho {!colG!}!bat_title!{# #}{\n}
echo !bat_page!
echo !bat_line!
echo.
cecho {!colG!}!str_plugin_name!{# #}{\n}
echo.
echo   01  !str_opt_del_classes! : !str_%delete_classes%!
echo   02  - !str_opt_only_if_odex_exist! : !str_%only_if_odex%!
echo   03  !str_opt_sign! : !str_%sign_files%!
echo   04  !str_opt_zipalign! : !str_%zipalign_files%!
echo.
echo   1   !str_process_system!
echo   2   !str_process_input_apk!
echo   3   !str_process_input_jar!
echo.
echo   0   !str_cancel!
echo.
:_make_choice
set INPUT=
SET /P INPUT=!str_makechoice! 
IF !INPUT!==01 (
	if %delete_classes%==ON (set delete_classes=OFF) else (set delete_classes=ON)
	goto savesettings
)
IF !INPUT!==02 (
	if %only_if_odex%==ON (set only_if_odex=OFF) else (set only_if_odex=ON)
	goto savesettings
)
IF !INPUT!==03 (
	if %sign_files%==ON (set sign_files=OFF) else (set sign_files=ON)
	goto savesettings
)
IF !INPUT!==04 (
	if %zipalign_files%==ON (set zipalign_files=OFF) else (set zipalign_files=ON)
	goto savesettings
)
IF !INPUT!==1 (goto _system)
IF !INPUT!==2 (goto _INPUT_APK)
IF !INPUT!==3 (goto _INPUT_JAR)
IF !INPUT!==0 (goto:eof)
goto _make_choice
:savesettings
echo delete_classes=%delete_classes%>%inifile%
echo only_if_odex=%only_if_odex%>>%inifile%
echo sign_files=%sign_files%>>%inifile%
echo zipalign_files=%zipalign_files%>>%inifile%
goto begin
:_system
call :show_header
FOR /f "delims=" %%a IN ('sfk list -quiet -quot -dir _system -minsize^=22b -file .jar .apk 2^>nul') DO (set /A count2+=1)
FOR /f "delims=" %%a IN ('sfk list -quiet -quot -dir _system -minsize^=22b -file .jar .apk 2^>nul') DO (
	call :do_job "%%~a" "%%~a"
)
goto job_done
:_INPUT_APK
call :show_header
FOR %%a IN ("_INPUT_APK\!apk_name!") DO (set /A count2+=1)
FOR %%a IN ("_INPUT_APK\!apk_name!") DO (
	call :do_job "%%~a" "_OUT_APK\%%~nxa"
)
goto job_done
:_INPUT_JAR
call :show_header
FOR %%a IN ("_INPUT_JAR\!jar_name!") DO (set /A count2+=1)
FOR %%a IN ("_INPUT_JAR\!jar_name!") DO (
	call :do_job "%%~a" "_OUT_JAR\%%~nxa"
)
goto job_done
:show_header
type nul >%logfile%
echo -------------------------------------------------->>%logfile%
echo Batch ApkTool                : !bat_version!>>%logfile%
echo -------------------------------------------------->>%logfile%
echo.>>%logfile%
goto:eof
:do_job
set /A count3+=1
title !title_text! [!count3!/!count2!]
set job_error=0
if %delete_classes%==ON (
	set odex_exist=1
	if %only_if_odex%==ON (
		call :GetParent "%~1" "parent"
		if "!parent:~0,7!"=="_system" (
			set odex_exist=0
			if /I "%~x1"==".jar" (
				FOR %%b IN (arm arm64 x86 x64 mips mips64) DO (
					if exist "_system\framework\%%b\boot-%~n1.oat" set odex_exist=1
				)
			)
			if exist "!parent!\%~n1.odex" set odex_exist=1
			FOR %%b IN (arm arm64 x86 x64 mips mips64) DO (
				if exist "!parent!\%%b\%~n1.odex" set odex_exist=1
				if exist "!parent!\oat\%%b\%~n1.odex" set odex_exist=1
			)
		)
	)
	if !odex_exist!==1 (
		set file_deodexed=0
		FOR /f "delims=" %%b IN ('7z l -tzip "%~1" classes.dex 2^>nul') DO (
			set x=%%b
			if not !x!==!x:classes.dex=! (set file_deodexed=1)
		)
		if !file_deodexed!==1 (
			if not exist "!plugdir!%~nx1" call :copy_and_log "%~1"
			7z d -tzip "!plugdir!%~nx1" classes*.dex >nul 2>>%logfile%
			if errorlevel 1 (set job_error=1)
		)
	)
)
if /I "%~x1"==".apk" (
	if %sign_files%==ON (
		if !job_error!==0 (
			if not exist "!plugdir!%~nx1" call :copy_and_log "%~1"
			7z d -tzip "!plugdir!%~nx1" META-INF\*.MF META-INF\*.SF META-INF\*.RSA META-INF\*.DSA META-INF\*.EC META-INF\com\android\otacert >nul 2>>%logfile%
			if errorlevel 1 (
				set job_error=1
			) else (
				del /f /q "!plugdir!s_%~nx1" 2>nul
				java -jar %bindir%signapk.jar -w "%bindir%!key_base!.x509.pem" "%bindir%!key_name!" "!plugdir!%~nx1" "!plugdir!s_%~nx1" >nul 2>>%logfile%
				if not "!errorlevel!"=="0" (
					set job_error=1
				) else (
					del /f /q "!plugdir!%~nx1" 2>nul
					ren "!plugdir!s_%~nx1" "%~nx1" >nul
				)
			)
		)
	)
	if %zipalign_files%==ON (
		if !job_error!==0 (
			if not exist "!plugdir!%~nx1" call :copy_and_log "%~1"
			zipalign -f -p 4 "!plugdir!%~nx1" "!plugdir!z_%~nx1" >nul 2>>%logfile%
			if not "!errorlevel!"=="0" (
				set job_error=1
			) else (
				del /f /q "!plugdir!%~nx1" 2>nul
				ren "!plugdir!z_%~nx1" "%~nx1" >nul
			)
		)
	)
)
if !job_error!==0 (
	if exist "!plugdir!%~nx1" (
		ATTRIB -R "%~2" >nul
		COPY "!plugdir!%~nx1" "%~2" >nul
		echo.
	)
) else (
	set /A error_count+=1
	cecho {!colR!} !str_error!{# #}{\n}
	echo [*] !str_error!>>%logfile%
)
del /f /q "!plugdir!%~nx1" "!plugdir!s_%~nx1" "!plugdir!z_%~nx1" 2>nul
goto:eof
:GetParent "input_string" "var_with_string_before_backslash" "var_with_string_after_backslash"
set "str=%~1"
FOR /L %%P IN (2,1,260) DO (
	if "!str:~-%%P,1!"=="\" (
		set "%~2=!str:~0,-%%P!"
		if not "%~3"=="" (
			set "str=!str:~-%%P!"
			set "%~3=!str:\=!"
		)
		goto:eof
	)
)
set "%~2="
if not "%~3"=="" (set "%~3=%~1")
goto:eof
:copy_and_log
cecho [*] !str_replacing! %~nx1...
echo [*] !str_replacing! %~nx1>>%logfile%
copy "%~1" "!plugdir!" >nul
goto:eof
:job_done
echo.
echo.>>%logfile%
if !error_count! GTR 0 (
	echo %str_doneerrors%>>%logfile%
	cecho {!colR!}%str_doneerrors%{# #}{\n}
) else (
	echo !str_done!>>%logfile%
	cecho {!colG!}!str_done!{# #}{\n}
)
nhrt -cp:!str_codepage!,UTF-8_BOM %logfile% >nul
if %open_log%==ON (
	start "" %logfile%
	pause
) else (
	SET INPUT=
	SET /P INPUT=!str_press1! 
	IF !INPUT!==1 start "" %logfile%
)
