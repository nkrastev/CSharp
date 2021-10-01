using System;
using System.Collections.Generic;
using System.Text;

namespace Ex02VehiclesExtension.Models
{
    public class Car : Vehicle
    {
        private const double FUELCONSUMPTION_WITH_AC = 0.9;
        public Car(double fuel, double consumption, double tank) : base(fuel, consumption, tank)
        {
        }

        

        public override void Drive(double distance)
        {
            //fuel consumption + 0.9
            var totalFuelConsumption = this.FuelConsumption + FUELCONSUMPTION_WITH_AC;
            if (totalFuelConsumption * distance<=this.FuelQuantity)
            {
                this.FuelQuantity -= totalFuelConsumption * distance;
                Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
            }
        }

       
    }
}
