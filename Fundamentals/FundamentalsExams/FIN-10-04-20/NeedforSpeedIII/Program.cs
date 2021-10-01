using System;
using System.Collections.Generic;
using System.Linq;

namespace NeedforSpeedIII
{
    class Program
    {
        static void Main()
        {            
            Dictionary<string, List<int>> cars = new Dictionary<string, List<int>>();
            ReadCars(cars);

            string command = Console.ReadLine();
            while (command!="Stop")
            {
                var commandItems = command.Split(" : ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (commandItems[0]=="Drive")
                {
                    //•	Drive : {car} : {distance} : {fuel} 
                    string model = commandItems[1];
                    int distance = int.Parse(commandItems[2]);
                    int fuel = int.Parse(commandItems[3]);
                    Drive(cars, model, distance, fuel);
                }
                if (commandItems[0]== "Refuel")
                {
                    //•	Refuel : {car} : {fuel}
                    string model = commandItems[1];
                    int fuel = int.Parse(commandItems[2]);
                    Refuel(cars, model, fuel);
                }
                if (commandItems[0]== "Revert")
                {
                    //•	Revert : {car} : {kilometers}
                    string model = commandItems[1];
                    int kilometers = int.Parse(commandItems[2]);
                    Revert(cars, model, kilometers);
                }

                command = Console.ReadLine();
            }

            cars = cars
                .OrderByDescending(x => x.Value[0])
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key,x => x.Value);

            foreach (var item in cars)
            {
                Console.WriteLine($"{item.Key} -> Mileage: {item.Value[0]} kms, Fuel in the tank: {item.Value[1]} lt.");
            }

        }

        private static Dictionary<string, List<int>> Revert(Dictionary<string, List<int>> cars, string model, int kilometers)
        {
            if (cars[model][0]-kilometers>=10000)
            {
                Console.WriteLine($"{model} mileage decreased by {kilometers} kilometers");
                cars[model][0] -= kilometers;
            }
            else
            {
                cars[model][0] = 10000;
            }
            return cars;
        }

        private static Dictionary<string, List<int>> Refuel(Dictionary<string, List<int>> cars, string model, int fuel)
        {
            //a maximum of 75 liters of fuel
            if (cars[model][1]+fuel>75)
            {
                int refueled = 75 - cars[model][1];
                cars[model][1] = 75;
                Console.WriteLine($"{model} refueled with {refueled} liters");
            }
            else
            {
                cars[model][1] += fuel;
                Console.WriteLine($"{model} refueled with {fuel} liters");
            }
            return cars;
        }

        private static Dictionary<string, List<int>> Drive(Dictionary<string, List<int>> cars, string model, int distance, int fuel)
        {
            if (cars[model][1]<fuel)
            {
                Console.WriteLine("Not enough fuel to make that ride");
            }
            else
            {
                Console.WriteLine($"{model} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                cars[model][0] += distance;
                cars[model][1] -= fuel;
            }
            if (cars[model][0]>=100000)
            {
                Console.WriteLine($"Time to sell the {model}!");
                cars.Remove(model);
            }
            return cars;
        }

        private static Dictionary<string, List<int>> ReadCars(Dictionary<string, List<int>> cars)
        {
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split("|", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                List<int> carItems = new List<int>();
                //{car}|{mileage}|{fuel}
                string model = input[0];
                int mileage = int.Parse(input[1]);
                int fuel = int.Parse(input[2]);
                carItems.Add(mileage);
                carItems.Add(fuel);
                //fill in dict
                cars.Add(model, carItems);
            }

            return cars;
        }
    }
}
