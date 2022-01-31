namespace SMS.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;        
    using SMS.ViewModels;

    using static Data.DataConstants;

    public class Validator : IValidator
    {
        public ICollection<string> ValidateUser(RegisterUserFormModel model)
        {
            var errors = new List<string>();

            if (model.Username.Length < UsernameMin || model.Username.Length > UsernameMax)
            {
                errors.Add($"Username '{model.Username}' is not valid. It must be between {UsernameMin} and {UsernameMax} characters long.");
            }

            if (!Regex.IsMatch(model.Email, UserEmailRegularExpression))
            {
                errors.Add($"Email {model.Email} is not a valid e-mail address.");
            }

            if (model.Password.Length < PasswordMin || model.Password.Length > PasswordMax)
            {
                errors.Add($"The provided password is not valid. It must be between {PasswordMin} and {PasswordMax} characters long.");
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
