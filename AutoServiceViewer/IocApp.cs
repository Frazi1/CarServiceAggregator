using System;
using System.Configuration;
using DataAccess.Repository;
using DataAccess.Repository.RepositoryDb;
using DataAccess.Repository.RepositoryFile;
using Microsoft.Practices.Unity;

namespace AutoServiceViewer
{
    public static class IocApp
    {
        private static IUnityContainer _container;

        /// <summary>
        /// Позволяет получить доступ к контейнеру.
        /// </summary>
        public static IUnityContainer Container {
            get {
                if (_container == null) Initialize();
                return _container;
            }
        }

        private static void Initialize()
        {
            _container = new UnityContainer();
        }

        /// <summary>
        /// Запрашивает реализацию репозитория из контейнера.
        /// </summary>
        /// <param name="repositoryType"></param>
        /// <returns>Реализацию репозитория, соответствующую указанному типу репозитория</returns>
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
                    throw new ArgumentOutOfRangeException(nameof(repositoryType), repositoryType, null);
            }
        }


        /// <summary>
        /// Проверяет, зарегистрирован ли репозиторий указанного типа.
        /// </summary>
        /// <param name="repositoryType"></param>
        /// <returns>True, если репозиторий зарегистрирован; иначе - false</returns>
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
                    throw new ArgumentOutOfRangeException(nameof(repositoryType), repositoryType, null);
            }
        }
    }
}