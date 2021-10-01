using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        //fields
        private const double DefaultFuelConsumption = 3.0;

        //override base ctor
        public Car(int horsePower, double fuel) : base(horsePower, fuel)
        {
        }

        public override double FuelConsumption()
        {
            return DefaultFuelConsumption;
        }
    }
}
