using System;
using System.Collections.Generic;
using System.Linq;

namespace ALab01CountSameValuesinArray
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            var dict = new Dictionary<double, int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (dict.ContainsKey(input[i]))
                {
                    dict[input[i]]++;
                }
                else
                {
                    dict.Add(input[i], 1);
                }
            }
            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}
