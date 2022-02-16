namespace Fdmc.Controllers
{
    using Fdmc.Data;
    using Fdmc.Data.Models;
    using Fdmc.ViewModels.Kittens;
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using System;
    using System.Linq;

    public class KittensController : Controller
    {
        private readonly ApplicationDbContext data;

        public KittensController(ApplicationDbContext data)
        {
            this.data = data;
        }

        [Authorize]
        public HttpResponse Add()
        {            
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Add(KittenFormModel model)
        {
            if (model.Name=="" || model.Age<0)
            {
                return BadRequest();
            }

            var kitten = new Kitten
            {
                Name = model.Name,
                Age = model.Age,
                Breed = (Breed)(model.Breed),
            };

            this.data.Kittens.Add(kitten);
            this.data.SaveChanges();

            return this.View();
        }


        [Authorize]
        public HttpResponse All()
        {
            var kittens = this.data.Kittens.Select(x => new KittenViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Age = x.Age.ToString(),
                Breed = x.Breed.ToString()
            });
            return this.View(kittens);
        }
    }
}
