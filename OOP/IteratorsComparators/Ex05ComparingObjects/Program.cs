using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = ReadPeople();

            var nPerson = int.Parse(Console.ReadLine());          
            Person searchedPerson = people[nPerson - 1];

            var totalPeople = people.Count;
            var equalPeople = 0;

            for (int i = 0; i < people.Count; i++)
            {                               
                if (searchedPerson.CompareTo(people[i])==0)
                {                    
                    equalPeople++;
                }
            }
            if (equalPeople>1)
            {
                Console.WriteLine($"{equalPeople} {totalPeople-equalPeople} {totalPeople}");
            }
            else
            {
                Console.WriteLine("No matches");
            }                        
        }

        private static List<Person> ReadPeople()
        {
            var list = new List<Person>();
            var command = Console.ReadLine();
            while (command != "END")
            {
                var cmdArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                list.Add(new Person(cmdArgs[0], int.Parse(cmdArgs[1]), cmdArgs[2]));
                command = Console.ReadLine();
            }
            return list;
        }
    }
}
