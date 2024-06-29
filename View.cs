public class View
{
    private readonly dynamic _passportTextbox;
    private readonly dynamic _textResult;

    public View(dynamic passportTextbox, dynamic textResult)
    {
        _passportTextbox = passportTextbox;
        _textResult = textResult;
    }

    public string GetPasportText()
    {
        return _passportTextbox.Text;
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