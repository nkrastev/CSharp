using System;
using System.Collections.Generic;
using System.Linq;

namespace Messaging
{
    class Program
    {
        static void Main()
        {
            List<string> chat = new List<string>();
            string command = Console.ReadLine();

            while (command!= "end")
            {
                string[] input = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                
                if (input[0]=="Chat")
                {
                    chat.Add(input[1]);
                }

                if (input[0]== "Delete")
                {
                    string messageToDelete = input[1];
                    if (chat.Contains(messageToDelete))
                    {
                        chat.RemoveAll(x => x == messageToDelete);
                    }
                }
               
                if (input[0]== "Edit")
                {
                    string messageToEdit = input[1];
                    string editedVersion = input[2];
                    if (chat.Contains(messageToEdit))
                    {
                        int index = chat.IndexOf(messageToEdit);
                        chat[index] = editedVersion;
                    }
                }
             
                if (input[0]=="Pin")
                {
                    string message = input[1];
                    if (chat.Contains(message))
                    {
                        chat.Remove(message);
                        chat.Add(message);
                    }
                }
           
                if (input[0]=="Spam")
                {
                    for (int i = 1; i < input.Length; i++)
                    {
                        chat.Add(input[i]);
                    }
                }
                command = Console.ReadLine();
            }
            //output
            foreach (var item in chat)
            {
                Console.WriteLine(item);
            }
        }
    }
}
