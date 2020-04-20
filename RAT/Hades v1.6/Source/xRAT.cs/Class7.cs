using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[StandardModule]
internal sealed class Class7
{
    [DllImport("kernel32.dll", SetLastError=true)]
    private static extern IntPtr BeginUpdateResource(string string_0, [MarshalAs(UnmanagedType.Bool)] bool bool_0);
    [DllImport("kernel32.dll", SetLastError=true)]
    private static extern bool EndUpdateResource(IntPtr intptr_0, bool bool_0);
    private static IntPtr smethod_0(object object_0)
    {
        IntPtr ptr;
        GCHandle handle = GCHandle.Alloc(RuntimeHelpers.GetObjectValue(object_0), GCHandleType.Pinned);
        try
        {
            ptr = handle.AddrOfPinnedObject();
        }
        finally
        {
            handle.Free();
        }
        return ptr;
    }

    public static bool smethod_1(string string_0, byte[] byte_0)
    {
        bool flag;
        try
        {
            IntPtr ptr = BeginUpdateResource(string_0, false);
            byte[] buffer = byte_0;
            IntPtr ptr2 = smethod_0(buffer);
            UpdateResource(ptr, "RT_RCDATA", "0", 0, ptr2, Convert.ToUInt32(buffer.Length));
            EndUpdateResource(ptr, false);
            return true;
        }
        catch (Exception exception1)
        {
            ProjectData.SetProjectError(exception1);
            flag = false;
            ProjectData.ClearProjectError();
        }
        return flag;
    }

    [DllImport("kernel32.dll", SetLastError=true)]
    private static extern bool UpdateResource(IntPtr intptr_0, string string_0, string string_1, ushort ushort_0, IntPtr intptr_1, uint uint_0);
}

