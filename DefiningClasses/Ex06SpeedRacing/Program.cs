using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex06SpeedRacing
{
    class Program
    {
        static void Main()
        {            
            var listOfCars = ReadCars(int.Parse(Console.ReadLine()));
            var command = Console.ReadLine();

            while (command!="End")
            {
                var cmdArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                var carModel = cmdArgs[1];
                var distance = double.Parse(cmdArgs[2]);
                
                //find index of the car to be driven
                var index = listOfCars.FindIndex(x => x.Model == carModel);
                
                //drive the car
                listOfCars[index].Drive(distance);                

                command = Console.ReadLine();
            }

            PrintOutput(listOfCars);


        }

        private static void PrintOutput(List<Car> listOfCars)
        {
            foreach (Car item in listOfCars)
            {
                Console.WriteLine($"{item.Model} {item.FuelAmount:f2} {item.TravelledDistance}");
            }
        }

        private static List<Car> ReadCars(int numberOfCars)
        {
            var list = new List<Car>();
            for (int i = 0; i < numberOfCars; i++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                var model = input[0];
                var fuel = double.Parse(input[1]);
                var consumption = double.Parse(input[2]);
                Car car = new Car(model, fuel, consumption);
                list.Add(car);
            }
            return list;
        }
    }
}
