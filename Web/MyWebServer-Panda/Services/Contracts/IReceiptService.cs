namespace Panda.Services.Contracts
{
    using Panda.ViewModels.Packages;
    using Panda.ViewModels.Receipt;
    using System.Collections.Generic;

    public interface IReceiptService
    {               
        List<ReceiptViewModel> GetForUser(string id);
      
    }
}
