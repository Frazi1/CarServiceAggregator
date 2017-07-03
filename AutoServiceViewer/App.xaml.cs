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

            const string connectionString = "server=localhost;port=3306;uid=testuser;password=testpassword; initial catalog=autoservicedb;";
            var xmlSettings = new XMLRepositorySettings("AutoService.xml", System.IO.FileMode.Open);
            var binarySettings = new BinaryRepositorySettings("AutoService.dat", System.IO.FileMode.Open);
            var databaseSettings = new DatabaseRepositorySettings(connectionString);

            UnityContainer c = new UnityContainer();
            c.RegisterType<IRepository, XMLRepository>();
            c.RegisterType<IRepository, BinaryRepository>();
            c.RegisterType<IRepository, DatabaseRepository>();
            c.RegisterInstance(xmlSettings);
            c.RegisterInstance(binarySettings);
            c.RegisterInstance(databaseSettings);
            c.RegisterType<MainViewModel>();

            var window = new MainWindow
            {
                DataContext = c.Resolve<MainViewModel>("DatabaseRepository")
            };
            window.ShowDialog();
        }
    }
}
