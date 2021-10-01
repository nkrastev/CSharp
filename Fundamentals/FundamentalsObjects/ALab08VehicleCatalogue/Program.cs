using System;
using System.Collections.Generic;
using System.Linq;

namespace ALab08VehicleCatalogue
{
    class Program
    {
        static void Main()
        {
            var catalogs = new Catalog();
            catalogs.Cars = new List<Car>();
            catalogs.Trucks = new List<Truck>();
            
            List<string> input = Console.ReadLine().Split("/", StringSplitOptions.RemoveEmptyEntries).ToList();

            while (input[0]!="end")
            {
                if (input[0]=="Car")
                {
                    Car newCar = new Car();
                    newCar.Brand = input[1];
                    newCar.Model = input[2];
                    newCar.HorsePower = int.Parse(input[3]);
                    catalogs.Cars.Add(newCar);
                }
                if (input[0] == "Truck")
                {
                    Truck newTruck = new Truck();
                    newTruck.Brand = input[1];
                    newTruck.Model = input[2];
                    newTruck.Weight = int.Parse(input[3]);
                    catalogs.Trucks.Add(newTruck);
                }

                input = Console.ReadLine().Split("/", StringSplitOptions.RemoveEmptyEntries).ToList();
            }
            
            catalogs.Cars = catalogs.Cars.OrderBy(x => x.Brand).ToList();
            catalogs.Trucks = catalogs.Trucks.OrderBy(x => x.Brand).ToList();

            Console.WriteLine("Cars:");
            foreach (Car item in catalogs.Cars)
            {
                Console.WriteLine($"{item.Brand}: {item.Model} - {item.HorsePower}hp");
            }
            Console.WriteLine("Trucks:");
            foreach (Truck item in catalogs.Trucks)
            {
                Console.WriteLine($"{item.Brand}: {item.Model} - {item.Weight}kg");
            }
        }
    }

    class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Weight { get; set; }
    }
    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
    }
    class Catalog
    {
        public List<Car> Cars { get; set; }
        public List<Truck> Trucks { get; set; }
    }
}
