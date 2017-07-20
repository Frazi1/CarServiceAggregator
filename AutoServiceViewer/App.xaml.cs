using System;
using System.Configuration;
using System.IO;
using AutoServiceViewer.UnityExtensions;
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
            //RegisterDbRepository();
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

        //private static void RegisterDbRepository()
        //{
        //    UnityDatabaseRepositoryExtension databaseExtension = new UnityDatabaseRepositoryExtension(
        //        ConfigurationManager
        //            .ConnectionStrings["mysql"]
        //            .ConnectionString);
        //    IocApp.Container.AddExtension(databaseExtension);
        //}

        private static void RegisterLogger()
        {
            string appPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
            IocApp.Container.RegisterType<ILogger, Messenger>(new InjectionConstructor(appPath));
        }
    }
}