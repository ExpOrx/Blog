Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Friend Class Control0
    Inherits TabControl
    ' Methods
    Public Sub New()
        Class1.QaIGh5M7cuigS
        Me.struct0_0 = New Struct0
        Me.int_0 = 50
        Me.SetStyle((ControlStyles.DoubleBuffer Or (ControlStyles.AllPaintingInWmPaint Or (ControlStyles.ResizeRedraw Or ControlStyles.UserPaint))), True)
        Me.DoubleBuffered = True
        Me.SizeMode = TabSizeMode.Fixed
        Dim size As New Size(&H2C, &H88)
        Me.ItemSize = size
    End Sub

    Protected Overrides Sub CreateHandle()
        MyBase.CreateHandle
        MyBase.DoubleBuffered = True
        Me.SizeMode = TabSizeMode.Fixed
        Me.Alignment = TabAlignment.Left
        Me.SetStyle((ControlStyles.DoubleBuffer Or (ControlStyles.AllPaintingInWmPaint Or (ControlStyles.ResizeRedraw Or ControlStyles.UserPaint))), True)
    End Sub

    Public Function method_0() As Integer
        Return Me.int_0
    End Function

    Public Sub method_1(ByVal int_1 As Integer)
        If Information.IsNothing(int_1) Then
            int_1 = 50
        End If
        If (int_1 < 0) Then
            int_1 = 0
        End If
        If (int_1 > 100) Then
            int_1 = 100
        End If
        Me.int_0 = int_1
    End Sub

    Private Function method_2(ByVal color_0 As Color) As Pen
        Return New Pen(color_0)
    End Function

    Private Function method_3(ByVal color_0 As Color) As Brush
        Return New SolidBrush(color_0)
    End Function

    Private Function method_4(ByVal bitmap_0 As Bitmap, ByVal float_0 As Single) As Image
        Dim image As New Bitmap(bitmap_0.Width, bitmap_0.Height, PixelFormat.Format32bppArgb)
        Dim bitmap2 As Bitmap = bitmap_0
        float_0 = Math.Min(float_0, 100!)
        Using attributes As ImageAttributes = New ImageAttributes
            Dim newColorMatrix As New ColorMatrix With { _
                .Matrix33 = (float_0 / 100!) _
            }
            attributes.SetColorMatrix(newColorMatrix)
            Dim tfArray As PointF() = New PointF(3  - 1) {}
            Dim point As New Point(0, 0)
            tfArray(0) = DirectCast(point, PointF)
            Dim point2 As New Point(bitmap2.Width, 0)
            tfArray(1) = DirectCast(point2, PointF)
            Dim point3 As New Point(0, bitmap2.Height)
            tfArray(2) = DirectCast(point3, PointF)
            Dim destPoints As PointF() = tfArray
            Using graphics As Graphics = Graphics.FromImage(image)
                graphics.Clear(Color.Transparent)
                Dim srcRect As New RectangleF(DirectCast(Point.Empty, PointF), DirectCast(bitmap2.Size, SizeF))
                graphics.DrawImage(bitmap_0, destPoints, srcRect, GraphicsUnit.Pixel, attributes)
            End Using
        End Using
        bitmap2 = Nothing
        Return image
    End Function

    Protected Overrides Sub OnMouseEnter(ByVal e As EventArgs)
        Me.struct0_0.bool_0 = True
        MyBase.OnMouseHover(e)
    End Sub

    Protected Overrides Sub OnMouseLeave(ByVal e As EventArgs)
        Dim enumerator As IEnumerator
        Me.struct0_0.bool_0 = False
        Try 
            enumerator = MyBase.TabPages.GetEnumerator
            Do While enumerator.MoveNext
                Dim current As TabPage = DirectCast(enumerator.Current, TabPage)
                If current.DisplayRectangle.Contains(Me.struct0_0.point_0) Then
                    goto Label_004B
                End If
            Loop
            goto Label_0067
        Label_004B:
            MyBase.Invalidate
        Finally
            If TypeOf enumerator Is IDisposable Then
                TryCast(enumerator,IDisposable).Dispose
            End If
        End Try
    Label_0067:
        MyBase.OnMouseHover(e)
    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
        Dim enumerator As IEnumerator
        Me.struct0_0.point_0 = e.Location
        Try 
            enumerator = MyBase.TabPages.GetEnumerator
            Do While enumerator.MoveNext
                Dim current As TabPage = DirectCast(enumerator.Current, TabPage)
                If current.DisplayRectangle.Contains(e.Location) Then
                    goto Label_004B
                End If
            Loop
            goto Label_0067
        Label_004B:
            MyBase.Invalidate
        Finally
            If TypeOf enumerator Is IDisposable Then
                TryCast(enumerator,IDisposable).Dispose
            End If
        End Try
    Label_0067:
        MyBase.OnMouseMove(e)
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim point2 As Point
        Dim format As StringFormat
        Dim image As New Bitmap(Me.Width, Me.Height)
        Dim graphics2 As Graphics = Graphics.FromImage(image)
        Try 
            Me.SelectedTab.BackColor = Color.White
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            ProjectData.ClearProjectError
        End Try
        graphics2.Clear(Color.White)
        Dim rect As New Rectangle(0, 0, (Me.ItemSize.Height + 4), Me.Height)
        graphics2.FillRectangle(New SolidBrush(Color.FromArgb(&H27, &H27, &H27)), rect)
        Dim point3 As New Point((Me.ItemSize.Height + 3), 0)
        Dim itemSize As Size = Me.ItemSize
        Dim location As New Point((itemSize.Height + 3), &H3E7)
        graphics2.DrawLine(New Pen(Color.FromArgb(&H27, &H27, &H27)), point3, location)
        Dim num2 As Integer = (Me.TabCount - 1)
        Dim index As Integer = 0
    Label_00D8:
        If (index > num2) Then
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality
            NewLateBinding.LateCall(e.Graphics, Nothing, "DrawImage", New Object() { RuntimeHelpers.GetObjectValue(image.Clone), 0, 0 }, Nothing, Nothing, Nothing, True)
            graphics2.Dispose
            image.Dispose
            graphics2 = Nothing
            Return
        End If
        If (index = Me.SelectedIndex) Then
            location = Me.GetTabRect(index).Location
            point3 = Me.GetTabRect(index).Location
            point2 = New Point((location.X - 2), (point3.Y - 2))
            itemSize = New Size((Me.GetTabRect(index).Width + 3), (Me.GetTabRect(index).Height - 1))
            Dim rectangle7 As New Rectangle(point2, itemSize)
            graphics2.FillRectangle(New SolidBrush(Color.FromArgb(&H1C, &H1C, &H1C)), rectangle7.X, rectangle7.Y, (rectangle7.Width + 1), (rectangle7.Height + 3))
            If (index <> 0) Then
                location = New Point((rectangle7.Location.X - 1), (rectangle7.Top + 1))
                point3 = New Point(rectangle7.Width, (rectangle7.Top + 1))
                graphics2.DrawLine(New Pen(Color.FromArgb(60, 60, 60)), location, point3)
            End If
            point2 = Me.GetTabRect(index).Location
            location = New Point(Me.GetTabRect(index).Width, Conversions.ToInteger(Operators.SubtractObject(point2.Y, Interaction.IIf((index = 0), 1, 0))))
            itemSize = New Size(4, Conversions.ToInteger(Operators.SubtractObject(Me.GetTabRect(index).Height, Interaction.IIf((index = 0), 1, 2))))
            Dim rectangle9 As New Rectangle(location, itemSize)
            graphics2.FillRectangle(New SolidBrush(Color.Red), rectangle9)
            Dim flag2 As Boolean = False
            Try 
                If (Not Information.IsNothing(Me.ImageList) AndAlso (Me.TabPages.Item(index).ImageIndex <> -1)) Then
                    point2 = rectangle7.Location
                    point3 = New Point((point2.X + 6), (rectangle7.Location.Y + 8))
                    graphics2.DrawImage(Me.ImageList.Images.Item(Me.TabPages.Item(index).ImageIndex), point3)
                    flag2 = True
                End If
                goto Label_085B
            Catch exception2 As Exception
                ProjectData.SetProjectError(exception2)
                ProjectData.ClearProjectError
                goto Label_085B
            Finally
                format = New StringFormat With { _
                    .LineAlignment = StringAlignment.Center, _
                    .Alignment = StringAlignment.Center _
                }
                graphics2.DrawString(Conversions.ToString(Operators.ConcatenateObject(Interaction.IIf(flag2, RuntimeHelpers.GetObjectValue(Interaction.IIf((Me.TabPages.Item(index).Text.Length >= 11), "     ", String.Empty)), String.Empty), Me.TabPages.Item(index).Text)), New Font(Me.Font.FontFamily, Me.Font.Size, FontStyle.Bold), Brushes.White, rectangle7, format)
            End Try
        End If
        location = Me.GetTabRect(index).Location
        point3 = New Point((Me.GetTabRect(index).Location.X - 2), (location.Y - 2))
        itemSize = New Size((Me.GetTabRect(index).Width + 3), (Me.GetTabRect(index).Height + 1))
        Dim layoutRectangle As New Rectangle(point3, itemSize)
        If (Me.struct0_0.bool_0 AndAlso layoutRectangle.Contains(Me.struct0_0.point_0)) Then
            graphics2.FillRectangle(New SolidBrush(Color.FromArgb(&H1C, &H1C, &H1C)), layoutRectangle.X, layoutRectangle.Y, (layoutRectangle.Width + 1), layoutRectangle.Height)
        Else
            Dim blend As New ColorBlend
            Dim blend2 As ColorBlend = blend
            blend2.Colors = New Color() { Color.FromArgb(&H33, &H33, &H33), Color.FromArgb(&H27, &H27, &H27), Color.FromArgb(&H25, &H25, &H25) }
            blend2.Positions = New Single() { 0!, 0.5!, 1! }
            blend2 = Nothing
            location = Me.GetTabRect(index).Location
            point3 = New Point((Me.GetTabRect(index).Location.X - 2), (location.Y - 1))
            itemSize = New Size((Me.GetTabRect(index).Width + 4), Me.GetTabRect(index).Height)
            Dim rectangle2 As New Rectangle(point3, itemSize)
            Dim brush As New LinearGradientBrush(rectangle2, Color.Black, Color.Black, 90!) With { _
                .InterpolationColors = blend _
            }
            graphics2.FillRectangle(brush, rectangle2)
        End If
        location = New Point((layoutRectangle.Location.X - 1), (layoutRectangle.Top + 1))
        point3 = New Point(layoutRectangle.Width, (layoutRectangle.Top + 1))
        graphics2.DrawLine(New Pen(Color.FromArgb(60, 60, 60)), location, point3)
        point2 = layoutRectangle.Location
        location = New Point((point2.X - 1), (layoutRectangle.Bottom - 1))
        point3 = layoutRectangle.Location
        Dim point4 As New Point((point3.X + layoutRectangle.Right), (layoutRectangle.Bottom - 1))
        graphics2.DrawLine(New Pen(Color.FromArgb(&H1B, &H1B, &H1B)), location, point4)
        If (Me.struct0_0.bool_0 AndAlso layoutRectangle.Contains(Me.struct0_0.point_0)) Then
            point4 = Me.GetTabRect(index).Location
            point2 = New Point(Me.GetTabRect(index).Width, point4.Y)
            itemSize = New Size(4, (Me.GetTabRect(index).Height - 2))
            Dim rectangle8 As New Rectangle(point2, itemSize)
            graphics2.FillRectangle(New SolidBrush(Color.FromArgb(&H66, &H66, &H66)), rectangle8)
        End If
        Dim expression As Boolean = False
        Try 
            If (Not Information.IsNothing(Me.ImageList) AndAlso (Me.TabPages.Item(index).ImageIndex <> -1)) Then
                point4 = layoutRectangle.Location
                point2 = layoutRectangle.Location
                location = New Point((point4.X + 6), (point2.Y + 8))
                graphics2.DrawImage(Me.method_4(DirectCast(Me.ImageList.Images.Item(Me.TabPages.Item(index).ImageIndex), Bitmap), CSng(Me.method_0)), location)
                expression = True
            End If
        Catch exception3 As Exception
            ProjectData.SetProjectError(exception3)
            ProjectData.ClearProjectError
        Finally
            format = New StringFormat With { _
                .LineAlignment = StringAlignment.Center, _
                .Alignment = StringAlignment.Center _
            }
            graphics2.DrawString(Conversions.ToString(Operators.ConcatenateObject(Interaction.IIf(expression, RuntimeHelpers.GetObjectValue(Interaction.IIf((Me.TabPages.Item(index).Text.Length >= 11), "      ", String.Empty)), String.Empty), Me.TabPages.Item(index).Text)), Me.Font, Me.method_3(Color.FromArgb(&H99, &H99, &H99)), layoutRectangle, format)
        End Try
    Label_085B:
        index += 1
        goto Label_00D8
    End Sub


    ' Fields
    Private int_0 As Integer
    Private struct0_0 As Struct0

    ' Nested Types
    <StructLayout(LayoutKind.Sequential)> _
    Private Structure Struct0
        Public bool_0 As Boolean
        Public point_0 As Point
    End Structure
End Class


