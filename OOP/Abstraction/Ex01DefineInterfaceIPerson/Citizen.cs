namespace PersonInfo
{
    public class Citizen : IPerson
    {
        private string name;
        private int age;

        public Citizen(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public string Name { get => this.name; set => this.name = value; }
        public int Age { get => this.age; set => this.age=value; }
    }
}
