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
    public class OpenURL : Form
    {
        [AccessedThroughProperty("Button1")]
        private Button _Button1;
        [AccessedThroughProperty("Label1")]
        private Label _Label1;
        [AccessedThroughProperty("TextBox1")]
        private TextBox _TextBox1;
        private IContainer icontainer_0;

        public OpenURL()
        {
            Class1.QaIGh5M7cuigS();
            this.InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
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
            ComponentResourceManager manager = new ComponentResourceManager(typeof(OpenURL));
            this.Button1 = new Button();
            this.Label1 = new Label();
            this.TextBox1 = new TextBox();
            this.SuspendLayout();
            Point point = new Point(12, 0x33);
            this.Button1.Location = point;
            this.Button1.Name = "Button1";
            Size size = new Size(260, 0x1c);
            this.Button1.Size = size;
            this.Button1.TabIndex = 0;
            this.Button1.Text = "Open";
            this.Button1.UseVisualStyleBackColor = true;
            this.Label1.AutoSize = true;
            point = new Point(12, 9);
            this.Label1.Location = point;
            this.Label1.Name = "Label1";
            size = new Size(0x1a, 13);
            this.Label1.Size = size;
            this.Label1.TabIndex = 1;
            this.Label1.Text = "URL";
            point = new Point(12, 0x19);
            this.TextBox1.Location = point;
            this.TextBox1.Name = "TextBox1";
            size = new Size(260, 0x15);
            this.TextBox1.Size = size;
            this.TextBox1.TabIndex = 2;
            SizeF ef = new SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = AutoScaleMode.Font;
            size = new Size(0x11c, 0x5c);
            this.ClientSize = size;
            this.Controls.Add(this.TextBox1);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.Button1);
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.Icon = (Icon) manager.GetObject("$this.Icon");
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OpenURL";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "URL";
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

        public object URL
        {
            get
            {
                return this.TextBox1.Text;
            }
        }
    }
}

