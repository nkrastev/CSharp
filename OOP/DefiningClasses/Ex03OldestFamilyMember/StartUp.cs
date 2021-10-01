using System;
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
                var commands = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).ToArray();
                var itemName = commands[0];
                var itemAge = int.Parse(commands[1]);

                Person person = new Person(itemName, itemAge);
                family.AddMember(person);
            }           

            Console.WriteLine($"{family.GetOldestMember().Name} {family.GetOldestMember().Age}");
        }
    }
}
