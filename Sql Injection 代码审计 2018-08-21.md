---
title: Sql Injection 代码审计 2018-08-21
---

=======
### 0x01 环境和工具
* IDEA
* Burp
* [WebGoat v8.0.0.M21](https://github.com/WebGoat/WebGoat/releases)

### 0x02 漏洞位置
```java
org.owasp.webgoat.plugin.introduction.SqlInjectionLesson5a.java
数据污染流如下，POST参数数据未经过处理直接进入函数，最终进入query语句，导致sql注入。
```
![sql1](https://i.screenshot.net/37yrruw)

### 0x03 漏洞验证，开启IDEA debug，下断点，查看脏数据流


![sql2](https://i.screenshot.net/vy700ud)


###  0x04 漏洞修补
```
   String query= "SELECT * FROM user_data WHERE last_name =? ;
   PreparedStatement preState = conn.prepareStatement(query);
   preState.setString(1, accountName);
   ResultSet rs = preState.executeQuery();
```






