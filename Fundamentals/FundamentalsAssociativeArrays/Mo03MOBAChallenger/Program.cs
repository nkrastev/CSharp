using System;
using System.Collections.Generic;
using System.Linq;

namespace Mo03MOBAChallenger
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, Dictionary<string, int>> entries = new Dictionary<string, Dictionary<string, int>>();

            string input = Console.ReadLine();

            while (input != "Season end")
            {
                if (input.Contains('-'))
                {     
                    // data input
                    ReadData(entries, input);
                }
                else
                {
                    // fight "{player} vs {player}"
                    DuelPlayers(entries, input);
                }
                input = Console.ReadLine();
            }            

            //output
            Dictionary<string, int> dictPlayerSkill = new Dictionary<string, int>();
            foreach (var item in entries)
            {
                //player position skill                
                dictPlayerSkill.Add(item.Key, GetTotalSkill(entries, item.Key));
            }

            dictPlayerSkill = dictPlayerSkill
                .OrderByDescending(x => x.Value)
                .ThenBy(x=>x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var item in dictPlayerSkill)
            {
                Console.WriteLine($"{item.Key}: {item.Value} skill");
                //get skills for each player (item.key)
                GetDetailDataPerPlayer(entries, item.Key);
            }
        }

        private static Dictionary<string, Dictionary<string, int>> DuelPlayers
            (
            Dictionary<string, Dictionary<string, int>> entries,
            string input
            )
        {
            //fight "{player} vs {player}"
            string[] players = input
                .Split(" vs ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string firstPlayer = players[0];
            string secondPlayer = players[1];

            bool haveCommonPositions = false;

            if (entries.ContainsKey(firstPlayer) && entries.ContainsKey(secondPlayer))
            {
                foreach (var firstPlayerItem in entries[firstPlayer])
                {
                    foreach (var secondPlayerItem in entries[secondPlayer])
                    {
                        if (firstPlayerItem.Key==secondPlayerItem.Key)
                        {
                            haveCommonPositions = true;
                            break;
                        }
                    }
                    if (haveCommonPositions)
                    {
                        break;
                    }
                }                
            }
            // if have common position check skills
            if (haveCommonPositions)
            {
                int player1skill = GetTotalSkill(entries, firstPlayer);
                int player2skill = GetTotalSkill(entries, secondPlayer);

                if (player1skill>player2skill)
                {
                    //remove player 2
                    entries.Remove(secondPlayer);
                }
                else
                {
                    //remove player 1
                    entries.Remove(firstPlayer);
                }

            }

            return entries;
        }

        private static void GetDetailDataPerPlayer(Dictionary<string, Dictionary<string, int>> entries, string player)
        {
            Dictionary<string, int> dictPositionSkill = new Dictionary<string, int>();
            
            foreach (var item in entries)
            {
                if (item.Key==player)
                {
                    foreach (var subItem in item.Value)
                    {
                        dictPositionSkill.Add(subItem.Key, subItem.Value);
                    }
                }
            }

            dictPositionSkill = dictPositionSkill.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (var item in dictPositionSkill)
            {
                Console.WriteLine($"- {item.Key} <::> {item.Value}");
            }
        }

        private static int GetTotalSkill(Dictionary<string, Dictionary<string, int>> entries, string player)
        {
            int totalSkill = 0;            
            foreach (var item in entries)
            {
                if (item.Key==player)
                {
                    foreach (var subItem in item.Value)
                    {
                        totalSkill += subItem.Value;
                    }
                }
            }

            return totalSkill;
        }

        private static Dictionary<string, Dictionary<string, int>> ReadData
            (
            Dictionary<string, Dictionary<string, int>> entries, 
            string input
            )
        {
            //input "{player} -> {position} -> {skill}"
            string[] command = input
                .Split(" -> ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string player = command[0];
            string position = command[1];
            int skill = int.Parse(command[2]);

            if (entries.ContainsKey(player))
            {
                //player exist, check skills
                if (entries[player].ContainsKey(position))
                {
                    //it has current skill, check if it is lower
                    if (entries[player][position]<skill)
                    {
                        entries[player][position] = skill;
                    }
                }
                else
                {
                    //player doesnt have such skill, add it
                    entries[player].Add(position, skill);
                }
            }
            else
            {
                //add player, skills, position
                Dictionary<string, int> newPlayer = new Dictionary<string, int>();
                newPlayer.Add(position, skill);
                entries.Add(player, newPlayer);
            }

            return entries;
        }
    }
}
