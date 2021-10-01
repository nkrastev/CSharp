using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Ex06VehicleCatalogue
{
    class Program
    {
        static void Main()
        {            
            List<Vehicle> vehiclesList = new List<Vehicle>();

            //fill in catalogue
            GetVehicles(vehiclesList);

            //get info for specific vehicle
            ModelsPrint(vehiclesList);

            //output average horsepower
            AverageHorsepower(vehiclesList);
            
        }

        static void AverageHorsepower(List<Vehicle> vehicles)
        {
            int countCars = 0;
            int countTrucks = 0;
            int totalHPcars = 0;
            int totalHPtrucks = 0;

            foreach (Vehicle item in vehicles)
            {
                if (item.Type=="Car")
                {
                    countCars++;
                    totalHPcars += item.HorsePower;
                }
                else
                {
                    countTrucks++;
                    totalHPtrucks += item.HorsePower;
                }
            }
            double avgCars = 0;
            double avgTrucks = 0;
            if (countCars>0)
            {
                avgCars = totalHPcars * 1.0 / countCars;
            }
            if (countTrucks > 0)
            {
                avgTrucks = totalHPtrucks * 1.0 / countTrucks;
            }
            Console.WriteLine($"Cars have average horsepower of: {avgCars:f2}.");
            Console.WriteLine($"Trucks have average horsepower of: {avgTrucks:f2}.");

        }

        static void ModelsPrint(List<Vehicle> vehiclesList)
        {
            string inputModel = Console.ReadLine();
            while (inputModel!= "Close the Catalogue")
            {
                foreach (Vehicle item in vehiclesList)
                {
                    if (item.Model==inputModel)
                    {
                        Console.WriteLine($"Type: {item.Type}");
                        Console.WriteLine($"Model: {item.Model}");
                        Console.WriteLine($"Color: {item.Color}");
                        Console.WriteLine($"Horsepower: {item.HorsePower}");
                    }
                }

                inputModel = Console.ReadLine();
            }
        }

        static List<Vehicle> GetVehicles(List<Vehicle> vehiclesList)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            while (input[0] != "End")
            {
                string type = input[0];
                //useless check but Judje want it
                if (input[0] == "Car" || input[0] == "car") { type = "Car"; }
                if (input[0] == "Truck" || input[0] == "truck") { type = "Truck"; }
                string model = input[1];                               
                string color = input[2];
                int horsePower = int.Parse(input[3]);
                // new instance of vehicle to add in list
                Vehicle itemVehicle = new Vehicle(type, model, color, horsePower);
                // add vehicle to the catalog
                vehiclesList.Add(itemVehicle);
                //read next
                input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            return vehiclesList;
        }
    }

    class Vehicle
    {
        //constructor
        public Vehicle(string typeOfVehicle, string modelOfVehicle, string colorOfVehicle, int horsePower)
        {
            Type = typeOfVehicle;
            Model = modelOfVehicle;
            Color = colorOfVehicle;
            HorsePower = horsePower;
        }
        //properties
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int HorsePower { get; set; }
    }
}
