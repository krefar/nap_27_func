public class Passport
{
    private readonly string _number;

    public Passport(string number)
    {
        _number = string.IsNullOrWhiteSpace(number) ? throw new ArgumentOutOfRangeException(nameof(number)) : number;
    }

    public string Num => _number;
}