---
title: GPlayed Trojan 分析
---

标签（空格分隔）： AndroidSec

---
### 介绍
移动设备越来越频繁地涉及个人的日常生活，恶意行为者正在看到越来越多的机会攻击这些设备。 一种我们称之为“GPlayed”的新Android特洛伊木马。这是一种具有许多内置功能的木马。同时，它非常灵活，使其成为恶意行为者非常有效的工具。我们分析的示例使用了一个非常类似于Google Apps的图标，标签为“Google Play Marketplace”以伪装自己。
![](https://i.screenshot.net/5v7y2ur)
### 0x01 样本信息
```
MD5 : 722df68edd734de789c5b94621a5c94e
SHA1 : 60ee08c423c1dce20b56cbc0e8d4ab295226e146
SHA256 : a342a16082ea53d101f556b50532651cd3e3fdc7d9e0be3aa136680ad9c6a69f
证书指纹：
    MD-5：EC DF C4 5C FB 81 D0 DA 6C B6 D5 5D E9 89 E1 B3 
    SHA-1：09 31 FC 02 7A CF C7 7E 81 9C 2F 1F 87 67 74 05 F0 6F E0 80 
    SHA-256：81 AD 26 6A 64 FB 77 4A AD E3 80 C8 A3 BD 90 25 E6 3B 95 56 9D 56 AC D0 97 FE 71 D6 56 51 B0 41 
```
### 0x02 权限分析
> 如下如所示，该木马声明了很多权限，类似常见的网络、读取联系人、接受发短信等，还有两个额外令人瞩目的系统APP的权限-BIND_DEVICE_ADMIN和PACKAGE_USAGE_STATS，而BIND_DEVICE_ADMIN权限可以让木马完全控制手机。

![](https://i.screenshot.net/1mxj2bd)
### 0x03 恶意代码迭代插件化
如下图中的代码功能，它可以接收新的.NET源代码，这些代码将在运行时在设备上进行编译，也可以在资源文件下添加。这说明添加功能，而无需重新编译和升级设备上已经感染的木马。
![](https://i.screenshot.net/0390nu2)
### 0x04 木马详情
#### 1.诞生时间
> 该木马诞生于2016/12/26 12:11:37，而发现于2018/10/11，在者两年中活动频繁。目前在通付盾全渠道检测平台中没有发现该木马在国内市场上架，我们将持续关注并进行安全响应。
![](https://i.screenshot.net/q8l7rcz)
#### 2.木马恶意行为详情
![](https://i.screenshot.net/e7k4gi3)
### 0x05 总结
这种木马凸显了威胁进化的新方式。能够毫不费力地将代码从PC移动到移动平台，类似eCommon.DLL，表明恶意行为者可以更快地创建混合威胁，并且所涉及的资源比以往任何时候都少。这种特洛伊木马的设计和实施具有非常高的水平，使其成为一种危险的威胁，随着移动互联网的发展，这些威胁将变得更加普遍。建议大家在官方应用市场下载APP的时候，注意APP的发布者，如果您对APP的安全存在怀疑，欢迎采用通付盾反病毒引擎进行查杀。
### 附IOC
```
http://5.9.33.226:5416/
http://5.9.33.226:5417/ws/
http://172.110.10.171:85/testcc.php
eCommon.dll——MD5：980b4dc1e9976f9d89bdddedfb5f6ad9
Reznov.dll——MD5：c95b3a8f8cf70cd094a12d39ae227c6c
```
 






