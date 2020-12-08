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
            var coalsCount = FindCoals(matrix);
            var startPosition = FindStart(matrix);
            StartMoving(matrix, commands, coalsCount, startPosition);
        }      

        private static void StartMoving(char[,] matrix, string[] commands, int coals, string startPosition)
        {
            //Console.WriteLine("Coals="+coals);
            //Console.WriteLine("Start="+ startPosition);
            var foundCoals = 0;
            var isEndCommand = false;
            var positions = startPosition.Split(",", StringSplitOptions.RemoveEmptyEntries).ToArray();
            var currentRow = int.Parse(positions[0]);
            var currentCol = int.Parse(positions[1]);

            for (int i = 0; i < commands.Length; i++)
            {
                //movements
                if (commands[i]=="up" && currentRow>0)
                {
                    currentRow -= 1;
                }
                if (commands[i]=="down" && currentRow+1<matrix.GetLength(0))
                {
                    currentRow += 1;
                }
                if (commands[i]=="left" && currentCol>0)
                {
                    currentCol -= 1;
                }
                if (commands[i]=="right" && currentCol+1<matrix.GetLength(0))
                {
                    currentCol += 1;
                }
                //new position conditions
                if (matrix[currentRow,currentCol]=='e')
                {
                    Console.WriteLine($"Game over! ({currentRow}, {currentCol})");
                    isEndCommand = true;
                    break;
                }
                if (matrix[currentRow, currentCol] =='c')
                {
                    foundCoals++;
                    matrix[currentRow, currentCol] = '*';
                }
                if (foundCoals==coals)
                {
                    Console.WriteLine($"You collected all coals! ({currentRow}, {currentCol})");
                    break;
                }
            }
            if (coals>foundCoals && !isEndCommand)
            {
                Console.WriteLine($"{coals-foundCoals} coals left. ({currentRow}, {currentCol})");
            }
        }
        private static string FindStart(char[,] matrix)
        {
            var startCoordinates = string.Empty;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 's')
                    {
                        startCoordinates = row.ToString() + ',' + col;
                    }
                }
            }
            return startCoordinates;
        }
        private static int FindCoals(char[,] matrix)
        {
            var coalNumber = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row,col]=='c')
                    {
                        coalNumber++;
                    }
                }
            }
            return coalNumber;
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
