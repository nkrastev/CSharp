using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace WebCats.Controllers
{
    public class CatsController : Controller
    {
        // Cats/method name the URL
        // return view returns html
        public IActionResult SendCatData()
        {
            return View();
        }

        public IActionResult ViewSubmittedData()
        {
            //TODO read the submitted data

            return View();
        }
    }
}
