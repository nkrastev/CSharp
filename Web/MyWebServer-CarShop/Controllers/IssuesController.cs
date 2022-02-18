namespace CarShop.Controllers
{
    using CarShop.Data;
    using CarShop.Data.Models;
    using CarShop.Services;
    using CarShop.ViewModels.Issues;
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using System.Linq;

    public class IssuesController : Controller
    {
        private readonly IValidator validator;
        private readonly ApplicationDbContext data;
        public IssuesController(IValidator validator, ApplicationDbContext data)
        {
            this.validator = validator;
            this.data = data;
        }

        [Authorize]       
        public HttpResponse Add(string carId)
        {
            if (carId == null || !this.data.Cars.Any(x => x.Id == carId))
            {
                return Error("Car Id is missing or invalid");
            }
            
            // todo check if car is owned by current user

            return View();
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Add(IssueFormModel model)
        {
            var car = this.data.Cars.FirstOrDefault(x => x.Id == model.CarId);
            var user = this.data.Users.FirstOrDefault(x => x.Id == User.Id);

            if (car == null || model==null)
            {
                return Error("Car not found for in DB or model for post is null.");
            }

            if (car.OwnerId != User.Id && user.IsMechanic==false)
            {
                return Error("This car is owned by another user.");
            }

            if (model.Description == "" || model.Description.Length<5)
            {
                return Error("Isssue description is required with min lenght of 5.");
            }

            var issue = new Issue
            {
                CarId = model.CarId,
                Description = model.Description,
            };

            this.data.Issues.Add(issue);
            this.data.SaveChanges();

            return Redirect($"/Issues/CarIssues?carId={model.CarId}");
        }

        [Authorize]
        public HttpResponse CarIssues(string carId)
        {           
            var car = this.data.Cars.FirstOrDefault(x => x.Id == carId);
            var user = this.data.Users.FirstOrDefault(x => x.Id == User.Id);
            
            if (car==null)
            {
                return Error("Target car does not exists");
            }

            if (car.OwnerId!=User.Id && !user.IsMechanic)
            {
                return Error("This car is owned by another user.");
            }

            var carModel = new IssuesCarViewModel
            {
                CarId = car.Id,
                Model = car.Model,
                Year = car.Year,
                IsCurrentUserMechanic = user.IsMechanic ? true: false,
                Issues = this.data.Issues.Where(x=>x.CarId==carId)
                    .Select(x => new IssueViewModel
                    {
                        Id = x.Id,
                        Description = x.Description,
                        IsFixed = x.IsFixed ? "Yes" : "Not yet",
                    }).ToList(),
            };

            return View(carModel);
        }

        [Authorize]
        public HttpResponse Delete(string issueId, string carId)
        {
            var issue = this.data.Issues.Where(x=>x.Id==issueId).FirstOrDefault();

            if (issue == null)
            {
                return Error("Invalid Issue Id");
            }

            this.data.Issues.Remove(issue);
            this.data.SaveChanges();

            return Redirect($"/Issues/CarIssues?CarId={carId}");
        }

        [Authorize]
        public HttpResponse Fix(string issueId, string carId)
        {
            var issue = this.data.Issues.Where(x => x.Id == issueId).FirstOrDefault();

            if (issue == null)
            {
                return Error("Invalid Issue Id");
            }

            issue.IsFixed= true;
            this.data.SaveChanges();

            return Redirect($"/Issues/CarIssues?CarId={carId}");
        }
    }
}
