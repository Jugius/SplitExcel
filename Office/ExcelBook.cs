using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SplitExcel.Office
{
    internal class ExcelBook
    {
        internal string FilePath { get; private set; }
        internal List<ExcelSheet> Sheets { get; set; } = new List<ExcelSheet>();
        internal ExcelBook(string filePath)
        {
            this.FilePath = filePath;
        }
    }
}
