using System.Data;
using System.Reflection;

public class DatabaseService : IDatabaseService
{
    public DataTable GetCitizenData(string pasportHash)
    {
        var result = new DataTable();

        string commandText = $"select * from passports where num='{pasportHash}' limit 1;";

        string dirName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        string connectionString = $"Data Source={dirName}\\db.sqlite";

        var connection = new SQLiteConnection(connectionString);
        connection.Open();

        SQLiteDataAdapter sqLiteDataAdapter = new SQLiteDataAdapter(new SQLiteCommand(commandText, connection));
        sqLiteDataAdapter.Fill(result);

        connection.Close();

        return result;
    }
}
