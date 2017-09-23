using System;

namespace ExceptionHandling.Null
{
    public class NullLogger : ILogger
    {
        public void Log(Exception e)
        {
            throw e;
        }

        public void Log(string text)
        {
            
        }

        public void SetError(IErrorReporter errorReporter)
        {
            errorReporter.ErrorHappened = true;
        }
    }
}