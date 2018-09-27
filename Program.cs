using System;
using System.Windows.Forms;


namespace SplitExcel
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {
            if (!IsExcelInstalled())
            {
                MessageBox.Show("Microsoft Excel не найден на этом компьютере", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;                                                
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args != null && args.Length > 0 && System.IO.File.Exists(args[0]))
                Application.Run(new SplitExcel(args[0]));
            else
                Application.Run(new SplitExcel());            
        }
        static bool IsExcelInstalled()
        {
            Type officeType = Type.GetTypeFromProgID("Excel.Application");
            if (officeType == null) return false;
            else return true;
        }
    }
}
