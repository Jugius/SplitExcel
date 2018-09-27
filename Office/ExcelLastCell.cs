using System.Collections.Generic;
namespace SplitExcel.Office
{
    internal class ExcelLastCell
    {
        internal enum ColumnsType { String, Numeric }
        internal int Row { get; set; }
        internal int Column { get; set; }
        internal List<string> Columns(ColumnsType type)
        {
            List<string> list = new List<string>();
            for (int i = 1; i <= this.Column; i++)
                list.Add((type == ColumnsType.String) ? GetColumnName(i) : i.ToString());
            return list;
        }
        internal ExcelLastCell(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }
        internal static string GetColumnName(int columnNumber)
        {
            int dividend = columnNumber;
            string columnName = string.Empty;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                columnName = System.Convert.ToChar(65 + modulo).ToString() + columnName;
                dividend = (int)((dividend - modulo) / 26);
            }
            return columnName;
        }
    }
    internal class SplitFileParameters
    {
        internal string FilePath { get; set; }
        internal int SheetIndex { get; set; }
        internal string ColumnSplit { get; set; }
        internal int RowBegin { get; set; }
        internal int RowEnd { get; set; }
        internal SplitFileParameters(string filePath,int sheetIndex, string columnSplit, int rowBegin, int rowEnd)
        {
            this.FilePath = filePath;
            this.SheetIndex = sheetIndex;
            this.ColumnSplit = columnSplit;
            this.RowBegin = rowBegin;
            this.RowEnd = rowEnd;
        }
    }    
}
