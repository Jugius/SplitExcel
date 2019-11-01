using System;
using System.Collections.Generic;
using System.Linq;
using Excel = Microsoft.Office.Interop.Excel;

namespace SplitExcel.Office
{
    internal class UsingExcel : IExcelProcessor, IDisposable
    {           
        internal ExcelFileInfo ReadExcelFileInfo(string fileName)
        {
            try
            {
                InitializeExcelApplication();
                this.xlWorkBook = IExcelProcessor.OpenWorkbook(this.xlApp, fileName, true);

                List<ExcelSheet> sheets = new List<ExcelSheet>();
                Excel.Sheets xlWorkSheets = xlWorkBook.Sheets;

                foreach (Excel.Worksheet sheet in xlWorkSheets)
                    sheets.Add(GetSheetInfo(sheet));

                ExcelFileInfo result = new ExcelFileInfo(fileName, sheets);

                xlWorkBook.Close();
                ExitExcelApplication();
                return result;
            }
            catch
            {
                if (xlWorkBook != null)
                    xlWorkBook.Close();

                if (xlApp != null)
                    ExitExcelApplication();

                throw;
            }
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
                InitializeExcelApplication();
                this.xlWorkBook = IExcelProcessor.OpenWorkbook(this.xlApp, splitParams.FilePath, true);

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
                ExitExcelApplication();

                splitValues = splitValues.Distinct().ToList();
                splitValues.Sort();
                return splitValues;
            }
            catch
            {
                if (xlWorkBook != null)
                    xlWorkBook.Close();

                if (xlApp != null)
                    ExitExcelApplication();

                throw;
            }
        }        
    }
}
