using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Person
    {
        //fields       

        public Person(string firstname, string lastname, int age)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Age = age;
        }

        //ctor

        //prop
        public string FirstName { get; private set; }
        public string LastName { get;private set; }
        public int Age { get; private set; }
        

        //method
        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} is {this.Age} years old.";
        }
    }
}
