using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03ShoppingSpree
{
    public class Product
    {
        //fields
        private string name;
        private decimal cost;

        //ctor
        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

        //prop
        public string Name 
        {
            get => this.name;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                this.name = value;
            }
        }
        public decimal Cost 
        {
            get => this.cost;
            private set
            {
                if (value<=0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.cost = value;
            }
        }

    }
}
