using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04PizzaCalories.Models
{
    public class Pizza
    {
        //fields
        private string name;
        private List<Topping> toppings;
        private Dough dough;

        //ctor
        public Pizza(string name, Dough dough)
        {
            this.Name = name;            
            this.Dough = dough;
            this.toppings = new List<Topping>();
        }

        //prop
        public string Name 
        {
            get => this.name;
            private set
            {
                if (value == string.Empty || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                this.name = value;
            }
        }
        public IReadOnlyCollection<Topping> Toppings
        {
            get => this.toppings.AsReadOnly();
        }

        public Dough Dough
        {
            private get => this.dough;
            set => this.dough = value;
        }

        //methods
        public void AddTopping(Topping itemTopping)
        {
            if (this.toppings.Count==10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");                
            }
            this.toppings.Add(itemTopping);
        }
        public double GetTotalCalories()
        {
            double totalCal = dough.CaloriesPerGram();            

            foreach (var item in toppings)
            {                
                totalCal += item.CaloriesPerGram();
            }
            return totalCal;
        }

        public override string ToString()
        {
            return $"{this.name} - {this.GetTotalCalories():f2} Calories.";
        }
    }
}
