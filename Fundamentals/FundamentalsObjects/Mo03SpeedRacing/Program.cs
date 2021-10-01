using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    class Program
    {
        static void Main()
        {

            List<Car> carsList = new List<Car>();

            AddCarsToList(carsList);
            
            DriveCommands(carsList);            
            
            PrintCarsList(carsList);

        }

        static void PrintCarsList(List<Car> carsList)
        {
            foreach (Car item in carsList)
            {
                Console.WriteLine($"{item.Model} {item.FuelAmount:f2} {item.TraveledDistance}");
            }
        }

        static List<Car> DriveCommands(List<Car> carsList)
        {
            string[] drive = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            while (drive[0] != "End")
            {
                string carModel = drive[1];
                double distanceToTravel = double.Parse(drive[2]);

                foreach (Car item in carsList)
                {
                    if (item.Model == carModel)
                    {
                        // entered car found
                        if (item.CheckIfEnoughtFuel(distanceToTravel))
                        {                            
                            double fuelLevel = item.FuelAmount;
                            double fuelPerKm = item.FuelConsumption;

                            //add new travel distance
                            item.TraveledDistance += distanceToTravel;

                            //reduce fuel
                            item.FuelAmount -= distanceToTravel * item.FuelConsumption;

                        }
                        else
                        {
                            Console.WriteLine("Insufficient fuel for the drive");
                        }

                    }
                }
                drive = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            }
            return carsList;
        }

        static List<Car> AddCarsToList(List<Car> carsList)
        {
            int numberCars = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberCars; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                Car newItem = new Car(input[0], double.Parse(input[1]), double.Parse(input[2]), 0);
                carsList.Add(newItem);
            }
            return carsList;
        }
    }

    class Car
    {
        //constructor
        public Car(string model, double fuelAmount, double fuelConsumption, double traveledDistance)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumption = fuelConsumption;
            TraveledDistance = traveledDistance;
        }

        //properties
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumption { get; set; }
        public double TraveledDistance { get; set; }

        //methods
        public bool CheckIfEnoughtFuel(double distance)
        {
            bool isFuelEnought = false;
            if (distance * FuelConsumption>FuelAmount)
            {
                isFuelEnought = false;
            }
            else
            {
                isFuelEnought = true;
            }

            return isFuelEnought;
        }
    }
}
