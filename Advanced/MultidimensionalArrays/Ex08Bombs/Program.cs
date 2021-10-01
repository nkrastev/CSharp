using System;
using System.Linq;

namespace Ex08Bombs
{
    class Program
    {
        static void Main()
        {
            int[,] matrix = ReadMatrix();
            //row1,column1  row2,column2  
            string[] bombCoordinates = ReadBombCoordinates();
            //check coordinates and detonate bombs
            for (int i = 0; i < bombCoordinates.Length; i++)
            {
                //coordinates combine row1,col1
                var coordinates = bombCoordinates[i].Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                var bombRow = coordinates[0];
                var bombCol = coordinates[1];                
                DetonateBomb(matrix, bombRow, bombCol);                                
            }
            PrintMatrix(matrix);

        }

        private static void PrintMatrix(int[,] matrix)
        {
            var activeCells = 0;
            var sum = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row,col]>0)
                    {
                        activeCells++;
                        sum += matrix[row, col];
                    }
                }
            }
            Console.WriteLine($"Alive cells: {activeCells}");
            Console.WriteLine($"Sum: {sum}");

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col]+" ");                    
                }
                Console.WriteLine();
            }
            
        }

        private static int[,] DetonateBomb(int[,] matrix, int bombRow, int bombCol)
        {
            var bombValue = matrix[bombRow, bombCol];
            if (bombValue>0)
            {
                //cell can explode
                matrix[bombRow, bombCol] = 0;
                var mSize = matrix.GetLength(0);//matrix is square, all dimensions are equal
                //explode upper row
                if (bombRow - 1 >= 0 && bombRow - 1 < mSize)
                {
                    if ( bombCol - 1 >= 0 && bombCol - 1 < mSize)
                    {
                        if (matrix[bombRow - 1, bombCol - 1] > 0)
                        {
                            matrix[bombRow - 1, bombCol - 1] -= bombValue;
                        }
                    }
                    if (bombCol >= 0 && bombCol < mSize)
                    {
                        if (matrix[bombRow - 1, bombCol] > 0)
                        {
                            matrix[bombRow - 1, bombCol] -= bombValue;
                        }
                    }
                    if (bombCol+1 >= 0 && bombCol+1 < mSize)
                    {
                        if (matrix[bombRow - 1, bombCol+1] > 0)
                        {
                            matrix[bombRow - 1, bombCol+1] -= bombValue;
                        }
                    }
                }
                //explode current row
                if (bombRow>= 0 && bombRow< mSize)
                {
                    if (bombCol - 1 >= 0 && bombCol - 1 < mSize)
                    {
                        if (matrix[bombRow, bombCol - 1] > 0)
                        {
                            matrix[bombRow, bombCol - 1] -= bombValue;
                        }
                    }                    
                    if (bombCol + 1 >= 0 && bombCol + 1 < mSize)
                    {
                        if (matrix[bombRow, bombCol + 1] > 0)
                        {
                            matrix[bombRow, bombCol + 1] -= bombValue;
                        }
                    }
                }
                //exploder lower row
                if (bombRow + 1 >= 0 && bombRow +1 < mSize)
                {
                    if (bombCol - 1 >= 0 && bombCol - 1 < mSize)
                    {
                        if (matrix[bombRow + 1, bombCol - 1] > 0)
                        {
                            matrix[bombRow + 1, bombCol - 1] -= bombValue;
                        }
                    }
                    if (bombCol >= 0 && bombCol < mSize)
                    {
                        if (matrix[bombRow + 1, bombCol] > 0)
                        {
                            matrix[bombRow + 1, bombCol] -= bombValue;
                        }
                    }
                    if (bombCol + 1 >= 0 && bombCol + 1 < mSize)
                    {
                        if (matrix[bombRow + 1, bombCol + 1] > 0)
                        {
                            matrix[bombRow + 1, bombCol + 1] -= bombValue;
                        }
                    }
                }

            }
            return matrix;
        }

        private static string[] ReadBombCoordinates()
        {
            var input = Console.ReadLine();
            var bombs = input.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries).ToArray();           
            return bombs;
        }

        private static int[,] ReadMatrix()
        {
            var input = int.Parse(Console.ReadLine());
           
            int[,] intMatrix = new int[input, input];

            for (int i = 0; i < input; i++)
            {
                var currentCol = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int j = 0; j < input; j++)
                {
                    intMatrix[i, j] = currentCol[j];
                }
            }
            return intMatrix;
        }
    }
}
