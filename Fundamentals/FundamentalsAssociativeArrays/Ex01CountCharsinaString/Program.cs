using System;
using System.Collections.Generic;

namespace Ex01CountCharsinaString
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();

            Dictionary<char, int> dictionary = new Dictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i]!=' ')
                {
                    if (!dictionary.ContainsKey(input[i]))
                    {
                        dictionary.Add(input[i], 1);
                    }
                    else
                    {
                        dictionary[input[i]]++;
                    }

                }
            }

            foreach (var item in dictionary)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
