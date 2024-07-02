public class App
{
    private readonly dynamic _passportTextbox;
    private readonly dynamic _textResult;

    private readonly View _view;
    private readonly Presenter _presenter;
    private readonly ISearchCitizenService _searchCitizenService;

    public App(dynamic passportTextbox, dynamic textResult)
    {
        _passportTextbox = passportTextbox;
        _textResult = textResult;

        _view = new View(_passportTextbox, _textResult);
        _searchCitizenService = new SearchCitizenService(new DatabaseService());
        _presenter = new Presenter(_view, _searchCitizenService);
    }

    private void checkButton_Click(object sender, EventArgs e)
    {
        _presenter.PerformCheck();
    }
}