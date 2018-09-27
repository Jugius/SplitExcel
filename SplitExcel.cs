using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using Updater;

namespace SplitExcel
{
    public partial class SplitExcel : Form
    {
        private Office.ExcelBook OpenedExcelFile;
        private int ItemsNumber;
        private int ItemsSplitted;
        private int ThreadsNumber;
        private int ThreadsFinished;
        Stopwatch timer;
        Updater.Updater updater;

        public SplitExcel()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.Excel_icon;
            this.updater = new Updater.Updater(this);
            LockControls();
        }
        public SplitExcel(string filePath) : this()
        {
            LoadExcelFile(filePath);
        }
        
        private void LoadExcelFile(string filePath)
        {                        
            try
            {
                this.OpenedExcelFile = Dialogs.GetExcelFileInformation(filePath);
                lblFileName.Text = System.IO.Path.GetFileName(OpenedExcelFile.FilePath);
                cmbSheets.Enabled = cmbSplitColumn.Enabled = true;
                cmbSheets.SelectedValueChanged -= new System.EventHandler(this.cmbSheets_SelectedValueChanged);
                cmbSheets.DataSource = OpenedExcelFile.Sheets;
                cmbSheets.SelectedValueChanged += new System.EventHandler(this.cmbSheets_SelectedValueChanged);
                UnlockControls();
                cmbSheets_SelectedValueChanged(null, null);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void SplitFile(Office.SplitFileParameters splParams)
        {
            try {
                LockControls();
                List<string> list = Dialogs.ReadSplitValuesList(splParams);
                lblSplitFounded.Text = "Найдено вариантов:  " + list.Count;
                if (list == null ||list.Count == 0) return;
                pbProgress.Maximum = ItemsNumber = list.Count;
                pbProgress.Value = ItemsSplitted = 0;

                List<List<string>> splittedList = Dialogs.SplitList(list, mnuUseMultiThreads.Checked);
                ThreadsNumber = splittedList.Count;
                ThreadsFinished = 0;
                //string message = $"Have {splittedList.Count} threads for total {list.Count} items:";
                //for (int i = 0; i < splittedList.Count; i++)
                //    message += $"\nThread {i+1} has {splittedList[i].Count} items";

                //MessageBox.Show(message);
                timer = new Stopwatch();
                timer.Start();
                foreach (List<string> l in splittedList)
                {
                    Office.SplitThread thread = new Office.SplitThread(l, splParams);
                    SubscribeEvents(thread);
                    Thread t = new Thread(thread.SplitExcelFile);
                    t.IsBackground = true;
                    t.Priority = ThreadPriority.Highest;
                    t.Start();
                }
            }
            catch (Exception ex) {
                UnlockControls();
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SubscribeEvents(Office.SplitThread splitThread)
        {
            splitThread.NewFileSaved += delegate (string s)
            {
                if (InvokeRequired) Invoke(new Action<string>(i => OnNewFileSaved(i)), s);
                else OnNewFileSaved(s);
            };
            splitThread.ThreadFinished += delegate (Office.SplitThread thread)
            {
                if (InvokeRequired) Invoke(new Action<Office.SplitThread>(i => OnThreadFinished(i)), thread);
                else OnThreadFinished(thread);
            };
        }
        private void OnNewFileSaved(string s)
        {
            ItemsSplitted++;
            label1.Text = $"Сохранено: {s} ({ItemsSplitted} / {ItemsNumber})";
            pbProgress.Value += 1;
        }
        private void OnThreadFinished(Office.SplitThread thread)
        {
            ThreadsFinished++;
            thread.Dispose();
            thread = null;
            if (ThreadsFinished == ThreadsNumber)
            {
                timer.Stop();
                lblSplitFounded.Text = string.Empty;
                label1.ForeColor = System.Drawing.Color.SteelBlue;
                label1.Font = new System.Drawing.Font("Calibri", 9.75f, System.Drawing.FontStyle.Bold);
                label1.Text = "Обработка файла завершена за " + timer.Elapsed;
                UnlockControls();
            }
        }

        private void FillColumnsCombo()
        {
            if (OpenedExcelFile == null)
                return;
            int i = Convert.ToInt32(cmbSheets.SelectedValue);
            Office.ExcelSheet sh = OpenedExcelFile.Sheets.FirstOrDefault(a => a.Index == i);
            FillColumnsCombo(sh);
        }
        private void FillColumnsCombo(Office.ExcelSheet sh)
        {
            cmbSplitColumn.DataSource = sh.LastCell.Columns((chkShowNumbers.Checked) ? Office.ExcelLastCell.ColumnsType.Numeric : Office.ExcelLastCell.ColumnsType.String);
        } 

        private void cmbSheets_SelectedValueChanged(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(cmbSheets.SelectedValue);
            Office.ExcelSheet sh = OpenedExcelFile.Sheets.FirstOrDefault(a => a.Index == i);
            lblNumberOfColumns.Text = $"Столбцов: {sh.LastCell.Column}";
            lblNumberOfRows.Text = $"Строк: {sh.LastCell.Row}";
            FillColumnsCombo(sh);
            txtSplitRowBegin.Text = "2";
            txtSplitRowEnd.Text = sh.LastCell.Row.ToString();
        }

        private void chkShowNumbers_CheckedChanged(object sender, EventArgs e)
        {
            FillColumnsCombo();
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.OpenedExcelFile == null)
                    throw new Exception("Файл не загружен");

                Office.ExcelSheet selectedSheet = OpenedExcelFile.Sheets.FirstOrDefault(a => a.Index == Convert.ToInt32(cmbSheets.SelectedValue));
                string columnSplit = (chkShowNumbers.Checked) ? Office.ExcelLastCell.GetColumnName(Convert.ToInt32(cmbSplitColumn.Text)) : cmbSplitColumn.Text;
                int rowBegin = Convert.ToInt32(txtSplitRowBegin.Text);
                int rowEnd = Convert.ToInt32(txtSplitRowEnd.Text);

                if (rowBegin < 1 || rowBegin > selectedSheet.LastCell.Row || rowEnd < rowBegin || rowEnd > selectedSheet.LastCell.Row)
                    throw new Exception("Указан неверный диапазон строк");

                Office.SplitFileParameters splParams = new Office.SplitFileParameters(OpenedExcelFile.FilePath, selectedSheet.Index, columnSplit, rowBegin, rowEnd);                
                SplitFile(splParams);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void OpenFile(object sender, EventArgs e)
        {
            string exFile = Dialogs.OpenExcelFileDialog();
            if (exFile == null || exFile == string.Empty)
                return;
            LoadExcelFile(exFile);
        }
        private void LockControls()
        {
            cmbSheets.Enabled = cmbSplitColumn.Enabled = btnStart.Enabled = chkShowNumbers.Enabled = txtSplitRowBegin.Enabled = txtSplitRowEnd.Enabled = false;
        }
        private void UnlockControls()
        {
            cmbSheets.Enabled = cmbSplitColumn.Enabled = btnStart.Enabled = chkShowNumbers.Enabled = txtSplitRowBegin.Enabled = txtSplitRowEnd.Enabled = true;
        }

        private void mnuUseMultiThreads_Click(object sender, EventArgs e)
        {
            mnuUseMultiThreads.Checked = !mnuUseMultiThreads.Checked;
        }

        private void SplitExcel_HelpButtonClicked(object sender, System.ComponentModel.CancelEventArgs e)
        {
            About frmAbout = new About();
            frmAbout.ShowDialog();
        }

        private void mnuAbout_Click(object sender, EventArgs e)
        {
            About frmAbout = new About();
            frmAbout.ShowDialog();
        }
        private void mnuCheckUpdate_Click(object sender, EventArgs e)
        {
            this.updater.DoUpdate(UpdateMethod.DownloadAndUpdateOnRequest);
        }

        private void SplitExcel_Shown(object sender, EventArgs e)
        {
            this.updater.DoUpdate(UpdateMethod.Automatic);
        }
    }
}
