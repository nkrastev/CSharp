using System;
using System.Collections.Generic;
using System.Text;

namespace Ex01Vehicles
{
    public class Truck : Vehicle
    {
        private const double FUELCONSUMPTION_WITH_AC = 1.6;
        public Truck(double fuel, double consumption) : base(fuel, consumption)
        {
        }               

        public override void Drive(double distance)
        {            
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
            //refuel 95%
            this.FuelQuantity += liters * 95 / 100.0;
        }
    }
}
