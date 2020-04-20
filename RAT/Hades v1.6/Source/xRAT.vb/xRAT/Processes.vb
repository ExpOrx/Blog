Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Threading
Imports System.Windows.Forms

Namespace xRAT
    <DesignerGenerated> _
    Public Class Processes
        Inherits Form
        ' Methods
        Public Sub New()
            Class1.QaIGh5M7cuigS
            AddHandler MyBase.Load, New EventHandler(AddressOf Me.Processes_Load)
            Me.InitializeComponent
        End Sub

        Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            Class2.Class4_0.method_6.SendToSelected("PRCLIST")
            Me.Button1.Enabled = False
            Dim num As Integer = 1
            Do
                Thread.Sleep(10)
                Application.DoEvents
                num += 1
            Loop While (num <= 200)
            Me.Button1.Enabled = True
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
            Dim manager As New ComponentResourceManager(GetType(Processes))
            Me.ContextMenuStrip3 = New ContextMenuStrip(Me.icontainer_0)
            Me.KillProcessToolStripMenuItem = New ToolStripMenuItem
            Me.Button1 = New Button
            Me.ListView1 = New ListView
            Me.ColumnHeader1 = New ColumnHeader
            Me.ContextMenuStrip3.SuspendLayout
            Me.SuspendLayout
            Me.ContextMenuStrip3.Items.AddRange(New ToolStripItem() { Me.KillProcessToolStripMenuItem })
            Me.ContextMenuStrip3.Name = "ContextMenuStrip3"
            Dim size As New Size(&H8A, &H1A)
            Me.ContextMenuStrip3.Size = size
            Me.KillProcessToolStripMenuItem.Image = Class5.smethod_6
            Me.KillProcessToolStripMenuItem.Name = "KillProcessToolStripMenuItem"
            size = New Size(&H89, &H16)
            Me.KillProcessToolStripMenuItem.Size = size
            Me.KillProcessToolStripMenuItem.Text = "Kill Process"
            Dim point As New Point(12, &H10D)
            Me.Button1.Location = point
            Me.Button1.Name = "Button1"
            size = New Size(&HB0, &H1B)
            Me.Button1.Size = size
            Me.Button1.TabIndex = 2
            Me.Button1.Text = "Refresh Processes"
            Me.Button1.UseVisualStyleBackColor = True
            Me.ListView1.Columns.AddRange(New ColumnHeader() { Me.ColumnHeader1 })
            Me.ListView1.ContextMenuStrip = Me.ContextMenuStrip3
            Me.ListView1.FullRowSelect = True
            point = New Point(12, 12)
            Me.ListView1.Location = point
            Me.ListView1.MultiSelect = False
            Me.ListView1.Name = "ListView1"
            size = New Size(&HB0, &HFB)
            Me.ListView1.Size = size
            Me.ListView1.Sorting = SortOrder.Ascending
            Me.ListView1.TabIndex = 4
            Me.ListView1.UseCompatibleStateImageBehavior = False
            Me.ListView1.View = View.Details
            Me.ColumnHeader1.Text = "Process Name"
            Me.ColumnHeader1.Width = &HAC
            Dim ef As New SizeF(6!, 13!)
            Me.AutoScaleDimensions = ef
            Me.AutoScaleMode = AutoScaleMode.Font
            size = New Size(200, &H133)
            Me.ClientSize = size
            Me.Controls.Add(Me.ListView1)
            Me.Controls.Add(Me.Button1)
            Me.FormBorderStyle = FormBorderStyle.FixedToolWindow
            Me.Icon = DirectCast(manager.GetObject("$this.Icon"), Icon)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "Processes"
            Me.StartPosition = FormStartPosition.CenterScreen
            Me.Text = "Running Processes"
            Me.ContextMenuStrip3.ResumeLayout(False)
            Me.ResumeLayout(False)
        End Sub

        Private Sub KillProcessToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim str As String = Me.ListView1.SelectedItems.Item(0).Text.ToString.Replace(".exe", "")
            Class2.Class4_0.method_6.SendToSelected(("PRCKILL|" & str))
            Dim num As Integer = 1
            Do
                Thread.Sleep(10)
                Application.DoEvents
                num += 1
            Loop While (num <= 200)
            Me.Button1.PerformClick
        End Sub

        Private Sub method_0(ByVal sender As Object, ByVal e As EventArgs)
        End Sub

        Private Sub method_1(ByVal sender As Object, ByVal e As EventArgs)
        End Sub

        Private Sub Processes_Load(ByVal sender As Object, ByVal e As EventArgs)
            Class2.Class4_0.method_6.SendToSelected("PRCLIST")
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

        Friend Overridable Property ColumnHeader1 As ColumnHeader
            Get
                Return Me.columnHeader_0
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ColumnHeader)
                Me.columnHeader_0 = value
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

        Friend Overridable Property KillProcessToolStripMenuItem As ToolStripMenuItem
            Get
                Return Me._KillProcessToolStripMenuItem
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal value As ToolStripMenuItem)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.KillProcessToolStripMenuItem_Click)
                If (Not Me._KillProcessToolStripMenuItem Is Nothing) Then
                    RemoveHandler Me._KillProcessToolStripMenuItem.Click, handler
                End If
                Me._KillProcessToolStripMenuItem = value
                If (Not Me._KillProcessToolStripMenuItem Is Nothing) Then
                    AddHandler Me._KillProcessToolStripMenuItem.Click, handler
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


        ' Fields
        <AccessedThroughProperty("Button1")> _
        Private _Button1 As Button
        <AccessedThroughProperty("ContextMenuStrip3")> _
        Private _ContextMenuStrip3 As ContextMenuStrip
        <AccessedThroughProperty("KillProcessToolStripMenuItem")> _
        Private _KillProcessToolStripMenuItem As ToolStripMenuItem
        <AccessedThroughProperty("ListView1")> _
        Private _ListView1 As ListView
        <AccessedThroughProperty("ColumnHeader1")> _
        Private columnHeader_0 As ColumnHeader
        Private icontainer_0 As IContainer
    End Class
End Namespace

