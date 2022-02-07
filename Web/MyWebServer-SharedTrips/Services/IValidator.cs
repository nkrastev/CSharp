namespace SharedTrip.Services
{
    using SharedTrip.ViewModels;
    using System.Collections.Generic;    

    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterUserFormModel model);
        ICollection<string> ValidateTrip(AddTripFormModel model);

    }
}
