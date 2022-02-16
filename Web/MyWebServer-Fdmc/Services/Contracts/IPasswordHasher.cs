namespace Fdmc.Services
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
    }
}
