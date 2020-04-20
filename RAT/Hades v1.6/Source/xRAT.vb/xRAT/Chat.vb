Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms

Namespace xRAT
    <DesignerGenerated> _
    Public Class Chat
        Inherits Form
        ' Methods
        Public Sub New()
            Class1.QaIGh5M7cuigS
            AddHandler MyBase.Load, New EventHandler(AddressOf Me.Chat_Load)
            Me.InitializeComponent
        End Sub

        Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim flag1 As Boolean = Me.RadioButton1.Checked
            Dim flag2 As Boolean = Me.RadioButton2.Checked
            Dim flag3 As Boolean = Me.RadioButton3.Checked
            Dim flag4 As Boolean = Me.RadioButton4.Checked
            Dim flag5 As Boolean = Me.RadioButton5.Checked
            Dim flag6 As Boolean = Me.RadioButton6.Checked
            If (Me.TextBox3.Text <> "") Then
                If (Me.TextBox1.Text.Trim = "") Then
                    Me.TextBox1.Text = "Master"
                End If
                Dim box As TextBox = Me.TextBox2
                box.Text = (box.Text & ChrW(13) & ChrW(10) & "You: " & Me.TextBox3.Text)
                Class2.Class4_0.method_6.SendToSelected(("CHAT|" & Me.TextBox1.Text & "|" & Me.TextBox3.Text))
            End If
        End Sub

        Private Sub Chat_Load(ByVal sender As Object, ByVal e As EventArgs)
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
            Dim manager As New ComponentResourceManager(GetType(Chat))
            Me.TextBox1 = New TextBox
            Me.Label1 = New Label
            Me.TextBox2 = New TextBox
            Me.Button1 = New Button
            Me.TextBox3 = New TextBox
            Me.Panel1 = New Panel
            Me.RadioButton1 = New RadioButton
            Me.RadioButton2 = New RadioButton
            Me.RadioButton3 = New RadioButton
            Me.RadioButton4 = New RadioButton
            Me.RadioButton5 = New RadioButton
            Me.RadioButton6 = New RadioButton
            Me.PictureBox4 = New PictureBox
            Me.PictureBox5 = New PictureBox
            Me.PictureBox6 = New PictureBox
            Me.PictureBox3 = New PictureBox
            Me.PictureBox2 = New PictureBox
            Me.PictureBox1 = New PictureBox
            Me.Panel1.SuspendLayout
            DirectCast(Me.PictureBox4, ISupportInitialize).BeginInit
            DirectCast(Me.PictureBox5, ISupportInitialize).BeginInit
            DirectCast(Me.PictureBox6, ISupportInitialize).BeginInit
            DirectCast(Me.PictureBox3, ISupportInitialize).BeginInit
            DirectCast(Me.PictureBox2, ISupportInitialize).BeginInit
            DirectCast(Me.PictureBox1, ISupportInitialize).BeginInit
            Me.SuspendLayout
            Dim point As New Point(&H63, 6)
            Me.TextBox1.Location = point
            Me.TextBox1.Name = "TextBox1"
            Dim size As New Size(&HCF, &H15)
            Me.TextBox1.Size = size
            Me.TextBox1.TabIndex = 0
            Me.Label1.AutoSize = True
            point = New Point(12, 9)
            Me.Label1.Location = point
            Me.Label1.Name = "Label1"
            size = New Size(&H51, 13)
            Me.Label1.Size = size
            Me.Label1.TabIndex = 4
            Me.Label1.Text = "Your Nickname:"
            Me.TextBox2.BackColor = Color.White
            point = New Point(12, &H20)
            Me.TextBox2.Location = point
            Me.TextBox2.Multiline = True
            Me.TextBox2.Name = "TextBox2"
            Me.TextBox2.ReadOnly = True
            Me.TextBox2.ScrollBars = ScrollBars.Vertical
            size = New Size(&HF3, &HBD)
            Me.TextBox2.Size = size
            Me.TextBox2.TabIndex = 3
            point = New Point(&H102, &HCA)
            Me.Button1.Location = point
            Me.Button1.Name = "Button1"
            size = New Size(&H37, &H30)
            Me.Button1.Size = size
            Me.Button1.TabIndex = 2
            Me.Button1.Text = "Send"
            Me.Button1.UseVisualStyleBackColor = True
            point = New Point(12, &HE2)
            Me.TextBox3.Location = point
            Me.TextBox3.Name = "TextBox3"
            size = New Size(&HF3, &H15)
            Me.TextBox3.Size = size
            Me.TextBox3.TabIndex = 1
            Me.Panel1.Controls.Add(Me.RadioButton6)
            Me.Panel1.Controls.Add(Me.RadioButton5)
            Me.Panel1.Controls.Add(Me.RadioButton4)
            Me.Panel1.Controls.Add(Me.RadioButton3)
            Me.Panel1.Controls.Add(Me.RadioButton2)
            Me.Panel1.Controls.Add(Me.RadioButton1)
            Me.Panel1.Controls.Add(Me.PictureBox4)
            Me.Panel1.Controls.Add(Me.PictureBox5)
            Me.Panel1.Controls.Add(Me.PictureBox6)
            Me.Panel1.Controls.Add(Me.PictureBox3)
            Me.Panel1.Controls.Add(Me.PictureBox2)
            Me.Panel1.Controls.Add(Me.PictureBox1)
            point = New Point(&H105, &H20)
            Me.Panel1.Location = point
            Me.Panel1.Name = "Panel1"
            size = New Size(&H2D, &HA4)
            Me.Panel1.Size = size
            Me.Panel1.TabIndex = 5
            Me.RadioButton1.AutoSize = True
            Me.RadioButton1.Checked = True
            point = New Point(3, 7)
            Me.RadioButton1.Location = point
            Me.RadioButton1.Name = "RadioButton1"
            size = New Size(14, 13)
            Me.RadioButton1.Size = size
            Me.RadioButton1.TabIndex = 12
            Me.RadioButton1.TabStop = True
            Me.RadioButton1.UseVisualStyleBackColor = True
            Me.RadioButton2.AutoSize = True
            point = New Point(3, &H21)
            Me.RadioButton2.Location = point
            Me.RadioButton2.Name = "RadioButton2"
            size = New Size(14, 13)
            Me.RadioButton2.Size = size
            Me.RadioButton2.TabIndex = 13
            Me.RadioButton2.TabStop = True
            Me.RadioButton2.UseVisualStyleBackColor = True
            Me.RadioButton3.AutoSize = True
            point = New Point(3, 60)
            Me.RadioButton3.Location = point
            Me.RadioButton3.Name = "RadioButton3"
            size = New Size(14, 13)
            Me.RadioButton3.Size = size
            Me.RadioButton3.TabIndex = 13
            Me.RadioButton3.TabStop = True
            Me.RadioButton3.UseVisualStyleBackColor = True
            Me.RadioButton4.AutoSize = True
            point = New Point(3, &H57)
            Me.RadioButton4.Location = point
            Me.RadioButton4.Name = "RadioButton4"
            size = New Size(14, 13)
            Me.RadioButton4.Size = size
            Me.RadioButton4.TabIndex = 13
            Me.RadioButton4.TabStop = True
            Me.RadioButton4.UseVisualStyleBackColor = True
            Me.RadioButton5.AutoSize = True
            point = New Point(3, &H71)
            Me.RadioButton5.Location = point
            Me.RadioButton5.Name = "RadioButton5"
            size = New Size(14, 13)
            Me.RadioButton5.Size = size
            Me.RadioButton5.TabIndex = 13
            Me.RadioButton5.TabStop = True
            Me.RadioButton5.UseVisualStyleBackColor = True
            Me.RadioButton6.AutoSize = True
            point = New Point(3, &H8D)
            Me.RadioButton6.Location = point
            Me.RadioButton6.Name = "RadioButton6"
            size = New Size(14, 13)
            Me.RadioButton6.Size = size
            Me.RadioButton6.TabIndex = 14
            Me.RadioButton6.TabStop = True
            Me.RadioButton6.UseVisualStyleBackColor = True
            Me.PictureBox4.BorderStyle = BorderStyle.FixedSingle
            Me.PictureBox4.Image = Class5.smethod_28
            point = New Point(&H13, &H87)
            Me.PictureBox4.Location = point
            Me.PictureBox4.Name = "PictureBox4"
            size = New Size(&H18, &H18)
            Me.PictureBox4.Size = size
            Me.PictureBox4.SizeMode = PictureBoxSizeMode.StretchImage
            Me.PictureBox4.TabIndex = 11
            Me.PictureBox4.TabStop = False
            Me.PictureBox5.BorderStyle = BorderStyle.FixedSingle
            Me.PictureBox5.Image = Class5.smethod_40
            point = New Point(&H13, &H6C)
            Me.PictureBox5.Location = point
            Me.PictureBox5.Name = "PictureBox5"
            size = New Size(&H18, &H18)
            Me.PictureBox5.Size = size
            Me.PictureBox5.SizeMode = PictureBoxSizeMode.StretchImage
            Me.PictureBox5.TabIndex = 10
            Me.PictureBox5.TabStop = False
            Me.PictureBox6.BorderStyle = BorderStyle.FixedSingle
            Me.PictureBox6.Image = DirectCast(manager.GetObject("PictureBox6.Image"), Image)
            point = New Point(&H13, &H52)
            Me.PictureBox6.Location = point
            Me.PictureBox6.Name = "PictureBox6"
            size = New Size(&H18, &H18)
            Me.PictureBox6.Size = size
            Me.PictureBox6.SizeMode = PictureBoxSizeMode.StretchImage
            Me.PictureBox6.TabIndex = 9
            Me.PictureBox6.TabStop = False
            Me.PictureBox3.BorderStyle = BorderStyle.FixedSingle
            Me.PictureBox3.Image = Class5.smethod_25
            point = New Point(&H13, &H37)
            Me.PictureBox3.Location = point
            Me.PictureBox3.Name = "PictureBox3"
            size = New Size(&H18, &H18)
            Me.PictureBox3.Size = size
            Me.PictureBox3.SizeMode = PictureBoxSizeMode.StretchImage
            Me.PictureBox3.TabIndex = 8
            Me.PictureBox3.TabStop = False
            Me.PictureBox2.BorderStyle = BorderStyle.FixedSingle
            Me.PictureBox2.Image = Class5.smethod_31
            point = New Point(&H13, &H1C)
            Me.PictureBox2.Location = point
            Me.PictureBox2.Name = "PictureBox2"
            size = New Size(&H18, &H18)
            Me.PictureBox2.Size = size
            Me.PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
            Me.PictureBox2.TabIndex = 7
            Me.PictureBox2.TabStop = False
            Me.PictureBox1.BorderStyle = BorderStyle.FixedSingle
            Me.PictureBox1.Image = Class5.smethod_82
            point = New Point(&H13, 2)
            Me.PictureBox1.Location = point
            Me.PictureBox1.Name = "PictureBox1"
            size = New Size(&H18, &H18)
            Me.PictureBox1.Size = size
            Me.PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
            Me.PictureBox1.TabIndex = 6
            Me.PictureBox1.TabStop = False
            Dim ef As New SizeF(6!, 13!)
            Me.AutoScaleDimensions = ef
            Me.AutoScaleMode = AutoScaleMode.Font
            size = New Size(&H13A, &H106)
            Me.ClientSize = size
            Me.Controls.Add(Me.Panel1)
            Me.Controls.Add(Me.TextBox3)
            Me.Controls.Add(Me.Button1)
            Me.Controls.Add(Me.TextBox2)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.TextBox1)
            Me.FormBorderStyle = FormBorderStyle.Fixed3D
            Me.Icon = DirectCast(manager.GetObject("$this.Icon"), Icon)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "Chat"
            Me.StartPosition = FormStartPosition.CenterScreen
            Me.Text = "Chat"
            Me.TopMost = True
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout
            DirectCast(Me.PictureBox4, ISupportInitialize).EndInit
            DirectCast(Me.PictureBox5, ISupportInitialize).EndInit
            DirectCast(Me.PictureBox6, ISupportInitialize).EndInit
            DirectCast(Me.PictureBox3, ISupportInitialize).EndInit
            DirectCast(Me.PictureBox2, ISupportInitialize).EndInit
            DirectCast(Me.PictureBox1, ISupportInitialize).EndInit
            Me.ResumeLayout(False)
            Me.PerformLayout
        End Sub

        Private Sub PictureBox4_Click(ByVal sender As Object, ByVal e As EventArgs)
        End Sub

        Private Sub PictureBox5_Click(ByVal sender As Object, ByVal e As EventArgs)
        End Sub

        Private Sub PictureBox6_Click(ByVal sender As Object, ByVal e As EventArgs)
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

        Friend Overridable Property Label1 As Label
            Get
                Return Me._Label1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As Label)
                Me._Label1 = value
            End Set
        End Property

        Friend Overridable Property Panel1 As Panel
            Get
                Return Me._Panel1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As Panel)
                Me._Panel1 = value
            End Set
        End Property

        Friend Overridable Property PictureBox1 As PictureBox
            Get
                Return Me._PictureBox1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As PictureBox)
                Me._PictureBox1 = value
            End Set
        End Property

        Friend Overridable Property PictureBox2 As PictureBox
            Get
                Return Me._PictureBox2
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As PictureBox)
                Me._PictureBox2 = value
            End Set
        End Property

        Friend Overridable Property PictureBox3 As PictureBox
            Get
                Return Me._PictureBox3
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As PictureBox)
                Me._PictureBox3 = value
            End Set
        End Property

        Friend Overridable Property PictureBox4 As PictureBox
            Get
                Return Me._PictureBox4
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As PictureBox)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.PictureBox4_Click)
                If (Not Me._PictureBox4 Is Nothing) Then
                    RemoveHandler Me._PictureBox4.Click, handler
                End If
                Me._PictureBox4 = value
                If (Not Me._PictureBox4 Is Nothing) Then
                    AddHandler Me._PictureBox4.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property PictureBox5 As PictureBox
            Get
                Return Me._PictureBox5
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As PictureBox)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.PictureBox5_Click)
                If (Not Me._PictureBox5 Is Nothing) Then
                    RemoveHandler Me._PictureBox5.Click, handler
                End If
                Me._PictureBox5 = value
                If (Not Me._PictureBox5 Is Nothing) Then
                    AddHandler Me._PictureBox5.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property PictureBox6 As PictureBox
            Get
                Return Me._PictureBox6
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As PictureBox)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.PictureBox6_Click)
                If (Not Me._PictureBox6 Is Nothing) Then
                    RemoveHandler Me._PictureBox6.Click, handler
                End If
                Me._PictureBox6 = value
                If (Not Me._PictureBox6 Is Nothing) Then
                    AddHandler Me._PictureBox6.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property RadioButton1 As RadioButton
            Get
                Return Me._RadioButton1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As RadioButton)
                Me._RadioButton1 = value
            End Set
        End Property

        Friend Overridable Property RadioButton2 As RadioButton
            Get
                Return Me._RadioButton2
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As RadioButton)
                Me._RadioButton2 = value
            End Set
        End Property

        Friend Overridable Property RadioButton3 As RadioButton
            Get
                Return Me._RadioButton3
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As RadioButton)
                Me._RadioButton3 = value
            End Set
        End Property

        Friend Overridable Property RadioButton4 As RadioButton
            Get
                Return Me._RadioButton4
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As RadioButton)
                Me._RadioButton4 = value
            End Set
        End Property

        Friend Overridable Property RadioButton5 As RadioButton
            Get
                Return Me._RadioButton5
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As RadioButton)
                Me._RadioButton5 = value
            End Set
        End Property

        Friend Overridable Property RadioButton6 As RadioButton
            Get
                Return Me._RadioButton6
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As RadioButton)
                Me._RadioButton6 = value
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
                Me._TextBox2 = value
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


        ' Fields
        <AccessedThroughProperty("Button1")> _
        Private _Button1 As Button
        <AccessedThroughProperty("Label1")> _
        Private _Label1 As Label
        <AccessedThroughProperty("Panel1")> _
        Private _Panel1 As Panel
        <AccessedThroughProperty("PictureBox1")> _
        Private _PictureBox1 As PictureBox
        <AccessedThroughProperty("PictureBox2")> _
        Private _PictureBox2 As PictureBox
        <AccessedThroughProperty("PictureBox3")> _
        Private _PictureBox3 As PictureBox
        <AccessedThroughProperty("PictureBox4")> _
        Private _PictureBox4 As PictureBox
        <AccessedThroughProperty("PictureBox5")> _
        Private _PictureBox5 As PictureBox
        <AccessedThroughProperty("PictureBox6")> _
        Private _PictureBox6 As PictureBox
        <AccessedThroughProperty("RadioButton1")> _
        Private _RadioButton1 As RadioButton
        <AccessedThroughProperty("RadioButton2")> _
        Private _RadioButton2 As RadioButton
        <AccessedThroughProperty("RadioButton3")> _
        Private _RadioButton3 As RadioButton
        <AccessedThroughProperty("RadioButton4")> _
        Private _RadioButton4 As RadioButton
        <AccessedThroughProperty("RadioButton5")> _
        Private _RadioButton5 As RadioButton
        <AccessedThroughProperty("RadioButton6")> _
        Private _RadioButton6 As RadioButton
        <AccessedThroughProperty("TextBox1")> _
        Private _TextBox1 As TextBox
        <AccessedThroughProperty("TextBox2")> _
        Private _TextBox2 As TextBox
        <AccessedThroughProperty("TextBox3")> _
        Private _TextBox3 As TextBox
        Private icontainer_0 As IContainer
    End Class
End Namespace

