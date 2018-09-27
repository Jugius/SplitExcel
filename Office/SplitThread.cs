using System;
using System.Collections.Generic;
using Excel = Microsoft.Office.Interop.Excel;


namespace SplitExcel.Office
{
    internal delegate void NewFileSavedEventHandler(string itemName);
    internal delegate void ThreadFinishedEventHandler(SplitThread thread);
    internal class SplitThread : IDisposable
    {
        internal event NewFileSavedEventHandler NewFileSaved;
        internal event ThreadFinishedEventHandler ThreadFinished;

        private Excel.Application xlApp = null;
        private List<string> SplitValues;
        SplitFileParameters SplitParameters;

        internal SplitThread(List<string> splitvalues, SplitFileParameters splitParameters)
        {
            SplitValues = splitvalues;
            SplitParameters = splitParameters;
        }
        internal void SplitExcelFile()
        {
            Excel.Workbook xlWorkBook = null;
            Excel.Worksheet xlWorkSheet = null; 

            string fileExt = System.IO.Path.GetExtension(SplitParameters.FilePath);
            string filename = System.IO.Path.GetFileNameWithoutExtension(SplitParameters.FilePath);
            string fileDir = System.IO.Path.GetDirectoryName(SplitParameters.FilePath);
            System.Globalization.CultureInfo oldCI = System.Threading.Thread.CurrentThread.CurrentCulture;

            try
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
                xlApp = new Excel.Application();
                xlApp.UserControl = false;
                xlApp.ScreenUpdating = false;
                xlApp.EnableEvents = false;
                xlApp.DisplayAlerts = false;
                xlApp.Visible = false;

                object val = string.Empty;

                for (int s = 0; s < SplitValues.Count; s++)
                {
                    xlWorkBook = xlApp.Workbooks.Open(SplitParameters.FilePath, ReadOnly: true);
                    xlWorkSheet = (Excel.Worksheet)xlWorkBook.Sheets[SplitParameters.SheetIndex];

                    for (int i = SplitParameters.RowEnd; i >= SplitParameters.RowBegin; i--)
                    {
                        val = xlWorkSheet.Range[SplitParameters.ColumnSplit + i].Value;
                        if (val == null || val.ToString().ToUpper().Trim() != SplitValues[s])
                            ((Excel.Range)xlWorkSheet.Rows[i, System.Reflection.Missing.Value]).Delete(Excel.XlDeleteShiftDirection.xlShiftUp);
                    }
                    xlWorkBook.SaveAs(fileDir + @"/" + ParseStringToFileName(filename + "_" + SplitValues[s]) + fileExt);
                    xlWorkBook.Close();

                    NewFileSaved?.Invoke(SplitValues[s]);
                }

                Release(xlWorkSheet);
                Release(xlWorkBook);

                xlApp.UserControl = true;
                xlApp.EnableEvents = true;
                xlApp.DisplayAlerts = true;

                xlApp.Quit();
                ThreadFinished?.Invoke(this);
            }
            catch (Exception ex) { throw ex; }
        }
        private string ParseStringToFileName(string sourse)
        {
            string str = sourse;
            str = str.Replace("\\", "-");
            str = str.Replace("/", "-");
            str = str.Replace("\"", "");
            foreach (char c in System.IO.Path.GetInvalidFileNameChars())
            {
                str = str.Replace(c, '_');
            }
            if (str.Length > 150)
                str = str.Substring(0, 150);
            return str;
        }

        #region Disposing Logic
        private bool iDisposed = false;
        public void Dispose()
        {
            if (!iDisposed)
            {
                iDisposed = true;
                Release(xlApp);
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.SuppressFinalize(this); //говорим сборщику мусора, что наш объект уже освободил ресурсы
            }

        }
        private void Release(object sender)
        {
            try
            {
                if (sender != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(sender);
                    sender = null;
                }
            }
            catch (Exception) { sender = null; }
        }
        #endregion
    }
}
