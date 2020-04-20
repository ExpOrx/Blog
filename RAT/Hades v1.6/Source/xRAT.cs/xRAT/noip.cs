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
    using System.Text;
    using System.Windows.Forms;

    [DesignerGenerated]
    public class noip : Form
    {
        [AccessedThroughProperty("Button1")]
        private Button _Button1;
        [AccessedThroughProperty("CheckBox1")]
        private CheckBox _CheckBox1;
        [AccessedThroughProperty("Label2")]
        private Label _Label2;
        [AccessedThroughProperty("Label3")]
        private Label _Label3;
        [AccessedThroughProperty("Label4")]
        private Label _Label4;
        [AccessedThroughProperty("RichTextBox1")]
        private RichTextBox _RichTextBox1;
        [AccessedThroughProperty("TextBox1")]
        private TextBox _TextBox1;
        [AccessedThroughProperty("TextBox2")]
        private TextBox _TextBox2;
        [AccessedThroughProperty("TextBox3")]
        private TextBox _TextBox3;
        private IContainer icontainer_0;
        [AccessedThroughProperty("Label1")]
        private Label label_0;

        public noip()
        {
            Class1.QaIGh5M7cuigS();
            base.Load += new EventHandler(this.noip_Load);
            this.InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                bool flag1 = this.CheckBox1.Checked;
                WebClient client = new WebClient();
                UTF8Encoding encoding = new UTF8Encoding();
                string[] strArray2 = encoding.GetString(client.DownloadData("http://dynupdate.no-ip.com/dns?username=" + this.TextBox1.Text + "&password=" + this.TextBox2.Text + "&hostname=" + this.TextBox3.Text)).Split(new char[] { ':' });
                this.RichTextBox1.Text = strArray2[1];
                if (strArray2[1].Contains("0"))
                {
                    Interaction.MsgBox("Success - IP address is current, no update performed", MsgBoxStyle.Information, "");
                }
                if (strArray2[1].Contains("1"))
                {
                    Interaction.MsgBox("Success - DNS hostname update successful", MsgBoxStyle.Information, "");
                }
                if (strArray2[1].Contains("2"))
                {
                    Interaction.MsgBox("Error - Hostname supplied does not exist", MsgBoxStyle.Critical, "");
                }
                if (strArray2[1].Contains("3"))
                {
                    Interaction.MsgBox("Error - Invalid username", MsgBoxStyle.Critical, "");
                }
                if (strArray2[1].Contains("4"))
                {
                    Interaction.MsgBox("Error - Invalid password", MsgBoxStyle.Critical, "");
                }
                if (strArray2[1].Contains("5"))
                {
                    Interaction.MsgBox("Error - Too many updates sent. Updates are blocked until 1 hour passes since last status of 5 returned.", MsgBoxStyle.Critical, "");
                }
                if (strArray2[1].Contains("6"))
                {
                    Interaction.MsgBox("Error - Account disabled due to violation of No-IP terms of service. Our terms of service can be viewed at http://www.no-ip.com/legal/tos", MsgBoxStyle.Critical, "");
                }
                if (strArray2[1].Contains("7"))
                {
                    Interaction.MsgBox("Error - Invalid IP. Invalid IP submitted is improperly formated, is a private LAN RFC 1918 address, or an abuse blacklisted address.", MsgBoxStyle.Critical, "");
                }
                if (strArray2[1].Contains("8"))
                {
                    Interaction.MsgBox("Error - Disabled / Locked hostname", MsgBoxStyle.Critical, "");
                }
                if (strArray2[1].Contains("9"))
                {
                    Interaction.MsgBox("Host updated is configured as a web redirect and no update was performed.", MsgBoxStyle.Information, "");
                }
                if (strArray2[1].Contains("10"))
                {
                    Interaction.MsgBox("Error - Group supplied does not exist", MsgBoxStyle.Critical, "");
                }
                if (strArray2[1].Contains("11"))
                {
                    Interaction.MsgBox("Success - DNS group update is successful", MsgBoxStyle.Information, "");
                }
                if (strArray2[1].Contains("12"))
                {
                    Interaction.MsgBox("Success - DNS group is current, no update performed.", MsgBoxStyle.Information, "");
                }
                if (strArray2[1].Contains("13"))
                {
                    Interaction.MsgBox("Error - Update client support not available for supplied hostname or group", MsgBoxStyle.Critical, "");
                }
                if (strArray2[1].Contains("14"))
                {
                    Interaction.MsgBox("Error - Hostname supplied does not have offline settings configured. Returned if sending offline=YES on a host that does not have any offline actions configured.", MsgBoxStyle.Critical, "");
                }
                if (strArray2[1].Contains("99"))
                {
                    Interaction.MsgBox("Error - Client disabled. Client should exit and not perform any more updates without user intervention.", MsgBoxStyle.Critical, "");
                }
                if (strArray2[1].Contains("100"))
                {
                    Interaction.MsgBox("Error - User input error usually returned if missing required request parameters", MsgBoxStyle.Critical, "");
                }
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                MessageBox.Show("No-IP", "Error false ID !", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                ProjectData.ClearProjectError();
            }
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
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
            ComponentResourceManager manager = new ComponentResourceManager(typeof(noip));
            this.Label2 = new Label();
            this.Label3 = new Label();
            this.Button1 = new Button();
            this.TextBox1 = new TextBox();
            this.TextBox2 = new TextBox();
            this.TextBox3 = new TextBox();
            this.RichTextBox1 = new RichTextBox();
            this.CheckBox1 = new CheckBox();
            this.Label4 = new Label();
            this.SuspendLayout();
            this.Label2.AutoSize = true;
            this.Label2.ForeColor = Color.Black;
            Point point = new Point(0x11, 0x24);
            this.Label2.Location = point;
            this.Label2.Name = "Label2";
            Size size = new Size(0x57, 13);
            this.Label2.Size = size;
            this.Label2.TabIndex = 1;
            this.Label2.Text = "No-IP Password:";
            this.Label3.AutoSize = true;
            this.Label3.ForeColor = Color.Black;
            point = new Point(0x11, 0x3b);
            this.Label3.Location = point;
            this.Label3.Name = "Label3";
            size = new Size(0x3f, 13);
            this.Label3.Size = size;
            this.Label3.TabIndex = 2;
            this.Label3.Text = "No-IP Host:";
            this.Button1.AccessibleRole = AccessibleRole.PushButton;
            this.Button1.ForeColor = Color.Black;
            point = new Point(20, 0x53);
            this.Button1.Location = point;
            this.Button1.Name = "Button1";
            size = new Size(0x100, 40);
            this.Button1.Size = size;
            this.Button1.TabIndex = 3;
            this.Button1.Text = "Update";
            point = new Point(0x6b, 10);
            this.TextBox1.Location = point;
            this.TextBox1.Name = "TextBox1";
            size = new Size(0xa9, 0x15);
            this.TextBox1.Size = size;
            this.TextBox1.TabIndex = 0;
            point = new Point(0x6b, 0x21);
            this.TextBox2.Location = point;
            this.TextBox2.Name = "TextBox2";
            size = new Size(0xa9, 0x15);
            this.TextBox2.Size = size;
            this.TextBox2.TabIndex = 1;
            point = new Point(0x6b, 0x38);
            this.TextBox3.Location = point;
            this.TextBox3.Name = "TextBox3";
            size = new Size(0xa9, 0x15);
            this.TextBox3.Size = size;
            this.TextBox3.TabIndex = 2;
            point = new Point(13, 0x9c);
            this.RichTextBox1.Location = point;
            this.RichTextBox1.Name = "RichTextBox1";
            size = new Size(0xbd, 0x8f);
            this.RichTextBox1.Size = size;
            this.RichTextBox1.TabIndex = 4;
            this.RichTextBox1.Text = "";
            this.RichTextBox1.Visible = false;
            this.CheckBox1.AutoSize = true;
            point = new Point(12, 0x9a);
            this.CheckBox1.Location = point;
            this.CheckBox1.Name = "CheckBox1";
            size = new Size(0x4f, 0x11);
            this.CheckBox1.Size = size;
            this.CheckBox1.TabIndex = 5;
            this.CheckBox1.Text = "CheckBox1";
            this.CheckBox1.UseVisualStyleBackColor = true;
            this.Label4.AutoSize = true;
            this.Label4.ForeColor = Color.Black;
            point = new Point(0x11, 13);
            this.Label4.Location = point;
            this.Label4.Name = "Label4";
            size = new Size(0x3f, 13);
            this.Label4.Size = size;
            this.Label4.TabIndex = 6;
            this.Label4.Text = "No-IP User:";
            SizeF ef = new SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = SystemColors.Control;
            size = new Size(0x127, 0x87);
            this.ClientSize = size;
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.CheckBox1);
            this.Controls.Add(this.RichTextBox1);
            this.Controls.Add(this.TextBox1);
            this.Controls.Add(this.TextBox2);
            this.Controls.Add(this.TextBox3);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label2);
            this.ForeColor = Color.White;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Icon = (Icon) manager.GetObject("$this.Icon");
            size = new Size(0x1f0, 0x1be);
            this.MaximumSize = size;
            size = new Size(0x128, 0x92);
            this.MinimumSize = size;
            this.Name = "noip";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "No-IP Update";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void noip_Load(object sender, EventArgs e)
        {
            this.CheckBox1.Checked = true;
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

        internal virtual CheckBox CheckBox1
        {
            get
            {
                return this._CheckBox1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.CheckBox1_CheckedChanged);
                if (this._CheckBox1 != null)
                {
                    this._CheckBox1.CheckedChanged -= handler;
                }
                this._CheckBox1 = value;
                if (this._CheckBox1 != null)
                {
                    this._CheckBox1.CheckedChanged += handler;
                }
            }
        }

        internal virtual Label Label1
        {
            get
            {
                return this.label_0;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this.label_0 = value;
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

