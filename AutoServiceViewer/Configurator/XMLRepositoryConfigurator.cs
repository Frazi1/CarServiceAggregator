using DataAccess.RepositoryFile.RepositoryXML;

namespace AutoServiceViewer.Configurator
{
    public class XmlRepositoryConfigurator : RepositoryConfigurator<XmlRepository, XmlRepositorySettings>
    {
        public string FileName { get; set; }
        protected override XmlRepositorySettings GetSettings()
        {
            return new XmlRepositorySettings(FileName, System.IO.FileMode.Open);
        }
    }
}
