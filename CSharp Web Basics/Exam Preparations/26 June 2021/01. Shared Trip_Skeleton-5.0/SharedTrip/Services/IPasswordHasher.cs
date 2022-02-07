namespace SharedTrip.Services
{
    public interface IPasswordHasher
    {
        string Hash(string password);
    }
}
