namespace SMS.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using SMS.Data;
    using SMS.Models;
    using SMS.ViewModels;
    using System.Diagnostics;
    using System.Linq;

    public class CartsController : Controller
    {
        private readonly SMSDbContext data;

        public CartsController(SMSDbContext data)
        {
            this.data = data;
        }

        [Authorize]
        public HttpResponse Details()
        {
            var user = data.Users.Where(x => x.Id == User.Id).FirstOrDefault();
            var userProducts = data.Products.Where(x => x.CartId == user.CartId)
                .Select(x => new CartDetailsViewModel
                {
                    Name = x.Name,
                    Price = x.Price,
                })
                .ToList();

            return View(userProducts);
        }

        [Authorize]
        public HttpResponse AddProduct(string productId)
        {
            var product = data.Products.Where(x=>x.Id== productId).FirstOrDefault();
            var cart = data.Carts.Where(x => x.UserId == User.Id).FirstOrDefault();

            if (product == null || cart == null)
            {
                return BadRequest();
            }        
            
            product.CartId = cart.Id;

            this.data.SaveChanges();

            return Redirect("/Carts/Details");
        }

        [Authorize]
        public HttpResponse Buy()
        {
            Trace.WriteLine("Entering Buy");

            var cart = data.Carts.Where(x => x.UserId == User.Id).FirstOrDefault();
            var userProducts = data.Products.Where(x=>x.CartId == cart.Id).ToList();

            foreach (var item in userProducts)
            {
                item.CartId = null;
            }
           

            this.data.SaveChanges();

            return Redirect("/");
        }
    }
}
