using System;
using System.Collections.Generic;
using System.Linq;

namespace SeashellTreasure
{
    class Program
    {
        static void Main()
        {
            List<char> collected = new List<char>();
            int stolen = 0;            
            char[][] beach = ReadBeach();

            string input = Console.ReadLine();
            while (input != "Sunset")
            {
                string[] splittedInput = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = splittedInput[0];
                int row = int.Parse(splittedInput[1]);
                int col = int.Parse(splittedInput[2]);

                if (command == "Collect")
                {
                    if (row >= 0 && row < beach.Length && col >= 0 && col < beach[row].Length)
                    {
                        if (beach[row][col] != '-')
                        {
                            collected.Add(beach[row][col]);
                            beach[row][col] = '-';
                        }
                    }
                }

                if (command == "Steal")
                {
                    string direction = splittedInput[3];
                    if (row >= 0 && row < beach.Length && col >= 0 && col < beach[row].Length)
                    {
                        if (direction == "down")
                        {
                            for (int i = row; i <= row + 3; i++)
                            {
                                if (i >= 0 && i < beach.Length && col >= 0 && col < beach[i].Length && beach[i][col] != '-')
                                {
                                    stolen++;
                                    beach[i][col] = '-';
                                }
                            }
                        }
                        else if (direction == "up")
                        {
                            for (int i = row; i >= row - 3; i--)
                            {
                                if (i >= 0 && i < beach.Length && col >= 0 && col < beach[i].Length && beach[i][col] != '-')
                                {
                                    stolen++;
                                    beach[i][col] = '-';
                                }
                            }
                        }
                        else if (direction == "right")
                        {
                            for (int i = col; i <= beach[row].Length; i++)
                            {
                                if (row >= 0 && row < beach.Length && i >= 0 && i < beach[row].Length && beach[row][i] != '-')
                                {
                                    stolen++;
                                    beach[row][i] = '-';
                                }
                            }
                        }
                        else if (direction == "left")
                        {
                            for (int i = col; i >= col - 3; i--)
                            {
                                if (row >= 0 && row < beach.Length && i >= 0 && i < beach[row].Length && beach[row][i] != '-')
                                {
                                    stolen++;
                                    beach[row][i] = '-';
                                }
                            }
                        }
                    }
                }

                input = Console.ReadLine();
            }

            //output

            foreach (var ins in beach)
            {
                Console.WriteLine(string.Join(" ", ins));
            }
            if (collected.Count != 0)
            {
                Console.Write($"Collected seashells: {collected.Count} -> ");
                Console.Write(string.Join(", ", collected));
                Console.WriteLine();
                Console.WriteLine($"Stolen seashells: { stolen}");
            }
            else
            {
                Console.WriteLine($"Collected seashells: {collected.Count}");
                Console.WriteLine($"Stolen seashells: { stolen}");
            }
        }

        private static char[][] ReadBeach()
        {
            var size = int.Parse(Console.ReadLine());
            var beach = new char[size][];
            for (int row = 0; row < size; row++)
            {
                char[] currentRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                beach[row] = new char[currentRow.Length];
                for (int col = 0; col < beach[row].Length; col++)
                {
                    beach[row][col] = currentRow[col];
                }
            }
            return beach;
        }
    }
}