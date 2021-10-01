using System;
using System.Collections.Generic;
using System.Linq;

namespace ALab04Largest3Numbers
{
    class Program
    {
        static void Main()
        {
            List<int> input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            input.Sort();
            input.Reverse();

            if (input.Count>=3)
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.Write(input[i]+" ");
                }
            }
            else
            {
                foreach (var item in input)
                {
                    Console.Write(item+" ");
                }
            }
        }
    }
}
