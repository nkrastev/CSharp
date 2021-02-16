using System;
using System.Collections.Generic;
using System.Text;

namespace HealthyHeaven
{
    public class Vegetable
    {
        public Vegetable(string name, int calories)
        {
            Name = name;
            Calories = calories;
        }

        public string Name { get; set; }
        public int Calories { get; set; }

        public override string ToString() => $" - {this.Name} have {this.Calories} calories";
        
    }
}
