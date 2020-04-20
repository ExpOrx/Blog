Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms

Namespace xRAT
    <DesignerGenerated> _
    Public Class IP_Tracer
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
            Dim manager As New ComponentResourceManager(GetType(IP_Tracer))
            Me.WebBrowser1 = New WebBrowser
            Me.SuspendLayout
            Me.WebBrowser1.Dock = DockStyle.Fill
            Dim point As New Point(0, 0)
            Me.WebBrowser1.Location = point
            Dim size As New Size(20, 20)
            Me.WebBrowser1.MinimumSize = size
            Me.WebBrowser1.Name = "WebBrowser1"
            size = New Size(&H162, &H13A)
            Me.WebBrowser1.Size = size
            Me.WebBrowser1.TabIndex = 0
            Me.WebBrowser1.Url = New Uri("http://www.trouver-ip.com/", UriKind.Absolute)
            Dim ef As New SizeF(6!, 13!)
            Me.AutoScaleDimensions = ef
            Me.AutoScaleMode = AutoScaleMode.Font
            size = New Size(&H162, &H13A)
            Me.ClientSize = size
            Me.Controls.Add(Me.WebBrowser1)
            Me.Icon = DirectCast(manager.GetObject("$this.Icon"), Icon)
            Me.Name = "IP_Tracer"
            Me.StartPosition = FormStartPosition.CenterScreen
            Me.Text = "IP Tracer"
            Me.ResumeLayout(False)
        End Sub


        ' Properties
        Friend Overridable Property WebBrowser1 As WebBrowser
            Get
                Return Me._WebBrowser1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As WebBrowser)
                Me._WebBrowser1 = value
            End Set
        End Property


        ' Fields
        <AccessedThroughProperty("WebBrowser1")> _
        Private _WebBrowser1 As WebBrowser
        Private icontainer_0 As IContainer
    End Class
End Namespace

