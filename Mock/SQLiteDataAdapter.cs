using System.Data;

internal class SQLiteDataAdapter
{
    private SQLiteCommand sQLiteCommand;

    public SQLiteDataAdapter(SQLiteCommand sQLiteCommand)
    {
        this.sQLiteCommand = sQLiteCommand;
    }

    internal void Fill(DataTable result)
    {
        throw new NotImplementedException();
    }
}