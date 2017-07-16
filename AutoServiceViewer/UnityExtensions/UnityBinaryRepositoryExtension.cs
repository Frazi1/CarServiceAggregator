using System;
using System.Configuration;
using System.IO;
using DataAccess.Repository;
using DataAccess.Repository.RepositoryFile;
using Microsoft.Practices.Unity;

namespace AutoServiceViewer.UnityExtensions
{
    public class UnityBinaryRepositoryExtension : UnityContainerExtension
    {
        public string FileName { get; set; }

        public UnityBinaryRepositoryExtension(string fileName)
        {
            FileName = fileName;
        }

        protected override void Initialize()
        {
            RegisterSettings();
            RegisterRepository();
        }

        private void RegisterSettings()
        {
            if (string.IsNullOrEmpty(FileName)) throw new ArgumentException("Filename must not be null");
            Container.RegisterType<BinaryRepositorySettings>(new InjectionConstructor(FileName, FileMode.Open));
        }

        private void RegisterRepository()
        {
            string name = ConfigurationManager.AppSettings["binaryRepository"];
            Container.RegisterType<IRepository, BinaryRepository>(name);
        }
    }
}