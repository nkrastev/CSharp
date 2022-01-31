namespace SMS.Services
{
    using SMS.ViewModels;
    using System.Collections.Generic;
    
    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterUserFormModel model);
        
    }
}
