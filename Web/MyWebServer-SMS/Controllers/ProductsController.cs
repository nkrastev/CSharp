namespace SMS.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using SMS.Data;
    using SMS.Models;
    using SMS.ViewModels;

    public class ProductsController : Controller
    {
        private readonly SMSDbContext data;

        public ProductsController(SMSDbContext data)
        {
            this.data = data;
        }

        [Authorize]
        public HttpResponse Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Create(CreateProductFormModel model)
        {
            var product = new Product
            {
                Name = model.Name,
                Price = model.Price,
            };
            this.data.Products.Add(product);
            this.data.SaveChanges();

            return Redirect("/");
        }

        //TODO validations
    }
}
