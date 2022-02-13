namespace BattleCards.Services
{
    using BattleCards.ViewModels.Cards;
    using BattleCards.ViewModels.Users; 
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;    

    public class Validator : IValidator
    {
        public ICollection<string> ValidateCard(CardFormModel model)
        {
            var errors = new List<string>();            

            if (model.ImageUrl == "" || model.Keyword == "" || model.Description == "" || model.Name=="" || model.Attack=="" || model.Health=="")
            {
                errors.Add("Some of the fields is empty :) check them all :) ");
            }

            if (model.Health!="")
            {
                if (int.Parse(model.Health) < 0)
                {
                    errors.Add("Health cannot be negative");
                }
            }

            if (model.Attack != "")
            {
                if (int.Parse(model.Attack) < 0)
                {
                    errors.Add("Attack cannot be negative");
                }
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
