using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04WildFarm.Models
{
    public abstract class Animal
    {
        //fields        
        public string Name { get; set; }
        public double Weight { get; set; }
        public int FoodEaten { get; set; }

        //methods
        public abstract string ProduceSound();

        public virtual void Feed(string type, int quantity)
        {
            this.FoodEaten += quantity;
        }


    }
}
