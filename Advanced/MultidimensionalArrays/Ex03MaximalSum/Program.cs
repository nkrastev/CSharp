using System;
using System.Linq;

namespace Ex03MaximalSum
{
    class Program
    {
        static void Main()
        {
            int[,] matrix = ReadMatrix();
            int maxSum = int.MinValue;
            int maxRow = 0;
            int maxCol = 0;

            for (int row = 0; row < matrix.GetLength(0)-2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1)-2; col++)
                {
                    //calculate square sum og 3x3
                    var currentSum = Calculate3x3(matrix, row, col);
                    if (currentSum>maxSum)
                    {
                        maxSum = currentSum;
                        maxRow = row;
                        maxCol = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");
            PrintSubMatrix(matrix, maxRow, maxCol);

        }

        private static void PrintSubMatrix(int[,] matrix, int maxRow, int maxCol)
        {
            for (int row = maxRow; row < maxRow+3; row++)
            {
                for (int col = maxCol; col < maxCol+3; col++)
                {
                    Console.Write(matrix[row,col]+" ");
                }
                Console.WriteLine();
            }
        }

        private static int Calculate3x3(int[,] matrix, int row, int col)
        {
            var sum = 0;
            for (int i = row; i < row+3; i++)
            {
                for (int j = col; j < col+3; j++)
                {
                    sum += matrix[i, j];
                }
            }


            return sum;
        }

        public static int[,] ReadMatrix()
        {
            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var rows = input[0];
            var cols = input[1];
            int[,] intMatrix = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                var currentCol = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int j = 0; j < cols; j++)
                {
                    intMatrix[i, j] = currentCol[j];
                }
            }
            return intMatrix;
        }
    }
}
