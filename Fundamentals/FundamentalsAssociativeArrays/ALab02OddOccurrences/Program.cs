using System;
using System.Collections.Generic;
using System.Linq;

namespace ALab02OddOccurrences
{
    class Program
    {
        static void Main()
        {
            List<string> input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Dictionary<string, int> result = new Dictionary<string, int>();

            for (int i = 0; i < input.Count; i++)
            {
                if (!result.ContainsKey(input[i].ToLower()))
                {
                    result.Add(input[i].ToLower(), 1);
                }
                else
                {
                    result[input[i].ToLower()]++;
                }
            }

            foreach (var item in result)
            {
                if (item.Value %2!=0)
                {
                    Console.Write(item.Key+" ");
                }
            }
        }
    }
}
