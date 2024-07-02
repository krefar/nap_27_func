public class Citizen
{
    private readonly Passport _passport;
    private readonly bool _isVoted;

    public Citizen(Passport passport, bool isVoted)
    {
        _passport = passport ?? throw new ArgumentNullException(nameof(passport));
        _isVoted = isVoted;
    }

    public Passport Passport => _passport;

    public bool IsVoted => _isVoted;
}