Imports Microsoft.VisualBasic.ApplicationServices
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.CodeDom.Compiler
Imports System.ComponentModel
Imports System.Configuration
Imports System.Diagnostics
Imports System.Runtime.CompilerServices

Namespace xRAT.My
    <CompilerGenerated, GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0"), EditorBrowsable(EditorBrowsableState.Advanced)> _
    Friend NotInheritable Class MySettings
        Inherits ApplicationSettingsBase
        ' Methods
        Shared Sub New()
            Class1.QaIGh5M7cuigS
            MySettings.mySettings_0 = DirectCast(SettingsBase.Synchronized(New MySettings), MySettings)
            MySettings.object_0 = RuntimeHelpers.GetObjectValue(New Object)
        End Sub

        Public Sub New()
            Class1.QaIGh5M7cuigS
        End Sub

        <EditorBrowsable(EditorBrowsableState.Advanced), DebuggerNonUserCode> _
        Private Shared Sub smethod_0(ByVal object_1 As Object, ByVal object_2 As Object)
            If Class2.Form0_0.SaveMySettingsOnExit Then
                Class11.MySettings_0.Save
            End If
        End Sub


        ' Properties
        Public Shared ReadOnly Property [Default] As MySettings
            Get
                If Not MySettings.bool_0 Then
                    Dim expression As Object = MySettings.object_0
                    ObjectFlowControl.CheckForSyncLockOnValueType(expression)
                    SyncLock expression
                        If Not MySettings.bool_0 Then
                            AddHandler Class2.Form0_0.Shutdown, New ShutdownEventHandler(AddressOf MySettings.smethod_0)
                            MySettings.bool_0 = True
                        End If
                    End SyncLock
                End If
                Return MySettings.mySettings_0
            End Get
        End Property


        ' Fields
        Private Shared bool_0 As Boolean
        Private Shared mySettings_0 As MySettings
        Private Shared object_0 As Object
    End Class
End Namespace

