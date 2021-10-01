using System;
using System.Collections.Generic;
using System.Text;

namespace Ex02VehiclesExtension.Models
{
    public abstract class Vehicle
    {
        //fields
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;

        public Vehicle(double fuel, double consumption, double tank)
        {
            if (tank >= fuel)
            {
                this.FuelQuantity = fuel;
            }
            else
            {
                this.FuelQuantity = 0;
            }

            this.FuelConsumption = consumption;
            this.TankCapacity = tank;

            
        }

        //prop
        public double TankCapacity
        {
            get => this.tankCapacity;
            set => this.tankCapacity = value;
        }
        public double FuelQuantity 
        { 
            get => this.fuelQuantity;
            set => this.fuelQuantity = value;            
        }
        public double FuelConsumption { get => this.fuelConsumption;  set => this.fuelConsumption = value; }

        

        //methods
        public virtual void Refuel(double liters)
        {
            if (liters <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }

            if (liters>this.tankCapacity-this.fuelQuantity)
            {
                //cannot fit
                Console.WriteLine($"Cannot fit {liters} fuel in the tank");
            }

            if (liters>0 && liters <= this.tankCapacity - this.fuelQuantity)
            {
                //refuel is possible
                if (this.GetType().Name=="Truck")
                {
                    this.FuelQuantity += liters * 95 / 100.0;
                }
                else
                {
                    this.FuelQuantity += liters;
                }
            }

        }
        public abstract void Drive(double distance);
        public virtual void DriveEmpty(double distance)
        {
        }
    }
}
