Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Namespace xRAT
    Public Class Win8Progressbar
        Inherits ProgressBar
        ' Methods
        Public Sub New()
            Class1.QaIGh5M7cuigS
            AddHandler MyBase.Paint, New PaintEventHandler(AddressOf Me.Win8Progressbar_Paint)
            MyBase.SetStyle(ControlStyles.UserPaint, True)
            MyBase.SetStyle(ControlStyles.DoubleBuffer, True)
            MyBase.SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        End Sub

        Private Sub Win8Progressbar_Paint(ByVal sender As Object, ByVal e As PaintEventArgs)
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality
            Dim height As Integer = MyBase.ClientRectangle.Height
            Dim width As Integer = MyBase.ClientRectangle.Width
            Dim y As Integer = MyBase.ClientRectangle.Height
            Dim num4 As Integer = (MyBase.Maximum - MyBase.Minimum)
            Dim num5 As Integer = CInt(Math.Round(CDbl(((CDbl(width) / CDbl(num4)) * Me.Value))))
            Dim color As Color = Color.FromArgb(&HF4, &HF4, &HF4)
            Dim color2 As Color = Color.FromArgb(&HDE, &HDE, &HDE)
            Dim color3 As Color = Color.FromArgb(80, &HCF, &H66)
            Dim color4 As Color = Color.FromArgb(&H15, &HCB, &H34)
            Dim point As New Point(0, 0)
            Dim point2 As New Point(0, height)
            Dim brush As New LinearGradientBrush(point, point2, color, color2)
            point2 = New Point(0, 0)
            point = New Point(0, y)
            Dim brush2 As New LinearGradientBrush(point2, point, color3, color4)
            e.Graphics.FillRectangle(brush, 0, 2, width, (height - 4))
            e.Graphics.DrawRectangle(Pens.Black, 0, 0, (width - 1), (height - 1))
            If (MyBase.Value = MyBase.Maximum) Then
                e.Graphics.FillRectangle(brush2, 0, 0, (num5 - 1), (y - 1))
            Else
                e.Graphics.FillRectangle(brush2, 0, 0, num5, (y - 1))
            End If
        End Sub

    End Class
End Namespace

