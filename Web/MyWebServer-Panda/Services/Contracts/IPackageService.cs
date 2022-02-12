namespace Panda.Services.Contracts
{
    using Panda.ViewModels.Packages;
    using System.Collections.Generic;

    public interface IPackageService
    {
        void Create(CreatePackageFormModel model);
       
        List<PendingPackageViewModel> GetPending();
        
        List<DeliveredPackageViewModel> GetDelivered();

        void Deliver(string packageId);
    }
}
