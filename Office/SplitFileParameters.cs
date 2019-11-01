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
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (object.ReferenceEquals(this, obj)) return true;

            SplitFileParameters other = obj as SplitFileParameters;
            if (other == null) return false;

            return this.FilePath == other.FilePath &&
                    this.SheetIndex == other.SheetIndex &&
                    this.ColumnSplit == other.ColumnSplit &&
                    this.RowBegin == other.RowBegin &&
                    this.RowEnd == other.RowEnd;                   
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
