using System;
using System.Collections.Generic;
using System.Linq;
using Excel = Microsoft.Office.Interop.Excel;

namespace SplitExcel.Office
{
    internal class UsingExcel : IDisposable
    {        
        private Excel.Application xlApp = null;

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
            try {
                if (sender != null) {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(sender);
                    sender = null;
                }
            }
            catch (Exception) { sender = null; }
        }
        #endregion
        internal ExcelBook ReadExcelFile(string fileName)
        {
            try {                
                xlApp = new Excel.Application();
                xlApp.Visible = false;
                xlApp.DisplayAlerts = false;
                Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(fileName);

                ExcelBook result = new ExcelBook(fileName);
                List<ExcelSheet> sheets = new List<ExcelSheet>();
                Excel.Sheets xlWorkSheets = xlWorkBook.Sheets;

                foreach (Excel.Worksheet sheet in xlWorkSheets)
                    sheets.Add(GetSheetInfo(sheet));

                result.Sheets = sheets;
                xlWorkBook.Close();
                Release(xlWorkSheets);
                Release(xlWorkBook);
                xlApp.DisplayAlerts = true;
                xlApp.Quit();

                return result;
            }
            catch (Exception ex) { throw ex; }
        }
        private ExcelSheet GetSheetInfo(Excel.Worksheet sheet)
        {
            int RowsUsed = -1;
            int ColsUsed = -1;
            ExcelSheet result = new Office.ExcelSheet();
            result.Name = sheet.Name;
            result.Index = sheet.Index;
            Excel.Range workRange = sheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell);

            RowsUsed = workRange.Row;
            ColsUsed = workRange.Column;
            Release(workRange);

            result.LastCell = new ExcelLastCell(RowsUsed, ColsUsed);

            Release(workRange);

            return result;
        }
        internal List<string> GetSplitValues(SplitFileParameters splitParams)
        {
            List<string> splitValues = new List<string>();
            try
            {
                xlApp = new Excel.Application();
                xlApp.Visible = false;
                xlApp.DisplayAlerts = false;

                Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(splitParams.FilePath);
                Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Sheets[splitParams.SheetIndex];

                object val = string.Empty;

                for (int i = splitParams.RowBegin; i <= splitParams.RowEnd; i++)
                {
                    val = xlWorkSheet.Range[splitParams.ColumnSplit + i].Value;
                    if (val != null)
                    {
                        string value = val.ToString().ToUpper().Trim();
                        if (value != string.Empty)
                            splitValues.Add(value);
                    }                        
                }
                xlWorkBook.Close();
                Release(xlWorkBook);
                xlApp.Quit();

                splitValues = splitValues.Distinct().ToList();
                splitValues.Sort();
                return splitValues;
            }
            catch (Exception ex) { throw ex; }
        }        
    }
}
