using System.Runtime.Serialization;

[Serializable]
internal class SQLiteException : Exception
{
    public SQLiteException()
    {
    }

    public SQLiteException(string? message) : base(message)
    {
    }

    public SQLiteException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected SQLiteException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public int ErrorCode { get; internal set; }
}