internal class SQLiteCommand
{
    private string commandText;
    private SQLiteConnection connection;

    public SQLiteCommand(string commandText, SQLiteConnection connection)
    {
        this.commandText = commandText;
        this.connection = connection;
    }
}