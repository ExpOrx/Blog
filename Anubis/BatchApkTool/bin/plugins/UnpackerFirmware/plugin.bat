:: Unpacker v1.6.0
:: Автор: unix3dgforce [MiuiPro.by DEV Team]
:: Плагин извлекает из zip архива прошивки system.new.dat и распаковывает. Дополнительно генерируются файлы со списком симлинков и производится конвертирование file_contexts.bin
if "%bat_version%"=="" goto:eof
set temp_name=
for /f "usebackq delims=" %%a in (`FileToOpen "set temp_name=" "!cd!\*.zip;*.new.dat;*.new.dat.br;*.img;rawprogram0.xml"`) do %%a
if not '!temp_name!'=='' (
	FOR %%F IN (!temp_name!) DO (
		pushd "%%~dpF"
		python "!plugdir!unpacker.py" unpack -f !temp_name!
		pause
		goto:eof
	)
)
	