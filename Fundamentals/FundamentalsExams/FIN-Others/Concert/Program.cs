using System;
using System.Collections.Generic;
using System.Linq;

namespace Concert
{
    class Program
    {
        static void Main()
        {
            List<Band> bands = new List<Band>();
            var command = Console.ReadLine();

            while (command!= "start of concert")
            {                
                var cmdArgs = command.Split("; ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (cmdArgs[0]=="Add")
                {
                    AddBand(bands, cmdArgs);
                }
                if (cmdArgs[0]== "Play")
                {
                    PlayBand(bands, cmdArgs);
                }
                command = Console.ReadLine();
            }
            var allMembers = Console.ReadLine();
            PrintOutput(bands, allMembers);                  
        }              

        private static void PrintOutput(List<Band> bands, string allMembers)
        {
            int totalTime = 0;
            foreach (Band item in bands)
            {
                totalTime += item.Time;
            }
            Console.WriteLine($"Total time: {totalTime}");

            //print bands with time
            bands = bands.OrderByDescending(x => x.Time).ThenBy(x => x.Name).ToList();
            foreach (Band item in bands)
            {
                Console.WriteLine(item.Name+" -> "+item.Time);
            }
            //print band members
            foreach (Band item in bands)
            {
                if (item.Name==allMembers)
                {
                    Console.WriteLine(item.Name);
                    for (int i = 0; i < item.Members.Count; i++)
                    {
                        Console.WriteLine("=> " + item.Members[i]);
                    }
                }
            }
        }

        private static List<Band> PlayBand(List<Band> bands, string[] cmdArgs)
        {
            //Play; {bandName}; {time}" 
            bool isBandInList = false;
            Band newBand = new Band(cmdArgs[1], int.Parse(cmdArgs[2]), new List<string>());
            foreach (Band item in bands)
            {
                if (item.Name==cmdArgs[1])
                {
                    //band exist, just add the time
                    item.Time += int.Parse(cmdArgs[2]);
                    isBandInList = true;
                }
            }
            if (!isBandInList)
            {
                bands.Add(newBand);
            }

            return bands;
        }

        private static List<Band> AddBand(List<Band> bands, string[] cmdArgs)
        {
            //Add; {bandName}; {member 1}, {member 2}, {member 3}                        
            Band newBand = new Band(cmdArgs[1], 0, cmdArgs[2].Split(", ").Distinct().ToList());
            bool bandExists = false;
            foreach (Band item in bands)
            {
                if (item.Name== cmdArgs[1])
                {
                    //band exists, add all new members, filter unique
                    bandExists = true;
                    item.Members.AddRange(cmdArgs[2].Split(", ").Distinct().ToList());
                    item.Members = item.Members.Distinct().ToList();
                }
            }
            if (!bandExists)
            {
                bands.Add(newBand);
            }            
            return bands;
        }
    }

    class Band
    {
        //constructor
        public Band(string name, int time, List<string> members)
        {
            Name = name;
            Time = time;
            Members = members;
        }
        //properties
        public string Name { get; set; }
        public int Time { get; set; }
        public List<string> Members { get; set; }
    }
}
