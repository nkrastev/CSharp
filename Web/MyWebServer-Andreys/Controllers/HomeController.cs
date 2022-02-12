namespace Andreys.App.Controllers
{
    using Andreys.Data;
    using Andreys.ViewModels.Products;
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using System.Linq;

    public class HomeController : Controller
    {
        private readonly AndreysDbContext data;

        public HomeController(AndreysDbContext data)
        {
            this.data = data;
        }

        public HttpResponse Index()
        {           
            return this.View();
        }

        [Authorize]
        public HttpResponse Home()
        {
            var allProducts = this.data.Products.Select(p => new HomeViewModel
            {
                Id = p.Id,
                Name = p.Name,
                ImageUrl = p.ImageUrl,
                Price = p.Price.ToString("F2"),
            }).ToList();

            return this.View(allProducts);
        }
    }
}
