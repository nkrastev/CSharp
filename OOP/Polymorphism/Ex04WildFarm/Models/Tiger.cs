using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04WildFarm.Models
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override string ProduceSound() => "ROAR!!!";

        public override void Feed(string type, int quantity)
        {
            if (type != "Meat")
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {type}!");
            }
            this.FoodEaten += quantity;
            this.Weight += quantity * 1;
        }
    }
}
