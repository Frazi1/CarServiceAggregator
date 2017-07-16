using System;
using System.Configuration;
using DataAccess.Repository;
using DataAccess.Repository.RepositoryDb;
using Microsoft.Practices.Unity;

namespace AutoServiceViewer.UnityExtensions
{
    public class UnityDatabaseRepositoryExtension : UnityRepositoryExtension
    {
        /// <summary>
        /// Дает доступ к строке соединения с базой данных.
        /// </summary>
        public string ConnectionString { get; set; }

        public UnityDatabaseRepositoryExtension(string connectionString)
        {
            ConnectionString = connectionString;
        }

        protected override void RegisterSettings()
        {
            if (string.IsNullOrEmpty(ConnectionString))
                throw new ArgumentException("Connection string must not be null");
            Container.RegisterType<DatabaseRepositorySettings>(
                new InjectionConstructor(ConnectionString, DatabaseConnectionAction.Connect));
        }

        /// <summary>
        /// Регистрирует Database репозиторий в контейнере.
        /// </summary>
        /// <param name="container">контейнер</param>
        protected override void RegisterRepository()
        {
            string name = ConfigurationManager.AppSettings["dbRepository"];
            Container.RegisterType<IRepository, DatabaseRepository>(name);
        }
    }
}