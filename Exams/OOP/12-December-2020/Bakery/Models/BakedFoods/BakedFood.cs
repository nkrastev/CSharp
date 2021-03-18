using Bakery.Models.BakedFoods.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.BakedFoods
{
    public abstract class BakedFood : IBakedFood
    {
        private string name;
        private int portion;
        private decimal price;

        protected BakedFood(string name, int portion, decimal price)
        {
            this.Name = name;
            this.Portion = portion;
            this.Price = price;
        }

        public string Name
        {
            get { return this.name; }
            private set 
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or white space!");
                }
                this.name = value; 
            }
        }
        

        public int Portion
        {
            get { return this.portion; }
            private set 
            {
                if (value<=0)
                {
                    throw new ArgumentException("Portion cannot be less or equal to zero");
                }
                this.portion = value; 
            }
        }
        

        public decimal Price
        {
            get { return this.price; }
            private set 
            {
                if (value<=0)
                {
                    throw new ArgumentException("Price cannot be less or equal to zero!");
                }
                this.price = value;
            }
        }

        public virtual string ToString() =>$"{this.Name}: {this.Portion}g - {this.Price:f2}";
        
    }
}
