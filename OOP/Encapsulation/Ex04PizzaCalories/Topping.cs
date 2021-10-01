using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04PizzaCalories
{
    public class Topping
    {
        private const string INVALID_WEIGHT = "{0} weight should be in the range [1..50].";

        private string typeOfMeat;
        private double weight;       

        public Topping(string typeOfMeat, double weight)
        {
            this.TypeOfMeat = typeOfMeat;
            this.Weight = weight;
        }

        public string TypeOfMeat
        {
            get => this.typeOfMeat;
            private set 
            {
                if (value.ToLower()!="meat" && 
                    value.ToLower()!= "veggies" && 
                    value.ToLower()!= "cheese" && 
                    value.ToLower()!= "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                this.typeOfMeat = value;
            }
        }
        public double Weight
        {
            get => this.weight;
            private set
            {
                if(value<1 || value>50)
                {
                    //-8 points cause of the format of exception!!!??? {0} weight should be in the range [1..50].                           
                    throw new ArgumentException(String.Format(INVALID_WEIGHT, this.TypeOfMeat));
                    //throw new ArgumentException($"{typeOfMeat} weight should be in the range[1..50].");
                }
                this.weight = value;
            }
        }

        public double Calories()
        {
            double totalModifier = 1;

            if (this.TypeOfMeat.ToLower() == "meat") { totalModifier *= 1.2; }
            if (this.TypeOfMeat.ToLower() == "veggies") { totalModifier *= 0.8; }
            if (this.TypeOfMeat.ToLower() == "cheese") { totalModifier *= 1.1; }
            if (this.TypeOfMeat.ToLower() == "sauce") { totalModifier *= 0.9; }

            double result = 2 * this.weight * totalModifier;

            return result;
        }


    }
}
