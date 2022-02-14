namespace IRunes.Controllers
{
    using IRunes.Data;
    using IRunes.Data.Models;
    using IRunes.Services;
    using IRunes.ViewModels.Albums;
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using System.Collections.Generic;
    using System.Linq;

    public class AlbumsController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly IValidator validator;

        public AlbumsController(ApplicationDbContext data, IValidator validator)
        {
            this.data = data;
            this.validator = validator;
        }

        [Authorize]
        public HttpResponse All()
        {
            var allAlbums = this.data.Albums.Select(x=> new AlbumViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Cover = x.Cover,
                Price = x.Price.ToString("F2"),
            })
            .ToList();

            return View(allAlbums);
        }

        [Authorize]
        public HttpResponse Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Create(AlbumFormModel model)
        {
            var modelErrors = this.validator.ValidateAlbum(model);

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            var album = new Album
            {
                Name = model.Name,
                Cover = model.Cover,
            };

            this.data.Albums.Add(album);
            this.data.SaveChanges();

            return View();
        }

        [Authorize]
        public HttpResponse Details(string id)
        {
            var album = this.data.Albums.Where(x => x.Id == id).ToArray().Select(x => new AlbumViewModel
            {
                Id=x.Id,
                Name = x.Name,
                Cover = x.Cover,
                Price = "",
                Tracks = this.data.Tracks.Where(t=>t.AlbumId==id).ToList(),
            })
                .FirstOrDefault(); 

            if (album == null)
            {
                return BadRequest();
            }

            var albumPrice = this.data.Tracks.Where(x => x.AlbumId == id).ToList();
            decimal totalPrice = 0.0m;

            foreach (var item in albumPrice)
            {
                totalPrice += item.Price;
            }

            album.Price = totalPrice.ToString("F2");

            return View(album);
        }
    }
}
