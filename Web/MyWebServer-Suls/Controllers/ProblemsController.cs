namespace Suls.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using Suls.Services;
    using Suls.Services.Contracts;
    using Suls.ViewModels.Problems;
    using System.Linq;

    public class ProblemsController : Controller
    {
        private readonly IValidator validator;
        private readonly IProblemService problemService;

        public ProblemsController(IValidator validator, IProblemService problemService)
        {
            this.validator = validator;
            this.problemService = problemService;
        }

        [Authorize]
        public HttpResponse Create()
        {            
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Create(ProblemFormModel model)
        {
            var modelErrors = this.validator.ValidateProblem(model);

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            this.problemService.AddProblem(User.Id, model);

            return Redirect("/");
        }

        [Authorize]
        public HttpResponse Details(string id)
        {
            var problem = this.problemService.GetDetailsById(id);
            
            return View(problem);
        }
    }
}
