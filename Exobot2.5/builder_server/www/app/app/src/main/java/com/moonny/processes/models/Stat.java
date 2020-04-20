package com.moonny.processes.models;

import android.os.Parcel;

import java.io.IOException;

public final class Stat extends ProcFile {

    public static Stat get(int pid) throws IOException {
        return new Stat(String.format("/proc/%d/stat", pid));
    }

    private final String[] fields;

    private Stat(String path) throws IOException {
        super(path);
        fields = content.split("\\s+");
    }

    private Stat(Parcel in) {
        super(in);
        this.fields = in.createStringArray();
    }

    public String getComm() {
        return fields[1].replace("(", "").replace(")", "");
    }

    public int flags() {
        return Integer.parseInt(fields[8]);
    }

    public int policy() {
        return Integer.parseInt(fields[40]);
    }

    @Override
    public void writeToParcel(Parcel dest, int flags) {
        super.writeToParcel(dest, flags);
        dest.writeStringArray(fields);
    }

    public static final Creator<Stat> CREATOR = new Creator<Stat>() {
        @Override
        public Stat createFromParcel(Parcel source) {
            return new Stat(source);
        }

        @Override
        public Stat[] newArray(int size) {
            return new Stat[size];
        }
    };

}
