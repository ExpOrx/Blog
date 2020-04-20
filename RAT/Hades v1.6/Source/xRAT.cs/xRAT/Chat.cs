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
    public class Chat : Form
    {
        [AccessedThroughProperty("Button1")]
        private Button _Button1;
        [AccessedThroughProperty("Label1")]
        private Label _Label1;
        [AccessedThroughProperty("Panel1")]
        private Panel _Panel1;
        [AccessedThroughProperty("PictureBox1")]
        private PictureBox _PictureBox1;
        [AccessedThroughProperty("PictureBox2")]
        private PictureBox _PictureBox2;
        [AccessedThroughProperty("PictureBox3")]
        private PictureBox _PictureBox3;
        [AccessedThroughProperty("PictureBox4")]
        private PictureBox _PictureBox4;
        [AccessedThroughProperty("PictureBox5")]
        private PictureBox _PictureBox5;
        [AccessedThroughProperty("PictureBox6")]
        private PictureBox _PictureBox6;
        [AccessedThroughProperty("RadioButton1")]
        private RadioButton _RadioButton1;
        [AccessedThroughProperty("RadioButton2")]
        private RadioButton _RadioButton2;
        [AccessedThroughProperty("RadioButton3")]
        private RadioButton _RadioButton3;
        [AccessedThroughProperty("RadioButton4")]
        private RadioButton _RadioButton4;
        [AccessedThroughProperty("RadioButton5")]
        private RadioButton _RadioButton5;
        [AccessedThroughProperty("RadioButton6")]
        private RadioButton _RadioButton6;
        [AccessedThroughProperty("TextBox1")]
        private TextBox _TextBox1;
        [AccessedThroughProperty("TextBox2")]
        private TextBox _TextBox2;
        [AccessedThroughProperty("TextBox3")]
        private TextBox _TextBox3;
        private IContainer icontainer_0;

        public Chat()
        {
            Class1.QaIGh5M7cuigS();
            base.Load += new EventHandler(this.Chat_Load);
            this.InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            bool flag1 = this.RadioButton1.Checked;
            bool flag2 = this.RadioButton2.Checked;
            bool flag3 = this.RadioButton3.Checked;
            bool flag4 = this.RadioButton4.Checked;
            bool flag5 = this.RadioButton5.Checked;
            bool flag6 = this.RadioButton6.Checked;
            if (this.TextBox3.Text != "")
            {
                if (this.TextBox1.Text.Trim() == "")
                {
                    this.TextBox1.Text = "Master";
                }
                TextBox box = this.TextBox2;
                box.Text = box.Text + "\r\nYou: " + this.TextBox3.Text;
                Class2.Class4_0.method_6().SendToSelected("CHAT|" + this.TextBox1.Text + "|" + this.TextBox3.Text);
            }
        }

        private void Chat_Load(object sender, EventArgs e)
        {
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
            ComponentResourceManager manager = new ComponentResourceManager(typeof(Chat));
            this.TextBox1 = new TextBox();
            this.Label1 = new Label();
            this.TextBox2 = new TextBox();
            this.Button1 = new Button();
            this.TextBox3 = new TextBox();
            this.Panel1 = new Panel();
            this.RadioButton1 = new RadioButton();
            this.RadioButton2 = new RadioButton();
            this.RadioButton3 = new RadioButton();
            this.RadioButton4 = new RadioButton();
            this.RadioButton5 = new RadioButton();
            this.RadioButton6 = new RadioButton();
            this.PictureBox4 = new PictureBox();
            this.PictureBox5 = new PictureBox();
            this.PictureBox6 = new PictureBox();
            this.PictureBox3 = new PictureBox();
            this.PictureBox2 = new PictureBox();
            this.PictureBox1 = new PictureBox();
            this.Panel1.SuspendLayout();
            ((ISupportInitialize) this.PictureBox4).BeginInit();
            ((ISupportInitialize) this.PictureBox5).BeginInit();
            ((ISupportInitialize) this.PictureBox6).BeginInit();
            ((ISupportInitialize) this.PictureBox3).BeginInit();
            ((ISupportInitialize) this.PictureBox2).BeginInit();
            ((ISupportInitialize) this.PictureBox1).BeginInit();
            this.SuspendLayout();
            Point point = new Point(0x63, 6);
            this.TextBox1.Location = point;
            this.TextBox1.Name = "TextBox1";
            Size size = new Size(0xcf, 0x15);
            this.TextBox1.Size = size;
            this.TextBox1.TabIndex = 0;
            this.Label1.AutoSize = true;
            point = new Point(12, 9);
            this.Label1.Location = point;
            this.Label1.Name = "Label1";
            size = new Size(0x51, 13);
            this.Label1.Size = size;
            this.Label1.TabIndex = 4;
            this.Label1.Text = "Your Nickname:";
            this.TextBox2.BackColor = Color.White;
            point = new Point(12, 0x20);
            this.TextBox2.Location = point;
            this.TextBox2.Multiline = true;
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.ReadOnly = true;
            this.TextBox2.ScrollBars = ScrollBars.Vertical;
            size = new Size(0xf3, 0xbd);
            this.TextBox2.Size = size;
            this.TextBox2.TabIndex = 3;
            point = new Point(0x102, 0xca);
            this.Button1.Location = point;
            this.Button1.Name = "Button1";
            size = new Size(0x37, 0x30);
            this.Button1.Size = size;
            this.Button1.TabIndex = 2;
            this.Button1.Text = "Send";
            this.Button1.UseVisualStyleBackColor = true;
            point = new Point(12, 0xe2);
            this.TextBox3.Location = point;
            this.TextBox3.Name = "TextBox3";
            size = new Size(0xf3, 0x15);
            this.TextBox3.Size = size;
            this.TextBox3.TabIndex = 1;
            this.Panel1.Controls.Add(this.RadioButton6);
            this.Panel1.Controls.Add(this.RadioButton5);
            this.Panel1.Controls.Add(this.RadioButton4);
            this.Panel1.Controls.Add(this.RadioButton3);
            this.Panel1.Controls.Add(this.RadioButton2);
            this.Panel1.Controls.Add(this.RadioButton1);
            this.Panel1.Controls.Add(this.PictureBox4);
            this.Panel1.Controls.Add(this.PictureBox5);
            this.Panel1.Controls.Add(this.PictureBox6);
            this.Panel1.Controls.Add(this.PictureBox3);
            this.Panel1.Controls.Add(this.PictureBox2);
            this.Panel1.Controls.Add(this.PictureBox1);
            point = new Point(0x105, 0x20);
            this.Panel1.Location = point;
            this.Panel1.Name = "Panel1";
            size = new Size(0x2d, 0xa4);
            this.Panel1.Size = size;
            this.Panel1.TabIndex = 5;
            this.RadioButton1.AutoSize = true;
            this.RadioButton1.Checked = true;
            point = new Point(3, 7);
            this.RadioButton1.Location = point;
            this.RadioButton1.Name = "RadioButton1";
            size = new Size(14, 13);
            this.RadioButton1.Size = size;
            this.RadioButton1.TabIndex = 12;
            this.RadioButton1.TabStop = true;
            this.RadioButton1.UseVisualStyleBackColor = true;
            this.RadioButton2.AutoSize = true;
            point = new Point(3, 0x21);
            this.RadioButton2.Location = point;
            this.RadioButton2.Name = "RadioButton2";
            size = new Size(14, 13);
            this.RadioButton2.Size = size;
            this.RadioButton2.TabIndex = 13;
            this.RadioButton2.TabStop = true;
            this.RadioButton2.UseVisualStyleBackColor = true;
            this.RadioButton3.AutoSize = true;
            point = new Point(3, 60);
            this.RadioButton3.Location = point;
            this.RadioButton3.Name = "RadioButton3";
            size = new Size(14, 13);
            this.RadioButton3.Size = size;
            this.RadioButton3.TabIndex = 13;
            this.RadioButton3.TabStop = true;
            this.RadioButton3.UseVisualStyleBackColor = true;
            this.RadioButton4.AutoSize = true;
            point = new Point(3, 0x57);
            this.RadioButton4.Location = point;
            this.RadioButton4.Name = "RadioButton4";
            size = new Size(14, 13);
            this.RadioButton4.Size = size;
            this.RadioButton4.TabIndex = 13;
            this.RadioButton4.TabStop = true;
            this.RadioButton4.UseVisualStyleBackColor = true;
            this.RadioButton5.AutoSize = true;
            point = new Point(3, 0x71);
            this.RadioButton5.Location = point;
            this.RadioButton5.Name = "RadioButton5";
            size = new Size(14, 13);
            this.RadioButton5.Size = size;
            this.RadioButton5.TabIndex = 13;
            this.RadioButton5.TabStop = true;
            this.RadioButton5.UseVisualStyleBackColor = true;
            this.RadioButton6.AutoSize = true;
            point = new Point(3, 0x8d);
            this.RadioButton6.Location = point;
            this.RadioButton6.Name = "RadioButton6";
            size = new Size(14, 13);
            this.RadioButton6.Size = size;
            this.RadioButton6.TabIndex = 14;
            this.RadioButton6.TabStop = true;
            this.RadioButton6.UseVisualStyleBackColor = true;
            this.PictureBox4.BorderStyle = BorderStyle.FixedSingle;
            this.PictureBox4.Image = Class5.smethod_28();
            point = new Point(0x13, 0x87);
            this.PictureBox4.Location = point;
            this.PictureBox4.Name = "PictureBox4";
            size = new Size(0x18, 0x18);
            this.PictureBox4.Size = size;
            this.PictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            this.PictureBox4.TabIndex = 11;
            this.PictureBox4.TabStop = false;
            this.PictureBox5.BorderStyle = BorderStyle.FixedSingle;
            this.PictureBox5.Image = Class5.smethod_40();
            point = new Point(0x13, 0x6c);
            this.PictureBox5.Location = point;
            this.PictureBox5.Name = "PictureBox5";
            size = new Size(0x18, 0x18);
            this.PictureBox5.Size = size;
            this.PictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            this.PictureBox5.TabIndex = 10;
            this.PictureBox5.TabStop = false;
            this.PictureBox6.BorderStyle = BorderStyle.FixedSingle;
            this.PictureBox6.Image = (Image) manager.GetObject("PictureBox6.Image");
            point = new Point(0x13, 0x52);
            this.PictureBox6.Location = point;
            this.PictureBox6.Name = "PictureBox6";
            size = new Size(0x18, 0x18);
            this.PictureBox6.Size = size;
            this.PictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
            this.PictureBox6.TabIndex = 9;
            this.PictureBox6.TabStop = false;
            this.PictureBox3.BorderStyle = BorderStyle.FixedSingle;
            this.PictureBox3.Image = Class5.smethod_25();
            point = new Point(0x13, 0x37);
            this.PictureBox3.Location = point;
            this.PictureBox3.Name = "PictureBox3";
            size = new Size(0x18, 0x18);
            this.PictureBox3.Size = size;
            this.PictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            this.PictureBox3.TabIndex = 8;
            this.PictureBox3.TabStop = false;
            this.PictureBox2.BorderStyle = BorderStyle.FixedSingle;
            this.PictureBox2.Image = Class5.smethod_31();
            point = new Point(0x13, 0x1c);
            this.PictureBox2.Location = point;
            this.PictureBox2.Name = "PictureBox2";
            size = new Size(0x18, 0x18);
            this.PictureBox2.Size = size;
            this.PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            this.PictureBox2.TabIndex = 7;
            this.PictureBox2.TabStop = false;
            this.PictureBox1.BorderStyle = BorderStyle.FixedSingle;
            this.PictureBox1.Image = Class5.smethod_82();
            point = new Point(0x13, 2);
            this.PictureBox1.Location = point;
            this.PictureBox1.Name = "PictureBox1";
            size = new Size(0x18, 0x18);
            this.PictureBox1.Size = size;
            this.PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.PictureBox1.TabIndex = 6;
            this.PictureBox1.TabStop = false;
            SizeF ef = new SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = AutoScaleMode.Font;
            size = new Size(0x13a, 0x106);
            this.ClientSize = size;
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.TextBox3);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.TextBox2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.TextBox1);
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.Icon = (Icon) manager.GetObject("$this.Icon");
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Chat";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Chat";
            this.TopMost = true;
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            ((ISupportInitialize) this.PictureBox4).EndInit();
            ((ISupportInitialize) this.PictureBox5).EndInit();
            ((ISupportInitialize) this.PictureBox6).EndInit();
            ((ISupportInitialize) this.PictureBox3).EndInit();
            ((ISupportInitialize) this.PictureBox2).EndInit();
            ((ISupportInitialize) this.PictureBox1).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {
        }

        private void PictureBox5_Click(object sender, EventArgs e)
        {
        }

        private void PictureBox6_Click(object sender, EventArgs e)
        {
        }

        internal virtual Button Button1
        {
            get
            {
                return this._Button1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.Button1_Click);
                if (this._Button1 != null)
                {
                    this._Button1.Click -= handler;
                }
                this._Button1 = value;
                if (this._Button1 != null)
                {
                    this._Button1.Click += handler;
                }
            }
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

        internal virtual Panel Panel1
        {
            get
            {
                return this._Panel1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Panel1 = value;
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

        internal virtual PictureBox PictureBox2
        {
            get
            {
                return this._PictureBox2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._PictureBox2 = value;
            }
        }

        internal virtual PictureBox PictureBox3
        {
            get
            {
                return this._PictureBox3;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._PictureBox3 = value;
            }
        }

        internal virtual PictureBox PictureBox4
        {
            get
            {
                return this._PictureBox4;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.PictureBox4_Click);
                if (this._PictureBox4 != null)
                {
                    this._PictureBox4.Click -= handler;
                }
                this._PictureBox4 = value;
                if (this._PictureBox4 != null)
                {
                    this._PictureBox4.Click += handler;
                }
            }
        }

        internal virtual PictureBox PictureBox5
        {
            get
            {
                return this._PictureBox5;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.PictureBox5_Click);
                if (this._PictureBox5 != null)
                {
                    this._PictureBox5.Click -= handler;
                }
                this._PictureBox5 = value;
                if (this._PictureBox5 != null)
                {
                    this._PictureBox5.Click += handler;
                }
            }
        }

        internal virtual PictureBox PictureBox6
        {
            get
            {
                return this._PictureBox6;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.PictureBox6_Click);
                if (this._PictureBox6 != null)
                {
                    this._PictureBox6.Click -= handler;
                }
                this._PictureBox6 = value;
                if (this._PictureBox6 != null)
                {
                    this._PictureBox6.Click += handler;
                }
            }
        }

        internal virtual RadioButton RadioButton1
        {
            get
            {
                return this._RadioButton1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._RadioButton1 = value;
            }
        }

        internal virtual RadioButton RadioButton2
        {
            get
            {
                return this._RadioButton2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._RadioButton2 = value;
            }
        }

        internal virtual RadioButton RadioButton3
        {
            get
            {
                return this._RadioButton3;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._RadioButton3 = value;
            }
        }

        internal virtual RadioButton RadioButton4
        {
            get
            {
                return this._RadioButton4;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._RadioButton4 = value;
            }
        }

        internal virtual RadioButton RadioButton5
        {
            get
            {
                return this._RadioButton5;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._RadioButton5 = value;
            }
        }

        internal virtual RadioButton RadioButton6
        {
            get
            {
                return this._RadioButton6;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._RadioButton6 = value;
            }
        }

        internal virtual TextBox TextBox1
        {
            get
            {
                return this._TextBox1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._TextBox1 = value;
            }
        }

        internal virtual TextBox TextBox2
        {
            get
            {
                return this._TextBox2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._TextBox2 = value;
            }
        }

        internal virtual TextBox TextBox3
        {
            get
            {
                return this._TextBox3;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._TextBox3 = value;
            }
        }
    }
}

