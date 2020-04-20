# End Call

# Typical Sample
75f11909e0db0b4d090a80b99080330fc3f96741

## Behavior Summary

| Group    | Category                                  | Behavior                                                     |
| -------- | ----------------------------------------- | ------------------------------------------------------------ |
| Featured |Unauthorized Call Operation | Hang up the incoming call without user consent  |



## Behavior Detail
Hang up(based on command from c2) the incoming call without user consent

- AXML part

  ```axml
  <uses-permission android:name="android.permission.CALL_PHONE" />
  ...
  <application ...>
    <receiver android:name="com.mix_four.dd.PhoneListener">
        <intent-filter android:priority="1000">
            <action android:name="android.intent.action.PHONE_STATE" />
            <category android:name="android.intent.category.DEFAULT" />
        </intent-filter>
    </receiver>
  ...
  </application>
  ```


- DEX part

  ```java
  private void endCall() {
       Object v3 = CoreService.mContext.getSystemService("phone");
       Class v0 = TelephonyManager.class;
       try {
           Method v2 = v0.getDeclaredMethod("getITelephony", null);
           v2.setAccessible(true);
           v2.invoke(v3, null).endCall();
       }
       catch(Exception v4) {
       }
   }
  ```


  ## Behavior Pattern
  ```
  apk:axml.value = "/manifest/uses-permission[@android:name=\"android.permission.CALL_PHONE\"]"
  apk:axml.value = "/manifest/application/receiver/intent-filter/action[@android:name=\"android.intent.action.PHONE_STAT\"]"
  apk:dexapi.value = "Lcom/android/internal/telephony/ITelephony;->endCall()Z"
  apk:dexstring.value = "getITelephony"
  ```
