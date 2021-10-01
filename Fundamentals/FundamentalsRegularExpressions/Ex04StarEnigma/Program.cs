using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Ex04StarEnigma
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string decryptedMessage = DecryptMessage(Console.ReadLine());

                string patternPlanet = @"@([a-zA-z]+)[^@\-!:>]*:([1-9][0-9]+)![^@\-!:>]*([AD])![^@\-!:>]*->([1-9][0-9]+)";
                Regex regexPlanet = new Regex(patternPlanet);
                MatchCollection matchesPlanets = regexPlanet.Matches(decryptedMessage);

                string planetName = "";
                string population = "";
                string attackType = "";
                string soldierCount = "";

                foreach (Match item in matchesPlanets)
                {
                    planetName = item.Groups[1].Value;
                    population = item.Groups[2].Value;
                    attackType = item.Groups[3].Value;
                    soldierCount = item.Groups[4].Value;
                }

                if (planetName!="" && population!="" && attackType!="" && soldierCount!="")
                {
                    //planet is valid put in the one of the lists
                    if (attackType=="A")
                    {
                        attackedPlanets.Add(planetName);
                    }
                    else
                    {
                        destroyedPlanets.Add(planetName);
                    }
                }
            }

            //output
            SortCountAndPrintPlanets(attackedPlanets, destroyedPlanets);

        }

        private static void SortCountAndPrintPlanets(List<string> attackedPlanets, List<string> destroyedPlanets)
        {
            attackedPlanets.Sort();
            destroyedPlanets.Sort();

            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");
            foreach (var item in attackedPlanets)
            {
                Console.WriteLine($"-> {item}");
            }
            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
            foreach (var item in destroyedPlanets)
            {
                Console.WriteLine($"-> {item}");
            }
        }

        private static string DecryptMessage(string message)
        {
            string decrypted = "";

            //count all the letters [s, t, a, r] – case insensitive             
            string patternAllLetters = @"[sStTaArR]";
            Regex regexLetters = new Regex(patternAllLetters);
            MatchCollection matchesLetters = regexLetters.Matches(message);
            int decryptionKey = matchesLetters.Count;

            for (int i = 0; i < message.Length; i++)
            {
                decrypted += (char)(message[i] - decryptionKey);
            }
            return decrypted;
        }
    }
}
