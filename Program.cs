public class App
{
    private readonly dynamic _passportTextbox;
    private readonly dynamic _textResult;

    private readonly Model _model;
    private readonly View _view;
    private readonly Controller _controller;

    public App(dynamic passportTextbox, dynamic textResult)
    {
        _passportTextbox = passportTextbox;
        _textResult = textResult;

        _model = new Model();
        _view = new View(_passportTextbox, _textResult);
        _controller = new Controller(_model, _view);
    }

    private void checkButton_Click(object sender, EventArgs e)
    {
        _controller.PerformCheck();
    }
}