using System;
using System.Collections.Generic;
using System.Text;

namespace P01_RawData.Models
{
    public class Tire
    {        
        public double Pressure { get; set; }
        public int Age { get; set; }

        public Tire(double pressure, int age)
        {
            this.Pressure = pressure;
            this.Age = age;
        }


    }
}
