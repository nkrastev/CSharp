using System;
using System.Collections.Generic;
using System.Text;

namespace Ex01Vehicles
{
    public class Car : Vehicle
    {
        private const double FUELCONSUMPTION_WITH_AC = 0.9;
        public Car(double fuel, double consumption) : base(fuel, consumption)
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

        public override void Refuel(double liters)
        {
            //refuel 100%
            this.FuelQuantity += liters;
        }
    }
}
