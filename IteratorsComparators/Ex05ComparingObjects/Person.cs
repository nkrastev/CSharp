using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ComparingObjects
{
    public class Person : IComparable<Person>
    {
        //fields
        private string name;
        private int age;
        private string town;

        //ctor
        public Person(string name, int age, string town)
        {
            this.Name = name;
            this.Age = age;
            this.Town = town;
        }

        //prop
        public string Name { get; set; }
        public int Age { get; set; }
        public string Town { get; set; }

        

        public int CompareTo(Person other)
        {            
            int resultName = this.Name.CompareTo(other.Name);
            int resultAge = this.Age.CompareTo(other.Age);
            int resultTown = this.Town.CompareTo(other.Town);

            if (resultName==0 && resultAge==0 && resultTown==0)
            {
                return 0;
            }
            else
            {
                return 1;
            }

        }
    }
}
