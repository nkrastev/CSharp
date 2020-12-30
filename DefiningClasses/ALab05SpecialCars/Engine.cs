using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Engine
    {
        //fields
        private int horsePower;
        private double cubicCapacity;

        //constructors
        public Engine(int horsePower, double cubics)
        {
            this.HorsePower = horsePower;
            this.CubicCapacity = cubics;
        }

        //properties
        public int HorsePower { get; set; }
        public double CubicCapacity { get; set; }
    }
}
