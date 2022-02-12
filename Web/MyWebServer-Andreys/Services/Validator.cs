namespace Andreys.Services
{
    using Andreys.Data.Models;
    using Andreys.ViewModels.Products;
    using Andreys.ViewModels.Users;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;    

    public class Validator : IValidator
    {
        public ICollection<string> ValidateProduct(AddProductFormModel model)
        {
            var errors = new List<string>();

            if (model.Name=="" || model.Name.Length==0)
            {
                errors.Add("Name is required");
            }

            if (model.Price == "")
            {
                errors.Add("Price cannot be empty");
            }            

            Category category;
            if (!Enum.TryParse(model.Category, out category)){
                errors.Add("Category Enum is unknown");
            }

            Gender gender;
            if (!Enum.TryParse(model.Gender, out gender))
            {
                errors.Add("Gender Enum is unknown");
            }


            return errors;
        }

        public ICollection<string> ValidateUser(RegisterUserFormModel model)
        {
            var errors = new List<string>();

            if (model.Username.Length <= 4 || model.Username.Length >= 10)
            {
                errors.Add($"Username '{model.Username}' is not valid. It must be between 4 and 10 characters long.");
            }

            if (!Regex.IsMatch(model.Email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
            {
                errors.Add($"Email {model.Email} is not a valid e-mail address.");
            }

            if (model.Password.Length <= 6 || model.Password.Length >=20)
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
