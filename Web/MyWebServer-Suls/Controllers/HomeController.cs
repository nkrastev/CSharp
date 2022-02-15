namespace Suls.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using Suls.Services.Contracts;

    public class HomeController : Controller
    {
        private readonly IProblemService problemService;

        public HomeController(IProblemService problemService)
        {
            this.problemService = problemService;
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
            var problems = this.problemService.GetProblemsForHome();

            return this.View(problems);
        }
    }
}