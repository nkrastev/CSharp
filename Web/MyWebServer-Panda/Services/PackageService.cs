namespace Panda.Services
{
    using Panda.Data;
    using Panda.Data.Models;
    using Panda.Services.Contracts;
    using Panda.ViewModels.Packages;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PackageService : IPackageService
    {
        private readonly ApplicationDbContext data;

        public PackageService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public void Create(CreatePackageFormModel model)
        {
            var package = new Package
            {
                Description = model.Description,
                Weight = double.Parse(model.Weight),
                ShippingAddress = model.ShippingAddress,
                Status = Data.Models.Enums.Status.Pending,
                RecipientId = model.RecipientId,
            };

            this.data.Packages.Add(package);
            this.data.SaveChanges();
        }

        public void Deliver(string packageId)
        {
            var package = this.data.Packages.Where(x=>x.Id == packageId).FirstOrDefault();

            if (package != null)
            {
                package.Status=Data.Models.Enums.Status.Delivered;

                //receipt is generated to the User for that Package
                var receipt = new Receipt
                {
                    Fee = (decimal)(package.Weight * 2.67),
                    IssuedOn = DateTime.Now,
                    PackageId = package.Id,
                    RecipientId = package.RecipientId,
                };

                this.data.Receipts.Add(receipt);
                this.data.SaveChanges();
            }
        }

        public List<PendingPackageViewModel> GetPending()
        {            
            var pending = this
                .data
                .Packages
                .Where(x => (int)x.Status==1)
                .Select(x => new PendingPackageViewModel
                {
                    Description = x.Description,
                    Weight = x.Weight.ToString(),
                    ShippingAddress = x.ShippingAddress,
                    Recipient = x.Recipient.Username,
                    Id = x.Id,
                })
                .ToList();

            return pending;
        }

        public List<DeliveredPackageViewModel> GetDelivered()
        {
            var pending = this
                .data
                .Packages
                .Where(x => (int)x.Status == 2)
                .Select(x => new DeliveredPackageViewModel
                {
                    Description = x.Description,
                    Weight = x.Weight.ToString(),
                    ShippingAddress = x.ShippingAddress,
                    Recipient = x.Recipient.Username,
                    Id = x.Id,
                })
                .ToList();

            return pending;
        }


    }
}
