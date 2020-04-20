using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

[EditorBrowsable(EditorBrowsableState.Never), GeneratedCode("MyTemplate", "8.0.0.0")]
internal class Form0 : WindowsFormsApplicationBase
{
    [DebuggerStepThrough]
    public Form0() : base(AuthenticationMode.Windows)
    {
        this.IsSingleInstance = false;
        this.EnableVisualStyles = true;
        this.SaveMySettingsOnExit = true;
        this.ShutdownStyle = ShutdownMode.AfterMainFormCloses;
    }

    [MethodImpl(MethodImplOptions.NoOptimization), EditorBrowsable(EditorBrowsableState.Advanced), DebuggerHidden, STAThread]
    internal static void Main(string[] args)
    {
        try
        {
            Application.SetCompatibleTextRenderingDefault(WindowsFormsApplicationBase.UseCompatibleTextRendering);
            Class1.QaIGh5M7cuigS();
        }
        finally
        {
        }
        Class2.Form0_0.Run(args);
    }

    [DebuggerStepThrough]
    protected override void OnCreateMainForm()
    {
        this.MainForm = Class2.Class4_0.method_6();
    }
}

