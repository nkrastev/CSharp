using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViceCity.Core.Contracts;
using ViceCity.Models.Guns;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Neghbourhoods;
using ViceCity.Models.Players;
using ViceCity.Models.Players.Contracts;
using ViceCity.Repositories;

namespace ViceCity.Core
{
    public class Controller : IController
    {
        private ICollection<IPlayer> civilPlayers;
        private GunRepository gunRepository;
        private MainPlayer tommy;
        private GangNeighbourhood gangNeighbourhood;

        public Controller()
        {
            this.civilPlayers = new List<IPlayer>();
            this.tommy = new MainPlayer();
            this.gunRepository = new GunRepository();
            this.gangNeighbourhood = new GangNeighbourhood();
        }

        public string AddGun(string type, string name)
        {
            IGun gun = null;
            if (type=="Pistol")
            {
                gun = new Pistol(name);
            }
            else if (type=="Rifle")
            {
                gun = new Rifle(name);
            }
            else
            {
                throw new ArgumentException("Invalid gun type!");
            }
            gunRepository.Add(gun);
            return $"Successfully added {name} of type: {type}";
        }

        public string AddGunToPlayer(string name)
        {
         
            var message = String.Empty;
            var gunToBeAdded = gunRepository.Models.FirstOrDefault();

            if (gunRepository.Models.Count==0)
            {
                message = "There are no guns in the queue!";
            }
            else if (name== "Vercetti")
            {
                tommy.GunRepository.Add(gunToBeAdded);
                gunRepository.Remove(gunToBeAdded);
                message = $"Successfully added {gunToBeAdded.Name} to the Main Player: Tommy Vercetti";
            }
            else if (!civilPlayers.Any(x=>x.Name==name))
            {
                message = "Civil player with that name doesn't exists!";
            }
            else
            {
                CivilPlayer targetCivilPlayer = (CivilPlayer)civilPlayers.FirstOrDefault(x => x.Name == name);
                targetCivilPlayer.GunRepository.Add(gunToBeAdded);
                gunRepository.Remove(gunToBeAdded);
                message = $"Successfully added {gunToBeAdded.Name} to the Civil Player: {name}";
            }

            return message;
        }

        public string AddPlayer(string name)
        {
            CivilPlayer player = new CivilPlayer(name);
            civilPlayers.Add(player);
            return $"Successfully added civil player: {name}!";
        }

        public string Fight()
        {
            int totalCivilians = civilPlayers.Count;
            bool noFight = true;
            
            this.gangNeighbourhood.Action(tommy, civilPlayers);

            //Fight Happened, Tommy is injured or number of civilians is different or there is injured one
            if (tommy.LifePoints!=100 || totalCivilians!=civilPlayers.Count || civilPlayers.Any(x=>x.LifePoints!=50))
            {
                noFight = false;
            }
            

            if (noFight)
            {
                return "Everything is okay!";
            }
            else
            {
                return "A fight happened:"+Environment.NewLine
                    + $"Tommy live points: {tommy.LifePoints}!"+Environment.NewLine
                    +$"Tommy has killed: {totalCivilians-civilPlayers.Count} players!"+Environment.NewLine
                    +$"Left Civil Players: {civilPlayers.Count}!";
            }
        }
    }
}
