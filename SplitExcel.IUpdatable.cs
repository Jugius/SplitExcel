using System;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using Updater;

namespace SplitExcel
{
    partial class SplitExcel : IUpdatableApplication
    {
        public string ApplicationName => "SplitExcel";
        public string ApplicationID => "SplitExcel";
        public Uri UpdateXmlLocation { get; } = new Uri("http://oohelp.net/software/versions.xml");
        public Version Version => new Version(FileVersionInfo.GetVersionInfo(ApplicationAssembly.Location).FileVersion);
        public Assembly ApplicationAssembly => Assembly.GetExecutingAssembly();
        public Icon ApplicationIcon => Properties.Resources.Excel_icon;
        public Image ApplicationImage => Properties.Resources.Excel_image;
        public Form Context => this;
    }
}
