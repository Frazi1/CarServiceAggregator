using AutoServiceViewer.UnityExtensions;
using Microsoft.Win32;

namespace AutoServiceViewer.RepositoryRegistration
{
    public class XmlRepositoryRegistrator : RepositoryRegistrator
    {
        public override bool Register()
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Xml файлы (*.xml, *.xmlns)|*.xml;*.xmlns|Все файлы (*.*)|*.*"
            };
            if (ofd.ShowDialog() != true) return false;
            UnityXmlRepositoryExtension xmlExtension = new UnityXmlRepositoryExtension(ofd.FileName);
            IocApp.AddExtension(xmlExtension);
            return true;
        }
    }
}