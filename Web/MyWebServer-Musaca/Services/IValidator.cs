namespace MUSACA.Services
{
    using MUSACA.ViewModels;
    using System.Collections.Generic;    

    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterUserFormModel model);

        //ICollection<string> ValidateRepository(CreateRepositoryFormModel model);
    }
}
