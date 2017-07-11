using System;

namespace ExceptionHandling.Null
{
    public class NullHandler : IExceptionHandler
    {
        public void Handle(Exception e)
        {
        }

        public void Handle(Exception e, IErrorReporter errorReporter)
        {
            
        }

        public void SetError(IErrorReporter errorReporter)
        {     
        }
    }
}