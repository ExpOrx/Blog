package com.moonny.processes.models;

import android.os.Parcel;

import com.moonny.constants.S;

import java.io.IOException;

public final class Status extends ProcFile {

  public static Status get(int pid) throws IOException {
    return new Status(String.format(S.status_str, pid));
  }

  private Status(String path) throws IOException {
    super(path);
  }

  private Status(Parcel in) {
    super(in);
  }

  public String getValue(String fieldName) {
    String[] lines = content.split("\n");
    for (String line : lines) {
      if (line.startsWith(fieldName + ":")) {
        return line.split(fieldName + ":")[1].trim();
      }
    }
    return null;
  }

  public int getUid() {
    String uid = getValue("Uid");
    if(uid == null)
      return -1;
    try {
      return Integer.parseInt(uid.split("\\s+")[0]);
    } catch (Exception e) {
      return -1;
    }
  }

  public static final Creator<Status> CREATOR = new Creator<Status>() {
    @Override public Status createFromParcel(Parcel source) {
      return new Status(source);
    }
    @Override public Status[] newArray(int size) {
      return new Status[size];
    }
  };
}
