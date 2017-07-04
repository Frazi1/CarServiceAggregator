using System;
using Microsoft.Practices.Unity;
using AutoServiceViewer.ViewModel;
using DataAccess;
using DataAccess.RepositoryDb;
using DataAccess.RepositoryFile.RepositoryBinary;
using DataAccess.RepositoryFile.RepositoryXML;

namespace AutoServiceViewer
{
    public static class IocApp
    {
        private static UnityContainer _container;
        private static IUnityContainer _dbContainer, _xmlContainer, _binaryContainer;

        public static UnityContainer Container => _container;
        public static IUnityContainer XMLContainer => _xmlContainer;

        public static void Initialize()
        {
            if (_container == null)
                _container = new UnityContainer();
            _dbContainer = _container.CreateChildContainer()
                .RegisterType<IRepository, DatabaseRepository>();
            _xmlContainer = _container.CreateChildContainer()
                .RegisterType<IRepository, XMLRepository>();
            _binaryContainer = _container.CreateChildContainer()
                .RegisterType<IRepository, BinaryRepository>();
        }
    }

    //public class ViewModelsExtension : UnityContainerExtension
    //{
    //    protected override void Initialize()
    //    {
    //        Container.RegisterType<MainViewModel>();
    //        Container.RegisterType<XMLSettingsViewModel>();

    //        Container.RegisterType<IRepository, XMLRepository>();
    //        Container.RegisterType<IRepository, BinaryRepository>();
    //        Container.RegisterType<IRepository, DatabaseRepository>();
    //        var xmlSettings = new XMLRepositorySettings("AutoService.xml", System.IO.FileMode.Open);

    //        Container.RegisterInstance(xmlSettings);

    //       var test = Container.Resolve<IRepository>();

            //IocApp.Container.RegisterType<XMLRepositorySettings>();
            //IocApp.Container.RegisterType<DatabaseRepositorySettings>();
            //IocApp.Container.RegisterType<BinaryRepositorySettings>();
    //    }
    //}
}
