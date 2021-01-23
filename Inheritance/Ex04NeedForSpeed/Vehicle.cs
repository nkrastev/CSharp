using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        //fields        
        const double DefaultFuelConsumption = 1.25;

        //ctor     
        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
        }

        //prop
        public int HorsePower { get; set; }
        public double Fuel { get; set; }

        

        //methods
        public virtual double FuelConsumption()
        {
            return DefaultFuelConsumption;
        }

        public virtual void Drive(double kilometers)
        {
            this.Fuel -= kilometers * this.FuelConsumption();
        }

    }
}
