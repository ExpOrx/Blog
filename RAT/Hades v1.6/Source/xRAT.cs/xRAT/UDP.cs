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
    public class UDP : Form
    {
        [AccessedThroughProperty("Button1")]
        private Button _Button1;
        [AccessedThroughProperty("GroupBox1")]
        private GroupBox _GroupBox1;
        [AccessedThroughProperty("Label1")]
        private Label _Label1;
        [AccessedThroughProperty("Label2")]
        private Label _Label2;
        [AccessedThroughProperty("TextBox1")]
        private TextBox _TextBox1;
        [AccessedThroughProperty("TextBox2")]
        private TextBox _TextBox2;
        private IContainer icontainer_0;

        public UDP()
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
                    IPHostEntry entry3 = Dns.GetHostEntry(this.TextBox1.Text.Replace("www.", string.Empty));
                    this.TextBox1.Text = entry3.AddressList[0].ToString();
                }
                else if (this.TextBox1.Text.Contains("http://"))
                {
                    IPHostEntry entry4 = Dns.GetHostEntry(this.TextBox1.Text.Replace("http://", string.Empty));
                    this.TextBox1.Text = entry4.AddressList[0].ToString();
                }
                else
                {
                    IPHostEntry entry2 = Dns.GetHostEntry(this.TextBox1.Text);
                    this.TextBox1.Text = entry2.AddressList[0].ToString();
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
            ComponentResourceManager manager = new ComponentResourceManager(typeof(UDP));
            this.GroupBox1 = new GroupBox();
            this.TextBox1 = new TextBox();
            this.Label1 = new Label();
            this.TextBox2 = new TextBox();
            this.Label2 = new Label();
            this.Button1 = new Button();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            this.GroupBox1.Controls.Add(this.TextBox1);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.TextBox2);
            this.GroupBox1.Controls.Add(this.Label2);
            Point point = new Point(12, 12);
            this.GroupBox1.Location = point;
            this.GroupBox1.Name = "GroupBox1";
            Size size = new Size(0x13a, 0x5c);
            this.GroupBox1.Size = size;
            this.GroupBox1.TabIndex = 14;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "UDP-Flood Settings";
            point = new Point(0x40, 30);
            this.TextBox1.Location = point;
            this.TextBox1.Name = "TextBox1";
            size = new Size(220, 0x15);
            this.TextBox1.Size = size;
            this.TextBox1.TabIndex = 0;
            this.TextBox1.Text = "127.0.0.1";
            this.Label1.AutoSize = true;
            point = new Point(0x19, 0x21);
            this.Label1.Location = point;
            this.Label1.Name = "Label1";
            size = new Size(0x21, 13);
            this.Label1.Size = size;
            this.Label1.TabIndex = 1;
            this.Label1.Text = "Host:";
            point = new Point(0x40, 0x38);
            this.TextBox2.Location = point;
            this.TextBox2.Name = "TextBox2";
            size = new Size(220, 0x15);
            this.TextBox2.Size = size;
            this.TextBox2.TabIndex = 2;
            this.TextBox2.Text = "80";
            this.Label2.AutoSize = true;
            point = new Point(0x19, 0x3b);
            this.Label2.Location = point;
            this.Label2.Name = "Label2";
            size = new Size(0x1f, 13);
            this.Label2.Size = size;
            this.Label2.TabIndex = 6;
            this.Label2.Text = "Port:";
            point = new Point(12, 0x6b);
            this.Button1.Location = point;
            this.Button1.Name = "Button1";
            size = new Size(0x13b, 0x22);
            this.Button1.Size = size;
            this.Button1.TabIndex = 13;
            this.Button1.Text = "Start UDP-Flood";
            this.Button1.UseVisualStyleBackColor = true;
            SizeF ef = new SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = AutoScaleMode.Font;
            size = new Size(0x153, 0x9c);
            this.ClientSize = size;
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.Button1);
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.Icon = (Icon) manager.GetObject("$this.Icon");
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UDP";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "UDP-Flood";
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
    }
}

