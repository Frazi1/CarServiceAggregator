using System;

namespace ExceptionHandling
{
    public interface IExceptionHandler : IErrorHandler
    {
        void Handle(Exception e);
        void Handle(Exception e, IErrorReporter errorReporter);
    }
}