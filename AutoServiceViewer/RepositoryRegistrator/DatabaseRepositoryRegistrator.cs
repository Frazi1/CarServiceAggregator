using System;
using DataAccess.RepositoryDb;
using Microsoft.Practices.Unity;

namespace AutoServiceViewer.RepositoryRegistrator
{
    public class DatabaseRepositoryRegistrator : RepositoryRegistrator<DatabaseRepository>
    {
        public string ConnectionString { get; set; }

        protected override void RegisterSettings(IUnityContainer container)
        {
            if(string.IsNullOrEmpty(ConnectionString)) throw new ArgumentException("Connection string must not be null");
            DatabaseRepositorySettings settings = new DatabaseRepositorySettings(ConnectionString);
            container.RegisterInstance(settings);
        }
    }
}
