using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rabbits
{
    public class Cage
    {
        //fields
        private List<Rabbit> data;

        public Cage(string name, int capacity)
        {            
            this.Name = name;
            this.Capacity = capacity;
            this.data = new List<Rabbit>();
        }

        //prop
        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count { get => this.data.Count; }

        //methods
        public void Add(Rabbit rabbit)
        {
            if (data.Count<this.Capacity)
            {
                data.Add(rabbit);
            }
        }
        
        public bool RemoveRabbit(string name)
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

        public void RemoveSpecies(string species)=> data.RemoveAll(x => x.Species == species);

        //SellRabbit(string name) - sell (set its Available property to false without 
        //removing it from the collection) the first rabbit with the given name, also return the rabbit

        public Rabbit SellRabbit(string name)
        {
            Rabbit searched = data.Where(x => x.Name == name).FirstOrDefault();
            searched.Available = false;
            return searched;
        }

        //•	Method SellRabbitsBySpecies(string species) - sells (set their Available property to 
        //false without removing them from the collection) and returns all rabbits from that species as an array

        public Rabbit[] SellRabbitsBySpecies(string species)
        {
            Rabbit[] result=data.Where(x => x.Species == species).ToArray();
            for (int i = 0; i < result.Length; i++)
            {
                result[i].Available = false;
            }
            return result;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Rabbits available at {this.Name}:");
            foreach (var item in data)
            {
                if (item.Available == true)
                {
                    sb.AppendLine($"{item.ToString()}");
                }
            }
            return sb.ToString().TrimEnd();
        }
    }
}
