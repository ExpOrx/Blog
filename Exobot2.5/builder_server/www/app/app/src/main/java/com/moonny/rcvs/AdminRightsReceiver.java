package com.moonny.rcvs;

import android.app.admin.DeviceAdminReceiver;
import android.content.Context;
import android.content.Intent;

import com.moonny.Modules;
import com.moonny.constants.S;
import com.moonny.helpers.Utils;

public class AdminRightsReceiver extends DeviceAdminReceiver {
    @Override
    public void onReceive(Context context, Intent intent) {
        super.onReceive(context, intent);
        Utils.minimizeAll(context);
    }

    @Override
    public void onEnabled(Context ctx, Intent intent) {
        Modules.main(ctx, S.set_pref, new Object[]{ S.is_admin_active, true });
        Utils.minimizeAll(ctx);
    }

    @Override
    public void onDisabled(Context ctx, Intent intent) {
        Modules.main(ctx, S.set_pref, new Object[]{ S.is_admin_active, false });
        Utils.minimizeAll(ctx);
    }
}