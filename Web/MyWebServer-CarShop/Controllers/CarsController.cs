namespace CarShop.Controllers
{
    using CarShop.Data;
    using CarShop.Data.Models;
    using CarShop.Services;    
    using CarShop.ViewModels.Cars;
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using System.Linq;

    public class CarsController : Controller
    {
        private readonly IValidator validator;
        private readonly ApplicationDbContext data;

        public CarsController(IValidator validator, ApplicationDbContext data)
        {
            this.validator = validator;
            this.data = data;
        }

        [Authorize]
        public HttpResponse All()
        {
            var user = this.data.Users.FirstOrDefault(x => x.Id == User.Id);


            if (user.IsMechanic==false)
            {
                // client
                var cars = this.data.Cars
                .Where(x => x.OwnerId == User.Id)
                .Select(c => new CarViewModel
                {
                    Id = c.Id,
                    Image = c.PictureUrl,
                    Model = c.Model,
                    PlateNumber = c.PlateNumber,
                    RemainingIssues = c.Issues.Count(i => i.IsFixed == false),
                    FixedIssues = c.Issues.Count(i => i.IsFixed),
                })
                .ToList();
                return View(cars);
            }
            else
            {
                // mechanic
                var cars = this.data.Cars
               .Where(x=>x.Issues.Count(i=>i.IsFixed==false)>0)
               .Select(c => new CarViewModel
               {
                   Id = c.Id,
                   Image = c.PictureUrl,
                   Model = c.Model,
                   PlateNumber = c.PlateNumber,
                   RemainingIssues = c.Issues.Count(i => i.IsFixed == false),
                   FixedIssues = c.Issues.Count(i => i.IsFixed),
               })
               .ToList();
                return View(cars);
            }

            
        }

        [Authorize]
        public HttpResponse Add()
        {
            var user = this.data.Users.FirstOrDefault(x=>x.Id==User.Id);
            
            if (user == null)
            {
                return Error("Current user does not exists.");
            }

            if (user.IsMechanic)
            {
                return Error("Mechanics cannot add cars.");
            }

            return View();
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Add(CarFormModel model)
        {
            var modelErrors = this.validator.ValidateCar(model);

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            var car = new Car
            {
                Model = model.Model,
                Year = model.Year,
                PictureUrl = model.Image,
                PlateNumber = model.PlateNumber,
                OwnerId = this.User.Id
            };

            this.data.Cars.Add(car);
            this.data.SaveChanges();

            return Redirect("/Cars/All");
        }

    }
}
