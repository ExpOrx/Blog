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
    public class ip : Form
    {
        [AccessedThroughProperty("Button1")]
        private Button _Button1;
        [AccessedThroughProperty("TextBox1")]
        private TextBox _TextBox1;
        [AccessedThroughProperty("TextBox2")]
        private TextBox _TextBox2;
        private IContainer icontainer_0;

        public ip()
        {
            Class1.QaIGh5M7cuigS();
            this.InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.TextBox1.Text.Contains("http://"))
                {
                    IPHostEntry hostEntry = Dns.GetHostEntry(this.TextBox1.Text.Replace("http://", string.Empty));
                    this.TextBox2.Text = hostEntry.AddressList[0].ToString();
                }
                else
                {
                    IPHostEntry entry2 = Dns.GetHostEntry(this.TextBox1.Text);
                    this.TextBox2.Text = entry2.AddressList[0].ToString();
                }
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception prompt = exception1;
                Interaction.MsgBox(prompt, MsgBoxStyle.OkOnly, null);
                ProjectData.ClearProjectError();
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

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(ip));
            this.TextBox1 = new TextBox();
            this.TextBox2 = new TextBox();
            this.Button1 = new Button();
            this.SuspendLayout();
            Point point = new Point(12, 9);
            this.TextBox1.Location = point;
            this.TextBox1.Name = "TextBox1";
            Size size = new Size(0xdb, 0x15);
            this.TextBox1.Size = size;
            this.TextBox1.TabIndex = 0;
            this.TextBox1.Text = "www.google.fr";
            point = new Point(12, 0x24);
            this.TextBox2.Location = point;
            this.TextBox2.Name = "TextBox2";
            size = new Size(0xdb, 0x15);
            this.TextBox2.Size = size;
            this.TextBox2.TabIndex = 1;
            point = new Point(12, 0x3f);
            this.Button1.Location = point;
            this.Button1.Name = "Button1";
            size = new Size(0xdb, 0x1a);
            this.Button1.Size = size;
            this.Button1.TabIndex = 2;
            this.Button1.Text = "Get IP";
            this.Button1.UseVisualStyleBackColor = true;
            SizeF ef = new SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = AutoScaleMode.Font;
            size = new Size(0xf3, 0x66);
            this.ClientSize = size;
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.TextBox2);
            this.Controls.Add(this.TextBox1);
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.Icon = (Icon) manager.GetObject("$this.Icon");
            this.Name = "ip";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Get IP";
            this.ResumeLayout(false);
            this.PerformLayout();
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

