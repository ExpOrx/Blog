using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

internal class Control0 : TabControl
{
    private int int_0;
    private Struct0 struct0_0;

    public Control0()
    {
        Class1.QaIGh5M7cuigS();
        this.struct0_0 = new Struct0();
        this.int_0 = 50;
        this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
        this.DoubleBuffered = true;
        this.SizeMode = TabSizeMode.Fixed;
        Size size = new Size(0x2c, 0x88);
        this.ItemSize = size;
    }

    protected override void CreateHandle()
    {
        base.CreateHandle();
        base.DoubleBuffered = true;
        this.SizeMode = TabSizeMode.Fixed;
        this.Alignment = TabAlignment.Left;
        this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
    }

    public int method_0()
    {
        return this.int_0;
    }

    public void method_1(int int_1)
    {
        if (Information.IsNothing(int_1))
        {
            int_1 = 50;
        }
        if (int_1 < 0)
        {
            int_1 = 0;
        }
        if (int_1 > 100)
        {
            int_1 = 100;
        }
        this.int_0 = int_1;
    }

    private Pen method_2(Color color_0)
    {
        return new Pen(color_0);
    }

    private Brush method_3(Color color_0)
    {
        return new SolidBrush(color_0);
    }

    private Image method_4(Bitmap bitmap_0, float float_0)
    {
        Bitmap image = new Bitmap(bitmap_0.Width, bitmap_0.Height, PixelFormat.Format32bppArgb);
        Bitmap bitmap2 = bitmap_0;
        float_0 = Math.Min(float_0, 100f);
        using (ImageAttributes attributes = new ImageAttributes())
        {
            ColorMatrix newColorMatrix = new ColorMatrix {
                Matrix33 = float_0 / 100f
            };
            attributes.SetColorMatrix(newColorMatrix);
            PointF[] tfArray = new PointF[3];
            Point point = new Point(0, 0);
            tfArray[0] = (PointF) point;
            Point point2 = new Point(bitmap2.Width, 0);
            tfArray[1] = (PointF) point2;
            Point point3 = new Point(0, bitmap2.Height);
            tfArray[2] = (PointF) point3;
            PointF[] destPoints = tfArray;
            using (Graphics graphics = Graphics.FromImage(image))
            {
                graphics.Clear(Color.Transparent);
                RectangleF srcRect = new RectangleF((PointF) Point.Empty, (SizeF) bitmap2.Size);
                graphics.DrawImage(bitmap_0, destPoints, srcRect, GraphicsUnit.Pixel, attributes);
            }
        }
        bitmap2 = null;
        return image;
    }

    protected override void OnMouseEnter(EventArgs e)
    {
        this.struct0_0.bool_0 = true;
        base.OnMouseHover(e);
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        IEnumerator enumerator;
        this.struct0_0.bool_0 = false;
        try
        {
            enumerator = base.TabPages.GetEnumerator();
            while (enumerator.MoveNext())
            {
                TabPage current = (TabPage) enumerator.Current;
                if (current.DisplayRectangle.Contains(this.struct0_0.point_0))
                {
                    goto Label_004B;
                }
            }
            goto Label_0067;
        Label_004B:
            base.Invalidate();
        }
        finally
        {
            if (enumerator is IDisposable)
            {
                (enumerator as IDisposable).Dispose();
            }
        }
    Label_0067:
        base.OnMouseHover(e);
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        IEnumerator enumerator;
        this.struct0_0.point_0 = e.Location;
        try
        {
            enumerator = base.TabPages.GetEnumerator();
            while (enumerator.MoveNext())
            {
                TabPage current = (TabPage) enumerator.Current;
                if (current.DisplayRectangle.Contains(e.Location))
                {
                    goto Label_004B;
                }
            }
            goto Label_0067;
        Label_004B:
            base.Invalidate();
        }
        finally
        {
            if (enumerator is IDisposable)
            {
                (enumerator as IDisposable).Dispose();
            }
        }
    Label_0067:
        base.OnMouseMove(e);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        Point point2;
        StringFormat format;
        Bitmap image = new Bitmap(this.Width, this.Height);
        Graphics graphics2 = Graphics.FromImage(image);
        try
        {
            this.SelectedTab.BackColor = Color.White;
        }
        catch (Exception exception1)
        {
            ProjectData.SetProjectError(exception1);
            ProjectData.ClearProjectError();
        }
        graphics2.Clear(Color.White);
        Rectangle rect = new Rectangle(0, 0, this.ItemSize.Height + 4, this.Height);
        graphics2.FillRectangle(new SolidBrush(Color.FromArgb(0x27, 0x27, 0x27)), rect);
        Point point3 = new Point(this.ItemSize.Height + 3, 0);
        Size itemSize = this.ItemSize;
        Point location = new Point(itemSize.Height + 3, 0x3e7);
        graphics2.DrawLine(new Pen(Color.FromArgb(0x27, 0x27, 0x27)), point3, location);
        int num2 = this.TabCount - 1;
        int index = 0;
    Label_00D8:
        if (index > num2)
        {
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            NewLateBinding.LateCall(e.Graphics, null, "DrawImage", new object[] { RuntimeHelpers.GetObjectValue(image.Clone()), 0, 0 }, null, null, null, true);
            graphics2.Dispose();
            image.Dispose();
            graphics2 = null;
            return;
        }
        if (index == this.SelectedIndex)
        {
            location = this.GetTabRect(index).Location;
            point3 = this.GetTabRect(index).Location;
            point2 = new Point(location.X - 2, point3.Y - 2);
            itemSize = new Size(this.GetTabRect(index).Width + 3, this.GetTabRect(index).Height - 1);
            Rectangle rectangle7 = new Rectangle(point2, itemSize);
            graphics2.FillRectangle(new SolidBrush(Color.FromArgb(0x1c, 0x1c, 0x1c)), rectangle7.X, rectangle7.Y, rectangle7.Width + 1, rectangle7.Height + 3);
            if (index != 0)
            {
                location = new Point(rectangle7.Location.X - 1, rectangle7.Top + 1);
                point3 = new Point(rectangle7.Width, rectangle7.Top + 1);
                graphics2.DrawLine(new Pen(Color.FromArgb(60, 60, 60)), location, point3);
            }
            point2 = this.GetTabRect(index).Location;
            location = new Point(this.GetTabRect(index).Width, Conversions.ToInteger(Operators.SubtractObject(point2.Y, Interaction.IIf(index == 0, 1, 0))));
            itemSize = new Size(4, Conversions.ToInteger(Operators.SubtractObject(this.GetTabRect(index).Height, Interaction.IIf(index == 0, 1, 2))));
            Rectangle rectangle9 = new Rectangle(location, itemSize);
            graphics2.FillRectangle(new SolidBrush(Color.Red), rectangle9);
            bool flag2 = false;
            try
            {
                if (!Information.IsNothing(this.ImageList) && (this.TabPages[index].ImageIndex != -1))
                {
                    point2 = rectangle7.Location;
                    point3 = new Point(point2.X + 6, rectangle7.Location.Y + 8);
                    graphics2.DrawImage(this.ImageList.Images[this.TabPages[index].ImageIndex], point3);
                    flag2 = true;
                }
                goto Label_085B;
            }
            catch (Exception exception2)
            {
                ProjectData.SetProjectError(exception2);
                ProjectData.ClearProjectError();
                goto Label_085B;
            }
            finally
            {
                format = new StringFormat {
                    LineAlignment = StringAlignment.Center,
                    Alignment = StringAlignment.Center
                };
                graphics2.DrawString(Conversions.ToString(Operators.ConcatenateObject(Interaction.IIf(flag2, RuntimeHelpers.GetObjectValue(Interaction.IIf(this.TabPages[index].Text.Length >= 11, "     ", string.Empty)), string.Empty), this.TabPages[index].Text)), new Font(this.Font.FontFamily, this.Font.Size, FontStyle.Bold), Brushes.White, rectangle7, format);
            }
        }
        location = this.GetTabRect(index).Location;
        point3 = new Point(this.GetTabRect(index).Location.X - 2, location.Y - 2);
        itemSize = new Size(this.GetTabRect(index).Width + 3, this.GetTabRect(index).Height + 1);
        Rectangle layoutRectangle = new Rectangle(point3, itemSize);
        if (this.struct0_0.bool_0 && layoutRectangle.Contains(this.struct0_0.point_0))
        {
            graphics2.FillRectangle(new SolidBrush(Color.FromArgb(0x1c, 0x1c, 0x1c)), layoutRectangle.X, layoutRectangle.Y, layoutRectangle.Width + 1, layoutRectangle.Height);
        }
        else
        {
            ColorBlend blend = new ColorBlend();
            ColorBlend blend2 = blend;
            blend2.Colors = new Color[] { Color.FromArgb(0x33, 0x33, 0x33), Color.FromArgb(0x27, 0x27, 0x27), Color.FromArgb(0x25, 0x25, 0x25) };
            blend2.Positions = new float[] { 0f, 0.5f, 1f };
            blend2 = null;
            location = this.GetTabRect(index).Location;
            point3 = new Point(this.GetTabRect(index).Location.X - 2, location.Y - 1);
            itemSize = new Size(this.GetTabRect(index).Width + 4, this.GetTabRect(index).Height);
            Rectangle rectangle2 = new Rectangle(point3, itemSize);
            LinearGradientBrush brush = new LinearGradientBrush(rectangle2, Color.Black, Color.Black, 90f) {
                InterpolationColors = blend
            };
            graphics2.FillRectangle(brush, rectangle2);
        }
        location = new Point(layoutRectangle.Location.X - 1, layoutRectangle.Top + 1);
        point3 = new Point(layoutRectangle.Width, layoutRectangle.Top + 1);
        graphics2.DrawLine(new Pen(Color.FromArgb(60, 60, 60)), location, point3);
        point2 = layoutRectangle.Location;
        location = new Point(point2.X - 1, layoutRectangle.Bottom - 1);
        point3 = layoutRectangle.Location;
        Point point4 = new Point(point3.X + layoutRectangle.Right, layoutRectangle.Bottom - 1);
        graphics2.DrawLine(new Pen(Color.FromArgb(0x1b, 0x1b, 0x1b)), location, point4);
        if (this.struct0_0.bool_0 && layoutRectangle.Contains(this.struct0_0.point_0))
        {
            point4 = this.GetTabRect(index).Location;
            point2 = new Point(this.GetTabRect(index).Width, point4.Y);
            itemSize = new Size(4, this.GetTabRect(index).Height - 2);
            Rectangle rectangle8 = new Rectangle(point2, itemSize);
            graphics2.FillRectangle(new SolidBrush(Color.FromArgb(0x66, 0x66, 0x66)), rectangle8);
        }
        bool expression = false;
        try
        {
            if (!Information.IsNothing(this.ImageList) && (this.TabPages[index].ImageIndex != -1))
            {
                point4 = layoutRectangle.Location;
                point2 = layoutRectangle.Location;
                location = new Point(point4.X + 6, point2.Y + 8);
                graphics2.DrawImage(this.method_4((Bitmap) this.ImageList.Images[this.TabPages[index].ImageIndex], (float) this.method_0()), location);
                expression = true;
            }
        }
        catch (Exception exception3)
        {
            ProjectData.SetProjectError(exception3);
            ProjectData.ClearProjectError();
        }
        finally
        {
            format = new StringFormat {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Center
            };
            graphics2.DrawString(Conversions.ToString(Operators.ConcatenateObject(Interaction.IIf(expression, RuntimeHelpers.GetObjectValue(Interaction.IIf(this.TabPages[index].Text.Length >= 11, "      ", string.Empty)), string.Empty), this.TabPages[index].Text)), this.Font, this.method_3(Color.FromArgb(0x99, 0x99, 0x99)), layoutRectangle, format);
        }
    Label_085B:
        index++;
        goto Label_00D8;
    }

    [StructLayout(LayoutKind.Sequential)]
    private struct Struct0
    {
        public bool bool_0;
        public Point point_0;
    }
}

