namespace Panda.Services
{
    using Panda.Data;
    using Panda.Services.Contracts;
    using Panda.ViewModels.Packages;
    using Panda.ViewModels.Receipt;
    using System.Collections.Generic;
    using System.Linq;

    public class ReceiptService : IReceiptService
    {
        private readonly ApplicationDbContext data;

        public ReceiptService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public List<ReceiptViewModel> GetForUser(string userId)
        {
            var receipts = this.data.Receipts.Where(x => x.RecipientId == userId)
                .Select(x => new ReceiptViewModel
                {
                    Id = x.Id,
                    Fee = x.Fee.ToString("F2"),
                    IssuedOn = x.IssuedOn.ToString(),
                    RecipientUsername = x.Recipient.Username,
                }).ToList();

            return receipts;
        }
    }
}
