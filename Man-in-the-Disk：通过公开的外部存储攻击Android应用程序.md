---
title: Man-in-the-Disk：通过公开的外部存储攻击Android应用程序
---

### 0x01 事件背景
> 国外安全研究人员 Slava Makkaveev 发现了Android使用存储资源设计的一个缺陷,应用程序在使用外部存储可能会导致应用程序被攻击，例如导致应用程序崩溃，代码注入的大门。当应用程序使用外部存储不当时，这些Man-in-the-Disk攻击成为可能，外部存储是一种在所有应用程序之间共享的资源，并且不被Android Sandbox保护。本文将展示一个WRITE_EXTERNAL_STORAGE权限如何使Android应用程序能够以静默方式执行特权代码并安装其他应用程序。

### 0x02 Android存储介绍
**在进一步了解之前，我们先了解一下Android的两种存储方式。**

- 外部存储：外部存储我们平时操作比较多，一般就是我们storage文件夹，当然也有可能是mnt文件夹，因为不同厂家有可能不一样，其路径一般为 **/storage/emulated/0/Android/data/app_package_name**，需要的权限为:
```
<uses-permission android:name="android.permission.WRITE_EXTERNAL_STORAGE"/>
```
![DDMS](https://i.screenshot.net/e8gees3)
 
- 内部存储：data文件夹就是我们常说的内部存储，当我们打开data文件夹之后（注：需root才能打开该文件夹），里边有两个文件夹值得我们关注，如下：
![DDMS](https://i.screenshot.net/86477i9)

### 0x03 模拟攻击
#### 1 模拟攻击的APP界面
![DDMS](https://i.screenshot.net/9l5vvig)
#### 2 发动攻击替换更新的文件
![DDMS](https://i.screenshot.net/6mvkktn)
#### 3 攻击视频
<iframe height=498 width=510 src='http://player.youku.com/embed/XMzc5NDAzMTk0MA==' frameborder=0 'allowfullscreen'></iframe>
优酷视频地址：https://v.youku.com/v_show/id_XMzc5NDAzMTk0MA==.html?spm=a2h3j.8428770.3416059.1
#### 4 攻击原理
![DDMS](https://i.screenshot.net/kyk44u5)
#### 5 国内案例---小米浏览器
- 更新小米浏览器APP被攻击（注：图片来源于blog.checkpoint.com）。
![图片来源于blog.checkpoint.com](https://blog.checkpoint.com/wp-content/uploads/2018/08/Man-in-the-Disk-Update-Phone.png)
<br>
- 针对源码剖析,对下载apk证书指纹sha1校验后,安装下载的APK,等校验完成后，为了良好的用户体验，不会立马安装,出现了一个时间差，攻击者利用这个时间差替换**/storage/emulated/0/Android/data/com.android.browser/files/update**下面的apk，成功完成攻击。
![图片来源于blog.checkpoint.com](https://i.screenshot.net/x2xppce)

### 0x04 怎么防御Man-in-the-Disk攻击
-  [谷歌Android安全指南之安全使用外部存储设备。](https://developer.android.com/training/articles/security-tips)
-  处理来自外部存储的数据时执行输入验证;不要将可执行文件或类文件存储在外部存储上;外部存储文件应在动态加载之前进行签名和加密验证。
-  [**使用通付盾安全SDK，为您的APP保驾护航。**](https://www.tongfudun.com/)