namespace Panda.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using Panda.Services;
    using Panda.Services.Contracts;
    using Panda.ViewModels.Packages;
    using System.Linq;

    public class PackagesController : Controller
    {
        private readonly IUserService userService;
        private readonly IValidator validator;
        private readonly IPackageService packageService;

        public PackagesController(
            IUserService userService, 
            IPackageService packageService,
            IValidator validator)
        {
            this.userService = userService;
            this.packageService = packageService;
            this.validator = validator;
        }

        [Authorize]
        public HttpResponse Create()
        {
            var allUsernames = this.userService.GetAllUsernames();            
            return View(allUsernames);
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Create(CreatePackageFormModel model)
        {
            var modelErrors = this.validator.ValidateCreatePackage(model);

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            model.RecipientId = this.User.Id;

            this.packageService.Create(model);

            return Redirect("/");
        }

        [Authorize]
        public HttpResponse Pending()
        {
            var pendingPackages = this.packageService.GetPending();
            return View(pendingPackages);
        }

        [Authorize]
        public HttpResponse Delivered()
        {
            var deliveredPackages = this.packageService.GetDelivered();
            return View(deliveredPackages);
        }

        [Authorize]
        public HttpResponse Deliver(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            this.packageService.Deliver(id);

            return Redirect("/Packages/Pending");
        }


    }
}
