using System;
using System.Collections.Generic;
using System.Linq;

namespace SongsQueue
{
    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            Queue<string> queueSongs = new Queue<string>(input);

            while (queueSongs.Count>0)
            {
                string command = Console.ReadLine();

                if (command=="Play")
                {
                    queueSongs.Dequeue();
                }

                if (command.Contains("Add"))
                {
                    string commandItems = command.Substring(4, command.Length - 4);

                    if (queueSongs.Contains(commandItems))
                    {
                        Console.WriteLine($"{commandItems} is already contained!");
                    }
                    else
                    {
                        queueSongs.Enqueue(commandItems);
                    }
                }

                if (command=="Show")
                {
                    Console.WriteLine(String.Join(", ",queueSongs));
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
