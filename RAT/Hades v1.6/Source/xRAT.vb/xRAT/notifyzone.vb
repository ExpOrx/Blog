Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms

Namespace xRAT
    <DesignerGenerated> _
    Public Class notifyzone
        Inherits Form
        ' Methods
        Public Sub New()
            Class1.QaIGh5M7cuigS
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

        <DebuggerStepThrough> _
        Private Sub InitializeComponent()
            Dim manager As New ComponentResourceManager(GetType(notifyzone))
            Me.PictureBox1 = New PictureBox
            Me.Label1 = New Label
            DirectCast(Me.PictureBox1, ISupportInitialize).BeginInit
            Me.SuspendLayout
            Me.PictureBox1.BackColor = Color.Transparent
            Me.PictureBox1.Image = Class5.smethod_59
            Dim point As New Point(12, 12)
            Me.PictureBox1.Location = point
            Me.PictureBox1.Name = "PictureBox1"
            Dim size As New Size(&H22, &H23)
            Me.PictureBox1.Size = size
            Me.PictureBox1.TabIndex = 0
            Me.PictureBox1.TabStop = False
            Me.Label1.AutoSize = True
            Me.Label1.BackColor = Color.Transparent
            Me.Label1.Font = New Font("Tahoma", 14.25!, FontStyle.Bold, GraphicsUnit.Point, 0)
            Me.Label1.ForeColor = SystemColors.ActiveCaptionText
            point = New Point(&H34, &H10)
            Me.Label1.Location = point
            Me.Label1.Name = "Label1"
            size = New Size(&HDE, &H17)
            Me.Label1.Size = size
            Me.Label1.TabIndex = 1
            Me.Label1.Text = "New User Connected !"
            Dim ef As New SizeF(6!, 13!)
            Me.AutoScaleDimensions = ef
            Me.AutoScaleMode = AutoScaleMode.Font
            Me.BackgroundImage = Class5.smethod_29
            size = New Size(&H11E, &H3D)
            Me.ClientSize = size
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.PictureBox1)
            Me.FormBorderStyle = FormBorderStyle.FixedToolWindow
            Me.Icon = DirectCast(manager.GetObject("$this.Icon"), Icon)
            point = New Point(250, 250)
            Me.Location = point
            Me.Name = "notifyzone"
            Me.StartPosition = FormStartPosition.Manual
            Me.Text = "Had" & ChrW(232) & "s R.A.T  -  New User Connected !"
            DirectCast(Me.PictureBox1, ISupportInitialize).EndInit
            Me.ResumeLayout(False)
            Me.PerformLayout
        End Sub


        ' Properties
        Friend Overridable Property Label1 As Label
            Get
                Return Me._Label1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As Label)
                Me._Label1 = value
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


        ' Fields
        <AccessedThroughProperty("Label1")> _
        Private _Label1 As Label
        <AccessedThroughProperty("PictureBox1")> _
        Private _PictureBox1 As PictureBox
        Private icontainer_0 As IContainer
    End Class
End Namespace

