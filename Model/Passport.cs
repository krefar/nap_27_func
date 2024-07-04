public class Passport
{
    private const string EnterPassportMessage = "Введите серию и номер паспорта";
    private const string WrongPassportFormatMessage = "Неверный формат серии или номера паспорта";
    private const int NumberLength = 10;

    private readonly string _number;

    public Passport(string number)
    {
        _number = string.IsNullOrWhiteSpace(number) ? throw new ArgumentOutOfRangeException(nameof(number)) : number;

        Validate();
    }

    public string SerialNumber => _number;

    private void Validate()
    {
        if (_number == string.Empty)
        {
            throw new InvalidPassportException(EnterPassportMessage);
        }
        else if (_number.Length < NumberLength)
        {
            throw new InvalidPassportException(WrongPassportFormatMessage);
        }
    }
}