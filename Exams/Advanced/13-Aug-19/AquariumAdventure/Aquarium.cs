using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquariumAdventure
{
    public class Aquarium
    {
        //fields
        private List<Fish> fishInPool;

        //ctor
        public Aquarium(string name, int capacity, int size)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Size = size;
            this.fishInPool = new List<Fish>();
        }

        //prop
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Size { get; set; }

        //methods
        //Method Add(Fish fish) - adds the entity if there isn't a fish with the same name and if there is enough space for it.
        public void Add(Fish fish)
        {
            if (fishInPool.Count<Capacity && !fishInPool.Any(x => x.Name == fish.Name))
            {
                fishInPool.Add(fish);
            }
        }

        //Method Remove(string name) - removes a fish from the pool with the given name, 
        //if such exists and returns bool if the deletion is successful.
        public bool Remove(string name)
        {
            Fish fish = fishInPool.Find(x => x.Name == name);
            if (fish != null)
            {
                fishInPool.Remove(fish);
                return true;
            }
            else
            {
                return false;
            }
        }

        //•	Method FindFish(string name) - returns a fish with the given name. If it doesn't exist, return null.
        public Fish FindFish(string name) => fishInPool.Where(x => x.Name == name).FirstOrDefault();

        //•	Method Report() - returns information about the aquarium and the fish inside it in the following format:

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Aquarium: {this.Name} ^ Size: {this.Size}");
            foreach (var item in fishInPool)
            {
                sb.AppendLine($"{item.ToString()}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
