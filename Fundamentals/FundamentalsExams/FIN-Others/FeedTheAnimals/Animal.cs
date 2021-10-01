using System;
using System.Collections.Generic;
using System.Text;

namespace FeedTheAnimals
{
    public class Animal
    {
        //constructor
        public Animal(string name, int foodlimit, string area)
        {
            Name = name;
            FoodLimit = foodlimit;
            Area = area;
        }
        //properties
        public string Name { get; set; }
        public int FoodLimit { get; set; }
        public string Area { get; set; }
    }
}
