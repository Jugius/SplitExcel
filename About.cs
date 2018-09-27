using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace SplitExcel
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.Excel_icon;
            lblVersion.Text = "Ver. "+ FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;
            lblCopyright.Text = AssemblyCopyright;
        }
        private string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start($"mailto:{linkLabel1.Text}");
        }
    }
}
