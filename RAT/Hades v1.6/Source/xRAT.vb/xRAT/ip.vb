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
    Public Class ip
        Inherits Form
        ' Methods
        Public Sub New()
            Class1.QaIGh5M7cuigS
            Me.InitializeComponent
        End Sub

        Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            Try 
                If Me.TextBox1.Text.Contains("http://") Then
                    Dim hostEntry As IPHostEntry = Dns.GetHostEntry(Me.TextBox1.Text.Replace("http://", String.Empty))
                    Me.TextBox2.Text = hostEntry.AddressList(0).ToString
                Else
                    Dim entry2 As IPHostEntry = Dns.GetHostEntry(Me.TextBox1.Text)
                    Me.TextBox2.Text = entry2.AddressList(0).ToString
                End If
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                Dim prompt As Exception = exception1
                Interaction.MsgBox(prompt, MsgBoxStyle.OkOnly, Nothing)
                ProjectData.ClearProjectError
            End Try
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
            Dim manager As New ComponentResourceManager(GetType(ip))
            Me.TextBox1 = New TextBox
            Me.TextBox2 = New TextBox
            Me.Button1 = New Button
            Me.SuspendLayout
            Dim point As New Point(12, 9)
            Me.TextBox1.Location = point
            Me.TextBox1.Name = "TextBox1"
            Dim size As New Size(&HDB, &H15)
            Me.TextBox1.Size = size
            Me.TextBox1.TabIndex = 0
            Me.TextBox1.Text = "www.google.fr"
            point = New Point(12, &H24)
            Me.TextBox2.Location = point
            Me.TextBox2.Name = "TextBox2"
            size = New Size(&HDB, &H15)
            Me.TextBox2.Size = size
            Me.TextBox2.TabIndex = 1
            point = New Point(12, &H3F)
            Me.Button1.Location = point
            Me.Button1.Name = "Button1"
            size = New Size(&HDB, &H1A)
            Me.Button1.Size = size
            Me.Button1.TabIndex = 2
            Me.Button1.Text = "Get IP"
            Me.Button1.UseVisualStyleBackColor = True
            Dim ef As New SizeF(6!, 13!)
            Me.AutoScaleDimensions = ef
            Me.AutoScaleMode = AutoScaleMode.Font
            size = New Size(&HF3, &H66)
            Me.ClientSize = size
            Me.Controls.Add(Me.Button1)
            Me.Controls.Add(Me.TextBox2)
            Me.Controls.Add(Me.TextBox1)
            Me.FormBorderStyle = FormBorderStyle.Fixed3D
            Me.Icon = DirectCast(manager.GetObject("$this.Icon"), Icon)
            Me.Name = "ip"
            Me.StartPosition = FormStartPosition.CenterScreen
            Me.Text = "Get IP"
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


        ' Fields
        <AccessedThroughProperty("Button1")> _
        Private _Button1 As Button
        <AccessedThroughProperty("TextBox1")> _
        Private _TextBox1 As TextBox
        <AccessedThroughProperty("TextBox2")> _
        Private _TextBox2 As TextBox
        Private icontainer_0 As IContainer
    End Class
End Namespace

