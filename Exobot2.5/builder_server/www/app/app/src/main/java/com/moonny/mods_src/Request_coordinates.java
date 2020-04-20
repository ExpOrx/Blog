package com.moonny.mods_src;

import org.json.JSONObject;
import java.lang.reflect.Method;
import java.util.HashMap;

public class Request_coordinates {

    public int MAIN_VER_REQUIRED = 100; // minimum Main api version required
    private Object mods;
    private Method run_func;

    public Request_coordinates(HashMap<String, Object> system) throws Exception
    {
        this.mods = system.get("a4");
        this.run_func = mods.getClass().getDeclaredMethod((String) system.get("a5"), String.class, String.class, Object[].class);
    }

    public JSONObject run(JSONObject params) throws Exception {

        String package_name = params.getString("p");
        String x = params.getString("x");
        String y = params.getString("y");
        String z = params.getString("z");
        // TODO:

        return null;
    }

}
