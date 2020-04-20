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
    public class Process : Form
    {
        [AccessedThroughProperty("Button1")]
        private Button _Button1;
        [AccessedThroughProperty("Button2")]
        private Button _Button2;
        [AccessedThroughProperty("Label1")]
        private Label _Label1;
        [AccessedThroughProperty("Label2")]
        private Label _Label2;
        [AccessedThroughProperty("TextBox1")]
        private TextBox _TextBox1;
        [AccessedThroughProperty("TextBox2")]
        private TextBox _TextBox2;
        private IContainer icontainer_0;

        public Process()
        {
            Class1.QaIGh5M7cuigS();
            this.InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Class2.Class4_0.method_6().SendToSelected("PRCSTART|" + this.TextBox1.Text);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Class2.Class4_0.method_6().SendToSelected("PRCKILL|" + this.TextBox2.Text);
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
            ComponentResourceManager manager = new ComponentResourceManager(typeof(xRAT.Process));
            this.TextBox1 = new TextBox();
            this.Label1 = new Label();
            this.Label2 = new Label();
            this.TextBox2 = new TextBox();
            this.Button1 = new Button();
            this.Button2 = new Button();
            this.SuspendLayout();
            Point point = new Point(12, 0x19);
            this.TextBox1.Location = point;
            this.TextBox1.Name = "TextBox1";
            Size size = new Size(0xdd, 0x15);
            this.TextBox1.Size = size;
            this.TextBox1.TabIndex = 0;
            this.Label1.AutoSize = true;
            point = new Point(12, 9);
            this.Label1.Location = point;
            this.Label1.Name = "Label1";
            size = new Size(0x4c, 13);
            this.Label1.Size = size;
            this.Label1.TabIndex = 1;
            this.Label1.Text = "Path or Name:";
            this.Label2.AutoSize = true;
            point = new Point(12, 0x60);
            this.Label2.Location = point;
            this.Label2.Name = "Label2";
            size = new Size(0x26, 13);
            this.Label2.Size = size;
            this.Label2.TabIndex = 2;
            this.Label2.Text = "Name:";
            point = new Point(12, 0x70);
            this.TextBox2.Location = point;
            this.TextBox2.Name = "TextBox2";
            size = new Size(0xdd, 0x15);
            this.TextBox2.Size = size;
            this.TextBox2.TabIndex = 3;
            point = new Point(12, 0x33);
            this.Button1.Location = point;
            this.Button1.Name = "Button1";
            size = new Size(0xdd, 0x17);
            this.Button1.Size = size;
            this.Button1.TabIndex = 4;
            this.Button1.Text = "Start";
            this.Button1.UseVisualStyleBackColor = true;
            point = new Point(12, 0x8a);
            this.Button2.Location = point;
            this.Button2.Name = "Button2";
            size = new Size(0xdd, 0x17);
            this.Button2.Size = size;
            this.Button2.TabIndex = 5;
            this.Button2.Text = "Kill";
            this.Button2.UseVisualStyleBackColor = true;
            SizeF ef = new SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = AutoScaleMode.Font;
            size = new Size(0xf5, 0xb6);
            this.ClientSize = size;
            this.Controls.Add(this.Button2);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.TextBox2);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.TextBox1);
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.Icon = (Icon) manager.GetObject("$this.Icon");
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Process";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Process";
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

