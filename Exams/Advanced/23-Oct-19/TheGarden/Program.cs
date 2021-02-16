using System;
using System.Collections.Generic;
using System.Linq;

namespace TheGarden
{
    class StartUp
    {
        static void Main()
        {
            char[][] matrix = ReadField();
            Dictionary<string, int> harvestResults = new Dictionary<string, int>
            {
                { "Carrots", 0},
                { "Potatoes", 0},
                { "Lettuce", 0},
                { "Harmed vegetables", 0}
            };

            var command = Console.ReadLine();
            while (command != "End of Harvest")
            {
                var cmdArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (cmdArgs[0] == "Harvest")
                {
                    var harvesterRow = int.Parse(cmdArgs[1]);
                    var harvesterCol = int.Parse(cmdArgs[2]);

                    if (ValidCoodrinates(matrix, harvesterRow, harvesterCol) && matrix[harvesterRow][harvesterCol] != ' ')
                    {
                        if (matrix[harvesterRow][harvesterCol] == 'C')
                        {
                            harvestResults["Carrots"]++;
                        }
                        else if (matrix[harvesterRow][harvesterCol] == 'P')
                        {
                            harvestResults["Potatoes"]++;
                        }
                        else if (matrix[harvesterRow][harvesterCol] == 'L')
                        {
                            harvestResults["Lettuce"]++;
                        }
                        matrix[harvesterRow][harvesterCol] = ' ';
                    }
                }

                if (cmdArgs[0] == "Mole")
                {
                    var moleRow = int.Parse(cmdArgs[1]);
                    var moleCol = int.Parse(cmdArgs[2]);
                    var directionMole = cmdArgs[3];
                    
                    for (int i = 0; i < matrix.Length; i++)
                    {
                        for (int j = 0; j < matrix[i].Length; j++)
                        {
                            if (i == moleRow && j == moleCol && matrix[i][j] != ' ')
                            {
                                if (directionMole == "up")
                                {
                                    for (int k = moleRow; k >= 0; k -= 2)
                                    {
                                        if (matrix[k][moleCol] != ' ')
                                        {
                                            matrix[k][moleCol] = ' ';
                                            harvestResults["Harmed vegetables"]++;
                                        }
                                    }
                                }

                                if (directionMole == "down")
                                {
                                    for (int k = moleRow; k < matrix.Length; k += 2)
                                    {
                                        if (matrix[k][moleCol] != ' ')
                                        {
                                            matrix[k][moleCol] = ' ';
                                            harvestResults["Harmed vegetables"]++;
                                        }
                                    }
                                }

                                if (directionMole == "right")
                                {
                                    for (int k = moleCol; k < matrix[i].Length; k += 2)
                                    {
                                        if (matrix[moleRow][k] != ' ')
                                        {
                                            matrix[moleRow][k] = ' ';
                                            harvestResults["Harmed vegetables"]++;
                                        }
                                    }
                                }

                                if (directionMole == "left")
                                {
                                    for (int k = moleCol; k >= 0; k -= 2)
                                    {
                                        if (matrix[moleRow][k] != ' ')
                                        {
                                            matrix[moleRow][k] = ' ';
                                            harvestResults["Harmed vegetables"]++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                command = Console.ReadLine();
            }
            Print(matrix);
            PrintHarvestResults(harvestResults);
        }

        private static void PrintHarvestResults(Dictionary<string, int> harvestResults)
        {
            foreach (var item in harvestResults)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }

        private static bool ValidCoodrinates(char[][] matrix, int checkedRow, int checkedCol)
        {
            if (
                checkedRow >= 0 &&
                checkedCol >= 0 &&
                checkedRow < matrix.Length &&
                checkedCol < matrix[checkedRow].Length
                )
            {
                return true;
            }
            else return false;
        }

        private static void Print(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col] + " ");
                }
                Console.WriteLine();
            }
        }

        private static char[][] ReadField()
        {
            var size = int.Parse(Console.ReadLine());
            var matrix = new char[size][];
            for (int row = 0; row < size; row++)
            {
                var line = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                matrix[row] = new char[line.Length];
                for (int col = 0; col < line.Length; col++)
                {
                    matrix[row][col] = line[col];
                }

            }
            return matrix;
        }
    }
}