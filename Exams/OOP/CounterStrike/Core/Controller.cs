using CounterStrike.Core.Contracts;
using CounterStrike.Models.Guns;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Maps;
using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Core
{
    public class Controller : IController
    {
        private GunRepository guns;
        private PlayerRepository players;
        private IMap map;

        public Controller()
        {
            this.guns = new GunRepository();
            this.players = new PlayerRepository();
            this.map = new Map();
        }
        public string AddGun(string type, string name, int bulletsCount)
        {
            IGun gun = type switch
            {
                "Pistol" =>     new Pistol(name, bulletsCount),
                "Rifle" =>      new Rifle(name, bulletsCount),
                _ => throw new ArgumentException(ExceptionMessages.InvalidGunType)
            };
            guns.Add(gun);
            return String.Format(OutputMessages.SuccessfullyAddedGun, name);
        }

        public string AddPlayer(string type, string username, int health, int armor, string gunName)
        {          
            IGun gunForPlayer = guns.FindByName(gunName);
            if (gunForPlayer==null)
            {
                throw new ArgumentException(ExceptionMessages.GunCannotBeFound);
            }
            IPlayer player = type switch
            {
                "Terrorist" => new Terrorist(username, health, armor, gunForPlayer),
                "CounterTerrorist" => new CounterTerrorist(username, health, armor, gunForPlayer),
                _ => throw new ArgumentException(ExceptionMessages.InvalidPlayerType)
            };
            players.Add(player);
            return String.Format(OutputMessages.SuccessfullyAddedPlayer, username);
        }

        public string Report()
        {            
            var orderedPlayers = players
                .Models
                .OrderBy(x => x.GetType().Name)
                .ThenByDescending(x => x.Health)
                .ThenBy(x => x.Username)
                .ToList();
            StringBuilder sb = new StringBuilder();
            foreach (var player in orderedPlayers)
            {
                sb.AppendLine($"{player.GetType().Name}: {player.Username}");
                sb.AppendLine($"--Health: {player.Health}");
                sb.AppendLine($"--Armor: {player.Armor}");
                sb.AppendLine($"--Gun: {player.Gun.Name}");
            }
            return sb.ToString().TrimEnd();
        }

        public string StartGame() => map.Start(players.Models.ToList());        
    }
}
