namespace SharedTrip.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using SharedTrip.Data;
    using SharedTrip.Models;
    using SharedTrip.Services;
    using SharedTrip.ViewModels;
    using System.Linq;

    public class TripsController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly IValidator validator;

        public TripsController(ApplicationDbContext data, IValidator validator)
        {
            this.data = data;
            this.validator = validator;
        }                

        [Authorize]
        public HttpResponse All()
        {
            var all = this.data.Trips.Select(x => new TripViewModel
            {
                Id = x.Id,
                Start = x.StartPoint,
                End = x.EndPoint,
                DepartureTime = x.DepartureTime.ToString(),
                Seats = x.Seats,
                Description = x.Description,
                ImagePath = x.ImagePath
            }).ToList();

            return this.View(all);
        }

        [Authorize]
        public HttpResponse Add()
        {
            return View();
        }

        [HttpPost]
        [Authorize]        
        public HttpResponse Add(AddTripFormModel model)
        {
            var modelErrors = this.validator.ValidateTrip(model);

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            var trip = new Trip()
            {
                StartPoint = model.StartPoint,
                EndPoint = model.EndPoint,
                DepartureTime = model.DepartureTime,
                Description = model.Description,
                Seats = model.Seats,
                ImagePath = model.ImagePath
            };

            this.data.Trips.Add(trip);          
            this.data.SaveChanges();

            return this.Redirect("All");
        }

        [Authorize]
        public HttpResponse Details(string tripId)
        {

            if (!this.data.Trips.Where(x=>x.Id == tripId).Any())
            {
                return Error("Trip does not exist");
            }

            var trip = this.data.Trips
                .Where(x => x.Id == tripId)
                .Select(x => new TripDetailsViewModel
                {
                    Id = x.Id,
                    Start = x.StartPoint,
                    End = x.EndPoint,
                    DepartureTime = x.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                    Seats = x.Seats,
                    Description = x.Description,
                    ImagePath = x.ImagePath
                }).FirstOrDefault();

            return this.View(trip);
        }


        [Authorize]
        public HttpResponse AddUserToTrip(string tripId)
        {
            if (!this.data.Trips.Where(x => x.Id == tripId).Any())
            {
                return Error("Trip does not exist");
            }
            
            var trip = this.data.Trips.Where(x => x.Id == tripId).FirstOrDefault();

            

            var userTrip = new UserTrip
            {
                TripId = tripId,
                UserId = this.User.Id,
            };

            if (this.data.UsersTrips.Where(x => x.TripId == tripId && x.UserId==this.User.Id).Any())
            {
                return Error("This user is already added to this trip");
            }

            this.data.UsersTrips.Add(userTrip);
            this.data.SaveChanges();

            return Redirect("/");
        }
    }
}
