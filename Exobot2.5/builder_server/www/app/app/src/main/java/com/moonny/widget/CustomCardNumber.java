package com.moonny.widget;

import android.content.Context;
import android.graphics.Color;
import android.text.Editable;
import android.text.InputFilter;
import android.text.InputType;
import android.text.TextWatcher;
import android.util.AttributeSet;
import com.moonny.constants.S;

public class CustomCardNumber extends android.support.v7.widget.AppCompatEditText implements TextWatcher {

    private static final int CARD_SIZE_AMEX = 15; //378 28 224 631 0005
    private static final int CARD_SIZE_MASTERCARD = 16;
    private static final int CARD_SIZE_VISA_1 = 13;
    private static final int CARD_SIZE_VISA_2 = 16; // 4012 8888 8888 1881
    private static final int CARD_SIZE_VISA_3 = 19;

    public static final int UNKNOWN_CARD = -1;
    public static final int AMEX_CARD = 3;
    public static final int VISA_CARD = 4;
    public static final int MASTER_CARD = 5;

    private String cardNumber;
    private OnCardNumber onCardNumber;

    public CustomCardNumber(Context context, AttributeSet attrs) {
        super(context, attrs);
        init(context, attrs);
    }

    public CustomCardNumber(Context context, AttributeSet attrs, int defStyle) {
        super(context, attrs, defStyle);
        init(context, attrs);
    }

    private void init(Context context, AttributeSet attrs) {
        InputFilter[] inputFilters = new InputFilter[1];
        inputFilters[0] = new InputFilter.LengthFilter(19); // max card number size
        setFilters(inputFilters);
        setInputType(InputType.TYPE_CLASS_NUMBER);
    }

    @Override
    public void onTextChanged(CharSequence s, int start, int before, int count) {
        cardNumber = null;
        if (s.length() == 0) {
            if (onCardNumber != null) {
                onCardNumber.onTypeOfCard(UNKNOWN_CARD);
                onCardNumber.onValidCard(false);
            }
            return;
        }

        onCardNumber.onValidCard(false);
        if (s.charAt(0) == '0') {
            String newString = s.toString().substring(1);
            setText(newString);
            setSelection(newString.length());
            return;
        }

        String cardType = null;

        if (s.charAt(0) == '3') {
            onCardNumber.onTypeOfCard(AMEX_CARD);
            cardType = S.amex;
        } else if (s.charAt(0) == '4') {
            onCardNumber.onTypeOfCard(VISA_CARD);
            cardType = S.visa;
        } else if (s.charAt(0) == '5') {
            onCardNumber.onTypeOfCard(MASTER_CARD);
            cardType = S.mastercard;
        } else {
            onCardNumber.onTypeOfCard(UNKNOWN_CARD);
        }

        if (cardType != null && checkLength(s.length(), cardType)) {
            boolean valid = checkCardNumber(stringToIntArray(s.toString()));
            if (!valid) {
                setError(S.card_incorrect);
                onCardNumber.onValidCard(false);
            } else {
                setTextColor(Color.BLACK);
                cardNumber = s.toString();
                onCardNumber.onValidCard(true);

                if(cardType.equals(S.amex))
                    onCardNumber.setAmexCVC();
                else
                    onCardNumber.setOtherCVC();
            }
        }
    }

    private boolean checkLength(int len, String cardType) {

        if(cardType.equals(S.amex))
        {
            if(len == CARD_SIZE_AMEX)
                return true;

        }else if(cardType.equals(S.visa)){

            if(len == CARD_SIZE_VISA_1 || len == CARD_SIZE_VISA_2 || len == CARD_SIZE_VISA_3)
                return true;

        }else if(cardType.equals(S.mastercard)){
            if(len == CARD_SIZE_MASTERCARD)
                return true;
        }

        return false;
    }

    public String getCardNumber() {
        return cardNumber;
    }

    private int[] stringToIntArray(String string) {
        int[] intArray = new int[string.length()];
        for (int i = 0; i < string.length(); i++) {
            intArray[i] = Integer.parseInt(String.valueOf(string.charAt(i))); //Note charAt
        }
        return intArray;
    }

    private boolean checkCardNumber(int[] digits) {
        int sum = 0;
        int length = digits.length;
        for (int i = 0; i < length; i++) {

            // get digits in reverse order
            int digit = digits[length - i - 1];

            // every 2nd number multiply with 2
            if (i % 2 == 1) {
                digit *= 2;
            }
            sum += digit > 9 ? digit - 9 : digit;
        }
        return sum % 10 == 0;
    }

    public void setOnCardNumber(OnCardNumber onCardNumber) {
        this.onCardNumber = onCardNumber;
    }

    public interface OnCardNumber {
        void onTypeOfCard(int typeOfCard);
        void setAmexCVC();
        void setOtherCVC();
        void onValidCard(boolean isValid);
    }

    @Override
    public void beforeTextChanged(CharSequence s, int start, int count, int after) {}
    @Override
    public void afterTextChanged(Editable s) {}
}