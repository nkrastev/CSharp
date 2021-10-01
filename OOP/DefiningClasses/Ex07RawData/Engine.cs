using System;
using System.Collections.Generic;
using System.Text;

namespace Ex07RawData
{
    public class Engine
    {
        //fields
        private int speed;
        private int power;

        //constructor
        public Engine(int speed, int power)
        {
            this.Speed = speed;
            this.Power = power;
        }

        //properties
        public int Speed { get; set; }
        public int Power { get; set; }
    }
}
