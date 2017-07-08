using System;
using System.Configuration;
using System.IO;
using DataAccess.Repository;
using DataAccess.Repository.RepositoryFile;
using Microsoft.Practices.Unity;

namespace AutoServiceViewer.RepositoryRegistrator
{
    public class BinaryRepositoryRegistrator : RepositoryRegistrator<BinaryRepository>
    {
        public string FileName { get; set; }

        protected override void RegisterSettings(IUnityContainer container)
        {
            if (string.IsNullOrEmpty(FileName)) throw new ArgumentException("Filename must not be null");
            //BinaryRepositorySettings settings = new BinaryRepositorySettings(FileName, FileMode.Open);
            //container.RegisterInstance(settings);
            container.RegisterType<BinaryRepositorySettings>(new InjectionConstructor(FileName, FileMode.Open));
        }

        protected override void RegisterRepository(IUnityContainer container)
        {
            string name = ConfigurationManager.AppSettings["binaryRepository"];
            container.RegisterType<IRepository, BinaryRepository>(name);
        }
    }
}