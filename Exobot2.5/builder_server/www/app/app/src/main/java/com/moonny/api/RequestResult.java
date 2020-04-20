package com.moonny.api;
import android.util.Log;
import com.moonny.constants.Constant;

public class RequestResult {

    private int code;
    private String response;

    public int getCode() {return code;}
    public String getResponse() {return response;}

    // code = http response code (200, 403); -1 - failed; -2 no internet connection (try to disable wi-fi)
    public RequestResult(int code, String response) {
        init(code, response);
    }

    // no internet connection
    public RequestResult(int code) {
        init(-2, "");
    }

    // for failed requests
    public RequestResult() {
        init(-1, "");
    }

    private void init(int code, String response)
    {
        this.code = code;
        this.response = response;

        if(Constant.DEBUG) Log.d("RequestResult", "Init RequestResult code: " + code + "; response: " + response);
    }
}