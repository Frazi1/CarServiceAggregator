using System;
using System.IO;
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
            XmlRepositorySettings settings = new XmlRepositorySettings(FileName, FileMode.Open);
            container.RegisterInstance(settings);
        }
    }
}