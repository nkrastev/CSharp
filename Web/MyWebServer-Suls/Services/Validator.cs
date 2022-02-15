namespace Suls.Services
{
    using Suls.ViewModels.Problems;
    using Suls.ViewModels.Submissions;
    using Suls.ViewModels.Users;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;    

    public class Validator : IValidator
    {
        public ICollection<string> ValidateProblem(ProblemFormModel model)
        {
            var errors = new List<string>();
            
            if (model.Name.Length < 5 || model.Name.Length > 20)
            {
                errors.Add($"Problem Name is invalid. [5,20]");
            }

            if (model.Points<50 || model.Points > 300)
            {
                errors.Add($"Problem Points is invalid. [50,300]");
            }

            return errors;
        }

        public ICollection<string> ValidateSubmission(SubmissionFormModel model)
        {
            var errors = new List<string>();

            if (model.Code.Length<30 || model.Code.Length>800)
            {
                errors.Add($"Submission Code is invalid. [30,800]");
            }
            

            return errors;
        }

        public ICollection<string> ValidateUser(RegisterUserFormModel model)
        {
            var errors = new List<string>();

            if (model.Username.Length < 4 || model.Username.Length > 10)
            {
                errors.Add($"Username '{model.Username}' is not valid. It must be between 4 and 10 characters long.");
            }

            if (!Regex.IsMatch(model.Email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
            {
                errors.Add($"Email {model.Email} is not a valid e-mail address.");
            }

            if (model.Password.Length < 6 || model.Password.Length >20)
            {
                errors.Add($"The provided password is not valid. It must be between 6 and 20 characters long.");
            }
            
            if (model.Password.Any(x => x == ' '))
            {
                errors.Add($"The provided password cannot contain whitespaces.");
            }

            if (model.Password != model.ConfirmPassword)
            {
                errors.Add($"Password and its confirmation are different.");
            }

            return errors;
        }

        
    }
}
