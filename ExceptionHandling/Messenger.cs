using System;
using System.Windows;

namespace ExceptionHandling
{
    public class Messenger : IExceptionHandler, ILogger
    {
        public void Handle(Exception e)
        {
            Log(e.Message);
        }

        public void Log(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}