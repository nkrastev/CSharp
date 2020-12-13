using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex03PeriodicTable
{
    class Program
    {
        static void Main()
        {
            var result = new SortedSet<string>();
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int j = 0; j < input.Length; j++)
                {
                    result.Add(input[j]);
                }
            }
            Console.WriteLine(String.Join(" ",result));
        }
    }
}
