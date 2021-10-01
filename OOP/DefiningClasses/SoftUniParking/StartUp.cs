using System;
using System.Collections.Generic;

namespace SoftUniParking
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var car = new Car("Skoda", "Fabia", 65, "CC1856BG");
            var car2 = new Car("Audi", "A3", 110, "EB8787MN");
            var car3 = new Car("BMW", "M3", 110, "CT8787MN");
            var car4 = new Car("BMW", "M3", 110, "CO8780MN");

           

            var parking = new Parking(10);

            Console.WriteLine(parking.AddCar(car));                       
            Console.WriteLine(parking.AddCar(car2));
            Console.WriteLine(parking.AddCar(car3));
            Console.WriteLine(parking.AddCar(car4));
            


            List<string> forRemove = new List<string>();
            forRemove.Add("5");
            forRemove.Add("EB8787MN");
            forRemove.Add("CT8787MN");
            forRemove.Add("CT8787MN");

            parking.RemoveSetOfRegistrationNumber(forRemove);

            Console.WriteLine(parking.Count); //1




        }
    }
}
