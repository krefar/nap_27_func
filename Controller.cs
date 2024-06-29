using System.Data;

public class Controller
{
    private const string EnterPassportMessage = "Введите серию и номер паспорта";
    private const string WrongPassportFormatMessage = "Неверный формат серии или номера паспорта";

    private const string SuccessTextTemplate = "По паспорту «{0}» доступ к бюллетеню на дистанционном электронном голосовании ПРЕДОСТАВЛЕН";
    private const string FailTextTemplate = "По паспорту «{0}» доступ к бюллетеню на дистанционном электронном голосовании НЕ ПРЕДОСТАВЛЯЛСЯ";
    private const string NotFoundTextTemplate = "Паспорт «{0}» в списке участников дистанционного голосования НЕ НАЙДЕН";

    private const string SqlFileNotFoundError = "Файл db.sqlite не найден. Положите файл в папку вместе с exe.";

    private readonly Model _model;
    private readonly View _view;

    public Controller(Model model, View view)
    {
        _model = model;
        _view = view;
    }

    public void PerformCheck()
    {
        string passportText = _view.GetPasportText();

        ValidateInput(passportText);
    }

    private void ValidateInput(string passportText)
    {
        if (passportText == "")
        {
            _view.DisplayMessage(EnterPassportMessage);
        }
        else if (passportText.Length < 10)
        {
            _view.DisplayResult(WrongPassportFormatMessage);
        }
        else
        {
            CheckPassport(passportText);
        }
    }

    private void CheckPassport(string passportText)
    {
        var data = new DataTable();

        try
        {
            data = _model.GetData(passportText);
        }
        catch (SQLiteException ex)
        {
            if (ex.ErrorCode != 1)
                throw;

            _view.DisplayMessage(SqlFileNotFoundError);
        }

        _view.DisplayResult(GetResultMessage(passportText, data));
    }

    private dynamic GetResultMessage(string passportText, DataTable dataTable)
    {
        string messageTemplate = NotFoundTextTemplate;

        if (dataTable.Rows.Count > 0)
        {
            bool isValid = Convert.ToBoolean(dataTable.Rows[0].ItemArray[1]);

            messageTemplate = isValid ? SuccessTextTemplate : FailTextTemplate;
        }

        return string.Format(messageTemplate, passportText);
    }
}