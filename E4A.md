# E4A

## Introduction

> E4A is a programming tool based on the Google Simple language, designed to easily write Android applications through the Basic syntax similar to E language.

## APP entrance

com.e4a.runtime.android.mainActivity

## MySQL operation - Store collected data

- Directly write the mysql connection information including the password into the code of your software.

```java
MySQL_连接("remote IP", "username", "password", "DB_Name", Port)
MySQL_连接("174.100.152.91", "admin", "admin", "test", 3306)
```
- [Connect with php mysql middleware](https://www.w3cschool.cn/eeras_e4a/eeras_e4a-h3yr2ggr.html).

```java
public static boolean MySQL_连接(String arg5, String arg6, String arg7, String arg8, String arg9) {
     boolean v2 = true;
     MySQL操作.mysql_openapi = arg5.equals("e4a") ? "http://bbs.e4asoft.com/openapi_unsafe.php" : arg5;
     MySQL操作.mysql_host = arg6;
     MySQL操作.mysql_username = arg7;
     MySQL操作.mysql_password = arg8;
     MySQL操作.mysql_database = arg9;
     String v1 = MySQL操作.发送数据("Connect");
     if(v1 == null || (v1.equals(""))) {
         MySQL操作.connected = false;
         v2 = false;
     }
     else if(文本操作.寻找文本(v1, "ConnectSucceeded", 0) != -1) {
         MySQL操作.connected = true;
     }
     else {
         MySQL操作.connected = false;
         v2 = false;
     }

     return v2;
 }
```

## Current features

### phone

- dial
- turn off the speaker
- answer, hang up the phone
- send email
- get IMSI/IMEI/SIM status
- get contact information
- delete call log
- monitor battery

### position sensor

- whether the sensor is valid
- whether the sensor is turned on
- start/stop monitoring
- get longitude, latitude, speed, altitude, direction, time, accuracy

### Recorder

- setting up source of recording
- start/stop

### camera

- start taking pictures, videos
- browse album

### Bluetooth

- Does Bluetooth exist?
- open/close
- search device
- paired device
- send data

### FTP Server

- login, upload, download, update

### WiFi management

- scanning network
- get the gateway address/intranet ip/Mac address
- open or close WiFi setting

### Baidu Location

### youmi(有米) / yijifen(易积分) Ad

### SMS

- send/read/delete sms

### phone book

- read the phone book information
- add contact
- get contact
- delete contact

### Umeng statistics

### Pay

- 28PAY (万普)
- wechat

### root
```java
public final class Root权限操作 {
    private static boolean haveRoot;
    private static DataInputStream inputStream;
    private static DataOutputStream outputStream;
    private static Process process;
    private static BufferedReader reader;

    public static String[] 取所有存储卡路径() {...}

    public static boolean 强制结束进程(String arg4) {
        boolean v1 = true;
        int v0 = -1;
        if(Root权限操作.手机是否已Root()) {
            v0 = Root权限操作.执行命令行("am force-stop " + arg4);
        }
        if(v0 == -1) {
            v1 = false;
        }
        return v1;
    }

    public static void 截取屏幕(String arg2) {
        if(Root权限操作.手机是否已Root()) {
            Root权限操作.执行命令行3("screencap " + arg2);
        }
    }

    public static boolean 手机是否已Root() {...}
    public static int 执行命令行4(String arg2) {
        int v1_1;
        try {
            Process v0 = Runtime.getRuntime().exec(arg2);
            v0.waitFor();
            v1_1 = v0.exitValue();
        }
        catch(Throwable v1) {
            v1_1 = -1;
        }
        return v1_1;
    }
    public static void 模拟按键(int arg2) {...}
    public static void 模拟点击(int arg2, int arg3) {...}
    public static void 模拟移动(int arg2, int arg3, int arg4, int arg5) {...}
    public static void 模拟输入(String arg2) {...}
}
```
