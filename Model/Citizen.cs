public class Citizen
{
    public Citizen(Passport passport, bool isVoted)
    {
        Passport = passport ?? throw new ArgumentNullException(nameof(passport));
        IsVoted = isVoted;
    }

    public Passport Passport { get; private set; }

    public bool IsVoted { get; private set; }
}