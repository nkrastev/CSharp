using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex10PredicateParty
{
    class Program
    {
        static void Main()
        {
            var guests = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            var command = Console.ReadLine();
            while (command!= "Party!")
            {
                var cmdArgs = command.Split().ToArray();
                if (cmdArgs[0]== "Remove")
                {
                    guests=RemoveGuest(guests, cmdArgs[1], cmdArgs[2]);
                }
                if (cmdArgs[0]== "Double")
                {
                    guests=DoubleGuests(guests, cmdArgs[1], cmdArgs[2]);
                }
                command = Console.ReadLine();
            }
            if (guests.Count == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            else
            {
                Console.WriteLine($"{String.Join(", ",guests)} are going to the party!");
            }
        }

        private static List<string> DoubleGuests(List<string> guests, string v1, string v2)
        {
            
            if (v1 == "StartsWith")
            {
                for (int i = 0; i < guests.Count; i++)
                {
                    if (guests[i].StartsWith(v2))
                    {
                        guests.Insert(i, guests[i]);
                    }
                    i++;
                }
            }
            else if (v1 == "EndsWith")
            {
                for (int i = 0; i < guests.Count; i++)
                {
                    if (guests[i].EndsWith(v2))
                    {
                        guests.Insert(i, guests[i]);
                    }
                    i++;
                }
            }
            else
            {
                var lenght = int.Parse(v2);
                for (int i = 0; i < guests.Count; i++)
                {
                    if (guests[i].Length==lenght)
                    {
                        guests.Insert(i, guests[i]);
                    }
                    i++;
                }
            }
            return guests;
        }

        private static List<string> RemoveGuest(List<string> guests, string v1, string v2)
        {
            var result = new List<string>();
            if (v1== "StartsWith")
            {
                result = guests.Where(x => !x.StartsWith(v2)).ToList();
            }
            else if (v1== "EndsWith")
            {
                result = guests.Where(x => !x.EndsWith(v2)).ToList();
            }
            else
            {
                var lenght = int.Parse(v2);
                result = guests.Where(x => x.Length != lenght).ToList();
            }
            return result;
        }
    }
}
