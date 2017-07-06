using DataAccess.RepositoryDb;

namespace AutoServiceViewer.Configurator
{
    public class DatabaseRepositoryConfigurator : RepositoryConfigurator<DatabaseRepository, DatabaseRepositorySettings>
    {
        public string ConnectionString { get; set; }
        protected override DatabaseRepositorySettings GetSettings()
        {
            return new DatabaseRepositorySettings(ConnectionString);
        }
    }
}
