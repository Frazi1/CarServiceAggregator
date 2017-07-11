using System;

namespace ExceptionHandling
{
    public abstract class BasicExceptionHandler : IExceptionHandler, ILogger
    {
        public abstract void Handle(Exception e);
        public abstract void Handle(Exception e, IErrorReporter errorReporter);
        public abstract void Log(string message);
        public abstract void SetError(IErrorReporter errorReporter);
    }
}