using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Repositories;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private DecorationRepository decorations;
        private List<IAquarium> aquariums;

        public Controller()
        {
            this.decorations = new DecorationRepository();
            this.aquariums = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium = aquariumType switch
            {
                "FreshwaterAquarium" => new FreshwaterAquarium(aquariumName),
                "SaltwaterAquarium" =>  new SaltwaterAquarium(aquariumName),
                _ => throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType)
            };
            aquariums.Add(aquarium);
            return String.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            Decoration decoration = decorationType switch
            {
                "Ornament" =>   new Ornament(),
                "Plant" =>      new Plant(),
                _ => throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType)
            };
            decorations.Add(decoration);
            return String.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {          
            IAquarium targetAquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);
            
            //is this check needed?
            if (targetAquarium==null)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumName);
            }

            Fish fishItem = fishType switch
            {
                "FreshwaterFish" => new FreshwaterFish(fishName, fishSpecies, price),
                "SaltwaterFish" =>  new SaltwaterFish(fishName, fishSpecies, price),
                _ => throw new InvalidOperationException(ExceptionMessages.InvalidFishType)
            };

            //"Water not suitable." CHECK
            string returnMessage = string.Empty;
            if (targetAquarium.GetType().Name== "FreshwaterAquarium" && fishItem.GetType().Name== "FreshwaterFish")
            {
                targetAquarium.AddFish(fishItem);
                returnMessage = String.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
            }
            else if (targetAquarium.GetType().Name == "SaltwaterAquarium" && fishItem.GetType().Name == "SaltwaterFish")
            {
                targetAquarium.AddFish(fishItem);
                returnMessage = String.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
            }
            else
            {
                returnMessage = "Water not suitable.";
            }
            return returnMessage;
        }

        public string CalculateValue(string aquariumName)
        {
            decimal aquariumValue = 0;
            IAquarium targetAquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);

            //is this check needed?
            if (targetAquarium == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumName);
            }

            //Calculations for fish
            foreach (var fishItem in targetAquarium.Fish)
            {
                aquariumValue += fishItem.Price;
            }
            //Calculations for decorations
            foreach (var decorationItems in targetAquarium.Decorations)
            {
                aquariumValue += decorationItems.Price;
            }
            return $"The value of Aquarium {aquariumName} is {aquariumValue:F2}.";
        }

        public string FeedFish(string aquariumName)
        {           
            int fedCount = 0;

            IAquarium targetAquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);
            //is this check needed?
            if (targetAquarium == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumName);
            }

            foreach (var fishItem in targetAquarium.Fish)
            {
                fishItem.Eat();
                fedCount++;
            }
            //useless fedcount, it is equal to aquarium fish count :/
            return $"Fish fed: {fedCount}";
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {            
            IAquarium targetAquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);

            //is this check needed?
            if (targetAquarium == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumName);
            }
            
            Decoration targetDecoration = decorations.FindByType(decorationType);
            if (targetDecoration==null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }

            //aquarium is valid, decoration is valid, insert to aquarium and remove from repo
            targetAquarium.AddDecoration(targetDecoration);
            decorations.Remove(targetDecoration);

            return string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in aquariums)
            {
                sb.AppendLine(item.GetInfo());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
