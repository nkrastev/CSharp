using System;
using System.Collections.Generic;

namespace Ex05CountSymbols
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine();
            var result = new SortedDictionary<char, int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (result.ContainsKey(input[i]))
                {
                    result[input[i]]++;
                }
                else
                {
                    result.Add(input[i], 1);
                }
            }

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
