Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Net
Imports System.Runtime.CompilerServices
Imports System.Text
Imports System.Windows.Forms

Namespace xRAT
    <DesignerGenerated> _
    Public Class noip
        Inherits Form
        ' Methods
        Public Sub New()
            Class1.QaIGh5M7cuigS
            AddHandler MyBase.Load, New EventHandler(AddressOf Me.noip_Load)
            Me.InitializeComponent
        End Sub

        Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            Try 
                Dim flag1 As Boolean = Me.CheckBox1.Checked
                Dim client As New WebClient
                Dim encoding As New UTF8Encoding
                Dim strArray2 As String() = encoding.GetString(client.DownloadData(String.Concat(New String() { "http://dynupdate.no-ip.com/dns?username=", Me.TextBox1.Text, "&password=", Me.TextBox2.Text, "&hostname=", Me.TextBox3.Text }))).Split(New Char() { ":"c })
                Me.RichTextBox1.Text = strArray2(1)
                If strArray2(1).Contains("0") Then
                    Interaction.MsgBox("Success - IP address is current, no update performed", MsgBoxStyle.Information, "")
                End If
                If strArray2(1).Contains("1") Then
                    Interaction.MsgBox("Success - DNS hostname update successful", MsgBoxStyle.Information, "")
                End If
                If strArray2(1).Contains("2") Then
                    Interaction.MsgBox("Error - Hostname supplied does not exist", MsgBoxStyle.Critical, "")
                End If
                If strArray2(1).Contains("3") Then
                    Interaction.MsgBox("Error - Invalid username", MsgBoxStyle.Critical, "")
                End If
                If strArray2(1).Contains("4") Then
                    Interaction.MsgBox("Error - Invalid password", MsgBoxStyle.Critical, "")
                End If
                If strArray2(1).Contains("5") Then
                    Interaction.MsgBox("Error - Too many updates sent. Updates are blocked until 1 hour passes since last status of 5 returned.", MsgBoxStyle.Critical, "")
                End If
                If strArray2(1).Contains("6") Then
                    Interaction.MsgBox("Error - Account disabled due to violation of No-IP terms of service. Our terms of service can be viewed at http://www.no-ip.com/legal/tos", MsgBoxStyle.Critical, "")
                End If
                If strArray2(1).Contains("7") Then
                    Interaction.MsgBox("Error - Invalid IP. Invalid IP submitted is improperly formated, is a private LAN RFC 1918 address, or an abuse blacklisted address.", MsgBoxStyle.Critical, "")
                End If
                If strArray2(1).Contains("8") Then
                    Interaction.MsgBox("Error - Disabled / Locked hostname", MsgBoxStyle.Critical, "")
                End If
                If strArray2(1).Contains("9") Then
                    Interaction.MsgBox("Host updated is configured as a web redirect and no update was performed.", MsgBoxStyle.Information, "")
                End If
                If strArray2(1).Contains("10") Then
                    Interaction.MsgBox("Error - Group supplied does not exist", MsgBoxStyle.Critical, "")
                End If
                If strArray2(1).Contains("11") Then
                    Interaction.MsgBox("Success - DNS group update is successful", MsgBoxStyle.Information, "")
                End If
                If strArray2(1).Contains("12") Then
                    Interaction.MsgBox("Success - DNS group is current, no update performed.", MsgBoxStyle.Information, "")
                End If
                If strArray2(1).Contains("13") Then
                    Interaction.MsgBox("Error - Update client support not available for supplied hostname or group", MsgBoxStyle.Critical, "")
                End If
                If strArray2(1).Contains("14") Then
                    Interaction.MsgBox("Error - Hostname supplied does not have offline settings configured. Returned if sending offline=YES on a host that does not have any offline actions configured.", MsgBoxStyle.Critical, "")
                End If
                If strArray2(1).Contains("99") Then
                    Interaction.MsgBox("Error - Client disabled. Client should exit and not perform any more updates without user intervention.", MsgBoxStyle.Critical, "")
                End If
                If strArray2(1).Contains("100") Then
                    Interaction.MsgBox("Error - User input error usually returned if missing required request parameters", MsgBoxStyle.Critical, "")
                End If
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                MessageBox.Show("No-IP", "Error false ID !", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                ProjectData.ClearProjectError
            End Try
        End Sub

        Private Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
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
            Dim manager As New ComponentResourceManager(GetType(noip))
            Me.Label2 = New Label
            Me.Label3 = New Label
            Me.Button1 = New Button
            Me.TextBox1 = New TextBox
            Me.TextBox2 = New TextBox
            Me.TextBox3 = New TextBox
            Me.RichTextBox1 = New RichTextBox
            Me.CheckBox1 = New CheckBox
            Me.Label4 = New Label
            Me.SuspendLayout
            Me.Label2.AutoSize = True
            Me.Label2.ForeColor = Color.Black
            Dim point As New Point(&H11, &H24)
            Me.Label2.Location = point
            Me.Label2.Name = "Label2"
            Dim size As New Size(&H57, 13)
            Me.Label2.Size = size
            Me.Label2.TabIndex = 1
            Me.Label2.Text = "No-IP Password:"
            Me.Label3.AutoSize = True
            Me.Label3.ForeColor = Color.Black
            point = New Point(&H11, &H3B)
            Me.Label3.Location = point
            Me.Label3.Name = "Label3"
            size = New Size(&H3F, 13)
            Me.Label3.Size = size
            Me.Label3.TabIndex = 2
            Me.Label3.Text = "No-IP Host:"
            Me.Button1.AccessibleRole = AccessibleRole.PushButton
            Me.Button1.ForeColor = Color.Black
            point = New Point(20, &H53)
            Me.Button1.Location = point
            Me.Button1.Name = "Button1"
            size = New Size(&H100, 40)
            Me.Button1.Size = size
            Me.Button1.TabIndex = 3
            Me.Button1.Text = "Update"
            point = New Point(&H6B, 10)
            Me.TextBox1.Location = point
            Me.TextBox1.Name = "TextBox1"
            size = New Size(&HA9, &H15)
            Me.TextBox1.Size = size
            Me.TextBox1.TabIndex = 0
            point = New Point(&H6B, &H21)
            Me.TextBox2.Location = point
            Me.TextBox2.Name = "TextBox2"
            size = New Size(&HA9, &H15)
            Me.TextBox2.Size = size
            Me.TextBox2.TabIndex = 1
            point = New Point(&H6B, &H38)
            Me.TextBox3.Location = point
            Me.TextBox3.Name = "TextBox3"
            size = New Size(&HA9, &H15)
            Me.TextBox3.Size = size
            Me.TextBox3.TabIndex = 2
            point = New Point(13, &H9C)
            Me.RichTextBox1.Location = point
            Me.RichTextBox1.Name = "RichTextBox1"
            size = New Size(&HBD, &H8F)
            Me.RichTextBox1.Size = size
            Me.RichTextBox1.TabIndex = 4
            Me.RichTextBox1.Text = ""
            Me.RichTextBox1.Visible = False
            Me.CheckBox1.AutoSize = True
            point = New Point(12, &H9A)
            Me.CheckBox1.Location = point
            Me.CheckBox1.Name = "CheckBox1"
            size = New Size(&H4F, &H11)
            Me.CheckBox1.Size = size
            Me.CheckBox1.TabIndex = 5
            Me.CheckBox1.Text = "CheckBox1"
            Me.CheckBox1.UseVisualStyleBackColor = True
            Me.Label4.AutoSize = True
            Me.Label4.ForeColor = Color.Black
            point = New Point(&H11, 13)
            Me.Label4.Location = point
            Me.Label4.Name = "Label4"
            size = New Size(&H3F, 13)
            Me.Label4.Size = size
            Me.Label4.TabIndex = 6
            Me.Label4.Text = "No-IP User:"
            Dim ef As New SizeF(6!, 13!)
            Me.AutoScaleDimensions = ef
            Me.AutoScaleMode = AutoScaleMode.Font
            Me.BackColor = SystemColors.Control
            size = New Size(&H127, &H87)
            Me.ClientSize = size
            Me.Controls.Add(Me.Label4)
            Me.Controls.Add(Me.CheckBox1)
            Me.Controls.Add(Me.RichTextBox1)
            Me.Controls.Add(Me.TextBox1)
            Me.Controls.Add(Me.TextBox2)
            Me.Controls.Add(Me.TextBox3)
            Me.Controls.Add(Me.Button1)
            Me.Controls.Add(Me.Label3)
            Me.Controls.Add(Me.Label2)
            Me.ForeColor = Color.White
            Me.FormBorderStyle = FormBorderStyle.FixedSingle
            Me.Icon = DirectCast(manager.GetObject("$this.Icon"), Icon)
            size = New Size(&H1F0, &H1BE)
            Me.MaximumSize = size
            size = New Size(&H128, &H92)
            Me.MinimumSize = size
            Me.Name = "noip"
            Me.StartPosition = FormStartPosition.CenterScreen
            Me.Text = "No-IP Update"
            Me.ResumeLayout(False)
            Me.PerformLayout
        End Sub

        Private Sub noip_Load(ByVal sender As Object, ByVal e As EventArgs)
            Me.CheckBox1.Checked = True
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

        Friend Overridable Property CheckBox1 As CheckBox
            Get
                Return Me._CheckBox1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As CheckBox)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.CheckBox1_CheckedChanged)
                If (Not Me._CheckBox1 Is Nothing) Then
                    RemoveHandler Me._CheckBox1.CheckedChanged, handler
                End If
                Me._CheckBox1 = value
                If (Not Me._CheckBox1 Is Nothing) Then
                    AddHandler Me._CheckBox1.CheckedChanged, handler
                End If
            End Set
        End Property

        Friend Overridable Property Label1 As Label
            Get
                Return Me.label_0
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As Label)
                Me.label_0 = value
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

        Friend Overridable Property Label4 As Label
            Get
                Return Me._Label4
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As Label)
                Me._Label4 = value
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
        <AccessedThroughProperty("CheckBox1")> _
        Private _CheckBox1 As CheckBox
        <AccessedThroughProperty("Label2")> _
        Private _Label2 As Label
        <AccessedThroughProperty("Label3")> _
        Private _Label3 As Label
        <AccessedThroughProperty("Label4")> _
        Private _Label4 As Label
        <AccessedThroughProperty("RichTextBox1")> _
        Private _RichTextBox1 As RichTextBox
        <AccessedThroughProperty("TextBox1")> _
        Private _TextBox1 As TextBox
        <AccessedThroughProperty("TextBox2")> _
        Private _TextBox2 As TextBox
        <AccessedThroughProperty("TextBox3")> _
        Private _TextBox3 As TextBox
        Private icontainer_0 As IContainer
        <AccessedThroughProperty("Label1")> _
        Private label_0 As Label
    End Class
End Namespace

