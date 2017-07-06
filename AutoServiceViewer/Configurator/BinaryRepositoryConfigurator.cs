using DataAccess.RepositoryFile.RepositoryBinary;

namespace AutoServiceViewer.Configurator
{
    public class BinaryRepositoryConfigurator : RepositoryConfigurator<BinaryRepository, BinaryRepositorySettings>
    {
        public string FileName { get; set; }
        protected override BinaryRepositorySettings GetSettings()
        {
            return new BinaryRepositorySettings(FileName, System.IO.FileMode.Open);
        }
    }
}
