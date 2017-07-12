using System;

namespace ExceptionHandling
{
    public abstract class BasicExceptionHandler : IExceptionHandler, ILogger
    {
        public abstract IExceptionHandler Handle(Exception e);
        public abstract ILogger Log(string message);
        public abstract IErrorHandler SetError(IErrorReporter errorReporter);
    }
}