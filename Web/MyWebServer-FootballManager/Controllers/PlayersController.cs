namespace FootballManager.Controllers
{
    using FootballManager.Data;
    using FootballManager.Data.Models;
    using FootballManager.Services;
    using FootballManager.ViewModels.Players;
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using System;
    using System.Linq;

    public class PlayersController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly IValidator validator;

        public PlayersController(ApplicationDbContext data, IValidator validator)
        {
            this.data = data;
            this.validator = validator;
        }

        [Authorize]
        public HttpResponse RemoveFromCollection(int playerId)
        {
            var player = this.data.Players.Where(x => x.Id == playerId).FirstOrDefault();

            if (player == null)
            {
                return Error("Player does not exists.");
            }

            if (!this.data.UserPlayers.Any(x => x.PlayerId == playerId && x.UserId == User.Id))
            {
                return Error("Player is NOT in collection.");
            }

            // player exists and it is in the collection
            var targetPlayer = this.data.UserPlayers.Where(x=>x.PlayerId==playerId).FirstOrDefault();

            this.data.UserPlayers.Remove(targetPlayer);
            this.data.SaveChanges();

            return Redirect("/Players/Collection");
        }

        [Authorize]
        public HttpResponse AddToCollection(int playerId)
        {
            var player = this.data.Players.Where(x=>x.Id == playerId).FirstOrDefault();
                        
            if (player ==null)
            {
                return Error("Player does not exists.");
            }

            if (this.data.UserPlayers.Any(x=>x.PlayerId==playerId && x.UserId==User.Id))
            {
                //return Error("Player is already in collection.");
                return Redirect("/Players/All");
            }

            // player exists and can be added to collection

            var userPlayer = new UserPlayer();
            userPlayer.UserId=User.Id;
            userPlayer.PlayerId=playerId;

            this.data.UserPlayers.Add(userPlayer);
            this.data.SaveChanges();

            return Redirect("/Players/All");
        }

        [Authorize]
        public HttpResponse Collection()
        {
            var collectionPlayers =
                this.data.UserPlayers.Where(x => x.UserId == User.Id).Select(x => new PlayerViewModel
                {
                    Id=x.Player.Id,
                    Image = x.Player.ImageUrl,
                    Description = x.Player.Description,
                    FullName = x.Player.FullName,
                    Position = x.Player.Position,
                    Speed = x.Player.Speed.ToString(),
                    Endurance = x.Player.Endurance.ToString(),
                })
                .ToList();

            return View(collectionPlayers);
        }

        [Authorize]
        public HttpResponse All()
        {
            var players = this.data.Players.Select(x=> new PlayerViewModel
            {
                Id = x.Id,
                Image = x.ImageUrl,
                Description = x.Description,
                FullName = x.FullName,
                Position=x.Position,
                Speed = x.Speed.ToString(),
                Endurance = x.Endurance.ToString(),
            })
                .ToList();
            return View(players);
        }

        [Authorize]
        public HttpResponse Add()
        {
            return View();
        }

       
        [Authorize]
        [HttpPost]
        public HttpResponse Add(AddPlayerFormModel model)
        {
            if (model == null)
            {
                return Redirect("/Players/Add");
            }
            
            var modelErrors = this.validator.ValidatePlayer(model);

            if (modelErrors.Any())
            {
                //return Error(modelErrors);
                return Redirect("/Players/Add");
            }

            var player = new Player
            {
                FullName = model.FullName,
                ImageUrl = model.ImageUrl,
                Position = model.Position,
                Speed = (byte)model.Speed,
                Endurance = (byte)model.Endurance,
                Description = model.Description,
            };
            this.data.Players.Add(player);
            this.data.SaveChanges();

            var userPlayer = new UserPlayer
            {
                UserId = this.User.Id,
                PlayerId = player.Id,
            };

            this.data.UserPlayers.Add(userPlayer);

            this.data.SaveChanges();
            
            return Redirect("/Players/All");
        }
    }
}
