using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex07OrderByAge
{
    class Program
    {
        static void Main()
        {
            List<Person> listOfPeople = new List<Person>();

            ReadPeopleFromCommandLine(listOfPeople);

            PrintPeopleOrderedByAge(listOfPeople);

        }

        static void PrintPeopleOrderedByAge(List<Person> listOfPeople)
        {
            listOfPeople = listOfPeople.OrderBy(x => x.Age).ToList();

            foreach (Person item in listOfPeople)
            {
                Console.WriteLine($"{item.Name} with ID: {item.Id} is {item.Age} years old.");
            }
        }

        static List<Person> ReadPeopleFromCommandLine(List<Person> peoples)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            while (input[0] != "End")
            {
                string personName = input[0];
                string personID = input[1];
                int personAge = int.Parse(input[2]);

                //new instance of person
                Person itemPerson = new Person(personName, personID, personAge);
                
                // add it to the list of persons
                peoples.Add(itemPerson);
                
                input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            }
            //return list of people to the main method
            return peoples;
        }
    }

    class Person
    {
        //constructor
        public Person (string name, string id, int age)
        {
            Name = name;
            Id = id;
            Age = age;
        }
        //properties
        public string Name { get; set; }
        public string Id { get; set; }
        public int Age { get; set; }
    }
}
