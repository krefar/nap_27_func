using System.Data;

public class Presenter
{
    private const string SuccessTextTemplate = "По паспорту «{0}» доступ к бюллетеню на дистанционном электронном голосовании ПРЕДОСТАВЛЕН";
    private const string FailTextTemplate = "По паспорту «{0}» доступ к бюллетеню на дистанционном электронном голосовании НЕ ПРЕДОСТАВЛЯЛСЯ";
    

    private readonly IView _view;
    private readonly ISearchCitizenService _searchCitizenService;

    public Presenter(IView view, ISearchCitizenService searchCitizenService)
    {
        _view = view;
        _searchCitizenService = searchCitizenService;
    }

    public void PerformCheck(string passportNumber)
    {
        CheckPassport(passportNumber);
    }

    private void CheckPassport(string passportNumber)
    {
        Passport passport;

        try
        {
            passport = new Passport(passportNumber);
        }
        catch (InvalidPassportException ex)
        {
            _view.DisplayMessage(ex.Message);
            return;
        }

        Citizen? citizen = null;

        try
        {
            citizen = _searchCitizenService.GetCitizen(passport);
        }
        catch (SearchCitizenException ex)
        {
            _view.DisplayMessage(ex.Message);
            return;
        }

        _view.DisplayResult(GetResultMessage(citizen, passportNumber));
    }

    private dynamic GetResultMessage(Citizen? citizen, string passportNumber)
    {
        string messageTemplate = citizen.IsVoted ? SuccessTextTemplate : FailTextTemplate;

        return string.Format(messageTemplate, passportNumber);
    }
}