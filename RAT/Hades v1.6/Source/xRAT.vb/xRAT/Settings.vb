Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms

Namespace xRAT
    <DesignerGenerated> _
    Public Class Settings
        Inherits Form
        ' Methods
        Public Sub New()
            Class1.QaIGh5M7cuigS
            AddHandler MyBase.Load, New EventHandler(AddressOf Me.Settings_Load)
            Me.InitializeComponent
        End Sub

        Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            Class2.Class4_0.method_6.autorefreshInt = Convert.ToInt32(Me.NumericUpDown1.Value)
        End Sub

        Private Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
            Select Case Me.CheckBox1.Checked
                Case False
                    Class2.Class4_0.method_6.popupnotify = 0
                    Exit Select
                Case True
                    Class2.Class4_0.method_6.popupnotify = 1
                    Exit Select
            End Select
        End Sub

        Private Sub CheckBox2_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
            Select Case Me.CheckBox2.Checked
                Case False
                    Me.NumericUpDown1.Enabled = False
                    Class2.Class4_0.method_6.autorefreshact = 0
                    Class2.Class4_0.method_6.Timer1.Enabled = False
                    Exit Select
                Case True
                    Me.NumericUpDown1.Enabled = True
                    Class2.Class4_0.method_6.autorefreshact = 1
                    Class2.Class4_0.method_6.Timer1.Enabled = True
                    Class2.Class4_0.method_6.autorefreshInt = Convert.ToInt32(Me.NumericUpDown1.Value)
                    Class2.Class4_0.method_6.Timer1.Interval = Convert.ToInt32(Decimal.Multiply(Me.NumericUpDown1.Value, 1000))
                    Exit Select
            End Select
        End Sub

        Private Sub CheckBox3_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
            Select Case Me.CheckBox3.Checked
                Case False
                    Class2.Class4_0.method_6.autosize = 0
                    Exit Select
                Case True
                    Class2.Class4_0.method_6.autosize = 1
                    Class2.Class4_0.method_6.AppNewAutosizeColumns(Class2.Class4_0.method_6.lstClients)
                    Exit Select
            End Select
        End Sub

        Private Sub CheckBox4_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
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
            Dim manager As New ComponentResourceManager(GetType(Settings))
            Me.CheckBox1 = New CheckBox
            Me.Label16 = New Label
            Me.CheckBox2 = New CheckBox
            Me.Label1 = New Label
            Me.NumericUpDown1 = New NumericUpDown
            Me.Label2 = New Label
            Me.Button1 = New Button
            Me.CheckBox3 = New CheckBox
            Me.CheckBox4 = New CheckBox
            Me.NumericUpDown1.BeginInit
            Me.SuspendLayout
            Me.CheckBox1.AutoSize = True
            Dim point As New Point(12, &H29)
            Me.CheckBox1.Location = point
            Me.CheckBox1.Name = "CheckBox1"
            Dim size As New Size(&HE2, &H11)
            Me.CheckBox1.Size = size
            Me.CheckBox1.TabIndex = 0
            Me.CheckBox1.Text = "Sound notification (On server connection)"
            Me.CheckBox1.UseVisualStyleBackColor = True
            Me.Label16.AutoSize = True
            Me.Label16.Font = New Font("Microsoft Sans Serif", 18!, FontStyle.Regular, GraphicsUnit.Point, 0)
            Me.Label16.ForeColor = SystemColors.ControlDarkDark
            point = New Point(12, 9)
            Me.Label16.Location = point
            Me.Label16.Name = "Label16"
            size = New Size(100, &H1D)
            Me.Label16.Size = size
            Me.Label16.TabIndex = &H29
            Me.Label16.Text = "Settings"
            Me.CheckBox2.AutoSize = True
            point = New Point(12, 110)
            Me.CheckBox2.Location = point
            Me.CheckBox2.Name = "CheckBox2"
            size = New Size(&HB2, &H11)
            Me.CheckBox2.Size = size
            Me.CheckBox2.TabIndex = &H2A
            Me.CheckBox2.Text = "Autorefresh Server Information"
            Me.CheckBox2.UseVisualStyleBackColor = True
            Me.Label1.AutoSize = True
            point = New Point(12, &H88)
            Me.Label1.Location = point
            Me.Label1.Name = "Label1"
            size = New Size(&H58, 13)
            Me.Label1.Size = size
            Me.Label1.TabIndex = &H2B
            Me.Label1.Text = "Refresh interval:"
            Me.NumericUpDown1.Enabled = False
            point = New Point(100, &H84)
            Me.NumericUpDown1.Location = point
            Dim num As New Decimal(New Integer() { &H3E8, 0, 0, 0 })
            Me.NumericUpDown1.Maximum = num
            num = New Decimal(New Integer() { 1, 0, 0, 0 })
            Me.NumericUpDown1.Minimum = num
            Me.NumericUpDown1.Name = "NumericUpDown1"
            size = New Size(&H41, &H15)
            Me.NumericUpDown1.Size = size
            Me.NumericUpDown1.TabIndex = &H2C
            num = New Decimal(New Integer() { 60, 0, 0, 0 })
            Me.NumericUpDown1.Value = num
            Me.Label2.AutoSize = True
            point = New Point(&HA7, &H88)
            Me.Label2.Location = point
            Me.Label2.Name = "Label2"
            size = New Size(12, 13)
            Me.Label2.Size = size
            Me.Label2.TabIndex = &H2D
            Me.Label2.Text = "s"
            point = New Point(&HED, &H29)
            Me.Button1.Location = point
            Me.Button1.Name = "Button1"
            size = New Size(&H9F, &H70)
            Me.Button1.Size = size
            Me.Button1.TabIndex = &H2E
            Me.Button1.Text = "Save interval"
            Me.Button1.UseVisualStyleBackColor = True
            Me.CheckBox3.AutoSize = True
            point = New Point(12, &H57)
            Me.CheckBox3.Location = point
            Me.CheckBox3.Name = "CheckBox3"
            size = New Size(110, &H11)
            Me.CheckBox3.Size = size
            Me.CheckBox3.TabIndex = &H2F
            Me.CheckBox3.Text = "Autosize Columns"
            Me.CheckBox3.UseVisualStyleBackColor = True
            Me.CheckBox4.AutoSize = True
            Me.CheckBox4.Checked = True
            Me.CheckBox4.CheckState = CheckState.Checked
            point = New Point(12, &H40)
            Me.CheckBox4.Location = point
            Me.CheckBox4.Name = "CheckBox4"
            size = New Size(&HDF, &H11)
            Me.CheckBox4.Size = size
            Me.CheckBox4.TabIndex = &H30
            Me.CheckBox4.Text = "Visual notification (On server connection)"
            Me.CheckBox4.UseVisualStyleBackColor = True
            Dim ef As New SizeF(6!, 13!)
            Me.AutoScaleDimensions = ef
            Me.AutoScaleMode = AutoScaleMode.Font
            size = New Size(&H195, &HA7)
            Me.ClientSize = size
            Me.Controls.Add(Me.CheckBox4)
            Me.Controls.Add(Me.CheckBox3)
            Me.Controls.Add(Me.Button1)
            Me.Controls.Add(Me.Label2)
            Me.Controls.Add(Me.NumericUpDown1)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.CheckBox2)
            Me.Controls.Add(Me.Label16)
            Me.Controls.Add(Me.CheckBox1)
            Me.FormBorderStyle = FormBorderStyle.Fixed3D
            Me.Icon = DirectCast(manager.GetObject("$this.Icon"), Icon)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "Settings"
            Me.StartPosition = FormStartPosition.CenterScreen
            Me.Text = "Settings"
            Me.NumericUpDown1.EndInit
            Me.ResumeLayout(False)
            Me.PerformLayout
        End Sub

        Private Sub Settings_Load(ByVal sender As Object, ByVal e As EventArgs)
            If (Class2.Class4_0.method_6.popupnotify = 1) Then
                Me.CheckBox1.Checked = True
            End If
            If (Class2.Class4_0.method_6.autosize = 1) Then
                Me.CheckBox3.Checked = True
            End If
            If (Class2.Class4_0.method_6.autorefreshact = 1) Then
                Me.NumericUpDown1.Enabled = True
                Me.CheckBox2.Checked = True
                Me.NumericUpDown1.Value = New Decimal(Class2.Class4_0.method_6.autorefreshInt)
            Else
                Me.NumericUpDown1.Enabled = False
            End If
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
                Dim handler As EventHandler = New EventHandler(AddressOf Me.CheckBox4_CheckedChanged)
                If (Not Me._CheckBox4 Is Nothing) Then
                    RemoveHandler Me._CheckBox4.CheckedChanged, handler
                End If
                Me._CheckBox4 = value
                If (Not Me._CheckBox4 Is Nothing) Then
                    AddHandler Me._CheckBox4.CheckedChanged, handler
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

        Friend Overridable Property Label16 As Label
            Get
                Return Me._Label16
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As Label)
                Me._Label16 = value
            End Set
        End Property

        Friend Overridable Property Label2 As Label
            Get
                Return Me.daxawBwCf
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As Label)
                Me.daxawBwCf = value
            End Set
        End Property

        Friend Overridable Property NumericUpDown1 As NumericUpDown
            Get
                Return Me._NumericUpDown1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As NumericUpDown)
                Me._NumericUpDown1 = value
            End Set
        End Property


        ' Fields
        <AccessedThroughProperty("Button1")> _
        Private _Button1 As Button
        <AccessedThroughProperty("CheckBox1")> _
        Private _CheckBox1 As CheckBox
        <AccessedThroughProperty("CheckBox2")> _
        Private _CheckBox2 As CheckBox
        <AccessedThroughProperty("CheckBox3")> _
        Private _CheckBox3 As CheckBox
        <AccessedThroughProperty("CheckBox4")> _
        Private _CheckBox4 As CheckBox
        <AccessedThroughProperty("Label1")> _
        Private _Label1 As Label
        <AccessedThroughProperty("Label16")> _
        Private _Label16 As Label
        <AccessedThroughProperty("NumericUpDown1")> _
        Private _NumericUpDown1 As NumericUpDown
        <AccessedThroughProperty("Label2")> _
        Private daxawBwCf As Label
        Private icontainer_0 As IContainer
    End Class
End Namespace

