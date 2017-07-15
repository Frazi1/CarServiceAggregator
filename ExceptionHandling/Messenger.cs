using System;
using System.Windows;

namespace ExceptionHandling
{
    public class Messenger : FileLogger
    {
        public Messenger(string logDirectoryPath)
            : base(logDirectoryPath)
        {
        }

        public override void Log(Exception e)
        {
            base.Log(e);
            MessageBox.Show(e.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}