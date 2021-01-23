using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {
        //fields
        private const double DefaultFuelConsumption = 8.0;

        //ctor
        public RaceMotorcycle(int horsePower, double fuel) : base(horsePower, fuel)
        {
        }

        public override double FuelConsumption()
        {
            return DefaultFuelConsumption;
        }
    }
}
