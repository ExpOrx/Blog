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
    public class IP_Tracer : Form
    {
        [AccessedThroughProperty("WebBrowser1")]
        private WebBrowser _WebBrowser1;
        private IContainer icontainer_0;

        public IP_Tracer()
        {
            Class1.QaIGh5M7cuigS();
            this.InitializeComponent();
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
            ComponentResourceManager manager = new ComponentResourceManager(typeof(IP_Tracer));
            this.WebBrowser1 = new WebBrowser();
            this.SuspendLayout();
            this.WebBrowser1.Dock = DockStyle.Fill;
            Point point = new Point(0, 0);
            this.WebBrowser1.Location = point;
            Size size = new Size(20, 20);
            this.WebBrowser1.MinimumSize = size;
            this.WebBrowser1.Name = "WebBrowser1";
            size = new Size(0x162, 0x13a);
            this.WebBrowser1.Size = size;
            this.WebBrowser1.TabIndex = 0;
            this.WebBrowser1.Url = new Uri("http://www.trouver-ip.com/", UriKind.Absolute);
            SizeF ef = new SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = AutoScaleMode.Font;
            size = new Size(0x162, 0x13a);
            this.ClientSize = size;
            this.Controls.Add(this.WebBrowser1);
            this.Icon = (Icon) manager.GetObject("$this.Icon");
            this.Name = "IP_Tracer";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "IP Tracer";
            this.ResumeLayout(false);
        }

        internal virtual WebBrowser WebBrowser1
        {
            get
            {
                return this._WebBrowser1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._WebBrowser1 = value;
            }
        }
    }
}

