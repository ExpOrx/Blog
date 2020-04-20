namespace xRAT
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    public class Win8Progressbar : ProgressBar
    {
        public Win8Progressbar()
        {
            Class1.QaIGh5M7cuigS();
            base.Paint += new PaintEventHandler(this.Win8Progressbar_Paint);
            base.SetStyle(ControlStyles.UserPaint, true);
            base.SetStyle(ControlStyles.DoubleBuffer, true);
            base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        private void Win8Progressbar_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            int height = base.ClientRectangle.Height;
            int width = base.ClientRectangle.Width;
            int y = base.ClientRectangle.Height;
            int num4 = base.Maximum - base.Minimum;
            int num5 = (int) Math.Round((double) ((((double) width) / ((double) num4)) * this.Value));
            Color color = Color.FromArgb(0xf4, 0xf4, 0xf4);
            Color color2 = Color.FromArgb(0xde, 0xde, 0xde);
            Color color3 = Color.FromArgb(80, 0xcf, 0x66);
            Color color4 = Color.FromArgb(0x15, 0xcb, 0x34);
            Point point = new Point(0, 0);
            Point point2 = new Point(0, height);
            LinearGradientBrush brush = new LinearGradientBrush(point, point2, color, color2);
            point2 = new Point(0, 0);
            point = new Point(0, y);
            LinearGradientBrush brush2 = new LinearGradientBrush(point2, point, color3, color4);
            e.Graphics.FillRectangle(brush, 0, 2, width, height - 4);
            e.Graphics.DrawRectangle(Pens.Black, 0, 0, width - 1, height - 1);
            if (base.Value == base.Maximum)
            {
                e.Graphics.FillRectangle(brush2, 0, 0, num5 - 1, y - 1);
            }
            else
            {
                e.Graphics.FillRectangle(brush2, 0, 0, num5, y - 1);
            }
        }
    }
}

