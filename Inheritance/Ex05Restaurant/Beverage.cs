using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Beverage : Product
    {
        public Beverage(string name, decimal price, double milliliters)
            : base(name, price)
        {
            this.Milliliters = milliliters; 
        }

        //prop
        //public virtual double Price { get; set; } no need of this, price is virtual from Product
        public virtual double Milliliters { get; set; }
    }
}
