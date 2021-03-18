using Bakery.Models.Drinks.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.Drinks
{
    public abstract class Drink : IDrink
    {
        private string name;
        private int portion;
        private decimal price;
        private string brand;
        protected Drink(string name, int portion, decimal price, string brand)
        {
            this.Name = name;
            this.Portion = portion;
            this.Price = price;
            this.Brand = brand;

        }

        public string Name
        {
            get => this.name;
            private set
            {
                if(String.IsNullOrWhiteSpace(value))
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
                if (value <= 0)
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
                if (value <= 0)
                {
                    throw new ArgumentException("Price cannot be less or equal to zero!");
                }
                this.price = value;
            }
        }

        public string Brand
        {
            get => this.brand;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Brand cannot be null or white space!");
                }
                this.brand = value;
            }
        }

        public virtual string ToString() => $"{this.Name} {this.Brand} - {this.Portion}ml - {this.Price:f2}lv";

    }
}
