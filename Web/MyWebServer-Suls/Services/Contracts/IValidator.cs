namespace Suls.Services
{
    using Suls.ViewModels.Problems;
    using Suls.ViewModels.Submissions;
    using Suls.ViewModels.Users;
    using System.Collections.Generic;
  

    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterUserFormModel model);                        
        ICollection<string> ValidateProblem(ProblemFormModel model);
        ICollection<string> ValidateSubmission(SubmissionFormModel model);

    }
}
