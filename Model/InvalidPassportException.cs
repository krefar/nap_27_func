public class InvalidPassportException : Exception
{
    public readonly new string Message;

    public InvalidPassportException(string message)
    {
        Message = message;
    }
}