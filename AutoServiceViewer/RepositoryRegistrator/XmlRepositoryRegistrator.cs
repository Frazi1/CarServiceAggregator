using System;
using System.Configuration;
using System.IO;
using DataAccess.Repository;
using DataAccess.Repository.RepositoryFile;
using Microsoft.Practices.Unity;

namespace AutoServiceViewer.RepositoryRegistrator
{
    /// <summary>
    /// Регистратор Xml репозитория.
    /// </summary>
    public class XmlRepositoryRegistrator : RepositoryRegistrator<XmlRepository>
    {
        /// <summary>
        /// Дает доступ к пути файла, из которого репозиторий загружает данные.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Регистрирует Xml репозиторий в контейнере
        /// </summary>
        /// <exception cref="ArgumentNullException"/>
        /// <param name="container">контейнер</param>
        protected override void RegisterSettings(IUnityContainer container)
        {
            if (string.IsNullOrEmpty(FileName)) throw new ArgumentException("Filename must not be null");
            container.RegisterType<XmlRepositorySettings>(new InjectionConstructor(FileName, FileMode.Open));
        }

        /// <summary>
        /// Выполняет все действия, необходимые для регистрации Xml репозитория/>
        /// </summary>
        /// <param name="container"></param>
        protected override void RegisterRepository(IUnityContainer container)
        {
            string name = ConfigurationManager.AppSettings["xmlRepository"];
            container.RegisterType<IRepository, XmlRepository>(name);
        }
    }
}