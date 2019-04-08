using SplitExcel.Office;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;


namespace SplitExcel
{
    public partial class SplitExcel : Form
    {
        private Office.ExcelFileInfo _openedExcelFile = null;
        SplitManager manager;
        private Office.ExcelFileInfo OpenedExcelFile
        {
            get { return _openedExcelFile; }
            set {
                _openedExcelFile = value;
                if (value == null)
                {
                    lblFileName.Text = null;
                    SetControlsEnabled(false);
                }
                else
                {
                    lblFileName.Text = System.IO.Path.GetFileName(value.Path);
                    lblFileName.ForeColor = System.Drawing.SystemColors.Highlight;
                    cmbSheets.SelectedValueChanged -= new System.EventHandler(this.cmbSheets_SelectedValueChanged);
                    cmbSheets.DataSource = value.Sheets;
                    cmbSheets.SelectedValueChanged += new System.EventHandler(this.cmbSheets_SelectedValueChanged);
                    SetControlsEnabled(true);
                    cmbSheets_SelectedValueChanged(null, null);
                }
            }
        }
        public SplitExcel()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.Excel_icon;
            toolStrip1.Renderer = new ToolStripRenderer();
            OpenedExcelFile = null;
            Updater.Updater upd = new Updater.Updater(this);
            upd.DoUpdate();
        }
        public SplitExcel(string filePath) : this()
        {
            ReadExcelFileInfo(filePath);
        }
        private void ReadExcelFileInfo(string path)
        {
            BackgroundWorker bw_ExcelReader = new BackgroundWorker();
            bw_ExcelReader.DoWork += Bw_ExcelReader_DoWork;
            bw_ExcelReader.RunWorkerCompleted += Bw_ExcelReader_RunWorkerCompleted;
            bw_ExcelReader.RunWorkerAsync(path);            
        }
        private void Bw_ExcelReader_DoWork(object sender, DoWorkEventArgs e)
        {
            string filePath = (string)e.Argument;
            string ext = System.IO.Path.GetExtension(filePath).ToLower();
            if (!(ext == ".xls" || ext == ".xlsx" || ext == ".xlsm"))
                throw new Exception($"Это не файл Excel! Расширение - {ext}.\n{filePath}");

            ExcelFileInfo result = null;
            using (Office.UsingExcel excel = new Office.UsingExcel())
                result = excel.ReadExcelFile(filePath);

            e.Result = result;
        }
        private void Bw_ExcelReader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                string message = e.Error.Message;
                if (e.Error.InnerException != null)
                {
                    message += $"\n{e.Error.InnerException.Message}";
                    message += $"\nStackTrace:\n{e.Error.InnerException.StackTrace}";
                }
                
                MessageBox.Show(message, "Ошибка чтения Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.OpenedExcelFile = null;
            }
            else
                this.OpenedExcelFile = (ExcelFileInfo)e.Result;
        }        


        private void SplitFile(Office.SplitFileParameters splParams)
        {
            SetControlsEnabled(false);
            manager = new Office.SplitManager(mnuUseMultiThreads.Checked);
            manager.ProgressChanged += Manager_ProgressChanged;
            manager.SpliterCompleted += Manager_SpliterCompleted;
            manager.StartSplit(splParams);
        }

        private void Manager_SpliterCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message, "Ошибка разделения файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (e.Cancelled)
            {
                lblStatus.Text = $"Отменено. Обработано {manager.ItemsSaved} из { manager.ItemsNumber}";
            }
            else
            {
                lblStatus.Text = "Обработка файла завершена";
            }
            SetControlsEnabled(true);
            btnStart.Enabled = true;
            btnStart.Text = "Начать";
            pbProgress.Style = ProgressBarStyle.Continuous;
            this.manager = null;
        }

        private void Manager_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage > -1)
                pbProgress.Value = e.ProgressPercentage;

            if (e.UserState != null)
                lblStatus.Text = e.UserState.ToString();
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
        private void SetControlsEnabled(bool enabled)
        {
            cmbSheets.Enabled = cmbSplitColumn.Enabled =
            chkShowNumbers.Enabled = txtSplitRowBegin.Enabled = txtSplitRowEnd.Enabled =
            btnRefresh.Enabled = enabled;
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
            var b = sender as Button;
            if (b.Text == "Отмена")
            {
                if (this.manager != null && manager.IsBusy)
                {
                    b.Enabled = false;
                    pbProgress.Style = ProgressBarStyle.Marquee;                    
                    this.manager.CancelAsync();
                }
            }
            else
            {
                try
                {
                    SplitFileParameters param = GetSplitFileParameters();
                    b.Text = "Отмена";
                    SplitFile(param);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

            
        }
        private SplitFileParameters GetSplitFileParameters()
        {
            if (this.OpenedExcelFile == null)
                throw new Exception("Файл не загружен");

            Office.ExcelSheet selectedSheet = OpenedExcelFile.Sheets.FirstOrDefault(a => a.Index == Convert.ToInt32(cmbSheets.SelectedValue));
            string columnSplit = (chkShowNumbers.Checked) ? Office.ExcelLastCell.GetColumnName(Convert.ToInt32(cmbSplitColumn.Text)) : cmbSplitColumn.Text;
            int rowBegin = Convert.ToInt32(txtSplitRowBegin.Text);
            int rowEnd = Convert.ToInt32(txtSplitRowEnd.Text);

            if (rowBegin < 1 || rowBegin > selectedSheet.LastCell.Row || rowEnd < rowBegin || rowEnd > selectedSheet.LastCell.Row)
                throw new Exception("Указан неверный диапазон строк");

            return new Office.SplitFileParameters(OpenedExcelFile.Path, selectedSheet.Index, columnSplit, rowBegin, rowEnd);
        }
        private void OpenFile(object sender, EventArgs e)
        {
            if (this.manager != null && manager.IsBusy)
            {
                MessageBox.Show("Дождитесь завершения операции.", "Программа в процессе..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string path = Dialogs.OpenExcelFileDialog();
            if (!string.IsNullOrEmpty(path))
            {
                ReadExcelFileInfo(path);
            }
            else
            {
                OpenedExcelFile = null;
            }
        }       

        private void mnuUseMultiThreads_Click(object sender, EventArgs e)
        {
            mnuUseMultiThreads.Checked = !mnuUseMultiThreads.Checked;
        }

        private void mnuAbout_Click(object sender, EventArgs e)
        {
            About frmAbout = new About();
            frmAbout.ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (OpenedExcelFile == null)
                return;
            ReadExcelFileInfo(OpenedExcelFile.Path);
        }

        private void SplitExcel_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.manager != null && manager.IsBusy)
            {
                var window = MessageBox.Show("Вы хотите прервать операцию?", "Программа в процессе..", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (window == DialogResult.Yes)
                {
                    btnStart.Enabled = false;
                    pbProgress.Style = ProgressBarStyle.Marquee;
                    this.manager.CancelAsync();
                }
                e.Cancel = true;
            }

            
        }
    }
}
