namespace IRunes.Controllers
{
    using IRunes.Data;
    using IRunes.Data.Models;
    using IRunes.Services;
    using IRunes.ViewModels.Tracks;
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using System.Linq;

    public class TracksController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly IValidator validator;

        public TracksController(ApplicationDbContext data, IValidator validator)
        {
            this.data = data;
            this.validator = validator;
        }

       

        [Authorize]
        public HttpResponse Create(string albumId)
        {            
            var track = new TrackViewModel { AlbumId = albumId };
            return View(track);
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Create(string albumId, TrackFormModel model)
        {
            // validation doesnt validate, 500 error

            var modelErrors = this.validator.ValidateTrack(model);

            if (modelErrors.Any())
            {
                return BadRequest();
            }


            var track = new Track
            {
                Name = model.Name,
                Link = model.Link,
                Price = model.Price,
                AlbumId = albumId
            };

            this.data.Tracks.Add(track);
            this.data.SaveChanges();
            return Redirect("/Albums/All");
        }

        [Authorize]
        public HttpResponse Details(string albumId, string trackId)
        {
            if (!this.data.Albums.Any(x => x.Id == albumId))
            {
                return BadRequest();
            }
            if (!this.data.Tracks.Any(x=>x.Id==trackId))
            {
                return BadRequest();
            }

            var track = this.data.Tracks.Where(x => x.Id == trackId).Select(x => new TrackDetailsViewModel
            {
                Name=x.Name,
                Price=x.Price.ToString("F2"),
                IFrameSource=x.Link,
                AlbumId=albumId,                
            }).FirstOrDefault();

            return View(track);
        }
    }
}
