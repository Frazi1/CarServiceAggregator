namespace ExceptionHandling.Null
{
    public class NullLogger : ILogger
    {
        public ILogger Log(string message)
        {
            return this;
        }
    }
}