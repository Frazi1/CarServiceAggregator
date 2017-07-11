using System;
using System.Windows;

namespace ExceptionHandling
{
    public class Messenger : BasicExceptionHandler
    {
        public override void Handle(Exception e)
        {
            Log(e.Message);
        }

        public override void Handle(Exception e, IErrorReporter errorReporter)
        {
            Handle(e);
            SetError(errorReporter);
        }

        public override void Log(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public override void SetError(IErrorReporter errorReporter)
        {
            errorReporter.ErrorHappened = true;
        }
    }
}