using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace SplitExcel
{
    public partial class About : Form
    {
        public const string ApplicationSite = @"https://www.oohelp.net/splitexcel/";
        public About()
        {
            InitializeComponent();
        }
        public About(SplitExcel app) : this()
        {
            this.Text = $"О программе {app.ApplicationName}";
            lblProgramName.Text = app.ApplicationName;
            this.Icon = app.Icon;
            //pictureAppImage.Image = Properties.Resources.Excel_image;
            var version = app.Version;
            lblVersion.Text = "Версия: " + version.Major + "." + version.Minor +
                (version.Build != 0 ? $" (build {version.Build}" +
                (version.Revision > 0 ? $" rev. {version.Revision}" : null) + ")" : null);
            lblCopyright.Text = GetAssemblyCopyright(Assembly.GetExecutingAssembly());
            linkWWW.Text = $"Страница {app.ApplicationName}";
        }

        private void LinkWWW_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(About.ApplicationSite);
        }

        private string GetAssemblyCopyright(Assembly assembly)
        {
            if (assembly == null) return "";
            object[] attributes = assembly.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
            if (attributes.Length == 0)
            {
                return "";
            }
            return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;

        }   
        private void _secondaryPanel_Paint(object sender, PaintEventArgs e)
        {
            VisualStyleRenderer renderer = new VisualStyleRenderer(VisualStyleElement.CreateElement("TASKDIALOG", 8, 0));
            renderer.DrawBackground(e.Graphics, _secondaryPanel.ClientRectangle, e.ClipRectangle);
        }
    }
}
