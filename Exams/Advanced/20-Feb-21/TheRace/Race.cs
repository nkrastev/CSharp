using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        //fields
        private List<Racer> data;

        public Race(string name, int capacity)
        {

            this.Name = name;
            this.Capacity = capacity;
            this.data = new List<Racer>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count { get => this.data.Count; }

        //methods
        public void Add(Racer racer)
        {
            if (data.Count < Capacity)
            {
                data.Add(racer);
            }
        }

        public bool Remove(string name)
        {
            Racer racer = data.Find(x => x.Name == name);
            if (racer != null)
            {
                data.Remove(racer);
                return true;
            }
            else
            {
                return false;
            }
        }
        //•	Method GetOldestRacer() – returns the oldest Racer.
        public Racer GetOldestRacer()
        {
            Racer racer = data.OrderByDescending(x => x.Age).First();
            return racer;
        }

        //•	Method GetRacer(string name) – returns the Racer with the given name.
        public Racer GetRacer(string name)
        {
            Racer racer = data.Find(x => x.Name == name && x.Name == name);
            if (racer != null)
            {
                return racer;
            }
            else
            {
                return null;
            }
        }
        //•	Method GetFastestRacer() – returns the Racer whose car has the highest speed.
        public Racer GetFastestRacer()
        {
            Racer racer = data.OrderByDescending(x => x.Car.Speed).FirstOrDefault();
            return racer;
        }

        //•	Report
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Racers participating at {this.Name}:");
            foreach (var item in data)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }

    }
}
