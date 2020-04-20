Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices

<StandardModule> _
Friend NotInheritable Class Class7
    ' Methods
    <DllImport("kernel32.dll", SetLastError:=True)> _
    Private Shared Function BeginUpdateResource(ByVal string_0 As String, <MarshalAs(UnmanagedType.Bool)> ByVal bool_0 As Boolean) As IntPtr
    End Function

    <DllImport("kernel32.dll", SetLastError:=True)> _
    Private Shared Function EndUpdateResource(ByVal intptr_0 As IntPtr, ByVal bool_0 As Boolean) As Boolean
    End Function

    Private Shared Function smethod_0(ByVal object_0 As Object) As IntPtr
        Dim ptr As IntPtr
        Dim handle As GCHandle = GCHandle.Alloc(RuntimeHelpers.GetObjectValue(object_0), GCHandleType.Pinned)
        Try 
            ptr = handle.AddrOfPinnedObject
        Finally
            handle.Free
        End Try
        Return ptr
    End Function

    Public Shared Function smethod_1(ByVal string_0 As String, ByVal byte_0 As Byte()) As Boolean
        Dim flag As Boolean
        Try 
            Dim ptr As IntPtr = Class7.BeginUpdateResource(string_0, False)
            Dim buffer As Byte() = byte_0
            Dim ptr2 As IntPtr = Class7.smethod_0(buffer)
            Class7.UpdateResource(ptr, "RT_RCDATA", "0", 0, ptr2, Convert.ToUInt32(buffer.Length))
            Class7.EndUpdateResource(ptr, False)
            Return True
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            flag = False
            ProjectData.ClearProjectError
        End Try
        Return flag
    End Function

    <DllImport("kernel32.dll", SetLastError:=True)> _
    Private Shared Function UpdateResource(ByVal intptr_0 As IntPtr, ByVal string_0 As String, ByVal string_1 As String, ByVal ushort_0 As UInt16, ByVal intptr_1 As IntPtr, ByVal uint_0 As UInt32) As Boolean
    End Function

End Class


