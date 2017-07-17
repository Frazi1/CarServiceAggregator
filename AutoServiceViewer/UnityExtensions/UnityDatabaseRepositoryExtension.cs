using System;
using System.Configuration;
using DataAccess.Repository;
using DataAccess.Repository.RepositoryDb;
using Microsoft.Practices.Unity;

namespace AutoServiceViewer.UnityExtensions
{
    public class UnityDatabaseRepositoryExtension : UnityRepositoryExtension
    {
        public UnityDatabaseRepositoryExtension(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public string ConnectionString { get; set; }

        protected override void RegisterSettings()
        {
            if (string.IsNullOrEmpty(ConnectionString))
                throw new ArgumentException("Connection string must not be null");
            Container.RegisterType<DatabaseRepositorySettings>(
                new InjectionConstructor(ConnectionString, DatabaseConnectionAction.Connect));
        }

        protected override void RegisterRepository()
        {
            string name = ConfigurationManager.AppSettings["dbRepository"];
            Container.RegisterType<IRepository, DatabaseRepository>(name);
        }
    }
}