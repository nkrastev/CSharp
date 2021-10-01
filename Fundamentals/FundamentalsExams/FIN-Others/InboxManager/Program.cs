using System;
using System.Collections.Generic;
using System.Linq;

namespace InboxManager
{
    class Program
    {
        static void Main()
        {
            List<User> list = new List<User>();
            var command = Console.ReadLine();
            while (command!= "Statistics")
            {
                var cmdArgs = command.Split("->", StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (cmdArgs[0]== "Add")
                {
                    AddUsername(list, cmdArgs[1]);
                }
                if (cmdArgs[0]== "Send")
                {
                    var username = cmdArgs[1];
                    var email = cmdArgs[2];
                    SendEmail(list, username, email);
                }
                if (cmdArgs[0]== "Delete")
                {
                    var username = cmdArgs[1];
                    DeleteUsername(list, username);
                }
                command = Console.ReadLine();
            }
            PrintOutput(list);
        }

        private static void PrintOutput(List<User> list)
        {
            Console.WriteLine($"Users count: {list.Count}");
            list = list.OrderByDescending(x => x.Emails.Count).ThenBy(x => x.Username).ToList();
            foreach (User item in list)
            {
                Console.WriteLine(item.Username);
                foreach (var mail in item.Emails)
                {
                    Console.WriteLine($" - {mail}");
                }
            }
        }

        private static List<User> DeleteUsername(List<User> list, string username)
        {
            var isExist = false;
            foreach (User item in list)
            {
                if (item.Username==username)
                {
                    isExist = true;
                    User userToBeRemoved = new User(username, new List<string>());
                    int index = list.FindIndex(x => x.Username==username);
                    list.RemoveAt(index);
                    break;
                }
            }
            if (!isExist)
            {
                Console.WriteLine($"{username} not found!");
            }
            return list;
        }

        private static List<User> SendEmail(List<User> list, string username, string email)
        {
            //o	Add the {Email} to the {username}'s collection of sent Emails.
            var isExist = false;            
            foreach (User item in list)
            {
                if (item.Username==username)
                {
                    isExist = true;
                    item.Emails.Add(email);
                    break;
                }
            }
            if (!isExist)
            {
                //user DOESNT exist, add new user with new mail
                List<string> newMails = new List<string>();
                newMails.Add(email);
                User newUser= new User(username, newMails);
            }
            return list;
        }

        private static List<User> AddUsername(List<User> list, string v)
        {
            var username = v;
            var isExist = false;
            foreach (User item in list)
            {
                if (item.Username==username)
                {
                    //user exists
                    Console.WriteLine($"{username} is already registered");
                    isExist = true;
                    break;
                }
            }
            if (!isExist)
            {                
                list.Add(new User(username, new List<string>()));
            }
            return list;
        }
    }
}
