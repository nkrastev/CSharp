namespace IRunes.Services
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
    }
}
