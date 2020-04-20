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
    public class notifyzone : Form
    {
        [AccessedThroughProperty("Label1")]
        private Label _Label1;
        [AccessedThroughProperty("PictureBox1")]
        private PictureBox _PictureBox1;
        private IContainer icontainer_0;

        public notifyzone()
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
            ComponentResourceManager manager = new ComponentResourceManager(typeof(notifyzone));
            this.PictureBox1 = new PictureBox();
            this.Label1 = new Label();
            ((ISupportInitialize) this.PictureBox1).BeginInit();
            this.SuspendLayout();
            this.PictureBox1.BackColor = Color.Transparent;
            this.PictureBox1.Image = Class5.smethod_59();
            Point point = new Point(12, 12);
            this.PictureBox1.Location = point;
            this.PictureBox1.Name = "PictureBox1";
            Size size = new Size(0x22, 0x23);
            this.PictureBox1.Size = size;
            this.PictureBox1.TabIndex = 0;
            this.PictureBox1.TabStop = false;
            this.Label1.AutoSize = true;
            this.Label1.BackColor = Color.Transparent;
            this.Label1.Font = new Font("Tahoma", 14.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.Label1.ForeColor = SystemColors.ActiveCaptionText;
            point = new Point(0x34, 0x10);
            this.Label1.Location = point;
            this.Label1.Name = "Label1";
            size = new Size(0xde, 0x17);
            this.Label1.Size = size;
            this.Label1.TabIndex = 1;
            this.Label1.Text = "New User Connected !";
            SizeF ef = new SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackgroundImage = Class5.smethod_29();
            size = new Size(0x11e, 0x3d);
            this.ClientSize = size;
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.PictureBox1);
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.Icon = (Icon) manager.GetObject("$this.Icon");
            point = new Point(250, 250);
            this.Location = point;
            this.Name = "notifyzone";
            this.StartPosition = FormStartPosition.Manual;
            this.Text = "Had\x00e8s R.A.T  -  New User Connected !";
            ((ISupportInitialize) this.PictureBox1).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        internal virtual Label Label1
        {
            get
            {
                return this._Label1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label1 = value;
            }
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

