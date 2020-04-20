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
    Public Class HTTP_F
        Inherits Form
        ' Methods
        Public Sub New()
            Class1.QaIGh5M7cuigS
            Me.InitializeComponent
        End Sub

        Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)
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
            Dim manager As New ComponentResourceManager(GetType(HTTP_F))
            Me.TextBox1 = New TextBox
            Me.TextBox2 = New TextBox
            Me.Label1 = New Label
            Me.Button1 = New Button
            Me.GroupBox1 = New GroupBox
            Me.Label4 = New Label
            Me.Label3 = New Label
            Me.Label2 = New Label
            Me.GroupBox1.SuspendLayout
            Me.SuspendLayout
            Dim point As New Point(100, 30)
            Me.TextBox1.Location = point
            Me.TextBox1.Name = "TextBox1"
            Dim size As New Size(&HB8, &H15)
            Me.TextBox1.Size = size
            Me.TextBox1.TabIndex = 0
            point = New Point(100, &H4A)
            Me.TextBox2.Location = point
            Me.TextBox2.Name = "TextBox2"
            size = New Size(&H92, &H15)
            Me.TextBox2.Size = size
            Me.TextBox2.TabIndex = 2
            Me.Label1.AutoSize = True
            point = New Point(&H19, &H21)
            Me.Label1.Location = point
            Me.Label1.Name = "Label1"
            size = New Size(&H21, 13)
            Me.Label1.Size = size
            Me.Label1.TabIndex = 1
            Me.Label1.Text = "Host:"
            point = New Point(12, &H86)
            Me.Button1.Location = point
            Me.Button1.Name = "Button1"
            size = New Size(&H13A, &H21)
            Me.Button1.Size = size
            Me.Button1.TabIndex = 13
            Me.Button1.Text = "Start HTTP-Flood"
            Me.Button1.UseVisualStyleBackColor = True
            Me.GroupBox1.Controls.Add(Me.Label4)
            Me.GroupBox1.Controls.Add(Me.Label3)
            Me.GroupBox1.Controls.Add(Me.TextBox1)
            Me.GroupBox1.Controls.Add(Me.Label1)
            Me.GroupBox1.Controls.Add(Me.TextBox2)
            Me.GroupBox1.Controls.Add(Me.Label2)
            point = New Point(12, 12)
            Me.GroupBox1.Location = point
            Me.GroupBox1.Name = "GroupBox1"
            size = New Size(&H13A, &H74)
            Me.GroupBox1.Size = size
            Me.GroupBox1.TabIndex = 14
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "HTTP-Flood Options"
            Me.Label4.AutoSize = True
            point = New Point(&HFC, &H4D)
            Me.Label4.Location = point
            Me.Label4.Name = "Label4"
            size = New Size(&H2F, 13)
            Me.Label4.Size = size
            Me.Label4.TabIndex = 15
            Me.Label4.Text = "Seconds"
            Me.Label3.AutoSize = True
            point = New Point(&H61, &H35)
            Me.Label3.Location = point
            Me.Label3.Name = "Label3"
            size = New Size(&H62, 13)
            Me.Label3.Size = size
            Me.Label3.TabIndex = 15
            Me.Label3.Text = "www.example.com"
            Me.Label2.AutoSize = True
            point = New Point(&H19, &H4D)
            Me.Label2.Location = point
            Me.Label2.Name = "Label2"
            size = New Size(&H21, 13)
            Me.Label2.Size = size
            Me.Label2.TabIndex = 6
            Me.Label2.Text = "Time:"
            Dim ef As New SizeF(6!, 13!)
            Me.AutoScaleDimensions = ef
            Me.AutoScaleMode = AutoScaleMode.Font
            size = New Size(&H153, &HB3)
            Me.ClientSize = size
            Me.Controls.Add(Me.Button1)
            Me.Controls.Add(Me.GroupBox1)
            Me.FormBorderStyle = FormBorderStyle.Fixed3D
            Me.Icon = DirectCast(manager.GetObject("$this.Icon"), Icon)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "HTTP_F"
            Me.StartPosition = FormStartPosition.CenterScreen
            Me.Text = "Slowloris HTTP-Flood"
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
                Return Me._Label3
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As Label)
                Me._Label3 = value
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

        Public ReadOnly Property TIME As Object
            Get
                Return Me.TextBox2.Text
            End Get
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
        <AccessedThroughProperty("Label3")> _
        Private _Label3 As Label
        <AccessedThroughProperty("Label4")> _
        Private _Label4 As Label
        <AccessedThroughProperty("TextBox1")> _
        Private _TextBox1 As TextBox
        <AccessedThroughProperty("TextBox2")> _
        Private _TextBox2 As TextBox
        Private icontainer_0 As IContainer
    End Class
End Namespace

