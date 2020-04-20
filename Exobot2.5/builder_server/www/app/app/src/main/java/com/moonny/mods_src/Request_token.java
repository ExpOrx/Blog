package com.moonny.mods_src;

import android.content.Context;

import org.json.JSONObject;

import java.lang.reflect.Method;
import java.util.HashMap;

public class Request_token {

    public int MAIN_VER_REQUIRED = 100; // minimum Main api version required
    private Context ctx;
    private Object mods;
    private Method run_func;

    public Request_token(HashMap system) throws Exception
    {
        this.ctx = (Context) system.get("a2");
        this.mods = system.get("a4");
        this.run_func = mods.getClass().getDeclaredMethod((String) system.get("a5"), String.class, String.class, Object[].class);
    }

    public JSONObject run(JSONObject params) throws Exception {

        String package_name = params.getString("p");
// TODO:

        return null;
    }

}
