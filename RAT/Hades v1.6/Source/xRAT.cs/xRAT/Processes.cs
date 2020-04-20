namespace xRAT
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Windows.Forms;

    [DesignerGenerated]
    public class Processes : Form
    {
        [AccessedThroughProperty("Button1")]
        private Button _Button1;
        [AccessedThroughProperty("ContextMenuStrip3")]
        private ContextMenuStrip _ContextMenuStrip3;
        [AccessedThroughProperty("KillProcessToolStripMenuItem")]
        private ToolStripMenuItem _KillProcessToolStripMenuItem;
        [AccessedThroughProperty("ListView1")]
        private ListView _ListView1;
        [AccessedThroughProperty("ColumnHeader1")]
        private ColumnHeader columnHeader_0;
        private IContainer icontainer_0;

        public Processes()
        {
            Class1.QaIGh5M7cuigS();
            base.Load += new EventHandler(this.Processes_Load);
            this.InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Class2.Class4_0.method_6().SendToSelected("PRCLIST");
            this.Button1.Enabled = false;
            int num = 1;
            do
            {
                Thread.Sleep(10);
                Application.DoEvents();
                num++;
            }
            while (num <= 200);
            this.Button1.Enabled = true;
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
            this.icontainer_0 = new System.ComponentModel.Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(Processes));
            this.ContextMenuStrip3 = new ContextMenuStrip(this.icontainer_0);
            this.KillProcessToolStripMenuItem = new ToolStripMenuItem();
            this.Button1 = new Button();
            this.ListView1 = new ListView();
            this.ColumnHeader1 = new ColumnHeader();
            this.ContextMenuStrip3.SuspendLayout();
            this.SuspendLayout();
            this.ContextMenuStrip3.Items.AddRange(new ToolStripItem[] { this.KillProcessToolStripMenuItem });
            this.ContextMenuStrip3.Name = "ContextMenuStrip3";
            Size size = new Size(0x8a, 0x1a);
            this.ContextMenuStrip3.Size = size;
            this.KillProcessToolStripMenuItem.Image = Class5.smethod_6();
            this.KillProcessToolStripMenuItem.Name = "KillProcessToolStripMenuItem";
            size = new Size(0x89, 0x16);
            this.KillProcessToolStripMenuItem.Size = size;
            this.KillProcessToolStripMenuItem.Text = "Kill Process";
            Point point = new Point(12, 0x10d);
            this.Button1.Location = point;
            this.Button1.Name = "Button1";
            size = new Size(0xb0, 0x1b);
            this.Button1.Size = size;
            this.Button1.TabIndex = 2;
            this.Button1.Text = "Refresh Processes";
            this.Button1.UseVisualStyleBackColor = true;
            this.ListView1.Columns.AddRange(new ColumnHeader[] { this.ColumnHeader1 });
            this.ListView1.ContextMenuStrip = this.ContextMenuStrip3;
            this.ListView1.FullRowSelect = true;
            point = new Point(12, 12);
            this.ListView1.Location = point;
            this.ListView1.MultiSelect = false;
            this.ListView1.Name = "ListView1";
            size = new Size(0xb0, 0xfb);
            this.ListView1.Size = size;
            this.ListView1.Sorting = SortOrder.Ascending;
            this.ListView1.TabIndex = 4;
            this.ListView1.UseCompatibleStateImageBehavior = false;
            this.ListView1.View = View.Details;
            this.ColumnHeader1.Text = "Process Name";
            this.ColumnHeader1.Width = 0xac;
            SizeF ef = new SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = AutoScaleMode.Font;
            size = new Size(200, 0x133);
            this.ClientSize = size;
            this.Controls.Add(this.ListView1);
            this.Controls.Add(this.Button1);
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.Icon = (Icon) manager.GetObject("$this.Icon");
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Processes";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Running Processes";
            this.ContextMenuStrip3.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private void KillProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string str = this.ListView1.SelectedItems[0].Text.ToString().Replace(".exe", "");
            Class2.Class4_0.method_6().SendToSelected("PRCKILL|" + str);
            int num = 1;
            do
            {
                Thread.Sleep(10);
                Application.DoEvents();
                num++;
            }
            while (num <= 200);
            this.Button1.PerformClick();
        }

        private void method_0(object sender, EventArgs e)
        {
        }

        private void method_1(object sender, EventArgs e)
        {
        }

        private void Processes_Load(object sender, EventArgs e)
        {
            Class2.Class4_0.method_6().SendToSelected("PRCLIST");
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

        internal virtual ColumnHeader ColumnHeader1
        {
            get
            {
                return this.columnHeader_0;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this.columnHeader_0 = value;
            }
        }

        internal virtual ContextMenuStrip ContextMenuStrip3
        {
            get
            {
                return this._ContextMenuStrip3;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ContextMenuStrip3 = value;
            }
        }

        internal virtual ToolStripMenuItem KillProcessToolStripMenuItem
        {
            get
            {
                return this._KillProcessToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.KillProcessToolStripMenuItem_Click);
                if (this._KillProcessToolStripMenuItem != null)
                {
                    this._KillProcessToolStripMenuItem.Click -= handler;
                }
                this._KillProcessToolStripMenuItem = value;
                if (this._KillProcessToolStripMenuItem != null)
                {
                    this._KillProcessToolStripMenuItem.Click += handler;
                }
            }
        }

        internal virtual ListView ListView1
        {
            get
            {
                return this._ListView1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ListView1 = value;
            }
        }
    }
}

