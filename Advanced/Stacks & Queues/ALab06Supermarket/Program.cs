using System;
using System.Collections.Generic;

namespace Supermarket
{
    class Program
    {
        static void Main()
        {
            Queue<string> people = new Queue<string>();
            string command = Console.ReadLine();

            while (command.ToLower()!="end")
            {
                if (command.ToLower()=="paid")
                {
                    Console.WriteLine(String.Join("\n",people));
                    people.Clear();
                }
                else
                {
                    people.Enqueue(command);
                }               
                command = Console.ReadLine();
            }
            Console.WriteLine($"{people.Count} people remaining.");
        }
    }
}
