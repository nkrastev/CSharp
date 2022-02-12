namespace Andreys.Controllers
{
    using Andreys.Data;
    using Andreys.Data.Models;
    using Andreys.Services;
    using Andreys.ViewModels.Products;
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using System;
    using System.Linq;

    public class ProductsController : Controller
    {
        private readonly AndreysDbContext data;
        private readonly IValidator validator;

        public ProductsController(AndreysDbContext data, IValidator validator)
        {
            this.data = data;
            this.validator = validator;
        }

        [Authorize]
        public HttpResponse Add() => View();

        
        [Authorize]
        [HttpPost]
        public HttpResponse Add(AddProductFormModel model)
        {
            var modelErrors = this.validator.ValidateProduct(model);

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }
            
            var product = new Product
            {
                Name = model.Name,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                Category = Enum.Parse<Category>(model.Category),
                Gender = Enum.Parse<Gender>(model.Gender),                
                Price = decimal.Parse(model.Price),
            };

            this.data.Products.Add(product);
            this.data.SaveChanges();

            return Redirect("/");
        }

        [Authorize]
        public HttpResponse Details(string id)
        {
            var product = this.data.Products.Where(x => x.Id == id).Select(x => new ProductViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                ImageUrl = x.ImageUrl,
                Category = x.Category.ToString(),
                Gender = x.Gender.ToString(),
                Price = x.Price.ToString("f2"),
            }).FirstOrDefault();

            if (product != null)
            {
                return View(product);
            }

            return Redirect("/");
        }

        [Authorize]
        public HttpResponse Delete(string id)
        {
            var productForDelete = this.data.Products.Where(x => x.Id == id).FirstOrDefault();

            if (productForDelete != null)
            {
                this.data.Products.Remove(productForDelete);
                this.data.SaveChanges();
            }

            return Redirect("/Home/Home");
        }
    }
}
