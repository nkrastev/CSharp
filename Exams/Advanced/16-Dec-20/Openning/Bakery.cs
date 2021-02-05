using System;
using System.Collections.Generic;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        private List<Employee> data;

        public Bakery(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.data = new List<Employee>();

        }

        public int Count { get => data.Count; }

        public string Name { get; set; }
        public int Capacity { get; set; }

        public void Add(Employee employee)
        {
            if (data.Count<this.Capacity)
            {
                data.Add(employee);
            }
        }
        public bool Remove(string nameToRemove)
        {
            bool isRemoved = false;
            int index = data.FindIndex(x => x.Name == nameToRemove);
            if (index>=0)
            {
                data.RemoveAt(index);
                isRemoved = true;
            }
            return isRemoved;
        }

        public Employee GetOldestEmployee()
        {
            Employee theOldest = new Employee("",-1,"");
            foreach (var item in data)
            {
                if (item.Age>theOldest.Age)
                {
                    theOldest = item;
                }
            }

            return theOldest;
        }

        public Employee GetEmployee(string name)
        {
            Employee byName = new Employee();
            foreach (var item in data)
            {
                if (item.Name==name)
                {
                    byName = item;
                }
            }

            return byName;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Employees working at Bakery {this.Name}:");
            foreach (var item in data)
            {
                sb.AppendLine($"{item.Name}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
