using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04WildFarm.Models
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override string ProduceSound() => "Meow";

        public override void Feed(string type, int quantity)
        {
            if (type != "Vegetable" && type != "Meat")
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {type}!");
            }
            this.FoodEaten += quantity;
            this.Weight += quantity * 0.3;
        }

    }
}
