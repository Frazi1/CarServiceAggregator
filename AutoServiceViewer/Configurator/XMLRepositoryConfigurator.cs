using DataAccess.RepositoryFile.RepositoryXML;

namespace AutoServiceViewer.Configurator
{
    public class XMLRepositoryConfigurator : RepositoryConfigurator<XMLRepository, XMLRepositorySettings>
    {
        public string FileName { get; set; }
        protected override XMLRepositorySettings GetSettings()
        {
            return new XMLRepositorySettings(FileName, System.IO.FileMode.Open);
        }
    }
}
