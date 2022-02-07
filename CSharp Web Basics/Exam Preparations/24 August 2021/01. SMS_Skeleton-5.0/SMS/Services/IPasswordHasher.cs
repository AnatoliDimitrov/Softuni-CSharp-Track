namespace SMS.Services
{
    public interface IPasswordHasher
    {
        string Hash(string password);
    }
}
