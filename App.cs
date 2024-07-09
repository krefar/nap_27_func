public class App
{
    private readonly dynamic _passportTextbox;
    private readonly dynamic _textResult;

    private readonly IView _view;

    public App(dynamic passportTextbox, dynamic textResult)
    {
        _passportTextbox = passportTextbox;
        _textResult = textResult;

        _view = new View(_passportTextbox, _textResult);
    }
}