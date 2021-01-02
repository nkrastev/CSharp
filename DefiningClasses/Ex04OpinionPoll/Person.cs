namespace DefiningClasses
{
    public class Person
    {
        // fields
        private string name;
        private int age;

        // constructor
        public Person()
        {
            this.Name = "No name";
            this.Age = 0;
        }

        public Person(int age)
            : this()
        {
            this.Age = age;
        }

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
            set { this.age = value; }
        }
    }
}
