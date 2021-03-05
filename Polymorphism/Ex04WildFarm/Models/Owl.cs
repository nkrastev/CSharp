using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04WildFarm.Models
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingsize)
            : base(name, weight, wingsize)
        {
        }

        public override string ProduceSound() => "Hoot Hoot";

        public override void Feed(string type, int quantity)
        {
            if (type!="Meat")
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {type}!");
            }
            this.FoodEaten += quantity;
            this.Weight += quantity * 0.25;
        }
    }
}
