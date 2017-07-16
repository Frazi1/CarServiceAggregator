using System;
using System.Configuration;
using System.IO;
using System.Text;
using System.Windows;
using AutoServiceViewer.RepositoryRegistrator;
using ExceptionHandling;
using Microsoft.Practices.Unity;

namespace AutoServiceViewer
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public App()
        {
            RegisterDbRepository();
            RegisterLogger();
            //Current.Dispatcher.UnhandledException += Dispatcher_UnhandledException;
        }

        //private static void Dispatcher_UnhandledException(object sender,
        //    System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        //{
        //    HandleException(e.Exception);
        //    e.Handled = true;
        //}

        //private static void HandleException(Exception e)
        //{
        //    StringBuilder s = new StringBuilder();
        //    var ex = e;
        //    while (ex != null)
        //    {
        //        s.Append(ex.Message);
        //        ex = ex.InnerException;
        //    }
        //    MessageBox.Show(s.ToString());
        //}

        private static void RegisterDbRepository()
        {
            DatabaseRepositoryRegistrator configurator = new DatabaseRepositoryRegistrator
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["mysql"].ConnectionString
            };
            configurator.Register(IocApp.Container);
        }

        private static void RegisterLogger()
        {
            string appPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
            IocApp.Container.RegisterType<ILogger, Messenger>(new InjectionConstructor(appPath));
        }
    }
}