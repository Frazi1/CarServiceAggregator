using System;
using System.Text;
using System.Windows;

namespace AutoServiceViewer
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public App()
        {
            Current.Dispatcher.UnhandledException += Dispatcher_UnhandledException;
        }

        private static void Dispatcher_UnhandledException(object sender,
            System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            HandleException(e.Exception);
            e.Handled = true;
        }

        private static void HandleException(Exception e)
        {
            StringBuilder s = new StringBuilder();
            var ex = e;
            while (ex != null)
            {
                s.Append(ex.Message);
                ex = ex.InnerException;
            }
            MessageBox.Show(s.ToString());
        }
    }
}