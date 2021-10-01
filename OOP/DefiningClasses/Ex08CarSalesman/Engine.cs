using System;
using System.Collections.Generic;
using System.Text;

namespace Ex08CarSalesman
{
    public class Engine
    {
        //fields
        private string model;
        private int power;
        private int displacement;
        private string efficiency;

        //constructor, default values 

        public Engine(string model, int power)
        {
            this.Model = model;
            this.Power = power;
        }

        public Engine(string model, int power, int displacement)
            :this(model, power)
        {            
            this.Displacement = displacement;           
        }
        public Engine(string model, int power, string efficiency)
            : this(model, power)
        {
            this.Efficiency = efficiency;
        }

        public Engine(string model, int power, int displacement, string efficiency)            
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = displacement;
            this.Efficiency = efficiency;
        }

        //properties
        public string Model { get; set; }
        public int Power { get; set; }
        public int Displacement { get; set; }
        public string Efficiency { get; set; }

    }
}
