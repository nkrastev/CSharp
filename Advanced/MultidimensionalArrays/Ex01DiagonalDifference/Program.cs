using System;
using System.Linq;

namespace Ex01DiagonalDifference
{
    class Program
    {
        static void Main()
        {
            int[,] matrix = ReadMatrix();
            int primary = CalculatePrimary(matrix);
            int secondary = CalculateSecondary(matrix);
            
            Console.WriteLine(Math.Abs(primary-secondary));
        }

        private static int CalculateSecondary(int[,] matrix)
        {
            int secondary = 0;
            int col = 0;
            for (int row = matrix.GetLength(0)-1; row >=0 ; row--)
            {
                secondary+=(matrix[row,col]);
                col++;
            }

            return secondary;
        }

        private static int CalculatePrimary(int[,] matrix)
        {
            int primary = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (row==col)
                    {
                        primary += matrix[row, col];
                    }
                }
            }
            return primary;
        }

        public static int[,] ReadMatrix()
        {
            //square matrix
            var matrixSize = int.Parse(Console.ReadLine());
            var rows = matrixSize;
            var cols = matrixSize;
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
