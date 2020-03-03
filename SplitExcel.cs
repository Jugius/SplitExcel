using SplitExcel.Office;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Taskbar;

namespace SplitExcel
{
    public partial class SplitExcel : Form
    {
        private Office.ExcelFileInfo _openedExcelFile = null;
        private SplitFileParameters PrevFinishedParameters = null;
        private bool WaitForFinishingToExit = false;

        private readonly Updater.Updater _updater;

        SplitManager manager;


        private Office.ExcelFileInfo OpenedExcelFile
        {
            get { return _openedExcelFile; }
            set {
                _openedExcelFile = value;
                lblStatus.Text = null;
                groupBox4.Enabled = false;
                pbProgress.Value = 0;
                if (value == null)
                {
                    lblFileName.Text = null;
                    SetControlsEnabled(false);
                    cmbSheets.SelectedValueChanged -= new System.EventHandler(this.cmbSheets_SelectedValueChanged);
                    cmbSheets.Text = cmbSplitColumn.Text = txtSplitRowBegin.Text = txtSplitRowEnd.Text = null;
                    lblNumberOfColumns.Text = "Столбцов:";
                    lblNumberOfRows.Text = "Строк:";
                }
                else
                {
                    lblFileName.Text = System.IO.Path.GetFileName(value.Path);
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
            OpenedExcelFile = null;
            _updater = new Updater.Updater(this);
        }
        public SplitExcel(string filePath) : this()
        {
            ReadExcelFileInfo(filePath);
        }
        private async void ReadExcelFileInfo(string path)
        {
            try
            {
                string ext = System.IO.Path.GetExtension(path).ToLower();
                if (!(ext == ".xls" || ext == ".xlsx" || ext == ".xlsm"))
                    throw new Exception($"Это не файл Excel! Расширение - {ext}.\n{path}");

                ExcelFileInfo result = await Task<ExcelFileInfo>.Factory.StartNew(() => 
                {
                    using (Office.UsingExcel excel = new Office.UsingExcel())
                        return excel.ReadExcelFileInfo(path);
                });               

                this.OpenedExcelFile = result;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null)
                {
                    message += $"\n{ex.InnerException.Message}";
                    message += $"\nStackTrace:\n{ex.InnerException.StackTrace}";
                }
                MessageBox.Show(message, "Ошибка чтения Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.OpenedExcelFile = null;
            }
        }
        private void SplitFile(Office.SplitFileParameters splParams)
        {
            SetControlsEnabled(false);
            manager = new Office.SplitManager(mnuUseMultiThreads.Checked);
            manager.ProgressChanged += Manager_ProgressChanged;
            manager.SpliterCompleted += Manager_SpliterCompleted;
            groupBox4.Enabled = true;
            this.PrevFinishedParameters = null;

            TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal, Handle);
            TaskbarManager.Instance.SetProgressValue(0, 100, Handle);

            manager.StartSplit(splParams);
        }

        private void Manager_SpliterCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Error, Handle);
                MessageBox.Show(e.Error.Message, "Ошибка разделения файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (e.Cancelled)
            {
                lblStatus.Text = $"Отменено. Обработано {manager.ItemsSaved} из { manager.ItemsNumber}";
            }
            else
            {                
                string message = $"Завершено успешно. Создано {manager.ItemsSaved} файлов.";
                MessageBox.Show(message, "Завершено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SplitFileParameters p = e.Result as SplitFileParameters;
                System.Diagnostics.Process.Start(System.IO.Path.GetDirectoryName(p.FilePath));
                lblStatus.Text = "Обработка файла завершена";
                this.PrevFinishedParameters = p;
            }
            SetControlsEnabled(true);
            btnStart.Enabled = true;
            btnStart.Text = "Начать";
            pbProgress.Style = ProgressBarStyle.Continuous;
            TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress, Handle);
            this.manager = null;
            if (this.WaitForFinishingToExit) Application.Exit();
        }

        private void Manager_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage > -1)
            {
                pbProgress.Value = e.ProgressPercentage;
                TaskbarManager.Instance.SetProgressValue(e.ProgressPercentage, 100, Handle);
            }
            

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
                    TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Indeterminate, Handle);
                    this.manager.CancelAsync();
                }
            }
            else
            {
                try
                {
                    SplitFileParameters param = GetSplitFileParameters();
                    if (param.Equals(this.PrevFinishedParameters))
                    {
                        const string mess = "Вы хотите порезать файл с теми же параметрами, как резали до этого. Вероятно, результат будет такой же.\n\nВы хотите продолжить?";
                        if (MessageBox.Show(mess, "Повторить?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                    }
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
            string path = null;
            using (OpenFileDialog f = new OpenFileDialog())
            {
                f.Filter = "Файлы Excel|*.xls;*.xlsx;*.xlsm";
                f.Title = "Выберите файл";                                
                if (f.ShowDialog(this) == DialogResult.OK)
                    path = f.FileName;
            }

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
                    TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Indeterminate, Handle);
                    this.manager.CancelAsync();
                }
                this.WaitForFinishingToExit = true;
                e.Cancel = true;
            }            
        }

        private void btnSettings_MouseDown(object sender, MouseEventArgs e)
        {
            Point screenPoint = btnSettings.PointToScreen(new Point(btnSettings.Left, btnSettings.Bottom));
            if (screenPoint.Y + mnuSettings.Size.Height > Screen.PrimaryScreen.WorkingArea.Height)
            {
                mnuSettings.Show(btnSettings, new Point(0, -mnuSettings.Size.Height));
            }
            else
            {
                mnuSettings.Show(btnSettings, new Point(0, btnSettings.Height));
            }
        }

        private void btnAbout_MouseDown(object sender, MouseEventArgs e)
        {
            Point screenPoint = btnSettings.PointToScreen(new Point(btnSettings.Left, btnSettings.Bottom));
            if (screenPoint.Y + mnuSettings.Size.Height > Screen.PrimaryScreen.WorkingArea.Height)
            {
                mnuAbout.Show(btnSettings, new Point(0, -mnuSettings.Size.Height));
            }
            else
            {
                mnuAbout.Show(btnSettings, new Point(0, btnSettings.Height));
            }
        }

        private void mnuShowAbout_Click(object sender, EventArgs e)
        {
            new About().ShowDialog(this);
        }

        private void mnuSendLetter_Click(object sender, EventArgs e)
        {
            string mailto = @"mailto:support@oohelp.net?Subject=Message from app: SplitExcel";
            mailto = System.Uri.EscapeUriString(mailto);
            System.Diagnostics.Process.Start(mailto);
        }

        private void mnuHelp_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://oohelp.net/splitexcel/#splitexcel_howto");
        }

        private void MnuCheckUpdates_Click(object sender, EventArgs e)
        {
            this._updater.DoUpdate(Updater.UpdateMethod.Manual);
        }

        private void SplitExcel_Shown(object sender, EventArgs e)
        {
            _updater.DoUpdate(global::Updater.UpdateMethod.DownloadAndUpdateOnRequest);
        }
    }
}
