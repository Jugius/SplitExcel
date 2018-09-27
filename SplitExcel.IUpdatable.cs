using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

        public Assembly ApplicationAssembly
        {
            get
            {
                return Assembly.GetExecutingAssembly();
            }
        }

        public Icon ApplicationIcon
        {
            get
            {
                return this.Icon;
            }
        }

        public Uri UpdateXmlLocation
        {
            get
            {
                return new Uri("http://region-m.com.ua/Software/versions.xml");
            }
        }

        public Form Context
        {
            get
            {
                return this;
            }
        }

        public Image ApplicationImage
        {
            get
            {
                return Properties.Resources.Excel_image;
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
