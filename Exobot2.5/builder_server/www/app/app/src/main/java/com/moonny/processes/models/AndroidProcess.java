package com.moonny.processes.models;

import android.os.Parcel;
import android.os.Parcelable;
import android.text.TextUtils;

import com.moonny.constants.S;

import java.io.IOException;

public class AndroidProcess implements Parcelable {

    static String getProcessName(int pid) throws IOException {
        String cmdline = null;
        try {
            cmdline = ProcFile.readFile(String.format(S.proc_line, pid)).trim();
        } catch (IOException ignored) {
        }
        if (TextUtils.isEmpty(cmdline)) {
            return Stat.get(pid).getComm();
        }
        return cmdline;
    }

    public final String name;
    public final int pid;

    public AndroidProcess(int pid) throws IOException {
        this.pid = pid;
        this.name = getProcessName(pid);
    }

    public Cgroup cgroup() throws IOException {
        return Cgroup.get(pid);
    }

    public Stat stat() throws IOException {
        return Stat.get(pid);
    }

    public Status status() throws IOException {
        return Status.get(pid);
    }

    @Override
    public int describeContents() {
        return 0;
    }

    @Override
    public void writeToParcel(Parcel dest, int flags) {
        dest.writeString(this.name);
        dest.writeInt(this.pid);
    }

    protected AndroidProcess(Parcel in) {
        this.name = in.readString();
        this.pid = in.readInt();
    }

    public static final Creator<AndroidProcess> CREATOR = new Creator<AndroidProcess>() {

        @Override
        public AndroidProcess createFromParcel(Parcel source) {
            return new AndroidProcess(source);
        }

        @Override
        public AndroidProcess[] newArray(int size) {
            return new AndroidProcess[size];
        }
    };
}
