using System;
using System.Reflection;
using System.Windows.Forms;
using SoftwareManagement.Updater;

namespace SplitExcel
{
    partial class SplitExcel : IUpdatableApplication
    {
        private const string _name = "SplitExcel";
        private const string _updatesServer = @"https://software.oohelp.net";
        public string ApplicationName => _name;
        public Form MainWindow => this;
        public Version Version => Assembly.GetExecutingAssembly().GetName().Version;
        public string UpdatesServerPath => _updatesServer;        
    }
}
