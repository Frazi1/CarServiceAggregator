using System;

namespace ExceptionHandling
{
    public interface IExceptionHandler : IErrorHandler
    {
        IExceptionHandler Handle(Exception e);
    }
}