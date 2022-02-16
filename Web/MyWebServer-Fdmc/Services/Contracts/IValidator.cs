namespace Fdmc.Services
{
   
    using Fdmc.ViewModels.Users;
    using System.Collections.Generic;
  

    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterUserFormModel model);                              

    }
}
