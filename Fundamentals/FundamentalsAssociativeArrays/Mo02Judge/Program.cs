using System;
using System.Collections.Generic;
using System.Linq;

namespace Mo02Judge
{
    class Program
    {
        static void Main()
        {
            // contest > username > submission points
            Dictionary<string, Dictionary<string, int>> entries = new Dictionary<string, Dictionary<string, int>>();

            AddDataToDictionary(entries);

            //output
            PrintingContestResults(entries);

            PrintingIndividualResults(entries);
            
        }

        private static void PrintingIndividualResults(Dictionary<string, Dictionary<string, int>> entries)
        {
            // new dict Individual
            Dictionary<string, int> dictIndividual = new Dictionary<string, int>();

            foreach (var item in entries)
            {
                foreach (var subItem in item.Value)
                {
                    if (dictIndividual.ContainsKey(subItem.Key))
                    {
                        //user added, change total points
                        dictIndividual[subItem.Key] += subItem.Value;
                    }
                    else
                    {
                        //no such user, add it with points
                        dictIndividual.Add(subItem.Key, subItem.Value);
                    }
                }
            }
            //reorder individual
            dictIndividual = dictIndividual.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            //print
            Console.WriteLine("Individual standings:");
            int counter = 1;
            foreach (var item in dictIndividual)
            {
                Console.WriteLine($"{counter}. {item.Key} -> {item.Value}");
                counter++;
            }

        }

        private static void PrintingContestResults(Dictionary<string, Dictionary<string, int>> entries)
        {
            foreach (var item in entries)
            {
                //contest name= item.key
                int currentParticipants = CountParticipantsInContest(entries, item.Key);
                Console.WriteLine($"{item.Key}: {currentParticipants} participants");

                // new dict for participants in the current contest
                Dictionary<string, int> dictParticipants = new Dictionary<string, int>();
                foreach (var participant in item.Value)
                {
                    dictParticipants.Add(participant.Key, participant.Value);
                }

                // sort participants in current contest
                dictParticipants = dictParticipants.OrderByDescending(x => x.Value).ThenBy(x=>x.Key).ToDictionary(x => x.Key, x => x.Value);

                //print partipants already ordered
                int participantCounter = 1;
                foreach (var participant in dictParticipants)
                {
                    Console.WriteLine($"{participantCounter}. {participant.Key} <::> {participant.Value}");
                    participantCounter++;
                }
            }
        }
        private static int CountParticipantsInContest(Dictionary<string, Dictionary<string, int>> entries, string contest)
        {
            int participantsCount = entries[contest].Count;
            return participantsCount;
        }

        private static Dictionary<string, Dictionary<string, int>> AddDataToDictionary(Dictionary<string, Dictionary<string, int>> entries)
        {
            string command = Console.ReadLine();

            while (command!= "no more time")
            {
                string[] input = command.Split(" -> ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string username = input[0];
                string contest = input[1];
                int points = int.Parse(input[2]);

                if (entries.ContainsKey(contest))
                {
                    //contest exist, check for user
                    if (entries[contest].ContainsKey(username))
                    {
                        //username exist, check for points and replace
                        if (entries[contest][username] < points)
                        {
                            entries[contest][username] = points;
                        }

                    }
                    else
                    {
                        //user doesnt exist, add submission                        
                        entries[contest].Add(username, points);
                    }

                }
                else
                {
                    //contest doesnt exist > add new contest with new user and points
                    Dictionary<string, int> newSubmission = new Dictionary<string, int>();
                    newSubmission.Add(username, points);
                    entries.Add(contest, newSubmission);
                }

                command = Console.ReadLine();
            }

            return entries;
        }
    }

}
