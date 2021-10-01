using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex07RawData
{
    public class Program
    {
        static void Main()
        {
            List<Car> carList = ReadCars(int.Parse(Console.ReadLine()));
            var command = Console.ReadLine();

            if (command== "fragile")
            {
                //car models, whose cargo is "fragile" with a tire, whose pressure is  < 1
                foreach (Car item in carList.Where(x=>x.Cargo.Type== "fragile"))
                {
                    if (CheckPressure(item))
                    {
                        Console.WriteLine(item.Model);
                    }
                }
            }
            if (command== "flamable")
            {
                //car models, whose cargo is "flamable" and have engine power > 250
                foreach (Car item in carList.Where(x=>x.Cargo.Type== "flamable").Where(x=>x.Engine.Power>250))
                {
                    Console.WriteLine(item.Model);
                }

            }

        }
        private static bool CheckPressure(Car carItem)
        {
            bool hasPressureUnder1 = false;
            for (int i = 0; i < 4; i++)
            {
                if (carItem.Tires[i].Pressure<1)
                {
                    hasPressureUnder1 = true;
                    break;
                }
            }
            return hasPressureUnder1;
        }

        private static List<Car> ReadCars(int numberOfCars)
        {
            List<Car> list = new List<Car>();
            for (int i = 0; i < numberOfCars; i++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                //init engine
                Engine engineItem = new Engine(int.Parse(input[1]), int.Parse(input[2]));
                //init cargo
                Cargo cargoItem = new Cargo(int.Parse(input[3]), input[4]);
                //init 4 tires, not the best solution, if you have 100 tires? :)
                Tire[] tires = new Tire[4];
                tires[0] = new Tire(int.Parse(input[6]), double.Parse(input[5]));
                tires[1] = new Tire(int.Parse(input[8]), double.Parse(input[7]));
                tires[2] = new Tire(int.Parse(input[10]), double.Parse(input[9]));
                tires[3] = new Tire(int.Parse(input[12]), double.Parse(input[11]));
                Car carItem = new Car(input[0], engineItem, cargoItem, tires);
                list.Add(carItem);
            }
            return list;
        }
    }
}
