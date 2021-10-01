using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex09ForceBook
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, List<string>> forceBook = new Dictionary<string, List<string>>();
            string command = Console.ReadLine();

            while (command!= "Lumpawaroo")
            {
                string[] commandLine = command.Split(" | ",StringSplitOptions.RemoveEmptyEntries).ToArray();
                string[] commandArrow = command.Split(" -> ", StringSplitOptions.RemoveEmptyEntries).ToArray();


                if (commandLine.Length>1)
                {
                    //format of commands {forceSide} | {forceUser}
                    string forceSide = commandLine[0];
                    string forceUser = commandLine[1];
                    AddLine(forceBook, forceSide, forceUser);

                }

                if (commandArrow.Length>1)
                {
                    //format of commands {forceUser} -> {forceSide}
                    string forceSide = commandArrow[1];
                    string forceUser = commandArrow[0];
                    AddArrow(forceBook, forceSide, forceUser);

                }

                command = Console.ReadLine();
            }

            // re order
            forceBook=forceBook.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            
            //output

            foreach (var item in forceBook)
            {
                if (item.Value.Count>0)
                {
                    Console.WriteLine($"Side: {item.Key}, Members: {item.Value.Count}");
                    item.Value.Sort();
                    foreach (var users in item.Value)
                    {
                        Console.WriteLine($"! {users}");
                    }
                }                
            }

        }

        private static Dictionary<string, List<string>> AddArrow(
            Dictionary<string, List<string>> forceBook,
            string forceSide,
            string forceUser)
        {
            //check if user exist in the whole dictionary
            bool isExist = false;
            string keyToBeDeleted = "";
            int listPositionToBeDeleted=0;
            foreach (var item in forceBook)
            {
                foreach (var users in item.Value)
                {
                    if (users==forceUser)
                    {
                        isExist = true;
                        //has to be removed and readded to the current forceside and forceuser
                        keyToBeDeleted = item.Key;
                        listPositionToBeDeleted = item.Value.FindIndex(x => x == users);
                        break;
                    }

                }
            }

            if (isExist)
            {
                //user exist, remove from dictionary
                forceBook[keyToBeDeleted].RemoveAt(listPositionToBeDeleted);

                //readd to dictionary !!! check if side is available?
                if (!forceBook.ContainsKey(forceSide))
                {
                    List<string> newListOfUsers = new List<string>();
                    newListOfUsers.Add(forceUser);
                    forceBook.Add(forceSide, newListOfUsers);
                }
                else
                {
                    forceBook[forceSide].Add(forceUser);

                }
                Console.WriteLine($"{forceUser} joins the {forceSide} side!");
            }
            else
            {
                //user doesnt exist
                if (!forceBook.ContainsKey(forceSide))
                {
                    List<string> newListOfUsers = new List<string>();
                    newListOfUsers.Add(forceUser);
                    forceBook.Add(forceSide, newListOfUsers);
                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                }
                else
                {
                    forceBook[forceSide].Add(forceUser);
                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                }

            }

            return forceBook;
        }

        private static Dictionary<string, List<string>> AddLine(
            Dictionary<string, List<string>> forceBook, 
            string forceSide, 
            string forceUser)
        {
            if (!forceBook.ContainsKey(forceSide))
            {
                // no such side => so no such user, add side and user
                List<string> newUser = new List<string>();
                newUser.Add(forceUser);
                forceBook.Add(forceSide, newUser);
            }
            else
            {
                //there is such side, check is user exists in the list, if not add him/her
                if (!forceBook[forceSide].Contains(forceUser))
                {
                    forceBook[forceSide].Add(forceUser);
                }
            }
            return forceBook;
        }
    }
}
