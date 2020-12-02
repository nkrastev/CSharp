using System;
using System.Linq;

namespace Ex06JaggedArrayManipulator
{
    class Program
    {
        static void Main()
        {
            var numberRows = int.Parse(Console.ReadLine());
            double[][] jagged = new double[numberRows][];
            
            ReadJaggedArray(jagged,numberRows);
            AnalyzeJaggedAdday(jagged);

            var instructions = Console.ReadLine();
            while (instructions!="End")
            {
                //commands
                var commands = instructions.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (commands.Length==4)
                {
                    var cmdRow = int.Parse(commands[1]);
                    var cmdCol = int.Parse(commands[2]);
                    var cmdValue = int.Parse(commands[3]);
                    var action = commands[0];
                    ManululateJagged(jagged, cmdRow, cmdCol, cmdValue, action);
                }
                
                instructions = Console.ReadLine();
            }

            PrintMatrix(jagged);
        }

        private static double[][] ManululateJagged(double[][] jagged, int cmdRow, int cmdCol, int cmdValue, string action)
        {
            if (
                cmdRow>=0 &&
                cmdRow<jagged.Length &&
                jagged[cmdRow].Length>cmdCol
                )
            {
                if (action=="Add")
                {
                    jagged[cmdRow][cmdCol] += cmdValue;
                }
                if (action== "Subtract")
                {
                    jagged[cmdRow][cmdCol] -= cmdValue;
                }
                
            }

            return jagged;
        }

        private static void PrintMatrix(double[][] jagged)
        {
            for (int row = 0; row < jagged.Length; row++)
            {
                for (int col = 0; col < jagged[row].Length; col++)
                {
                    Console.Write(jagged[row][col]+" ");
                }
                Console.WriteLine();
            }
        }

        private static double[][] AnalyzeJaggedAdday(double[][] jagged)
        {
            for (int row = 0; row < jagged.Length-1; row++)
            {
                if (jagged[row].Length==jagged[row+1].Length)
                {
                    for (int i = 0; i < jagged[row].Length; i++)
                    {
                        jagged[row][i] *= 2;
                        jagged[row+1][i] *= 2;
                    }
                }
                else
                {
                    for (int i = 0; i < jagged[row].Length; i++)
                    {
                        jagged[row][i] /= 2; 
                    }
                    for (int i = 0; i < jagged[row+1].Length; i++)
                    {
                        jagged[row+1][i] /= 2;
                    }
                }
            }
            return jagged;
        }

        private static double[][] ReadJaggedArray(double[][] jagged, int num)
        {
            for (int row = 0; row < num; row++)
            {
                jagged[row] = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            }
            return jagged;
        }
    }
}
