public class View : IView
{
    private readonly dynamic _passportTextbox;
    private readonly dynamic _textResult;

    private readonly Presenter _presenter;
    private readonly ISearchCitizenService _searchCitizenService;

    public View(dynamic passportTextbox, dynamic textResult)
    {
        _passportTextbox = passportTextbox;
        _textResult = textResult;

        _searchCitizenService = new SearchCitizenService(new DatabaseService(), new HashService());
        _presenter = new Presenter(this, _searchCitizenService);
    }

    private void CheckButtonClicked(object sender, EventArgs e)
    {
        _presenter.PerformCheck(_passportTextbox.Text);
    }

    public void DisplayResult(string resultText)
    {
        _textResult.Text = resultText;
    }

    public void DisplayMessage(string message)
    {
        DialogResult dialogResult = MessageBox.Show(message);
    }
}