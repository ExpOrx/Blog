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
    public class Stealer : Form
    {
        [AccessedThroughProperty("exitbtn")]
        private Button _exitbtn;
        [AccessedThroughProperty("Label7")]
        private Label _Label7;
        [AccessedThroughProperty("PictureBox1")]
        private PictureBox _PictureBox1;
        [AccessedThroughProperty("RichTextBox1")]
        private RichTextBox _RichTextBox1;
        private IContainer icontainer_0;
        [AccessedThroughProperty("Timer1")]
        private Timer timer_0;

        public Stealer()
        {
            Class1.QaIGh5M7cuigS();
            base.Load += new EventHandler(this.Stealer_Load);
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

        private void exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.icontainer_0 = new System.ComponentModel.Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(Stealer));
            this.PictureBox1 = new PictureBox();
            this.Label7 = new Label();
            this.exitbtn = new Button();
            this.Timer1 = new Timer(this.icontainer_0);
            this.RichTextBox1 = new RichTextBox();
            ((ISupportInitialize) this.PictureBox1).BeginInit();
            this.SuspendLayout();
            this.PictureBox1.Image = Class5.smethod_49();
            Point point = new Point(11, 0xf1);
            this.PictureBox1.Location = point;
            this.PictureBox1.Name = "PictureBox1";
            Size size = new Size(0x10, 0x10);
            this.PictureBox1.Size = size;
            this.PictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            this.PictureBox1.TabIndex = 0x16;
            this.PictureBox1.TabStop = false;
            this.Label7.AutoSize = true;
            point = new Point(0x21, 0xf2);
            this.Label7.Location = point;
            this.Label7.Name = "Label7";
            size = new Size(0x49, 13);
            this.Label7.Size = size;
            this.Label7.TabIndex = 0x15;
            this.Label7.Text = "Please wait...";
            point = new Point(0xfd, 0xec);
            this.exitbtn.Location = point;
            this.exitbtn.Name = "exitbtn";
            size = new Size(0x4e, 0x18);
            this.exitbtn.Size = size;
            this.exitbtn.TabIndex = 20;
            this.exitbtn.Text = "&Close";
            this.exitbtn.UseVisualStyleBackColor = true;
            point = new Point(12, 12);
            this.RichTextBox1.Location = point;
            this.RichTextBox1.Name = "RichTextBox1";
            size = new Size(0x13f, 0xda);
            this.RichTextBox1.Size = size;
            this.RichTextBox1.TabIndex = 0x18;
            this.RichTextBox1.Text = "";
            SizeF ef = new SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            size = new Size(0x157, 0x110);
            this.ClientSize = size;
            this.Controls.Add(this.RichTextBox1);
            this.Controls.Add(this.PictureBox1);
            this.Controls.Add(this.Label7);
            this.Controls.Add(this.exitbtn);
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.Icon = (Icon) manager.GetObject("$this.Icon");
            this.Name = "Stealer";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Stealer";
            ((ISupportInitialize) this.PictureBox1).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void Stealer_Load(object sender, EventArgs e)
        {
            this.Timer1.Start();
            this.PictureBox1.Visible = true;
            this.Label7.Visible = true;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (this.RichTextBox1.Text == "")
            {
                this.RichTextBox1.Text = Class2.Class4_0.method_6().RichTextBox2.Text;
            }
            else
            {
                this.Label7.Visible = false;
                this.PictureBox1.Visible = false;
                this.Timer1.Stop();
            }
        }

        internal virtual Button exitbtn
        {
            get
            {
                return this._exitbtn;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.exitbtn_Click);
                if (this._exitbtn != null)
                {
                    this._exitbtn.Click -= handler;
                }
                this._exitbtn = value;
                if (this._exitbtn != null)
                {
                    this._exitbtn.Click += handler;
                }
            }
        }

        internal virtual Label Label7
        {
            get
            {
                return this._Label7;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label7 = value;
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

        internal virtual RichTextBox RichTextBox1
        {
            get
            {
                return this._RichTextBox1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._RichTextBox1 = value;
            }
        }

        internal virtual Timer Timer1
        {
            get
            {
                return this.timer_0;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.Timer1_Tick);
                if (this.timer_0 != null)
                {
                    this.timer_0.Tick -= handler;
                }
                this.timer_0 = value;
                if (this.timer_0 != null)
                {
                    this.timer_0.Tick += handler;
                }
            }
        }
    }
}

