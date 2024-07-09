public class Passport
{
    private const string EnterPassportMessage = "Введите серию и номер паспорта";
    private const string WrongPassportFormatMessage = "Неверный формат серии или номера паспорта";
    private const int NumberLength = 10;

    public Passport(string number)
    {
        SerialNumber = string.IsNullOrWhiteSpace(number) ? throw new ArgumentOutOfRangeException(nameof(number)) : number;

        Validate();
    }

    public string SerialNumber { get; private set; }

    private void Validate()
    {
        if (SerialNumber == string.Empty)
        {
            throw new InvalidPassportException(EnterPassportMessage);
        }
        else if (SerialNumber.Length < NumberLength)
        {
            throw new InvalidPassportException(WrongPassportFormatMessage);
        }
    }
}