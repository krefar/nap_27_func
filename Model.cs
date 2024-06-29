
using System.Data;
using System.Reflection;

public class Model
{
    public DataTable GetData(string passportText)
    {
        var result = new DataTable();

        string pasportHash = ComputeSha256Hash(passportText);
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

    private string ComputeSha256Hash(string passportText)
    {
        throw new NotImplementedException();
    }
}