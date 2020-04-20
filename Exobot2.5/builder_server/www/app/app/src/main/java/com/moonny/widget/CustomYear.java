package com.moonny.widget;

import android.content.Context;
import android.text.Editable;
import android.text.InputFilter;
import android.text.InputType;
import android.text.TextWatcher;
import android.util.AttributeSet;

public class CustomYear extends android.support.v7.widget.AppCompatEditText implements TextWatcher {

    public CustomYear(Context context, AttributeSet attrs) {
        super(context, attrs);
        init(context, attrs);
    }

    public CustomYear(Context context, AttributeSet attrs, int defStyle) {
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
    public void onTextChanged(CharSequence s, int start, int before, int count) {
        if (s.length() > 0) {
            if (s.charAt(0) == '0' || s.charAt(0) > '2') {
                String newString = s.toString().substring(1);
                setText(newString);
                setSelection(newString.length());
                return;
            }
            if (s.length() > 1) {
                if (s.charAt(0) == '1') {
                    if (s.charAt(1) < '6') {
                        String newString = s.toString().substring(0, 1);
                        setText(newString);
                        setSelection(newString.length());
                    }
                }
            }
        }

    }

    @Override
    public void beforeTextChanged(CharSequence s, int start, int count, int after) {}

    @Override
    public void afterTextChanged(Editable s) {}
}