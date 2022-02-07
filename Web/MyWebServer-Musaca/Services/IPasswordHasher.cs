namespace MUSACA.Services
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
    }
}
