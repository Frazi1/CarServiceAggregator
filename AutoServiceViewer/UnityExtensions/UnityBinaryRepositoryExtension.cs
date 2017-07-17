using System;
using System.Configuration;
using System.IO;
using DataAccess.Repository;
using DataAccess.Repository.RepositoryFile;
using Microsoft.Practices.Unity;

namespace AutoServiceViewer.UnityExtensions
{
    public class UnityBinaryRepositoryExtension : UnityRepositoryExtension
    {
        public UnityBinaryRepositoryExtension(string fileName)
        {
            FileName = fileName;
        }

        public string FileName { get; set; }

        protected override void Initialize()
        {
            RegisterSettings();
            RegisterRepository();
        }

        protected override void RegisterSettings()
        {
            if (string.IsNullOrEmpty(FileName)) throw new ArgumentException("Filename must not be null");
            Container.RegisterType<BinaryRepositorySettings>(new InjectionConstructor(FileName, FileMode.Open));
        }

        protected override void RegisterRepository()
        {
            string name = ConfigurationManager.AppSettings["binaryRepository"];
            Container.RegisterType<IRepository, BinaryRepository>(name);
        }
    }
}