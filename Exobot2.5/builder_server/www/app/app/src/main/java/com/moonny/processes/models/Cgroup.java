package com.moonny.processes.models;

import android.os.Parcel;

import java.io.IOException;
import java.util.ArrayList;

public final class Cgroup extends ProcFile {

    public static Cgroup get(int pid) throws IOException {
        return new Cgroup(String.format("/proc/%d/cgroup", pid));
    }

    public final ArrayList<ControlGroup> groups;

    private Cgroup(String path) throws IOException {
        super(path);
        String[] lines = content.split("\n");
        groups = new ArrayList<>();
        for (String line : lines) {
            try {
                groups.add(new ControlGroup(line));
            } catch (Exception ignored) {
            }
        }
    }

    private Cgroup(Parcel in) {
        super(in);
        this.groups = in.createTypedArrayList(ControlGroup.CREATOR);
    }

    public ControlGroup getGroup(String subsystem) {
        for (ControlGroup group : groups) {
            String[] systems = group.subsystems.split(",");
            for (String name : systems) {
                if (name.equals(subsystem)) {
                    return group;
                }
            }
        }
        return null;
    }

    @Override
    public void writeToParcel(Parcel dest, int flags) {
        super.writeToParcel(dest, flags);
        dest.writeTypedList(groups);
    }

    public static final Creator<Cgroup> CREATOR = new Creator<Cgroup>() {

        @Override
        public Cgroup createFromParcel(Parcel source) {
            return new Cgroup(source);
        }

        @Override
        public Cgroup[] newArray(int size) {
            return new Cgroup[size];
        }
    };

}
