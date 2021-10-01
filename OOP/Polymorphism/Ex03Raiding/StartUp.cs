using Ex03Raiding.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex03Raiding
{
    public class StartUp
    {
        static void Main()
        {
            var numberOfHeroes = int.Parse(Console.ReadLine());
            List<BaseHero> heroes = new List<BaseHero>();

            while (heroes.Count!=numberOfHeroes)
            {
                var heroName = Console.ReadLine();
                var heroType = Console.ReadLine();

                if (heroType == "Druid")
                {
                    BaseHero hero = new Druid(heroName, heroType);
                    heroes.Add(hero);
                }
                else if (heroType == "Paladin")
                {
                    BaseHero hero = new Paladin(heroName, heroType);
                    heroes.Add(hero);
                }
                else if (heroType == "Rogue")
                {
                    BaseHero hero = new Rogue(heroName, heroType);
                    heroes.Add(hero);
                }
                else if (heroType == "Warrior")
                {
                    BaseHero hero = new Warrior(heroName, heroType);
                    heroes.Add(hero);
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                }
            }
                                           

            int bossPower = int.Parse(Console.ReadLine());
            int totalHeroesPower = heroes.Sum(item => item.Power);

            foreach (var item in heroes)
            {
                Console.WriteLine(item.CastAbility());
            }

            if (bossPower<=totalHeroesPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
