using System.Collections.Generic;
using System.ComponentModel;
using Excel = Microsoft.Office.Interop.Excel;


namespace SplitExcel.Office
{
    internal sealed class SplitThread : IExcelProcessor
    {               
        private SplitFileParameters Parameters { get; }

        internal SplitThread(SplitFileParameters splitParameters)
        {
            Parameters = splitParameters;
        }
        internal void SplitExcelFile(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = sender as BackgroundWorker;
            List<string> splitValues = e.Argument as List<string>;            

            string fileExt = System.IO.Path.GetExtension(Parameters.FilePath);
            string filename = System.IO.Path.GetFileNameWithoutExtension(Parameters.FilePath);
            string fileDir = System.IO.Path.GetDirectoryName(Parameters.FilePath);

            try
            {
                InitializeExcelApplication();
                e.Result = this;

                object val = string.Empty;

                foreach (string splitVal in splitValues)
                {
                    if (bw.CancellationPending)
                    {
                        e.Cancel = true;
                        break;
                    }
                    this.xlWorkBook = IExcelProcessor.OpenWorkbook(this.xlApp, this.Parameters.FilePath, true);
                    this.xlWorkSheet = (Excel.Worksheet)xlWorkBook.Sheets[Parameters.SheetIndex];

                    for (int i = Parameters.RowEnd; i >= Parameters.RowBegin; i--)
                    {
                        val = xlWorkSheet.Range[Parameters.ColumnSplit + i].Value;
                        if (val == null || val.ToString().ToUpper().Trim() != splitVal)
                            ((Excel.Range)xlWorkSheet.Rows[i, System.Reflection.Missing.Value]).Delete(Excel.XlDeleteShiftDirection.xlShiftUp);
                        bw.ReportProgress(0);
                    }
                    xlWorkBook.SaveAs(fileDir + @"/" + ParseStringToFileName(filename + "_" + splitVal) + fileExt);
                    xlWorkBook.Close();
                    bw.ReportProgress(0, splitVal);
                }

                ExitExcelApplication();
            }
            catch
            {
                if (xlWorkBook != null)
                    xlWorkBook.Close();

                if (xlApp != null)
                    ExitExcelApplication();

                throw;
            }
            finally
            {
                ReleaseUnmanaged();
            }
        }
        private static string ParseStringToFileName(string sourse)
        {
            string str = sourse;
            str = str.Replace('\\', '-');
            str = str.Replace('/', '-');
            str = str.Replace("\"", "");
            foreach (char c in System.IO.Path.GetInvalidFileNameChars())
            {
                str = str.Replace(c, '_');
            }
            if (str.Length > 150)
                str = str.Substring(0, 150);
            return str;
        }        
    }
}
