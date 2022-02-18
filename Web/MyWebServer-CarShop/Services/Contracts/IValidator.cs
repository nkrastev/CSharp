namespace CarShop.Services
{
    using CarShop.ViewModels.Cars;
    using CarShop.ViewModels.Users;
    using System.Collections.Generic;
  

    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterUserFormModel model);                        
        ICollection<string> ValidateCar(CarFormModel model);

    }
}
