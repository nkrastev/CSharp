using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex04PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private ICollection<Topping> toppings;

        public Pizza(string name)
        {
            this.Name = name;
            this.toppings = new List<Topping>();
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (String.IsNullOrWhiteSpace(value) || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                this.name = value;
            }
        }

        public Dough Dough
        {
            set
            {
                this.dough = value;
            }
        }

        public int NumberOfToppings
        {
            get => this.toppings.Count;
        }

        public void AddTopping(Topping toppling)
        {
            if (toppings.Count == 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            toppings.Add(toppling);
        }

        public double Calories() => dough.Calories() + toppings.Sum(x => x.Calories());

        public override string ToString()
        {
            return $"{this.Name} - {this.Calories():f2} Calories.";
        }
    }
}
