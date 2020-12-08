using System;
using System.Linq;

namespace Ex09Miner
{
    class Program
    {
        static void Main()
        {
            var lines = int.Parse(Console.ReadLine());            
            string[] commands = ReadCommands();
            char[,] matrix = ReadField(lines);
            StartMoving(matrix, commands);
        }

        private static void StartMoving(char[,] matrix, string[] commands)
        {
            
        }

        private static string[] ReadCommands()
        {
            var commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            return commands;
        }

        private static char[,] ReadField(int lines)
        {           
            char[,] charMatrix = new char[lines, lines];

            for (int i = 0; i < lines; i++)
            {
                var currentCol = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int j = 0; j < lines; j++)
                {
                    charMatrix[i, j] = currentCol[j];
                }
            }
            return charMatrix;
        }
    }
}
