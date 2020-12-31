using System;

namespace DefiningClasses
{
    class Person
    {
        // fields
        private string name;
        private int age;

        // constructor
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }        

        //properties
        public string Name 
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public int Age 
        {
            get { return this.age; }
            set 
            {
                if (value<=0)
                {
                    throw new ArgumentException("The Age cannot be less than 0.");                   
                }
                this.age = value; 
            }
        }        
    }
}
