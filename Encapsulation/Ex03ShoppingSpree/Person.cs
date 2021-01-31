using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03ShoppingSpree
{
    public class Person
    {
        //fields
        private string name;
        private decimal money;
        private List<Product> bag;

        //ctor
        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.bag = new List<Product>();
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
        public decimal Money
        {
            get => this.money;
            private set
            {
                if(value<0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.money = value;
            }
        }

        public IReadOnlyCollection<Product> Bag
        {
            get => this.bag.AsReadOnly();
        }

        //method
        public string AddProduct(Product product)
        {
            if (this.Money < product.Cost)
            {
                return $"{this.Name} can't afford {product.Name}";
            }

            this.Money -= product.Cost;
            this.bag.Add(product);
            return $"{this.Name} bought {product.Name}";
        }

        public bool CheckIfCanBuy(Product productItem)
        {
            if (this.Money>=productItem.Cost)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string BagContent()
        {
            if (this.bag.Count>0)
            {
                var result = " - ";
                foreach (var item in this.bag)
                {
                    result += item.Name + ", ";
                }
                return result.Remove(result.Length - 2);
            }
            else
            {
                return " - Nothing bought";
            }            
        }

        
        public override string ToString()
        {
            if (this.bag.Count == 0)
            {
                return $"{this.Name} - Nothing bought";
            }

            return $"{this.Name} - {String.Join(", ", this.bag.Select(p => p.Name))}";
        }

    }
}
