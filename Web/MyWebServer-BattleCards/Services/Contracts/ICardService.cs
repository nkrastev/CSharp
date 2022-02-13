namespace BattleCards.Services
{
    using BattleCards.Data.Models;
    using BattleCards.ViewModels.Cards;
    using System.Collections.Generic;

    public interface ICardService
    {
        List<AllCardViewModel> GetAll();

        List<AllCardViewModel> GetByUser(string id);

        void AddNew(CardFormModel model);

        void RemoveCardFromCollectionByCardId(int id);

        bool AddCardToCollection(int cardId, string userId);
    }
}
