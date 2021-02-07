using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private List<Car> data;
        private string type;
        private int capacity;

        public Parking(string type, int capacity)
        {
            this.Type = type;
            this.Capacity = capacity;
            this.data = new List<Car>();
        }


        public string Type { get=>this.type; set=>this.type=value; }
        public int Capacity { get => this.capacity; set => this.capacity = value; }

        public int Count
        {
            get => data.Count;
        }

        public void Add(Car car)
        {
            if (this.capacity>data.Count)
            {
                this.data.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            var isRemoved = false;
            var indexToRemove = data.FindIndex(x => x.Manufacturer == manufacturer && x.Model == model);

            if (indexToRemove>=0)
            {
                data.RemoveAt(indexToRemove);
                isRemoved = true;
            }

            return isRemoved;
        }

        public Car GetLatestCar() //– returns the latest car(by year) or null if have no cars.
        {
            if (Count == 0)
            {
                return null;
            }
            else
            {
                Car latestCar = data.OrderByDescending(x => x.Year).FirstOrDefault();
                return latestCar;
            }
        }

        public Car GetCar(string manufacturer, string model)
        {
            if (Count>0)
            {
                Car getCar = data.FirstOrDefault(c => (c.Manufacturer == manufacturer && c.Model == model));
                return getCar;
            }
            else
            {
                return null;
            }
            
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The cars are parked in {this.Type}:");
            foreach (var item in data)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();

        }


    }
}
