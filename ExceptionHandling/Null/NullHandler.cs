using System;

namespace ExceptionHandling.Null
{
    public class NullHandler : IExceptionHandler
    {
        public IErrorHandler SetError(IErrorReporter errorReporter)
        {
            return this;
        }

        public IExceptionHandler Handle(Exception e)
        {
            return this;
        }
    }
}