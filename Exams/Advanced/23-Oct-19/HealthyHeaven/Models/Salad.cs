using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthyHeaven
{
    public class Salad
    {
        //fields
        private List<Vegetable> products;

        public Salad(string name)
        {            
            Name = name;
            this.products = new List<Vegetable>();
        }

        //prop
        public string Name { get; set; }

        //methods
        public int GetTotalCalories() => products.Sum(x => x.Calories);
        public int GetProductCount() => products.Count;

        public void Add(Vegetable product)
        {
            this.products.Add(product);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"* Salad {this.Name} is {this.GetTotalCalories()} calories and have {this.GetProductCount()} products:");
            foreach (var item in products)
            {
                sb.AppendLine(item.Name);
            }
            return sb.ToString().TrimEnd();
        }

    }
}
