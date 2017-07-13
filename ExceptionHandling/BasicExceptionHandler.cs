using System;

namespace ExceptionHandling
{
    public abstract class BasicExceptionHandler : IExceptionHandler, ILogger
    {
        public abstract IExceptionHandler Handle(Exception e);
        public abstract ILogger Log(string message);

        public IErrorHandler SetError(IErrorReporter errorReporter)
        {
            errorReporter.ErrorHappened = true;
            return this;
        }

        public IErrorHandler SetErrorMessage(IErrorReporter errorReporter, string message)
        {
            errorReporter.ErrorMessage = message;
            return this;
        }
    }
}