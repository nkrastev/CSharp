using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthyHeaven
{
    public class Restaurant
    {
        //fields
        private List<Salad> data;

        //ctor
        public Restaurant(string name)
        {
            this.Name = name;
            this.data = new List<Salad>();
        }

        //prop    
        public string Name { get; set; }

        //methods
        public void Add(Salad salad)
        {
            data.Add(salad);
        }        
        public bool Buy(string name)
        {
            if (data.Any(x=>x.Name==name))
            {
                data.RemoveAll(x => x.Name == name);
                return true;
            }
            else
            {
                return false;
            }
        }        
        public Salad GetHealthiestSalad() => data.OrderBy(x => x.GetTotalCalories()).FirstOrDefault();

        public string GenerateMenu()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Name} have {data.Count} salads:");
            foreach (var item in data)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }        
            


    }
}
