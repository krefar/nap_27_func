using System.Data;

public class SearchCitizenService : ISearchCitizenService
{
    private const string NotFoundTextTemplate = "Паспорт «{0}» в списке участников дистанционного голосования НЕ НАЙДЕН";

    private readonly IDatabaseService _databaseService;
    private readonly IHashService _hashService;

    public SearchCitizenService(IDatabaseService databaseService, IHashService hashService)
    {
        _databaseService = databaseService ?? throw new ArgumentNullException(nameof(databaseService));
        _hashService = hashService ?? throw new ArgumentNullException(nameof(hashService));
    }

    public Citizen GetCitizen(Passport passport)
    {
        if (passport == null)
            throw new ArgumentNullException(nameof(passport));

        string passportHash = _hashService.ComputeHash(passport.SerialNumber);

        DataTable searchResult = _databaseService.GetCitizenData(passportHash);

        return ConvertResultToCitizen(searchResult);
    }

    private Citizen ConvertResultToCitizen(DataTable searchResult)
    {
        if (searchResult == null)
            throw new ArgumentNullException(nameof(searchResult));

        if (searchResult.Rows.Count == 0)
            throw new SearchCitizenException(NotFoundTextTemplate);

        string pasportNum = Convert.ToString(searchResult.Rows[0].ItemArray[0]);
        bool isVoted = Convert.ToBoolean(searchResult.Rows[0].ItemArray[1]);

        return new Citizen(new Passport(pasportNum), isVoted);
    }
}