using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex02SetsofElements
{
    class Program
    {
        static void Main()
        {
            var numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var firstLenght = numbers[0];
            var secondLenght = numbers[1];
            var firstSet = new List<int>();
            var secondSet = new List<int>();
            var result = new HashSet<int>();

            for (int i = 0; i < firstLenght; i++)
            {
                firstSet.Add(int.Parse(Console.ReadLine()));
            }
            for (int i = 0; i < secondLenght; i++)
            {
                secondSet.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < firstSet.Count; i++)
            {
                if (secondSet.Contains(firstSet[i]))
                {
                    result.Add(firstSet[i]);
                }
            }
            for (int i = 0; i < secondSet.Count; i++)
            {
                if (firstSet.Contains(secondSet[i])) 
                {
                    result.Add(secondSet[i]);
                }
            }
            if (result.Count>0)
            {
                Console.WriteLine(String.Join(" ",result));
            }
        }
    }
}
