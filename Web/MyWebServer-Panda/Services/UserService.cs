namespace Panda.Services
{
    using Panda.Data;
    using Panda.Services.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class UserService : IUserService
    {
        private readonly ApplicationDbContext data;

        public UserService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public string GetUsernameById(string id)
        {
            var currentUser = this.data.Users.Where(x=>x.Id == id).FirstOrDefault();

            if (currentUser==null)
            {
                return "Error Getting User";
            }
            else
            {
                return currentUser.Username;
            }
        }

        public List<string> GetAllUsernames()
        {
            return this.data.Users.Select(x=>x.Username).ToList();
        }
    }
}
