namespace FootballManager.Services
{
    using FootballManager.ViewModels.Players;
    using FootballManager.ViewModels.Users;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;    

    public class Validator : IValidator
    {
        public ICollection<string> ValidatePlayer(AddPlayerFormModel model)
        {
            var errors = new List<string>();

            if (model.FullName == null || model.FullName.Length < 5 || model.FullName.Length > 80)
            {
                errors.Add($"Fullname '{model.FullName}' is not valid. It must be between 5 and 80 characters long.");
            }

            if (model.ImageUrl == null)
            {
                errors.Add($"Image Url is required");
            }

            if (model.Position == null || model.Position.Length < 5 || model.Position.Length>20)
            {
                errors.Add($"Position is required and have to be in range [5,20]");
            }

            if (model.Speed < 0 || model.Speed > 10)
            {
                errors.Add($"Speed is required and have to be in range [0,10]");
            }

            if (model.Endurance < 0 || model.Endurance > 10)
            {
                errors.Add($"Endurance  is required and have to be in range [0,10]");
            }

            if (model.Description.Length == 0 || model.Description.Length > 200)
            {
                errors.Add($"Description  is required and have to be in range [0,200]");
            }



            return errors;
        }

       

        public ICollection<string> ValidateUser(RegisterUserFormModel model)
        {
            var errors = new List<string>();           

            if (model.Username == null || model.Username.Length < 5 || model.Username.Length > 20)
            {
                errors.Add($"Username '{model.Username}' is not valid. It must be between 5 and 20 characters long.");
            }

            if (!Regex.IsMatch(model.Email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
            {
                errors.Add($"Email {model.Email} is not a valid e-mail address.");
            }

            if (model.Email == null || model.Email.Length < 10 || model.Email.Length > 60)
            {
                errors.Add($"Email is not valid. It must be between 10 and 60 characters long.");
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


            return errors;
        }

        
    }
}
