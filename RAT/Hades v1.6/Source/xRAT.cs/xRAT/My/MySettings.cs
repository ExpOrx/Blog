namespace xRAT.My
{
    using Microsoft.VisualBasic.ApplicationServices;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.Configuration;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0"), EditorBrowsable(EditorBrowsableState.Advanced)]
    internal sealed class MySettings : ApplicationSettingsBase
    {
        private static bool bool_0;
        private static MySettings mySettings_0;
        private static object object_0;

        static MySettings()
        {
            Class1.QaIGh5M7cuigS();
            mySettings_0 = (MySettings) SettingsBase.Synchronized(new MySettings());
            object_0 = RuntimeHelpers.GetObjectValue(new object());
        }

        public MySettings()
        {
            Class1.QaIGh5M7cuigS();
        }

        [EditorBrowsable(EditorBrowsableState.Advanced), DebuggerNonUserCode]
        private static void smethod_0(object object_1, object object_2)
        {
            if (Class2.Form0_0.SaveMySettingsOnExit)
            {
                Class11.MySettings_0.Save();
            }
        }

        public static MySettings Default
        {
            get
            {
                if (!bool_0)
                {
                    object expression = object_0;
                    ObjectFlowControl.CheckForSyncLockOnValueType(expression);
                    lock (expression)
                    {
                        if (!bool_0)
                        {
                            Class2.Form0_0.Shutdown += new ShutdownEventHandler(MySettings.smethod_0);
                            bool_0 = true;
                        }
                    }
                }
                return mySettings_0;
            }
        }
    }
}

