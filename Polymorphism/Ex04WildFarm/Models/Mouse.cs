using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04WildFarm.Models
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override string ProduceSound() => "Squeak";

        public override void Feed(string type, int quantity)
        {
            if (type != "Vegetable" && type!= "Fruit")
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {type}!");
            }
            this.FoodEaten += quantity;
            this.Weight += quantity * 0.1;
        }
    }
}
