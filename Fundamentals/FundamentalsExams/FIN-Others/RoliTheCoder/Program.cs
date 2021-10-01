using System;
using System.Collections.Generic;
using System.Linq;

namespace RoliTheCoder
{
    class Program
    {
        static void Main()
        {
            List<Event> events = new List<Event>();
            var command = Console.ReadLine();
            while (command!= "Time for Code")
            {
                if (command.Contains('#'))
                {
                    //input is valid, create new instance from data
                    var cmdArgs = command.Split(new char[] {'#','@',' '}, StringSplitOptions.RemoveEmptyEntries).ToArray();
                    var evId = int.Parse(cmdArgs[0]);
                    var evName = cmdArgs[1];
                    List<string> evParticipants = new List<string>();
                    for (int i = 2; i < cmdArgs.Length; i++)
                    {
                        evParticipants.Add(cmdArgs[i]);
                    }
                    evParticipants = evParticipants.Distinct().ToList();
                    Event newEvent = new Event(evId, evName, evParticipants);
                    //check for id of event
                    var isIdExist = false;
                    var isNameExist = false;
                    foreach (Event item in events)
                    {
                        if (item.Id==evId)
                        {
                            if (item.Name==evName)
                            {
                                isIdExist = true;
                                isNameExist = true;
                                item.Participants.AddRange(evParticipants);
                                item.Participants = item.Participants.Distinct().ToList();
                                break;
                            }
                            else
                            {
                                isIdExist = true;
                                isNameExist = false;
                            }
                            
                        }
                    }
                    if (!isIdExist && !isNameExist)
                    {
                        //event id DOES NOT exist, add new event
                        events.Add(newEvent);
                    }

                }
                command = Console.ReadLine();
            }

            //output
            events = events.OrderByDescending(x => x.Participants.Count).ThenBy(x => x.Name).ToList();
            foreach (Event item in events)
            {
                Console.WriteLine(item.Name+" - "+item.Participants.Count);
                List<string> orderedParticipants = item.Participants.OrderBy(x=>x).ToList();
                for (int i = 0; i < orderedParticipants.Count; i++)
                {
                    Console.WriteLine($"@{orderedParticipants[i]}");
                }

            }
        }
    }
}
