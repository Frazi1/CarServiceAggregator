using System;
using System.IO;
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
            RegisterLogger();
        }

        private static void RegisterLogger()
        {
            string appPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
            IocApp.Container.RegisterType<ILogger, Messenger>(new InjectionConstructor(appPath));
        }
    }
}