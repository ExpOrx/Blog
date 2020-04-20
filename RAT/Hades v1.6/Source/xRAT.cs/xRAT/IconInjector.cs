namespace xRAT
{
    using System;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Security;

    public class IconInjector
    {
        public IconInjector()
        {
            Class1.QaIGh5M7cuigS();
        }

        public static void InjectIcon(string exeFileName, string iconFileName)
        {
            InjectIcon(exeFileName, iconFileName, 1, 1);
        }

        public static void InjectIcon(string exeFileName, string iconFileName, uint iconGroupID, uint iconBaseID)
        {
            Class9 class2 = Class9.smethod_0(iconFileName);
            IntPtr ptr = Class8.BeginUpdateResource(exeFileName, false);
            byte[] buffer = class2.method_2(iconBaseID);
            IntPtr ptr2 = new IntPtr(14L);
            IntPtr ptr3 = new IntPtr((long) iconGroupID);
            Class8.UpdateResource(ptr, ptr2, ptr3, 0, buffer, buffer.Length);
            int num = class2.method_0() - 1;
            for (int i = 0; i <= num; i++)
            {
                byte[] buffer2 = class2.method_1(i);
                ptr3 = new IntPtr(3L);
                ptr2 = new IntPtr(iconBaseID + i);
                Class8.UpdateResource(ptr, ptr3, ptr2, 0, buffer2, buffer2.Length);
            }
            Class8.EndUpdateResource(ptr, false);
        }

        [SuppressUnmanagedCodeSecurity]
        private class Class8
        {
            public Class8()
            {
                Class1.QaIGh5M7cuigS();
            }

            [DllImport("kernel32")]
            public static extern IntPtr BeginUpdateResource(string string_0, [MarshalAs(UnmanagedType.Bool)] bool bool_0);
            [return: MarshalAs(UnmanagedType.Bool)]
            [DllImport("kernel32")]
            public static extern bool EndUpdateResource(IntPtr intptr_0, [MarshalAs(UnmanagedType.Bool)] bool bool_0);
            [return: MarshalAs(UnmanagedType.Bool)]
            [DllImport("kernel32")]
            public static extern bool UpdateResource(IntPtr intptr_0, IntPtr intptr_1, IntPtr intptr_2, short short_0, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex=5)] byte[] byte_0, int int_0);
        }

        private class Class9
        {
            private byte[][] byte_0;
            private IconInjector.Struct1[] struct1_0;
            private IconInjector.Struct2 struct2_0;

            private Class9()
            {
                Class1.QaIGh5M7cuigS();
                this.struct2_0 = new IconInjector.Struct2();
            }

            public int method_0()
            {
                return this.struct2_0.ushort_2;
            }

            public byte[] method_1(int int_0)
            {
                return this.byte_0[int_0];
            }

            public byte[] method_2(uint uint_0)
            {
                int num = Marshal.SizeOf(typeof(IconInjector.Struct2)) + (Marshal.SizeOf(typeof(IconInjector.Struct3)) * this.method_0());
                byte[] buffer = new byte[(num - 1) + 1];
                GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
                Marshal.StructureToPtr(this.struct2_0, handle.AddrOfPinnedObject(), false);
                int num2 = Marshal.SizeOf(this.struct2_0);
                int num3 = this.method_0() - 1;
                for (int i = 0; i <= num3; i++)
                {
                    IconInjector.Struct3 structure = new IconInjector.Struct3();
                    IconInjector.Struct4 struct3 = new IconInjector.Struct4();
                    GCHandle handle2 = GCHandle.Alloc(struct3, GCHandleType.Pinned);
                    Marshal.Copy(this.method_1(i), 0, handle2.AddrOfPinnedObject(), Marshal.SizeOf(typeof(IconInjector.Struct4)));
                    handle2.Free();
                    structure.byte_0 = this.struct1_0[i].byte_0;
                    structure.byte_1 = this.struct1_0[i].byte_1;
                    structure.byte_2 = this.struct1_0[i].byte_2;
                    structure.byte_3 = this.struct1_0[i].byte_3;
                    structure.ushort_0 = struct3.ushort_0;
                    structure.ushort_1 = struct3.ushort_1;
                    structure.int_0 = this.struct1_0[i].int_0;
                    structure.ushort_2 = (ushort) (uint_0 + i);
                    IntPtr ptr = new IntPtr(handle.AddrOfPinnedObject().ToInt64() + num2);
                    Marshal.StructureToPtr(structure, ptr, false);
                    num2 += Marshal.SizeOf(typeof(IconInjector.Struct3));
                }
                handle.Free();
                return buffer;
            }

            public static IconInjector.Class9 smethod_0(string string_0)
            {
                IconInjector.Class9 class2 = new IconInjector.Class9();
                byte[] buffer = File.ReadAllBytes(string_0);
                GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
                class2.struct2_0 = (IconInjector.Struct2) Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(IconInjector.Struct2));
                class2.struct1_0 = new IconInjector.Struct1[(class2.struct2_0.ushort_2 - 1) + 1];
                class2.byte_0 = new byte[(class2.struct2_0.ushort_2 - 1) + 1][];
                int num = Marshal.SizeOf(class2.struct2_0);
                Type t = typeof(IconInjector.Struct1);
                int num2 = Marshal.SizeOf(t);
                int num3 = class2.struct2_0.ushort_2 - 1;
                for (int i = 0; i <= num3; i++)
                {
                    IntPtr ptr = new IntPtr(handle.AddrOfPinnedObject().ToInt64() + num);
                    IconInjector.Struct1 struct2 = (IconInjector.Struct1) Marshal.PtrToStructure(ptr, t);
                    class2.struct1_0[i] = struct2;
                    class2.byte_0[i] = new byte[(struct2.int_0 - 1) + 1];
                    Buffer.BlockCopy(buffer, struct2.int_1, class2.byte_0[i], 0, struct2.int_0);
                    num += num2;
                }
                handle.Free();
                return class2;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct Struct1
        {
            public byte byte_0;
            public byte byte_1;
            public byte byte_2;
            public byte byte_3;
            public ushort ushort_0;
            public ushort ushort_1;
            public int int_0;
            public int int_1;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct Struct2
        {
            public ushort ushort_0;
            public ushort ushort_1;
            public ushort ushort_2;
        }

        [StructLayout(LayoutKind.Sequential, Pack=2)]
        private struct Struct3
        {
            public byte byte_0;
            public byte byte_1;
            public byte byte_2;
            public byte byte_3;
            public ushort ushort_0;
            public ushort ushort_1;
            public int int_0;
            public ushort ushort_2;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct Struct4
        {
            public uint uint_0;
            public int int_0;
            public int int_1;
            public ushort ushort_0;
            public ushort ushort_1;
            public uint uint_1;
            public uint uint_2;
            public int int_2;
            public int int_3;
            public uint uint_3;
            public uint uint_4;
        }
    }
}

