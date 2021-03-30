using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Core
{
    public class ChampionshipController : IChampionshipController
    {
        private DriverRepository driversRepository;
        private CarRepository carsRepository;
        private RaceRepository raceRepository;

        public ChampionshipController()
        {
            driversRepository = new DriverRepository();
            carsRepository = new CarRepository();
            raceRepository = new RaceRepository();
        }
        public string AddCarToDriver(string driverName, string carModel)
        {
            //TODO check if valid exeptions
            if (driversRepository.GetByName(driverName)==null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }
            if (carsRepository.GetByName(carModel)==null)
            {
                throw new InvalidOperationException($"Car {carModel} could not be found.");
            }
            IDriver driver = driversRepository.GetByName(driverName);
            ICar car = carsRepository.GetByName(carModel);
            driver.AddCar(car);
            
            return $"Driver {driverName} received car {carModel}.";
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            if (raceRepository.GetByName(raceName)==null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }
            if (driversRepository.GetByName(driverName)== null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }
            IDriver driver = driversRepository.GetByName(driverName);
            IRace race = raceRepository.GetByName(raceName);
            race.AddDriver(driver);
            return $"Driver {driverName} added in {raceName} race.";
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            if (carsRepository.GetByName(model)!=null)
            {
                throw new ArgumentException($"Car {model} is already created.");
            }
            ICar car = null;
            if (type== "Muscle")
            {
                car = new MuscleCar(model, horsePower);                
            }
            if (type== "Sports")
            {
                car = new SportsCar(model, horsePower);
            }
            carsRepository.Add(car);
            return $"{car.GetType().Name} {model} is created.";
        }

        public string CreateDriver(string driverName)
        {
            IDriver driver = new Driver(driverName);
            if (driversRepository.GetByName(driverName)!=null)
            {
                throw new ArgumentException($"Driver {driverName} is already created.");
            }
            driversRepository.Add(driver);
            return $"Driver {driverName} is created.";
        }

        public string CreateRace(string name, int laps)
        {
            IRace race = new Race(name, laps);
            if (raceRepository.GetByName(name)!=null)
            {
                throw new InvalidOperationException($"Race {name} is already create.");
            }            
            raceRepository.Add(race);
            return $"Race {name} is created.";
        }

        public string StartRace(string raceName)
        {
            if (raceRepository.GetByName(raceName)==null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }
            IRace currentRace = raceRepository.GetByName(raceName);
            if (currentRace.Drivers.Count<3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than 3 participants.");
            }
            var allDrivers = driversRepository.GetAll().OrderByDescending(x => x.Car.CalculateRacePoints(currentRace.Laps)).Take(3).ToList();
            
            //IDriver first = allDrivers.Take(1).ToList();
            //var second = allDrivers.Take(2);
            //var third = allDrivers.Take(3);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Driver {allDrivers[0].Name} wins {raceName} race.");
            sb.AppendLine($"Driver {allDrivers[1].Name} is second in {raceName} race.");
            sb.AppendLine($"Driver {allDrivers[2].Name} is third in {raceName} race.");

            return sb.ToString().TrimEnd();
            
        }
    }
}
