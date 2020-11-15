using System;
using System.Collections.Generic;
using System.Linq;

namespace HotPotato
{
    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            int n = int.Parse(Console.ReadLine());

            Queue<string> children = new Queue<string>(input);
            
            while (children.Count>1)
            {
                for (int i =1 ; i < n; i++)
                {
                    children.Enqueue(children.Dequeue());                    
                }
                Console.WriteLine($"Removed {children.Dequeue()}");
            }
            Console.WriteLine($"Last is {children.Dequeue()}");

        }
    }
}
