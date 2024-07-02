using System.Data;

public class SearchCitizenService : ISearchCitizenService
{
    private const string SqlFileNotFoundError = "Файл db.sqlite не найден. Положите файл в папку вместе с exe.";

    private readonly DatabaseService _databaseService;

    public SearchCitizenService(DatabaseService databaseService)
    {
        _databaseService = databaseService ?? throw new ArgumentNullException(nameof(databaseService));
    }

    public Citizen? GetCitizen(string passportNumber)
    {
        DataTable searchResult = new DataTable();

        try
        {
            searchResult = _databaseService.GetCitizenData(passportNumber);
        }
        catch (SQLiteException ex)
        {
            if (ex.ErrorCode != 1)
                throw;

            throw new SearchCitizenException(SqlFileNotFoundError);
        }

        return ConverResultToCitizen(searchResult);
    }

    private Citizen? ConverResultToCitizen(DataTable searchResult)
    {
        if (searchResult.Rows.Count > 0)
        {
            string pasportNum = Convert.ToString(searchResult.Rows[0].ItemArray[0]);
            bool isVoted = Convert.ToBoolean(searchResult.Rows[0].ItemArray[1]);

            return new Citizen(new Passport(pasportNum), isVoted);
        }

        return null;
    }
}