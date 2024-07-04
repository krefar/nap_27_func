public class HashService : IHashService
{
    public string ComputeHash(string text)
    {
        return ComputeSha256Hash(text);
    }

    private string ComputeSha256Hash(string text)
    {
        throw new NotImplementedException();
    }
}