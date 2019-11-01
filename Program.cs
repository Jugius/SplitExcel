using System;
using System.IO;
using System.Reflection;
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
            EmbeddedAssembly.Load("SplitExcel.office.dll", "office.dll");
            EmbeddedAssembly.Load("SplitExcel.Microsoft.Office.Interop.Excel.dll", "Microsoft.Office.Interop.Excel.dll");

            EmbeddedAssembly.Load("SplitExcel.Microsoft.WindowsAPICodePack.dll", "Microsoft.WindowsAPICodePack.dll");
            EmbeddedAssembly.Load("SplitExcel.Microsoft.WindowsAPICodePack.Shell.dll", "Microsoft.WindowsAPICodePack.Shell.dll");

            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args != null && args.Length>0)
            {                
                Application.Run(new SplitExcel(args[0]));
            }
            else
            {
                Application.Run(new SplitExcel());
            }
        }
        private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            return EmbeddedAssembly.Get(args.Name);
        }

        static bool IsExcelInstalled()
        {
            Type officeType = Type.GetTypeFromProgID("Excel.Application");
            if (officeType == null) return false;
            else return true;
        }
    }
}
