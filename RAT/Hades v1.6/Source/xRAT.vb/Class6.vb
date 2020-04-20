Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text

<StandardModule> _
Friend NotInheritable Class Class6
    ' Methods
    Public Shared Function smethod_0(ByVal string_0 As String, ByVal string_1 As String) As Object
        Dim managed As New RijndaelManaged
        Dim provider As New MD5CryptoServiceProvider
        Dim buffer As Byte() = provider.ComputeHash(Encoding.UTF8.GetBytes(string_0))
        provider.Clear
        managed.Key = buffer
        managed.GenerateIV
        Dim iV As Byte() = managed.IV
        Dim stream As New MemoryStream
        stream.Write(iV, 0, iV.Length)
        Dim stream2 As New CryptoStream(stream, managed.CreateEncryptor, CryptoStreamMode.Write)
        Dim bytes As Byte() = Encoding.UTF8.GetBytes(string_1)
        stream2.Write(bytes, 0, bytes.Length)
        stream2.FlushFinalBlock
        Dim inArray As Byte() = stream.ToArray
        stream2.Close
        managed.Clear
        Return Convert.ToBase64String(inArray)
    End Function

    Public Shared Function smethod_1(ByVal string_0 As String, ByVal string_1 As String) As Object
        Dim managed As New RijndaelManaged
        Dim provider As New MD5CryptoServiceProvider
        Dim buffer As Byte() = provider.ComputeHash(Encoding.UTF8.GetBytes(string_0))
        provider.Clear
        Dim stream As New MemoryStream(Convert.FromBase64String(string_1))
        Dim buffer3 As Byte() = New Byte(&H10  - 1) {}
        stream.Read(buffer3, 0, &H10)
        managed.IV = buffer3
        managed.Key = buffer
        Dim stream2 As New CryptoStream(stream, managed.CreateDecryptor, CryptoStreamMode.Read)
        Dim buffer4 As Byte() = New Byte((CInt((stream.Length - &H10)) + 1)  - 1) {}
        Dim count As Integer = stream2.Read(buffer4, 0, buffer4.Length)
        stream2.Close
        managed.Clear
        Return Encoding.UTF8.GetString(buffer4, 0, count)
    End Function

End Class


