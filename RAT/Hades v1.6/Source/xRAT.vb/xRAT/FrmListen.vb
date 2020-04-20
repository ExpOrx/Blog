Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms

Namespace xRAT
    <DesignerGenerated> _
    Public Class FrmListen
        Inherits Form
        ' Methods
        Public Sub New()
            Class1.QaIGh5M7cuigS
            AddHandler MyBase.Load, New EventHandler(AddressOf Me.FrmListen_Load)
            Me.InitializeComponent
        End Sub

        Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            If Not Class2.Class4_0.method_6.listening Then
                If ((Me.TextBox1.Text <> Nothing) And (Me.TextBox2.Text <> Nothing)) Then
                    If (Conversions.ToDouble(Me.TextBox1.Text) > 60000) Then
                        Interaction.MsgBox("Port must be under 60000!", MsgBoxStyle.Information, Nothing)
                    Else
                        Class2.Class4_0.method_6.port = Conversions.ToInteger(Me.TextBox1.Text)
                        Class2.Class4_0.method_6.password = Me.TextBox2.Text
                        Me.Close
                        Try 
                        Catch exception1 As Exception
                            ProjectData.SetProjectError(exception1)
                            Interaction.MsgBox(("Access denied for path:" & ChrW(13) & ChrW(10) & Application.StartupPath), MsgBoxStyle.Exclamation, Nothing)
                            ProjectData.ClearProjectError
                        End Try
                    End If
                End If
            Else
                Interaction.MsgBox("Please stop listening first!", MsgBoxStyle.Exclamation, Nothing)
                Me.Close
            End If
        End Sub

        Private Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs)
            If Not Class2.Class4_0.method_6.listening Then
                If ((Me.TextBox1.Text <> Nothing) And (Me.TextBox2.Text <> Nothing)) Then
                    If (Conversions.ToDouble(Me.TextBox1.Text) > 60000) Then
                        Interaction.MsgBox("Please use a Port under 60000!", MsgBoxStyle.Information, Nothing)
                    Else
                        Class2.Class4_0.method_6.port = Conversions.ToInteger(Me.TextBox1.Text)
                        Class2.Class4_0.method_6.password = Me.TextBox2.Text
                        Class2.Class4_0.method_6.ListenToolStripMenuItem.PerformClick
                        Me.Close
                        Try 
                        Catch exception1 As Exception
                            ProjectData.SetProjectError(exception1)
                            Interaction.MsgBox(("Access denied for path:" & ChrW(13) & ChrW(10) & Application.StartupPath), MsgBoxStyle.Exclamation, Nothing)
                            ProjectData.ClearProjectError
                        End Try
                    End If
                End If
            Else
                Interaction.MsgBox("Please stop listening first!", MsgBoxStyle.Exclamation, Nothing)
                Me.Close
            End If
        End Sub

        Private Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
            If Me.CheckBox1.Checked Then
                Me.TextBox2.PasswordChar = ChrW(0)
            Else
                Me.TextBox2.PasswordChar = ChrW(9679)
            End If
        End Sub

        <DebuggerNonUserCode> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try 
                If (disposing AndAlso (Not Me.icontainer_0 Is Nothing)) Then
                    Me.icontainer_0.Dispose
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub

        Private Sub FrmListen_Load(ByVal sender As Object, ByVal e As EventArgs)
            Me.TextBox2.PasswordChar = ChrW(9679)
            Me.TextBox1.Text = Conversions.ToString(Class2.Class4_0.method_6.port)
            Me.TextBox2.Text = Class2.Class4_0.method_6.password
            If Not Class2.Class4_0.method_6.enable Then
                Me.TextBox1.Enabled = False
                Me.TextBox2.Enabled = False
            ElseIf Class2.Class4_0.method_6.enable Then
                Me.TextBox1.Enabled = True
                Me.TextBox2.Enabled = True
            End If
        End Sub

        <DebuggerStepThrough> _
        Private Sub InitializeComponent()
            Dim manager As New ComponentResourceManager(GetType(FrmListen))
            Me.Label1 = New Label
            Me.Label2 = New Label
            Me.TextBox1 = New TextBox
            Me.TextBox2 = New TextBox
            Me.Button1 = New Button
            Me.CheckBox1 = New CheckBox
            Me.Button2 = New Button
            Me.SuspendLayout
            Me.Label1.AutoSize = True
            Dim point As New Point(12, 9)
            Me.Label1.Location = point
            Me.Label1.Name = "Label1"
            Dim size As New Size(&H1F, 13)
            Me.Label1.Size = size
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "Port:"
            Me.Label2.AutoSize = True
            point = New Point(12, &H22)
            Me.Label2.Location = point
            Me.Label2.Name = "Label2"
            size = New Size(&H39, 13)
            Me.Label2.Size = size
            Me.Label2.TabIndex = 1
            Me.Label2.Text = "Password:"
            point = New Point(&H4A, 6)
            Me.TextBox1.Location = point
            Me.TextBox1.Name = "TextBox1"
            size = New Size(&H91, &H15)
            Me.TextBox1.Size = size
            Me.TextBox1.TabIndex = 2
            point = New Point(&H4A, &H1F)
            Me.TextBox2.Location = point
            Me.TextBox2.Name = "TextBox2"
            size = New Size(&H91, &H15)
            Me.TextBox2.Size = size
            Me.TextBox2.TabIndex = 3
            point = New Point(12, 80)
            Me.Button1.Location = point
            Me.Button1.Name = "Button1"
            size = New Size(&H4B, &H17)
            Me.Button1.Size = size
            Me.Button1.TabIndex = 4
            Me.Button1.Text = "Save"
            Me.Button1.UseVisualStyleBackColor = True
            Me.CheckBox1.AutoSize = True
            point = New Point(&H75, &H39)
            Me.CheckBox1.Location = point
            Me.CheckBox1.Name = "CheckBox1"
            size = New Size(&H65, &H11)
            Me.CheckBox1.Size = size
            Me.CheckBox1.TabIndex = 8
            Me.CheckBox1.Text = "Show Password"
            Me.CheckBox1.UseVisualStyleBackColor = True
            point = New Point(&H5D, 80)
            Me.Button2.Location = point
            Me.Button2.Name = "Button2"
            size = New Size(&H7E, &H17)
            Me.Button2.Size = size
            Me.Button2.TabIndex = 9
            Me.Button2.Text = "Save and Listen"
            Me.Button2.UseVisualStyleBackColor = True
            Dim ef As New SizeF(6!, 13!)
            Me.AutoScaleDimensions = ef
            Me.AutoScaleMode = AutoScaleMode.Font
            size = New Size(&HE4, &H73)
            Me.ClientSize = size
            Me.Controls.Add(Me.Button2)
            Me.Controls.Add(Me.CheckBox1)
            Me.Controls.Add(Me.Button1)
            Me.Controls.Add(Me.TextBox2)
            Me.Controls.Add(Me.TextBox1)
            Me.Controls.Add(Me.Label2)
            Me.Controls.Add(Me.Label1)
            Me.FormBorderStyle = FormBorderStyle.Fixed3D
            Me.Icon = DirectCast(manager.GetObject("$this.Icon"), Icon)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "FrmListen"
            Me.StartPosition = FormStartPosition.CenterScreen
            Me.Text = "Listen"
            Me.ResumeLayout(False)
            Me.PerformLayout
        End Sub

        Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
            Dim num As Integer = Strings.Asc(e.KeyChar)
            If (((num < &H30) OrElse (num > &H39)) AndAlso (num <> 8)) Then
                e.Handled = True
            End If
        End Sub


        ' Properties
        Friend Overridable Property Button1 As Button
            Get
                Return Me._Button1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As Button)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.Button1_Click)
                If (Not Me._Button1 Is Nothing) Then
                    RemoveHandler Me._Button1.Click, handler
                End If
                Me._Button1 = value
                If (Not Me._Button1 Is Nothing) Then
                    AddHandler Me._Button1.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property Button2 As Button
            Get
                Return Me._Button2
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As Button)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.Button2_Click)
                If (Not Me._Button2 Is Nothing) Then
                    RemoveHandler Me._Button2.Click, handler
                End If
                Me._Button2 = value
                If (Not Me._Button2 Is Nothing) Then
                    AddHandler Me._Button2.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property CheckBox1 As CheckBox
            Get
                Return Me._CheckBox1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As CheckBox)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.CheckBox1_CheckedChanged)
                If (Not Me._CheckBox1 Is Nothing) Then
                    RemoveHandler Me._CheckBox1.CheckedChanged, handler
                End If
                Me._CheckBox1 = value
                If (Not Me._CheckBox1 Is Nothing) Then
                    AddHandler Me._CheckBox1.CheckedChanged, handler
                End If
            End Set
        End Property

        Friend Overridable Property Label1 As Label
            Get
                Return Me._Label1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As Label)
                Me._Label1 = value
            End Set
        End Property

        Friend Overridable Property Label2 As Label
            Get
                Return Me._Label2
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As Label)
                Me._Label2 = value
            End Set
        End Property

        Friend Overridable Property TextBox1 As TextBox
            Get
                Return Me._TextBox1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As TextBox)
                Dim handler As KeyPressEventHandler = New KeyPressEventHandler(AddressOf Me.TextBox1_KeyPress)
                If (Not Me._TextBox1 Is Nothing) Then
                    RemoveHandler Me._TextBox1.KeyPress, handler
                End If
                Me._TextBox1 = value
                If (Not Me._TextBox1 Is Nothing) Then
                    AddHandler Me._TextBox1.KeyPress, handler
                End If
            End Set
        End Property

        Friend Overridable Property TextBox2 As TextBox
            Get
                Return Me._TextBox2
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As TextBox)
                Me._TextBox2 = value
            End Set
        End Property


        ' Fields
        <AccessedThroughProperty("Button1")> _
        Private _Button1 As Button
        <AccessedThroughProperty("Button2")> _
        Private _Button2 As Button
        <AccessedThroughProperty("CheckBox1")> _
        Private _CheckBox1 As CheckBox
        <AccessedThroughProperty("Label1")> _
        Private _Label1 As Label
        <AccessedThroughProperty("Label2")> _
        Private _Label2 As Label
        <AccessedThroughProperty("TextBox1")> _
        Private _TextBox1 As TextBox
        <AccessedThroughProperty("TextBox2")> _
        Private _TextBox2 As TextBox
        Private icontainer_0 As IContainer
    End Class
End Namespace

