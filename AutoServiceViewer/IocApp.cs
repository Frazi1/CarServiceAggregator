using System;
using System.Configuration;
using DataAccess;
using DataAccess.RepositoryDb;
using DataAccess.RepositoryFile.RepositoryBinary;
using DataAccess.RepositoryFile.RepositoryXML;
using Microsoft.Practices.Unity;
using AutoServiceViewer.Configurator;

namespace AutoServiceViewer
{
    public class IocApp
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
            string connectionString = ConfigurationSettings.AppSettings.Get("connectionString");
            var configurator = new DatabaseRepositoryConfigurator
            {
                ConnectionString = connectionString
            };
            configurator.UpdateContainer(_container);
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

        protected IocApp()
        { }
    }
}
