using MXGP.Core.Contracts;
using MXGP.Models.Motorcycles;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Models.Races;
using MXGP.Models.Riders;
using MXGP.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Core
{
    public class ChampionshipController : IChampionshipController
    {
        private RaceRepository races;
        private RiderRepository riders;
        private MotorcycleRepository motorcycles;

        public ChampionshipController()
        {
            this.races = new RaceRepository();
            this.riders = new RiderRepository();
            this.motorcycles = new MotorcycleRepository();
        }

        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            if (this.riders.GetByName(riderName)==null)
            {
                throw new InvalidOperationException($"Rider {riderName} could not be found.");
            }
            var riderToAddMotorTo = this.riders.GetByName(riderName);
            if (this.motorcycles.GetByName(motorcycleModel)==null)
            {
                throw new InvalidOperationException($"Motorcycle {motorcycleModel} could not be found.");
            }
            var motorToBeAdded = this.motorcycles.GetByName(motorcycleModel);

            riderToAddMotorTo.AddMotorcycle(motorToBeAdded);
            return $"Rider {riderName} received motorcycle {motorcycleModel}.";
        }

        public string AddRiderToRace(string raceName, string riderName)
        {        
            if (this.races.GetByName(raceName) == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }
            var theCurrentRace = this.races.GetByName(raceName);
            if (this.riders.GetByName(riderName) == null)
            {
                throw new InvalidOperationException($"Rider {riderName} could not be found.");
            }
            var theCurrentRider = this.riders.GetByName(riderName);
            theCurrentRace.AddRider(theCurrentRider);
            return $"Rider {riderName} added in {raceName} race.";
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {           
            IMotorcycle motorcycle = type switch
            {
                "SpeedMotorcycle" => new SpeedMotorcycle(model, horsePower),
                "PowerMotorcycle" => new PowerMotorcycle(model, horsePower),
                _ => throw new ArgumentException("INVALID MC Type")
            };

            if (motorcycles.GetByName(model)!=null)
            {
                throw new ArgumentException($"Motorcycle {model} is already created.");
            }
            this.motorcycles.Add(motorcycle);
            return $"{motorcycle.GetType().Name} {model} is created.";
        }

        public string CreateRace(string name, int laps)
        {           
            if (this.races.GetByName(name) != null)
            {
                throw new InvalidOperationException($"Race {name} is already created.");
            }
            Race raceToBeAdded = new Race(name, laps);
            this.races.Add(raceToBeAdded);
            return $"Race {name} is created.";
        }

        public string CreateRider(string riderName)
        {
            Rider rider = new Rider(riderName);

            if (riders.GetByName(riderName)!=null)
            {
                throw new ArgumentException($"Rider {riderName} is already created.");
            }
            this.riders.Add(rider);
            return $"Rider {riderName} is created.";
        }

        public string StartRace(string raceName)
        {
          
            if (races.GetByName(raceName)==null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }
            var raceToStart = races.GetByName(raceName);
            var raceLaps = raceToStart.Laps;
            
            if (raceToStart.Riders.Count<3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than 3 participants.");
            }

            //reorder riders in current race
            var orderedResults = raceToStart.Riders.OrderByDescending(x => x.Motorcycle.CalculateRacePoints(raceLaps)).ToList();
            

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Rider {orderedResults[0].Name} wins {raceName} race.");
            sb.AppendLine($"Rider {orderedResults[1].Name} is second in {raceName} race.");
            sb.AppendLine($"Rider {orderedResults[2].Name} is third in {raceName} race.");

            this.races.Remove(raceToStart);

            return sb.ToString().TrimEnd();
        }
    }
}
