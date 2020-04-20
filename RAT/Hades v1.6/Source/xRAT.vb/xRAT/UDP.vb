Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Net
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms

Namespace xRAT
    <DesignerGenerated> _
    Public Class UDP
        Inherits Form
        ' Methods
        Public Sub New()
            Class1.QaIGh5M7cuigS
            Me.InitializeComponent
        End Sub

        Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            Try 
                If Me.TextBox1.Text.Contains("http://www.") Then
                    Dim hostEntry As IPHostEntry = Dns.GetHostEntry(Me.TextBox1.Text.Replace("http://www.", String.Empty))
                    Me.TextBox1.Text = hostEntry.AddressList(0).ToString
                ElseIf Me.TextBox1.Text.Contains("www.") Then
                    Dim entry3 As IPHostEntry = Dns.GetHostEntry(Me.TextBox1.Text.Replace("www.", String.Empty))
                    Me.TextBox1.Text = entry3.AddressList(0).ToString
                ElseIf Me.TextBox1.Text.Contains("http://") Then
                    Dim entry4 As IPHostEntry = Dns.GetHostEntry(Me.TextBox1.Text.Replace("http://", String.Empty))
                    Me.TextBox1.Text = entry4.AddressList(0).ToString
                Else
                    Dim entry2 As IPHostEntry = Dns.GetHostEntry(Me.TextBox1.Text)
                    Me.TextBox1.Text = entry2.AddressList(0).ToString
                End If
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                ProjectData.ClearProjectError
            End Try
            Me.DialogResult = DialogResult.OK
            Me.Close
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

        <DebuggerStepThrough> _
        Private Sub InitializeComponent()
            Dim manager As New ComponentResourceManager(GetType(UDP))
            Me.GroupBox1 = New GroupBox
            Me.TextBox1 = New TextBox
            Me.Label1 = New Label
            Me.TextBox2 = New TextBox
            Me.Label2 = New Label
            Me.Button1 = New Button
            Me.GroupBox1.SuspendLayout
            Me.SuspendLayout
            Me.GroupBox1.Controls.Add(Me.TextBox1)
            Me.GroupBox1.Controls.Add(Me.Label1)
            Me.GroupBox1.Controls.Add(Me.TextBox2)
            Me.GroupBox1.Controls.Add(Me.Label2)
            Dim point As New Point(12, 12)
            Me.GroupBox1.Location = point
            Me.GroupBox1.Name = "GroupBox1"
            Dim size As New Size(&H13A, &H5C)
            Me.GroupBox1.Size = size
            Me.GroupBox1.TabIndex = 14
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "UDP-Flood Settings"
            point = New Point(&H40, 30)
            Me.TextBox1.Location = point
            Me.TextBox1.Name = "TextBox1"
            size = New Size(220, &H15)
            Me.TextBox1.Size = size
            Me.TextBox1.TabIndex = 0
            Me.TextBox1.Text = "127.0.0.1"
            Me.Label1.AutoSize = True
            point = New Point(&H19, &H21)
            Me.Label1.Location = point
            Me.Label1.Name = "Label1"
            size = New Size(&H21, 13)
            Me.Label1.Size = size
            Me.Label1.TabIndex = 1
            Me.Label1.Text = "Host:"
            point = New Point(&H40, &H38)
            Me.TextBox2.Location = point
            Me.TextBox2.Name = "TextBox2"
            size = New Size(220, &H15)
            Me.TextBox2.Size = size
            Me.TextBox2.TabIndex = 2
            Me.TextBox2.Text = "80"
            Me.Label2.AutoSize = True
            point = New Point(&H19, &H3B)
            Me.Label2.Location = point
            Me.Label2.Name = "Label2"
            size = New Size(&H1F, 13)
            Me.Label2.Size = size
            Me.Label2.TabIndex = 6
            Me.Label2.Text = "Port:"
            point = New Point(12, &H6B)
            Me.Button1.Location = point
            Me.Button1.Name = "Button1"
            size = New Size(&H13B, &H22)
            Me.Button1.Size = size
            Me.Button1.TabIndex = 13
            Me.Button1.Text = "Start UDP-Flood"
            Me.Button1.UseVisualStyleBackColor = True
            Dim ef As New SizeF(6!, 13!)
            Me.AutoScaleDimensions = ef
            Me.AutoScaleMode = AutoScaleMode.Font
            size = New Size(&H153, &H9C)
            Me.ClientSize = size
            Me.Controls.Add(Me.GroupBox1)
            Me.Controls.Add(Me.Button1)
            Me.FormBorderStyle = FormBorderStyle.Fixed3D
            Me.Icon = DirectCast(manager.GetObject("$this.Icon"), Icon)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "UDP"
            Me.StartPosition = FormStartPosition.CenterScreen
            Me.Text = "UDP-Flood"
            Me.GroupBox1.ResumeLayout(False)
            Me.GroupBox1.PerformLayout
            Me.ResumeLayout(False)
        End Sub

        Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
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

        Friend Overridable Property GroupBox1 As GroupBox
            Get
                Return Me._GroupBox1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As GroupBox)
                Me._GroupBox1 = value
            End Set
        End Property

        Public ReadOnly Property HOST As Object
            Get
                Return Me.TextBox1.Text
            End Get
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

        Public ReadOnly Property PORT As Object
            Get
                Return Me.TextBox2.Text
            End Get
        End Property

        Friend Overridable Property TextBox1 As TextBox
            Get
                Return Me._TextBox1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As TextBox)
                Me._TextBox1 = value
            End Set
        End Property

        Friend Overridable Property TextBox2 As TextBox
            Get
                Return Me._TextBox2
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As TextBox)
                Dim handler As KeyPressEventHandler = New KeyPressEventHandler(AddressOf Me.TextBox2_KeyPress)
                If (Not Me._TextBox2 Is Nothing) Then
                    RemoveHandler Me._TextBox2.KeyPress, handler
                End If
                Me._TextBox2 = value
                If (Not Me._TextBox2 Is Nothing) Then
                    AddHandler Me._TextBox2.KeyPress, handler
                End If
            End Set
        End Property


        ' Fields
        <AccessedThroughProperty("Button1")> _
        Private _Button1 As Button
        <AccessedThroughProperty("GroupBox1")> _
        Private _GroupBox1 As GroupBox
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

