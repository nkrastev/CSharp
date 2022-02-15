namespace Suls.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using Suls.Services;
    using Suls.Services.Contracts;
    using Suls.ViewModels.Submissions;
    using System.Linq;

    public class SubmissionsController : Controller
    {
        private readonly IValidator validator;
        private readonly ISubmissionService submissionService;
        private readonly IProblemService problemService;

        public SubmissionsController(IValidator validator, ISubmissionService submissionService, IProblemService problemService)
        {
            this.validator = validator;
            this.submissionService = submissionService;
            this.problemService = problemService;
        }

        [Authorize]
        public HttpResponse Create(string id)
        {
            var name = this.problemService.GetNameById(id);
            var model = new SubmissionCreateViewModel
            {
                Name = name,
                ProblemId = id
            };
            return this.View(model);
        }
        
        [Authorize]
        [HttpPost]
        public HttpResponse Create(string id, SubmissionFormModel model)
        {
            var modelErrors = this.validator.ValidateSubmission(model);

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            this.submissionService.AddSubmission(User.Id, model);

            return Redirect("/");
        }

        [Authorize]
        public HttpResponse Delete(string id)
        {
            this.submissionService.DeleteById(id);
            return Redirect("/");
        }
    }
}
