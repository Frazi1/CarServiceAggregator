using System;

namespace ExceptionHandling.Null
{
    public class NullHandler : BasicExceptionHandler
    {
        public override IExceptionHandler Handle(Exception e)
        {
            throw e;
        }

        public override ILogger Log(string message)
        {
            return this;
        }
    }
}