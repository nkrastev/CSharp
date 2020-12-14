using System;
using System.Collections.Generic;

namespace Ex04EvenTimes
{
    class Program
    {
        static void Main()
        {
            var countOfNumbers = int.Parse(Console.ReadLine());
            var numbers = new Dictionary<int, int>();
            for (int i = 0; i < countOfNumbers; i++)
            {
                var input = int.Parse(Console.ReadLine());
                if (numbers.ContainsKey(input))
                {
                    numbers[input]++;
                }
                else
                {
                    numbers.Add(input, 1);
                }
            }

            foreach (var item in numbers)
            {
                if (item.Value%2==0)
                {
                    Console.WriteLine(item.Key);
                }
            }
        }
    }
}
