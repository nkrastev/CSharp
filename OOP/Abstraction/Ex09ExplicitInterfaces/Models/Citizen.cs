using Ex09ExplicitInterfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex09ExplicitInterfaces.Models
{
    public class Citizen : IPerson, IResident
    {
        private string name;
        private string country;
        private int age;

        public Citizen(string name, string country, int age)
        {
            this.Name = name;
            this.Country = country;
            this.Age = age;
        }

        public string Name 
        {
            get => this.name;
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or empty");
                }
                this.name = value;
            }
        }
        public int Age
        {
            get => this.age;
            set
            {
                if (value<=0)
                {
                    throw new ArgumentException("Age cannot be negative or Zero");
                }
                this.age = value;
            }
        }
        public string Country
        {
            get => this.country;
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Country cannot be null or empty");
                }
                this.country = value;
            }
        }


        string IResident.GetName() => "Mr/Ms/Mrs ";

        string IPerson.GetName() => $"{this.Name}";
       
    }
}
