namespace Panda.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using Panda.Services.Contracts;
    using Panda.ViewModels.Users;

    public class HomeController : Controller
    {
        private readonly IUserService userService;

        public HomeController(IUserService userService)
        {
            this.userService = userService;
        }

        public HttpResponse Index()
        {
           
            return View();
        }

        [Authorize]
        public HttpResponse IndexLoggedIn()
        {
            var username = this.userService.GetUsernameById(this.User.Id);
            var viewData = new HomeLoggedInUserViewModel
            {
                Username = username,
            };
            return View(viewData);
        }
    }
}