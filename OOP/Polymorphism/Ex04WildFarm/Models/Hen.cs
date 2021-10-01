using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04WildFarm.Models
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingsize) 
            : base(name, weight, wingsize)
        {
        }

        public override string ProduceSound() => "Cluck";

        public override void Feed(string type, int quantity)
        {
            base.Feed(type, quantity);
            this.Weight += quantity * 0.35;
        }

    }
}
