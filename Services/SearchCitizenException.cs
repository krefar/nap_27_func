public class SearchCitizenException : Exception
{
    public readonly new string Message;

    public SearchCitizenException(string message)
    {
        Message = message;
    }
}