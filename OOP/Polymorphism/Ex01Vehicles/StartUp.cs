using System;
using System.Linq;

namespace Ex01Vehicles
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var carInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            var truckInput= Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            
            Vehicle car = new Car(double.Parse(carInput[1]), double.Parse(carInput[2]));
            Vehicle truck = new Truck(double.Parse(truckInput[1]), double.Parse(truckInput[2]));

            var commands = int.Parse(Console.ReadLine());

            for (int i = 0; i < commands; i++)
            {
                var cmdArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (cmdArgs[0]=="Drive")
                {
                    if (cmdArgs[1]=="Car")
                    {
                        car.Drive(double.Parse(cmdArgs[2]));
                    }
                    else
                    {
                        truck.Drive(double.Parse(cmdArgs[2]));
                    }
                }

                if (cmdArgs[0]=="Refuel")
                {
                    if (cmdArgs[1]=="Car")
                    {
                        car.Refuel(double.Parse(cmdArgs[2]));
                    }
                    else
                    {
                        truck.Refuel(double.Parse(cmdArgs[2]));
                    }
                }

            }

            //output - remaining fuel for both the car and the truck
            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
        }
    }
}
