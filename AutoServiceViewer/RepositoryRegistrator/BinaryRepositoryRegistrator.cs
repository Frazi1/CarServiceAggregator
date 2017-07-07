using System;
using System.IO;
using DataAccess.RepositoryFile.RepositoryBinary;
using Microsoft.Practices.Unity;

namespace AutoServiceViewer.RepositoryRegistrator
{
    public class BinaryRepositoryRegistrator : RepositoryRegistrator<BinaryRepository>
    {
        public string FileName { get; set; }

        protected override void RegisterSettings(IUnityContainer container)
        {
            if (string.IsNullOrEmpty(FileName)) throw new ArgumentException("Filename must not be null");
            var settings = new BinaryRepositorySettings(FileName, FileMode.Open);
            container.RegisterInstance(settings);
        }
    }
}
