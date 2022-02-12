namespace Panda.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using Panda.Services.Contracts;

    public class ReceiptsController : Controller
    {
        private readonly IReceiptService receiptService;

        public ReceiptsController(IReceiptService receiptService)
        {
            this.receiptService = receiptService;
        }

        public HttpResponse Index()
        {
            var receipts = this.receiptService.GetForUser(User.Id);

            return View(receipts);
        }
    }
}
