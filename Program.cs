using OfficeOpenXml;
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
            EmbeddedAssembly.Load("SplitExcel.Microsoft.WindowsAPICodePack.dll", "Microsoft.WindowsAPICodePack.dll");
            EmbeddedAssembly.Load("SplitExcel.Microsoft.WindowsAPICodePack.Shell.dll", "Microsoft.WindowsAPICodePack.Shell.dll");

            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

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
    }
}
