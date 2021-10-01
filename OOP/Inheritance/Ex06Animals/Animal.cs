using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public abstract class Animal
    {
        //fields
        private string name;
        private int age;
        private string gender;
        private const string errorMessage = "Invalid input!";

        //ctor       
        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        //prop
        public string Name 
        {
            get { return this.name; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(errorMessage);
                }
                this.name = value;
            }
        }
        public int Age 
        {
            get
            {
                return this.age;                
            }
            private set
            {                
                if (value < 0)
                {
                    throw new ArgumentException(errorMessage);
                }
                this.age=value;                
            }
        }
        public string Gender
        {
            get
            {
                return this.gender;
            }
            private set
            {
                if (value!="Male" && value!="Female")
                {
                    throw new ArgumentException(errorMessage);
                }
                this.gender = value;
            } 
        }

        //methods
        public abstract string ProduceSound();
        
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name}");
            sb.AppendLine($"{this.Name} {this.Age} {this.Gender}");
            sb.AppendLine($"{this.ProduceSound()}");
            return sb.ToString().TrimEnd();
        }

    }
}
