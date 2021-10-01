using System;
using System.Collections.Generic;
using System.Text;

namespace Ex06SpeedRacing
{
    public class Car
    {
        //fields
        private string model;
        private double fuelAmount;
        private double fuelConsumptionPerKilometer;
        private double travelledDistance;

        //constructor
        public Car(string model, double fuel, double consumption)
        {
            this.Model = model;
            this.FuelAmount = fuel;
            this.FuelConsumptionPerKilometer = consumption;
            this.TravelledDistance = 0;
        }

        //properties
        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }
        public double FuelAmount
        {
            get { return this.fuelAmount; }
            set { this.fuelAmount = value; }
        }
        public double FuelConsumptionPerKilometer
        {
            get { return this.fuelConsumptionPerKilometer; }
            set { this.fuelConsumptionPerKilometer = value; }
        }
        public double TravelledDistance
        {
            get { return this.travelledDistance; }
            set
            {
                if (value<0)
                {
                    throw new ArgumentException("Travelled distance cannot be negative.");
                }
                this.travelledDistance = value;
            }
        }

        //methods
        public void Drive(double distanceToDrive)
        {
            if (((this.FuelAmount - distanceToDrive * this.FuelConsumptionPerKilometer) >= 0.0))
            {
                this.FuelAmount -= distanceToDrive * this.FuelConsumptionPerKilometer;
                this.TravelledDistance += distanceToDrive;
            }
            else
            {
                //have to throw exception not CW
                Console.WriteLine("Insufficient fuel for the drive");
            }
            
        }
    }
}
