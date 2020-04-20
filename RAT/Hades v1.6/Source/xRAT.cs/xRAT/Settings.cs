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
    public class Settings : Form
    {
        [AccessedThroughProperty("Button1")]
        private Button _Button1;
        [AccessedThroughProperty("CheckBox1")]
        private CheckBox _CheckBox1;
        [AccessedThroughProperty("CheckBox2")]
        private CheckBox _CheckBox2;
        [AccessedThroughProperty("CheckBox3")]
        private CheckBox _CheckBox3;
        [AccessedThroughProperty("CheckBox4")]
        private CheckBox _CheckBox4;
        [AccessedThroughProperty("Label1")]
        private Label _Label1;
        [AccessedThroughProperty("Label16")]
        private Label _Label16;
        [AccessedThroughProperty("NumericUpDown1")]
        private NumericUpDown _NumericUpDown1;
        [AccessedThroughProperty("Label2")]
        private Label daxawBwCf;
        private IContainer icontainer_0;

        public Settings()
        {
            Class1.QaIGh5M7cuigS();
            base.Load += new EventHandler(this.Settings_Load);
            this.InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Class2.Class4_0.method_6().autorefreshInt = Convert.ToInt32(this.NumericUpDown1.Value);
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            switch (this.CheckBox1.Checked)
            {
                case false:
                    Class2.Class4_0.method_6().popupnotify = 0;
                    break;

                case true:
                    Class2.Class4_0.method_6().popupnotify = 1;
                    break;
            }
        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            switch (this.CheckBox2.Checked)
            {
                case false:
                    this.NumericUpDown1.Enabled = false;
                    Class2.Class4_0.method_6().autorefreshact = 0;
                    Class2.Class4_0.method_6().Timer1.Enabled = false;
                    break;

                case true:
                    this.NumericUpDown1.Enabled = true;
                    Class2.Class4_0.method_6().autorefreshact = 1;
                    Class2.Class4_0.method_6().Timer1.Enabled = true;
                    Class2.Class4_0.method_6().autorefreshInt = Convert.ToInt32(this.NumericUpDown1.Value);
                    Class2.Class4_0.method_6().Timer1.Interval = Convert.ToInt32(decimal.Multiply(this.NumericUpDown1.Value, 1000M));
                    break;
            }
        }

        private void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            switch (this.CheckBox3.Checked)
            {
                case false:
                    Class2.Class4_0.method_6().autosize = 0;
                    break;

                case true:
                    Class2.Class4_0.method_6().autosize = 1;
                    Class2.Class4_0.method_6().AppNewAutosizeColumns(Class2.Class4_0.method_6().lstClients);
                    break;
            }
        }

        private void CheckBox4_CheckedChanged(object sender, EventArgs e)
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
            ComponentResourceManager manager = new ComponentResourceManager(typeof(Settings));
            this.CheckBox1 = new CheckBox();
            this.Label16 = new Label();
            this.CheckBox2 = new CheckBox();
            this.Label1 = new Label();
            this.NumericUpDown1 = new NumericUpDown();
            this.Label2 = new Label();
            this.Button1 = new Button();
            this.CheckBox3 = new CheckBox();
            this.CheckBox4 = new CheckBox();
            this.NumericUpDown1.BeginInit();
            this.SuspendLayout();
            this.CheckBox1.AutoSize = true;
            Point point = new Point(12, 0x29);
            this.CheckBox1.Location = point;
            this.CheckBox1.Name = "CheckBox1";
            Size size = new Size(0xe2, 0x11);
            this.CheckBox1.Size = size;
            this.CheckBox1.TabIndex = 0;
            this.CheckBox1.Text = "Sound notification (On server connection)";
            this.CheckBox1.UseVisualStyleBackColor = true;
            this.Label16.AutoSize = true;
            this.Label16.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.Label16.ForeColor = SystemColors.ControlDarkDark;
            point = new Point(12, 9);
            this.Label16.Location = point;
            this.Label16.Name = "Label16";
            size = new Size(100, 0x1d);
            this.Label16.Size = size;
            this.Label16.TabIndex = 0x29;
            this.Label16.Text = "Settings";
            this.CheckBox2.AutoSize = true;
            point = new Point(12, 110);
            this.CheckBox2.Location = point;
            this.CheckBox2.Name = "CheckBox2";
            size = new Size(0xb2, 0x11);
            this.CheckBox2.Size = size;
            this.CheckBox2.TabIndex = 0x2a;
            this.CheckBox2.Text = "Autorefresh Server Information";
            this.CheckBox2.UseVisualStyleBackColor = true;
            this.Label1.AutoSize = true;
            point = new Point(12, 0x88);
            this.Label1.Location = point;
            this.Label1.Name = "Label1";
            size = new Size(0x58, 13);
            this.Label1.Size = size;
            this.Label1.TabIndex = 0x2b;
            this.Label1.Text = "Refresh interval:";
            this.NumericUpDown1.Enabled = false;
            point = new Point(100, 0x84);
            this.NumericUpDown1.Location = point;
            decimal num = new decimal(new int[] { 0x3e8, 0, 0, 0 });
            this.NumericUpDown1.Maximum = num;
            num = new decimal(new int[] { 1, 0, 0, 0 });
            this.NumericUpDown1.Minimum = num;
            this.NumericUpDown1.Name = "NumericUpDown1";
            size = new Size(0x41, 0x15);
            this.NumericUpDown1.Size = size;
            this.NumericUpDown1.TabIndex = 0x2c;
            num = new decimal(new int[] { 60, 0, 0, 0 });
            this.NumericUpDown1.Value = num;
            this.Label2.AutoSize = true;
            point = new Point(0xa7, 0x88);
            this.Label2.Location = point;
            this.Label2.Name = "Label2";
            size = new Size(12, 13);
            this.Label2.Size = size;
            this.Label2.TabIndex = 0x2d;
            this.Label2.Text = "s";
            point = new Point(0xed, 0x29);
            this.Button1.Location = point;
            this.Button1.Name = "Button1";
            size = new Size(0x9f, 0x70);
            this.Button1.Size = size;
            this.Button1.TabIndex = 0x2e;
            this.Button1.Text = "Save interval";
            this.Button1.UseVisualStyleBackColor = true;
            this.CheckBox3.AutoSize = true;
            point = new Point(12, 0x57);
            this.CheckBox3.Location = point;
            this.CheckBox3.Name = "CheckBox3";
            size = new Size(110, 0x11);
            this.CheckBox3.Size = size;
            this.CheckBox3.TabIndex = 0x2f;
            this.CheckBox3.Text = "Autosize Columns";
            this.CheckBox3.UseVisualStyleBackColor = true;
            this.CheckBox4.AutoSize = true;
            this.CheckBox4.Checked = true;
            this.CheckBox4.CheckState = CheckState.Checked;
            point = new Point(12, 0x40);
            this.CheckBox4.Location = point;
            this.CheckBox4.Name = "CheckBox4";
            size = new Size(0xdf, 0x11);
            this.CheckBox4.Size = size;
            this.CheckBox4.TabIndex = 0x30;
            this.CheckBox4.Text = "Visual notification (On server connection)";
            this.CheckBox4.UseVisualStyleBackColor = true;
            SizeF ef = new SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = AutoScaleMode.Font;
            size = new Size(0x195, 0xa7);
            this.ClientSize = size;
            this.Controls.Add(this.CheckBox4);
            this.Controls.Add(this.CheckBox3);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.NumericUpDown1);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.CheckBox2);
            this.Controls.Add(this.Label16);
            this.Controls.Add(this.CheckBox1);
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.Icon = (Icon) manager.GetObject("$this.Icon");
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.NumericUpDown1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            if (Class2.Class4_0.method_6().popupnotify == 1)
            {
                this.CheckBox1.Checked = true;
            }
            if (Class2.Class4_0.method_6().autosize == 1)
            {
                this.CheckBox3.Checked = true;
            }
            if (Class2.Class4_0.method_6().autorefreshact == 1)
            {
                this.NumericUpDown1.Enabled = true;
                this.CheckBox2.Checked = true;
                this.NumericUpDown1.Value = new decimal(Class2.Class4_0.method_6().autorefreshInt);
            }
            else
            {
                this.NumericUpDown1.Enabled = false;
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

        internal virtual CheckBox CheckBox2
        {
            get
            {
                return this._CheckBox2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.CheckBox2_CheckedChanged);
                if (this._CheckBox2 != null)
                {
                    this._CheckBox2.CheckedChanged -= handler;
                }
                this._CheckBox2 = value;
                if (this._CheckBox2 != null)
                {
                    this._CheckBox2.CheckedChanged += handler;
                }
            }
        }

        internal virtual CheckBox CheckBox3
        {
            get
            {
                return this._CheckBox3;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.CheckBox3_CheckedChanged);
                if (this._CheckBox3 != null)
                {
                    this._CheckBox3.CheckedChanged -= handler;
                }
                this._CheckBox3 = value;
                if (this._CheckBox3 != null)
                {
                    this._CheckBox3.CheckedChanged += handler;
                }
            }
        }

        internal virtual CheckBox CheckBox4
        {
            get
            {
                return this._CheckBox4;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.CheckBox4_CheckedChanged);
                if (this._CheckBox4 != null)
                {
                    this._CheckBox4.CheckedChanged -= handler;
                }
                this._CheckBox4 = value;
                if (this._CheckBox4 != null)
                {
                    this._CheckBox4.CheckedChanged += handler;
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

        internal virtual Label Label16
        {
            get
            {
                return this._Label16;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label16 = value;
            }
        }

        internal virtual Label Label2
        {
            get
            {
                return this.daxawBwCf;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this.daxawBwCf = value;
            }
        }

        internal virtual NumericUpDown NumericUpDown1
        {
            get
            {
                return this._NumericUpDown1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._NumericUpDown1 = value;
            }
        }
    }
}

