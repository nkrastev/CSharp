namespace IRunes.Controllers
{
    using IRunes.Data;
    using IRunes.ViewModels.Users;
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
                return Redirect("/Home/Home");
            }
            return this.View();
        }

        [Authorize]
        public HttpResponse Home()
        {
            var username = this.data.Users.Where(x => x.Id == User.Id).FirstOrDefault();
            var model = new UsernameViewModel
            {
                Username = username.Username,
            };
            return this.View(model);
        }
    }
}