using System;
using System.Collections.Generic;
using System.Text;

namespace Ex01Vehicles
{
    public abstract class Vehicle
    {
        //fields
        private double fuelQuantity;
        private double fuelConsumption;

        public Vehicle(double fuel, double consumption)
        {
            this.FuelQuantity = fuel;
            this.FuelConsumption = consumption;
        }

        //prop
        public double FuelQuantity { get => this.fuelQuantity;  set => this.fuelQuantity = value; }
        public double FuelConsumption { get => this.fuelConsumption;  set => this.fuelConsumption = value; }
        
        //methods
        public abstract void Refuel(double liters);
        public abstract void Drive(double distance);
    }
}
