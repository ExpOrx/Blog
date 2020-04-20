::
::	БАТЧХ АПКТООЛ by BurSoft
::
@echo off
set colB=07
set colG=0A
set colR=0C
COLOR %colB%
set "dp0dir=%~dp0"
set "rootdir=%dp0dir:~0,-4%"
setLocal EnableExtensions EnableDelayedExpansion
set OS_PATH=
set xOS=x64& if %PROCESSOR_ARCHITECTURE%==x86 if not defined PROCESSOR_ARCHITEW6432 set xOS=x86
if "%xOS%"=="x64" (set OS_PATH=!dp0dir!bin64;!dp0dir!bin64\jre\bin;!dp0dir!bin64\python3;)
for /f "tokens=4 delims=[.]" %%a in ('ver') do (set vOS=%%a)
if %vOS% LSS 7600 (set OS_PATH=!dp0dir!binXP;!dp0dir!binXP\jre\bin;!dp0dir!binXP\python3;!OS_PATH!)
set PATH=!OS_PATH!!dp0dir!;!dp0dir!jre\bin;!dp0dir!python3;!PATH!;!JAVA_HOME!\bin;!SystemRoot!\Sysnative;!SystemRoot!\system32;!SystemRoot!\SysWOW64
set PATHEXT=.COM;.EXE;.BAT;.CMD;!PATHEXT!
mode con:cols=105 lines=48
if not "%~1"=="launcher" (
	goto:eof
	for /f "tokens=2 delims=," %%a in ('tasklist /V /FI "IMAGENAME eq cmd.exe" /FO CSV /NH ^| find /I "BAT by BurSoft"') do (
		nircmd win activate process /%%~a
		nircmd win flash process /%%~a 2
		goto:eof
	)
)
set title_text=BAT by BurSoft
title !title_text!
cd /d "!dp0dir!"
if not exist language\english.lng (
	COLOR !colR!
	echo ERROR^^!
	echo Batch ApkTool is not fully installed or do not have full access to the folder
	PAUSE
	goto:eof
)
if exist language\lang (
	for /F "usebackq tokens=1* delims==" %%a in ("language\lang") do set %%a=%%b
) else (
	for /f "delims=" %%a in ('chcp') DO set x=%%a
	if not !x!==!x:866=! (set language=russian) else (set language=english)
)
call :__language
set opt=
FOR %%a IN (sfk.exe nircmd.exe nhrt.exe) DO (
	if not exist bin64\%%a if not exist %%a set opt=!opt!%%a 
)
if not "%opt%"=="" (
	COLOR !colR!
	echo !str_error!
	echo !str_necessary_files_missing! (%opt%^)
	PAUSE
	goto:eof
)
set bat_version=3.7.3
set bat_title=                                     BATCH APKTOOL %bat_version% by BurSoft                                     
set bat_page=                                  http://bursoft-portable.blogspot.com
set bat_line=--------------------------------------------------------------------------------------------------------
set logR=log_recompile.txt
set logD=log_decompile.txt
set logX=log_deodex.txt
set TEMP=!TEMP!\BAT_temp
set TMP=!TMP!\BAT_temp
set JAVA_TOOL_OPTIONS=
set _JAVA_OPTIONS=
set PYTHONPATH=
set PYTHONHOME=
set workdir=.
if exist settings.ini (
	for /f "delims=" %%a in ('inifile settings.ini [global_settings]') do %%a
)
COLOR %colB%
set opt=0
echo "!dp0dir!" | FINDSTR /I "%% ^! ^^" >nul 2>nul
if not errorlevel 1 set opt=1
cd /d "!rootdir!"
if errorlevel 1 set opt=1
if %opt%==1 (
	COLOR !colR!
	echo !str_error!
	echo !str_startup_error1!
	PAUSE
	goto:eof
)
type NUL > write_test
if errorlevel 1 (
	COLOR !colR!
	echo !str_error!
	echo !str_startup_error2!
	PAUSE
	goto:eof
) else (
	del /f /q write_test 2>nul
)
md "!TEMP!" "!TMP!" 2>nul
if not exist bin\language\lang (
	set bindir=bin\
	call :setlanguage
)
if "%~1"=="launcher" (
	set jv=%~2
	set jt=%~3
	goto SkipJava
)
for /f "delims=" %%a in ('java -version 2^>^&1') DO (
	set x=%%a
	if not !x!==!x:version=! (
		for /f tokens^=2^ delims^=^" %%b in ("%%a") do (
			set jt=%%b
			for /f "tokens=1 delims=._-" %%c in ("%%b") do (
				if %%c==1 (
					set jv=!jt:~2,1!
					set jt=!jt:~2,1!u!jt:~6!
				) else (
					set jv=%%c
				)
			
			)
		)	
	)
	if not !x!==!x:64-Bit=! (set jt=!jt! x64)
)
:SkipJava
if defined jv (
	set title_text=!title_text! (Java !jt!^)
	title !title_text!
	if !jv! LSS 8 (
		cecho {!colR!}!str_previous_java1! !jt!{# #}{\n}
		cecho {!colR!}!str_previous_java2!{# #}{\n}
		echo !str_get_java!
		PAUSE
	)
) else (
	cecho {!colR!}!str_java_notfound!{# #}{\n}
	echo !str_get_java!
	PAUSE
)
:restart3
cd /d "!rootdir!"
set apktool=apktool.jar
set smali=smali.jar
set api=19
set sign_after=ON
set open_log=MANUAL
set adb_ip=
set apk_name=*
set jar_name=*
set keepbrokenres=ON
set deldebuginfo=OFF
set expert_mode=OFF
set key_name=testkey.pk8
set bindir=bin\
set projdir=..
set framedir=_framework
set deodex_tool=baksmali
set del_symlinks=OFF
set rewrite_check=ON
set sound_notifications=OFF
set save_orig_manifest=OFF
set set_postfix=OFF
set tray_notifications=ON
set backup_resources=ON
set use_aapt2=OFF
set deodex_vdex_tool=vdexExtractor
set adb_mode=off
if not "!workdir!"=="." (
	if exist "!workdir!" (
		cd "!workdir!"
		set bindir=..\bin\
		set projdir=..\!workdir!
	) else (
		set workdir=.
		call :saveglobal "workdir"
	)
)
md _framework _INPUT_APK _INPUT_JAR _OUT_APK _OUT_JAR _system 2>nul
md "%bindir%framework" "%bindir%temp" 2>nul
if exist batchapktool.ini (
	for /f "delims=" %%a in ('inifile batchapktool.ini [settings]') do %%a
)
if not exist "%bindir%!apktool!" (
	FOR %%F IN (%bindir%apktool*.jar) DO set apktool=%%~nxF
	call :savesettings "apktool"
)
if not exist "%bindir%!smali!" (
	FOR %%F IN (%bindir%smali*.jar) DO set smali=%%~nxF
	call :savesettings "smali"
)
:restart2
set apk_base=*
if not "!apk_name!"=="*" (
	if exist "_INPUT_APK\!apk_name!" (
		FOR %%F IN ("!apk_name!") DO set apk_base=%%~nF
	) else (
		set apk_name=*
		call :savesettings "apk_name"
	)
)
set jar_base=*
if not "!jar_name!"=="*" (
	if exist "_INPUT_JAR\!jar_name!" (
		FOR %%F IN ("!jar_name!") DO set jar_base=%%~nF
	) else (
		set jar_name=*
		call :savesettings "jar_name"
	)
)
FOR %%F IN ("!key_name!") DO set key_base=%%~nF
:restart
set old_smali=0
if "!smali:~6,1!"=="1" (set old_smali=1)
if "!smali:~6,3!"=="2.0" (set old_smali=1)
if "!smali:~6,3!"=="2.1" (set old_smali=1)
cls
COLOR %colB%
title !title_text!
echo.
cecho {!colG!}!bat_title!{# #}{\n}
echo !bat_page!
echo !bat_line!
echo   80  !str_project! : !workdir!
echo   81  !str_currentapk! : !apk_name!
echo   82  !str_currentjar! : !jar_name!
echo   83  SMALI                                        : !smali!
echo   84  - !str_apilevel! : %api%
echo   85  APKTOOL                                      : !apktool!
echo   86  - !str_keepbroken! : !str_%keepbrokenres%!
echo   87  - !str_buildexpert! : !str_%expert_mode%!
echo   88  !str_dontwritedebug! : !str_%deldebuginfo%!
echo   89  !str_signafter! : !str_%sign_after%!
echo   90  - !str_key! : !key_name!
echo   91  !str_language! : !language!
echo !bat_line!
cecho {!colG!}SMALI:{# #}{\n}
echo   01  !str_deodexall! 04  !str_baksmaliapk!
echo   02  !str_copy_deodexed_apk! 05  !str_smaliapk!
echo   03  !str_copy_deodexed_jar! 06  !str_baksmalijar!
echo                                                    07  !str_smalijar!
echo !bat_line!
cecho {!colG!}APKTOOL:{# #}{\n}
echo   1   !str_decompile! 4   !str_signfiles!
echo   2   !str_decompile_r! 5   !str_zipalfiles!
echo   3   !str_recompile! 6   !str_viewsource!
echo                                                    7   !str_plugins!
echo !bat_line!
cecho {!colG!}!str_adbmenu!{# #}{\n}
echo   10  !str_devices! 16  !str_screenrecord!
echo   11  !str_install! 17  !str_shell!
echo   12  !str_rootremount! 18  !str_logs!
echo   13  !str_pull! 19  !str_reboot!
echo   14  !str_push! 20  !str_info!
echo   15  !str_screenshot! 21  !str_kill-server!
echo !bat_line!
cecho {!colG!}!str_servicemenu!{# #}{\n}
echo   30  !str_cleanup1! 32  !str_cleanup3!
echo   31  !str_cleanup2! 33  !str_cleanup4!
echo !bat_line!
echo.
if "%~1"=="refresh_menu" (goto:eof)
SET INPUT=
SET /P INPUT=!str_choosetask! 
IF /I !INPUT!==bat (goto about)
IF !INPUT!==80 (goto setproject)
IF !INPUT!==81 (goto setcurrentapk)
IF !INPUT!==82 (goto setcurrentjar)
IF !INPUT!==83 (goto setsbversion)
IF !INPUT!==84 (goto setapi)
IF !INPUT!==85 (goto setapktoolversion)
IF !INPUT!==86 (goto setkeepbrokenres)
IF !INPUT!==87 (goto setexpert_mode)
IF !INPUT!==88 (goto setdeldebuginfo)
IF !INPUT!==89 (goto setsign)
IF !INPUT!==90 (goto setsignkey)
IF !INPUT!==91 (call :setlanguage) & goto restart
IF !INPUT!==01 (goto deodex)
IF !INPUT!==02 (call :copy_files .apk) & goto restart
IF !INPUT!==03 (call :copy_files .jar) & goto restart
IF !INPUT!==04 (goto baksmaliapk)
IF !INPUT!==05 (goto smaliapk)
IF !INPUT!==06 (goto baksmalijar)
IF !INPUT!==07 (goto smalijar)
IF !INPUT!==1 (set opt=& goto decompile)
IF !INPUT!==2 (set opt=-s& goto decompile)
IF !INPUT!==3 (goto recompile)
IF !INPUT!==4 (goto signzip)
IF !INPUT!==5 (goto zipalignoutapks)
IF !INPUT!==6 (goto javasource)
IF !INPUT!==7 (goto plugins)
IF !INPUT!==10 (goto adbdevices)
IF !INPUT!==11 (goto adbinstall)
IF !INPUT!==12 (goto adbremount)
IF !INPUT!==13 (goto adbpull)
IF !INPUT!==14 (goto adbpush)
IF !INPUT!==15 (goto adbscreenshot)
IF !INPUT!==16 (goto screenrecord)
IF !INPUT!==17 (goto adbshell)
IF !INPUT!==18 (goto adblogs)
IF !INPUT!==19 (goto adbreboot)
IF !INPUT!==20 (goto adbinfo)
IF !INPUT!==21 (goto adbexit)
IF !INPUT!==30 (call :clean "_framework _system") & goto restart
IF !INPUT!==31 (call :clean "_INPUT_APK _INPUT_JAR") & goto restart2
IF !INPUT!==32 (call :clean "_OUT_APK _OUT_JAR") & goto restart
IF !INPUT!==33 (call :clean "_framework _INPUT_APK _INPUT_JAR _OUT_APK _OUT_JAR _system") & goto restart2
IF !INPUT!==00 (goto advanced_settings)
goto restart
:advanced_settings
cls
echo.
cecho {!colG!}                                           ADVANCED SETTINGS{# #}{\n}
echo !bat_line!
echo   1  !str_tool_for_deodex!  : !deodex_tool!
echo   2  !str_tool_for_deodex_vdex!  : !deodex_vdex_tool!
echo   3  !str_del_symlinks!  : !str_%del_symlinks%!
echo.
echo   4  !str_manifest_opt!  : !str_%save_orig_manifest%!
echo   5  !str_rewrite_opt!  : !str_%rewrite_check%!
echo   6  Use aapt2 (experimental)                                                : !str_%use_aapt2%!
echo.
echo   7  !str_openlog!  : !str_%open_log%!
echo   8  !str_sound_opt!  : !str_%sound_notifications%!
echo.
echo   9  Run Python's IDLE
echo.
echo   0  Back to main menu
echo.
SET INPUT=
SET /P INPUT=!str_choosetask! 
IF !INPUT!==1 (
	if %deodex_tool%==baksmali (set deodex_tool=oat2dex) else (set deodex_tool=baksmali)
	call :savesettings "deodex_tool"
)
IF !INPUT!==2 (
	if %deodex_vdex_tool%==baksmali (set deodex_vdex_tool=vdexExtractor) else (set deodex_vdex_tool=baksmali)
	call :savesettings "deodex_vdex_tool"
)
IF !INPUT!==3 (
	if %del_symlinks%==OFF (set del_symlinks=ON) else (set del_symlinks=OFF)
	call :savesettings "del_symlinks"
)
IF !INPUT!==4 (
	if %save_orig_manifest%==OFF (set save_orig_manifest=ON)
	if %save_orig_manifest%==ON (set save_orig_manifest=AUTO)
	if %save_orig_manifest%==AUTO (set save_orig_manifest=AUTO+)
	if %save_orig_manifest%==AUTO+ (set save_orig_manifest=OFF)
	call :savesettings "save_orig_manifest"
)
IF !INPUT!==5 (
	if %rewrite_check%==OFF (set rewrite_check=ON) else (set rewrite_check=OFF)
	call :savesettings "rewrite_check"
)
IF !INPUT!==6 (
	if %use_aapt2%==OFF (set use_aapt2=ON) else (set use_aapt2=OFF)
	call :savesettings "use_aapt2"
)
IF !INPUT!==7 (
	if %open_log%==ON (set open_log=MANUAL) else (set open_log=ON)
	call :savesettings "open_log"
)
IF !INPUT!==8 (
	if %sound_notifications%==ON (set sound_notifications=OFF) else (set sound_notifications=ON)
	call :savesettings "sound_notifications"
)
IF !INPUT!==9 (
	start pythonw -m idlelib
)
IF !INPUT!==0 (goto restart)
goto advanced_settings
:: --------------------
:plugins
cecho {!colG!}  !str_selplugin!{# #}{\n}
set count=0
FOR /D %%F IN (%bindir%plugins\*) DO (
	set /A count+=1
	set name!count!=%%~nxF
	set plugin_name=%%~nxF
	if not "!language!"=="english" (
		if exist "%bindir%plugins\%%~nxF\language\!language!.lng" (
			for /F "eol=; tokens=1* delims==" %%a in ('type "%bindir%plugins\%%~nxF\language\!language!.lng"') do (
				if "%%a"=="plugin_name" set %%a=!plugin_name!: %%b
			)
		)
	)
	if "!plugin_name!"=="%%~nxF" (
		if exist "%bindir%plugins\%%~nxF\language\english.lng" (
			for /F "eol=; tokens=1* delims==" %%a in ('type "%bindir%plugins\%%~nxF\language\english.lng"') do (
				if "%%a"=="plugin_name" set %%a=!plugin_name!: %%b
			)
		)
	)
	echo    !count! = !plugin_name!
	set /A MOD=!count! %% 45
	if !MOD! equ 0 pause
)
echo.
echo    0 = !str_cancel!
:_plugins
set INPUT=
set /P INPUT=!str_makechoice! 
if !INPUT!==0 goto restart
if !INPUT! GTR !count! (goto _plugins)
if !INPUT! LSS 1 (goto _plugins)
set "plugdir=!dp0dir!plugins\!name%INPUT%!\"
if exist "!plugdir!system" (
	set system_plugin=1
) else (
	set system_plugin=0
	setLocal EnableExtensions EnableDelayedExpansion
)
echo "!PATH!" | FIND /I "!plugdir!" >nul 2>nul
if errorlevel 1 (set PATH=!plugdir!;!PATH!)
if exist "!plugdir!language\english.lng" (
	for /F "eol=; tokens=1* delims==" %%a in ('type "!plugdir!language\english.lng"') do set str_%%a=%%b
)
if not "!language!"=="english" (
	if exist "!plugdir!language\!language!.lng" (
		for /F "eol=; tokens=1* delims==" %%a in ('type "!plugdir!language\!language!.lng"') do set str_%%a=%%b
	)
)
call "!plugdir!plugin.bat"
if !system_plugin!==0 endLocal
goto restart
:measure_time
set temp_time=!time:~0,2!
if "!temp_time:~0,1!"=="0" set temp_time=!temp_time:~1,1!
set /A temp_time=!temp_time! * 3600 + (1!time:~3,2! - 100) * 60 + 1!time:~6,2! - 100
if %~1==start (
	set start_time=!temp_time!
) else (
	set stop_time=!temp_time!
	if !stop_time! GEQ !start_time! (
		set /A diff_time=!stop_time! - !start_time!
	) else (
		set /A diff_time=!stop_time! + 86400 - !start_time!
	)
	set /A time_h=!diff_time! / 3600
	set /A time_m=(!diff_time! - !time_h! * 3600^) / 60
	set /A time_s=!diff_time! %% 60
	set elapsed_time=
	if not !time_h!==0 set elapsed_time=!time_h! !str_elapsed_h! 
	if not !time_m!==0 set elapsed_time=!elapsed_time!!time_m! !str_elapsed_m! 
	set elapsed_time=!str_elapsed_time!: !elapsed_time!!time_s! !str_elapsed_s!
)
goto:eof
:: --------------------
:install_framework
call :log_version "%~1" "apktool"
if "!apktool:~8,1!"=="1" (
	del /f /q "%USERPROFILE%\apktool\framework\*.apk" 2>nul
) else (
	del /f /q "%bindir%framework\*.apk" 2>nul
)
FOR /f "delims=" %%F IN ('sfk list -quiet -quot "!framedir!" .apk 2^>nul') DO (
	cecho [*] !str_instframe! %%~nxF...
	echo [*] !str_instframe! %%~nxF>>%~1
	if "!apktool:~8,1!"=="1" (
		java -jar "%bindir%!apktool!" if "%%~F" >>%~1 2>&1
	) else (
		java -jar "%bindir%!apktool!" if -p "%bindir%framework" "%%~F" >>%~1 2>&1
	)
	if not "!errorlevel!"=="0" (
		set /A error_count+=1
		cecho {!colR!} !str_error!{# #}{\n}
		echo [*] ---^> !str_instframe_error! %%~nxF>>%~1
	) else (
		echo.
	)
)
goto:eof
:decompile
set count2=0
FOR %%F IN ("_INPUT_APK\!apk_base!.apk") DO (set /A count2+=1)
if %count2%==0 (
	cecho {!colR!}[*] !str_inputapk_empty!{# #}{\n}
	pause
	goto restart
)
if %rewrite_check%==ON (
	call :check_rewrite "_INPUT_APK" "!apk_base!.apk"
	if !_temp_!==0 goto restart
)
call :measure_time start
set error_count=0
call :install_framework "%logD%"
if %keepbrokenres%==ON (set opt=--keep-broken-res %opt%)
if %deldebuginfo%==ON (set opt=-b %opt%)
set count3=0
FOR %%F IN ("_INPUT_APK\!apk_base!.apk") DO (
	set /A count3+=1
	title !title_text! [!count3!/!count2!]
	cecho [*] !str_decompiling! %%~nxF...
	echo.>>%logD%
	echo [*] !str_decompiling! %%~nxF>>%logD%
	rd /s /q "_INPUT_APK\%%~nF" 2>nul
	if "!apktool:~8,1!"=="1" (
		java -jar "%bindir%!apktool!" d -f %opt% "_INPUT_APK\%%~nxF" "_INPUT_APK\%%~nF" >>%logD% 2>&1
	) else (
		java -jar "%bindir%!apktool!" d -f %opt% -o "_INPUT_APK\%%~nF" -p "%bindir%framework" "_INPUT_APK\%%~nxF" >>%logD% 2>&1
	)
	if not "!errorlevel!"=="0" (
		set /A error_count+=1
		cecho {!colR!} !str_error!{# #}{\n}
		echo [*] ---^> !str_decompiling_error! %%~nxF>>%logD%
	) else (
		echo.
	)
	md "_INPUT_APK\%%~nF\_backup" 2>nul
	if %backup_resources%==ON (
		FOR %%a IN (assets lib libs res unknown) DO (
			xcopy "_INPUT_APK\%%~nF\%%a" "_INPUT_APK\%%~nF\_backup\%%a\" /e /h /i /r /q /y >nul 2>nul
		)
	)
	xcopy "_INPUT_APK\%%~nF\original" "_INPUT_APK\%%~nF\_backup\original\" /e /h /i /r /q /y >nul 2>nul
	FOR %%a IN (AndroidManifest.xml apktool.yml) DO (
		copy "_INPUT_APK\%%~nF\%%a" "_INPUT_APK\%%~nF\_backup\" >nul
	)
	if %deldebuginfo%==OFF (
		FOR /D %%S IN ("_INPUT_APK\%%~nF\smali*") DO (
			md "_INPUT_APK\%%~nF\_backup\%%~nxS" 2>nul
			sfk list -time -size -stat -hidden -quiet -relnames "_INPUT_APK\%%~nF\%%~nxS">"_INPUT_APK\%%~nF\_backup\%%~nxS\list.txt" 2>nul
		)
	)
	7z x -tzip "_INPUT_APK\%%~nxF" -o"_INPUT_APK\%%~nF\_backup" *.dex -aoa >nul 2>>%logD%
	ATTRIB +H "_INPUT_APK\%%~nF\_backup" >nul
)
call :done "%logD%"
goto restart
:check_rewrite
set _temp_=1
FOR %%F IN ("%~1\%~2") DO (
	if exist "%~1\%%~nF" (
		cecho {!colR!}!str_warn_rewrite1!{# #}{\n}
		SET INPUT=
		SET /P INPUT=!str_warn_rewrite2! 
		IF '!INPUT!'=='1' goto:eof
		set _temp_=0
		goto:eof
	)
)
goto:eof
:recompile
rd /s /q "!TMP!" 2>nul
md "!TMP!" 2>nul
call :measure_time start
set error_count=0
call :install_framework "%logR%"
set count2=0
set count3=0
set opt=
if %use_aapt2%==ON (set opt=--use-aapt2)
FOR /D %%F IN ("_INPUT_APK\!apk_base!") DO (set /A count2+=1)
FOR /D %%F IN ("_INPUT_APK\!apk_base!") DO (
	set /A count3+=1
	title !title_text! [!count3!/!count2!]
	cecho [*] !str_recompiling! %%~nxF...
	echo.>>%logR%
	echo [*] !str_recompiling! %%~nxF>>%logR%
	rd /s /q "_INPUT_APK\%%~nxF\build" "_INPUT_APK\%%~nxF\dist" 2>nul
	FOR /D %%S IN ("_INPUT_APK\%%~nxF\smali*") DO (
		if exist "_INPUT_APK\%%~nxF\_backup\%%~nxS\list.txt" (
			sfk list -time -size -stat -hidden -quiet -relnames "_INPUT_APK\%%~nxF\%%~nxS">"_INPUT_APK\%%~nxF\_backup\%%~nxS\list2.txt" 2>nul
			FC /B "_INPUT_APK\%%~nxF\_backup\%%~nxS\list.txt" "_INPUT_APK\%%~nxF\_backup\%%~nxS\list2.txt" >nul 2>nul
			if "!errorlevel!"=="0" (
				ren "_INPUT_APK\%%~nxF\%%~nxS" "bat_%%~nxS" >nul
			)
			del /f /q "_INPUT_APK\%%~nxF\_backup\%%~nxS\list2.txt" 2>nul
		)
	)
	FOR %%S IN ("_INPUT_APK\%%~nxF\*.dex") DO (
		ren "_INPUT_APK\%%~nxF\%%~nxS" "%%~nS.bat_dex" >nul
	)
	if "!apktool:~8,1!"=="1" (
		call :rebuild_expert "%%~nxF"
	) else (
		if "%expert_mode%"=="ON" (call :rebuild_expert "%%~nxF") else (call :rebuild_standart "%%~nxF")
	)
	if exist "_INPUT_APK\%%~nxF\dist\%%~nxF.apk" (
		set postfix=
		if %set_postfix%==ON (
			FOR /L %%P IN (1,1,100) DO (
				if exist "_OUT_APK\%%~nxF!postfix!.apk" (
					set postfix=_%%P
				)
			)
		)
		if %sign_after%==ON (
			call :sign "_INPUT_APK\%%~nxF\dist\%%~nxF.apk" "_OUT_APK\%%~nxF!postfix!.apk" "2>>%logR%"
		) else (
			zipalign -f -p 4 "_INPUT_APK\%%~nxF\dist\%%~nxF.apk" "_OUT_APK\%%~nxF!postfix!.apk" >nul 2>>%logR%
		)
	)
	FOR /D %%S IN ("_INPUT_APK\%%~nxF\bat_*") DO (
		set REN2=%%~nxS
		ren "_INPUT_APK\%%~nxF\%%~nxS" "!REN2:~4!" >nul
	)
	FOR %%S IN ("_INPUT_APK\%%~nxF\*.bat_dex") DO (
		ren "_INPUT_APK\%%~nxF\%%~nxS" "%%~nS.dex" >nul
	)
	rd /s /q "_INPUT_APK\%%~nxF\dist" 2>nul
)
call :done "%logR%"
goto restart
:rebuild_expert
if not %backup_resources%==ON (
	cecho {!colG!} EXPERT MODE DISABLED{# #}{\n}
	exit /b 1
)
if not exist "_INPUT_APK\%~1.apk" (
	set /A error_count+=1
	cecho {!colR!} !str_orignotfound!{# #}{\n}
	echo [*] ---^> !str_orignotfound!>>%logR%
	exit /b 1
)
if not exist "_INPUT_APK\%~1\_backup" (
	set /A error_count+=1
	cecho {!colR!} !str_backupnotfound!{# #}{\n}
	echo [*] ---^> !str_backupnotfound!>>%logR%
	exit /b 1
)
if /I "!apktool:~8,6!"=="2.0.0b" (if exist "_INPUT_APK\%~1\unknown" ren "_INPUT_APK\%~1\unknown" "bat_unknown" >nul)
FOR %%F IN (assets lib libs) DO (
	if exist "_INPUT_APK\%~1\%%F" ren "_INPUT_APK\%~1\%%F" "bat_%%F" >nul
)
call :fix_apktool_yml "_INPUT_APK\%~1"
if "!apktool:~8,1!"=="1" (
	pushd "!dp0dir!"
	java -jar "!apktool!" b "!projdir!\_INPUT_APK\%~1" >>!projdir!\%logR% 2>&1
) else (
	java -jar "%bindir%!apktool!" b %opt% -p "%bindir%framework" "_INPUT_APK\%~1" >>%logR% 2>&1
)
if not "!errorlevel!"=="0" (
	if "!apktool:~8,1!"=="1" popd
	set /A error_count+=1
	cecho {!colR!} !str_error!{# #}{\n}
	echo [*] ---^> !str_recompiling_error! "%~1">>%logR%
	exit /b 1
)
if "!apktool:~8,1!"=="1" popd
echo.
FOR /D %%S IN ("_INPUT_APK\%~1\bat_*") DO (
	set REN2=%%~nxS
	ren "_INPUT_APK\%~1\%%~nxS" "!REN2:~4!" >nul
)
copy "_INPUT_APK\%~1.apk" "_INPUT_APK\%~1\dist\" >nul
rd /s /q "_INPUT_APK\%~1\_backup\upd" 2>nul
md "_INPUT_APK\%~1\_backup\upd" 2>nul
FOR %%F IN (assets lib libs unknown) DO (
	if exist "_INPUT_APK\%~1\%%F" (
		FOR /f "tokens=1* delims= " %%a IN ('sfk list -hidden -quiet -quot -relnames "_INPUT_APK\%~1\%%F" -sincedir "_INPUT_APK\%~1\_backup\%%F" 2^>nul') DO (
			if /I %%F==assets (call :copy2 "_INPUT_APK\%~1\assets\%%~b" "_INPUT_APK\%~1\_backup\upd\0\assets\%%~b")
			if /I %%F==lib (call :copy2 "_INPUT_APK\%~1\lib\%%~b" "_INPUT_APK\%~1\_backup\upd\9\lib\%%~b")
			if /I %%F==libs (call :copy2 "_INPUT_APK\%~1\libs\%%~b" "_INPUT_APK\%~1\_backup\upd\9\libs\%%~b")
			if /I %%F==unknown (call :copy2 "_INPUT_APK\%~1\unknown\%%~b" "_INPUT_APK\%~1\_backup\upd\0\%%~b")
		)
		FOR /f "tokens=1* delims= " %%a IN ('sfk list -hidden -quiet -quot -relnames "_INPUT_APK\%~1\_backup\%%F" -sinceadd "_INPUT_APK\%~1\%%F" 2^>nul') DO (
			if /I %%F==assets (echo assets\%%~b>>"_INPUT_APK\%~1\_backup\upd\delete.list")
			if /I %%F==lib (echo lib\%%~b>>"_INPUT_APK\%~1\_backup\upd\delete.list")
			if /I %%F==libs (echo libs\%%~b>>"_INPUT_APK\%~1\_backup\upd\delete.list")
			if /I %%F==unknown (echo %%~b>>"_INPUT_APK\%~1\_backup\upd\delete.list")
		)
	)
)
set COPYRES=0
if exist "_INPUT_APK\%~1\res\values" (
	FOR /f "tokens=1* delims= " %%a IN ('sfk list -hidden -quiet -quot -relnames -dir "_INPUT_APK\%~1\res" -sub values* -sincedir "_INPUT_APK\%~1\_backup\res" 2^>nul') DO (
		set COPYRES=1
	)
	FOR /f "tokens=1* delims= " %%a IN ('sfk list -hidden -quiet -quot -relnames -dir "_INPUT_APK\%~1\_backup\res" -sub values* -sinceadd "_INPUT_APK\%~1\res" 2^>nul') DO (
		set COPYRES=1
	)
)
if exist "_INPUT_APK\%~1\res" (
	FOR /f "tokens=1* delims= " %%a IN ('sfk list -hidden -quiet -quot -relnames -dir "_INPUT_APK\%~1\res" ^^!values* -sincedif "_INPUT_APK\%~1\_backup\res" 2^>nul') DO (
		call :copy2 "_INPUT_APK\%~1\build\apk\res\%%~b" "_INPUT_APK\%~1\_backup\upd\0\res\%%~b"
	)
	FOR /f "tokens=1* delims= " %%a IN ('sfk list -hidden -quiet -quot -relnames -dir "_INPUT_APK\%~1\res" ^^!values* -sinceadd "_INPUT_APK\%~1\_backup\res" 2^>nul') DO (
		set COPYRES=1
		call :copy2 "_INPUT_APK\%~1\build\apk\res\%%~b" "_INPUT_APK\%~1\_backup\upd\0\res\%%~b"
	)
	FOR /f "tokens=1* delims= " %%a IN ('sfk list -hidden -quiet -quot -relnames -dir "_INPUT_APK\%~1\_backup\res" ^^!values* -sinceadd "_INPUT_APK\%~1\res" 2^>nul') DO (
		set COPYRES=1
		echo res\%%~b>>"_INPUT_APK\%~1\_backup\upd\delete.list"
	)
)
if !COPYRES!==1 (
	call :copy2 "_INPUT_APK\%~1\build\apk\resources.arsc" "_INPUT_APK\%~1\_backup\upd\0\resources.arsc"
)
call :check_manifest "%~1"
if !manifest_changed!==1 (
	call :copy2 "_INPUT_APK\%~1\build\apk\AndroidManifest.xml" "_INPUT_APK\%~1\_backup\upd\9\AndroidManifest.xml"
)
FOR %%S IN ("_INPUT_APK\%~1\build\apk\*.dex") DO (
	call :copy2 "_INPUT_APK\%~1\build\apk\%%~nxS" "_INPUT_APK\%~1\_backup\upd\9\%%~nxS"
)
if exist "_INPUT_APK\%~1\_backup\upd\delete.list" (
	7z d -tzip "_INPUT_APK\%~1\dist\%~1.apk" @"_INPUT_APK\%~1\_backup\upd\delete.list" -scs!str_codepage! >nul 2>nul
	if errorlevel 1 (
		zip -d -ic "_INPUT_APK\%~1\dist\%~1.apk" * -i@"_INPUT_APK\%~1\_backup\upd\delete.list" >nul 2>>%logR%
	)
)
if exist "_INPUT_APK\%~1\_backup\upd\9" (
	7z a -tzip "_INPUT_APK\%~1\dist\%~1.apk" ".\_INPUT_APK\%~1\_backup\upd\9\*" -mx7 >nul 2>nul
	if errorlevel 1 (
		pushd "_INPUT_APK\%~1\_backup\upd\9"
		zip -r -7 "..\..\..\dist\%~1.apk" * >nul 2>>..\..\..\..\..\%logR%
		popd
	)
)
if exist "_INPUT_APK\%~1\_backup\upd\0" (
	7z a -tzip "_INPUT_APK\%~1\dist\%~1.apk" ".\_INPUT_APK\%~1\_backup\upd\0\*" -mx0 >nul 2>nul
	if errorlevel 1 (
		pushd "_INPUT_APK\%~1\_backup\upd\0"
		zip -r -0 "..\..\..\dist\%~1.apk" * >nul 2>>..\..\..\..\..\%logR%
		popd
	)
)
7z a -tzip "_INPUT_APK\%~1\dist\%~1.apk" ".\_INPUT_APK\%~1\build\apk\res" -up1q1r2x1y1z1w1 -mx0 >nul 2>nul
if errorlevel 1 (
	if exist "_INPUT_APK\%~1\build\apk" (
		pushd "_INPUT_APK\%~1\build\apk"
		zip -r -0 "..\..\dist\%~1.apk" res >nul 2>>..\..\..\..\%logR%
		popd
	)
)
rd /s /q "_INPUT_APK\%~1\_backup\upd" 2>nul
goto:eof
:copy2
if exist "%~1" (
	if not exist "%~dp2" md "%~dp2" 2>nul
	COPY "%~1" "%~dp2" >nul
)
goto:eof
:rebuild_standart
if not exist "_INPUT_APK\%~1\_backup" (
	set /A error_count+=1
	cecho {!colR!} !str_backupnotfound!{# #}{\n}
	echo [*] ---^> !str_backupnotfound!>>%logR%
	exit /b 1
)
call :fix_apktool_yml "_INPUT_APK\%~1"
java -jar "%bindir%!apktool!" b %opt% -p "%bindir%framework" "_INPUT_APK\%~1" >>%logR% 2>&1
if not "!errorlevel!"=="0" (
	set /A error_count+=1
	cecho {!colR!} !str_error!{# #}{\n}
	echo [*] ---^> !str_recompiling_error! "%~1">>%logR%
	exit /b 1
)
echo.
7z a -tzip "_INPUT_APK\%~1\dist\%~1.apk" ".\_INPUT_APK\%~1\original\META-INF" -mx7 >nul 2>nul
set _temp_=0
if %save_orig_manifest%==ON set _temp_=1
if %save_orig_manifest%==AUTO (
	call :check_manifest "%~1"
	if !manifest_changed!==0 set _temp_=1
)
if %save_orig_manifest%==AUTO+ (
	if %sign_after%==OFF (
		call :check_manifest "%~1"
		if !manifest_changed!==0 set _temp_=1
	)
)
if %_temp_%==1 (
	7z a -tzip "_INPUT_APK\%~1\dist\%~1.apk" ".\_INPUT_APK\%~1\original\AndroidManifest.xml" -mx7 >nul 2>nul
)
7z a -tzip "_INPUT_APK\%~1\dist\%~1.apk" ".\_INPUT_APK\%~1\_backup\*.dex" -up1q1r2x1y1z1w1 -mx7 >nul 2>nul
goto:eof
:fix_apktool_yml
set yml_line=0
if exist "%~1\apktool.yml" (
	FOR /f "delims=" %%a IN ('yq_windows read "%~1\apktool.yml" doNotCompress 2^>nul') DO (set /A yml_line+=1)
)
if !yml_line! LSS 100 (goto:eof)
set yml_ext_count=0
FOR /f "delims=" %%a IN ('yq_windows read "%~1\apktool.yml" doNotCompress 2^>nul') DO (
	set "yml_line=%%~a"
	if "!yml_line:~0,2!"=="- " (
		FOR /f "delims=" %%b IN ("!yml_line:~2!") DO (set "yml_ext=%%~xb")
		if "!yml_ext!"=="" set "yml_ext=.!yml_line:~2!"
		set _temp_=0
		FOR /L %%c IN (1,1,!yml_ext_count!) DO (
			if /I "!yml_ext!"==".!yml_ext_%%c!" set _temp_=1
		)
		if !_temp_!==0 (
			set /A yml_ext_count+=1
			set "yml_ext_!yml_ext_count!=!yml_ext:~1!"
		)
	)
)
echo doNotCompress:>"%~1\apktool_fix.yml"
FOR /L %%c IN (1,1,!yml_ext_count!) DO (
	echo - !yml_ext_%%c!>>"%~1\apktool_fix.yml"
)
yq_windows merge -i -x "%~1\apktool.yml" "%~1\apktool_fix.yml" >>%logR% 2>&1
del /f /q "%~1\apktool_fix.yml" 2>nul
goto:eof
:check_manifest
set manifest_changed=0
FC /B "_INPUT_APK\%~1\AndroidManifest.xml" "_INPUT_APK\%~1\_backup\AndroidManifest.xml" >nul 2>nul
if not "!errorlevel!"=="0" (
	set manifest_changed=1
	goto:eof
)
FC /B "_INPUT_APK\%~1\apktool.yml" "_INPUT_APK\%~1\_backup\apktool.yml" >nul 2>nul
if "!errorlevel!"=="0" (
	goto:eof
)
set yml1=0
set yml2=0
for /F tokens^=1^,3^ delims^=^:^'^" %%a in ('type "_INPUT_APK\%~1\apktool.yml"') do (
	if /I "%%a"=="  minSdkVersion" (set yml1=!yml1!%%b)
	if /I "%%a"=="  targetSdkVersion" (set yml1=!yml1!%%b)
	if /I "%%a"=="  versionCode" (set yml1=!yml1!%%b)
	if /I "%%a"=="  versionName" (set yml1=!yml1!%%b)
)
for /F tokens^=1^,3^ delims^=^:^'^" %%a in ('type "_INPUT_APK\%~1\_backup\apktool.yml"') do (
	if /I "%%a"=="  minSdkVersion" (set yml2=!yml2!%%b)
	if /I "%%a"=="  targetSdkVersion" (set yml2=!yml2!%%b)
	if /I "%%a"=="  versionCode" (set yml2=!yml2!%%b)
	if /I "%%a"=="  versionName" (set yml2=!yml2!%%b)
)
if /I not "!yml1!"=="!yml2!" (set manifest_changed=1)
goto:eof
:signzip
set error_count=0
call :measure_time start
FOR %%F IN ("_INPUT_APK\!apk_name!") DO (
	echo [*] !str_signing! %%~nxF...
	call :sign "%%~F" "_OUT_APK\%%~nxF" ""
)
echo.
if !error_count! GTR 0 (cecho {!colR!}%str_doneerrors%{# #}{\n}) else (cecho {!colG!}!str_done!{# #}{\n})
call :measure_time stop
echo !elapsed_time!
pause
goto restart
:sign
set sign_error=0
COPY "%~1" "%bindir%temp\%~n1_%~x1" >nul
7z d -tzip "%bindir%temp\%~n1_%~x1" META-INF\*.MF META-INF\*.SF META-INF\*.RSA META-INF\*.DSA META-INF\*.EC META-INF\com\android\otacert >nul 2>nul
if errorlevel 1 (
	zip -d -ic "%bindir%temp\%~n1_%~x1" META-INF/*.MF META-INF/*.SF META-INF/*.RSA META-INF/*.DSA META-INF/*.EC META-INF/com/android/otacert >nul %~3
)
if /I "%~x1"==".apk" (
	del /f /q "%bindir%temp\%~n1__%~x1" 2>nul
	java -jar "%bindir%signapk.jar" -w "%bindir%!key_base!.x509.pem" "%bindir%!key_name!" "%bindir%temp\%~n1_%~x1" "%bindir%temp\%~n1__%~x1" >nul %~3
	if "!errorlevel!"=="0" (
		zipalign -f -p 4 "%bindir%temp\%~n1__%~x1" "%~2" >nul %~3
		if not "!errorlevel!"=="0" (
			set sign_error=1
		)
	) else (
		set sign_error=1
	)
) else (
	del /f /q "%~2" 2>nul
	java -jar "%bindir%signapk.jar" -w "%bindir%!key_base!.x509.pem" "%bindir%!key_name!" "%bindir%temp\%~n1_%~x1" "%~2" >nul %~3
	if not "!errorlevel!"=="0" (
		set sign_error=1
	)
)
if "!sign_error!"=="1" (
	set /A error_count+=1
	cecho {!colR!}[*] !str_signing_error! "%~nx1"{# #}{\n}
)
del /f /q "%bindir%temp\%~n1_%~x1" "%bindir%temp\%~n1__%~x1" 2>nul
goto:eof
:zipalignoutapks
set error_count=0
call :measure_time start
FOR %%F IN ("_INPUT_APK\!apk_name!") DO (
	echo [*] !str_zipal! %%~nxF...
	zipalign -f -p 4 "_INPUT_APK\%%~nxF" "_OUT_APK\%%~nxF" >nul
	if not "!errorlevel!"=="0" (
		set /A error_count+=1
		cecho {!colR!}[*] !str_zipal_error! %%~nxF{# #}{\n}
	)
)
echo.
if !error_count! GTR 0 (cecho {!colR!}%str_doneerrors%{# #}{\n}) else (cecho {!colG!}!str_done!{# #}{\n})
call :measure_time stop
echo !elapsed_time!
pause
goto restart
:javasource
cecho {!colG!}  !str_selectviewer!{# #}{\n}
echo    1 = procyon
echo    2 = jadx
echo.
echo    0 = !str_cancel!
:_javasource
set INPUT=
SET /P INPUT=!str_makechoice! 
IF !INPUT!==1 (goto javasource-jd-gui)
IF !INPUT!==2 (goto javasource-jadx)
IF !INPUT!==0 (goto restart)
goto _javasource
:javasource-jadx
set temp_name=
for /f "delims=" %%a in ('FileToOpen "set temp_name=" "!cd!\*.apk;*.jar;*.dex" "!str_dragajd!"') do %%a
if not '!temp_name!'=='' (
	start cmd /c %bindir%jadx\bin\jadx-gui.bat !temp_name!
)
goto restart
:javasource-jd-gui
set temp_name=
for /f "delims=" %%a in ('FileToOpen "set temp_name=" "!cd!\*.apk;*.jar;*.dex" "!str_dragajd!"') do %%a
if not '!temp_name!'=='' (
	FOR %%F IN (!temp_name!) DO (
		echo [*] !str_genjava! %%~nxF...
		del /f /q "%bindir%enjarify\jar\%%~nF.jar" 2>nul
		md "%bindir%enjarify\jar" 2>nul
		call %bindir%enjarify\enjarify.bat -f -o "%bindir%enjarify\jar\%%~nF.jar" !temp_name! >nul 2>nul
		if exist "%bindir%enjarify\jar\%%~nF.jar" (
			start javaw -jar %bindir%procyon\luyten.jar "%bindir%enjarify\jar\%%~nF.jar"
		) else (
			cecho {!colR!}[*] !str_genjava_error! %%~nxF{# #}{\n}
			pause
		)
	)
)
goto restart
:: --------------------
:log_version
echo -------------------------------------------------->%~1
echo Batch ApkTool                : !bat_version!>>%~1
if '%~2'=='apktool' (
	echo APKTOOL                      : !apktool!>>%~1
	if %use_aapt2%==ON (
		echo Use aapt2 (experimental^)     : !str_%use_aapt2%!>>%~1
	)
	echo !str_buildexpert_log! : !str_%expert_mode%!>>%~1
	if %expert_mode%==OFF (
		if not %save_orig_manifest%==OFF (
			echo Save AndroidManifest.xml     : !str_%save_orig_manifest%!>>%~1
		)
	)
	echo !str_signafter_log! : !str_%sign_after%!>>%~1
)
if '%~2'=='smali' (
	echo SMALI                        : !smali!>>%~1
	echo !str_apilevel_log! : !api!>>%~1
	echo !str_signafter_log! : !str_%sign_after%!>>%~1
)
if '%~2'=='smali-jar' (
	echo SMALI                        : !smali!>>%~1
	echo !str_apilevel_log! : !api!>>%~1
)
if '%~2'=='deodex' (
	echo SMALI                        : !smali!>>%~1
	echo !str_apilevel_log! : !api!>>%~1
)
if '%~2'=='deodex_oat2dex' (
	echo SMALI                        : oat2dex>>%~1
	echo !str_apilevel_log! : !api!>>%~1
)
if '%~2'=='deodex_vdex' (
	echo SMALI                        : vdexExtractor>>%~1
	echo !str_apilevel_log! : !api!>>%~1
)
echo -------------------------------------------------->>%~1
echo.>>%~1
goto:eof
:done
echo.>>%~1
if !error_count! GTR 0 (
	echo %str_doneerrors%>>%~1
) else (
	echo !str_done!>>%~1
)
call :measure_time stop
echo !elapsed_time! >>%~1
::rem convert logfiles to UTF8
::sfk atou "%~1" -codepage=!str_codepage! -tofile "%~1" >nul
nhrt -sre:"([^^\r])\n" -fet:"$1\r\n" -cp:!str_codepage!,UTF-8_BOM "%~1" >nul
echo.
if !error_count! GTR 0 (
	cecho {!colR!}%str_doneerrors%{# #}{\n}
	echo !elapsed_time!
	if %tray_notifications%==ON (
		start nircmd trayballoon "Batch ApkTool" "%str_doneerrors%" "!rootdir!\BatchApkTool.exe" 3000
	)
	if %sound_notifications%==ON (
		start nircmd speak text "Done with errors"
	)
) else (
	cecho {!colG!}!str_done!{# #}{\n}
	echo !elapsed_time!
	if %tray_notifications%==ON (
		start nircmd trayballoon "Batch ApkTool" "!str_done!" "!rootdir!\BatchApkTool.exe" 3000
	)
	if %sound_notifications%==ON (
		start nircmd speak text "Done"
	)
)
if %open_log%==ON (
	start %~1
	pause
) else (
	SET INPUT=
	SET /P INPUT=!str_press1! 
	IF !INPUT!==1 start %~1
)
goto:eof
:get_date_time
set DATE2=!DATE:/=-!
set TIME2=!TIME::=.!
set TIME2=!TIME2:~0,-3!
goto:eof
:clean
cecho  {!colR!}!str_deletedialog!{# #} %~1{\n}
cecho  {!colG!}!str_proceed!{# #}{\n}
echo    1 = !str_yes!
echo    0 = !str_cancel!
:_clean
set INPUT=
set /P INPUT=!str_makechoice! 
if !INPUT!==0 goto:eof
IF !INPUT!==1 (
	rd /s /q %~1 2>nul
	md %~1 2>nul
	cecho {!colG!}!str_done!{# #}{\n}
	pause
	goto:eof
)
goto _clean
:: --------------------
:setproject
cd /d "!rootdir!"
set bindir=bin\
set count=2
cecho {!colG!}  !str_selproj!{# #}{\n}
echo    1 = !str_usedefproj!
echo    2 = !str_createnewproj!
FOR /D %%F IN (*) DO (
	set x=%%~F
	if !x!==!x:_framework=! (
	if /I not "%%~F"=="_INPUT_APK" (
	if /I not "%%~F"=="_INPUT_JAR" (
	if /I not "%%~F"=="_OUT_APK" (
	if /I not "%%~F"=="_OUT_JAR" (
	if /I not "%%~F"=="_system" (
	if /I not "%%~F"=="bin" (
		set /A count+=1
		set name!count!=%%~nxF
		echo    !count! = %%~nxF
	)
	)
	)
	)
	)
	)
	)
	)
	)
)
echo.
echo    0 = !str_cancel!
:_setproject
set INPUT=
set /P INPUT=!str_makechoice! 
if !INPUT!==0 goto restart
if !INPUT! GTR !count! (goto _setproject)
if !INPUT! LSS 1 (goto _setproject)
set name1=.
:_project
if !INPUT!==2 (
	set name2=
	set /P name2=!str_inputprojname! 
	if '!name2!'=='' goto _project
)
set workdir=!name%INPUT%!
md "!workdir!" 2>nul
call :saveglobal "workdir"
goto restart3
:setcurrentapk
set temp_name=*
for /f "delims=" %%a in ('FileToOpen "set temp_name=" "!cd!\_INPUT_APK\*.apk;*.zip;*.jar" "!str_selectapk!"') do %%a
if not '!temp_name!'=='*' (
	FOR %%F IN (!temp_name!) DO (
		if /I !temp_name!=="!cd!\_INPUT_APK\%%~nxF" (
			set temp_name=%%~nxF
		) else (
			goto setcurrentapk
		)
	)
)
if not '!temp_name!'=='!apk_name!' (
	set apk_name=!temp_name!
	call :savesettings "apk_name"
	goto restart2
)
goto restart
:setcurrentjar
set temp_name=*
for /f "delims=" %%a in ('FileToOpen "set temp_name=" "!cd!\_INPUT_JAR\*.jar" "!str_selectjar!"') do %%a
if not '!temp_name!'=='*' (
	FOR %%F IN (!temp_name!) DO (
		if /I !temp_name!=="!cd!\_INPUT_JAR\%%~nxF" (
			set temp_name=%%~nxF
		) else (
			goto setcurrentjar
		)
	)
)
if not '!temp_name!'=='!jar_name!' (
	set jar_name=!temp_name!
	call :savesettings "jar_name"
	goto restart2
)
goto restart
:setapktoolversion
set count=0
cecho {!colG!}  !str_selectapktool!{# #}{\n}
FOR %%F IN (%bindir%apktool*.jar) DO (
	set /A count+=1
	set name!count!=%%~nxF
	echo    !count! = %%~nxF
)
echo.
echo    0 = !str_cancel!
:_apktoolversion
set INPUT=
set /P INPUT=!str_makechoice! 
if !INPUT!==0 goto restart
if !INPUT! GTR !count! (goto _apktoolversion)
if !INPUT! LSS 1 (goto _apktoolversion)
set apktool=!name%INPUT%!
call :savesettings "apktool"
goto restart
:setsbversion
set count=0
cecho {!colG!}  !str_selectsmali!{# #}{\n}
FOR %%F IN (%bindir%smali*.jar) DO (
	set /A count+=1
	set name!count!=%%~nxF
	echo    !count! = %%~nxF
)
echo.
echo    0 = !str_cancel!
:_sbversion
set INPUT=
set /P INPUT=!str_makechoice! 
if !INPUT!==0 goto restart
if !INPUT! GTR !count! (goto _sbversion)
if !INPUT! LSS 1 (goto _sbversion)
set smali=!name%INPUT%!
call :savesettings "smali"
goto restart
:setapi
echo !bat_line!
cecho {!colG!}  !str_apilevels! !str_aversions!{# #}{\n}
echo !bat_line!
echo   28              Android 9.0 (P)
echo   27              Android 8.1 (O_MR1)
echo   26              Android 8.0 (O)
echo   25              Android 7.1 (N_MR1)
echo   24              Android 7.0 (N)
echo   23              Android 6.0 (M)
echo   22              Android 5.1 (LOLLIPOP_MR1)
echo   21              Android 5.0 (LOLLIPOP)
echo   19              Android 4.4 (KITKAT)
echo   18              Android 4.3 (JELLY_BEAN_MR2)
echo   17              Android 4.2 (JELLY_BEAN_MR1)
echo   16              Android 4.1 (JELLY_BEAN)
echo   15              Android 4.0 (ICE_CREAM_SANDWICH)
echo   10              Android 2.3 (GINGERBREAD)
echo.
echo    0 = !str_cancel!
:_api
set INPUT=
set /P INPUT=!str_enterapi! 
if !INPUT!==0 goto restart
::set x=-10-15-16-17-18-19-
::if !x!==!x:-%INPUT%-=! (
if !INPUT! GTR 28 (
	cecho {!colR!}!str_invalidapi!{# #}{\n}
	goto _api
)
if !INPUT! LSS 1 (
	cecho {!colR!}!str_invalidapi!{# #}{\n}
	goto _api
)
set api=!INPUT!
call :savesettings "api"
goto restart
:setsignkey
set count=0
cecho {!colG!}  !str_selectkey!{# #}{\n}
FOR %%F IN (%bindir%*.pk8) DO (
	set /A count+=1
	set name!count!=%%~nxF
	echo    !count! = %%~nxF
)
echo.
echo    0 = !str_cancel!
:_signkey
set INPUT=
set /P INPUT=!str_makechoice! 
if !INPUT!==0 goto restart
if !INPUT! GTR !count! (goto _signkey)
if !INPUT! LSS 1 (goto _signkey)
set key_name=!name%INPUT%!
call :savesettings "key_name"
goto restart2
:setlanguage
set count=0
cecho {!colG!}!str_selectlang!{# #}{\n}
FOR %%F IN (%bindir%language\*.lng) DO (
	set /A count+=1
	set name!count!=%%~nF
	echo   !count! = %%~nF
)
:_language
set INPUT=
set /P INPUT=!str_makechoice! 
if !INPUT! GTR !count! (goto _language)
if !INPUT! LSS 1 (goto _language)
set language=!name%INPUT%!
echo language=!language!>%bindir%language\lang
:__language
chcp 1252>nul
for /F "eol=; tokens=1* delims==" %%a in ('type "%bindir%language\english.lng"') do set str_%%a=%%b
if "!language!"=="english" goto:eof
for /F "eol=; tokens=1* delims==" %%a in ('type "%bindir%language\!language!.lng"') do (
	if "%%a"=="codepage" chcp %%b>nul
)
for /F "eol=; tokens=1* delims==" %%a in ('type "%bindir%language\!language!.lng"') do set str_%%a=%%b
goto:eof
:setkeepbrokenres
if %keepbrokenres%==ON (set keepbrokenres=OFF) else (set keepbrokenres=ON)
call :savesettings "keepbrokenres"
goto restart
:setdeldebuginfo
if %deldebuginfo%==ON (set deldebuginfo=OFF) else (set deldebuginfo=ON)
call :savesettings "deldebuginfo"
goto restart
:setsign
if %sign_after%==ON (set sign_after=OFF) else (set sign_after=ON)
call :savesettings "sign_after"
goto restart
:setexpert_mode
if %expert_mode%==ON (set expert_mode=OFF) else (set expert_mode=ON)
call :savesettings "expert_mode"
goto restart
:savesettings
if not exist batchapktool.ini type nul >batchapktool.ini
inifile batchapktool.ini [settings] "%~1=!%~1!"
goto:eof
:saveglobal
if not exist "%bindir%settings.ini" type nul >"%bindir%settings.ini"
start /B inifile "%bindir%settings.ini" [global_settings] "%~1=!%~1!"
goto:eof
:: --------------------
:deodex
if exist "_system\build.prop" (
FOR /f "tokens=1* delims==" %%a IN ('type "_system\build.prop"') DO (
	if /I "%%~a"=="ro.build.version.sdk" (
		if not "%%~b"=="%api%" (
			set api=%%~b
			call :savesettings "api"
			call :restart "refresh_menu"
		)
	)
)
)
set count=0
FOR %%F IN (_system\framework\*.*) DO set /A count+=1
if %count% LSS 5 (
	cecho {!colR!}[*] !str_framework_empty!{# #}{\n}
	pause
)
set error_count=0
call :measure_time start
if %api% GEQ 21 (goto deodex_oat2dex)
call :log_version "%logX%" "deodex"
if %old_smali%==1 (
	set opt_b=-x
	set opt_s=
) else (
	set opt_b=x
	set opt_s=a
)
if exist "%bindir%inline.txt" (set opt_b=%opt_b% --inline-table %bindir%inline.txt)
set count2=0
set count3=0
FOR /f "delims=" %%F IN ('sfk list -quiet -quot -dir _system -minsize^=22b -file .jar .apk 2^>nul') DO (
	call :GetParent "%%~F" "parent"
	if exist "!parent!\%%~nF.odex" (
		set /A count2+=1
	)
)
FOR /f "delims=" %%F IN ('sfk list -quiet -quot -dir _system -minsize^=22b -file .jar +then list -quiet -quot -dir _system -minsize^=22b -file .apk 2^>nul') DO (
	call :GetParent "%%~F" "parent"
	if exist "!parent!\%%~nF.odex" (
		call :deodex_1 "%%~F" "!parent!"
	)
)
call :symlinks_search
call :done "%logX%"
goto restart
:deodex_1 file folder
set /A count3+=1
title !title_text! [!count3!/!count2!]
FOR /f "delims=" %%b IN ('7z l -tzip "%~1" classes.dex 2^>nul') DO (
	set x=%%b
	if not !x!==!x:classes.dex=! (
		del /f /q "%~2\%~n1.odex" 2>nul
		goto:eof
	)
)
cecho [*] !str_deodexing! %~nx1... 
echo [*] !str_deodexing! %~nx1...>>%logX%
rd /s /q "%~2\%~n1" 2>nul
java -Xmx1024m -jar "%bindir%bak!smali!" %opt_b% -a %api% -d _system\framework -o "%~2\%~n1\smali" "%~2\%~n1.odex" >>%logX% 2>&1
if "!errorlevel!"=="0" (
	java -Xmx1024m -jar "%bindir%!smali!" %opt_s% -a %api% -o "%~2\%~n1\classes.dex" "%~2\%~n1\smali" >>%logX% 2>&1
	if "!errorlevel!"=="0" (
		echo.
		call :zip_and_align "%~2\%~nx1" "%~2\%~n1\classes*.dex"
		del /f /q "%~2\%~n1.odex" 2>nul
	) else (
		set /A error_count+=1
		cecho {!colR!} !str_error!{# #}{\n}
		echo [*] ---^> !str_deodexing_error! "%~nx1">>%logX%
	)
) else (
	set /A error_count+=1
	cecho {!colR!} !str_error!{# #}{\n}
	echo [*] ---^> !str_deodexing_error! "%~nx1">>%logX%
)
rd /s /q "%~2\%~n1" 2>nul
goto:eof
:zip_and_align
ATTRIB -R "%~1" >nul
if /I "%~x1"==".apk" (
	COPY "%~1" "%bindir%temp\" >nul
	7z a -tzip "%bindir%temp\%~nx1" ".\%~2" -mx7 >nul 2>nul
	if errorlevel 1 (
		zip -j -7 "%bindir%temp\%~nx1" "%~2" >nul 2>>%logX%
	)
	zipalign -f -p 4 "%bindir%temp\%~nx1" "%~1" >nul 2>>%logX%
	del /f /q "%bindir%temp\%~nx1" 2>nul
) else (
	7z a -tzip "%~1" ".\%~2" -mx7 >nul 2>nul
	if errorlevel 1 (
		zip -j -7 "%~1" "%~2" >nul 2>>%logX%
	)
)
goto:eof
:deodex_oat2dex
set count_boot=0
set count_arch=0
set FARCH1=
FOR /D %%F IN (_system\framework\*) DO (
	if exist "%%~F\boot.oat" (
		set /A count_boot+=1
		set x=%%~nxF
		if not !x!==!x:64=! (
			set count_arch=1
			set FARCH1=%%~nxF
		)
	)
)
if !count_boot!==0 (
	set /A error_count+=1
	cecho {!colR!}[*] !str_bootnotfound!{# #}{\n}
	pause
	goto restart
)
FOR /D %%F IN (_system\framework\*) DO (
	if exist "%%~F\boot.oat" (
		if /I not "%%~nxF"=="!FARCH1!" (
			set /A count_arch+=1
			set FARCH!count_arch!=%%~nxF
		)
	)
)
if %api% GEQ 26 goto deodex_baksmali
if %api% GEQ 23 (
	if %deodex_tool%==baksmali (goto deodex_baksmali)
	set oat_dir=\oat
) else (
	set oat_dir=
)
call :log_version "%logX%" "deodex_oat2dex"
cecho [*] !str_selectedarch! {!colG!}!FARCH1!{# #}{\n}
echo [*] !str_selectedarch! !FARCH1!>>%logX%
cecho [*] !str_extractboot! 
echo [*] !str_extractboot!>>%logX%
rd /s /q "_system\framework\!FARCH1!-dex" "_system\framework\!FARCH1!-odex" "_system\framework\!FARCH1!\odex" 2>nul
if %api% GEQ 24 (
	set opt="_system\framework\!FARCH1!"
) else (
	set opt="_system\framework\!FARCH1!\boot.oat"
)
java -Xmx1200m -jar "%bindir%oat2dex.jar" -a %api% -o "_system\framework\!FARCH1!-dex" boot !opt! >>%logX% 2>&1
set odex_count=0
FOR %%F IN ("_system\framework\!FARCH1!-dex\*") DO (set /A odex_count+=1)
if "!odex_count!"=="0" (
	set /A error_count+=1
	cecho {!colR!} !str_error!{# #}{\n}
	echo [*] ---^> !str_extractboot_error! (!FARCH1!^)>>%logX%
	call :done "%logX%"
	rd /s /q "_system\framework\!FARCH1!-dex" 2>nul
	goto restart
)
echo.
call :extract_odex
set count2=0
set count3=0
FOR /f "delims=" %%a IN ('sfk list -quiet -quot -dir _system -minsize^=22b -file .jar .apk 2^>nul') DO (
	set file_deodexed=0
	call :GetParent "%%~a" "parent"
	if exist "_system\framework\!FARCH1!-dex\%%~na.dex" (
		set file_deodexed=1
		set /A count2+=1
	)
	FOR /L %%b IN (1,1,!count_arch!) DO (
		if !file_deodexed!==0 (
			if exist "!parent!!oat_dir!\!FARCH%%b!\%%~na.odex" (
				set file_deodexed=1
				set /A count2+=1
			)
		)
	)
)
FOR /f "delims=" %%a IN ('sfk list -quiet -quot -dir _system -minsize^=22b -file .jar +then list -quiet -quot -dir _system -minsize^=22b -file .apk 2^>nul') DO (
	set file_deodexed=0
	call :GetParent "%%~a" "parent"
	if exist "_system\framework\!FARCH1!-dex\%%~na.dex" (
		call :deodex_2 "%%~a" "_system\framework\!FARCH1!-dex\%%~na.dex" "_system\framework\!FARCH1!-dex"
	)
	FOR /L %%b IN (1,1,!count_arch!) DO (
		if !file_deodexed!==0 (
			if exist "!parent!!oat_dir!\!FARCH%%b!\%%~na.odex" (
				call :deodex_2 "%%~a" "!parent!!oat_dir!\!FARCH%%b!\%%~na.odex" "!parent!!oat_dir!\!FARCH%%b!"
			)
		)
	)
	if !file_deodexed!==1 (
		FOR /L %%b IN (1,1,!count_arch!) DO (
			del /f /q "!parent!!oat_dir!\!FARCH%%b!\%%~na.*dex*" "!parent!!oat_dir!\!FARCH%%b!\%%~na.art" 2>nul
			rd "!parent!!oat_dir!\!FARCH%%b!" 2>nul
		)
		if %api% GEQ 23 (rd "!parent!\oat" 2>nul)
	)
)
rd /s /q "_system\framework\!FARCH1!-dex" "_system\framework\!FARCH1!-odex" "_system\framework\!FARCH1!\odex" 2>nul
call :symlinks_search
call :done "%logX%"
goto restart
:deodex_2 apk_file odex_file odex_folder
set /A count3+=1
title !title_text! [!count3!/!count2!]
FOR /f "delims=" %%b IN ('7z l -tzip "%~1" classes.dex 2^>nul') DO (
	set x=%%b
	if not !x!==!x:classes.dex=! (
		set file_deodexed=1
		goto:eof
	)
)
cecho [*] !str_deodexing! %~nx1... 
echo [*] !str_deodexing! %~nx1...>>%logX%
if /I "%~x2"==".dex" (
	rd /s /q "%~3\dex" 2>nul
	md "%~3\dex" 2>nul
	COPY "%~3\%~n1.dex" "%~3\dex\classes.dex" >nul
	FOR %%S IN ("%~3\%~n1-classes*.dex") DO (
		set REN2=%%~nxS
		COPY "%%~S" "%~3\dex\!REN2:%~n1-=!" >nul
	)
	call :zip_and_align "%~1" "%~3\dex\*.dex"
	rd /s /q "%~3\dex" 2>nul
	echo.
	set file_deodexed=1
	goto:eof
)
rd /s /q "%~2-dex" 2>nul
::if exist "%~3\%~n1.vdex" (
::	set opt="%~3\%~n1.vdex"
::) else (
	set opt="%~2" "_system\framework\!FARCH1!-dex"
::)
java -Xmx1200m -jar "%bindir%oat2dex.jar" -a %api% -o "%~2-dex" !opt! >>%logX% 2>&1
if not exist "%~2-dex\%~n1.dex" (
	set /A error_count+=1
	cecho {!colR!} !str_error!{# #}{\n}
	echo [*] ---^> !str_deodexing_error! "%~nx1">>%logX%
	rd /s /q "%~2-dex" 2>nul
	set file_deodexed=2
	goto:eof
)
echo.
set file_deodexed=1
FOR %%S IN ("%~2-dex\%~n1-classes*.dex") DO (
	set REN2=%%~nxS
	ren "%%~S" "!REN2:%~n1-=!" >nul
)
FOR %%S IN ("%~2-dex\%~n1*.dex") DO (
	set REN2=%%~nxS
	ren "%%~S" "!REN2:%~n1=classes!" >nul
)
call :zip_and_align "%~1" "%~2-dex\*.dex"
rd /s /q "%~2-dex" 2>nul
goto:eof
:deodex_baksmali
if %old_smali%==1 (
	cecho {!colR!}[*] !str_old_smali_used!{# #}{\n}
	pause
	goto restart
)
if %api% GEQ 26 (
	if %deodex_vdex_tool%==vdexExtractor (call :log_version "%logX%" "deodex_vdex") else (call :log_version "%logX%" "deodex")
) else (
	call :log_version "%logX%" "deodex"
)
cecho [*] !str_selectedarch! {!colG!}!FARCH1!{# #}{\n}
echo [*] !str_selectedarch! !FARCH1!>>%logX%
set count2=0
set count3=0
FOR /f "delims=" %%a IN ('sfk list -quiet -quot -dir _system -file .oat .odex 2^>nul') DO (set /A count2+=1)
FOR /f "delims=" %%b IN ('sfk list -quiet -quot -dir _system *\!FARCH1!\* -file .oat +then list -quiet -quot -dir _system ^^!\!FARCH1!\ -file .oat 2^>nul') DO (
	set /A count3+=1
	title !title_text! [!count3!/!count2!]
	call :GetParent "%%~b" "odex_folder"
	call :deodex_3 "%%~b" "!odex_folder!"
)
call :extract_odex
FOR /f "delims=" %%b IN ('sfk list -quiet -quot -dir _system\framework\ *\!FARCH1!\* -file .odex +then list -quiet -quot -dir _system\framework\ ^^!\!FARCH1!\* -file .odex +then list -quiet -quot -dir _system\ ^^!_system\framework *\!FARCH1!\* -file .odex +then list -quiet -quot -dir _system\ ^^!_system\framework ^^!\!FARCH1!\ -file .odex 2^>nul') DO (
	set /A count3+=1
	title !title_text! [!count3!/!count2!]
	if exist "%%~b" (
		call :GetParent "%%~b" "odex_folder"
		call :deodex_3 "%%~b" "!odex_folder!"
	)
)
call :symlinks_search
call :done "%logX%"
goto restart
:deodex_3 odex_file odex_folder
set odex_count=0
java -Xmx1024m -jar "%bindir%bak!smali!" l d "%~1" >"%~2\%~n1.list" 2>>%logX%
if "!errorlevel!"=="0" (
	FOR /f "usebackq delims=" %%a IN ("%~2\%~n1.list") DO (set /A odex_count+=1)
)
if "!odex_count!"=="0" (
	set /A error_count+=1
	cecho {!colR!}[*] !str_deodexing_error! "%~nx1"{# #}{\n}
	echo [*] ---^> !str_deodexing_error! "%~nx1">>%logX%
	del /f /q "%~2\%~n1.list" 2>nul
	goto:eof
)
FOR /L %%a IN (1,1,!odex_count!) DO (
	sfk filter "%~2\%~n1.list" -line=%%a>"%~2\%~n1.list%%a"
)
set check_error_count=!error_count!
FOR /L %%a IN (1,1,!odex_count!) DO (
	SET /P list_string=<"%~2\%~n1.list%%a"
	if "!list_string:~0,1!"=="/" (set list_string=!list_string:~1!)
	set apk_file=_!list_string:/=\!
	set apk_dex=classes.dex
	FOR /L %%P IN (2,1,260) DO (
		if !apk_dex!==classes.dex (
			if "!apk_file:~-%%P,1!"==":" (
				set odex_separator=:
				set apk_dex=!apk_file:*:=!
				set apk_file=!apk_file:~0,-%%P!
			)
			if "!apk_file:~-%%P,1!"=="^!" (
				set odex_separator=^^!
				set apk_dex=!apk_file:*^!=!
				set apk_file=!apk_file:~0,-%%P!
			)
		)
	)
	if %api% GEQ 26 (
		if %deodex_vdex_tool%==vdexExtractor (
			set opt=
			call :GetParent "!apk_file!" "apk_folder"
			if exist "%~2\%~n1.vdex" set opt="%~2\%~n1.vdex" "%~2"
			if exist "_system\framework\%~n1.vdex" set opt="_system\framework\%~n1.vdex" "_system\framework"
			if exist "!apk_folder!\%~n1.vdex" set opt="!apk_folder!\%~n1.vdex" "!apk_folder!"
			if not "!opt!"=="" (
				call :deodex_4 !opt! "!apk_file!" "!apk_dex!"
			) else (
				cecho {!colR!}[*] WARNING: "%~n1.vdex" not found{# #}{\n}
				echo [*] WARNING: "%~n1.vdex" not found>>%logX%
			)
		) else (
			call :deodex_3_1 "%~1" "%~2" "!apk_file!" "!apk_dex!"
		)
	) else (
		call :deodex_3_1 "%~1" "%~2" "!apk_file!" "!apk_dex!"
	)
)
del /f /q "%~2\%~n1.list*" 2>nul
if !check_error_count!==!error_count! (
	if /I "%~x1"==".odex" (
		call :GetParent "%~2" "arch_folder"
		FOR /L %%b IN (1,1,!count_arch!) DO (
			del /f /q "!arch_folder!\!FARCH%%b!\%~n1.*dex*" "!arch_folder!\!FARCH%%b!\%~n1.art" 2>nul
			rd "!arch_folder!\!FARCH%%b!" 2>nul
		)
		rd "!arch_folder!" 2>nul
		call :GetParent "!apk_file!" "apk_folder"
		del /f /q "!apk_folder!\%%~na.vdex" 2>nul
	)
)
goto:eof
:deodex_3_1 odex_file odex_folder apk_file apk_dex
if exist "%~3" (
	FOR /f "delims=" %%b IN ('7z l -tzip "%~3" %~4 2^>nul ^| find /I "%~4"') DO (
		goto:eof
	)
)
if "%~4"=="classes.dex" (set "opt=%~nx3") else (set "opt=%~nx3!odex_separator!%~4")
cecho [*] !str_deodexing! !opt!... 
echo [*] !str_deodexing! !opt!...>>%logX%
rd /s /q "%~2\%~n1" 2>nul
java -Xmx1024m -jar "%bindir%bak!smali!" x -a %api% -b "_system\framework\!FARCH1!\boot.oat" -o "%~2\%~n1\%~n4" "%~1/!list_string!" >>%logX% 2>&1
if "!errorlevel!"=="0" (
	java -Xmx1024m -jar "%bindir%!smali!" a -a %api% -o "%~2\%~n1\%~4" "%~2\%~n1\%~n4" >>%logX% 2>&1
	if "!errorlevel!"=="0" (
		if not exist "%~3" (
			cecho {!colR!}WARNING {# #}
			echo  - "%~nx1" WARNING: "%~3" not found>>%logX%
			md "%~dp3" 2>nul
			COPY "%bindir%empty.jar" "%~3" >nul
		)
		echo.
		call :zip_and_align "%~3" "%~2\%~n1\%~4"
	) else (
		set /A error_count+=1
		cecho {!colR!} !str_error!{# #}{\n}
		echo [*] ---^> !str_deodexing_error! !opt!>>%logX%
	)
) else (
	set /A error_count+=1
	cecho {!colR!} !str_error!{# #}{\n}
	echo [*] ---^> !str_deodexing_error! !opt!>>%logX%
)
rd /s /q "%~2\%~n1" 2>nul
goto:eof
:deodex_4 vdex_file vdex_folder apk_file apk_dex
if exist "%~3" (
	FOR /f "delims=" %%b IN ('7z l -tzip "%~3" %~4 2^>nul ^| find /I "%~4"') DO (
		set file_deodexed=1
		goto:eof
	)
)
cecho [*] !str_deodexing! %~nx3... 
echo [*] !str_deodexing! %~nx3...>>%logX%
del /f /q "%~2\*.dex" "%~2\*.cdex" 2>nul
vdexExtractor -f --ignore-crc-error -v 2 -i "%~1" >>%logX% 2>&1
if exist "%~2\%~n1_classes.dex" (
	set file_deodexed=1
	FOR %%S IN ("%~2\*_classes*.dex") DO (
		set REN1=%%~nxS
		ren "%%~S" "!REN1:*_classes=classes!" >nul
	)
)
if not "!file_deodexed!"=="1" (
	set /A error_count+=1
	cecho {!colR!} !str_error!{# #}{\n}
	echo [*] ---^> !str_deodexing_error! "%~nx3">>%logX%
	del /f /q "%~2\*.dex" "%~2\*.cdex" 2>nul
	goto:eof
)
if not exist "%~3" (
	cecho {!colR!}WARNING {# #}
	echo  - "%~nx1" WARNING: "%~3" not found>>%logX%
	md "%~dp3" 2>nul
	COPY "%bindir%empty.jar" "%~3" >nul
)
echo.
call :zip_and_align "%~3" "%~2\*.dex"
del /f /q "%~2\*.dex" "%~2\*.cdex" 2>nul
goto:eof
:extract_odex
FOR %%F IN ("_system\odex.*.sqsh") DO (
	set x=%%~nxF
	7z x "%%~F" -o"_system\!x:~5,-5!\" -aou >nul 2>>%logX%
	if errorlevel 1 (
		cecho {!colR!}[*] !str_errorunp! %%~nxF{# #}{\n}
		echo [*] ---^> !str_errorunp! %%~nxF>>%logX%
	) else (
		del /f /q "%%~F" 2>nul
	)
)
FOR %%F IN ("_system\odex*.sqsh") DO (
	7z x "%%~F" -o"_system\" -aou >nul 2>>%logX%
	if errorlevel 1 (
		cecho {!colR!}[*] !str_errorunp! %%~nxF{# #}{\n}
		echo [*] ---^> !str_errorunp! %%~nxF>>%logX%
	) else (
		del /f /q "%%~F" 2>nul
	)
)
FOR /f "delims=" %%a IN ('sfk list -quiet -quot -dir _system -file .odex.xz .odex.gz 2^>nul') DO (
	call :GetParent "%%~a" "parent"
	7z x "%%a" -o"!parent!" -aoa >nul 2>>%logX%
	if errorlevel 1 (
		cecho {!colR!}[*] !str_errorunp! %%~a{# #}{\n}
		echo [*] ---^> !str_errorunp! %%~a>>%logX%
	) else (
		del /f /q "%%~a" 2>nul
	)
)
goto:eof
:symlinks_search
echo.>>%logX%
echo [*] !str_symlinks!:>>%logX%
for /f "delims=" %%a in ('sfk list -hidden -quiet -quot -dir _system -minsize^=7b -maxsize^=4112b +findbin -names symlink 2^>nul') do (
	set count2=0
	set x=
	set z=
	for /f "delims=" %%b in ('strings /accepteula -n 3 -nobanner "%%~a" 2^>nul') do (
		set /A count2+=1
		if "!z!"=="found" (
			set x=%%~b
			set z=writed
		)
		if "!z!"=="" (
			set y=%%b
			if not !y!==!y:symlink=! (set z=found)
		)
	)
	if !count2! LEQ 3 (
		if not "!x!"=="" (
			set y=%%~a
			set y=!y:~1!
			echo symlink("!x!", "/!y:\=/!"^);>>%logX%
			if %del_symlinks%==ON (del /f /q /A "%%~a" 2>nul)
		)
	)
)
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
:TrimRight "input_string" "string_to_trim" "var_with_trimmed_string"
set "_temp_=%~1"
::strLenN_binarySplit
set "str=%~2#"
set "len=0"
for %%P in (4096 2048 1024 512 256 128 64 32 16 8 4 2 1) do (
	if "!str:~%%P,1!" NEQ "" (
		set /a "len+=%%P"
		set "str=!str:~%%P!"
	)
)
set "%~3=!_temp_:~0,-%len%!"
goto:eof
:copy_files
set count2=0
set count3=0
set progressbar=0
FOR /f "delims=" %%F IN ('sfk list -quiet -quot -dir _system -minsize^=22b -file %~1 2^>nul') DO (set /A count2+=1)
FOR /f "delims=" %%F IN ('sfk list -quiet -quot -dir _system -minsize^=22b -file %~1 2^>nul') DO (
	if !count3!==0 (cecho {!colG!}[#)
	if /I "%~1"==".apk" (
		COPY "%%~F" "_INPUT_APK\" >nul
	) else (
		COPY "%%~F" "_INPUT_JAR\" >nul
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
echo [*] !str_copied_files! !count3!
pause
goto:eof
:baksmaliapk
if %rewrite_check%==ON (
	call :check_rewrite "_INPUT_APK" "!apk_base!.apk"
	if !_temp_!==0 goto restart
)
set error_count=0
call :measure_time start
call :log_version "%logD%" "smali"
if %old_smali%==1 (
	set opt=-l -s
	if %deldebuginfo%==ON (set opt=-b -l -s)
) else (
	set opt=d -l --sl
	if %deldebuginfo%==ON (set opt=!opt! --di false)
)
FOR %%F IN ("_INPUT_APK\!apk_base!.apk") DO (
	echo [*] !str_baksmaling! %%~nxF...
	echo [*] !str_baksmaling! %%~nxF...>>%logD%
	call :baksmali "%%~nxF" "_INPUT_APK"
)
call :done "%logD%"
goto restart
:baksmalijar
if %rewrite_check%==ON (
	call :check_rewrite "_INPUT_JAR" "!jar_base!.jar"
	if !_temp_!==0 goto restart
)
set error_count=0
call :measure_time start
call :log_version "%logD%" "smali-jar"
if %old_smali%==1 (
	set opt=
	if %deldebuginfo%==ON (set opt=-b)
) else (
	set opt=d
	if %deldebuginfo%==ON (set opt=!opt! --di false)
)
FOR %%F IN ("_INPUT_JAR\!jar_base!.jar") DO (
	echo [*] !str_baksmaling! %%~nxF...
	echo [*] !str_baksmaling! %%~nxF...>>%logD%
	call :baksmali "%%~nxF" "_INPUT_JAR"
)
call :done "%logD%"
goto restart
:smaliapk
set error_count=0
call :measure_time start
call :log_version "%logR%" "smali"
if %old_smali%==1 (
	set opt=
) else (
	set opt=a
)
FOR /D %%F IN ("_INPUT_APK\!apk_base!") DO (
	echo [*] !str_smaling! %%~nxF...
	echo [*] !str_smaling! %%~nxF...>>%logR%
	call :smali "%%~nxF.apk" "_INPUT_APK"
)
call :done "%logR%"
goto restart
:smalijar
set error_count=0
call :measure_time start
call :log_version "%logR%" "smali-jar"
if %old_smali%==1 (
	set opt=
) else (
	set opt=a
)
FOR /D %%F IN ("_INPUT_JAR\!jar_base!") DO (
	echo [*] !str_smaling! %%~nxF...
	echo [*] !str_smaling! %%~nxF...>>%logR%
	call :smali "%%~nxF.jar" "_INPUT_JAR"
)
call :done "%logR%"
goto restart
:baksmali
rd /s /q "%~2\%~n1" 2>nul
7z x -tzip "%~2\%~nx1" -o"%~2\%~n1" *.dex -aoa >nul 2>>%logD%
set count2=0
FOR %%F IN ("%~2\%~n1\*.dex") DO (set /A count2+=1)
if %count2%==0 (
	cecho {!colG!}!str_dex_notfound!{# #}{\n}
	echo !str_dex_notfound!>>%logD%
	goto:eof
)
FOR %%F IN ("%~2\%~n1\*.dex") DO (
	if /I "%%~nF"=="classes" (set REN2=smali) else (set REN2=smali_%%~nF)
	if not %count2%==1 (
		echo  - %%~nxF
		echo  - %%~nxF>>%logD%
	)
	java -Xmx1024m -jar "%bindir%bak!smali!" %opt% -a %api% -o "%~2\%~n1\!REN2!" "%%~F" >>%logD% 2>&1
	if not "!errorlevel!"=="0" (
		set /A error_count+=1
		cecho {!colR!}[*] !str_bsmerror! "%~nx1:%%~nxF"{# #}{\n}
		echo [*] ---^> !str_bsmerror! "%~nx1:%%~nxF">>%logD%
	)
)
del /f /q "%~2\%~n1\*.dex" 2>nul
goto:eof
:smali
FOR /D %%F IN ("%~2\%~n1\smali*") DO (
	set REN2=%%~nxF
	if /I "%%~nxF"=="smali" (set REN2=classes) else (set REN2=!REN2:smali_=!)
	java -Xmx1024m -jar "%bindir%!smali!" %opt% -a %api% -o "%~2\%~n1\!REN2!.dex" "%%~F" >>%logR% 2>&1
	if not "!errorlevel!"=="0" (
		set /A error_count+=1
		cecho {!colR!}[*] !str_smerror! "%~n1"{# #}{\n}
		echo [*] ---^> !str_smerror! "%~n1">>%logR%
		goto:eof
	)
)
if not exist "%~2\%~nx1" (
	set /A error_count+=1
	cecho {!colR!}[*] !str_orignotfound!{# #}{\n}
	echo [*] ---^> !str_orignotfound!>>%logR%
	goto:eof
)
if /I "%~2"=="_INPUT_JAR" (
	COPY "%~2\%~nx1" "_OUT_JAR\" >nul
	7z a -tzip "_OUT_JAR\%~nx1" ".\%~2\%~n1\*.dex" -mx7 >nul 2>nul
	if errorlevel 1 (
		zip -j -7 "_OUT_JAR\%~nx1" "%~2\%~n1\*.dex" >nul 2>>%logR%
	)
)
if /I "%~2"=="_INPUT_APK" (
	COPY "%~2\%~nx1" "%bindir%temp\" >nul
	7z a -tzip "%bindir%temp\%~nx1" ".\%~2\%~n1\*.dex" -mx7 >nul 2>nul
	if errorlevel 1 (
		zip -j -7 "%bindir%temp\%~nx1" "%~2\%~n1\*.dex" >nul 2>>%logR%
	)
	if %sign_after%==ON (
		call :sign "%bindir%temp\%~nx1" "_OUT_APK\%~nx1" "2>>%logR%"
	) else (
		zipalign -f -p 4 "%bindir%temp\%~nx1" "_OUT_APK\%~nx1" >nul 2>>%logR%
	)
	del /f /q "%bindir%temp\%~nx1" 2>nul
)
goto:eof
:: --------------------
:adbdevices
cecho {!colG!}  !str_connection_type!{# #}{\n}
echo    1 = USB
echo    2 = Wi-Fi
echo.
echo    0 = !str_cancel!
:_adbdevices
set INPUT=
SET /P INPUT=!str_makechoice! 
IF !INPUT!==1 (goto adbusb)
IF !INPUT!==2 (goto adbwifi)
IF !INPUT!==0 (goto restart)
goto _adbdevices
:adbusb
set adb_mode=usb
adb devices
pause
goto restart
:adbwifi
set INPUT=
if '!adb_ip!'=='' (
	SET /P INPUT=[*] !str_input_ip! 
	if '!INPUT!'=='' (
		goto adbwifi
	) else (
		set adb_ip=!INPUT!
		call :savesettings "adb_ip"
	)
) else (
	SET /P INPUT=[*] !str_input_ip2! !adb_ip!: 
	if not '!INPUT!'=='' (
		set adb_ip=!INPUT!
		call :savesettings "adb_ip"
	)
)
set adb_mode=wireless
adb connect !adb_ip!
pause
goto restart
:adbinstall
cecho {!colG!}  !str_installtodef!{# #}{\n}
echo    1 = !str_singlefile!
echo    2 = !str_allfrom! _OUT_APK
cecho {!colG!}  !str_installtosd!{# #}{\n}
echo    3 = !str_singlefile!
echo    4 = !str_allfrom! _OUT_APK
echo.
echo    0 = !str_cancel!
:_adbinstall
set INPUT=
SET /P INPUT=!str_makechoice! 
set opt=-r -t -d
IF !INPUT!==1 (goto adbinstall2-a)
IF !INPUT!==2 (goto adbinstall2-b)
set opt=-r -t -s -d
IF !INPUT!==3 (goto adbinstall2-a)
IF !INPUT!==4 (goto adbinstall2-b)
IF !INPUT!==0 (goto restart)
goto _adbinstall
:adbinstall2-a
set temp_name=
for /f "delims=" %%a in ('FileToOpen "set temp_name=" "!cd!\_OUT_APK\*.apk" "!str_selectapk!" /multiselect') do %%a
if '!temp_name!'=='' (
	goto restart
) else (
	FOR %%F IN (!temp_name!) DO (
		echo [*] !str_installing! %%~nxF...
		adb install !opt! "%%~F"
	)
)
pause
goto restart
:adbinstall2-b
FOR %%F IN (_OUT_APK\*.apk) DO (
	echo [*] !str_installing! %%~nxF...
	adb install !opt! "%%~F"
)
pause
goto restart
:adbremount
adb root
if %adb_mode%==wireless (
	adb connect !adb_ip!
)
adb wait-for-device
adb remount
pause
goto restart
:adbpull
cecho {!colG!}  !str_pull2!{# #}{\n}
echo    1 = !str_allfrom! /system/app
echo    2 = !str_allfrom! /system/priv-app
echo    3 = !str_allfrom! /system/framework
echo    4 = !str_allfrom! /system/app, /system/priv-app, /system/framework
echo.
echo    0 = !str_cancel!
:_adbpull
set INPUT=
SET /P INPUT=!str_makechoice! 
IF !INPUT!==1 (
	adb pull -a /system/build.prop _system
	adb pull -a /system/app _system\app
	pause
	goto restart
)
IF !INPUT!==2 (
	adb pull -a /system/build.prop _system
	adb pull -a /system/priv-app _system\priv-app
	pause
	goto restart
)
IF !INPUT!==3 (
	adb pull -a /system/build.prop _system
	adb pull -a /system/framework _system\framework
	pause
	goto restart
)
IF !INPUT!==4 (
	adb pull -a /system/build.prop _system
	adb pull -a /system/framework _system\framework
	adb pull -a /system/app _system\app
	adb pull -a /system/priv-app _system\priv-app
	pause
	goto restart
)
IF !INPUT!==0 (goto restart)
goto _adbpull
:adbpush
cecho {!colG!}  !str_pushto! /system:{# #}{\n}
echo    1 = !str_allfrom! _system
echo    2 = !str_allfrom! _system (!str_alt_method!)
cecho {!colG!}  !str_pushto! /sdcard/BAT/:{# #}{\n}
echo    3 = !str_singlefile!
echo    4 = !str_allfrom! _OUT_APK
echo    5 = !str_allfrom! _system
echo.
echo    0 = !str_cancel!
:_adbpush
set INPUT=
SET /P INPUT=!str_makechoice! 
IF !INPUT!==1 (goto adbpush1)
IF !INPUT!==2 (goto adbpush2)
IF !INPUT!==3 (goto adbpush3)
IF !INPUT!==4 (adb push _OUT_APK /sdcard/BAT/) & pause & goto restart
IF !INPUT!==5 (adb push _system /sdcard/BAT/) & pause & goto restart
IF !INPUT!==0 (goto restart)
goto _adbpush
:adbpush1
::<nul set /p =.	rem echo without new line
adb push _system /system
if "!errorlevel!"=="0" (
	FOR /f "delims=" %%a IN ('sfk list -hidden -quiet -quot -relnames _system 2^>nul') DO (
		set REN2=%%~a
		adb shell chmod 644 '/system/!REN2:\=/!'
	)
) else (
	cecho {!colR!}!str_error!{# #}{\n}
)
pause
goto restart
:adbpush2
adb shell su -c 'mount -o remount,rw /system'
FOR /f "delims=" %%a IN ('sfk list -quiet -quot -relnames _system 2^>nul') DO (
	call :GetParent "%%~a" "parent"
	if "!parent!"=="" (
		set REN2=
	) else (
		set REN2=/!parent:\=/!
	)
	echo [*] _system\%%~a -^> /system!REN2!/
	adb push "_system\%%~a" /data/local/tmp/
	adb shell su -c 'mkdir -p \"/system!REN2!\" ^&^& cp -f \"/data/local/tmp/%%~nxa\" \"/system!REN2!/\" ^&^& chmod 644 \"/system!REN2!/%%~nxa\"'
	adb shell rm '/data/local/tmp/%%~nxa'
)
adb shell su -c 'mount -o remount,ro /system'
pause
goto restart
:adbpush3
set temp_name=
for /f "delims=" %%a in ('FileToOpen "set temp_name=" "!cd!\*.*" "SELECT FILE" /multiselect') do %%a
if '!temp_name!'=='' (
	goto restart
) else (
	adb shell mkdir -p /sdcard/BAT
	FOR %%F IN (!temp_name!) DO (
		adb push "%%~F" /sdcard/BAT/
	)
)
pause
goto restart
:adbscreenshot
adb shell screencap -p /data/local/tmp/screenshot.png
nircmd wait 1000
adb pull /data/local/tmp/screenshot.png
if exist screenshot.png (
	adb shell rm /data/local/tmp/screenshot.png
	call :get_date_time
	ren "screenshot.png" "screenshot_!DATE2!_!TIME2!.png" >nul
	echo [*] !str_screensavedto! "screenshot_!DATE2!_!TIME2!.png"
) else (
	cecho {!colR!}!str_error!{# #}{\n}
)
pause
goto restart
:screenrecord
echo n|start /max /wait cmd /c "mode 80,25& echo [*] !str_closetostop!& adb shell screenrecord --verbose /sdcard/screenrecord.mp4"
nircmd wait 3000
adb pull /sdcard/screenrecord.mp4
if exist screenrecord.mp4 (
	adb shell rm /sdcard/screenrecord.mp4
	call :get_date_time
	ren "screenrecord.mp4" "screenrecord_!DATE2!_!TIME2!.mp4" >nul
	echo [*] !str_scrrecsavedto! "screenrecord_!DATE2!_!TIME2!.mp4"
) else (
	cecho {!colR!}!str_error!{# #}{\n}
)
pause
goto restart
:adbshell
start /max cmd /c "mode 120,9999& adb shell"
goto restart
:adblogs
cecho {!colG!}  Logcat:{# #} !str_toscreen!{\n}
echo    1 = Logcat
echo    2 = Logcat (!str_logcatr!)
echo    3 = Logcat (!str_logcate!)
echo    4 = Logcat (last)
cecho {!colG!}  Dmesg:{# #}{\n}
echo    5 = !str_tofile!
cecho {!colG!}  !str_bugreport!{# #}{\n}
echo    6 = !str_tofile!
cecho {!colG!}  !str_inlinetable!{# #}{\n}
echo    7 = !str_tofile!
echo.
echo    0 = !str_cancel!
:_adblogs
set INPUT=
SET /P INPUT=!str_makechoice! 
IF !INPUT!==1 (set opt1=& set opt2=& goto adblogcat)
IF !INPUT!==2 (set opt1=-b radio& set opt2=_radio& goto adblogcat)
IF !INPUT!==3 (set opt1=-b events& set opt2=_events& goto adblogcat)
IF !INPUT!==4 (set opt1=-L& set opt2=_last& goto adblogcat)
IF !INPUT!==5 (goto adbdmesg)
IF !INPUT!==6 (goto adbbug)
IF !INPUT!==7 (goto adbinline)
IF !INPUT!==0 (goto restart)
goto _adblogs
:adblogcat
call :get_date_time
call :_adblogcat
pause
goto restart
:_adblogcat
setLocal EnableExtensions EnableDelayedExpansion
set PYTHONIOENCODING=utf-8
start /max cmd /c "mode 120,360& adb logcat !opt1! -v time | mtee "logcat!opt2!_!DATE2!_!TIME2!.txt" | python "%bindir%coloredlogcat\coloredlogcat.py""
echo !str_saved_to_file! "logcat!opt2!_!DATE2!_!TIME2!.txt"
endLocal
goto:eof
:adbdmesg
call :get_date_time
adb shell dmesg >"dmesg_!DATE2!_!TIME2!.txt"
sfk rep "dmesg_!DATE2!_!TIME2!.txt" -binary /0D0D/0D/ -quiet -yes >nul
echo !str_saved_to_file! "dmesg_!DATE2!_!TIME2!.txt"
pause
goto restart
:adbbug
call :get_date_time
adb bugreport >"bugreport_!DATE2!_!TIME2!.txt"
sfk rep "bugreport_!DATE2!_!TIME2!.txt" -binary /0D0D/0D/ -quiet -yes >nul
echo !str_saved_to_file! "bugreport_!DATE2!_!TIME2!.txt"
pause
goto restart
:adbinline
adb push %bindir%deodexerant /data/local/tmp/
adb shell chmod 755 /data/local/tmp/deodexerant
adb shell /data/local/tmp/deodexerant > inline.txt 2>&1
adb shell rm /data/local/tmp/deodexerant
sfk rep "inline.txt" -binary /0D0D/0D/ -quiet -yes >nul
echo !str_saved_to_file! "inline.txt"
pause
goto restart
:adbinfo
echo.
FOR /f "tokens=1* delims=:" %%a IN ('adb shell getprop ^| sort') DO (
	if /I "%%a"=="[ro.build.version.release]" (echo !str_android_version!%%b)
	if /I "%%a"=="[ro.product.brand]" (echo !str_brand!%%b)
	if /I "%%a"=="[ro.product.model]" (echo !str_model!%%b)
	if /I "%%a"=="[ro.product.cpu.abi]" (echo Arch:%%b)
)
echo.
adb shell df
echo.
pause
goto restart
:adbreboot
cecho {!colG!}  !str_reboot2!{# #}{\n}
echo    1 = !str_reboot3!
echo    2 = !str_rebootto! recovery
echo    3 = !str_rebootto! bootloader
echo.
echo    0 = !str_cancel!
:_adbreboot
set INPUT=
SET /P INPUT=!str_makechoice! 
IF !INPUT!==1 (goto rebootnormal)
IF !INPUT!==2 (goto rebootrecovery)
IF !INPUT!==3 (goto rebootbootloader)
IF !INPUT!==0 (goto restart)
goto _adbreboot
:rebootrecovery
echo !str_rebootto! recovery...
adb reboot recovery
goto restart
:rebootbootloader
echo !str_rebootto! bootloader...
adb reboot bootloader
goto restart
:rebootnormal
echo !str_reboot3!...
adb reboot
goto restart
:adbexit
set adb_mode=off
adb kill-server
cecho {!colG!}!str_done!{# #}{\n}
pause
goto restart
:about
cls
COLOR 07
call :empty_line 21
cecho               {0A}####{#}    #   ##### #   # #   #        {0A}#{#}   ##### #   # {0A}#####{#}  ###   ###  #####{\n}
cecho                {09}#{#}     # #    #   #   #  # #        {09}# #{#}  #   # #  #    {09}#{#}   #   # #   #  #  #{\n}
cecho                {0E}####{#} #####   #    ####   #        {0E}#####{#} #   # ###     {0E}#{#}   #   # #   #  #  #{\n}
cecho                {0B}#  #{#} #   #   #       #  # #       {0B}#   #{#} #   # #  #    {0B}#{#}   #   # #   #  #  #{\n}
cecho               {0D}#####{#} #   #   #       # #   #      {0D}#   #{#} #   # #   #   {0D}#{#}    ###   ###  #   #{\n}
call :empty_line 21
start nircmd speak text "Batch ApkTool"
pause
COLOR %colB%
goto restart
:empty_line
FOR /L %%a IN (1,1,%~1) DO echo.
goto:eof
