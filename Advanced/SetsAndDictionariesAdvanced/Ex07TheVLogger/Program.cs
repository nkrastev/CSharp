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
                    //adding vlogger to list
                    var vloggerName = cmdArgs[0];
                    InsertVloggerToList(list, vloggerName);
                }
                else
                {
                    //adding followers
                    //{vloggername} followed {vloggername}
                    var userThatFollow = cmdArgs[0];
                    var followedUser = cmdArgs[2];
                    FollowingMethod(list, userThatFollow, followedUser);
                }

                command = Console.ReadLine();
            }

            PrintOutput(list);
        }
        private static void PrintOutput(List<Vlogger> list)
        {            
            Console.WriteLine($"The V-Logger has a total of {list.Count} vloggers in its logs.");
            list = list.OrderByDescending(x => x.Followers.Count).ThenBy(x => x.Following.Count).ToList();
            var counter = 1;
            foreach (Vlogger item in list)
            {
                Console.WriteLine($"{counter}. {item.Username} : {item.Followers.Count} followers, {item.Following.Count} following");
                if (counter == 1)
                {
                    List<string> firstFollowes = item.Followers.OrderBy(x => x).ToList();
                    
                    foreach (var follower in firstFollowes)
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }
                counter++;
            }
        }


        private static List<Vlogger> FollowingMethod(List<Vlogger> list, string userThatFollow, string followedUser)
        {
            //adding follower
            if (userThatFollow!=followedUser)
            {
                foreach (Vlogger item in list)
                {
                    if (item.Username == followedUser && list.Any(x => x.Username == followedUser) && list.Any(x => x.Username == userThatFollow))
                    {
                        item.Followers.Add(userThatFollow);
                    }
                    if (item.Username == userThatFollow && list.Any(x => x.Username == followedUser) && list.Any(x => x.Username == userThatFollow))
                    {
                        item.Following.Add(followedUser);
                    }
                }
            }            
            return list;
        }

        
        private static List<Vlogger> InsertVloggerToList(List<Vlogger> list, string vloggerName)
        {
            if (!list.Any(x=>x.Username==vloggerName))
            {
                //add new vlogger
                Vlogger newVlogger = new Vlogger(vloggerName, new HashSet<string>(), new HashSet<string>());
                list.Add(newVlogger);
            }
            return list;
        }
    }

    class Vlogger
    {
        //constructor
        public Vlogger(string username, HashSet<string> followers, HashSet<string> following)
        {
            Username = username;
            Followers = followers;
            Following = following;
        }
        //properties
        public string Username { get; set; }
        public HashSet<string> Followers { get; set; }
        public HashSet<string> Following { get; set; }

    }
}
