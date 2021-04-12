using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Repositories;
using AquaShop.Repositories.Contracts;
using AquaShop.Repositories.Models;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private IRepository<IDecoration> decorations;
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
                "SaltwaterAquarium" => new SaltwaterAquarium(aquariumName),
                _ => throw new InvalidOperationException("Invalid aquarium type.")
            };
            aquariums.Add(aquarium);
            return $"Successfully added { aquariumType}.";
        }

        public string AddDecoration(string decorationType)
        {
            Decoration decoration = decorationType switch
            {
                "Ornament" => new Ornament(),
                "Plant" => new Plant(),
                _ => throw new InvalidOperationException("Invalid decoration type.")
            };
            decorations.Add(decoration);
            return $"Successfully added {decorationType}.";
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            Fish fishItem = fishType switch
            {
                "FreshwaterFish" => new FreshwaterFish(fishName, fishSpecies, price),
                "SaltwaterFish" => new SaltwaterFish(fishName, fishSpecies, price),
                _ => throw new InvalidOperationException("Invalid fish type.")
            };

            IAquarium targetAquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);
           
            

            //"Water not suitable." CHECK
            string returnMessage = string.Empty;

            if (targetAquarium.GetType().Name == "FreshwaterAquarium" && fishItem.GetType().Name == "FreshwaterFish")
            {
                targetAquarium.AddFish(fishItem);
                returnMessage = $"Successfully added {fishItem.GetType().Name} to {aquariumName}.";
            }
            else if (targetAquarium.GetType().Name == "SaltwaterAquarium" && fishItem.GetType().Name == "SaltwaterFish")
            {
                targetAquarium.AddFish(fishItem);
                returnMessage = $"Successfully added {fishItem.GetType().Name} to {aquariumName}.";
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

            //TODO POSSIBLE ERRORS

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
            IDecoration targetDecoration = this.decorations.FindByType(decorationType);

            if (targetDecoration == null)
            {
                throw new InvalidOperationException($"There isn't a decoration of type {decorationType}.");
            }

            //aquarium is valid, decoration is valid, insert to aquarium and remove from repo
            targetAquarium.AddDecoration(targetDecoration);
            decorations.Remove(targetDecoration);

            return string.Format($"Successfully added {decorationType} to {aquariumName}.");
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