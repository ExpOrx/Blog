Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms

Namespace xRAT
    <DesignerGenerated> _
    Public Class OpenURL
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
            Dim manager As New ComponentResourceManager(GetType(OpenURL))
            Me.Button1 = New Button
            Me.Label1 = New Label
            Me.TextBox1 = New TextBox
            Me.SuspendLayout
            Dim point As New Point(12, &H33)
            Me.Button1.Location = point
            Me.Button1.Name = "Button1"
            Dim size As New Size(260, &H1C)
            Me.Button1.Size = size
            Me.Button1.TabIndex = 0
            Me.Button1.Text = "Open"
            Me.Button1.UseVisualStyleBackColor = True
            Me.Label1.AutoSize = True
            point = New Point(12, 9)
            Me.Label1.Location = point
            Me.Label1.Name = "Label1"
            size = New Size(&H1A, 13)
            Me.Label1.Size = size
            Me.Label1.TabIndex = 1
            Me.Label1.Text = "URL"
            point = New Point(12, &H19)
            Me.TextBox1.Location = point
            Me.TextBox1.Name = "TextBox1"
            size = New Size(260, &H15)
            Me.TextBox1.Size = size
            Me.TextBox1.TabIndex = 2
            Dim ef As New SizeF(6!, 13!)
            Me.AutoScaleDimensions = ef
            Me.AutoScaleMode = AutoScaleMode.Font
            size = New Size(&H11C, &H5C)
            Me.ClientSize = size
            Me.Controls.Add(Me.TextBox1)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.Button1)
            Me.FormBorderStyle = FormBorderStyle.Fixed3D
            Me.Icon = DirectCast(manager.GetObject("$this.Icon"), Icon)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "OpenURL"
            Me.StartPosition = FormStartPosition.CenterScreen
            Me.Text = "URL"
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

