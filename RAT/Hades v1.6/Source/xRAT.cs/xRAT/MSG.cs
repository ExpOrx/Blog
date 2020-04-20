namespace xRAT
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    [DesignerGenerated]
    public class MSG : Form
    {
        [AccessedThroughProperty("Button1")]
        private Button _Button1;
        [AccessedThroughProperty("Button2")]
        private Button _Button2;
        [AccessedThroughProperty("GroupBox1")]
        private GroupBox _GroupBox1;
        [AccessedThroughProperty("GroupBox2")]
        private GroupBox _GroupBox2;
        [AccessedThroughProperty("PictureBox1")]
        private PictureBox _PictureBox1;
        [AccessedThroughProperty("PictureBox2")]
        private PictureBox _PictureBox2;
        [AccessedThroughProperty("PictureBox3")]
        private PictureBox _PictureBox3;
        [AccessedThroughProperty("PictureBox4")]
        private PictureBox _PictureBox4;
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
        [AccessedThroughProperty("RadioButton7")]
        private RadioButton _RadioButton7;
        [AccessedThroughProperty("RadioButton8")]
        private RadioButton _RadioButton8;
        [AccessedThroughProperty("TextBox1")]
        private TextBox _TextBox1;
        [AccessedThroughProperty("TextBox2")]
        private TextBox _TextBox2;
        private IContainer icontainer_0;
        private int int_0;
        private int int_1;

        public MSG()
        {
            Class1.QaIGh5M7cuigS();
            base.Load += new EventHandler(this.MSG_Load);
            this.InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.MESSAGEBOX(Conversions.ToString(this._TEXT), Conversions.ToString(this._TITLE), Conversions.ToInteger(this._STYLE), Conversions.ToInteger(this._BUTTON));
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
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
            ComponentResourceManager manager = new ComponentResourceManager(typeof(xRAT.MSG));
            this.TextBox1 = new TextBox();
            this.TextBox2 = new TextBox();
            this.RadioButton1 = new RadioButton();
            this.RadioButton2 = new RadioButton();
            this.RadioButton3 = new RadioButton();
            this.RadioButton5 = new RadioButton();
            this.RadioButton6 = new RadioButton();
            this.RadioButton7 = new RadioButton();
            this.RadioButton8 = new RadioButton();
            this.Button1 = new Button();
            this.Button2 = new Button();
            this.GroupBox1 = new GroupBox();
            this.GroupBox2 = new GroupBox();
            this.PictureBox4 = new PictureBox();
            this.PictureBox3 = new PictureBox();
            this.PictureBox2 = new PictureBox();
            this.PictureBox1 = new PictureBox();
            this.RadioButton4 = new RadioButton();
            this.GroupBox1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            ((ISupportInitialize) this.PictureBox4).BeginInit();
            ((ISupportInitialize) this.PictureBox3).BeginInit();
            ((ISupportInitialize) this.PictureBox2).BeginInit();
            ((ISupportInitialize) this.PictureBox1).BeginInit();
            this.SuspendLayout();
            Point point = new Point(15, 0x57);
            this.TextBox1.Location = point;
            this.TextBox1.Name = "TextBox1";
            Size size = new Size(0x15d, 0x15);
            this.TextBox1.Size = size;
            this.TextBox1.TabIndex = 2;
            this.TextBox1.Text = "Title";
            point = new Point(15, 0x72);
            this.TextBox2.Location = point;
            this.TextBox2.Multiline = true;
            this.TextBox2.Name = "TextBox2";
            size = new Size(0x15d, 0x44);
            this.TextBox2.Size = size;
            this.TextBox2.TabIndex = 3;
            this.TextBox2.Text = "Message.";
            this.RadioButton1.AutoSize = true;
            this.RadioButton1.Checked = true;
            point = new Point(0x2a, 0x3a);
            this.RadioButton1.Location = point;
            this.RadioButton1.Name = "RadioButton1";
            size = new Size(14, 13);
            this.RadioButton1.Size = size;
            this.RadioButton1.TabIndex = 4;
            this.RadioButton1.TabStop = true;
            this.RadioButton1.UseVisualStyleBackColor = true;
            this.RadioButton2.AutoSize = true;
            point = new Point(0x7c, 0x3a);
            this.RadioButton2.Location = point;
            this.RadioButton2.Name = "RadioButton2";
            size = new Size(14, 13);
            this.RadioButton2.Size = size;
            this.RadioButton2.TabIndex = 5;
            this.RadioButton2.TabStop = true;
            this.RadioButton2.UseVisualStyleBackColor = true;
            this.RadioButton3.AutoSize = true;
            point = new Point(0x121, 0x3a);
            this.RadioButton3.Location = point;
            this.RadioButton3.Name = "RadioButton3";
            size = new Size(14, 13);
            this.RadioButton3.Size = size;
            this.RadioButton3.TabIndex = 6;
            this.RadioButton3.TabStop = true;
            this.RadioButton3.UseVisualStyleBackColor = true;
            this.RadioButton5.AutoSize = true;
            this.RadioButton5.Checked = true;
            point = new Point(10, 0x16);
            this.RadioButton5.Location = point;
            this.RadioButton5.Name = "RadioButton5";
            size = new Size(0x26, 0x11);
            this.RadioButton5.Size = size;
            this.RadioButton5.TabIndex = 8;
            this.RadioButton5.TabStop = true;
            this.RadioButton5.Text = "Ok";
            this.RadioButton5.UseVisualStyleBackColor = true;
            this.RadioButton6.AutoSize = true;
            point = new Point(0x36, 0x17);
            this.RadioButton6.Location = point;
            this.RadioButton6.Name = "RadioButton6";
            size = new Size(80, 0x11);
            this.RadioButton6.Size = size;
            this.RadioButton6.TabIndex = 9;
            this.RadioButton6.TabStop = true;
            this.RadioButton6.Text = "Ok / Cancel";
            this.RadioButton6.UseVisualStyleBackColor = true;
            this.RadioButton7.AutoSize = true;
            point = new Point(140, 0x17);
            this.RadioButton7.Location = point;
            this.RadioButton7.Name = "RadioButton7";
            size = new Size(0x41, 0x11);
            this.RadioButton7.Size = size;
            this.RadioButton7.TabIndex = 10;
            this.RadioButton7.TabStop = true;
            this.RadioButton7.Text = "Yes / No";
            this.RadioButton7.UseVisualStyleBackColor = true;
            this.RadioButton8.AutoSize = true;
            point = new Point(0xd4, 0x17);
            this.RadioButton8.Location = point;
            this.RadioButton8.Name = "RadioButton8";
            size = new Size(0x83, 0x11);
            this.RadioButton8.Size = size;
            this.RadioButton8.TabIndex = 11;
            this.RadioButton8.TabStop = true;
            this.RadioButton8.Text = "Abort / Retry / Ignore";
            this.RadioButton8.UseVisualStyleBackColor = true;
            point = new Point(15, 0xfe);
            this.Button1.Location = point;
            this.Button1.Name = "Button1";
            size = new Size(0x15d, 0x1c);
            this.Button1.Size = size;
            this.Button1.TabIndex = 12;
            this.Button1.Text = ":: Test ::";
            this.Button1.UseVisualStyleBackColor = true;
            point = new Point(15, 0x11d);
            this.Button2.Location = point;
            this.Button2.Name = "Button2";
            size = new Size(0x15d, 0x1c);
            this.Button2.Size = size;
            this.Button2.TabIndex = 13;
            this.Button2.Text = ":: Send ::";
            this.Button2.UseVisualStyleBackColor = true;
            this.GroupBox1.Controls.Add(this.RadioButton5);
            this.GroupBox1.Controls.Add(this.RadioButton6);
            this.GroupBox1.Controls.Add(this.RadioButton8);
            this.GroupBox1.Controls.Add(this.RadioButton7);
            point = new Point(15, 0xbc);
            this.GroupBox1.Location = point;
            this.GroupBox1.Name = "GroupBox1";
            size = new Size(0x15d, 60);
            this.GroupBox1.Size = size;
            this.GroupBox1.TabIndex = 14;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Button";
            this.GroupBox2.Controls.Add(this.PictureBox4);
            this.GroupBox2.Controls.Add(this.PictureBox3);
            this.GroupBox2.Controls.Add(this.PictureBox2);
            this.GroupBox2.Controls.Add(this.PictureBox1);
            this.GroupBox2.Controls.Add(this.RadioButton1);
            this.GroupBox2.Controls.Add(this.RadioButton2);
            this.GroupBox2.Controls.Add(this.RadioButton4);
            this.GroupBox2.Controls.Add(this.RadioButton3);
            point = new Point(15, 1);
            this.GroupBox2.Location = point;
            this.GroupBox2.Name = "GroupBox2";
            size = new Size(0x15d, 80);
            this.GroupBox2.Size = size;
            this.GroupBox2.TabIndex = 15;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Style";
            this.PictureBox4.Image = (Image) manager.GetObject("PictureBox4.Image");
            point = new Point(0x112, 0x10);
            this.PictureBox4.Location = point;
            this.PictureBox4.Name = "PictureBox4";
            size = new Size(0x2d, 0x29);
            this.PictureBox4.Size = size;
            this.PictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            this.PictureBox4.TabIndex = 11;
            this.PictureBox4.TabStop = false;
            this.PictureBox3.Image = Class5.smethod_33();
            point = new Point(0xbf, 0x10);
            this.PictureBox3.Location = point;
            this.PictureBox3.Name = "PictureBox3";
            size = new Size(0x2d, 0x29);
            this.PictureBox3.Size = size;
            this.PictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            this.PictureBox3.TabIndex = 10;
            this.PictureBox3.TabStop = false;
            this.PictureBox2.Image = Class5.smethod_84();
            point = new Point(0x6c, 0x10);
            this.PictureBox2.Location = point;
            this.PictureBox2.Name = "PictureBox2";
            size = new Size(0x2d, 0x29);
            this.PictureBox2.Size = size;
            this.PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            this.PictureBox2.TabIndex = 9;
            this.PictureBox2.TabStop = false;
            this.PictureBox1.Image = (Image) manager.GetObject("PictureBox1.Image");
            point = new Point(0x1b, 0x10);
            this.PictureBox1.Location = point;
            this.PictureBox1.Name = "PictureBox1";
            size = new Size(0x2d, 0x29);
            this.PictureBox1.Size = size;
            this.PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.PictureBox1.TabIndex = 8;
            this.PictureBox1.TabStop = false;
            this.RadioButton4.AutoSize = true;
            point = new Point(0xd0, 0x3a);
            this.RadioButton4.Location = point;
            this.RadioButton4.Name = "RadioButton4";
            size = new Size(14, 13);
            this.RadioButton4.Size = size;
            this.RadioButton4.TabIndex = 7;
            this.RadioButton4.TabStop = true;
            this.RadioButton4.UseVisualStyleBackColor = true;
            SizeF ef = new SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = AutoScaleMode.Font;
            size = new Size(0x177, 0x148);
            this.ClientSize = size;
            this.Controls.Add(this.Button2);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.TextBox2);
            this.Controls.Add(this.TextBox1);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.GroupBox2);
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.Icon = (Icon) manager.GetObject("$this.Icon");
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MSG";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Message Box";
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            ((ISupportInitialize) this.PictureBox4).EndInit();
            ((ISupportInitialize) this.PictureBox3).EndInit();
            ((ISupportInitialize) this.PictureBox2).EndInit();
            ((ISupportInitialize) this.PictureBox1).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        public void MESSAGEBOX(string text, string title, int style, int button)
        {
            switch (style)
            {
                case 1:
                    switch (button)
                    {
                        case 1:
                            Interaction.MsgBox(text, MsgBoxStyle.Information, title);
                            return;

                        case 2:
                            Interaction.MsgBox(text, MsgBoxStyle.Information | MsgBoxStyle.OkCancel, title);
                            return;

                        case 3:
                            Interaction.MsgBox(text, MsgBoxStyle.Information | MsgBoxStyle.YesNo, title);
                            return;

                        case 4:
                            Interaction.MsgBox(text, MsgBoxStyle.Information | MsgBoxStyle.AbortRetryIgnore, title);
                            return;
                    }
                    break;

                case 2:
                    switch (button)
                    {
                        case 1:
                            Interaction.MsgBox(text, MsgBoxStyle.Critical, title);
                            return;

                        case 2:
                            Interaction.MsgBox(text, MsgBoxStyle.Critical | MsgBoxStyle.OkCancel, title);
                            return;

                        case 3:
                            Interaction.MsgBox(text, MsgBoxStyle.Critical | MsgBoxStyle.YesNo, title);
                            return;

                        case 4:
                            Interaction.MsgBox(text, MsgBoxStyle.Critical | MsgBoxStyle.AbortRetryIgnore, title);
                            return;
                    }
                    break;

                case 3:
                    switch (button)
                    {
                        case 1:
                            Interaction.MsgBox(text, MsgBoxStyle.Exclamation, title);
                            return;

                        case 2:
                            Interaction.MsgBox(text, MsgBoxStyle.Exclamation | MsgBoxStyle.OkCancel, title);
                            return;

                        case 3:
                            Interaction.MsgBox(text, MsgBoxStyle.Exclamation | MsgBoxStyle.YesNo, title);
                            return;

                        case 4:
                            Interaction.MsgBox(text, MsgBoxStyle.Exclamation | MsgBoxStyle.AbortRetryIgnore, title);
                            return;
                    }
                    break;

                case 4:
                    switch (button)
                    {
                        case 1:
                            Interaction.MsgBox(text, MsgBoxStyle.Question, title);
                            return;

                        case 2:
                            Interaction.MsgBox(text, MsgBoxStyle.Question | MsgBoxStyle.OkCancel, title);
                            return;

                        case 3:
                            Interaction.MsgBox(text, MsgBoxStyle.Question | MsgBoxStyle.YesNo, title);
                            return;

                        case 4:
                            Interaction.MsgBox(text, MsgBoxStyle.Question | MsgBoxStyle.AbortRetryIgnore, title);
                            return;
                    }
                    break;
            }
        }

        private void MSG_Load(object sender, EventArgs e)
        {
            this.int_0 = 1;
            this.int_1 = 1;
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.RadioButton1.Checked)
            {
                this.int_0 = 1;
            }
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.RadioButton2.Checked)
            {
                this.int_0 = 2;
            }
        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (this.RadioButton3.Checked)
            {
                this.int_0 = 3;
            }
        }

        private void RadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (this.RadioButton4.Checked)
            {
                this.int_0 = 4;
            }
        }

        private void RadioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (this.RadioButton5.Checked)
            {
                this.int_1 = 1;
            }
        }

        private void RadioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (this.RadioButton6.Checked)
            {
                this.int_1 = 2;
            }
        }

        private void RadioButton7_CheckedChanged(object sender, EventArgs e)
        {
            if (this.RadioButton7.Checked)
            {
                this.int_1 = 3;
            }
        }

        private void RadioButton8_CheckedChanged(object sender, EventArgs e)
        {
            if (this.RadioButton8.Checked)
            {
                this.int_1 = 4;
            }
        }

        public object _BUTTON
        {
            get
            {
                return this.int_1;
            }
        }

        public object _STYLE
        {
            get
            {
                return this.int_0;
            }
        }

        public object _TEXT
        {
            get
            {
                return this.TextBox2.Text;
            }
        }

        public object _TITLE
        {
            get
            {
                return this.TextBox1.Text;
            }
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

        internal virtual Button Button2
        {
            get
            {
                return this._Button2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.Button2_Click);
                if (this._Button2 != null)
                {
                    this._Button2.Click -= handler;
                }
                this._Button2 = value;
                if (this._Button2 != null)
                {
                    this._Button2.Click += handler;
                }
            }
        }

        internal virtual GroupBox GroupBox1
        {
            get
            {
                return this._GroupBox1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._GroupBox1 = value;
            }
        }

        internal virtual GroupBox GroupBox2
        {
            get
            {
                return this._GroupBox2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._GroupBox2 = value;
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
                this._PictureBox4 = value;
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
                EventHandler handler = new EventHandler(this.RadioButton1_CheckedChanged);
                if (this._RadioButton1 != null)
                {
                    this._RadioButton1.CheckedChanged -= handler;
                }
                this._RadioButton1 = value;
                if (this._RadioButton1 != null)
                {
                    this._RadioButton1.CheckedChanged += handler;
                }
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
                EventHandler handler = new EventHandler(this.RadioButton2_CheckedChanged);
                if (this._RadioButton2 != null)
                {
                    this._RadioButton2.CheckedChanged -= handler;
                }
                this._RadioButton2 = value;
                if (this._RadioButton2 != null)
                {
                    this._RadioButton2.CheckedChanged += handler;
                }
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
                EventHandler handler = new EventHandler(this.RadioButton3_CheckedChanged);
                if (this._RadioButton3 != null)
                {
                    this._RadioButton3.CheckedChanged -= handler;
                }
                this._RadioButton3 = value;
                if (this._RadioButton3 != null)
                {
                    this._RadioButton3.CheckedChanged += handler;
                }
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
                EventHandler handler = new EventHandler(this.RadioButton4_CheckedChanged);
                if (this._RadioButton4 != null)
                {
                    this._RadioButton4.CheckedChanged -= handler;
                }
                this._RadioButton4 = value;
                if (this._RadioButton4 != null)
                {
                    this._RadioButton4.CheckedChanged += handler;
                }
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
                EventHandler handler = new EventHandler(this.RadioButton5_CheckedChanged);
                if (this._RadioButton5 != null)
                {
                    this._RadioButton5.CheckedChanged -= handler;
                }
                this._RadioButton5 = value;
                if (this._RadioButton5 != null)
                {
                    this._RadioButton5.CheckedChanged += handler;
                }
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
                EventHandler handler = new EventHandler(this.RadioButton6_CheckedChanged);
                if (this._RadioButton6 != null)
                {
                    this._RadioButton6.CheckedChanged -= handler;
                }
                this._RadioButton6 = value;
                if (this._RadioButton6 != null)
                {
                    this._RadioButton6.CheckedChanged += handler;
                }
            }
        }

        internal virtual RadioButton RadioButton7
        {
            get
            {
                return this._RadioButton7;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.RadioButton7_CheckedChanged);
                if (this._RadioButton7 != null)
                {
                    this._RadioButton7.CheckedChanged -= handler;
                }
                this._RadioButton7 = value;
                if (this._RadioButton7 != null)
                {
                    this._RadioButton7.CheckedChanged += handler;
                }
            }
        }

        internal virtual RadioButton RadioButton8
        {
            get
            {
                return this._RadioButton8;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.RadioButton8_CheckedChanged);
                if (this._RadioButton8 != null)
                {
                    this._RadioButton8.CheckedChanged -= handler;
                }
                this._RadioButton8 = value;
                if (this._RadioButton8 != null)
                {
                    this._RadioButton8.CheckedChanged += handler;
                }
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
    }
}

