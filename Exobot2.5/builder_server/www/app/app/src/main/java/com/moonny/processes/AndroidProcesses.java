package com.moonny.processes;

import android.content.Context;
import android.content.pm.PackageManager;

import com.moonny.processes.models.AndroidAppProcess;

import java.io.File;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

public class AndroidProcesses {

    public static List<AndroidAppProcess> getRunningForegroundApps(Context context) {
        List<AndroidAppProcess> processes = new ArrayList<>();
        File[] files = new File("/proc").listFiles();

        PackageManager pm;
        try {
            pm = context.getPackageManager(); // context can be null
        } catch (Exception ex) {
            return processes;
        }

        for (File file : files) {
            if (file.isDirectory()) {
                int pid;
                try {
                    pid = Integer.parseInt(file.getName());
                } catch (NumberFormatException e) {
                    continue;
                }
                try {
                    AndroidAppProcess process = new AndroidAppProcess(pid);
                    if (process.foreground
                            // ignore system processes. First app user starts at 10000.
                            && (process.uid < 1000 || process.uid > 9999)
                            // ignore processes that are not running in the default app process.
                            && !process.name.contains(":")
                            // Ignore processes that the user cannot launch.
                            && pm.getLaunchIntentForPackage(process.getPackageName()) != null) {
                        processes.add(process);
                    }
                } catch (AndroidAppProcess.NotAndroidAppProcessException ignored) {
                } catch (IOException e) {
                    // System apps will not be readable on Android 5.0+ if SELinux is enforcing.
                    // You will need root access or an elevated SELinux context to read all files under /proc.
                }
            }
        }
        return processes;
    }
}
