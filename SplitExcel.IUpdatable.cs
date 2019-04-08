using System;
using System.Diagnostics;
using System.Reflection;
using Updater;

namespace SplitExcel
{
    partial class SplitExcel : IUpdatableApplication
    {
        public string ApplicationName
        {
            get
            {
                return "SplitExcel";
            }
        }

        public string ApplicationID
        {
            get
            {
                return "SplitExcel";
            }
        }
        public Uri UpdateXmlLocation
        {
            get
            {
                return new Uri("http://oohelp.net/software/versions.xml");
            }
        }
        public Version Version
        {
            get
            {
                return new Version(FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion);
            }
        }
    }
}
