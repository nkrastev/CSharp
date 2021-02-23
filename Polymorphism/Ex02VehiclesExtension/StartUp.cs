using Ex02VehiclesExtension.Models;
using System;
using System.Linq;

namespace Ex02VehiclesExtension
{
    class StartUp
    {
        static void Main()
        {
            var carInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            Vehicle car = new Car(double.Parse(carInput[1]), double.Parse(carInput[2]), double.Parse(carInput[3]));

            var truckInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            Vehicle truck = new Truck(double.Parse(truckInput[1]), double.Parse(truckInput[2]), double.Parse(truckInput[3]));

            var busInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();                       
            Vehicle bus = new Bus(double.Parse(busInput[1]), double.Parse(busInput[2]), double.Parse(busInput[3]));

            var numberCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberCommands; i++)
            {
                var cmdAgrs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                
                if (cmdAgrs[0]== "Refuel")
                {
                    if (cmdAgrs[1]== "Car")   { car.Refuel(double.Parse(cmdAgrs[2])); }
                    if (cmdAgrs[1]== "Truck") { truck.Refuel(double.Parse(cmdAgrs[2])); }
                    if (cmdAgrs[1]== "Bus")   { bus.Refuel(double.Parse(cmdAgrs[2])); }
                }

                if (cmdAgrs[0]=="Drive")
                {
                    if (cmdAgrs[1] == "Car") { car.Drive(double.Parse(cmdAgrs[2])); }
                    if (cmdAgrs[1] == "Truck") { truck.Drive(double.Parse(cmdAgrs[2])); }
                    if (cmdAgrs[1] == "Bus") { bus.Drive(double.Parse(cmdAgrs[2])); }
                }

                if (cmdAgrs[0]=="DriveEmpty")
                {
                    bus.DriveEmpty(double.Parse(cmdAgrs[2]));                    
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:F2}");

        }
    }
}
