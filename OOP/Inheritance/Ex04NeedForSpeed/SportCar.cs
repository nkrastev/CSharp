using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class SportCar : Car
    {
        //fields
        private const double DefaultFuelConsumption = 10.0;
        
        //ctor
        public SportCar(int horsePower, double fuel) : base(horsePower, fuel)
        {
        }

        //methods override
        public override double FuelConsumption()
        {
            return DefaultFuelConsumption;
        }


    }
}
