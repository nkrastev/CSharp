using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private int capacity;
        private List<Item> items;

        public Bag(int capacity)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
        }

        public int Capacity 
        {
            get => this.capacity; 
            set => this.capacity=value; 
        }

        public int Load
        {
            get
            {
                int sum = 0;
                foreach (var item in items)
                {
                    sum += item.Weight;
                }
                return sum;
            }
        }

        public IReadOnlyCollection<Item> Items => this.Items;

        public void AddItem(Item item)
        {
            if (this.Load+item.Weight>this.capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }
            items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (items.Count==0)
            {
                throw new InvalidOperationException("Bag is empty!");
            }
            if (!items.Any(x=>x.GetType().Name==name))
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }
            Item result = items.Where(x => x.GetType().Name == name).FirstOrDefault();
            items.Remove(result);
            return result;
        }
    }
}
