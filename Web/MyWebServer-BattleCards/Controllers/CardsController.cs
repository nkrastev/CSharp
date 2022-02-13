namespace BattleCards.Controllers
{
    using BattleCards.Services;
    using BattleCards.ViewModels.Cards;
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using System.Linq;

    public class CardsController : Controller
    {
        private readonly ICardService cardService;
        private readonly IValidator validator;

        public CardsController(ICardService cardService, IValidator validator)
        {
            this.cardService = cardService;
            this.validator = validator;
        }

        [Authorize]
        public HttpResponse All()
        {
            var all = this.cardService.GetAll();
            return View(all);
        }

        [Authorize]       
        public HttpResponse Add()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Add(CardFormModel model)
        {
            var modelErrors = this.validator.ValidateCard(model);

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            model.UserId = this.User.Id;

            this.cardService.AddNew(model);

            return Redirect("/Cards/All");
        }

        [Authorize]
        public HttpResponse Collection()
        {
            var myCards = this.cardService.GetByUser(User.Id);

            return View(myCards);
        }

        [Authorize]
        public HttpResponse RemoveFromCollection(int cardId)
        {
            this.cardService.RemoveCardFromCollectionByCardId(cardId);

            return Redirect("/Cards/Collection");
        }

        [Authorize]
        public HttpResponse AddToCollection(int cardId)
        {
            bool isAdded = this.cardService.AddCardToCollection(cardId, User.Id);

            if (isAdded)
            {
                return Redirect("/Cards/Collection");
            }
            else
            {
                return Redirect("/Cards/All");
            }
            
        }
    }
}
