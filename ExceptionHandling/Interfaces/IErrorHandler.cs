namespace ExceptionHandling
{
    public interface IErrorHandler
    {
        IErrorHandler SetError(IErrorReporter errorReporter);
    }
}