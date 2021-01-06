using System;
using System.Collections.Generic;
using System.Text;

namespace Ex07RawData
{
    public class Cargo
    {
        //fields
        private int weight;
        private string type;

        //constructor
        public Cargo(int weight, string type)
        {
            this.Weight = weight;
            this.Type = type;
        }

        //properties
        public int Weight { get; set; }
        public string Type { get; set; }
    }
}
