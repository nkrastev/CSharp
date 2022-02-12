namespace Panda.Services.Contracts
{
    using System.Collections.Generic;

    public interface IUserService
    {
        string GetUsernameById(string id);

        List<string> GetAllUsernames();
    }
}
