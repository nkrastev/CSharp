using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Ex05NetherRealms
{
    class Program
    {
        static void Main()
        {
            List<string> demonList = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions
                .RemoveEmptyEntries).ToList();

            demonList.Sort();

            foreach (string item in demonList)
            {
                int health = GetHealth(item);
                double damage = GetDamage(item);

                Console.WriteLine($"{item} - {health} health, {damage:f2} damage");

            }
        }

        private static double GetDamage(string item)
        {
            double damage = 0;
            string patternIntDouble = @"(\-|\+)*([0-9]+\.)*[0-9]+";
            Regex regexSumNumbers = new Regex(patternIntDouble);
            MatchCollection matchesNumbers = regexSumNumbers.Matches(item);
            
            foreach (Match itemNum in matchesNumbers)
            {
                //'4', '+4', '-4', '3.5', '+3.5', '-3.5' 
                if (itemNum.Value.Contains('.'))
                {
                    //the number is double
                    if (itemNum.Value.StartsWith('-'))
                    {
                        //remove the minus from the string and parse it
                        damage -= double.Parse(itemNum.Value.Remove(0, 1));
                    }
                    else
                    {
                        //the number is positive and double
                        damage += double.Parse(itemNum.Value);
                    }
                }
                else
                {
                    //the number is int
                    if (itemNum.Value.StartsWith('-'))
                    {
                        //remove the minus from the string and parse it
                        damage -= double.Parse(itemNum.Value.Remove(0, 1));
                    }
                    else
                    {
                        //the number is positive and double
                        damage += int.Parse(itemNum.Value);
                    }
                }             
            }
            //multiplication and division 
            for (int i = 0; i < item.Length; i++)
            {
                if (item[i]=='*')
                {
                    damage *= 2;
                }
                if (item[i]=='/')
                {
                    damage /= 2;
                }
            }

            return damage;
        }

        private static int GetHealth(string item)
        {
            int health = 0;
            string demonName = "";
            string pattern = @"[^0-9\+\-\*\/\.]+";
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(item);

            foreach (Match itemMatch in matches)
            {
                demonName += itemMatch;
            }
            for (int i = 0; i < demonName.Length; i++)
            {
                health += demonName[i];
            }
            return health;
        }
    }
}
