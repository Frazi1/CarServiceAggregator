using System;
using System.Windows;

namespace ExceptionHandling
{
    public class Messenger : BasicExceptionHandler
    {
        public override IExceptionHandler Handle(Exception e)
        {
            Log(e.Message);
            return this;
        }

        //public void Handle(Exception e, IErrorReporter errorReporter)
        //{
        //    Handle(e);
        //    SetError(errorReporter);
        //}

        public override ILogger Log(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return this;
        }

        public override IErrorHandler SetError(IErrorReporter errorReporter)
        {
            errorReporter.ErrorHappened = true;
            return this;
        }
    }
}