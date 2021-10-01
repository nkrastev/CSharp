using System;
using System.Collections.Generic;
using System.Linq;

namespace P_rates
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, int[]> cities = new Dictionary<string, int[]>();
            ReadCityPopulationGold(cities);

            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] input = command.Split("=>", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (input[0] == "Plunder")
                {
                    //Plunder=>{town}=>{people}=>{gold}"
                    string town = input[1];
                    int people = int.Parse(input[2]);
                    int gold = int.Parse(input[3]);
                    if (cities.ContainsKey(town))
                    {
                        cities[town][0] -= people;
                        cities[town][1] -= gold;
                        Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");
                        if (cities[town][0] <= 0 || cities[town][1] <= 0)
                        {
                            Console.WriteLine($"{town} has been wiped off the map!");
                            cities.Remove(town);
                        }
                    }
                }

                if (input[0] == "Prosper")
                {
                    //Prosper=>{town}=>{gold}"
                    string town = input[1];
                    int gold = int.Parse(input[2]);
                    if (gold < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                    }
                    else
                    {
                        cities[town][1] += gold;
                        Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {cities[town][1]} gold.");
                    }
                }
                command = Console.ReadLine();
            }

            if (cities.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");
                cities = cities.OrderByDescending(x => x.Value[1]).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
                foreach (var item in cities)
                {
                    Console.WriteLine($"{item.Key} -> Population: {item.Value[0]} citizens, Gold: {item.Value[1]} kg");
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }

        }

        private static Dictionary<string, int[]> ReadCityPopulationGold(Dictionary<string, int[]> cities)
        {
            string command = Console.ReadLine();
            while (command != "Sail")
            {
                string[] input = command
                .Split("||", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
                int[] populationAndGold = { int.Parse(input[1]), int.Parse(input[2]) };

                if (cities.ContainsKey(input[0]))
                {
                    int oldPopulation = cities[input[0]][0];
                    int oldGold = cities[input[0]][1];
                    int[] newPopulationAndGold = { int.Parse(input[1]) + oldPopulation, int.Parse(input[2]) + oldGold };
                    cities[input[0]] = newPopulationAndGold;
                }
                else
                {
                    cities.Add(input[0], populationAndGold);
                }
                command = Console.ReadLine();
            }
            return cities;
        }
    }
}
