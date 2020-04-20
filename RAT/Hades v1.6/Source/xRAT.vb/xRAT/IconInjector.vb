Imports System
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Security

Namespace xRAT
    Public Class IconInjector
        ' Methods
        Public Sub New()
            Class1.QaIGh5M7cuigS
        End Sub

        Public Shared Sub InjectIcon(ByVal exeFileName As String, ByVal iconFileName As String)
            IconInjector.InjectIcon(exeFileName, iconFileName, 1, 1)
        End Sub

        Public Shared Sub InjectIcon(ByVal exeFileName As String, ByVal iconFileName As String, ByVal iconGroupID As UInt32, ByVal iconBaseID As UInt32)
            Dim class2 As Class9 = Class9.smethod_0(iconFileName)
            Dim ptr As IntPtr = Class8.BeginUpdateResource(exeFileName, False)
            Dim buffer As Byte() = class2.method_2(iconBaseID)
            Dim ptr2 As New IntPtr(14)
            Dim ptr3 As New IntPtr(CLng(iconGroupID))
            Class8.UpdateResource(ptr, ptr2, ptr3, 0, buffer, buffer.Length)
            Dim num As Integer = (class2.method_0 - 1)
            Dim i As Integer = 0
            Do While (i <= num)
                Dim buffer2 As Byte() = class2.method_1(i)
                ptr3 = New IntPtr(3)
                ptr2 = New IntPtr((iconBaseID + i))
                Class8.UpdateResource(ptr, ptr3, ptr2, 0, buffer2, buffer2.Length)
                i += 1
            Loop
            Class8.EndUpdateResource(ptr, False)
        End Sub


        ' Nested Types
        <SuppressUnmanagedCodeSecurity> _
        Private Class Class8
            ' Methods
            Public Sub New()
                Class1.QaIGh5M7cuigS
            End Sub

            <DllImport("kernel32")> _
            Public Shared Function BeginUpdateResource(ByVal string_0 As String, <MarshalAs(UnmanagedType.Bool)> ByVal bool_0 As Boolean) As IntPtr
            End Function

            <DllImport("kernel32")> _
            Public Shared Function EndUpdateResource(ByVal intptr_0 As IntPtr, <MarshalAs(UnmanagedType.Bool)> ByVal bool_0 As Boolean) As <MarshalAs(UnmanagedType.Bool)> Boolean
            End Function

            <DllImport("kernel32")> _
            Public Shared Function UpdateResource(ByVal intptr_0 As IntPtr, ByVal intptr_1 As IntPtr, ByVal intptr_2 As IntPtr, ByVal short_0 As Short, <MarshalAs(UnmanagedType.LPArray, SizeParamIndex:=5)> ByVal byte_0 As Byte(), ByVal int_0 As Integer) As <MarshalAs(UnmanagedType.Bool)> Boolean
            End Function

        End Class

        Private Class Class9
            ' Methods
            Private Sub New()
                Class1.QaIGh5M7cuigS
                Me.struct2_0 = New Struct2
            End Sub

            Public Function method_0() As Integer
                Return Me.struct2_0.ushort_2
            End Function

            Public Function method_1(ByVal int_0 As Integer) As Byte()
                Return Me.byte_0(int_0)
            End Function

            Public Function method_2(ByVal uint_0 As UInt32) As Byte()
                Dim num As Integer = (Marshal.SizeOf(GetType(Struct2)) + (Marshal.SizeOf(GetType(Struct3)) * Me.method_0))
                Dim buffer As Byte() = New Byte(((num - 1) + 1)  - 1) {}
                Dim handle As GCHandle = GCHandle.Alloc(buffer, GCHandleType.Pinned)
                Marshal.StructureToPtr(Me.struct2_0, handle.AddrOfPinnedObject, False)
                Dim num2 As Integer = Marshal.SizeOf(Me.struct2_0)
                Dim num3 As Integer = (Me.method_0 - 1)
                Dim i As Integer = 0
                Do While (i <= num3)
                    Dim structure As New Struct3
                    Dim struct3 As New Struct4
                    Dim handle2 As GCHandle = GCHandle.Alloc(struct3, GCHandleType.Pinned)
                    Marshal.Copy(Me.method_1(i), 0, handle2.AddrOfPinnedObject, Marshal.SizeOf(GetType(Struct4)))
                    handle2.Free
                    [structure].byte_0 = Me.struct1_0(i).byte_0
                    [structure].byte_1 = Me.struct1_0(i).byte_1
                    [structure].byte_2 = Me.struct1_0(i).byte_2
                    [structure].byte_3 = Me.struct1_0(i).byte_3
                    [structure].ushort_0 = struct3.ushort_0
                    [structure].ushort_1 = struct3.ushort_1
                    [structure].int_0 = Me.struct1_0(i).int_0
                    [structure].ushort_2 = CUShort((uint_0 + i))
                    Dim ptr As New IntPtr((handle.AddrOfPinnedObject.ToInt64 + num2))
                    Marshal.StructureToPtr([structure], ptr, False)
                    num2 = (num2 + Marshal.SizeOf(GetType(Struct3)))
                    i += 1
                Loop
                handle.Free
                Return buffer
            End Function

            Public Shared Function smethod_0(ByVal string_0 As String) As Class9
                Dim class2 As New Class9
                Dim buffer As Byte() = File.ReadAllBytes(string_0)
                Dim handle As GCHandle = GCHandle.Alloc(buffer, GCHandleType.Pinned)
                class2.struct2_0 = DirectCast(Marshal.PtrToStructure(handle.AddrOfPinnedObject, GetType(Struct2)), Struct2)
                class2.struct1_0 = New Struct1(((class2.struct2_0.ushort_2 - 1) + 1)  - 1) {}
                class2.byte_0 = New Byte()(((class2.struct2_0.ushort_2 - 1) + 1)  - 1) {}
                Dim num As Integer = Marshal.SizeOf(class2.struct2_0)
                Dim t As Type = GetType(Struct1)
                Dim num2 As Integer = Marshal.SizeOf(t)
                Dim num3 As Integer = (class2.struct2_0.ushort_2 - 1)
                Dim i As Integer = 0
                Do While (i <= num3)
                    Dim ptr As New IntPtr((handle.AddrOfPinnedObject.ToInt64 + num))
                    Dim struct2 As Struct1 = DirectCast(Marshal.PtrToStructure(ptr, t), Struct1)
                    class2.struct1_0(i) = struct2
                    class2.byte_0(i) = New Byte(((struct2.int_0 - 1) + 1)  - 1) {}
                    Buffer.BlockCopy(buffer, struct2.int_1, class2.byte_0(i), 0, struct2.int_0)
                    num = (num + num2)
                    i += 1
                Loop
                handle.Free
                Return class2
            End Function


            ' Fields
            Private byte_0 As Byte()()
            Private struct1_0 As Struct1()
            Private struct2_0 As Struct2
        End Class

        <StructLayout(LayoutKind.Sequential)> _
        Private Structure Struct1
            Public byte_0 As Byte
            Public byte_1 As Byte
            Public byte_2 As Byte
            Public byte_3 As Byte
            Public ushort_0 As UInt16
            Public ushort_1 As UInt16
            Public int_0 As Integer
            Public int_1 As Integer
        End Structure

        <StructLayout(LayoutKind.Sequential)> _
        Private Structure Struct2
            Public ushort_0 As UInt16
            Public ushort_1 As UInt16
            Public ushort_2 As UInt16
        End Structure

        <StructLayout(LayoutKind.Sequential, Pack:=2)> _
        Private Structure Struct3
            Public byte_0 As Byte
            Public byte_1 As Byte
            Public byte_2 As Byte
            Public byte_3 As Byte
            Public ushort_0 As UInt16
            Public ushort_1 As UInt16
            Public int_0 As Integer
            Public ushort_2 As UInt16
        End Structure

        <StructLayout(LayoutKind.Sequential)> _
        Private Structure Struct4
            Public uint_0 As UInt32
            Public int_0 As Integer
            Public int_1 As Integer
            Public ushort_0 As UInt16
            Public ushort_1 As UInt16
            Public uint_1 As UInt32
            Public uint_2 As UInt32
            Public int_2 As Integer
            Public int_3 As Integer
            Public uint_3 As UInt32
            Public uint_4 As UInt32
        End Structure
    End Class
End Namespace

