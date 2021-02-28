using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04PizzaCalories
{
    public class Dough
    {
        //flour type, which can be white or wholegrain
        //baking technique, which can be crispy, chewy or homemade
        //weight in grams
        //Modifiers:	
        /*•	White - 1.5;
        •	Wholegrain - 1.0;
        •	Crispy - 0.9;
        •	Chewy - 1.1;
        •	Homemade - 1.0;*/       

        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flour, string baking, double weight)
        {
            this.Flour = flour;
            this.Baking = baking;
            this.Weight = weight;
        }
        public string Flour 
        {
            get => this.flourType;
            private set
            {
                if (value.ToLower()!= "white" && value.ToLower()!= "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.flourType = value;
            }
        }

        public string Baking
        {
            get => this.bakingTechnique;
            private set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower()!= "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.bakingTechnique = value;
            }
        }

        public double Weight 
        {
            get => this.weight;
            private set
            {
                if (value<1 || value>200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                this.weight = value;
            }
        }

        public double Calories()
        {            
            double totalModifier = 1;

            if (flourType.ToLower()=="white") { totalModifier *= 1.5; }            
            if (bakingTechnique.ToLower() == "crispy") { totalModifier *= 0.9; }
            if (bakingTechnique.ToLower() == "chewy") { totalModifier *= 1.1; }

            return 2 * weight * totalModifier;
        }

    }
}
