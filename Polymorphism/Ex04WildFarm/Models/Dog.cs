using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04WildFarm.Models
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override string ProduceSound() => "Woof!";

        public override void Feed(string type, int quantity)
        {
            if (type != "Meat")
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {type}!");
            }
            this.FoodEaten += quantity;
            this.Weight += quantity * 0.4;
        }
    }
}
