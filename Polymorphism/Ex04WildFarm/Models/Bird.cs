using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04WildFarm.Models
{
    public abstract class Bird : Animal
    {
        public Bird(string name, double weight, double wingsize)
        {
            this.Name = name;
            this.Weight = weight;
            this.WingSize = wingsize;           
        }
        public double WingSize { get; set; }

        public override string ToString() => $"{this.GetType().Name} [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";

        
    }
}
