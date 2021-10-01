using System;
using System.Collections.Generic;
using System.Linq;

namespace Heroes_of_Code_and_Logic7
{
    class Program
    {
        static void Main()
        {
            int numberOfHeroes = int.Parse(Console.ReadLine());
            Dictionary<string, int[]> heroes = ReadHeroes(numberOfHeroes);

            string command = Console.ReadLine();
            while (command.ToLower() != "end")
            {
                string[] input = command
                    .Split(" - ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (input[0] == "CastSpell")
                {
                    string hName = input[1];
                    int hManaNeeded = int.Parse(input[2]);
                    string spellName = input[3];
                    CastSpell(heroes, hName, hManaNeeded, spellName);
                }
                if (input[0] == "TakeDamage")
                {
                    string hName = input[1];
                    int hDamage = int.Parse(input[2]);
                    string attacker = input[3];
                    TakeDamage(heroes, hName, hDamage, attacker);
                }
                if (input[0] == "Recharge")
                {
                    string hName = input[1];
                    int amount = int.Parse(input[2]);
                    Recharge(heroes, hName, amount);
                }
                if (input[0] == "Heal")
                {
                    string hName = input[1];
                    int amount = int.Parse(input[2]);
                    Heal(heroes, hName, amount);
                }
                command = Console.ReadLine();
            }

            //output
            PrintOutput(heroes);
        }

        private static void PrintOutput(Dictionary<string, int[]> heroes)
        {
            heroes = heroes.OrderByDescending(x => x.Value[0]).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            foreach (var item in heroes)
            {
                Console.WriteLine(item.Key);
                Console.WriteLine($"  HP: {item.Value[0]}");
                Console.WriteLine($"  MP: {item.Value[1]}");
            }


        }

        private static Dictionary<string, int[]> Heal(Dictionary<string, int[]> heroes, string hName, int amount)
        {
            if (heroes[hName][0] + amount > 100)
            {
                Console.WriteLine($"{hName} healed for {100 - heroes[hName][0]} HP!");
                heroes[hName][0] = 100;
            }
            else
            {
                Console.WriteLine($"{hName} healed for {amount} HP!");
                heroes[hName][0] += amount;
            }
            return heroes;
        }

        private static Dictionary<string, int[]> Recharge(Dictionary<string, int[]> heroes, string hName, int amount)
        {
            //•	The hero increases his MP
            if (heroes[hName][1] + amount > 200)
            {
                Console.WriteLine($"{hName} recharged for {200 - heroes[hName][1]} MP!");
                heroes[hName][1] = 200;
            }
            else
            {
                Console.WriteLine($"{hName} recharged for {amount} MP!");
                heroes[hName][1] += amount;
            }
            return heroes;
        }

        private static Dictionary<string, int[]> TakeDamage(Dictionary<string, int[]> heroes, string hName, int hDamage, string attacker)
        {
            //TakeDamage – {hero name} – {damage} – {attacker}
            if (heroes[hName][0] > hDamage)
            {
                heroes[hName][0] -= hDamage;
                Console.WriteLine($"{hName} was hit for {hDamage} HP by {attacker} and now has {heroes[hName][0]} HP left!");
            }
            else
            {
                Console.WriteLine($"{hName} has been killed by {attacker}!");
                heroes.Remove(hName);
            }
            return heroes;
        }

        private static Dictionary<string, int[]> CastSpell(Dictionary<string, int[]> heroes, string hName, int hManaNeeded, string spellName)
        {
            //CastSpell – {hero name} – {MP needed} – {spell name} 
            if (heroes[hName][1] >= hManaNeeded)
            {
                heroes[hName][1] -= hManaNeeded;
                Console.WriteLine($"{hName} has successfully cast {spellName} and now has {heroes[hName][1]} MP!");
            }
            else
            {
                Console.WriteLine($"{hName} does not have enough MP to cast {spellName}!");
            }
            return heroes;
        }

        private static Dictionary<string, int[]> ReadHeroes(int numberOfHeroes)
        {
            Dictionary<string, int[]> dict = new Dictionary<string, int[]>();

            for (int i = 0; i < numberOfHeroes; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string heroName = input[0];
                int heroHealth = int.Parse(input[1]);
                int heroMana = int.Parse(input[2]);
                dict.Add(heroName, new int[] { heroHealth, heroMana });
            }
            return dict;
        }
    }
}
