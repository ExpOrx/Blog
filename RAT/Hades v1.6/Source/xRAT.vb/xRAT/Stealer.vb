Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms

Namespace xRAT
    <DesignerGenerated> _
    Public Class Stealer
        Inherits Form
        ' Methods
        Public Sub New()
            Class1.QaIGh5M7cuigS
            AddHandler MyBase.Load, New EventHandler(AddressOf Me.Stealer_Load)
            Me.InitializeComponent
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

        Private Sub exitbtn_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.Close
        End Sub

        <DebuggerStepThrough> _
        Private Sub InitializeComponent()
            Me.icontainer_0 = New Container
            Dim manager As New ComponentResourceManager(GetType(Stealer))
            Me.PictureBox1 = New PictureBox
            Me.Label7 = New Label
            Me.exitbtn = New Button
            Me.Timer1 = New Timer(Me.icontainer_0)
            Me.RichTextBox1 = New RichTextBox
            DirectCast(Me.PictureBox1, ISupportInitialize).BeginInit
            Me.SuspendLayout
            Me.PictureBox1.Image = Class5.smethod_49
            Dim point As New Point(11, &HF1)
            Me.PictureBox1.Location = point
            Me.PictureBox1.Name = "PictureBox1"
            Dim size As New Size(&H10, &H10)
            Me.PictureBox1.Size = size
            Me.PictureBox1.SizeMode = PictureBoxSizeMode.AutoSize
            Me.PictureBox1.TabIndex = &H16
            Me.PictureBox1.TabStop = False
            Me.Label7.AutoSize = True
            point = New Point(&H21, &HF2)
            Me.Label7.Location = point
            Me.Label7.Name = "Label7"
            size = New Size(&H49, 13)
            Me.Label7.Size = size
            Me.Label7.TabIndex = &H15
            Me.Label7.Text = "Please wait..."
            point = New Point(&HFD, &HEC)
            Me.exitbtn.Location = point
            Me.exitbtn.Name = "exitbtn"
            size = New Size(&H4E, &H18)
            Me.exitbtn.Size = size
            Me.exitbtn.TabIndex = 20
            Me.exitbtn.Text = "&Close"
            Me.exitbtn.UseVisualStyleBackColor = True
            point = New Point(12, 12)
            Me.RichTextBox1.Location = point
            Me.RichTextBox1.Name = "RichTextBox1"
            size = New Size(&H13F, &HDA)
            Me.RichTextBox1.Size = size
            Me.RichTextBox1.TabIndex = &H18
            Me.RichTextBox1.Text = ""
            Dim ef As New SizeF(6!, 13!)
            Me.AutoScaleDimensions = ef
            Me.AutoScaleMode = AutoScaleMode.Font
            Me.BackColor = Color.White
            size = New Size(&H157, &H110)
            Me.ClientSize = size
            Me.Controls.Add(Me.RichTextBox1)
            Me.Controls.Add(Me.PictureBox1)
            Me.Controls.Add(Me.Label7)
            Me.Controls.Add(Me.exitbtn)
            Me.FormBorderStyle = FormBorderStyle.Fixed3D
            Me.Icon = DirectCast(manager.GetObject("$this.Icon"), Icon)
            Me.Name = "Stealer"
            Me.StartPosition = FormStartPosition.CenterScreen
            Me.Text = "Stealer"
            DirectCast(Me.PictureBox1, ISupportInitialize).EndInit
            Me.ResumeLayout(False)
            Me.PerformLayout
        End Sub

        Private Sub Stealer_Load(ByVal sender As Object, ByVal e As EventArgs)
            Me.Timer1.Start
            Me.PictureBox1.Visible = True
            Me.Label7.Visible = True
        End Sub

        Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.RichTextBox1.Text = "") Then
                Me.RichTextBox1.Text = Class2.Class4_0.method_6.RichTextBox2.Text
            Else
                Me.Label7.Visible = False
                Me.PictureBox1.Visible = False
                Me.Timer1.Stop
            End If
        End Sub


        ' Properties
        Friend Overridable Property exitbtn As Button
            Get
                Return Me._exitbtn
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As Button)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.exitbtn_Click)
                If (Not Me._exitbtn Is Nothing) Then
                    RemoveHandler Me._exitbtn.Click, handler
                End If
                Me._exitbtn = value
                If (Not Me._exitbtn Is Nothing) Then
                    AddHandler Me._exitbtn.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property Label7 As Label
            Get
                Return Me._Label7
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As Label)
                Me._Label7 = value
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

        Friend Overridable Property RichTextBox1 As RichTextBox
            Get
                Return Me._RichTextBox1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As RichTextBox)
                Me._RichTextBox1 = value
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
        <AccessedThroughProperty("exitbtn")> _
        Private _exitbtn As Button
        <AccessedThroughProperty("Label7")> _
        Private _Label7 As Label
        <AccessedThroughProperty("PictureBox1")> _
        Private _PictureBox1 As PictureBox
        <AccessedThroughProperty("RichTextBox1")> _
        Private _RichTextBox1 As RichTextBox
        Private icontainer_0 As IContainer
        <AccessedThroughProperty("Timer1")> _
        Private timer_0 As Timer
    End Class
End Namespace

