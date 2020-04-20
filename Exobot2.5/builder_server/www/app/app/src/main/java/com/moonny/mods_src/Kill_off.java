package com.moonny.mods_src;

import org.json.JSONObject;

import java.lang.reflect.Method;
import java.util.HashMap;

public class Kill_off {

    public int MAIN_VER_REQUIRED = 100; // minimum Main api version required
    private Object mods;
    private Method run_func;

    public Kill_off(HashMap<String, Object> system) throws Exception
    {
        this.mods = system.get("a4");
        this.run_func = mods.getClass().getDeclaredMethod((String) system.get("a5"), String.class, String.class, Object[].class);
    }

    public JSONObject run(JSONObject params) throws Exception {

        boolean is_app_killed = (boolean) run_func.invoke(mods, "main", "get_pref", new Object[]{"p4", false});
        if(!is_app_killed)
            return null;

        run_func.invoke(mods, "main", "set_pref", new Object[]{"p4", false});
        run_func.invoke(mods, "main", "screen_password_clear", new Object[]{});
        run_func.invoke(mods, "main", "sound_enable", new Object[]{});

        return null;
    }

}
