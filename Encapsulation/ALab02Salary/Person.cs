using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Person
    {
        //fields       

        public Person(string firstname, string lastname, int age, decimal salary)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Age = age;
            this.Salary = salary;
        }

        //ctor

        //prop
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Age { get; private set; }
        public decimal Salary { get; private set; }


        //method
        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} receives {this.Salary:f2} leva.";

        }

        public void IncreaseSalary(decimal percentage)
        {
            if (this.Age < 30)
            {
                this.Salary += this.Salary * percentage / 100M / 2M;
            }
            else
            {
                this.Salary += this.Salary * percentage / 100M;
            }
        }
    }
}
