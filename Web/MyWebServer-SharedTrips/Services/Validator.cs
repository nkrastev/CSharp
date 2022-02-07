namespace SharedTrip.Services
{
    using SharedTrip.ViewModels;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;        

    public class Validator : IValidator
    {
        private readonly List<string> errors;
        public const string RequiredField = "The field {0} is required";

        public Validator()
        {
            this.errors = new List<string>();
        }

        public const string UserEmailRegularExpression = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

        public ICollection<string> ValidateUser(RegisterUserFormModel model)
        {
            var errors = new List<string>();

            if (model.Username.Length < 5 || model.Username.Length > 20)
            {
                errors.Add($"Username '{model.Username}' is not valid. It must be between 5 and 20 characters long.");
            }

            if (!Regex.IsMatch(model.Email, UserEmailRegularExpression))
            {
                errors.Add($"Email {model.Email} is not a valid e-mail address.");
            }

            if (model.Password.Length < 6 || model.Password.Length > 20)
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


        public ICollection<string> ValidateTrip(AddTripFormModel model)
        {
            
            this.Required(model.StartPoint, "StartPoint");
            this.Required(model.EndPoint, "EndPoint");
            this.Required(model.Description, "Description");
            this.Required(model.DepartureTime.ToString(), "DepartureTime");

            if (model.Seats<2 || model.Seats>6)
            {
                errors.Add("Has a Seats – an integer with min value 2 and max value 6");
            }

            if (model.Description.Length>80)
            {
                errors.Add("Description – a string with max length 80");
            }

            return errors;
        }

        private void Required(string text, string field)
        {
            if (text == null)
            {
                this.errors.Add(string.Format(RequiredField, field));
            }
        }
    }
}
