namespace ExceptionHandling
{
    public interface IErrorReporter
    {
        bool ErrorHappened { get; set; }
    }
}