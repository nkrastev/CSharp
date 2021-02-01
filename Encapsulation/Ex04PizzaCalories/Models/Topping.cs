using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04PizzaCalories.Models
{
    public class Topping
    {
        //const
        private const double TYPE_MEAT = 1.2;
        private const double TYPE_VEGGIES = 0.8;
        private const double TYPE_CHEESE = 1.1;
        private const double TYPE_SAUCE = 0.9;


        //fields
        private string type;
        private double weight;

        //ctor
        public Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        //prop
        public string Type 
        {
            get => this.type;
            private set
            {
                if (value.ToLower()!="meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    //var valueName = value[0].ToString().ToUpper() + value.Substring(1);
                    //throw new ArgumentException($"Cannot place {valueName} on top of your pizza.");
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                this.type = value;
            }
        }
        public double Weight 
        {
            get => this.weight;
            private set
            {
                if (value>50 || value<1)
                {
                    throw new ArgumentException($"{this.type} weight should be in the range[1..50].");
                }
                this.weight = value;
            }
        }

        //methods

        public double CaloriesPerGram()
        {
            //The base calories per gram are 2 
            double result = 2 * this.weight;

            if (this.type.ToLower() == "meat") { result *= TYPE_MEAT; }
            if (this.type.ToLower() == "veggies") { result *= TYPE_VEGGIES; }
            if (this.type.ToLower() == "cheese") { result *= TYPE_CHEESE; }
            if (this.type.ToLower() == "sauce") { result *= TYPE_SAUCE; }            

            return result;
        }
    }
}
