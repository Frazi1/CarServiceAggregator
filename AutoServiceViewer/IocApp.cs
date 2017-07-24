using System;
using AutoServiceViewer.RepositoryRegistration;
using DataAccess.Repository;
using DataAccess.Repository.RepositoryDb;
using DataAccess.Repository.RepositoryFile;
using ExceptionHandling;
using Microsoft.Practices.Unity;

namespace AutoServiceViewer
{
    public static class IocApp
    {
        private static IUnityContainer _container;

        private static IUnityContainer Container {
            get {
                if (_container != null) return _container;
                _container = new UnityContainer();
                return _container;
            }
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
                    throw new ArgumentOutOfRangeException(nameof(repositoryType), repositoryType, null);
            }
        }

        public static RepositoryRegistrator GetRegistrator(RepositoryType repositoryType)
        {
            switch (repositoryType)
            {
                case RepositoryType.Xml:
                    return Container.Resolve<XmlRepositoryRegistrator>();
                case RepositoryType.Binary:
                    return Container.Resolve<BinaryRepositoryRegistrator>();
                case RepositoryType.Database:
                    return Container.Resolve<DatabaseRepositoryRegistrator>();
                default:
                    throw new ArgumentOutOfRangeException(nameof(repositoryType), repositoryType, null);
            }
        }

        public static void RegisterLogger<T>(params InjectionMember[] injectionMembers)
            where T : ILogger
        {
            Container.RegisterType<ILogger, T>(injectionMembers);
        }

        public static void AddExtension<T>(T extension)
            where T : UnityContainerExtension
        {
            Container.AddExtension(extension);
        }
    }
}