using System;
using System.Collections.Generic;
using System.Text;

namespace Ex07RawData
{
    public class Tire
    {
        //fields
        private int age;
        private double pressure;

        //constructor
        public Tire(int age, double pressure)
        {
            this.Age = age;
            this.Pressure = pressure;
        }

        //properties
        public int Age { get; set; }
        public double Pressure { get; set; }
    }
}
