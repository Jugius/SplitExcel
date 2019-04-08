using System.Collections.Generic;

namespace SplitExcel.Office
{
    internal class ExcelFileInfo
    {
        internal string Path { get; }
        internal List<ExcelSheet> Sheets { get; }
        internal ExcelFileInfo(string filePath, List<ExcelSheet> sheets)
        {
            this.Path = filePath;
            this.Sheets = sheets;
        }
    }
}
