using SKYNET.Controles;
using SKYNET.Controls;
using SKYNET.Properties;

namespace SKYNET
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }
            catch { }

        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.Tittle = new System.Windows.Forms.Label();
            this.status = new System.Windows.Forms.Label();
            this.linkHP = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.L_State = new System.Windows.Forms.Label();
            this.ClearLabel = new System.Windows.Forms.Timer(this.components);
            this.PN_Top = new System.Windows.Forms.Panel();
            this.BT_MinimizeBox = new SKYNET.Controls.SKYNET_MinimizeBox();
            this.BT_CloseBox = new SKYNET.Controls.SKYNET_CloseBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlMessage = new System.Windows.Forms.Panel();
            this.ResultContainer = new System.Windows.Forms.Panel();
            this.txtMessage = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.LV_FileList = new System.Windows.Forms.ListView();
            this.FileN = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Size = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Paths = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel5 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.LB_FileName = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.BT_Search = new SKYNET.Controls.SKYNET_Button();
            this.PB_Progress = new SKYNET.Controles.SKYNET_ProgressBar();
            this.ListMenu = new SKYNET_ContextMenuStrip();
            this.Open_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenContainer_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.ChangeName_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.Delete_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.TB_Extention = new XNova_Utils.Others.SKYNET_TextBox2();
            this.TB_FilePath = new XNova_Utils.Others.SKYNET_TextBox2();
            this.TB_KeyToFind = new XNova_Utils.Others.SKYNET_TextBox2();
            this.BT_Clear = new SKYNET.Controls.SKYNET_Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.PN_Top.SuspendLayout();
            this.pnlMessage.SuspendLayout();
            this.ResultContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            this.ListMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Tittle
            // 
            this.Tittle.AutoSize = true;
            this.Tittle.Font = new System.Drawing.Font("Segoe UI Emoji", 8.5F, System.Drawing.FontStyle.Bold);
            this.Tittle.ForeColor = System.Drawing.Color.White;
            this.Tittle.Location = new System.Drawing.Point(9, 5);
            this.Tittle.Name = "Tittle";
            this.Tittle.Size = new System.Drawing.Size(177, 16);
            this.Tittle.TabIndex = 7;
            this.Tittle.Text = "[SKYNET] Content Searcher";
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.status.Location = new System.Drawing.Point(14, 441);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(0, 15);
            this.status.TabIndex = 6;
            // 
            // linkHP
            // 
            this.linkHP.AutoSize = true;
            this.linkHP.Font = new System.Drawing.Font("Segoe UI", 7.25F);
            this.linkHP.ForeColor = System.Drawing.Color.White;
            this.linkHP.Location = new System.Drawing.Point(18, 5);
            this.linkHP.Name = "linkHP";
            this.linkHP.Size = new System.Drawing.Size(70, 12);
            this.linkHP.TabIndex = 251;
            this.linkHP.Text = "By Hackerprod";
            this.linkHP.Click += new System.EventHandler(this.label4_Click);
            this.linkHP.MouseLeave += new System.EventHandler(this.linkHP_MouseLeave);
            this.linkHP.MouseMove += new System.Windows.Forms.MouseEventHandler(this.linkHP_MouseMove);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.L_State);
            this.panel2.Location = new System.Drawing.Point(-9, 579);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(793, 36);
            this.panel2.TabIndex = 234;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.linkHP);
            this.panel3.Location = new System.Drawing.Point(687, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(172, 100);
            this.panel3.TabIndex = 253;
            // 
            // L_State
            // 
            this.L_State.AutoSize = true;
            this.L_State.Font = new System.Drawing.Font("Segoe UI", 7.25F);
            this.L_State.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.L_State.Location = new System.Drawing.Point(20, 4);
            this.L_State.Name = "L_State";
            this.L_State.Size = new System.Drawing.Size(0, 12);
            this.L_State.TabIndex = 252;
            this.L_State.MouseHover += new System.EventHandler(this.state_MouseHover);
            this.L_State.MouseMove += new System.Windows.Forms.MouseEventHandler(this.state_MouseMove);
            // 
            // ClearLabel
            // 
            this.ClearLabel.Interval = 5000;
            this.ClearLabel.Tick += new System.EventHandler(this.ClearLabel_Tick);
            // 
            // PN_Top
            // 
            this.PN_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.PN_Top.Controls.Add(this.BT_MinimizeBox);
            this.PN_Top.Controls.Add(this.BT_CloseBox);
            this.PN_Top.Controls.Add(this.label1);
            this.PN_Top.Controls.Add(this.Tittle);
            this.PN_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.PN_Top.Location = new System.Drawing.Point(0, 0);
            this.PN_Top.Name = "PN_Top";
            this.PN_Top.Size = new System.Drawing.Size(776, 28);
            this.PN_Top.TabIndex = 258;
            // 
            // BT_MinimizeBox
            // 
            this.BT_MinimizeBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.BT_MinimizeBox.Color = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.BT_MinimizeBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.BT_MinimizeBox.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(78)))));
            this.BT_MinimizeBox.Location = new System.Drawing.Point(708, 0);
            this.BT_MinimizeBox.MaximumSize = new System.Drawing.Size(34, 26);
            this.BT_MinimizeBox.MinimumSize = new System.Drawing.Size(34, 26);
            this.BT_MinimizeBox.Name = "BT_MinimizeBox";
            this.BT_MinimizeBox.Size = new System.Drawing.Size(34, 26);
            this.BT_MinimizeBox.TabIndex = 254;
            this.BT_MinimizeBox.Clicked += new System.EventHandler(this.MinimizeBox_Clicked);
            // 
            // BT_CloseBox
            // 
            this.BT_CloseBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.BT_CloseBox.Color = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.BT_CloseBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.BT_CloseBox.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(78)))));
            this.BT_CloseBox.Location = new System.Drawing.Point(742, 0);
            this.BT_CloseBox.MaximumSize = new System.Drawing.Size(34, 26);
            this.BT_CloseBox.MinimumSize = new System.Drawing.Size(34, 26);
            this.BT_CloseBox.Name = "BT_CloseBox";
            this.BT_CloseBox.Size = new System.Drawing.Size(34, 26);
            this.BT_CloseBox.TabIndex = 253;
            this.BT_CloseBox.Clicked += new System.EventHandler(this.CloseBox_Clicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 7.25F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(157)))), ((int)(((byte)(160)))));
            this.label1.Location = new System.Drawing.Point(21, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 252;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label3.Location = new System.Drawing.Point(10, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 15);
            this.label3.TabIndex = 269;
            this.label3.Text = "Directory path:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label4.Location = new System.Drawing.Point(528, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 15);
            this.label4.TabIndex = 271;
            this.label4.Text = "Word to search:";
            // 
            // pnlMessage
            // 
            this.pnlMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.pnlMessage.Controls.Add(this.ResultContainer);
            this.pnlMessage.Location = new System.Drawing.Point(12, 545);
            this.pnlMessage.Name = "pnlMessage";
            this.pnlMessage.Padding = new System.Windows.Forms.Padding(1);
            this.pnlMessage.Size = new System.Drawing.Size(554, 28);
            this.pnlMessage.TabIndex = 274;
            this.pnlMessage.Visible = false;
            // 
            // ResultContainer
            // 
            this.ResultContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.ResultContainer.Controls.Add(this.txtMessage);
            this.ResultContainer.Controls.Add(this.pictureBox2);
            this.ResultContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResultContainer.Location = new System.Drawing.Point(1, 1);
            this.ResultContainer.Name = "ResultContainer";
            this.ResultContainer.Size = new System.Drawing.Size(552, 26);
            this.ResultContainer.TabIndex = 2;
            // 
            // txtMessage
            // 
            this.txtMessage.AutoSize = true;
            this.txtMessage.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessage.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.txtMessage.Location = new System.Drawing.Point(30, 5);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(39, 15);
            this.txtMessage.TabIndex = 0;
            this.txtMessage.Text = "label2";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(6, 1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(23, 23);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // LV_FileList
            // 
            this.LV_FileList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.LV_FileList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LV_FileList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FileN,
            this.Size,
            this.Paths});
            this.LV_FileList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LV_FileList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(157)))), ((int)(((byte)(160)))));
            this.LV_FileList.FullRowSelect = true;
            this.LV_FileList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.LV_FileList.HideSelection = false;
            this.LV_FileList.Location = new System.Drawing.Point(1, 1);
            this.LV_FileList.Name = "LV_FileList";
            this.LV_FileList.Size = new System.Drawing.Size(751, 425);
            this.LV_FileList.TabIndex = 282;
            this.LV_FileList.UseCompatibleStateImageBehavior = false;
            this.LV_FileList.View = System.Windows.Forms.View.Details;
            this.LV_FileList.SelectedIndexChanged += new System.EventHandler(this.FileList_SelectedIndexChanged);
            this.LV_FileList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FileList_MouseClick);
            this.LV_FileList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.FileList_MouseDoubleClick);
            // 
            // FileN
            // 
            this.FileN.Text = "Nombre";
            this.FileN.Width = 169;
            // 
            // Size
            // 
            this.Size.Text = "Tamaño";
            this.Size.Width = 73;
            // 
            // Paths
            // 
            this.Paths.Text = "Ubicación";
            this.Paths.Width = 477;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.panel5.Controls.Add(this.label6);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.LB_FileName);
            this.panel5.Location = new System.Drawing.Point(13, 82);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(753, 27);
            this.panel5.TabIndex = 283;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label6.Location = new System.Drawing.Point(245, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 15);
            this.label6.TabIndex = 272;
            this.label6.Text = "Ubication";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label5.Location = new System.Drawing.Point(172, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 15);
            this.label5.TabIndex = 271;
            this.label5.Text = "Size";
            // 
            // LB_FileName
            // 
            this.LB_FileName.AutoSize = true;
            this.LB_FileName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LB_FileName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LB_FileName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.LB_FileName.Location = new System.Drawing.Point(3, 5);
            this.LB_FileName.Name = "LB_FileName";
            this.LB_FileName.Size = new System.Drawing.Size(58, 15);
            this.LB_FileName.TabIndex = 270;
            this.LB_FileName.Text = "File name";
            this.LB_FileName.Click += new System.EventHandler(this.FileName_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label7.Location = new System.Drawing.Point(705, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 15);
            this.label7.TabIndex = 332;
            this.label7.Text = "Extention";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.panel7.Controls.Add(this.LV_FileList);
            this.panel7.Location = new System.Drawing.Point(13, 112);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(1);
            this.panel7.Size = new System.Drawing.Size(753, 427);
            this.panel7.TabIndex = 434;
            // 
            // BT_Search
            // 
            this.BT_Search.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.BT_Search.BackColorMouseOver = System.Drawing.Color.Empty;
            this.BT_Search.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BT_Search.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BT_Search.ForeColor = System.Drawing.Color.White;
            this.BT_Search.ForeColorMouseOver = System.Drawing.Color.Empty;
            this.BT_Search.ImageAlignment = SKYNET.Controls.SKYNET_Button.ImgAlign.Left;
            this.BT_Search.ImageIcon = null;
            this.BT_Search.Location = new System.Drawing.Point(678, 546);
            this.BT_Search.MenuMode = false;
            this.BT_Search.Name = "BT_Search";
            this.BT_Search.Rounded = false;
            this.BT_Search.Size = new System.Drawing.Size(88, 26);
            this.BT_Search.Style = SKYNET.Controls.SKYNET_Button._Style.TextOnly;
            this.BT_Search.TabIndex = 439;
            this.BT_Search.Text = "Search";
            this.BT_Search.Click += new System.EventHandler(this.FileProcess);
            // 
            // PB_Progress
            // 
            this.PB_Progress.BackColor = System.Drawing.Color.Transparent;
            this.PB_Progress.DrawHatch = true;
            this.PB_Progress.Location = new System.Drawing.Point(12, 550);
            this.PB_Progress.Maximum = 100;
            this.PB_Progress.Minimum = 0;
            this.PB_Progress.Name = "PB_Progress";
            this.PB_Progress.ProgressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.PB_Progress.ProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(200)))));
            this.PB_Progress.ShowPercentage = false;
            this.PB_Progress.Size = new System.Drawing.Size(550, 18);
            this.PB_Progress.TabIndex = 433;
            this.PB_Progress.Text = "progressBar1";
            this.PB_Progress.Value = 100;
            this.PB_Progress.ValueAlignment = SKYNET.Controles.SKYNET_ProgressBar.Alignment.Right;
            this.PB_Progress.Visible = false;
            // 
            // ListMenu
            // 
            this.ListMenu.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.ListMenu.ForeColor = System.Drawing.Color.White;
            this.ListMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Open_Menu,
            this.OpenContainer_Menu,
            this.ChangeName_Menu,
            this.Delete_Menu});
            this.ListMenu.Name = "xnovaMenu";
            this.ListMenu.ShowImageMargin = false;
            this.ListMenu.Size = new System.Drawing.Size(198, 92);
            // 
            // Open_Menu
            // 
            this.Open_Menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.Open_Menu.Name = "Open_Menu";
            this.Open_Menu.Size = new System.Drawing.Size(197, 22);
            this.Open_Menu.Text = "Open";
            this.Open_Menu.Click += new System.EventHandler(this.AbrirMenu_Click);
            // 
            // OpenContainer_Menu
            // 
            this.OpenContainer_Menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.OpenContainer_Menu.Name = "OpenContainer_Menu";
            this.OpenContainer_Menu.Size = new System.Drawing.Size(197, 22);
            this.OpenContainer_Menu.Text = "Open Container Folder";
            this.OpenContainer_Menu.Click += new System.EventHandler(this.OpenContainer_Click);
            // 
            // ChangeName_Menu
            // 
            this.ChangeName_Menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.ChangeName_Menu.Name = "ChangeName_Menu";
            this.ChangeName_Menu.Size = new System.Drawing.Size(197, 22);
            this.ChangeName_Menu.Text = "Copy Full Name to Clipboard";
            this.ChangeName_Menu.Click += new System.EventHandler(this.ChangeNameMenu_Click);
            // 
            // Delete_Menu
            // 
            this.Delete_Menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.Delete_Menu.Name = "Delete_Menu";
            this.Delete_Menu.Size = new System.Drawing.Size(197, 22);
            this.Delete_Menu.Text = "Delete File";
            this.Delete_Menu.Click += new System.EventHandler(this.DeleteMenu_Click);
            // 
            // TB_Extention
            // 
            this.TB_Extention.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.TB_Extention.BackColorControl = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(48)))));
            this.TB_Extention.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TB_Extention.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TB_Extention.isCustomColor = false;
            this.TB_Extention.Location = new System.Drawing.Point(726, 50);
            this.TB_Extention.MaxLength = 32767;
            this.TB_Extention.Multiline = false;
            this.TB_Extention.Name = "TB_Extention";
            this.TB_Extention.OnlyNumber = false;
            this.TB_Extention.ReadOnly = false;
            this.TB_Extention.Size = new System.Drawing.Size(38, 26);
            this.TB_Extention.TabIndex = 435;
            this.TB_Extention.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.TB_Extention.UseSystemPasswordChar = false;
            // 
            // TB_FilePath
            // 
            this.TB_FilePath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.TB_FilePath.BackColorControl = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(48)))));
            this.TB_FilePath.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TB_FilePath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TB_FilePath.isCustomColor = false;
            this.TB_FilePath.Location = new System.Drawing.Point(12, 50);
            this.TB_FilePath.MaxLength = 32767;
            this.TB_FilePath.Multiline = false;
            this.TB_FilePath.Name = "TB_FilePath";
            this.TB_FilePath.OnlyNumber = false;
            this.TB_FilePath.ReadOnly = false;
            this.TB_FilePath.Size = new System.Drawing.Size(510, 26);
            this.TB_FilePath.TabIndex = 436;
            this.TB_FilePath.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.TB_FilePath.UseSystemPasswordChar = false;
            // 
            // TB_KeyToFind
            // 
            this.TB_KeyToFind.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.TB_KeyToFind.BackColorControl = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(48)))));
            this.TB_KeyToFind.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TB_KeyToFind.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TB_KeyToFind.isCustomColor = false;
            this.TB_KeyToFind.Location = new System.Drawing.Point(530, 49);
            this.TB_KeyToFind.MaxLength = 32767;
            this.TB_KeyToFind.Multiline = false;
            this.TB_KeyToFind.Name = "TB_KeyToFind";
            this.TB_KeyToFind.OnlyNumber = false;
            this.TB_KeyToFind.ReadOnly = false;
            this.TB_KeyToFind.Size = new System.Drawing.Size(170, 26);
            this.TB_KeyToFind.TabIndex = 437;
            this.TB_KeyToFind.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.TB_KeyToFind.UseSystemPasswordChar = false;
            this.TB_KeyToFind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchText_KeyDown);
            // 
            // BT_Clear
            // 
            this.BT_Clear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.BT_Clear.BackColorMouseOver = System.Drawing.Color.Empty;
            this.BT_Clear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BT_Clear.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BT_Clear.ForeColor = System.Drawing.Color.White;
            this.BT_Clear.ForeColorMouseOver = System.Drawing.Color.Empty;
            this.BT_Clear.ImageAlignment = SKYNET.Controls.SKYNET_Button.ImgAlign.Left;
            this.BT_Clear.ImageIcon = null;
            this.BT_Clear.Location = new System.Drawing.Point(572, 546);
            this.BT_Clear.MenuMode = false;
            this.BT_Clear.Name = "BT_Clear";
            this.BT_Clear.Rounded = false;
            this.BT_Clear.Size = new System.Drawing.Size(100, 26);
            this.BT_Clear.Style = SKYNET.Controls.SKYNET_Button._Style.TextOnly;
            this.BT_Clear.TabIndex = 438;
            this.BT_Clear.Text = "Clear Cache";
            this.BT_Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(708, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(20, 26);
            this.panel1.TabIndex = 283;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "* .";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(776, 606);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BT_Search);
            this.Controls.Add(this.BT_Clear);
            this.Controls.Add(this.TB_KeyToFind);
            this.Controls.Add(this.TB_FilePath);
            this.Controls.Add(this.TB_Extention);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.PB_Progress);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.pnlMessage);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PN_Top);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.status);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.PN_Top.ResumeLayout(false);
            this.PN_Top.PerformLayout();
            this.pnlMessage.ResumeLayout(false);
            this.ResultContainer.ResumeLayout(false);
            this.ResultContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.ListMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label status;
        public System.Windows.Forms.Label linkHP;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Timer ClearLabel;
        private System.Windows.Forms.Panel PN_Top;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label L_State;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel pnlMessage;
        private System.Windows.Forms.Label txtMessage;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel ResultContainer;
        private SKYNET_ContextMenuStrip ListMenu;
        private System.Windows.Forms.ToolStripMenuItem Open_Menu;
        private System.Windows.Forms.ToolStripMenuItem OpenContainer_Menu;
        private System.Windows.Forms.ToolStripMenuItem ChangeName_Menu;
        private System.Windows.Forms.ToolStripMenuItem Delete_Menu;
        private System.Windows.Forms.ListView LV_FileList;
        private System.Windows.Forms.ColumnHeader FileN;
        private System.Windows.Forms.ColumnHeader Size;
        private System.Windows.Forms.ColumnHeader Paths;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label LB_FileName;
        private System.Windows.Forms.Label label7;
        private SKYNET_ProgressBar PB_Progress;
        private System.Windows.Forms.Panel panel7;
        public System.Windows.Forms.Label Tittle;
        private XNova_Utils.Others.SKYNET_TextBox2 TB_Extention;
        private XNova_Utils.Others.SKYNET_TextBox2 TB_FilePath;
        private XNova_Utils.Others.SKYNET_TextBox2 TB_KeyToFind;
        private SKYNET_Button BT_Clear;
        private SKYNET_Button BT_Search;
        private Controls.SKYNET_MinimizeBox BT_MinimizeBox;
        private Controls.SKYNET_CloseBox BT_CloseBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
    }
}