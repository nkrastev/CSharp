namespace Panda.Services
{
    using Panda.ViewModels.Packages;
    using Panda.ViewModels.Users;
    using System.Collections.Generic;
  

    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterUserFormModel model);        
        ICollection<string> ValidateCreatePackage(CreatePackageFormModel model);

    }
}
