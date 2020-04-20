using Microsoft.VisualBasic.CompilerServices;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

[StandardModule]
internal sealed class Class6
{
    public static object smethod_0(string string_0, string string_1)
    {
        RijndaelManaged managed = new RijndaelManaged();
        MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider();
        byte[] buffer = provider.ComputeHash(Encoding.UTF8.GetBytes(string_0));
        provider.Clear();
        managed.Key = buffer;
        managed.GenerateIV();
        byte[] iV = managed.IV;
        MemoryStream stream = new MemoryStream();
        stream.Write(iV, 0, iV.Length);
        CryptoStream stream2 = new CryptoStream(stream, managed.CreateEncryptor(), CryptoStreamMode.Write);
        byte[] bytes = Encoding.UTF8.GetBytes(string_1);
        stream2.Write(bytes, 0, bytes.Length);
        stream2.FlushFinalBlock();
        byte[] inArray = stream.ToArray();
        stream2.Close();
        managed.Clear();
        return Convert.ToBase64String(inArray);
    }

    public static object smethod_1(string string_0, string string_1)
    {
        RijndaelManaged managed = new RijndaelManaged();
        MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider();
        byte[] buffer = provider.ComputeHash(Encoding.UTF8.GetBytes(string_0));
        provider.Clear();
        MemoryStream stream = new MemoryStream(Convert.FromBase64String(string_1));
        byte[] buffer3 = new byte[0x10];
        stream.Read(buffer3, 0, 0x10);
        managed.IV = buffer3;
        managed.Key = buffer;
        CryptoStream stream2 = new CryptoStream(stream, managed.CreateDecryptor(), CryptoStreamMode.Read);
        byte[] buffer4 = new byte[((int) (stream.Length - 0x10L)) + 1];
        int count = stream2.Read(buffer4, 0, buffer4.Length);
        stream2.Close();
        managed.Clear();
        return Encoding.UTF8.GetString(buffer4, 0, count);
    }
}

