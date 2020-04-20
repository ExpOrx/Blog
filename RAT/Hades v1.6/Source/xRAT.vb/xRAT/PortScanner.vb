Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Net
Imports System.Net.Sockets
Imports System.Runtime.CompilerServices
Imports System.Threading
Imports System.Windows.Forms

Namespace xRAT
    <DesignerGenerated> _
    Public Class PortScanner
        Inherits Form
        ' Methods
        Public Sub New()
            Class1.QaIGh5M7cuigS
            Me.InitializeComponent
        End Sub

        Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            If Me.bool_0 Then
                Me.method_2(True)
            Else
                Me.method_2(False)
                Me.ListBox1.Items.Clear
                Me.ProgressBar1.Maximum = Convert.ToInt32(Decimal.Add(Me.NumericUpDown2.Value, Decimal.One))
                Me.ProgressBar1.Minimum = Convert.ToInt32(Me.NumericUpDown1.Value)
                Me.ProgressBar1.Value = Convert.ToInt32(Me.NumericUpDown1.Value)
                Try 
                    Dim address As IPAddress = Me.method_0(Me.TextBox1.Text)
                    Dim num As Integer = 0
                    Do
                        New Thread(New ParameterizedThreadStart(AddressOf Me.method_3)).Start(New Object() { Decimal.Add(Me.NumericUpDown1.Value, New Decimal(num)), Me.NumericUpDown2.Value, 8, address, Me.NumericUpDown3.Value })
                        num += 1
                    Loop While (num <= 7)
                Catch exception1 As Exception
                    ProjectData.SetProjectError(exception1)
                    ProjectData.ClearProjectError
                End Try
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

        <DebuggerStepThrough> _
        Private Sub InitializeComponent()
            Dim manager As New ComponentResourceManager(GetType(PortScanner))
            Me.NumericUpDown1 = New NumericUpDown
            Me.NumericUpDown2 = New NumericUpDown
            Me.TextBox1 = New TextBox
            Me.Label2 = New Label
            Me.Label3 = New Label
            Me.ListBox1 = New ListBox
            Me.NumericUpDown3 = New NumericUpDown
            Me.Label4 = New Label
            Me.Button1 = New Button
            Me.Label5 = New Label
            Me.ProgressBar1 = New ProgressBar
            Me.NumericUpDown1.BeginInit
            Me.NumericUpDown2.BeginInit
            Me.NumericUpDown3.BeginInit
            Me.SuspendLayout
            Me.NumericUpDown1.Font = New Font("Verdana", 8.25!, FontStyle.Regular, GraphicsUnit.Point, 0)
            Dim point As New Point(&H80, 70)
            Me.NumericUpDown1.Location = point
            Dim num As New Decimal(New Integer() { &HFFFF, 0, 0, 0 })
            Me.NumericUpDown1.Maximum = num
            Me.NumericUpDown1.Name = "NumericUpDown1"
            Dim size As New Size(60, &H15)
            Me.NumericUpDown1.Size = size
            Me.NumericUpDown1.TabIndex = 2
            Me.NumericUpDown1.TextAlign = HorizontalAlignment.Center
            Me.NumericUpDown2.Font = New Font("Verdana", 8.25!, FontStyle.Regular, GraphicsUnit.Point, 0)
            point = New Point(&HC2, 70)
            Me.NumericUpDown2.Location = point
            num = New Decimal(New Integer() { &HFFFF, 0, 0, 0 })
            Me.NumericUpDown2.Maximum = num
            Me.NumericUpDown2.Name = "NumericUpDown2"
            size = New Size(60, &H15)
            Me.NumericUpDown2.Size = size
            Me.NumericUpDown2.TabIndex = 3
            Me.NumericUpDown2.TextAlign = HorizontalAlignment.Center
            Me.TextBox1.Font = New Font("Verdana", 8.25!, FontStyle.Regular, GraphicsUnit.Point, 0)
            point = New Point(&H80, &H19)
            Me.TextBox1.Location = point
            Me.TextBox1.Name = "TextBox1"
            size = New Size(&H7E, &H15)
            Me.TextBox1.Size = size
            Me.TextBox1.TabIndex = 4
            Me.TextBox1.Text = "127.0.0.1"
            Me.TextBox1.TextAlign = HorizontalAlignment.Center
            Me.Label2.AutoSize = True
            Me.Label2.Font = New Font("Verdana", 8.25!, FontStyle.Regular, GraphicsUnit.Point, 0)
            point = New Point(&H7D, &H36)
            Me.Label2.Location = point
            Dim padding As New Padding(3, 5, 3, 0)
            Me.Label2.Margin = padding
            Me.Label2.Name = "Label2"
            size = New Size(70, 13)
            Me.Label2.Size = size
            Me.Label2.TabIndex = 5
            Me.Label2.Text = "Port Range"
            Me.Label3.AutoSize = True
            Me.Label3.Font = New Font("Verdana", 8.25!, FontStyle.Regular, GraphicsUnit.Point, 0)
            point = New Point(&H7D, 9)
            Me.Label3.Location = point
            Me.Label3.Name = "Label3"
            size = New Size(&H2C, 13)
            Me.Label3.Size = size
            Me.Label3.TabIndex = 7
            Me.Label3.Text = "Target"
            Me.ListBox1.FormattingEnabled = True
            point = New Point(15, &H19)
            Me.ListBox1.Location = point
            Me.ListBox1.Name = "ListBox1"
            size = New Size(&H6B, &HBA)
            Me.ListBox1.Size = size
            Me.ListBox1.TabIndex = 8
            Me.NumericUpDown3.Font = New Font("Verdana", 8.25!, FontStyle.Regular, GraphicsUnit.Point, 0)
            point = New Point(&H80, &H73)
            Me.NumericUpDown3.Location = point
            num = New Decimal(New Integer() { &HEA60, 0, 0, 0 })
            Me.NumericUpDown3.Maximum = num
            Me.NumericUpDown3.Name = "NumericUpDown3"
            size = New Size(&H7E, &H15)
            Me.NumericUpDown3.Size = size
            Me.NumericUpDown3.TabIndex = 9
            Me.NumericUpDown3.TextAlign = HorizontalAlignment.Center
            num = New Decimal(New Integer() { 800, 0, 0, 0 })
            Me.NumericUpDown3.Value = num
            Me.Label4.AutoSize = True
            Me.Label4.Font = New Font("Verdana", 8.25!, FontStyle.Regular, GraphicsUnit.Point, 0)
            point = New Point(&H81, &H63)
            Me.Label4.Location = point
            padding = New Padding(3, 5, 3, 0)
            Me.Label4.Margin = padding
            Me.Label4.Name = "Label4"
            size = New Size(&H35, 13)
            Me.Label4.Size = size
            Me.Label4.TabIndex = 10
            Me.Label4.Text = "Timeout"
            Me.Button1.Font = New Font("Verdana", 8.25!, FontStyle.Regular, GraphicsUnit.Point, 0)
            point = New Point(&H80, 180)
            Me.Button1.Location = point
            Me.Button1.Name = "Button1"
            size = New Size(&H7E, &H1F)
            Me.Button1.Size = size
            Me.Button1.TabIndex = 11
            Me.Button1.Text = "Scan Ports"
            Me.Button1.UseVisualStyleBackColor = True
            Me.Label5.AutoSize = True
            Me.Label5.Font = New Font("Verdana", 8.25!, FontStyle.Regular, GraphicsUnit.Point, 0)
            point = New Point(12, 9)
            Me.Label5.Location = point
            Me.Label5.Name = "Label5"
            size = New Size(70, 13)
            Me.Label5.Size = size
            Me.Label5.TabIndex = 12
            Me.Label5.Text = "Open Ports"
            point = New Point(&H80, &H97)
            Me.ProgressBar1.Location = point
            Me.ProgressBar1.Name = "ProgressBar1"
            size = New Size(&H7E, &H17)
            Me.ProgressBar1.Size = size
            Me.ProgressBar1.TabIndex = 13
            Dim ef As New SizeF(6!, 13!)
            Me.AutoScaleDimensions = ef
            Me.AutoScaleMode = AutoScaleMode.Font
            size = New Size(&H108, &HDD)
            Me.ClientSize = size
            Me.Controls.Add(Me.ProgressBar1)
            Me.Controls.Add(Me.Label5)
            Me.Controls.Add(Me.Button1)
            Me.Controls.Add(Me.Label4)
            Me.Controls.Add(Me.NumericUpDown3)
            Me.Controls.Add(Me.ListBox1)
            Me.Controls.Add(Me.Label3)
            Me.Controls.Add(Me.Label2)
            Me.Controls.Add(Me.TextBox1)
            Me.Controls.Add(Me.NumericUpDown2)
            Me.Controls.Add(Me.NumericUpDown1)
            Me.FormBorderStyle = FormBorderStyle.Fixed3D
            Me.Icon = DirectCast(manager.GetObject("$this.Icon"), Icon)
            Me.MaximizeBox = False
            Me.Name = "PortScanner"
            Me.StartPosition = FormStartPosition.CenterScreen
            Me.Text = "Port Scanner"
            Me.NumericUpDown1.EndInit
            Me.NumericUpDown2.EndInit
            Me.NumericUpDown3.EndInit
            Me.ResumeLayout(False)
            Me.PerformLayout
        End Sub

        Private Function method_0(ByVal string_0 As String) As IPAddress
            Return Dns.GetHostEntry(string_0).AddressList(0)
        End Function

        Private Function method_1(ByVal ipaddress_0 As IPAddress, ByVal int_0 As Integer, ByVal int_1 As Integer) As Boolean
            Dim flag As Boolean
            Dim socket As New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            Try 
                socket.BeginConnect(ipaddress_0, int_0, Nothing, 0)
                Dim time As DateTime = DateAndTime.Now.AddMilliseconds(CDbl(int_1))
                Do While (DateTime.Compare(DateAndTime.Now, time) < 0)
                    Thread.Sleep(1)
                    If socket.Connected Then
                        goto Label_0049
                    End If
                Loop
                Return flag
            Label_0049:
                flag = True
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                ProjectData.ClearProjectError
            Finally
                If (Not socket Is Nothing) Then
                    socket.Dispose
                End If
            End Try
            Return flag
        End Function

        Private Sub method_2(ByVal bool_1 As Boolean)
            Me.NumericUpDown1.Enabled = bool_1
            Me.NumericUpDown2.Enabled = bool_1
            Me.NumericUpDown3.Enabled = bool_1
            Me.Button1.Text = If(bool_1, "Begin", "Cancel")
            Me.bool_0 = Not bool_1
        End Sub

        Private Sub method_3(ByVal object_0 As Object)
            Dim obj2 As Object
            Dim obj3 As Object
            If ForLoopControl.ForLoopInitObj(obj2, NewLateBinding.LateIndexGet(object_0, New Object() { 0 }, Nothing), NewLateBinding.LateIndexGet(object_0, New Object() { 1 }, Nothing), NewLateBinding.LateIndexGet(object_0, New Object() { 2 }, Nothing), obj3, obj2) Then
                Do While Me.bool_0
                    Me.method_4(Me.method_1(DirectCast(NewLateBinding.LateIndexGet(object_0, New Object() { 3 }, Nothing), IPAddress), Conversions.ToInteger(obj2), Conversions.ToInteger(NewLateBinding.LateIndexGet(object_0, New Object() { 4 }, Nothing))), Conversions.ToInteger(obj2))
                    If Not ForLoopControl.ForNextCheckObj(obj2, obj3, obj2) Then
                        Exit Do
                    End If
                Loop
            End If
        End Sub

        Private Sub method_4(ByVal bool_1 As Boolean, ByVal int_0 As Integer)
            If Me.InvokeRequired Then
                Me.Invoke(New OD(AddressOf Me.method_4), New Object() { bool_1, int_0 })
            Else
                If bool_1 Then
                    Me.ListBox1.Items.Add(int_0)
                End If
                Dim bar As ProgressBar = Me.ProgressBar1
                bar.Value += 1
                If (Me.ProgressBar1.Value = Me.ProgressBar1.Maximum) Then
                    Me.method_2(True)
                End If
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

        Friend Overridable Property Label5 As Label
            Get
                Return Me._Label5
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As Label)
                Me._Label5 = value
            End Set
        End Property

        Friend Overridable Property ListBox1 As ListBox
            Get
                Return Me._ListBox1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ListBox)
                Me._ListBox1 = value
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

        Friend Overridable Property NumericUpDown2 As NumericUpDown
            Get
                Return Me._NumericUpDown2
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As NumericUpDown)
                Me._NumericUpDown2 = value
            End Set
        End Property

        Friend Overridable Property NumericUpDown3 As NumericUpDown
            Get
                Return Me._NumericUpDown3
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As NumericUpDown)
                Me._NumericUpDown3 = value
            End Set
        End Property

        Friend Overridable Property ProgressBar1 As ProgressBar
            Get
                Return Me._ProgressBar1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ProgressBar)
                Me._ProgressBar1 = value
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


        ' Fields
        <AccessedThroughProperty("Button1")> _
        Private _Button1 As Button
        <AccessedThroughProperty("Label2")> _
        Private _Label2 As Label
        <AccessedThroughProperty("Label3")> _
        Private _Label3 As Label
        <AccessedThroughProperty("Label4")> _
        Private _Label4 As Label
        <AccessedThroughProperty("Label5")> _
        Private _Label5 As Label
        <AccessedThroughProperty("ListBox1")> _
        Private _ListBox1 As ListBox
        <AccessedThroughProperty("NumericUpDown1")> _
        Private _NumericUpDown1 As NumericUpDown
        <AccessedThroughProperty("NumericUpDown2")> _
        Private _NumericUpDown2 As NumericUpDown
        <AccessedThroughProperty("NumericUpDown3")> _
        Private _NumericUpDown3 As NumericUpDown
        <AccessedThroughProperty("ProgressBar1")> _
        Private _ProgressBar1 As ProgressBar
        <AccessedThroughProperty("TextBox1")> _
        Private _TextBox1 As TextBox
        Private bool_0 As Boolean
        Private icontainer_0 As IContainer

        ' Nested Types
        Public Delegate Sub OD(ByVal open As Boolean, ByVal port As Integer)
    End Class
End Namespace

