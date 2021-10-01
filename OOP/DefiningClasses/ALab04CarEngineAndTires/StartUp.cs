using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            var carTires = new Tire[5]
            {
                new Tire(2020, 2.1),
                new Tire(2020, 2.1),
                new Tire(2020, 2.1),
                new Tire(2020, 2.1),
                new Tire(2020, 2.1)
            };

            var engine = new Engine(55, 1.2);
            var car = new Car("Ford", "KA", 1050, 2, 3, engine, carTires);
            
        }
    }
}
