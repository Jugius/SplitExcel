using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SplitExcel.Office
{
    internal class ExcelSheet
    {
        public int Index { get; set; }
        public string Name { get; set; }
        public ExcelLastCell LastCell { get; set; }       
    }
}
