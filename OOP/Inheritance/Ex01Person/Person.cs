using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Person
    {
        //fields
        private string name;
        private int age;

        //ctor
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        //prop
        public string Name { get; set; }
        public int Age { get; set; }

        //methods
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {this.Name}, Age: {this.Age}");
            return sb.ToString().TrimEnd();            
        }

    }
}
