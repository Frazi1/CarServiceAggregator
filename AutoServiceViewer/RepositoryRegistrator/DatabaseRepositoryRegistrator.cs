using System;
using System.Configuration;
using DataAccess.Repository;
using DataAccess.Repository.RepositoryDb;
using Microsoft.Practices.Unity;

namespace AutoServiceViewer.RepositoryRegistrator
{
    public class DatabaseRepositoryRegistrator : RepositoryRegistrator<DatabaseRepository>
    {
        /// <summary>
        /// Дает доступ к строке соединения с базой данных.
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Регистрирует Database репозиторий в контейнере.
        /// </summary>
        /// <exception cref="ArgumentNullException"/>
        /// <param name="container">контейнер</param>
        protected override void RegisterSettings(IUnityContainer container)
        {
            if (string.IsNullOrEmpty(ConnectionString))
                throw new ArgumentException("Connection string must not be null");
            container.RegisterType<DatabaseRepositorySettings>(
                new InjectionConstructor(ConnectionString, DatabaseConnectionAction.Connect));
        }

        /// <summary>
        /// Регистрирует Database репозиторий в контейнере.
        /// </summary>
        /// <param name="container">контейнер</param>
        protected override void RegisterRepository(IUnityContainer container)
        {
            string name = ConfigurationManager.AppSettings["dbRepository"];
            container.RegisterType<IRepository, DatabaseRepository>(name);
        }
    }
}