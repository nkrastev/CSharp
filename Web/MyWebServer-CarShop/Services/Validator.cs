namespace CarShop.Services
{
    using CarShop.ViewModels.Cars;
    using CarShop.ViewModels.Users;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;    

    public class Validator : IValidator
    {       
        public ICollection<string> ValidateCar (CarFormModel model)
        {
            var errors = new List<string>();

            if (model.Model == null || model.Model.Length < 5 || model.Model.Length > 20)
            {
                errors.Add($"Model '{model.Model}' is not valid. It must be between 5 and 20 characters long.");
            }

            if (!Regex.IsMatch(model.PlateNumber, @"[A-Z]{2}[0-9]{4}[A-Z]{2}"))
            {
                errors.Add($"Plate Number {model.PlateNumber} is not a valid. It have to be in format AA3333АА");
            }

            if (model.Year<=1900 || model.Year> DateTime.Now.Year)
            {
                errors.Add($"Year is not valid. It must be between 1900 and current year.");
            }

            if (model.Image==null)
            {
                errors.Add($"Car image is required.");
            }

            return errors;
        }
        public ICollection<string> ValidateUser(RegisterUserFormModel model)
        {
            var errors = new List<string>();           

            if (model.Username == null || model.Username.Length < 4 || model.Username.Length > 20)
            {
                errors.Add($"Username '{model.Username}' is not valid. It must be between 4 and 20 characters long.");
            }

            if (!Regex.IsMatch(model.Email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
            {
                errors.Add($"Email {model.Email} is not a valid e-mail address.");
            }

            if (model.Password.Length < 5 || model.Password.Length >20)
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

            if (model.UserType != "Client" && model.UserType != "Mechanic")
            {
                errors.Add($"The user can be either a 'Client' or a 'Mechanic'.");
            }

            return errors;
        }

        
    }
}
