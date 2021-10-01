using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public abstract class Animal
    {
        private string name;
        private string favouriteFood;

        public Animal(string name, string food)
        {
            this.Name = name;
            this.FavouriteFood = food;
        }

        public string Name { get; protected set; }
        public string FavouriteFood { get; protected set; }

        public virtual string ExplainSelf()
        {
            return $"I am {this.Name} and my fovourite food is {this.FavouriteFood}";
        }
    }
}
