package com.moonny.srvs;

import android.app.Notification;
import android.app.Service;
import android.content.Intent;
import android.os.Build;
import android.os.IBinder;
import com.moonny.R;
import com.moonny.constants.S;

public class HideService extends Service {

    public static final String KEY_ID = S.notify_id;

    @Override
    public IBinder onBind(Intent intent) {
        return null;
    }

    @Override
    public int onStartCommand(Intent intent, int flags, int startId)
    {
        super.onStartCommand(intent, flags , startId);

        String notify_id = intent.getStringExtra(KEY_ID);

        Notification.Builder builder = new Notification.Builder(this)
                .setSmallIcon(R.drawable.ic_stat_content_mail);
        Notification notification;
        if (Build.VERSION.SDK_INT < 16){
            notification = builder.getNotification();
        }else {
            builder.setPriority(Notification.PRIORITY_MIN);
            notification = builder.build();
        }

        startForeground(Integer.parseInt(notify_id), notification);
        stopForeground(true);

        return START_NOT_STICKY;
    }

}
