using System;
using System.Collections.Generic;
using System.Text;

namespace Rabbits
{
    public class Rabbit
    {

        //ctor
        public Rabbit(string name, string species)
        {
            this.Name = name;
            this.Species = species;
            this.Available = true;
        }

        //prop
        public string Name { get; set; }
        public string Species { get; set; }
        public bool Available { get; set; }

        //methods
        public override string ToString() =>$"Rabbit({this.Species}): {this.Name}";
    
    }
}
