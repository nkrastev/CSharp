using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04WildFarm.Models
{
    public abstract class Food
    {
        //fields
        private int quantity;

        //ctor

        //prop       

        public int Quantity
        {
            get => this.quantity;
            set { this.quantity = value; }
        }

    }
}
