using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> carList = new List<Car>();

            for (int i = 0; i < n; i++)
            {                
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string inputModel = input[0];
                int inputEngineSpeed = int.Parse(input[1]);
                int inputEnginePower = int.Parse(input[2]);
                int inputCargoWeight = int.Parse(input[3]);
                string inputCargoType = input[4];
                
                Car carItem = new Car
                (
                    inputModel,
                    new Engine(inputEngineSpeed, inputEnginePower),
                    new Cargo( inputCargoWeight, inputCargoType)                                     
                );
                carList.Add(carItem);
            }

            string command = Console.ReadLine();
            PrintOutput(carList, command);
            
        }

        private static void PrintOutput(List<Car> carList, string command)
        {
            if (command == "fragile")
            {                
                List<string> filteredList = carList
                    .Where(x=> x.Cargo.CargoWeight<1000)
                    .Select(y => y.Model)
                    .ToList();
                Console.WriteLine(String.Join("\n",filteredList));
            }

            if (command == "flamable")
            {               
                List<string> filteredList = carList
                    .Where(x => x.Engine.EnginePower > 250 && x.Cargo.CargoType=="flamable")
                    .Select(y => y.Model)
                    .ToList();
                Console.WriteLine(String.Join("\n", filteredList));
            }
        }
    }

    class Car
    {
        //constructor
        public Car(string carModel, Engine carEngine, Cargo carCargo)
        {
            Model = carModel;
            Engine = carEngine;
            Cargo = carCargo;
        }

        //properties
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
    }

    class Engine
    {
        //constructor
        public Engine(int speed, int power)
        {
            EngineSpeed = speed;
            EnginePower = power;

        }
        //properties
        public int EngineSpeed { get; set; }
        public int EnginePower { get; set; }
    }

    class Cargo
    {
        //constructor
        public Cargo(int weight, string type)
        {
            CargoWeight = weight;
            CargoType = type;
        }
        //properties
        public int CargoWeight { get; set; }
        public string CargoType { get; set; }
    }
}
