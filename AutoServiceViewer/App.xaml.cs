using AutoServiceViewer.ViewModel;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
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
            IocApp.Initialize();
        }
    }
}
