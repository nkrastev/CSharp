using System;
using System.Collections.Generic;
using System.Linq;

namespace The_Final_Quest
{
    class Program
    {
        static void Main()
        {
            List<string> input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string comm = Console.ReadLine();

            while (comm != "Stop")
            {
                string[] command = comm.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (command[0] == "Delete")
                {
                    int index = int.Parse(command[1]);
                    if (index + 1 < input.Count && index + 1 > -1)
                    {
                        input.RemoveAt(index + 1);
                    }
                }

                if (command[0] == "Swap")
                {
                    int index1 = input.IndexOf(command[1]);
                    int index2 = input.IndexOf(command[2]);
                    string word1 = command[1];
                    string word2 = command[2];

                    if (input.Contains(command[1]) && input.Contains(command[2]))
                    {

                        input[index1] = word2;
                        input[index2] = word1;
                    }
                }

                if (command[0] == "Put")
                {
                    string word = command[1];
                    int index = int.Parse(command[2]);

                    if (index > 0 && index <= input.Count + 1)
                    {
                        input.Insert(index - 1, word);
                    }
                }

                if (command[0] == "Sort")
                {
                    input = input.OrderByDescending(i => i).ToList();
                }

                if (command[0] == "Replace")
                {
                    string word1 = command[1];
                    string word2 = command[2];

                    int index2 = input.IndexOf(word2);

                    if (index2 != -1)
                    {
                        input[index2] = word1;
                    }
                }                

                comm = Console.ReadLine();
            }

            Console.WriteLine(String.Join(" ", input));

        }
    }
}
