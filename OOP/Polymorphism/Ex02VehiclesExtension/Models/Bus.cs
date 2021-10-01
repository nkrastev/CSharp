using System;
using System.Collections.Generic;
using System.Text;

namespace Ex02VehiclesExtension.Models
{
    public class Bus : Vehicle
    {
        private const double FUELCONSUMPTION_WITH_PEOPLE = 1.4;

        public Bus(double fuel, double consumption, double tank) : base(fuel, consumption, tank)
        {
        }

        public override void Drive(double distance)
        {
            var totalFuelConsumption = this.FuelConsumption + FUELCONSUMPTION_WITH_PEOPLE;
            if (totalFuelConsumption * distance <= this.FuelQuantity)
            {
                this.FuelQuantity -= totalFuelConsumption * distance;
                Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
            }
        }


        public override void DriveEmpty(double distance)
        {
            var totalFuelConsumption = this.FuelConsumption;
            if (totalFuelConsumption * distance <= this.FuelQuantity)
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
