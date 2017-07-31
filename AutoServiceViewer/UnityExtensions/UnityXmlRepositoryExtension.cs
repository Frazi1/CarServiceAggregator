using System;
using System.Configuration;
using DataAccess.Repository;
using DataAccess.Repository.RepositoryFile;
using Microsoft.Practices.Unity;

namespace AutoServiceViewer.UnityExtensions
{
    public class UnityXmlRepositoryExtension : UnityRepositoryExtension
    {
        public UnityXmlRepositoryExtension(string fileName)
        {
            FileName = fileName;
        }

        public string FileName { get; set; }

        protected override void RegisterSettings()
        {
            if (string.IsNullOrEmpty(FileName)) throw new ArgumentException("Filename must not be null");
            Container.RegisterType<XmlRepositorySettings>(new InjectionConstructor(FileName, FileRepositoryMode.Open));
        }

        protected override void RegisterRepository()
        {
            string name = ConfigurationManager.AppSettings["xmlRepository"];
            Container.RegisterType<IRepository, XmlRepository>(name);
        }
    }
}