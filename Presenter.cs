using System.Data;

public class Presenter
{
    private const string EnterPassportMessage = "Введите серию и номер паспорта";
    private const string WrongPassportFormatMessage = "Неверный формат серии или номера паспорта";

    private const string SuccessTextTemplate = "По паспорту «{0}» доступ к бюллетеню на дистанционном электронном голосовании ПРЕДОСТАВЛЕН";
    private const string FailTextTemplate = "По паспорту «{0}» доступ к бюллетеню на дистанционном электронном голосовании НЕ ПРЕДОСТАВЛЯЛСЯ";
    private const string NotFoundTextTemplate = "Паспорт «{0}» в списке участников дистанционного голосования НЕ НАЙДЕН";

    private readonly View _view;
    private readonly ISearchCitizenService _searchCitizenService;

    public Presenter(View view, ISearchCitizenService searchCitizenService)
    {
        _view = view;
        _searchCitizenService = searchCitizenService;
    }

    public void PerformCheck()
    {
        string passportNumber = _view.GetPasportNumber();

        ValidateInput(passportNumber);
    }

    private void ValidateInput(string passportNumber)
    {
        if (passportNumber == string.Empty)
        {
            _view.DisplayMessage(EnterPassportMessage);
        }
        else if (passportNumber.Length < 10)
        {
            _view.DisplayResult(WrongPassportFormatMessage);
        }
        else
        {
            CheckPassport(passportNumber);
        }
    }

    private void CheckPassport(string passportNumber)
    {
        Citizen? citizen = null;

        try
        {
            citizen = _searchCitizenService.GetCitizen(passportNumber);
        }
        catch (SearchCitizenException ex)
        {
            _view.DisplayMessage(ex.Message);
        }

        _view.DisplayResult(GetResultMessage(citizen, passportNumber));
    }

    private dynamic GetResultMessage(Citizen? citizen, string passportNumber)
    {
        string messageTemplate = NotFoundTextTemplate;

        if (citizen != null)
        {
            messageTemplate = citizen.IsVoted ? SuccessTextTemplate : FailTextTemplate;
        }

        return string.Format(messageTemplate, passportNumber);
    }
}