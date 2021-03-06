using System;
using System.Collections.Generic;
using System.Text;

namespace Ex06FoodShortage
{
    public class Rebel : IBuyer
    {
        private string name;
        private int age;
        private string group;
        private int food;

        public Rebel(string name, int age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
            this.Food = 0;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Group { get; set; }
        public int Food { get => this.food; set => this.food = value; }

        public void BuyFood()
        {
            this.food += 5;
        }
    }
}
