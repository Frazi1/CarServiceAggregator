namespace ExceptionHandling
{
    public interface IErrorHandler
    {
        IErrorHandler SetError(IErrorReporter errorReporter);
        IErrorHandler SetErrorMessage(IErrorReporter errorReporter, string message);
    }
}