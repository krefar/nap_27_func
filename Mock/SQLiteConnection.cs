
internal class SQLiteConnection
{
    private string connectionString;

    public SQLiteConnection(string connectionString)
    {
        this.connectionString = connectionString;
    }

    internal void Close()
    {
        throw new NotImplementedException();
    }

    internal void Open()
    {
        throw new NotImplementedException();
    }
}