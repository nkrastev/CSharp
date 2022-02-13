namespace BattleCards.Services
{
    using BattleCards.ViewModels.Cards;
    using BattleCards.ViewModels.Users;
    using System.Collections.Generic;
  

    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterUserFormModel model);                
        ICollection<string> ValidateCard(CardFormModel model);

    }
}
