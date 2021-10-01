using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Product
    {
        //ctor
        public Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        //prop
        public string Name { get; set; }
        public virtual decimal Price { get; set; }
    }
}
