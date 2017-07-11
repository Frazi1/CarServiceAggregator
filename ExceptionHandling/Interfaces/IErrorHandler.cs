namespace ExceptionHandling
{
    public interface IErrorHandler
    {
        void SetError(IErrorReporter errorReporter);
    }
}