using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Ex02Race
{
    class Program
    {
        static void Main()
        {
            List<string> participants = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
            Dictionary<string, int> resultsTable = new Dictionary<string, int>();

            string patternName = @"[A-Za-z]+";
            string patternDigits = @"[0-9]";

            string command = Console.ReadLine();

            while (command!= "end of race")
            {                
                Regex regexName = new Regex(patternName);
                Regex regexDigits = new Regex(patternDigits);

                MatchCollection matchesName = regexName.Matches(command);
                MatchCollection matchesDigits = regexDigits.Matches(command);

                string playerName = "";
                int playerResult = 0;

                //create name
                foreach (Match item in matchesName)
                {
                    playerName += item.Value;
                }

                //calculate score
                foreach (Match item in matchesDigits)
                {
                    playerResult += int.Parse(item.Value);
                }

                //check if player exist in the input list
                if (participants.Contains(playerName))
                {
                    //if exists check if there is result and add score to previous, else add it in Dict
                    if (resultsTable.ContainsKey(playerName))
                    {
                        resultsTable[playerName] += playerResult;
                    }
                    else
                    {
                        resultsTable.Add(playerName, playerResult);
                    }
                }
                command = Console.ReadLine();
            }

            //output
            var sortedResults = resultsTable.OrderByDescending(x => x.Value).Take(3).ToDictionary(x => x.Key, x => x.Value);

            //stupid solution for printing
            int count = 1;
            foreach (var item in sortedResults)
            {
                if (count==1)
                {
                    Console.WriteLine($"1st place: {item.Key}");
                }
                if (count==2)
                {
                    Console.WriteLine($"2nd place: {item.Key}");
                }
                if (count==3)
                {
                    Console.WriteLine($"3rd place: {item.Key}");
                }
                count++;                
            }

        }
    }
}
