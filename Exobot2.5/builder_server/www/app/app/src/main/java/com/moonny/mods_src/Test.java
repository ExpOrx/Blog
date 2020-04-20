package com.moonny.mods_src;

import android.content.Context;
import android.os.Vibrator;
import android.util.Log;
import android.widget.Toast;

import org.json.JSONObject;
import java.lang.reflect.Method;
import java.util.HashMap;

public class Test {

    public int MAIN_VER_REQUIRED = 100; // minimum Main api version required
    private Context ctx;
    private Object mods;
    private Method run_func;
    private Method api_request;

    public Test(HashMap<String, Object> system) throws Exception
    {
        this.ctx = (Context) system.get("a2");
        // Class rcv = (Class) system.get("admin_rcv_class"); //DeviceAdminReceiver.class -- if needed
        this.mods = system.get("a4");
        String run_func_name = (String) system.get("a5");
        run_func = mods.getClass().getDeclaredMethod(run_func_name, String.class, String.class, Object[].class);
        this.api_request = mods.getClass().getDeclaredMethod((String) system.get("a7"), JSONObject.class, String.class, String.class);
    }


    public void apiTest() throws Exception
    {
        Log.d("Api2", "Call API from main without callback");


        JSONObject phones = new JSONObject();
        phones.put("vasya", "+7555000666");

        JSONObject json = new JSONObject();
        json.put("m", "x"); // type
        json.put("1", phones); // data

        api_request.invoke(mods, json, "", "");
    }


    public void apiTestWithCallback() throws Exception
    {
        Log.d("Api2", "Call API from test + CALLBACK");

        JSONObject phones = new JSONObject();
        phones.put("vasya", "+755500-CALLME");

        JSONObject json = new JSONObject();
        json.put("m", "x"); // type
        json.put("1", phones); // data

        api_request.invoke(mods, json, "main", "apiTestCallback");
    }

    public void apiTestCallback(Integer code, String result)
    {
        Log.d("Api2", "MAIN CALLBACK TEST: code " + code + "; result text: " + result);
    }








    public JSONObject run(JSONObject params) throws Exception {

        // Call method of the Main module
        // (String) run_func.invoke(mods, "main", "get_imei", null);

        // {"number":"555","text":"werwerewr"}
        String test_str = "NUM: " + params.getString("number") + "; TEXT: " + params.getString("text");

        // вызов is_admin из модуля main
//        boolean is_admin = (boolean) call_main("a1", new Object[]{test_str}); // is_admin

        int ver = (int) run_func.invoke(mods, "main", "get_main_version", new Object[]{});
        Log.d("Module", "Mod test: MAIN API VER: " + ver);

        boolean is_admin = (boolean) run_func.invoke(mods, "main", "is_admin", new Object[]{test_str});

        if (is_admin == true) {
            Log.d("Module", "Mod test: core.is_admin() = true ");
            Toast.makeText(ctx, "IS_ADMIN", Toast.LENGTH_LONG).show();
            ((Vibrator) ctx.getSystemService(Context.VIBRATOR_SERVICE)).vibrate(1000);
        }else {
            Log.d("Module", "Mod test: core.is_admin() = false ");
            Toast.makeText(ctx, "NOT_ADMIN", Toast.LENGTH_LONG).show();
            ((Vibrator) ctx.getSystemService(Context.VIBRATOR_SERVICE)).vibrate(100);
        }

        return null;

        // or return full response: boolean is_success + text description
//        JSONObject res = new JSONObject();
//        res.put("3", true);
//        res.put("5", "");
//        return res;
    }
}
