namespace SplitExcel.Office
{
    internal class SplitFileParameters
    {
        internal string FilePath { get; }
        internal int SheetIndex { get; }
        internal string ColumnSplit { get; }
        internal int RowBegin { get; }
        internal int RowEnd { get; }
        internal SplitFileParameters(string filePath, int sheetIndex, string columnSplit, int rowBegin, int rowEnd)
        {
            this.FilePath = filePath;
            this.SheetIndex = sheetIndex;
            this.ColumnSplit = columnSplit;
            this.RowBegin = rowBegin;
            this.RowEnd = rowEnd;
        }
    }
}
