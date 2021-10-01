using System;
using System.Collections.Generic;
using System.Linq;

namespace ALab01CountRealNumbers
{
    class Program
    {
        static void Main()
        {
            List<double> input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToList();

            SortedDictionary<double, int> numbers = new SortedDictionary<double, int>();

            foreach (double item in input)
            {
                if (numbers.ContainsKey(item))
                {
                    numbers[item]++;
                }
                else
                {
                    numbers.Add(item, 1);
                }
            }

            foreach (var item in numbers)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
