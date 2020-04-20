
## Sample hash(you can get more info from koodous)

 - sha1 98d48a91f8a6624f022ef44be00f3c75ede996ac
 - sh256 7b33baf796af6885251c0860c530057207b2ef302bf0c246fd862e172a8efc8e

## How to get it.
 [Download it from koodous market.](https://koodous.com/apks/7b33baf796af6885251c0860c530057207b2ef302bf0c246fd862e172a8efc8e)

## Using JEB open it.
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

Now, we need to analyze loadEncryptedDex function in DexManipulation class. After analysis, you can get function scheduling order as follows:
```
1.DexManipulation.loadEncryptedDex(this.getAssets().open("classes.dat"), context);----> 2.DexManipulation.decryptDex(v12, v3);---->3.Native.decrypt(v2_3.toByteArray());
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

Using IDA open secure_lib.so, its functions relation is as follows:

![](https://github.com/JohnCUMT/Android-Project/blob/master/functions.png)

its function scheduling order is very complex and it has antidebug function by ptrace itself. So, we can using black box to decrypt dex.

## Using Android Studio to build module as com.protector.testing2, new package as com.protector.testing2.helper, build Native class under this package as follows:
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

## The result we are expecting
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
