namespace Fdmc.Controllers
{
    using Fdmc.Data;
    using Fdmc.ViewModels.Users;
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using System.Linq;

    public class HomeController : Controller
    {
        private readonly ApplicationDbContext data;

        public HomeController(ApplicationDbContext data)
        {
            this.data = data;
        }
        
        public HttpResponse Index()
        {
            if (this.User.IsAuthenticated)
            {
                return Redirect("/Home/IndexLoggedIn");
            }
            return this.View();
        }

        [Authorize]
        public HttpResponse IndexLoggedIn()
        {
            var user = this.data.Users.Where(x => x.Id == User.Id).FirstOrDefault();
            var model = new UserHomeViewModel
            {
                Username = user.Username,
            };
            return this.View(model);
        }



    }
}