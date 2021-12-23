using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Linq;
using System.ComponentModel;
using System.IO;                   
using System.Text;                
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using SKYNET.GUI;

namespace SKYNET
{
    public partial class frmMain : frmBase
    {
        public static frmMain frm;
        public static SearchManager SearchManager;
        public static CacheManager cacheManager;

        private DateTime started;
        private string fileSelected;

        public frmMain()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;  //Para permitir acceso a los subprocesos
            frm = this;
            base.SetMouseMove(PN_Top);

            HideProgress(false);
            DoubleBuffered = true;

            for (int i = 0; i < Controls.Count; i++)
            {
                DoubleBufferedToAllControls(Controls[i]);
            }

            InitializeSearchManager();

            string cachePath = Path.Combine(modCommon.GetPath(), "Data", "Cache");
            modCommon.EnsureDirectoryExists(cachePath);
            cacheManager = new CacheManager(cachePath);
            cacheManager.Load();

        }

        private void InitializeSearchManager()
        {
            SearchManager = new SearchManager();
            SearchManager.OnProgressChanged += SearchManager_OnProgressChanged;
            SearchManager.OnFileFounded += SearchManager_OnFileFounded;
            SearchManager.OnSearchStarted += SearchManager_OnSearchStarted;
            SearchManager.OnSearchCompleted += SearchManager_OnSearchCompleted;
            SearchManager.OnSearchCancelled += SearchManager_OnSearchCancelled;
        }

        public static void Write(object v)
        {
            modCommon.InvokeAction(frm.L_State, () =>
            {
                frm.L_State.Text = v.ToString();
            });
        }

        private void SearchManager_OnSearchCancelled(object sender, int e)
        {
            modCommon.InvokeAction(PB_Progress, () =>
            {
                PB_Progress.Visible = false;
            });
            SetFinished(e, true);
        }

        private void SearchManager_OnSearchStarted(object sender, DateTime start)
        {
            started = start;
            Write($"Searching files...");

            modCommon.InvokeAction(PB_Progress, () =>
            {
                PB_Progress.Visible = true;
                PB_Progress.Maximum = 100;
                PB_Progress.Value = 0;
            });

            ResultContainer.Visible = false;
        }

        private void SearchManager_OnFileFounded(object sender, FileDetails e)
        {
            AddItem(e.FileName, e.FileSize, e.FilePath);
        }

        private void SearchManager_OnProgressChanged(object sender, int e)
        {
            try
            {
                PB_Progress.Value = e;
                PB_Progress.Maximum = SearchManager.Files.Count;
            }
            catch (Exception)
            {
                
            }
        }

        private void SearchManager_OnSearchCompleted(object sender, int e)
        {
            SetFinished(e, false);
            modCommon.InvokeAction(PB_Progress, () =>
            {
                PB_Progress.Visible = false;
            });
        }

        private void DoubleBufferedToAllControls(object control)
        {
            control.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(RuntimeHelpers.GetObjectValue(control), true, null);
            
            if (((Control)control).HasChildren)
            {
                for (int i = 0; i < ((Control)control).Controls.Count; i++)
                {
                    DoubleBufferedToAllControls(((Control)control).Controls[i]);
                }
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (modCommon.Hackerprod)
            {
                // For tests only
                TB_FilePath.Text = @"D:\Instaladores\Programación\Projects";
                TB_KeyToFind.Text = "modCommon";
                TB_Extention.Text = "cs";
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Process.Start("www.facebook.com/HackerprodLive");
        }

        private void linkHP_MouseMove(object sender, MouseEventArgs e)
        {
            linkHP.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void linkHP_MouseLeave(object sender, EventArgs e)
        {
            linkHP.ForeColor = Color.FromArgb(147, 157, 160);
        }


        private void ClearLabel_Tick(object sender, EventArgs e)
        {
            pnlMessage.Visible = false;
            ClearLabel.Enabled = false;
        }
        private void FilePath_DoubleClick(object sender, EventArgs e)
        {
            FolderBrowserDialog serverloc_patch = new FolderBrowserDialog();
            serverloc_patch.ShowDialog();
            TB_FilePath.Text = serverloc_patch.SelectedPath;
        }

        private void FileProcess(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TB_FilePath.Text))
            {
                modCommon.Show("To continue you must specify the path where you want to search the files");
                return;
            }
            if (string.IsNullOrEmpty(TB_Extention.Text))
            {
                modCommon.Show("To continue you must specify a phrase or word to search into the files");
                return;
            }
            switch (BT_Search.Text)
            {
                case "Search":
                    BT_Search.Text = "Cancel";
                    FileList.Items.Clear();
                    InitializeSearchManager();
                    SearchManager.Initialize(TB_FilePath.Text, TB_KeyToFind.Text, TB_Extention.Text);
                    SearchManager.Search();
                    Write("Creating file list");
                    break;
                case "Cancel":
                    BT_Search.Text = "Search";
                    SearchManager.Dispose();
                    break;
            }

        }


        private void SetFinished(int count, bool canceled)
        {
            
            string msg = canceled ?
                "Search stopped, canceled by user" :
                "The search finished correctly with " + FileList.Items.Count.ToString() + " coincidences";
            ShowControl(msg);

            modCommon.InvokeAction(ResultContainer, () => { ResultContainer.Visible = true; });

            TimeSpan span = DateTime.Now - started;
            Write("The search finished in " + string.Format(CultureInfo.CurrentCulture, $"{span.Minutes} minutes, {span.Seconds} seconds, {span.Milliseconds} milliseconds, {count} files searched"));
            HideProgress(false);
            BT_Search.Text = "Search";
        }


        #region ListView
        private ListViewItem.ListViewSubItem fname;
        private ListViewItem.ListViewSubItem fsize;
        private ListViewItem.ListViewSubItem fpath;
        private ListViewItem.ListViewSubItem ficon;

        private void AddItem(string fileName, long fileSize, string FilePath, string Icon = "")
        {
            string FileSize = modCommon.LongToMbytes(fileSize);
            ListViewItem listViewItem = new ListViewItem();

            listViewItem.SubItems.Add(fileName);
            listViewItem.SubItems.Add(FileSize);
            listViewItem.SubItems.Add(FilePath);

            fname = new ListViewItem.ListViewSubItem();
            fsize = new ListViewItem.ListViewSubItem();
            fpath = new ListViewItem.ListViewSubItem();
            ficon = new ListViewItem.ListViewSubItem();

            listViewItem.SubItems.Add(fname);
            listViewItem.SubItems.Add(fsize);
            listViewItem.SubItems.Add(fpath);
            listViewItem.SubItems.Add(ficon);

            listViewItem.SubItems[0].Text = fileName;
            listViewItem.SubItems[1].Text = FileSize;
            listViewItem.SubItems[2].Text = FilePath;

            modCommon.InvokeAction(FileList, ()=> { FileList.Items.Add(listViewItem); });

        }
        #endregion


        private void ShowControl(string message)
        {

            modCommon.InvokeAction(pnlMessage, () => { pnlMessage.Visible = true; });
            modCommon.InvokeAction(txtMessage, () => { txtMessage.Text = message; });

            ClearLabel.Enabled = true;
        }


        private void HideProgress(bool show)
        {
            /*if (show)
                this.progressBar1.Location = new System.Drawing.Point(6, 519);
            else
                progressBar1.Location = new System.Drawing.Point(1000, 1000);*/
        }

        private void FileList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string filePath = FileList.SelectedItems[0].SubItems[2].Text;
                string FileName = System.IO.Path.GetFileName(filePath);
                string FileSize = modCommon.LongToMbytes(new FileInfo(filePath).Length);
                Write("Name: " + FileName + " Size: " + FileSize + " Path: " + filePath);
            }
            catch { }
        }

        private void state_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void state_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(L_State, L_State.Text);
        }

        private void FileList_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            try
            {
                string filePath = FileList.SelectedItems[0].SubItems[2].Text;
                Process.Start(filePath);
            }
            catch { }
        }

        private void FileList_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                fileSelected = FileList.SelectedItems[0].SubItems[2].Text;
                if (e.Button == MouseButtons.Right && FileList.FocusedItem.Bounds.Contains(e.Location))
                {
                    ListMenu.Show(Cursor.Position);
                }
            }
            catch
            {
            }
        }

        private void AbrirMenu_Click(object sender, EventArgs e)
        {
            Process.Start(fileSelected);
        }

        private void OpenContainer_Click(object sender, EventArgs e)
        {
            modCommon.OpenFolderAndSelectFile(fileSelected);
        }

        private void ChangeNameMenu_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText(fileSelected, TextDataFormat.UnicodeText);

        }

        private void DeleteMenu_Click(object sender, EventArgs e)
        {
            try
            {
                File.Delete(fileSelected);
            }
            catch { }
        }

        private void SearchText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Enter)
                return;
        }

        private void FileName_Click(object sender, EventArgs e)
        {
            switch (FileList.Sorting)
            {
                case SortOrder.None:
                    FileList.Sorting = SortOrder.Ascending;
                    break;
                case SortOrder.Ascending:
                    FileList.Sorting = SortOrder.Descending;
                    break;
                case SortOrder.Descending:
                    FileList.Sorting = SortOrder.Ascending;
                    break;
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            var Result = MessageBox.Show("Are you sure?", "Clear cache", MessageBoxButtons.YesNo);
            if (Result == DialogResult.Yes)
            {
                cacheManager.Clear();
            }
        }

        private void MinimizeBox_Clicked(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void CloseBox_Clicked(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }

}
