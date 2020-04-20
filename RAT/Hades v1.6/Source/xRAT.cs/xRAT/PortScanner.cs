namespace xRAT
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Net;
    using System.Net.Sockets;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Windows.Forms;

    [DesignerGenerated]
    public class PortScanner : Form
    {
        [AccessedThroughProperty("Button1")]
        private Button _Button1;
        [AccessedThroughProperty("Label2")]
        private Label _Label2;
        [AccessedThroughProperty("Label3")]
        private Label _Label3;
        [AccessedThroughProperty("Label4")]
        private Label _Label4;
        [AccessedThroughProperty("Label5")]
        private Label _Label5;
        [AccessedThroughProperty("ListBox1")]
        private ListBox _ListBox1;
        [AccessedThroughProperty("NumericUpDown1")]
        private NumericUpDown _NumericUpDown1;
        [AccessedThroughProperty("NumericUpDown2")]
        private NumericUpDown _NumericUpDown2;
        [AccessedThroughProperty("NumericUpDown3")]
        private NumericUpDown _NumericUpDown3;
        [AccessedThroughProperty("ProgressBar1")]
        private ProgressBar _ProgressBar1;
        [AccessedThroughProperty("TextBox1")]
        private TextBox _TextBox1;
        private bool bool_0;
        private IContainer icontainer_0;

        public PortScanner()
        {
            Class1.QaIGh5M7cuigS();
            this.InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (this.bool_0)
            {
                this.method_2(true);
            }
            else
            {
                this.method_2(false);
                this.ListBox1.Items.Clear();
                this.ProgressBar1.Maximum = Convert.ToInt32(decimal.Add(this.NumericUpDown2.Value, decimal.One));
                this.ProgressBar1.Minimum = Convert.ToInt32(this.NumericUpDown1.Value);
                this.ProgressBar1.Value = Convert.ToInt32(this.NumericUpDown1.Value);
                try
                {
                    IPAddress address = this.method_0(this.TextBox1.Text);
                    int num = 0;
                    do
                    {
                        new Thread(new ParameterizedThreadStart(this.method_3)).Start(new object[] { decimal.Add(this.NumericUpDown1.Value, new decimal(num)), this.NumericUpDown2.Value, 8, address, this.NumericUpDown3.Value });
                        num++;
                    }
                    while (num <= 7);
                }
                catch (Exception exception1)
                {
                    ProjectData.SetProjectError(exception1);
                    ProjectData.ClearProjectError();
                }
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
            ComponentResourceManager manager = new ComponentResourceManager(typeof(PortScanner));
            this.NumericUpDown1 = new NumericUpDown();
            this.NumericUpDown2 = new NumericUpDown();
            this.TextBox1 = new TextBox();
            this.Label2 = new Label();
            this.Label3 = new Label();
            this.ListBox1 = new ListBox();
            this.NumericUpDown3 = new NumericUpDown();
            this.Label4 = new Label();
            this.Button1 = new Button();
            this.Label5 = new Label();
            this.ProgressBar1 = new ProgressBar();
            this.NumericUpDown1.BeginInit();
            this.NumericUpDown2.BeginInit();
            this.NumericUpDown3.BeginInit();
            this.SuspendLayout();
            this.NumericUpDown1.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            Point point = new Point(0x80, 70);
            this.NumericUpDown1.Location = point;
            decimal num = new decimal(new int[] { 0xffff, 0, 0, 0 });
            this.NumericUpDown1.Maximum = num;
            this.NumericUpDown1.Name = "NumericUpDown1";
            Size size = new Size(60, 0x15);
            this.NumericUpDown1.Size = size;
            this.NumericUpDown1.TabIndex = 2;
            this.NumericUpDown1.TextAlign = HorizontalAlignment.Center;
            this.NumericUpDown2.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0xc2, 70);
            this.NumericUpDown2.Location = point;
            num = new decimal(new int[] { 0xffff, 0, 0, 0 });
            this.NumericUpDown2.Maximum = num;
            this.NumericUpDown2.Name = "NumericUpDown2";
            size = new Size(60, 0x15);
            this.NumericUpDown2.Size = size;
            this.NumericUpDown2.TabIndex = 3;
            this.NumericUpDown2.TextAlign = HorizontalAlignment.Center;
            this.TextBox1.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x80, 0x19);
            this.TextBox1.Location = point;
            this.TextBox1.Name = "TextBox1";
            size = new Size(0x7e, 0x15);
            this.TextBox1.Size = size;
            this.TextBox1.TabIndex = 4;
            this.TextBox1.Text = "127.0.0.1";
            this.TextBox1.TextAlign = HorizontalAlignment.Center;
            this.Label2.AutoSize = true;
            this.Label2.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x7d, 0x36);
            this.Label2.Location = point;
            Padding padding = new Padding(3, 5, 3, 0);
            this.Label2.Margin = padding;
            this.Label2.Name = "Label2";
            size = new Size(70, 13);
            this.Label2.Size = size;
            this.Label2.TabIndex = 5;
            this.Label2.Text = "Port Range";
            this.Label3.AutoSize = true;
            this.Label3.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x7d, 9);
            this.Label3.Location = point;
            this.Label3.Name = "Label3";
            size = new Size(0x2c, 13);
            this.Label3.Size = size;
            this.Label3.TabIndex = 7;
            this.Label3.Text = "Target";
            this.ListBox1.FormattingEnabled = true;
            point = new Point(15, 0x19);
            this.ListBox1.Location = point;
            this.ListBox1.Name = "ListBox1";
            size = new Size(0x6b, 0xba);
            this.ListBox1.Size = size;
            this.ListBox1.TabIndex = 8;
            this.NumericUpDown3.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x80, 0x73);
            this.NumericUpDown3.Location = point;
            num = new decimal(new int[] { 0xea60, 0, 0, 0 });
            this.NumericUpDown3.Maximum = num;
            this.NumericUpDown3.Name = "NumericUpDown3";
            size = new Size(0x7e, 0x15);
            this.NumericUpDown3.Size = size;
            this.NumericUpDown3.TabIndex = 9;
            this.NumericUpDown3.TextAlign = HorizontalAlignment.Center;
            num = new decimal(new int[] { 800, 0, 0, 0 });
            this.NumericUpDown3.Value = num;
            this.Label4.AutoSize = true;
            this.Label4.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x81, 0x63);
            this.Label4.Location = point;
            padding = new Padding(3, 5, 3, 0);
            this.Label4.Margin = padding;
            this.Label4.Name = "Label4";
            size = new Size(0x35, 13);
            this.Label4.Size = size;
            this.Label4.TabIndex = 10;
            this.Label4.Text = "Timeout";
            this.Button1.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x80, 180);
            this.Button1.Location = point;
            this.Button1.Name = "Button1";
            size = new Size(0x7e, 0x1f);
            this.Button1.Size = size;
            this.Button1.TabIndex = 11;
            this.Button1.Text = "Scan Ports";
            this.Button1.UseVisualStyleBackColor = true;
            this.Label5.AutoSize = true;
            this.Label5.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(12, 9);
            this.Label5.Location = point;
            this.Label5.Name = "Label5";
            size = new Size(70, 13);
            this.Label5.Size = size;
            this.Label5.TabIndex = 12;
            this.Label5.Text = "Open Ports";
            point = new Point(0x80, 0x97);
            this.ProgressBar1.Location = point;
            this.ProgressBar1.Name = "ProgressBar1";
            size = new Size(0x7e, 0x17);
            this.ProgressBar1.Size = size;
            this.ProgressBar1.TabIndex = 13;
            SizeF ef = new SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = AutoScaleMode.Font;
            size = new Size(0x108, 0xdd);
            this.ClientSize = size;
            this.Controls.Add(this.ProgressBar1);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.NumericUpDown3);
            this.Controls.Add(this.ListBox1);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.TextBox1);
            this.Controls.Add(this.NumericUpDown2);
            this.Controls.Add(this.NumericUpDown1);
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.Icon = (Icon) manager.GetObject("$this.Icon");
            this.MaximizeBox = false;
            this.Name = "PortScanner";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Port Scanner";
            this.NumericUpDown1.EndInit();
            this.NumericUpDown2.EndInit();
            this.NumericUpDown3.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private IPAddress method_0(string string_0)
        {
            return Dns.GetHostEntry(string_0).AddressList[0];
        }

        private bool method_1(IPAddress ipaddress_0, int int_0, int int_1)
        {
            bool flag;
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                socket.BeginConnect(ipaddress_0, int_0, null, 0);
                DateTime time = DateAndTime.Now.AddMilliseconds((double) int_1);
                while (DateTime.Compare(DateAndTime.Now, time) < 0)
                {
                    Thread.Sleep(1);
                    if (socket.Connected)
                    {
                        goto Label_0049;
                    }
                }
                return flag;
            Label_0049:
                flag = true;
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                ProjectData.ClearProjectError();
            }
            finally
            {
                if (socket != null)
                {
                    socket.Dispose();
                }
            }
            return flag;
        }

        private void method_2(bool bool_1)
        {
            this.NumericUpDown1.Enabled = bool_1;
            this.NumericUpDown2.Enabled = bool_1;
            this.NumericUpDown3.Enabled = bool_1;
            this.Button1.Text = bool_1 ? "Begin" : "Cancel";
            this.bool_0 = !bool_1;
        }

        private void method_3(object object_0)
        {
            object obj2;
            object obj3;
            if (ObjectFlowControl.ForLoopControl.ForLoopInitObj(obj2, NewLateBinding.LateIndexGet(object_0, new object[] { 0 }, null), NewLateBinding.LateIndexGet(object_0, new object[] { 1 }, null), NewLateBinding.LateIndexGet(object_0, new object[] { 2 }, null), ref obj3, ref obj2))
            {
                while (this.bool_0)
                {
                    this.method_4(this.method_1((IPAddress) NewLateBinding.LateIndexGet(object_0, new object[] { 3 }, null), Conversions.ToInteger(obj2), Conversions.ToInteger(NewLateBinding.LateIndexGet(object_0, new object[] { 4 }, null))), Conversions.ToInteger(obj2));
                    if (!ObjectFlowControl.ForLoopControl.ForNextCheckObj(obj2, obj3, ref obj2))
                    {
                        break;
                    }
                }
            }
        }

        private void method_4(bool bool_1, int int_0)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new OD(this.method_4), new object[] { bool_1, int_0 });
            }
            else
            {
                if (bool_1)
                {
                    this.ListBox1.Items.Add(int_0);
                }
                ProgressBar bar = this.ProgressBar1;
                bar.Value++;
                if (this.ProgressBar1.Value == this.ProgressBar1.Maximum)
                {
                    this.method_2(true);
                }
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

        internal virtual Label Label5
        {
            get
            {
                return this._Label5;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label5 = value;
            }
        }

        internal virtual ListBox ListBox1
        {
            get
            {
                return this._ListBox1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ListBox1 = value;
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

        internal virtual NumericUpDown NumericUpDown2
        {
            get
            {
                return this._NumericUpDown2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._NumericUpDown2 = value;
            }
        }

        internal virtual NumericUpDown NumericUpDown3
        {
            get
            {
                return this._NumericUpDown3;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._NumericUpDown3 = value;
            }
        }

        internal virtual ProgressBar ProgressBar1
        {
            get
            {
                return this._ProgressBar1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ProgressBar1 = value;
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

        public delegate void OD(bool open, int port);
    }
}

