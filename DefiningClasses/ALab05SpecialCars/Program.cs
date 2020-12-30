using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    class Program
    {
        static void Main()
        {
            List<Tire[]> tiresList = ReadTires();
            List<Engine> enginesList = ReadEngines();
            List<Car> carsList = ReadCars(tiresList, enginesList);

            for (int i = 0; i < carsList.Count; i++)
            {
                if (
                    carsList[i].Year>=2017 && 
                    carsList[i].Engine.HorsePower>330 && 
                    carsList[i].SumTirePressure()>9 &&
                    carsList[i].SumTirePressure()<10)
                {
                    //drive 20 kilometers and print details
                    carsList[i].Drive(20);
                    Console.WriteLine(carsList[i].PrintDetails());                    
                }
            }
            
        }

        

        private static List<Car> ReadCars(List<Tire[]> tiresList, List<Engine> enginesList)
        {
            var list = new List<Car>();
            var command = Console.ReadLine();
            while (command!= "Show special")
            {
                var cmdAgrs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                var carMake = cmdAgrs[0];
                var carModel = cmdAgrs[1];
                var carYear = int.Parse(cmdAgrs[2]);
                var carFuelQuantity = double.Parse(cmdAgrs[3]);
                var carFuelConsumption = double.Parse(cmdAgrs[4]);
                var carEngineIndex = int.Parse(cmdAgrs[5]);
                var carTireIndex = int.Parse(cmdAgrs[6]);

                Car carItem = new Car(
                    carMake, 
                    carModel, 
                    carYear, 
                    carFuelQuantity, 
                    carFuelConsumption, 
                    enginesList[carEngineIndex], 
                    tiresList[carTireIndex]);

                list.Add(carItem);
                command = Console.ReadLine();
            }

            return list;
        }

        private static List<Engine> ReadEngines()
        {
            var list = new List<Engine>();
            var command = Console.ReadLine();
            while (command != "Engines done")
            {
                var cmdArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                var horsePower = int.Parse(cmdArgs[0]);
                var cubicCapacity = double.Parse(cmdArgs[1]);
                Engine engineItem = new Engine(horsePower, cubicCapacity);
                list.Add(engineItem);
                command = Console.ReadLine();
            }
            return list;
        }

        private static List<Tire[]> ReadTires()
        {
            var list = new List<Tire[]>();
            var command = Console.ReadLine();
            while (command!= "No more tires")
            {
                var tireSet = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                var fourTires = new List<Tire>();
                for (int i = 0; i < tireSet.Length; i += 2)
                {
                    var year = int.Parse(tireSet[i]);
                    var pressure = double.Parse(tireSet[i + 1]);
                    var tire = new Tire(year, pressure);
                    fourTires.Add(tire);
                }
                list.Add(fourTires.ToArray());
                command = Console.ReadLine();
            }
            return list;
        }
    }
}
