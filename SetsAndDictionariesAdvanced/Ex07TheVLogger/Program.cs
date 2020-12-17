using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex07TheVLogger
{
    class Program
    {
        static void Main()
        {
            List<Vlogger> list = new List<Vlogger>();
            var command = Console.ReadLine();
            while (command!= "Statistics")
            {
                var cmdArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (cmdArgs[1]== "joined")
                {
                    var vloggerName = cmdArgs[0];
                    InsertVloggerToList(list, vloggerName);
                }
                command = Console.ReadLine();
            }

            PrintOutput(list);
        }

        private static void PrintOutput(List<Vlogger> list)
        {
            Console.WriteLine($"The V-Logger has a total of {list.Count} vloggers in its logs.");
            foreach (Vlogger item in list)
            {
                Console.WriteLine($"{item.Username}");
            }
        }

        private static List<Vlogger> InsertVloggerToList(List<Vlogger> list, string vloggerName)
        {
            if (!list.Any(x=>x.Username==vloggerName))
            {
                //add new vlogger
                Vlogger newVlogger = new Vlogger(vloggerName, new List<string>(), new List<string>());
                list.Add(newVlogger);
            }
            return list;
        }
    }

    class Vlogger
    {
        //constructor
        public Vlogger(string username, List<string> followers, List<string> following)
        {
            Username = username;
            Followers = followers;
            Following = following;
        }
        //properties
        public string Username { get; set; }
        public List<string> Followers { get; set; }
        public List<string> Following { get; set; }

    }
}
