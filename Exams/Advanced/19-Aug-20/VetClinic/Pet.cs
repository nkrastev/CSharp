using System;
using System.Collections.Generic;
using System.Text;

namespace VetClinic
{
    public class Pet
    {

        //prop
        public string Name { get; set; }
        public int Age { get; set; }
        public string Owner { get; set; }

        //ctor
        public Pet(string name, int age, string owner)
        {
            this.Name = name;
            this.Age = age;
            this.Owner = owner;
        }

        //methods
        public override string ToString()
        {
            return $"Name: {Name} Age: {Age} Owner: {Owner}";
        }
    }
}
