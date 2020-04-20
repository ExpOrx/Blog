Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms

Namespace xRAT
    <DesignerGenerated> _
    Public Class Process
        Inherits Form
        ' Methods
        Public Sub New()
            Class1.QaIGh5M7cuigS
            Me.InitializeComponent
        End Sub

        Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            Class2.Class4_0.method_6.SendToSelected(("PRCSTART|" & Me.TextBox1.Text))
        End Sub

        Private Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs)
            Class2.Class4_0.method_6.SendToSelected(("PRCKILL|" & Me.TextBox2.Text))
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
            Dim manager As New ComponentResourceManager(GetType(Process))
            Me.TextBox1 = New TextBox
            Me.Label1 = New Label
            Me.Label2 = New Label
            Me.TextBox2 = New TextBox
            Me.Button1 = New Button
            Me.Button2 = New Button
            Me.SuspendLayout
            Dim point As New Point(12, &H19)
            Me.TextBox1.Location = point
            Me.TextBox1.Name = "TextBox1"
            Dim size As New Size(&HDD, &H15)
            Me.TextBox1.Size = size
            Me.TextBox1.TabIndex = 0
            Me.Label1.AutoSize = True
            point = New Point(12, 9)
            Me.Label1.Location = point
            Me.Label1.Name = "Label1"
            size = New Size(&H4C, 13)
            Me.Label1.Size = size
            Me.Label1.TabIndex = 1
            Me.Label1.Text = "Path or Name:"
            Me.Label2.AutoSize = True
            point = New Point(12, &H60)
            Me.Label2.Location = point
            Me.Label2.Name = "Label2"
            size = New Size(&H26, 13)
            Me.Label2.Size = size
            Me.Label2.TabIndex = 2
            Me.Label2.Text = "Name:"
            point = New Point(12, &H70)
            Me.TextBox2.Location = point
            Me.TextBox2.Name = "TextBox2"
            size = New Size(&HDD, &H15)
            Me.TextBox2.Size = size
            Me.TextBox2.TabIndex = 3
            point = New Point(12, &H33)
            Me.Button1.Location = point
            Me.Button1.Name = "Button1"
            size = New Size(&HDD, &H17)
            Me.Button1.Size = size
            Me.Button1.TabIndex = 4
            Me.Button1.Text = "Start"
            Me.Button1.UseVisualStyleBackColor = True
            point = New Point(12, &H8A)
            Me.Button2.Location = point
            Me.Button2.Name = "Button2"
            size = New Size(&HDD, &H17)
            Me.Button2.Size = size
            Me.Button2.TabIndex = 5
            Me.Button2.Text = "Kill"
            Me.Button2.UseVisualStyleBackColor = True
            Dim ef As New SizeF(6!, 13!)
            Me.AutoScaleDimensions = ef
            Me.AutoScaleMode = AutoScaleMode.Font
            size = New Size(&HF5, &HB6)
            Me.ClientSize = size
            Me.Controls.Add(Me.Button2)
            Me.Controls.Add(Me.Button1)
            Me.Controls.Add(Me.TextBox2)
            Me.Controls.Add(Me.Label2)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.TextBox1)
            Me.FormBorderStyle = FormBorderStyle.Fixed3D
            Me.Icon = DirectCast(manager.GetObject("$this.Icon"), Icon)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "Process"
            Me.StartPosition = FormStartPosition.CenterScreen
            Me.Text = "Process"
            Me.ResumeLayout(False)
            Me.PerformLayout
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
        <AccessedThroughProperty("Label1")> _
        Private _Label1 As Label
        <AccessedThroughProperty("Label2")> _
        Private _Label2 As Label
        <AccessedThroughProperty("TextBox1")> _
        Private _TextBox1 As TextBox
        <AccessedThroughProperty("TextBox2")> _
        Private _TextBox2 As TextBox
        Private icontainer_0 As IContainer
    End Class
End Namespace

