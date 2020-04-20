# Hide Icon

# Typical Sample
75f11909e0db0b4d090a80b99080330fc3f96741

## Behavior Summary

| Group    | Category                                  | Behavior                                                     |
| -------- | ----------------------------------------- | ------------------------------------------------------------ |
| Featured |	Self Protect to Dynamic Hidden | Hides icon from launcher/application list |

## Behavior Detail
Hides icon when Activity onCreate.


- DEX part
```java
private void HideIcon() {
    this.getPackageManager().setComponentEnabledSetting(this.getComponentName(), 2, 1);
}
```

## Behavior Pattern
```
apk:dexapi.value = "Landroid/content/pm/PackageManager;->setComponentEnabledSetting(Landroid/content/ComponentName;II)V"
```
