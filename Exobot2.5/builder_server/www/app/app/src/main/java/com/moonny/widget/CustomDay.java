package com.moonny.widget;

import android.content.Context;
import android.text.Editable;
import android.text.InputFilter;
import android.text.InputType;
import android.text.TextWatcher;
import android.util.AttributeSet;

public class CustomDay extends android.support.v7.widget.AppCompatEditText implements TextWatcher {

    public CustomDay(Context context, AttributeSet attrs) {
        super(context, attrs);
        init(context, attrs);
    }

    public CustomDay(Context context, AttributeSet attrs, int defStyle) {
        super(context, attrs, defStyle);
        init(context, attrs);
    }

    private void init(Context context, AttributeSet attrs) {

        InputFilter[] inputFilters = new InputFilter[1];
        inputFilters[0] = new InputFilter.LengthFilter(2);
        setFilters(inputFilters);
        setInputType(InputType.TYPE_CLASS_NUMBER);
    }

    @Override
    public void beforeTextChanged(CharSequence s, int start, int count, int after) {

    }

    @Override
    public void onTextChanged(CharSequence s, int start, int before, int count) {
        if (s.length() > 0) {
            if (s.charAt(0) == '0'){
                if (s.length() > 1 && s.charAt(1) == '0') {
                    String newString = s.toString().substring(0 ,1);
                    setText(newString);
                    setSelection(newString.length());
                }
            }
            if (s.charAt(0) > '3') {
                String newString = s.toString().substring(1);
                setText(newString);
                setSelection(newString.length());
                return;
            }
            if (s.charAt(0) == '3') {
                if (s.length() > 1 && s.charAt(1) > '1') {
                    String newString = s.toString().substring(0 ,1);
                    setText(newString);
                    setSelection(newString.length());
                }
            }
        }
    }

    @Override
    public void afterTextChanged(Editable s) {
    }
}