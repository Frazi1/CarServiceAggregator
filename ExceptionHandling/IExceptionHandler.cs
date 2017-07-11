using System;

namespace ExceptionHandling
{
    public interface IExceptionHandler
    {
        void Handle(Exception e);
    }
}