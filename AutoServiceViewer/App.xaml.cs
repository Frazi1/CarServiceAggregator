using System;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Markup;
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
            SetUpCulture();
        }

        private static void SetUpCulture()
        {
            // Ensure the current culture passed into bindings is the OS culture.
            // By default, WPF uses en-US as the culture, regardless of the system settings.
            FrameworkElement.LanguageProperty.OverrideMetadata(
                typeof(FrameworkElement),
                new FrameworkPropertyMetadata(
                    XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));
        }

        private static void RegisterLogger()
        {
            string appPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
            IocApp.RegisterLogger<Messenger>(new InjectionConstructor(appPath));
        }
    }
}