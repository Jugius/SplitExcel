using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Windows.Forms;
using System.Xml;

namespace Updater
{
    internal interface IUpdatableApplication
    {
        string ApplicationName { get; }
        string ApplicationID { get; }
        Uri UpdateXmlLocation { get; }
        Version Version { get; }
    }
    internal class Updater
    {
        private IUpdatableApplication ApplicationInfo { get; }

        public Updater(IUpdatableApplication applicationInfo)
        {
            if (applicationInfo == null) throw new Exception("applicationInfo");
            this.ApplicationInfo = applicationInfo;
        }
        public void DoUpdate()
        {
            BackgroundWorker bgW_UpdateInfoGetter = new BackgroundWorker();
            bgW_UpdateInfoGetter.DoWork += bgW_UpdateInfoGetter_DoWork;
            bgW_UpdateInfoGetter.RunWorkerCompleted += bgW_UpdateInfoGetter_WorkCompleted;
            bgW_UpdateInfoGetter.RunWorkerAsync();
        }
        private void bgW_UpdateInfoGetter_DoWork(object sender, DoWorkEventArgs e)
        {

            if (!UpdateXml.ExistsOnServer(this.ApplicationInfo.UpdateXmlLocation))
                throw new Exception($"Ошибка получения данных об обновлении: {this.ApplicationInfo.UpdateXmlLocation}");

            UpdateXml updateXml = UpdateXml.Parse(this.ApplicationInfo.UpdateXmlLocation, this.ApplicationInfo.ApplicationID);
            if (updateXml == null)
                throw new Exception($"Ошибка чтения файла по адресу: {this.ApplicationInfo.UpdateXmlLocation}");

            e.Result = updateXml;
        }
        private void bgW_UpdateInfoGetter_WorkCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                UpdateXml updateXml = (UpdateXml)e.Result;

                if (!updateXml.IsNewerThan(this.ApplicationInfo.Version))
                    return;

                string message = "Обнаружена новая версия программы. Вы ходите перейти на страницу загрузки новой версии?" +
                    $"\nНовая версия - {this.ApplicationInfo.Version}.";
                string caption = $"{this.ApplicationInfo.ApplicationName} - новая версия";

                if (MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    Process.Start(updateXml.Uri);
            }
        }   
    }
    internal class UpdateXml
    {
        public Version Version { get; }
        public string Uri { get; }
        public string Description { get; }
        internal UpdateXml(Version version, string uri, string description)
        {
            this.Version = version;
            this.Uri = uri;
            this.Description = description;
        }
        internal bool IsNewerThan(Version version) => this.Version > version;
        internal static bool ExistsOnServer(Uri location)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(location);
            using (HttpWebResponse resp = (HttpWebResponse)req.GetResponse())
            {
                resp.Close();
                return resp.StatusCode == HttpStatusCode.OK;
            }
        }
        internal static UpdateXml Parse(Uri location, string appID)
        {
            Version version = null;
            string url = "", description = "";

            try
            {
                ServicePointManager.ServerCertificateValidationCallback = (s, ce, ch, ssl) => true;
                XmlDocument doc = new XmlDocument();
                doc.Load(location.AbsoluteUri);

                XmlNode node = doc.DocumentElement.SelectSingleNode("//update[@appID='" + appID + "']");
                if (node == null)
                    return null;

                version = new Version(node["version"].InnerText);
                url = node["url"].InnerText;
                description = node["description"].InnerText;

                return new UpdateXml(version, url, description);
            }
            catch
            {
                return null;
            }
        }
    }
}
