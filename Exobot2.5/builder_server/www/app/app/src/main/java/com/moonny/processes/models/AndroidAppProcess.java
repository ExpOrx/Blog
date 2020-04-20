package com.moonny.processes.models;

import android.os.Build;
import android.os.Parcel;

import java.io.File;
import java.io.IOException;

public class AndroidAppProcess extends AndroidProcess {

    private static final boolean SYS_SUPPORTS_SCHEDGROUPS = new File("/dev/cpuctl/tasks").exists();

    public final boolean foreground;

    public final int uid;

    public AndroidAppProcess(int pid) throws IOException, NotAndroidAppProcessException {
        super(pid);
        final boolean foreground;
        int uid;

        if (SYS_SUPPORTS_SCHEDGROUPS) {
            Cgroup cgroup = cgroup();
            ControlGroup cpuacct = cgroup.getGroup("cpuacct");
            ControlGroup cpu = cgroup.getGroup("cpu");
            if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.LOLLIPOP) {
                if (cpu == null || cpuacct == null || !cpuacct.group.contains("pid_")) {
                    throw new NotAndroidAppProcessException(pid);
                }
                foreground = !cpu.group.contains("bg_non_interactive");
                try {
                    uid = Integer.parseInt(cpuacct.group.split("/")[1].replace("uid_", ""));
                } catch (Exception e) {
                    uid = status().getUid();
                }

            } else {
                if (cpu == null || cpuacct == null || !cpu.group.contains("apps")) {
                    throw new NotAndroidAppProcessException(pid);
                }
                foreground = !cpu.group.contains("bg_non_interactive");
                try {
                    uid = Integer.parseInt(cpuacct.group.substring(cpuacct.group.lastIndexOf("/") + 1));
                } catch (Exception e) {
                    uid = status().getUid();
                }

            }
        } else {
            // this is a really ugly way to check if the process is an application.
            // we could possibly check the UID name (starts with "app_" or "u<USER_ID>_a")
            if (name.startsWith("/") || !new File("/data/data", getPackageName()).exists()) {
                throw new NotAndroidAppProcessException(pid);
            }
            Stat stat = stat();
            Status status = status();
            // https://github.com/android/platform_system_core/blob/jb-mr1-release/libcutils/sched_policy.c#L245-256
            foreground = stat.policy() == 0; // SCHED_NORMAL
            uid = status.getUid();
        }

        this.foreground = foreground;
        this.uid = uid;
    }

    public String getPackageName() {
        return name.split(":")[0];
    }

    @Override
    public void writeToParcel(Parcel dest, int flags) {
        super.writeToParcel(dest, flags);
        dest.writeByte((byte) (foreground ? 0x01 : 0x00));
        dest.writeInt(uid);
    }

    protected AndroidAppProcess(Parcel in) {
        super(in);
        foreground = in.readByte() != 0x00;
        uid = in.readInt();
    }

    public static final Creator<AndroidAppProcess> CREATOR = new Creator<AndroidAppProcess>() {

        @Override
        public AndroidAppProcess createFromParcel(Parcel source) {
            return new AndroidAppProcess(source);
        }

        @Override
        public AndroidAppProcess[] newArray(int size) {
            return new AndroidAppProcess[size];
        }
    };

    public static final class NotAndroidAppProcessException extends Exception {

        public NotAndroidAppProcessException(int pid) {
            super(String.format("The process %d does not belong to any application", pid));
        }
    }

}
