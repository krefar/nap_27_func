﻿using System.Data;

public class Presenter
{
    private const string SuccessTextTemplate = "По паспорту «{0}» доступ к бюллетеню на дистанционном электронном голосовании ПРЕДОСТАВЛЕН";
    private const string FailTextTemplate = "По паспорту «{0}» доступ к бюллетеню на дистанционном электронном голосовании НЕ ПРЕДОСТАВЛЯЛСЯ";

    private const string SqlFileNotFoundError = "Файл db.sqlite не найден. Положите файл в папку вместе с exe.";

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
        try
        {
            var passport = new Passport(passportNumber);
            Citizen citizen = _searchCitizenService.GetCitizen(passport);

            _view.DisplayResult(GetResultMessage(citizen, passportNumber));
        }
        catch (SQLiteException ex)
        {
            _view.DisplayMessage(SqlFileNotFoundError);
        }
        catch (InvalidPassportException ex)
        {
            _view.DisplayMessage(ex.Message);
        }
        catch (SearchCitizenException ex)
        {
            _view.DisplayMessage(ex.Message);
        }
    }

    private string GetResultMessage(Citizen citizen, string passportNumber)
    {
        string messageTemplate = citizen.IsVoted ? SuccessTextTemplate : FailTextTemplate;

        return string.Format(messageTemplate, passportNumber);
    }
}