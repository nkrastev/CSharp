namespace BattleCards.Services
{
    using BattleCards.Data;
    using BattleCards.Data.Models;
    using BattleCards.Models;
    using BattleCards.ViewModels.Cards;
    using System.Collections.Generic;
    using System.Linq;

    public class CardService : ICardService
    {
        private readonly ApplicationDbContext data;

        public CardService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public bool AddCardToCollection(int cardId, string userId)
        {
            if (this.data.UserCards.Any(x=>x.CardId==cardId && x.UserId==userId))
            {
                //card is already added
                return false;
            }
            else
            {
                //add card to collection
                var userCard = new UserCard
                {
                    CardId = cardId,
                    UserId = userId
                };
                this.data.UserCards.Add(userCard);
                this.data.SaveChanges();

                return true;
            }            
        }

        public void AddNew(CardFormModel model)
        {
            var card = new Card
            {
                Name = model.Name,
                ImageUrl = model.ImageUrl,
                Keyword = model.Keyword,
                Description = model.Description,
                Attack = int.Parse(model.Attack),
                Health = int.Parse(model.Health),
            };            

            this.data.Cards.Add(card);            
            this.data.SaveChanges();

            var userCard = new UserCard
            {
                CardId = card.Id,
                UserId = model.UserId,
            };
            this.data.UserCards.Add(userCard);
            this.data.SaveChanges();
        }

        public List<AllCardViewModel> GetAll()
        {
            var all = this.data.Cards.Select(x => new AllCardViewModel
            {
                Id = x.Id,
                Name = x.Name,
                ImageUrl = x.ImageUrl,
                Keyword = x.Keyword,
                Attack = x.Attack,
                Health = x.Health,
                Description = x.Description,
            })
            .ToList();

            return all;            
        }

        public List<AllCardViewModel> GetByUser(string id)
        {
            var myCards = this.data.UserCards.Where(x => x.UserId == id).Select(x => new AllCardViewModel
            {
                Id = x.CardId,
                Name = x.Card.Name,
                ImageUrl = x.Card.ImageUrl,
                Keyword = x.Card.Keyword,
                Health = x.Card.Health,
                Attack = x.Card.Attack,
                Description = x.Card.Description,
            })
            .ToList();

            return myCards;
        }

        public void RemoveCardFromCollectionByCardId(int id)
        {
            var targetCard = this.data.UserCards.Where(x=>x.CardId==id).FirstOrDefault();

            if (targetCard != null)
            {
                this.data.UserCards.Remove(targetCard);
                this.data.SaveChanges();
            }            
        }
    }
}
