namespace Andreys.Services
{
    using Andreys.ViewModels.Products;
    using Andreys.ViewModels.Users;
    using System.Collections.Generic;
  

    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterUserFormModel model);
        ICollection<string> ValidateProduct(AddProductFormModel model);
        
    }
}
