using System.Configuration;
using AutoServiceViewer.RepositoryRegistrator;
using DataAccess.Repository;
using DataAccess.Repository.RepositoryDb;
using DataAccess.Repository.RepositoryFile;
using Microsoft.Practices.Unity;

namespace AutoServiceViewer
{
    public static class IocApp
    {
        private static IUnityContainer _container;

        public static IUnityContainer Container {
            get {
                if (_container == null) Initialize();
                return _container;
            }
        }

        private static void Initialize()
        {
            _container = new UnityContainer();
            var connectionString = ConfigurationManager.ConnectionStrings["mysql"].ConnectionString;
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

        public static bool IsRegistered(RepositoryType repositoryType)
        {
            switch (repositoryType)
            {
                case RepositoryType.Xml:
                    return Container.IsRegistered<IRepository>(ConfigurationManager.AppSettings["xmlRepository"]);
                case RepositoryType.Binary:
                    return Container.IsRegistered<IRepository>(ConfigurationManager.AppSettings["binaryRepository"]);
                case RepositoryType.Database:
                    return Container.IsRegistered<IRepository>(ConfigurationManager.AppSettings["dbRepository"]);
                default:
                    return false;
            }
        }
    }
}