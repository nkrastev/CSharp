namespace QRComposer.Controllers
{
    using System;
    using System.Diagnostics;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using Microsoft.AspNetCore.Mvc;
    using QRCoder;
    using QRComposer.Models;   
    using static QRCoder.PayloadGenerator;

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            QrCodeModel model = new QrCodeModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(QrCodeModel model)
        {
            if (model.WebsiteUrl!=null)
            {
                Payload payload = new Url(model.WebsiteUrl);
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(payload);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap logoImage = new Bitmap(@"wwwroot/img/logo-penguin.jpg");
                var qrCodeAsBitmap = qrCode.GetGraphic(20, Color.Black, Color.White, logoImage);
                string base64String = Convert.ToBase64String(BitmapToByteArray(qrCodeAsBitmap));
                model.QrImageUrl = "data:image/png;base64," + base64String;
                return View("Index", model);
            }
            return RedirectToAction("Index");
        }

        private byte[] BitmapToByteArray(Bitmap bitmap)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}