Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms

Namespace xRAT
    <DesignerGenerated> _
    Public Class DL
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
            Dim manager As New ComponentResourceManager(GetType(DL))
            Me.TextBox1 = New TextBox
            Me.Button1 = New Button
            Me.Label1 = New Label
            Me.SuspendLayout
            Dim point As New Point(12, &H19)
            Me.TextBox1.Location = point
            Me.TextBox1.Name = "TextBox1"
            Dim size As New Size(&HD3, &H15)
            Me.TextBox1.Size = size
            Me.TextBox1.TabIndex = 0
            point = New Point(12, &H34)
            Me.Button1.Location = point
            Me.Button1.Name = "Button1"
            size = New Size(&HD3, &H1B)
            Me.Button1.Size = size
            Me.Button1.TabIndex = 1
            Me.Button1.Text = "Download and Execute"
            Me.Button1.UseVisualStyleBackColor = True
            Me.Label1.AutoSize = True
            point = New Point(9, 9)
            Me.Label1.Location = point
            Me.Label1.Name = "Label1"
            size = New Size(&H51, 13)
            Me.Label1.Size = size
            Me.Label1.TabIndex = 2
            Me.Label1.Text = "Download-URL:"
            Dim ef As New SizeF(6!, 13!)
            Me.AutoScaleDimensions = ef
            Me.AutoScaleMode = AutoScaleMode.Font
            size = New Size(&HEB, &H5B)
            Me.ClientSize = size
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.Button1)
            Me.Controls.Add(Me.TextBox1)
            Me.FormBorderStyle = FormBorderStyle.Fixed3D
            Me.Icon = DirectCast(manager.GetObject("$this.Icon"), Icon)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "DL"
            Me.StartPosition = FormStartPosition.CenterScreen
            Me.Text = "Download & Execute"
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

        Friend Overridable Property Label1 As Label
            Get
                Return Me._Label1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As Label)
                Me._Label1 = value
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

        Public ReadOnly Property URL As Object
            Get
                Return Me.TextBox1.Text
            End Get
        End Property


        ' Fields
        <AccessedThroughProperty("Button1")> _
        Private _Button1 As Button
        <AccessedThroughProperty("Label1")> _
        Private _Label1 As Label
        <AccessedThroughProperty("TextBox1")> _
        Private _TextBox1 As TextBox
        Private icontainer_0 As IContainer
    End Class
End Namespace

