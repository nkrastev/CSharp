using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04BorderControl
{
    public class Person : IIdentity
    {
        private string name;
        private int age;
        private string id;
        public Person(string name, int age, string id)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
        }

        public string Name { get; }
        public int Age { get; }
        public string Id { get => this.id; set => this.id = value; }

        
    }
}
