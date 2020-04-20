using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using xRAT;

[HideModuleName, StandardModule, GeneratedCode("MyTemplate", "8.0.0.0")]
internal sealed class Class2
{
    private static readonly Class0<Class10> class0_0;
    private static readonly Class0<Form0> class0_1;
    private static readonly Class0<User> class0_2;
    private static Class0<Class4> class0_3;
    private static readonly Class0<Class3> class0_4;

    static Class2()
    {
        Class1.QaIGh5M7cuigS();
        class0_0 = new Class0<Class10>();
        class0_1 = new Class0<Form0>();
        class0_2 = new Class0<User>();
        class0_3 = new Class0<Class4>();
        class0_4 = new Class0<Class3>();
    }

    [HelpKeyword("My.Computer")]
    internal static Class10 Class10_0
    {
        [DebuggerHidden]
        get
        {
            return class0_0.method_0();
        }
    }

    [HelpKeyword("My.WebServices")]
    internal static Class3 Class3_0
    {
        [DebuggerHidden]
        get
        {
            return class0_4.method_0();
        }
    }

    [HelpKeyword("My.Forms")]
    internal static Class4 Class4_0
    {
        [DebuggerHidden]
        get
        {
            return class0_3.method_0();
        }
    }

    [HelpKeyword("My.Application")]
    internal static Form0 Form0_0
    {
        [DebuggerHidden]
        get
        {
            return class0_1.method_0();
        }
    }

    [HelpKeyword("My.User")]
    internal static User User_0
    {
        [DebuggerHidden]
        get
        {
            return class0_2.method_0();
        }
    }

    [ComVisible(false), EditorBrowsable(EditorBrowsableState.Never)]
    internal sealed class Class0<T> where T: new()
    {
        [ThreadStatic, CompilerGenerated]
        private static T gparam_0;

        [EditorBrowsable(EditorBrowsableState.Never), DebuggerHidden]
        public Class0()
        {
            Class1.QaIGh5M7cuigS();
        }

        [DebuggerHidden]
        internal T method_0()
        {
            if (Class2.Class0<T>.gparam_0 == null)
            {
                Class2.Class0<T>.gparam_0 = Activator.CreateInstance<T>();
            }
            return Class2.Class0<T>.gparam_0;
        }
    }

    [EditorBrowsable(EditorBrowsableState.Never), MyGroupCollection("System.Web.Services.Protocols.SoapHttpClientProtocol", "Create__Instance__", "Dispose__Instance__", "")]
    internal sealed class Class3
    {
        [EditorBrowsable(EditorBrowsableState.Never), DebuggerHidden]
        public Class3()
        {
            Class1.QaIGh5M7cuigS();
        }

        [DebuggerHidden, EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj)
        {
            return base.Equals(RuntimeHelpers.GetObjectValue(obj));
        }

        [DebuggerHidden, EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        [DebuggerHidden, EditorBrowsable(EditorBrowsableState.Never)]
        internal Type method_0()
        {
            return typeof(Class2.Class3);
        }

        [DebuggerHidden]
        private void method_1<T>(ref T gparam_0)
        {
            gparam_0 = default(T);
        }

        [DebuggerHidden]
        private static T smethod_0<T>(object instance) where T: new()
        {
            if (((T) instance) == null)
            {
                return Activator.CreateInstance<T>();
            }
            return (T) instance;
        }

        [DebuggerHidden, EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString()
        {
            return base.ToString();
        }
    }

    [MyGroupCollection("System.Windows.Forms.Form", "Create__Instance__", "Dispose__Instance__", "My.MyProject.Forms"), EditorBrowsable(EditorBrowsableState.Never)]
    internal sealed class Class4
    {
        [ThreadStatic]
        private static Hashtable hashtable_0;
        public object object_0;
        public object object_1;
        public object object_10;
        public object object_11;
        public object object_12;
        public object object_13;
        public object object_14;
        public object object_15;
        public object object_16;
        public object object_17;
        public object object_18;
        public object object_19;
        public object object_2;
        public object object_20;
        public object object_21;
        public object object_22;
        public object object_23;
        public object object_24;
        public object object_25;
        public object object_26;
        public object object_3;
        public object object_4;
        public object object_5;
        public object object_6;
        public object object_7;
        public object object_8;
        public object object_9;

        [EditorBrowsable(EditorBrowsableState.Never), DebuggerHidden]
        public Class4()
        {
            Class1.QaIGh5M7cuigS();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj)
        {
            return base.Equals(RuntimeHelpers.GetObjectValue(obj));
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public void kCxtdfSub(noip noip_0)
        {
            if (noip_0 != this.object_14)
            {
                if (noip_0 != null)
                {
                    throw new ArgumentException("Property can only be set to Nothing");
                }
                this.method_53<noip>(ref (noip) ref this.object_14);
            }
        }

        public Avast method_0()
        {
            this.object_0 = smethod_0<Avast>(this.object_0);
            return (Avast) this.object_0;
        }

        public bitcoinn method_1()
        {
            this.object_1 = smethod_0<bitcoinn>(this.object_1);
            return (bitcoinn) this.object_1;
        }

        public HTTP_F method_10()
        {
            this.object_10 = smethod_0<HTTP_F>(this.object_10);
            return (HTTP_F) this.object_10;
        }

        public ip method_11()
        {
            this.object_11 = smethod_0<ip>(this.object_11);
            return (ip) this.object_11;
        }

        public IP_Tracer method_12()
        {
            this.object_12 = smethod_0<IP_Tracer>(this.object_12);
            return (IP_Tracer) this.object_12;
        }

        public MSG method_13()
        {
            this.object_13 = smethod_0<MSG>(this.object_13);
            return (MSG) this.object_13;
        }

        public noip method_14()
        {
            this.object_14 = smethod_0<noip>(this.object_14);
            return (noip) this.object_14;
        }

        public notifyzone method_15()
        {
            this.object_15 = smethod_0<notifyzone>(this.object_15);
            return (notifyzone) this.object_15;
        }

        public OpenURL method_16()
        {
            this.object_16 = smethod_0<OpenURL>(this.object_16);
            return (OpenURL) this.object_16;
        }

        public PortScanner method_17()
        {
            this.object_17 = smethod_0<PortScanner>(this.object_17);
            return (PortScanner) this.object_17;
        }

        public xRAT.Process method_18()
        {
            this.object_18 = smethod_0<xRAT.Process>(this.object_18);
            return (xRAT.Process) this.object_18;
        }

        public Processes method_19()
        {
            this.object_19 = smethod_0<Processes>(this.object_19);
            return (Processes) this.object_19;
        }

        public Builder method_2()
        {
            this.object_2 = smethod_0<Builder>(this.object_2);
            return (Builder) this.object_2;
        }

        public RemoteDesktop method_20()
        {
            this.object_20 = smethod_0<RemoteDesktop>(this.object_20);
            return (RemoteDesktop) this.object_20;
        }

        public Settings method_21()
        {
            this.object_21 = smethod_0<Settings>(this.object_21);
            return (Settings) this.object_21;
        }

        public Stealer method_22()
        {
            this.object_22 = smethod_0<Stealer>(this.object_22);
            return (Stealer) this.object_22;
        }

        public SYN method_23()
        {
            this.object_23 = smethod_0<SYN>(this.object_23);
            return (SYN) this.object_23;
        }

        public SysInfo method_24()
        {
            this.object_24 = smethod_0<SysInfo>(this.object_24);
            return (SysInfo) this.object_24;
        }

        public UDP method_25()
        {
            this.object_25 = smethod_0<UDP>(this.object_25);
            return (UDP) this.object_25;
        }

        public WWebcam method_26()
        {
            this.object_26 = smethod_0<WWebcam>(this.object_26);
            return (WWebcam) this.object_26;
        }

        public void method_27(Avast avast_0)
        {
            if (avast_0 != this.object_0)
            {
                if (avast_0 != null)
                {
                    throw new ArgumentException("Property can only be set to Nothing");
                }
                this.method_53<Avast>(ref (Avast) ref this.object_0);
            }
        }

        public void method_28(bitcoinn bitcoinn_0)
        {
            if (bitcoinn_0 != this.object_1)
            {
                if (bitcoinn_0 != null)
                {
                    throw new ArgumentException("Property can only be set to Nothing");
                }
                this.method_53<bitcoinn>(ref (bitcoinn) ref this.object_1);
            }
        }

        public void method_29(Builder builder_0)
        {
            if (builder_0 != this.object_2)
            {
                if (builder_0 != null)
                {
                    throw new ArgumentException("Property can only be set to Nothing");
                }
                this.method_53<Builder>(ref (Builder) ref this.object_2);
            }
        }

        public Chat method_3()
        {
            this.object_3 = smethod_0<Chat>(this.object_3);
            return (Chat) this.object_3;
        }

        public void method_30(Chat chat_0)
        {
            if (chat_0 != this.object_3)
            {
                if (chat_0 != null)
                {
                    throw new ArgumentException("Property can only be set to Nothing");
                }
                this.method_53<Chat>(ref (Chat) ref this.object_3);
            }
        }

        public void method_31(DL dl_0)
        {
            if (dl_0 != this.object_4)
            {
                if (dl_0 != null)
                {
                    throw new ArgumentException("Property can only be set to Nothing");
                }
                this.method_53<DL>(ref (DL) ref this.object_4);
            }
        }

        public void method_32(File_Manager file_Manager_0)
        {
            if (file_Manager_0 != this.object_5)
            {
                if (file_Manager_0 != null)
                {
                    throw new ArgumentException("Property can only be set to Nothing");
                }
                this.method_53<File_Manager>(ref (File_Manager) ref this.object_5);
            }
        }

        public void method_33(Form1 form1_0)
        {
            if (form1_0 != this.object_6)
            {
                if (form1_0 != null)
                {
                    throw new ArgumentException("Property can only be set to Nothing");
                }
                this.method_53<Form1>(ref (Form1) ref this.object_6);
            }
        }

        public void method_34(Form2 form2_0)
        {
            if (form2_0 != this.object_7)
            {
                if (form2_0 != null)
                {
                    throw new ArgumentException("Property can only be set to Nothing");
                }
                this.method_53<Form2>(ref (Form2) ref this.object_7);
            }
        }

        public void method_35(FrmListen frmListen_0)
        {
            if (frmListen_0 != this.object_8)
            {
                if (frmListen_0 != null)
                {
                    throw new ArgumentException("Property can only be set to Nothing");
                }
                this.method_53<FrmListen>(ref (FrmListen) ref this.object_8);
            }
        }

        public void method_36(hijackb hijackb_0)
        {
            if (hijackb_0 != this.object_9)
            {
                if (hijackb_0 != null)
                {
                    throw new ArgumentException("Property can only be set to Nothing");
                }
                this.method_53<hijackb>(ref (hijackb) ref this.object_9);
            }
        }

        public void method_37(HTTP_F http_F_0)
        {
            if (http_F_0 != this.object_10)
            {
                if (http_F_0 != null)
                {
                    throw new ArgumentException("Property can only be set to Nothing");
                }
                this.method_53<HTTP_F>(ref (HTTP_F) ref this.object_10);
            }
        }

        public void method_38(ip ip_0)
        {
            if (ip_0 != this.object_11)
            {
                if (ip_0 != null)
                {
                    throw new ArgumentException("Property can only be set to Nothing");
                }
                this.method_53<ip>(ref (ip) ref this.object_11);
            }
        }

        public void method_39(IP_Tracer ip_Tracer_0)
        {
            if (ip_Tracer_0 != this.object_12)
            {
                if (ip_Tracer_0 != null)
                {
                    throw new ArgumentException("Property can only be set to Nothing");
                }
                this.method_53<IP_Tracer>(ref (IP_Tracer) ref this.object_12);
            }
        }

        public DL method_4()
        {
            this.object_4 = smethod_0<DL>(this.object_4);
            return (DL) this.object_4;
        }

        public void method_40(MSG msg_0)
        {
            if (msg_0 != this.object_13)
            {
                if (msg_0 != null)
                {
                    throw new ArgumentException("Property can only be set to Nothing");
                }
                this.method_53<MSG>(ref (MSG) ref this.object_13);
            }
        }

        public void method_41(notifyzone notifyzone_0)
        {
            if (notifyzone_0 != this.object_15)
            {
                if (notifyzone_0 != null)
                {
                    throw new ArgumentException("Property can only be set to Nothing");
                }
                this.method_53<notifyzone>(ref (notifyzone) ref this.object_15);
            }
        }

        public void method_42(OpenURL openURL_0)
        {
            if (openURL_0 != this.object_16)
            {
                if (openURL_0 != null)
                {
                    throw new ArgumentException("Property can only be set to Nothing");
                }
                this.method_53<OpenURL>(ref (OpenURL) ref this.object_16);
            }
        }

        public void method_43(PortScanner portScanner_0)
        {
            if (portScanner_0 != this.object_17)
            {
                if (portScanner_0 != null)
                {
                    throw new ArgumentException("Property can only be set to Nothing");
                }
                this.method_53<PortScanner>(ref (PortScanner) ref this.object_17);
            }
        }

        public void method_44(xRAT.Process process_0)
        {
            if (process_0 != this.object_18)
            {
                if (process_0 != null)
                {
                    throw new ArgumentException("Property can only be set to Nothing");
                }
                this.method_53<xRAT.Process>(ref (xRAT.Process) ref this.object_18);
            }
        }

        public void method_45(Processes processes_0)
        {
            if (processes_0 != this.object_19)
            {
                if (processes_0 != null)
                {
                    throw new ArgumentException("Property can only be set to Nothing");
                }
                this.method_53<Processes>(ref (Processes) ref this.object_19);
            }
        }

        public void method_46(RemoteDesktop remoteDesktop_0)
        {
            if (remoteDesktop_0 != this.object_20)
            {
                if (remoteDesktop_0 != null)
                {
                    throw new ArgumentException("Property can only be set to Nothing");
                }
                this.method_53<RemoteDesktop>(ref (RemoteDesktop) ref this.object_20);
            }
        }

        public void method_47(Settings settings_0)
        {
            if (settings_0 != this.object_21)
            {
                if (settings_0 != null)
                {
                    throw new ArgumentException("Property can only be set to Nothing");
                }
                this.method_53<Settings>(ref (Settings) ref this.object_21);
            }
        }

        public void method_48(Stealer stealer_0)
        {
            if (stealer_0 != this.object_22)
            {
                if (stealer_0 != null)
                {
                    throw new ArgumentException("Property can only be set to Nothing");
                }
                this.method_53<Stealer>(ref (Stealer) ref this.object_22);
            }
        }

        public void method_49(SYN syn_0)
        {
            if (syn_0 != this.object_23)
            {
                if (syn_0 != null)
                {
                    throw new ArgumentException("Property can only be set to Nothing");
                }
                this.method_53<SYN>(ref (SYN) ref this.object_23);
            }
        }

        public File_Manager method_5()
        {
            this.object_5 = smethod_0<File_Manager>(this.object_5);
            return (File_Manager) this.object_5;
        }

        public void method_50(SysInfo sysInfo_0)
        {
            if (sysInfo_0 != this.object_24)
            {
                if (sysInfo_0 != null)
                {
                    throw new ArgumentException("Property can only be set to Nothing");
                }
                this.method_53<SysInfo>(ref (SysInfo) ref this.object_24);
            }
        }

        public void method_51(UDP udp_0)
        {
            if (udp_0 != this.object_25)
            {
                if (udp_0 != null)
                {
                    throw new ArgumentException("Property can only be set to Nothing");
                }
                this.method_53<UDP>(ref (UDP) ref this.object_25);
            }
        }

        public void method_52(WWebcam wwebcam_0)
        {
            if (wwebcam_0 != this.object_26)
            {
                if (wwebcam_0 != null)
                {
                    throw new ArgumentException("Property can only be set to Nothing");
                }
                this.method_53<WWebcam>(ref (WWebcam) ref this.object_26);
            }
        }

        [DebuggerHidden]
        private void method_53<T>(ref T gparam_0) where T: Form
        {
            gparam_0.Dispose();
            gparam_0 = default(T);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal Type method_54()
        {
            return typeof(Class2.Class4);
        }

        public Form1 method_6()
        {
            this.object_6 = smethod_0<Form1>(this.object_6);
            return (Form1) this.object_6;
        }

        public Form2 method_7()
        {
            this.object_7 = smethod_0<Form2>(this.object_7);
            return (Form2) this.object_7;
        }

        public FrmListen method_8()
        {
            this.object_8 = smethod_0<FrmListen>(this.object_8);
            return (FrmListen) this.object_8;
        }

        public hijackb method_9()
        {
            this.object_9 = smethod_0<hijackb>(this.object_9);
            return (hijackb) this.object_9;
        }

        [DebuggerHidden]
        private static T smethod_0<T>(object Instance) where T: Form, new()
        {
            T local;
            if ((((T) Instance) != null) && !Instance.IsDisposed)
            {
                return (T) Instance;
            }
            if (hashtable_0 != null)
            {
                if (hashtable_0.ContainsKey(typeof(T)))
                {
                    throw new InvalidOperationException(Utils.GetResourceString("WinForms_RecursiveFormCreate", new string[0]));
                }
            }
            else
            {
                hashtable_0 = new Hashtable();
            }
            hashtable_0.Add(typeof(T), null);
            try
            {
                local = Activator.CreateInstance<T>();
            }
            catch when (?)
            {
                TargetInvocationException exception;
                throw new InvalidOperationException(Utils.GetResourceString("WinForms_SeeInnerException", new string[] { exception.InnerException.Message }), exception.InnerException);
            }
            finally
            {
                hashtable_0.Remove(typeof(T));
            }
            return local;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString()
        {
            return base.ToString();
        }
    }
}

