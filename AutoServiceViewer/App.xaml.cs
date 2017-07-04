using AutoServiceViewer.View;
using AutoServiceViewer.ViewModel;
using DataAccess;
using DataAccess.RepositoryDb;
using DataAccess.RepositoryFile;
using DataAccess.RepositoryFile.RepositoryBinary;
using DataAccess.RepositoryFile.RepositoryXML;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AutoServiceViewer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //IocApp.Initialize();
            IocApp.Initialize();

            //const string connectionString = "server=localhost;port=3306;uid=testuser;password=testpassword; initial catalog=autoservicedb;";
            //var xmlSettings = new XMLRepositorySettings("AutoService.xml", System.IO.FileMode.Open);
            //var binarySettings = new BinaryRepositorySettings("AutoService.dat", System.IO.FileMode.Open);
            //var databaseSettings = new DatabaseRepositorySettings(connectionString);
            //IocApp.Container.RegisterInstance(xmlSettings);
            //IocApp.Container.RegisterInstance(binarySettings);
            //IocApp.Container.RegisterInstance(databaseSettings);

            //IocApp.Container.RegisterType<IRepository, XMLRepository>();
            //IocApp.Container.RegisterType<IRepository, BinaryRepository>();
            //IocApp.Container.RegisterType<IRepository, DatabaseRepository>();

            //var test = IocApp.Container.Resolve<IRepository>();
           
        }
    }
}
