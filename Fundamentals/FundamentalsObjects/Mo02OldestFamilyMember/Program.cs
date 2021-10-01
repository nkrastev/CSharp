using System;
using System.Collections.Generic;
using System.Linq;

namespace Mo02OldestFamilyMember
{
    class Program
    {
        static void Main()
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            Family theFamily = new Family(new List<Person>());

            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                Person newPerson = new Person(input[0], int.Parse(input[1]));

                theFamily.AddMember(newPerson);
            }

            Person theOldest = theFamily.GetOldestMember();

            Console.WriteLine(theOldest.Name + " " + theOldest.Age);

        }
    }

    class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }
    }

    class Family
    {

        public Family(List<Person> people)
        {
            ListOfPersons = new List<Person>();
        }

        public List<Person> ListOfPersons { get; set; }

        public void AddMember(Person member)
        {
            this.ListOfPersons.Add(member);
        }

        public Person GetOldestMember()
        {
            return this.ListOfPersons.OrderByDescending(p => p.Age).First();
        }
    }
}
