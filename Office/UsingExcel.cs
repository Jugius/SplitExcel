using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SplitExcel.Office
{
    internal static class UsingExcel
    {
        private static readonly HashSet<string> allowedFileExtentions =
            new HashSet<string>(StringComparer.OrdinalIgnoreCase) { ".xlsx", ".xlsm" };

        public static ExcelFileInfo ReadExcelFileInfo(string fileName)
        {
            if (!allowedFileExtentions.Contains(Path.GetExtension(fileName)))
                throw new Exception("Неподдерживаемый формат. Поддерживаются только файлы Office 2007 и выше, формата .xlsx и .xlsm");

            ExcelFileInfo result;

            using (ExcelPackage excel = new ExcelPackage(fileName))
            {
                if (excel.Workbook?.Worksheets?.Count == 0)
                    throw new Exception("Не найдены листы в файле!");

                List<ExcelSheet> sheets = new List<ExcelSheet>(excel.Workbook.Worksheets.Count);
                foreach (var sheet in excel.Workbook.Worksheets)
                {
                    sheets.Add(GetSheetInfo(sheet));
                }
                result = new ExcelFileInfo(fileName, sheets);
            }

            return result;
        }
        private static ExcelSheet GetSheetInfo(ExcelWorksheet sheet)
        {
            ExcelSheet result = new Office.ExcelSheet
            {
                Name = sheet.Name,
                Index = sheet.Index,
            };

            if (sheet.Dimension == null)
            {
                result.LastCell = new ExcelLastCell(1, 1);
            }
            else
            {
                result.LastCell = new ExcelLastCell(sheet.Dimension.End.Row, sheet.Dimension.End.Column);
            }

            return result;
        }
        internal static List<string> GetSplitValues(SplitFileParameters splitParams)
        {
            HashSet<string> values = new HashSet<string>(splitParams.RowEnd - splitParams.RowBegin + 1, StringComparer.OrdinalIgnoreCase);
            int splitColumnNumber = GetColumnNumber(splitParams.ColumnSplit);

            using (ExcelPackage excel = new ExcelPackage(splitParams.FilePath))
            {
                var sheet = excel.Workbook.Worksheets[splitParams.SheetIndex];

                for (int row = splitParams.RowBegin; row <= splitParams.RowEnd; row++)
                {
                    string value = sheet.Cells[row, splitColumnNumber].GetValue<string>();
                    if (!string.IsNullOrWhiteSpace(value))
                        values.Add(value.Trim());
                }
            }
            return values.OrderBy(a => a).ToList();
        }
        public static int GetColumnNumber(string colAdress)
        {
            int[] digits = new int[colAdress.Length];
            for (int i = 0; i < colAdress.Length; ++i)
            {
                digits[i] = Convert.ToInt32(colAdress[i]) - 64;
            }
            int mul = 1; int res = 0;
            for (int pos = digits.Length - 1; pos >= 0; --pos)
            {
                res += digits[pos] * mul;
                mul *= 26;
            }
            return res;
        }
    }
}
