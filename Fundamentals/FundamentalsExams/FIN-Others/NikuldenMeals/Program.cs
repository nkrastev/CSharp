using System;
using System.Collections.Generic;
using System.Linq;

namespace NikuldenMeals
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, List<string>> guests = new Dictionary<string, List<string>>();
            var command = Console.ReadLine();
            var unlikedCount = 0;
            while (command!="Stop")
            {
                var cmdArgs = command.Split("-", StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (cmdArgs[0]== "Like")
                {
                    var guest = cmdArgs[1];
                    var meal = cmdArgs[2];
                    LikeGuest(guests, guest, meal);
                }
                if (cmdArgs[0]== "Unlike")
                {
                    var guest = cmdArgs[1];
                    var meal = cmdArgs[2];
                    if (!guests.ContainsKey(guest))
                    {
                        Console.WriteLine($"{guest} is not at the party.");
                    }
                    else
                    {
                        //guest exists check for meal
                        if (guests[guest].Contains(meal))
                        {
                            //guest has meal, remove it
                            guests[guest].Remove(meal);
                            unlikedCount++;
                            Console.WriteLine($"{guest} doesn't like the {meal}.");
                        }
                        else
                        {
                            //guest exist but the meal is missing
                            Console.WriteLine($"{guest} doesn't have the {meal} in his/her collection.");
                        }
                    }
                }
                command = Console.ReadLine();
            }
            //order dictionary
            guests = guests.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            foreach (var item in guests)
            {
                Console.WriteLine($"{item.Key}: {String.Join(", ",item.Value)}");
            }
            Console.WriteLine($"Unliked meals: {unlikedCount}");

        }


        private static Dictionary<string, List<string>> LikeGuest(Dictionary<string, List<string>> guests, string guest, string meal)
        {
            if (guests.ContainsKey(guest))
            {
                guests[guest].Add(meal);
            }
            else
            {
                List<string> newMeals = new List<string>();
                newMeals.Add(meal);
                guests.Add(guest, newMeals);
            }
            return guests;
        }
    }
}
