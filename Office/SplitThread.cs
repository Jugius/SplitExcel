using OfficeOpenXml;
using System.Collections.Generic;
using System.ComponentModel;



namespace SplitExcel.Office
{
    internal sealed class SplitThread 
    {
        static readonly object locker = new object();
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

            int splitColumnNumber = UsingExcel.GetColumnNumber(Parameters.ColumnSplit);
            e.Result = this;
            foreach (string splitVal in splitValues)
            {
                if (bw.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }

                using (ExcelPackage excel = new ExcelPackage(Parameters.FilePath))
                {
                    var sheet = excel.Workbook.Worksheets[Parameters.SheetIndex];

                    for (int row = Parameters.RowEnd; row >= Parameters.RowBegin; row--)
                    {
                        string value = sheet.Cells[row, splitColumnNumber].GetValue<string>();
                        if (string.IsNullOrWhiteSpace(value) || !splitVal.Equals(value.Trim(), System.StringComparison.OrdinalIgnoreCase))
                        {
                            sheet.DeleteRow(row);
                        }
                        bw.ReportProgress(0);
                    }

                    excel.SaveAs(fileDir + @"/" + ParseStringToFileName(filename + "_" + splitVal) + fileExt);
                }
                bw.ReportProgress(0, splitVal);
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
