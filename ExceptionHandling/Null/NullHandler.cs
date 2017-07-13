using System;

namespace ExceptionHandling.Null
{
    public class NullHandler : BasicExceptionHandler
    {
        public override IExceptionHandler Handle(Exception e)
        {
            return this;
        }

        public override ILogger Log(string message)
        {
            return this;
        }
    }
}