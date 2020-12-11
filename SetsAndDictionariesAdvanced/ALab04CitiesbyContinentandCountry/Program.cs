using System;
using System.Collections.Generic;
using System.Linq;

namespace ALab04CitiesbyContinentandCountry
{
    class Program
    {
        static void Main()
        {
            var dict = new Dictionary<string, Dictionary<string, List<string>>>();
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                var items = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                var continent = items[0];
                var country = items[1];
                var city = items[2];

                if (dict.ContainsKey(continent))
                {
                    if (dict[continent].ContainsKey(country))
                    {
                        dict[continent][country].Add(city);
                    }
                    else
                    {
                        dict[continent].Add(country, new List<string> { city });
                    }
                    
                }
                else
                {
                    dict.Add(continent, new Dictionary<string, List<string>>());
                    dict[continent].Add(country, new List<string> { city });
                }
            }

            foreach (var cont in dict)
            {
                Console.WriteLine(cont.Key+":");
                foreach (var count in cont.Value)
                {
                    Console.WriteLine($"{count.Key} -> {String.Join(", ",count.Value)}");
                }
            }
        }
    }
}
