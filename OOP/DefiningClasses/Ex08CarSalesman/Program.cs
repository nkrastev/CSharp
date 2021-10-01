using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex08CarSalesman
{
    class Program
    {
        static void Main()
        {
            var engineList = ReadEngines(int.Parse(Console.ReadLine()));
            var carList = ReadCars(int.Parse(Console.ReadLine()), engineList);

            //output
            foreach (Car item in carList)
            {
                Console.WriteLine(item.ToString());
            }

        }

        private static List<Car> ReadCars(int numberOfCars, List<Engine> engineList)
        {
            //car has only the default constructor
            var list = new List<Car>();
            for (int i = 0; i < numberOfCars; i++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (input.Length==2)
                {
                    //only model and engine provided
                    var carEngineModel = input[1];
                    var newEngine = new Engine(carEngineModel, 0);
                    foreach (Engine item in engineList.Where(x=>x.Model==carEngineModel))
                    {
                        newEngine = item;
                    }
                    var carItem = new Car(input[0],newEngine,0,"n/a");
                    list.Add(carItem);
                }
                else if (input.Length == 3)
                {
                    var lastInputValue = input[2];
                    var isNumeric = !string.IsNullOrEmpty(lastInputValue) && lastInputValue.All(Char.IsDigit);
                    if (isNumeric)
                    {
                        //last value is numeric =>car has model, engine, weight
                        var carEngineModel = input[1];
                        var newEngine = new Engine(carEngineModel, 0);
                        foreach (Engine item in engineList.Where(x => x.Model == carEngineModel))
                        {
                            newEngine = item;
                        }
                        var carItem = new Car(input[0], newEngine, int.Parse(input[2]), "n/a");
                        list.Add(carItem);
                    }
                    else
                    {
                        //last value is string =>car has model, engine, color
                        var carEngineModel = input[1];
                        var newEngine = new Engine(carEngineModel, 0);
                        foreach (Engine item in engineList.Where(x => x.Model == carEngineModel))
                        {
                            newEngine = item;
                        }
                        var carItem = new Car(input[0], newEngine, 0, input[2]);
                        list.Add(carItem);
                    }
                }
                else
                {
                    //4 values are provided by input
                    var carEngineModel = input[1];
                    var newEngine = new Engine(carEngineModel, 0);
                    foreach (Engine item in engineList.Where(x => x.Model == carEngineModel))
                    {
                        newEngine = item;
                    }                    
                    var carItem = new Car(input[0], newEngine, int.Parse(input[2]), input[3]);
                    list.Add(carItem);
                }
            }

            return list;
        }

        private static List<Engine> ReadEngines(int numberOfEngines)
        {
            var list = new List<Engine>();
            for (int i = 0; i < numberOfEngines; i++)
            {
                var input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (input.Length==2)
                {
                    //only model and power
                    var engine = new Engine(input[0], int.Parse(input[1]));
                    list.Add(engine);
                }
                else if (input.Length==3)
                {
                    //two cases
                    var lastInputValue = input[2];
                    var isNumeric = !string.IsNullOrEmpty(lastInputValue) && lastInputValue.All(Char.IsDigit);
                    if (isNumeric)
                    {
                        //last value is numeric => model, power, displacement
                        var engine = new Engine(input[0], int.Parse(input[1]), int.Parse(input[2]));
                        list.Add(engine);
                    }
                    else
                    {
                        //last value is string => model, power, efficiency
                        var engine = new Engine(input[0], int.Parse(input[1]), input[2]);
                        list.Add(engine);
                    }
                }
                else
                {
                    //4 values are provided by input
                    var engine = new Engine(input[0], int.Parse(input[1]), int.Parse(input[2]), input[3]);
                    list.Add(engine);
                }
            }
            return list;
        }
    }
}
