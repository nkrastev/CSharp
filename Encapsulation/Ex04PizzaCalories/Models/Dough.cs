using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04PizzaCalories.Models
{
    public class Dough
    {
        //const
        private const double TYPE_WHITE= 1.5;
        private const double TYPE_WHOLEGRAIN= 1.0;
        private const double BAKE_CRISPY= 0.9;
        private const double BAKE_CHEWY= 1.1;
        private const double BAKE_HOMEMADE= 1.0;
        private const string errorWeight = "Dough weight should be in the range [1..200].";
        private const string errorDough = "Invalid type of dough.";


        //fields
        private string flourType;
        private string bakingType;
        private double weight;       

        //ctor
        public Dough(string flourType, string bakingType, double weight)
        {
            this.FlourType = flourType;
            this.BakingType = bakingType;
            this.Weight = weight;
        }

        //prop
        public string FlourType 
        { 
            get => this.flourType;
            private set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException(errorDough);
                }
                this.flourType = value;
            }
        }
        public string BakingType 
        {
            get => this.bakingType; 
            private set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException(errorDough);
                }
                this.bakingType = value;
            }
        }

        public double Weight 
        {
            get => this.weight; 
            private set
            {
                if (value>200 || value<1)
                {
                    throw new ArgumentException(errorWeight);
                }
                this.weight = value;
            }
        }

        //methods
        public double CaloriesPerGram()
        {
            //Every dough has 2 calories per gram as a base and a modifier 
            double result = 2 * this.weight;

            if (this.flourType.ToLower()=="white") { result *= TYPE_WHITE; }
            if (this.flourType.ToLower() == "wholegrain") { result *= TYPE_WHOLEGRAIN; }
            if (this.bakingType.ToLower() == "crispy") { result *= BAKE_CRISPY; }
            if (this.bakingType.ToLower() == "chewy") { result *= BAKE_CHEWY; }
            if (this.bakingType.ToLower() == "homemade") { result *= BAKE_HOMEMADE; }

            //Console.WriteLine($"dough calories {result}");
            return result;
        }
    }
}
