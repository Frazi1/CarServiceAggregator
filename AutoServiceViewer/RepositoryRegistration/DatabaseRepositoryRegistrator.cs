using System.Configuration;
using AutoServiceViewer.UnityExtensions;

namespace AutoServiceViewer.RepositoryRegistration
{
    public class DatabaseRepositoryRegistrator : RepositoryRegistrator
    {
        public override bool Register()
        {
            UnityDatabaseRepositoryExtension databaseExtension = new UnityDatabaseRepositoryExtension(
                ConfigurationManager
                    .ConnectionStrings["mysql"]
                    .ConnectionString);
            IocApp.AddExtension(databaseExtension);
            return true;
        }
    }
}