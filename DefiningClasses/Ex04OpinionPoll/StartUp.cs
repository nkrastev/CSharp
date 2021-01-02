using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            Family family = new Family();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                var itemName = input[0];
                var itemAge = int.Parse(input[1]);

                Person person = new Person(itemName, itemAge);
                family.AddMember(person);
            }

            List<Person> olderThan30 = family.GetOlderThan30();

            foreach (Person item in olderThan30.OrderBy(x=>x.Name))
            {
                Console.WriteLine($"{item.Name} - {item.Age}");
            }
        }
    }
}
