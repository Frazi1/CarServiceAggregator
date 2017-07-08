using System;
using System.Configuration;
using System.IO;
using DataAccess.Repository;
using DataAccess.Repository.RepositoryFile;
using Microsoft.Practices.Unity;

namespace AutoServiceViewer.RepositoryRegistrator
{
    public class XmlRepositoryRegistrator : RepositoryRegistrator<XmlRepository>
    {
        public string FileName { get; set; }

        protected override void RegisterSettings(IUnityContainer container)
        {
            if (string.IsNullOrEmpty(FileName)) throw new ArgumentException("Filename must not be null");
            //XmlRepositorySettings settings = new XmlRepositorySettings(FileName, FileMode.Open);
            //container.RegisterInstance(settings);
            container.RegisterType<XmlRepositorySettings>(new InjectionConstructor(FileName, FileMode.Open));
        }

        protected override void RegisterRepository(IUnityContainer container)
        {
            string name = ConfigurationManager.AppSettings["xmlRepository"];
            container.RegisterType<IRepository, XmlRepository>(name);
        }
    }
}