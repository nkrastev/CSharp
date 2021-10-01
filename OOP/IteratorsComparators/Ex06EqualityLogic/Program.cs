using System;
using System.Collections.Generic;

namespace EqualityLogic
{
    class Program
    {
        static void Main(string[] args)
        {            
            SortedSet<Person> sortedSetPeople = new SortedSet<Person>();
            HashSet<Person> hashSetPeople = new HashSet<Person>();

            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                sortedSetPeople.Add(new Person(input[0], int.Parse(input[1])));
                hashSetPeople.Add(new Person(input[0], int.Parse(input[1])));
            }

            Console.WriteLine(sortedSetPeople.Count);
            Console.WriteLine(hashSetPeople.Count);

        }

    }
}
