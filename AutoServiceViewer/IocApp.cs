using System.Configuration;
using AutoServiceViewer.RepositoryRegistrator;
using DataAccess.Repository;
using DataAccess.Repository.RepositoryDb;
using DataAccess.Repository.RepositoryFile;
using Microsoft.Practices.Unity;

namespace AutoServiceViewer
{
    public class IocApp
    {
        private static IUnityContainer _container;

        protected IocApp()
        {
        }

        public static IUnityContainer Container {
            get {
                if (_container == null) Initialize();
                return _container;
            }
        }

        private static void Initialize()
        {
            _container = new UnityContainer();
            var connectionString = ConfigurationSettings.AppSettings.Get("connectionString");
            DatabaseRepositoryRegistrator configurator = new DatabaseRepositoryRegistrator
            {
                ConnectionString = connectionString
            };
            configurator.Register(_container);
        }

        public static IRepository GetRepository(RepositoryType repositoryType)
        {
            switch (repositoryType)
            {
                case RepositoryType.Database:
                    return Container.Resolve<DatabaseRepository>();
                case RepositoryType.Xml:
                    return Container.Resolve<XmlRepository>();
                case RepositoryType.Binary:
                    return Container.Resolve<BinaryRepository>();
                default:
                    return null;
            }
        }
    }
}