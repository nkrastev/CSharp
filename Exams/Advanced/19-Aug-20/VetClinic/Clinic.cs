using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        //field
        private List<Pet> data;

        //ctor
        public Clinic(int capacity)
        {
            this.Capacity = capacity;
            this.data = new List<Pet>();
        }

        //prop
        public int Capacity { get; set; }
        public int Count
        {
            get
            {
                return data.Count;
            }
        }

        //methods
        public void Add(Pet pet)
        {
            if (data.Count<Capacity)
            {
                data.Add(pet);
            }
        }
        public bool Remove(string name)
        {            
            Pet pet = data.Find(x => x.Name == name);
            if (pet != null)
            {
                data.Remove(pet);
                return true;
            }
            else
            {
                return false;
            }
        }
        public Pet GetPet(string name, string owner)
        {
            //•	Method GetPet(string name, string owner) – returns the pet with the given name and owner or null if no such pet exists.
            Pet pet = data.Find(x => x.Name == name && x.Owner==owner );
            if (pet!=null)
            {
                return pet;
            }
            else
            {
                return null;
            }
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("The clinic has the following patients:");
            foreach (var item in data)
            {
                sb.AppendLine($"Pet {item.Name} with owner: {item.Owner}");
            }

            return sb.ToString().TrimEnd();
        }

        public Pet GetOldestPet()
        {
            //•	Method GetOldestPet() – returns the oldest Pet.
            Pet pet = data.OrderByDescending(x => x.Age).First();
            return pet;
        }

    }
}
